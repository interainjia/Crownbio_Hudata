using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDXmodelBase
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["LoginType"] != null)
                {
                    
                    if (Request["LoginType"].ToString() == "2")
                    {
                        lblMsg.Text = "<br>You do not have permission to access this page.";
                    }
                   
                }
                else
                {
                    lblMsg.Text = "<br>该信息已被系统记录，请稍后重试或与管理员联系。";
                }
            }

        }
    }
}