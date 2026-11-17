using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDXmodelBase.HuData
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 用户名/密码登录已停用，仅支持 Sign In With Azure；注册/找回密码页面跳回登录页
            Response.Redirect("Login.aspx", true);
        }
    }
}