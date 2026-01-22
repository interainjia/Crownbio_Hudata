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
    public partial class SpecimenStocks : System.Web.UI.Page
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
                //bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "SpecimenStocks", "view");
                bool havePerm = ojbReportRule.GetUserFunctions2(userLogin.Permission, "SpecimenStocks", AppConfig.UserViewRightList);
                if (!havePerm)
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                    return;
                }
                //bool havePerm3 = ojbReportRule.GetUserFunctions(userLogin.Permission, "SpecimenStocks", "edit");
                bool havePerm3 = ojbReportRule.GetUserFunctions2(userLogin.Permission, "SpecimenStocks", AppConfig.UserEditRightList);
                if (!havePerm3)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", "$('#divStocksImport').css('display','none');document.getElementById('btndelete').style.display = 'none'; ", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", "$('#divStocksImport').css('display','block');document.getElementById('btndelete').style.display = 'inline-block'; ", true);
                }
               
            }
        }


        protected void btnExport1_Click(object sender, EventArgs e)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = queryTissueStock();
            if (paralist.Clause != "")
            {
                SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause) };
                DataTable dt = ojbReportRule.GetGrid("GetdgSpecimenStocks_export", para);
                if (dt.Rows.Count <= 20000)
                {
                    ToExport.TableToExcel(dt, "Specimen_Stocks");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key", "alert('If the number exceeds 20000, contact the administrator to provide the download service.');", true);
                }
            }
        }


        private ParamCollection queryTissueStock()
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            if (Request["searchModel_ID"] != null)
            {
                if (Request["searchModel_ID"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.MODEL_ID_FIELD;
                    string mids = "";
                    foreach (string mid in Request["searchModel_ID"].ToString().Split(','))
                    {
                        mids += " model_id like '%" + mid + "%' or";
                    }
                    Clause += "AND (" + mids.TrimEnd('r').TrimEnd('o') + ")";
                }
            }
            if (Request["S_PojectNo"] != null)
            {
                if (Request["S_PojectNo"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.IMPORT_PROJECT_NUMBER_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, "%" + Request["S_PojectNo"].ToString() + "%");
                }
            }
            if (Request["S_Well_ID"] != null)
            {
                if (Request["S_Well_ID"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.WELL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, "%" + Request["S_Well_ID"].ToString() + "%");
                }
            }
            if (Request["S_Location_ID"] != null)
            {
                if (Request["S_Location_ID"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.LOCATION_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, "%" + Request["S_Location_ID"].ToString() + "%");
                }
            }
            if (Request["S_Site_of_Tissue_Collection"] != null)
            {
                if (Request["S_Site_of_Tissue_Collection"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.SITE_OF_TISSUE_COLLECTION_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, "%" + Request["S_Site_of_Tissue_Collection"].ToString() + "%");
                }
            }
            if (Request["S_Preserve_Method"] != null)
            {
                if (Request["S_Preserve_Method"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.PRESERVE_METHOD_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, "%" + Request["S_Preserve_Method"].ToString() + "%");
                }
            }
            if (Request["S_Date_of_Tissue_Collection"] != null)
            {
                if (Request["S_Date_of_Tissue_Collection"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.DATE_OF_TISSUE_COLLECTION_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, Request["S_Date_of_Tissue_Collection"].ToString());
                }
            }
            if (Request["S_Animal_Number"] != null)
            {
                if (Request["S_Animal_Number"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.ANIMAL_NUMBER_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, Request["S_Animal_Number"].ToString());
                }
            }
            if (Request["S_Pn"] != null)
            {
                if (Request["S_Pn"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.PN_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, Request["S_Pn"].ToString());
                }
            }
            if (Request["S_Region"] != null)
            {
                if (Request["S_Region"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.REGION_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, Request["S_Region"].ToString());
                }
            }
            paraList.Clause = Clause;
            return paraList;
        }
   

   

     

    
    }
}