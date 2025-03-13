using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crownbio.BLL;
using Crownbio.Model;
using Crownbio.Common;
using Crownbio.Utility;
using System.Data;
using System.Data.SqlClient;

namespace PDXmodelBase.HuData
{
    public partial class TissueWithdraw : System.Web.UI.Page
    {
        ObjectBLL bll = new ObjectBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SYS_USER userLogin = CacheHelper.getCurrentUser();
                if (!userLogin.IS_Login)
                {
                    Response.Write(" <script language='javascript'>top.location.href='../ErrorMsg.aspx?LoginType=1'</script>");
                    return;
                }
                bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "TissueWithdraw", "view");
                if (!havePerm)
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                    return;
                }
              
            }
        }


        protected void btnExport1_Click(object sender, EventArgs e)
        {
            if (Session["dgTissueWithdraw"] != null)
            {
                DataTable dt = (DataTable)Session["dgTissueWithdraw"];

                ToExport.TableToExcel(dt, "Tissue_Withdraw");
            }
        }

        protected void btnExport2_Click(object sender, EventArgs e)
        {
            if (Session["dgTissueWithdraw_Completed"] != null)
            {
                DataTable dt = (DataTable)Session["dgTissueWithdraw_Completed"];

                ToExport.TableToExcel(dt, "dgTissueWithdraw_Completed");
            }
        }

        protected void btnExport3_Click(object sender, EventArgs e)
        {
            SqlParameter[] para = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("GetdgTissueWithdraw_Preserve_Method", para);
            ToExport.TableToExcel(dt, "Preserve_Amount");
        }

   

     

    
    }
}