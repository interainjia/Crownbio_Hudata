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
                case "trial":
                     ReturnTrial(context);
                    break;
                case "userLogin":
                    ReturnLogin(context, name, pwd);
                    break;
                case "register":
                    Returnregister(context, First_name, Last_name, Position, Department, Institution, Street_Address, City, Country, Phone, Fax, Email, Password, Interest);
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
                case "forgot":
                    ReturnForgot(context, Email);
                    break;
              
            }
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
            BaseList data = bll.Select(QueryEmail(email), typeof(SYS_USER));
            string dd = "Email address dose not exist.";
            if (data.Count > 0)
            {
                SYS_USER row = (SYS_USER)data[0];
                string Subject = string.Format("HuData-Retrieve Password!");
                StringBuilder Body = new StringBuilder();
                Body.Append("Dear " + row.FIRST_NAME + ",\r\n");
                Body.Append("Thanks for using HuData. Your password has been recovered.\r\n");
                Body.Append("Below please find your login credentials:\r\n");
                Body.Append("Username: " + row.EMAIL + "\r\n");
                string newpw = UtitityHelper.GenerateRandom(6);
                Body.Append("New Password: " + newpw + "\r\n\r\n");
                Body.Append("Login using your username and password is required to access the database.\r\n\r\n");
                Body.Append("Happy HuBasing!\r\n\r\n");
                Body.Append("The Administrator");

                string[] toMails = { row.EMAIL };
                dd = SendEmail.SendMail_SMTP("Text", Subject, Body.ToString(), toMails, "An email has been sent.");

                if (dd == "An email has been sent.")
                {
                    row.CurModel = DealModel.Modify;
                    row.USER_PWD = DEncryptHelper.Encrypt(newpw);
                    bll.Update(row);
                    row.CurModel = DealModel.None;
                }
            }
            context.Response.Write(dd);
        }
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
            SYS_USER loginUser = bll.Login(context, name, DEncryptHelper.Encrypt(pwd));
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


                if (remember == "true")
                {
                    context.Response.Cookies["Hudatausername"].Value = name;
                    context.Response.Cookies["Hudatapassword"].Value = pwd;
                    context.Response.Cookies["HudatauserName"].Expires = DateTime.Now.AddDays(7);//设置过期时间
                    context.Response.Cookies["Hudatapassword"].Expires = DateTime.Now.AddDays(7);//设置过期时间
                }

                //FormsAuthentication.SetAuthCookie(name, false);
                //   Session["DigitData"] = new ObjectBLL().Select(typeof(BASE_DIGIT));
                context.Session["HudataUserInfo"] = loginUser;
                context.Response.Write(msg);
            }
        }
        public void ReturnTrial(HttpContext context)
        {
            SYS_USER loginUser = bll.Login(context, "AACR@2013.org", DEncryptHelper.Encrypt("2013aacr"));
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
                    currentRow.USER_PWD = DEncryptHelper.Encrypt(Password);
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
                ////FreeMail.SendMail(gmailSmtp, new List<string> { "lijun@crownbio.com" }, "xianyue48@gmail.com", "lijun", Subject, Body);
                ////使用自己配置的SMTP服务器，可以任意指定发件人地址
                //FreeMail.SendMail(mySmtp, new List<string> { "lijun@crownbio.com" }, "xianyue48@gmail.com", "lijun", Subject, Body);

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
                currentRow.USER_PWD = DEncryptHelper.Encrypt(Password);
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
                SYS_USER loginUser = bll.Login(context, userLogin.EMAIL, DEncryptHelper.Encrypt(Password));
                context.Session["HudataUserInfo"] = loginUser;
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