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
    public partial class NewModel : System.Web.UI.Page
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
                bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "NewModel", "view");
                if (!havePerm)
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                    return;
                }

                bool havePerm3 = ojbReportRule.GetUserFunctions(userLogin.Permission, "NewModel", "edit");
                if (!havePerm3)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", "$('#divNewModelImport').css('display','none');document.getElementById('btndelete').style.display = 'none'; ", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", "$('#divNewModelImport').css('display','block');document.getElementById('btndelete').style.display = 'inline-block'; ", true);
                }
               
            }
        }




        protected void btnExport1_Click(object sender, EventArgs e)
        {
            if (Session["dgNewModel"] != null)
            {
                DataTable dt = (DataTable)Session["dgNewModel"];

                ToExport.TableToExcel(dt, "New_Model");
            }
        }

        protected void btnExport2_Click(object sender, EventArgs e)
        {
            if (Session["dgAnimalInfo_NewModel"] != null)
            {
                DataTable dt = (DataTable)Session["dgAnimalInfo_NewModel"];

                ToExport.TableToExcel(dt, "NewModel_AnimalInfo");
            }
        }


        protected void btnExport3_Click(object sender, EventArgs e)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = query_dgNewModel();
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause) };
            DataTable dtAll = ojbReportRule.GetGrid("GetdgNewModel_export", para);
            if (dtAll.Rows.Count > 0)
            {
                ToExport.TableToExcel(dtAll, "New_Model");
            }
        }
        private ParamCollection query_dgNewModel()
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            Clause += " where 1 = 1 ";
            if (Request["S_StartData"].ToString() != "" && Request["S_EndData"].ToString() != "")
            {
                string start = Request["S_StartData"].ToString();
                string end = Request["S_EndData"].ToString();
                string DOI = NEWMODEL.DATE_OF_PASSAGE_INOCULATION_FIELD;
                string DOT = NEWMODEL.DATE_OF_PASSAGE_TERMINATION_FIELD;
                Clause += string.Format("AND '{2}' <= '{3}' and  ( ({0}.{1} > '{2}' and {0}.{1} <= '{3}' and ({0}.{4} <= '{3}' or {0}.{4} = '0001-01-01' or {0}.{4} is null) )", NEWMODEL.TABLE_NAME, DOI, start, end, DOT);
                Clause += string.Format(" or ({0}.{4} >= '{2}' and {0}.{4} < '{3}' and {0}.{1} < '{2}')", NEWMODEL.TABLE_NAME, DOI, start, end, DOT);
                //Clause += string.Format(" or ({0}.{4} > '{3}' and {0}.{1} < '{2}' )", NEWMODEL.TABLE_NAME, DOI, start, end, DOT);
                Clause += string.Format(" or (({0}.{4} = '0001-01-01' or {0}.{4} is null) and {0}.{1} < '{2}' )", NEWMODEL.TABLE_NAME, DOI, start, end, DOT);
                Clause += string.Format(" or ({0}.{1} > '{2}' and {0}.{1} < '{3}' and {0}.{4} > '{2}' and {0}.{4} < '{3}' ))", NEWMODEL.TABLE_NAME, DOI, start, end, DOT);
            }


            paraList.Clause = Clause;
            return paraList;
        }
    }
}