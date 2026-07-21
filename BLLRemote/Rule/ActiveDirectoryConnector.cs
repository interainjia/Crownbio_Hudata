using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.DirectoryServices.AccountManagement;
using Crownbio.BLL.Rule;
using System.Web;
using System.Web.Hosting;
using System.DirectoryServices;
using System.Configuration;
using System.DirectoryServices.Protocols;

namespace Crownbio.BLL.Rule
{
    // 专门表示"该域里确实找不到这个账号"，与密码错误/账号锁定等其他失败原因区分开，
    // 便于 IsUserLoggedIn 在多域尝试时挑选更有信息量的错误对外抛出。
    public class ActiveDirectoryUserNotFoundException : Exception
    {
        public ActiveDirectoryUserNotFoundException(string message) : base(message) { }
        public ActiveDirectoryUserNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    public static class ActiveDirectoryConnector
    {
        #region Member Variables

        private static ActiveDirectoryConfiguration _currentActiveDirectoryConfiguration = null;

        #endregion

        #region Properties

        private static ActiveDirectoryConfiguration activeDirectorySettings = null;
        public static ActiveDirectoryConfiguration ActiveDirectorySettings
        {
            get
            {
                try
                {
                    if (activeDirectorySettings == null)
                    {
                        activeDirectorySettings = (ActiveDirectoryConfiguration)ConfigurationManager.GetSection("ldapConfiguration");
                    }
                }
                catch (Exception ex)
                {
                }
                return activeDirectorySettings;
            }
        }

        // 新域（crownbio.cn），在 web.config 中通过独立的 "ldapConfigurationCn" 节点配置。
        // 在配置补充之前，GetSection 会返回 null，IsUserLoggedIn 会自动忽略该域，行为与改造前一致。
        private static ActiveDirectoryConfiguration activeDirectorySettingsCn = null;
        public static ActiveDirectoryConfiguration ActiveDirectorySettingsCn
        {
            get
            {
                try
                {
                    if (activeDirectorySettingsCn == null)
                    {
                        activeDirectorySettingsCn = (ActiveDirectoryConfiguration)ConfigurationManager.GetSection("ldapConfigurationCn");
                    }
                }
                catch (Exception ex)
                {
                }
                return activeDirectorySettingsCn;
            }
        }

        #endregion

        #region Methods

        // UC 用户中心接口不可用（网络异常/超时/响应格式异常等）时用来触发回退到本地 LDAP 校验，
        // 与 UC 明确返回"账号密码不对"这类判定结果区分开，避免把网络问题误判成校验失败。
        private class UcUnavailableException : Exception
        {
            public UcUnavailableException(string message, Exception innerException) : base(message, innerException) { }
        }

        public static bool IsUserLoggedIn(string userName, string password)
        {
            try
            {
                return AuthenticateAgainstUc(userName, password);
            }
            catch (ActiveDirectoryUserNotFoundException) { throw; }
            catch (UcUnavailableException)
            {
                // UC 接口打不通时回退到本地 LDAP 校验兜底，其余情况（UC 明确返回密码错误等）直接向上抛出。
                return IsUserLoggedInViaLdap(userName, password);
            }
        }

        // 调用用户中心(UC)登录接口验证账号密码；UC 已知会用 po 参数对域账号做 AD 绑定校验，
        // 因此这里不再需要区分域账号/本地账号，统一交给 UC 处理。
        private static bool AuthenticateAgainstUc(string userName, string password)
        {
            string apiUrl = ConfigurationManager.AppSettings["UcApiUrl"];
            if (string.IsNullOrEmpty(apiUrl))
            {
                throw new UcUnavailableException("UcApiUrl is not configured.", null);
            }
            string apiKey = ConfigurationManager.AppSettings["UcApiKey"];

            int at = userName.IndexOf("@");
            string account = at >= 0 ? userName.Substring(0, at) : userName;

            string pwd = Crownbio.Utility.SecureHelper.GetSHA1(password).ToLower();
            string po = string.IsNullOrEmpty(apiKey) ? string.Empty : Crownbio.Utility.SecureHelper.EncPwd(password, apiKey);
            string sid = HttpContext.Current != null && HttpContext.Current.Session != null
                ? HttpContext.Current.Session.SessionID
                : Guid.NewGuid().ToString();

            string url = string.Format("{0}/syswebapi/sysuserapi/login?u={1}&p={2}&po={3}&sid={4}&lang=en",
                apiUrl.TrimEnd('/'), Uri.EscapeDataString(account), Uri.EscapeDataString(pwd), Uri.EscapeDataString(po), Uri.EscapeDataString(sid));

            string responseText;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Timeout = 5000;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseText = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new UcUnavailableException("Failed to call UC login api.", ex);
            }

            if (string.IsNullOrEmpty(responseText))
            {
                throw new UcUnavailableException("UC login api returned an empty response.", null);
            }

            Match messageMatch = Regex.Match(responseText, "\"message\"\\s*:\\s*\"([^\"]*)\"");
            if (!messageMatch.Success)
            {
                // 没有 message 字段，说明返回的是合法 token，账号密码校验通过。
                return true;
            }

            string message = messageMatch.Groups[1].Value;
            if (message.IndexOf("not exist", StringComparison.OrdinalIgnoreCase) >= 0
                || message.IndexOf("not found", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                throw new ActiveDirectoryUserNotFoundException("User [" + userName + "] not found via UC login api: " + message);
            }
            throw new Exception(message);
        }

        private static bool IsUserLoggedInViaLdap(string userName, string password)
        {
            // 新域优先尝试，旧域兜底；未配置 ldapConfigurationCn 时该域会被自动跳过。
            List<ActiveDirectoryConfiguration> domainConfigs = new List<ActiveDirectoryConfiguration>();
            if (ActiveDirectorySettingsCn != null)
            {
                domainConfigs.Add(ActiveDirectorySettingsCn);
            }
            if (ActiveDirectorySettings != null)
            {
                domainConfigs.Add(ActiveDirectorySettings);
            }

            bool anyEnabled = false;
            foreach (ActiveDirectoryConfiguration cfg in domainConfigs)
            {
                if (cfg.Enabled)
                {
                    anyEnabled = true;
                    break;
                }
            }
            if (!anyEnabled)
            {
                return true;
            }

            int startIndex = userName.IndexOf("@");
            if (startIndex >= 0)
            {
                userName = userName.Substring(0, startIndex);
            }

            bool lastResult = false;
            Exception lastException = null;

            foreach (ActiveDirectoryConfiguration settings in domainConfigs)
            {
                if (!settings.Enabled)
                {
                    continue;
                }
                try
                {
                    bool success = AuthenticateAgainstDomain(settings, userName, password);
                    if (success)
                    {
                        return true;
                    }
                    lastResult = false;
                }
                catch (ActiveDirectoryUserNotFoundException ex)
                {
                    // "账号不存在"信息量最低，只有在还没有更具体的错误时才记录，
                    // 避免后面某个域返回"密码错误"之类的具体原因被它覆盖掉。
                    if (lastException == null)
                    {
                        lastException = ex;
                    }
                    lastResult = false;
                }
                catch (Exception ex)
                {
                    // 密码错误、账号锁定/过期等具体原因，优先级高于"账号不存在"，始终覆盖。
                    lastException = ex;
                    lastResult = false;
                }
            }

            if (lastException != null)
            {
                throw lastException;
            }
            return lastResult;
        }

        private static bool AuthenticateAgainstDomain(ActiveDirectoryConfiguration settings, string userName, string password)
        {
            try
            {
                DirectoryEntry ldapConnection = new DirectoryEntry("LDAP://" + settings.Server + "/" + settings.DirectoryPath, userName, password);
                DirectorySearcher searcher = new DirectorySearcher(ldapConnection);
                searcher.Filter = settings.Filter.Replace("and", "&");
                searcher.Filter = searcher.Filter.Replace(settings.FilterReplace, userName);
                searcher.PropertiesToLoad.Add("memberOf");
                searcher.PropertiesToLoad.Add("userAccountControl");

                SearchResult directoryUser = searcher.FindOne();
                if (directoryUser != null)
                {
                    int flags = Convert.ToInt32(directoryUser.Properties["userAccountControl"][0].ToString());
                    if (!Convert.ToBoolean(flags & 0x0002))
                    {
                        string desiredGroupName = settings.GroupName.ToLower();
                        if (desiredGroupName != string.Empty)
                        {
                            desiredGroupName = "cn=" + desiredGroupName + ",";
                            int numberOfGroups = directoryUser.Properties["memberOf"].Count;
                            bool isWithinGroup = false;
                            for (int i = 0; i < numberOfGroups; i++)
                            {
                                string groupName = directoryUser.Properties["memberOf"][i].ToString().ToLower();
                                if (groupName.Contains(desiredGroupName))
                                {
                                    isWithinGroup = true;
                                    break;
                                }
                            }
                            if (!isWithinGroup)
                            {
                                throw new Exception("User [" + userName + "] is not a member of the desired group.");
                            }
                        }
                        return true;
                    }
                    else
                    {
                        throw new Exception("User [" + userName + "] is inactive.");
                    }
                }
                else
                {
                    throw new ActiveDirectoryUserNotFoundException("User [" + userName + "] not found in the specified active directory path.");
                }
            }
            catch (ActiveDirectoryUserNotFoundException)
            {
                // 由 try 块内主动抛出，原样往外传，不要被下面的通用 catch 包装掉类型。
                throw;
            }
            catch (LdapException ex)
            {
                if (ex.ErrorCode == 49)
                {
                    throw new Exception("Invalid user authentication. Please input a valid user name & pasword and try again.", ex);
                }
                else
                {
                    throw new Exception("Active directory server not found.", ex);
                }
            }
            catch (DirectoryOperationException ex)
            {
                throw new Exception("Invalid active directory path.", ex);
            }
            catch (DirectoryServicesCOMException ex)
            {
                // AD 绑定失败时用扩展错误码区分具体原因（"data 52e"=密码错误、"data 525"=账号不存在等），
                // 而不是像之前那样统一 return false，导致上层把"密码错误"也误判成"用户不存在"。
                string extendedMessage = ex.ExtendedErrorMessage ?? string.Empty;
                if (ContainsAdErrorCode(extendedMessage, "525"))
                {
                    throw new ActiveDirectoryUserNotFoundException("User [" + userName + "] not found in the specified active directory path.", ex);
                }
                else if (ContainsAdErrorCode(extendedMessage, "52e"))
                {
                    throw new Exception("Invalid user authentication. Please input a valid user name & pasword and try again.", ex);
                }
                else if (ContainsAdErrorCode(extendedMessage, "532"))
                {
                    throw new Exception("User [" + userName + "]'s password has expired.", ex);
                }
                else if (ContainsAdErrorCode(extendedMessage, "533"))
                {
                    throw new Exception("User [" + userName + "] is inactive.", ex);
                }
                else if (ContainsAdErrorCode(extendedMessage, "701"))
                {
                    throw new Exception("User [" + userName + "]'s account has expired.", ex);
                }
                else if (ContainsAdErrorCode(extendedMessage, "775"))
                {
                    throw new Exception("User [" + userName + "]'s account is locked out.", ex);
                }
                else
                {
                    // 无法归类的绑定错误，维持改造前的保守行为：安静返回 false，不做具体归因。
                    return false;
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                throw new Exception("Active directory server not found.", ex);
            }
            catch (ArgumentException ex)
            {
                if (ex.Source == "System.DirectoryServices")
                {
                    throw new Exception("Invalid search filter expression.", ex);
                }
                else
                {
                    throw new Exception("Unhandeled exception occured while authenticating user using active directory.", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unhandeled exception occured while authenticating user using active directory.", ex);
            }
        }

        private static bool ContainsAdErrorCode(string extendedErrorMessage, string dataCode)
        {
            return extendedErrorMessage.IndexOf("data " + dataCode, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        //public static void UserAuthenticationCheck()
        //{
        //    try
        //    {
        //        if (ActiveDirectorySettings.Enabled)
        //        {
        //            if ((ActiveDirectorySettings.PageLevelSecurityCheck) && !HttpContext.Current.Request.Url.AbsolutePath.ToLower().Contains("login.aspx"))
        //            {
        //                if (HttpContext.Current.User != null)
        //                {
        //                    if (HttpContext.Current.User.Identity.IsAuthenticated)
        //                    {
        //                        if (HttpContext.Current.User.Identity is FormsIdentity)
        //                        {
        //                            FormsIdentity formIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
        //                            FormsAuthenticationTicket userAuthTicket = formIdentity.Ticket;
        //                            if (!IsUserLoggedIn(userAuthTicket.Name, userAuthTicket.UserData))
        //                            {
        //                                FormsAuthentication.SignOut();
        //                                FormsAuthentication.RedirectToLoginPage();
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        FormsAuthentication.SignOut();
        //        FormsAuthentication.RedirectToLoginPage();
        //    }
        //}

        public static string GetDepartmentByUser(string userName, string password)
        {
            string department = string.Empty;
            try
            {
                if (ActiveDirectorySettings.Enabled)
                {

                    int startIndex = userName.IndexOf("@");
                    if (startIndex >= 0)
                    {
                        userName = userName.Substring(0, startIndex);
                    }
                    DirectoryEntry ldapConnection = new DirectoryEntry("LDAP://" + ActiveDirectorySettings.Server + "/" + ActiveDirectorySettings.DirectoryPath, userName, password);
                    DirectorySearcher searcher = new DirectorySearcher(ldapConnection);
                    searcher.Filter = ActiveDirectorySettings.Filter.Replace("and", "&");
                    searcher.Filter = searcher.Filter.Replace(ActiveDirectorySettings.FilterReplace, userName);
                    searcher.PropertiesToLoad.Add("department");
                    searcher.PropertiesToLoad.Add("userAccountControl");

                    SearchResult directoryUser = searcher.FindOne();
                    if (directoryUser != null)
                    {
                        int flags = Convert.ToInt32(directoryUser.Properties["userAccountControl"][0].ToString());
                        if (!Convert.ToBoolean(flags & 0x0002))
                        {
                            department = directoryUser.Properties["department"][0].ToString();

                            //string desiredGroupName = ActiveDirectorySettings.GroupName.ToLower();
                            //if (desiredGroupName != string.Empty)
                            //{
                            ////    desiredGroupName = "cn=" + desiredGroupName + ",";
                            //    int numberOfGroups = directoryUser.Properties["memberOf"].Count;
                            ////    bool isWithinGroup = false;
                            //    for (int i = 0; i < numberOfGroups; i++)
                            //    {
                            //        department = directoryUser.Properties["memberOf"][i].ToString().ToLower() + ",";
                            ////        if (groupName.Contains(desiredGroupName))
                            ////        {
                            ////            isWithinGroup = true;
                            ////            break;
                            ////        }
                            //    }
                            ////    if (!isWithinGroup)
                            ////    {
                            //        throw new Exception("User [" + userName + "] is not a member of the desired group.");
                            //    }
                            //}
                            return department;
                        }
                        else
                        {
                            throw new Exception("User [" + userName + "] is inactive.");
                        }
                    }
                    else
                    {
                        throw new Exception("User [" + userName + "] not found in the specified active directory path.");
                    }
                }
                else
                {
                    return department;
                }
            }
            catch (LdapException ex)
            {
                if (ex.ErrorCode == 49)
                {
                    throw new Exception("Invalid user authentication. Please input a valid user name & pasword and try again.", ex);
                }
                else
                {
                    throw new Exception("Active directory server not found.", ex);
                }
            }
            catch (DirectoryOperationException ex)
            {
                throw new Exception("Invalid active directory path.", ex);
            }
            catch (DirectoryServicesCOMException ex)
            {
                if (ex.ExtendedError == 8333)
                {
                    throw new Exception("Invalid active directory path.", ex);
                }
                else
                {
                    throw new Exception("Invalid user authentication. Please input a valid user name & pasword and try again.", ex);
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                throw new Exception("Active directory server not found.", ex);
            }
            catch (ArgumentException ex)
            {
                if (ex.Source == "System.DirectoryServices")
                {
                    throw new Exception("Invalid search filter expression.", ex);
                }
                else
                {
                    throw new Exception("Unhandeled exception occured while authenticating user using active directory.", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unhandeled exception occured while authenticating user using active directory.", ex);
            }
        }
        public static string GetEmailByUser(string userName, string password)
        {
            string email = string.Empty;
            try
            {
                if (ActiveDirectorySettings.Enabled)
                {

                    int startIndex = userName.IndexOf("@");
                    if (startIndex >= 0)
                    {
                        userName = userName.Substring(0, startIndex);
                    }
                    DirectoryEntry ldapConnection = new DirectoryEntry("LDAP://" + ActiveDirectorySettings.Server + "/" + ActiveDirectorySettings.DirectoryPath, userName, password);
                    DirectorySearcher searcher = new DirectorySearcher(ldapConnection);
                    searcher.Filter = ActiveDirectorySettings.Filter.Replace("and", "&");
                    searcher.Filter = searcher.Filter.Replace(ActiveDirectorySettings.FilterReplace, userName);
                    searcher.PropertiesToLoad.Add("mail");
                    searcher.PropertiesToLoad.Add("userAccountControl");

                    SearchResult directoryUser = searcher.FindOne();
                    if (directoryUser != null)
                    {
                        int flags = Convert.ToInt32(directoryUser.Properties["userAccountControl"][0].ToString());
                        if (!Convert.ToBoolean(flags & 0x0002))
                        {
                            email = directoryUser.Properties["mail"][0].ToString();

                            //string desiredGroupName = ActiveDirectorySettings.GroupName.ToLower();
                            //if (desiredGroupName != string.Empty)
                            //{
                            ////    desiredGroupName = "cn=" + desiredGroupName + ",";
                            //    int numberOfGroups = directoryUser.Properties["memberOf"].Count;
                            ////    bool isWithinGroup = false;
                            //    for (int i = 0; i < numberOfGroups; i++)
                            //    {
                            //        department = directoryUser.Properties["memberOf"][i].ToString().ToLower() + ",";
                            ////        if (groupName.Contains(desiredGroupName))
                            ////        {
                            ////            isWithinGroup = true;
                            ////            break;
                            ////        }
                            //    }
                            ////    if (!isWithinGroup)
                            ////    {
                            //        throw new Exception("User [" + userName + "] is not a member of the desired group.");
                            //    }
                            //}
                            return email;
                        }
                        else
                        {
                            throw new Exception("User [" + userName + "] is inactive.");
                        }
                    }
                    else
                    {
                        throw new Exception("User [" + userName + "] not found in the specified active directory path.");
                    }
                }
                else
                {
                    return email;
                }
            }
            catch (LdapException ex)
            {
                if (ex.ErrorCode == 49)
                {
                    throw new Exception("Invalid user authentication. Please input a valid user name & pasword and try again.", ex);
                }
                else
                {
                    throw new Exception("Active directory server not found.", ex);
                }
            }
            catch (DirectoryOperationException ex)
            {
                throw new Exception("Invalid active directory path.", ex);
            }
            catch (DirectoryServicesCOMException ex)
            {
                if (ex.ExtendedError == 8333)
                {
                    throw new Exception("Invalid active directory path.", ex);
                }
                else
                {
                    throw new Exception("Invalid user authentication. Please input a valid user name & pasword and try again.", ex);
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                throw new Exception("Active directory server not found.", ex);
            }
            catch (ArgumentException ex)
            {
                if (ex.Source == "System.DirectoryServices")
                {
                    throw new Exception("Invalid search filter expression.", ex);
                }
                else
                {
                    throw new Exception("Unhandeled exception occured while authenticating user using active directory.", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unhandeled exception occured while authenticating user using active directory.", ex);
            }
        }
        public static string GetGroupByUser(string userName, string password)
        {
            StringBuilder group = new StringBuilder();
            try
            {
                if (ActiveDirectorySettings.Enabled)
                {

                    int startIndex = userName.IndexOf("@");
                    if (startIndex >= 0)
                    {
                        userName = userName.Substring(0, startIndex);
                    }
                    DirectoryEntry ldapConnection = new DirectoryEntry("LDAP://" + ActiveDirectorySettings.Server + "/" + ActiveDirectorySettings.DirectoryPath, userName, password);
                    DirectorySearcher searcher = new DirectorySearcher(ldapConnection);
                    searcher.Filter = ActiveDirectorySettings.Filter.Replace("and", "&");
                    searcher.Filter = searcher.Filter.Replace(ActiveDirectorySettings.FilterReplace, userName);
                    searcher.PropertiesToLoad.Add("memberof");
                    searcher.PropertiesToLoad.Add("userAccountControl");

                    SearchResult directoryUser = searcher.FindOne();
                    if (directoryUser != null)
                    {
                        int flags = Convert.ToInt32(directoryUser.Properties["userAccountControl"][0].ToString());
                        if (!Convert.ToBoolean(flags & 0x0002))
                        {
                            int propertyCount = directoryUser.Properties["memberOf"].Count;
                            string dn;
                            int equalsIndex, commaIndex;
                            for (int i = 0; i < propertyCount; i++)
                            {
                                dn = (string)directoryUser.Properties["memberOf"][i];
                                equalsIndex = dn.IndexOf("=", 1);
                                commaIndex = dn.IndexOf(",", 1);
                                if (-1 == equalsIndex)
                                {
                                    return null;
                                }
                                group.Append("</br>" + dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
                            }
                            return group.ToString();
                        }
                        else
                        {
                            throw new Exception("User [" + userName + "] is inactive.");
                        }
                    }
                    else
                    {
                        throw new Exception("User [" + userName + "] not found in the specified active directory path.");
                    }
                }
                else
                {
                    return group.ToString();
                }
            }
            catch (LdapException ex)
            {
                if (ex.ErrorCode == 49)
                {
                    throw new Exception("Invalid user authentication. Please input a valid user name & pasword and try again.", ex);
                }
                else
                {
                    throw new Exception("Active directory server not found.", ex);
                }
            }
            catch (DirectoryOperationException ex)
            {
                throw new Exception("Invalid active directory path.", ex);
            }
            catch (DirectoryServicesCOMException ex)
            {
                if (ex.ExtendedError == 8333)
                {
                    throw new Exception("Invalid active directory path.", ex);
                }
                else
                {
                    throw new Exception("Invalid user authentication. Please input a valid user name & pasword and try again.", ex);
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                throw new Exception("Active directory server not found.", ex);
            }
            catch (ArgumentException ex)
            {
                if (ex.Source == "System.DirectoryServices")
                {
                    throw new Exception("Invalid search filter expression.", ex);
                }
                else
                {
                    throw new Exception("Unhandeled exception occured while authenticating user using active directory.", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unhandeled exception occured while authenticating user using active directory.", ex);
            }
        }
        public static string GetUserTitle(string userName)
        {
            int startIndex = userName.IndexOf("@");
            if (startIndex >= 0)
            {
                userName = userName.Substring(0, startIndex);
            }
            string title = string.Empty;
            using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "crownbio.com"))
            {
                // Search the directory for the new object. 
                UserPrincipalEx myUser = UserPrincipalEx.FindByIdentity(ctx, userName);

                if (myUser != null)
                {
                    // get the title which is now available on your "myUser" object!
                    title = myUser.Title;
                    if (!string.IsNullOrEmpty(title))
                        title = title.ToLower().Trim();
                }
            }
            return title;
        }

        public static string GetUserCompany(string userName)
        {
            int startIndex = userName.IndexOf("@");
            if (startIndex >= 0)
            {
                userName = userName.Substring(0, startIndex);
            }
            string company = string.Empty;
            using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "crownbio.com"))
            {
                // Search the directory for the new object. 
                UserPrincipalEx myUser = UserPrincipalEx.FindByIdentity(ctx, userName);

                if (myUser != null)
                {
                    // get the title which is now available on your "myUser" object!
                    company = myUser.Company;
                    if (!string.IsNullOrEmpty(company))
                        company = company.ToLower().Trim();
                }
            }
            return company;
        }

        public static List<string> GetUsersByGroup(string groupname)
        {
            List<string> list = new List<string>();
            using (var context = new PrincipalContext(ContextType.Domain, "crownbio.com"))
            {
                using (var group = GroupPrincipal.FindByIdentity(context, groupname))
                {
                    if (group == null)
                    {

                    }
                    else
                    {
                        var users = group.GetMembers(true);
                        foreach (UserPrincipal user in users)
                        {
                            list.Add(user.EmailAddress);
                        }
                    }
                }
            }

            return list;
        }

        public static string GetOU(string username)
        {
            string result = string.Empty;
            using (HostingEnvironment.Impersonate())
            {
                //Getting the domain
                PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);

                //Finding the user
                UserPrincipal user = UserPrincipal.FindByIdentity(yourDomain, username);

                //If the user found
                if (user != null)
                {
                    // Getting the DirectoryEntry
                    DirectoryEntry directoryEntry = (user.GetUnderlyingObject() as DirectoryEntry);
                    //if the directoryEntry is not null
                    if (directoryEntry != null)
                    {
                        //Getting the directoryEntry's path and spliting with the "," character
                        string[] directoryEntryPath = directoryEntry.Path.Split(',');
                        //Getting the each items of the array and spliting again with the "=" character
                        foreach (var splitedPath in directoryEntryPath)
                        {
                            string[] eleiments = splitedPath.Split('=');
                            //If the 1st element of the array is "OU" string then get the 2dn element
                            if (eleiments[0].Trim() == "OU")
                            {
                                result = username + "-" + eleiments[1].Trim();
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static List<string> GetUsersByDepartment(string department)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("OU=IT,OU=CBTC Users,DC=crownbio,DC=com", department);
            string ou = sb.ToString();
            List<string> list = new List<string>();
            using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "crownbio.com", ou))
            {
                // define the "query-by-example" user (or group, or computer) for your search
                UserPrincipal qbeUser = new UserPrincipal(ctx);

                // define a searcher for that context and that query-by-example 
                using (PrincipalSearcher searcher = new PrincipalSearcher(qbeUser))
                {
                    foreach (Principal p in searcher.FindAll())
                    {
                        // Convert the "generic" Principal to a UserPrincipal
                        UserPrincipal user = p as UserPrincipal;

                        if (user != null)
                        {
                            // do something with your found user....
                        }
                    }
                }
            }
            return list;
        }

        public static List<string> GetAllActiveDirectoryGroups()
        {
            List<string> groups = new List<string>();
            using (var context = new PrincipalContext(ContextType.Domain, "crownbio.com"))
            {
                using (var group = new GroupPrincipal(context))
                {
                    if (group == null)
                    {

                    }
                    else
                    {
                        group.IsSecurityGroup = false;
                        PrincipalSearcher srch = new PrincipalSearcher(group);

                        // find all matches
                        foreach (var found in srch.FindAll())
                        {
                            if (!string.IsNullOrEmpty(found.DisplayName))
                            {
                                groups.Add(found.DisplayName);
                            }
                        }
                    }
                }
            }

            return groups;
        }

        public static List<string> GetAllDepartments(string name, string password)
        {
            List<string> dict = new List<string>();
            DirectoryEntry ldapConnection = new DirectoryEntry("LDAP://" + ActiveDirectorySettings.Server + "/" + ActiveDirectorySettings.DirectoryPath, name, password);
            DirectorySearcher searcher = new DirectorySearcher(ldapConnection);
            searcher.Filter = "(objectClass=user)";
            searcher.PropertiesToLoad.Add("department");
            SearchResultCollection results = searcher.FindAll();
            foreach (SearchResult result in results)
            {
                string dept = String.Empty;
                DirectoryEntry de = result.GetDirectoryEntry();
                if (de.Properties.Contains("department"))
                {
                    dept = de.Properties["department"][0].ToString();
                    if (!dict.Contains(dept))
                    {
                        dict.Add(result.Properties["department"][0].ToString());
                    }
                }
            }
            return dict;
        }

        #endregion

        #region helper method

        public static string GetProperty(DirectoryEntry de, string propertyName)
        {
            if (de.Properties.Contains(propertyName))
            {
                return de.Properties[propertyName][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
