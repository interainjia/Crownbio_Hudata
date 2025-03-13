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

namespace PDXmodelBase.HuData
{
    public partial class CaseReport : System.Web.UI.Page
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
                bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "CaseReport", "view");
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
                        if (fn.OPERATE == "Cancer_Type" || fn.OPERATE == "Subtype1" || fn.OPERATE == "Subtype2")
                        {
                            js.Append("$('#div" + fn.OPERATE + "').css('display','none');");
                        }
                        else
                        {
                            js.Append("$('#txt" + fn.OPERATE + "').css('display','none');");
                        }
                    }
                    else {
                        isShow = true;
                    }
                }
                if (!isShow)
                {
                    js.Append("$('#divPDXmodelImport').css('display','none');");
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
                                if (dr["Current_Project_Number"].ToString() != "Revival")
                                {
                                    DateTime time = DateTime.Parse(dr["DOI"].ToString()).AddDays(int.Parse(dr["Time_of_Model_for_Transplant"].ToString()));
                                    dot = FormatHelper.getFormatDate(time);
                                }
                                else
                                {
                                    PDXMODEL_INFO pdxmodel = pdxmodels.Find(delegate(PDXMODEL_INFO perm) { return perm.MODEL_ID == dr["MODEL_ID"].ToString(); });
                                    if (pdxmodel != null)
                                    {
                                        if (pdxmodel.TIME_OF_REVIVAL != "" && pdxmodel.TIME_OF_REVIVAL != "NT")
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
                                            DateTime time = DateTime.Parse(dr["DOI"].ToString()).AddDays(int.Parse(revival));
                                            dot = FormatHelper.getFormatDate(time);
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

    }
}