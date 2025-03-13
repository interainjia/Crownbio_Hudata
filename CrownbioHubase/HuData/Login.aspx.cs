using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crownbio.Utility;

namespace PDXmodelBase.HuData
{
    public partial class Login : System.Web.UI.Page
    {
        string username = "";
        string password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { ////读cookie登录
                if (Request.Cookies["Hudatausername"] != null)
                {
                    username = Request.Cookies["Hudatausername"].Value;
                    password = Request.Cookies["Hudatapassword"].Value;
                    MessageHelper.ResponseClientScript(this, "$('#username').val('" + username + "');$('#password').val('" + password + "');");

                }
            }
        }
    }
}