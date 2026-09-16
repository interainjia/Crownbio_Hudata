using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crownbio.BLL;
using System.Collections;
using System.Data;
using Crownbio.Common;
using Crownbio.Model;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using System.Text;
using Crownbio.Utility;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Web.UI.WebControls;

namespace PDXmodelBase.HuData
{
    /// <summary>
    /// Getdatagrid 的摘要说明
    /// </summary>
    public class Getdatagrid : IHttpHandler, IRequiresSessionState
    {
        ObjectBLL bll = new ObjectBLL();
       
        private DataTable typedata = new DataTable();
        public void ProcessRequest(HttpContext context)
        {
            int page = 1;
            int row = 10;
          
            string sort = "";
            string order = "";

            context.Response.ContentType = "text/plain";
            if (context.Request["rows"] != null)
            {
                row = int.Parse(context.Request["rows"].ToString());
                page = int.Parse(context.Request["page"].ToString());
            }
            if (context.Request["sort"] != null)
            {
                sort = context.Request["sort"].ToString();
            }
            if (context.Request["order"] != null)
            {
                order = context.Request["order"].ToString();
            }
            string Method = context.Request.Params["M"];
            switch (Method)
            {
                case "ajaxGetColumns":
                    ajaxGetColumns(context);
                    break;

                #region New Request
                case "getdgRequest2":
                    getdgRequest2(context, row, page, sort, order);
                    break;
                case "getdgRequest_Completed":
                    getdgRequest_Completed(context, row, page, sort, order);
                    break;
                //case "getdgSelectMice":
                //    getdgSelectMice(context, row, page, sort, order);
                //    break;
                case "getdgSelectMice2":
                    getdgSelectMice2(context, row, page, sort, order);
                    break;
                case "getdgModifyRequest":
                    getdgModifyRequest(context, row, page, sort, order);
                    break;
                case "getdgEditRequest":
                    getdgEditRequest(context);
                    break;
                case "getdgAnimalStatus":
                    getdgAnimalStatus(context, row, page, sort, order);
                    break;
                #endregion




                case "getdgModelInfo":
                    getdgModelInfo(context, row, page, sort, order);
                    break;



                case "getdgProjectBooking":
                    getdgProjectBooking(context, row, page, sort, order);
                    break;
                case "getdgAnimalInfo":
                    getdgAnimalInfo(context, row, page, sort, order);
                    break;

                case "gettbAnimalinfo_Logs":
                    gettbAnimalinfo_Logs(context, row, page, sort, order);
                    break;

                #region Project Monitor
                case "getAnimal_Handover":
                    getAnimal_Handover(context);
                    break;
                case "CheckRole_Animal_Handover":
                    CheckRole_Animal_Handover(context);
                    break;
                #endregion

                #region ProjectMonitor
                case "getdgProjectMonitor":
                    getdgProjectMonitor(context, row, page, sort, order);
                    break;
                case "getdgStudyDesign":
                    getdgStudyDesign(context, row, page, sort, order);
                    break;

                case "getdgHusbandry":
                    getdgHusbandry(context, row, page, sort, order);
                    break;
                case "getdgWorkload":
                    getdgWorkload(context, row, page, sort, order);
                    break;
                case "getdgTakeRate":
                    getdgTakeRate(context, row, page, sort, order);
                    break;
                case "getPharmacology_Effect":
                    getPharmacology_Effect(context);
                    break;
                case "getdgDTgroup":
                    getdgDTgroup(context, row, page, sort, order);
                    break;

                #endregion

                #region Tissue Bank

                case "getTemp_dgTissueStock":
                    getTemp_dgTissueStock(context, row, page, sort, order);
                    break;
                case "getdgTissueStock":
                    getdgTissueStock(context, row, page, sort, order);
                    break;
                case "getdgTissueWithdraw":
                    getdgTissueWithdraw(context, row, page, sort, order);
                    break;
                case "getdgTissueWithdraw_Completed":
                    getdgTissueWithdraw_Completed(context, row, page, sort, order);
                    break;
                case "getdgAnimal":
                    getdgAnimal(context, row, page, sort, order);
                    break;

                case "editModelTree":
                    editModelTree(context);
                    break;

                #endregion


                #region New Model
                case "getdgAnimalInfo_NewModel":
                    getdgAnimalInfo_NewModel(context, row, page, sort, order);
                    break;
                case "getdgNewModel":
                    getdgNewModel(context, row, page, sort, order);
                    break;
                case "getdgNewModel_Log":
                    getdgNewModel_Log(context, row, page, sort, order);
                    break;

                case "getdgValidation":
                    getdgValidation(context, row, page, sort, order);
                    break;
                case "getdgValidation_Log":
                    getdgValidation_Log(context, row, page, sort, order);
                    break;
                case "getdgAnimalInfo_Validation":
                    getdgAnimalInfo_Validation(context, row, page, sort, order);
                    break;

                case "getdgRoutineMaintain":
                    getdgRoutineMaintain(context, row, page, sort, order);
                    break;
                case "getdgRoutineMaintain_Log":
                    getdgRoutineMaintain_Log(context, row, page, sort, order);
                    break;
                case "getdgAnimalInfo_RoutineMaintain":
                    getdgAnimalInfo_RoutineMaintain(context, row, page, sort, order);
                    break;
                case "getdgEndModels":
                    getdgEndModels(context, row, page, sort, order);
                    break;

                case "getdgValidationStatus_Huprime":
                    getdgValidationStatus_Huprime(context, row, page, sort, order);
                    break;
                case "getdgValidationStatus_Hukime":
                    getdgValidationStatus_Hukime(context, row, page, sort, order);
                    break;
                case "getdgRevival":
                    getdgRevival(context, row, page, sort, order);
                    break;
                case "getdgGeneticTest":
                    getdgGeneticTest(context, row, page, sort, order);
                    break;
                    
                #endregion

                #region MuPrime
                case "getdgMuPrime":
                    getdgMuPrime(context, row, page, sort, order);
                    break;
                #endregion
            }
        }

        public void getdgMuPrime(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();
            #region 高级搜索
            string str = context.Request["str"] ?? "";
            ParamCollection paralist = new ParamCollection();
            if (str != "")
            {
                string[] list = str.Split(':');

                for (int z = 0; z < list.Length - 1; z++)
                {
                    string[] strlist = list[z].Split(',');
                    string value = strlist[3];
                    if (strlist[2].Contains("like"))
                    {
                        value = "%" + strlist[3] + "%";
                    }
                    paralist.Clause += " and " + strlist[1] + " " + strlist[2] + " '" + value + "'";
                }
                paralist = queryAdSearch(context, paralist.Clause);
            }
            else
            {
                paralist = queryMuPrime(context);
            }
            #endregion

            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause) };
            dtAll = ojbReportRule.GetGrid("GetdgMuPrime", para);


            context.Session["dgMuPrime"] = null;
            if (dtAll.Rows.Count > 0)
            {
                SYS_USER userLogin = CacheHelper.getCurrentUser();
                if (!ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin"))
                {
                    dtAll.Columns.Remove("Model_From");
                }
                context.Session["dgMuPrime"] = dtAll;
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }

        public void getdgRoutineMaintain(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = query_dgRoutineMaintain(context);
            context.Session["dgRoutineMaintain"] = null;
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause)
                , new SqlParameter("@pageSize", pageSize)
                ,new SqlParameter("@CurrentPageIndex", CurrentPageIndex)};

            DataTable dtAll = ojbReportRule.GetGrid("GetdgRoutineMaintain_Total", new SqlParameter[] { new SqlParameter("@str", paralist.Clause) });
            if (int.Parse(dtAll.Rows[0][0].ToString()) > 0)
            {
                DataTable dt = ojbReportRule.GetGrid("GetdgRoutineMaintain", para);
                context.Session["dgRoutineMaintain"] = dt;
                var list = new { total = dtAll.Rows[0][0].ToString(), rows = dt };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
            else
            {
                var list = new { total = 0, rows = new List<object>() };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
        }

        public void getdgValidation(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = query_dgValidation(context);
            context.Session["dgValidation"] = null;
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause)
                , new SqlParameter("@pageSize", pageSize)
                ,new SqlParameter("@CurrentPageIndex", CurrentPageIndex)};

            DataTable dtAll = ojbReportRule.GetGrid("GetdgValidation_Total", new SqlParameter[] { new SqlParameter("@str", paralist.Clause) });
            if (int.Parse(dtAll.Rows[0][0].ToString()) > 0)
            {
                DataTable dt = ojbReportRule.GetGrid("GetdgValidation", para);
                context.Session["dgValidation"] = dt;
                var list = new { total = dtAll.Rows[0][0].ToString(), rows = dt };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
            else
            {
                var list = new { total = 0, rows = new List<object>() };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
        }

        public void getdgEndModels(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = query_dgEndModels(context);
            context.Session["dgEndModels"] = null;
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause) };
            DataTable dtAll = ojbReportRule.GetGrid("GetdgEndModels", para);

            if (dtAll.Rows.Count > 0)
            {
                context.Session["dgEndModels"] = dtAll;
                DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }

        public void getdgGeneticTest(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = query_dgGeneticTest(context);

            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause)
                , new SqlParameter("@pageSize", pageSize)
                ,new SqlParameter("@CurrentPageIndex", CurrentPageIndex)};

            DataTable dtAll = ojbReportRule.GetGrid("GetdgGeneticTest_Total", new SqlParameter[] { new SqlParameter("@str", paralist.Clause) });
            if (int.Parse(dtAll.Rows[0][0].ToString()) > 0)
            {
                DataTable dt = ojbReportRule.GetGrid("GetdgGeneticTest", para);

                var list = new { total = dtAll.Rows[0][0].ToString(), rows = dt };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
            else
            {
                var list = new { total = 0, rows = new List<object>() };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
        }

        public void getdgRevival(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = query_dgRevival(context);
   
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause)
                , new SqlParameter("@pageSize", pageSize)
                ,new SqlParameter("@CurrentPageIndex", CurrentPageIndex)};

            DataTable dtAll = ojbReportRule.GetGrid("GetdgRevival_Total", new SqlParameter[] { new SqlParameter("@str", paralist.Clause) });
            if (int.Parse(dtAll.Rows[0][0].ToString()) > 0)
            {
                DataTable dt = ojbReportRule.GetGrid("GetdgRevival", para);
            
                var list = new { total = dtAll.Rows[0][0].ToString(), rows = dt };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
            else
            {
                var list = new { total = 0, rows = new List<object>() };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
        }

        public void getdgValidationStatus_Huprime(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = query_dgValidationStatus_Huprime(context);
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause) };
            DataTable dtAll = ojbReportRule.GetGrid("GetdgValidationStatus_Huprime", para);

            if (dtAll.Rows.Count > 0)
            {
                DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }
        public void getdgValidationStatus_Hukime(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = query_dgValidationStatus_Hukime(context);
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause) };
            DataTable dtAll = ojbReportRule.GetGrid("getdgValidationStatus_Hukime", para);

            if (dtAll.Rows.Count > 0)
            {
                DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }


        public void getdgNewModel(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            ParamCollection paralist = new ParamCollection();
            paralist = query_dgNewModel(context);
            context.Session["dgNewModel"] = null;
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause)
                , new SqlParameter("@pageSize", pageSize)
                ,new SqlParameter("@CurrentPageIndex", CurrentPageIndex)};

            DataTable dtAll = ojbReportRule.GetGrid("GetdgNewModel_Total", new SqlParameter[] { new SqlParameter("@str", paralist.Clause) });
            if (int.Parse(dtAll.Rows[0][0].ToString()) > 0)
            {
                DataTable dt = ojbReportRule.GetGrid("GetdgNewModel", para);
                context.Session["dgNewModel"] = dt;
                var list = new { total = dtAll.Rows[0][0].ToString(), rows = dt };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
            else
            {
                var list = new { total = 0, rows = new List<object>() };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
        }

        
        public void getdgNewModel_Log(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@id", context.Request.Form["id"].ToString()) };
            DataTable dtAll = ojbReportRule.GetGrid("GetdgNewModel_Log", para);
            if (dtAll.Rows.Count > 0)
            {
                DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }

        public void getdgValidation_Log(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@id", context.Request.Form["id"].ToString()) };
            DataTable dtAll = ojbReportRule.GetGrid("GetdgValidation_Log", para);
            if (dtAll.Rows.Count > 0)
            {
                DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }

        public void getdgRoutineMaintain_Log(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@id", context.Request.Form["id"].ToString()) };
            DataTable dtAll = ojbReportRule.GetGrid("GetdgRoutineMaintain_Log", para);
            if (dtAll.Rows.Count > 0)
            {
                DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }

        public void getPharmacology_Effect(HttpContext context)
        {
            string hf_Pharmacology_Effect = context.Request["hf_Pharmacology_Effect"] ?? "";
            ParamCollection query2 = new ParamCollection();
            query2.Clause = PHARMACOLOGY_EFFECT.ANIMALTREE_ID_FIELD + " = '" + hf_Pharmacology_Effect + "'";
            BaseList data = bll.Select(query2, typeof(PHARMACOLOGY_EFFECT));
            DataTable dt = UtitityHelper.ToDataTable(data);
            string dd = MStoJson(dt);
            context.Response.Write(dd);
        }

        public void getTemp_dgTissueStock(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            if (context.Session["temp_tissue"] != null)
            {
                DataTable dtAll = (DataTable)context.Session["temp_tissue"];
                DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else if (context.Session["temp_Withdraw"] != null)
            {
                DataTable dtAll = (DataTable)context.Session["temp_Withdraw"];
                DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }
        public void getdgTissueStock(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {

            ParamCollection paralist = new ParamCollection();
            paralist = queryTissueStock(context);
            context.Session["dgSpecimenStocks"] = null;
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause)
                , new SqlParameter("@pageSize", pageSize)
                ,new SqlParameter("@CurrentPageIndex", CurrentPageIndex)};

            DataTable dtAll = ojbReportRule.GetGrid("GetdgSpecimenStocks_Total", new SqlParameter[] { new SqlParameter("@str", paralist.Clause) });
            if (int.Parse(dtAll.Rows[0][0].ToString())>0)
            {
                DataTable dt = ojbReportRule.GetGrid("GetdgSpecimenStocks", para);
                context.Session["dgSpecimenStocks"] = dt;
                string dd = ConvertDTToJson(dt, dtAll.Rows[0][0].ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }

        public void getdgTissueWithdraw(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {

            ParamCollection paralist = new ParamCollection();
            paralist = queryTissueWithdraw(context);
            context.Session["dgTissueWithdraw"] = null;
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause)
                , new SqlParameter("@pageSize", pageSize)
                ,new SqlParameter("@CurrentPageIndex", CurrentPageIndex)};
            DataTable dtAll = ojbReportRule.GetGrid("GetdgTissueWithdraw", para);

            paralist.Clause = paralist.Clause.Replace("where", "");
            int total = bll.GetCount(paralist, typeof(TISSUE_WITHDRAW));
            if (dtAll.Rows.Count>0)
            {
                context.Session["dgTissueWithdraw"] = dtAll;
                string dd = ConvertDTToJson(dtAll, total.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }

        public void getdgTissueWithdraw_Completed(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {

            ParamCollection paralist = new ParamCollection();
            paralist = queryTissueWithdraw_Completed(context);
            context.Session["dgTissueWithdraw_Completed"] = null;
          
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause)
                , new SqlParameter("@pageSize", pageSize)
                ,new SqlParameter("@CurrentPageIndex", CurrentPageIndex)};
            DataTable dtAll = ojbReportRule.GetGrid("GetdgTissueWithdraw", para);

            paralist.Clause = paralist.Clause.Replace("where", "");
            int total = bll.GetCount(paralist, typeof(TISSUE_WITHDRAW));
            if (dtAll.Rows.Count>0)
            {
                context.Session["dgTissueWithdraw_Completed"] = dtAll;
                string dd = ConvertDTToJson(dtAll, total.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }


        public void editModelTree(HttpContext context)
        {
            string editModelTree_ID = context.Request["editModelTree_ID"] ?? "";
            ParamCollection paramlist = new ParamCollection();
            paramlist.Clause = ANIMAL_TREE.AID_FIELD + "='" + editModelTree_ID + "'";
            BaseList data = bll.Select(paramlist, typeof(ANIMAL_TREE));
            if (data.Count > 0)
            {
                ANIMAL_TREE row = (ANIMAL_TREE)data[0];
                BaseList data2 = new BaseList();

                ParamCollection paramlist2 = new ParamCollection();
                paramlist.Clause = NEWMODEL.MODEL_ID_FIELD + "='" + row.MODEL_ID + "'";
                paramlist.Clause += " and " + NEWMODEL.RN_FIELD + "='R" + row.RN + "'";
                paramlist.Clause += " and " + NEWMODEL.PN_FIELD + "='P" + row.PN + "'";
                data2 = bll.Select(paramlist, typeof(NEWMODEL));
                if (data2.Count > 0)
                {
                    string dd = ConvertDTToJson(UtitityHelper.ToDataTable(data2), data2.Count.ToString());
                    context.Response.Write(dd);
                }
                else
                {
                    context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
                }
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }

        public void getdgAnimal(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            string txtModel_ID = context.Request["txtModel_ID"] ?? "";
            ParamCollection paralist = new ParamCollection();
            paralist.Clause = ANIMAL_INFO.MODEL_ID_FIELD + "='" + txtModel_ID + "'";

            BaseList data = bll.Select(paralist,typeof(ANIMAL_INFO));
            DataTable dtAll = UtitityHelper.ToDataTable(data);
            if (dtAll.Rows.Count>0)
            {
                DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }
        

        public void CheckRole_Animal_Handover(HttpContext context)
        {
            string msg = "";
            SYS_USER userLogin = CacheHelper.getCurrentUser();

            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format(" ROLE_NO in (select ROLE_NO from SYS_USER_ROLE where USER_ID = '{0}')"
                , new object[] { userLogin.USER_ID.ToString() });
            BaseList Roledata = bll.Select(_paramCollection, typeof(SYS_ROLE));
            foreach(SYS_ROLE row in Roledata)
            {
                if (row.ROLE_NAME == "CBCN JSD Group" || row.ROLE_NAME == "PDX Logistic")
                {
                    msg = "save";
                    break;
                }
                else if (row.ROLE_NAME == "CBCN SD Group")
                {
                    msg = "read only";
                }
            }
            context.Response.Write(msg);
        }
        public void getAnimal_Handover(HttpContext context)
        {
            DataTable newData = new DataTable();
            newData.Columns.Add("Tissue_Batch");
            newData.Columns.Add("Date_of_Tissue");
            newData.Columns.Add("Animal_by_Tissue");
            newData.Columns.Add("Source_Project");
            newData.Columns.Add("Leader");
            newData.Columns.Add("Modelbatch1");
            newData.Columns.Add("Animal_by_Live");
            newData.Columns.Add("IVC");
            newData.Columns.Add("Expected_Date_To_Support");
            newData.Columns.Add("Date_of_Deliver");
            newData.Columns.Add("Receiving_Project");
            newData.Columns.Add("JSD");
            newData.Columns.Add("Modelbatch2");
            newData.Columns.Add("Healthy_and_Alive");
            newData.Columns.Add("Animal_Dead");
            newData.Columns.Add("Date_of_Receive");
            newData.Columns.Add("Inoculation_Used");
            newData.Columns.Add("Tissue_Collection");

            string hfMid = context.Request["hfMid"] ?? "";
            string hfRid = context.Request["hfRid"] ?? "";
            string pdate = context.Request["pdate"] ?? "";
            DataRow newRow = newData.NewRow();

            #region ANIMAL_HANDOVER
            #region booking 在自己项目和piggybacked by 项目的都算
            ParamCollection pl = new ParamCollection();
            pl.Clause += " Project_Number in (select [PIGGYBACKED_BY] from [PIGGYBACKED] where REQUEST_ID = '" + hfRid + "'";
            pl.Clause += " and Model_ID = '" + hfMid + "')";
            BaseList newRid = bll.Select(pl, typeof(REQUEST));
            string id = hfRid;
            if (newRid.Count > 0)
            {
                id = ((REQUEST)newRid[0]).REQUEST_ID.ToString();
            }
            #endregion

            ParamCollection paraList2 = new ParamCollection();
            paraList2.Clause = ANIMAL_HANDOVER.MODEL_ID_FIELD + "='" + hfMid + "' and " + ANIMAL_HANDOVER.REQUEST_ID_FIELD + "='" + hfRid + "'";
            BaseList hData = bll.Select(paraList2, typeof(ANIMAL_HANDOVER));
            if (hData.Count == 0)
            {
                ParamCollection paraList3 = new ParamCollection();
                paraList3.Clause = ANIMAL_HANDOVER.MODEL_ID_FIELD + "='" + hfMid + "' and " + ANIMAL_HANDOVER.REQUEST_ID_FIELD + "='" + id + "'";
                hData = bll.Select(paraList3, typeof(ANIMAL_HANDOVER));
            }
            //#region 取消预约的老鼠应该查不到
            //ParamCollection paraList4 = new ParamCollection();
            //paraList4.Clause = PROJECT_MONITOR.MODEL_ID_FIELD + "='" + hfMid + "' and " + PROJECT_MONITOR.REQUEST_ID_FIELD + "='" + hfRid + "' and " + PROJECT_MONITOR.BOOKING_ANIMALS_FIELD + " <> ''";
            //BaseList pmData = bll.Select(paraList4, typeof(PROJECT_MONITOR));
            //#endregion
            if (hData.Count > 0)
            {
              
                ANIMAL_HANDOVER hrow = (ANIMAL_HANDOVER)hData[0];
                newRow["Tissue_Batch"] = hrow.TISSUE_BATCH;
                newRow["Date_of_Tissue"] = FormatHelper.getFormatDate(hrow.DATE_OF_TISSUE);
                newRow["Animal_by_Tissue"] = hrow.ANIMAL_BY_TISSUE;
                newRow["Leader"] = hrow.LEADER;
                newRow["Expected_Date_To_Support"] = hrow.EXPECTED_DATE_TO_SUPPORT;
                newRow["Date_of_Deliver"] = hrow.DATE_OF_DELIVER;

                newRow["Source_Project"] = hrow.SOURCE_PROJECT;
                newRow["Modelbatch1"] = hrow.MODELBATCH1;
                newRow["Animal_by_Live"] = hrow.ANIMAL_BY_LIVE;
                newRow["IVC"] = hrow.IVC;
                newRow["Receiving_Project"] = hrow.RECEIVING_PROJECT;

                newRow["JSD"] = hrow.JSD;
                newRow["Modelbatch2"] = hrow.MODELBATCH2;
                newRow["Healthy_and_Alive"] = hrow.HEALTHY_AND_ALIVE;
                newRow["Animal_Dead"] = hrow.ANIMAL_DEAD;
                newRow["Date_of_Receive"] = hrow.DATE_OF_RECEIVE;
                newRow["Inoculation_Used"] = hrow.INOCULATION_USED;
                newRow["Tissue_Collection"] = hrow.TISSUE_COLLECTION;
               
            }
            else
            {

                newRow["Tissue_Batch"] = "";
                newRow["Date_of_Tissue"] = "";
                newRow["Animal_by_Tissue"] = "";
                newRow["Healthy_and_Alive"] = "";
                newRow["Animal_Dead"] = "";
                newRow["Inoculation_Used"] = "";
                newRow["Tissue_Collection"] = "";
                newRow["Leader"] = "";
              
            }
            #region ANIMAL_INFO
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Model_ID", hfMid)
                    ,new SqlParameter("@PN", " ")    };
            DataTable dt = ojbReportRule.GetGrid("GetAnimalStatus", para);


            DataRow[] drs = dt.Select("Request_ID = '" + id + "'");
            DataTable Adata = dt.Clone();
            for (int i = 0; i < drs.Length; i++)
            {
                Adata.ImportRow((DataRow)drs[i]);
            }

            int rn = 0;
            int pn = 0;
            if (Adata.Rows.Count > 0)
            {
                DataRow dr = Adata.Rows[0];
                newRow["Source_Project"] = dr["Source_Project"].ToString();
                newRow["Modelbatch1"] = dr["MODEL_ID"].ToString() + "-" + dr["Rn"].ToString() + dr["Pn"].ToString() + "-" + DateTime.Parse(dr["DOI"].ToString()).ToString("yyyyMMdd");
                if (RegHelper.IsNumber0(dr["Rn"].ToString().Replace("R", "")))
                {
                    rn = int.Parse(dr["Rn"].ToString().Replace("R", ""));
                }
                if (RegHelper.IsNumber0(dr["Pn"].ToString().Replace("P", "")))
                {
                    pn = int.Parse(dr["Pn"].ToString().Replace("P", ""));
                }
                newRow["IVC"] = dr["Location_of_live_animal"].ToString() + "-" + dr["Animal_Room_Number"].ToString() + "-" + dr["IVC_Location"].ToString();

                #region PROJECT_BOOKING
                DataRow drr = Adata.Rows[0];
                newRow["Receiving_Project"] = drr["Animal_Booking"].ToString();

                ArrayList animal_number = new ArrayList();
                foreach (DataRow dr2 in Adata.Rows)
                {
                    animal_number.Add(dr2["Animal_Number"]);
                }
                newRow["Animal_by_Live"] = string.Join(",", animal_number.ToArray());
                #endregion
            }

            
            #endregion

            if (hData.Count == 0)
            {
                #region PROJECT_MONITOR
                ParamCollection pl4 = new ParamCollection();
                pl4.Clause = PROJECT_MONITOR.MODEL_ID_FIELD + "='" + hfMid + "' and " + PROJECT_MONITOR.REQUEST_ID_FIELD + "='" + hfRid + "'";
                BaseList MData = bll.Select(pl4, typeof(PROJECT_MONITOR));
                if (MData.Count > 0)
                {
                    PROJECT_MONITOR Mrow = (PROJECT_MONITOR)MData[0];
                    newRow["JSD"] = Mrow.JSD;
                    newRow["Expected_Date_To_Support"] = Mrow.ESTIMATED_DOI;
                    if (RegHelper.IsDateTime(Mrow.INOCULATION))
                    {
                        newRow["Modelbatch2"] = hfMid + "-R" + rn + "P" + (pn + 1).ToString() + "-" + DateTime.Parse(Mrow.INOCULATION).ToString("yyyyMMdd");
                    }
                }
                #endregion
            }
            #endregion

            

            newData.Rows.Add(newRow);

            string dd = MStoJson(newData);
            context.Response.Write(dd);
        }


        public void getdgEditRequest(HttpContext context)
        {
            string hfRequest_id = context.Request["request_id"] ?? "";
            ParamCollection paraList = new ParamCollection();
            paraList.Clause = REQUEST.REQUEST_ID_FIELD + "='" + hfRequest_id + "'";
            BaseList data = bll.Select(paraList, typeof(REQUEST));
            DataTable dt = UtitityHelper.ToDataTable(data);
            string dd = MStoJson(dt);
            context.Response.Write(dd);
        }
        public string MStoJson(DataTable dt)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ArrayList dic = new ArrayList();
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> drow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    drow.Add(col.ColumnName, row[col.ColumnName]);
                }
                dic.Add(drow);
            }
            return jss.Serialize(dic);
        }

        public string CharttoJson(DataTable dt)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ArrayList dic = new ArrayList();
            foreach (DataRow row in dt.Rows)
            {
                ArrayList drow = new ArrayList();
                foreach (DataColumn col in dt.Columns)
                {
                    drow.Add(row[col.ColumnName]);
                }
                dic.Add(drow);
            }
            return jss.Serialize(dic);
        }


        public void getdgModifyRequest(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();
            string hfRequest_id = context.Request["hfRequest_id"] ?? "";
            BaseList data = bll.Select(queryModifydata(hfRequest_id), typeof(REQUEST_LOG));
            dtAll = UtitityHelper.ToDataTable(data);
            if (dtAll.Rows.Count > 0)
            {
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }

        public void getdgStudyDesign(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();

            if (context.Request["hfMonitor_id"] != null)
            {
                if (context.Request["hfMonitor_id"].ToString() != "")
                {
                    BaseList data = bll.Select(queryStudy(context), "PROJECT_MONITOR_ID ASC", typeof(PROJECT_MONITOR_STUDY_DESIGN));
                    dtAll = UtitityHelper.ToDataTable(data);
                }
            }
            context.Session["dgStudyDesign"] = null;
            if (dtAll.Rows.Count > 0)
            {
                context.Session["dgStudyDesign"] = dtAll;
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
             

        }

        public void getdgProjectMonitor(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            ParamCollection paralist = new ParamCollection();
            if (context.Request["type"].ToString() == "All")
            {
                paralist = queryMonitor(context);
            }
            else if (context.Request["type"].ToString() == "Completed")
            {
                paralist = queryMonitor_Completed(context);
            }
            context.Session["dgProjectMonitor"] = null;
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@str", paralist.Clause)
                , new SqlParameter("@pageSize", pageSize)
                ,new SqlParameter("@CurrentPageIndex", CurrentPageIndex)};

            DataTable dtAll = ojbReportRule.GetGrid("GetdgProjectMonitor_Total", new SqlParameter[] { new SqlParameter("@str", paralist.Clause) });
            if (int.Parse(dtAll.Rows[0][0].ToString()) > 0)
            {
                DataTable dt = ojbReportRule.GetGrid("GetdgProjectMonitor", para);
                context.Session["dgProjectMonitor"] = dt;
                var list = new { total = dtAll.Rows[0][0].ToString(), rows = dt };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
            else
            {
                var list = new { total = 0, rows = new List<object>() };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
        }

        #region //算分钟
        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public double SearchRoute(List<PROJECT_MONITOR_DOSING_ROUTE> data, string codes)
        {
            double time = 0;
            foreach (string code in codes.Split(','))
            {
                PROJECT_MONITOR_DOSING_ROUTE ds = data.Find(delegate(PROJECT_MONITOR_DOSING_ROUTE perm) { return perm.CODE == code; });
                if (ds != null)
                {
                    time += double.Parse(ds.UNIT_TIME);
                }

            }
            return time;
        }
        #endregion




        public void getdgDTgroup(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();


            context.Session["dgDTgroup"] = null;
            SqlParameter[] para = new SqlParameter[] { };
            dtAll = ojbReportRule.GetGrid("GetWorkload_DM3", para);
            if (dtAll.Rows.Count > 0)
            {
                context.Session["dgDTgroup"] = dtAll;
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }


        }

        public void getdgWorkload(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();
          
            string person = context.Request["cbxDep"] ?? "";

            string name = context.Request["txtName"] ?? ""; 
            context.Session["dgWorkload"] = null;



            if (person == "SD")
            {
                SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Person", name)
                        };
                    dtAll = ojbReportRule.GetGrid("GetWorkload_SD2", para);
                
            }
            else if (person == "JSD")
            {
                SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Person", name)
                        };
                dtAll = ojbReportRule.GetGrid("GetWorkload_JSD2", para);
            }
            else
            {
                #region afterGroup
                List<PROJECT_MONITOR_DOSING_ROUTE> dataRoute = bll.Select(typeof(PROJECT_MONITOR_DOSING_ROUTE)).ConvertAll<PROJECT_MONITOR_DOSING_ROUTE>(PROJECT_MONITOR_DOSING_ROUTE.Convert);

                if (person == "DT group")
                {
                    SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Person", name) 
                        };
                    dtAll = ojbReportRule.GetGrid("GetWorkload_DT2", para);
                }
                else if (person == "DM")
                {
                    SqlParameter[] para = new SqlParameter[] { new SqlParameter("@DM", name) 
                        };
                    dtAll = ojbReportRule.GetGrid("GetWorkload_DM2", para);
                }
                foreach (DataRow row in dtAll.Rows)
                {
                    double dm_addwork = 0;
                    if (person == "DM")
                    {
                        dm_addwork = SearchRoute(dataRoute, "1.08") * double.Parse(row["Studylog_Time"].ToString());//当天活动次数
                    }
                    double alltime = double.Parse(row["STUDY_WORKLOAD"].ToString()) + dm_addwork;
                    if (alltime < 180 && alltime > 0)
                    {
                        row["STUDY_WORKLOAD"] = alltime + SearchRoute(dataRoute, "1.01,1.02");
                    }
                    else
                    {
                        row["STUDY_WORKLOAD"] = alltime + SearchRoute(dataRoute, "1.01,1.02") * 2;
                    }
                }

                #endregion
            }

            if (dtAll.Rows.Count > 0)
            {
                context.Session["dgWorkload"] = dtAll;
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }


        }

        public void getdgTakeRate(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();

            context.Session["dgTakeRate"] = null;

            SqlParameter[] para = new SqlParameter[] {};
            dtAll = ojbReportRule.GetGrid("CancerType_Take_Rate", para);
           
            if (dtAll.Rows.Count > 0)
            {
                context.Session["dgTakeRate"] = dtAll;
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }


        }
        

        public void getdgHusbandry(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            DataTable dt = new DataTable();
            string date = context.Request["txtDate"] ?? "";
            BaseList dataAll = bll.Select(typeof(HUSBANDRY_ANALYSIS));
            List<HUSBANDRY_ANALYSIS> mastdata = dataAll.ConvertAll<HUSBANDRY_ANALYSIS>(HUSBANDRY_ANALYSIS.Convert);
            #region alive
            //foreach (HUSBANDRY_ANALYSIS row in mastdata)
            //{
            //    if (row.CurModel != DealModel.New)
            //    {
            //        row.CurModel = DealModel.Modify;
            //    }
            //    string pn = (int.Parse(row.PN.ToString().TrimStart('P')) + 1).ToString();
            //    HUSBANDRY_ANALYSIS newRow = mastdata.Find(delegate(HUSBANDRY_ANALYSIS perm)
            //    {
            //        return perm.MODEL_ID == row.MODEL_ID && perm.RN == row.RN && perm.PN == pn
            //            && perm.ALIVE != "Die";
            //    });
            //    DateTime start = row.DOI;//Husbandry Start
            //    if (start < DateTime.Parse("2014/01/01"))
            //    {
            //        start = DateTime.Parse("2014/01/01");
            //    }
            //    if (newRow != null)//有迭代
            //    {
            //        if (row.ALIVE != "z")
            //        {
            //            if (newRow.DOI > DateTime.Parse("2014/01/01"))
            //            {
            //                row.HUNBANDRY_DAYS = (newRow.DOI - start).Days + 1;
            //            }
            //            else
            //            {
            //                row.HUNBANDRY_DAYS = (newRow.DOI - row.DOI).Days + 1;
            //            }
            //            row.ALIVE = "Die";
            //        }
            //    }
            //    else
            //    {

            //    }
            //    if (row.CAGE != "")
            //    {
            //        string location = row.CAGE.Split('-')[0];
            //        if (location == "TC")
            //        {
            //            row.COST_ACCUMULATION = (13 * row.NUMBER_IN_CAGE * row.HUNBANDRY_DAYS).ToString();
            //        }
            //        else
            //        {
            //            row.COST_ACCUMULATION = (11 * row.NUMBER_IN_CAGE * row.HUNBANDRY_DAYS).ToString();
            //        }
            //    }

            //}
            #endregion
            
            context.Session["dgHusbandry"] = null;
            if (dataAll.Count > 0)
            {
                DataTable dtAll = UtitityHelper.ToDataTable(dataAll);
                dtAll.Columns.Remove("CurModel");
                dtAll.Columns.Remove("PID");
                dtAll.Columns.Remove("CODE");
                dtAll.Columns.Remove("DESC");
                dtAll.Columns.Remove("CHECK_CODE");
                dtAll.Columns.Remove("ID");
                dtAll.Columns.Remove("HUSBANDRY_ANALYSIS_ID");
                dtAll.Columns["CANCER_TYPE"].ColumnName = "Cancer_Type";
                dtAll.Columns["PROJECT"].ColumnName = "Project";
                dtAll.Columns["MODEL_ID"].ColumnName = "Model_ID";
                dtAll.Columns["RN"].ColumnName = "Rn";
                dtAll.Columns["PN"].ColumnName = "Pn";
                dtAll.Columns["DOI"].ColumnName = "DOI";
                dtAll.Columns["CAGE"].ColumnName = "Cage";
                dtAll.Columns["NUMBER_IN_CAGE"].ColumnName = "Number_in_Cage";
                dtAll.Columns["DATE_OF_UPDATE"].ColumnName = "Date_of_Update";
                dtAll.Columns["HUNBANDRY_DAYS"].ColumnName = "Hunbandry_Days";
                dtAll.Columns["COST_ACCUMULATION"].ColumnName = "Cost_accumulation";
                context.Session["dgHusbandry"] = dtAll;
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }


        }

        public void getdgSelectMice2(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            string hfRequest_id = context.Request["hfRequest_id"] ?? "";
            DataTable data = new DataTable();
            if (hfRequest_id != "")
            {
                ParamCollection paraList = new ParamCollection();
                paraList.Clause = REQUEST.REQUEST_ID_FIELD + "='" + hfRequest_id + "'";
                BaseList requestData = bll.Select(paraList, typeof(REQUEST));
                context.Session["dgSelectMice2"] = null;
                if (requestData.Count > 0)
                {
                    REQUEST row = (REQUEST)requestData[0];
                    if (row.MODEL_ID != "")
                    {
                        //dataModelInfo = bll.Select(queryModelRequest(context, row.MODEL_ID), typeof(PDXMODEL_INFO));
                        SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Model_ID", row.MODEL_ID)
                        ,new SqlParameter("@REQUEST_ID",row.REQUEST_ID)
                        };
                        data = ojbReportRule.GetGrid("GetRequestPart2-1", para);

                    }
                    else if ((row.TUMOR_TYPE != "" && row.TUMOR_TYPE != " ") || (row.SUBTYPE1 != "" && row.SUBTYPE1 != " ") || (row.SUBTYPE2 != "" && row.SUBTYPE2 != " "))
                    {
                        //string[] subtype = { };
                        //subtype = row.SUBTYPE.Split(',');
                        //dataModelInfo = bll.Select(queryPDXmodelinfo(context, row.TUMOR_TYPE, subtype), typeof(PDXMODEL_INFO));
                        SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TUMOR_TYPE", row.TUMOR_TYPE)
                        ,new SqlParameter("@subtype1",row.SUBTYPE1)  ,new SqlParameter("@subtype2",row.SUBTYPE2) ,new SqlParameter("@REQUEST_ID",row.REQUEST_ID)
                        };
                        data = ojbReportRule.GetGrid("GetRequestPart2-2", para);

                    }
                }
            }
            else
            {
                if (context.Session["dgSelectMice2"] != null)
                {
                    DataTable dt = (DataTable)context.Session["dgSelectMice2"];
                    string part2ProjectN = context.Request["part2ProjectN"] ?? "";
                    string part2HaveAnimals = context.Request["part2HaveAnimals"] ?? "";
                    string part2Model_ID = context.Request["part2Model_ID"] ?? "";
                    string query = "";
                    if (part2Model_ID != "")
                    {
                        query += "AND Model_ID= '" + part2Model_ID + "' ";
                    }
                    if (part2ProjectN != "")
                    {
                        query += "AND Project_Number= '" + part2ProjectN + "' ";
                    }
                    if (part2HaveAnimals != "")
                    {
                        query += "AND Have_Animals= '" + part2HaveAnimals + "' ";
                    }
                    if (query.Length > 3)
                    {
                        query = query.Substring(3, query.Length - 3);
                    }
                    DataRow[] drs = dt.Select(query);
                    data = dt.Clone();
                    for (int i = 0; i < drs.Length; i++)
                    {
                        data.ImportRow((DataRow)drs[i]);
                    }
                }
            }
            if (data.Rows.Count > 0)
            {
                DataTable dtAll = data;
                if (hfRequest_id != "")
                {
                    dtAll = UtitityHelper.AddAutoIdColumn(dtAll);//add AutoId
                    #region 加Location
                    dtAll.Columns.Add("Location");
                    dtAll.Columns.Add("Tumor_Numbers");
                    foreach (DataRow dr in dtAll.Rows)
                    {
                        ParamCollection paraList = new ParamCollection();
                        paraList.Clause = ANIMAL_INFO.MODEL_ID_FIELD + "='" + dr["Model_ID"] + "'";
                        BaseList locaData = bll.Select(paraList, typeof(ANIMAL_INFO));
                        string locationBJ = "-";
                        string locationTC = "-";
                        int Tumor_Numbers = 0;
                        foreach (ANIMAL_INFO row in locaData)
                        {
                            if (row.LOCATION_OF_LIVE_ANIMAL == "BJ")
                            {
                                locationBJ = "+";
                            }
                            else if (row.LOCATION_OF_LIVE_ANIMAL == "TC")
                            {
                                locationTC = "+";
                            }
                            Tumor_Numbers += row.TUMOR_NUMBER;
                        }
                        dr["Location"] = locationBJ + "/" + locationTC;
                        dr["Tumor_Numbers"] = Tumor_Numbers;
                    }
                    #endregion
                  
                    context.Session["dgSelectMice2"] = dtAll;
                }
                DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
              

                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {

                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }


        }

        #region request时候查询对应的pdxmodelinfo
        private ParamCollection queryPDXmodelinfo(HttpContext context, string cancertype, string[] subtype, string[] subtype2)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            if (cancertype != "" && cancertype != " ")
            {
                column = PDXMODEL_INFO.CANCER_TYPE_FIELD;
                Clause += string.Format("AND ({0}.{1} = '{2}')", PDXMODEL_INFO.TABLE_NAME, column, cancertype);
            }

            string ids = "";
            if (subtype[0] == "")//为选择或者全选
            {
            }
            else
            {
                foreach (string id in subtype)
                {
                    ids += "'" + id + "',";
                }
                column = PDXMODEL_INFO.SUBTYPE1_FIELD;
                Clause += string.Format("AND ({0}.{1} in ({2}) )", PDXMODEL_INFO.TABLE_NAME, column, ids.TrimEnd(','));
            }

            string ids2 = "";
            if (subtype2[0] == "")//为选择或者全选
            {
            }
            else
            {
                foreach (string id in subtype2)
                {
                    ids2 += "'" + id + "',";
                }
                column = PDXMODEL_INFO.SUBTYPE2_FIELD;
                Clause += string.Format("AND ({0}.{1} in ({2}) )", PDXMODEL_INFO.TABLE_NAME, column, ids2.TrimEnd(','));
            }
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }


        public string ModelIDs(string model_ids)
        {
            string ids = "";
            foreach (string a in model_ids.Split(','))
            {
                if (a != "")
                {
                    ids += "'" + a + "',";
                }
            }
            return ids.TrimEnd(',');
        }
        private ParamCollection queryModelRequest(HttpContext context, string model_ids)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";

            string ids = "";
            foreach (string a in model_ids.Split(','))
            {
                if (a != "")
                {
                    ids += "'" + a + "',";
                }
            }
            column = PDXMODEL_INFO.MODEL_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} in ({2}) )", PDXMODEL_INFO.TABLE_NAME, column, ids.TrimEnd(','));


            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }
        #endregion


        public void getdgAnimalStatus(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {

            string modelid = context.Request["modelid"] ?? "";
            string pn = context.Request["PN"] ?? "";
            
            if (sort == "")
            {
                sort = "Model_ID";
                order = "asc";
            }
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();
            BaseList dataModelInfo = new BaseList();
            DataTable dtAnimal = new DataTable();

            if (modelid != "")
            {
                SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Model_ID", modelid)
                    ,new SqlParameter("@PN", pn)    };
                DataTable data = ojbReportRule.GetGrid("GetAnimalStatus", para);//还没有respond的时候查询animal
                dtAnimal.Merge(data);


            }
            dtAll = dtAnimal;
            context.Session["dgAnimalStatus"] = null;

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
                dtAll = UtitityHelper.AddAutoIdColumn(dtAll);//add AutoId
                dtAll.DefaultView.Sort = sort + " " + order;
                dtAll = dtAll.DefaultView.ToTable();
              

                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);

                context.Session["dgAnimalStatus"] = dtAll;

                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
        }

        public void getdgSelectMice(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
           string model_ids= context.Request["model_ids"] ?? "";
           string hfRequest_id = context.Request["hfRequest_id"] ?? "";
           
            if (sort == "")
            {
                sort = "Model_ID";
                order = "asc";
            }
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();
            BaseList dataModelInfo = new BaseList();
            DataTable dtAnimal = new DataTable();
          
            if (hfRequest_id != "")
            {
                dataModelInfo = bll.Select(queryRespondModels(context, hfRequest_id), typeof(RESPOND_MODELS));
                foreach (RESPOND_MODELS row in dataModelInfo)
                {
                    if (row.PN == "")
                    {
                        SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Model_ID", row.MODEL_ID)
                        };
                        DataTable data = ojbReportRule.GetGrid("GetRespondAnimal_noResponded", para);//还没有respond的时候查询animal
                        dtAnimal.Merge(data);
                    }
                    else {
                        SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Model_ID", row.MODEL_ID)
                        ,new SqlParameter("@PN", row.PN)
                        ,new SqlParameter("@RN", row.RN)};
                        DataTable data = ojbReportRule.GetGrid("GetRespondAnimal", para);//已经respond的时候查询animal
                        dtAnimal.Merge(data);
                    }
                }
            }
            dtAll = dtAnimal;
            context.Session["dgSelectMice"] = null;

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
                dtAll = UtitityHelper.AddAutoIdColumn(dtAll);//add AutoId
                dtAll.DefaultView.Sort = sort + " " + order;
                dtAll = dtAll.DefaultView.ToTable();
              

                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                
                context.Session["dgSelectMice"] = dtAll;

                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }

        }

        #region 查询Animalinfo
        private ParamCollection queryAnimal(HttpContext context, string mid)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = ANIMAL_INFO.MODEL_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} = '{2}' )", ANIMAL_INFO.TABLE_NAME, column, mid);
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }
        #endregion

        public void getdgModelInfo(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
           
            DataTable dt = new DataTable();
            DataTable joindt  = new DataTable();
            DataTable dtAll = new DataTable();
            BaseList dataModelInfo = bll.Select(queryPDXmodelinfo(context), typeof(PDXMODEL_INFO));

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
                else if (dc.ColumnName == "MODEL_FROM")
                {
                    dc.ColumnName = "Model_From";
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
                else if (dc.ColumnName == "PATIENT_ID")
                {
                    dc.ColumnName = "Patient_ID";
                }
            }
          
            #endregion
            if (joindt.Rows.Count > 0 && modelstatus.Rows.Count > 0)
            {
                dtAll = DataJoin.Join(joindt, modelstatus, "Model_ID", "MODEL_ID", 1, true, false);//join modelstatus
            }
           
            context.Session["dgModelInfo"] = null;

            if (dtAll.Rows.Count > 0)
            {
                dtAll.Columns[dtAll.Columns.Count - 1].SetOrdinal(12); //列交换位置,含ID列
               
                if (sort == "")
                {
                    dtAll.DefaultView.Sort = "Sq_Number asc";
                }
                else
                {
                    if (sort == "Time_of_Revival" || sort == "Time_of_Model_for_Transplant")
                    {
                        dtAll.Columns.Add("sortColumn",typeof(Int32));
                        foreach (DataRow dr in dtAll.Rows)
                        {
                            if (dr[sort].ToString() != "" && dr[sort].ToString() != "NT")
                            {
                                try
                                {
                                    string sortColumn = "";
                                    if (sort == "Time_of_Revival")
                                    {
                                        if (Regex.Matches(dr[sort].ToString(), "/").Count == 2)
                                        {
                                            sortColumn = dr[sort].ToString().Substring(0, dr[sort].ToString().IndexOf('/'));
                                        }
                                        else
                                        {
                                            sortColumn = dr[sort].ToString().Substring(0, dr[sort].ToString().IndexOf('('));
                                        }
                                    }
                                    else {
                                        if (dr[sort].ToString().IndexOf('/') == -1)
                                        {
                                            sortColumn = dr[sort].ToString().Substring(0, dr[sort].ToString().IndexOf('('));
                                        }
                                        else
                                        {
                                            sortColumn = dr[sort].ToString().Substring(0, dr[sort].ToString().IndexOf('/'));
                                        }
                                    }
                                    dr["sortColumn"] = int.Parse(sortColumn.Trim());
                                }
                                catch (Exception ex)
                                {

                                }
                               
                            }
                            else {
                                dr["sortColumn"] = 0;
                            }
                        }
                        dtAll.DefaultView.Sort = "sortColumn asc";
                        dtAll.DefaultView.RowFilter = "sortColumn <> '0'";
                    }
                    else {
                        dtAll.DefaultView.Sort = sort + " asc";
                        dtAll.DefaultView.RowFilter = sort + " <> '0'";
                    }
                }
                string cbxModelstatus = "";
                if (context.Request["cbxModelstatus"] != "")
                {
                    cbxModelstatus = context.Request["cbxModelstatus"].ToString();
                    dtAll.DefaultView.RowFilter = "Model_Status = '" + cbxModelstatus + "'";
                }
                dtAll = dtAll.DefaultView.ToTable();
                dtAll.Columns.Remove("CRYO_P");
                dtAll.Columns.Remove("SNAP_FROZEN");
                dtAll.Columns.Remove("FFPE1");

                //SYS_USER userLogin = CacheHelper.getCurrentUser();
                //if (!ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin"))
                //{
                //    dtAll.Columns.Remove("Source");
                //}
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);

                context.Session["dgModelInfo"] = dtAll;

                string dd = ConvertDTToJsonAuto(dt, dtAll.Rows.Count.ToString(), "PDXmodelInfo");
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{\"data\":[{ \"total\":0,\"rows\":[ ]}]}");
            }

        }


        public void getdgAnimalInfo_NewModel(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            if (sort == "")
            {
                sort = "MODEL_ID";
                order = "asc";
            }
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();

            dtAll = ojbReportRule.GetgridAnimalInfo();

            DataView dv = dtAll.DefaultView;

            if (context.Request["id"] != null)
            {
                if (context.Request["id"].ToString() != "")
                {
                    if (context.Request["id"].ToString() != "-1")
                    {
                        string[] study = context.Request["id"].ToString().Split('-');
                        string modelid = study[0];
                        string rn = study[1].Substring(0, study[1].IndexOf("P"));
                        string pn = study[1].Replace(rn, "");
                        dv.RowFilter = "MODEL_ID = '" + modelid + "' and Rn = '" + rn + "' and Pn = '" + pn + "'";
                        dtAll = dv.ToTable();
                    }
                    else {
                        dtAll = new DataTable();
                    }
                }
            }
            

           
            context.Session["dgAnimalInfo_NewModel"] = null;

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
                dtAll.Columns["Estimated_DOT"].SetOrdinal(dtAll.Columns.Count - 4);//换位置

                if (sort == "TV" || sort == "Body_Weight")
                {
                    dtAll.Columns.Add("sortColumn", typeof(Double));
                    foreach (DataRow dr in dtAll.Rows)
                    {
                        if (dr[sort].ToString() != "")
                        {
                            string sortColumn = dr[sort].ToString();
                            dr["sortColumn"] = double.Parse(sortColumn);
                        }
                        else
                        {
                            dr["sortColumn"] = 0;
                        }
                    }
                    dtAll.DefaultView.Sort = "sortColumn asc";
                    //dtAll.DefaultView.RowFilter = "sortColumn <> '0'";
                }
                else
                {
                    dtAll.DefaultView.Sort = sort + " asc";
                    //dtAll.DefaultView.RowFilter = sort + " <> '0'";
                }

              
                dtAll = dtAll.DefaultView.ToTable();
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                if (sort == "TV" || sort == "Body_Weight")
                {
                    dt.Columns.Remove("sortColumn");
                }
                context.Session["dgAnimalInfo_NewModel"] = dtAll;

                string dd = ConvertDTToJsonAuto(dt, dtAll.Rows.Count.ToString(), "AnimalInfo");
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{\"data\":[{ \"total\":0,\"rows\":[ ]}]}");
            }

        }

        public void getdgAnimalInfo_RoutineMaintain(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            if (sort == "")
            {
                sort = "MODEL_ID";
                order = "asc";
            }
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();

            dtAll = ojbReportRule.GetgridAnimalInfo();

            DataView dv = dtAll.DefaultView;

            if (context.Request["id"] != null)
            {
                if (context.Request["id"].ToString() != "")
                {
                    if (context.Request["id"].ToString() != "-1")
                    {
                        string[] study = context.Request["id"].ToString().Split('-');
                        string modelid = study[0];
                        string rn = study[1].Substring(0, study[1].IndexOf("P"));
                        string pn = study[1].Replace(rn, "");
                        dv.RowFilter = "MODEL_ID = '" + modelid + "' and Rn = '" + rn + "' and Pn = '" + pn + "'";
                        dtAll = dv.ToTable();
                    }
                    else
                    {
                        dtAll = new DataTable();
                    }
                }
            }



            context.Session["dgAnimalInfo_RoutineMaintain"] = null;

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
                dtAll.Columns["Estimated_DOT"].SetOrdinal(dtAll.Columns.Count - 4);//换位置

                if (sort == "TV" || sort == "Body_Weight")
                {
                    dtAll.Columns.Add("sortColumn", typeof(Double));
                    foreach (DataRow dr in dtAll.Rows)
                    {
                        if (dr[sort].ToString() != "")
                        {
                            string sortColumn = dr[sort].ToString();
                            dr["sortColumn"] = double.Parse(sortColumn);
                        }
                        else
                        {
                            dr["sortColumn"] = 0;
                        }
                    }
                    dtAll.DefaultView.Sort = "sortColumn asc";
                    //dtAll.DefaultView.RowFilter = "sortColumn <> '0'";
                }
                else
                {
                    dtAll.DefaultView.Sort = sort + " asc";
                    //dtAll.DefaultView.RowFilter = sort + " <> '0'";
                }


                dtAll = dtAll.DefaultView.ToTable();
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                if (sort == "TV" || sort == "Body_Weight")
                {
                    dt.Columns.Remove("sortColumn");
                }
                context.Session["dgAnimalInfo_RoutineMaintain"] = dtAll;

                string dd = ConvertDTToJsonAuto(dt, dtAll.Rows.Count.ToString(), "AnimalInfo");
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{\"data\":[{ \"total\":0,\"rows\":[ ]}]}");
            }

        }

        public void getdgAnimalInfo_Validation(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            if (sort == "")
            {
                sort = "MODEL_ID";
                order = "asc";
            }
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();

            dtAll = ojbReportRule.GetgridAnimalInfo();

            DataView dv = dtAll.DefaultView;

            if (context.Request["id"] != null)
            {
                if (context.Request["id"].ToString() != "")
                {
                    if (context.Request["id"].ToString() != "-1")
                    {
                        string[] study = context.Request["id"].ToString().Split('-');
                        string modelid = study[0];
                        string rn = study[1].Substring(0, study[1].IndexOf("P"));
                        string pn = study[1].Replace(rn, "");
                        dv.RowFilter = "MODEL_ID = '" + modelid + "' and Rn = '" + rn + "' and Pn = '" + pn + "'";
                        dtAll = dv.ToTable();
                    }
                    else
                    {
                        dtAll = new DataTable();
                    }
                }
            }



            context.Session["dgAnimalInfo_Validation"] = null;

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
                dtAll.Columns["Estimated_DOT"].SetOrdinal(dtAll.Columns.Count - 4);//换位置

                if (sort == "TV" || sort == "Body_Weight")
                {
                    dtAll.Columns.Add("sortColumn", typeof(Double));
                    foreach (DataRow dr in dtAll.Rows)
                    {
                        if (dr[sort].ToString() != "")
                        {
                            string sortColumn = dr[sort].ToString();
                            dr["sortColumn"] = double.Parse(sortColumn);
                        }
                        else
                        {
                            dr["sortColumn"] = 0;
                        }
                    }
                    dtAll.DefaultView.Sort = "sortColumn asc";
                    //dtAll.DefaultView.RowFilter = "sortColumn <> '0'";
                }
                else
                {
                    dtAll.DefaultView.Sort = sort + " asc";
                    //dtAll.DefaultView.RowFilter = sort + " <> '0'";
                }


                dtAll = dtAll.DefaultView.ToTable();
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                if (sort == "TV" || sort == "Body_Weight")
                {
                    dt.Columns.Remove("sortColumn");
                }
                context.Session["dgAnimalInfo_Validation"] = dtAll;

                string dd = ConvertDTToJsonAuto(dt, dtAll.Rows.Count.ToString(), "AnimalInfo");
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{\"data\":[{ \"total\":0,\"rows\":[ ]}]}");
            }

        }
        public void getdgAnimalInfo(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            if (sort == "")
            {
                sort = "MODEL_ID";
                order = "asc";
            }
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();

            dtAll = ojbReportRule.GetgridAnimalInfo();

            DataView dv = dtAll.DefaultView;

            if (context.Request["modelid"] != null)
            {
                if (context.Request["modelid"].ToString() != "")
                {
                    dv.RowFilter = "MODEL_ID like '" + context.Request["modelid"].ToString() + "%'";
                    dtAll = dv.ToTable();
                }
            }
            string[] searchAlive = { };
            searchAlive = context.Request["searchAlive"].Split(',');
            string ids = "";
            if (searchAlive[0] == "")//未选择或者全选
            {
            }
            else
            {
                foreach (string id in searchAlive)
                {
                    ids += "'" + id + "',";
                }
                dv.RowFilter = string.Format("Mortality_Observation in ({0}) ",  ids.TrimEnd(','));
                dtAll = dv.ToTable();
            }

            //dtAll.Columns.RemoveAt(0);
            context.Session["dgAnimalInfo"] = null;

            if (dtAll.Rows.Count > 0)
            {

                #region 计算Estimated_DOT
                List<PDXMODEL_INFO> pdxmodels = bll.Select(typeof(PDXMODEL_INFO)).ConvertAll<PDXMODEL_INFO>(PDXMODEL_INFO.Convert);

                dtAll.Columns.Add("Estimated_DOT");
                foreach (DataRow dr in dtAll.Rows)
                {
                    string dot = "";
                    int kk = 0;
                    if (dr["model_id"].ToString().Contains("9493") && dr["Animal_Number"].ToString()=="34516")
                    { 
                    
                    }
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
                dtAll.Columns["Estimated_DOT"].SetOrdinal(dtAll.Columns.Count - 4);//换位置

                if (sort == "TV" || sort == "Body_Weight")
                {
                    dtAll.Columns.Add("sortColumn", typeof(Double));
                    foreach (DataRow dr in dtAll.Rows)
                    {
                        if (dr[sort].ToString() != "")
                        {
                            string sortColumn = dr[sort].ToString();
                            dr["sortColumn"] = double.Parse(sortColumn);
                        }
                        else
                        {
                            dr["sortColumn"] = 0;
                        }
                    }
                    dtAll.DefaultView.Sort = "sortColumn asc";
                    //dtAll.DefaultView.RowFilter = "sortColumn <> '0'";
                }
                else
                {
                    dtAll.DefaultView.Sort = sort + " asc";
                    //dtAll.DefaultView.RowFilter = sort + " <> '0'";
                }
                dtAll = dtAll.DefaultView.ToTable();
                if (sort == "TV" || sort == "Body_Weight")
                {
                    dtAll.Columns.Remove("sortColumn");
                }
                dtAll.Columns.Remove("Current_Project_Number");
                dtAll.Columns["Ongoing_Project"].ColumnName = "Current_Project_Number";
              
               
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                
                context.Session["dgAnimalInfo"] = dtAll;

                string dd = ConvertDTToJsonAuto(dt, dtAll.Rows.Count.ToString(), "AnimalInfo");
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{\"data\":[{ \"total\":0,\"rows\":[ ]}]}");
            }

        }

        public void gettbAnimalinfo_Logs(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            context.Session["tbAnimalinfo_Logs"] = null;
            string aid = context.Request["aid"] ?? "";
            string mid = context.Request["mid"] ?? "";
            if (aid != "")
            {
                ParamCollection paramlist = new ParamCollection();
                paramlist.Clause = ANIMAL_TREE.AID_FIELD + "='" + aid + "'";
                BaseList data = bll.Select(paramlist, typeof(ANIMAL_TREE));
                StringBuilder sb = new StringBuilder();
                if (data.Count > 0)
                {
                    ANIMAL_TREE row = (ANIMAL_TREE)data[0];
                    ParamCollection pl = new ParamCollection();
                    pl.Clause = ANIMAL_INFO_LOGS.MODEL_ID_FIELD + "='" + row.MODEL_ID + "'";
                    pl.Clause += " and " + ANIMAL_INFO_LOGS.RN_FIELD + "='R" + row.RN + "'";
                    pl.Clause += " and " + ANIMAL_INFO_LOGS.PN_FIELD + "='P" + row.PN + "'";
                    pl.Clause += " and " + ANIMAL_INFO_LOGS.LOCATION_OF_LIVE_ANIMAL_FIELD + "='" + row.LOCATION + "'";

                    BaseList data2 = bll.Select(pl, typeof(ANIMAL_INFO_LOGS));
                    if (data2.Count > 0)
                    {
                        //ANIMAL_INFO_LOGS row2 = (ANIMAL_INFO_LOGS)data2[0];
                        //sb.Append("<tr>" + row2.MODEL_ID + "</tr>");
                        //sb.Append("<tr>" + row2.RN + "</tr>");
                        //sb.Append("<tr>" + row2.PN + "</tr>");
                        //sb.Append("<tr>" + row2.LOCATION_OF_LIVE_ANIMAL + "</tr>");
                        //sb.Append("<tr>" + row2.ANIMAL_ROOM_NUMBER + "</tr>");
                        //sb.Append("<tr>" + row2.IVC_LOCATION + "</tr>");
                        //sb.Append("<tr>" + row2.ANIMAL_NUMBER + "</tr>");
                        //sb.Append("<tr>" + row2.BODY_WEIGHT + "</tr>");
                        //sb.Append("<tr>" + row2.TVLB + "</tr>");
                        //sb.Append("<tr>" + row2.TVLF + "</tr>");
                        //sb.Append("<tr>" + row2.TVRF + "</tr>");
                        //sb.Append("<tr>" + row2.TVRB + "</tr>");
                        //sb.Append("<tr>" + row2.TV_AVG + "</tr>");
                        //sb.Append("<tr>" + row2.TUMOR_NUMBER + "</tr>");
                        //sb.Append("<tr>" + row2.DATE_OF_UPDATE + "</tr>");
                        //sb.Append("<tr>" + row2.DURATION + "</tr>");

                        DataTable dtAll = UtitityHelper.ToDataTable(data2);
                        context.Session["tbAnimalinfo_Logs"] = dtAll;

                        DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                        string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                        context.Response.Write(dd);
                    }
                    else
                    {
                        context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
                    }
                }

                else
                {
                    context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
                }
            }
            if (aid == "" && mid != "")
            {
                string S_DOI_from = context.Request["S_DOI_from"] ?? "";
                string S_DOI_to = context.Request["S_DOI_to"] ?? "";
                string S_Date_of_update_from = context.Request["S_Date_of_update_from"] ?? "";
                string S_Date_of_update_to = context.Request["S_Date_of_update_to"] ?? "";
                string S_Mortality_Observation = context.Request["S_Mortality_Observation"] ?? "";
                ParamCollection pl = new ParamCollection();
                pl.Clause = "1=1";
                //Add by Jack 2026.04.02
                //if (S_Mortality_Observation != "")
                //{
                //    pl.Clause = ANIMAL_INFO_LOGS.MORTALITY_OBSERVATION_FIELD + "='" + S_Mortality_Observation + "'";
                //}
                //else
                //{
                //    pl.Clause = ANIMAL_INFO_LOGS.MODEL_ID_FIELD + "='" + mid + "'";
                //}
                if (S_Mortality_Observation == "")
                {
                    pl.Clause = ANIMAL_INFO_LOGS.MODEL_ID_FIELD + "='" + mid + "'";
                }
                else
                {
                    if (S_Mortality_Observation != "All") {
                        pl.Clause = ANIMAL_INFO_LOGS.MORTALITY_OBSERVATION_FIELD + "='" + S_Mortality_Observation + "'";
                    }
                }
                if (S_DOI_from != "" && S_DOI_to != "")
                {
                    pl.Clause += " and (DOI between '" + S_DOI_from + "' and '" + S_DOI_to + "')";
                }
                if (S_Date_of_update_from != "" && S_Date_of_update_to != "")
                {
                    pl.Clause += " and (Date_of_update between '" + S_Date_of_update_from + "' and '" + S_Date_of_update_to + "')";
                }
                BaseList data2 = bll.Select(pl, typeof(ANIMAL_INFO_LOGS));
                if (data2.Count > 0)
                {
                    DataTable dtAll = UtitityHelper.ToDataTable(data2);
                    context.Session["tbAnimalinfo_Logs"] = dtAll;

                    DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                    string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                    context.Response.Write(dd);
                }
                else
                {
                    context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
                }

            }
        }

        public void getdgRespond(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            if (sort == "")
            {
                sort = "REQUEST_ID";
                order = "desc";
            }
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();
            DataTable joindt = new DataTable();

            BaseList dataRequest = bll.Select(queryRequest(context), typeof(REQUEST));
            joindt = UtitityHelper.ToDataTable(dataRequest);
            DataTable joindt2 = ojbRuleHuData.getModifyLogCount();

            if (joindt.Rows.Count > 0)
            {
                dtAll = DataJoin.Join(joindt, joindt2, "REQUEST_ID", "REQUEST_ID", 1, true, false);//join 
            }
           
            context.Session["dgRespond"] = null;

            if (dtAll.Rows.Count > 0)
            {
                dtAll.DefaultView.Sort = sort + " " + order;
                dtAll = dtAll.DefaultView.ToTable();
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);

                context.Session["dgRespond"] = dtAll;

                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }

        }

        public void getdgProjectBooking(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            if (sort == "")
            {
                sort = "Date_Of_Booking";
                order = "desc";
            }
  
            string txtAnimalBooking = "";
            string txtFurtherExpanding = "";
            string txtRevive = "";
            string searchModelID = "";
            string searchBD = "";
            string searchSD = "";
            string txtPN = "";
            string txtAnimal_Number = "";
            if (context.Request["txtAnimalBooking"] != null)
            {
                txtAnimalBooking = context.Request["txtAnimalBooking"].ToString() ?? "";
            }
            if (context.Request["txtFurtherExpanding"] != null)
            {
                txtFurtherExpanding = context.Request["txtFurtherExpanding"].ToString() ?? "";
            }
            if (context.Request["txtRevive"] != null)
            {
                txtRevive = context.Request["txtRevive"].ToString() ?? "";
            }
            if (context.Request["searchModelID"] != null)
            {
                searchModelID = context.Request["searchModelID"].ToString() ?? "";
            }
            if (context.Request["searchBD"] != null)
            {
                searchBD = context.Request["searchBD"].ToString() ?? "";
            }
            if (context.Request["searchSD"] != null)
            {
                searchSD = context.Request["searchSD"].ToString() ?? "";
            }
            if (context.Request["txtPN"] != null)
            {
                txtPN = context.Request["txtPN"].ToString() ?? "";
            }
            if (context.Request["txtAnimal_Number"] != null)
            {
                txtAnimal_Number = context.Request["txtAnimal_Number"].ToString() ?? "";
            }
            //dtAll = ojbRuleHuData.getProjectBooking(txtAnimalBooking, txtFurtherExpanding, txtRevive, searchModelID, searchBD, searchSD, txtPN, txtAnimal_Number);

            SqlParameter[] para = new SqlParameter[] {    new SqlParameter("@txtAnimalBooking",txtAnimalBooking),
                  new SqlParameter("@txtFurtherExpanding",txtFurtherExpanding),
                   new SqlParameter("@txtRevive",txtRevive),
                    new SqlParameter("@searchModelID",searchModelID),
                      new SqlParameter("@searchBD",searchBD),
                        new SqlParameter("@searchSD",searchSD),
                          new SqlParameter("@txtPN",txtPN),
                             new SqlParameter("@txtAnimal_Number",txtAnimal_Number)
                , new SqlParameter("@pageSize", pageSize)
                ,new SqlParameter("@CurrentPageIndex", CurrentPageIndex)};

            DataTable dtAll = ojbReportRule.GetGrid("getProjectBooking_Total",
                new SqlParameter[] {    new SqlParameter("@txtAnimalBooking",txtAnimalBooking),
                  new SqlParameter("@txtFurtherExpanding",txtFurtherExpanding),
                   new SqlParameter("@txtRevive",txtRevive),
                    new SqlParameter("@searchModelID",searchModelID),
                      new SqlParameter("@searchBD",searchBD),
                        new SqlParameter("@searchSD",searchSD),
                          new SqlParameter("@txtPN",txtPN),
                             new SqlParameter("@txtAnimal_Number",txtAnimal_Number) });
            if (int.Parse(dtAll.Rows[0][0].ToString()) > 0)
            {
                DataTable dt = ojbReportRule.GetGrid("getProjectBooking", para);
                var list = new { total = dtAll.Rows[0][0].ToString(), rows = dt };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
            else
            {
                var list = new { total = 0, rows = new List<object>() };
                context.Response.Write(JsonConvert.SerializeObject(list));
            }

        }

        public void getdgRequest(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            if (sort == "")
            {
                sort = "REQUEST_ID";
                order = "desc";
            }
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();
             DataTable joindt = new DataTable();
       
            BaseList dataRequest = bll.Select(queryRequest(context), typeof(REQUEST));
            joindt = UtitityHelper.ToDataTable(dataRequest);
            DataTable joindt2 = ojbRuleHuData.getModifyLogCount();

            if (joindt.Rows.Count > 0)
            {
                dtAll = DataJoin.Join(joindt, joindt2, "REQUEST_ID", "REQUEST_ID", 1, true, false);//join 
            }
            


            context.Session["dgRequest"] = null;
            if (dtAll.Rows.Count > 0)
            {
                dtAll.DefaultView.Sort = sort + " " + order;
                dtAll = dtAll.DefaultView.ToTable();
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);

                context.Session["dgRequest"] = dtAll;

                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }

        }


        public void getdgRequest_Completed(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            if (sort == "")
            {
                sort = "REQUEST_ID";
                order = "desc";
            }
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();
            DataTable joindt = new DataTable();

            BaseList dataRequest = bll.Select(queryRequest_Completed(context), typeof(REQUEST));
          
            joindt = UtitityHelper.ToDataTable(dataRequest);
            DataTable joindt2 = ojbRuleHuData.getModifyLogCount();

            if (joindt.Rows.Count > 0)
            {
                dtAll = DataJoin.Join(joindt, joindt2, "REQUEST_ID", "REQUEST_ID", 1, true, false);//join 
            }



            context.Session["dgRequest_Completed"] = null;
            context.Session["dgProjectMonitor"] = null;
            if (dtAll.Rows.Count > 0)
            {
                dtAll.DefaultView.Sort = sort + " " + order;
                dtAll = dtAll.DefaultView.ToTable();
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);

                context.Session["dgRequest_Completed"] = dtAll;

                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }

        }
        

        public void getdgRequest2(HttpContext context, int pageSize, int CurrentPageIndex, string sort, string order)
        {
            if (sort == "")
            {
                sort = "REQUEST_ID";
                order = "desc";
            }
            DataTable dt = new DataTable();
            DataTable dtAll = new DataTable();
            DataTable joindt = new DataTable();

            BaseList dataRequest = bll.Select(queryRequest2(context), typeof(REQUEST));
          
            joindt = UtitityHelper.ToDataTable(dataRequest);
            DataTable joindt2 = ojbRuleHuData.getModifyLogCount();

            if (joindt.Rows.Count > 0)
            {
                dtAll = DataJoin.Join(joindt, joindt2, "REQUEST_ID", "REQUEST_ID", 1, true, false);//join 
            }



            context.Session["dgRequest"] = null;
            context.Session["dgSelectMice2"] = null;
            if (dtAll.Rows.Count > 0)
            {
                dtAll.DefaultView.Sort = sort + " " + order;
                dtAll = dtAll.DefaultView.ToTable();
                dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);

                context.Session["dgRequest"] = dtAll;

                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }

        }
        private ParamCollection queryModifydata(string rid)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = REQUEST_LOG.REQUEST_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} = '{2}' )", REQUEST_LOG.TABLE_NAME, column, rid);
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection queryRequest_Completed(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            //if (CacheHelper.getCurrentUser().DEPARTMENT == "SD")
            //{
            //    column = REQUEST.REQUESTER_ID_FIELD;
            //    Clause += string.Format("AND ({0}.{1} = '{2}')", REQUEST.TABLE_NAME, column, CacheHelper.getCurrentUser().USER_ID);
            //}
            if (context.Request["searchSponsor"] != null)
            {
                if (context.Request["searchSponsor"].ToString() != "")
                {
                    column = REQUEST.CLIENT_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchSponsor"].ToString() + "%");
                }
            }
            if (context.Request["searchAXcode"] != null)
            {
                if (context.Request["searchAXcode"].ToString() != "")
                {
                    column = SPONSOR_AX_CODE.AX_CODE_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", SPONSOR_AX_CODE.TABLE_NAME, column, "%" + context.Request["searchAXcode"].ToString() + "%");
                }
            }
            if (context.Request["searchProjectNumber"] != null)
            {
                if (context.Request["searchProjectNumber"].ToString() != "")
                {
                    column = REQUEST.PROJECT_NUMBER_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchProjectNumber"].ToString() + "%");
                }
            }
            if (context.Request["searchBD"] != null)
            {
                if (context.Request["searchBD"].ToString() != "")
                {
                    column = REQUEST.BD_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchBD"].ToString() + "%");
                }
            }
            if (context.Request["searchSD"] != null)
            {
                if (context.Request["searchSD"].ToString() != "")
                {
                    column = REQUEST.SD_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchSD"].ToString() + "%");
                }
            }
            if (context.Request["searchPM"] != null)
            {
                if (context.Request["searchPM"].ToString() != "")
                {
                    column = REQUEST.PM_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchPM"].ToString() + "%");
                }
            }
            if (context.Request["searchModelID"] != null)
            {
                if (context.Request["searchModelID"].ToString() != "")
                {
                    column = REQUEST.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchModelID"].ToString() + "%");
                }
            }

            if (context.Request["searchSigned"] != null)
            {
                if (context.Request["searchSigned"].ToString() == "Signed")
                {
                    column = REQUEST.SIGNED_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", REQUEST.TABLE_NAME, column, context.Request["searchSigned"].ToString());
                }
                else if (context.Request["searchSigned"].ToString() == "All")
                {
                    //所有情况
                }
                else
                {
                    column = REQUEST.SIGNED_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", REQUEST.TABLE_NAME, column, context.Request["searchSigned"].ToString());
                    //Clause += string.Format("AND ({0}.{1} > '{2}')", REQUEST.TABLE_NAME, REQUEST.DATE_REQUEST_FIELD, DateTime.Now.AddYears(-1));
                }
            }
            else
            {
                Clause += string.Format("AND ({0}.{1} > '{2}')", REQUEST.TABLE_NAME, REQUEST.DATE_REQUEST_FIELD, DateTime.Now.AddYears(-1));
            }
            Clause += "AND ((REQUEST_ID in (select max(REQUEST_ID) as REQUEST_ID from PROJECT_MONITOR where Completion_Proportions_Per_Project ='100' group by REQUEST_ID) ) or SIGNED = 'Cancelled') ";
            Clause += "AND REQUEST.Isdelete <> 'Y' ";
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }



        private ParamCollection queryRequest2(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            //if (CacheHelper.getCurrentUser().DEPARTMENT == "SD")
            //{
            //    column = REQUEST.REQUESTER_ID_FIELD;
            //    Clause += string.Format("AND ({0}.{1} = '{2}')", REQUEST.TABLE_NAME, column, CacheHelper.getCurrentUser().USER_ID);
            //}
            if (context.Request["searchRequestID"] != null)
            {
                if (context.Request["searchRequestID"].ToString() != "")
                {
                    column = REQUEST.REQUEST_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", REQUEST.TABLE_NAME, column, context.Request["searchRequestID"].ToString());
                }
            }
            if (context.Request["searchSponsor"] != null)
            {
                if (context.Request["searchSponsor"].ToString() != "")
                {
                    column = REQUEST.CLIENT_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchSponsor"].ToString() + "%");
                }
            }
            if (context.Request["searchAXcode"] != null)
            {
                if (context.Request["searchAXcode"].ToString() != "")
                {
                    column = SPONSOR_AX_CODE.AX_CODE_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", SPONSOR_AX_CODE.TABLE_NAME, column, "%" + context.Request["searchAXcode"].ToString() + "%");
                }
            }
            if (context.Request["searchProjectNumber"] != null)
            {
                if (context.Request["searchProjectNumber"].ToString() != "")
                {
                    column = REQUEST.PROJECT_NUMBER_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchProjectNumber"].ToString() + "%");
                }
            }
            if (context.Request["searchBD"] != null)
            {
                if (context.Request["searchBD"].ToString() != "")
                {
                    column = REQUEST.BD_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchBD"].ToString() + "%");
                }
            }
            if (context.Request["searchSD"] != null)
            {
                if (context.Request["searchSD"].ToString() != "")
                {
                    column = REQUEST.SD_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchSD"].ToString() + "%");
                }
            }
            if (context.Request["searchPM"] != null)
            {
                if (context.Request["searchPM"].ToString() != "")
                {
                    column = REQUEST.PM_FIELD;
                    Clause += string.Format("AND ({0}.{1} LIKE '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchPM"].ToString() + "%");
                }
            }
            if (context.Request["searchModelID"] != null)
            {
                if (context.Request["searchModelID"].ToString() != "")
                {
                    column = REQUEST.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchModelID"].ToString() + "%");
                }
            }
           
            if (context.Request["searchSigned"] != null)
            {
                if (context.Request["searchSigned"].ToString() == "Signed")
                {
                    column = REQUEST.SIGNED_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", REQUEST.TABLE_NAME, column, context.Request["searchSigned"].ToString());
                }
                else if (context.Request["searchSigned"].ToString() == "All")
                {
                    //所有情况
                }
                else
                {
                    column = REQUEST.SIGNED_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", REQUEST.TABLE_NAME, column, context.Request["searchSigned"].ToString());
                    //Clause += string.Format("AND ({0}.{1} > '{2}')", REQUEST.TABLE_NAME, REQUEST.DATE_REQUEST_FIELD, DateTime.Now.AddYears(-1));
                }
            }
            else {
                Clause += string.Format("AND ({0}.{1} > '{2}')", REQUEST.TABLE_NAME, REQUEST.DATE_REQUEST_FIELD, DateTime.Now.AddYears(-1));
            }
            Clause += "AND REQUEST_ID not in (select max(REQUEST_ID) as REQUEST_ID from PROJECT_MONITOR where Completion_Proportions_Per_Project ='100' group by REQUEST_ID) ";
            Clause += "AND REQUEST.Isdelete <> 'Y' ";
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }
        private ParamCollection queryRequest(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            if (CacheHelper.getCurrentUser().DEPARTMENT == "SD")
            {
                column = REQUEST.REQUESTER_ID_FIELD;
                Clause += string.Format("AND ({0}.{1} = '{2}')", REQUEST.TABLE_NAME, column, CacheHelper.getCurrentUser().USER_ID);
            }

            if (context.Request["searchCancertype"] != null)
            {
                if (context.Request["searchCancertype"].ToString() != "")
                {
                    column = REQUEST.TUMOR_TYPE_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchCancertype"].ToString() + "%");
                }
            }
            if (context.Request["searchSubtype"] != null)
            {
                //if (context.Request["searchSubtype"].ToString() == "")
                //{

                //}
                //else
                //{
                //    column = REQUEST.SUBTYPE_FIELD;
                //    Clause += string.Format("AND ({0}.{1} like '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchSubtype"].ToString().Trim() + "%");
                //}
            }
            if (context.Request["is_responded"] != null)
            {
                string is_responded = context.Request["is_responded"].ToString();
                if (is_responded == "Have responded")
                {
                    column = REQUEST.RESPONDER_FIELD;
                    Clause += string.Format("AND ({0}.{1} <> '' )", REQUEST.TABLE_NAME, column);
                }
                else if (is_responded == "Not responded")
                {
                    column = REQUEST.RESPONDER_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '' )", REQUEST.TABLE_NAME, column);
                }
            }
            if (context.Request["modelid"] != null)
            {
                if (context.Request["modelid"].ToString() != "")
                {
                    column = REQUEST.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["modelid"].ToString() + "%");
                }
            }
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection queryRespond(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
           

            if (context.Request["modelid"] != null)
            {
                if (context.Request["modelid"].ToString() != "")
                {
                    column = REQUEST.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", REQUEST.TABLE_NAME, column, context.Request["modelid"].ToString());
                }
            }
            if (context.Request["is_responded"] != null)
            {
                string is_responded = context.Request["is_responded"].ToString();
                if (is_responded == "Have responded")
                {
                    column = REQUEST.RESPONDER_FIELD;
                    Clause += string.Format("AND ({0}.{1} <> '' )", REQUEST.TABLE_NAME, column);
                }
                else if (is_responded == "Not responded")
                {
                    column = REQUEST.RESPONDER_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '' )", REQUEST.TABLE_NAME, column);
                }
            }
            
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection QueryCollectionMutation_Validated(string name)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = MUTATION.SAMPLE_NAME_FIELD;
            Clause += string.Format("({0}.{1} = '{2}')", MUTATION.TABLE_NAME, column, name);
            paraList.Clause = Clause;
            return paraList;
        }



        private ParamCollection queryStudy(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            if (context.Request["hfMonitor_id"] != null)
            {
                if (context.Request["hfMonitor_id"].ToString() != "")
                {
                    column = PROJECT_MONITOR_STUDY_DESIGN.PROJECT_MONITOR_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", PROJECT_MONITOR_STUDY_DESIGN.TABLE_NAME, column, context.Request["hfMonitor_id"].ToString());
                }
            }
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection queryTissueStock(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["model_id"] != null)
            {
                if (context.Request["model_id"].ToString() != "")
                {
                    string mids = "";
                    foreach (string mid in context.Request["model_id"].ToString().Split(','))
                    {
                        mids += " model_id like '%" + mid + "%' or";
                    }
                    Clause += "AND (" + mids.TrimEnd('r').TrimEnd('o') + ")";
                }
            }
           
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            bool havePerm0 = ojbReportRule.GetUserFunctions(userLogin.Permission, "SpecimenStocks", "view");
            if (!havePerm0)
            {
                bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "SpecimenStocks", "CBSD view only");
                if (havePerm)
                {
                    column = SPECIMEN_STOCK.REGION_FIELD;
                    Clause += string.Format("AND ({0}.{1} = 'CBSD')", SPECIMEN_STOCK.TABLE_NAME, column);
                }
                else {
                    bool havePerm2 = ojbReportRule.GetUserFunctions(userLogin.Permission, "SpecimenStocks", "CBSG view only");
                    if (havePerm2)
                    {
                        column = SPECIMEN_STOCK.REGION_FIELD;
                        Clause += string.Format("AND ({0}.{1} = 'CBSG')", SPECIMEN_STOCK.TABLE_NAME, column);
                    }
                    else {
                        bool havePerm3 = ojbReportRule.GetUserFunctions(userLogin.Permission, "SpecimenStocks", "CBNC view only");
                        if (havePerm3)
                        {
                            column = SPECIMEN_STOCK.REGION_FIELD;
                            Clause += string.Format("AND ({0}.{1} = 'CBNC')", SPECIMEN_STOCK.TABLE_NAME, column);
                        }
                    }
                }
            }
            
            if (context.Request["S_Region"] != null)
            {
                if (context.Request["S_Region"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.REGION_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, "%" + context.Request["S_Region"].ToString() + "%");
                }
            }
            if (context.Request["S_PojectNo"] != null)
            {
                if (context.Request["S_PojectNo"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.IMPORT_PROJECT_NUMBER_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, "%" + context.Request["S_PojectNo"].ToString() + "%");
                }
            }
            if (context.Request["S_Well_ID"] != null)
            {
                if (context.Request["S_Well_ID"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.WELL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, "%" + context.Request["S_Well_ID"].ToString() + "%");
                }
            }
            if (context.Request["S_Location_ID"] != null)
            {
                if (context.Request["S_Location_ID"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.LOCATION_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, "%" + context.Request["S_Location_ID"].ToString() + "%");
                }
            }
            if (context.Request["S_Site_of_Tissue_Collection"] != null)
            {
                if (context.Request["S_Site_of_Tissue_Collection"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.SITE_OF_TISSUE_COLLECTION_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, "%" + context.Request["S_Site_of_Tissue_Collection"].ToString() + "%");
                }
            }
            if (context.Request["S_Preserve_Method"] != null)
            {
                if (context.Request["S_Preserve_Method"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.PRESERVE_METHOD_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, "%" + context.Request["S_Preserve_Method"].ToString() + "%");
                }
            }
            if (context.Request["S_Date_of_Tissue_Collection"] != null)
            {
                if (context.Request["S_Date_of_Tissue_Collection"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.DATE_OF_TISSUE_COLLECTION_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, context.Request["S_Date_of_Tissue_Collection"].ToString());
                }
            }
            if (context.Request["S_Animal_Number"] != null)
            {
                if (context.Request["S_Animal_Number"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.ANIMAL_NUMBER_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, context.Request["S_Animal_Number"].ToString());
                }
            }
            if (context.Request["S_Pn"] != null)
            {
                if (context.Request["S_Pn"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.PN_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, context.Request["S_Pn"].ToString());
                }
            }
            if (context.Request["S_Tissue_Type"] != null)
            {
                if (context.Request["S_Tissue_Type"].ToString() != "")
                {
                    column = SPECIMEN_STOCK.TISSUE_TYPE_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", SPECIMEN_STOCK.TABLE_NAME, column, context.Request["S_Tissue_Type"].ToString() + "%");
                }
            }
            paraList.Clause = Clause;
            return paraList;
        }


        private ParamCollection queryMuPrime(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["S_MuPrimename"] != null)
            {
                if (context.Request["S_MuPrimename"].ToString() != "")
                {
                    column = PDXMODEL_INFO.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '%{2}%')", PDXMODEL_INFO.TABLE_NAME, column, context.Request["S_MuPrimename"].ToString());
                }
            }
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            if (!ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin"))
            {
                column = PDXMODEL_INFO.MODEL_CATEGORY_FIELD;
                Clause += string.Format("AND ({0}.{1} not like '%{2}%')", PDXMODEL_INFO.TABLE_NAME, column, "Failed");

                Clause += string.Format("AND ({0}.{1} not like '%{2}%')", PDXMODEL_INFO.TABLE_NAME, column, "Identical as other model");
            }
            Clause += " AND " + PDXMODEL_INFO.DATA_TYPE_FIELD + " ='Mouse' ";

            paraList.Clause = Clause;
            return paraList;
        }
        private ParamCollection query_dgNewModel(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["model_id"] != null)
            {
                if (context.Request["model_id"].ToString() != "")
                {
                    column = NEWMODEL.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", NEWMODEL.TABLE_NAME, column, "%" + context.Request["model_id"].ToString() + "%");
                }
            }
            if (context.Request["S_Model_Type"] != null)
            {
                if (context.Request["S_Model_Type"].ToString() != "")
                {
                    column = NEWMODEL.MODEL_TYPE_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", NEWMODEL.TABLE_NAME, column, "%" + context.Request["S_Model_Type"].ToString() + "%");
                }
            }
            if (context.Request["S_Subtype1"] != null)
            {
                if (context.Request["S_Subtype1"].ToString() != "")
                {
                    column = NEWMODEL.SUBTYPE1_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", NEWMODEL.TABLE_NAME, column, "%" + context.Request["S_Subtype1"].ToString() + "%");
                }
            }
            if (context.Request["S_Subtype2"] != null)
            {
                if (context.Request["S_Subtype2"].ToString() != "")
                {
                    column = NEWMODEL.SUBTYPE2_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", NEWMODEL.TABLE_NAME, column, "%" + context.Request["S_Subtype2"].ToString() + "%");
                }
            }
            if (context.Request["S_Project"] != null)
            {
                if (context.Request["S_Project"].ToString() != "")
                {
                    column = NEWMODEL.PROJECT_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", NEWMODEL.TABLE_NAME, column, "%" + context.Request["S_Project"].ToString() + "%");
                }
            }
            if (context.Request["S_Location"] != null)
            {
                if (context.Request["S_Location"].ToString() != "")
                {
                    column = NEWMODEL.LOCATION_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", NEWMODEL.TABLE_NAME, column, "%" + context.Request["S_Location"].ToString() + "%");
                }
            }
            if (context.Request["S_Rn"] != null)
            {
                if (context.Request["S_Rn"].ToString() != "")
                {
                    column = NEWMODEL.RN_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", NEWMODEL.TABLE_NAME, column, "%" + context.Request["S_Rn"].ToString() + "%");
                }
            }
            if (context.Request["S_Pn"] != null)
            {
                if (context.Request["S_Pn"].ToString() != "")
                {
                    column = NEWMODEL.PN_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", NEWMODEL.TABLE_NAME, column, "%" + context.Request["S_Pn"].ToString() + "%");
                }
            }
            if (context.Request["S_Date_of_Passage_inoculation"] != null)
            {
                if (context.Request["S_Date_of_Passage_inoculation"].ToString() != "")
                {
                    column = NEWMODEL.DATE_OF_PASSAGE_INOCULATION_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", NEWMODEL.TABLE_NAME, column, context.Request["S_Date_of_Passage_inoculation"].ToString());
                }
            }
            if (context.Request["S_Current_Animal_Ear_Tag"] != null)
            {
                if (context.Request["S_Current_Animal_Ear_Tag"].ToString() != "")
                {
                    column = NEWMODEL.CURRENT_ANIMAL_EAR_TAG_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", NEWMODEL.TABLE_NAME, column, "%" + context.Request["S_Current_Animal_Ear_Tag"].ToString() + "%");
                }
            }
            //Clause +=" and  ([Date_of_Passage_Termination] = '0001-01-01' or  [Date_of_Passage_Termination] is null )";
            
            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection query_dgRevival(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["S_ModelID"] != null)
            {
                if (context.Request["S_ModelID"].ToString() != "")
                {
                    column = REVIVAL.MODELID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", REVIVAL.TABLE_NAME, column, "%" + context.Request["S_ModelID"].ToString() + "%");
                }
            }
            if (context.Request["S_Sq"] != null)
            {
                if (context.Request["S_Sq"].ToString() != "")
                {
                    column = REVIVAL.SQ_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", REVIVAL.TABLE_NAME, column, "%" + context.Request["S_Sq"].ToString() + "%");
                }
            }
            if (context.Request["S_Location"] != null)
            {
                if (context.Request["S_Location"].ToString() != "")
                {
                    column = REVIVAL.LOCATION_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", REVIVAL.TABLE_NAME, column, context.Request["S_Location"].ToString());
                }
            }
            if (context.Request["s_Rn"] != null)
            {
                if (context.Request["s_Rn"].ToString() != "")
                {
                    column = REVIVAL.RN_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", REVIVAL.TABLE_NAME, column, context.Request["s_Rn"].ToString());
                }
            }
            if (context.Request["s_Pn"] != null)
            {
                if (context.Request["s_Pn"].ToString() != "")
                {
                    column = REVIVAL.PN_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", REVIVAL.TABLE_NAME, column, context.Request["s_Pn"].ToString());
                }
            }
            if (context.Request["s_Animal_Strain"] != null)
            {
                if (context.Request["s_Animal_Strain"].ToString() != "All")
                {
                    column = REVIVAL.ANIMAL_STRAIN_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", REVIVAL.TABLE_NAME, column, context.Request["s_Animal_Strain"].ToString());
                }
            }
            if (context.Request["s_Outcome"] != null)
            {
                if (context.Request["s_Outcome"].ToString() != "All")
                {
                    column = REVIVAL.OUTCOME_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", REVIVAL.TABLE_NAME, column, context.Request["s_Outcome"].ToString());
                }
            }
            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection query_dgGeneticTest(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["S_ModelID"] != null)
            {
                if (context.Request["S_ModelID"].ToString() != "")
                {
                    column = GENETICTEST.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", GENETICTEST.TABLE_NAME, column, "%" + context.Request["S_ModelID"].ToString() + "%");
                }
            }
            if (context.Request["S_Sq"] != null)
            {
                if (context.Request["S_Sq"].ToString() != "")
                {
                    column = GENETICTEST.SQ_NUMBER_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", GENETICTEST.TABLE_NAME, column, "%" + context.Request["S_Sq"].ToString() + "%");
                }
            }
            if (context.Request["s_Source"] != null)
            {
                if (context.Request["s_Source"].ToString() != "")
                {
                    column = GENETICTEST.SOURCE_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", GENETICTEST.TABLE_NAME, column, context.Request["S_Location"].ToString());
                }
            }
            if (context.Request["s_RNAseq"] != null)
            {
                if (context.Request["s_RNAseq"].ToString() != "")
                {
                    column = GENETICTEST.RNASEQ_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", GENETICTEST.TABLE_NAME, column, context.Request["s_RNAseq"].ToString());
                }
            }
            if (context.Request["s_WES"] != null)
            {
                if (context.Request["s_WES"].ToString() != "")
                {
                    column = GENETICTEST.WES_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", GENETICTEST.TABLE_NAME, column, context.Request["s_WES"].ToString());
                }
            }
            if (context.Request["s_WGS"] != null)
            {
                if (context.Request["s_WGS"].ToString() != "")
                {
                    column = GENETICTEST.WGS_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", GENETICTEST.TABLE_NAME, column, context.Request["s_WGS"].ToString());
                }
            }
            paraList.Clause = Clause;
            return paraList;
        }


        private ParamCollection query_dgValidationStatus_Huprime(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["S_ModelID"] != null)
            {
                if (context.Request["S_ModelID"].ToString() != "")
                {
                    column = VALIDATIONSTATUS_HUPRIME.MODELID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATIONSTATUS_HUPRIME.TABLE_NAME, column, "%" + context.Request["S_ModelID"].ToString() + "%");
                }
            }
            if (context.Request["S_Sq"] != null)
            {
                if (context.Request["S_Sq"].ToString() != "")
                {
                    column = VALIDATIONSTATUS_HUPRIME.SQ_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATIONSTATUS_HUPRIME.TABLE_NAME, column, "%" + context.Request["S_Sq"].ToString() + "%");
                }
            }
            if (context.Request["S_Established_Location"] != null)
            {
                if (context.Request["S_Established_Location"].ToString() != "")
                {
                    column = VALIDATIONSTATUS_HUPRIME.ESTABLISHED_LOCATION_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATIONSTATUS_HUPRIME.TABLE_NAME, column, "%" + context.Request["S_Established_Location"].ToString() + "%");
                }
            }

            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection query_dgValidationStatus_Hukime(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["S_ModelID"] != null)
            {
                if (context.Request["S_ModelID"].ToString() != "")
                {
                    column = VALIDATIONSTATUS_HUKIME.MODELID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATIONSTATUS_HUKIME.TABLE_NAME, column, "%" + context.Request["S_ModelID"].ToString() + "%");
                }
            }
            if (context.Request["S_Sq"] != null)
            {
                if (context.Request["S_Sq"].ToString() != "")
                {
                    column = VALIDATIONSTATUS_HUKIME.SQ_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATIONSTATUS_HUKIME.TABLE_NAME, column, "%" + context.Request["S_Sq"].ToString() + "%");
                }
            }


            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection query_dgEndModels(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["S_Animal"] != null)
            {
                if (context.Request["S_Animal"].ToString() != "")
                {
                    column = ENDMODELS.ANIMAL_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ENDMODELS.TABLE_NAME, column, "%" + context.Request["S_Animal"].ToString() + "%");
                }
            }
            if (context.Request["S_GroupName"] != null)
            {
                if (context.Request["S_GroupName"].ToString() != "")
                {
                    column = ENDMODELS.GROUP_NAME_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ENDMODELS.TABLE_NAME, column, "%" + context.Request["S_GroupName"].ToString() + "%");
                }
            }
            if (context.Request["S_Leader"] != null)
            {
                if (context.Request["S_Leader"].ToString() != "")
                {
                    column = ENDMODELS.LEADER_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ENDMODELS.TABLE_NAME, column, "%" + context.Request["S_Leader"].ToString() + "%");
                }
            }
            if (context.Request["S_Rn"] != null)
            {
                if (context.Request["S_Rn"].ToString() != "")
                {
                    column = ENDMODELS.RN_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ENDMODELS.TABLE_NAME, column, "%" + context.Request["S_Rn"].ToString() + "%");
                }
            }
            if (context.Request["S_Pn"] != null)
            {
                if (context.Request["S_Pn"].ToString() != "")
                {
                    column = ENDMODELS.PN_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ENDMODELS.TABLE_NAME, column, "%" + context.Request["S_Pn"].ToString() + "%");
                }
            }
            if (context.Request["S_Location"] != null)
            {
                if (context.Request["S_Location"].ToString() != "")
                {
                    column = ENDMODELS.LOCATION_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ENDMODELS.TABLE_NAME, column, "%" + context.Request["S_Location"].ToString() + "%");
                }
            }
            if (context.Request["S_IVC"] != null)
            {
                if (context.Request["S_IVC"].ToString() != "")
                {
                    column = ENDMODELS.IVC_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ENDMODELS.TABLE_NAME, column, "%" + context.Request["S_IVC"].ToString() + "%");
                }
            }
         
            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection query_dgValidation(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["model_id"] != null)
            {
                if (context.Request["model_id"].ToString() != "")
                {
                    column = VALIDATION.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATION.TABLE_NAME, column, "%" + context.Request["model_id"].ToString() + "%");
                }
            }
            if (context.Request["S_Model_Type"] != null)
            {
                if (context.Request["S_Model_Type"].ToString() != "")
                {
                    column = VALIDATION.MODEL_TYPE_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATION.TABLE_NAME, column, "%" + context.Request["S_Model_Type"].ToString() + "%");
                }
            }
            if (context.Request["S_Subtype1"] != null)
            {
                if (context.Request["S_Subtype1"].ToString() != "")
                {
                    column = VALIDATION.SUBTYPE1_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATION.TABLE_NAME, column, "%" + context.Request["S_Subtype1"].ToString() + "%");
                }
            }
            if (context.Request["S_Subtype2"] != null)
            {
                if (context.Request["S_Subtype2"].ToString() != "")
                {
                    column = VALIDATION.SUBTYPE2_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATION.TABLE_NAME, column, "%" + context.Request["S_Subtype2"].ToString() + "%");
                }
            }
            if (context.Request["S_Project"] != null)
            {
                if (context.Request["S_Project"].ToString() != "")
                {
                    column = VALIDATION.PROJECT_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATION.TABLE_NAME, column, "%" + context.Request["S_Project"].ToString() + "%");
                }
            }
            if (context.Request["S_Location"] != null)
            {
                if (context.Request["S_Location"].ToString() != "")
                {
                    column = VALIDATION.LOCATION_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATION.TABLE_NAME, column, "%" + context.Request["S_Location"].ToString() + "%");
                }
            }
            if (context.Request["S_Rn"] != null)
            {
                if (context.Request["S_Rn"].ToString() != "")
                {
                    column = VALIDATION.RN_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATION.TABLE_NAME, column, "%" + context.Request["S_Rn"].ToString() + "%");
                }
            }
            if (context.Request["S_Pn"] != null)
            {
                if (context.Request["S_Pn"].ToString() != "")
                {
                    column = VALIDATION.PN_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATION.TABLE_NAME, column, "%" + context.Request["S_Pn"].ToString() + "%");
                }
            }
            if (context.Request["S_Date_of_Passage_inoculation"] != null)
            {
                if (context.Request["S_Date_of_Passage_inoculation"].ToString() != "")
                {
                    column = VALIDATION.DATE_OF_PASSAGE_INOCULATION_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", VALIDATION.TABLE_NAME, column, context.Request["S_Date_of_Passage_inoculation"].ToString());
                }
            }
            if (context.Request["S_Current_Animal_Ear_Tag"] != null)
            {
                if (context.Request["S_Current_Animal_Ear_Tag"].ToString() != "")
                {
                    column = VALIDATION.CURRENT_ANIMAL_EAR_TAG_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", VALIDATION.TABLE_NAME, column, "%" + context.Request["S_Current_Animal_Ear_Tag"].ToString() + "%");
                }
            }
            //Clause += " and  ([Date_of_Passage_Termination] = '0001-01-01' or  [Date_of_Passage_Termination] is null )";
            paraList.Clause = Clause;
            return paraList;
        }
        private ParamCollection query_dgRoutineMaintain(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["model_id"] != null)
            {
                if (context.Request["model_id"].ToString() != "")
                {
                    column = ROUTINEMAINTAIN.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ROUTINEMAINTAIN.TABLE_NAME, column, "%" + context.Request["model_id"].ToString() + "%");
                }
            }
            if (context.Request["S_Model_Type"] != null)
            {
                if (context.Request["S_Model_Type"].ToString() != "")
                {
                    column = ROUTINEMAINTAIN.MODEL_TYPE_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ROUTINEMAINTAIN.TABLE_NAME, column, "%" + context.Request["S_Model_Type"].ToString() + "%");
                }
            }
            if (context.Request["S_Subtype1"] != null)
            {
                if (context.Request["S_Subtype1"].ToString() != "")
                {
                    column = ROUTINEMAINTAIN.SUBTYPE1_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ROUTINEMAINTAIN.TABLE_NAME, column, "%" + context.Request["S_Subtype1"].ToString() + "%");
                }
            }
            if (context.Request["S_Subtype2"] != null)
            {
                if (context.Request["S_Subtype2"].ToString() != "")
                {
                    column = ROUTINEMAINTAIN.SUBTYPE2_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ROUTINEMAINTAIN.TABLE_NAME, column, "%" + context.Request["S_Subtype2"].ToString() + "%");
                }
            }
            if (context.Request["S_Project"] != null)
            {
                if (context.Request["S_Project"].ToString() != "")
                {
                    column = ROUTINEMAINTAIN.PROJECT_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ROUTINEMAINTAIN.TABLE_NAME, column, "%" + context.Request["S_Project"].ToString() + "%");
                }
            }
            if (context.Request["S_Location"] != null)
            {
                if (context.Request["S_Location"].ToString() != "")
                {
                    column = ROUTINEMAINTAIN.LOCATION_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ROUTINEMAINTAIN.TABLE_NAME, column, "%" + context.Request["S_Location"].ToString() + "%");
                }
            }
            if (context.Request["S_Rn"] != null)
            {
                if (context.Request["S_Rn"].ToString() != "")
                {
                    column = ROUTINEMAINTAIN.RN_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ROUTINEMAINTAIN.TABLE_NAME, column, "%" + context.Request["S_Rn"].ToString() + "%");
                }
            }
            if (context.Request["S_Pn"] != null)
            {
                if (context.Request["S_Pn"].ToString() != "")
                {
                    column = ROUTINEMAINTAIN.PN_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ROUTINEMAINTAIN.TABLE_NAME, column, "%" + context.Request["S_Pn"].ToString() + "%");
                }
            }
            if (context.Request["S_Date_of_Passage_inoculation"] != null)
            {
                if (context.Request["S_Date_of_Passage_inoculation"].ToString() != "")
                {
                    column = ROUTINEMAINTAIN.DATE_OF_PASSAGE_INOCULATION_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", ROUTINEMAINTAIN.TABLE_NAME, column, context.Request["S_Date_of_Passage_inoculation"].ToString());
                }
            }
            if (context.Request["S_Current_Animal_Ear_Tag"] != null)
            {
                if (context.Request["S_Current_Animal_Ear_Tag"].ToString() != "")
                {
                    column = ROUTINEMAINTAIN.CURRENT_ANIMAL_EAR_TAG_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", ROUTINEMAINTAIN.TABLE_NAME, column, "%" + context.Request["S_Current_Animal_Ear_Tag"].ToString() + "%");
                }
            }
            //Clause += " and  ([Date_of_Passage_Termination] = '0001-01-01' or  [Date_of_Passage_Termination] is null )";
            paraList.Clause = Clause;
            return paraList;
        }
        private ParamCollection queryTissueWithdraw(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["model_id"] != null)
            {
                if (context.Request["model_id"].ToString() != "")
                {
                    column = TISSUE_WITHDRAW.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", TISSUE_WITHDRAW.TABLE_NAME, column, "%" + context.Request["model_id"].ToString() + "%");
                }
            }
            if (context.Request["searchProjectNumber"] != null)
            {
                if (context.Request["searchProjectNumber"].ToString() != "")
                {
                    column = TISSUE_WITHDRAW.WITHDRAW_PROJECT_NUMBER_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", TISSUE_WITHDRAW.TABLE_NAME, column, "%" + context.Request["searchProjectNumber"].ToString() + "%");
                }
            }
            if (context.Request["S_Date_of_Withdraw"] != null)
            {
                if (context.Request["S_Date_of_Withdraw"].ToString() != "")
                {
                    column = TISSUE_WITHDRAW.WITHDRAW_DATE_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", TISSUE_WITHDRAW.TABLE_NAME, column, context.Request["S_Date_of_Withdraw"].ToString());
                }
            }
            if (context.Request["S_Site_of_Tissue_Collection"] != null)
            {
                if (context.Request["S_Site_of_Tissue_Collection"].ToString() != "")
                {
                    column = TISSUE_WITHDRAW.SITE_OF_TISSUE_COLLECTION_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", TISSUE_WITHDRAW.TABLE_NAME, column, "%" + context.Request["S_Site_of_Tissue_Collection"].ToString() + "%");
                }
            }
            column = TISSUE_WITHDRAW.CONFIRM_FIELD;
            Clause += string.Format(" AND ({0}.{1} = 'No')", TISSUE_WITHDRAW.TABLE_NAME, column);

            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection queryTissueWithdraw_Completed(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["model_id"] != null)
            {
                if (context.Request["model_id"].ToString() != "")
                {
                    column = TISSUE_WITHDRAW.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", TISSUE_WITHDRAW.TABLE_NAME, column, "%" + context.Request["model_id"].ToString() + "%");
                }
            }
            if (context.Request["searchProjectNumber"] != null)
            {
                if (context.Request["searchProjectNumber"].ToString() != "")
                {
                    column = TISSUE_WITHDRAW.WITHDRAW_PROJECT_NUMBER_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", TISSUE_WITHDRAW.TABLE_NAME, column, "%" + context.Request["searchProjectNumber"].ToString() + "%");
                }
            }
            if (context.Request["S_Date_of_Withdraw2"] != null)
            {
                if (context.Request["S_Date_of_Withdraw2"].ToString() != "")
                {
                    column = TISSUE_WITHDRAW.WITHDRAW_DATE_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", TISSUE_WITHDRAW.TABLE_NAME, column,  context.Request["S_Date_of_Withdraw2"].ToString());
                }
            }
            if (context.Request["S_Site_of_Tissue_Collection2"] != null)
            {
                if (context.Request["S_Site_of_Tissue_Collection2"].ToString() != "")
                {
                    column = TISSUE_WITHDRAW.SITE_OF_TISSUE_COLLECTION_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", TISSUE_WITHDRAW.TABLE_NAME, column, "%" + context.Request["S_Site_of_Tissue_Collection2"].ToString() + "%");
                }
            }
            column = TISSUE_WITHDRAW.CONFIRM_FIELD;
            Clause += string.Format(" AND ({0}.{1} = 'Yes')", TISSUE_WITHDRAW.TABLE_NAME, column);

            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection queryMonitor(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["model_id"] != null)
            {
                if (context.Request["model_id"].ToString() != "")
                {
                    column = PROJECT_MONITOR.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", PROJECT_MONITOR.TABLE_NAME, column, context.Request["model_id"].ToString());
                }
            }
            if (context.Request["searchJSD"] != null)
            {
                if (context.Request["searchJSD"].ToString() != "")
                {
                    column = REQUEST.SD_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchJSD"].ToString() + "%");
                }
            }
          
            if (context.Request["searchProjectNumber"] != null)
            {
                if (context.Request["searchProjectNumber"].ToString() != "")
                {
                    column = PROJECT_MONITOR.PROJECT_NUMBER_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", PROJECT_MONITOR.TABLE_NAME, column, "%" + context.Request["searchProjectNumber"].ToString() + "%");
                }
            }
            if (context.Request["searchDOI"] != null)
            {
                if (context.Request["searchDOI"].ToString() != "")
                {
                    if (context.Request["searchDOI"].ToString() == "Yes")
                    {
                        column = PROJECT_MONITOR.INOCULATION_FIELD;
                        Clause += string.Format("AND ({0}.{1} <> '0001-01-01')", PROJECT_MONITOR.TABLE_NAME, column);
                    }
                    else {
                        column = PROJECT_MONITOR.INOCULATION_FIELD;
                        Clause += string.Format("AND ({0}.{1} = '0001-01-01')", PROJECT_MONITOR.TABLE_NAME, column);
                    }
                }
            }
            
            string isComplete = context.Request["searchCompleted"] ?? "";
            if (isComplete == "Yes")
            {
                Clause += string.Format("AND ({0}.{1} = '{2}')", PROJECT_MONITOR.TABLE_NAME, PROJECT_MONITOR.COMPLETE_STUDY_FIELD, "Yes");
            }
            else if (isComplete == "No" || isComplete == "")
            {
                Clause += string.Format("AND ({0}.{1} <> '{2}')", PROJECT_MONITOR.TABLE_NAME, PROJECT_MONITOR.COMPLETE_STUDY_FIELD, "Yes");
            }
            Clause += " and Request.signed <> 'Cancelled' and Request.signed <> 'Request only' and request.Isdelete <> 'Y'";
            Clause += " and Completion_Proportions_Per_Project <> '100' ";

            if (context.Request["searchPM"] != null)
            {
                if (context.Request["searchPM"].ToString() != "")
                {
                    Clause += " and Request.PM like '%" + context.Request["searchPM"].ToString() + "%'";
                }
            }

            //if (Clause.Length > 3)
            //{
            //    Clause = Clause.Substring(3, Clause.Length - 3);
            //}
            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection queryMonitor_Completed(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += " where 1 = 1 ";
            if (context.Request["model_id"] != null)
            {
                if (context.Request["model_id"].ToString() != "")
                {
                    column = PROJECT_MONITOR.MODEL_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", PROJECT_MONITOR.TABLE_NAME, column, context.Request["model_id"].ToString());
                }
            }
            if (context.Request["searchJSD"] != null)
            {
                if (context.Request["searchJSD"].ToString() != "")
                {
                    column = REQUEST.SD_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", REQUEST.TABLE_NAME, column, "%" + context.Request["searchJSD"].ToString() + "%");
                }
            }
            if (context.Request["searchProjectNumber"] != null)
            {
                if (context.Request["searchProjectNumber"].ToString() != "")
                {
                    column = PROJECT_MONITOR.PROJECT_NUMBER_FIELD;
                    Clause += string.Format("AND ({0}.{1} like '{2}')", PROJECT_MONITOR.TABLE_NAME, column, "%" + context.Request["searchProjectNumber"].ToString() + "%");
                }
            }
            if (context.Request["searchDOI"] != null)
            {
                if (context.Request["searchDOI"].ToString() != "")
                {
                    if (context.Request["searchDOI"].ToString() == "Yes")
                    {
                        column = PROJECT_MONITOR.INOCULATION_FIELD;
                        Clause += string.Format("AND ({0}.{1} <> '0001-01-01')", PROJECT_MONITOR.TABLE_NAME, column);
                    }
                    else {
                        column = PROJECT_MONITOR.INOCULATION_FIELD;
                        Clause += string.Format("AND ({0}.{1} = '0001-01-01')", PROJECT_MONITOR.TABLE_NAME, column);
                    }
                }
            }
          
            string isComplete = context.Request["searchCompleted"] ?? "";
            if (isComplete == "Yes")
            {
                Clause += string.Format("AND ({0}.{1} = '{2}')", PROJECT_MONITOR.TABLE_NAME, PROJECT_MONITOR.COMPLETE_STUDY_FIELD, "Yes");
            }
            else if (isComplete == "No" || isComplete == "")
            {
                Clause += string.Format("AND ({0}.{1} <> '{2}')", PROJECT_MONITOR.TABLE_NAME, PROJECT_MONITOR.COMPLETE_STUDY_FIELD, "Yes");
            }


            if (context.Request["request_id"] != null)
            {
                if (context.Request["request_id"].ToString() != "")
                {
                    column = PROJECT_MONITOR.REQUEST_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", PROJECT_MONITOR.TABLE_NAME, column, context.Request["request_id"].ToString());
                }
                else {
                    column = PROJECT_MONITOR.REQUEST_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '-1')", PROJECT_MONITOR.TABLE_NAME, column);
                }
            }
            else
            {
                column = PROJECT_MONITOR.REQUEST_ID_FIELD;
                Clause += string.Format("AND ({0}.{1} = '-1')", PROJECT_MONITOR.TABLE_NAME, column);
            }
            if (context.Request["searchPM2"] != null)
            {
                if (context.Request["searchPM2"].ToString() != "")
                {
                    Clause += " and Request.PM like '%" + context.Request["searchPM2"].ToString() + "%'";
                }
            }
            paraList.Clause = Clause;
            return paraList;
        }
        
        private ParamCollection queryPDXmodelinfo2(HttpContext context,string model_ids)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
         
                if (model_ids != "")
                {
                    string ids = "";
                    foreach (string a in model_ids.Split(','))
                    {
                        if (a != "")
                        {
                            ids += "'" + a + "',";
                        }
                    }
                    column = PDXMODEL_INFO.PDXMODEL_INFO_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} in ({2}) )", PDXMODEL_INFO.TABLE_NAME, column, ids.TrimEnd(','));
                }
            
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }
        private ParamCollection queryRespondModels(HttpContext context, string respond_models)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = RESPOND_MODELS.REQUEST_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} in ({2}) )", RESPOND_MODELS.TABLE_NAME, column, respond_models);
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }
        

        private ParamCollection queryPDXmodelinfo(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            Clause += "and (DATA_TYPE ='PDX' or data_type is null or data_type = '') ";

            if (context.Request["modelid"] != null)
            {
                if (context.Request["modelid"].ToString() != "")
                {
                    column = PDXMODEL_INFO.MODEL_ID_FIELD;
                    Clause += string.Format("AND ( ({0}.{1} like '{2}')", PDXMODEL_INFO.TABLE_NAME, column, "%" + context.Request["modelid"].ToString() + "%");
                    Clause += string.Format("or ({0}.{1} like '{2}') )", PDXMODEL_INFO.TABLE_NAME, PDXMODEL_INFO.SQ_NUMBER_FIELD, "%" + context.Request["modelid"].ToString() + "%");
                }
            }
            if (context.Request["Cancertype"] != null)
            {
                if (context.Request["Cancertype"].ToString() != "" && context.Request["Cancertype"].ToString() != " ")
                {
                    column = PDXMODEL_INFO.CANCER_TYPE_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", PDXMODEL_INFO.TABLE_NAME, column, context.Request["Cancertype"].ToString());
                }
            }
            if (context.Request["searchSubtype1"] != null)
            {
                string[] subtype = { };
                subtype = context.Request["searchSubtype1"].Split(',');
                string ids = "";
                if (subtype[0] == "")//为选择或者全选
                {
                }
                else
                {
                    foreach (string id in subtype)
                    {
                        ids += "'" + id + "',";
                    }
                    column = PDXMODEL_INFO.SUBTYPE1_FIELD;
                    Clause += string.Format("AND ({0}.{1} in ({2}) )", PDXMODEL_INFO.TABLE_NAME, column, ids.TrimEnd(','));
                }
            }
            if (context.Request["searchSubtype2"] != null)
            {
                string[] subtype = { };
                subtype = context.Request["searchSubtype2"].Split(',');
                string ids = "";
                if (subtype[0] == "")//为选择或者全选
                {
                }
                else
                {
                    foreach (string id in subtype)
                    {
                        ids += "'" + id + "',";
                    }
                    column = PDXMODEL_INFO.SUBTYPE2_FIELD;
                    Clause += string.Format("AND ({0}.{1} in ({2}) )", PDXMODEL_INFO.TABLE_NAME, column, ids.TrimEnd(','));
                }
            }
            if (context.Request["cbxModel_Category"] != null)
            {
                SYS_USER userLogin = CacheHelper.getCurrentUser();
                string[] cbxModel_Category = { };
                if (context.Request["cbxModel_Category"] == "")//未选择
                {
                    if (!ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID,"Admin"))
                    {
                        column = PDXMODEL_INFO.MODEL_CATEGORY_FIELD;
                        Clause += string.Format("AND ({0}.{1} not like '%{2}%')", PDXMODEL_INFO.TABLE_NAME, column, "Failed");

                        Clause += string.Format("AND ({0}.{1} not like '%{2}%')", PDXMODEL_INFO.TABLE_NAME, column, "Identical as other model");
                    }
                }
                else
                {
                    cbxModel_Category = context.Request["cbxModel_Category"].Split(',');
                    string ids = "";
                    foreach (string id in cbxModel_Category)
                    {
                        ids += "'" + id + "',";
                    }
                    column = PDXMODEL_INFO.MODEL_CATEGORY_FIELD;
                    Clause += string.Format("AND ({0}.{1} in ({2}) )", PDXMODEL_INFO.TABLE_NAME, column, ids.TrimEnd(','));
                    if (!ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID,"Admin"))
                    {
                        Clause += string.Format(" AND ({0}.{1} not like '%{2}%')", PDXMODEL_INFO.TABLE_NAME, column, "Failed");
                    }
                }
            }
            //if (context.Request["cbx_isbooked"] != null)
            //{
            //    string cbx_isbooked = context.Request["cbx_isbooked"].ToString() == "checked" ? "Y" : "N";
            //    if (cbx_isbooked == "Y")
            //    {
            //        Clause += string.Format("AND Model_ID in (select PDXMODEL_INFO_ID from [PROJECT_BOOKING])");
            //    }
            //}
            if (context.Request["cbxSource"] != "")
            {
                string cbxSource = context.Request["cbxSource"].ToString();
                Clause += "AND Source =" + "'" + cbxSource + "'";
            }
           
            if (context.Request["cbxPatient"] != "")
            {
                string cbxPatient = context.Request["cbxPatient"].ToString();
                Clause += "AND Source_ID =" + "'" + cbxPatient + "'";
            }
            if (context.Request["cbxSource_Note"] != "")
            {
                string cbxSource_Note = context.Request["cbxSource_Note"].ToString();
                Clause += "AND Source_Note =" + "'" + cbxSource_Note + "'";
            }
            
            if (context.Request["cbxPDX_QC"] != "")
            {
                string cbxPDX_QC = context.Request["cbxPDX_QC"].ToString();
                Clause += "AND PDX_QC =" + "'" + cbxPDX_QC + "'";
            }
            
            if (context.Request["cbxSTR_Consistence"] != "")
            {
                string cbxSTR_Consistence = context.Request["cbxSTR_Consistence"].ToString();
                Clause += "AND STR_Consistence =" + "'" + cbxSTR_Consistence + "'";
            }
            if (context.Request["cbxDosing_Window"] != "")
            {
                string cbxDosing_Window = context.Request["cbxDosing_Window"].ToString();
                Clause += "AND Dosing_Window =" + "'" + cbxDosing_Window + "'";

            }
            if (context.Request["searchUlceration_Label"] != "")
            {
                string searchUlceration_Label = context.Request["searchUlceration_Label"].ToString();
                Clause += "AND Ulceration_Label =" + "'" + searchUlceration_Label + "'";

            }
           
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection querybooking(HttpContext context)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";

            if (context.Request["key"] != null)
            {
                if (context.Request["key"].ToString() != "")
                {
                   // column = PROJECT_BOOKING.PDXMODEL_INFO_ID_FIELD;
                    Clause += string.Format("AND ({0}.{1} = '{2}')", PROJECT_BOOKING.TABLE_NAME, column, context.Request["key"].ToString());
                }
            }
           
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private ParamCollection queryAdSearch(HttpContext context, string str)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";

            Clause += " where 1 = 1 ";
            Clause += str;

            SYS_USER userLogin = CacheHelper.getCurrentUser();
            if (!ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin"))
            {
                string column = PDXMODEL_INFO.MODEL_CATEGORY_FIELD;
                Clause += string.Format("AND ({0}.{1} not like '%{2}%')", PDXMODEL_INFO.TABLE_NAME, column, "Failed");

                Clause += string.Format("AND ({0}.{1} not like '%{2}%')", PDXMODEL_INFO.TABLE_NAME, column, "Identical as other model");
            }
            paraList.Clause = Clause;
            return paraList;

        }
        public void ajaxGetColumns(HttpContext context)
        {
            string tablename = context.Request["tablename"].ToString();
            StringBuilder JsonString = new StringBuilder();
            JsonString.Append("{\"columns\":\"");
            JsonString.Append(CreateColumn_AutoDisplayColumns(tablename));
            JsonString.Append("\"}");
            context.Response.Write(JsonString.ToString());
        }

        protected string CreateColumn_AutoDisplayColumns(string tbname)
        {
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            ParamCollection paralist = new ParamCollection();
            paralist.Clause = USERSELECTCOLUMNS.SELECTTABLENAME_FIELD + " ='" + tbname + "'";
            paralist.Clause += " and " + USERSELECTCOLUMNS.USER_ID_FIELD + "='" + userLogin.USER_ID + "'";
            BaseList data = bll.Select(paralist, typeof(USERSELECTCOLUMNS));
            StringBuilder columns = new StringBuilder("[[");
            if (data.Count > 0)
            {
                int width = 0;
                USERSELECTCOLUMNS row = (USERSELECTCOLUMNS)data[0];
                foreach (string node in row.DISPLAYCOLUMNS.Split(','))
                {
                    string col = node.Replace("\\n", "");
                    if (col == "Model_From" && tbname == "MuPrime" && !ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin"))
                    {
                        continue;
                    }
                    if (col == "FBS" || col == "PM" || col == "BD" || col == "Client")
                    {
                        width = 150;
                    }
                    else
                    {
                        width = col.Length * 10;
                    }
                    columns.AppendFormat("{{field:'{0}',title:'{1}',align:'left',width:{2}}},", col, col, width);
                }
                if (columns.Length > 3)
                {
                    columns.Remove(columns.Length - 1, 1);//去除多余的','号
                }
            }
            else
            {
                ParamCollection paralist2 = new ParamCollection();
                paralist2.Clause = TABLEDISPLAYCOLUMNS.TABLENAME_FIELD + " ='" + tbname + "'";
                BaseList data2 = bll.Select(paralist2, typeof(TABLEDISPLAYCOLUMNS));
                if (data2.Count > 0)
                {
                    int width = 0;
                    TABLEDISPLAYCOLUMNS row = (TABLEDISPLAYCOLUMNS)data2[0];
                    foreach (string node in row.TABLECOLUMNS.Split(','))
                    {
                        string col = node.Replace("\\n", "");
                        if (col == "Model_From" && tbname == "MuPrime" && !ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin"))
                        {
                            continue;
                        }
                        width = col.Length * 10;
                        columns.AppendFormat("{{field:'{0}',title:'{1}',align:'left',width:{2}}},", col, col, width);
                    }
                    if (columns.Length > 3)
                    {
                        columns.Remove(columns.Length - 1, 1);//去除多余的','号
                    }
                }
            }
            columns.Append("]]");
            return columns.ToString();

        }

        public string ConvertDTToJsonAuto(DataTable dt, string count,string tablename)
        {
            //方法一：自动生成列
            #region
            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{ ");
                //列
                JsonString.Append("\"columns\":\"");
                if (tablename == "PDXmodelInfo")
                {
                    JsonString.Append(CreateDataGridColumnModel(dt));
                }
                else if(tablename == "AnimalInfo")
                {
                    JsonString.Append(CreateColumn_AnimalInfo(dt));
                }
                JsonString.Append("\",\"data\":[{");
                //值
                JsonString.Append("\"total\":" + count + ",");//作为传给前台的total域，放置一共多少条数据   
                JsonString.Append("\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]}]}");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
            #endregion
        }

        /// <summary>
        /// 从dataTable创建 jquery easyui datagrid格式的columns参数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected string CreateDataGridColumnModel(DataTable dt)
        {
            SYS_USER userLogin = CacheHelper.getCurrentUser();

            StringBuilder columns = new StringBuilder("[[");
            int width = 0;
            foreach (DataColumn col in dt.Columns)
            {

                bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "PDXModelInfo-show", col.ColumnName);
                if (havePerm)
                {
                    if (!ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin") && col.ColumnName == "Model_From")
                    {
                        continue;
                    }
                    //控制列的宽度 第一列日期宽度为139,其余列为列名的汉字长度*20px
                    if (col.ColumnName == "日期")
                    {
                        width = 139;
                    }
                    else if (col.ColumnName == "Subtype1" || col.ColumnName == "Subtype2" || col.ColumnName == "SOC")
                    {
                        width = 150;
                    }
                    else
                    {
                        width = col.ColumnName.Length * 15;
                    }
                   
                    //if (col.ColumnName == "Cachexia_Label")
                    //{
                    //    col.ColumnName = "Cachexia Label";
                    //}
                   
                    columns.AppendFormat("{{field:'{0}',title:'{1}',align:'left',width:{2}}},", col.ColumnName, col.ColumnName, width);
                }
            }
            if (columns.Length > 3)
            {
                columns.Remove(columns.Length - 1, 1);//去除多余的','号
            }
            columns.Append("]]");
            return columns.ToString();
        }
        //protected string CreateDataGridTableModel(DataTable dt)
        //{
          //  SYS_USER userLogin = CacheHelper.getCurrentUser();
          //  foreach (DataColumn col in dt.Columns)
          //      for(int i=dt.Columns.Count;i>0;i--)
          //  {
          //      BaseList Pdata = ojbReportRule.GetUserFunctions(userLogin.USER_ID.ToString(), "ModelColumn", col.ColumnName);
          //      if (Pdata.Count > 0)
          //      {
          //          columns.AppendFormat("{{field:'{0}',title:'{1}',align:'left',width:{2}}},", col.ColumnName, col.ColumnName, width);
          //      }
          //  }
          //dt.Columns.Remove(
        //}

        protected string CreateColumn_AnimalInfo(DataTable dt)
        {
            //SYS_USER userLogin = CacheHelper.getCurrentUser();
          
            StringBuilder columns = new StringBuilder("[[");
            int width = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == "DOI" || col.ColumnName == "Subtype2" || col.ColumnName == "Subtype1")
                {
                    width = col.ColumnName.Length * 30;
                }
                else if (col.ColumnName == "TV")
                {
                    width = col.ColumnName.Length * 30;
                }  
                else
                {
                    width = col.ColumnName.Length * 10;
                }
                columns.AppendFormat("{{field:'{0}',title:'{1}',align:'left',width:{2}}},", col.ColumnName, col.ColumnName, width);

            }
            if (columns.Length > 3)
            {
                columns.Remove(columns.Length - 1, 1);//去除多余的','号
            }
            columns.Append("]]");
            return columns.ToString();
        }
        
       

        public string ConvertDTToJson(DataTable dt, string count)
        {
            //方法二
            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{ ");

                //值
                JsonString.Append("\"total\":" + count + ",");//作为传给前台的total域，放置一共多少条数据   
                JsonString.Append("\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]}");
                return JsonString.ToString();
            }
            else
            {
                JsonString.Append("{ ");
                JsonString.Append("\"total\":" + count + ",");//作为传给前台的total域，放置一共多少条数据   
                JsonString.Append("\"rows\":[ ");
                JsonString.Append("]}");
                return JsonString.ToString();
            }

        }

    
  
    }
}