using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Crownbio.BLL;
using Crownbio.Common;
using Crownbio.Model;
using System.Collections;
using Crownbio.Utility;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Drawing;



namespace PDXmodelBase.HuData
{
    public partial class index : System.Web.UI.Page
    {
        private ObjectBLL bll = new ObjectBLL();
        private BaseList masterData = new BaseList();
        public string IsUsers = "";
        public string ChangeUser = "";
        public string FunctionName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            if (!userLogin.IS_Login)
            {
                Response.Write(" <script language='javascript'>location.href='../ErrorMsg.aspx?LoginType=1'</script>");
                return;
            }
            if (!IsPostBack)
            {
                if (userLogin.IS_ADMIN == "Y" || ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin"))
                {
                    ChangeUser = userLogin.FIRST_NAME + " " + userLogin.LAST_NAME;
                    IsUsers = "<li><a id=\"Users\" href=\"javascript:void(0);\" onclick=\"addTab('System Management','SysManagement.aspx')\">Admin</a></li>";
                }
                else
                {
                    bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "DataImport", "view");
                    if (havePerm)
                    {
                        IsUsers = "<li><a id=\"Users\" href=\"javascript:void(0);\" onclick=\"addTab('System Management','SysManagement.aspx')\">Admin</a></li>";
                    }
                    ChangeUser = userLogin.FIRST_NAME + " " + userLogin.LAST_NAME;

                }
                if (userLogin.ROLE_TYPE == "1")
                {
                    FunctionName = " <li><a href=\"#\" class=\"parent\" onclick=\"addTab('Hudata','../HuBase/Hudata.aspx')\"><span>Hudata</span></a> </li>";
                }
            }

        }

      
    }
}