using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDXmodelBase
{
    public partial class ErrorMsg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["LoginType"] != null)
                {
                    if (Request["LoginType"].ToString() == "LOCK" || Request["LoginType"].ToString() == "1")
                    {
                        lblMsg.Text = "<br>The user logged out.";
                    }
                    else if (Request["LoginType"].ToString() == "2")
                    {
                        lblMsg.Text = "<br>You do not have permission to access this page.";
                    }
                    else
                    {
                        lblMsg.Text = "<br>登陆超时请关闭本页面后再试！";
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