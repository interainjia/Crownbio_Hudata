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
using System.Text;
using System.Data.SqlClient;

namespace PDXmodelBase.HuData
{
    public partial class PDXmodelInfo : System.Web.UI.Page
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
                //bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "PDXModelInfo", "view");
                bool havePerm = ojbReportRule.GetUserFunctions2(userLogin.Permission, "PDXModelInfo", AppConfig.UserViewRightList);
                if (!havePerm)
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                    return;
                }
                StringBuilder js = new StringBuilder();
                ParamCollection paralist = new ParamCollection();
                paralist.Clause = HUBASE_FUNCTION.FUNCTION_NAME_FIELD + "='PDXModelInfo-save'";
                BaseList functions = bll.Select(paralist, typeof(HUBASE_FUNCTION));
                bool isShow = false;
                foreach (HUBASE_FUNCTION fn in functions)
                {
                    bool havePerm2 = ojbReportRule.GetUserFunctions(userLogin.Permission, "PDXModelInfo-save", fn.OPERATE);
                    if (!havePerm2)
                    {
                        if (fn.OPERATE == "Source" || fn.OPERATE == "Cachexia_Label" || fn.OPERATE == "Cachexia" || fn.OPERATE == "Slight_BW_loss" || fn.OPERATE == "Normal" || fn.OPERATE == "Survival_Curve" || fn.OPERATE == "SOC" || fn.OPERATE == "Cancer_Type" || fn.OPERATE == "Subtype1" || fn.OPERATE == "Subtype2" || fn.OPERATE == "Model_From" || fn.OPERATE == "Origin" || fn.OPERATE == "STR_Consistence")
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
                    js.Append("$('#divPDXmodelImport').css('display','none');");
                }
                if (!ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin"))
                {
                    js.Append("$('#aExport3').css('display','none');");
                }

                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", js.ToString(), true);

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
                if (Session["dgModelInfo"] != null)
                {
                    DataTable dt = (DataTable)Session["dgModelInfo"];
                    DataTable temp = dt.Copy();
                    temp.Columns.Remove("ID");
                    temp.Columns.Remove("PDXMODEL_INFO_ID");
                    temp.Columns.Remove("Model_Status1");
                    temp.Columns.Remove("CurModel");
                    temp.Columns.Remove("PID");
                    temp.Columns.Remove("CODE");
                    temp.Columns.Remove("DESC");
                    temp.Columns.Remove("CHECK_CODE");
                    temp.Columns.Remove("Model_ID1");
                    //if (columns[0] == "")//全选
                    //{
                    //}
                    //else
                    //{
                    for (int i = temp.Columns.Count - 1; i >= 0; i--)
                    {
                        if (!columns.Contains(temp.Columns[i].ColumnName))
                        {
                            temp.Columns.Remove(temp.Columns[i].ColumnName);
                        }
                    }

                    //}
                    ToExport.TableToExcel(temp, "PDXmodelInfo");
                    hfAvailableColumns.Value = "";
                }
            }
        }


        protected void btnExport2_Click(object sender, EventArgs e)
        {
            if (Session["dgModelInfo"] != null)
            {
                string mids = "";
                DataTable mdata = (DataTable)Session["dgModelInfo"];
                foreach (DataRow dr in mdata.Rows)
                {
                    mids += "'" + dr["MODEL_ID"] + "',";
                }

                DataTable dtAll = new DataTable();
                dtAll = ojbReportRule.GetgridAnimalInfo();
                DataView dv = dtAll.DefaultView;

                if (mids != "")
                {
                    dv.RowFilter = "MODEL_ID in (" + mids.TrimEnd(',') + ")";
                    dtAll = dv.ToTable();
                }
                Session["dgExportAnimalInfo"] = null;
                if (dtAll.Rows.Count > 0)
                {
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
                                    PDXMODEL_INFO pdxmodel = pdxmodels.Find(delegate (PDXMODEL_INFO perm) { return perm.MODEL_ID == dr["MODEL_ID"].ToString(); });
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
                    dtAll.Columns["Estimated_DOT"].SetOrdinal(dtAll.Columns.Count - 2);//换位置
                    dtAll = dtAll.DefaultView.ToTable();
                    Session["dgExportAnimalInfo"] = dtAll;
                }




                string[] columns = { };
                if (hfAvailableColumns2.Value != "")
                {
                    columns = hfAvailableColumns2.Value.Split(',');
                    if (Session["dgExportAnimalInfo"] != null)
                    {
                        DataTable dt = (DataTable)Session["dgExportAnimalInfo"];
                        DataTable temp = dt.Copy();
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
                        ToExport.TableToExcel(temp, "AnimalInfo");
                        hfAvailableColumns2.Value = "";
                    }
                }
            }




        }

        protected void btnExport3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable joindt = new DataTable();
            DataTable dtAll = new DataTable();
            BaseList dataModelInfo = bll.Select(typeof(PDXMODEL_INFO));

            SqlParameter[] para = new SqlParameter[] { };
            DataTable modelstatus = ojbReportRule.GetGrid("GetPDXmodel_modelstatus", para);
            joindt = UtitityHelper.ToDataTable(dataModelInfo);
            #region 转换列名
            foreach (DataColumn dc in joindt.Columns)
            {
                if (dc.ColumnName == "CACHEXIA")
                {
                    dc.ColumnName = "Cachexia";
                }
                if (dc.ColumnName == "SLIGHT_BW_LOSS")
                {
                    dc.ColumnName = "Slight_BW_loss";
                }
                if (dc.ColumnName == "NORMAL")
                {
                    dc.ColumnName = "Normal";
                }
                if (dc.ColumnName == "ULCERATION_LABEL")
                {
                    dc.ColumnName = "Ulceration_Label";
                }
                if (dc.ColumnName == "SQ_NUMBER")
                {
                    dc.ColumnName = "Sq_Number";
                }
                else if (dc.ColumnName == "CANCER_TYPE_ABBR")
                {
                    dc.ColumnName = "Cancer_Type_Abbr";
                }
                else if (dc.ColumnName == "MODEL_ID")
                {
                    dc.ColumnName = "Model_ID";
                }
                else if (dc.ColumnName == "FROM")
                {
                    dc.ColumnName = "From";
                }
                else if (dc.ColumnName == "ORIGIN")
                {
                    dc.ColumnName = "Origin";
                }
                else if (dc.ColumnName == "CANCER_TYPE")
                {
                    dc.ColumnName = "Cancer_Type";
                }
                else if (dc.ColumnName == "SUBTYPE1")
                {
                    dc.ColumnName = "Subtype1";
                }
                else if (dc.ColumnName == "SUBTYPE2")
                {
                    dc.ColumnName = "Subtype2";
                }
                else if (dc.ColumnName == "MODEL_CATEGORY")
                {
                    dc.ColumnName = "Model_Category";
                }
                else if (dc.ColumnName == "MODEL_STATUS")
                {
                    dc.ColumnName = "Model_Status1";
                }
                else if (dc.ColumnName == "SOURCE_ID")
                {
                    dc.ColumnName = "Source_ID";
                }
                else if (dc.ColumnName == "SOURCE_NOTE")
                {
                    dc.ColumnName = "Source_Note";
                }
                else if (dc.ColumnName == "PDX_QC")
                {
                    dc.ColumnName = "PDX_QC";
                }
                else if (dc.ColumnName == "TOTAL_REVIVAL_SUCCESS_RATE")
                {
                    dc.ColumnName = "Total_Revival_Success_Rate";
                }
                else if (dc.ColumnName == "REVIVAL_RECOMMENDED_STRAIN")
                {
                    dc.ColumnName = "Revival_Recommended_Strain";
                }
                else if (dc.ColumnName == "TIME_OF_REVIVAL")
                {
                    dc.ColumnName = "Time_of_Revival";
                }
                else if (dc.ColumnName == "MAINTAIN_RECOMMENDED_STRAIN")
                {
                    dc.ColumnName = "Maintain_Recommended_Strain";
                }
                else if (dc.ColumnName == "STR_CONSISTENCE")
                {
                    dc.ColumnName = "STR_Consistence";
                }
                else if (dc.ColumnName == "EXOMESEQ")
                {
                    dc.ColumnName = "Exomeseq";
                }
                else if (dc.ColumnName == "IN_HUBA")
                {
                    dc.ColumnName = "In_Huba";
                }
                else if (dc.ColumnName == "AVAILABLE_SITE")
                {
                    dc.ColumnName = "Available_Site";
                }
                else if (dc.ColumnName == "TIME_OF_MODEL_FOR_TRANSPLANT")
                {
                    dc.ColumnName = "Time_of_Model_for_Transplant";
                }
                else if (dc.ColumnName == "CV40_TAKE_RATE")
                {
                    dc.ColumnName = "Spare_for_CV40";
                }
                else if (dc.ColumnName == "CV30_TAKE_RATE")
                {
                    dc.ColumnName = "Spare_for_CV30";
                }
                else if (dc.ColumnName == "OPTIMAL_OVERAGE")
                {
                    dc.ColumnName = "Optimal_Overage";
                }
                else if (dc.ColumnName == "DOSING_WINDOW")
                {
                    dc.ColumnName = "Dosing_Window";
                }
                else if (dc.ColumnName == "CRYO_P_0")
                {
                    dc.ColumnName = "Cryo_P";
                }
                else if (dc.ColumnName == "SNAP_FROZEN_0")
                {
                    dc.ColumnName = "Snap_Frozen";
                }
                else if (dc.ColumnName == "FFPE")
                {
                    dc.ColumnName = "FFPE1";
                }
                else if (dc.ColumnName == "FFPE_0")
                {
                    dc.ColumnName = "FFPE";
                }
                else if (dc.ColumnName == "TIMES_USED_IN_STUDY")
                {
                    dc.ColumnName = "Times_Used_In_Study";
                }
                else if (dc.ColumnName == "CACHEXIA_LABEL")
                {
                    dc.ColumnName = "Cachexia_Label";
                }
                else if (dc.ColumnName == "SURVIVAL_CURVE")
                {
                    dc.ColumnName = "Survival_Curve";
                }
                else if (dc.ColumnName == "UPDATE_TIME")
                {
                    dc.ColumnName = "Time_of_Update";
                }
                else if (dc.ColumnName == "COMMENTS")
                {
                    dc.ColumnName = "Comments";
                }
                else if (dc.ColumnName == "LOCATION")
                {
                    dc.ColumnName = "Location";
                }
                else if (dc.ColumnName == "TOTAL_REVIVAL_SUCCESS_RATE_CBNC")
                {
                    dc.ColumnName = "Total_Revival_Success_Rate_CBNC";
                }
                else if (dc.ColumnName == "TIME_OF_REVIVAL_CBNC")
                {
                    dc.ColumnName = "Time_of_Revival_CBNC";
                }
                else if (dc.ColumnName == "REVIVAL_RECOMMENDED_STRAIN_CBNC")
                {
                    dc.ColumnName = "Revival_Recommended_Strain_CBNC";
                }
                else if (dc.ColumnName == "TREATMENT_HISTORY_1")
                {
                    dc.ColumnName = "Treatment_history_1";
                }
                else if (dc.ColumnName == "TREATMENT_HISTORY_2")
                {
                    dc.ColumnName = "Treatment_history_2";
                }
                else if (dc.ColumnName == "DEATHRATE")
                {
                    dc.ColumnName = "DeathRate";
                }
                else if (dc.ColumnName == "SOURCE")
                {
                    dc.ColumnName = "Source";
                }
                else if (dc.ColumnName == "IMPLANTATION_METHOD")
                {
                    dc.ColumnName = "Implantation_Method";
                }
            }

            #endregion
            if (joindt.Rows.Count > 0 && modelstatus.Rows.Count > 0)
            {
                dtAll = DataJoin.Join(joindt, modelstatus, "Model_ID", "MODEL_ID", 1, true, false);//join modelstatus
            }

            if (dtAll.Rows.Count > 0)
            {
                dtAll.Columns[dtAll.Columns.Count - 1].SetOrdinal(12); //列交换位置,含ID列
                dtAll.DefaultView.Sort = "Sq_Number asc";
                dtAll = dtAll.DefaultView.ToTable();
                dtAll.Columns.Remove("CRYO_P");
                dtAll.Columns.Remove("SNAP_FROZEN");
                dtAll.Columns.Remove("FFPE1");
                dtAll.Columns.Remove("CODE");
                dtAll.Columns.Remove("CurModel");
                dtAll.Columns.Remove("PID");
                dtAll.Columns.Remove("DESC");
                dtAll.Columns.Remove("CHECK_CODE");
                dtAll.Columns.Remove("Model_ID1");
                ToExport.TableToExcel(dtAll, "PDXmodelInfo");
            }
        }

     
    }
}