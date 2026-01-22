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
    public partial class ProjectMonitor : System.Web.UI.Page
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
                //bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "ProjectMonitor", "view");
                bool havePerm = ojbReportRule.GetUserFunctions2(userLogin.Permission, "ProjectMonitor", AppConfig.UserViewRightList);
                if (!havePerm)
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                    return;
                }
                bool havePerm3 = ojbReportRule.GetUserFunctions(userLogin.Permission, "ProjectMonitor", "JSD-edit");
                if (!havePerm3)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key3", "$('#btnSave').css('display','none');$('#btnJSD_edit').css('display','none');$('#divMonitorImport').css('display','none');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key3", "$('#btnSave').css('display','inline-block');$('#btnJSD_edit').css('display','inline-block');$('#divMonitorImport').css('display','block');", true);

                }
                bool havePerm4 = ojbReportRule.GetUserFunctions(userLogin.Permission, "ProjectMonitor", "PM-edit");
                if (!havePerm4)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key4", "$('#btnPM_edit').css('display','none');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key4", "$('#btnPM_edit').css('display','inline-block');", true);

                }
                bool havePerm5 = ojbReportRule.GetUserFunctions(userLogin.Permission, "ProjectMonitor", "Complete_study");
                if (!havePerm5)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key5", "$('#btnComplete_study').css('display','none');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key5", "$('#btnComplete_study').css('display','inline-block');", true);

                }
            }
        }

        protected void btnExport1_Click(object sender, EventArgs e)
        {
           
            ParamCollection paralist = new ParamCollection();
            paralist = query_dg();
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause) };
            DataTable dtAll = ojbReportRule.GetGrid("GetdgProjectMonitor_export", para);
            if (dtAll.Rows.Count > 0)
            {
                ToExport.TableToExcel(dtAll, "ProjectMonitor");
            }
        }

        private ParamCollection query_dg()
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            Clause += " where 1 = 1 ";

            paraList.Clause = Clause;
            return paraList;
        }









    }
}