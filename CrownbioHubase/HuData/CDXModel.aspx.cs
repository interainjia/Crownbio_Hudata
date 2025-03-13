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

namespace PDXmodelBase.HuData
{
    public partial class CDXModel : System.Web.UI.Page
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
            bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "CDXModel", "select");
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
                    if (fn.OPERATE == "Model_Category" || fn.OPERATE == "Cachexia_Label" || fn.OPERATE == "Survival_Curve" || fn.OPERATE == "SOC" || fn.OPERATE == "Cancer_Type" || fn.OPERATE == "Subtype1" || fn.OPERATE == "DeathRate" || fn.OPERATE == "Model_From" || fn.OPERATE == "Origin" || fn.OPERATE == "STR_Consistence")
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
    }
}