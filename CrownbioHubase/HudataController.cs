using Aspose.Cells;
using Crownbio.BLL;
using Crownbio.BLL.Rule;
using Crownbio.Common;
using Crownbio.Model;
using Crownbio.Utility;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace PDXmodelBase
{
    public class HudataController : ApiController, IRequiresSessionState
    {
        ObjectBLL bll = new ObjectBLL();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody]dynamic ojb)
        {
            return ojb.value;
        }

        // PUT api/<controller>/5  ,修改
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        public HttpResponseMessage SaveRequest([FromBody]dynamic ojb)
        {
            string msg = "";
            string code = "";
            try
            {
                string _email = ojb.email ?? "";
                string _pwd = ojb.password ?? "";
                var query = new ParamCollection();
                query.Clause += "email = '" + _email + "' and user_pwd = '" + DEncryptHelper.Encrypt(_pwd) + "'";
                var existUser = bll.Select(query, typeof(SYS_USER));
                if (existUser.Count > 0)
                {
                    string hfRequest_id = ojb.hfRequest_id ?? "";
                    string txtProjectNumber = ojb.txtProjectNumber ?? "";
                    BaseList exist = new BaseList();
                    if (txtProjectNumber != "")
                    {
                        ParamCollection query1 = new ParamCollection();
                        query1.Clause = REQUEST.PROJECT_NUMBER_FIELD + "='" + txtProjectNumber + "' and " + REQUEST.REQUEST_ID_FIELD + " <> '" + hfRequest_id + "' and " + REQUEST.ISDELETE_FIELD + " <> 'Y'";
                        exist = bll.Select(query1, typeof(REQUEST));
                    }
                    if (exist.Count == 0)
                    {
                        REQUEST row = null;

                        ParamCollection paraList = new ParamCollection();
                        paraList.Clause = REQUEST.REQUEST_ID_FIELD + "='" + hfRequest_id + "'";
                        BaseList data = bll.Select(paraList, typeof(REQUEST));
                        if (data.Count > 0)
                        {
                            string txtDate_of_1st_responding = ojb.txtDate_of_1st_responding ?? "";
                            string editRemark = ojb.editRemark ?? "";

                            row = (REQUEST)data[0];
                            #region 保存旧request
                            REQUEST_LOG logrow = new REQUEST_LOG(DealModel.New);
                            logrow.REQUEST_ID = row.REQUEST_ID;
                            logrow.MODEL_ID = row.MODEL_ID;
                            logrow.STUDY_SIZE = row.POTENTIAL_STUDY_SIZE;
                            logrow.DATE_OF_1ST_RESPONDING = row.DATE_RESPONDING != null ? row.DATE_RESPONDING : DateTime.MinValue;
                            logrow.REMARK = row.REMARK != null ? doTran(row.REMARK) : "";
                            logrow.SIGNED = row.SIGNED;
                            logrow.PROJECT_NUMBER = row.PROJECT_NUMBER;
                            logrow.CREATE_OF_DATE = row.CREATE_OF_DATE;
                            logrow.BD = row.BD;
                            logrow.PARENT_PROJECT = row.PARENT_PROJECT;
                            logrow.LEADING_SD = row.LEADING_SD;
                            logrow.SD = row.SD;
                            logrow.CLIENT = row.CLIENT;
                            logrow.PM = row.PM;

                            logrow.EDITOR = ((SYS_USER)existUser[0]).USER_NAME;
                            bll.Update(logrow);
                            #endregion

                            #region 删除 旧booking、further、revive
                            string editModel_ID = ojb.txtModel_ID.Value.Replace("\n", "") ?? "";
                            if (editModel_ID == "")
                            {
                                SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TUMOR_TYPE", row.TUMOR_TYPE)
                        ,new SqlParameter("@subtype1",row.SUBTYPE1)  ,new SqlParameter("@subtype2",row.SUBTYPE2) ,new SqlParameter("@REQUEST_ID",row.REQUEST_ID)
                        };
                                DataTable mdata = ojbReportRule.GetGrid("GetRequestPart2-2", para);
                                ArrayList lists = new ArrayList();
                                foreach (DataRow mid in mdata.Rows)
                                {
                                    lists.Add(mid["Model_ID"]);
                                }
                                editModel_ID = string.Join(",", lists.ToArray());
                            }

                            ParamCollection delQuery = new ParamCollection();
                            delQuery.Clause = PROJECT_BOOKING.PROJECT_NUMBER_FIELD + "='" + row.PROJECT_NUMBER + "'";
                            if (editModel_ID != "")
                            {
                                string ids = "";
                                foreach (string a in editModel_ID.Split(','))
                                {
                                    if (a != "")
                                    {
                                        ids += "'" + a + "',";
                                    }
                                }

                                delQuery.Clause += string.Format("AND ({0}.{1} not in ({2}) )", PROJECT_BOOKING.TABLE_NAME, PROJECT_BOOKING.MODEL_ID_FIELD, ids.TrimEnd(','));
                            }
                            BaseList deletes = bll.Select(delQuery, typeof(PROJECT_BOOKING));
                            foreach (PROJECT_BOOKING del in deletes)
                            {
                                del.CurModel = DealModel.Delete;
                            }
                            bll.UpdateAllByParams(deletes);



                            ParamCollection delQuery2 = new ParamCollection();
                            delQuery2.Clause = PROJECT_FURTHER_EXPANDING.PROJECT_NUMBER_FIELD + "='" + row.PROJECT_NUMBER + "'";
                            if (editModel_ID != "")
                            {
                                string ids = "";
                                foreach (string a in editModel_ID.Split(','))
                                {
                                    if (a != "")
                                    {
                                        ids += "'" + a + "',";
                                    }
                                }

                                delQuery2.Clause += string.Format("AND ({0}.{1} not in ({2}) )", PROJECT_FURTHER_EXPANDING.TABLE_NAME, PROJECT_FURTHER_EXPANDING.MODEL_ID_FIELD, ids.TrimEnd(','));
                            }
                            BaseList deletes2 = bll.Select(delQuery2, typeof(PROJECT_FURTHER_EXPANDING));
                            foreach (PROJECT_FURTHER_EXPANDING del2 in deletes2)
                            {
                                del2.CurModel = DealModel.Delete;
                            }
                            bll.UpdateAllByParams(deletes2);


                            ParamCollection delQuery3 = new ParamCollection();
                            delQuery3.Clause = PROJECT_REVIVE.PROJECT_NUMBER_FIELD + "='" + row.PROJECT_NUMBER + "'";
                            if (editModel_ID != "")
                            {
                                string ids = "";
                                foreach (string a in editModel_ID.Split(','))
                                {
                                    if (a != "")
                                    {
                                        ids += "'" + a + "',";
                                    }
                                }

                                delQuery3.Clause += string.Format("AND ({0}.{1} not in ({2}) )", PROJECT_REVIVE.TABLE_NAME, PROJECT_REVIVE.MODEL_ID_FIELD, ids.TrimEnd(','));
                            }
                            BaseList deletes3 = bll.Select(delQuery3, typeof(PROJECT_REVIVE));
                            foreach (PROJECT_REVIVE del3 in deletes3)
                            {
                                del3.CurModel = DealModel.Delete;
                            }
                            bll.UpdateAllByParams(deletes3);
                            #endregion

                            #region edit Request
                            row.CurModel = DealModel.Modify;
                            row.CLIENT = ojb.txtClient ?? "";
                            row.DATE_REQUEST = DateTime.Parse(ojb.txtDate_of_Request.Value);
                            row.PROJECT_NUMBER = ojb.txtProjectNumber ?? "";
                            row.PARENT_PROJECT = ojb.txtParent_Project ?? "";

                            ParamCollection _pl = new ParamCollection();
                            _pl.Clause = "email = '" + ojb.ccLeading_SD + "'";
                            var temp1 = bll.Select(_pl, typeof(SYS_USER));
                            row.LEADING_SD = temp1 is null ? "" : ((SYS_USER)temp1[0]).USER_NAME;

                            _pl.Clause = "email = '" + ojb.ccBD + "'";
                            var temp2 = bll.Select(_pl, typeof(SYS_USER));
                            row.BD = temp2 is null ? "" : ((SYS_USER)temp2[0]).USER_NAME;

                            _pl.Clause = "email = '" + ojb.ccSD + "'";
                            var temp3 = bll.Select(_pl, typeof(SYS_USER));
                            row.SD = temp3 is null ? "" : ((SYS_USER)temp3[0]).USER_NAME;

                            row.TYPE_OF_STUDY = ojb.txtType_of_Study ?? "";
                            row.TUMOR_TYPE = ojb.ddlTumor_Type ?? "";
                            row.SUBTYPE1 = ojb.ddlSubtype1 ?? "";
                            row.SUBTYPE2 = ojb.ddlSubtype2 ?? "";
                            row.MODEL_ID = ojb.txtModel_ID.Value.Replace("\n", "") ?? "";
                            row.POTENTIAL_STUDY_SIZE = ojb.txtPotential_Study_Size ?? "";
                            row.SPECIAL_REQUIREMENTS = ojb.txtRequirements.Value.Replace("\n", "") ?? "";
                            row.DATE_RESPONDING = txtDate_of_1st_responding == "" ? DateTime.MinValue : DateTime.Parse(txtDate_of_1st_responding);
                            row.REMARK = doTran(editRemark);
                            row.CREATE_OF_DATE = DateTime.Now;
                            bll.Update(row);
                            #endregion
                        }
                        else
                        {
                            #region 新增 Request
                            BaseList dataRequest = new BaseList();
                            try
                            {
                                row = new REQUEST(DealModel.New);
                                row.CLIENT = ojb.txtClient ?? "";
                                row.DATE_REQUEST = DateTime.Parse(ojb.txtDate_of_Request.Value);
                                row.PROJECT_NUMBER = ojb.txtProjectNumber ?? "";
                                row.PARENT_PROJECT = ojb.txtParent_Project ?? "";

                                ParamCollection _pl = new ParamCollection();
                                _pl.Clause = "email = '" + ojb.ccLeading_SD + "'";
                                var temp1 = bll.Select(_pl, typeof(SYS_USER));
                                row.LEADING_SD = temp1 is null ? "" : ((SYS_USER)temp1[0]).USER_NAME;

                                _pl.Clause = "email = '" + ojb.ccBD + "'";
                                var temp2 = bll.Select(_pl, typeof(SYS_USER));
                                row.BD = temp2 is null ? "" : ((SYS_USER)temp2[0]).USER_NAME;

                                _pl.Clause = "email = '" + ojb.ccSD + "'";
                                var temp3 = bll.Select(_pl, typeof(SYS_USER));
                                row.SD = temp3 is null ? "" : ((SYS_USER)temp3[0]).USER_NAME;

                                row.TYPE_OF_STUDY = ojb.txtType_of_Study ?? "";
                                row.TUMOR_TYPE = ojb.ddlTumor_Type ?? "";
                                row.SUBTYPE1 = ojb.ddlSubtype1 ?? "";
                                row.SUBTYPE2 = ojb.ddlSubtype2 ?? "";
                                row.MODEL_ID = ojb.txtModel_ID.Value.Replace("\n", "") ?? "";
                                row.POTENTIAL_STUDY_SIZE = ojb.txtPotential_Study_Size ?? "";
                                row.SPECIAL_REQUIREMENTS = ojb.txtRequirements.Value.Replace("\n", "") ?? "";
                                //row.REQUEST_ONLY = "No";
                                row.SIGNED = "";
                                row.CREATE_OF_DATE = DateTime.Now;
                                row.COMPLETED_MODEL_ID = "";
                                row.RESPONDER = "";
                                row.RESPONDER_ID = "";
                                row.DATE_RESPONDING = DateTime.MinValue;
                                row.HAVE_CONFIRMED = "N";
                                row.ISDELETE = "N";
                                string txtDate_of_1st_responding = ojb.txtDate_of_1st_responding.Value ?? "";
                                string editRemark = ojb.editRemark ?? "";
                                row.REMARK = doTran(editRemark);

                                row.DATE_RESPONDING = txtDate_of_1st_responding == "" ? DateTime.MinValue : DateTime.Parse(txtDate_of_1st_responding);
                                dataRequest.Add(row);
                                bll.UpdateAllByParams(dataRequest);

                            }
                            catch (Exception ex)
                            {
                                code = "error";
                                msg = ex.Message.ToString();
                            }
                            #endregion
                        }

                        #region send SD/guiqing
                        string txtEmail = "";
                        string body = requestEmailgrid(row.DATE_REQUEST_F, row.PROJECT_NUMBER, row.MODEL_ID, row.POTENTIAL_STUDY_SIZE.ToString(), row.CLIENT, row.BD, row.SD, row.TYPE_OF_STUDY);
                        txtEmail += body;
                        string Subject = string.Format("New HuData Request");
                        string title = requestEmailtitle(txtEmail);

                        string[] toMails1 = { "guiqing.wu@crownbio.com" };
                        string[] toMails2 = { "sichun.fan@crownbio.com" };
                        //msg = SendEmail.SendMail_SMTP("html", Subject, title, toMails1, "Send successfully.");
                        //msg = SendEmail.SendMail_SMTP("html", Subject, title, toMails2, "Send successfully.");

                        ParamCollection pl = new ParamCollection();
                        pl.Clause = " USER_NAME ='" + row.SD + "' or USER_NAME ='" + row.LEADING_SD + "'";
                        BaseList userlist = bll.Select(pl, typeof(SYS_USER));
                        foreach (SYS_USER user in userlist)
                        {
                            string sd_email = user.EMAIL;
                            string[] toMails = { sd_email };
                            //msg = SendEmail.SendMail_SMTP("html", Subject, title, toMails, "Send successfully.");
                        }
                        code = "success";
                        msg = "OK";
                        #endregion
                    }
                    else
                    {
                        code = "error";
                        msg = "Sub-Project already exists.";
                    }
                }
                else
                {
                    code = "error";
                    msg = "User does not exist.";
                }
            }
            catch (Exception ex)
            {
                code = "error";
                msg = ex.Message.ToString();
            }
            var json = APItoJson(new { code, msg });
            return json;
        }

        /// <summary>
        /// 转换Json 换行符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string doTran(string str)
        {
            str = str.Replace("\n", "\\r\\n");
            str = str.Replace("\r\n", "\\r\\n");
            str = str.Replace("\t", "\\t");
            str = str.Replace("\"", "'");
            return str;
        }

        public static HttpResponseMessage APItoJson(Object obj)
        {
            var str = JsonConvert.SerializeObject(obj);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        public string requestEmailtitle(string body)
        {
            StringBuilder Body = new StringBuilder();
            Body.Append("<table cellpadding='0' cellspacing='0' width=\"1240\" border='1' style=\"word-break:keep-all;word-wrap:break-word\">");
            Body.Append("<tr>");
            Body.Append("<td>Date of Request</td><td>Project Number</td><td>Model ID</td><td>Potential Study Size</td><td>Sponsor</td><td>BD</td><td>SD</td><td>Type of Study</td>");
            Body.Append("</tr>");
            Body.Append(body);
            Body.Append("</table>");
            Body.Append("</br>");
            Body.Append("The Administrator");
            return Body.ToString();
        }

        public string requestEmailgrid(string a, string b, string c, string d, string e, string f, string g, string h)
        {
            c = c == "" ? "&nbsp;" : c;
            d = d == "" ? "&nbsp;" : d;
            e = e == "" ? "&nbsp;" : e;
            f = f == "" ? "&nbsp;" : f;
            g = g == "" || g == " " ? "&nbsp;" : g;
            h = h == "" || h == " " ? "&nbsp;" : h;
            StringBuilder Body = new StringBuilder();

            Body.Append("<tr>");
            Body.Append("<td style=\"width:120px\">" + a + "</td><td style=\"width:120px\">" + b + "</td><td style=\"width:80px\">" + c + "</td><td style=\"width:80px\">" + d + "</td><td style=\"width:80px\">" + e + "</td><td style=\"width:80px\">" + f + "</td><td style=\"width:80px\">" + g + "</td><td style=\"width:120px\">" + h + "</td>");
            Body.Append("</tr>");

            return Body.ToString();
        }


        [HttpPost]
        public HttpResponseMessage importAnimalInfo()
        {
            string msg = "";
            string code = "";
            try
            {
                var Request = HttpContext.Current.Request;
                HttpPostedFile oFile = Request.Files[0];

                if (oFile != null)
                {
                    var filePath = updateInfo();
                    Workbook book = new Workbook(filePath);
                    foreach (Worksheet sheet in book.Worksheets)
                    {
                        #region set importData
                        DataTable importData = new DataTable();
                        importData.Columns.Add("MODEL_ID");
                        importData.Columns.Add("Current_Project_Number");
                        importData.Columns.Add("Rn");
                        importData.Columns.Add("Pn");
                        importData.Columns.Add("Model_Fit_for_efficacy");
                        importData.Columns.Add("Location_of_live_animal");
                        importData.Columns.Add("Animal_Room_Number");
                        importData.Columns.Add("IVC_Location");
                        importData.Columns.Add("DOI", typeof(DateTime));
                        importData.Columns.Add("Model_status");
                        importData.Columns.Add("Animal_Number");
                        importData.Columns.Add("Date_of_Update", typeof(DateTime));
                        importData.Columns.Add("TV", typeof(Int32));
                        importData.Columns.Add("TVLB", typeof(Int32));
                        importData.Columns.Add("TVLF", typeof(Int32));
                        importData.Columns.Add("TVRF", typeof(Int32));
                        importData.Columns.Add("TVRB", typeof(Int32));
                        importData.Columns.Add("TV_AVG", typeof(Int32));
                        importData.Columns.Add("Tumor_Number", typeof(Int32));
                        importData.Columns.Add("Estimated_DOT");
                        importData.Columns.Add("Time_of_Model_for_Transplant");
                        importData.Columns.Add("Body_Weight");
                        importData.Columns.Add("Mortality_Observation");
                        importData.Columns.Add("Ongoing_Project");
                        importData.Columns.Add("Source_Project");
                        importData.Columns.Add("Clinical_Observation");
                        #endregion

                        BaseList data_AnimalInfo = new BaseList();
                        Dictionary<string, DataTable> email_to1 = new Dictionary<string, DataTable>();
                        #region set tb_email1
                        DataTable tb_email1 = new DataTable();
                        tb_email1.Columns.Add("LEADER");
                        tb_email1.Columns.Add("SD");
                        tb_email1.Columns.Add("MODEL ID");
                        tb_email1.Columns.Add("PROJECT NUMBER");
                        tb_email1.Columns.Add("ANIMAL NUMBER");
                        tb_email1.Columns.Add("RN");
                        tb_email1.Columns.Add("PN");
                        tb_email1.Columns.Add("LAST BW");
                        tb_email1.Columns.Add("BW");
                        tb_email1.Columns.Add("REMOVAL OF TUMOR WEIGHT");
                        tb_email1.Columns.Add("CLINICAL_OBSERVATION");
                        tb_email1.Columns.Add("MORTALITY_OBSERVATION");
                        tb_email1.Columns.Add("TVLB");
                        tb_email1.Columns.Add("TVLF");
                        tb_email1.Columns.Add("TVRF");
                        tb_email1.Columns.Add("TVRB");
                        tb_email1.Columns.Add("ANIMAL_ROOM_NUMBER");
                        tb_email1.Columns.Add("DOI");
                        #endregion

                        Dictionary<string, DataTable> email_to2 = new Dictionary<string, DataTable>();
                        #region set tb_email2
                        DataTable tb_email2 = new DataTable();
                        tb_email2.Columns.Add("LEADER");
                        tb_email2.Columns.Add("SD");
                        tb_email2.Columns.Add("MODEL ID");
                        tb_email2.Columns.Add("ANIMAL NUMBER");
                        tb_email2.Columns.Add("RN");
                        tb_email2.Columns.Add("PN");
                        tb_email2.Columns.Add("BW");
                        tb_email2.Columns.Add("CLINICAL_OBSERVATION");
                        tb_email2.Columns.Add("MORTALITY_OBSERVATION");
                        tb_email2.Columns.Add("TVLB");
                        tb_email2.Columns.Add("TVLF");
                        tb_email2.Columns.Add("TVRF");
                        tb_email2.Columns.Add("TVRB");
                        tb_email2.Columns.Add("ANIMAL_ROOM_NUMBER");
                        tb_email2.Columns.Add("DOI");
                        #endregion
                        ArrayList HaveModel = new ArrayList();
                        ArrayList HaveModel_abbr = new ArrayList();
                        string _errors = "";

                        string Ongoing_Project = "";
                        string Source_Project = "";
                        string MODEL_ID = "";
                        string Rn = "";
                        string Pn = "";
                        string DOI = "";
                        int carcinoma = 13;
                        string project = "";

                        Cells cells = sheet.Cells;
                        //cells.MaxDataRow + 1
                        for (int i = 0; i < cells.MaxDataRow + 1; i++)
                        {
                            if (cells[i, 0].StringValue != "AnimalInfo")
                            {
                                _errors = i.ToString() + ":" + cells[i, 0].StringValue;
                                if (i == 0)
                                {

                                }
                                if (Ongoing_Project == "")
                                {
                                    Ongoing_Project = cells[i, 0].StringValue;
                                }
                                else if (Source_Project == "")
                                {
                                    Source_Project = cells[i, 0].StringValue;
                                }
                                else if (cells[i, 0].StringValue.Length > 17)
                                {
                                    ArrayList models = new ArrayList();
                                    foreach (string model in cells[i, 0].StringValue.Split('-'))
                                    {
                                        models.Add(model);
                                    }

                                    MODEL_ID = models[0].ToString();
                                    HaveModel.Add(MODEL_ID);
                                    if (!HaveModel_abbr.Contains(MODEL_ID.Substring(0, 2)))
                                    {
                                        HaveModel_abbr.Add(MODEL_ID.Substring(0, 2));
                                    }
                                    Rn = models[1].ToString().Substring(0, models[1].ToString().IndexOf("P"));
                                    Pn = models[1].ToString().Substring(models[1].ToString().IndexOf("P"), models[1].ToString().Length - models[1].ToString().IndexOf("P"));
                                    DOI = models[2].ToString();
                                    if (models.Count == 3)
                                    {
                                        if (Rn == "R1")
                                        {
                                            project = "New Model Establishment";
                                        }
                                        else
                                        {
                                            project = "Maintenance";
                                        }
                                    }
                                    else
                                    {
                                        project = "Revival";
                                    }
                                }
                                else if (cells[i, 0].StringValue == "M#")
                                {
                                    if (cells[i, 12].StringValue == "Mortality Observation")
                                    {
                                        carcinoma = 13;
                                    }
                                    else if (cells[i, 13].StringValue == "Mortality Observation")
                                    {
                                        carcinoma = 14;
                                    }
                                    else if (cells[i, 14].StringValue == "Mortality Observation")
                                    {
                                        carcinoma = 15;
                                    }
                                }
                                else if (cells[i, 0].StringValue != "M#" && cells[i, 0].StringValue != "")
                                {
                                    #region 更新//新增

                                    ParamCollection paralist = new ParamCollection();
                                    paralist.Clause = "MODEL_ID= '" + MODEL_ID + "' and Animal_Number = '" + cells[i, 0].StringValue + "'";
                                    BaseList animaData = bll.Select(paralist, typeof(ANIMAL_INFO));
                                    if (animaData.Count > 0)
                                    {
                                        #region 替换
                                        ANIMAL_INFO newRow = (ANIMAL_INFO)animaData[0];

                                        newRow.CurModel = DealModel.Modify;
                                        newRow.MODEL_ID = MODEL_ID;
                                        newRow.RN = Rn;
                                        newRow.PN = Pn;
                                        newRow.DOI = DOI == "" ? DateTime.MinValue : Convert.ToDateTime(DOI.Substring(0, 4) + "-" + DOI.Substring(4, 2) + "-" + DOI.Substring(6, 2));
                                        newRow.ANIMAL_NUMBER = cells[i, 0].StringValue;
                                        string[] list1 = cells[i, 1].StringValue.Split('-');
                                        newRow.LOCATION_OF_LIVE_ANIMAL = list1.Length > 1 ? list1[0] : "";
                                        newRow.ANIMAL_ROOM_NUMBER = list1.Length > 1 ? list1[1] : "";
                                        newRow.IVC_LOCATION = list1.Length > 1 ? list1[2] : list1[0];
                                        newRow.DATE_OF_UPDATE = cells[i, 2].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 2].StringValue);

                                        newRow.ONGOING_PROJECT = Ongoing_Project;
                                        newRow.SOURCE_PROJECT = Source_Project;

                                        int begin = 3;
                                        if (carcinoma == 14)//默认13
                                        {
                                            begin = begin + 1;
                                        }
                                        else if (carcinoma == 15)
                                        {
                                            begin = begin + 2;
                                        }
                                        try
                                        {
                                            decimal d1 = cells[i, begin].StringValue == "" ? 0 : decimal.Parse(cells[i, begin].StringValue);
                                            decimal d2 = cells[i, begin + 1].StringValue == "" ? 0 : decimal.Parse(cells[i, begin + 1].StringValue);
                                            decimal d3 = cells[i, begin + 2].StringValue == "" ? 0 : decimal.Parse(cells[i, begin + 2].StringValue);
                                            decimal d4 = cells[i, begin + 3].StringValue == "" ? 0 : decimal.Parse(cells[i, begin + 3].StringValue);
                                            int avgcoun = 0;
                                            newRow.TVLB = 0;
                                            newRow.TVLF = 0;
                                            newRow.TVRF = 0;
                                            newRow.TVRB = 0;
                                            if (d1 != 0)
                                            {
                                                avgcoun += 1;
                                                newRow.TVLB = Convert.ToInt32(Math.Round(d1, 0, MidpointRounding.AwayFromZero).ToString());
                                            }
                                            if (d2 != 0)
                                            {
                                                avgcoun += 1;
                                                newRow.TVLF = Convert.ToInt32(Math.Round(d2, 0, MidpointRounding.AwayFromZero).ToString());
                                            }
                                            if (d3 != 0)
                                            {
                                                avgcoun += 1;
                                                newRow.TVRF = Convert.ToInt32(Math.Round(d3, 0, MidpointRounding.AwayFromZero).ToString());
                                            }
                                            if (d4 != 0)
                                            {
                                                avgcoun += 1;
                                                newRow.TVRB = Convert.ToInt32(Math.Round(d4, 0, MidpointRounding.AwayFromZero).ToString());
                                            }
                                            newRow.TV = int.Parse(Math.Round(d1 + d2 + d3 + d4, 0, MidpointRounding.AwayFromZero).ToString());
                                            if (avgcoun != 0)
                                            {
                                                newRow.TV_AVG = int.Parse(Math.Round((d1 + d2 + d3 + d4) / avgcoun, 0, MidpointRounding.AwayFromZero).ToString());
                                                newRow.TUMOR_NUMBER = avgcoun;
                                            }
                                            else
                                            {
                                                newRow.TV_AVG = 0;
                                                newRow.TUMOR_NUMBER = 0;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            newRow.TV = 0;
                                            newRow.TV_AVG = 0;
                                            newRow.TUMOR_NUMBER = 0;
                                        }
                                        newRow.BODY_WEIGHT = cells[i, begin + 7].StringValue;
                                        newRow.CLINICAL_OBSERVATION = cells[i, begin + 8].StringValue;
                                        newRow.MORTALITY_OBSERVATION = cells[i, begin + 9].StringValue;

                                        newRow.CURRENT_PROJECT_NUMBER = project;

                                        string fit = newRow.CURRENT_PROJECT_NUMBER.ToString();
                                        string Model_status = "";
                                        if (fit == "Revival" || fit == "New Model Establishment" || fit == "No live animals")
                                        {
                                            Model_status = "Not Available";
                                        }
                                        else
                                        {
                                            Model_status = "Available";
                                        }
                                        newRow.MODEL_STATUS = Model_status;
                                        #endregion

                                        #region 添加1.小鼠体重涨幅计算;本次体重-上一次体重/上一次；2.小鼠去瘤体重：小鼠测量体重-单只小鼠荷瘤总和/1000（1000mm3体积设置为1g）
                                        ParamCollection pl = new ParamCollection();
                                        pl.Clause = "MODEL_ID= '" + newRow.MODEL_ID + "' and Animal_Number = '" + newRow.ANIMAL_NUMBER + "'";
                                        pl.Clause += " and Rn = '" + newRow.RN + "' and Pn = '" + newRow.PN + "'";
                                        pl.Clause += " and Date_of_Update < '" + newRow.DATE_OF_UPDATE.ToString() + "'";
                                        BaseList LogData = bll.Select(pl, "Date_of_Update desc", typeof(ANIMAL_INFO_LOGS));
                                        if (LogData.Count > 0)
                                        {
                                            double BW_new = 0;//现有体重
                                            double Loss_of_weight = 0;//小鼠体重下降率%：
                                            double bw1 = 0;//小鼠去瘤体重

                                            ANIMAL_INFO_LOGS log = (ANIMAL_INFO_LOGS)LogData[0];
                                            if (log.BODY_WEIGHT != "" && log.BODY_WEIGHT != "0")
                                            {
                                                BW_new = double.Parse(newRow.BODY_WEIGHT);
                                                Loss_of_weight = (double.Parse(log.BODY_WEIGHT) - BW_new) / double.Parse(log.BODY_WEIGHT) * 100;
                                                bw1 = BW_new - Math.Round(Convert.ToDouble(newRow.TV_AVG * newRow.TUMOR_NUMBER) / 1000, 2);
                                                if (BW_new < 20 || bw1 < 20 || Loss_of_weight > 10)
                                                {
                                                    #region 发送给动物房间号负责人Leader
                                                    ParamCollection pls = new ParamCollection();
                                                    pls.Clause = "DropDownList_Name = 'AnimalRoom Management'";
                                                    BaseList data = bll.Select(pls, typeof(DROPDOWNLIST));
                                                    DROPDOWNLIST row = (DROPDOWNLIST)data[0];
                                                    foreach (string nodes in row.DROPDOWNLIST_CONTEXT.Split(new char[] { ';', '；' }, StringSplitOptions.RemoveEmptyEntries))
                                                    {
                                                        string[] aa = nodes.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries);
                                                        if (aa[0].Contains(newRow.ANIMAL_ROOM_NUMBER + "-" + newRow.LOCATION_OF_LIVE_ANIMAL))
                                                        {
                                                            DataRow new1 = tb_email1.NewRow();
                                                            new1[0] = aa[2];
                                                            new1[1] = "";
                                                            new1[2] = newRow.MODEL_ID;
                                                            new1[3] = "";
                                                            new1[4] = newRow.ANIMAL_NUMBER;
                                                            new1[5] = newRow.RN;
                                                            new1[6] = newRow.PN;
                                                            new1[7] = log.BODY_WEIGHT;
                                                            new1[8] = BW_new;
                                                            new1[9] = Math.Round(bw1, 2);
                                                            new1[10] = newRow.TVLB.ToString();
                                                            new1[11] = newRow.TVLF.ToString();
                                                            new1[12] = newRow.TVRF.ToString();
                                                            new1[13] = newRow.TVRB.ToString();
                                                            new1[14] = newRow.ANIMAL_ROOM_NUMBER;
                                                            new1[15] = newRow.DOI_F;
                                                            tb_email1.Rows.Add(new1);
                                                            if (email_to1.Keys.Contains(aa[2]))
                                                            {
                                                                email_to1.Remove(aa[2]);
                                                            }
                                                            email_to1.Add(aa[2], tb_email1.Select("LEADER = '" + aa[2] + "' ").CopyToDataTable());
                                                            break;
                                                        }
                                                    }
                                                    #endregion

                                                    #region 发送给预约老鼠的项目SD
                                                    ParamCollection pls2 = new ParamCollection();
                                                    pls2.Clause = "Animal_Number = '" + newRow.ANIMAL_NUMBER + "' and Model_ID='" + newRow.MODEL_ID + "'";
                                                    BaseList BookingData = bll.Select(pls2, typeof(PROJECT_BOOKING));
                                                    foreach (PROJECT_BOOKING dr in BookingData)
                                                    {
                                                        ParamCollection pl2 = new ParamCollection();
                                                        pl2.Clause = "USER_NAME = '" + dr.SD + "'";
                                                        BaseList user = bll.Select(pl2, typeof(SYS_USER));
                                                        if (user.Count > 0)
                                                        {
                                                            string email = ((SYS_USER)user[0]).EMAIL;
                                                            DataRow new1 = tb_email1.NewRow();
                                                            new1[0] = "";
                                                            new1[1] = dr.SD;
                                                            new1[2] = newRow.MODEL_ID;
                                                            new1[3] = dr.PROJECT_NUMBER;
                                                            new1[4] = newRow.ANIMAL_NUMBER;
                                                            new1[5] = newRow.RN;
                                                            new1[6] = newRow.PN;
                                                            new1[7] = log.BODY_WEIGHT;
                                                            new1[8] = BW_new;
                                                            new1[9] = Math.Round(bw1, 2);
                                                            new1[10] = newRow.CLINICAL_OBSERVATION;
                                                            new1[11] = newRow.MORTALITY_OBSERVATION;
                                                            new1[12] = newRow.TVLB.ToString();
                                                            new1[13] = newRow.TVLF.ToString();
                                                            new1[14] = newRow.TVRF.ToString();
                                                            new1[15] = newRow.TVRB.ToString();
                                                            new1[16] = newRow.ANIMAL_ROOM_NUMBER;
                                                            new1[17] = newRow.DOI_F;
                                                            tb_email1.Rows.Add(new1);
                                                            if (email_to1.Keys.Contains(email))
                                                            {
                                                                email_to1.Remove(email);
                                                            }
                                                            email_to1.Add(email, tb_email1.Select("SD = '" + dr.SD + "' ").CopyToDataTable());
                                                        }
                                                    }
                                                    #endregion
                                                }

                                            }
                                        }
                                        #endregion

                                        #region 添加体积>300 or >1000的邮件提醒
                                        if (newRow.TVLB >= 1000 || newRow.TVLF >= 1000 || newRow.TVRB >= 1000 || newRow.TVRF >= 1000)
                                        {
                                            #region 发送给动物房间号负责人Leader
                                            ParamCollection pls = new ParamCollection();
                                            pls.Clause = "DropDownList_Name = 'AnimalRoom Management'";
                                            BaseList data = bll.Select(pls, typeof(DROPDOWNLIST));
                                            DROPDOWNLIST row = (DROPDOWNLIST)data[0];
                                            foreach (string nodes in row.DROPDOWNLIST_CONTEXT.Split(new char[] { ';', '；' }, StringSplitOptions.RemoveEmptyEntries))
                                            {
                                                string[] aa = nodes.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries);
                                                if (aa[0].Contains(newRow.ANIMAL_ROOM_NUMBER + "-" + newRow.LOCATION_OF_LIVE_ANIMAL))
                                                {
                                                    DataRow new1 = tb_email2.NewRow();
                                                    new1[0] = aa[2];
                                                    new1[1] = "";
                                                    new1[2] = newRow.MODEL_ID;
                                                    new1[3] = newRow.ANIMAL_NUMBER;
                                                    new1[4] = newRow.RN;
                                                    new1[5] = newRow.PN;
                                                    new1[6] = newRow.BODY_WEIGHT;
                                                    new1[7] = newRow.CLINICAL_OBSERVATION;
                                                    new1[8] = newRow.MORTALITY_OBSERVATION;
                                                    new1[9] = newRow.TVLB.ToString();
                                                    new1[10] = newRow.TVLF.ToString();
                                                    new1[11] = newRow.TVRF.ToString();
                                                    new1[12] = newRow.TVRB.ToString();
                                                    new1[13] = newRow.ANIMAL_ROOM_NUMBER;
                                                    new1[14] = newRow.DOI_F;
                                                    tb_email2.Rows.Add(new1);
                                                    if (email_to2.Keys.Contains(aa[2]))
                                                    {
                                                        email_to2.Remove(aa[2]);
                                                    }
                                                    email_to2.Add(aa[2], tb_email2.Select("LEADER = '" + aa[2] + "' ").CopyToDataTable());
                                                    break;
                                                }
                                            }
                                            #endregion
                                        }
                                        if (newRow.TVLB >= 300 || newRow.TVLF >= 300 || newRow.TVRB >= 300 || newRow.TVRF >= 300)
                                        {
                                            #region 发送给预约老鼠的项目SD
                                            ParamCollection pls2 = new ParamCollection();
                                            pls2.Clause = "Animal_Number = '" + newRow.ANIMAL_NUMBER + "' and Model_ID='" + newRow.MODEL_ID + "'";
                                            BaseList BookingData = bll.Select(pls2, typeof(PROJECT_BOOKING));
                                            foreach (PROJECT_BOOKING dr in BookingData)
                                            {
                                                ParamCollection p3 = new ParamCollection();
                                                p3.Clause = "REQUEST_ID ='" + dr.REQUEST_ID.ToString() + "' and Model_ID='" + dr.MODEL_ID + "' and Inoculation = ''";
                                                BaseList monitorData = bll.Select(p3, typeof(PROJECT_MONITOR));

                                                ParamCollection pl2 = new ParamCollection();
                                                pl2.Clause = "USER_NAME = '" + dr.SD + "'";
                                                BaseList user = bll.Select(pl2, typeof(SYS_USER));
                                                if (monitorData.Count > 0 && user.Count > 0)
                                                {
                                                    string email = ((SYS_USER)user[0]).EMAIL;
                                                    DataRow new1 = tb_email2.NewRow();
                                                    new1[0] = "";
                                                    new1[1] = dr.SD;
                                                    new1[2] = newRow.MODEL_ID;
                                                    new1[3] = newRow.ANIMAL_NUMBER;
                                                    new1[4] = newRow.RN;
                                                    new1[5] = newRow.PN;
                                                    new1[6] = newRow.BODY_WEIGHT;
                                                    new1[7] = newRow.CLINICAL_OBSERVATION;
                                                    new1[8] = newRow.MORTALITY_OBSERVATION;
                                                    new1[9] = newRow.TVLB.ToString();
                                                    new1[10] = newRow.TVLF.ToString();
                                                    new1[11] = newRow.TVRF.ToString();
                                                    new1[12] = newRow.TVRB.ToString();
                                                    new1[13] = newRow.ANIMAL_ROOM_NUMBER;
                                                    new1[14] = newRow.DOI_F;
                                                    tb_email2.Rows.Add(new1);
                                                    if (email_to2.Keys.Contains(email))
                                                    {
                                                        email_to2.Remove(email);
                                                    }
                                                    email_to2.Add(email, tb_email2.Select("SD = '" + dr.SD + "' ").CopyToDataTable());
                                                }
                                            }
                                            #endregion
                                        }
                                        #endregion
                                        //data_AnimalInfo.Add(newRow);
                                        bll.Update(newRow);
                                    }
                                    else
                                    {
                                        ParamCollection p1 = new ParamCollection();
                                        p1.Clause = "MODEL_ID= '" + MODEL_ID + "' and Current_Project_Number = 'No live animals'";
                                        BaseList nolive = bll.Select(p1, typeof(ANIMAL_INFO));
                                        if (nolive.Count > 0)
                                        {
                                            ANIMAL_INFO del = (ANIMAL_INFO)nolive[0];
                                            del.CurModel = DealModel.Delete;
                                            bll.Delete(del);
                                        }

                                        #region 新增
                                        DataRow newRow = importData.NewRow();
                                        newRow["MODEL_ID"] = MODEL_ID;
                                        newRow["Rn"] = Rn;
                                        newRow["Pn"] = Pn;
                                        newRow["DOI"] = DOI == "" ? DateTime.MinValue : Convert.ToDateTime(DOI.Substring(0, 4) + "-" + DOI.Substring(4, 2) + "-" + DOI.Substring(6, 2));
                                        newRow["Animal_Number"] = cells[i, 0].StringValue;
                                        string[] list1 = cells[i, 1].StringValue.Split('-');
                                        newRow["Location_of_live_animal"] = list1.Length > 1 ? list1[0] : "";
                                        newRow["Animal_Room_Number"] = list1.Length > 1 ? list1[1] : "";
                                        newRow["IVC_Location"] = list1.Length > 1 ? list1[2] : list1[0];
                                        newRow["Date_of_Update"] = cells[i, 2].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 2].StringValue);


                                        newRow["Ongoing_Project"] = Ongoing_Project;
                                        newRow["Source_Project"] = Source_Project;

                                        int begin = 3;
                                        if (carcinoma == 14)//默认13
                                        {
                                            begin = begin + 1;
                                        }
                                        else if (carcinoma == 15)
                                        {
                                            begin = begin + 2;
                                        }
                                        try
                                        {
                                            decimal d1 = cells[i, begin].StringValue == "" ? 0 : decimal.Parse(cells[i, begin].StringValue);
                                            decimal d2 = cells[i, begin + 1].StringValue == "" ? 0 : decimal.Parse(cells[i, begin + 1].StringValue);
                                            decimal d3 = cells[i, begin + 2].StringValue == "" ? 0 : decimal.Parse(cells[i, begin + 2].StringValue);
                                            decimal d4 = cells[i, begin + 3].StringValue == "" ? 0 : decimal.Parse(cells[i, begin + 3].StringValue);
                                            int avgcoun = 0;
                                            newRow["TVLB"] = 0;
                                            newRow["TVLF"] = 0;
                                            newRow["TVRF"] = 0;
                                            newRow["TVRB"] = 0;
                                            if (d1 != 0)
                                            {
                                                avgcoun += 1;
                                                newRow["TVLB"] = Convert.ToInt32(Math.Round(d1, 0, MidpointRounding.AwayFromZero).ToString());
                                            }
                                            if (d2 != 0)
                                            {
                                                avgcoun += 1;
                                                newRow["TVLF"] = Convert.ToInt32(Math.Round(d2, 0, MidpointRounding.AwayFromZero).ToString());
                                            }
                                            if (d3 != 0)
                                            {
                                                avgcoun += 1;
                                                newRow["TVRF"] = Convert.ToInt32(Math.Round(d3, 0, MidpointRounding.AwayFromZero).ToString());
                                            }
                                            if (d4 != 0)
                                            {
                                                avgcoun += 1;
                                                newRow["TVRB"] = Convert.ToInt32(Math.Round(d4, 0, MidpointRounding.AwayFromZero).ToString());
                                            }
                                            newRow["TV"] = Math.Round(d1 + d2 + d3 + d4, 0, MidpointRounding.AwayFromZero);
                                            if (avgcoun != 0)
                                            {
                                                newRow["TV_AVG"] = Math.Round((d1 + d2 + d3 + d4) / avgcoun, 0, MidpointRounding.AwayFromZero);
                                                newRow["Tumor_Number"] = avgcoun;
                                            }
                                            else
                                            {
                                                newRow["TV_AVG"] = 0;
                                                newRow["Tumor_Number"] = 0;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            newRow["TV"] = 0;
                                            newRow["TV_AVG"] = 0;
                                            newRow["Tumor_Number"] = 0;
                                        }
                                        newRow["Body_Weight"] = cells[i, begin + 7].StringValue;
                                        newRow["Clinical_Observation"] = cells[i, begin + 8].StringValue;
                                        newRow["Mortality_Observation"] = cells[i, begin + 9].StringValue;

                                        newRow["Current_Project_Number"] = project;
                                        string fit = newRow["Current_Project_Number"].ToString();
                                        string Model_status = "";
                                        if (fit == "Revival" || fit == "New Model Establishment" || fit == "No live animals")
                                        {
                                            Model_status = "Not Available";
                                        }
                                        else
                                        {
                                            Model_status = "Available";
                                        }
                                        newRow["Model_status"] = Model_status;
                                        importData.Rows.Add(newRow);
                                        #endregion
                                    }

                                    #endregion
                                }
                            }
                        }


                        ArrayList columns = new ArrayList();
                        foreach (DataColumn dc in importData.Columns)
                        {
                            columns.Add(dc.ColumnName);
                        }
                        ojbReportRule.InsertBigSql(importData, columns, "ANIMAL_INFO");

                        foreach (string key in email_to1.Keys)
                        {
                            DataTable data = email_to1[key];
                            string Subject = string.Format("HuData Animal BW Warning");
                            string email_body = Note_EmailBody1(data, key);
                            string[] toMails = { key };
                            //SendEmail.SendMail_SMTP("html", Subject, email_body, toMails, "Send successfully.");
                        }
                        foreach (string key in email_to2.Keys)
                        {
                            DataTable data = email_to2[key];
                            string Subject = string.Format("HuData Animal TV Warning");
                            string email_body = Note_EmailBody2(data, key);
                            string[] toMails = { key };
                            //SendEmail.SendMail_SMTP("html", Subject, email_body, toMails, "Send successfully.");
                        }
                    }
                    #region no live animal

                    SqlParameter[] para = new SqlParameter[] { };
                    DataTable pdx_nolive = ojbReportRule.GetGrid("GetNoliveAnimal", para);
                    DataTable nolivedata = new DataTable();
                    nolivedata.Columns.Add("MODEL_ID");
                    nolivedata.Columns.Add("Current_Project_Number");
                    nolivedata.Columns.Add("Rn");
                    nolivedata.Columns.Add("Pn");
                    nolivedata.Columns.Add("Model_Fit_for_efficacy");
                    nolivedata.Columns.Add("Location_of_live_animal");
                    nolivedata.Columns.Add("Animal_Room_Number");
                    nolivedata.Columns.Add("IVC_Location");
                    nolivedata.Columns.Add("DOI", typeof(DateTime));
                    nolivedata.Columns.Add("Model_status");
                    nolivedata.Columns.Add("Animal_Number");
                    nolivedata.Columns.Add("Date_of_Update", typeof(DateTime));
                    nolivedata.Columns.Add("TV", typeof(Int32));
                    nolivedata.Columns.Add("TVLB", typeof(Int32));
                    nolivedata.Columns.Add("TVLF", typeof(Int32));
                    nolivedata.Columns.Add("TVRF", typeof(Int32));
                    nolivedata.Columns.Add("TVRB", typeof(Int32));
                    nolivedata.Columns.Add("TV_AVG", typeof(Int32));
                    nolivedata.Columns.Add("Tumor_Number", typeof(Int32));
                    nolivedata.Columns.Add("Estimated_DOT");
                    nolivedata.Columns.Add("Time_of_Model_for_Transplant");
                    nolivedata.Columns.Add("Body_Weight");
                    nolivedata.Columns.Add("Mortality_Observation");
                    nolivedata.Columns.Add("Ongoing_Project");
                    nolivedata.Columns.Add("Source_Project");
                    nolivedata.Columns.Add("Clinical_Observation");
                    foreach (DataRow row in pdx_nolive.Rows)
                    {
                        DataRow nolive = nolivedata.NewRow();
                        nolive["MODEL_ID"] = row["MODEL_ID"].ToString();
                        nolive["Current_Project_Number"] = "No live animals";
                        nolive["Rn"] = "";
                        nolive["Pn"] = "";
                        nolive["Model_Fit_for_efficacy"] = "Fit for efficacy";
                        nolive["Location_of_live_animal"] = "";
                        nolive["Animal_Room_Number"] = "";
                        nolive["IVC_Location"] = "";
                        nolive["DOI"] = DateTime.MinValue;
                        nolive["Model_status"] = "Not Available";
                        nolive["Animal_Number"] = "";
                        nolive["Date_of_Update"] = DateTime.Now;
                        nolive["TV"] = 0;
                        nolive["TVLB"] = 0;
                        nolive["TVLF"] = 0;
                        nolive["TVRF"] = 0;
                        nolive["TVRB"] = 0;
                        nolive["TV_AVG"] = 0;
                        nolive["Estimated_DOT"] = "N/A";
                        nolive["Time_of_Model_for_Transplant"] = row["TIME_OF_MODEL_FOR_TRANSPLANT"];
                        nolive["Body_Weight"] = "";
                        nolive["Mortality_Observation"] = "";
                        nolive["Ongoing_Project"] = "";
                        nolive["Source_Project"] = "";
                        nolive["Clinical_Observation"] = "";
                        nolivedata.Rows.Add(nolive);
                    }
                    ArrayList columns2 = new ArrayList();
                    foreach (DataColumn dc in nolivedata.Columns)
                    {
                        columns2.Add(dc.ColumnName);
                    }
                    ojbReportRule.InsertBigSql(nolivedata, columns2, "ANIMAL_INFO");
                    #endregion

                    code = "success";
                    msg = "import is successful.";
                }
                else
                {
                    code = "error";
                    msg = "file is empty.";
                }
            }
            catch (Exception ex)
            {
                code = "error";
                msg = ex.Message.ToString();
            }
            var json = APItoJson(new { code, msg });
            return json;
        }

        public string Note_EmailBody1(DataTable data, string key)
        {
            StringBuilder Body = new StringBuilder();
            Body.Append("Hi " + key + ",</br>");
            Body.Append("<span style=\"color: Red\">These animals had body weight/removal of tumor weight< 20! or weight loss rate > 10%!</span></br></br>");
            Body.Append("The Aniaml Info:</br>");
            Body.Append("<table cellpadding='0' cellspacing='0' width=\"1240\" border='1' style=\"word-break:keep-all;word-wrap:break-word\">");
            Body.Append("<tr>");
            foreach (DataColumn col in data.Columns)
            {
                Body.Append("<td>" + col.ColumnName + "</td>");
            }
            Body.Append("</tr>");
            foreach (DataRow row in data.Rows)
            {
                Body.Append("<tr>");
                foreach (DataColumn col in data.Columns)
                {
                    Body.Append("<td>" + row[col].ToString() + "</td>");
                }
                Body.Append("</tr>");
            }
            Body.Append("</table>");
            Body.Append("</br></br>The HuData Admin");
            return Body.ToString();
        }

        public string Note_EmailBody2(DataTable data, string key)
        {
            StringBuilder Body = new StringBuilder();
            Body.Append("Hi " + key + ",</br>");
            Body.Append("<span style=\"color: Red\">These animals had tumor volume >=300 or >=1000!</span></br></br>");
            Body.Append("The Animal Info:</br>");
            Body.Append("<table cellpadding='0' cellspacing='0' width=\"1240\" border='1' style=\"word-break:keep-all;word-wrap:break-word\">");
            Body.Append("<tr>");
            foreach (DataColumn col in data.Columns)
            {
                Body.Append("<td>" + col.ColumnName + "</td>");
            }
            Body.Append("</tr>");
            foreach (DataRow row in data.Rows)
            {
                Body.Append("<tr>");
                foreach (DataColumn col in data.Columns)
                {
                    Body.Append("<td>" + row[col].ToString() + "</td>");
                }
                Body.Append("</tr>");
            }
            Body.Append("</table>");
            Body.Append("</br></br>The HuData Admin");
            return Body.ToString();
        }

        public string updateInfo()
        {
            var Request = HttpContext.Current.Request;
        
            HttpPostedFile oFile = Request.Files[0];//获取上传的文件
         
            Stream fs = oFile.InputStream;

            byte[] by = new byte[oFile.InputStream.Length];//分块读取

            string folderPath = HttpContext.Current.Server.MapPath("~/UploadUser/");
            string filePath = folderPath + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".csv";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            FileStream fStream = new FileStream(filePath, FileMode.Create);
            int osize = fs.Read(by, 0, by.Length);

            while (osize > 0)
            {
                if (osize > 0)
                {
                    fStream.Write(by, 0, osize);
                }
                osize = fs.Read(by, 0, by.Length);
            }
            fStream.Close();
            fStream.Dispose();

            return filePath;

        }

        [HttpGet]
        public HttpResponseMessage getAnimalBooking([FromUri] param1 oData)
        {
            string msg = "";
            string code = "";
            try
            {
                //SqlParameter[] para1 = new SqlParameter[] {
                //new SqlParameter("@txtAnimalBooking",""),
                //  new SqlParameter("@txtFurtherExpanding",""),
                //   new SqlParameter("@txtRevive",""),
                //    new SqlParameter("@searchModelID",oData.model_id),
                //      new SqlParameter("@searchBD",""),
                //        new SqlParameter("@searchSD",""),
                //          new SqlParameter("@txtPN",""),
                //             new SqlParameter("@txtAnimal_Number","") };
                //DataTable data = ojbReportRule.GetGrid("getProjectBooking", para1);

                SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Model_ID", oData.model_id)
                    ,new SqlParameter("@PN", "")    };
                DataTable data = ojbReportRule.GetGrid("GetAnimalStatus", para);
                if (data.Rows.Count > 0)
                {
                    #region 计算Estimated_DOT
                    List<PDXMODEL_INFO> pdxmodels = bll.Select(typeof(PDXMODEL_INFO)).ConvertAll<PDXMODEL_INFO>(PDXMODEL_INFO.Convert);

                    data.Columns.Add("Estimated_DOT");
                    foreach (DataRow dr in data.Rows)
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
                }
                code = "OK";
                var json = APItoJson(new { code, msg = data });
                return json;
            }
            catch (Exception ex)
            {
                code = "error";
                msg = ex.Message.ToString();
                var json = APItoJson(new { code, msg });
                return json;
            }
          
        }

        public class param1
        {
            public string model_id { get; set; }
        }

        [HttpGet]
        public HttpResponseMessage getDropdownlist()
        {
            string msg = "";
            string code = "";
            try
            {
                ParamCollection paralist = new ParamCollection();
                BaseList data = bll.Select(paralist, typeof(DROPDOWNLIST));
                code = "OK";
                var json = APItoJson(new { code, msg = data });
                return json;
            }
            catch (Exception ex)
            {
                code = "error";
                msg = ex.Message.ToString();
                var json = APItoJson(new { code, msg });
                return json;
            }

        }

        [HttpPost]
        public HttpResponseMessage saveAnimalBooking([FromBody] savebooking oData)
        {
            string msg = "";
            string code = "";
            try
            {
                PROJECT_BOOKING row = null;
                string txtAnimal_Booking = oData.Animal_Booking ?? "";
                string txtFurther_expanding = oData.Further_Expanding ?? "";
                string hfAnimal_Number = oData.Animal_Number ?? "";
                string txtProject_Number = oData.Project_Number ?? "";
                string book_MODEL_ID = oData.Book_MODEL_ID ?? "";

                string txtRevive = oData.Revive ?? "";

                ParamCollection query = new ParamCollection();
                query.Clause = REQUEST.PROJECT_NUMBER_FIELD + "='" + txtProject_Number.Trim() + "'";
                query.Clause += " and Isdelete = 'N'";
                BaseList requestData = bll.Select(query, typeof(REQUEST));
                if (requestData.Count > 0)
                {
                    REQUEST request = (REQUEST)requestData[0];
                    #region save booking
                    string _del_project = "";
                    ParamCollection paraList1 = new ParamCollection();
                    paraList1.Clause = ANIMAL_INFO.ANIMAL_NUMBER_FIELD + "='" + hfAnimal_Number + "'";
                    BaseList animal = bll.Select(paraList1, typeof(ANIMAL_INFO));
                    string doi = "";
                    if (animal.Count > 0)
                    {
                        doi = ((ANIMAL_INFO)animal[0]).DOI_F;
                    }
                    ParamCollection paraList = new ParamCollection();
                    paraList.Clause = PROJECT_BOOKING.ANIMAL_NUMBER_FIELD + "='" + hfAnimal_Number + "'";
                    paraList.Clause += " and " + PROJECT_BOOKING.DOI_FIELD + "='" + doi + "'";
                    BaseList data = bll.Select(paraList, typeof(PROJECT_BOOKING));
                    if (txtAnimal_Booking != "")
                    {
                        _del_project = txtAnimal_Booking;
                        if (data.Count > 0)
                        {
                            row = (PROJECT_BOOKING)data[0];
                            row.CurModel = DealModel.Modify;
                            row.PROJECT_NUMBER = request.PROJECT_NUMBER;
                            row.BOOKING = txtAnimal_Booking;
                            row.MODEL_ID = book_MODEL_ID;
                            row.BD = request.BD;
                            row.SD = request.SD;
                            row.REQUEST_ID = request.REQUEST_ID;
                            row.DATE_OF_BOOKING = DateTime.Now;
                            row.ANIMAL_NUMBER = hfAnimal_Number;
                            bll.Update(row);
                        }
                        else
                        {
                            ParamCollection q1 = new ParamCollection();
                            q1.Clause = PROJECT_BOOKING.MODEL_ID_FIELD + "='" + book_MODEL_ID + "'";
                            q1.Clause += " And " + PROJECT_BOOKING.ANIMAL_NUMBER_FIELD + " in (select Animal_Number from ANIMAL_INFO where MODEL_ID = '" + book_MODEL_ID + "' and DOI = '" + doi + "')";
                            BaseList maxdata = bll.Select(q1, typeof(PROJECT_BOOKING));

                            row = new PROJECT_BOOKING(DealModel.New);
                            row.PROJECT_NUMBER = request.PROJECT_NUMBER;
                            row.BOOKING = txtAnimal_Booking;
                            row.MODEL_ID = book_MODEL_ID;
                            row.BD = request.BD;
                            row.SD = request.SD;//JSD(Executive_SD)
                            row.LEADING_SD = request.LEADING_SD;//SD
                            row.REQUEST_ID = request.REQUEST_ID;
                            row.DATE_OF_BOOKING = DateTime.Now;
                            row.ANIMAL_NUMBER = hfAnimal_Number;
                            row.DOI = doi;
                            bll.Update(row);
                        }

                        #region email to SD/JSD
                        string body = requestEmailgrid(request.DATE_REQUEST_F, request.PROJECT_NUMBER, request.MODEL_ID, request.POTENTIAL_STUDY_SIZE.ToString(), request.CLIENT, request.BD, request.SD, request.TYPE_OF_STUDY);
                        string Subject = string.Format("New HuData Animal booking!");
                        string title = "<span style=\"color: Red\">The animal " + hfAnimal_Number + " in " + book_MODEL_ID + " has been booked!</span></br>" + requestEmailtitle(body);
                        ParamCollection pl = new ParamCollection();
                        pl.Clause = " USER_NAME ='" + row.SD + "' or USER_NAME ='" + row.LEADING_SD + "'";
                        BaseList userlist = bll.Select(pl, typeof(SYS_USER));
                        foreach (SYS_USER user in userlist)
                        {
                            string sd_email = user.EMAIL;
                            string[] toMails = { sd_email };
                            SendEmail.SendMail_SMTP("html", Subject, title, toMails, "Send successfully.");
                        }
                        string[] toMails1 = { "guiqing.wu@crownbio.com" };
                        string[] toMails2 = { "sichun.fan@crownbio.com" };
                        SendEmail.SendMail_SMTP("html", Subject, title, toMails1, "Send successfully.");
                        SendEmail.SendMail_SMTP("html", Subject, title, toMails2, "Send successfully.");
                        #endregion

                        #region 发送给动物房间号负责人Leader
                        ParamCollection pl1 = new ParamCollection();
                        pl1.Clause = "DropDownList_Name = 'AnimalRoom Management'";
                        BaseList rooms = bll.Select(pl1, typeof(DROPDOWNLIST));
                        DROPDOWNLIST r = (DROPDOWNLIST)rooms[0];
                        foreach (string nodes in r.DROPDOWNLIST_CONTEXT.Split(new char[] { ';', '；' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            string[] aa = nodes.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries);
                            if (aa[0].Contains(((ANIMAL_INFO)animal[0]).ANIMAL_ROOM_NUMBER + "-" + ((ANIMAL_INFO)animal[0]).LOCATION_OF_LIVE_ANIMAL))
                            {
                                string[] toMails = { aa[2] };
                                SendEmail.SendMail_SMTP("html", Subject, title, toMails, "Send successfully.");
                                break;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        if (data.Count > 0)
                        {
                            row = (PROJECT_BOOKING)data[0];
                            _del_project = row.BOOKING;
                            row.CurModel = DealModel.Delete;
                            bll.Delete(row);
                        }
                    }
                    #endregion

                    #region save pro-monitor(booking)
                    ParamCollection pls = new ParamCollection();
                    pls.Clause += " MODEL_ID='" + book_MODEL_ID + "' and Booking = '" + _del_project + "'";
                    BaseList bookeddata = bll.Select(pls, typeof(PROJECT_BOOKING));

                    if (bookeddata.Count == 1)
                    {
                        ParamCollection pl1 = new ParamCollection();
                        pl1.Clause += " BOOKING_ANIMALS = '' and Model_ID = '" + book_MODEL_ID + "' and Project_Number='" + _del_project + "'";
                        BaseList monitor = bll.Select(pl1, typeof(PROJECT_MONITOR));
                        foreach (PROJECT_MONITOR dr in monitor)
                        {
                            dr.CurModel = DealModel.Modify;
                            dr.BOOKING_ANIMALS = DateTime.Now.ToShortDateString();
                            bll.Update(dr);
                        }
                        //子项目依附主项目
                        ParamCollection pl = new ParamCollection();
                        pl.Clause += " REQUEST_ID in (select [REQUEST_ID] from [PIGGYBACKED] where Model_ID = '" + book_MODEL_ID + "' and PIGGYBACKED_BY ='" + _del_project + "')";
                        BaseList childrenData = bll.Select(pl, typeof(REQUEST));
                        if (childrenData.Count > 0)
                        {
                            REQUEST childrow = (REQUEST)childrenData[0];
                            ParamCollection pl2 = new ParamCollection();
                            pl2.Clause += " BOOKING_ANIMALS = '' and Model_ID = '" + childrow.MODEL_ID + "' and Project_Number='" + childrow.PROJECT_NUMBER + "'";
                            BaseList monitor2 = bll.Select(pl2, typeof(PROJECT_MONITOR));
                            foreach (PROJECT_MONITOR dr in monitor2)
                            {
                                dr.CurModel = DealModel.Modify;
                                dr.BOOKING_ANIMALS = DateTime.Now.ToShortDateString();
                                bll.Update(dr);
                            }
                        }
                    }

                    else if (bookeddata.Count == 0)
                    {
                        ParamCollection pl1 = new ParamCollection();
                        pl1.Clause += " BOOKING_ANIMALS <> '' and Model_ID = '" + book_MODEL_ID + "' and Project_Number='" + _del_project + "'";
                        BaseList monitor = bll.Select(pl1, typeof(PROJECT_MONITOR));
                        foreach (PROJECT_MONITOR dr in monitor)
                        {
                            dr.CurModel = DealModel.Modify;
                            dr.BOOKING_ANIMALS = "";
                            bll.Update(dr);
                        }
                        //子项目依附主项目
                        ParamCollection pl = new ParamCollection();
                        pl.Clause += " REQUEST_ID in (select [REQUEST_ID] from [PIGGYBACKED] where Model_ID = '" + book_MODEL_ID + "' and PIGGYBACKED_BY ='" + _del_project + "')";
                        BaseList childrenData = bll.Select(pl, typeof(REQUEST));
                        if (childrenData.Count > 0)
                        {
                            REQUEST childrow = (REQUEST)childrenData[0];
                            ParamCollection pl2 = new ParamCollection();
                            pl2.Clause += " BOOKING_ANIMALS <> '' and Model_ID = '" + childrow.MODEL_ID + "' and Project_Number='" + childrow.PROJECT_NUMBER + "'";
                            BaseList monitor2 = bll.Select(pl2, typeof(PROJECT_MONITOR));
                            foreach (PROJECT_MONITOR dr in monitor2)
                            {
                                dr.CurModel = DealModel.Modify;
                                dr.BOOKING_ANIMALS = "";
                                bll.Update(dr);
                            }
                        }
                    }
                    #endregion

                    code = "OK";
                    var json = APItoJson(new { code, msg = "booking is successful" });
                    return json;
                }
                else
                {
                    code = "error";
                    var json = APItoJson(new { code, msg = "project number is not found" });
                    return json;
                }
            }
            catch (Exception ex)
            {
                code = "error";
                msg = ex.Message.ToString();
                var json = APItoJson(new { code, msg });
                return json;
            }

        }
        public class savebooking
        {
            public string Animal_Booking { get; set; }
            public string Further_Expanding { get; set; }
            public string Revive { get; set; }
            public string Animal_Number { get; set; }
            public string Request_ID { get; set; }
            public string Project_Number { get; set; }
            public string Book_MODEL_ID { get; set; }
        }
    }
}