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
            context.Session["HudataUserInfo"] = null;
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