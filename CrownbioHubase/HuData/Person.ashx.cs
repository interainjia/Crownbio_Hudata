using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Crownbio.BLL;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Collections;
using System.IO;
using Crownbio.Common;
using Crownbio.Model;
using System.Web.SessionState;
using Crownbio.Utility;
using System.Text;
using Org.BouncyCastle.Utilities.Collections;
using Crownbio.BLL.Rule;
using System.Web.Http.Results;
using Newtonsoft.Json;

namespace PDXmodelBase.HuData
{
    /// <summary>
    /// GetCelllineType 的摘要说明
    /// </summary>
    public class Person : IHttpHandler, IRequiresSessionState
    {
        ObjectBLL bll = new ObjectBLL();
        private DataTable typedata = new DataTable();
        public void ProcessRequest(HttpContext context)
        {
                context.Response.ClearHeaders();
                context.Response.AppendHeader("Access-Control-Allow-Headers", "Content-Type,Content-Length, Authorization, Accept,X-Requested-With");
                context.Response.AppendHeader("Access-Control-Allow-Methods", "PUT,POST,GET,DELETE,OPTIONS");
           
            context.Response.ContentType = "text/plain";
            string Method = context.Request.Params["M"];
            switch (Method)
            {
                //case "getPerson":
                //    getPerson(context);
                //    break;

                #region PDXmodel
                case "getCancertype":
                    getCancertype(context);
                    break;

                case "getddlSOC":
                    getddlSOC(context);
                    break;
                case "SavePDXmodel":
                    SavePDXmodel(context);
                    break;
                #endregion

                #region Animal info
                case "getsearchAlive":
                    getsearchAlive(context);
                    break;
                #endregion

                #region model tree
                case "Remove_ModelTree_Node":
                    Remove_ModelTree_Node(context);
                    break;
                #endregion

                case "getccBD":
                    getccBD(context);
                    break;
                case "getccPM":
                    getccPM(context);
                    break;

                case "getccLeading_SD":
                    getccLeading_SD(context);
                    break;
                case "getccSD":
                    getccSD(context);
                    break;


                case "getWorkloadPerson":
                    getWorkloadPerson(context);
                    break;

                #region Project Monitor
                case "getMonitorSD":
                    getMonitorSD(context);
                    break;
                case "getMonitorJSD":
                    getMonitorJSD(context);
                    break;
                case "getMonitorDTgroup":
                    getMonitorDTgroup(context);
                    break;
                case "getddlDT":
                    getddlDT(context);
                    break;
                case "getMonitorDM":
                    getMonitorDM(context);
                    break;
                #endregion


                #region MyRegion
                case "getSponsor":
                    getSponsor(context);
                    break;
                #endregion


                case "getSubtype-combobox":
                    getSubtypecombobox(context);
                    break;
                case "getSubtype2-combobox":
                    getSubtype2combobox(context);
                    break;
                case "getSubtype":
                    getSubtype(context);
                    break;
                case "getSubtype2":
                    getSubtype2(context);
                    break;

                case "cbxModel_Category-combotree":
                    cbxModel_Category_combotree(context);
                    break;

                case "CheckRequest":
                    CheckRequest(context);
                    break;
                case "SaveRequest":
                    SaveRequest(context);
                    break;
                case "SaveRequest2":
                    SaveRequest2(context);
                    break;

                case "CheckRespond":
                    CheckRespond(context);
                    break;
                case "SaveRespond":
                    SaveRespond(context);
                    break;
                case "SavePorjectbooking":
                    SavePorjectbooking(context);
                    break;
                case "ModifyRequest":
                    ModifyRequest(context);
                    break;
                case "SaveBooking":
                    SaveBooking(context);
                    break;
                case "SaveEditRequest":
                    SaveEditRequest(context);
                    break;
                case "SavePM_Edit":
                    SavePM_Edit(context);
                    break;

                #region Project Monitor
                case "SaveMonitor":
                    SaveMonitor(context);
                    break;
                case "SaveMonitorAdd":
                    SaveMonitorAdd(context);
                    break;
                case "SaveMonitorPM_edit":
                    SaveMonitorPM_edit(context);
                    break;
                case "Complete_study":
                    Complete_study(context);
                    break;
                case "SaveAnimal_Handover":
                    SaveAnimal_Handover(context);
                    break;

                case "SaveMonitorJSD_edit":
                    SaveMonitorJSD_edit(context);
                    break;

                case "SaveStudy":
                    SaveStudy(context);
                    break;
                case "deleteStudy":
                    deleteStudy(context);
                    break;

                case "DeleteMonitor":
                    DeleteMonitor(context);
                    break;
                case "MoveToStudyDesign":
                    MoveToStudyDesign(context);
                    break;
                #endregion



           
                case "deleteRequest":
                    deleteRequest(context);
                    break;
                case "ConvertMid":
                    ConvertMid(context);
                    break;
                case "MoveToSubproject":
                    MoveToSubproject(context);
                    break;

                case "getRoleUserName":
                    getRoleUserName(context);
                    break;

                case "SavePiggybacked":
                    SavePiggybacked(context);
                    break;
                case "getDDLtxtSource":
                    getDDLtxtSource(context);
                    break;
                case "SavePharmacology_Effect":
                    SavePharmacology_Effect(context);
                    break;


                #region Tissue Bank
                case "CopyLocations":
                    CopyLocations(context);
                    break;
                case "SaveLocations_Name":
                    SaveLocations_Name(context);
                    break;
                case "Remove_Locations":
                    Remove_Locations(context);
                    break;
                case "edit_Locations":
                    edit_Locations(context);
                    break;
                case "btnSaveLocation":
                    btnSaveLocation(context);
                    break;
                case "SaveTissueStock":
                    SaveTissueStock(context);
                    break;
                case "SaveWithdraw":
                    SaveWithdraw(context);
                    break;

                case "SetMaps_location":
                    SetMaps_location(context);
                    break;
                case "GotoWithDraw":
                    GotoWithDraw(context);
                    break;
                case "ConfirmWithDraw":
                    ConfirmWithDraw(context);
                    break;
                case "CancelWithDraw":
                    CancelWithDraw(context);
                    break;
                case "Save_SpecimenStocks":
                    Save_SpecimenStocks(context);
                    break;
                case "deleteSpecimenStocks":
                    deleteSpecimenStocks(context);
                    break;
                case "deleteSpecimenStocks2":
                    deleteSpecimenStocks2(context);
                    break;

                #endregion

                #region New Model
                case "getCancerType_Abbr":
                    getCancerType_Abbr(context);
                    break;
                case "SaveNewModel":
                    SaveNewModel(context);
                    break;
                case "deleteNewModel":
                    deleteNewModel(context);
                    break;

                case "SaveValidation":
                    SaveValidation(context);
                    break;
                case "deleteValidation":
                    deleteValidation(context);
                    break;

                case "SaveRoutineMaintain":
                    SaveRoutineMaintain(context);
                    break;
                case "deleteRoutineMaintain":
                    deleteRoutineMaintain(context);
                    break;

                case "SaveEndModels":
                    SaveEndModels(context);
                    break;
                case "deleteEndModels":
                    deleteEndModels(context);
                    break;


                case "SaveValidationStatus_Huprime":
                    SaveValidationStatus_Huprime(context);
                    break;
                case "deleteValidationStatus_Huprime":
                    deleteValidationStatus_Huprime(context);
                    break;
                case "SaveValidationStatus_Hukime":
                    SaveValidationStatus_Hukime(context);
                    break;
                case "deleteValidationStatus_Hukime":
                    deleteValidationStatus_Hukime(context);
                    break;

                case "SaveRevival":
                    SaveRevival(context);
                    break;
                case "deleteRevival":
                    deleteRevival(context);
                    break;

                    
                 case "SaveGeneticTest":
                    SaveGeneticTest(context);
                    break;
                case "deleteGeneticTest":
                    deleteGeneticTest(context);
                    break;
                #endregion

                #region MuPrime
                case "SaveMuPrime":
                    SaveMuPrime(context);
                    break;
                case "deleteMuPrime":
                    deleteMuPrime(context);
                    break;
             
                #endregion

                #region DisplayColumns
                case "getTableDisplayColumns":
                    getTableDisplayColumns(context);
                    break;
                case "SaveUserColumns":
                    SaveUserColumns(context);
                    break;
                case "hfAvailableColumns":
                    hfAvailableColumns(context);
                    break;
                #endregion
                case "CheckIsRole_View":
                    CheckIsRole_View(context);
                    break;

                case "CheckIsRole_Edit":
                    CheckIsRole_Edit(context);
                    break;
                
            }
        }

        public void SaveUserColumns(HttpContext context)
        {
            string msg = "";
            USERSELECTCOLUMNS row = null;
            string Table = context.Request["Table"] ?? "-1";
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            ParamCollection paralist = new ParamCollection();
            paralist.Clause = USERSELECTCOLUMNS.USER_ID_FIELD + "='" + userLogin.USER_ID.ToString() + "'";
            paralist.Clause += " and " + USERSELECTCOLUMNS.SELECTTABLENAME_FIELD + "= '" + Table + "'";
            BaseList data = bll.Select(paralist, typeof(USERSELECTCOLUMNS));
            if (data.Count == 0)
            {
                row = new USERSELECTCOLUMNS(DealModel.New);
            }
            else
            {
                row = (USERSELECTCOLUMNS)data[0];
                row.CurModel = DealModel.Modify;
            }
            row.USER_ID = userLogin.USER_ID;
            row.SELECTTABLENAME = Table;
            row.DISPLAYCOLUMNS = context.Request["s2"] ?? "";
            row.HIDDENCOLUMNS = context.Request["s1"] ?? "";
            decimal id = bll.Update(row);
            if (row.CurModel == DealModel.New)
                row.ID = id;
            row.CurModel = DealModel.None;
            context.Response.Write(msg);
        }

        public void deleteMuPrime(HttpContext context)
        {
            string msg = "";
            string delMuPrime_ID = context.Request["delMuPrime_ID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (PDXMODEL_INFO_ID = '{0}' )", delMuPrime_ID);

            BaseList data = bll.Select(paraList, typeof(PDXMODEL_INFO));
            if (data.Count > 0)
            {
                PDXMODEL_INFO row = (PDXMODEL_INFO)data[0];
                row.CurModel = DealModel.Delete;
                bll.Delete(row);
                msg = "Delete successfully";
            }
            context.Response.Write(msg);
        }
        public void CancelWithDraw(HttpContext context)
        {
            string msg = "";
            try
            {
                ParamCollection paralist = new ParamCollection();
                string checks = context.Request["id"];

                paralist.Clause = "Tissue_Withdraw_ID in (" + checks + ")";
                BaseList data = bll.Select(paralist, typeof(TISSUE_WITHDRAW));
                foreach (TISSUE_WITHDRAW dr in data)
                {
                    dr.CurModel = DealModel.Delete;
                    bll.Delete(dr);
                }
                context.Response.Write(msg);
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }

        public void ConfirmWithDraw(HttpContext context)
        {
            string msg = "";
            try
            {
                ParamCollection paralist = new ParamCollection();
                string checks = context.Request["id"];

                paralist.Clause = "Tissue_Withdraw_ID in (" + checks + ")";
                BaseList data = bll.Select(paralist, typeof(TISSUE_WITHDRAW));
                foreach (TISSUE_WITHDRAW dr in data)
                {
                    dr.CurModel = DealModel.Modify;
                    dr.CONFIRM = "Yes";

                    BaseList stockData = bll.Select(decimal.Parse(dr.SPECIMEN_STOCK_ID), typeof(SPECIMEN_STOCK));
                    if (stockData.Count > 0)
                    {
                        SPECIMEN_STOCK row = (SPECIMEN_STOCK)stockData[0];
                        row.CurModel = DealModel.Delete;
                        bll.Delete(row);
                    }
                }
                bll.UpdateAllByParams(data);
                context.Response.Write(msg);
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }

        public void GotoWithDraw(HttpContext context)
        {
            string msg = "";

            try
            {
                ParamCollection paralist = new ParamCollection();
                string checks = context.Request["id"];
                string pn = context.Request["pn"];
                paralist.Clause = "Specimen_Stock_ID in (" + checks + ")";


                BaseList IsHaveData = bll.Select(paralist, typeof(TISSUE_WITHDRAW));
                if (IsHaveData.Count > 0)
                {
                    msg = "There are already tissues withdraw.";
                }
                else
                {
                    BaseList data = bll.Select(paralist, typeof(SPECIMEN_STOCK));
                    BaseList addData = new BaseList();
                    foreach (SPECIMEN_STOCK dr in data)
                    {
                        //BaseList withData = bll.Select(dr.SPECIMEN_STOCK_ID.ToString(), typeof(TISSUE_WITHDRAW));
                        //if (withData.Count == 0)
                        //{
                            TISSUE_WITHDRAW row = new TISSUE_WITHDRAW(DealModel.New);
                            row.SPECIMEN_STOCK_ID = dr.SPECIMEN_STOCK_ID.ToString();
                            row.WITHDRAW_DATE = DateTime.Now;
                            row.WITHDRAW_PROJECT_NUMBER = pn;
                            row.MODEL_ID = dr.MODEL_ID;
                            row.CONFIRM = "No";
                            row.RN = dr.RN;
                            row.PN = dr.PN;
                            row.DATE_OF_INOCULATION = dr.DATE_OF_INOCULATION == DateTime.MinValue ? DateTime.MinValue : dr.DATE_OF_INOCULATION;
                            row.ANIMAL_NUMBER = dr.ANIMAL_NUMBER;
                            row.TOTAL_TUMOR_VOLUME = dr.TOTAL_TUMOR_VOLUME;
                            row.DATE_OF_TISSUE_COLLECTION = dr.DATE_OF_TISSUE_COLLECTION == DateTime.MinValue ? DateTime.MinValue : dr.DATE_OF_TISSUE_COLLECTION;
                            row.SITE_OF_TISSUE_COLLECTION = dr.SITE_OF_TISSUE_COLLECTION;
                            row.TISSUE_TYPE = dr.TISSUE_TYPE;
                            row.PRESERVE_METHOD = dr.PRESERVE_METHOD;
                            row.TREATMENT_TO_MICE = dr.TREATMENT_TO_MICE;
                            row.LOCATION_ID = dr.LOCATION_ID;
                            row.WELL_ID = dr.WELL_ID;
                            addData.Add(row);
                        //}
                    }
                    bll.UpdateAllByParams(addData);
                }
                context.Response.Write(msg);
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }


        public void SaveWithdraw(HttpContext context)
        {
            string msg = "";
            if (context.Session["temp_Withdraw"] != null)
            {
                try
                {
                    DataTable dt = (DataTable)context.Session["temp_Withdraw"];

                    string checks = context.Request["id"];
                    DataRow[] rows = dt.Select("Specimen_Stock_ID in (" + checks + ")");
                    DataTable importData = dt.Clone();
                    for (int i = 0; i < rows.Length; i++)
                    {
                        importData.ImportRow((DataRow)rows[i]);
                    }
                    importData.Columns["Export_Date"].ColumnName = "Withdraw_Date";
                    importData.Columns["Export_Project_Number"].ColumnName = "Withdraw_Project_Number";
                    ArrayList columns = new ArrayList();
                    foreach (DataColumn dc in importData.Columns)
                    {
                        columns.Add(dc.ColumnName);
                    }

                    columns.Remove("have_animal");


                    ojbRuleHuData.DelCheck_SpecimenStocks(checks);

                    ojbReportRule.InsertBigSql(importData, columns, "Tissue_Withdraw");

                    context.Session["temp_Withdraw"] = null;

                    #region 计算总格子和占用格子

                    try
                    {
                        List<LOCATION> allChilds = new List<LOCATION>();
                        BaseList locationData = bll.Select(typeof(LOCATION));
                        List<LOCATION> lData = locationData.ConvertAll<LOCATION>(LOCATION.Convert);
                        foreach (LOCATION dr in locationData)
                        {
                            string filter = dr.AID.Split(';')[0].ToString();
                            if (dr.ISPARENT)
                            {
                                List<LOCATION> allChilds2 = lData.FindAll(delegate(LOCATION perm) { return !perm.ISPARENT && perm.P_ID.Length > filter.Length; });
                                allChilds = allChilds2.FindAll(delegate(LOCATION perm) { return perm.P_ID.Substring(0, filter.Length) == filter; });
                            }
                            else
                            {
                                allChilds = lData.FindAll(delegate(LOCATION perm) { return perm.AID == dr.AID; });
                            }

                            double allbox = 0;//全部冰箱
                            foreach (LOCATION drr in allChilds)
                            {
                                allbox += double.Parse(drr.MAPS_ROWS) * double.Parse(drr.MAPS_COLUMNS);
                            }
                            dr.CurModel = DealModel.Modify;
                            dr.BOX_NUMBER = allbox;

                            DataTable db = ojbRuleHuData.getCountBankBox(filter);
                            double havebox = 0;
                            if (db.Rows.Count > 0)
                            {
                                havebox = double.Parse(db.Rows[0][0].ToString());
                            }
                            //已用冰箱个数
                            dr.USED_SPACE = havebox;

                        }
                        bll.UpdateAllByParams(locationData);
                    }
                    catch (Exception ex)
                    {
                        msg = "error";
                    }
                    #endregion
                    context.Response.Write(msg);
                }
                catch (Exception ex)
                {
                    context.Response.Write(ex.Message);
                }
            }

        }

        public void SaveTissueStock(HttpContext context)
        {
            string msg = "";
            if (context.Session["temp_tissue"] != null)
            {
                try
                {
                    DataTable dt = (DataTable)context.Session["temp_tissue"];

                    string checks = context.Request["id"];
                    DataRow[] rows = dt.Select("Specimen_Stock_ID in (" + checks + ")");
                    DataTable importData = dt.Clone();
                    for (int i = 0; i < rows.Length; i++)
                    {
                        importData.ImportRow((DataRow)rows[i]);
                    }
                    ArrayList columns = new ArrayList();
                    foreach (DataColumn dc in importData.Columns)
                    {
                        columns.Add(dc.ColumnName);
                    }
                    columns.Remove("Specimen_Stock_ID");
                    columns.Remove("have_animal");
                    ojbReportRule.InsertBigSql(importData, columns, "Specimen_Stock");

                    context.Session["temp_tissue"] = null;

                    if (importData.Rows.Count > 0)
                    {
                        List<LOCATION> allChilds = new List<LOCATION>();
                        BaseList locationData = bll.Select(typeof(LOCATION));
                        List<LOCATION> lData = locationData.ConvertAll<LOCATION>(LOCATION.Convert);

                        var query = from t in importData.AsEnumerable()
                                    group t by new { t1 = t.Field<string>("Location_ID") } into m
                                    select new
                                    {
                                        Location_ID = m.Key.t1
                                    };

                        foreach (var row in query.ToList())
                        {
                            string location_id = row.Location_ID;
                            ParamCollection pl = new ParamCollection();
                            pl.Clause += " AID like '" + location_id + "%'";
                            BaseList editData = bll.Select(pl,typeof(LOCATION));
                            if (editData.Count == 1)
                            {
                                #region 计算总格子和占用格子
                                try
                                {
                                    foreach (LOCATION dr in editData)
                                    {
                                        string filter = dr.AID.Split(';')[0].ToString();
                                        if (dr.ISPARENT)
                                        {
                                            List<LOCATION> allChilds2 = lData.FindAll(delegate(LOCATION perm) { return !perm.ISPARENT && perm.P_ID.Length > filter.Length; });
                                            allChilds = allChilds2.FindAll(delegate(LOCATION perm) { return perm.P_ID.Substring(0, filter.Length) == filter; });
                                        }
                                        else
                                        {
                                            allChilds = lData.FindAll(delegate(LOCATION perm) { return perm.AID == dr.AID; });
                                        }

                                        double allbox = 0;//全部冰箱
                                        foreach (LOCATION drr in allChilds)
                                        {
                                            allbox += double.Parse(drr.MAPS_ROWS) * double.Parse(drr.MAPS_COLUMNS);
                                        }
                                        dr.CurModel = DealModel.Modify;
                                        dr.BOX_NUMBER = allbox;

                                        DataTable db = ojbRuleHuData.getCountBankBox(filter);
                                        double havebox = 0;
                                        if (db.Rows.Count > 0)
                                        {
                                            havebox = double.Parse(db.Rows[0][0].ToString());
                                        }
                                        //已用冰箱个数
                                        dr.USED_SPACE = havebox;

                                    }
                                    bll.UpdateAllByParams(editData);
                                }
                                catch (Exception ex)
                                {
                                    msg = ex.Message;
                                }
                                #endregion
                                countLocation(((LOCATION)editData[0]).P_ID, lData);
                            }
                        }
                      
                    }
                    



                    context.Response.Write(msg);
                }
                catch (Exception ex)
                {
                    context.Response.Write(ex.Message);
                }
            }

        }


        #region 递归查询
        private void countLocation(string P_ID, List<LOCATION> lData)
        {
            List<LOCATION> allChilds = new List<LOCATION>();

            ParamCollection pl = new ParamCollection();
            pl.Clause += " AID = '" + P_ID + "'";
            BaseList editData = bll.Select(pl, typeof(LOCATION));
            if (editData.Count == 1)
            {
                #region 计算总格子和占用格子
                try
                {
                    foreach (LOCATION dr in editData)
                    {
                        string filter = dr.AID.Split(';')[0].ToString();
                        if (dr.ISPARENT)
                        {
                            List<LOCATION> allChilds2 = lData.FindAll(delegate(LOCATION perm) { return !perm.ISPARENT && perm.P_ID.Length > filter.Length; });
                            allChilds = allChilds2.FindAll(delegate(LOCATION perm) { return perm.P_ID.Substring(0, filter.Length) == filter; });
                        }
                        else
                        {
                            allChilds = lData.FindAll(delegate(LOCATION perm) { return perm.AID == dr.AID; });
                        }

                        double allbox = 0;//全部冰箱
                        foreach (LOCATION drr in allChilds)
                        {
                            allbox += double.Parse(drr.MAPS_ROWS) * double.Parse(drr.MAPS_COLUMNS);
                        }
                        dr.CurModel = DealModel.Modify;
                        dr.BOX_NUMBER = allbox;

                        DataTable db = ojbRuleHuData.getCountBankBox(filter);
                        double havebox = 0;
                        if (db.Rows.Count > 0)
                        {
                            havebox = double.Parse(db.Rows[0][0].ToString());
                        }
                        //已用冰箱个数
                        dr.USED_SPACE = havebox;
                    }
                    bll.UpdateAllByParams(editData);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion
                countLocation(((LOCATION)editData[0]).P_ID, lData);
            }
            else
            {
                return;
            }
        }
        #endregion

        public void btnSaveLocation(HttpContext context)
        {
            string msg = "";
            string id = context.Request["id"] ?? "";
            string txtRows = context.Request["txtRows"] ?? "";
            string txtColumns = context.Request["txtColumns"] ?? "";
            string txtLocation_Type = context.Request["txtLocation_Type"] ?? "";
            DataTable dt = new DataTable();
            try
            {
                BaseList deltetData = new BaseList();
                ParamCollection query1 = new ParamCollection();
                query1.Clause = LOCATION.AID_FIELD + " = '" + id + "'";
                BaseList data = bll.Select(query1, typeof(LOCATION));
                if (data.Count > 0)
                {
                    LOCATION row = (LOCATION)data[0];
                    row.CurModel = DealModel.Modify;
                    row.MAPS_ROWS = txtRows;
                    row.MAPS_COLUMNS = txtColumns;
                    row.LOCATION_TYPE = txtLocation_Type;
                    bll.Update(row);
                }

            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            context.Response.Write(msg);
        }


        public void SetMaps_location(HttpContext context)
        {
            string msg = "";
            string id = context.Request["id"] ?? "";
            DataTable dt = new DataTable();

            BaseList deltetData = new BaseList();
            ParamCollection query1 = new ParamCollection();
            query1.Clause = SPECIMEN_STOCK.LOCATION_ID_FIELD + " = '" + id + "'";
            BaseList data = bll.Select(query1, typeof(SPECIMEN_STOCK));
            if (data.Count > 0)
            {
                dt = UtitityHelper.ToDataTable(data);
                msg = MStoJson(dt);
            }

            context.Response.Write(msg);
        }

        public void edit_Locations(HttpContext context)
        {
            string msg = "";
            string id = context.Request["id"] ?? "";
            DataTable dt = new DataTable();
            try
            {
                BaseList deltetData = new BaseList();
                ParamCollection query1 = new ParamCollection();
                query1.Clause = LOCATION.AID_FIELD + " = '" + id + "'";
                BaseList data = bll.Select(query1, typeof(LOCATION));
                if (data.Count > 0)
                {
                    dt = UtitityHelper.ToDataTable(data);
                    msg = MStoJson(dt);
                }
          
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
         

            context.Response.Write(msg);
        }


        public string getAllLocations(HttpContext context)
        {
           
            StringBuilder NodesData = new StringBuilder();
            List<string> treenodes = new List<string>();
            BaseList data = bll.Select(typeof(LOCATION));
            foreach (LOCATION row in data)
            {
                if (row.ISPARENT)
                {
                    string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}", row.AID, row.P_ID, row.NAME);
                    treenodes.Add(node);
                }
                else
                {
                    string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":false}}", row.AID, row.P_ID, row.NAME);
                    treenodes.Add(node);
                }
            }
            string Strtest = string.Join(",", treenodes.ToArray());
            NodesData.Append("["+ Strtest+"]");
            return NodesData.ToString();
        }

        public void Remove_ModelTree_Node(HttpContext context)
        {
            string msg = "";
            string id = context.Request["id"] ?? "";
            try
            {
                BaseList deltetData = new BaseList();
                ParamCollection query1 = new ParamCollection();
                query1.Clause = ANIMAL_TREE.AID_FIELD + " = '" + id + "'";
                BaseList data = bll.Select(query1, typeof(ANIMAL_TREE));
                if (data.Count > 0)
                {
                    ANIMAL_TREE oldRow = (ANIMAL_TREE)data[0];
                    oldRow.CurModel = DealModel.Delete;
                    deltetData.Add(oldRow);

                    delete_ModelTree_Node(id, oldRow, deltetData);
                }
                bll.UpdateAllByParams(deltetData);
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            //msg = getAllLocations(context);

            context.Response.Write(msg);
        }


        public void delete_ModelTree_Node(string id, ANIMAL_TREE rows, BaseList deltetData)
        {
            ParamCollection query1 = new ParamCollection();
            query1.Clause = ANIMAL_TREE.P_ID_FIELD + " = '" + id + "'";
            BaseList data = bll.Select(query1, typeof(ANIMAL_TREE));
            foreach (ANIMAL_TREE child in data)
            {
                child.CurModel = DealModel.Delete;
                deltetData.Add(child);
                string oldID = child.AID;
                delete_ModelTree_Node(oldID, child, deltetData);
            }
        }


        public void Remove_Locations(HttpContext context)
        {
            string msg = "";
            string id = context.Request["id"] ?? "";
          
            try
            {
                BaseList deltetData = new BaseList();
                ParamCollection query1 = new ParamCollection();
                query1.Clause = LOCATION.AID_FIELD + " = '" + id + "'";
                BaseList data = bll.Select(query1, typeof(LOCATION));
                if (data.Count > 0)
                {
                    LOCATION oldRow = (LOCATION)data[0];
                    oldRow.CurModel = DealModel.Delete;
                    deltetData.Add(oldRow);

                    delete_location(id, oldRow, deltetData);
                }
                bll.UpdateAllByParams(deltetData);
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            msg = getAllLocations(context);

            context.Response.Write(msg);
        }

        /// <summary> ///递归删除
        /// </summary>
        /// <param name="context"></param>
        public void delete_location(string id, LOCATION rows, BaseList deltetData)
        {
            ParamCollection query1 = new ParamCollection();
            query1.Clause = LOCATION.P_ID_FIELD + " = '" + id + "'";
            BaseList data = bll.Select(query1, typeof(LOCATION));
            foreach (LOCATION child in data)
            {
                child.CurModel = DealModel.Delete;
                deltetData.Add(child);
                string oldID = child.AID;
                delete_location(oldID, child, deltetData);
            }
        }


        public void SaveLocations_Name(HttpContext context)
        {
            string msg = "";
            string id = context.Request["id"] ?? "";
            string name = context.Request["name"] ?? "";

            try
            {
                ParamCollection query1 = new ParamCollection();
                query1.Clause = LOCATION.AID_FIELD + " = '" + id + "'";
                BaseList data = bll.Select(query1, typeof(LOCATION));
                if (data.Count > 0)
                {
                    LOCATION oldRow = (LOCATION)data[0];
                    oldRow.CurModel = DealModel.Modify;
                    oldRow.AID = oldRow.AID.Replace(oldRow.NAME, name);
                    oldRow.NAME = name;
                    bll.Update(oldRow);

                    edit_locationName(id,oldRow);
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            msg = getAllLocations(context);

            context.Response.Write(msg);
        }

        /// <summary>
        /// 递归修改名字
        /// </summary>
        /// <param name="id">aid</param>
        /// <param name="oldname">旧名字</param>
        /// <param name="name">新名字</param>
        public void edit_locationName(string id,LOCATION rows)
        {
            ParamCollection query1 = new ParamCollection();
            query1.Clause = LOCATION.P_ID_FIELD + " = '" + id + "'";
            BaseList data = bll.Select(query1, typeof(LOCATION));
            foreach (LOCATION child in data)
            {
                child.CurModel = DealModel.Modify;
                child.P_ID = rows.AID;

                string oldID = child.AID;
                child.AID = child.P_ID.Split(';')[0] + ":" + child.NAME + ";" + child.AID.Split(';')[1];
                bll.Update(child);

                edit_locationName(oldID, child);
            }
        }

        public void CopyLocations(HttpContext context)
        {
              string msg = "";
              string targetNode = context.Request["targetNode"] ?? "";//复制到哪个根节点
              string curSrcNode = context.Request["curSrcNode"] ?? "";//复制的节点AID
            
              try
              {
                  ParamCollection query1 = new ParamCollection();
                  query1.Clause = LOCATION.AID_FIELD + " = '" + curSrcNode + "'";
                  BaseList data = bll.Select(query1, typeof(LOCATION));
                  if (data.Count > 0)
                  {
                      LOCATION oldRow = (LOCATION)data[0];
                      LOCATION newRow = null;
                      newRow = new LOCATION(DealModel.New);
                      newRow.NAME = oldRow.NAME;
                      newRow.LOCATION_TYPE = oldRow.LOCATION_TYPE;
                      newRow.ISPARENT = oldRow.ISPARENT;
                      newRow.MAPS_ROWS = oldRow.MAPS_ROWS;
                      newRow.MAPS_COLUMNS = oldRow.MAPS_COLUMNS;
                      newRow.AID = targetNode.Split(';')[0] + ":" + newRow.NAME;
                      newRow.P_ID = targetNode;
                      decimal id = bll.Update(newRow);

                      newRow.CurModel = DealModel.Modify;
                      newRow.AID = newRow.AID + ";" + id.ToString();
                      bll.Update(newRow);

                      copyChild_location(curSrcNode, newRow, id);
                    
                  }

                 

              }
              catch (Exception ex)
              {
                  msg = ex.ToString();
              }
              msg = getAllLocations(context);
              context.Response.Write(msg);
        }

        //递归
        public void copyChild_location(string curSrcNode, LOCATION newRow, decimal id)
        {
            ParamCollection query2 = new ParamCollection();
            query2.Clause = LOCATION.P_ID_FIELD + " = '" + curSrcNode + "'";
            BaseList data2 = bll.Select(query2, typeof(LOCATION));
            LOCATION childRow = null;
            BaseList chidlData = new BaseList();
            foreach (LOCATION child in data2)
            {
                childRow = new LOCATION(DealModel.New);
                childRow.NAME = child.NAME;
                childRow.LOCATION_TYPE = child.LOCATION_TYPE;
                childRow.ISPARENT = child.ISPARENT;
                childRow.MAPS_ROWS = child.MAPS_ROWS;
                childRow.MAPS_COLUMNS = child.MAPS_COLUMNS;
                childRow.AID = newRow.AID.Split(';')[0] + ":" + childRow.NAME;
                childRow.P_ID = newRow.AID;
                decimal _id = bll.Update(childRow);

                childRow.CurModel = DealModel.Modify;
                childRow.AID = childRow.AID + ";" + _id.ToString();
                bll.Update(childRow);


                copyChild_location(child.AID, childRow, _id);
            }
          
        }

        public void SavePharmacology_Effect(HttpContext context)
        {
            string msg = "";
            try
            {
                string hf_Pharmacology_Effect = context.Request["hf_Pharmacology_Effect"] ?? "";

                ParamCollection query1 = new ParamCollection();
                query1.Clause = ANIMAL_TREE.AID_FIELD + " = '" + hf_Pharmacology_Effect + "'";
                BaseList dataTree = bll.Select(query1, typeof(ANIMAL_TREE));

                ParamCollection query2 = new ParamCollection();
                query2.Clause = PHARMACOLOGY_EFFECT.ANIMALTREE_ID_FIELD + " = '" + hf_Pharmacology_Effect + "'";

                BaseList data = bll.Select(query2, typeof(PHARMACOLOGY_EFFECT));
                PHARMACOLOGY_EFFECT row = null;
                if (data.Count > 0)
                {
                    row = (PHARMACOLOGY_EFFECT)data[0];
                    row.CurModel = DealModel.Modify;
                }
                else
                {
                    row = new PHARMACOLOGY_EFFECT(DealModel.New);
                    row.ANIMALTREE_ID = hf_Pharmacology_Effect;
                    row.MODEL_ID = ((ANIMAL_TREE)dataTree[0]).MODEL_ID;
                    row.PN = ((ANIMAL_TREE)dataTree[0]).PN;
                }
                row.STUDY_NUMBER = context.Request["txtStudy_Number"] ?? "";
                row.INOCULATION_DATE = DateTime.Parse(context.Request["txtInoculation_Date"]);
                bll.Update(row);
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            context.Response.Write(msg);
        }
        public void getTableDisplayColumns(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
            string ddlname = context.Request["Table"] ?? "";
            ParamCollection paralist = new ParamCollection();
            paralist.Clause = TABLEDISPLAYCOLUMNS.TABLENAME_FIELD + " = '" + ddlname + "'";
            BaseList data = bll.Select(paralist, typeof(TABLEDISPLAYCOLUMNS));
            if (data.Count > 0)
            {
                TABLEDISPLAYCOLUMNS row = (TABLEDISPLAYCOLUMNS)data[0];
                foreach (string node in row.TABLECOLUMNS.Split(','))
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.Replace("\\n", ""), node.Replace("\\n", ""));
                    resultStr += "},";
                }
            }
            else
            {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }


        public void SaveMuPrime(HttpContext context)
        {
            string msg = "";
            PDXMODEL_INFO row = null;
            decimal pid = decimal.Parse(context.Request["hfMuPrime_ID"]);
            if (!bll.Find(pid, context.Request["txtSq_Number"], typeof(PDXMODEL_INFO)))
            {
                BaseList dataPDX = bll.Select(typeof(PDXMODEL_INFO));
                try
                {
                    row = (PDXMODEL_INFO)dataPDX.Find(pid);
                    if(row == null)
                    {
                        row = new PDXMODEL_INFO(DealModel.New);
                    }
                    if (row.CurModel != DealModel.New)
                    {
                        row.CurModel = DealModel.Modify;
                        
                    }
                    row.SQ_NUMBER = context.Request["txtSq_Number"].ToString();
                    string type = context.Request["txtCancer_Type"] ?? "";
                    if (type != "")
                    {
                        string abbr = ojbRuleHuData.getCancerType_Abbr(type);
                        row.CANCER_TYPE_ABBR = abbr;
                        string sq = row.SQ_NUMBER.ToString();
                        if (row.SQ_NUMBER.ToString().Length < 4)
                        {
                            sq = row.SQ_NUMBER.ToString().PadLeft(4, '0'); 
                        }

                        if (sq.Contains("m"))
                        {
                            row.MODEL_ID = "m" + row.CANCER_TYPE_ABBR + sq.Replace("m", "");
                        }
                        else
                        {
                            row.MODEL_ID = row.CANCER_TYPE_ABBR + sq;
                        }

                        if (row.CurModel == DealModel.Modify)
                        {
                            //model id 更新
                            if (row.MODEL_ID != abbr + sq)
                            { 
                                //
                            }
                        }
                    }
                    else
                    {
                        row.CANCER_TYPE_ABBR = "";
                        row.MODEL_ID = "";
                    }
                    row.MODEL_FROM = context.Request["txtModel_From"] ?? "";
                    row.ORIGIN = context.Request["txtMouse_Strain"] ?? "";
                    row.CANCER_TYPE = context.Request["txtCancer_Type"] ?? "";
                    row.SUBTYPE1 = context.Request["txtSubtype1"] ?? "";
                    row.SUBTYPE2 = context.Request["txtSubtype2"] ?? "";
                    row.MODEL_CATEGORY = context.Request["txtModel_Category"] ?? "";
                    row.SOURCE_ID = context.Request["txtSource_ID"] ?? "";
                    row.SOURCE_NOTE = context.Request["txtSource_Note"] ?? "";
                    row.PDX_QC = context.Request["txtPDX_QC"] ?? "";
                    row.STR_CONSISTENCE = context.Request["txtGenotype_Consistence"] ?? "";
                    row.IN_HUBA = context.Request["txtIN_HUBA"] ?? "";
                    row.TOTAL_REVIVAL_SUCCESS_RATE = context.Request["txtTotal_Revival_Success_Rate"] ?? "";
                    row.TIME_OF_REVIVAL = context.Request["txtTime_of_Revival"] ?? "";
                    row.REVIVAL_RECOMMENDED_STRAIN = context.Request["txtRevival_Recommended_Strain"] ?? "";
                    row.TIME_OF_MODEL_FOR_TRANSPLANT = context.Request["txtTime_of_Model_for_Transplant"] ?? "";
                    row.MAINTAIN_RECOMMENDED_STRAIN = context.Request["txtMaintain_Recommended_Strain"] ?? "";
                    row.CV40_TAKE_RATE = context.Request["txtSpareforCV40"] ?? "";
                    row.CV30_TAKE_RATE = context.Request["txtSpareforCV30"] ?? "";
                    row.OPTIMAL_OVERAGE = context.Request["txtOptimal_Overage"] ?? "";
                    row.DOSING_WINDOW = context.Request["txtDosing_Window"] ?? "";
                    row.CRYO_P = RegHelper.IsNumber0(context.Request["txtCryo_P"]) == true ? int.Parse(context.Request["txtCryo_P"]) : 0;
                    row.SNAP_FROZEN = RegHelper.IsNumber0(context.Request["txtSnap_Frozen"]) == true ? int.Parse(context.Request["txtSnap_Frozen"]) : 0;
                    row.FFPE = RegHelper.IsNumber0(context.Request["txtFFPE"]) == true ? int.Parse(context.Request["txtFFPE"]) : 0;
                    row.TIMES_USED_IN_STUDY = context.Request["txtTimes_Used_In_Study"] ?? "";
                    row.CACHEXIA_LABEL = context.Request["txtCachexia_Label"] ?? "";
                    row.CACHEXIA = context.Request["txtCachexia"] ?? "";
                    row.SLIGHT_BW_LOSS = context.Request["txtSlight_BW_loss"] ?? "";
                    row.NORMAL = context.Request["txtNormal"] ?? "";

                    row.ULCERATION_LABEL = context.Request["txtUlceration_Label"] ?? "";
                    row.SURVIVAL_CURVE = context.Request["txtSurvival_Curve"] ?? "";
                    row.COMMENTS = FormatHelper.doTran(context.Request["txtcomments"]) ?? "";
                    row.SOURCE = context.Request["txtSource"] ?? "";

                    row.SOC = context.Request["ddlSOC"] ?? "";
                    row.DATA_TYPE = "Mouse";
                    row.UPDATE_TIME = DateTime.Now;
                    dataPDX.Add(row);
                    decimal id = bll.Update(row);
                    if (row.CurModel == DealModel.New)
                        row.ID = id;
                    row.CurModel = DealModel.None;
                    //msg = "Save successfully.";
                }
                catch (Exception ex)
                {
                    msg = ex.Message.ToString();
                }
            }
            else
            {
                msg = "Sq Number already exists.";
            }
            context.Response.Write(msg);

        }


        public void SavePDXmodel(HttpContext context)
        {
            string msg = "";
            PDXMODEL_INFO row = null;
            decimal pid = decimal.Parse(context.Request["hfPDXInfoID"]);
            if (!bll.Find(pid, context.Request["txtSq_Number"], typeof(PDXMODEL_INFO)))
            {
                BaseList dataPDX = bll.Select(typeof(PDXMODEL_INFO));
                try
                {
                    row = (PDXMODEL_INFO)dataPDX.Find(pid);
                    if(row == null)
                    {
                        row = new PDXMODEL_INFO(DealModel.New);
                        //SYS_USER userLogin = CacheHelper.getCurrentUser();
                        //bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "PDXModelInfo", "CBSD edit only");
                        //row.LOCATION = havePerm == true ? "CBSD" : "Not CBSD";
                    }
                    if (row.CurModel != DealModel.New)
                    {
                        row.CurModel = DealModel.Modify;
                        
                    }
                    row.SQ_NUMBER = context.Request["txtSq_Number"];
                    string type = context.Request["txtCancer_Type"] ?? "";
                    if (type != "")
                    {
                        string abbr = ojbRuleHuData.getCancerType_Abbr(type);
                        row.CANCER_TYPE_ABBR = abbr;
                        string sq = row.SQ_NUMBER.ToString();
                        if (row.SQ_NUMBER.ToString().Length < 4)
                        {
                            sq = row.SQ_NUMBER.ToString().PadLeft(4, '0'); 
                        }
                        if (sq.Contains("m"))
                        {
                            row.MODEL_ID = "m" + row.CANCER_TYPE_ABBR + sq.Replace("m", "");
                        }
                        else
                        {
                            row.MODEL_ID = row.CANCER_TYPE_ABBR + sq;
                        }

                        if (row.CurModel == DealModel.Modify)
                        {
                            //model id 更新
                            if (row.MODEL_ID != abbr + sq)
                            { 
                                //
                            }
                        }
                    }
                    else
                    {
                        row.CANCER_TYPE_ABBR = "";
                        row.MODEL_ID = "";
                    }
                    SYS_USER userLogin = CacheHelper.getCurrentUser();
                    if (ojbReportRule.GetUserFunctions(userLogin.Permission, "PDXModelInfo-save", "Model_From"))
                    {
                        row.MODEL_FROM = context.Request["txtModel_From"] ?? "";
                    }
                    row.ORIGIN = context.Request["txtOrigin"] ?? "";
                    row.CANCER_TYPE = context.Request["txtCancer_Type"] ?? "";
                    row.SUBTYPE1 = context.Request["txtSubtype1"] ?? "";
                    row.SUBTYPE2 = context.Request["txtSubtype2"] ?? "";
                    row.MODEL_CATEGORY = context.Request["txtModel_Category"] ?? "";
                    row.SOURCE_ID = context.Request["txtSource_ID"] ?? "";
                    row.SOURCE_NOTE = context.Request["txtSource_Note"] ?? "";
                    row.PDX_QC = context.Request["txtPDX_QC"] ?? "";
                    row.STR_CONSISTENCE = context.Request["txtSTR_Consistence"]?? "";
                    row.IN_HUBA = context.Request["txtIN_HUBA"] ?? "";
                    row.EXOMESEQ = context.Request["txtExomeseq"] ?? "";

                    row.TOTAL_REVIVAL_SUCCESS_RATE = context.Request["txtTotal_Revival_Success_Rate"] ?? "";
                    row.TIME_OF_REVIVAL = context.Request["txtTime_of_Revival"] ?? "";
                    row.REVIVAL_RECOMMENDED_STRAIN = context.Request["txtRevival_Recommended_Strain"] ?? "";
                    row.TIME_OF_MODEL_FOR_TRANSPLANT = context.Request["txtTime_of_Model_for_Transplant"] ?? "";
                    row.MAINTAIN_RECOMMENDED_STRAIN = context.Request["txtMaintain_Recommended_Strain"] ?? "";
                    row.CV40_TAKE_RATE = context.Request["txtSpareforCV40"] ?? "";
                    row.CV30_TAKE_RATE = context.Request["txtSpareforCV30"] ?? "";
                    row.OPTIMAL_OVERAGE = context.Request["txtOptimal_Overage"] ?? "";
                    row.DOSING_WINDOW = context.Request["txtDosing_Window"] ?? "";
                    row.CRYO_P = RegHelper.IsNumber0(context.Request["txtCryo_P"]) == true ? int.Parse(context.Request["txtCryo_P"]) : 0;
                    row.SNAP_FROZEN = RegHelper.IsNumber0(context.Request["txtSnap_Frozen"]) == true ? int.Parse(context.Request["txtSnap_Frozen"]) : 0;
                    row.FFPE = RegHelper.IsNumber0(context.Request["txtFFPE"]) == true ? int.Parse(context.Request["txtFFPE"]) : 0;
                    row.HP2 = context.Request["txtHP2"] ?? "";
                    row.TIMES_USED_IN_STUDY = context.Request["txtTimes_Used_In_Study"] ?? "";
                    row.CACHEXIA_LABEL = context.Request["txtCachexia_Label"] ?? "";
                    row.CACHEXIA = context.Request["txtCachexia"] ?? "";
                    row.SLIGHT_BW_LOSS = context.Request["txtSlight_BW_loss"] ?? "";
                    row.NORMAL = context.Request["txtNormal"] ?? "";

                    row.ULCERATION_LABEL = context.Request["txtUlceration_Label"] ?? "";
                    row.SURVIVAL_CURVE = context.Request["txtSurvival_Curve"] ?? "";
                    row.SOC = context.Request["ddlSOC"] ?? "";
                    row.DATA_TYPE = "PDX";
                    row.COMMENTS = FormatHelper.doTran(context.Request["txtcomments"]) ?? "";

                    row.TOTAL_REVIVAL_SUCCESS_RATE_CBNC = context.Request["txtTotal_Revival_Success_Rate_CBNC"] ?? "";
                    row.TIME_OF_REVIVAL_CBNC = context.Request["txtTime_of_Revival_CBNC"] ?? "";
                    row.REVIVAL_RECOMMENDED_STRAIN_CBNC = context.Request["txtRevival_Recommended_Strain_CBNC"] ?? "";

                    row.TREATMENT_HISTORY_1 = context.Request["txtTreatment_history_1"] ?? "";
                    row.TREATMENT_HISTORY_2 = context.Request["txtTreatment_history_2"] ?? "";
                    row.SOURCE = context.Request["txtSource"] ?? "";
                    row.IMPLANTATION_METHOD = context.Request["txtImplantation_Method"] ?? "";
                    row.DEATHRATE = context.Request["txtDeathRate"] ?? "";

                    row.PATIENT_ID = context.Request["txtPatient_ID"] ?? "";

                    row.UPDATE_TIME = DateTime.Now;
                    dataPDX.Add(row);
                    decimal id = bll.Update(row);
                    if (row.CurModel == DealModel.New)
                        row.ID = id;
                    row.CurModel = DealModel.None;
                    //msg = "Save successfully.";
                }
                catch (Exception ex)
                {
                    msg = ex.Message.ToString();
                }
            }
            else
            {
                msg = "Sq Number already exists.";
            }
            context.Response.Write(msg);

        }


        public void MoveToSubproject(HttpContext context)
        {
            string msg = "";
            string Requestid = context.Request["Requestid"] ?? "";
            string moveIDs = context.Request["moveIDs"] ?? "";
            string subprojects = context.Request["subprojects"] ?? "";
            ParamCollection paralist = new ParamCollection();
            paralist.Clause = REQUEST.PROJECT_NUMBER_FIELD + "='" + subprojects + "'";
            BaseList todata = bll.Select(paralist, typeof(REQUEST));
            if (todata.Count > 0)
            {
                REQUEST toRow = (REQUEST)todata[0];
                toRow.CurModel = DealModel.Modify;
                ArrayList list = new ArrayList(toRow.MODEL_ID.Split(','));
                foreach (string mid in moveIDs.Split(','))
                {
                    if(!list.Contains(mid))
                    list.Add(mid);
                }
                toRow.MODEL_ID = string.Join(",", (string[])list.ToArray(typeof(string))); ;
                bll.Update(toRow);
            }
            ParamCollection paralist1 = new ParamCollection();
            paralist1.Clause = REQUEST.REQUEST_ID_FIELD + "='" + Requestid + "'";
            BaseList olddata = bll.Select(paralist1, typeof(REQUEST));
            if (olddata.Count > 0)
            {
                REQUEST oldRow = (REQUEST)olddata[0];
                oldRow.CurModel = DealModel.Modify;
                ArrayList list = new ArrayList(oldRow.MODEL_ID.Split(','));
                foreach (string mid in moveIDs.Split(','))
                {
                    list.Remove(mid);
                }
                oldRow.MODEL_ID = string.Join(",", (string[])list.ToArray(typeof(string)));
                bll.Update(oldRow);
            }
            msg = "Move successfully";
            context.Response.Write(msg);
        }


        public void MoveToStudyDesign(HttpContext context)
        {
            string msg = "";
            string Monitor_id = context.Request["Monitor_id"] ?? "";
            string cbxToModelID = context.Request["cbxToModelID"]??"";
            string cbxToProject = context.Request["cbxToProject"] ?? "";
            
            ParamCollection pl = new ParamCollection();
            pl.Clause = PROJECT_MONITOR.PROJECT_MONITOR_ID_FIELD + "='" + Monitor_id + "'";
            BaseList mdata = bll.Select(pl, typeof(PROJECT_MONITOR));
            PROJECT_MONITOR fromRow = (PROJECT_MONITOR)mdata[0];

            ParamCollection pl2 = new ParamCollection();
           
            
            pl2.Clause = PROJECT_MONITOR.PROJECT_NUMBER_FIELD + "='" + cbxToProject + "'";
            if (cbxToModelID != "")
            {
                string ids = "";
                foreach (string a in cbxToModelID.Split(','))
                {
                    if (a != "")
                    {
                        ids += "'" + a + "',";
                    }
                }
               string column = PROJECT_MONITOR.MODEL_ID_FIELD;
               pl2.Clause += string.Format(" AND ({0}.{1} in ({2}) )", PROJECT_MONITOR.TABLE_NAME, column, ids.TrimEnd(','));
            }
            BaseList toData = bll.Select(pl2, typeof(PROJECT_MONITOR));
            foreach (PROJECT_MONITOR toRow in toData)
            {
                if (toRow.PROJECT_MONITOR_ID.ToString() != Monitor_id)
                {
                    ParamCollection paralist = new ParamCollection();
                    paralist.Clause = PROJECT_MONITOR_STUDY_DESIGN.PROJECT_MONITOR_ID_FIELD + "='" + toRow.PROJECT_MONITOR_ID + "'";
                    BaseList todata = bll.Select(paralist, typeof(PROJECT_MONITOR_STUDY_DESIGN));
                    foreach (PROJECT_MONITOR_STUDY_DESIGN del in todata)
                    {
                        del.CurModel = DealModel.Delete;
                    }
                    bll.UpdateAllByParams(todata);


                    toRow.CurModel = DealModel.Modify;
                    toRow.FFPE_TUMOR_SAMPLE_NUMBER = fromRow.FFPE_TUMOR_SAMPLE_NUMBER;
                    toRow.SNAP_FROZNE_SAMPLE_NUMBER = fromRow.SNAP_FROZNE_SAMPLE_NUMBER;
                    toRow.BLOOD_SAMPLE_NUMBER = fromRow.BLOOD_SAMPLE_NUMBER;
                    toRow.BLOOD_SAMPLE_TYPE = fromRow.BLOOD_SAMPLE_TYPE;
                    toRow.NUMBER_OF_ANIMAL_PURCHASE = fromRow.NUMBER_OF_ANIMAL_PURCHASE;
                    toRow.NUMBER_OF_ANIMAL_INOCULATION = fromRow.NUMBER_OF_ANIMAL_INOCULATION;
                    toRow.TUMOR_MONITOR_SCHEDULE = fromRow.TUMOR_MONITOR_SCHEDULE;
                    toRow.TUMOR_MONITOR_SCHEDULE2 = fromRow.TUMOR_MONITOR_SCHEDULE2;
                    bll.Update(toRow);
                }
                BaseList newData = new BaseList();
                ParamCollection newpl = new ParamCollection();
                newpl.Clause = PROJECT_MONITOR_STUDY_DESIGN.PROJECT_MONITOR_ID_FIELD + "='" + Monitor_id + "'";
                BaseList studyData = bll.Select(newpl, typeof(PROJECT_MONITOR_STUDY_DESIGN));
                if (studyData.Count > 0)
                {
                    newData = studyData;
                    foreach (PROJECT_MONITOR_STUDY_DESIGN row in newData)
                    {
                        if (toRow.PROJECT_MONITOR_ID.ToString() != Monitor_id)
                        {
                            row.CurModel = DealModel.New;
                            row.PROJECT_MONITOR_ID = toRow.PROJECT_MONITOR_ID;
                        }
                    }
                    bll.UpdateAllByParams(newData);
                }


            };


           

            msg = "Copy successfully";
            context.Response.Write(msg);
        }


        public void ConvertMid(HttpContext context)
        {
            string msg = "";
            string txtImport = context.Request["txtImport"] ?? "";
            if (txtImport != "")
            {
                string[] mids = txtImport.Split('\n');
                foreach (string mid in mids)
                {
                    if (mid != "")
                    {
                        msg += mid + ",";
                    }
                }
                msg = msg.TrimEnd(',');
            }
            context.Response.Write(msg);
        }
        public void ModifyRequest(HttpContext context)
        {
            string hfRequest_id = context.Request["hfRequest_id"] ?? "";
            BaseList oldRequest = bll.Select(queryEdit(context.Request["hfRequest_id"].ToString()), typeof(REQUEST));
            REQUEST oldrow = (REQUEST)oldRequest[0];

            //#region 保存旧request
            //REQUEST_LOG logrow = new REQUEST_LOG(DealModel.New);
            //logrow.REQUEST_ID = decimal.Parse(context.Request["hfRequest_id"].ToString());
            //logrow.CLIENT = oldrow.CLIENT;
            //logrow.DATE_REQUEST = oldrow.DATE_REQUEST;
            //logrow.PROJECT_NUMBER = oldrow.PROJECT_NUMBER;
            //logrow.BD = oldrow.BD;
            //logrow.SD = oldrow.SD;
            //logrow.REQUESTER_ID = oldrow.REQUESTER_ID;
            //logrow.RESPONDER = oldrow.RESPONDER;
            //logrow.RESPONDER_ID = oldrow.RESPONDER_ID;
            //logrow.DATE_RESPONDING = oldrow.DATE_RESPONDING;
            //logrow.HAVE_CONFIRMED = oldrow.HAVE_CONFIRMED;
            //logrow.MODEL_ID = oldrow.MODEL_ID;
            //logrow.TUMOR_TYPE = oldrow.TUMOR_TYPE;
            ////logrow.SUBTYPE = oldrow.SUBTYPE;
            ////logrow.POTENTIAL_STUDY_SIZE = oldrow.POTENTIAL_STUDY_SIZE;
            //logrow.SPECIAL_REQUIREMENTS = oldrow.SPECIAL_REQUIREMENTS;
            //logrow.CONFIRM_DATE = oldrow.CONFIRM_DATE;
            //logrow.OTHERS_TO_NOTIFY = oldrow.REMARK;
            //bll.Update(logrow);
            //#endregion

            BaseList dataModels = bll.Select(queryRespondModels(context, hfRequest_id), typeof(RESPOND_MODELS));
            foreach (RESPOND_MODELS dv in dataModels)
            {
                dv.CurModel = DealModel.Delete;
            }
            bll.UpdateAllByParams(dataModels);
           

            string msg = "";
            try
            {
                #region 更新request
                string projectnumber = context.Request["PN"] ?? "";
                oldrow.CurModel = DealModel.Modify;
                oldrow.DATE_REQUEST = DateTime.Now;
                oldrow.RESPONDER = "";
                oldrow.RESPONDER_ID = "";
                oldrow.DATE_RESPONDING = DateTime.MinValue;
                oldrow.HAVE_CONFIRMED = "N";
                oldrow.PROJECT_NUMBER = projectnumber;
                oldrow.REMARK = "";
                //logrow.CONFIRM_DATE = DateTime.MinValue;

                string ddlTumor_Type = context.Request["ddlTumor_Type"] ?? "";
                string txtModel_ID = context.Request["txtModel_ID"] ?? "";

                BaseList dataRespondModels = new BaseList();
                ArrayList list_cancertype = new ArrayList();
                ArrayList list_subtype = new ArrayList();
                string type1 = "";
                string type2 = "";
                if (txtModel_ID != "")
                {
                    oldrow.MODEL_ID = txtModel_ID.Substring(2, txtModel_ID.Length - 2);
                    BaseList dataTypes = bll.Select(queryOnlytype(context, txtModel_ID), "Subtype", typeof(PDXMODEL_INFO));
                    if (dataTypes.Count > 0)
                    {
                        foreach (PDXMODEL_INFO dr in dataTypes)
                        {
                            if (!list_cancertype.Contains(dr.CANCER_TYPE))
                            {
                                list_cancertype.Add(dr.CANCER_TYPE);
                                type1 += dr.CANCER_TYPE + ",";
                            }
                            //if (!list_subtype.Contains(dr.SUBTYPE))
                            //{
                            //    list_subtype.Add(dr.SUBTYPE);
                            //    type2 += dr.SUBTYPE + ",";
                            //}
                        }
                        oldrow.TUMOR_TYPE = type1.TrimEnd(',');
                       // oldrow.SUBTYPE = type2.TrimEnd(',');
                    }
                    BaseList dataModelInfo = bll.Select(queryModelRequest(context, txtModel_ID), typeof(PDXMODEL_INFO));
                    if (dataModelInfo.Count > 0)
                    {
                        foreach (PDXMODEL_INFO dr in dataModelInfo)
                        {
                            RESPOND_MODELS row3 = new RESPOND_MODELS(DealModel.New);
                            row3.MODEL_ID = dr.MODEL_ID;
                            row3.PDXMODEL_INFO_ID = dr.MODEL_ID;
                            row3.RN = "";
                            row3.PN = "";
                            dataRespondModels.Add(row3);
                        }
                    }
                }
                else
                {
                    oldrow.MODEL_ID = "";
                    //oldrow.SUBTYPE = "";
                    oldrow.TUMOR_TYPE = ddlTumor_Type;
                    string[] subtype = { };
                    string[] subtype2 = { };
                    if (context.Request["ddlSubtype"] != null)
                    {
                        subtype = context.Request["ddlSubtype"].Split(',');
                       // oldrow.SUBTYPE = context.Request["ddlSubtype"].ToString();
                    }
                    BaseList dataModelInfo = bll.Select(queryPDXmodelinfo(context, ddlTumor_Type, subtype, subtype2), typeof(PDXMODEL_INFO));
                    if (dataModelInfo.Count > 0)
                    {
                        foreach (PDXMODEL_INFO dr in dataModelInfo)
                        {
                            RESPOND_MODELS row3 = new RESPOND_MODELS(DealModel.New);
                            row3.MODEL_ID = dr.MODEL_ID;
                            row3.PDXMODEL_INFO_ID = dr.MODEL_ID;
                            row3.RN = "";
                            row3.PN = "";

                            dataRespondModels.Add(row3);
                        }
                    }
                }
                #endregion

                bll.UpdateMasterDetail(oldrow, new BaseList[] { dataRespondModels });
                //if (oldrow.CurModel == DealModel.New)
                //    oldrow.ID = IDD;
                oldrow.CurModel = DealModel.None;

            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
            }
            context.Response.Write(msg);
        }


        public void SaveBooking(HttpContext context)
        {
            PROJECT_BOOKING row = null;
            PROJECT_REVIVE row3 = null;
            string txtAnimal_Booking = context.Request["txtAnimal_Booking"] ?? "";
            string txtFurther_expanding = context.Request["txtFurther_expanding"] ?? "";
            string hfAnimal_Number = context.Request["hfAnimal_Number"] ?? "";
            string rid = context.Request["rid"] ?? "";
            string book_MODEL_ID = context.Request["book_MODEL_ID"] ?? "";

            string txtRevive = context.Request["txtRevive"] ?? "";
            string hfNoliveAnimal = context.Request["hfNoliveAnimal"] ?? "";



            ParamCollection query = new ParamCollection();
            query.Clause = REQUEST.REQUEST_ID_FIELD + "='" + rid + "'";
            BaseList requestData = bll.Select(query, typeof(REQUEST));
            REQUEST request = (REQUEST)requestData[0];
            string msg = "";


            #region save revive

            ParamCollection paraList3 = new ParamCollection();
            if (hfNoliveAnimal == "No live animals")//安排复苏
            {
                paraList3.Clause = PROJECT_REVIVE.MODEL_ID_FIELD + "='" + book_MODEL_ID + "'";
                paraList3.Clause += " AND " + PROJECT_REVIVE.REQUEST_ID_FIELD + "='" + request.REQUEST_ID.ToString() + "' ";
            }
            else
            {
                paraList3.Clause = PROJECT_REVIVE.ANIMAL_NUMBER_FIELD + "='" + hfAnimal_Number + "'";
                paraList3.Clause += " AND " + PROJECT_REVIVE.REQUEST_ID_FIELD + "='" + request.REQUEST_ID.ToString() + "' ";
            }
            BaseList data3 = bll.Select(paraList3, typeof(PROJECT_REVIVE));
            if (txtRevive != "")
            {
                if (data3.Count > 0)
                {
                    row3 = (PROJECT_REVIVE)data3[0];
                    row3.CurModel = DealModel.Modify;
                    row3.PROJECT_NUMBER = request.PROJECT_NUMBER;
                    row3.BOOKING = txtRevive;
                    row3.MODEL_ID = book_MODEL_ID;
                    row3.BD = request.BD;
                    row3.SD = request.SD;
                    row3.REQUEST_ID = request.REQUEST_ID;
                    row3.DATE_OF_REVIVE = DateTime.Now;
                    if (hfNoliveAnimal == "No live animals")//安排复苏
                    {
                        row3.ANIMAL_NUMBER = "No live animals";
                    }
                    else
                    {
                        row3.ANIMAL_NUMBER = hfAnimal_Number;
                    }
                    bll.Update(row3);

                }
                else
                {

                    row3 = new PROJECT_REVIVE(DealModel.New);
                    row3.PROJECT_NUMBER = request.PROJECT_NUMBER;
                    row3.BOOKING = txtRevive;
                    row3.MODEL_ID = book_MODEL_ID;
                    row3.BD = request.BD;
                    row3.SD = request.SD;
                    row3.REQUEST_ID = request.REQUEST_ID;
                    row3.DATE_OF_REVIVE = DateTime.Now;
                    if (hfNoliveAnimal == "No live animals")//安排复苏
                    {
                        row3.ANIMAL_NUMBER = "No live animals";
                    }
                    else
                    {
                        row3.ANIMAL_NUMBER = hfAnimal_Number;
                    }
                    bll.Update(row3);

                }
            }
            else
            {
                if (data3.Count > 0)
                {
                    row3 = (PROJECT_REVIVE)data3[0];
                    row3.CurModel = DealModel.Delete;
                    bll.Delete(row3);
                }
            }
            #endregion

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


                    int total = context.Request["total"] == "" ? 0 : int.Parse(context.Request["total"]);
                    //if (total - maxdata.Count > 1)//最后一只不能预约
                    //{
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
                    //}
                    //else
                    //{
                    //    msg = "1";
                    //}

                }

                #region email to SD/JSD
                string body = requestEmailgrid(request.DATE_REQUEST_F, request.PROJECT_NUMBER, request.MODEL_ID, request.POTENTIAL_STUDY_SIZE.ToString(), request.CLIENT, request.BD, request.SD, request.TYPE_OF_STUDY);
                string Subject = string.Format("New HuData Animal booking!");
                string title = "<span style=\"color: Red\">The animal " + hfAnimal_Number +" in "+ book_MODEL_ID + " has been booked!</span></br>" + requestEmailtitle(body);
                ParamCollection pl = new ParamCollection();
                pl.Clause = " USER_NAME ='" + row.SD + "' or USER_NAME ='" + row.LEADING_SD + "'";
                BaseList userlist = bll.Select(pl, typeof(SYS_USER));
                foreach(SYS_USER user in userlist)
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
            BaseList bookeddata = bll.Select(pls,typeof(PROJECT_BOOKING));

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

            #region save Further_expanding
            ParamCollection paraList2 = new ParamCollection();
            paraList2.Clause = PROJECT_FURTHER_EXPANDING.ANIMAL_NUMBER_FIELD + "='" + hfAnimal_Number + "'";
            // paraList2.Clause += PROJECT_FURTHER_EXPANDING.PROJECT_NUMBER_FIELD + "='" + request.PROJECT_NUMBER + "' ";
            BaseList data2 = bll.Select(paraList2, typeof(PROJECT_FURTHER_EXPANDING));
            PROJECT_FURTHER_EXPANDING row2 = null;
            if (txtFurther_expanding != "")
            {
                if (data2.Count > 0)
                {
                    row2 = (PROJECT_FURTHER_EXPANDING)data2[0];
                    row2.CurModel = DealModel.Modify;
                    row2.PROJECT_NUMBER = request.PROJECT_NUMBER;
                    row2.BOOKING = txtFurther_expanding;
                    row2.MODEL_ID = book_MODEL_ID;
                    row2.BD = request.BD;
                    row2.SD = request.SD;
                    row2.REQUEST_ID = request.REQUEST_ID;
                    row2.DATE_OF_FURTHER_EXPANDING = DateTime.Now;
                    row2.ANIMAL_NUMBER = hfAnimal_Number;
                    bll.Update(row2);

                }
                else
                {
                    ParamCollection q2 = new ParamCollection();
                    q2.Clause = PROJECT_FURTHER_EXPANDING.MODEL_ID_FIELD + "='" + book_MODEL_ID + "'";
                    q2.Clause += " And " + PROJECT_FURTHER_EXPANDING.ANIMAL_NUMBER_FIELD + " in (select Animal_Number from ANIMAL_INFO where MODEL_ID = '" + book_MODEL_ID + "' )";
                    BaseList maxdata2 = bll.Select(q2, typeof(PROJECT_FURTHER_EXPANDING));
                    int total2 = context.Request["total"] == "" ? 0 : int.Parse(context.Request["total"]);
                    if (total2 - maxdata2.Count > 1)
                    {
                        row2 = new PROJECT_FURTHER_EXPANDING(DealModel.New);
                        row2.PROJECT_NUMBER = request.PROJECT_NUMBER;
                        row2.BOOKING = txtFurther_expanding;
                        row2.MODEL_ID = book_MODEL_ID;
                        row2.DATE_OF_FURTHER_EXPANDING = DateTime.Now;
                        row2.ANIMAL_NUMBER = hfAnimal_Number;
                        row2.REQUEST_ID = request.REQUEST_ID;
                        row2.BD = request.BD;
                        row2.SD = request.SD;
                        bll.Update(row2);
                    }
                    else
                    {
                        msg = "1";
                    }
                }
            }
            else
            {
                if (data2.Count > 0)
                {
                    row2 = (PROJECT_FURTHER_EXPANDING)data2[0];
                    row2.CurModel = DealModel.Delete;
                    bll.Delete(row2);
                }
            }
            #endregion

            context.Response.Write(msg);
        }
        public void CheckRespond(HttpContext context)
        {
            string msg = "";
            string txtDateRespond = context.Request["txtDateRespond"] ?? "";
            if (!RegHelper.IsDateTime(txtDateRespond))
            {
                msg += "Date of Respond is invalid." + "\n";
            }
            context.Response.Write(msg);
        }


        public void SaveEditRequest(HttpContext context)
        {
        }

        public void SaveRequest(HttpContext context)
        {  
    
            string msg = "";
            string hfRequest_id = context.Request["hfRequest_id"] ?? "";
            string txtProjectNumber = context.Request["txtProjectNumber"] ?? "";
            try
            {
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
                        string txtDate_of_1st_responding = context.Request["txtDate_of_1st_responding"] ?? "";
                        string editRemark = context.Request["editRemark"] ?? "";

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

                        SYS_USER userLogin = CacheHelper.getCurrentUser();
                        logrow.EDITOR = userLogin.USER_NAME;
                        bll.Update(logrow);
                        #endregion

                        #region 删除 旧booking、further、revive
                        string editModel_ID = context.Request["txtModel_ID"].Replace("\n", "") ?? "";
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
                        row.CLIENT = context.Request["txtClient"] ?? "";
                        row.DATE_REQUEST = DateTime.Parse(context.Request["txtDate_of_Request"]);
                        row.PROJECT_NUMBER = context.Request["txtProjectNumber"] ?? "";
                        row.PARENT_PROJECT = context.Request["txtParent_Project"] ?? "";
                        row.LEADING_SD = context.Request["ccLeading_SD"] ?? "";
                        row.BD = context.Request["ccBD"] ?? "";
                        row.SD = context.Request["ccSD"] ?? "";
                        row.TYPE_OF_STUDY = context.Request["txtType_of_Study"] ?? "";
                        row.TUMOR_TYPE = context.Request["ddlTumor_Type"] ?? "";
                        row.SUBTYPE1 = context.Request["ddlSubtype1"] ?? "";
                        row.SUBTYPE2 = context.Request["ddlSubtype2"] ?? "";
                        row.MODEL_ID = context.Request["txtModel_ID"].Replace("\n", "") ?? "";
                        row.POTENTIAL_STUDY_SIZE = context.Request["txtPotential_Study_Size"] ?? "";
                        row.SPECIAL_REQUIREMENTS = context.Request["txtRequirements"].Replace("\n", "") ?? "";
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
                            row.CLIENT = context.Request["txtClient"] ?? "";
                            row.DATE_REQUEST = DateTime.Parse(context.Request["txtDate_of_Request"]);
                            row.PROJECT_NUMBER = context.Request["txtProjectNumber"] ?? "";
                            row.PARENT_PROJECT = context.Request["txtParent_Project"] ?? "";
                            row.LEADING_SD = context.Request["ccLeading_SD"] ?? "";
                            row.BD = context.Request["ccBD"] ?? "";
                            row.SD = context.Request["ccSD"] ?? "";
                            row.TYPE_OF_STUDY = context.Request["txtType_of_Study"] ?? "";
                            row.TUMOR_TYPE = context.Request["ddlTumor_Type"] ?? "";
                            row.SUBTYPE1 = context.Request["ddlSubtype1"] ?? "";
                            row.SUBTYPE2 = context.Request["ddlSubtype2"] ?? "";
                            row.MODEL_ID = context.Request["txtModel_ID"].Replace("\n", "") ?? "";
                            row.POTENTIAL_STUDY_SIZE = context.Request["txtPotential_Study_Size"] ?? "";
                            row.SPECIAL_REQUIREMENTS = context.Request["txtRequirements"].Replace("\n", "") ?? "";
                            //row.REQUEST_ONLY = "No";
                            row.SIGNED = "";
                            row.CREATE_OF_DATE = DateTime.Now;
                            row.COMPLETED_MODEL_ID = "";
                            row.RESPONDER = "";
                            row.RESPONDER_ID = "";
                            row.DATE_RESPONDING = DateTime.MinValue;
                            row.HAVE_CONFIRMED = "N";
                            row.ISDELETE = "N";
                            string txtDate_of_1st_responding = context.Request["txtDate_of_1st_responding"] ?? "";
                            string editRemark = context.Request["editRemark"] ?? "";
                            row.REMARK = doTran(editRemark);

                            row.DATE_RESPONDING = txtDate_of_1st_responding == "" ? DateTime.MinValue : DateTime.Parse(txtDate_of_1st_responding);
                            dataRequest.Add(row);
                            bll.UpdateAllByParams(dataRequest);

                        }
                        catch (Exception ex)
                        {
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
                    msg = SendEmail.SendMail_SMTP("html", Subject, title, toMails1, "Send successfully.");
                    msg = SendEmail.SendMail_SMTP("html", Subject, title, toMails2, "Send successfully.");

                    ParamCollection pl = new ParamCollection();
                    pl.Clause = " USER_NAME ='" + row.SD + "' or USER_NAME ='" + row.LEADING_SD + "'";
                    BaseList userlist = bll.Select(pl, typeof(SYS_USER));
                    foreach (SYS_USER user in userlist)
                    {
                        string sd_email = user.EMAIL;
                        string[] toMails = { sd_email };
                        msg = SendEmail.SendMail_SMTP("html", Subject, title, toMails, "Send successfully.");
                    }
                    #endregion
                }
                else
                {
                    msg = "Sub-Project already exists.";
                }
            }
            catch(Exception ex)
            {
                msg = ex.Message.ToString();
            }
            context.Response.Write(msg);


        }

       
        public void SaveStudy(HttpContext context)
        {

           string msg = "";
           try
           {
               string hfMonitor_id = context.Request["hfMonitor_id"] ?? "";
               string strs = context.Request["txtImport"] ?? "";
               string[] str = strs.Split('\n');

               ArrayList listDosing_route = new ArrayList();
               listDosing_route.Add(new string[] { "2.02", "i.p." });
               listDosing_route.Add(new string[] { "2.03", "s.c." });
               listDosing_route.Add(new string[] { "2.04", "i.t." });
               listDosing_route.Add(new string[] { "2.05", "i.m." });
               listDosing_route.Add(new string[] { "2.06", "i.v." });
               listDosing_route.Add(new string[] { "2.07", "p.o." });


               ArrayList listDosing_Schedule = new ArrayList();
               listDosing_Schedule.Add(new string[] { "3", "TID" });
               listDosing_Schedule.Add(new string[] { "2", "BID" });
               listDosing_Schedule.Add(new string[] { "1", "QD" });
               listDosing_Schedule.Add(new string[] { "0.71", "5 Days on and 2 days off" });
               listDosing_Schedule.Add(new string[] { "0.5", "Q2D" });
               listDosing_Schedule.Add(new string[] { "0.33", "Q3D" });
               listDosing_Schedule.Add(new string[] { "0.25", "Q4D" });
               listDosing_Schedule.Add(new string[] { "0.43", "TIW" });
               listDosing_Schedule.Add(new string[] { "0.29", "BIW" });
               listDosing_Schedule.Add(new string[] { "0.14", "QW" });
               listDosing_Schedule.Add(new string[] { "0.07", "Q2W" });
               listDosing_Schedule.Add(new string[] { "0.05", "Q3W" });
               listDosing_Schedule.Add(new string[] { "1", "Once" });
               

               foreach (string txt in str)
               {
                   if (txt != "")
                   {
                       string[] lists = txt.Split('\t');
                       if (lists.Count() == 10 && lists[0] != "Group")
                       {
                           PROJECT_MONITOR_STUDY_DESIGN row = new PROJECT_MONITOR_STUDY_DESIGN();
                           row.CurModel = DealModel.New;
                           row.PROJECT_MONITOR_ID = decimal.Parse(hfMonitor_id);
                           row._GROUP = lists[0];
                           row.MICE_GROUP = lists[1] == "" ? "0" : lists[1];
                           row.TYPE = lists[2];
                           row.ARTICLE = lists[3];
                           row.VEHICLE = lists[4];
                           row.DOSE_LEVEL = lists[5];
                           row.UNIT = lists[6];
                           row.DOSING_ROUTE = lists[7];
                           row.DOSING_PERIOD = "0";
                           if (row.DOSING_ROUTE == "")
                           {
                               row.DOSING_ROUTE_VALUE = 0;
                           }
                           else
                           {
                               foreach (string[] route in listDosing_route)
                               {

                                   if (route[1].ToString() == row.DOSING_ROUTE.Substring(0, 4))
                                   {
                                       row.DOSING_ROUTE_VALUE = double.Parse(route[0].ToString());
                                       break;
                                   }
                               }
                           }
                          
                           if (lists[8] == "")
                           {
                               row.DOSING_SCHEDULE = "";
                               row.DOSING_ROUTE_VALUE = 0;
                               row.DOSING_PERIOD = "0";
                           }
                           else
                           {
                               row.DOSING_SCHEDULE = lists[8].Substring(0, lists[8].IndexOf('*'));
                               foreach (string[] Schedule in listDosing_Schedule)
                               {
                                   if (Schedule[1].ToString() == row.DOSING_SCHEDULE)
                                   {
                                       row.DOSING_SCHEDULE_VALUE = double.Parse(Schedule[0].ToString());
                                       row.DOSING_PERIOD = lists[8].Substring(lists[8].IndexOf('*') + 1, lists[8].Length - Schedule[1].ToString().Length - 1);
                                       break;
                                   }
                               }
                           }
                           row.DOSE_RULE = lists[9];
                           


                           bll.Update(row);
                          
                       }
                       else
                       {
                           msg = "Error";
                       }
                   }
               }
           }
           catch (Exception ex)
           {
               msg = ex.Message.ToString();
           }

           context.Response.Write(msg);
         }

        public void deleteStudy(HttpContext context)
        {
            string msg = "";
            string hfStudy_id = context.Request["hfStudy_id"] ?? "";
            string ids = "";
            string[] hfStudy_ids = hfStudy_id.Split(',');
            foreach (string id in hfStudy_ids)
            {
                ids += "'" + id + "',";
            }
            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" ({0}.{1} in ({2}) )", PROJECT_MONITOR_STUDY_DESIGN.TABLE_NAME, PROJECT_MONITOR_STUDY_DESIGN.PROJECT_MONITOR_STUDY_DESIGN_ID_FIELD, ids.TrimEnd(','));
            BaseList data = bll.Select(paraList, typeof(PROJECT_MONITOR_STUDY_DESIGN));
            foreach (PROJECT_MONITOR_STUDY_DESIGN row in data)
            {
                row.CurModel = DealModel.Delete;
            }
            bll.UpdateAllByParams(data);
            msg = "Delete successfully";
            context.Response.Write(msg);
        }

        public void SaveMonitorAdd(HttpContext context)
        {
            string msg = "";
            int count = 0;
            try
            {
                BaseList newData = bll.Select(typeof(PROJECT_MONITOR_ADD));
                foreach (PROJECT_MONITOR_ADD newRow in newData)
                {
                    ParamCollection paraList = new ParamCollection();
                    paraList.Clause = PROJECT_MONITOR.PROJECT_MONITOR_ID_FIELD + "='" + newRow.PROJECT_MONITOR_ADD_ID + "'";
                    BaseList data = bll.Select(paraList, typeof(PROJECT_MONITOR));
                    if (data.Count > 0)
                    {
                        count++;
                        PROJECT_MONITOR row = (PROJECT_MONITOR)data[0];
                        row.CurModel = DealModel.Modify;


                        //row.PROJECT_NUMBER = newRow.PROJECT_NUMBER;
                        //row.POTENTIAL_STUDY_SIZE = newRow.POTENTIAL_STUDY_SIZE;
                        //row.CV40_TAKE_RATE = newRow.CV40_TAKE_RATE;
                        //row.DOSING_WINDOW = newRow.DOSING_WINDOW;
                        //row.STR_CONSISTENCE = newRow.STR_CONSISTENCE;
                        //row.ESTIMATED_DOI = newRow.ESTIMATED_DOI;
                        //row.ISDELETE = newRow.ISDELETE;
                        //row.NUMBER_OF_ANIMAL_PURCHASE = newRow.NUMBER_OF_ANIMAL_PURCHASE;
                        //row.SD = newRow.SD;
                        //row.JSD = newRow.JSD;
                        //row.DT_GROUP = newRow.DT_GROUP;
                        //row.DT_ID = newRow.DT_ID;
                        //row.DT = newRow.DT;
                        //row.DM = newRow.DM;
                        //row.ROOM = newRow.ROOM;
                        //row.NUMBER_OF_ANIMAL_INOCULATION = newRow.NUMBER_OF_ANIMAL_INOCULATION;
                        //row.TUMOR_MONITOR_SCHEDULE = newRow.TUMOR_MONITOR_SCHEDULE;
                        //row.TUMOR_MONITOR_SCHEDULE2 = newRow.TUMOR_MONITOR_SCHEDULE2;
                        //row.SD_WORKLOAD = newRow.SD_WORKLOAD;
                        //row.DM_WORKLOAD = newRow.DM_WORKLOAD;
                        //row.DT_TEAM_WORKLOAD = newRow.DT_TEAM_WORKLOAD;
                        //row.JSD_WORKLOAD = newRow.JSD_WORKLOAD;
                        //row.FFPE_TUMOR_SAMPLE_NUMBER = newRow.FFPE_TUMOR_SAMPLE_NUMBER;
                        //row.SNAP_FROZNE_SAMPLE_NUMBER = newRow.SNAP_FROZNE_SAMPLE_NUMBER;
                        //row.BLOOD_SAMPLE_NUMBER = newRow.BLOOD_SAMPLE_NUMBER;
                        //row.BLOOD_SAMPLE_TYPE = newRow.BLOOD_SAMPLE_TYPE;
                        //row.SAMPLE_AMOUNT = newRow.SAMPLE_AMOUNT;
                        //row.ESTIMATED_TIME = newRow.ESTIMATED_TIME;
                        //row.ARMS = newRow.ARMS;
                        //row.SIGNED_QUOTATION = newRow.SIGNED_QUOTATION;
                        //row.KICKOFF = newRow.KICKOFF;
                        //row.REGISTER_PROJECT = newRow.REGISTER_PROJECT;
                        //row.BOOKING_ANIMALS = newRow.BOOKING_ANIMALS;
                        //row.ORDER_ANIMAL = newRow.ORDER_ANIMAL;
                        //row.FINALIZE_PROTOCOL = newRow.FINALIZE_PROTOCOL;
                        //row.PROVIDE_SEEDING_ANIMAL = newRow.PROVIDE_SEEDING_ANIMAL;
                        //row.INOCULATION = newRow.INOCULATION;
                        //row.RANDOMIZATION = newRow.RANDOMIZATION;
                        //row.TREATMENT_START = newRow.TREATMENT_START;
                        //row.TREATMENT_FINISHED = newRow.TREATMENT_FINISHED;
                        //row.OBSERVATION_POST_TREATMENT = newRow.OBSERVATION_POST_TREATMENT;
                        row.TISSUE_COLLECTION = newRow.TISSUE_COLLECTION;
                        //row.TISSUE_SENT_OUT = newRow.TISSUE_SENT_OUT;
                        //row.FINAL_DATA_SENT_OUT = newRow.FINAL_DATA_SENT_OUT;
                        //row.DOCUMENT_ARCHIEVE = newRow.DOCUMENT_ARCHIEVE;
                        //row.REPORT_SENT_OUT = newRow.REPORT_SENT_OUT;
                        //row.BALANCE_INVOICE_SENT_OUT = newRow.BALANCE_INVOICE_SENT_OUT;
                        //row.COMPLETION_PROPORTIONS_PER_STUDY = newRow.COMPLETION_PROPORTIONS_PER_STUDY;
                        //row.COMPLETION_PROPORTIONS_PER_PROJECT = newRow.COMPLETION_PROPORTIONS_PER_PROJECT;
                        bll.Update(row);
                    }
                }
                msg = count.ToString();
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
            }

            context.Response.Write(msg);
        }


        public void SaveMonitor(HttpContext context)
        {
            string msg = "";
            try
            {
                string hfMonitor_id = context.Request["hfMonitor_id"] ?? "";
                ParamCollection paraList = new ParamCollection();
                paraList.Clause = PROJECT_MONITOR.PROJECT_MONITOR_ID_FIELD + "='" + hfMonitor_id + "'";
                BaseList data = bll.Select(paraList, typeof(PROJECT_MONITOR));
                PROJECT_MONITOR row = (PROJECT_MONITOR)data[0];

                //ParamCollection q1 = new ParamCollection();
                //q1.Clause = REQUEST.REQUEST_ID_FIELD + " = '" + row.REQUEST_ID + "'";
                //BaseList rdata = bll.Select(q1, typeof(REQUEST));
                //SYS_USER userLogin = CacheHelper.getCurrentUser();
                //string pm = "";
                //if (rdata.Count > 0)
                //{
                //    pm = ((REQUEST)rdata[0]).PM;
                //}
                //if (userLogin.USER_NAME == pm)
                //{

                    if (row.COMPLETION_PROPORTIONS_PER_STUDY != 100)
                    {
                        row.CurModel = DealModel.Modify;
                        //row.DOI = context.Request["txtDOI"] != "" ? DateTime.Parse(context.Request["txtDOI"]) : DateTime.MinValue;
                        //row.DOR = context.Request["txtDOR"] != "" ? DateTime.Parse(context.Request["txtDOR"]) : DateTime.MinValue;
                        //row.DOT = context.Request["txtDOT"] != "" ? DateTime.Parse(context.Request["txtDOT"]) : DateTime.MinValue;
                        //row.DOS = context.Request["txtDOS"] != "" ? DateTime.Parse(context.Request["txtDOS"]) : DateTime.MinValue;
                        if (RegHelper.IsNumber0(context.Request["txtNumber_of_Animal_Purchase"]))
                        {
                            row.NUMBER_OF_ANIMAL_PURCHASE = int.Parse(context.Request["txtNumber_of_Animal_Purchase"]);
                        }
                        //row.SD = context.Request["txtSD"];
                        row.JSD = context.Request["txtJSD"];
                        row.DT_GROUP = context.Request["txtDTgroup"];

                        string DT_ID = context.Request["ddlDT_ID"] ?? "";
                        row.DT_ID = DT_ID;

                        string DT = context.Request["ddlDT"] ?? "";
                        row.DT = DT;
                        row.DM = context.Request["txtDM"];
                        row.ROOM = context.Request["txtROOM"];
                        if (RegHelper.IsNumber0(context.Request["txtNUMBER_OF_ANIMAL_INOCULATION"]))
                        {
                            row.NUMBER_OF_ANIMAL_INOCULATION = int.Parse(context.Request["txtNUMBER_OF_ANIMAL_INOCULATION"]);
                        }

                        row.FFPE_TUMOR_SAMPLE_NUMBER = int.Parse(context.Request["txtFFPE"]);
                        row.SNAP_FROZNE_SAMPLE_NUMBER = int.Parse(context.Request["txtSnap"]);
                        string[] number = context.Request["txtbloodnumber"].Split(',');
                        ArrayList type = new ArrayList();
                        ArrayList numbers = new ArrayList();
                        int sum_number = 0;
                        if (number[0] != "" && number[0] != "0")
                        {
                            type.Add("Plasma");
                            numbers.Add(number[0]);
                            sum_number += int.Parse(number[0]);
                        }
                        if (number[1] != "" && number[1] != "0")
                        {
                            type.Add("Serum");
                            numbers.Add(number[1]);
                            sum_number += int.Parse(number[1]);
                        }
                        if (number[2] != "" && number[2] != "0")
                        {
                            type.Add("Whole Blood");
                            numbers.Add(number[2]);
                            sum_number += int.Parse(number[2]);
                        }
                        row.BLOOD_SAMPLE_NUMBER = string.Join(",", numbers.ToArray());
                        row.BLOOD_SAMPLE_TYPE = string.Join(",", type.ToArray());

                        row.SAMPLE_AMOUNT = row.FFPE_TUMOR_SAMPLE_NUMBER + row.SNAP_FROZNE_SAMPLE_NUMBER + sum_number;
                        row.TUMOR_MONITOR_SCHEDULE = context.Request["txtTumor_Monitor_Schedule"] ?? "";
                        row.TUMOR_MONITOR_SCHEDULE2 = context.Request["txtTumor_Monitor_Schedule2"] ?? "";
                        ParamCollection paralist = new ParamCollection();
                        paralist.Clause = PROJECT_MONITOR_STUDY_DESIGN.PROJECT_MONITOR_ID_FIELD + "='" + row.PROJECT_MONITOR_ID + "'";
                        BaseList arms = bll.Select(paralist, typeof(PROJECT_MONITOR_STUDY_DESIGN));
                        row.ARMS = arms.Count;

                        string cv40 = row.CV40_TAKE_RATE;
                        if (row.CV40_TAKE_RATE.Contains("("))
                        {
                            cv40 = row.CV40_TAKE_RATE.Substring(0, row.CV40_TAKE_RATE.IndexOf("(")).Trim();
                        }

                        //List<PROJECT_MONITOR_DOSING_ROUTE> dataRoute = bll.Select(typeof(PROJECT_MONITOR_DOSING_ROUTE)).ConvertAll<PROJECT_MONITOR_DOSING_ROUTE>(PROJECT_MONITOR_DOSING_ROUTE.Convert);
                        ////计算DM_workload工时
                        //decimal DM_workload = ComputeDM(dataRoute, context, row.POTENTIAL_STUDY_SIZE, cv40, row.ESTIMATED_TIME, row.DOT, row.DOR, row.TUMOR_MONITOR_SCHEDULE);
                        //row.DM_WORKLOAD = DM_workload;

                        ////计算DT_workload工时
                        //decimal DT_workload = ComputeDT(dataRoute, context, row.POTENTIAL_STUDY_SIZE, cv40, row.ESTIMATED_TIME, row.DOT, row.DOR, row.TUMOR_MONITOR_SCHEDULE, row.PROJECT_MONITOR_ID
                        //    , row.FFPE_TUMOR_SAMPLE_NUMBER, row.SNAP_FROZNE_SAMPLE_NUMBER, row.BLOOD_SAMPLE_NUMBER, row.BLOOD_SAMPLE_TYPE);
                        //row.DT_TEAM_WORKLOAD = DT_workload;

                        bll.Update(row);
                    }
                    else
                    {
                        msg = "You can not edit completed project.";
                    }
                //}
                //else {
                //    msg = "You can not save this project.";
                //}
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
            }

            context.Response.Write(msg);
        }

        //计算JSD_workload工时
        //public decimal ComputeJSD(decimal jsd)
        //{ 
        //    decimal JSD_workload=0;
        //    ParamCollection paraList = new ParamCollection();
        //    paraList.Clause = PROJECT_MONITOR. + "='" + mid + "'";
        //    BaseList data = bll.Select(typeof(PROJECT_MONITOR));
        //    JSD_workload = data.Count;
        //    return JSD_workload;
        //}


        //计算DT_workload工时
        public decimal ComputeDT(List<PROJECT_MONITOR_DOSING_ROUTE> data, HttpContext context, string size, string CV40_take_rate, int esit200, DateTime dot, DateTime dor, string tumor, decimal mid, int ffpe, int Snap, int blood, string bloodtype)
        {
            decimal DT_workload = 0;
            //分组前工作量=1.01+1.02+2.12*5+(2.19+*Study size * （1+10%+CV30_take rate)
            double cv40 = double.Parse(CV40_take_rate.Replace("%", "")) / 100;
            double before = SearchRoute(data, "1.01") + SearchRoute(data, "1.02") + SearchRoute(data, "2.12") * 5 + (SearchRoute(data, "2.19") + double.Parse(size) * (1 + 0.1 + cv40));

            //分组工作量=1.01+1.02+study size*1.08
            double group = SearchRoute(data, "1.01") + SearchRoute(data, "1.02") + double.Parse(size) * SearchRoute(data, "1.08");

            //给药期工作量＝group 1 给药工作量+Group2 给药工作量+……Group n 给药工作量+给药准备时间）
            //Groupｎ的给药工作量=mice #/group*（2.08+1.07+根据各组Dosing route选择的单位时间，从2.02-2.07任选）* Dosing schedule*Dosing period*7
            double groupN = 0;
            ParamCollection paraList = new ParamCollection();
            paraList.Clause = PROJECT_MONITOR_STUDY_DESIGN.PROJECT_MONITOR_ID_FIELD + "='" + mid + "'";
            BaseList dataGroup = bll.Select(paraList,typeof(PROJECT_MONITOR_STUDY_DESIGN));
            if (dataGroup.Count > 0)
            {
                foreach (PROJECT_MONITOR_STUDY_DESIGN row in dataGroup)
                {
                    //给药准备时间=（1.01+1.02+2.25 ）* Dosing schedule*Dosing period*7
                    groupN += double.Parse(row.MICE_GROUP) * (SearchRoute(data, "2.08") + SearchRoute(data, "1.07") + SearchRoute(data, row.DOSING_ROUTE_VALUE.ToString())) * row.DOSING_SCHEDULE_VALUE * double.Parse(row.DOSING_PERIOD) * 7
                        + (SearchRoute(data, "1.01") + SearchRoute(data, "1.02") + SearchRoute(data, "2.25")) * row.DOSING_SCHEDULE_VALUE * double.Parse(row.DOSING_PERIOD) * 7;


                }
            }
            //组织收集工作量=肿瘤收集工作量+血样收集工作量+准备工作量
            //肿瘤收集工作量=FFPE tumor sample number *2.15+ (Snap frozen sample number *2.13+2.31) + (FFPE tumor sample number +snap frozen sample number)/2*2.12 
            //血样收集工作量=blood sample number *2.16 + 2.18* blood sample type + 2.31
            //准备工作量=2.11+1.01+1.02
            //收尾工作量=study size*2.10+1.01+1.02
            double tumorOrg = ffpe * SearchRoute(data, "2.15") + (Snap * SearchRoute(data, "2.13") + SearchRoute(data, "2.31")) + (ffpe + Snap) / 2 * SearchRoute(data, "2.12");
            int bloodtype1 = 0;
            if (bloodtype == "Plasma" || bloodtype == "Serum")
            {
                bloodtype1 = 1;
            }
            double bloodOrg = blood * SearchRoute(data, "2.16") + SearchRoute(data, "2.18") * bloodtype1 + SearchRoute(data, "2.31");
            double prepareOrg = SearchRoute(data, "2.11") + SearchRoute(data, "1.01") + SearchRoute(data, "1.02");
            double endorg = double.Parse(size) * SearchRoute(data, "2.10") + SearchRoute(data, "1.01") + SearchRoute(data, "1.02");
            double organize = tumorOrg + bloodOrg + prepareOrg;


            DT_workload = decimal.Parse(((before + group + groupN + organize + endorg) / 60).ToString());

            //总工作量=分组前工作量before+分组工作量group+给药期工作量groupN+组织收集工作量+收尾工作量

            return DT_workload;
        }

        //计算DM_workload工时
        public decimal ComputeDM(List<PROJECT_MONITOR_DOSING_ROUTE> data,HttpContext context, string size, string CV40_take_rate, int esit200, DateTime dot, DateTime dor, string tumor)
        {
            decimal DM_workload = 0;
            try
            {
                //分组前工作量=Study size*（1+10%+CV30_take_rate）*（分组前量瘤次数*（1.04+2.08））+分组前量瘤次数*（1.01+1.02+1.09）+Study size*（1+10%+CV30_take_rate）*1.03
                //分组前量瘤次数= Esitimated_time _to_200mm3/7
                double cv40 = double.Parse(CV40_take_rate.Replace("%", "")) / 100;
                double before = double.Parse(size) * (1 + 0.1 + cv40) * (esit200 / 7 * (SearchRoute(data, "1.04") + SearchRoute(data, "2.08")))
                    + esit200 / 7 * (SearchRoute(data, "1.01") + SearchRoute(data, "1.02") + SearchRoute(data, "1.09"))
                    + double.Parse(size) * (1 + 0.1 + cv40) * SearchRoute(data, "1.03");

                //分组后工作量=（DOT-DOR）/7*Tumor_Monitor_Schedule *（1.01+1.02+1.09+（1.05+2.08）*Study size）
                int SCHEDULE = 0;
                if (tumor == "QW")
                {
                    SCHEDULE = 1;
                }
                else if (tumor == "BIW")
                {
                    SCHEDULE = 2;
                }
                else if (tumor == "TIW")
                {
                    SCHEDULE = 3;
                }
                double after = (dot - dor).Days / 7 * SCHEDULE * (SearchRoute(data, "1.01") + SearchRoute(data, "1.02") + SearchRoute(data, "1.09") + (SearchRoute(data, "1.05") + SearchRoute(data, "2.08")) * double.Parse(size));
                //总工作量=分组前工作量+分组后工作量。
                DM_workload = decimal.Parse(((before + after) / 60).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DM_workload;
        }
        public double SearchRoute(List<PROJECT_MONITOR_DOSING_ROUTE> data, string code)
        {
            PROJECT_MONITOR_DOSING_ROUTE ds = data.Find(delegate(PROJECT_MONITOR_DOSING_ROUTE perm) { return perm.CODE == code; });
            if (ds != null)
            {
                return double.Parse(ds.UNIT_TIME);
            }
            else {
                return 0;
            }
        }

        public void DeleteMonitor(HttpContext context)
        {
            string msg = "";
            string hfMonitor_id = context.Request["MonitorID"] ?? "";
            string ids = "";
            string[] hfMonitor_ids = hfMonitor_id.Split(',');
            foreach (string id in hfMonitor_ids)
            {
                ids += "'" + id + "',";
            }
            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" ({0}.{1} in ({2}) )", PROJECT_MONITOR.TABLE_NAME, PROJECT_MONITOR.PROJECT_MONITOR_ID_FIELD, ids.TrimEnd(','));

            BaseList data = bll.Select(paraList, typeof(PROJECT_MONITOR));
            foreach (PROJECT_MONITOR row in data)
            {
                row.CurModel = DealModel.Modify;
                row.ISDELETE = "Y";
            }
            bll.UpdateAllByParams(data);
            msg = "Save successfully";
            context.Response.Write(msg);
        }

        public void deleteNewModel(HttpContext context)
        {
            string msg = "";
            string delNewModel_ID = context.Request["delNewModel_ID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (NEWMODEL_ID = '{0}' )", delNewModel_ID);

            BaseList data = bll.Select(paraList, typeof(NEWMODEL));
            if (data.Count > 0)
            {
                NEWMODEL row = (NEWMODEL)data[0];
                row.CurModel = DealModel.Delete;
                bll.Delete(row);

                BaseList data_log = bll.Select(paraList, typeof(NEWMODEL_LOG));
                foreach(NEWMODEL_LOG del in data_log)
                {
                    del.CurModel = DealModel.Delete;
                    bll.Delete(del);
                }

                msg = "Delete successfully";
            }
            context.Response.Write(msg);
        }

        public void deleteSpecimenStocks2(HttpContext context)
        {
            string msg = "";
            string[] aa = {"CrownBio:PDX-TC:Freezer03:Rack07"
                          };
            foreach (string a in aa)
            {
                ParamCollection pl = new ParamCollection();
                pl.Clause += SPECIMEN_STOCK.LOCATION_ID_FIELD + " like '" + a + "%'";
                BaseList all = bll.Select(pl, typeof(SPECIMEN_STOCK));

                string ids = "";
                foreach (SPECIMEN_STOCK id in all)
                {
                    ids += "'" + id.SPECIMEN_STOCK_ID + "',";
                }
                ParamCollection paraList = new ParamCollection();
                paraList.Clause += string.Format(" ({0}.{1} in ({2}) )", SPECIMEN_STOCK.TABLE_NAME, SPECIMEN_STOCK.SPECIMEN_STOCK_ID_FIELD, ids.TrimEnd(','));

                BaseList data = bll.Select(paraList, typeof(SPECIMEN_STOCK));
                foreach (SPECIMEN_STOCK row in data)
                {
                    row.CurModel = DealModel.Delete;
                    // 递归Location的Used_Space-1
                    #region
                    BaseList updateData = new BaseList();
                    ParamCollection query1 = new ParamCollection();
                    query1.Clause = LOCATION.AID_FIELD + " like '" + row.LOCATION_ID + "%'";
                    BaseList modfydata = bll.Select(query1, typeof(LOCATION));
                    if (modfydata.Count > 0)
                    {
                        LOCATION oldRow = (LOCATION)modfydata[0];
                        oldRow.CurModel = DealModel.Modify;
                        oldRow.USED_SPACE = oldRow.USED_SPACE - 1;
                        updateData.Add(oldRow);

                        modfy_location(oldRow, updateData);
                    }
                    bll.UpdateAllByParams(updateData);
                    #endregion

                }
                bll.Delete(data);
            }
            msg = "Delete successfully";
            context.Response.Write(msg);
        }


        public void deleteSpecimenStocks(HttpContext context)
        {
            string msg = "";
            string delSpecimen_Stock_ID = context.Request["delSpecimen_Stock_ID"] ?? "";
            string ids = "";
            string[] hfid = delSpecimen_Stock_ID.Split(',');
            foreach (string id in hfid)
            {
                ids += "'" + id + "',";
            }
            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" ({0}.{1} in ({2}) )", SPECIMEN_STOCK.TABLE_NAME, SPECIMEN_STOCK.SPECIMEN_STOCK_ID_FIELD, ids.TrimEnd(','));

            BaseList data = bll.Select(paraList, typeof(SPECIMEN_STOCK));
            foreach (SPECIMEN_STOCK row in data)
            {
                row.CurModel = DealModel.Delete;
                // 递归Location的Used_Space-1
                #region
                BaseList updateData = new BaseList();
                ParamCollection query1 = new ParamCollection();
                query1.Clause = LOCATION.AID_FIELD + " like '" + row.LOCATION_ID + "%'";
                BaseList modfydata = bll.Select(query1, typeof(LOCATION));
                if (modfydata.Count > 0)
                {
                    LOCATION oldRow = (LOCATION)modfydata[0];
                    oldRow.CurModel = DealModel.Modify;
                    oldRow.USED_SPACE = oldRow.USED_SPACE - 1;
                    updateData.Add(oldRow);

                    modfy_location(oldRow, updateData);
                }
                bll.UpdateAllByParams(updateData);
                #endregion
               
            }
            bll.Delete(data);
            msg = "Delete successfully";
            context.Response.Write(msg);
        }
        /// <summary> ///递归Location的Used_Space-1
        /// </summary>
        /// <param name="context"></param>
        public void modfy_location(LOCATION rows, BaseList updateData)
        {
            string[] pid = rows.P_ID.Split(';');
            if (pid.Length > 1)
            {
                string id = pid[1];
                ParamCollection query1 = new ParamCollection();
                query1.Clause = LOCATION.LOCATION_ID_FIELD + " = '" + id + "'";
                BaseList data = bll.Select(query1, typeof(LOCATION));
                if (data.Count > 0)
                {
                    LOCATION oldRow = (LOCATION)data[0];
                    oldRow.CurModel = DealModel.Modify;
                    oldRow.USED_SPACE = oldRow.USED_SPACE - 1;
                    updateData.Add(oldRow);
                    modfy_location(oldRow, updateData);
                }
            }
        }

        public void deleteValidation(HttpContext context)
        {
            string msg = "";
            string delValidation_ID = context.Request["delValidation_ID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (Validation_ID = '{0}' )", delValidation_ID);

            BaseList data = bll.Select(paraList, typeof(VALIDATION));
            if (data.Count > 0)
            {
                VALIDATION row = (VALIDATION)data[0];
                row.CurModel = DealModel.Delete;
                bll.Delete(row);
                BaseList data_log = bll.Select(paraList, typeof(VALIDATION_LOG));
                foreach (VALIDATION_LOG del in data_log)
                {
                    del.CurModel = DealModel.Delete;
                    bll.Delete(del);
                }
                msg = "Delete successfully";
            }
            context.Response.Write(msg);
        }

        public void deleteEndModels(HttpContext context)
        {
            string msg = "";
            string delEndModels_ID = context.Request["delEndModels_ID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (EndModels_ID = '{0}' )", delEndModels_ID);

            BaseList data = bll.Select(paraList, typeof(ENDMODELS));
            if (data.Count > 0)
            {
                ENDMODELS row = (ENDMODELS)data[0];
                row.CurModel = DealModel.Delete;
                bll.Delete(row);

                msg = "Delete successfully";
            }
            context.Response.Write(msg);
        }

        public void deleteValidationStatus_Huprime(HttpContext context)
        {
            string msg = "";
            string delValidationStatus_Huprime_ID = context.Request["delValidationStatus_Huprime_ID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (ValidationStatus_Huprime_ID = '{0}' )", delValidationStatus_Huprime_ID);

            BaseList data = bll.Select(paraList, typeof(VALIDATIONSTATUS_HUPRIME));
            if (data.Count > 0)
            {
                VALIDATIONSTATUS_HUPRIME row = (VALIDATIONSTATUS_HUPRIME)data[0];
                row.CurModel = DealModel.Delete;
                bll.Delete(row);

                msg = "Delete successfully";
            }
            context.Response.Write(msg);
        }

        
        public void deleteRevival(HttpContext context)
        {
            string msg = "";
            string delRevival_ID = context.Request["delRevival_ID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (Revival_ID = '{0}' )", delRevival_ID);

            BaseList data = bll.Select(paraList, typeof(REVIVAL));
            if (data.Count > 0)
            {
                REVIVAL row = (REVIVAL)data[0];
                row.CurModel = DealModel.Delete;
                bll.Delete(row);

                msg = "Delete successfully";
            }
            context.Response.Write(msg);
        }
        
        public void deleteGeneticTest(HttpContext context)
        {
            string msg = "";
            string delGeneticTest_ID = context.Request["delGeneticTest_ID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (GeneticTest_ID = '{0}' )", delGeneticTest_ID);

            BaseList data = bll.Select(paraList, typeof(GENETICTEST));
            if (data.Count > 0)
            {
                GENETICTEST row = (GENETICTEST)data[0];
                row.CurModel = DealModel.Delete;
                bll.Delete(row);

                msg = "Delete successfully";
            }
            context.Response.Write(msg);
        }

        public void deleteValidationStatus_Hukime(HttpContext context)
        {
            string msg = "";
            string delValidationStatus_Hukime_ID = context.Request["delValidationStatus_Hukime_ID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (ValidationStatus_Hukime_ID = '{0}' )", delValidationStatus_Hukime_ID);

            BaseList data = bll.Select(paraList, typeof(VALIDATIONSTATUS_HUKIME));
            if (data.Count > 0)
            {
                VALIDATIONSTATUS_HUKIME row = (VALIDATIONSTATUS_HUKIME)data[0];
                row.CurModel = DealModel.Delete;
                bll.Delete(row);

                msg = "Delete successfully";
            }
            context.Response.Write(msg);
        }

        public void deleteRoutineMaintain(HttpContext context)
        {
            string msg = "";
            string delRoutineMaintain_ID = context.Request["delRoutineMaintain_ID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (RoutineMaintain_ID = '{0}' )", delRoutineMaintain_ID);

            BaseList data = bll.Select(paraList, typeof(ROUTINEMAINTAIN));
            if (data.Count > 0)
            {
                ROUTINEMAINTAIN row = (ROUTINEMAINTAIN)data[0];
                row.CurModel = DealModel.Delete;
                bll.Delete(row);

                msg = "Delete successfully";
            }
            context.Response.Write(msg);
        }
        
        public void deleteRequest(HttpContext context)
        {
            string msg = "";
            string delRequest_id = context.Request["delRequest_id"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (REQUEST_ID = '{0}' )", delRequest_id);

            BaseList data = bll.Select(paraList, typeof(REQUEST));
            if (data.Count > 0)
            {
                REQUEST row = (REQUEST)data[0];
                row.CurModel = DealModel.Modify;
                row.ISDELETE = "Y";
                bll.Update(row);
                //BaseList data1 = bll.Select(paraList, typeof(PROJECT_BOOKING));
                //foreach (PROJECT_BOOKING row1 in data1)
                //{
                //    row1.CurModel = DealModel.Delete;
                //}
                //BaseList data2 = bll.Select(paraList, typeof(PROJECT_FURTHER_EXPANDING));
                //foreach (PROJECT_FURTHER_EXPANDING row2 in data2)
                //{
                //    row2.CurModel = DealModel.Delete;
                //}
                //BaseList data3 = bll.Select(paraList, typeof(PROJECT_MONITOR));
                //foreach (PROJECT_MONITOR row3 in data3)
                //{
                //    row3.CurModel = DealModel.Delete;
                //}
                //BaseList data4 = bll.Select(paraList, typeof(REQUEST_LOG));
                //foreach (REQUEST_LOG row4 in data4)
                //{
                //    row4.CurModel = DealModel.Delete;
                //}

                //bll.UpdateMultiData(new BaseList[] { data, data1, data2, data3, data4 });
                msg = "Delete successfully";
            }
            context.Response.Write(msg);
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



        public void SaveAnimal_Handover(HttpContext context)
        {
            string msg = "";
            string hfMid = context.Request["hfMid"] ?? "";
            string hfRid = context.Request["hfRid"] ?? "";


            ANIMAL_HANDOVER row = null;
            BaseList exist = new BaseList();

            ParamCollection query1 = new ParamCollection();
            query1.Clause = ANIMAL_HANDOVER.MODEL_ID_FIELD + "='" + hfMid + "' and " + ANIMAL_HANDOVER.REQUEST_ID_FIELD + " = '" + hfRid + "'";
            exist = bll.Select(query1, typeof(ANIMAL_HANDOVER));

            if (exist.Count == 0)
            {
                row = new ANIMAL_HANDOVER(DealModel.New);
                row.MODEL_ID = hfMid;
                row.REQUEST_ID = hfRid;

            }
            else
            {
                row = (ANIMAL_HANDOVER)exist[0];
                row.CurModel = DealModel.Modify;

            }
            row.TISSUE_BATCH = context.Request["lblTissue_Batch"] ?? "";
            row.DATE_OF_TISSUE = context.Request["txtDate_of_Tissue"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDate_of_Tissue"]);
            row.ANIMAL_BY_TISSUE = context.Request["txtAnimal_by_Tissue"] ?? "";
            row.LEADER = context.Request["lblLeader"] ?? "";



            int rn = 0;
            int pn = 0;


            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Model_ID", hfMid)
                    ,new SqlParameter("@PN", " ")    };
            DataTable dt = ojbReportRule.GetGrid("GetAnimalStatus", para);
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
            DataRow[] drs = dt.Select("Request_ID = '" + id + "'");
            DataTable Adata = dt.Clone();
            for (int i = 0; i < drs.Length; i++)
            {
                Adata.ImportRow((DataRow)drs[i]);
            }

            ArrayList animal_number = new ArrayList();
            string txtAnimal = context.Request["lblAnimal_by_Live"] ?? "";
            if (Adata.Rows.Count > 0)
            {
                #region ANIMAL_INFO
                DataRow dr = Adata.Rows[0];
                row.SOURCE_PROJECT = dr["Source_Project"].ToString();
                row.MODELBATCH1 = dr["MODEL_ID"].ToString() + "-" + dr["Rn"].ToString() + dr["Pn"].ToString() + "-" + DateTime.Parse(dr["DOI"].ToString()).ToString("yyyyMMdd");
                if (RegHelper.IsNumber0(dr["Rn"].ToString().Replace("R", "")))
                {
                    rn = int.Parse(dr["Rn"].ToString().Replace("R", ""));
                }
                if (RegHelper.IsNumber0(dr["Pn"].ToString().Replace("P", "")))
                {
                    pn = int.Parse(dr["Pn"].ToString().Replace("P", ""));
                }
                row.IVC = dr["Location_of_live_animal"].ToString() + "-" + dr["Animal_Room_Number"].ToString() + "-" + dr["IVC_Location"].ToString();

                #endregion

                #region PROJECT_BOOKING
                DataRow drr = Adata.Rows[0];
                row.RECEIVING_PROJECT = drr["Animal_Booking"].ToString();

                foreach (DataRow dr2 in Adata.Rows)
                {
                    animal_number.Add(dr2["Animal_Number"]);
                }

                row.ANIMAL_BY_LIVE = string.Join(",", animal_number.ToArray());
                #endregion
            }

            else if (txtAnimal != "")
            {
                foreach (string dr2 in txtAnimal.Split(','))
                {
                    animal_number.Add(dr2);
                }
                row.ANIMAL_BY_LIVE = string.Join(",", animal_number.ToArray());
            }

            #region 关联number
            row.HEALTHY_AND_ALIVE = context.Request["txtAlive"] ?? "";
            string[] alive = row.HEALTHY_AND_ALIVE.Split(',');
            foreach (string str in alive)
            {
                animal_number.Remove(str);
            }
            if (row.HEALTHY_AND_ALIVE != "")
            {
                row.ANIMAL_DEAD = string.Join(",", animal_number.ToArray());
            }
            else
            {
                row.ANIMAL_DEAD = "";
            }
            List<string> alive1 = alive.ToList();
            row.INOCULATION_USED = context.Request["txtInoculation_Used"] ?? "";
            string[] used = row.INOCULATION_USED.Split(',');
            foreach (string str in used)
            {
                alive1.Remove(str);
            }
            if (row.INOCULATION_USED != "")
            {
                row.TISSUE_COLLECTION = string.Join(",", alive1.ToArray());
            }
            else
            {
                row.TISSUE_COLLECTION = "";
            }
            #endregion





            row.DATE_OF_DELIVER = context.Request["txtDeliver"].ToString();
            row.DATE_OF_RECEIVE = context.Request["txtReceive"].ToString();
          
            #region PROJECT_MONITOR
            ParamCollection pl4 = new ParamCollection();
            pl4.Clause = PROJECT_MONITOR.MODEL_ID_FIELD + "='" + hfMid + "' and " + PROJECT_MONITOR.REQUEST_ID_FIELD + "='" + hfRid + "'";
            BaseList MData = bll.Select(pl4, typeof(PROJECT_MONITOR));
            if (MData.Count > 0)
            {
                PROJECT_MONITOR Mrow = (PROJECT_MONITOR)MData[0];

                ParamCollection pl5 = new ParamCollection();
                pl5.Clause = REQUEST.REQUEST_ID_FIELD + "='" + Mrow.REQUEST_ID + "'";
                BaseList rData = bll.Select(pl5, typeof(REQUEST));
                if (rData.Count > 0)
                {
                    row.JSD = ((REQUEST)rData[0]).SD;
                }
                else
                {
                    row.JSD = "";
                }
                row.EXPECTED_DATE_TO_SUPPORT = Mrow.ESTIMATED_DOI;

                if (row.MODELBATCH1 != "" || row.MODELBATCH1 != null)
                {
                    string[] strs = row.MODELBATCH1.Split('-');
                    rn = Convert.ToInt32(strs[1].Substring(1, strs[1].IndexOf('P') - 1));
                    pn = Convert.ToInt32(strs[1].Substring(strs[1].IndexOf('P') + 1, strs[1].Length - strs[1].IndexOf('P') - 1));
                }
                if (RegHelper.IsDateTime(Mrow.INOCULATION))
                {
                    row.MODELBATCH2 = hfMid + "-R" + rn + "P" + (pn + 1).ToString() + "-" + DateTime.Parse(Mrow.INOCULATION).ToString("yyyyMMdd");
                }
                if (row.DATE_OF_DELIVER != "")
                {
                    Mrow.CurModel = DealModel.Modify;
                    Mrow.PROVIDE_SEEDING_ANIMAL = row.DATE_OF_DELIVER.ToString();
                    bll.Update(Mrow);
                }
                else
                {
                    Mrow.CurModel = DealModel.Modify;
                    Mrow.PROVIDE_SEEDING_ANIMAL = "";
                    bll.Update(Mrow);
                }
            }
            #endregion


         
            bll.Update(row);
            context.Response.Write(msg);
        }


        public void SavePiggybacked(HttpContext context)
        {
            string msg = "";
            string hfMid = context.Request["hfMid"] ?? "";
            string hfRid = context.Request["hfRid"] ?? "";
            string hfsubProject = context.Request["hfsubProject"] ?? "";
            string txtPiggybacked = context.Request["txtPiggybacked"] ?? "";
            PIGGYBACKED row = null;
            BaseList exist = new BaseList();

            ParamCollection query1 = new ParamCollection();
            query1.Clause = PIGGYBACKED.MODEL_ID_FIELD + "='" + hfMid + "' and " + PIGGYBACKED.REQUEST_ID_FIELD + " = '" + hfRid + "'";
            exist = bll.Select(query1, typeof(PIGGYBACKED));
            if (txtPiggybacked != "")
            {
                if (exist.Count == 0)
                {
                    row = new PIGGYBACKED(DealModel.New);
                    row.MODEL_ID = hfMid;
                    row.REQUEST_ID = decimal.Parse(hfRid);
                }
                else
                {
                    row = (PIGGYBACKED)exist[0];
                    row.CurModel = DealModel.Modify;
                }
                row.PIGGYBACKED_BY = txtPiggybacked;
                bll.Update(row);
            }
            else
            {
                if (exist.Count > 0)
                {
                    row = (PIGGYBACKED)exist[0];
                    row.CurModel = DealModel.Delete;
                    bll.Delete(row);
                }
            }
            
            context.Response.Write(msg);
        }

        public void SavePM_Edit(HttpContext context)
        {
            string msg = "";
            string hfRequest_id = context.Request["hfRequest_id"] ?? "";
            string signed = context.Request["SIGNED"] ?? "";

            ParamCollection query1 = new ParamCollection();
            query1.Clause = REQUEST.REQUEST_ID_FIELD + " = '" + hfRequest_id + "'";

            BaseList data = bll.Select(query1, typeof(REQUEST));
            if (data.Count > 0)
            {
                REQUEST row = (REQUEST)data[0];

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

                SYS_USER userLogin = CacheHelper.getCurrentUser();
                logrow.EDITOR = userLogin.USER_NAME;
                bll.Update(logrow);
                #endregion


              
                row.CurModel = DealModel.Modify;
                row.CLIENT = context.Request["editSponsor"] ?? "";
                row.PM = context.Request["ccPM"] ?? "";
                row.SIGNED = signed;
                row.CREATE_OF_DATE = DateTime.Now;
               
                bll.Update(row);


                #region save monitor
                DataTable dataAll = new DataTable();
                if (signed == "Signed")//更新PROJECT_MONITOR,yes后能不能回到no？
                {
                    if (row.MODEL_ID != "" || row.COMPLETED_MODEL_ID != "")
                    {
                        string mid = row.MODEL_ID;
                        if (row.COMPLETED_MODEL_ID != "")
                        {
                            mid += "," + row.COMPLETED_MODEL_ID;
                        }
                        SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Model_ID", mid.TrimStart(','))
                        ,new SqlParameter("@REQUEST_ID",row.REQUEST_ID)
                        };
                        DataTable data1 = ojbReportRule.GetGrid("GetProjectMonitor-1", para);
                        dataAll.Merge(data1);

                    }
                    else
                    {
                         SqlParameter[] para = new SqlParameter[] { 
                        new SqlParameter("@REQUEST_ID",row.REQUEST_ID) };
                        DataTable data2 = ojbReportRule.GetGrid("GetProjectMonitor-3", para);
                        dataAll.Merge(data2);
                    }

                    List<PDXMODEL_INFO> pdxmodels = bll.Select(typeof(PDXMODEL_INFO)).ConvertAll<PDXMODEL_INFO>(PDXMODEL_INFO.Convert);
                    dataAll.Columns.Add("Estimated_DOI");
                    dataAll.Columns.Add("Isdelete");
                    dataAll.Columns.Add("DOI");
                    dataAll.Columns.Add("DOR");
                    dataAll.Columns.Add("DOT");
                    dataAll.Columns.Add("SD");
                    dataAll.Columns.Add("JSD");
                    dataAll.Columns.Add("DT");
                    dataAll.Columns.Add("DM");
                    dataAll.Columns.Add("Room");
                    dataAll.Columns.Add("Number_of_Animal_Inoculation", typeof(Int32));
                    dataAll.Columns.Add("Tumor_Monitor_Schedule");
                    dataAll.Columns.Add("Tumor_Monitor_Schedule2");
                    dataAll.Columns.Add("SD_Workload");
                    dataAll.Columns.Add("DM_Workload");
                    dataAll.Columns.Add("DT_team_Workload");
                    dataAll.Columns.Add("JSD_Workload");
                    dataAll.Columns.Add("Observation", typeof(Int32));
                    dataAll.Columns.Add("FFPE_Tumor_Sample_Number", typeof(Int32));
                    dataAll.Columns.Add("Snap_Frozne_Sample_Number", typeof(Int32));
                    dataAll.Columns.Add("Blood_Sample_Number", typeof(Int32));
                    dataAll.Columns.Add("Blood_Sample_Type", typeof(Int32));
                    dataAll.Columns.Add("Estimated_time", typeof(Int32));



                    dataAll.Columns.Add("Signed_Quotation");
                    dataAll.Columns.Add("Kickoff");
                    dataAll.Columns.Add("Register_Project");
                    dataAll.Columns.Add("Booking_Animals");
                    dataAll.Columns.Add("Order_Animal");
                    dataAll.Columns.Add("Finalize_Protocol");
                    dataAll.Columns.Add("Provide_Seeding_Animal");
                    dataAll.Columns.Add("Inoculation");
                    dataAll.Columns.Add("Randomization");
                    dataAll.Columns.Add("Treatment_Start");
                    dataAll.Columns.Add("Treatment_Finished");
                    dataAll.Columns.Add("Observation_Post_Treatment");
                    dataAll.Columns.Add("Tissue_Collection");
                    dataAll.Columns.Add("Tissue_Sent_Out");
                    dataAll.Columns.Add("Final_Data_Sent_Out");
                    dataAll.Columns.Add("Document_Archieve");
                    dataAll.Columns.Add("Report_Sent_Out");
                    dataAll.Columns.Add("Balance_Invoice_Sent_Out");
                    dataAll.Columns.Add("Completion_Proportions_Per_Study", typeof(Int32));
                    dataAll.Columns.Add("Completion_Proportions_Per_Project", typeof(Int32));
                    dataAll.Columns.Add("Complete_Study");
                    foreach (DataRow drr in dataAll.Rows)
                    {
                        SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Model_ID", drr["Model_ID"]) 
                             ,new SqlParameter("@PN", row.PROJECT_NUMBER)   };
                        DataTable dataAnimal = ojbReportRule.GetGrid("GetAnimalStatus", para);
                        if (dataAnimal.Rows.Count > 0)
                        {
                            DataRow dr = dataAnimal.Rows[0];//取第一个DOT
                            #region 计算Estimated_DOT

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
                            drr["Estimated_DOI"] = dot;

                            #endregion
                        }
                        drr["Isdelete"] = "N";
                        drr["DOI"] = DateTime.MinValue;
                        drr["DOR"] = DateTime.MinValue;
                        drr["DOT"] = DateTime.MinValue;
                        drr["SD"] = "";
                        drr["JSD"] = "";
                        drr["DT"] = "";
                        drr["DM"] = "";
                        drr["Room"] = "";
                        drr["Number_of_Animal_Inoculation"] = 0;
                        drr["Tumor_Monitor_Schedule"] = "";
                        drr["Tumor_Monitor_Schedule2"] = 0;
                        drr["SD_Workload"] = 0;
                        drr["DM_Workload"] = 0;
                        drr["DT_team_Workload"] = 0;
                        drr["JSD_Workload"] = 0;
                        drr["Observation"] = 0;
                        drr["FFPE_Tumor_Sample_Number"] = 0;
                        drr["Snap_Frozne_Sample_Number"] = 0;
                        drr["Blood_Sample_Number"] = 0;
                        drr["Blood_Sample_Type"] = 0;
                        drr["Estimated_time"] = 0;
                        drr["Signed_Quotation"] = "";
                        drr["Kickoff"] = "";
                        drr["Register_Project"] = row.DATE_REQUEST_F;
                        drr["Booking_Animals"] = "";
                        drr["Order_Animal"] = "";
                        drr["Finalize_Protocol"] = "";
                        drr["Provide_Seeding_Animal"] = "";
                        drr["Inoculation"] = "";
                        drr["Randomization"] = "";
                        drr["Treatment_Start"] = "";
                        drr["Treatment_Finished"] = "";
                        drr["Observation_Post_Treatment"] = "";
                        drr["Tissue_Collection"] = "";
                        drr["Tissue_Sent_Out"] = "";
                        drr["Final_Data_Sent_Out"] = "";
                        drr["Document_Archieve"] = "";
                        drr["Report_Sent_Out"] = "";
                        drr["Balance_Invoice_Sent_Out"] = "";
                        drr["Completion_Proportions_Per_Study"] = 0;
                        drr["Completion_Proportions_Per_Project"] = 0;
                        drr["Complete_Study"] = "";
                       
                    }
                    ArrayList columns = new ArrayList();
                    foreach (DataColumn dc in dataAll.Columns)
                    {
                        columns.Add(dc.ColumnName);
                    }

                    ParamCollection paraList1 = new ParamCollection();
                    paraList1.Clause = PROJECT_MONITOR.REQUEST_ID_FIELD + "='" + hfRequest_id + "'";
                    BaseList oldData = bll.Select(paraList1, typeof(PROJECT_MONITOR));
                    if (oldData.Count > 0)
                    {
                        foreach (PROJECT_MONITOR dr in oldData)
                        {
                            dr.CurModel = DealModel.Delete;//旧的先删
                        }
                        DataTable newdt = new DataTable();
                        newdt = dataAll.Clone();
                        foreach (DataRow dr in dataAll.Rows)
                        {
                            List<PROJECT_MONITOR> list = oldData.FindAll(dr["Model_ID"].ToString()).ConvertAll<PROJECT_MONITOR>(PROJECT_MONITOR.Convert);
                            if (list.Count > 0)
                            {
                                list[0].CurModel = DealModel.Modify;//原有的保留
                                list[0].PROJECT_NUMBER = dr["PROJECT_NUMBER"].ToString();
                                list[0].POTENTIAL_STUDY_SIZE = dr["Potential_Study_Size"].ToString();
                            }
                            else
                            {
                               //新增的
                                newdt.ImportRow(dr);
                            }
                        }
                        bll.UpdateAllByParams(oldData);
                        ojbReportRule.InsertBigSql(newdt, columns, "PROJECT_MONITOR");
                    }
                    else
                    {
                        ojbReportRule.InsertBigSql(dataAll, columns, "PROJECT_MONITOR");
                    }
                }
                #endregion


                msg = "Save successfully";
            }
            context.Response.Write(msg);
        }


        public void Complete_study(HttpContext context)
        {
            string msg = "";
            string hfMonitor_id = context.Request["hfMonitor_id"] ?? "";
            ParamCollection query1 = new ParamCollection();
            query1.Clause = PROJECT_MONITOR.PROJECT_MONITOR_ID_FIELD + " = '" + hfMonitor_id + "'";

            BaseList data = bll.Select(query1, typeof(PROJECT_MONITOR));
            if (data.Count > 0)
            {
                PROJECT_MONITOR row = (PROJECT_MONITOR)data[0];
                row.CurModel = DealModel.Modify;
                row.COMPLETE_STUDY = "Yes";
                bll.Update(row);

                #region 删除request里的completed Model ID
                ParamCollection paralist = new ParamCollection();
                paralist.Clause = REQUEST.REQUEST_ID_FIELD + "='" + row.REQUEST_ID + "'";
                BaseList request = bll.Select(paralist, typeof(REQUEST));
                if (request.Count > 0)
                {
                    REQUEST rowRequest = (REQUEST)request[0];
                    rowRequest.CurModel = DealModel.Modify;
                    string[] list = rowRequest.MODEL_ID.Split(',');
                    List<string> alist = list.ToList();
                    alist.Remove(row.MODEL_ID);
                    rowRequest.MODEL_ID = string.Join(",", alist);
                    if (rowRequest.COMPLETED_MODEL_ID == "")
                    {
                        rowRequest.COMPLETED_MODEL_ID = row.MODEL_ID;
                    }
                    else
                    {
                        rowRequest.COMPLETED_MODEL_ID += "," + row.MODEL_ID;
                    }
                    bll.Update(rowRequest);
                }
                #endregion
               
            }
            context.Response.Write(msg);
        }
        public void SaveMonitorPM_edit(HttpContext context)
        {
            string msg = "";
            string hfMonitor_id = context.Request["hfMonitor_id"] ?? "";
            ParamCollection query1 = new ParamCollection();
            query1.Clause = PROJECT_MONITOR.PROJECT_MONITOR_ID_FIELD + " = '" + hfMonitor_id + "'";

            BaseList data = bll.Select(query1, typeof(PROJECT_MONITOR));
            if (data.Count > 0)
            {

                ParamCollection q1 = new ParamCollection();
                q1.Clause = REQUEST.REQUEST_ID_FIELD + " = '" + ((PROJECT_MONITOR)data[0]).REQUEST_ID + "'";
                BaseList rdata = bll.Select(q1, typeof(REQUEST));
                SYS_USER userLogin = CacheHelper.getCurrentUser();
                string pm = "";
                if (rdata.Count > 0)
                {
                    pm = ((REQUEST)rdata[0]).PM;
                }
                if (userLogin.USER_NAME == pm)
                {
                    #region 保存per_project
                    ParamCollection query2 = new ParamCollection();
                    query2.Clause = PROJECT_MONITOR.REQUEST_ID_FIELD + " = '" + ((PROJECT_MONITOR)data[0]).REQUEST_ID + "'";
                    BaseList perStudyData = bll.Select(query2, typeof(PROJECT_MONITOR));
                    int oldper_project = 0;
                    foreach (PROJECT_MONITOR dr in perStudyData)
                    {
                        oldper_project += dr.COMPLETION_PROPORTIONS_PER_STUDY;
                    }

                    oldper_project = int.Parse(Math.Round(oldper_project * 0.65 / perStudyData.Count, 0, MidpointRounding.AwayFromZero).ToString());
                    foreach (PROJECT_MONITOR row in perStudyData)
                    {
                        int per_project = 0;

                        row.SIGNED_QUOTATION = context.Request["txtSigned_Quotation"] ?? "";
                        if (row.SIGNED_QUOTATION != "" && row.COMPLETION_PROPORTIONS_PER_PROJECT < 10)
                        {
                            per_project = 0;
                        }
                        row.KICKOFF = context.Request["txtKickoff"] ?? "";
                        if (row.KICKOFF != "" && row.COMPLETION_PROPORTIONS_PER_PROJECT < 10)
                        {
                            per_project = 5;
                        }
                        row.REGISTER_PROJECT = context.Request["txtRegister_Project"] ?? "";
                        if (row.REGISTER_PROJECT != "" && row.COMPLETION_PROPORTIONS_PER_PROJECT <= 10)
                        {
                            per_project = 10;
                        }
                        row.TISSUE_SENT_OUT = context.Request["txtTissue_Sent_Out"] ?? "";
                        if (row.TISSUE_SENT_OUT != "")
                        {
                            per_project = 80;
                        }
                        row.FINAL_DATA_SENT_OUT = context.Request["txtFinal_Data_Sent_Out"] ?? "";
                        if (row.FINAL_DATA_SENT_OUT != "")
                        {
                            per_project = 85;
                        }
                        row.DOCUMENT_ARCHIEVE = context.Request["txtDocument_Archieve"] ?? "";
                        if (row.DOCUMENT_ARCHIEVE != "")
                        {
                            per_project = 90;
                        }
                        row.REPORT_SENT_OUT = context.Request["txtReport_Sent_Out"] ?? "";
                        if (row.REPORT_SENT_OUT != "")
                        {
                            per_project = 95;
                        }
                        row.BALANCE_INVOICE_SENT_OUT = context.Request["txtBalance_Invoice_Sent_Out"] ?? "";
                        if (row.BALANCE_INVOICE_SENT_OUT != "")
                        {
                            per_project = 100;
                        }
                        row.CurModel = DealModel.Modify;


                        if (oldper_project > 0 && per_project < 80)
                        {
                            row.COMPLETION_PROPORTIONS_PER_PROJECT = oldper_project + 10;
                        }
                        else
                        {
                            row.COMPLETION_PROPORTIONS_PER_PROJECT = per_project;
                        }

                    }
                    bll.UpdateAllByParams(perStudyData);
                    #endregion
                }
                else {
                    msg = "You can not save this project.";
                }
            }
            context.Response.Write(msg);
        }

        public void SaveMonitorJSD_edit(HttpContext context)
        {

            List<PROJECT_MONITOR_DOSING_ROUTE> dataRoute = bll.Select(typeof(PROJECT_MONITOR_DOSING_ROUTE)).ConvertAll<PROJECT_MONITOR_DOSING_ROUTE>(PROJECT_MONITOR_DOSING_ROUTE.Convert);
            #region 补救办法2.10
            //ParamCollection pl = new ParamCollection();
            //pl.Clause += PROJECT_MONITOR_DAY.PHASE_FIELD + "='8'";
            //BaseList datalist = bll.Select(pl, typeof(PROJECT_MONITOR_DAY));

            //List<PROJECT_MONITOR> lists = bll.Select(typeof(PROJECT_MONITOR)).ConvertAll<PROJECT_MONITOR>(PROJECT_MONITOR.Convert);
            //foreach (PROJECT_MONITOR_DAY ds in datalist)
            //{
            //    PROJECT_MONITOR row = lists.Find(delegate(PROJECT_MONITOR perm) { return perm.PROJECT_MONITOR_ID == ds.PROJECT_MONITOR_ID; });
            //    if (row != null)
            //    {
            //        if (RegHelper.IsDateTime(row.INOCULATION))
            //        {
            //            double value = SearchRoute(dataRoute, "2.10") * row.NUMBER_OF_ANIMAL_INOCULATION;
            //            ds.CurModel = DealModel.Modify;
            //            ds.STUDY_WORKLOAD = value;
            //            bll.Update(ds);
            //        }
            //    }
            //}
            #endregion

            string msg = "";
            string hfMonitor_id = context.Request["hfMonitor_id"] ?? "";


            ParamCollection query1 = new ParamCollection();
            query1.Clause = PROJECT_MONITOR.PROJECT_MONITOR_ID_FIELD + " = '" + hfMonitor_id + "'";

            BaseList data = bll.Select(query1, typeof(PROJECT_MONITOR));
            if (data.Count > 0)
            {
                #region save per_study

                int per_study = 0;
                PROJECT_MONITOR row = (PROJECT_MONITOR)data[0];
                row.CurModel = DealModel.Modify;
                row.BOOKING_ANIMALS = context.Request["txtBooking_Animals"] ?? "";
                if (row.BOOKING_ANIMALS != "")
                {
                    per_study = 8;
                }
                row.ORDER_ANIMAL = context.Request["txtOrder_Animal"] ?? "";
                if (row.ORDER_ANIMAL != "")
                {
                    per_study = 16;
                }
                row.FINALIZE_PROTOCOL = context.Request["txtFinalize_Protocol"] ?? "";
                if (row.FINALIZE_PROTOCOL != "")
                {
                    per_study = 24;
                }
                row.PROVIDE_SEEDING_ANIMAL = context.Request["txtProvide_Seeding_Animal"] ?? "";
                if (row.PROVIDE_SEEDING_ANIMAL != "")
                {
                    per_study = 32;
                }
                row.INOCULATION = context.Request["txtInoculation"] ?? "";
                if (row.INOCULATION != "")
                {
                    per_study = 47;
                }
                row.RANDOMIZATION = context.Request["txtRandomization"] ?? "";
                if (row.RANDOMIZATION != "")
                {
                    per_study = 62;
                }
                row.TREATMENT_START = context.Request["txtTreatment_Start"] ?? "";
                if (row.TREATMENT_START != "")
                {
                    per_study = 77;
                }
                row.TREATMENT_FINISHED = context.Request["txtTreatment_Finished"] ?? "";
                if (row.TREATMENT_FINISHED != "")
                {
                    per_study = 85;
                }
                row.OBSERVATION_POST_TREATMENT = context.Request["txtObservation_Post_Treatment"] ?? "";
                if (row.OBSERVATION_POST_TREATMENT != "")
                {
                    per_study = 93;
                }
                row.TISSUE_COLLECTION = context.Request["txtTissue_Collection"] ?? "";
                if (row.TISSUE_COLLECTION != "")
                {
                    per_study = 100;
                    #region 删除request里的completed Model ID
                    ParamCollection paralist = new ParamCollection();
                    paralist.Clause = REQUEST.REQUEST_ID_FIELD + "='" + row.REQUEST_ID + "'";
                    BaseList request = bll.Select(paralist, typeof(REQUEST));
                    if (request.Count > 0)
                    {
                        REQUEST rowRequest = (REQUEST)request[0];
                        rowRequest.CurModel = DealModel.Modify;
                        string[] list = rowRequest.MODEL_ID.Split(',');
                        List<string> alist = list.ToList();
                        alist.Remove(row.MODEL_ID);
                        rowRequest.MODEL_ID = string.Join(",", alist);
                        if (rowRequest.COMPLETED_MODEL_ID == "")
                        {
                            rowRequest.COMPLETED_MODEL_ID = row.MODEL_ID;
                        }
                        else
                        {
                            rowRequest.COMPLETED_MODEL_ID += "," + row.MODEL_ID;
                        }
                        bll.Update(rowRequest);
                    }
                    #endregion


                }
                row.COMPLETION_PROPORTIONS_PER_STUDY = per_study;
                bll.Update(row);

                #endregion

                #region save per_project
                ParamCollection query2 = new ParamCollection();
                query2.Clause = PROJECT_MONITOR.REQUEST_ID_FIELD + " = '" + row.REQUEST_ID + "'";
                BaseList perStudyData = bll.Select(query2, typeof(PROJECT_MONITOR));
                if (perStudyData.Count > 0)
                {
                    int per_project = 0;
                    foreach (PROJECT_MONITOR dr in perStudyData)
                    {
                        per_project += dr.COMPLETION_PROPORTIONS_PER_STUDY;
                    }

                    per_project = int.Parse(Math.Round(per_project * 0.65 / perStudyData.Count, 0, MidpointRounding.AwayFromZero).ToString());
                    foreach (PROJECT_MONITOR dr in perStudyData)
                    {
                        dr.CurModel = DealModel.Modify;
                        if (dr.COMPLETION_PROPORTIONS_PER_PROJECT < 80)
                        {
                            if (per_project != 0)
                            {
                                dr.COMPLETION_PROPORTIONS_PER_PROJECT = per_project + 10;
                            }
                            else
                            {
                                int temp = 0;
                                if (dr.SIGNED_QUOTATION != "")
                                {
                                    temp = 0;
                                }
                                if (dr.KICKOFF != "")
                                {
                                    temp = 5;
                                }
                                if (dr.REGISTER_PROJECT != "")
                                {
                                    temp = 10;
                                }
                                dr.COMPLETION_PROPORTIONS_PER_PROJECT = temp;
                            }
                        }
                    }
                    bll.UpdateAllByParams(perStudyData);
                }
                #endregion


                if (row.RANDOMIZATION != "")
                {
                    ParamCollection pl = new ParamCollection();
                    pl.Clause = PROJECT_MONITOR_DAY.PROJECT_MONITOR_ID_FIELD + "='" + row.PROJECT_MONITOR_ID + "'";
                    BaseList DTgroupData = bll.Select(pl, typeof(PROJECT_MONITOR_DAY));
                    foreach (PROJECT_MONITOR_DAY del in DTgroupData)
                    {
                        del.CurModel = DealModel.Delete;
                    }
                    bll.Delete(DTgroupData);
                    DTgroup_workload(row);
                }

                if (row.ORDER_ANIMAL != "")
                {
                    ParamCollection pl = new ParamCollection();
                    pl.Clause = PROJECT_MONITOR_DAY.PROJECT_MONITOR_ID_FIELD + "='" + row.PROJECT_MONITOR_ID + "'";
                    BaseList DM_Data = bll.Select(pl, typeof(PROJECT_MONITOR_DM_WORKLOAD));
                    foreach (PROJECT_MONITOR_DM_WORKLOAD del in DM_Data)
                    {
                        del.CurModel = DealModel.Delete;
                    }
                    bll.Delete(DM_Data);
                    DM_workload(row);
                }

                msg = "Save successfully";
            }
            context.Response.Write(msg);
        }

        public void DM_workload(PROJECT_MONITOR row)
        {
            string role = "DM";
            string person = row.DM;
            List<PROJECT_MONITOR_DOSING_ROUTE> dataRoute = bll.Select(typeof(PROJECT_MONITOR_DOSING_ROUTE)).ConvertAll<PROJECT_MONITOR_DOSING_ROUTE>(PROJECT_MONITOR_DOSING_ROUTE.Convert);
            if (person != "")
            {
                BaseList newGroupData = new BaseList();
                double time = 1;//1天1次
                if (row.TUMOR_MONITOR_SCHEDULE == "TID")//1天3次
                {
                    time = 3;
                }
                else if (row.TUMOR_MONITOR_SCHEDULE == "BID")//1天2次
                {
                    time = 2;
                }

                #region 计算mice_number
                double mice_number = 0;
                ParamCollection paraList2 = new ParamCollection();
                paraList2.Clause = PROJECT_MONITOR_STUDY_DESIGN.PROJECT_MONITOR_ID_FIELD + "='" + row.PROJECT_MONITOR_ID + "'";
                BaseList dataGroup = bll.Select(paraList2, typeof(PROJECT_MONITOR_STUDY_DESIGN));

                if (dataGroup.Count > 0)
                {
                    foreach (PROJECT_MONITOR_STUDY_DESIGN dr in dataGroup)
                    {
                        mice_number += int.Parse(dr.MICE_GROUP);
                    }
                }
                #endregion

                #region 计算beforeGroup5,6,7,8,9,10,11,12
                for (int i = 0; i < 8; i++)
                {
                    string day2 = "";
                    string phase = "";
                    if (i == 0)
                    {
                        day2 = row.ORDER_ANIMAL;
                        phase = "5";
                    }
                    else if (i == 1)
                    {
                        day2 = row.FINALIZE_PROTOCOL;
                        phase = "6";
                    }
                    else if (i == 2)
                    {
                        day2 = row.PROVIDE_SEEDING_ANIMAL;
                        phase = "7";
                    }
                    else if (i == 3)
                    {
                        day2 = row.INOCULATION;
                        phase = "8";
                    }
                    else if (i == 4)
                    {
                        day2 = row.RANDOMIZATION;
                        phase = "9";
                    }
                    else if (i == 5)
                    {
                        day2 = row.TREATMENT_START;
                        phase = "10";
                    }
                    else if (i == 6)
                    {
                        day2 = row.TREATMENT_FINISHED;
                        phase = "11";
                    }
                    else if (i == 7)
                    {
                        day2 = row.OBSERVATION_POST_TREATMENT;
                        phase = "12";
                    }


                    if (RegHelper.IsDateTime(day2))
                    {
                        DateTime day = DateTime.Parse(day2);
                        double workload = 0;
                        if (phase == "5" || phase == "6" || phase == "7")
                        {
                            workload = SearchRoute(dataRoute, "1.07") * row.NUMBER_OF_ANIMAL_PURCHASE * time;

                            #region QW//每周一次，固定在Date of treatment当天。按照Date of treatment自动选择
                            DateTime newTime = new DateTime();
                            if (phase == "5")
                            {
                                if (RegHelper.IsDateTime(row.FINAL_DATA_SENT_OUT))
                                {
                                    newTime = DateTime.Parse(row.FINAL_DATA_SENT_OUT);
                                }
                            }
                            else if (phase == "6")
                            {
                                if (RegHelper.IsDateTime(row.PROVIDE_SEEDING_ANIMAL))
                                {
                                    newTime = DateTime.Parse(row.PROVIDE_SEEDING_ANIMAL);
                                }
                            }
                            else if (phase == "7")
                            {
                                if (RegHelper.IsDateTime(row.INOCULATION))
                                {
                                    newTime = DateTime.Parse(row.INOCULATION);
                                }
                            }
                            for (DateTime dt = day; dt < newTime; dt = dt.AddDays(1))
                            {
                                if (dt.DayOfWeek == day.DayOfWeek)
                                {
                                    saveDM_work(row, role, person, workload, dt, phase, newGroupData);

                                }
                            }
                          
                        
                        #endregion
                        }
                        else if (phase == "8" || phase == "9")
                        {
                            if (phase == "8")
                            {
                                workload = SearchRoute(dataRoute, "1.04") * row.NUMBER_OF_ANIMAL_INOCULATION * time;
                                workload += SearchRoute(dataRoute, "1.03") * row.NUMBER_OF_ANIMAL_PURCHASE;
                                #region QW//每周一次，固定在Date of treatment当天。按照Date of treatment自动选择
                                DateTime newTime = new DateTime();

                                if (RegHelper.IsDateTime(row.RANDOMIZATION))
                                {
                                    newTime = DateTime.Parse(row.RANDOMIZATION);
                                }

                                for (DateTime dt = day; dt < newTime; dt = dt.AddDays(1))
                                {
                                    if (dt.DayOfWeek == day.DayOfWeek)
                                    {
                                        saveDM_work(row, role, person, workload, dt, phase, newGroupData);

                                    }
                                }


                                #endregion
                            }
                            else
                            {
                                saveDM_work(row, role, person, 0, day, phase, newGroupData);
                            }
                        }
                        else if (phase == "10" || phase == "11" || phase == "12")
                        {
                            workload = SearchRoute(dataRoute, "1.05") * mice_number * time;
                            DateTime newTime = new DateTime();
                            string measure = "";
                            if (phase == "10")
                            {
                                if (RegHelper.IsDateTime(row.TREATMENT_FINISHED))
                                {
                                    newTime = DateTime.Parse(row.TREATMENT_FINISHED);
                                    measure = row.TUMOR_MONITOR_SCHEDULE;
                                }
                            }
                            else if (phase == "11")
                            {
                                if (RegHelper.IsDateTime(row.OBSERVATION_POST_TREATMENT))
                                {
                                    newTime = DateTime.Parse(row.OBSERVATION_POST_TREATMENT);
                                    measure = row.TUMOR_MONITOR_SCHEDULE;
                                }
                            }
                            else if (phase == "12")
                            {
                                if (RegHelper.IsDateTime(row.TISSUE_COLLECTION))
                                {
                                    newTime = DateTime.Parse(row.TISSUE_COLLECTION);
                                    measure = row.TUMOR_MONITOR_SCHEDULE2;
                                }
                            }


                            #region QD,Q2D,Q3D,Q4D//每2天1次,每3天1次,每4天1次
                            if (measure == "QD" || measure == "Q2D" || measure == "Q3D" || measure == "Q4D")
                            {
                                int d = 1;
                                if (measure == "Q2D")
                                {
                                    d = 2;
                                }
                                else if (measure == "Q3D")
                                {
                                    d = 3;
                                }
                                else if (measure == "Q4D")
                                {
                                    d = 4;
                                }
                                for (DateTime dt = day; dt < newTime; dt = dt.AddDays(d))
                                {
                                    saveDM_work(row, role, person, workload, dt, phase, newGroupData);
                                }
                            }
                            #endregion

                            #region 5 Days on and 2 days off//每天一次，固定在Monday/Tuesday开始。按照Date of treatment自动选择
                            else if (measure == "5 Days on and 2 days off")
                            {
                                for (DateTime dt = day; dt < newTime; dt = dt.AddDays(1))
                                {
                                    if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
                                    {
                                        saveDM_work(row, role, person, workload, dt, phase, newGroupData);
                                    }

                                }
                            }
                            #endregion

                            #region TIW//每周三次，固定在Monday, Wednesday, Friday。按照Date of treatment自动选择
                            else if (measure == "TIW")
                            {
                                for (DateTime dt = day; dt < newTime; dt = dt.AddDays(1))
                                {
                                    if (dt.DayOfWeek == DayOfWeek.Monday || dt.DayOfWeek == DayOfWeek.Friday || dt.DayOfWeek == DayOfWeek.Wednesday)
                                    {
                                        saveDM_work(row, role, person, workload, dt, phase, newGroupData);
                                    }
                                }
                            }
                            #endregion

                            #region BIW//每周两次，固定在Monday/Thursday或Tuesday/Friday。按照Date of treatment自动选择
                            else if (measure == "BIW")
                            {
                             
                                if (day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Thursday)
                                {
                                    for (DateTime dt = day; dt < newTime; dt = dt.AddDays(1))
                                    {
                                        if (dt.DayOfWeek == DayOfWeek.Monday || dt.DayOfWeek == DayOfWeek.Thursday)
                                        {
                                            saveDM_work(row, role, person, workload, dt, phase, newGroupData);
                                        }
                                    }
                                }
                                else if (day.DayOfWeek == DayOfWeek.Tuesday || day.DayOfWeek == DayOfWeek.Friday)
                                {
                                    for (DateTime dt = day; dt < newTime; dt = dt.AddDays(1))
                                    {
                                        if (dt.DayOfWeek == DayOfWeek.Tuesday || dt.DayOfWeek == DayOfWeek.Friday)
                                        {
                                            saveDM_work(row, role, person, workload, dt, phase, newGroupData);
                                        }
                                    }
                                }
                            }
                            #endregion

                            #region QW//每周一次，固定在Date of treatment当天。按照Date of treatment自动选择
                            else if (measure == "QW")
                            {
                                for (DateTime dt = day; dt < newTime; dt = dt.AddDays(1))
                                {
                                    if (dt.DayOfWeek == day.DayOfWeek)
                                    {
                                        saveDM_work(row, role, person, workload, dt, phase, newGroupData);

                                    }
                                }
                            }
                            #endregion

                            #region Q2W//每两周一次，固定在Date of treatment当天。按照Date of treatment自动选择
                            else if (measure == "Q2W")
                            {
                                for (DateTime dt = day; dt < newTime; dt = dt.AddDays(14))
                                {
                                    if (dt.DayOfWeek == day.DayOfWeek)
                                    {

                                        saveDM_work(row, role, person, workload, dt, phase, newGroupData);
                                    }
                                }
                            }
                            #endregion

                            #region Q3W//每3周一次，固定在Date of treatment当天。按照Date of treatment自动选择
                            else if (measure == "Q3W")
                            {
                                for (DateTime dt = day; dt < newTime; dt = dt.AddDays(21))
                                {
                                    if (dt.DayOfWeek == day.DayOfWeek)
                                    {
                                        saveDM_work(row, role, person, workload, dt, phase, newGroupData);
                                    }
                                }
                            }
                            #endregion

                            #region  Once//整个实验过程只有一次给药，根据选择日期确定。
                            else if (measure == "Once")
                            {
                                saveDM_work(row, role, person, workload, day, phase, newGroupData);
                            }
                            #endregion
                            
                        }
                    }

                }
                #endregion

                bll.UpdateAllByParams(newGroupData);
            }

        }
        public void saveDM_work(PROJECT_MONITOR row, string role, string person, double workload, DateTime day, string phase, BaseList newGroupData)
        {
            PROJECT_MONITOR_DM_WORKLOAD newday = new PROJECT_MONITOR_DM_WORKLOAD(DealModel.New);
            newday.PROJECT_MONITOR_ID = row.PROJECT_MONITOR_ID;
            newday.SUB_PROJECT = row.PROJECT_NUMBER;
            newday.MODEL_ID = row.MODEL_ID;
            newday.ROLE_NAME = role;
            newday.PERSON = person;
            newday.STUDY_DESIGN_DAY = day;
            newday.STUDY_WORKLOAD = workload;
            newday.DM = row.DM;
            newday.PHASE = phase;
            newGroupData.Add(newday);
        }

        public void saveDTgroup_work(string phase, PROJECT_MONITOR dr, string role, string person, double beforeGroup, List<PROJECT_MONITOR_DOSING_ROUTE> dataRoute, DateTime day)
        {
            BaseList newGroupData = new BaseList();
            PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
            newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
            newday.SUB_PROJECT = dr.PROJECT_NUMBER;
            newday.MODEL_ID = dr.MODEL_ID;
            newday.ROLE_NAME = role;
            newday.PERSON = person;
            newday.STUDY_DESIGN_DAY = day;
            newday.DM = dr.DM;
            newday.PHASE = phase;
            newday.STUDY_WORKLOAD = beforeGroup;
            newGroupData.Add(newday);
            bll.UpdateAllByParams(newGroupData);
        }

        public void DTgroup_workload(PROJECT_MONITOR dr)
        {
           

            string role = "DT group";
            string person = dr.DT_GROUP;
            List<PROJECT_MONITOR_DOSING_ROUTE> dataRoute = bll.Select(typeof(PROJECT_MONITOR_DOSING_ROUTE)).ConvertAll<PROJECT_MONITOR_DOSING_ROUTE>(PROJECT_MONITOR_DOSING_ROUTE.Convert);

            #region

            if (person != "")
            {

                #region 计算beforeGroup7
                double beforeGroup7 = 0;
                if (RegHelper.IsDateTime(dr.PROVIDE_SEEDING_ANIMAL))
                {
                    //beforeGroup7 = SearchRoute(dataRoute, "2.08");
                    
                    saveDTgroup_work("7", dr, role, person, beforeGroup7, dataRoute, DateTime.Parse(dr.PROVIDE_SEEDING_ANIMAL));
                }

                #endregion

                #region 计算beforeGroup8
                double beforeGroup8 = 0;
                if (RegHelper.IsDateTime(dr.INOCULATION))
                {
                    beforeGroup8 = SearchRoute(dataRoute, "2.10") * dr.NUMBER_OF_ANIMAL_INOCULATION;
                    saveDTgroup_work("8", dr, role, person, beforeGroup8, dataRoute, DateTime.Parse(dr.INOCULATION));
                }

                #endregion

                ParamCollection paraList2 = new ParamCollection();
                paraList2.Clause = PROJECT_MONITOR_STUDY_DESIGN.PROJECT_MONITOR_ID_FIELD + "='" + dr.PROJECT_MONITOR_ID + "'";
                BaseList dataGroup = bll.Select(paraList2, typeof(PROJECT_MONITOR_STUDY_DESIGN));
                double mice_number = 0;
                if (dataGroup.Count > 0)
                {
                    double workload = 0;

                    #region 计算mice_number
                    foreach (PROJECT_MONITOR_STUDY_DESIGN row in dataGroup)
                    {
                        mice_number += int.Parse(row.MICE_GROUP);

                    }
                    #endregion

                    #region 计算beforeGroup9
                    double beforeGroup9 = 0;
                    if (RegHelper.IsDateTime(dr.RANDOMIZATION))
                    {
                        beforeGroup9 = SearchRoute(dataRoute, "2.01,2.23") * mice_number;
                        saveDTgroup_work("9", dr, role, person, beforeGroup9, dataRoute, DateTime.Parse(dr.RANDOMIZATION));
                    }


                    #endregion

                    #region 计算workload_Group10
                    #region beforeGroup10
                    double beforeGroup10 = 0;

                    if (dr.TREATMENT_START != "")
                    {
                        if (dr.SAMPLE_AMOUNT != 0)
                        {
                            beforeGroup10 = SearchRoute(dataRoute, "2.09") * 1;
                        }
                    }


                    #endregion



                    if (RegHelper.IsDateTime(dr.TREATMENT_START))
                    {
                        BaseList newGroupData = new BaseList();
                        foreach (PROJECT_MONITOR_STUDY_DESIGN row in dataGroup)
                        {

                            DateTime day = DateTime.Parse(dr.TREATMENT_START);
                            //循环周期
                            int period = 0;
                            if (row.DOSING_PERIOD != "")
                            {
                                period = int.Parse(row.DOSING_PERIOD);
                            }
                            double time = 1;//1天1次
                            if (row.DOSING_SCHEDULE == "TID")//1天3次
                            {
                                time = 3;
                            }
                            else if (row.DOSING_SCHEDULE == "BID")//1天2次
                            {
                                time = 2;
                            }
                            //每天的工作量
                            workload = beforeGroup10 + SearchRoute(dataRoute, row.DOSING_ROUTE_VALUE.ToString()) * double.Parse(row.MICE_GROUP) * time;

                            #region Q2D,Q3D,Q4D//每2天1次,每3天1次,每4天1次
                            if (row.DOSING_SCHEDULE == "Q2D" || row.DOSING_SCHEDULE == "Q3D" || row.DOSING_SCHEDULE == "Q4D")
                            {
                                for (int i = 0; i < period; i++)
                                {
                                    PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                    newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                    newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                    newday.MODEL_ID = dr.MODEL_ID;
                                    newday.ROLE_NAME = role;
                                    newday.PERSON = person;
                                    if (row.DOSING_SCHEDULE == "Q2D")
                                    {
                                        newday.STUDY_DESIGN_DAY = day.AddDays(i * 2);
                                    }
                                    else if (row.DOSING_SCHEDULE == "Q3D")
                                    {
                                        newday.STUDY_DESIGN_DAY = day.AddDays(i * 3);
                                    }
                                    else if (row.DOSING_SCHEDULE == "Q3D")
                                    {
                                        newday.STUDY_DESIGN_DAY = day.AddDays(i * 4);
                                    }
                                    newday.STUDY_WORKLOAD = workload;
                                    newday.DM = dr.DM;
                                    newday.PHASE = "10";
                                    newGroupData.Add(newday);
                                }
                            }
                            #endregion

                            #region 5 Days on and 2 days off//每天一次，固定在Monday/Tuesday开始。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "5 Days on and 2 days off")
                            {
                                int totalDay = period * 7;
                                for (int d = 0; d < totalDay; d++)
                                {
                                    if (day.AddDays(d).DayOfWeek != DayOfWeek.Saturday && day.AddDays(d).DayOfWeek != DayOfWeek.Sunday)
                                    {
                                        PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                        newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                        newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                        newday.MODEL_ID = dr.MODEL_ID;
                                        newday.ROLE_NAME = role;
                                        newday.PERSON = person;
                                        newday.STUDY_DESIGN_DAY = day.AddDays(d);
                                        newday.STUDY_WORKLOAD = workload;
                                        newday.DM = dr.DM;
                                        newday.PHASE = "10";
                                        newGroupData.Add(newday);
                                    }

                                }
                            }
                            #endregion

                            #region TIW//每周三次，固定在Monday, Wednesday, Friday。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "TIW")
                            {
                                int totalDay = period * 7;
                                for (int d = 0; d < totalDay; d++)
                                {
                                    if (day.AddDays(d).DayOfWeek == DayOfWeek.Monday || day.AddDays(d).DayOfWeek == DayOfWeek.Friday || day.AddDays(d).DayOfWeek == DayOfWeek.Wednesday)
                                    {
                                        PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                        newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                        newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                        newday.MODEL_ID = dr.MODEL_ID;
                                        newday.ROLE_NAME = role;
                                        newday.PERSON = person;
                                        newday.STUDY_DESIGN_DAY = day.AddDays(d);
                                        newday.STUDY_WORKLOAD = workload;
                                        newday.DM = dr.DM;
                                        newday.PHASE = "10";
                                        newGroupData.Add(newday);
                                    }
                                }
                            }
                            #endregion

                            #region BIW//每周两次，固定在Monday/Thursday或Tuesday/Friday。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "BIW")
                            {
                                int totalDay = period * 7;
                                if (day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Thursday)
                                {
                                    for (int d = 0; d < totalDay; d++)
                                    {
                                        if (day.AddDays(d).DayOfWeek == DayOfWeek.Monday || day.AddDays(d).DayOfWeek == DayOfWeek.Thursday)
                                        {
                                            PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                            newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                            newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                            newday.MODEL_ID = dr.MODEL_ID;
                                            newday.ROLE_NAME = role;
                                            newday.PERSON = person;
                                            newday.STUDY_DESIGN_DAY = day.AddDays(d);
                                            newday.STUDY_WORKLOAD = workload;
                                            newday.DM = dr.DM;
                                            newday.PHASE = "10";
                                            newGroupData.Add(newday);
                                        }
                                    }
                                }
                                else if (day.DayOfWeek == DayOfWeek.Tuesday || day.DayOfWeek == DayOfWeek.Friday)
                                {
                                    for (int d = 0; d < totalDay; d++)
                                    {
                                        if (day.AddDays(d).DayOfWeek == DayOfWeek.Tuesday || day.AddDays(d).DayOfWeek == DayOfWeek.Friday)
                                        {
                                            PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                            newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                            newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                            newday.MODEL_ID = dr.MODEL_ID;
                                            newday.ROLE_NAME = role;
                                            newday.PERSON = person;
                                            newday.STUDY_DESIGN_DAY = day.AddDays(d);
                                            newday.STUDY_WORKLOAD = workload;
                                            newday.DM = dr.DM;
                                            newGroupData.Add(newday);
                                        }
                                    }
                                }
                            }
                            #endregion

                            #region QW//每周一次，固定在Date of treatment当天。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "QW")
                            {
                                int week = period;
                                for (int d = 0; d < week; d++)
                                {
                                    if (day.AddDays(d).DayOfWeek == day.DayOfWeek)
                                    {
                                        PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                        newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                        newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                        newday.MODEL_ID = dr.MODEL_ID;
                                        newday.ROLE_NAME = role;
                                        newday.PERSON = person;
                                        newday.STUDY_DESIGN_DAY = day.AddDays(d * 7);
                                        newday.STUDY_WORKLOAD = workload;
                                        newday.DM = dr.DM;
                                        newday.PHASE = "10";
                                        newGroupData.Add(newday);
                                    }
                                }
                            }
                            #endregion

                            #region Q2W//每两周一次，固定在Date of treatment当天。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "Q2W")
                            {
                                int week = period;
                                for (int d = 0; d < week; d++)
                                {
                                    if (day.AddDays(d).DayOfWeek == day.DayOfWeek)
                                    {
                                        PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                        newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                        newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                        newday.MODEL_ID = dr.MODEL_ID;
                                        newday.ROLE_NAME = role;
                                        newday.PERSON = person;
                                        newday.STUDY_DESIGN_DAY = day.AddDays(d * 14);
                                        newday.STUDY_WORKLOAD = workload;
                                        newday.DM = dr.DM;
                                        newday.PHASE = "10";
                                        newGroupData.Add(newday);
                                    }
                                }
                            }
                            #endregion

                            #region Q3W//每3周一次，固定在Date of treatment当天。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "Q3W")
                            {
                                int week = period;
                                for (int d = 0; d < week; d++)
                                {
                                    if (day.AddDays(d).DayOfWeek == day.DayOfWeek)
                                    {
                                        PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                        newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                        newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                        newday.MODEL_ID = dr.MODEL_ID;
                                        newday.ROLE_NAME = role;
                                        newday.PERSON = person;
                                        newday.STUDY_DESIGN_DAY = day.AddDays(d * 21);
                                        newday.STUDY_WORKLOAD = workload;
                                        newday.DM = dr.DM;
                                        newday.PHASE = "10";
                                        newGroupData.Add(newday);
                                    }
                                }
                            }
                            #endregion

                            #region  Once//整个实验过程只有一次给药，根据选择日期确定。
                            else if (row.DOSING_SCHEDULE == "Once")
                            {
                                PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                newday.MODEL_ID = dr.MODEL_ID;
                                newday.ROLE_NAME = role;
                                newday.PERSON = person;
                                newday.STUDY_DESIGN_DAY = day;
                                newday.STUDY_WORKLOAD = workload;
                                newday.DM = dr.DM;
                                newday.PHASE = "10";
                                newGroupData.Add(newday);
                            }
                            #endregion
                            else
                            {
                                for (int i = 0; i < period; i++)
                                {
                                    PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                    newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                    newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                    newday.MODEL_ID = dr.MODEL_ID;
                                    newday.ROLE_NAME = role;
                                    newday.PERSON = person;
                                    newday.STUDY_DESIGN_DAY = day.AddDays(i);
                                    newday.STUDY_WORKLOAD = workload;
                                    newday.DM = dr.DM;
                                    newday.PHASE = "10";
                                    newGroupData.Add(newday);
                                }
                            }
                        }
                        bll.UpdateAllByParams(newGroupData);
                    }
                    #endregion
                }

                #region 计算beforeGroup11
                double beforeGroup11 = 0;
                if (RegHelper.IsDateTime(dr.TREATMENT_FINISHED))
                {
                    beforeGroup11 = SearchRoute(dataRoute, "2.16") * dr.SAMPLE_AMOUNT;
                    if (dr.SAMPLE_AMOUNT != 0)
                    {
                        beforeGroup11 += SearchRoute(dataRoute, "2.18") * 1;
                    }
                    
                    beforeGroup11 += SearchRoute(dataRoute, "2.23") * mice_number;
                    saveDTgroup_work("11", dr, role, person, beforeGroup11, dataRoute, DateTime.Parse(dr.TREATMENT_FINISHED));
                }

                #endregion

                #region 计算beforeGroup12
                if (RegHelper.IsDateTime(dr.OBSERVATION_POST_TREATMENT))
                {
                    // List<PROJECT_MONITOR> mdata = allData.ConvertAll<PROJECT_MONITOR>(PROJECT_MONITOR.Convert).FindAll(delegate(PROJECT_MONITOR perm) { return perm.TISSUE_COLLECTION == dr.OBSERVATION_POST_TREATMENT; });
                    //if (mdata.Count > 0)
                    //{
                    //   
                    if (dr.TISSUE_COLLECTION != "")
                    {
                        double beforeGroup12 = SearchRoute(dataRoute, "2.18");
                        saveDTgroup_work("12", dr, role, person, beforeGroup12, dataRoute, DateTime.Parse(dr.OBSERVATION_POST_TREATMENT));
                    }
                    // }
                }

                #endregion
            }
            #endregion
        }

        public void SaveRoutineMaintain(HttpContext context)
        {

            string msg = "";
            ROUTINEMAINTAIN row = null;
            decimal pid = decimal.Parse(context.Request["hfRoutineMaintain_ID"]);
            object[] codes = { context.Request["txtSerial"], context.Request["txtCurrent_Animal_Ear_Tag"] };
            if (!bll.Find(pid, codes, typeof(ROUTINEMAINTAIN)))
            {
                ParamCollection paralist = new ParamCollection();
                paralist.Clause = ROUTINEMAINTAIN.ROUTINEMAINTAIN_ID_FIELD + "= '" + pid + "'";
                BaseList dataPDX = bll.Select(paralist, typeof(ROUTINEMAINTAIN));
                try
                {
                    if (dataPDX.Count == 0)
                    {
                        row = new ROUTINEMAINTAIN(DealModel.New);
                      
                    }
                    else
                    {
                        row = (ROUTINEMAINTAIN)dataPDX[0];
                        row.CurModel = DealModel.Modify;
                        #region 保存旧记录
                        ROUTINEMAINTAIN_LOG logrow = new ROUTINEMAINTAIN_LOG(DealModel.New);
                        logrow.ROUTINEMAINTAIN_ID = row.ROUTINEMAINTAIN_ID;
                        logrow.SERIAL = row.SERIAL;
                        logrow.MODEL_TYPE = row.MODEL_TYPE;
                        logrow.CANCER_TYPE_ABBR = row.CANCER_TYPE_ABBR;
                        logrow.SUBTYPE1 = row.SUBTYPE1;
                        logrow.SUBTYPE2 = row.SUBTYPE2;
                        logrow.MODEL_ID = row.MODEL_ID;
                        logrow.PROJECT = row.PROJECT;
                        logrow.LOCATION = row.LOCATION;
                        logrow.SOURCE_ANIMAL = row.SOURCE_ANIMAL;
                        logrow.OPREATION = row.OPREATION;
                        logrow.RN = row.RN;
                        logrow.PN = row.PN;
                        logrow.DATE_OF_PASSAGE_INOCULATION = row.DATE_OF_PASSAGE_INOCULATION;
                        logrow.STUDY = row.STUDY;
                        logrow.ANIMAL_STRAIN = row.ANIMAL_STRAIN;
                        logrow.ANIMAL_SEX = row.ANIMAL_SEX;
                        logrow.CURRENT_ANIMAL_EAR_TAG = row.CURRENT_ANIMAL_EAR_TAG;
                        logrow.ANIMAL_QUANTITY = row.ANIMAL_QUANTITY;
                        logrow.PDX_GROWTH_STATUS = row.PDX_GROWTH_STATUS;
                        logrow.DATE_OF_PASSAGE_TERMINATION = row.DATE_OF_PASSAGE_TERMINATION;
                        logrow.DURATION = row.DURATION;

                        logrow.COMMENTS = row.COMMENTS;
                        logrow.ANIMAL_ROOM_NUMBER = row.ANIMAL_ROOM_NUMBER;
                        logrow.EDITOR = row.EDITOR;
                        logrow.DATE_OF_CREATE = row.DATE_OF_CREATE;
                        bll.Update(logrow);
                        #endregion
                    }


                    #region 新增修改
                    row.SERIAL = context.Request["txtSerial"];
                    row.MODEL_TYPE = context.Request["txtModel_Type"] ?? "";
                    row.SUBTYPE1 = context.Request["txtSubtype1"] ?? "";
                    row.SUBTYPE2 = context.Request["txtSubtype2"] ?? "";
                    row.CANCER_TYPE_ABBR = context.Request["txtCancer_Type_Abbr"] ?? "";
                    string sq = row.SERIAL.ToString();
                    if (row.SERIAL.ToString().Length < 4)
                    {
                        sq = row.SERIAL.ToString().PadLeft(4, '0');
                    }
                    if (sq.Contains("m"))
                    {
                        row.MODEL_ID = "m" + row.CANCER_TYPE_ABBR + sq.Replace("m", "");
                    }
                    else
                    {
                        row.MODEL_ID = row.CANCER_TYPE_ABBR + sq;
                    }
                    row.PROJECT = context.Request["txtProject"] ?? "";

                   
                    SYS_USER userLogin = CacheHelper.getCurrentUser();
                    bool cbsd = ojbReportRule.GetUserFunctions(userLogin.Permission, "RoutineMaintain", "CBSD edit only");
                    bool cbsg = ojbReportRule.GetUserFunctions(userLogin.Permission, "RoutineMaintain", "CBSG edit only");
                    bool cbnc = ojbReportRule.GetUserFunctions(userLogin.Permission, "RoutineMaintain", "CBNC edit only");
                    string _location = context.Request["txtLocation"] ?? "";
                    //row.LOCATION = cbsd == true ? "CBSD" : cbsg == true ? "CBSG" : _location;
                    row.LOCATION = cbsd ? "CBSD" : cbsg ? "CBSG" : cbnc ? "CBNC" : _location;

                    row.SOURCE_ANIMAL = context.Request["txtSource_Animal"] ?? "";
                    row.OPREATION = context.Request["txtOpreation"] ?? "";
                    row.RN = context.Request["txtRn"] ?? "";
                    row.PN = context.Request["txtPn"] ?? "";
                    row.DATE_OF_PASSAGE_INOCULATION = context.Request["txtDate_of_Passage_inoculation"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDate_of_Passage_inoculation"]);
                    row.STUDY = row.MODEL_ID + "-" + row.RN + row.PN + "-" + row.DATE_OF_PASSAGE_INOCULATION.ToString("yyyyMMdd");
                    row.ANIMAL_STRAIN = context.Request["txtAnimal_Strain"] ?? "";
                    row.ANIMAL_SEX = context.Request["txtAnimal_Sex"] ?? "";
                    row.CURRENT_ANIMAL_EAR_TAG = context.Request["txtCurrent_Animal_Ear_Tag"].Replace("\t","") ?? "";
                    row.ANIMAL_QUANTITY = context.Request["txtAnimal_Quantity"] ?? "";
                    row.PDX_GROWTH_STATUS = context.Request["txtPDX_growth_status"] ?? "";
                   

                    row.DATE_OF_PASSAGE_TERMINATION = context.Request["txtDate_of_Passage_Termination"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDate_of_Passage_Termination"]);
                    if (row.DATE_OF_PASSAGE_TERMINATION != DateTime.MinValue && row.DATE_OF_PASSAGE_INOCULATION != DateTime.MinValue)
                    {
                        row.DURATION = (row.DATE_OF_PASSAGE_TERMINATION - row.DATE_OF_PASSAGE_INOCULATION).Days.ToString();
                    }
                    else
                    {
                        row.DURATION = "";
                    }

                    row.COMMENTS = context.Request["txtComments"] ?? "";
                    row.ANIMAL_ROOM_NUMBER = context.Request["txtAnimal_Room_Number"] ?? "";
                    row.MODEL_TUMOR_CHARACTERISTICS = context.Request["txtModel_Tumor_Characteristics"] ?? "";
                    SYS_USER userLogin2 = CacheHelper.getCurrentUser();
                    row.EDITOR = userLogin2.USER_NAME;
                    row.DATE_OF_CREATE = DateTime.Now;

                    decimal id = bll.Update(row);

                    if (row.PDX_GROWTH_STATUS == "PDX taken" && row.MODEL_ID.Substring(0, 1) != "m")
                    {
                        #region 更新至Model_Tree
                        ArrayList lists = new ArrayList();
                        lists.Add(row.MODEL_ID);
                        lists.Add(row.OPREATION);
                        lists.Add(row.RN.Replace("R", ""));
                        lists.Add(row.PN.Replace("P", ""));
                        lists.Add(context.Request["txtDate_of_Passage_inoculation"]);
                        lists.Add(context.Request["txtDate_of_Passage_Termination"]);
                        string location = row.LOCATION.Length > 7 ? row.LOCATION.Substring(6, 2) : row.LOCATION;
                        lists.Add(location);
                        AddToModelTree(lists);
                        #endregion
                    }
                    if (row.CurModel == DealModel.New)
                        row.ID = id;
                    row.CurModel = DealModel.None;
                    #endregion
                }
                catch (Exception ex)
                {
                    msg = ex.Message.ToString();
                }

            }
            else
            {
                msg = "Serial # already exists.";
            }
            context.Response.Write(msg);


        }

        public void SaveValidation(HttpContext context)
        {

            string msg = "";
            VALIDATION row = null;
            decimal pid = decimal.Parse(context.Request["hfValidation_ID"]);
            object[] codes = { context.Request["txtSerial"], context.Request["txtCurrent_Animal_Ear_Tag"] };
            if (!bll.Find(pid, codes, typeof(VALIDATION)))
            {
                ParamCollection paralist = new ParamCollection();
                paralist.Clause = VALIDATION.VALIDATION_ID_FIELD + "= '" + pid + "'";
                BaseList dataPDX = bll.Select(paralist, typeof(VALIDATION));
                try
                {
                    if (dataPDX.Count == 0)
                    {
                        row = new VALIDATION(DealModel.New);
                    }
                    else
                    {
                        row = (VALIDATION)dataPDX[0];
                        row.CurModel = DealModel.Modify;
                        #region 保存旧记录
                        VALIDATION_LOG logrow = new VALIDATION_LOG(DealModel.New);
                        logrow.VALIDATION_ID = row.VALIDATION_ID;
                        logrow.SERIAL = row.SERIAL;
                        logrow.MODEL_TYPE = row.MODEL_TYPE;
                        logrow.CANCER_TYPE_ABBR = row.CANCER_TYPE_ABBR;
                        logrow.SUBTYPE1 = row.SUBTYPE1;
                        logrow.SUBTYPE2 = row.SUBTYPE2;
                        logrow.MODEL_ID = row.MODEL_ID;
                        logrow.PROJECT = row.PROJECT;
                        logrow.LOCATION = row.LOCATION;
                        logrow.SOURCE_ANIMAL = row.SOURCE_ANIMAL;
                        logrow.OPREATION = row.OPREATION;
                        logrow.RN = row.RN;
                        logrow.PN = row.PN;
                        logrow.DATE_OF_PASSAGE_INOCULATION = row.DATE_OF_PASSAGE_INOCULATION;
                        logrow.STUDY = row.STUDY;
                        logrow.ANIMAL_STRAIN = row.ANIMAL_STRAIN;
                        logrow.ANIMAL_SEX = row.ANIMAL_SEX;
                        logrow.CURRENT_ANIMAL_EAR_TAG = row.CURRENT_ANIMAL_EAR_TAG;
                        logrow.ANIMAL_QUANTITY = row.ANIMAL_QUANTITY;
                        logrow.PDX_GROWTH_STATUS = row.PDX_GROWTH_STATUS;
                        logrow.DATE_OF_PASSAGE_TERMINATION = row.DATE_OF_PASSAGE_TERMINATION;
                        logrow.DURATION = row.DURATION;
                        logrow.SOURCE_HOSPITAL = row.SOURCE_HOSPITAL;
                        logrow.PATHOLOGY_INFO_AVAILABLE = row.PATHOLOGY_INFO_AVAILABLE;
                        logrow.DATE_OF_PATHOLOGY_INFO_RECEIVED = row.DATE_OF_PATHOLOGY_INFO_RECEIVED;
                        logrow.PATIENT_NO = row.PATIENT_NO;
                        logrow.PATIENT_NAME = row.PATIENT_NAME;
                        logrow.PATIENT_AGE = row.PATIENT_AGE;
                        logrow.PATIENT_SEX = row.PATIENT_SEX;
                        logrow.PATHOLOGY_INFO_QCED = row.PATHOLOGY_INFO_QCED;
                        logrow.COMMENTS = row.COMMENTS;
                        logrow.ANIMAL_ROOM_NUMBER = row.ANIMAL_ROOM_NUMBER;
                        logrow.EDITOR = row.EDITOR;
                        logrow.DATE_OF_CREATE = row.DATE_OF_CREATE;
                        bll.Update(logrow);
                        #endregion
                    }


                    #region 新增修改
                    row.SERIAL = context.Request["txtSerial"];
                    row.CANCER_TYPE_ABBR = context.Request["txtCancer_Type_Abbr"] ?? "";
                    row.MODEL_TYPE = context.Request["txtModel_Type"] ?? "";
                    row.SUBTYPE1 = context.Request["txtSubtype1"] ?? "";
                    row.SUBTYPE2 = context.Request["txtSubtype2"] ?? "";

                    string sq = row.SERIAL.ToString();
                    if (row.SERIAL.ToString().Length < 4)
                    {
                        sq = row.SERIAL.ToString().PadLeft(4, '0');
                    }
                    if (sq.Contains("m"))
                    { 
                        row.MODEL_ID = "m" + row.CANCER_TYPE_ABBR + sq.Replace("m",""); 
                    }
                    else
                    {
                        row.MODEL_ID = row.CANCER_TYPE_ABBR + sq;
                    }
                    row.PROJECT = context.Request["txtProject"] ?? "";

                    row.LOCATION = context.Request["txtLocation"] ?? "";
                    row.SOURCE_ANIMAL = context.Request["txtSource_Animal"] ?? "";
                    row.OPREATION = context.Request["txtOpreation"] ?? "";
                    row.RN = context.Request["txtRn"] ?? "";
                    row.PN = context.Request["txtPn"] ?? "";
                    row.DATE_OF_PASSAGE_INOCULATION = context.Request["txtDate_of_Passage_inoculation"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDate_of_Passage_inoculation"]);
                    row.STUDY = row.MODEL_ID + "-" + row.RN + row.PN + "-" + row.DATE_OF_PASSAGE_INOCULATION.ToString("yyyyMMdd");
                    row.ANIMAL_STRAIN = context.Request["txtAnimal_Strain"] ?? "";
                    row.ANIMAL_SEX = context.Request["txtAnimal_Sex"] ?? "";
                    row.CURRENT_ANIMAL_EAR_TAG = context.Request["txtCurrent_Animal_Ear_Tag"].Replace("\t", "") ?? "";
                    row.ANIMAL_QUANTITY = context.Request["txtAnimal_Quantity"] ?? "";
                    row.PDX_GROWTH_STATUS = context.Request["txtPDX_growth_status"] ?? "";
                   
                  
                    row.DATE_OF_PASSAGE_TERMINATION = context.Request["txtDate_of_Passage_Termination"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDate_of_Passage_Termination"]);
                    if (row.DATE_OF_PASSAGE_TERMINATION != DateTime.MinValue && row.DATE_OF_PASSAGE_INOCULATION != DateTime.MinValue)
                    {
                        row.DURATION = (row.DATE_OF_PASSAGE_TERMINATION - row.DATE_OF_PASSAGE_INOCULATION).Days.ToString();
                    }
                    else
                    {
                        row.DURATION = "";
                    }
                    row.SOURCE_HOSPITAL = context.Request["txtSource_Hospital"] ?? "";
                    row.PATHOLOGY_INFO_AVAILABLE = context.Request["txtPathology_info_available"] ?? "";
                    row.DATE_OF_PATHOLOGY_INFO_RECEIVED = context.Request["txtDate_of_Pathology_info_Received"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDate_of_Pathology_info_Received"]);
                    row.PATIENT_NO = context.Request["txtPatient_No"] ?? "";
                    row.PATIENT_NAME = context.Request["txtPatient_Name"] ?? "";
                    row.PATIENT_AGE = context.Request["txtPatient_Age"] ?? "";
                    row.PATIENT_SEX = context.Request["txtPatient_Sex"] ?? "";
                    row.PATHOLOGY_INFO_QCED = context.Request["txtPathology_info_Qced"] ?? "";
                    row.COMMENTS = context.Request["txtComments"] ?? "";
                    row.ANIMAL_ROOM_NUMBER = context.Request["txtAnimal_Room_Number"] ?? "";
                    row.MODEL_TUMOR_CHARACTERISTICS = context.Request["txtModel_Tumor_Characteristics"] ?? "";
                    SYS_USER userLogin = CacheHelper.getCurrentUser();
                    row.EDITOR = userLogin.USER_NAME;
                    row.DATE_OF_CREATE = DateTime.Now;

                    decimal id = bll.Update(row);
                    if (row.PDX_GROWTH_STATUS == "PDX taken" && row.MODEL_ID.Substring(0, 1) != "m")
                    {
                        #region 更新至Model_Tree
                        ArrayList lists = new ArrayList();
                        lists.Add(row.MODEL_ID);
                        lists.Add(row.OPREATION);
                        lists.Add(row.RN.Replace("R", ""));
                        lists.Add(row.PN.Replace("P", ""));
                        lists.Add(context.Request["txtDate_of_Passage_inoculation"]);
                        lists.Add(context.Request["txtDate_of_Passage_Termination"]);
                        string location = row.LOCATION.Length > 7 ? row.LOCATION.Substring(6, 2) : row.LOCATION;
                        lists.Add(location);
                        AddToModelTree(lists);
                        #endregion
                    }
                    if (row.CurModel == DealModel.New)
                        row.ID = id;
                    row.CurModel = DealModel.None;
                    #endregion

                }
                catch (Exception ex)
                {
                    msg = ex.Message.ToString();
                }
            }
            else
            {
                msg = "Serial # already exists.";
            }
            context.Response.Write(msg);


        }

        public void SaveNewModel(HttpContext context)
        {

            string msg = "";
            NEWMODEL row = null;
            decimal pid = decimal.Parse(context.Request["hfNewModel_ID"]);
            object[] codes = { context.Request["txtSerial"], context.Request["txtCurrent_Animal_Ear_Tag"] };
            if (!bll.Find(pid, codes, typeof(NEWMODEL)))
            {
                ParamCollection paralist = new ParamCollection();
                paralist.Clause = NEWMODEL.NEWMODEL_ID_FIELD + "= '" + pid + "'";
                BaseList dataPDX = bll.Select(paralist, typeof(NEWMODEL));
                try
                {
                    if (dataPDX.Count == 0)
                    {
                        row = new NEWMODEL(DealModel.New);
                    }
                    else
                    {
                        row = (NEWMODEL)dataPDX[0];
                        row.CurModel = DealModel.Modify;
                        #region 保存旧记录
                        NEWMODEL_LOG logrow = new NEWMODEL_LOG(DealModel.New);
                        logrow.NEWMODEL_ID = row.NEWMODEL_ID;
                        logrow.SERIAL = row.SERIAL;
                        logrow.MODEL_TYPE = row.MODEL_TYPE;
                        logrow.CANCER_TYPE_ABBR = row.CANCER_TYPE_ABBR;
                        logrow.SUBTYPE1 = row.SUBTYPE1;
                        logrow.SUBTYPE2 = row.SUBTYPE2;
                        logrow.MODEL_ID = row.MODEL_ID;
                        logrow.PROJECT = row.PROJECT;
                        logrow.LOCATION = row.LOCATION;
                        logrow.SOURCE_ANIMAL = row.SOURCE_ANIMAL;
                        logrow.OPREATION = row.OPREATION;
                        logrow.RN = row.RN;
                        logrow.PN = row.PN;
                        logrow.DATE_OF_PASSAGE_INOCULATION = row.DATE_OF_PASSAGE_INOCULATION;
                        logrow.STUDY = row.STUDY;
                        logrow.ANIMAL_STRAIN = row.ANIMAL_STRAIN;
                        logrow.ANIMAL_SEX = row.ANIMAL_SEX;
                        logrow.CURRENT_ANIMAL_EAR_TAG = row.CURRENT_ANIMAL_EAR_TAG;
                        logrow.ANIMAL_QUANTITY = row.ANIMAL_QUANTITY;
                        logrow.PDX_GROWTH_STATUS = row.PDX_GROWTH_STATUS;
                        logrow.DATE_OF_PASSAGE_TERMINATION = row.DATE_OF_PASSAGE_TERMINATION;
                        logrow.DURATION = row.DURATION;
                        //logrow.SOURCE_HOSPITAL = row.SOURCE_HOSPITAL;
                        //logrow.PATHOLOGY_INFO_AVAILABLE = row.PATHOLOGY_INFO_AVAILABLE;
                        //logrow.DATE_OF_PATHOLOGY_INFO_RECEIVED = row.DATE_OF_PATHOLOGY_INFO_RECEIVED;
                        //logrow.PATIENT_NO = row.PATIENT_NO;
                        //logrow.PATIENT_NAME = row.PATIENT_NAME;
                        //logrow.PATIENT_AGE = row.PATIENT_AGE;
                        //logrow.PATIENT_SEX = row.PATIENT_SEX;
                        //logrow.PATIENT_PATHOLOGY_INFO_QCED = row.PATIENT_PATHOLOGY_INFO_QCED;
                        logrow.COMMENTS = row.COMMENTS;
                        logrow.ANIMAL_ROOM_NUMBER = row.ANIMAL_ROOM_NUMBER;
                        logrow.EDITOR = row.EDITOR;
                        logrow.DATE_OF_CREATE = row.DATE_OF_CREATE;
                        bll.Update(logrow);
                        #endregion
                    }


                    #region 新增修改
                    row.SERIAL = context.Request["txtSerial"];
                    row.CANCER_TYPE_ABBR = context.Request["txtCancer_Type_Abbr"] ?? "";
                    row.MODEL_TYPE = context.Request["txtModel_Type"] ?? "";
                    row.SUBTYPE1 = context.Request["txtSubtype1"] ?? "";
                    row.SUBTYPE2 = context.Request["txtSubtype2"] ?? "";
                    string sq = row.SERIAL.ToString();
                    if (row.SERIAL.ToString().Length < 4)
                    {
                        sq = row.SERIAL.ToString().PadLeft(4, '0');
                    }
                    if (sq.Contains("m"))
                    {
                        row.MODEL_ID = "m" + row.CANCER_TYPE_ABBR + sq.Replace("m", "");
                    }
                    else
                    {
                        row.MODEL_ID = row.CANCER_TYPE_ABBR + sq;
                    }
                    row.PROJECT = context.Request["txtProject"] ?? "";

                    row.LOCATION = context.Request["txtLocation"] ?? "";
                    row.SOURCE_ANIMAL = context.Request["txtSource_Animal"] ?? "";
                    row.OPREATION = context.Request["txtOpreation"] ?? "";
                    row.RN = context.Request["txtRn"] ?? "";
                    row.PN = context.Request["txtPn"] ?? "";
                    row.DATE_OF_PASSAGE_INOCULATION = context.Request["txtDate_of_Passage_inoculation"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDate_of_Passage_inoculation"]);
                    row.STUDY = row.MODEL_ID + "-" + row.RN + row.PN + "-" + row.DATE_OF_PASSAGE_INOCULATION.ToString("yyyyMMdd");
                    row.ANIMAL_STRAIN = context.Request["txtAnimal_Strain"] ?? "";
                    row.ANIMAL_SEX = context.Request["txtAnimal_Sex"] ?? "";
                    row.CURRENT_ANIMAL_EAR_TAG = context.Request["txtCurrent_Animal_Ear_Tag"].Replace("\t", "") ?? "";
                    row.ANIMAL_QUANTITY = context.Request["txtAnimal_Quantity"] ?? "";

                    row.PDX_GROWTH_STATUS = context.Request["txtPDX_growth_status"] ?? "";
                    row.DATE_OF_PASSAGE_TERMINATION = context.Request["txtDate_of_Passage_Termination"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDate_of_Passage_Termination"]);
                    if (row.DATE_OF_PASSAGE_TERMINATION != DateTime.MinValue && row.DATE_OF_PASSAGE_INOCULATION != DateTime.MinValue)
                    {
                        row.DURATION = (row.DATE_OF_PASSAGE_TERMINATION - row.DATE_OF_PASSAGE_INOCULATION).Days.ToString();
                    }
                    else
                    {
                        row.DURATION = "";
                    }
                    //row.SOURCE_HOSPITAL = context.Request["txtSource_Hospital"] ?? "";
                    //row.PATHOLOGY_INFO_AVAILABLE = context.Request["txtPathology_info_available"] ?? "";
                    //row.DATE_OF_PATHOLOGY_INFO_RECEIVED = context.Request["txtDate_of_Pathology_info_Received"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDate_of_Pathology_info_Received"]);
                    //row.PATIENT_NO = context.Request["txtPatient_No"] ?? "";
                    //row.PATIENT_NAME = context.Request["txtPatient_Name"] ?? "";
                    //row.PATIENT_AGE = context.Request["txtPatient_Age"] ?? "";
                    //row.PATIENT_SEX = context.Request["txtPatient_Sex"] ?? "";
                    //row.PATIENT_PATHOLOGY_INFO_QCED = context.Request["txtPatient_Pathology_info_Qced"] ?? "";
                    row.COMMENTS = context.Request["txtComments"] ?? "";
                    row.ANIMAL_ROOM_NUMBER = context.Request["txtAnimal_Room_Number"] ?? "";
                    row.MODEL_TUMOR_CHARACTERISTICS = context.Request["txtModel_Tumor_Characteristics"] ?? "";
                    SYS_USER userLogin = CacheHelper.getCurrentUser();
                    row.EDITOR = userLogin.USER_NAME;
                    row.DATE_OF_CREATE = DateTime.Now;

                    decimal id = bll.Update(row);

                    if (row.PDX_GROWTH_STATUS == "PDX taken" && row.MODEL_ID.Substring(0, 1) != "m")
                    {
                        #region 更新至Model_Tree
                        ArrayList lists = new ArrayList();
                        lists.Add(row.MODEL_ID);
                        lists.Add(row.OPREATION);
                        lists.Add(row.RN.Replace("R", ""));
                        lists.Add(row.PN.Replace("P", ""));
                        lists.Add(context.Request["txtDate_of_Passage_inoculation"]);
                        lists.Add(context.Request["txtDate_of_Passage_Termination"]);
                        string location = row.LOCATION.Length > 7 ? row.LOCATION.Substring(6, 2) : row.LOCATION;
                        lists.Add(location);
                        AddToModelTree(lists);
                        #endregion
                    }
                    if (row.CurModel == DealModel.New)
                        row.ID = id;
                    row.CurModel = DealModel.None;
                    #endregion

                }
                catch (Exception ex)
                {
                    msg = ex.Message.ToString();
                }
            }
            else
            {
                msg = "Serial # already exists.";
            }
            context.Response.Write(msg);


        }


        public void SaveEndModels(HttpContext context)
        {
            string msg = "";
            ENDMODELS row = null;
            decimal pid = decimal.Parse(context.Request["hfEndModels_ID"]);

            ParamCollection paralist = new ParamCollection();
            paralist.Clause = ENDMODELS.ENDMODELS_ID_FIELD + "= '" + pid + "'";
            BaseList dataPDX = bll.Select(paralist, typeof(ENDMODELS));
            try
            {
                if (dataPDX.Count == 0)
                {
                    row = new ENDMODELS(DealModel.New);
                }
                else
                {
                    row = (ENDMODELS)dataPDX[0];
                    row.CurModel = DealModel.Modify;
                }
                #region 新增修改
                row.LEADER = context.Request["txtLEADER"];
                row.GROUP_NAME = context.Request["txtGROUP_NAME"] ?? "";
                row.RN = context.Request["txtRN"] ?? "";
                row.PN = context.Request["txtPN"] ?? "";
                row.LOCATION = context.Request["txtLOCATION"] ?? "";
                row.IVC = context.Request["txtIVC"];
                row.REVIVAL = context.Request["txtREVIVAL"] ?? "";
                row.HUSBANDRY_START = context.Request["txtHUSBANDRY_START"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtHUSBANDRY_START"]);
                row.DATE_OF_DEAD = context.Request["txtDATE_OF_DEAD"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDATE_OF_DEAD"]);
                row.ANIMAL = context.Request["txtANIMAL"] ?? "";
                row.COMMENTS = context.Request["txtCOMMENTS"] ?? "";
                row.DATE_OF_UPDATE = DateTime.Now;
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


        public void SaveRevival(HttpContext context)
        {
            string msg = "";
            REVIVAL row = null;
            decimal pid = decimal.Parse(context.Request["hfRevival_ID"]);

            ParamCollection paralist = new ParamCollection();
            paralist.Clause = REVIVAL.REVIVAL_ID_FIELD + "= '" + pid + "'";
            BaseList dataPDX = bll.Select(paralist, typeof(REVIVAL));
            try
            {
                if (dataPDX.Count == 0)
                {
                    row = new REVIVAL(DealModel.New);
                }
                else
                {
                    row = (REVIVAL)dataPDX[0];
                    row.CurModel = DealModel.Modify;
                }
                #region 新增修改
                row.SQ1 = context.Request["txtsq1"] ?? "";
                row.SQ = context.Request["txtSq"] ?? "";
                row.CANCERTYPE = context.Request["txtCancerType"] ?? "";
                row.MODELID = context.Request["txtModelID"] ?? "";

                row.BATCH_OF_CRYO_P_TISSUE = context.Request["txtBatch_of_cryo_p_tissue"] ?? "";
                row.DATE_OF_REVIVAL = context.Request["txtDATE_OF_REVIVAL"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDATE_OF_REVIVAL"]);
              
                row.LOCATION = context.Request["txtLocation"] ?? "";
                row.PRE_RN = context.Request["txtPre_Rn"] ?? "";
                row.RN = context.Request["txtRn"] ?? "";
                row.PN = context.Request["txtPn"] ?? "";
             
                row.ANIMAL_STRAIN = context.Request["txtAnimal_Strain"] ?? "";
                row.ANIMAL_QUANTITY = context.Request["txtAnimal_Quantity"] ?? "";
                row.STUDY = context.Request["txtStudy"] ?? "";
                row.PROJECT_NO = context.Request["txtProject_No"] ?? "";


                row.DATE_OF_TISSUE_COLLECTION = context.Request["txtDate_of_Tissue_collection"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDate_of_Tissue_collection"]);
                row.DATE_OF_REVIVAL_SUCEEDED = context.Request["txtDATE_OF_REVIVAL_SUCEEDED"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDATE_OF_REVIVAL_SUCEEDED"]);
                if (RegHelper.IsDateTime(row.DATE_OF_REVIVAL.ToShortDateString()) && RegHelper.IsDateTime(row.DATE_OF_TISSUE_COLLECTION.ToShortDateString()))
                {
                    //row.DURATION_IN_LIN2  = cells[i, 7].StringValue.Trim();
                    row.DURATION_IN_LIN2 = (row.DATE_OF_REVIVAL - row.DATE_OF_TISSUE_COLLECTION).Days.ToString();
                }
                else
                {
                    row.DURATION_IN_LIN2 = "";
                }
                if (row.PRE_RN == row.RN)
                {
                    //row.RN_MATCH = cells[i, 15].StringValue.Trim();
                    row.RN_MATCH = "Yes";
                }
                else
                {
                    row.RN_MATCH = "/";
                }
                row.OUTCOME = context.Request["txtOutcome"] ?? "";

                if (row.OUTCOME == "Succeeded" || row.OUTCOME == "Failed")
                {
                    if (RegHelper.IsDateTime(row.DATE_OF_REVIVAL_SUCEEDED.ToShortDateString()) && RegHelper.IsDateTime(row.DATE_OF_REVIVAL.ToShortDateString()))
                    {
                        //row.DURATION_OF_REVIVAL = cells[i, 17].StringValue.Trim();
                        row.DURATION_OF_REVIVAL = (row.DATE_OF_REVIVAL_SUCEEDED - row.DATE_OF_REVIVAL).Days.ToString();
                    }
                    else
                    {
                        row.DURATION_OF_REVIVAL = "";
                    }
                }
                else
                {
                    row.DURATION_OF_REVIVAL = "";
                }
                row.COMMENT = context.Request["txtComment"] ?? "";
                row.PRE_RECOVERY_PATHOGEN = context.Request["txtPre_Recovery_Pathogen"] ?? "";
                row.RECOVERY_PATHOGEN = context.Request["txtRecovery_Pathogen"] ?? "";
                row.IMPLANTATION_PATHOGEN = context.Request["txtImplantation_Pathogen"] ?? "";
                row.RECOVERY_SNP = context.Request["txtRecovery_SNP"] ?? "";
                row.IMPLANTATION_SNP = context.Request["txtImplantation_SNP"] ?? "";
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

        
        public void SaveGeneticTest(HttpContext context)
        {
            string msg = "";
            GENETICTEST row = null;
            decimal pid = decimal.Parse(context.Request["hfGeneticTest_ID"]);

            ParamCollection paralist = new ParamCollection();
            paralist.Clause = GENETICTEST.GENETICTEST_ID_FIELD + "= '" + pid + "'";
            BaseList dataPDX = bll.Select(paralist, typeof(GENETICTEST));
            try
            {
                if (dataPDX.Count == 0)
                {
                    row = new GENETICTEST(DealModel.New);
                }
                else
                {
                    row = (GENETICTEST)dataPDX[0];
                    row.CurModel = DealModel.Modify;
                }
                #region 新增修改
                row.SQ_NUMBER = context.Request["txtSq_Number"] ?? "";
                row.MODEL_ID = context.Request["txtModel_ID"] ?? "";
                row.SOURCE = context.Request["txtSource"] ?? "";
                row.RNASEQ = context.Request["txtRNAseq"] ?? "";
                row.WES = context.Request["txtWES"] ?? "";
                row.WGS = context.Request["txtWGS"] ?? "";
                row.COMMENT = context.Request["txtComment"] ?? "";
                row.GENETIC_TYPE_UPDATA = context.Request["txtGenetic_type_updata"] ?? "";
                row.PATHOLOGY = context.Request["txtPathology"] ?? "";
                row.PATHOLOG_UPDATA = context.Request["txtPatholog_updata"] ?? "";
                row.COMMENT_ALL = context.Request["txtComment_all"] ?? "";

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


        public void SaveValidationStatus_Huprime(HttpContext context)
        {
            string msg = "";
            VALIDATIONSTATUS_HUPRIME row = null;
            decimal pid = decimal.Parse(context.Request["hfValidationStatus_Huprime_ID"]);

            ParamCollection paralist = new ParamCollection();
            paralist.Clause = VALIDATIONSTATUS_HUPRIME.VALIDATIONSTATUS_HUPRIME_ID_FIELD + "= '" + pid + "'";
            BaseList dataPDX = bll.Select(paralist, typeof(VALIDATIONSTATUS_HUPRIME));
            try
            {
                if (dataPDX.Count == 0)
                {
                    row = new VALIDATIONSTATUS_HUPRIME(DealModel.New);
                }
                else
                {
                    row = (VALIDATIONSTATUS_HUPRIME)dataPDX[0];
                    row.CurModel = DealModel.Modify;
                }
                #region 新增修改
                row.SQ = context.Request["txtSQ"] ?? "";
                row.CANCERTYPE = context.Request["txtCANCERTYPE"] ?? "";
                row.CANCERTYPEABBR = context.Request["txtCANCERTYPEABBR"] ?? "";
                row.MODELID = context.Request["txtMODELID"] ?? "";
                row.MODEL_TYPE = context.Request["txtMODEL_TYPE"] ?? "";
                row.SOURCE = context.Request["txtSOURCE"] ?? "";
                row.PROJECT = FormatHelper.doTran(context.Request["txtPROJECT"]) ?? "";
                //add by Jack 2025.09.04
                row.ARRIVAL_DATE = context.Request["txtArrival_Date"] ?? "";
                row.ESTABLISHED_DATE = context.Request["txtESTABLISHED_DATE"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtESTABLISHED_DATE"]);
                row.ESTABLISHED_LOCATION = context.Request["txtESTABLISHED_LOCATION"] ?? "";
                row.VALIDATIONSTATUS = context.Request["txtVALIDATIONSTATUS"] ?? "";
                row.FINALDATEOFVALIDATION = context.Request["txtFINALDATEOFVALIDATION"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtFINALDATEOFVALIDATION"]);
                row.CRYO_PTISSUE = context.Request["txtCRYO_PTISSUE"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtCRYO_PTISSUE"]);
                row.CRYO_PTISSUE_NUMBER = context.Request["txtCRYO_PTISSUE_NUMBER"] ?? "";
                row.FROZEN_STORAGE = context.Request["txtFROZEN_STORAGE"] ?? "";
                row.FIRST_REVIVAL = context.Request["txtFIRST_REVIVAL"] ?? "";
                row.GC = context.Request["txtGC"] ?? "";
                row.ANIMALROOMNUMBER = context.Request["txtANIMALROOMNUMBER"] ?? "";
                row.DATEOFUPDATE = DateTime.Now;
                row.COMMENT = FormatHelper.doTran(context.Request["txtCOMMENT"]) ?? "";


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

        
         public void SaveValidationStatus_Hukime(HttpContext context)
        {
            string msg = "";
            VALIDATIONSTATUS_HUKIME row = null;
            decimal pid = decimal.Parse(context.Request["hfValidationStatus_Hukime_ID"]);

            ParamCollection paralist = new ParamCollection();
            paralist.Clause = VALIDATIONSTATUS_HUKIME.VALIDATIONSTATUS_HUKIME_ID_FIELD + "= '" + pid + "'";
            BaseList dataPDX = bll.Select(paralist, typeof(VALIDATIONSTATUS_HUKIME));
            try
            {
                if (dataPDX.Count == 0)
                {
                    row = new VALIDATIONSTATUS_HUKIME(DealModel.New);
                }
                else
                {
                    row = (VALIDATIONSTATUS_HUKIME)dataPDX[0];
                    row.CurModel = DealModel.Modify;
                }
                #region 新增修改
                row.SQ = context.Request["txtSQ"] ?? "";
                row.CANCERTYPE = context.Request["txtCANCERTYPE"] ?? "";
                row.CANCERTYPEABBR = context.Request["txtCANCERTYPEABBR"] ?? "";
                row.MODELID = context.Request["txtMODELID"] ?? "";
                row.MODEL_TYPE = context.Request["txtMODEL_TYPE"] ?? "";
                row.SOURCE = context.Request["txtSOURCE"] ?? "";
                row.SUBTYPE = context.Request["txtSUBTYPE"] ?? "";
                row.ESTABLISHED_DATE = context.Request["txtESTABLISHED_DATE"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtESTABLISHED_DATE"]);
                row.ESTABLISHED_LOCATION = context.Request["txtESTABLISHED_LOCATION"] ?? "";
                row.VALIDATIONSTATUS = context.Request["txtVALIDATIONSTATUS"] ?? "";
                row.FINALDATEOFVALIDATION = context.Request["txtFINALDATEOFVALIDATION"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtFINALDATEOFVALIDATION"]);
                row.REVIVAL = context.Request["txtREVIVAL"] ?? "";
                row.TU = context.Request["txtTU"] ?? "";
                row.FACS = context.Request["txtFACS"] ?? "";
                row.BANK = context.Request["txtbank"] ?? "";
                row.PASSAGE = context.Request["txtpassage"] ?? "";
                row.SNP = context.Request["txtsnp"] ?? "";
                row.DATEOFUPDATE = DateTime.Now;
                row.COMMENT = FormatHelper.doTran(context.Request["txtCOMMENT"]) ?? "";


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

        public void AddToModelTree(ArrayList lists)
        {
            BaseList importData2 = new BaseList();
            DataTable importData = new DataTable();
            importData.Columns.Add("Model_ID");
            importData.Columns.Add("Status");
            importData.Columns.Add("Rn");
            importData.Columns.Add("Pn");
            importData.Columns.Add("DOI");
            importData.Columns.Add("DOT");
            importData.Columns.Add("Location");
            importData.Columns.Add("AID", typeof(Int32));
            importData.Columns.Add("P_ID", typeof(Int32));

            importData2 = new BaseList();

            BaseList data_Tree = new BaseList();
            ParamCollection paraList = new ParamCollection();
            paraList.Clause += ANIMAL_TREE.P_ID_FIELD + "='0'";
            BaseList Models = bll.Select(paraList, typeof(ANIMAL_TREE));
            List<ANIMAL_TREE> trees = Models.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert);
            ArrayList tempMID = new ArrayList();
            BaseList alltree = new BaseList();


            string str_doi = lists[4].ToString().Trim() == "" ? "" : DateTime.Parse(lists[4].ToString()).ToString("yyyy/MM/dd");
            string str_dot = lists[5].ToString().Trim() == "" ? "" : DateTime.Parse(lists[5].ToString()).ToString("yyyy/MM/dd");
                     

            if (lists[2].ToString() != "" && lists[0].ToString() != "Model ID")//Rn不为空
            {
                ANIMAL_TREE row = trees.Find(delegate(ANIMAL_TREE perm) { return perm.MODEL_ID == lists[0].ToString(); });
                if (row == null)
                {
                    #region
                    row = new ANIMAL_TREE(DealModel.New);
                    row.MODEL_ID = lists[0].ToString();
                    row.STATUS = "";
                    row.RN = "";
                    row.PN = "";
                    row.DOI = "";
                    row.LOCATION = "";
                    row.DOT = "";
                    row.AID = (SeqNoRule.MaxSeqNo("ANIMAL_TREE", "P_ID", "0", "AID") + 1).ToString();
                    row.P_ID = "0";
                    bll.Update(row);
                    trees.Add(row);




                    ANIMAL_TREE RnRow = new ANIMAL_TREE(DealModel.New);
                    RnRow.MODEL_ID = lists[0].ToString();
                    RnRow.STATUS = "";
                    RnRow.RN = lists[2].ToString();
                    RnRow.PN = "";
                    RnRow.DOI = "";
                    RnRow.DOT = "";
                    RnRow.LOCATION = "";
                    RnRow.AID = row.MODEL_ID + "-" + RnRow.RN;
                    RnRow.P_ID = row.AID;
                    bll.Update(RnRow);


                    ANIMAL_TREE RnPnRow = new ANIMAL_TREE(DealModel.New);
                    RnPnRow.MODEL_ID = lists[0].ToString();
                    RnPnRow.STATUS = "";
                    RnPnRow.RN = lists[2].ToString();
                    RnPnRow.PN = lists[3].ToString();
                    RnPnRow.DOI = "";
                    RnPnRow.DOT = "";
                    RnPnRow.LOCATION = "";
                    RnPnRow.AID = RnRow.AID + RnPnRow.RN + RnPnRow.PN;
                    RnPnRow.P_ID = RnRow.AID;
                    bll.Update(RnPnRow);


                    ANIMAL_TREE DOIRow = new ANIMAL_TREE(DealModel.New);
                    DOIRow.MODEL_ID = lists[0].ToString();
                    DOIRow.STATUS = "";
                    DOIRow.RN = lists[2].ToString();
                    DOIRow.PN = lists[3].ToString();
                    DOIRow.DOI = str_doi;
                    DOIRow.DOT = str_dot;
                    DOIRow.LOCATION = "";
                    string _dot = "";
                    if (str_dot != "")
                    {
                        _dot = "-" + str_dot;
                    }
                    DOIRow.AID = RnPnRow.AID + "-" + DOIRow.DOI + _dot;
                    DOIRow.P_ID = RnPnRow.AID;
                    bll.Update(DOIRow);


                    ANIMAL_TREE newRow = new ANIMAL_TREE(DealModel.New);

                    newRow.MODEL_ID = lists[0].ToString();
                    newRow.STATUS = lists[1].ToString();
                    newRow.RN = lists[2].ToString();
                    newRow.PN = lists[3].ToString();
                    newRow.DOI = str_doi;
                    newRow.DOT = str_dot;
                    newRow.LOCATION = lists[6].ToString();
                    newRow.AID = DOIRow.AID + "-" + newRow.LOCATION;
                    newRow.P_ID = DOIRow.AID;
                    //aid = int.Parse(newRow[8].ToString());
                    //rn = lists[3].ToString();
                    bll.Update(newRow);
                    #endregion
                }
                else
                {
                    List<ANIMAL_TREE> alltreeData = null;
                    if (!tempMID.Contains(lists[0].ToString()))
                    {
                        ParamCollection paralist = new ParamCollection();
                        paralist.Clause += ANIMAL_TREE.MODEL_ID_FIELD + "='" + lists[0].ToString() + "'";
                        alltree = bll.Select(paralist, typeof(ANIMAL_TREE));
                        tempMID.Add(lists[0].ToString());
                        alltreeData = alltree.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert);
                    }
                    else
                    {
                        ParamCollection paralist = new ParamCollection();
                        paralist.Clause += ANIMAL_TREE.MODEL_ID_FIELD + "='" + lists[0].ToString() + "'";
                        alltree = bll.Select(paralist, typeof(ANIMAL_TREE));

                        List<ANIMAL_TREE> addData = importData2.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert).FindAll(delegate(ANIMAL_TREE perm) { return perm.MODEL_ID == lists[0].ToString(); });
                        IEnumerable<ANIMAL_TREE> alltreeData2 = alltree.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert).Union(addData);
                        alltreeData = alltreeData2.ToList();
                        tempMID.Add(lists[0].ToString());
                    }
                    ANIMAL_TREE RnData = alltreeData.Find(delegate(ANIMAL_TREE perm) { return perm.RN == lists[2].ToString() && perm.PN == ""; });
                    //lastData = lastData.OrderBy(s => decimal.Parse(s.PN)).ToList();
                    if (RnData != null)// 有Rn
                    {
                        ANIMAL_TREE RNPNRow = alltreeData.Find(delegate(ANIMAL_TREE perm) { return perm.RN == lists[2].ToString() && perm.PN == lists[3].ToString() && perm.DOI == ""; });
                        if (RNPNRow != null)//有RnPn
                        {

                            ANIMAL_TREE DOIData = alltreeData.Find(delegate(ANIMAL_TREE perm) { return perm.RN == lists[2].ToString() && perm.PN == lists[3].ToString() && perm.DOI == str_doi && perm.LOCATION == ""; });
                            if (DOIData != null)//有DOI
                            {
                                ANIMAL_TREE LocationData = alltreeData.Find(delegate(ANIMAL_TREE perm) { return perm.PN == lists[3].ToString() && perm.DOI == str_doi && perm.LOCATION == lists[6].ToString(); });

                                if (LocationData != null)//有Location
                                {
                                    //插入tree141113-Revival时用
                                    if (str_dot != "" && LocationData.DOT == "")
                                    {
                                        DOIData.CurModel = DealModel.Modify;
                                        DOIData.DOT = str_dot;
                                        DOIData.AID = DOIData.P_ID + "-" + DOIData.DOI + "-" + DOIData.DOT;
                                        bll.Update(DOIData);
                                        LocationData.CurModel = DealModel.Modify;
                                        LocationData.DOT = str_dot;
                                        LocationData.P_ID = LocationData.P_ID + "-" + LocationData.DOT;
                                        LocationData.AID = LocationData.P_ID + "-" + LocationData.LOCATION;
                                        bll.Update(LocationData);
                                    }
                                    else if (str_dot != "" && LocationData.DOT != "")
                                    {
                                        DOIData.CurModel = DealModel.Modify;
                                        DOIData.DOT = str_dot;
                                        DOIData.AID = DOIData.P_ID + "-" + DOIData.DOI + "-" + DOIData.DOT;
                                        bll.Update(DOIData);
                                        LocationData.CurModel = DealModel.Modify;
                                        LocationData.DOT = str_dot;
                                        LocationData.P_ID = DOIData.AID;
                                        LocationData.AID = LocationData.P_ID + "-" + LocationData.LOCATION;
                                        bll.Update(LocationData);
                                    }
                                }
                                else
                                {
                                    #region 没有Location
                                    ANIMAL_TREE newRow = new ANIMAL_TREE(DealModel.New);

                                    newRow.MODEL_ID = lists[0].ToString();
                                    newRow.STATUS = lists[1].ToString();
                                    newRow.RN = lists[2].ToString();
                                    newRow.PN = lists[3].ToString();
                                    newRow.DOI = str_doi;
                                    newRow.DOT = str_dot;
                                    newRow.LOCATION = lists[6].ToString();
                                    newRow.AID = DOIData.AID + "-" + newRow.LOCATION;
                                    newRow.P_ID = DOIData.AID;

                                    alltree.Add(newRow);
                                    importData2.Add(newRow);


                                    #endregion

                                }
                            }
                            else
                            {
                                #region 没有DOI
                                ANIMAL_TREE DOIRow = new ANIMAL_TREE(DealModel.New);
                                DOIRow.MODEL_ID = lists[0].ToString();
                                DOIRow.STATUS = "";
                                DOIRow.RN = lists[2].ToString();
                                DOIRow.PN = lists[3].ToString();
                                DOIRow.DOI = str_doi;
                                DOIRow.DOT = str_dot;
                                DOIRow.LOCATION = "";
                                string _dot = "";
                                if (str_dot != "")
                                {
                                    _dot = "-" + str_dot;
                                }
                                DOIRow.AID = RNPNRow.AID + "-" + DOIRow.DOI + _dot;
                                DOIRow.P_ID = RNPNRow.AID;
                                alltree.Add(DOIRow);
                                importData2.Add(DOIRow);


                                ANIMAL_TREE newRow = new ANIMAL_TREE(DealModel.New);

                                newRow.MODEL_ID = lists[0].ToString();
                                newRow.STATUS = lists[1].ToString();
                                newRow.RN = lists[2].ToString();
                                newRow.PN = lists[3].ToString();
                                newRow.DOI = str_doi;
                                newRow.DOT = str_dot;
                                newRow.LOCATION = lists[6].ToString();
                                newRow.AID = DOIRow.AID + "-" + newRow.LOCATION;
                                newRow.P_ID = DOIRow.AID;

                                alltree.Add(newRow);
                                importData2.Add(newRow);
                                #endregion
                            }
                        }
                        else
                        {
                            #region 没有RnPn
                            ANIMAL_TREE RnPnRow = new ANIMAL_TREE(DealModel.New);
                            RnPnRow.MODEL_ID = lists[0].ToString();
                            RnPnRow.STATUS = "";
                            RnPnRow.RN = lists[2].ToString();
                            RnPnRow.PN = lists[3].ToString();
                            RnPnRow.DOI = "";
                            RnPnRow.DOT = "";
                            RnPnRow.LOCATION = "";
                            RnPnRow.AID = RnData.AID + RnPnRow.RN + RnPnRow.PN;
                            RnPnRow.P_ID = RnData.AID;
                            alltree.Add(RnPnRow);
                            importData2.Add(RnPnRow);


                            ANIMAL_TREE DOIRow = new ANIMAL_TREE(DealModel.New);
                            DOIRow.MODEL_ID = lists[0].ToString();
                            DOIRow.STATUS = "";
                            DOIRow.RN = lists[2].ToString();
                            DOIRow.PN = lists[3].ToString();
                            DOIRow.DOI = str_doi;
                            DOIRow.DOT = str_dot;
                            DOIRow.LOCATION = "";
                            string _dot = "";
                            if (str_dot != "")
                            {
                                _dot = "-" + str_dot;
                            }
                            DOIRow.AID = RnPnRow.AID + "-" + DOIRow.DOI + _dot;
                            DOIRow.P_ID = RnPnRow.AID;
                            alltree.Add(DOIRow);
                            importData2.Add(DOIRow);


                            ANIMAL_TREE newRow = new ANIMAL_TREE(DealModel.New);

                            newRow.MODEL_ID = lists[0].ToString();
                            newRow.STATUS = lists[1].ToString();
                            newRow.RN = lists[2].ToString();
                            newRow.PN = lists[3].ToString();
                            newRow.DOI = str_doi;
                            newRow.DOT = str_dot;
                            newRow.LOCATION = lists[6].ToString();
                            newRow.AID = DOIRow.AID + "-" + newRow.LOCATION;
                            newRow.P_ID = DOIRow.AID;
                            //aid = int.Parse(newRow[8].ToString());
                            //rn = lists[3].ToString();

                            alltree.Add(newRow);
                            importData2.Add(newRow);
                            #endregion

                        }
                    }
                    else
                    {
                        #region 没有Rn
                        ANIMAL_TREE RnRow = new ANIMAL_TREE(DealModel.New);
                        RnRow.MODEL_ID = lists[0].ToString();
                        RnRow.STATUS = "";
                        RnRow.RN = lists[2].ToString();
                        RnRow.PN = "";
                        RnRow.DOI = "";
                        RnRow.DOT = "";
                        RnRow.LOCATION = "";
                        RnRow.AID = row.MODEL_ID + "-" + RnRow.RN;
                        RnRow.P_ID = row.AID;
                        alltree.Add(RnRow);
                        importData2.Add(RnRow);


                        ANIMAL_TREE RnPnRow = new ANIMAL_TREE(DealModel.New);
                        RnPnRow.MODEL_ID = lists[0].ToString();
                        RnPnRow.STATUS = "";
                        RnPnRow.RN = lists[2].ToString();
                        RnPnRow.PN = lists[3].ToString();
                        RnPnRow.DOI = "";
                        RnPnRow.DOT = "";
                        RnPnRow.LOCATION = "";
                        RnPnRow.AID = RnRow.AID + RnPnRow.RN + RnPnRow.PN;
                        RnPnRow.P_ID = RnRow.AID;
                        alltree.Add(RnPnRow);
                        importData2.Add(RnPnRow);


                        ANIMAL_TREE DOIRow = new ANIMAL_TREE(DealModel.New);
                        DOIRow.MODEL_ID = lists[0].ToString();
                        DOIRow.STATUS = "";
                        DOIRow.RN = lists[2].ToString();
                        DOIRow.PN = lists[3].ToString();
                        DOIRow.DOI = str_doi;
                        DOIRow.DOT = str_dot;
                        DOIRow.LOCATION = "";
                        string _dot = "";
                        if (str_dot != "")
                        {
                            _dot = "-" + str_dot;
                        }
                        DOIRow.AID = RnPnRow.AID + "-" + DOIRow.DOI + _dot;
                        DOIRow.P_ID = RnPnRow.AID;
                        alltree.Add(DOIRow);
                        importData2.Add(DOIRow);


                        ANIMAL_TREE newRow = new ANIMAL_TREE(DealModel.New);

                        newRow.MODEL_ID = lists[0].ToString();
                        newRow.STATUS = lists[1].ToString();
                        newRow.RN = lists[2].ToString();
                        newRow.PN = lists[3].ToString();
                        newRow.DOI = str_doi;
                        newRow.DOT = str_dot;
                        newRow.LOCATION = lists[6].ToString();
                        newRow.AID = DOIRow.AID + "-" + newRow.LOCATION;
                        newRow.P_ID = DOIRow.AID;
                        //aid = int.Parse(newRow[8].ToString());
                        //rn = lists[3].ToString();

                        alltree.Add(newRow);
                        importData2.Add(newRow);

                        #endregion

                    }


                }
            }

            ArrayList columns = new ArrayList();
            foreach (DataColumn dc in importData.Columns)
            {
                columns.Add(dc.ColumnName);
            }
            ojbReportRule.InsertBigSql(UtitityHelper.ToDataTable(importData2), columns, "ANIMAL_TREE");


        }

        public void Save_SpecimenStocks(HttpContext context)
        { 
        
            string msg = "";
            SPECIMEN_STOCK row = null;
            decimal pid = decimal.Parse(context.Request["hfStocks_ID"]);
            //if (!bll.Find(pid, context.Request["txtSerial"], typeof(NEWMODEL)))
            //{
                ParamCollection paralist = new ParamCollection();
                paralist.Clause = SPECIMEN_STOCK.SPECIMEN_STOCK_ID_FIELD + "= '" + pid + "'";
                BaseList dataPDX = bll.Select(paralist, typeof(SPECIMEN_STOCK));
                try
                {
                    if (dataPDX.Count == 0)
                    {
                        row = new SPECIMEN_STOCK(DealModel.New);
                    }
                    else
                    {
                        row = (SPECIMEN_STOCK)dataPDX[0];
                        row.CurModel = DealModel.Modify;
                    }
                    row.MODEL_ID = context.Request["txtModel_ID"]??"";

                    row.DATE_OF_TISSUE_COLLECTION = context.Request["txtDate_of_Tissue_Collection"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtDate_of_Tissue_Collection"]);
                    row.IMPORT_DATE = context.Request["txtImport_Date"] == "" ? DateTime.MinValue : DateTime.Parse(context.Request["txtImport_Date"]);
                    row.SITE_OF_TISSUE_COLLECTION = context.Request["txtSite_of_Tissue_Collection"] ?? "";
                    row.TISSUE_TYPE = context.Request["txtTissue_Type"] ?? "";
                    row.PRESERVE_METHOD = context.Request["txtPreserve_Method"] ?? "";
                    row.TREATMENT_TO_MICE = context.Request["txtTreatment_To_Mice"] ?? "";
                    row.LOCATION_ID = context.Request["txtLocation_ID"] ?? "";
                    row.WELL_ID = context.Request["txtWell_ID"] ?? "";
                    row.STR = context.Request["txtSTR"] ?? "";
                   string aa = context.Request["animal_id"] ?? "";

                   ParamCollection paralist2 = new ParamCollection();
                   paralist2.Clause = ANIMAL_INFO.ANIMAL_INFO_ID_FIELD + "= '" + aa + "'";
                   BaseList animals = bll.Select(paralist2, typeof(ANIMAL_INFO));
                   if (animals.Count > 0)
                   {
                       ANIMAL_INFO animal_row = (ANIMAL_INFO)animals[0];
                       row.RN = animal_row.RN;
                       row.PN = animal_row.PN;
                       row.DATE_OF_INOCULATION = animal_row.DOI;
                       row.ANIMAL_NUMBER = animal_row.ANIMAL_NUMBER;
                       row.TOTAL_TUMOR_VOLUME = animal_row.LOCATION_OF_LIVE_ANIMAL;
                       row.IMPORT_PROJECT_NUMBER = animal_row.SOURCE_PROJECT;

                   }

                   
                   
                    decimal id = bll.Update(row);
                    if (row.CurModel == DealModel.New)
                        row.ID = id;
                    row.CurModel = DealModel.None;
                    //msg = "Save successfully.";
                }
                catch (Exception ex)
                {
                    msg = ex.Message.ToString();
                }
            //}
            //else
            //{
            //    msg = "Serial # already exists.";
            //}
            context.Response.Write(msg);

        
        }
        

        public void SaveRequest2(HttpContext context)
        {
            BaseList dataRequest = new BaseList();

            REQUEST row = null;

            string msg = "";
            try
            {
                string txtEmail = "";
                string strs = context.Request["txtImport"] ?? "";
                string[] str = strs.Split('\n');
                foreach (string txt in str)
                {

                    string[] lists = txt.Split('\t');
                    if (lists.Count() > 12)
                    {
                        BaseList exist = new BaseList();
                        if (lists[5] != "")
                        {
                            ParamCollection query1 = new ParamCollection();
                            query1.Clause = REQUEST.PROJECT_NUMBER_FIELD + "='" + lists[5] + "'";
                            exist = bll.Select(query1, typeof(REQUEST));
                        }
                        if (exist.Count == 0)
                        {
                            row = new REQUEST(DealModel.New);
                            row.DATE_REQUEST = DateTime.Parse(lists[0]);
                            row.CLIENT = lists[1];
                            row.BD = lists[2];
                            row.PM = lists[3];
                            row.LEADING_SD = lists[5];
                            row.SD = lists[7];
                            row.PARENT_PROJECT = lists[4];
                            row.PROJECT_NUMBER = lists[6];
                            row.TYPE_OF_STUDY = lists[8];
                            row.TUMOR_TYPE = lists[9];
                            row.SUBTYPE1 = lists[10];
                            row.SUBTYPE2 = lists[11];
                            row.MODEL_ID = lists[12].Replace("\n", "");
                            row.POTENTIAL_STUDY_SIZE = lists[13];
                            row.SPECIAL_REQUIREMENTS = lists[14];
                            //row.REQUEST_ONLY = lists[15];
                            row.SIGNED = "";
                            row.CREATE_OF_DATE = DateTime.Now;
                            row.ISDELETE = "N";
                            row.RESPONDER = "";
                            row.RESPONDER_ID = "";
                            row.DATE_RESPONDING = DateTime.MinValue;
                            row.HAVE_CONFIRMED = "N";

                            dataRequest.Add(row);


                            string body = requestEmailgrid(row.DATE_REQUEST_F, row.PROJECT_NUMBER, row.MODEL_ID, row.POTENTIAL_STUDY_SIZE.ToString(), row.CLIENT, row.BD, row.SD, row.TYPE_OF_STUDY);
                            txtEmail += body;

                        }
                    }
                }

                bll.UpdateAllByParams(dataRequest);

                string Subject = string.Format("New HuData Request");
                string title = requestEmailtitle(txtEmail);
                string[] toMails = { "lijun@crownbio.com" };
                msg = SendEmail.SendMail_SMTP("html", Subject, title, toMails, "Send successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
            }
            context.Response.Write(msg);
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
	#endregion
     

   

        #region 只查类别
        private ParamCollection queryOnlytype(HttpContext context, string model_ids)
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


    
       
        private ParamCollection queryUpdateModels(HttpContext context, string hfRequest_id, string mids)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = RESPOND_MODELS.REQUEST_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} = '{2}' )", RESPOND_MODELS.TABLE_NAME, column, hfRequest_id);

            string ids = "";
            foreach (string a in mids.Split(','))
            {
                if (a != "")
                {
                    ids += "'" + a + "',";
                }
            }
            if (mids != "")
            {
                column = RESPOND_MODELS.MODEL_ID_FIELD;
                Clause += string.Format("AND ({0}.{1} not in ({2}) )", RESPOND_MODELS.TABLE_NAME, column, ids.TrimEnd(','));
            }
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection queryRespondModels(HttpContext context, string hfRequest_id)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = RESPOND_MODELS.REQUEST_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} = '{2}' )", RESPOND_MODELS.TABLE_NAME, column, hfRequest_id);
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }
        public void SavePorjectbooking(HttpContext context)
        {
            string model_ids = context.Request["model_ids"] ?? "";
            string hfRequest_id = context.Request["hfRequest_id"] ?? "";
            string msg = "";

            try
            {
                BaseList dataRespond = bll.Select(queryEdit(context.Request["hfRequest_id"].ToString()), typeof(REQUEST));
                REQUEST row = (REQUEST)dataRespond[0];
                row.CurModel = DealModel.Modify;
                row.HAVE_CONFIRMED = "Y";
                row.CONFIRM_DATE = DateTime.Now;
                bll.Update(row);

                BaseList dataModels = bll.Select(queryRespondModels(context, hfRequest_id), typeof(RESPOND_MODELS));
                BaseList databooking = bll.Select(typeof(PROJECT_BOOKING));
              
                if (dataModels.Count > 0)
                {
                    foreach (RESPOND_MODELS dr in dataModels)
                    {
                        PROJECT_BOOKING row2 = new PROJECT_BOOKING(DealModel.New);
                        row2.REQUEST_ID = decimal.Parse(hfRequest_id);
                        //row2.CONFIRM_DATE = DateTime.Now;
                        //row2.PDXMODEL_INFO_ID = dr.MODEL_ID;
                        row2.BOOKING = dr.RN + dr.PN;
                        databooking.Add(row2);
                    }
                    bll.UpdateAllByParams(databooking);
                  
                }
                msg = "Booking successfully";
            }

            catch (Exception ex)
            {
                msg = ex.Message.ToString();
            }

            context.Response.Write(msg);

        }

        public void SaveRespond(HttpContext context)
        {
            string msg = "";
            string mids= context.Request["mids"].ToString();
            string[] all=  mids.Split(',');
          
            //mids = string.Join(",", mylist1.ToArray());

            string remark= context.Request["remark"].ToString();
            
           
            BaseList datadelete = bll.Select(queryUpdateModels(context, context.Request["hfRequest_id"].ToString(),""), typeof(RESPOND_MODELS));
            if (datadelete.Count > 0)
            {
                foreach (RESPOND_MODELS del in datadelete)
                {
                    del.CurModel = DealModel.Delete;
                }
                bll.UpdateAllByParams(datadelete);
            }
            BaseList updata = new BaseList();//加入RN，PN
            foreach(string al in all)
            {
                string[] str = al.Split(';');
                RESPOND_MODELS row3 = new RESPOND_MODELS(DealModel.New);
                row3.REQUEST_ID =decimal.Parse(context.Request["hfRequest_id"].ToString());
                row3.MODEL_ID = str[0];
                row3.PDXMODEL_INFO_ID = str[0];
                row3.RN = str[1];
                row3.PN = str[2];
                row3.DOT = str[3];
                updata.Add(row3);
            }
            bll.UpdateAllByParams(updata);

            BaseList dataRespond = bll.Select(queryEdit(context.Request["hfRequest_id"].ToString()), typeof(REQUEST));
            REQUEST row2 = (REQUEST)dataRespond[0];
            try
            {
                row2.CurModel = DealModel.Modify;
                row2.DATE_RESPONDING = DateTime.Now;
                row2.RESPONDER_ID = CacheHelper.getCurrentUser().USER_ID.ToString();
                row2.RESPONDER = CacheHelper.getCurrentUser().USER_NAME.ToString();
                row2.REMARK = remark;
                bll.UpdateAllByParams(dataRespond);
                row2.CurModel = DealModel.None;

                BaseList dataRequest = bll.Select(queryRequester(row2.REQUESTER_ID.ToString()), typeof(SYS_USER));
                string requester = ((SYS_USER)dataRequest[0]).EMAIL;

                BaseList dataRespondModels = bll.Select(queryRespondModels(context,row2.REQUEST_ID.ToString()), typeof(RESPOND_MODELS));


                string body = respondEmailgrid(dataRespondModels, row2.RESPONDER, row2.DATE_RESPONDING_F, row2.REQUEST_ID.ToString(), remark);

                string Subject = string.Format("New HuData Respond");
                string[] toMails = { requester };
                msg = SendEmail.SendMail_SMTP("html", Subject, body, toMails, "Respond successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
            }
            context.Response.Write(msg);
        }

        public string respondEmailgrid(BaseList data, string a, string b, string c, string remark)
        {
           
            StringBuilder Body = new StringBuilder();
            Body.Append("<table cellpadding='0' cellspacing='0' width=\"1040\" border='1' style=\"word-break:keep-all;word-wrap:break-word\">");
            Body.Append("<tr>");
            Body.Append("<td>Responder</td><td>Date of Responding</td><td>Request ID</td><td>Model ID</td><td>Fit For Efficacy</td><td>DOT</td>");
            Body.Append("</tr>");
            if (data.Count > 0)
            {
                foreach (RESPOND_MODELS row in data)
                {
                    string dot = row.RN + row.PN + " " + row.DOT;
                    Body.Append("<tr>");
                    Body.Append("<td style=\"width:80px\">" + a + "</td><td style=\"width:80px\">" + b + "</td><td style=\"width:80px\">" + c + "</td><td style=\"width:80px\">" + row.MODEL_ID + "</td><td style=\"width:80px\">" + "Yes" + "</td><td style=\"width:100px\">" + dot + "</td>");
                    Body.Append("</tr>");
                }
            }
            else {
                Body.Append("<tr>");
                Body.Append("<td style=\"width:80px\">" + a + "</td><td style=\"width:80px\">" + b + "</td><td style=\"width:80px\">" + c + "</td><td style=\"width:80px\">&nbsp;</td><td style=\"width:80px\">&nbsp;</td><td style=\"width:100px\">&nbsp;</td>");
                Body.Append("</tr>");
            }
            Body.Append("</table>");
            Body.Append("</br>");
            if (remark != "")
            {
                Body.Append(remark);
            }
            Body.Append("</br>");
            Body.Append("The Administrator");
            return Body.ToString();
        }

        public void CheckRequest(HttpContext context)
        {
            string msg = "";
            //string txtDate_Request = context.Request["txtDate_Request"] ?? "";
            //if (!RegHelper.IsDateTime(txtDate_Request))
            //{
            //    msg += "Date of Request is invalid." + "\n";
            //}
            //string cc1 = context.Request["ccBD"] ?? "";
            //string cc2 = context.Request["ccSD"] ?? "";
            //SYS_USER userLogin = CacheHelper.getCurrentUser();
            //if (userLogin.DEPARTMENT == "BD" || userLogin.DEPARTMENT == "SD")
            //{
            //    if (cc1 == "" && cc2 == "")
            //    {
            //        msg += "BD or SD is required." + "\n";
            //    }
            //}
            //string txtOthers = context.Request["txtOthers"] ?? "";
            //if (txtOthers != "")
            //{
            //    string[] emails = txtOthers.Split(' ');
            //    foreach (string email in emails)
            //    {
            //        if (!RegHelper.IsEmail(email))
            //        {
            //            msg += "Others to Notify is not a valid email address." + "\n";
            //            break;
            //        }
            //    }
            //}
            string txtModel_ID = context.Request["txtModel_ID"] ?? "";
            if (txtModel_ID == "")
            {
                string ddlTumor_Type = context.Request["ddlTumor_Type"] ?? "";
                if (ddlTumor_Type == "" || ddlTumor_Type == " ")
                {
                    msg += "Model ID or Cancer Type is required." + "\n";
                }
            }
            else
            {
                BaseList data = bll.Select(querymodel(txtModel_ID), typeof(PDXMODEL_INFO));
                if (data.Count == 0)
                {
                    msg += "Model ID is invalid." + "\n";
                }
            }
            context.Response.Write(msg);
        }

        public void CheckIsRole_Edit(HttpContext context)
        {
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            string function = context.Request["_modulepPge"] ?? "";
            bool cbsd = ojbReportRule.GetUserFunctions(userLogin.Permission, function, "CBSD edit only");
            bool cbsg = ojbReportRule.GetUserFunctions(userLogin.Permission, function, "CBSG edit only");
            bool cbnc = ojbReportRule.GetUserFunctions(userLogin.Permission, function, "CBNC edit only");
            bool all = ojbReportRule.GetUserFunctions(userLogin.Permission, function, "edit");
            bool pm = ojbReportRule.GetUserFunctions(userLogin.Permission, function, "PM-edit");
            var res = new { cbsd, cbsg, cbnc, all, pm };
            context.Response.Write(JsonConvert.SerializeObject(res));
        }

        public void CheckIsRole_View(HttpContext context)
        {
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            string function = context.Request["_modulepPge"] ?? "";
            bool cbsd = ojbReportRule.GetUserFunctions(userLogin.Permission, function, "CBSD view only");
            bool cbsg = ojbReportRule.GetUserFunctions(userLogin.Permission, function, "CBSG view only");
            bool cbnc = ojbReportRule.GetUserFunctions(userLogin.Permission, function, "CBNC view only");
            bool all = ojbReportRule.GetUserFunctions(userLogin.Permission, function, "view");
            var res = new { cbsd, cbsg, cbnc, all };
            context.Response.Write(JsonConvert.SerializeObject(res));
        }


        private ParamCollection querymodel(string model)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";

            column = PDXMODEL_INFO.MODEL_ID_FIELD;
            Clause += string.Format("({0}.{1} =@{1})", PDXMODEL_INFO.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, model));

            paraList.Clause = Clause;
            return paraList;
        }

        public void getCancerType_Abbr(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";

            DataTable dataCancerType = ojbRuleHuData.GetCancerType_Abbr();
            if (dataCancerType.Rows.Count > 0)
            {
                foreach (DataRow node in dataCancerType.Rows)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node["Abbreviation"], node["CancerType"]);
                    resultStr += "},";
                }
            }
            else {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }

        public void getCancertype(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
  
            DataTable dataCancerType = ojbRuleHuData.GetCancerType();
            if (dataCancerType.Rows.Count > 0)
            {
                foreach (DataRow node in dataCancerType.Rows)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node["CancerType"], node["CancerType"]);
                    resultStr += "},";
                }
            }
            else {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }

       
        

        public void getDDLtxtSource(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
            string ddlname = context.Request["ddlname"] ?? "";
            ParamCollection paralist = new ParamCollection();
            paralist.Clause = DROPDOWNLIST.DROPDOWNLIST_NAME_FIELD + " = '" + ddlname + "'";
            BaseList data = bll.Select(paralist, typeof(DROPDOWNLIST));
            if (data.Count > 0)
            {
                DROPDOWNLIST row = (DROPDOWNLIST)data[0];
                foreach (string node in row.DROPDOWNLIST_CONTEXT.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.Replace("\\n", ""), node.Replace("\\n", ""));
                    resultStr += "},";
                }
            }
            else
            {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }
        
        public void getsearchAlive(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";

            resultStr += "{";
            resultStr += string.Format("\"id\": \"\", \"text\": \"{0}\", \"state\": \"open\"", "Select All");
            DataTable dataCancerType = ojbRuleHuData.getSearchAlive();

            if (dataCancerType.Rows.Count > 0)
            {
                resultStr += ",\"children\":";
                resultStr += "[";
                foreach (DataRow node in dataCancerType.Rows)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node["Mortality_Observation"], node["Mortality_Observation"]);
                    resultStr += "},";
                }
                resultStr = resultStr.Substring(0, resultStr.Length - 1);
                resultStr += "]";
            }
            resultStr += "},";

            resultStr = resultStr.Substring(0, resultStr.Length - 1);


            resultStr += "]";

            context.Response.Write(resultStr);
        }


        public void getSponsor(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
            BaseList data = bll.Select(typeof(SPONSOR_AX_CODE));
            if (data.Count > 0)
            {
                foreach (SPONSOR_AX_CODE node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.AX_CODE, FormatHelper.doTran(node.SPONSOR));
                    resultStr += "},";
                }
            }
            else {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }

        public void getccBD(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format("SYS_USER.USER_ID in (select SYS_USER_ROLE.USER_ID from SYS_USER_ROLE where {0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.ROLE_NAME = '{3}' )) "
                , new object[] { SYS_USER_ROLE.TABLE_NAME, SYS_USER_ROLE.ROLE_NO_FIELD, SYS_ROLE.TABLE_NAME, "Globle BD Group" });
            BaseList data = bll.Select(_paramCollection, SYS_USER.USER_NAME_FIELD, typeof(SYS_USER));
            if (data.Count > 0)
            {
                foreach (SYS_USER node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.USER_NAME, node.USER_NAME);
                    resultStr += "},";
                }
            }
            else {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }
        public void getccPM(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format("SYS_USER.USER_ID in (select SYS_USER_ROLE.USER_ID from SYS_USER_ROLE where {0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.ROLE_NAME = '{3}' )) "
                , new object[] { SYS_USER_ROLE.TABLE_NAME, SYS_USER_ROLE.ROLE_NO_FIELD, SYS_ROLE.TABLE_NAME, "PDX Project Register" });
            BaseList data = bll.Select(_paramCollection, SYS_USER.USER_NAME_FIELD, typeof(SYS_USER));
            if (data.Count > 0)
            {
                foreach (SYS_USER node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.USER_NAME, node.USER_NAME);
                    resultStr += "},";
                }
            }
            else
            {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }
        public void getMonitorSD(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format("SYS_USER.USER_ID in (select SYS_USER_ROLE.USER_ID from SYS_USER_ROLE where {0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE ({2}.ROLE_NAME = '{3}' or {2}.ROLE_NAME = '{4}') )) "
              , new object[] { SYS_USER_ROLE.TABLE_NAME, SYS_USER_ROLE.ROLE_NO_FIELD, SYS_ROLE.TABLE_NAME, "CBCN SD Group", "CBCN JSD Group" });
            BaseList data = bll.Select(_paramCollection, SYS_USER.USER_NAME_FIELD, typeof(SYS_USER));
            if (data.Count > 0)
            {
                foreach (SYS_USER node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.USER_NAME, node.USER_NAME);
                    resultStr += "},";
                }
            }
            else {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }


        public void getWorkloadPerson(HttpContext context)
        {
            string cbxDep = context.Request["cbxDep"] ?? "";
            if (cbxDep == "SD")
            {
                getMonitorSD(context);
            }
            else if (cbxDep == "JSD")
            {
                getMonitorJSD(context);
            }
            else if (cbxDep == "DM")
            {
                getMonitorDM(context);
            }
            else if (cbxDep == "DT group")
            {
                getMonitorDTgroup(context);
            }
        }

        public void getMonitorJSD(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format("SYS_USER.USER_ID in (select SYS_USER_ROLE.USER_ID from SYS_USER_ROLE where {0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.ROLE_NAME = '{3}' )) "
                , new object[] { SYS_USER_ROLE.TABLE_NAME, SYS_USER_ROLE.ROLE_NO_FIELD, SYS_ROLE.TABLE_NAME, "Global JSD Group" });
            BaseList data = bll.Select(_paramCollection, SYS_USER.USER_NAME_FIELD, typeof(SYS_USER));
            if (data.Count > 0)
            {
                foreach (SYS_USER node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.USER_NAME, node.USER_NAME);
                    resultStr += "},";
                }
            }
            else
            {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }
        public void getMonitorDTgroup(HttpContext context)
        {
            string group = context.Request["group"] ?? "";
            string resultStr = "";
            resultStr += "[";
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format("ROLE_NAME like 'DT group%'");
            BaseList data = bll.Select(_paramCollection, SYS_ROLE.ROLE_NAME_FIELD, typeof(SYS_ROLE));
            if (data.Count > 0)
            {
                foreach (SYS_ROLE node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.ROLE_NAME, node.ROLE_NAME);
                    resultStr += "},";
                }
            }
            else
            {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }
        public void getMonitorDM(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format("SYS_USER.USER_ID in (select SYS_USER_ROLE.USER_ID from SYS_USER_ROLE where {0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE ({2}.ROLE_NAME = '{3}' or {2}.ROLE_NAME = '{4}') )) "
                , new object[] { SYS_USER_ROLE.TABLE_NAME, SYS_USER_ROLE.ROLE_NO_FIELD, SYS_ROLE.TABLE_NAME, "DT", "DM" });
            BaseList data = bll.Select(_paramCollection, SYS_USER.USER_NAME_FIELD, typeof(SYS_USER));
            if (data.Count > 0)
            {
                foreach (SYS_USER node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.USER_NAME, node.USER_NAME);
                    resultStr += "},";
                }
            }
            else
            {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }
        public void getccLeading_SD(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format("SYS_USER.USER_ID in (select SYS_USER_ROLE.USER_ID from SYS_USER_ROLE where {0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE ({2}.ROLE_NAME = '{3}' or {2}.ROLE_NAME = '{4}') )) "
                , new object[] { SYS_USER_ROLE.TABLE_NAME, SYS_USER_ROLE.ROLE_NO_FIELD, SYS_ROLE.TABLE_NAME, "CBCN SD Group", "CBCN JSD Group" });
            BaseList data = bll.Select(_paramCollection, SYS_USER.USER_NAME_FIELD, typeof(SYS_USER));
            if (data.Count > 0)
            {
                foreach (SYS_USER node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.USER_NAME, node.USER_NAME);
                    resultStr += "},";
                }
            }
            else
            {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }

        public void getccSD(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format("SYS_USER.USER_ID in (select SYS_USER_ROLE.USER_ID from SYS_USER_ROLE where {0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE ({2}.ROLE_NAME = '{3}' or {2}.ROLE_NAME = '{4}') )) "
                , new object[] { SYS_USER_ROLE.TABLE_NAME, SYS_USER_ROLE.ROLE_NO_FIELD, SYS_ROLE.TABLE_NAME, "CBCN SD Group", "CBCN JSD Group" });
            BaseList data = bll.Select(_paramCollection, SYS_USER.USER_NAME_FIELD, typeof(SYS_USER));
            if (data.Count > 0)
            {
                foreach (SYS_USER node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.USER_NAME, node.USER_NAME);
                    resultStr += "},";
                }
            }
            else
            {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }

        public void getSubtypecombobox(HttpContext context)
        {
            string cancertype = context.Request["Tumor_Type"] ?? "";
            string resultStr = "";
            resultStr += "[";
            DataTable dataSubtype = new DataTable();
            dataSubtype = ojbRuleHuData.GetSubtype(cancertype);
            if (dataSubtype.Rows.Count > 0)
            {
                foreach (DataRow node in dataSubtype.Rows)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node["subtype1"], node["subtype1"]);
                    resultStr += "},";
                }
            }
            else
            {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }
        public void getSubtype2combobox(HttpContext context)
        {
            string cancertype = context.Request["Tumor_Type"] ?? "";
            string resultStr = "";
            resultStr += "[";
            DataTable dataSubtype = new DataTable();
            dataSubtype = ojbRuleHuData.GetSubtype2(cancertype);
            if (dataSubtype.Rows.Count > 0)
            {
                foreach (DataRow node in dataSubtype.Rows)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node["subtype2"], node["subtype2"]);
                    resultStr += "},";
                }
            }
            else
            {
                resultStr += "{ },";
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }
        public void hfAvailableColumns(HttpContext context)
        {
            string type = context.Request["Type"] ?? "";
            string[] columns = new string[50];
            string resultStr = "";
            resultStr += "[";
            resultStr += "{";
            resultStr += string.Format("\"id\": \"\", \"text\": \"{0}\", \"state\": \"open\"", "Select All");
            if (type == "animalinfo")
            {
                columns = new string[] { "MODEL_ID","Cancer_Type","Subtype1","Subtype2","Model_Category","Model_status","DOI","Rn","Pn","Location_of_live_animal","Animal_Room_Number","IVC_Location"
            ,"Animal_Number","Clinical_Observation","Mortality_Observation","Body_Weight","TVLB","TVLF","TVRF","TVRB","TV_AVG","Tumor_Number","Time_of_Model_for_Transplant","Estimated_DOT","Date_of_Update","Current_Project_Number","Source_Project"};
            }
            else if (type == "modelinfo")
            {
                SYS_USER userLogin = CacheHelper.getCurrentUser();
                string[] columns1 = new string[] { "Sq_Number","Cancer_Type_Abbr","Model_ID","Model_From","Source","Origin","Cancer_Type","Subtype1","Subtype2","Model_Category","Model_Status",
                "Source_ID","Source_Note","PDX_QC","STR_Consistence","In_Huba","Exomeseq","Total_Revival_Success_Rate","Time_of_Revival","Revival_Recommended_Strain",
                "Time_of_Model_for_Transplant","Maintain_Recommended_Strain","Spare_for_CV40","Spare_for_CV30","Optimal_Overage","Dosing_Window","Cryo_P","Snap_Frozen","FFPE","HP2","Times_Used_In_Study"
                ,"Cachexia_Label","Cachexia","Slight_BW_loss","Normal","Location","Ulceration_Label","Survival_Curve","SOC","Time_of_Update","Implantation_Method","Comments"
                ,"Total_Revival_Success_Rate_CBNC","Time_of_Revival_CBNC","Revival_Recommended_Strain_CBNC","Treatment_history_1","Treatment_history_2","DeathRate","Patient_ID"};
                int i = 0;
                foreach (string str in columns1)
                {
                    bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "PDXModelInfo-show", str);
                    if (havePerm)
                    {
                        columns[i] = str;
                        i++;
                    }
                }
            }
            else if (type == "request2")
            {
                columns = new string[] { "REQUEST_ID","Sub Project","Major Project","SPONSOR","AX_CODE","BD","PM","Leading SD","Executive SD","TYPE_OF_STUDY","CANCER_TYPE","SUBTYPE1","SUBTYPE2","MODEL_ID","COMPLETED_MODEL_ID","SPECIAL_REQUIREMENTS",
                    "POTENTIAL_STUDY_SIZE","Request Status","REMARK","DATE_OF_REQUEST","DATE_OF_1ST_RESPONDING"};
            }
            else if (type == "ModelStatus")
            {
                columns = new string[] { "REQUEST_ID","Sponsor","Project_Number","Potential_Study_Size","Animal_Booking","Further_expanding","Revive","Provide_Date",
                   "Tumor_Numbers","Model_ID","Cancer_Type","Subtype1","Subtype2","Model_Category","Current_Project_Number","Model_status","DOI","Rn","Pn","Location_of_live_animal","Animal_Room_Number","IVC_Location"
                   ,"Animal_Number","Body_Weight","TVLB","TVLF","TVRF","TVRB","TV_AVG","Tumor_Number","Time_of_Model_for_Transplant","Estimated_DOT","Date_of_Update"};
            }
            resultStr += ",\"children\":";
            resultStr += "[";
            foreach (string node in columns)
            {
                if (node != null)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node, node);
                    resultStr += "},";
                }
            }
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            resultStr += "},";

            resultStr = resultStr.Substring(0, resultStr.Length - 1);

            resultStr += "]";

            context.Response.Write(resultStr);

        }



        public void cbxModel_Category_combotree(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";

            resultStr += "{";
            resultStr += string.Format("\"id\": \"\", \"text\": \"{0}\", \"state\": \"open\"", "Select All");

            ParamCollection paralist = new ParamCollection();
            paralist.Clause = DROPDOWNLIST.DROPDOWNLIST_NAME_FIELD + " = 'Model Category'";
            BaseList data = bll.Select(paralist, typeof(DROPDOWNLIST));
          
            if (data.Count > 0)
            {
                resultStr += ",\"children\":";
                resultStr += "[";
                DROPDOWNLIST row = (DROPDOWNLIST)data[0];
                foreach (string node in row.DROPDOWNLIST_CONTEXT.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.Replace("\\n", ""), node.Replace("\\n", ""));
                    resultStr += "},";
                }
                resultStr = resultStr.Substring(0, resultStr.Length - 1);
                resultStr += "]";
            }
            resultStr += "},";

            resultStr = resultStr.Substring(0, resultStr.Length - 1);

            resultStr += "]";

            context.Response.Write(resultStr);
        }


        public void getddlSOC(HttpContext context)
        {
          

            string resultStr = "";
            resultStr += "[";
            resultStr += "{";
            resultStr += string.Format("\"id\": \"\", \"text\": \"{0}\", \"state\": \"open\"", "Select All");
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = DROPDOWNLIST.DROPDOWNLIST_NAME_FIELD + " = 'SOC drug'";
            BaseList data = bll.Select(_paramCollection,typeof(DROPDOWNLIST));
            if (data.Count > 0)
            {
                resultStr += ",\"children\":";
                resultStr += "[";
                string[] strs = ((DROPDOWNLIST)data[0]).DROPDOWNLIST_CONTEXT.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string node in strs)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node, node);
                    resultStr += "},";
                }
                resultStr = resultStr.Substring(0, resultStr.Length - 1);
                resultStr += "]";
            }
            resultStr += "},";
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }
        public void getddlDT(HttpContext context)
        {
            string DTgroup = context.Request["DTgroup"] ?? "";

            string resultStr = "";
            resultStr += "[";
            resultStr += "{";
            resultStr += string.Format("\"id\": \"\", \"text\": \"{0}\", \"state\": \"open\"", "Select All");
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format("SYS_USER.USER_ID in (select SYS_USER_ROLE.USER_ID from SYS_USER_ROLE where {0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.ROLE_NAME = '{3}' )) "
                , new object[] { SYS_USER_ROLE.TABLE_NAME, SYS_USER_ROLE.ROLE_NO_FIELD, SYS_ROLE.TABLE_NAME, DTgroup });
            BaseList data = bll.Select(_paramCollection,SYS_USER.USER_NAME_FIELD, typeof(SYS_USER));
            if (data.Count > 0)
            {
                resultStr += ",\"children\":";
                resultStr += "[";
                foreach (SYS_USER node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.USER_ID, node.USER_NAME);
                    resultStr += "},";
                }
                resultStr = resultStr.Substring(0, resultStr.Length - 1);
                resultStr += "]";
            }
            resultStr += "},";
            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";
            context.Response.Write(resultStr);
        }

        public void getSubtype(HttpContext context)
        {
            string cancertype = context.Request["Tumor_Type"] ?? "";

            string resultStr = "";
            resultStr += "[";


            DataTable dataSubtype = new DataTable();
            //if (cancertype != "" && cancertype != " ")
            //{
                resultStr += "{";
                resultStr += string.Format("\"id\": \"\", \"text\": \"{0}\", \"state\": \"open\"", "Select All");
                dataSubtype = ojbRuleHuData.GetSubtype(cancertype);

                if (dataSubtype.Rows.Count > 0)
                {
                    resultStr += ",\"children\":";
                    resultStr += "[";
                    foreach (DataRow node in dataSubtype.Rows)
                    {
                        resultStr += "{";
                        resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node["subtype1"], node["subtype1"]);
                        resultStr += "},";
                    }
                    resultStr = resultStr.Substring(0, resultStr.Length - 1);
                    resultStr += "]";
                }
                resultStr += "},";

                resultStr = resultStr.Substring(0, resultStr.Length - 1);
            //}

            resultStr += "]";

            context.Response.Write(resultStr);
        }

        public void getSubtype2(HttpContext context)
        {
            string cancertype = context.Request["Tumor_Type"] ?? "";

            string resultStr = "";
            resultStr += "[";


            DataTable dataSubtype = new DataTable();
            //if (cancertype != "" && cancertype != " ")
            //{
                resultStr += "{";
                resultStr += string.Format("\"id\": \"\", \"text\": \"{0}\", \"state\": \"open\"", "Select All");
                dataSubtype = ojbRuleHuData.GetSubtype2(cancertype);

                if (dataSubtype.Rows.Count > 0)
                {
                    resultStr += ",\"children\":";
                    resultStr += "[";
                    foreach (DataRow node in dataSubtype.Rows)
                    {
                        resultStr += "{";
                        resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node["subtype2"], node["subtype2"]);
                        resultStr += "},";
                    }
                    resultStr = resultStr.Substring(0, resultStr.Length - 1);
                    resultStr += "]";
                }
                resultStr += "},";

                resultStr = resultStr.Substring(0, resultStr.Length - 1);
            //}

            resultStr += "]";

            context.Response.Write(resultStr);
        }


        public void getRoleUserName(HttpContext context)
        {
           

            string resultStr = "";
            resultStr += "[";

                resultStr += "{";
                resultStr += string.Format("\"id\": \"\", \"text\": \"{0}\", \"state\": \"open\"", "Select All");
                BaseList data = bll.Select(new ParamCollection(),SYS_USER.USER_NAME_FIELD , typeof(SYS_USER));


                if (data.Count > 0)
                {
                    resultStr += ",\"children\":";
                    resultStr += "[";
                    foreach (SYS_USER node in data)
                    {
                        resultStr += "{";
                        resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.USER_ID, node.USER_NAME);
                        resultStr += "},";
                    }
                    resultStr = resultStr.Substring(0, resultStr.Length - 1);
                    resultStr += "]";
                }
                resultStr += "},";

                resultStr = resultStr.Substring(0, resultStr.Length - 1);
         

            resultStr += "]";

            context.Response.Write(resultStr);
        }


        public void getPerson(HttpContext context)
        {
            string dep = context.Request["dep"] ?? "";
            string resultStr = "";
            resultStr += "[";
            resultStr += "{";
            resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\", \"state\": \"open\"", 0, "Select All");
            BaseList userdata = bll.Select(queryBD(dep), typeof(SYS_USER));
            if (userdata.Count > 0)
            {
                resultStr += ",\"children\":";
                resultStr += "[";
                foreach (SYS_USER node in userdata)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.USER_ID, node.FIRST_NAME + " " + node.LAST_NAME);
                    resultStr += "},";
                }
                resultStr = resultStr.Substring(0, resultStr.Length - 1);
                resultStr += "]";
            }
            resultStr += "},";

            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";

            context.Response.Write(resultStr);
        }

        private ParamCollection queryEdit(string r_id)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = REQUEST.REQUEST_ID_FIELD;
            Clause += string.Format("{0}.{1} = '{2}'", REQUEST.TABLE_NAME, column, r_id);
            paraList.Clause = Clause;
            return paraList;
        }
        

        private ParamCollection queryBD(string dep)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = SYS_USER.DEPARTMENT_FIELD;
            Clause += string.Format("{0}.{1} = '{2}'", SYS_USER.TABLE_NAME, column, dep);
            paraList.Clause = Clause;
            return paraList;
        }
        private ParamCollection queryRequester(string id)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = SYS_USER.USER_ID_FIELD;
            Clause += string.Format("{0}.{1} = '{2}'", SYS_USER.TABLE_NAME, column, id);
            paraList.Clause = Clause;
            return paraList;
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}