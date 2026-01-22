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
    public partial class ValidationStatus_Hukime : System.Web.UI.Page
    {
        ObjectBLL bll = new ObjectBLL();
        public string btnImport;
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
                //bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "ModelValidationStatus", "view");
                bool havePerm = ojbReportRule.GetUserFunctions2(userLogin.Permission, "ModelValidationStatus", AppConfig.UserViewRightList);
                if (!havePerm)
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                    return;
                }

                //bool havePerm3 = ojbReportRule.GetUserFunctions(userLogin.Permission, "ModelValidationStatus", "edit");
                bool havePerm3 = ojbReportRule.GetUserFunctions2(userLogin.Permission, "ModelValidationStatus", AppConfig.UserEditRightList);
                if (!havePerm3)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", "$('#divValidationStatus_HukimeImport').css('display','none');document.getElementById('btndelete').style.display = 'none'; ", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", "$('#divValidationStatus_HukimeImport').css('display','block');document.getElementById('btndelete').style.display = 'inline-block'; ", true);
                    btnImport += " <a href=\"javascript:void(); \" class=\"easyui-linkbutton\" iconcls=\"icon-search\" onclick='Import();'>Import</a>";

                }

            }
        }




        protected void btnExport1_Click(object sender, EventArgs e)
        {
            if (Session["dgValidationStatus_Hukime"] != null)
            {
                DataTable dt = (DataTable)Session["dgValidationStatus_Hukime"];

                ToExport.TableToExcel(dt, "End_of_Models");
            }
        }

 

        protected void btnExport3_Click(object sender, EventArgs e)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = query_dgValidationStatus_Hukime();
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause) };
            DataTable dtAll = ojbReportRule.GetGrid("GetdgValidationStatus_Hukime", para);
            if (dtAll.Rows.Count > 0)
            {
                ToExport.TableToExcel(dtAll, "ValidationStatus_Hukime");
            }
        }
        private ParamCollection query_dgValidationStatus_Hukime()
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            Clause += " where 1 = 1 ";
          
            paraList.Clause = Clause;
            return paraList;
        }
    }
}