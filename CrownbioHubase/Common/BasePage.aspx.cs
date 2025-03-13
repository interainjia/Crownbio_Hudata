using System;
using System.Data;
using System.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace PDXmodelBase.Common
{
    /// <summary>
    /// BasePage 的摘要说明
    /// </summary>
    public partial class BasePage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["ThemeSelector1$ASPxComboBox1"]))
            {
                this.Theme = Request["ThemeSelector1$ASPxComboBox1"];
                this.Session["CurrentTheme"] = this.Theme;
            }
            else
            {

                if (Session["CurrentTheme"] != null)
                {
                    this.Theme = Session["CurrentTheme"].ToString();
                }
                else
                {
                    this.Theme = "Aqua";
                }
            }

            base.OnPreInit(e);


        }



    }

}