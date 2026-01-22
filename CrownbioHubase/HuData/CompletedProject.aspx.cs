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
    public partial class CompletedProject : System.Web.UI.Page
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
                //bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "CompletedProject", "view");
                bool havePerm = ojbReportRule.GetUserFunctions2(userLogin.Permission, "CompletedProject", AppConfig.UserViewRightList);
                if (!havePerm)
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                    return;
                }
              
            }
        }


        protected void btnExport2_Click(object sender, EventArgs e)
        {
            if (Session["dgProjectMonitor"] != null)
            {
                DataTable dt = (DataTable)Session["dgProjectMonitor"];
              
                ToExport.TableToExcel(dt, "ProjectMonitor");
            }
        }



        protected void btnExport1_Click(object sender, EventArgs e)
        {
            string[] columns = { };
            if (hfAvailableColumns.Value != "")
            {
                columns = hfAvailableColumns.Value.Split(',');
                if (Session["dgRequest_Completed"] != null)
                {
                    DataTable dt = (DataTable)Session["dgRequest_Completed"];
                    DataTable temp = dt.Copy();
                    temp.Columns.Remove("ID");
                    temp.Columns.Remove("DATE_REQUEST");
                    temp.Columns.Remove("RESPONDER_ID");
                    temp.Columns.Remove("HAVE_RESPONDED");
                    temp.Columns.Remove("REQUESTER_ID");
                    temp.Columns.Remove("RESPONDER");
                    temp.Columns.Remove("HAVE_CONFIRMED");
                    temp.Columns.Remove("CREATE_OF_DATE");
                    temp.Columns.Remove("CREATE_OF_DATE_F");
                    temp.Columns.Remove("DATE_RESPONDING");
                    temp.Columns.Remove("CONFIRM_DATE");
                    temp.Columns.Remove("CONFIRM_DATE_F");
                    temp.Columns.Remove("CurModel");
                    temp.Columns.Remove("PID");
                    temp.Columns.Remove("CODE");
                    temp.Columns.Remove("DESC");
                    temp.Columns.Remove("CHECK_CODE");
                    temp.Columns.Remove("REQUEST_ID1");
                    temp.Columns.Remove("log_count");
                    temp.Columns["DATE_REQUEST_F"].ColumnName = "DATE_OF_REQUEST";
                    temp.Columns["DATE_RESPONDING_F"].ColumnName = "DATE_OF_1ST_RESPONDING";
                    temp.Columns["CLIENT"].ColumnName = "SPONSOR";
                    temp.Columns["TUMOR_TYPE"].ColumnName = "CANCER_TYPE";
                    temp.Columns["PROJECT_NUMBER"].ColumnName = "Sub Project";
                    temp.Columns["PARENT_PROJECT"].ColumnName = "Major Project";
                    temp.Columns["SD"].ColumnName = "Executive SD";
                    temp.Columns["SIGNED"].ColumnName = "Request Status";
                    if (columns[0] == "")//全选
                    {
                    }
                    else
                    {
                        for (int i = temp.Columns.Count - 1; i >= 0; i--)
                        {
                            if (!columns.Contains(temp.Columns[i].ColumnName))
                            {
                                temp.Columns.Remove(temp.Columns[i].ColumnName);
                            }
                        }

                    }
                    ToExport.TableToExcel(temp, "Completed Project");
                    hfAvailableColumns.Value = "";
                }
            }

        }

   

     

    
    }
}