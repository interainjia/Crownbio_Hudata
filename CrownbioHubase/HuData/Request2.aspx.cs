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
    public partial class Request2 : System.Web.UI.Page
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
                bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "Request", "view");
                if (!havePerm)
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                    return;
                }
                //if (userLogin.DEPARTMENT == "BD")
                //{
                //    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key", "$('#ccBD').val('" + userLogin.USER_NAME + "');", true);
                //}
                //else if (userLogin.DEPARTMENT == "SD")
                //{
                //    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key", "$('#ccSD').val('" + userLogin.USER_NAME + "');", true);
                //}
                //else if (userLogin.DEPARTMENT == "SIMM")
                //{
                //    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key", "$('#txtClient').val('" + userLogin.USER_NAME + "');$('#txtClient').prop(\"disabled\", true);", true);
                //}
              
                bool havePerm3 = ojbReportRule.GetUserFunctions(userLogin.Permission, "Request", "edit");
                if (!havePerm3)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", "$('#divTosubject').css('display','none');$('#divRequestImport').css('display','none');$('#btnSaveBooking').css('display','none');document.getElementById('btndelete').style.display = 'none'; ", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", "$('#divTosubject').css('display','inline-block');$('#divRequestImport').css('display','block');$('#btnSaveBooking').css('display','inline-block');document.getElementById('btndelete').style.display = 'inline-block'; ", true);
                }
                bool havePerm4 = ojbReportRule.GetUserFunctions(userLogin.Permission, "Request", "PM-edit");
                if (!havePerm4)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key3", "$('#btnSave1').css('display','none');", true);
                }
                else {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key3", "$('#btnSave1').css('display','inline-block');", true);
                
                }
            }
        }


     
 

        #region btnSend_OnClick
        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            //REQUEST row = new REQUEST(DealModel.New);
            //row.CLIENT = Request.Form["txtClient"];
            //row.DATE_REQUEST = DateTime.Parse(Request["txtDate_Request"]);

            //List<SYS_USER> dataUser = bll.Select(typeof(SYS_USER)).ConvertAll<SYS_USER>(SYS_USER.Convert);
            //string[] bd = Request.Form.GetValues("cc1");

            //string strBD = "";
            //if (bd != null)
            //{
            //    foreach (string id in bd)
            //    {
            //        SYS_USER user = dataUser.Find(delegate(SYS_USER perm) { return perm.USER_ID.ToString() == id; });
            //        if (user != null)
            //        {
            //            strBD += user.FIRST_NAME + " " + user.LAST_NAME + ",";
            //            //SendEmail.SendExchangeEmail("Subject", "Body.ToString()", user.EMAIL, "");
            //        }
            //    }
            //}
            //row.BD = strBD != "" ? strBD.TrimEnd(',') : "";

            //string[] sd = Request.Form.GetValues("cc2");
            //string strSD = "";
            //if (sd != null)
            //{
            //    foreach (string id in sd)
            //    {
            //        SYS_USER user = dataUser.Find(delegate(SYS_USER perm) { return perm.USER_ID.ToString() == id; });
            //        if (user != null)
            //        {
            //            strSD += user.FIRST_NAME + " " + user.LAST_NAME + ",";
            //            //SendEmail.SendExchangeEmail("Subject", "Body.ToString()", user.EMAIL, "");
            //        }
            //    }
            //}
            //row.SD = strSD != "" ? strSD.TrimEnd(',') : "";
            //row.OTHERS_TO_NOTIFY = txtOthers.Text.Trim();
            //row.TUMOR_TYPE = ddlTumor_Type.SelectedIndex == 0 ? "" : ddlTumor_Type.SelectedValue;
            //row.SUBTYPE = ddlSubtype.SelectedIndex == 0 ? "" : ddlSubtype.SelectedValue;
            //row.MODEL_ID = Request.Form["txtModel_ID"].ToString();
            //row.POTENTIAL_STUDY_SIZE = int.Parse(txtPotential_Study_Size.Text.Trim());
            //row.SPECIAL_REQUIREMENTS = txtRequirements.Text.Trim();
            //bll.Update(row);
            //row.CurModel = DealModel.None;

            //string emails = txtOthers.Text.Trim();
            //foreach (string email in emails.Split(','))
            //{
            //    if (RegHelper.IsEmail(email))
            //    {
            //        //SendEmail.SendExchangeEmail("Subject", "Body.ToString()", email, "");
            //    }
            //}
        }
        #endregion
        protected void btnExport1_Click(object sender, EventArgs e)
        {
            string[] columns = { };
            if (hfAvailableColumns.Value != "")
            {
                columns = hfAvailableColumns.Value.Split(',');
                if (Session["dgRequest"] != null)
                {
                    DataTable dt = (DataTable)Session["dgRequest"];
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
                    ToExport.TableToExcel(temp, "Request");
                    hfAvailableColumns.Value = "";
                }
            }
         
        }
        protected void btnExport2_Click(object sender, EventArgs e)
        {
            string[] columns = { };
            if (hfAvailableColumns2.Value != "")
            {
                columns = hfAvailableColumns2.Value.Split(',');
                if (Session["dgSelectMice2"] != null)
                {

                    DataTable dt = (DataTable)Session["dgSelectMice2"];
                    DataTable temp = dt.Copy();
                    temp.TableName = "table1";
                    string hfexport1 = hfexport.Value;
                    string ids = "";
                    foreach (string a in hfexport1.Split(','))
                    {
                        if (a != "")
                        {
                            ids += "'" + a + "',";
                        }
                    }
                    DataTable newdt = new DataTable();
                    newdt = temp.Clone();
                    DataRow[] drs = temp.Select("AutoID in (" + ids.TrimEnd(',') + ")");
                    for (int i = 0; i < drs.Length; i++)
                    {
                        newdt.ImportRow((DataRow)drs[i]);
                    }
                    SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Model_ID", ""), new SqlParameter("@PN", newdt.Rows[0]["Project_Number"]) };
                    DataTable data = ojbReportRule.GetGrid("GetAnimalStatus", para);

                    DataTable dtAll = DataJoin.Join(newdt, data, "MODEL_ID", "MODEL_ID", 1, true, false);
                    dtAll.Columns.Remove("ANIMAL_INFO_ID");
                    dtAll.Columns.Remove("MODEL_ID1");
                    //dtAll.Columns.Remove("Model_Category");
                    //dtAll.Columns.Remove("Location_of_live_animal");
                    //dtAll.Columns.Remove("Animal_Room_Number");
                    //dtAll.Columns.Remove("IVC_Location");
                    //dtAll.Columns.Remove("Model_status");
                    //dtAll.Columns.Remove("Time_of_Model_for_Transplant");
                    dtAll.Columns.Remove("Have_Animals");
                    dtAll.Columns.Remove("AutoID");
                    dtAll.Columns.Remove("Location");
                    #region 计算Estimated_DOT
                    List<PDXMODEL_INFO> pdxmodels = bll.Select(typeof(PDXMODEL_INFO)).ConvertAll<PDXMODEL_INFO>(PDXMODEL_INFO.Convert);

                    dtAll.Columns.Add("Estimated_DOT");
                    foreach (DataRow dr in dtAll.Rows)
                    {
                        string dot = "";
                        int kk = 0;
                        if (dr["Time_of_Model_for_Transplant"].ToString() == "ND")
                        {
                            dot = "Depending on TV";
                        }
                        else if (dr["Time_of_Model_for_Transplant"].ToString() == "" || dr["Current_Project_Number"].ToString() == "No live animals")
                        {
                            dot = "N/A";
                        }
                        else if (dr["Current_Project_Number"].ToString() != "No live animals" && dr["Time_of_Model_for_Transplant"].ToString() != "ND")
                        {
                            try
                            {
                                if (dr["MODEL_ID"].ToString() == "CR0004" || dr["MODEL_ID"].ToString() == "BL3249")
                                {

                                }
                                if (dr["Current_Project_Number"].ToString() != "Revival")
                                {
                                    if (dr["DOI"] != null && dr["DOI"].ToString() != "" && RegHelper.IsNumber(dr["Time_of_Model_for_Transplant"].ToString().Trim()))
                                    {
                                        kk = 1;
                                        DateTime time = DateTime.Parse(dr["DOI"].ToString()).AddDays(int.Parse(dr["Time_of_Model_for_Transplant"].ToString().Trim()));
                                        dot = FormatHelper.getFormatDate(time);
                                    }
                                }
                                else
                                {
                                    PDXMODEL_INFO pdxmodel = pdxmodels.Find(delegate(PDXMODEL_INFO perm) { return perm.MODEL_ID == dr["MODEL_ID"].ToString(); });
                                    if (pdxmodel != null)
                                    {
                                        if (!string.IsNullOrEmpty(pdxmodel.TIME_OF_REVIVAL) && pdxmodel.TIME_OF_REVIVAL != "NT")
                                        {
                                            string revival = "";
                                            if (pdxmodel.TIME_OF_REVIVAL.IndexOf('(') != -1)
                                            {
                                                revival = pdxmodel.TIME_OF_REVIVAL.Substring(0, pdxmodel.TIME_OF_REVIVAL.IndexOf('('));
                                                if (revival.IndexOf('/') != -1)
                                                {
                                                    revival = revival.Substring(0, revival.IndexOf('/'));
                                                }
                                                else
                                                {
                                                    //revival = revival;
                                                }
                                            }
                                            else
                                            {
                                                revival = pdxmodel.TIME_OF_REVIVAL;
                                            }
                                            if (dr["DOI"] != null && dr["DOI"].ToString() != "" && RegHelper.IsNumber(revival.Trim()))
                                            {
                                                kk = 2;
                                                DateTime time = DateTime.Parse(dr["DOI"].ToString()).AddDays(int.Parse(revival.Trim()));
                                                dot = FormatHelper.getFormatDate(time);

                                            }
                                        }
                                        else
                                        {
                                            dot = "N/A";
                                        }
                                    }
                                    else
                                    {
                                        dot = "N/A";
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                int b = kk;
                                throw ex;
                            }
                        }
                        dr["Estimated_DOT"] = dot;
                    }
                    #endregion
                    //dtAll.Columns["Estimated_DOT"].SetOrdinal(dtAll.Columns.Count - 2);//换位置
                    dtAll.Columns["Client"].ColumnName = "Sponsor";
                  
                    if (columns[0] == "")//全选
                    {
                    }
                    else
                    {
                        for (int i = dtAll.Columns.Count - 1; i >= 0; i--)
                        {
                            if (!columns.Contains(dtAll.Columns[i].ColumnName))
                            {
                                dtAll.Columns.Remove(dtAll.Columns[i].ColumnName);
                            }
                        }

                    }
                    ToExport.TableToExcel(dtAll, "Model_Status");
                    hfAvailableColumns2.Value = "";
                }
            }
        }

        protected void btnSendmail_Click(object sender, EventArgs e)
        {
            if (Session["dgSelectMice2"] != null)
            {
                DataTable dt = (DataTable)Session["dgSelectMice2"];
                dt.TableName = "table1";
                string hfexport1 = hfexport.Value;
                string ids = "";
                foreach (string a in hfexport1.Split(','))
                {
                    if (a != "")
                    {
                        ids += "'" + a + "',";
                    }
                }
                DataTable newdt = new DataTable();
                newdt = dt.Clone();
                DataRow[] drs = dt.Select("AutoID in (" + ids.TrimEnd(',') + ")");
                for (int i = 0; i < drs.Length; i++)
                {
                    newdt.ImportRow((DataRow)drs[i]);
                }
                SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Model_ID", ""), new SqlParameter("@PN", newdt.Rows[0]["Project_Number"]) };
                DataTable data = ojbReportRule.GetGrid("GetAnimalStatus", para);

                DataTable dtAll = DataJoin.Join(newdt, data, "MODEL_ID", "MODEL_ID", 1, true, false);
                dtAll.Columns.Remove("ANIMAL_INFO_ID");
                dtAll.Columns.Remove("MODEL_ID1");
                dtAll.Columns.Remove("Model_Category");
                dtAll.Columns.Remove("Location_of_live_animal");
                dtAll.Columns.Remove("Animal_Room_Number");
                dtAll.Columns.Remove("IVC_Location");
                dtAll.Columns.Remove("Model_status");
                dtAll.Columns.Remove("Date_of_Update");
                dtAll.Columns.Remove("AutoID");

                #region 计算Estimated_DOT
                List<PDXMODEL_INFO> pdxmodels = bll.Select(typeof(PDXMODEL_INFO)).ConvertAll<PDXMODEL_INFO>(PDXMODEL_INFO.Convert);

                dtAll.Columns.Add("Estimated_DOT");
                foreach (DataRow dr in dtAll.Rows)
                {
                    string dot = "";
                    int kk = 0;
                    if (dr["Time_of_Model_for_Transplant"].ToString() == "ND")
                    {
                        dot = "Depending on TV";
                    }
                    else if (dr["Time_of_Model_for_Transplant"].ToString() == "" || dr["Current_Project_Number"].ToString() == "No live animals")
                    {
                        dot = "N/A";
                    }
                    else if (dr["Current_Project_Number"].ToString() != "No live animals" && dr["Time_of_Model_for_Transplant"].ToString() != "ND")
                    {
                        try
                        {
                            if (dr["MODEL_ID"].ToString() == "CR0004" || dr["MODEL_ID"].ToString() == "BL3249")
                            {

                            }
                            if (dr["Current_Project_Number"].ToString() != "Revival")
                            {
                                if (dr["DOI"] != null && dr["DOI"].ToString() != "" && RegHelper.IsNumber(dr["Time_of_Model_for_Transplant"].ToString().Trim()))
                                {
                                    kk = 1;
                                    DateTime time = DateTime.Parse(dr["DOI"].ToString()).AddDays(int.Parse(dr["Time_of_Model_for_Transplant"].ToString().Trim()));
                                    dot = FormatHelper.getFormatDate(time);
                                }
                            }
                            else
                            {
                                PDXMODEL_INFO pdxmodel = pdxmodels.Find(delegate(PDXMODEL_INFO perm) { return perm.MODEL_ID == dr["MODEL_ID"].ToString(); });
                                if (pdxmodel != null)
                                {
                                    if (!string.IsNullOrEmpty(pdxmodel.TIME_OF_REVIVAL) && pdxmodel.TIME_OF_REVIVAL != "NT")
                                    {
                                        string revival = "";
                                        if (pdxmodel.TIME_OF_REVIVAL.IndexOf('(') != -1)
                                        {
                                            revival = pdxmodel.TIME_OF_REVIVAL.Substring(0, pdxmodel.TIME_OF_REVIVAL.IndexOf('('));
                                            if (revival.IndexOf('/') != -1)
                                            {
                                                revival = revival.Substring(0, revival.IndexOf('/'));
                                            }
                                            else
                                            {
                                                //revival = revival;
                                            }
                                        }
                                        else
                                        {
                                            revival = pdxmodel.TIME_OF_REVIVAL;
                                        }
                                        if (dr["DOI"] != null && dr["DOI"].ToString() != "" && RegHelper.IsNumber(revival.Trim()))
                                        {
                                            kk = 2;
                                            DateTime time = DateTime.Parse(dr["DOI"].ToString()).AddDays(int.Parse(revival.Trim()));
                                            dot = FormatHelper.getFormatDate(time);

                                        }
                                    }
                                    else
                                    {
                                        dot = "N/A";
                                    }
                                }
                                else
                                {
                                    dot = "N/A";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            int b = kk;
                            throw ex;
                        }
                    }
                    dr["Estimated_DOT"] = dot;
                }
                #endregion
                dtAll.Columns.Remove("Time_of_Model_for_Transplant");
                string MSG = ToExport.ExcelToEmail(dtAll, "Model_Status");
                string msg1 = "$.messager.alert(\"info\", \"" + MSG + "\", \"info\", null);";
                ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "key", msg1, true);
            
            }
        }

     

    
    }
}