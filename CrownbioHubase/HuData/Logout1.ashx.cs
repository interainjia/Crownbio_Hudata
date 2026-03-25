using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Crownbio.Model;
using Crownbio.Common;
using Crownbio.BLL;
using Crownbio.Utility;

namespace PDXmodelBase.HuData
{
    /// <summary>
    /// Logout1 的摘要说明
    /// </summary>
    public class Logout1 : IHttpHandler, IRequiresSessionState 
    {
        ObjectBLL bll = new ObjectBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Method = context.Request.Params["M"];
            switch (Method)
            {
                case "logout":
                    Logout(context);
                    break;
            }
        }
        public void Logout(HttpContext context)
        {
            //if (((ArrayList)context.Application["sid"]).Contains(context.Session.SessionID))
            //{
            //    context.Application.Lock();
            //    //减少一个在线人数
            //    ((ArrayList)context.Application["sid"]).Remove(context.Session.SessionID);
            //    context.Application["count"] = (int)context.Application["count"] - 1;
            //    //解锁
            //    context.Application.UnLock();
            //    //对Appliaction加锁以防止并行性
            //}

            //login_LOG
            SYS_USER user = CacheHelper.getCurrentUser();
            ParamCollection pl = new ParamCollection();
            pl.Clause += " LOGIN_TIME = " + user.LoginTime.ToString();
            pl.Clause += " and USER_CODE = " + user.USER_CODE;
            BaseList data = bll.Select(pl, typeof(SYS_USER_LOG));
            if (data.Count>0)
            {
                SYS_USER_LOG sl = (SYS_USER_LOG)data[0];
                sl.CurModel = DealModel.Modify;
                sl.LOGOUT_TIME = System.DateTime.Now;
                bll.Update(sl);
                sl.CurModel = DealModel.None;
            }

            // 1. 清除本地系统的 Session
            context.Session["HudataUserInfo"] = null;

            // ==============================================================
            // 2. 新增：清除 Azure AD 的 identity_token，打破自动登录死循环
            // ==============================================================
            if (context.Request.Cookies["identity_token"] != null)
            {
                HttpCookie ssoCookie = new HttpCookie("identity_token");

                // 将过期时间设置为昨天，强制浏览器删除
                ssoCookie.Expires = DateTime.Now.AddDays(-1);

                // 【关键】必须加上跨域的 Domain，否则无法跨域删除！
                ssoCookie.Domain = ".crownbio.com";

                context.Response.Cookies.Add(ssoCookie);
            }
            // ==============================================================

            // 3. 告诉前端跳转回登录页
            context.Response.Write("Login.aspx");

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