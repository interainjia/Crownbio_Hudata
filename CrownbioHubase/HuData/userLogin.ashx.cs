using System;
using System.Collections.Generic;
using System.Web;
using Crownbio.BLL;
using System.Data;
using Crownbio.Model;
using Crownbio.Utility;
using System.Web.Security;
using System.Web.SessionState;
using Crownbio.Language;
using Crownbio.Common;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections;
using Crownbio.BLL.Rule;

namespace PDXmodelBase.HuData
{
    /// <summary>
    /// userLogin 的摘要说明
    /// </summary>
    public class userLogin : IHttpHandler, IRequiresSessionState
    {
        ObjectBLL bll = new ObjectBLL();
        public void ProcessRequest(HttpContext context)
        {
            LanguageHelper.SetResourceManager("en-US");
            context.Response.ContentType = "text/plain";
            string Method = context.Request.Params["M"];
            string name = "";
            string pwd = "";

            string First_name = "";
            string Last_name = "";
            string Position = "";
            string Department = "";
            string Institution = "";
            string Street_Address = "";
            string City = "";
            string Country = "";
            string Phone = "";
            string Fax = "";
            string Email = "";
            string Password = "";
            string Interest = "";
            if (context.Request["name"] != null)
            {
                name = context.Request["name"].ToString();
                pwd = context.Request["pwd"].ToString();
            }
            if (context.Request["First_name"] != null)
            {
                First_name = context.Request["First_name"].ToString();
            }
            if (context.Request["Last_name"] != null)
            {
                Last_name = context.Request["Last_name"].ToString();
            }
            if (context.Request["Position"] != null)
            {
                Position = context.Request["Position"].ToString();
            }
            if (context.Request["Department"] != null)
            {
                Department = context.Request["Department"].ToString();
            }
            if (context.Request["Institution"] != null)
            {
                Institution = context.Request["Institution"].ToString();
            }
            if (context.Request["Street_Address"] != null)
            {
                Street_Address = context.Request["Street_Address"].ToString();
            }
            if (context.Request["City"] != null)
            {
                City = context.Request["City"].ToString();
            }
            if (context.Request["Country"] != null)
            {
                Country = context.Request["Country"].ToString();
            }
            if (context.Request["Phone"] != null)
            {
                Phone = context.Request["Phone"].ToString();
            }
            if (context.Request["Fax"] != null)
            {
                Fax = context.Request["Fax"].ToString();
            }
            if (context.Request["Email"] != null)
            {
                Email = context.Request["Email"].ToString();
            }
            if (context.Request["Password"] != null)
            {
                Password = context.Request["Password"].ToString();
            }

            if (context.Request["Interest"] != null)
            {
                Interest = context.Request["Interest"].ToString();
            }
            switch (Method)
            {
                // 试用账号（共享的 AACR@2013.org 固定账号）登录保持停用
                case "trial":
                    context.Response.StatusCode = 403;
                    context.Response.Write("Trial login is disabled.");
                    break;
                case "userLogin":
                    ReturnLogin(context, name, pwd);
                    break;
                case "userLoginAuto":
                    ReturnLoginAuto(context, name, pwd);
                    break;
                case "register":
                    Returnregister(context, First_name, Last_name, Position, Department, Institution, Street_Address, City, Country, Phone, Fax, Email, Password, Interest);
                    break;
                case "forgot":
                    ReturnForgot(context, Email);
                    break;
                case "resetPassword":
                    ReturnResetPassword(context, context.Request.Form["token"], Password);
                    break;
                case "changeInfo":
                    ReturnChange(context, First_name, Last_name, Position, Department, Institution, Street_Address, City, Country, Phone, Fax, Password, Interest);
                    break;
                case "Approve":
                    string id = context.Request.Params["USER_ID"];
                    ApproveUser(context, id);
                    break;
                case "Disable":
                    string idd = context.Request.Params["USER_ID"];
                    DisableUser(context, idd);
                    break;
            }
        }

        private const string CrownbioPasswordMsg = "The password of a CrownBio account is managed by Azure AD. Please use Sign In With Azure, or reset your password at https://password.crownbio.com.";

        private const string PasswordRuleMsg = "Your password must contain at least 6 characters and be consist of both numbers and letters, e.g. Crown01. The password is case sensitive.";

        /// <summary>
        /// 是否为公司域账号（@crownbio.com 或 *.crownbio.com）：密码由 Azure AD 域控管理，HuData 不保存、不修改其密码
        /// </summary>
        public static bool IsCrownbioEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            string e = email.Trim();
            return e.EndsWith("@crownbio.com", StringComparison.OrdinalIgnoreCase)
                || e.EndsWith(".crownbio.com", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 外部客户密码规则（与 Register.aspx / ChangeUsers.aspx 前端校验一致）：至少 6 位，同时包含字母和数字，不含空白字符
        /// </summary>
        private static bool IsValidExternalPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                return false;
            }
            bool hasLetter = false, hasDigit = false;
            foreach (char c in password)
            {
                if (char.IsWhiteSpace(c)) return false;
                if (char.IsLetter(c)) hasLetter = true;
                if (char.IsDigit(c)) hasDigit = true;
            }
            return hasLetter && hasDigit;
        }

       
        public string MStoJson(DataTable dt)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ArrayList dic = new ArrayList();
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> drow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    drow.Add(col.ColumnName, row[col.ColumnName]);
                }
                dic.Add(drow);
            }
            return jss.Serialize(dic);
        }

      

        /// <summary>
        /// ApproveUser
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        public void ApproveUser(HttpContext context, string id)
        {
            BaseList data = bll.Select(QueryCollection(id), typeof(SYS_USER));
            string dd = "wrong";
            if (data.Count > 0)
            {
                SYS_USER row = (SYS_USER)data[0];
                row.CurModel = DealModel.Modify;
                row.IS_AVAILABLE = "Y";
                bll.Update(row);
                row.CurModel = DealModel.None;
                string Subject = string.Format("Welcome to HuData!");
                StringBuilder Body = new StringBuilder();
                Body.Append("Dear " + row.FIRST_NAME + ",\r\n");
                Body.Append("Thanks for using HuData. You have been approved.\r\n");
                //Body.Append("Below please find your login credentials:\r\n");
                //Body.Append("Username: " + row.EMAIL + "\r\n");
                //Body.Append("Password: " + DEncryptHelper.Decrypt(row.USER_PWD) + "\r\n\r\n");
                Body.Append("Login using your username and password is required to access the database.\r\n\r\n");
                Body.Append("Happy HuDataing!\r\n\r\n");
                Body.Append("The Administrator");
                string[] toMails = { row.EMAIL };
                dd = SendEmail.SendMail_SMTP("Text", Subject, Body.ToString(), toMails, row.EMAIL + " is active.");
            }
            context.Response.Write(dd);
        }
        public void ReturnForgot(HttpContext context, string email)
        {
            // 公司域账号密码由 Azure AD 管理，不在 HuData 中重置
            if (IsCrownbioEmail(email))
            {
                context.Response.Write(CrownbioPasswordMsg);
                return;
            }
            email = (email ?? "").Trim();
            if (email == "")
            {
                context.Response.Write("Please enter your email.");
                return;
            }

            // 不论邮箱是否存在都返回同样的提示，避免被用来探测哪些邮箱已注册
            BaseList data = bll.Select(QueryEmail(email), typeof(SYS_USER));
            if (data.Count > 0)
            {
                SYS_USER row = (SYS_USER)data[0];
                // 未审批 / 已停用的账号不发送重置邮件
                if (row.IS_AVAILABLE != "N")
                {
                    string link = GetSiteBaseUrl() + "/HuData/Forget.aspx?token=" + CreateResetToken(row);
                    StringBuilder Body = new StringBuilder();
                    Body.Append("Dear " + row.FIRST_NAME + ",\r\n\r\n");
                    Body.Append("We received a request to reset the password of your HuData account (" + row.EMAIL + ").\r\n");
                    Body.Append("To choose a new password, open the link below. The link is valid for "
                        + (int)ResetLinkLifetime.TotalMinutes + " minutes and can only be used once:\r\n\r\n");
                    Body.Append(link + "\r\n\r\n");
                    Body.Append("If you did not request this, you can ignore this email. Your current password stays unchanged.\r\n\r\n");
                    Body.Append("The Administrator");
                    try
                    {
                        // 直接调用 GraphMailSender，不使用 SendEmail.SendMail_SMTP：后者会密送管理员，重置链接只能发给账号本人
                        GraphMailSender.Send("HuData - Reset your password", Body.ToString(), false, new[] { row.EMAIL });
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Log(ex, "Password reset email failed: " + row.EMAIL);
                    }
                }
            }
            context.Response.Write(ResetEmailSentMsg);
        }

        private const string ResetEmailSentMsg = "If an account with this email exists, we have sent it an email with a link to reset the password. The link is valid for 1 hour.";
        private const string ResetLinkInvalidMsg = "This password reset link is invalid, has expired or has already been used. Please request a new one.";
        private const string ResetTokenPurpose = "HuData.PasswordReset.v1";
        private static readonly TimeSpan ResetLinkLifetime = TimeSpan.FromHours(1);

        /// <summary>
        /// 重置链接中使用的站点地址：取 Web.config appSettings 的 HudataSiteUrl，未配置时为 https://hudata.crownbio.com。
        /// 不使用请求的 Host 头，防止伪造 Host 让重置链接指向其他网站。
        /// </summary>
        private static string GetSiteBaseUrl()
        {
            string url = System.Configuration.ConfigurationManager.AppSettings["HudataSiteUrl"];
            if (string.IsNullOrWhiteSpace(url))
            {
                url = "https://hudata.crownbio.com";
            }
            return url.Trim().TrimEnd('/');
        }

        private static string PasswordFingerprint(string storedPassword)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(storedPassword ?? "")));
            }
        }

        /// <summary>
        /// 生成重置令牌：USER_ID | 过期时间 | 当前密码哈希的指纹，用 MachineKey 加密并签名（无需新增数据库表）。
        /// 密码一旦修改指纹就不再匹配，因此链接只能使用一次，旧链接也随之失效。
        /// </summary>
        private static string CreateResetToken(SYS_USER user)
        {
            string payload = user.USER_ID.ToString(System.Globalization.CultureInfo.InvariantCulture)
                + "|" + DateTime.UtcNow.Add(ResetLinkLifetime).Ticks.ToString(System.Globalization.CultureInfo.InvariantCulture)
                + "|" + PasswordFingerprint(user.USER_PWD);
            byte[] protectedBytes = MachineKey.Protect(Encoding.UTF8.GetBytes(payload), ResetTokenPurpose);
            return HttpServerUtility.UrlTokenEncode(protectedBytes);
        }

        /// <summary>
        /// 校验重置令牌，有效时返回对应用户，否则返回 null（error 为提示信息）
        /// </summary>
        public static SYS_USER ValidateResetToken(string token, out string error)
        {
            error = ResetLinkInvalidMsg;
            if (string.IsNullOrWhiteSpace(token))
            {
                return null;
            }
            string payload;
            try
            {
                byte[] bytes = MachineKey.Unprotect(HttpServerUtility.UrlTokenDecode(token.Trim()), ResetTokenPurpose);
                payload = Encoding.UTF8.GetString(bytes);
            }
            catch (Exception)
            {
                // 被篡改、格式错误或服务器 machineKey 已变化
                return null;
            }
            string[] parts = payload.Split('|');
            if (parts.Length != 3 || !long.TryParse(parts[1], out long expiryTicks) || expiryTicks < DateTime.UtcNow.Ticks)
            {
                return null;
            }

            ParamCollection paraList = new ParamCollection();
            paraList.Clause = string.Format("({0}.{1} =@{1})", SYS_USER.TABLE_NAME, SYS_USER.USER_ID_FIELD);
            paraList.Add(new ParamData(SYS_USER.USER_ID_FIELD, DbType.String, parts[0]));
            BaseList data = new ObjectBLL().Select(paraList, typeof(SYS_USER));
            if (data.Count == 0)
            {
                return null;
            }
            SYS_USER row = (SYS_USER)data[0];
            if (row.IS_AVAILABLE == "N" || IsCrownbioEmail(row.EMAIL) || PasswordFingerprint(row.USER_PWD) != parts[2])
            {
                return null;
            }
            error = "";
            return row;
        }

        /// <summary>
        /// 通过邮件中的重置链接设置新密码（M=resetPassword，参数 token、Password）
        /// </summary>
        public void ReturnResetPassword(HttpContext context, string token, string password)
        {
            SYS_USER row = ValidateResetToken(token, out string error);
            if (row == null)
            {
                context.Response.Write(error);
                return;
            }
            if (!IsValidExternalPassword(password))
            {
                context.Response.Write(PasswordRuleMsg);
                return;
            }
            row.CurModel = DealModel.Modify;
            row.USER_PWD = PasswordHasher.Hash(password);
            bll.Update(row);
            row.CurModel = DealModel.None;
            context.Response.Write(ResetPasswordDoneMsg);
        }

        public const string ResetPasswordDoneMsg = "Your password has been reset. Please log in with your new password.";
        /// <summary>
        /// DisableUser
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        public void DisableUser(HttpContext context, string id)
        {
            BaseList data = bll.Select(QueryCollection(id), typeof(SYS_USER));
            string dd = "Error!";
            if (data.Count > 0)
            {
                SYS_USER row = (SYS_USER)data[0];
                row.CurModel = DealModel.Modify;
                row.IS_AVAILABLE = "N";
                bll.Update(row);
                row.CurModel = DealModel.None;
                dd = row.EMAIL + " is not active.";
            }
            context.Response.Write(dd);
        }

        private ParamCollection QueryCollection(string id)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";

            column = SYS_USER.USER_ID_FIELD;
            Clause += string.Format("({0}.{1} =@{1})", SYS_USER.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, id));

            paraList.Clause = Clause;
            return paraList;
        }
        private ParamCollection QueryEmail(string email)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";

            column = SYS_USER.EMAIL_FIELD;
            Clause += string.Format("({0}.{1} =@{1})", SYS_USER.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, email));

            paraList.Clause = Clause;
            return paraList;
        }
        
        public void ReturnLogin(HttpContext context, string name, string pwd)
        {
            string remember = "";
            if (context.Request["remember"] != null)
            {
                remember = context.Request["remember"].ToString();
            }
            SYS_USER loginUser = bll.Login(context, name, pwd);
            if (!loginUser.IS_Login)
            {
                context.Response.Write(loginUser.ErrMsg);
            }
            else
            {
                string msg = loginUser.ErrMsg;
                //if (loginUser.ROLE_TYPE == "01" && loginUser.PART_MENT != "Y")//试用账户第一次登录
                //{
                //    loginUser.UPDATE_TIME = loginUser.LoginTime;
                //    loginUser.PART_MENT = "Y";
                //    decimal id = bll.Update(loginUser);
                //    loginUser.CurModel = DealModel.None;
                //}
                if (loginUser.REMARK != null && loginUser.REMARK != "")
                {
                    string day = ((DateTime.Parse(loginUser.REMARK) - System.DateTime.Now).Days + 1).ToString();
                    msg = "User Trial:" + day;
                }

                //login_LOG
                SYS_USER_LOG sl = null;
                sl = new SYS_USER_LOG(DealModel.New);
                sl.LOGIN_TIME = loginUser.LoginTime;
                sl.IP = context.Request.UserHostAddress;
                sl.USER_CODE = loginUser.USER_CODE;
                sl.USER_NAME = loginUser.FIRST_NAME + " " + loginUser.LAST_NAME;
                sl.EMAIL = loginUser.EMAIL;
                sl.ROLE_TYPE = loginUser.ROLE_TYPE;
                bll.Update(sl);
                sl.CurModel = DealModel.None;


                // Remember Me 只记住用户名（7 天），不再把明文密码写入 Cookie
                if (remember == "true")
                {
                    context.Response.Cookies.Add(new HttpCookie(Login.RememberUserCookieName, HttpUtility.UrlEncode(name))
                    {
                        Expires = DateTime.Now.AddDays(7),
                        HttpOnly = true,
                        Secure = context.Request.IsSecureConnection
                    });
                }
                else
                {
                    context.Response.Cookies.Add(new HttpCookie(Login.RememberUserCookieName, "") { Expires = DateTime.Now.AddDays(-1) });
                }

                //FormsAuthentication.SetAuthCookie(name, false);
                //   Session["DigitData"] = new ObjectBLL().Select(typeof(BASE_DIGIT));
                context.Session["HudataUserInfo"] = loginUser;
                context.Response.Write(msg);
            }
        }

        public void ReturnLoginAuto(HttpContext context, string name, string pwd)
        {
            string remember = "";
            if (context.Request["remember"] != null)
            {
                remember = context.Request["remember"].ToString();
            }

            // SSO 登录必须携带签名有效的 identity_token，登录账号以 Token 中的邮箱为准，忽略前端传入的 name
            if (!SsoTokenValidator.TryValidateRequest(context.Request, out string ssoEmail, out string ssoError))
            {
                context.Response.Write(ssoError);
                return;
            }
            name = ssoEmail;

            SYS_USER loginUser = bll.LoginSSO(context, name, pwd);
            if (!loginUser.IS_Login)
            {
                context.Response.Write(loginUser.ErrMsg);
            }
            else
            {
                string msg = loginUser.ErrMsg;
                //if (loginUser.ROLE_TYPE == "01" && loginUser.PART_MENT != "Y")//试用账户第一次登录
                //{
                //    loginUser.UPDATE_TIME = loginUser.LoginTime;
                //    loginUser.PART_MENT = "Y";
                //    decimal id = bll.Update(loginUser);
                //    loginUser.CurModel = DealModel.None;
                //}
                if (loginUser.REMARK != null && loginUser.REMARK != "")
                {
                    string day = ((DateTime.Parse(loginUser.REMARK) - System.DateTime.Now).Days + 1).ToString();
                    msg = "User Trial:" + day;
                }

                //login_LOG
                SYS_USER_LOG sl = null;
                sl = new SYS_USER_LOG(DealModel.New);
                sl.LOGIN_TIME = loginUser.LoginTime;
                sl.IP = context.Request.UserHostAddress;
                sl.USER_CODE = loginUser.USER_CODE;
                sl.USER_NAME = loginUser.FIRST_NAME + " " + loginUser.LAST_NAME;
                sl.EMAIL = loginUser.EMAIL;
                sl.ROLE_TYPE = loginUser.ROLE_TYPE;
                bll.Update(sl);
                sl.CurModel = DealModel.None;

                // SSO 登录不再写入 Hudatausername/Hudatapassword Cookie（旧版 Remember Me 会保存明文密码）

                //FormsAuthentication.SetAuthCookie(name, false);
                //   Session["DigitData"] = new ObjectBLL().Select(typeof(BASE_DIGIT));
                context.Session["HudataUserInfo"] = loginUser;
                context.Response.Write(msg);
            }
        }

        public void ReturnTrial(HttpContext context)
        {
            SYS_USER loginUser = bll.Login(context, "AACR@2013.org", "2013aacr");
            if (!loginUser.IS_Login)
            {
                context.Response.Write(loginUser.ErrMsg);
            }
            else
            {
                string msg = loginUser.ErrMsg;
                //if (loginUser.ROLE_TYPE == "01" && loginUser.PART_MENT != "Y")//试用账户第一次登录
                //{
                //    loginUser.UPDATE_TIME = loginUser.LoginTime;
                //    loginUser.PART_MENT = "Y";
                //    decimal id = bll.Update(loginUser);
                //    loginUser.CurModel = DealModel.None;
                //}
                //if (loginUser.ROLE_TYPE == "01")
                //{
                //    string day = ((loginUser.UPDATE_TIME.AddDays(7) - System.DateTime.Now).Days + 1).ToString();
                //    msg = "User Trial:" + day;
                //}

                //login_LOG
                SYS_USER_LOG sl = null;
                sl = new SYS_USER_LOG(DealModel.New);
                sl.LOGIN_TIME = loginUser.LoginTime;
                sl.IP = context.Request.UserHostAddress;
                sl.USER_CODE = loginUser.USER_CODE;
                sl.USER_NAME = loginUser.FIRST_NAME + " " + loginUser.LAST_NAME;
                sl.EMAIL = loginUser.EMAIL;
                //sl.ROLE_TYPE = loginUser.ROLE_TYPE;
                bll.Update(sl);
                sl.CurModel = DealModel.None;

                FormsAuthentication.SetAuthCookie("AACR@2013.org", false);
                //   Session["DigitData"] = new ObjectBLL().Select(typeof(BASE_DIGIT));
                context.Session["HudataUserInfo"] = loginUser;
                context.Response.Write(msg);
            }
        }
        public void Returnregister(HttpContext context, string First_name, string Last_name, string Position, string Department, string Institution, string Street_Address, string City, string Country, string Phone, string Fax, string Email, string Password, string Interest)
        {
            Email = (Email ?? "").Trim();
            if (string.IsNullOrEmpty(Email))
            {
                context.Response.Write("Please enter your company email.");
                return;
            }
            // 外部客户必须设置密码；公司域账号密码由 Azure AD 管理，忽略提交的密码
            bool isCrownbio = IsCrownbioEmail(Email);
            if (!isCrownbio && !IsValidExternalPassword(Password))
            {
                context.Response.Write(PasswordRuleMsg);
                return;
            }
            if (bll.Find(-1, Email, typeof(SYS_USER)))
            {
                context.Response.Write("Email address already exists!");
            }
            else
            {
                SYS_USER currentRow = null;
                //currentRow = (SYS_USER)masterData.Find(decimal.Parse(this.txtID.Value));
                bool isNew = false;
                if (currentRow == null)
                {
                    currentRow = new SYS_USER(DealModel.New);
                    isNew = true;
                }
                currentRow.USER_CODE = Email;
                currentRow.USER_NAME = First_name + " " + Last_name;
                if (isNew)
                {
                    // 公司域账号：登录时由 AD 校验密码，本地只保存一个无人知晓的随机密码哈希（不可用于登录）
                    currentRow.USER_PWD = PasswordHasher.Hash(isCrownbio ? PasswordHasher.GenerateRandomSecret() : Password);
                }

                currentRow.EMAIL = Email;
                currentRow.CITY = City;
                currentRow.COUNTRY = Country;
                currentRow.DEPARTMENT = Department;
                currentRow.FAX = Fax;
                currentRow.FIRST_NAME = First_name;
                currentRow.LAST_NAME = Last_name;
                currentRow.INSTITUTION = Institution;
                currentRow.INTEREST = Interest;
                currentRow.PHONE = Phone;
                currentRow.POSITION = Position;
                currentRow.STREET_ADDRESS = Street_Address;

                currentRow.IS_AVAILABLE = "N";//未审批
                currentRow.IS_ADMIN = "N";
                currentRow.ROLE_TYPE = "02";//注册用户
                bll.Update(currentRow);


                currentRow.CurModel = DealModel.None;

                string Subject = string.Format("HuData registration notice!");
                StringBuilder Body = new StringBuilder();
                Body.Append("Client info\r\n");
                Body.Append("Full name: " + First_name + " " + Last_name + "\r\n");
                Body.Append("Company Email: " + Email + "\r\n");
                Body.Append("Position/Title: " + Position + "\r\n");
                Body.Append("Department: " + Department + "\r\n");
                Body.Append("Institution: " + Institution + "\r\n");
                Body.Append("Street Address: " + Street_Address + "\r\n");
                Body.Append("City and State: " + City + "\r\n");
                Body.Append("Country: " + Country + "\r\n");
                Body.Append("Phone number: " + Phone + "\r\n");
                Body.Append("Fax number: " + Fax + "\r\n\r\n");
                ////FreeMail.SmtpContext gmailSmtp = new FreeMail.SmtpContext()
                ////{
                ////    Server = "smtp.gmail.com",
                ////    UserName = "xianyue48@gmail.com",
                ////    Password = "amokslab",
                ////    Port = "587",
                ////    EnableSSL = true   //发送邮件 (SMTP) 服务器 - 需要 TLS2 或 SSL
                ////};
                //FreeMail.SmtpContext mySmtp = new FreeMail.SmtpContext()
                //{
                //    Server = "localhost"
                //};
                ////使用Gmail的SMTP服务器发送邮件，需要Gmail用户名密码作为认证信息，发件人地址会被强制转换为Gmail邮箱，必须使用SSL发送
                ////FreeMail.SendMail(gmailSmtp, new List<string> { "runjun.jia@crownbio.com" }, "xianyue48@gmail.com", "lijun", Subject, Body);
                ////使用自己配置的SMTP服务器，可以任意指定发件人地址
                //FreeMail.SendMail(mySmtp, new List<string> { "runjun.jia@crownbio.com" }, "xianyue48@gmail.com", "lijun", Subject, Body);

                string msg = "Registration was successful! Please wait for approval.";
                //SendEmail.SendExchangeEmail(Subject, Body.ToString(), "HuBaseAdmin@crownbio.com", msg);
                //SendEmail.SendExchangeEmail(Subject, Body.ToString(), "guosheng@crownbio.com", msg);
                //string dd = SendEmail.SendExchangeEmail(Subject, Body.ToString(), "yangjie@crownbio.com", msg);

                context.Response.Write(msg);
            }
        }
        public void ReturnChange(HttpContext context, string First_name, string Last_name, string Position, string Department, string Institution, string Street_Address, string City, string Country, string Phone, string Fax, string Password, string Interest)
        {
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            string Email = "";
            SYS_USER currentRow = null;
            BaseList masterdata =bll.Select(QueryEmail(userLogin.EMAIL),typeof(SYS_USER));
            if (userLogin.IS_Login)
            {
                Email = userLogin.EMAIL;
                currentRow = (SYS_USER)masterdata[0];
                currentRow.CurModel = DealModel.Modify;
                currentRow.USER_CODE = Email;
                currentRow.USER_NAME = First_name + " " + Last_name;
                // 外部客户填写了新密码才修改；公司域账号密码由 Azure AD 管理，USER_PWD 保持不变
                if (!IsCrownbioEmail(Email) && !string.IsNullOrEmpty(Password))
                {
                    if (!IsValidExternalPassword(Password))
                    {
                        context.Response.Write(PasswordRuleMsg);
                        return;
                    }
                    currentRow.USER_PWD = PasswordHasher.Hash(Password);
                }
                currentRow.CITY = City;
                currentRow.COUNTRY = Country;
                currentRow.DEPARTMENT = Department;
                currentRow.FAX = Fax;
                currentRow.FIRST_NAME = First_name;
                currentRow.LAST_NAME = Last_name;
                currentRow.INSTITUTION = Institution;
                currentRow.INTEREST = Interest;
                currentRow.PHONE = Phone;
                currentRow.POSITION = Position;
                currentRow.STREET_ADDRESS = Street_Address;
                bll.Update(currentRow);
                currentRow.CurModel = DealModel.None;
                // 不再用密码重新登录（Azure 用户没有可用的本地密码，重新登录会导致会话失效），直接同步当前会话中的用户信息
                userLogin.USER_NAME = currentRow.USER_NAME;
                userLogin.FIRST_NAME = First_name;
                userLogin.LAST_NAME = Last_name;
                userLogin.POSITION = Position;
                userLogin.DEPARTMENT = Department;
                userLogin.INSTITUTION = Institution;
                userLogin.STREET_ADDRESS = Street_Address;
                userLogin.CITY = City;
                userLogin.COUNTRY = Country;
                userLogin.PHONE = Phone;
                userLogin.FAX = Fax;
                userLogin.INTEREST = Interest;
                context.Session["HudataUserInfo"] = userLogin;
                context.Response.Write("Save successfully.");
            }

          
           
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

      
    }
}