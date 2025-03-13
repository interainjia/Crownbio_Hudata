using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Crownbio.Language;
using Crownbio.Common;


namespace Crownbio.Utility
{
    public class MessageHelper
    {

        /// <summary> 
        /// 显示消息提示对话框 
        /// </summary> 
        /// <param name="page">当前页面指针，一般为this</param> 
        /// <param name="msg">提示信息</param> 
        public static void Show(System.Web.UI.Page page, string msg)
        {
            //page.ClientScript.RegisterStartupScript(GetType(), "msg", "<script>alert('无用户！');</script>");
            page.RegisterStartupScript("message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        /// <summary> 
        /// 控件点击消息确认提示框 
        /// </summary> 
        /// <param name="page">当前页面指针，一般为this</param> 
        /// <param name="msg">提示信息</param> 
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}"); 
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary> 
        /// 控件点击消息确认提示框 
        /// </summary> 
        /// <param name="page">当前页面指针，一般为this</param> 
        /// <param name="msg">提示信息</param> 
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, System.Web.UI.WebControls.WebControl GridView, string msg)
        {
            Control.Attributes.Add("onclick", "return selectConfirm('" + GridView.ClientID + "','" + msg + "');");
        }

        public static void ShowConfirm1(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            Control.Attributes.Add("OnSelect", "return confirm('" + msg + "');");
        }

        public static void SetEnterSubMit(System.Web.UI.WebControls.WebControl Control, System.Web.UI.WebControls.Button _SearchButton)
        {
            //StringBuilder buider = new StringBuilder();
            //buider.Append(" if(event.which || event.keyCode)");
            //buider.Append(" { if ((event.which == 13) || (event.keyCode == 13))  ");
            //buider.Append(" { document.getElementById('{0}').click();return false;}} ");
            //buider.Append(" else {return true}; ");
            Control.Attributes["onkeydown"] = String.Format("setSubMit('{0}');", _SearchButton.ClientID);
        }

        /// <summary> 
        /// 显示消息提示对话框，并进行页面跳转 
        /// </summary> 
        /// <param name="page">当前页面指针，一般为this</param> 
        /// <param name="msg">提示信息</param> 
        /// <param name="url">跳转的目标URL</param> 
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");
            page.RegisterStartupScript("message", Builder.ToString());
        }

        public static void ShowAndRedirect(System.Web.UI.Page page, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("parent.location.href='{0}'", url);
            Builder.Append("</script>");
            page.RegisterStartupScript("message", Builder.ToString());
        }

        /// <summary> 
        /// 输出自定义脚本信息 
        /// </summary> 
        /// <param name="page">当前页面指针，一般为this</param> 
        /// <param name="script">输出脚本</param> 
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.RegisterStartupScript("message", "<script language='javascript' defer>" + script + "</script>");
        }

        /// <summary>
        /// 输出脚本
        /// </summary>
        /// <param name="page"></param>
        /// <param name="script"></param>
        public static void ResponseClientScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script type='text/javascript'>" + script + "</script>");
        }


    }
}
