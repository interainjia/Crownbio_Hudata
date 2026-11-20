using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDXmodelBase.HuData
{
    public partial class Forget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 防止重置链接（含令牌）被缓存或通过 Referer 泄露
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.AppendHeader("Referrer-Policy", "no-referrer");

            // 带 token 打开：显示"设置新密码"表单；令牌无效时直接提示，不显示表单
            string token = Request.QueryString["token"];
            if (!string.IsNullOrEmpty(token))
            {
                string script;
                if (userLogin.ValidateResetToken(token, out string error) != null)
                {
                    script = "$('#request-pane').hide();$('#reset-pane').show();";
                }
                else
                {
                    script = "$('#request-pane').hide();$('#reset-invalid').text('" + HttpUtility.JavaScriptStringEncode(error) + "').show();";
                }
                ClientScript.RegisterStartupScript(GetType(), "resetMode",
                    "<script type='text/javascript'>$(function(){" + script + "});</script>");
            }
        }
    }
}
