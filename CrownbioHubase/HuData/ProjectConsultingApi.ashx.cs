using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using Crownbio.BLL;
using System.Data.SqlClient;
using System.IO;
using Crownbio.Common;
using Crownbio.Model;
using System.Web.SessionState;
using Crownbio.Utility;
using Newtonsoft.Json;
using Aspose.Cells;

namespace PDXmodelBase.HuData
{
    /// <summary>
    /// GetCelllineType 的摘要说明
    /// </summary>
    public class ProjectConsultingApi : IHttpHandler, IRequiresSessionState
    {
        ObjectBLL bll = new ObjectBLL();
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
                context.Response.ClearHeaders();
                context.Response.AppendHeader("Access-Control-Allow-Headers", "Content-Type,Content-Length, Authorization, Accept,X-Requested-With");
                context.Response.AppendHeader("Access-Control-Allow-Methods", "PUT,POST,GET,DELETE,OPTIONS");

            int page = 1;
            int row = 10;

            context.Response.ContentType = "text/plain";
            if (context.Request["rows"] != null)
            {
                row = int.Parse(context.Request["rows"].ToString());
                page = int.Parse(context.Request["page"].ToString());

            }
            string Method = context.Request.Params["M"];
            switch (Method)
            {
                #region 

                case "getdgProjectConsulting":
                    getdgProjectConsulting(context, row, page);
                    break;
                case "SaveProjectConsulting":
                    SaveProjectConsulting(context);
                    break;
                case "deleteProjectConsulting":
                    deleteProjectConsulting(context);
                    break;
                case "importProjectConsulting":
                    importProjectConsulting(context);
                    break;
                    #endregion

            }
        }

        public void getdgProjectConsulting(HttpContext context, int pageSize, int CurrentPageIndex)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = query_dgProjectConsulting(context);

            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause)
                , new SqlParameter("@pageSize", pageSize)
                ,new SqlParameter("@CurrentPageIndex", CurrentPageIndex)};

            paralist.Clause = paralist.Clause.Replace("where", "");
            var dtAll = bll.GetCount(paralist,typeof(PROJECTCONSULTING));
            if (dtAll > 0)
            {
                DataTable dt = ojbReportRule.GetGrid("GetdgProjectConsulting", para);

                var list = new { total = dtAll, rows = dt };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
            else
            {
                var list = new { total = 0, rows = new List<object>() };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
        }

        private ParamCollection query_dgProjectConsulting(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["S_ModelID"] != null)
            {
                if (context.Request["S_ModelID"].ToString() != "")
                {
                    column = PROJECTCONSULTING.MODELID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", PROJECTCONSULTING.TABLE_NAME, column, "%" + context.Request["S_ModelID"].ToString() + "%");
                }
            }
            if (context.Request["S_Customer"] != null)
            {
                if (context.Request["S_Customer"].ToString() != "")
                {
                    column = PROJECTCONSULTING.CUSTOMER_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", PROJECTCONSULTING.TABLE_NAME, column, "%" + context.Request["S_Customer"].ToString() + "%");
                }
            }
         
            paraList.Clause = Clause;
            return paraList;
        }


        public void SaveProjectConsulting(HttpContext context)
        {
            string msg = "";
            PROJECTCONSULTING row = null;
            decimal pid = decimal.Parse(context.Request["hfProjectConsulting_ID"]);

            ParamCollection paralist = new ParamCollection();
            paralist.Clause = PROJECTCONSULTING.PROJECTCONSULTING_ID_FIELD + "= '" + pid + "'";
            BaseList data = bll.Select(paralist, typeof(PROJECTCONSULTING));
            try
            {
                if (data.Count == 0)
                {
                    row = new PROJECTCONSULTING(DealModel.New);
                }
                else
                {
                    row = (PROJECTCONSULTING)data[0];
                    row.CurModel = DealModel.Modify;
                }
                #region 新增修改
                row.MODELID = context.Request["ModelID"] ?? "";
                row.CANCERTYPE = context.Request["CancerType"] ?? "";
                row.LIVESTATUS = context.Request["LiveStatus"] ?? "";
                row.PN = context.Request["Pn"] ?? "";
                row.LOCATION = context.Request["Location"] ?? "";
                row.ESTIMATED_TIMEFRAME_OF_INOCULATION = context.Request["Estimated_Timeframe_of_inoculation"] ?? "";
                row.CONFIDENCESCORE = context.Request["ConfidenceScore"] ?? "";
                row.AVAILABLEIN = context.Request["AvailableIn"] ?? "";
                row.SPECIALFEATURE = context.Request["SpecialFeature"] ?? "";
                row.COMMENT = context.Request["Comment"] ?? "";
                row.BD = context.Request["BD"] ?? "";
                row.CUSTOMER = context.Request["Customer"] ?? "";
                row.CONSULTATIONDATE = DateTime.Parse(context.Request["ConsultationDate"].ToString());
                row.PROJECTNO = context.Request["ProjectNo"] ?? "";
                row.CAUSE = context.Request["Cause"] ?? "";

                row.TIME_OF_UPDATE = DateTime.Now;
                SYS_USER userLogin = CacheHelper.getCurrentUser();
                row.NAME_OF_UPDATE = userLogin.USER_NAME;

                decimal id = bll.Update(row);
                if (row.CurModel == DealModel.New)
                    row.ID = id;
                row.CurModel = DealModel.None;
                #endregion
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
            }

            context.Response.Write(msg);
        }

        public void deleteProjectConsulting(HttpContext context)
        {
            string msg = "";
            string delProjectConsulting_ID = context.Request["delProjectConsulting_ID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (ProjectConsulting_ID = '{0}' )", delProjectConsulting_ID);

            BaseList data = bll.Select(paraList, typeof(PROJECTCONSULTING));
            if (data.Count > 0)
            {
                PROJECTCONSULTING row = (PROJECTCONSULTING)data[0];
                row.CurModel = DealModel.Delete;
                bll.Delete(row);

                msg = "Delete successfully";
            }
            context.Response.Write(msg);
        }

        public void importProjectConsulting(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                try
                {
                    string filePath = updateInfoNew(context);
                    Workbook book = new Workbook(filePath);
                    Worksheet sheet = book.Worksheets[0];

                    Cells cells = sheet.Cells;
                    if (cells.MaxDataColumn != 17)
                    {
                        context.Response.Write("Import format error");
                        return;
                    }
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        if (cells[i, 0].StringValue != "Model ID" && cells[i, 0].StringValue != "")
                        {
                            PROJECTCONSULTING row = null;
                            try
                            {
                                ParamCollection paraList = new ParamCollection();
                                paraList.Clause += string.Format(" (ModelID = '{0}' )", cells[i, 0].StringValue.Trim());
                                paraList.Clause += string.Format(" and (BD = '{0}' )", cells[i, 10].StringValue.Trim());
                                paraList.Clause += string.Format(" and (LiveStatus = '{0}' )", cells[i, 2].StringValue.Trim());
                                paraList.Clause += string.Format(" and (Pn = '{0}' )", cells[i, 3].StringValue.Trim());
                                paraList.Clause += string.Format(" and (Location = '{0}' )", cells[i, 4].StringValue.Trim());
                                paraList.Clause += string.Format(" and (Customer = '{0}' )", cells[i, 11].StringValue.Trim());
                                paraList.Clause += string.Format(" and (SpecialFeature = '{0}' )", cells[i, 8].StringValue.Trim());
                                paraList.Clause += string.Format(" and (Comment = '{0}' )", cells[i, 9].StringValue.Trim());
                                paraList.Clause += string.Format(" and (Estimated_Timeframe_of_inoculation = '{0}' )", cells[i, 5].StringValue.Trim());
                                paraList.Clause += string.Format(" and (ConsultationDate = '{0}' )", FormatHelper.getFormatDate(DateTime.Parse(cells[i, 12].StringValue.Trim())));

                                var data = bll.Select(paraList, typeof(PROJECTCONSULTING));
                                var list = data.ConvertAll(PROJECTCONSULTING.Convert);
                                if (list.Count > 0)
                                {
                                    row = list[0];
                                }
                            }
                            catch (Exception ex)
                            {
                                row = null;
                            }
                            if (row == null)
                            {
                                row = new PROJECTCONSULTING(DealModel.New);
                                row.MODELID = cells[i, 0].StringValue.Trim() ?? "";
                                row.CANCERTYPE = cells[i, 1].StringValue.Trim() ?? "";
                                row.LIVESTATUS = cells[i, 2].StringValue.Trim() ?? "";
                                row.PN = cells[i, 3].StringValue.Trim() ?? "";
                                row.LOCATION = cells[i, 4].StringValue.Trim() ?? "";
                                row.ESTIMATED_TIMEFRAME_OF_INOCULATION = cells[i, 5].StringValue.Trim() ?? "";
                                row.CONFIDENCESCORE = cells[i, 6].StringValue.Trim() ?? "";
                                row.AVAILABLEIN = cells[i, 7].StringValue.Trim() ?? "";
                                row.SPECIALFEATURE = cells[i, 8].StringValue.Trim() ?? "";
                                row.COMMENT = cells[i, 9].StringValue.Trim() ?? "";
                                row.BD = cells[i, 10].StringValue.Trim() ?? "";
                                row.CUSTOMER = cells[i, 11].StringValue.Trim() ?? "";
                                row.CONSULTATIONDATE = cells[i, 12].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 12].StringValue.Trim());
                                row.PROJECTNO = cells[i, 16].StringValue.Trim() ?? "";
                                row.CAUSE = cells[i, 15].StringValue.Trim() ?? "";

                                row.TIME_OF_UPDATE = DateTime.Now;
                                SYS_USER userLogin = CacheHelper.getCurrentUser();
                                row.NAME_OF_UPDATE = userLogin.USER_NAME;
                                bll.Update(row);
                            }
                        }
                    }
                    context.Response.Write("Import successfully");
                }
                catch (Exception ex)
                {
                    context.Response.Write("Import error");
                }
            }
            else
            {
                context.Response.Write("Please add file.");
            }
        }

        public string updateInfoNew(HttpContext context)
        {
            string msg = "";
            try
            {
                string strUploadPath = context.Server.MapPath("../UploadUser/tempFile") + "\\";
                for (int i = 0; i < context.Request.Files.Count; i++)
                {
                    HttpPostedFile postedFile = context.Request.Files[i];

                    if (!Directory.Exists(strUploadPath))
                    {
                        Directory.CreateDirectory(strUploadPath);
                    }
                    string fileName = strUploadPath + Path.GetFileName(postedFile.FileName);
                    if (fileName != "")
                    {
                        postedFile.SaveAs(fileName);

                        msg = fileName;
                    }
                }
                return msg;

            }
            catch (Exception ex)
            {
                return "";
            }

        }
    }
}