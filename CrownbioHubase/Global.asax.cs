using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Collections;
using System.Net;
using PDXmodelBase.App_Start;
using System.Web.Http;

namespace PDXmodelBase
{
    public class Global : System.Web.HttpApplication
    {
       
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["count"] = 0;
            Application["sid"] = null;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            if (application != null && application.Context != null)
            {
                //移除Server
                application.Context.Response.Headers.Remove("Server");
            }

        }

        protected void Application_PostAuthorizeRequest()
        {
            HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
         


        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            if (Application["sid"] != null)
            {
                if (((ArrayList)Application["sid"]).Contains(Session.SessionID))
                {
                    Application.Lock();
                    //减少一个在线人数
                    ((ArrayList)Application["sid"]).Remove(Session.SessionID);
                    Application["count"] = (int)Application["count"] - 1;
                    //解锁
                    Application.UnLock();
                    //对Appliaction加锁以防止并行性
                }
            }
        }


        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}