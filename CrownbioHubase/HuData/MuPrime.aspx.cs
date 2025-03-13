using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crownbio.Model;
using Crownbio.Utility;
using Crownbio.BLL;
using System.Data;
using System.Text;
using Crownbio.Common;
using System.Data.SqlClient;

namespace PDXmodelBase.HuData
{
    public partial class MuPrime : System.Web.UI.Page
    {
        ObjectBLL bll = new ObjectBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            if (!userLogin.IS_Login)
            {
                Response.Write(" <script language='javascript'>top.location.href='../ErrorMsg.aspx?LoginType=1'</script>");
                return;
            }
            bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "MuPrime", "select");
            if (!havePerm)
            {
                Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                return;
            }

            //bool havePerm3 = ojbReportRule.GetUserFunctions(userLogin.Permission, "MuPrime", "edit");
            //if (!havePerm3)
            //{
            //    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", "$('#divMuPrimeImport').css('display','none');document.getElementById('btndelete').style.display = 'none'; ", true);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", "$('#divMuPrimeImport').css('display','block');document.getElementById('btndelete').style.display = 'inline-block'; ", true);
            //}
            StringBuilder js = new StringBuilder();
            ParamCollection paralist = new ParamCollection();
            paralist.Clause = HUBASE_FUNCTION.FUNCTION_NAME_FIELD + "='MuPrimeModelInfo-save'";
            BaseList functions = bll.Select(paralist, typeof(HUBASE_FUNCTION));
            bool isShow = false;
            foreach (HUBASE_FUNCTION fn in functions)
            {
                bool havePerm2 = ojbReportRule.GetUserFunctions(userLogin.Permission, "MuPrimeModelInfo-save", fn.OPERATE);
                if (!havePerm2)
                {
                    if (fn.OPERATE == "Source" || fn.OPERATE == "Model_Category" || fn.OPERATE == "Cachexia_Label" || fn.OPERATE == "Survival_Curve" || fn.OPERATE == "SOC" || fn.OPERATE == "Cancer_Type" || fn.OPERATE == "Subtype1" || fn.OPERATE == "Subtype2" || fn.OPERATE == "Model_From" || fn.OPERATE == "Origin" || fn.OPERATE == "STR_Consistence")
                    {
                        js.Append("$('#div" + fn.OPERATE + "').css('display','none');");
                    }
                    else
                    {
                        js.Append("$('#txt" + fn.OPERATE + "').css('display','none');");
                    }
                }
                else
                {
                    isShow = true;
                }
            }
            if (!isShow)
            {
                js.Append("$('#divMuPrimeImport').css('display','none');");
            }
            if (!ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin"))
            {
                js.Append("$('#aExport3').css('display','none');");
            }
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", js.ToString(), true);

        }

        protected void btnExport1_Click(object sender, EventArgs e)
        {
            if (Session["dgMuPrime"] != null)
            {
                DataTable dt = (DataTable)Session["dgMuPrime"];

                ToExport.TableToExcel(dt, "MuPrime");
            }
        }

        protected void btnExport3_Click(object sender, EventArgs e)
        {
            DataTable dtAll = new DataTable();
            ParamCollection paralist = new ParamCollection();
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause) };
            dtAll = ojbReportRule.GetGrid("GetdgMuPrime", para);
            if (dtAll.Rows.Count > 0)
            {
                ToExport.TableToExcel(dtAll, "MuPrimeInfo");
            }
        }
    }
}