using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crownbio.Model;
using Crownbio.BLL;
using Crownbio.Common;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using System.Web.SessionState;
using System.Collections;
using System.Data;
using System.Text;
using Crownbio.Utility;
using Aspose.Cells;
using System.Data.SqlClient;
using Crownbio.BLL.Rule;

namespace PDXmodelBase.HuData
{
    /// <summary>
    /// importDB 的摘要说明
    /// </summary>
    public class importDB : IHttpHandler, IRequiresSessionState
    {
        ObjectBLL bll = new ObjectBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string tablename = context.Request["Tablename"] ?? "";
            if (tablename == "AnimalInfo")
            {
                AddAnimalInfo(context);
            }
            else if (tablename == "AnimalInfo(logs)")
            {
                AddAnimalInfo_Logs(context);
            }
            else if (tablename == "AnimalInfo(update)")
            {
                UpdateAnimalInfo(context);
            }
            else if (tablename == "AnimalInfo(Z-group)")
            {
                FinishAnimalInfo(context);
            }

            else if (tablename == "PDXmodelInfo")
            {
                AddPDXmodelInfo(context);
            }
            else if (tablename == "PDXModelInfo_subtype")
            {
                Update_PDXModelInfo_subtype(context);
            }
            else if (tablename == "PDXModelInfo_update")
            {
                Update_PDXModelInfo_update(context);
            }
            else if (tablename == "ANIMAL_TREE")
            {
                AddModelTree2(context);
            }
            else if (tablename == "Maintain")
            {
                Maintain(context);
            }
            else if (tablename == "Sponsor")
            {
                Sponsor(context);
            }
            else if (tablename == "SpecimenStock")
            {
                SpecimenStock(context);
            }
            else if (tablename == "Tissue_Withdraw")
            {
                Tissue_Withdraw(context);
            }
            else if (tablename == "NewModel")
            {
                NewModel(context,"NewModel");
            }
            else if (tablename == "Validation")
            {
                NewModel(context, "Validation");
            }
            else if (tablename == "RoutineMaintain")
            {
                NewModel(context, "RoutineMaintain");
            }
            else if (tablename == "Table_1")
            {
                Table_1(context, "Table_1");
            }
            else if (tablename == "Cachexia")
            {
                Cachexia(context, "PDXMODEL_INFO");
            }
            string Method = context.Request.Params["M"];
            switch (Method)
            {
                case "UploadHusbandry":
                    AddHusbandry(context);
                    break;
                case "UploadHusbandry_Zgroup":
                    UploadHusbandry_Zgroup(context);
                    break;

                case "DeleteHus":
                    DeleteHus(context);
                    break;
                case "Analysis":
                    Analysis(context);
                    break;
                case "importEndModels":
                    importEndModels(context);
                    break;
                case "importValidationStatus_Huprime":
                    importValidationStatus_Huprime(context);
                    break;
                case "importValidationStatus_Hukime":
                    importValidationStatus_Hukime(context);
                    break;
                case "importRevival":
                    importRevival(context);
                    break;
                case "importGeneticTest":
                    importGeneticTest(context);
                    break;
                    
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

        
        public void importRevival(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                try
                {
                    string filePath = updateInfoNew(context);
                    Workbook book = new Workbook(filePath);
                    Worksheet sheet = book.Worksheets[0];

                    Cells cells = sheet.Cells;

                    BaseList data = bll.Select(typeof(REVIVAL));
                    List<REVIVAL> lists = data.ConvertAll(REVIVAL.Convert);
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        if (cells[i, 0].StringValue != "sq#1" && cells[i, 0].StringValue != "")
                        {
                            REVIVAL row = null;
                            try
                            {
                                row = lists.Find(delegate (REVIVAL perm)
                                {
                                    return perm.MODELID == cells[i, 3].StringValue.Trim()
                                            && perm.BATCH_OF_CRYO_P_TISSUE == cells[i, 5].StringValue.Trim()
                                    && DateTime.Compare(Convert.ToDateTime(perm.DATE_OF_REVIVAL), Convert.ToDateTime(cells[i, 6].StringValue.Trim())) == 0
                                    && perm.LOCATION == cells[i, 8].StringValue.Trim()
                                    && perm.RN == cells[i, 10].StringValue.Trim()
                                    && perm.PN == cells[i, 12].StringValue.Trim()
                                    && perm.ANIMAL_STRAIN == cells[i, 13].StringValue.Trim()
                                    && perm.ANIMAL_QUANTITY == cells[i, 14].StringValue.Trim()
                                    ;
                                });
                            }
                            catch(Exception ex)
                            {
                                row = null;
                            }
                            if (row == null)
                            {
                                row = new REVIVAL(DealModel.New);
                                //第一次导入
                                row.SQ1 = cells[i, 0].StringValue.Trim();
                                row.SQ = cells[i, 1].StringValue.Trim();
                                row.CANCERTYPE = cells[i, 2].StringValue.Trim();
                                row.MODELID = cells[i, 3].StringValue.Trim();
                                row.BATCH_OF_CRYO_P_TISSUE = FormatHelper.doTran(cells[i, 5].StringValue.Trim());
                                if (RegHelper.IsDateTime(cells[i, 6].StringValue.Trim()))
                                {
                                    row.DATE_OF_REVIVAL = DateTime.Parse(cells[i, 6].StringValue.Trim());
                                }
                                else {
                                    row.DATE_OF_REVIVAL = DateTime.MinValue;
                                }
                                row.LOCATION = cells[i, 8].StringValue.Trim();
                                row.PRE_RN = cells[i, 9].StringValue.Trim();
                                row.RN = cells[i, 10].StringValue.Trim();
                            
                                row.PN = cells[i, 12].StringValue.Trim();
                                row.ANIMAL_STRAIN = cells[i, 13].StringValue.Trim();
                                row.ANIMAL_QUANTITY = cells[i, 14].StringValue.Trim();
                              
                             
                                row.STUDY = FormatHelper.doTran(cells[i, 18].StringValue.Trim());
                                row.PROJECT_NO = FormatHelper.doTran(cells[i, 19].StringValue.Trim());
                                if (RegHelper.IsDateTime(cells[i, 4].StringValue.Trim()))
                                {
                                    row.DATE_OF_TISSUE_COLLECTION = DateTime.Parse(cells[i, 4].StringValue.Trim());
                                }
                                else
                                {
                                    row.DATE_OF_TISSUE_COLLECTION = DateTime.MinValue;
                                }
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
                                row.COMMENT = cells[i, 20].StringValue.Trim();
                                row.PRE_RECOVERY_PATHOGEN = cells[i, 21].StringValue.Trim();
                                row.RECOVERY_PATHOGEN = cells[i, 22].StringValue.Trim();
                                row.IMPLANTATION_PATHOGEN = cells[i, 23].StringValue.Trim();
                                row.RECOVERY_SNP = cells[i, 24].StringValue.Trim();
                                row.IMPLANTATION_SNP = cells[i, 25].StringValue.Trim();
                            }
                            else
                            {
                                row.CurModel = DealModel.Modify;
                            }
                          
                            if (RegHelper.IsDateTime(cells[i, 15].StringValue.Trim()))
                            {
                                row.DATE_OF_REVIVAL_SUCEEDED = DateTime.Parse(cells[i, 15].StringValue.Trim());
                            }
                            else
                            {
                                row.DATE_OF_REVIVAL_SUCEEDED = DateTime.MinValue;
                            }
                        
                            row.OUTCOME = cells[i, 16].StringValue.Trim();
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
                         
                         
                            row.TIME_OF_UPDATE = DateTime.Now;
                            SYS_USER userLogin = CacheHelper.getCurrentUser();
                            row.NAME_OF_UPDATE = userLogin.USER_NAME;
                            bll.Update(row);
                        }
                    }
                    context.Response.Write("Import successfully");
                }
                catch (Exception ex)
                {
                    context.Response.Write("Import error:" + ex.Message.ToString());
                }
            }
            else
            {
                context.Response.Write("Please add file.");
            }
        }

        public void importGeneticTest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                try
                {
                    string filePath = updateInfoNew(context);
                    Workbook book = new Workbook(filePath);
                    Worksheet sheet = book.Worksheets[0];

                    Cells cells = sheet.Cells;

                    BaseList data = bll.Select(typeof(GENETICTEST));
                    List<GENETICTEST> lists = data.ConvertAll(GENETICTEST.Convert);
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        if (cells[i, 0].StringValue != "Sq_Number" && cells[i, 0].StringValue != "")
                        {
                            GENETICTEST row = null;
                            try
                            {
                                row = lists.Find(delegate (GENETICTEST perm)
                                {
                                    return perm.SQ_NUMBER == cells[i, 0].StringValue.Trim()
                                    && perm.MODEL_ID == cells[i, 1].StringValue.Trim()
                                    ;
                                });
                            }
                            catch (Exception ex)
                            {
                                row = null;
                            }
                            if (row == null)
                            {
                                row = new GENETICTEST(DealModel.New);
                                //第一次导入
                                row.SQ_NUMBER = cells[i, 0].StringValue.Trim();
                                row.MODEL_ID = cells[i, 1].StringValue.Trim();
                            }
                            else
                            {
                                row.CurModel = DealModel.Modify;
                            }
                            row.SOURCE = cells[i, 2].StringValue.Trim();
                            row.RNASEQ = cells[i, 3].StringValue.Trim();
                            row.WES = cells[i, 4].StringValue.Trim();
                            row.WGS = cells[i, 5].StringValue.Trim();
                            row.COMMENT = cells[i, 6].StringValue.Trim();

                            row.GENETIC_TYPE_UPDATA = cells[i, 7].StringValue.Trim();
                            row.PATHOLOGY = cells[i, 8].StringValue.Trim();
                            row.PATHOLOG_UPDATA = cells[i, 9].StringValue.Trim();
                            row.COMMENT_ALL = cells[i, 10].StringValue.Trim();

                            row.TIME_OF_UPDATE = DateTime.Now;
                            SYS_USER userLogin = CacheHelper.getCurrentUser();
                            row.NAME_OF_UPDATE = userLogin.USER_NAME;
                            bll.Update(row);
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

        
        public void importValidationStatus_Huprime(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                try
                {
                    string filePath = updateInfoNew(context);
                    Workbook book = new Workbook(filePath);
                    Worksheet sheet = book.Worksheets[0];

                    Cells cells = sheet.Cells;

                    BaseList data = bll.Select(typeof(VALIDATIONSTATUS_HUPRIME));
                    List<VALIDATIONSTATUS_HUPRIME> lists = data.ConvertAll(VALIDATIONSTATUS_HUPRIME.Convert);
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        if (cells[i, 0].StringValue != "Sq#" && cells[i, 0].StringValue != "")
                        {
                            VALIDATIONSTATUS_HUPRIME row = lists.Find(delegate (VALIDATIONSTATUS_HUPRIME perm)
                            {
                                return perm.SQ == cells[i, 0].StringValue.Trim()
                                        && perm.MODELID == cells[i, 3].StringValue.Trim();
                                        //&& perm.PROJECT == cells[i, 6].StringValue.Trim();
                            });
                            if (row == null)
                            {
                                row = new VALIDATIONSTATUS_HUPRIME(DealModel.New);
                                row.SQ = cells[i, 0].StringValue.Trim();
                                row.MODELID = cells[i, 3].StringValue.Trim();

                                //第一次导入
                                row.ESTABLISHED_LOCATION = cells[i, 9].StringValue.Trim();
                                row.VALIDATIONSTATUS = cells[i, 10].StringValue.Trim();
                                row.FINALDATEOFVALIDATION = cells[i, 11].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 11].StringValue.Trim());
                                row.CRYO_PTISSUE = cells[i, 12].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 12].StringValue.Trim());
                                row.CRYO_PTISSUE_NUMBER = cells[i, 13].StringValue.Trim();
                                row.FROZEN_STORAGE = cells[i, 14].StringValue.Trim();
                                row.FIRST_REVIVAL = cells[i, 15].StringValue.Trim();
                                row.GC = cells[i, 16].StringValue.Trim();
                                row.ANIMALROOMNUMBER = cells[i, 17].StringValue.Trim();
                                row.COMMENT = FormatHelper.doTran(cells[i, 19].StringValue.Trim());
                            }
                            else
                            {
                                row.CurModel = DealModel.Modify;
                            }
                            row.CANCERTYPE = cells[i, 1].StringValue.Trim();
                            row.CANCERTYPEABBR = cells[i, 2].StringValue.Trim();
                            row.MODEL_TYPE = cells[i, 4].StringValue.Trim();
                            row.SOURCE = cells[i, 5].StringValue.Trim();
                            row.PROJECT = FormatHelper.doTran(cells[i, 6].StringValue.Trim());
                            row.ARRIVAL_DATE = cells[i, 7].StringValue.Trim();
                            row.ESTABLISHED_DATE = cells[i, 8].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 8].StringValue.Trim());
                            row.DATEOFUPDATE = cells[i, 18].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 18].StringValue.Trim());

                            bll.Update(row);
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
        

        /*
        //add by Jack 2025.09.04
        /// <summary>
        /// Imports validation status data from an Excel file.
        /// This improved version finds columns by header name, making it resilient to column order changes.
        /// </summary>
        /// <param name="context">The HTTP context containing the uploaded file.</param>
        public void importValidationStatus_Huprime(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                try
                {
                    // Assuming updateInfoNew is a method that saves the file and returns its path.
                    string filePath = updateInfoNew(context);
                    Workbook book = new Workbook(filePath);
                    Worksheet sheet = book.Worksheets[0];
                    Cells cells = sheet.Cells;

                    // 1. Get the header row to create a dynamic mapping
                    Dictionary<string, int> columnIndexMap = GetColumnMapping(cells);

                    // Check if all required columns exist based on the new provided list
                    if (!columnIndexMap.ContainsKey("SQ#") || !columnIndexMap.ContainsKey("MODELID*"))
                    {
                        context.Response.Write("Error: Required columns 'Sq#' and 'ModelID*' not found.");
                        return;
                    }

                    // Assuming bll.Select and VALIDATIONSTATUS_HUPRIME exist
                    BaseList data = bll.Select(typeof(VALIDATIONSTATUS_HUPRIME));
                    List<VALIDATIONSTATUS_HUPRIME> lists = data.ConvertAll(VALIDATIONSTATUS_HUPRIME.Convert);

                    // 2. Iterate through data rows using the dynamic mapping
                    for (int i = 1; i < cells.MaxDataRow + 1; i++) // Start from row 1 to skip headers
                    {
                        // Check if the first cell (Sq#) is not empty.
                        string sqValue = cells[i, columnIndexMap["SQ#"]].StringValue.Trim();
                        if (!string.IsNullOrEmpty(sqValue))
                        {
                            string modelIdValue = cells[i, columnIndexMap["MODELID*"]].StringValue.Trim();
                            // Assuming this logic is correct for finding an existing row
                            VALIDATIONSTATUS_HUPRIME row = lists.Find(p => p.SQ == sqValue && p.MODELID == modelIdValue);

                            if (row == null)
                            {
                                row = new VALIDATIONSTATUS_HUPRIME(DealModel.New);
                                row.SQ = sqValue;
                                row.MODELID = modelIdValue;

                                // Populate fields that are only set on the first import
                                if (columnIndexMap.ContainsKey("ESTABLISHED LOCATION"))
                                    row.ESTABLISHED_LOCATION = cells[i, columnIndexMap["ESTABLISHED LOCATION"]].StringValue.Trim();
                                if (columnIndexMap.ContainsKey("VALIDATIONSTATUS*"))
                                    row.VALIDATIONSTATUS = cells[i, columnIndexMap["VALIDATIONSTATUS*"]].StringValue.Trim();
                                if (columnIndexMap.ContainsKey("FINALDATEOFVALIDATION"))
                                    row.FINALDATEOFVALIDATION = ParseDate(cells[i, columnIndexMap["FINALDATEOFVALIDATION"]].StringValue.Trim());
                                if (columnIndexMap.ContainsKey("CRYO-PTISSUE(填写第20管日期）*"))
                                    row.CRYO_PTISSUE = ParseDate(cells[i, columnIndexMap["CRYO-PTISSUE(填写第20管日期）*"]].StringValue.Trim());
                                if (columnIndexMap.ContainsKey("CRYO-PTISSUE(NUMBER)（填写YES/NO)"))
                                    row.CRYO_PTISSUE_NUMBER = cells[i, columnIndexMap["CRYO-PTISSUE(NUMBER)（填写YES/NO)"]].StringValue.Trim();

                                if (columnIndexMap.ContainsKey("冻存库存"))
                                    row.FROZEN_STORAGE = cells[i, columnIndexMap["冻存库存"]].StringValue.Trim();

                                if (columnIndexMap.ContainsKey("1STREVIVAL*"))
                                    row.FIRST_REVIVAL = cells[i, columnIndexMap["1STREVIVAL*"]].StringValue.Trim();
                                if (columnIndexMap.ContainsKey("GC*"))
                                    row.GC = cells[i, columnIndexMap["GC*"]].StringValue.Trim();
                                if (columnIndexMap.ContainsKey("ANIMALROOMNUMBER*"))
                                    row.ANIMALROOMNUMBER = cells[i, columnIndexMap["ANIMALROOMNUMBER*"]].StringValue.Trim();
                                if (columnIndexMap.ContainsKey("COMMENT"))
                                    row.COMMENT = FormatHelper.doTran(cells[i, columnIndexMap["COMMENT"]].StringValue.Trim());
                            }
                            else
                            {
                                row.CurModel = DealModel.Modify;
                            }

                            // Populate fields that are always updated
                            if (columnIndexMap.ContainsKey("CANCERTYPE*"))
                                row.CANCERTYPE = cells[i, columnIndexMap["CANCERTYPE*"]].StringValue.Trim();
                            if (columnIndexMap.ContainsKey("CANCERTYPEABBR"))
                                row.CANCERTYPEABBR = cells[i, columnIndexMap["CANCERTYPEABBR"]].StringValue.Trim();
                            if (columnIndexMap.ContainsKey("MODEL TYPE"))
                                row.MODEL_TYPE = cells[i, columnIndexMap["MODEL TYPE"]].StringValue.Trim();
                            if (columnIndexMap.ContainsKey("SOURCE*"))
                                row.SOURCE = cells[i, columnIndexMap["SOURCE*"]].StringValue.Trim();
                            if (columnIndexMap.ContainsKey("PROJECT#"))
                                row.PROJECT = FormatHelper.doTran(cells[i, columnIndexMap["PROJECT#"]].StringValue.Trim());

                            // Add the new column "Arrival date*" if it exists.
                            if (columnIndexMap.ContainsKey("ARRIVAL DATE*"))
                                row.ARRIVAL_DATE = ParseDate(cells[i, columnIndexMap["ARRIVAL DATE*"]].StringValue.Trim());

                            if (columnIndexMap.ContainsKey("ESTABLISHED DATE*"))
                                row.ESTABLISHED_DATE = ParseDate(cells[i, columnIndexMap["ESTABLISHED DATE*"]].StringValue.Trim());
                            if (columnIndexMap.ContainsKey("DATEOFUPDATE*"))
                                row.DATEOFUPDATE = ParseDate(cells[i, columnIndexMap["DATEOFUPDATE*"]].StringValue.Trim());

                            bll.Update(row);
                        }
                    }
                    context.Response.Write("Import successfully");
                }
                catch (Exception ex)
                {
                    // Log the exception details for debugging
                    Console.WriteLine(ex.ToString());
                    context.Response.Write("Import error");
                }
            }
            else
            {
                context.Response.Write("Please add file.");
            }
        }

        /// <summary>
        /// Reads the first row of the worksheet to create a dictionary
        /// mapping column header names to their zero-based index.
        /// </summary>
        /// <param name="cells">The Cells object from the Excel worksheet.</param>
        /// <returns>A dictionary with column names as keys and indices as values.</returns>
        private Dictionary<string, int> GetColumnMapping(Cells cells)
        {
            var columnIndexMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (int j = 0; j < cells.MaxDataColumn + 1; j++)
            {
                // Get the header name, clean it up, and add it to the dictionary.
                string headerName = cells[0, j].StringValue.Trim().ToUpper();
                if (!string.IsNullOrEmpty(headerName))
                {
                    // This 'j' here is where your loop variable would be used to build the map.
                    columnIndexMap[headerName] = j;
                }
            }
            return columnIndexMap;
        }

        /// <summary>
        /// Helper method to safely parse a date string.
        /// </summary>
        /// <param name="dateString">The string to parse.</param>
        /// <returns>A DateTime object or DateTime.MinValue if parsing fails.</returns>
        private DateTime ParseDate(string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
            {
                return DateTime.MinValue;
            }
            DateTime date;
            if (DateTime.TryParse(dateString, out date))
            {
                return date;
            }
            return DateTime.MinValue;
        }
        */

        public void importValidationStatus_Hukime(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                try
                {
                    string filePath = updateInfoNew(context);
                    Workbook book = new Workbook(filePath);
                    Worksheet sheet = book.Worksheets[0];

                    Cells cells = sheet.Cells;

                    BaseList data = bll.Select(typeof(VALIDATIONSTATUS_HUKIME));
                    List<VALIDATIONSTATUS_HUKIME> lists = data.ConvertAll(VALIDATIONSTATUS_HUKIME.Convert);
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        if (cells[i, 0].StringValue != "Sq#" && cells[i, 0].StringValue != "")
                        {
                            VALIDATIONSTATUS_HUKIME row = lists.Find(delegate (VALIDATIONSTATUS_HUKIME perm)
                            {
                                return perm.SQ == cells[i, 0].StringValue.Trim()
                                        && perm.MODELID == cells[i, 3].StringValue.Trim();
                                      
                            });
                            if (row == null)
                            {
                                row = new VALIDATIONSTATUS_HUKIME(DealModel.New);
                                row.SQ = cells[i, 0].StringValue.Trim();
                                row.MODELID = cells[i, 3].StringValue.Trim();

                                //第一次导入
                                row.ESTABLISHED_LOCATION = cells[i, 8].StringValue.Trim();
                                row.VALIDATIONSTATUS = cells[i, 9].StringValue.Trim();
                                row.FINALDATEOFVALIDATION = cells[i, 10].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 10].StringValue.Trim());
                                row.REVIVAL = cells[i, 11].StringValue.Trim();
                                row.TU = cells[i, 12].StringValue.Trim();
                                row.FACS = cells[i, 13].StringValue.Trim();
                                row.BANK = cells[i, 14].StringValue.Trim();
                                row.PASSAGE = cells[i, 15].StringValue.Trim();
                                row.SNP = cells[i, 16].StringValue.Trim();
                                row.COMMENT = FormatHelper.doTran(cells[i, 18].StringValue.Trim());
                            }
                            else {
                                row.CurModel = DealModel.Modify;
                            }
                            row.CANCERTYPE = cells[i, 1].StringValue.Trim();
                            row.CANCERTYPEABBR = cells[i, 2].StringValue.Trim();
                            row.MODEL_TYPE = cells[i, 4].StringValue.Trim();
                            row.SOURCE = cells[i, 5].StringValue.Trim();
                            row.SUBTYPE = cells[i, 6].StringValue.Trim();
                            row.ESTABLISHED_DATE = cells[i, 7].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 7].StringValue.Trim());
                            row.DATEOFUPDATE = cells[i, 17].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 17].StringValue.Trim());
                            bll.Update(row);
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

        public void importEndModels(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                try
                {
                    string filePath = updateInfoNew(context);
                    Workbook book = new Workbook(filePath);
                    Worksheet sheet = book.Worksheets[0];

                    Cells cells = sheet.Cells;

                    BaseList data = bll.Select(typeof(ENDMODELS));
                    List<ENDMODELS> lists = data.ConvertAll(ENDMODELS.Convert);
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        if (cells[i, 0].StringValue != "Date of update" && cells[i, 0].StringValue != "")
                        {
                            ENDMODELS row = lists.Find(delegate (ENDMODELS perm)
                            {
                                return perm.GROUP_NAME == cells[i, 2].StringValue.Trim()
                                        && perm.RN == cells[i, 3].StringValue.Trim()
                                        && perm.PN == cells[i, 4].StringValue.Trim()
                                        && perm.HUSBANDRY_START == DateTime.Parse(cells[i, 5].StringValue.Trim())
                                        && perm.LOCATION == cells[i, 7].StringValue.Trim()
                                        && perm.IVC == cells[i, 8].StringValue.Trim()
;
                            });
                            if (row == null)
                            {
                                row = new ENDMODELS(DealModel.New);
                                row.LEADER = cells[i, 1].StringValue.Trim();
                                row.GROUP_NAME = cells[i, 2].StringValue.Trim();
                                row.RN = cells[i, 3].StringValue.Trim();
                                row.PN = cells[i, 4].StringValue.Trim();
                                row.LOCATION = cells[i, 7].StringValue.Trim();
                                row.IVC = cells[i, 8].StringValue.Trim();
                                row.REVIVAL = cells[i, 9].StringValue.Trim();
                                row.HUSBANDRY_START = cells[i, 5].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 5].StringValue.Trim());
                                row.DATE_OF_DEAD = cells[i, 6].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 6].StringValue.Trim());
                                row.ANIMAL = cells[i, 10].StringValue.Trim();
                                row.COMMENTS = cells[i, 11].StringValue.Trim();
                                row.DATE_OF_UPDATE = DateTime.Now;
                                bll.Add(row);
                            }
                            else
                            {
                                row.CurModel = DealModel.Modify;
                                row.LEADER = cells[i, 1].StringValue.Trim();
                                row.GROUP_NAME = cells[i, 2].StringValue.Trim();
                                row.RN = cells[i, 3].StringValue.Trim();
                                row.PN = cells[i, 4].StringValue.Trim();
                                row.LOCATION = cells[i, 7].StringValue.Trim();
                                row.IVC = cells[i, 8].StringValue.Trim();
                                row.REVIVAL = cells[i, 9].StringValue.Trim();
                                row.HUSBANDRY_START = cells[i, 5].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 5].StringValue.Trim());
                                row.DATE_OF_DEAD = cells[i, 6].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 6].StringValue.Trim());
                                row.ANIMAL = cells[i, 10].StringValue.Trim();
                                row.COMMENTS = cells[i, 11].StringValue.Trim();
                                row.DATE_OF_UPDATE = DateTime.Now;
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

        public void DeleteHus(HttpContext context)
        {
            int count = ojbRuleHuData.delHusbandry();
            context.Response.Write("Delete Successfully");

        }

        //public void AddModelTree(HttpContext context)
        //{
        //    BaseList importData2 = new BaseList();
        //    DataTable importData = new DataTable();
        //    importData.Columns.Add("Number");
        //    importData.Columns.Add("Model_ID");
        //    importData.Columns.Add("Status");
        //    importData.Columns.Add("Rn");
        //    importData.Columns.Add("Pn");
        //    importData.Columns.Add("DOI");
        //    importData.Columns.Add("Location");
        //    importData.Columns.Add("Passage");
        //    importData.Columns.Add("AID", typeof(Int32));
        //    importData.Columns.Add("P_ID", typeof(Int32));

        //    BaseList data_Tree = new BaseList();
        //    ParamCollection paraList = new ParamCollection();
        //    paraList.Clause += ANIMAL_TREE.P_ID_FIELD + "='0'";
        //    BaseList Models = bll.Select(paraList, typeof(ANIMAL_TREE));
        //    List<ANIMAL_TREE> trees = Models.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert);
        //    string tempMID="";
        //     BaseList alltree = new BaseList();
        //    //int aid = 0;
        //    //string rn = "";
        //    string filePath = updateInfo(context);
        //    try
        //    {
        //        Workbook book = new Workbook(filePath);
        //        Worksheet sheet = book.Worksheets[0];
        //        Cells cells = sheet.Cells;
        //        for (int i = 0; i < cells.MaxDataRow + 1; i++)
        //        {

        //            if (cells[i, 0].StringValue != "#")
        //            {
        //                if (cells[i, 3].StringValue != "")
        //                {
        //                    ANIMAL_TREE row = trees.Find(delegate(ANIMAL_TREE perm) { return perm.MODEL_ID == cells[i, 1].StringValue; });
        //                    if (row == null)
        //                    {
        //                        row = new ANIMAL_TREE(DealModel.New);
                               
        //                        row.MODEL_ID = cells[i, 1].StringValue;
        //                        row.STATUS = "";
        //                        row.RN = "";
        //                        row.PN = "";
        //                        row.DOI = "";
        //                        row.LOCATION = "";
                                
        //                        row.AID = SeqNoRule.MaxSeqNo("ANIMAL_TREE", "P_ID", "0", "AID") + 1;
        //                        row.P_ID = 0;
        //                        bll.Update(row);
        //                        trees.Add(row);


        //                        ANIMAL_TREE newRow = new ANIMAL_TREE(DealModel.New);
                             
        //                        newRow.MODEL_ID = cells[i, 1].StringValue;
        //                        newRow.STATUS = cells[i, 2].StringValue;
        //                        newRow.RN = cells[i, 3].StringValue;
        //                        newRow.PN = cells[i, 4].StringValue;
        //                        newRow.DOI = cells[i, 5].StringValue;
        //                        newRow.LOCATION = cells[i, 6].StringValue;
                                
        //                        newRow.AID = int.Parse(row.AID + cells[i, 3].StringValue + cells[i, 4].StringValue);
        //                        newRow.P_ID = row.AID;
        //                        //aid = int.Parse(newRow[8].ToString());
        //                        //rn = cells[i, 3].StringValue;
        //                        bll.Update(newRow);
        //                    }
        //                    else
        //                    {
                               
        //                        if (cells[i, 1].StringValue != tempMID)
        //                        {
        //                            ParamCollection paralist = new ParamCollection();
        //                            paralist.Clause += ANIMAL_TREE.MODEL_ID_FIELD + "='" + cells[i, 1].StringValue + "'";
        //                            alltree = bll.Select(paralist, typeof(ANIMAL_TREE));
        //                            tempMID = cells[i, 1].StringValue;
        //                        }
        //                        List<ANIMAL_TREE> alltreeData = alltree.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert);
        //                        List<ANIMAL_TREE> lastData = alltreeData.FindAll(delegate(ANIMAL_TREE perm) { return perm.RN == cells[i, 3].StringValue; });
        //                        lastData = lastData.OrderBy(s => decimal.Parse(s.PN)).ToList();
        //                        if (lastData.Count > 0)// 找到Rn一样的
        //                        {
        //                            ANIMAL_TREE sameRow = lastData.Find(delegate(ANIMAL_TREE perm)
        //                            {
        //                                return perm.PN == cells[i, 4].StringValue;
        //                            });
        //                            if (sameRow == null)//没有相同的
        //                            {
        //                                //string maxPN = lastData.OrderByDescending(s => decimal.Parse(s.PN)).FirstOrDefault().PN;
        //                                ANIMAL_TREE lastRow = lastData.FindLast(delegate(ANIMAL_TREE perm)
        //                                {
        //                                    return perm.RN == cells[i, 3].StringValue && int.Parse(perm.PN) < int.Parse(cells[i, 4].StringValue);
        //                                });

        //                                ANIMAL_TREE threeRow = new ANIMAL_TREE(DealModel.New);
                                    
        //                                threeRow.MODEL_ID = cells[i, 1].StringValue;
        //                                threeRow.STATUS = cells[i, 2].StringValue;
        //                                threeRow.RN = cells[i, 3].StringValue;
        //                                threeRow.PN = cells[i, 4].StringValue;
        //                                threeRow.DOI = cells[i, 5].StringValue;
        //                                threeRow.LOCATION = cells[i, 6].StringValue;
                                      
        //                                threeRow.AID = int.Parse(row.AID + cells[i, 3].StringValue + cells[i, 4].StringValue);
        //                                if (lastRow != null)//有上一条
        //                                {                           
        //                                    threeRow.P_ID = lastRow.AID;
        //                                }
        //                                else
        //                                {                                          
        //                                    threeRow.P_ID = row.AID;
        //                                }
        //                                alltree.Add(threeRow);
        //                                importData2.Add(threeRow);

        //                                ANIMAL_TREE nextRow = lastData.First(delegate(ANIMAL_TREE perm)
        //                                {
        //                                    return perm.RN == cells[i, 3].StringValue && int.Parse(perm.PN) > int.Parse(cells[i, 4].StringValue);
        //                                });
        //                                if (nextRow != null)//有下一条
        //                                {
        //                                    nextRow.CurModel = DealModel.Modify;
        //                                    nextRow.P_ID = threeRow.AID;
        //                                    bll.Update(nextRow);
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            ANIMAL_TREE threeRow = new ANIMAL_TREE(DealModel.New);
                                  
        //                            threeRow.MODEL_ID = cells[i, 1].StringValue;
        //                            threeRow.STATUS = cells[i, 2].StringValue;
        //                            threeRow.RN = cells[i, 3].StringValue;
        //                            threeRow.PN = cells[i, 4].StringValue;
        //                            threeRow.DOI = cells[i, 5].StringValue;
        //                            threeRow.LOCATION = cells[i, 6].StringValue;
                              
        //                            threeRow.AID = int.Parse(row.AID + cells[i, 3].StringValue + cells[i, 4].StringValue);
        //                            threeRow.P_ID = row.AID;
        //                            alltree.Add(threeRow);
        //                            importData2.Add(threeRow);
        //                        }


        //                    }
        //                }
                        
        //            }
        //        }
        //        ArrayList columns = new ArrayList();
        //        foreach (DataColumn dc in importData.Columns)
        //        {
        //            columns.Add(dc.ColumnName);
        //        }
        //        ojbReportRule.InsertBigSql(UtitityHelper.ToDataTable(importData2), columns, "ANIMAL_TREE");
        //        context.Response.Write("Import successfully!");
        //    }
        //    catch (Exception ex)
        //    {
        //        context.Response.Write(ex.Message);
        //    }

        //}
        public void Cachexia(HttpContext context, string table_name)
        {

            string msg = "";
            BaseList data = bll.Select(typeof(PDXMODEL_INFO));
            List<PDXMODEL_INFO> lists = data.ConvertAll(PDXMODEL_INFO.Convert);
                      
            string filePath = updateInfo(context);
            try
            {
                Workbook book = new Workbook(filePath);
                Worksheet sheet = book.Worksheets[0];

                Cells cells = sheet.Cells;
                for (int i = 0; i < cells.MaxDataRow + 1; i++)
                {
                    PDXMODEL_INFO row = lists.Find(delegate(PDXMODEL_INFO perm) { return perm.MODEL_ID == cells[i, 0].StringValue; });
                    if (row != null)
                    {
                        row.CurModel = DealModel.Modify;
                        row.CACHEXIA_LABEL = cells[i, 1].StringValue.Trim();
                        row.CACHEXIA = cells[i, 2].StringValue.Trim();
                        row.SLIGHT_BW_LOSS = cells[i, 3].StringValue.Trim();
                        row.NORMAL = cells[i, 4].StringValue.Trim();
                        bll.Update(row);
                    }
                }
                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }

        public void Table_1(HttpContext context, string table_name)
        {

            string msg = "";
            BaseList importData2 = new BaseList();
            DataTable importData = new DataTable();


            importData.Columns.Add("id");
            importData.Columns.Add("pro");
            string filePath = updateInfo(context);
            try
            {
                Workbook book = new Workbook(filePath);
                Worksheet sheet = book.Worksheets[0];

                Cells cells = sheet.Cells;
                for (int i = 0; i < cells.MaxDataRow + 1; i++)
                {
                    if (cells[i, 0].StringValue != "Specimen_Stock_ID" && cells[i, 0].StringValue != "")
                    {
                        DataRow newRow = importData.NewRow();
                     
                        newRow[0] = cells[i, 0].StringValue;
                        newRow[1] = cells[i, 1].StringValue;
                        importData.Rows.Add(newRow);
                    }
                }


                ArrayList columns = new ArrayList();
                foreach (DataColumn dc in importData.Columns)
                {
                    columns.Add(dc.ColumnName);
                }
                ojbReportRule.InsertBigSql(importData, columns, table_name);

                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }
    
        public void NewModel(HttpContext context,string table_name)
        {

            string msg = "";
            BaseList importData2 = new BaseList();
            DataTable importData = new DataTable();


            importData.Columns.Add("Serial");
            importData.Columns.Add("Model_Type");
            importData.Columns.Add("Cancer_Type_Abbr");
            importData.Columns.Add("Subtype1");
            importData.Columns.Add("Subtype2");
            importData.Columns.Add("Model_ID");
            importData.Columns.Add("Project");
            importData.Columns.Add("Location");
            importData.Columns.Add("Source_Animal");
            importData.Columns.Add("Opreation");
            importData.Columns.Add("Rn");
            importData.Columns.Add("Pn");
            importData.Columns.Add("Date_of_Passage_inoculation", typeof(DateTime));
            importData.Columns.Add("Study");
            importData.Columns.Add("Animal_Strain");
            importData.Columns.Add("Animal_Sex");
            importData.Columns.Add("Current_Animal_Ear_Tag");
            importData.Columns.Add("Animal_Quantity");
            importData.Columns.Add("PDX_growth_status");
            importData.Columns.Add("Date_of_Passage_Termination", typeof(DateTime));
            importData.Columns.Add("Duration");
            //移除
            importData.Columns.Add("Source_Hospital");
            importData.Columns.Add("Pathology_info_available");
            importData.Columns.Add("Date_of_Pathology_info_Received", typeof(DateTime));
            importData.Columns.Add("Patient_No");
            importData.Columns.Add("Patient_Name");
            importData.Columns.Add("Patient_Age");
            importData.Columns.Add("Patient_Sex");
            importData.Columns.Add("Patient_Pathology_info_Qced");
            //
            importData.Columns.Add("Pathology_info_Qced");
            importData.Columns.Add("Comments");
            importData.Columns.Add("Editor");
            importData.Columns.Add("Date_of_Create", typeof(DateTime));
            importData.Columns.Add("Animal_Room_Number");
            importData.Columns.Add("Model_Tumor_Characteristics");
            string filePath = updateInfo(context);
            try
            {
                Workbook book = new Workbook(filePath);
                Worksheet sheet = book.Worksheets[0];

                Cells cells = sheet.Cells;
                for (int i = 0; i < cells.MaxDataRow + 1; i++)
                {
                    if (cells[i, 0].StringValue != "Serial" && cells[i, 0].StringValue != "")
                    {
                        DataRow newRow = importData.NewRow();
                        string sq = cells[i, 0].StringValue;
                        if (sq.Length < 4)
                        {
                            sq = sq.PadLeft(4, '0');
                        }
                        newRow[0] = sq;
                        newRow[1] = cells[i, 1].StringValue;
                        newRow[2] = cells[i, 2].StringValue;
                        newRow[3] = cells[i, 3].StringValue;
                        newRow[4] = cells[i, 4].StringValue;
                        newRow[5] = cells[i, 5].StringValue;
                        newRow[6] = cells[i, 6].StringValue;
                        newRow[7] = cells[i, 7].StringValue;
                        newRow[8] = cells[i, 8].StringValue.Replace("\r\n", "").Replace("\n", "");
                        newRow[9] = cells[i, 9].StringValue;
                        newRow[10] = cells[i, 10].StringValue;
                        newRow[11] = cells[i, 11].StringValue;
                        newRow[12] = cells[i, 12].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 12].StringValue.Trim());
                        newRow[13] = cells[i, 13].StringValue;
                        newRow[14] = cells[i, 14].StringValue;
                        newRow[15] = cells[i, 15].StringValue;
                        newRow[16] = cells[i, 16].StringValue;
                        newRow[17] = cells[i, 17].StringValue;
                        newRow[18] = cells[i, 18].StringValue;
                        newRow[19] = cells[i, 19].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 19].StringValue.Trim());
                        newRow[20] = cells[i, 20].StringValue;
                        newRow[21] = cells[i, 21].StringValue;
                        newRow[22] = cells[i, 22].StringValue;
                        newRow[23] = cells[i, 23].StringValue.Trim() == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 23].StringValue.Trim());
                        newRow[24] = cells[i, 24].StringValue;
                        newRow[25] = cells[i, 25].StringValue;
                        newRow[26] = cells[i, 26].StringValue;
                        newRow[27] = cells[i, 27].StringValue;
                        newRow[28] = cells[i, 28].StringValue;
                        newRow[29] = cells[i, 29].StringValue;
                        newRow[30] = cells[i, 30].StringValue;
                        newRow[31] = "Admin";
                        newRow[32] = DateTime.Now;
                        newRow[33] = cells[i, 33].StringValue;
                        newRow[34] = cells[i, 34].StringValue;
                        importData.Rows.Add(newRow);
                       
                        if (newRow["PDX_GROWTH_STATUS"].ToString() == "PDX taken" && newRow["MODEL_ID"].ToString().Substring(0, 1) != "m")
                        {
                            #region 更新至Model_Tree
                            ArrayList lists = new ArrayList();
                            lists.Add(newRow["MODEL_ID"].ToString());
                            lists.Add(newRow["OPREATION"].ToString());
                            lists.Add(newRow["RN"].ToString().Replace("R", ""));
                            lists.Add(newRow["PN"].ToString().Replace("P", ""));
                            lists.Add(newRow[12].ToString());
                            lists.Add(newRow[19].ToString());
                            string location = newRow["LOCATION"].ToString().Length > 7 ? newRow["LOCATION"].ToString().Substring(6, 2) : newRow["LOCATION"].ToString();
                            lists.Add(location);
                            Person pp = new Person();
                            pp.AddToModelTree(lists);
                            #endregion
                        }
                    }
                }
                ArrayList columns = new ArrayList();
                foreach (DataColumn dc in importData.Columns)
                {
                    columns.Add(dc.ColumnName);
                }
                ojbReportRule.InsertBigSql(importData, columns, table_name);

                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }


        public void Tissue_Withdraw(HttpContext context)
        {
            string msg = "";
            BaseList importData2 = new BaseList();
            DataTable importData = new DataTable();
            context.Session["temp_tissue"] = null;
            context.Session["temp_Withdraw"] = null;
            importData.Columns.Add("Specimen_Stock_ID");
            importData.Columns.Add("Model_ID");
            importData.Columns.Add("Confirm"); 
            importData.Columns.Add("Rn");
            importData.Columns.Add("Pn");
            importData.Columns.Add("Date_of_Inoculation", typeof(DateTime));
            importData.Columns.Add("Animal_Number");
            importData.Columns.Add("Total_Tumor_Volume");
            importData.Columns.Add("Date_of_Tissue_Collection", typeof(DateTime));
            importData.Columns.Add("Site_of_Tissue_Collection");
            importData.Columns.Add("Tissue_Type");
            importData.Columns.Add("Preserve_Method");
            importData.Columns.Add("Treatment_To_Mice");
            importData.Columns.Add("Location_ID");
            importData.Columns.Add("Well_ID");
            importData.Columns.Add("Export_Date", typeof(DateTime));
            importData.Columns.Add("Export_Project_Number");
          
            //importData.Columns.Add("have_animal"); 
            string filePath = updateInfo2(context);
            try
            {
                Workbook book = new Workbook(filePath);
                Worksheet sheet = book.Worksheets[0];

                Cells cells = sheet.Cells;


                BaseList animalInfo = bll.Select(typeof(ANIMAL_INFO));
                List<ANIMAL_INFO> animals = animalInfo.ConvertAll<ANIMAL_INFO>(ANIMAL_INFO.Convert);
                context.Session["temp_tissue"] = null;
                for (int i = 0; i < cells.MaxDataRow + 1; i++)
                {
                    if (cells[i, 0].StringValue != "Model ID")
                    {
                        #region 判断是否已出库
                        ParamCollection paralist = new ParamCollection();
                        SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Location_ID", cells[i, 11].StringValue.Replace("\t", "")), new SqlParameter("@Well_ID", cells[i, 12].StringValue) };
                        DataTable haveData = ojbReportRule.GetGrid("GetCheck_SpecimenStocks", para);
                        if (haveData.Rows.Count == 0)
                        {
                            msg = "The well ID of " + i + "row is empty.";
                            break;
                        }
                        #endregion


                        DataRow newRow = importData.NewRow();
                        newRow[0] = haveData.Rows[0]["Specimen_Stock_ID"].ToString();
                        newRow[1] = cells[i, 0].StringValue;
                        newRow[2] = "Yes";
                        newRow[3] = cells[i, 1].StringValue;
                        newRow[4] = cells[i, 2].StringValue;
                        newRow[5] = cells[i, 3].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 3].StringValue);
                        newRow[6] = cells[i, 4].StringValue;
                        newRow[7] = cells[i, 5].StringValue;
                        newRow[8] = cells[i, 6].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 6].StringValue);
                        newRow[9] = cells[i, 7].StringValue;
                        newRow[10] = cells[i, 8].StringValue;
                        newRow[11] = cells[i, 9].StringValue;
                        newRow[12] = cells[i, 10].StringValue;
                        newRow[13] = cells[i, 11].StringValue.Replace("\t", "");
                        newRow[14] = cells[i, 12].StringValue;
                        newRow[15] = cells[i, 15].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 15].StringValue);
                        newRow[16] = FormatHelper.doRemoveEmpty(cells[i, 16].StringValue);

                        importData.Rows.Add(newRow);
                    }
                }
                context.Session["temp_Withdraw"] = importData;
                if (importData.Rows.Count > 0)
                { msg = "Import cache."; }
             
                


                context.Response.Write(msg);
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }

        public void SpecimenStock(HttpContext context)
        {
            string msg = "";
            BaseList importData2 = new BaseList();
            DataTable importData = new DataTable();
            context.Session["temp_tissue"] = null;
            context.Session["temp_Withdraw"] = null;
            importData.Columns.Add("Model_ID");
            importData.Columns.Add("Rn");
            importData.Columns.Add("Pn");
            importData.Columns.Add("Date_of_Inoculation", typeof(DateTime));
            importData.Columns.Add("Animal_Number");
            importData.Columns.Add("Total_Tumor_Volume");
            importData.Columns.Add("Date_of_Tissue_Collection", typeof(DateTime));
            importData.Columns.Add("Site_of_Tissue_Collection");
            importData.Columns.Add("Tissue_Type");
            importData.Columns.Add("Preserve_Method");
            importData.Columns.Add("Treatment_To_Mice");
            importData.Columns.Add("Location_ID");
            importData.Columns.Add("Well_ID");
            importData.Columns.Add("Import_Date", typeof(DateTime));
            importData.Columns.Add("Import_Project_Number");
            importData.Columns.Add("STR"); 
            importData.Columns.Add("Specimen_Stock_ID");
            importData.Columns.Add("Region"); 
            string filePath = updateInfo(context);
            try
            {
                Workbook book = new Workbook(filePath);
                Worksheet sheet = book.Worksheets[0];

                Cells cells = sheet.Cells;


                BaseList animalInfo = bll.Select(typeof(ANIMAL_INFO));
                List<ANIMAL_INFO> animals = animalInfo.ConvertAll<ANIMAL_INFO>(ANIMAL_INFO.Convert);
                context.Session["temp_tissue"] = null;
                for (int i = 0; i < cells.MaxDataRow + 1; i++)
                {
                    if (cells[i, 0].StringValue != "Model ID")
                    {
                        #region 判断是否已入库
                        ParamCollection paralist = new ParamCollection();
                        SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Location_ID", cells[i, 11].StringValue.Replace("\t", "")), new SqlParameter("@Well_ID", cells[i, 12].StringValue) };
                        DataTable haveData = ojbReportRule.GetGrid("GetCheck_SpecimenStocks", para);
                        if (haveData.Rows.Count > 0)
                        {
                            msg ="The well ID of " + i+1 + " row is exist.";
                            break;
                        }
                        #endregion


                        DataRow newRow = importData.NewRow();
                        newRow[0] = cells[i, 0].StringValue.Trim();
                        newRow[1] = cells[i, 1].StringValue.Trim();
                        newRow[2] = cells[i, 2].StringValue.Trim();
                        newRow[3] = cells[i, 3].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 3].StringValue);
                        newRow[4] = cells[i, 4].StringValue.Trim();
                        newRow[5] = cells[i, 5].StringValue.Trim();
                        newRow[6] = cells[i, 6].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 6].StringValue);
                        newRow[7] = cells[i, 7].StringValue.Trim();
                        newRow[8] = cells[i, 8].StringValue.Trim();
                        newRow[9] = cells[i, 9].StringValue.Trim();
                        newRow[10] = cells[i, 10].StringValue.Trim();
                        newRow[11] = cells[i, 11].StringValue.Replace("\t", "").Trim();
                        newRow[12] = cells[i, 12].StringValue.Trim();
                        newRow[13] = cells[i, 13].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 13].StringValue);
                        newRow[14] = FormatHelper.doRemoveEmpty(cells[i, 14].StringValue);
                        newRow[15] = cells[i, 15].StringValue.Trim();
                        newRow[16] = i.ToString();

                        string S_region = context.Request["S_region"] ?? "";
                        newRow[17] = S_region;
                        //ANIMAL_INFO havaData = animals.Find(delegate(ANIMAL_INFO perm) { return perm.MODEL_ID == newRow[0].ToString() && perm.RN == newRow[1].ToString() && perm.PN == newRow[2].ToString() && perm.ANIMAL_NUMBER == newRow[4].ToString(); });
                        //if (havaData != null)
                        //{
                        //    newRow[16] = "yes";
                           
                        //}
                        //else {
                        //    newRow[16] = "";
                        //}
                        importData.Rows.Add(newRow);
                    }
                }
                context.Session["temp_tissue"] = importData;
                if (importData.Rows.Count > 0)
                { msg = "Import cache."; }
                //ArrayList columns = new ArrayList();
                //foreach (DataColumn dc in importData.Columns)
                //{
                //    columns.Add(dc.ColumnName);
                //}
                //ojbReportRule.InsertBigSql(importData, columns, "Specimen_Stock");


                //第一次导入时用导入Location，否则注释
                #region 计算总格子和占用格子

                //try
                //{
                //    List<LOCATION> allChilds = new List<LOCATION>();
                //    BaseList locationData = bll.Select(typeof(LOCATION));
                //    List<LOCATION> lData = locationData.ConvertAll<LOCATION>(LOCATION.Convert);
                //    foreach (LOCATION dr in locationData)
                //    {
                //        string filter = dr.AID.Split(';')[0].ToString();
                //        if (dr.ISPARENT)
                //        {
                //            List<LOCATION> allChilds2 = lData.FindAll(delegate(LOCATION perm) { return !perm.ISPARENT && perm.P_ID.Length > filter.Length; });
                //            allChilds = allChilds2.FindAll(delegate(LOCATION perm) { return perm.P_ID.Substring(0, filter.Length) == filter; });
                //        }
                //        else
                //        {
                //            allChilds = lData.FindAll(delegate(LOCATION perm) { return perm.AID == dr.AID; });
                //        }

                //        double allbox = 0;//全部冰箱
                //        foreach (LOCATION drr in allChilds)
                //        {
                //            allbox += double.Parse(drr.MAPS_ROWS) * double.Parse(drr.MAPS_COLUMNS);
                //        }
                //        dr.CurModel = DealModel.Modify;
                //        dr.BOX_NUMBER = allbox;

                //        DataTable db = ojbRuleHuData.getCountBankBox(filter);
                //        double havebox = 0;
                //        if (db.Rows.Count > 0)
                //        {
                //            havebox = double.Parse(db.Rows[0][0].ToString());
                //        }
                //        //已用冰箱个数
                //        dr.USED_SPACE = havebox;
                        
                //    }
                //    bll.UpdateAllByParams(locationData);
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}
                #endregion


                context.Response.Write(msg);
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }

        public void Sponsor(HttpContext context)
        {
            BaseList importData2 = new BaseList();
            DataTable importData = new DataTable();
            importData.Columns.Add("SPONSOR");
            importData.Columns.Add("AX_CODE");
        
            string filePath = updateInfo(context);
            try
            {

                ojbRuleHuData.deleteSponsor();
                Workbook book = new Workbook(filePath);
                foreach (Worksheet sheet in book.Worksheets)
                {
                    Cells cells = sheet.Cells;
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        if (cells[i, 0].StringValue != "客户帐户")
                        {
                            SPONSOR_AX_CODE newRow = new SPONSOR_AX_CODE(DealModel.New);
                            newRow.SPONSOR = cells[i, 2].StringValue.Replace("\r", "").Replace("\n", "").Replace("\"", "'");
                            newRow.AX_CODE = cells[i, 0].StringValue;
                            importData2.Add(newRow);
                        }
                    }
                }

                ArrayList columns = new ArrayList();
                foreach (DataColumn dc in importData.Columns)
                {
                    columns.Add(dc.ColumnName);
                }
                ojbReportRule.InsertBigSql(UtitityHelper.ToDataTable(importData2), columns, "SPONSOR_AX_CODE");

                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }

        public void Maintain(HttpContext context)
        {
            BaseList importData2 = new BaseList();
            DataTable importData = new DataTable();
            importData.Columns.Add("AnimalTree_ID");
            importData.Columns.Add("Model_ID");
            importData.Columns.Add("DOI", typeof(DateTime));
            importData.Columns.Add("RN");
            importData.Columns.Add("PN");
            importData.Columns.Add("Maintain");
            string filePath = updateInfo(context);
            try
            {
               
                ParamCollection paraList = new ParamCollection();
                paraList.Clause += ANIMAL_TREE.LOCATION_FIELD + "<> ''";
                BaseList Models = bll.Select(paraList, typeof(ANIMAL_TREE));
                List<ANIMAL_TREE> trees = Models.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert);

                BaseList mdatas = bll.Select(typeof(MODELTREE_MAINTAIN));
                List<MODELTREE_MAINTAIN> mdata = mdatas.ConvertAll<MODELTREE_MAINTAIN>(MODELTREE_MAINTAIN.Convert);


                Workbook book = new Workbook(filePath);
                foreach (Worksheet sheet in book.Worksheets)
                {
                   
                    Cells cells = sheet.Cells;
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        ANIMAL_TREE row = trees.Find(delegate(ANIMAL_TREE perm) { return perm.MODEL_ID == cells[i, 0].StringValue && perm.RN == cells[i, 2].StringValue && perm.PN == cells[i, 3].StringValue && perm.LOCATION == cells[i, 5].StringValue && perm.DOI == cells[i, 4].StringValue; });
                        if (row != null)
                        {
                            MODELTREE_MAINTAIN oldRow = mdata.Find(delegate(MODELTREE_MAINTAIN perm) { return perm.ANIMALTREE_ID == row.AID; });
                            if (oldRow == null)
                            {
                                MODELTREE_MAINTAIN newRow = new MODELTREE_MAINTAIN(DealModel.New);
                                newRow.MODEL_ID = row.MODEL_ID;
                                newRow.ANIMALTREE_ID = row.AID;
                                newRow.RN = row.RN;
                                newRow.PN = row.PN;
                                newRow.DOI = DateTime.Parse(cells[i, 4].StringValue);
                                newRow.MAINTAIN = cells[i, 1].StringValue;
                                importData2.Add(newRow);
                            }
                        }
                    }
                }

                ArrayList columns = new ArrayList();
                foreach (DataColumn dc in importData.Columns)
                {
                    columns.Add(dc.ColumnName);
                }
                ojbReportRule.InsertBigSql(UtitityHelper.ToDataTable(importData2), columns, "ModelTree_Maintain");

                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }


        public void AddModelTree2(HttpContext context)
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

        
            //int aid = 0;
            //string rn = "";
            string filePath = updateInfo(context);
            try
            {

                Workbook book = new Workbook(filePath);
                foreach (Worksheet sheet in book.Worksheets)
                {
                    importData2 = new BaseList();

                    BaseList data_Tree = new BaseList();
                    ParamCollection paraList = new ParamCollection();
                    paraList.Clause += ANIMAL_TREE.P_ID_FIELD + "='0'";
                    BaseList Models = bll.Select(paraList, typeof(ANIMAL_TREE));
                    List<ANIMAL_TREE> trees = Models.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert);
                    ArrayList tempMID = new ArrayList();
                    BaseList alltree = new BaseList();

                    Cells cells = sheet.Cells;
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        if (cells[i, 2].StringValue != "" && cells[i, 0].StringValue != "Model ID")//Rn不为空
                        {
                            string str_doi = cells[i, 4].StringValue.Trim() == "" ? "" : DateTime.Parse(cells[i, 4].StringValue).ToString("yyyy/MM/dd");
                            string str_dot = cells[i, 5].StringValue.Trim() == "" ? "" : DateTime.Parse(cells[i, 5].StringValue).ToString("yyyy/MM/dd");
                            ANIMAL_TREE row = trees.Find(delegate(ANIMAL_TREE perm) { return perm.MODEL_ID == cells[i, 0].StringValue; });
                            if (row == null)
                            {
                                row = new ANIMAL_TREE(DealModel.New);
                                row.MODEL_ID = cells[i, 0].StringValue;
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
                                RnRow.MODEL_ID = cells[i, 0].StringValue;
                                RnRow.STATUS = "";
                                RnRow.RN = cells[i, 2].StringValue;
                                RnRow.PN = "";
                                RnRow.DOI = "";
                                RnRow.DOT = "";
                                RnRow.LOCATION = "";
                                RnRow.AID = row.MODEL_ID + "-" + RnRow.RN;
                                RnRow.P_ID = row.AID;
                                bll.Update(RnRow);


                                ANIMAL_TREE RnPnRow = new ANIMAL_TREE(DealModel.New);
                                RnPnRow.MODEL_ID = cells[i, 0].StringValue;
                                RnPnRow.STATUS = "";
                                RnPnRow.RN = cells[i, 2].StringValue;
                                RnPnRow.PN = cells[i, 3].StringValue;
                                RnPnRow.DOI = "";
                                RnPnRow.DOT = "";
                                RnPnRow.LOCATION = "";
                                RnPnRow.AID = RnRow.AID + RnPnRow.RN + RnPnRow.PN;
                                RnPnRow.P_ID = RnRow.AID;
                                bll.Update(RnPnRow);


                                ANIMAL_TREE DOIRow = new ANIMAL_TREE(DealModel.New);
                                DOIRow.MODEL_ID = cells[i, 0].StringValue;
                                DOIRow.STATUS = "";
                                DOIRow.RN = cells[i, 2].StringValue;
                                DOIRow.PN = cells[i, 3].StringValue;
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

                                newRow.MODEL_ID = cells[i, 0].StringValue;
                                newRow.STATUS = cells[i, 1].StringValue;
                                newRow.RN = cells[i, 2].StringValue;
                                newRow.PN = cells[i, 3].StringValue;
                                newRow.DOI = str_doi;
                                newRow.DOT = str_dot;
                                newRow.LOCATION = cells[i, 6].StringValue;
                                newRow.AID = DOIRow.AID + "-" + newRow.LOCATION;
                                newRow.P_ID = DOIRow.AID;
                                //aid = int.Parse(newRow[8].ToString());
                                //rn = cells[i, 3].StringValue;
                                bll.Update(newRow);




                            }
                            else
                            {
                                List<ANIMAL_TREE> alltreeData = null;
                                if (!tempMID.Contains(cells[i, 0].StringValue))
                                {
                                    ParamCollection paralist = new ParamCollection();
                                    paralist.Clause += ANIMAL_TREE.MODEL_ID_FIELD + "='" + cells[i, 0].StringValue + "'";
                                    alltree = bll.Select(paralist, typeof(ANIMAL_TREE));
                                    tempMID.Add(cells[i, 0].StringValue);
                                    alltreeData = alltree.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert);
                                }
                                else {
                                    ParamCollection paralist = new ParamCollection();
                                    paralist.Clause += ANIMAL_TREE.MODEL_ID_FIELD + "='" + cells[i, 0].StringValue + "'";
                                    alltree = bll.Select(paralist, typeof(ANIMAL_TREE));

                                    List<ANIMAL_TREE> addData  = importData2.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert).FindAll(delegate(ANIMAL_TREE perm) { return perm.MODEL_ID == cells[i, 0].StringValue; });
                                    IEnumerable<ANIMAL_TREE> alltreeData2  =alltree.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert).Union(addData);
                                    alltreeData = alltreeData2.ToList();
                                    tempMID.Add(cells[i, 0].StringValue);
                                }
                                ANIMAL_TREE RnData = alltreeData.Find(delegate(ANIMAL_TREE perm) { return perm.RN == cells[i, 2].StringValue && perm.PN == ""; });
                                //lastData = lastData.OrderBy(s => decimal.Parse(s.PN)).ToList();
                                if (RnData != null)// 有Rn
                                {
                                    ANIMAL_TREE RNPNRow = alltreeData.Find(delegate(ANIMAL_TREE perm) { return perm.RN == cells[i, 2].StringValue && perm.PN == cells[i, 3].StringValue && perm.DOI == ""; });
                                    if (RNPNRow != null)//有RnPn
                                    {

                                        ANIMAL_TREE DOIData = alltreeData.Find(delegate(ANIMAL_TREE perm) { return perm.RN == cells[i, 2].StringValue && perm.PN == cells[i, 3].StringValue && perm.DOI == str_doi && perm.LOCATION == ""; });
                                        if (DOIData != null)//有DOI
                                        {
                                            ANIMAL_TREE LocationData = alltreeData.Find(delegate(ANIMAL_TREE perm) { return perm.PN == cells[i, 3].StringValue && perm.DOI == str_doi && perm.LOCATION == cells[i, 6].StringValue; });
                                           
                                            if (LocationData != null)//有Location
                                            {
                                                //插入tree141113-Revival时用
                                                if (str_dot != "" && LocationData.DOT =="")
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
                                            }
                                            else
                                            {
                                                #region 没有Location
                                                ANIMAL_TREE newRow = new ANIMAL_TREE(DealModel.New);

                                                newRow.MODEL_ID = cells[i, 0].StringValue;
                                                newRow.STATUS = cells[i, 1].StringValue;
                                                newRow.RN = cells[i, 2].StringValue;
                                                newRow.PN = cells[i, 3].StringValue;
                                                newRow.DOI = str_doi;
                                                newRow.DOT = str_dot;
                                                newRow.LOCATION = cells[i, 6].StringValue;
                                                newRow.AID = DOIData.AID + "-" + newRow.LOCATION;
                                                newRow.P_ID = DOIData.AID;

                                                alltree.Add(newRow);
                                                importData2.Add(newRow);

                                                ////string maxPN = lastData.OrderByDescending(s => decimal.Parse(s.PN)).FirstOrDefault().PN;
                                                //ANIMAL_TREE lastRow = lastData.FindLast(delegate(ANIMAL_TREE perm)
                                                //{
                                                //    return perm.RN == cells[i, 3].StringValue && int.Parse(perm.PN) < int.Parse(str_doi);
                                                //});

                                                //ANIMAL_TREE threeRow = new ANIMAL_TREE(DealModel.New);

                                                //threeRow.MODEL_ID = cells[i, 1].StringValue;
                                                //threeRow.STATUS = cells[i, 2].StringValue;
                                                //threeRow.RN = cells[i, 3].StringValue;
                                                //threeRow.PN = str_doi;
                                                //threeRow.DOI = str_dot;
                                                //threeRow.LOCATION = cells[i, 6].StringValue;

                                                ////threeRow.AID = int.Parse(row.AID + cells[i, 3].StringValue + str_doi);
                                                //if (lastRow != null)//有上一条
                                                //{
                                                //    threeRow.P_ID = lastRow.AID;
                                                //}
                                                //else
                                                //{
                                                //    threeRow.P_ID = row.AID;
                                                //}
                                                //alltree.Add(threeRow);
                                                //importData2.Add(threeRow);

                                                //ANIMAL_TREE nextRow = lastData.First(delegate(ANIMAL_TREE perm)
                                                //{
                                                //    return perm.RN == cells[i, 3].StringValue && int.Parse(perm.PN) > int.Parse(str_doi);
                                                //});
                                                //if (nextRow != null)//有下一条
                                                //{
                                                //    nextRow.CurModel = DealModel.Modify;
                                                //    nextRow.P_ID = threeRow.AID;
                                                //    bll.Update(nextRow);
                                                //}
                                                #endregion

                                            }
                                        }
                                        else
                                        {
                                            #region 没有DOI
                                            ANIMAL_TREE DOIRow = new ANIMAL_TREE(DealModel.New);
                                            DOIRow.MODEL_ID = cells[i, 0].StringValue;
                                            DOIRow.STATUS = "";
                                            DOIRow.RN = cells[i, 2].StringValue;
                                            DOIRow.PN = cells[i, 3].StringValue;
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

                                            newRow.MODEL_ID = cells[i, 0].StringValue;
                                            newRow.STATUS = cells[i, 1].StringValue;
                                            newRow.RN = cells[i, 2].StringValue;
                                            newRow.PN = cells[i, 3].StringValue;
                                            newRow.DOI = str_doi;
                                            newRow.DOT = str_dot;
                                            newRow.LOCATION = cells[i, 6].StringValue;
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
                                        RnPnRow.MODEL_ID = cells[i, 0].StringValue;
                                        RnPnRow.STATUS = "";
                                        RnPnRow.RN = cells[i, 2].StringValue;
                                        RnPnRow.PN = cells[i, 3].StringValue;
                                        RnPnRow.DOI = "";
                                        RnPnRow.DOT = "";
                                        RnPnRow.LOCATION = "";
                                        RnPnRow.AID = RnData.AID + RnPnRow.RN + RnPnRow.PN;
                                        RnPnRow.P_ID = RnData.AID;
                                        alltree.Add(RnPnRow);
                                        importData2.Add(RnPnRow);


                                        ANIMAL_TREE DOIRow = new ANIMAL_TREE(DealModel.New);
                                        DOIRow.MODEL_ID = cells[i, 0].StringValue;
                                        DOIRow.STATUS = "";
                                        DOIRow.RN = cells[i, 2].StringValue;
                                        DOIRow.PN = cells[i, 3].StringValue;
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

                                        newRow.MODEL_ID = cells[i, 0].StringValue;
                                        newRow.STATUS = cells[i, 1].StringValue;
                                        newRow.RN = cells[i, 2].StringValue;
                                        newRow.PN = cells[i, 3].StringValue;
                                        newRow.DOI = str_doi;
                                        newRow.DOT = str_dot;
                                        newRow.LOCATION = cells[i, 6].StringValue;
                                        newRow.AID = DOIRow.AID + "-" + newRow.LOCATION;
                                        newRow.P_ID = DOIRow.AID;
                                        //aid = int.Parse(newRow[8].ToString());
                                        //rn = cells[i, 3].StringValue;

                                        alltree.Add(newRow);
                                        importData2.Add(newRow);
                                        #endregion

                                    }
                                }
                                else
                                {
                                    #region 没有Rn
                                    ANIMAL_TREE RnRow = new ANIMAL_TREE(DealModel.New);
                                    RnRow.MODEL_ID = cells[i, 0].StringValue;
                                    RnRow.STATUS = "";
                                    RnRow.RN = cells[i, 2].StringValue;
                                    RnRow.PN = "";
                                    RnRow.DOI = "";
                                    RnRow.DOT = "";
                                    RnRow.LOCATION = "";
                                    RnRow.AID = row.MODEL_ID + "-" + RnRow.RN;
                                    RnRow.P_ID = row.AID;
                                    alltree.Add(RnRow);
                                    importData2.Add(RnRow);


                                    ANIMAL_TREE RnPnRow = new ANIMAL_TREE(DealModel.New);
                                    RnPnRow.MODEL_ID = cells[i, 0].StringValue;
                                    RnPnRow.STATUS = "";
                                    RnPnRow.RN = cells[i, 2].StringValue;
                                    RnPnRow.PN = cells[i, 3].StringValue;
                                    RnPnRow.DOI = "";
                                    RnPnRow.DOT = "";
                                    RnPnRow.LOCATION = "";
                                    RnPnRow.AID = RnRow.AID + RnPnRow.RN + RnPnRow.PN;
                                    RnPnRow.P_ID = RnRow.AID;
                                    alltree.Add(RnPnRow);
                                    importData2.Add(RnPnRow);


                                    ANIMAL_TREE DOIRow = new ANIMAL_TREE(DealModel.New);
                                    DOIRow.MODEL_ID = cells[i, 0].StringValue;
                                    DOIRow.STATUS = "";
                                    DOIRow.RN = cells[i, 2].StringValue;
                                    DOIRow.PN = cells[i, 3].StringValue;
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

                                    newRow.MODEL_ID = cells[i, 0].StringValue;
                                    newRow.STATUS = cells[i, 1].StringValue;
                                    newRow.RN = cells[i, 2].StringValue;
                                    newRow.PN = cells[i, 3].StringValue;
                                    newRow.DOI = str_doi;
                                    newRow.DOT = str_dot;
                                    newRow.LOCATION = cells[i, 6].StringValue;
                                    newRow.AID = DOIRow.AID + "-" + newRow.LOCATION;
                                    newRow.P_ID = DOIRow.AID;
                                    //aid = int.Parse(newRow[8].ToString());
                                    //rn = cells[i, 3].StringValue;

                                    alltree.Add(newRow);
                                    importData2.Add(newRow);

                                    #endregion

                                }


                            }
                        }


                    }
                    ArrayList columns = new ArrayList();
                    foreach (DataColumn dc in importData.Columns)
                    {
                        columns.Add(dc.ColumnName);
                    }
                    ojbReportRule.InsertBigSql(UtitityHelper.ToDataTable(importData2), columns, "ANIMAL_TREE");
                    UtitityHelper.ToDataTable(importData2).Dispose();
                }
                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }
        //算饲养天数
        public BaseList getHusbandry_Days(string strFileName, DataTable importData)
        {
            BaseList dataAll = bll.Select(typeof(HUSBANDRY_DAYS));
            try
            {
                Workbook book = new Workbook();
                book.Open(strFileName);
                List<HUSBANDRY_DAYS> mastdata = dataAll.ConvertAll<HUSBANDRY_DAYS>(HUSBANDRY_DAYS.Convert);

                #region add
                Worksheet sheet = book.Worksheets[0];
                Cells cells = sheet.Cells;
                for (int i = 0; i < cells.MaxDataRow + 1; i++)
                {
                    if (cells[i, 0].StringValue != "Date of update" && cells[i, 0].StringValue != "")
                    {
                        DateTime doi = cells[i, 5].StringValue == "" ? DateTime.MinValue : Convert.ToDateTime(cells[i, 5].StringValue);
                        HUSBANDRY_DAYS oldRow = mastdata.Find(delegate(HUSBANDRY_DAYS perm)
                        {
                            return perm.MODEL_ID == cells[i, 2].StringValue && perm.RN == cells[i, 3].StringValue &&
                                perm.PN == cells[i, 4].StringValue && perm.DOI == doi;
                        });
                        if (oldRow == null)
                        {
                            HUSBANDRY_DAYS newRow = new HUSBANDRY_DAYS(DealModel.New);
                            newRow.CANCER_TYPE = cells[i, 1].StringValue;
                            newRow.MODEL_ID = cells[i, 2].StringValue;
                            newRow.RN = cells[i, 3].StringValue;
                            newRow.PN = cells[i, 4].StringValue;
                            newRow.DOI = doi;
                            newRow.CAGE = "";
                            newRow.NUMBER_IN_CAGE = 0;
                            newRow.DATE_OF_UPDATE = cells[i, 0].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 0].StringValue);
                            newRow.HUNBANDRY_DAYS = 0;
                            newRow.COST_ACCUMULATION = "";
                            newRow.PROJECT = cells[i, 7].StringValue;
                            newRow.ALIVE = "";
                            mastdata.Add(newRow);
                            dataAll.Add(newRow);
                        }
                    }
                }
                #endregion

                #region alive
                foreach (HUSBANDRY_DAYS row in mastdata)
                {
                    if (row.ALIVE != "Die")
                    {
                        if (row.CurModel != DealModel.New)
                        {
                            row.CurModel = DealModel.Modify;
                        }
                        string pn = (int.Parse(row.PN.ToString().TrimStart('P')) + 1).ToString();
                        HUSBANDRY_DAYS newRow = mastdata.Find(delegate(HUSBANDRY_DAYS perm)
                        {
                            return perm.MODEL_ID == row.MODEL_ID && perm.RN == row.RN && perm.PN == pn  ;
                        });
                        DateTime start = row.DOI;//Husbandry Start
                        if (start < DateTime.Parse("2014/01/01"))
                        {
                            start = DateTime.Parse("2014/01/01");
                        }
                        if (newRow != null)//有迭代
                        {
                            if (row.ALIVE != "z")
                            {
                                if (newRow.DOI > DateTime.Parse("2014/01/01"))
                                {
                                    row.HUNBANDRY_DAYS = (newRow.DOI - start).Days + 1;
                                }
                                else
                                {
                                    row.HUNBANDRY_DAYS = (newRow.DOI - row.DOI).Days + 1;
                                }
                                row.ALIVE = "Die";
                            }
                        }
                        else
                        {

                        }
                        //if (row.PROJECT == "TC")
                        //{
                        //    row.COST_ACCUMULATION = (13 * row.NUMBER_IN_CAGE * row.HUNBANDRY_DAYS).ToString();
                        //}
                        //else
                        //{
                        //    row.COST_ACCUMULATION = (11 * row.NUMBER_IN_CAGE * row.HUNBANDRY_DAYS).ToString();
                        //}
                    }
                }


                #endregion

                #region dead
                BaseList tempZ = new BaseList();
                HUSBANDRY_DAYS tempRow = null;
                Worksheet sheet2 = book.Worksheets[1];
                if (sheet2 != null)
                {
                    Cells cells2 = sheet2.Cells;
                    if (cells2[0, 0].StringValue != "")
                    {
                        for (int i = 0; i < cells2.MaxDataRow + 1; i++)
                        {
                            if (cells2[i, 0].StringValue != "Date of update" && cells2[i, 0].StringValue != "")
                            {
                                DateTime doi = cells2[i, 5].StringValue == "" ? DateTime.MinValue : Convert.ToDateTime(cells2[i, 5].StringValue);
                                tempRow = new HUSBANDRY_DAYS(DealModel.New);
                                tempRow.CANCER_TYPE = cells2[i, 1].StringValue;
                                tempRow.MODEL_ID = cells2[i, 2].StringValue;
                                tempRow.RN = cells2[i, 3].StringValue;
                                tempRow.PN = cells2[i, 4].StringValue;
                                tempRow.DOI = doi;
                                tempRow.CAGE = "";
                                tempRow.NUMBER_IN_CAGE = 0;
                                tempRow.DATE_OF_UPDATE = cells2[i, 0].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells2[i, 0].StringValue);
                                tempRow.HUNBANDRY_DAYS = 0;
                                tempRow.COST_ACCUMULATION = "";
                                tempRow.PROJECT = cells2[i, 7].StringValue;
                                tempRow.ALIVE = "";
                                tempRow.HUNBANDRY_FINISH = cells2[i, 6].StringValue;
                                tempZ.Add(tempRow);
                            }
                        }

                        List<HUSBANDRY_DAYS> tempZData = tempZ.ConvertAll<HUSBANDRY_DAYS>(HUSBANDRY_DAYS.Convert);
                        foreach (HUSBANDRY_DAYS row in mastdata)
                        {
                            if (row.ALIVE != "z")
                            {
                                if (row.CurModel != DealModel.New)
                                {
                                    row.CurModel = DealModel.Modify;
                                }
                                HUSBANDRY_DAYS oldRow = tempZData.Find(delegate(HUSBANDRY_DAYS perm)
                                {
                                    return perm.MODEL_ID == row.MODEL_ID && perm.RN == row.RN &&
                                        perm.PN == row.PN;
                                });
                                DateTime start = row.DOI;//Husbandry Start
                                if (start < DateTime.Parse("2014/01/01"))
                                {
                                    start = DateTime.Parse("2014/01/01");
                                }
                                if (oldRow != null)//找到死的
                                {
                                    if (oldRow.HUNBANDRY_FINISH != "")//Husbandry Finish
                                    {
                                        row.HUNBANDRY_DAYS = (DateTime.Parse(oldRow.HUNBANDRY_FINISH) - start).Days + 1;
                                        row.ALIVE = "z";
                                    }
                                    else
                                    {
                                        if (row.ALIVE != "jiaZ" && row.ALIVE != "Die")
                                        {
                                            row.HUNBANDRY_DAYS = (oldRow.DATE_OF_UPDATE - start).Days + 1;
                                            row.ALIVE = "jiaZ";
                                        }
                                    }
                                }
                                else
                                {
                                    if (row.ALIVE != "jiaZ" && row.ALIVE != "Die")//未找到，假死
                                    {
                                        row.HUNBANDRY_DAYS = (tempRow.DATE_OF_UPDATE - start).Days + 1;
                                        row.ALIVE = "jiaZ";
                                    }
                                }

                            }
                        }
                    }
                }







                #endregion
                

            }
            catch (Exception ex)
            {
                throw ex;

            }
            return dataAll;
        }


        //算饲养成本
        public BaseList getHusbandry_Analysis(HttpContext context, string strFileName, DataTable importData)
        {
            Temp1(strFileName, importData);
            Temp2(context);
            Temp3(context, importData);

            BaseList dataAll = bll.Select(typeof(HUSBANDRY_ANALYSIS));
            List<HUSBANDRY_ANALYSIS> mastdata = dataAll.ConvertAll<HUSBANDRY_ANALYSIS>(HUSBANDRY_ANALYSIS.Convert);
            #region alive
            foreach (HUSBANDRY_ANALYSIS row in mastdata)
            {
                if (row.ALIVE != "Die")
                {
                    if (row.CurModel != DealModel.New)
                    {
                        row.CurModel = DealModel.Modify;
                    }
                    string pn = (int.Parse(row.PN.ToString().TrimStart('P')) + 1).ToString();
                    HUSBANDRY_ANALYSIS newRow = mastdata.Find(delegate(HUSBANDRY_ANALYSIS perm)
                    {
                        return perm.MODEL_ID == row.MODEL_ID && perm.RN == row.RN && perm.PN == pn;
                    });
                    DateTime start = row.DOI;//Husbandry Start
                    if (start < DateTime.Parse("2014/01/01"))
                    {
                        start = DateTime.Parse("2014/01/01");
                    }
                    if (newRow != null)//有迭代
                    {
                        if (row.ALIVE != "z")
                        {
                            if (newRow.DOI > DateTime.Parse("2014/01/01"))
                            {
                                row.HUNBANDRY_DAYS = (newRow.DOI - start).Days + 1;
                            }
                            else
                            {
                                row.HUNBANDRY_DAYS = (newRow.DOI - row.DOI).Days + 1;
                            }
                            row.ALIVE = "Die";
                        }
                    }
                    else
                    {

                    }
                    string localtion = "BJ";
                    if (row.CAGE != "")
                    {
                        localtion = row.CAGE.Split('-')[0];
                    }
                    else
                    {
                        if (row.PROJECT == "TC")
                        {
                            localtion = row.PROJECT;
                        }
                    }
                    int per = localtion == "BJ" ? 11 : 13;
                    row.COST_ACCUMULATION = (11 * row.NUMBER_IN_CAGE * row.HUNBANDRY_DAYS).ToString();
                }
            }


            #endregion

            

            return dataAll;
        }

        public BaseList getHusbandry_Analysis_Zgroup(HttpContext context, string strFileName, DataTable importData)
        {
            BaseList dataAll = bll.Select(typeof(HUSBANDRY_ANALYSIS));
            List<HUSBANDRY_ANALYSIS> mastdata = dataAll.ConvertAll<HUSBANDRY_ANALYSIS>(HUSBANDRY_ANALYSIS.Convert);
            #region dead
            Workbook book = new Workbook(strFileName);
            BaseList tempZ = new BaseList();
            HUSBANDRY_ANALYSIS tempRow = null;
            Worksheet sheet2 = book.Worksheets[0];
            if (sheet2 != null)
            {
                Cells cells2 = sheet2.Cells;
                if (cells2[0, 0].StringValue != "")
                {
                    for (int i = 0; i < cells2.MaxDataRow + 1; i++)
                    {
                        if (cells2[i, 0].StringValue != "Date of update" && cells2[i, 0].StringValue != "")
                        {
                            DateTime doi = cells2[i, 5].StringValue == "" ? DateTime.MinValue : Convert.ToDateTime(cells2[i, 5].StringValue);
                            tempRow = new HUSBANDRY_ANALYSIS(DealModel.New);
                            if (cells2[i, 1].StringValue == "")
                            {
                                tempRow.CANCER_TYPE = cells2[i, 2].StringValue.Substring(0, 2);
                            }
                            else
                            {
                                tempRow.CANCER_TYPE = cells2[i, 1].StringValue;
                            }
                            tempRow.MODEL_ID = cells2[i, 2].StringValue;
                            tempRow.RN = cells2[i, 3].StringValue;
                            tempRow.PN = cells2[i, 4].StringValue;
                            tempRow.DOI = doi;
                            tempRow.CAGE = "";
                            tempRow.NUMBER_IN_CAGE = 0;
                            tempRow.DATE_OF_UPDATE = cells2[i, 0].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells2[i, 0].StringValue);
                            tempRow.HUNBANDRY_DAYS = 0;
                            tempRow.COST_ACCUMULATION = "";
                            tempRow.PROJECT = cells2[i, 7].StringValue;
                            tempRow.ALIVE = "";
                            tempRow.HUNBANDRY_FINISH = cells2[i, 6].StringValue;
                            tempZ.Add(tempRow);
                        }
                    }

                    List<HUSBANDRY_ANALYSIS> tempZData = tempZ.ConvertAll<HUSBANDRY_ANALYSIS>(HUSBANDRY_ANALYSIS.Convert);
                    foreach (HUSBANDRY_ANALYSIS row in mastdata)
                    {
                        if (row.ALIVE != "z")
                        {
                            if (row.CurModel != DealModel.New)
                            {
                                row.CurModel = DealModel.Modify;
                            }
                            HUSBANDRY_ANALYSIS oldRow = tempZData.Find(delegate(HUSBANDRY_ANALYSIS perm)
                            {
                                return perm.MODEL_ID == row.MODEL_ID && perm.RN == row.RN &&
                                    perm.PN == row.PN;
                            });
                            DateTime start = row.DOI;//Husbandry Start
                            if (start < DateTime.Parse("2014/01/01"))
                            {
                                start = DateTime.Parse("2014/01/01");
                            }
                            if (oldRow != null)//找到死的
                            {
                                if (oldRow.HUNBANDRY_FINISH != "")//Husbandry Finish
                                {
                                    row.HUNBANDRY_DAYS = (DateTime.Parse(oldRow.HUNBANDRY_FINISH) - start).Days + 1;
                                    row.ALIVE = "z";
                                    row.HUNBANDRY_FINISH = oldRow.HUNBANDRY_FINISH;
                                }
                                else
                                {
                                    if (row.ALIVE != "jiaZ" && row.ALIVE != "Die")
                                    {
                                        row.HUNBANDRY_DAYS = (oldRow.DATE_OF_UPDATE - start).Days + 1;
                                        row.ALIVE = "jiaZ";
                                    }
                                }
                            }
                            else
                            {
                                if (row.ALIVE != "jiaZ" && row.ALIVE != "Die")//未找到，假死
                                {
                                    row.HUNBANDRY_DAYS = (tempRow.DATE_OF_UPDATE - start).Days + 1;
                                    row.ALIVE = "jiaZ";
                                }
                            }
                            string localtion = "BJ";
                            if (row.CAGE != "")
                            {
                                localtion = row.CAGE.Split('-')[0];
                            }
                            else
                            {
                                if (row.PROJECT == "TC")
                                {
                                    localtion = row.PROJECT;
                                }
                            }
                            int per = localtion == "BJ" ? 11 : 13;
                            row.COST_ACCUMULATION = (11 * row.NUMBER_IN_CAGE * row.HUNBANDRY_DAYS).ToString();
                        }
                    }
                }
            }







            #endregion
            return dataAll;
        }
        //UploadHusbandry_Zgroup
        public void UploadHusbandry_Zgroup(HttpContext context)
        {

            DataTable importData = new DataTable();
            importData.Columns.Add("Cancer_Type");
            importData.Columns.Add("Model_ID");
            importData.Columns.Add("Rn");
            importData.Columns.Add("Pn");
            importData.Columns.Add("DOI", typeof(DateTime));
            importData.Columns.Add("Cage");
            importData.Columns.Add("Number_in_Cage", typeof(Int32));
            importData.Columns.Add("Date_of_Update", typeof(DateTime));
            importData.Columns.Add("Hunbandry_Days");
            importData.Columns.Add("Cost_accumulation");
            importData.Columns.Add("Project");
            importData.Columns.Add("Alive");
            importData.Columns.Add("Hunbandry_Finish");
            importData.Columns.Add("Ongoing_Project");
            importData.Columns.Add("Source_Project");
            BaseList data_AnimalInfo = new BaseList();
            ArrayList HaveModel = new ArrayList();
            ArrayList HaveModel_abbr = new ArrayList();


            string strUploadPath = context.Server.MapPath("../UploadUser/Husbandry") + "\\";
            if (Directory.Exists(strUploadPath))
            {
                Directory.Delete(strUploadPath, true);
            }
            HttpPostedFile postedFile = context.Request.Files["Filedata"];

            string filesname = DateTime.Now.ToString("yyyyMMddhhmmssfff") + postedFile.FileName;
            if (!Directory.Exists(strUploadPath))
            {
                Directory.CreateDirectory(strUploadPath);
            }
            string fileName = strUploadPath + filesname;
            if (fileName != "")
            {
                postedFile.SaveAs(fileName);

                string folderPath = context.Server.MapPath("../UploadUser/Husbandry") + "\\";
                DirectoryInfo fileInfo = new DirectoryInfo(folderPath);
                FileInfo[] sortList = fileInfo.GetFiles();
                FileInfo fi = sortList[0];
                try
                {

                    BaseList dataAll = getHusbandry_Analysis_Zgroup(context, fi.FullName, importData);
                    DataTable Data = UtitityHelper.ToDataTable(dataAll);
                    DataView dv = Data.DefaultView;
                    dv.Sort = "Model_ID,Rn,Pn";
                    Data = dv.ToTable();
                    ojbRuleHuData.delHusbandry();

                    ArrayList columns2 = new ArrayList();
                    foreach (DataColumn dc in importData.Columns)
                    {
                        columns2.Add(dc.ColumnName);
                    }
                    ojbReportRule.InsertBigSql(Data, columns2, "HUSBANDRY_ANALYSIS");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

          
         

            
            context.Response.Write("Analysis successfully!");
        }
        

        // 第一步-插入未过滤数据
        public void Temp1(string strFileName, DataTable importData)
        {
            try
            {              
                Workbook book = new Workbook();
                book.Open(strFileName);
                string MODEL_ID = "";
                string Rn = "";
                string Pn = "";
                string DOI = "";
                string carcinoma = "";
          
                foreach (Worksheet sheet in book.Worksheets)
                {
                    string Ongoing_Project = "";
                    string Source_Project = "";
                    Cells cells = sheet.Cells;
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        try
                        {
                            if (cells[i, 0].StringValue == "AnimalInfo")
                            {
                                continue;
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
                                Rn = models[1].ToString().Substring(0, models[1].ToString().IndexOf("P"));
                                Pn = models[1].ToString().Substring(models[1].ToString().IndexOf("P"), models[1].ToString().Length - models[1].ToString().IndexOf("P"));
                                DOI = models[2].ToString();
                            }
                            else if (cells[i, 0].StringValue == "M#")
                            {
                                carcinoma = cells[i, 3].StringValue;
                            }
                            else if (cells[i, 0].StringValue != "M#" && cells[i, 0].StringValue != "" && cells[i, 0].StringValue != "Animal info")
                            {
                                DataRow newRow = importData.NewRow();
                                newRow["MODEL_ID"] = MODEL_ID;
                                newRow["Rn"] = Rn.Replace("R", "");
                                newRow["Pn"] = Pn.Replace("P", "");
                                newRow["DOI"] = DOI == "" ? DateTime.MinValue : Convert.ToDateTime(DOI.Substring(0, 4) + "-" + DOI.Substring(4, 2) + "-" + DOI.Substring(6, 2));
                                newRow["Cage"] = cells[i, 1].StringValue;
                                newRow["Number_in_Cage"] = 0;
                                newRow["Date_of_Update"] = cells[i, 2].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 2].StringValue);
                                newRow["Hunbandry_Days"] = 0;
                                newRow["Cost_accumulation"] = 0;
                                newRow["Ongoing_Project"] = Ongoing_Project;
                                newRow["Source_Project"] = Source_Project;
                                newRow["Alive"] = "";
                                importData.Rows.Add(newRow);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            ArrayList columns = new ArrayList();
            foreach (DataColumn dc in importData.Columns)
            {
                columns.Add(dc.ColumnName);
            }
            ojbReportRule.InsertBigSql(importData, columns, "HUSBANDRY_TEMP");
        }

        /// 第二步-插入过滤数据
        public void Temp2(HttpContext context)
        {
            DataTable dtAll = ojbRuleHuData.Husbandry2();//Group by 
            ArrayList columns = new ArrayList();
            foreach (DataColumn dc in dtAll.Columns)
            {
                columns.Add(dc.ColumnName);
            }
            ojbRuleHuData.delHusbandry_Temp();
            ojbReportRule.InsertBigSql(dtAll, columns, "HUSBANDRY_TEMP");
        }

        /// 第二步-插入分析表
        public void Temp3(HttpContext context, DataTable importData)
        {
            BaseList newData = new BaseList();
            BaseList Tdata = bll.Select(typeof(HUSBANDRY_TEMP));
            List<HUSBANDRY_ANALYSIS> aData = bll.Select(typeof(HUSBANDRY_ANALYSIS)).ConvertAll<HUSBANDRY_ANALYSIS>(HUSBANDRY_ANALYSIS.Convert);
            foreach (HUSBANDRY_TEMP row in Tdata)
            {
                HUSBANDRY_ANALYSIS oldrow = aData.Find(delegate(HUSBANDRY_ANALYSIS perm)
                {
                    return perm.MODEL_ID == row.MODEL_ID && perm.RN == row.RN && perm.PN == row.PN && perm.DOI == row.DOI;
                });
                if (oldrow != null)
                {
                    if (oldrow.CAGE == "")//和days表对比 （2014-4-11之前的数据）
                    {
                        oldrow.CurModel = DealModel.Modify;
                        oldrow.CAGE = row.CAGE;
                        oldrow.NUMBER_IN_CAGE = row.NUMBER_IN_CAGE;
                        bll.Update(oldrow);
                    }
                }
                else
                {
                    HUSBANDRY_ANALYSIS newRow = new HUSBANDRY_ANALYSIS(DealModel.New);
                    newRow.MODEL_ID = row.MODEL_ID;
                    if (row.MODEL_ID.Length == 6)
                    {
                        newRow.CANCER_TYPE = row.MODEL_ID.Substring(0, 2);
                    }
                    newRow.PROJECT = "";
                    newRow.RN = row.RN;
                    newRow.PN = row.PN;
                    newRow.DOI = row.DOI;
                    newRow.CAGE = row.CAGE;
                    newRow.NUMBER_IN_CAGE = row.NUMBER_IN_CAGE;
                    newRow.DATE_OF_UPDATE = row.DATE_OF_UPDATE;
                    newRow.HUNBANDRY_DAYS = row.HUNBANDRY_DAYS;
                    newRow.COST_ACCUMULATION = row.COST_ACCUMULATION;
                    newRow.ONGOING_PROJECT = row.ONGOING_PROJECT;
                    newRow.SOURCE_PROJECT = row.SOURCE_PROJECT;
                    newData.Add(newRow);
                }
            }
            DataTable dtAll = UtitityHelper.ToDataTable(newData);
            ArrayList columns = new ArrayList();
            foreach (DataColumn dc in importData.Columns)
            {
                columns.Add(dc.ColumnName);
            }
            ojbRuleHuData.delHusbandry_Temp();
            ojbReportRule.InsertBigSql(dtAll, columns, "HUSBANDRY_ANALYSIS");
        }

        /// <summary>
        /// 分析饲养成本
        /// </summary>
        /// <param name="context"></param>
        public void Analysis(HttpContext context)
        {

            DataTable importData = new DataTable();
            importData.Columns.Add("Cancer_Type");
            importData.Columns.Add("Model_ID");
            importData.Columns.Add("Rn");
            importData.Columns.Add("Pn");
            importData.Columns.Add("DOI", typeof(DateTime));
            importData.Columns.Add("Cage");
            importData.Columns.Add("Number_in_Cage", typeof(Int32));
            importData.Columns.Add("Date_of_Update", typeof(DateTime));
            importData.Columns.Add("Hunbandry_Days");
            importData.Columns.Add("Cost_accumulation");
            importData.Columns.Add("Project");
            importData.Columns.Add("Alive");
            importData.Columns.Add("Hunbandry_Finish");
            importData.Columns.Add("Ongoing_Project");
            importData.Columns.Add("Source_Project");
            BaseList data_AnimalInfo = new BaseList();
            ArrayList HaveModel = new ArrayList();
            ArrayList HaveModel_abbr = new ArrayList();

            string folderPath = context.Server.MapPath("../UploadUser/Husbandry") + "\\";
            DirectoryInfo fileInfo = new DirectoryInfo(folderPath);
            FileInfo[] sortList = fileInfo.GetFiles();
            FileInfo fi = sortList[0];

            try
            {

                BaseList dataAll = getHusbandry_Analysis(context, fi.FullName, importData);
                DataTable Data = UtitityHelper.ToDataTable(dataAll);
                DataView dv = Data.DefaultView;
                dv.Sort = "Model_ID,Rn,Pn";
                Data = dv.ToTable();
                ojbRuleHuData.delHusbandry();

                ArrayList columns2 = new ArrayList();
                foreach (DataColumn dc in importData.Columns)
                {
                    columns2.Add(dc.ColumnName);
                }
                ojbReportRule.InsertBigSql(Data, columns2, "HUSBANDRY_ANALYSIS");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            context.Response.Write("Analysis successfully!");
        }

        /// <summary>
        /// 分析饲养天数
        /// </summary>
        /// <param name="context"></param>
        public void Analysis_Days(HttpContext context)
        {

            DataTable importData = new DataTable();
            importData.Columns.Add("Cancer_Type");
            importData.Columns.Add("Model_ID");
            importData.Columns.Add("Rn");
            importData.Columns.Add("Pn");
            importData.Columns.Add("DOI", typeof(DateTime));
            importData.Columns.Add("Cage");
            importData.Columns.Add("Number_in_Cage", typeof(Int32));
            importData.Columns.Add("Date_of_Update", typeof(DateTime));
            importData.Columns.Add("Hunbandry_Days");
            importData.Columns.Add("Cost_accumulation");
            importData.Columns.Add("Project");
            importData.Columns.Add("Alive");
            BaseList data_AnimalInfo = new BaseList();
            ArrayList HaveModel = new ArrayList();
            ArrayList HaveModel_abbr = new ArrayList();

            string folderPath = context.Server.MapPath("../UploadUser/Husbandry") + "\\";
            DirectoryInfo fileInfo = new DirectoryInfo(folderPath);
            FileInfo[] sortList = fileInfo.GetFiles();
            FileInfo fi = sortList[0];

            try
            {
                BaseList dataAll = getHusbandry_Days(fi.FullName, importData);
                DataTable Data = UtitityHelper.ToDataTable(dataAll);
                DataView dv = Data.DefaultView;
                dv.Sort = "Model_ID,Rn,Pn";
                Data = dv.ToTable();
                ojbRuleHuData.delHusbandry_Days();
                ArrayList columns2 = new ArrayList();
                foreach (DataColumn dc in importData.Columns)
                {
                    columns2.Add(dc.ColumnName);
                }
                ojbReportRule.InsertBigSql(Data, columns2, "HUSBANDRY_DAYS");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            context.Response.Write("Analysis successfully!");
        }

        /// <summary>
        /// 导入文件
        /// </summary>
        /// <param name="context"></param>
        public void AddHusbandry(HttpContext context)
        {

            try
            {
                string strUploadPath = context.Server.MapPath("../UploadUser/Husbandry") + "\\";
                if (Directory.Exists(strUploadPath))
                {
                    Directory.Delete(strUploadPath, true);
                }
                HttpPostedFile postedFile = context.Request.Files["Filedata"];

                string filesname = DateTime.Now.ToString("yyyyMMddhhmmssfff") + postedFile.FileName;
                if (!Directory.Exists(strUploadPath))
                {
                    Directory.CreateDirectory(strUploadPath);
                }
                string fileName = strUploadPath + filesname;
                if (fileName != "")
                {
                    postedFile.SaveAs(fileName);
                    //Analysis_Days(context);
                    Analysis(context);
                    context.Response.Write("Upload successfully!");

                }

            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }


        public void AddPDXmodelInfo(HttpContext context)
        {
            try
            {
                //if (context.Request["delete"] == "true")
                //{
                //    BaseList data = bll.Select(typeof(PDXMODEL_INFO));
                //    if (data.Count > 0)
                //    {
                //        foreach (PDXMODEL_INFO del in data)
                //        {
                //            del.CurModel = DealModel.Delete;
                //        }
                //        bll.UpdateAllByParams(data);
                //    }
                //}


                DataTable importData = new DataTable();
                  
                importData.Columns.Add("Sq_Number");
                importData.Columns.Add("Cancer_Type_Abbr");
                importData.Columns.Add("Model_ID");
                importData.Columns.Add("Model_From");
                importData.Columns.Add("Origin");
                importData.Columns.Add("Cancer_Type");
                importData.Columns.Add("Subtype1");
                importData.Columns.Add("Subtype2");
                importData.Columns.Add("Model_Category");
                importData.Columns.Add("Model_Status");
                importData.Columns.Add("Source_ID");
                importData.Columns.Add("Source_Note");
                importData.Columns.Add("PDX_QC");
                importData.Columns.Add("Total_Revival_Success_Rate");
                importData.Columns.Add("Revival_Recommended_Strain");
                importData.Columns.Add("Time_of_Revival");
                importData.Columns.Add("Maintain_Recommended_Strain");
                importData.Columns.Add("STR_Consistence");
                importData.Columns.Add("In_Huba");
                importData.Columns.Add("Time_of_Model_for_Transplant");
                importData.Columns.Add("CV40_Take_rate");
                importData.Columns.Add("CV30_Take_rate");
                importData.Columns.Add("Optimal_Overage");
                importData.Columns.Add("Dosing_Window");
                importData.Columns.Add("Cryo_P", typeof(Int32));
                importData.Columns.Add("Snap_Frozen", typeof(Int32));
                importData.Columns.Add("FFPE", typeof(Int32));
                importData.Columns.Add("HP2");
                importData.Columns.Add("Times_Used_In_Study");
                importData.Columns.Add("Update_Time", typeof(DateTime));
                importData.Columns.Add("Cachexia_Label");
                importData.Columns.Add("Cachexia");
                importData.Columns.Add("Slight_BW_loss");
                importData.Columns.Add("Normal");
                importData.Columns.Add("Ulceration_Label");
                importData.Columns.Add("Survival_Curve");
                importData.Columns.Add("SOC");
                importData.Columns.Add("data_type");
                importData.Columns.Add("Comments");
                importData.Columns.Add("Location");
                importData.Columns.Add("Total_Revival_Success_Rate_CBSD");
                importData.Columns.Add("Time_of_Revival_CBSD");
                importData.Columns.Add("Revival_Recommended_Strain_CBSD");
                importData.Columns.Add("Exomeseq");
                importData.Columns.Add("Treatment_history_1");
                importData.Columns.Add("Treatment_history_2");
                importData.Columns.Add("Source");
                importData.Columns.Add("Implantation_Method");
                importData.Columns.Add("DeathRate");
                BaseList data_AnimalInfo = new BaseList();

                string filePath = updateInfo(context);
                using (CsvReader csv1 =
                  new CsvReader(new StreamReader(filePath), true))
                {
                    //字段数量
                    int fieldCount = csv1.FieldCount;

                    using (CsvReader csv =
                   new CsvReader(new StreamReader(filePath), true))
                    {
                        //标题数组
                        string[] headers = csv.GetFieldHeaders();

                        //只进的游标读取
                        while (csv.ReadNextRecord())
                        {
                            if (csv[0] != "Sq#")
                            {
                                if (csv[0] != "")
                                {
                                    DataRow newRow = importData.NewRow();
                                    newRow[0] = csv[0];
                                    newRow[1] = csv[1];
                                    newRow[2] = csv[2];
                                    newRow[3] = csv[3];
                                    newRow[4] = csv[4];
                                    newRow[5] = csv[5];
                                    newRow[6] = csv[6];
                                    newRow[7] = csv[7];
                                    newRow[8] = csv[8];
                                    newRow[9] = csv[9];
                                    newRow[10] = csv[10];
                                    newRow[11] = csv[11];
                                    newRow[12] = csv[12];
                                    newRow[13] = csv[13];
                                    newRow[14] = csv[14];
                                    newRow[15] = csv[15];
                                    newRow[16] = csv[16];
                                    newRow[17] = csv[17];
                                    newRow[18] = csv[18];
                                    newRow[19] = csv[19];
                                    newRow[20] = csv[20];
                                    newRow[21] = csv[21];
                                    newRow[22] = csv[22];
                                    newRow[23] = csv[23];
                                    newRow[24] = RegHelper.IsNumber0(csv[24].ToString()) == true ? int.Parse(csv[24].ToString()) : 0;
                                    newRow[25] = RegHelper.IsNumber0(csv[25].ToString()) == true ? int.Parse(csv[25].ToString()) : 0;
                                    newRow[26] = RegHelper.IsNumber0(csv[26].ToString()) == true ? int.Parse(csv[26].ToString()) : 0;
                                    newRow[27] = csv[27];
                                    newRow[28] = csv[28];
                                    newRow[29] = csv[29] == "" ? DateTime.Now : DateTime.Parse(csv[29]);
                                    newRow[30] = csv[30];
                                    newRow[31] = csv[31];
                                    newRow[32] = csv[32];
                                    newRow[33] = csv[33];
                                    newRow[34] = csv[34];
                                    newRow[35] = csv[35];
                                    newRow[36] = csv[36];
                                    newRow[37] = csv[37];
                                    newRow[38] = csv[38];
                                    newRow[39] = csv[39];
                                    newRow[40] = csv[40];
                                    newRow[41] = csv[41];
                                    newRow[42] = csv[42];
                                    newRow[43] = csv[43];
                                    newRow[44] = csv[44];
                                    newRow[45] = csv[45];
                                    newRow[46] = csv[46];
                                    newRow[47] = csv[47];
                                    newRow[48] = csv[48];
                                    importData.Rows.Add(newRow);
                                }
                            }
                        }
                    }

                }
                ArrayList columns = new ArrayList();
                foreach (DataColumn dc in importData.Columns)
                {
                    columns.Add(dc.ColumnName);
                }
                ojbReportRule.InsertBigSql(importData, columns, "PDXMODEL_INFO");
                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }




        public void FinishAnimalInfo(HttpContext context)
        {
            try
            {
                string filePath = updateInfo(context);
                Workbook book = new Workbook(filePath);
                foreach (Worksheet sheet in book.Worksheets)
                {
                    try
                    {
                        BaseList animaData = bll.Select(typeof(ANIMAL_INFO));
                        List<ANIMAL_INFO> delData = animaData.ConvertAll<ANIMAL_INFO>(ANIMAL_INFO.Convert);
                        Cells cells = sheet.Cells;
                        for (int i = 0; i < cells.MaxDataRow + 1; i++)
                        {
                            if (cells[i, 0].StringValue != "Date of update")
                            {
                                List<ANIMAL_INFO> data = delData.FindAll(delegate(ANIMAL_INFO perm) { return perm.DOI == DateTime.Parse(cells[i, 5].StringValue) && perm.MODEL_ID == cells[i, 2].StringValue && perm.RN == "R"+ cells[i, 3].StringValue && perm.PN == "P" + cells[i, 4].StringValue; });
                                foreach (ANIMAL_INFO dr in data)
                                {
                                    dr.CurModel = DealModel.Delete;
                                    bll.Delete(dr);
                                }
                              
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                context.Response.Write("Delete successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }

        public void Update_PDXModelInfo_update(HttpContext context)
        {
            try
            {
                string filePath = updateInfo(context);
                BaseList data = bll.Select(typeof(PDXMODEL_INFO));
                Workbook book = new Workbook(filePath);
                Worksheet sheet = book.Worksheets[0];

                List<PDXMODEL_INFO> lists = data.ConvertAll(PDXMODEL_INFO.Convert);
                string _errors = "";
                try
                {

                    Cells cells = sheet.Cells;
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        if (cells[i, 0].StringValue.Trim() == "")
                        {
                            break;
                        }
                        else if (cells[i, 0].StringValue != "Sq#")
                        {
                            PDXMODEL_INFO row = lists.Find(delegate (PDXMODEL_INFO perm) { return perm.SQ_NUMBER == cells[i, 0].StringValue.Trim(); });
                            if (row != null)
                            {
                                row.CurModel = DealModel.Modify;
                                if(cells[i, 1].StringValue.Trim()!="")
                                    row.CANCER_TYPE_ABBR = cells[i, 1].StringValue;
                                if (cells[i, 2].StringValue.Trim() != "")
                                    row.MODEL_ID = cells[i, 2].StringValue;
                                if (cells[i, 3].StringValue.Trim() != "")
                                    row.MODEL_FROM = cells[i, 3].StringValue;
                                if (cells[i, 4].StringValue.Trim() != "")
                                    row.ORIGIN = cells[i, 4].StringValue;
                                if (cells[i, 5].StringValue.Trim() != "")
                                    row.CANCER_TYPE = cells[i, 5].StringValue;
                                if (cells[i, 6].StringValue.Trim() != "")
                                    row.SUBTYPE1 = cells[i, 6].StringValue;
                                if (cells[i, 7].StringValue.Trim() != "")
                                    row.SUBTYPE2 = cells[i, 7].StringValue;
                                if (cells[i, 8].StringValue.Trim() != "")
                                    row.MODEL_CATEGORY = cells[i, 8].StringValue;
                                if (cells[i, 9].StringValue.Trim() != "")
                                    row.MODEL_STATUS = cells[i, 9].StringValue;
                                if (cells[i, 10].StringValue.Trim() != "")
                                    row.SOURCE_ID = cells[i, 10].StringValue;
                                if (cells[i, 11].StringValue.Trim() != "")
                                    row.SOURCE_NOTE = cells[i, 11].StringValue;
                                if (cells[i, 12].StringValue.Trim() != "")
                                    row.PDX_QC = cells[i, 12].StringValue;
                                if (cells[i, 13].StringValue.Trim() != "")
                                    row.TOTAL_REVIVAL_SUCCESS_RATE = cells[i, 13].StringValue;
                                if (cells[i, 14].StringValue.Trim() != "")
                                    row.REVIVAL_RECOMMENDED_STRAIN = cells[i, 14].StringValue;
                                if (cells[i, 15].StringValue.Trim() != "")
                                    row.TIME_OF_REVIVAL = cells[i, 15].StringValue;
                                if (cells[i, 16].StringValue.Trim() != "")
                                    row.MAINTAIN_RECOMMENDED_STRAIN = cells[i, 16].StringValue;
                                if (cells[i, 17].StringValue.Trim() != "")
                                    row.STR_CONSISTENCE = cells[i, 17].StringValue;
                                if (cells[i, 18].StringValue.Trim() != "")
                                    row.IN_HUBA = cells[i, 18].StringValue;
                                if (cells[i, 19].StringValue.Trim() != "")
                                    row.TIME_OF_MODEL_FOR_TRANSPLANT = cells[i, 19].StringValue;
                                if (cells[i, 20].StringValue.Trim() != "")
                                    row.CV40_TAKE_RATE = cells[i, 20].StringValue;
                                if (cells[i, 21].StringValue.Trim() != "")
                                    row.CV30_TAKE_RATE = cells[i, 21].StringValue;
                                if (cells[i, 22].StringValue.Trim() != "")
                                    row.OPTIMAL_OVERAGE = cells[i, 22].StringValue;
                                if (cells[i, 23].StringValue.Trim() != "")
                                    row.DOSING_WINDOW = cells[i, 23].StringValue;
                                if (cells[i, 24].StringValue.Trim() != "")
                                    row.CRYO_P = RegHelper.IsNumber0(cells[i,24].StringValue.ToString()) == true ? int.Parse(cells[i, 24].StringValue.ToString()) : 0;
                                if (cells[i, 25].StringValue.Trim() != "")
                                    row.SNAP_FROZEN = RegHelper.IsNumber0(cells[i, 25].StringValue.ToString()) == true ? int.Parse(cells[i, 25].StringValue.ToString()) : 0;
                                if (cells[i, 26].StringValue.Trim() != "")
                                    row.FFPE = RegHelper.IsNumber0(cells[i, 26].StringValue.ToString()) == true ? int.Parse(cells[i, 26].StringValue.ToString()) : 0;
                                if (cells[i, 27].StringValue.Trim() != "")
                                    row.HP2 = cells[i, 27].StringValue;
                                if (cells[i, 28].StringValue.Trim() != "")
                                    row.TIMES_USED_IN_STUDY = cells[i, 28].StringValue;
                                if (cells[i, 29].StringValue.Trim() != "")
                                    row.UPDATE_TIME = cells[i, 29].StringValue == "" ? DateTime.Now : DateTime.Parse(cells[i, 29].StringValue);
                                if (cells[i, 30].StringValue.Trim() != "")
                                    row.CACHEXIA_LABEL = cells[i, 30].StringValue;
                                if (cells[i, 31].StringValue.Trim() != "")
                                    row.CACHEXIA = cells[i, 31].StringValue;
                                if (cells[i, 32].StringValue.Trim() != "")
                                    row.SLIGHT_BW_LOSS = cells[i, 32].StringValue;
                                if (cells[i, 33].StringValue.Trim() != "")
                                    row.NORMAL = cells[i, 33].StringValue;
                                if (cells[i, 34].StringValue.Trim() != "")
                                    row.ULCERATION_LABEL = cells[i, 34].StringValue;
                                if (cells[i, 35].StringValue.Trim() != "")
                                    row.SURVIVAL_CURVE = cells[i, 35].StringValue;
                                if (cells[i, 36].StringValue.Trim() != "")
                                    row.SOC = cells[i, 36].StringValue;
                                if (cells[i, 37].StringValue.Trim() != "")
                                    row.DATA_TYPE = cells[i, 37].StringValue;
                                if (cells[i, 38].StringValue.Trim() != "")
                                    row.COMMENTS = cells[i, 38].StringValue;
                                if (cells[i, 39].StringValue.Trim() != "")
                                    row.LOCATION = cells[i, 39].StringValue;
                                if (cells[i, 40].StringValue.Trim() != "")
                                    row.TOTAL_REVIVAL_SUCCESS_RATE_CBSD = cells[i, 40].StringValue;
                                if (cells[i, 41].StringValue.Trim() != "")
                                    row.TIME_OF_REVIVAL_CBSD = cells[i, 41].StringValue;
                                if (cells[i, 42].StringValue.Trim() != "")
                                    row.REVIVAL_RECOMMENDED_STRAIN_CBSD = cells[i, 42].StringValue;
                                if (cells[i, 43].StringValue.Trim() != "")
                                    row.EXOMESEQ = cells[i, 43].StringValue;
                                if (cells[i, 44].StringValue.Trim() != "")
                                    row.TREATMENT_HISTORY_1 = cells[i, 44].StringValue;
                                if (cells[i, 45].StringValue.Trim() != "")
                                    row.TREATMENT_HISTORY_2 = cells[i, 45].StringValue;
                                if (cells[i, 46].StringValue.Trim() != "")
                                    row.SOURCE = cells[i, 46].StringValue;
                                if (cells[i, 47].StringValue.Trim() != "")
                                    row.IMPLANTATION_METHOD = cells[i, 47].StringValue;
                                if (cells[i, 48].StringValue.Trim() != "")
                                    row.DEATHRATE = cells[i, 48].StringValue;
                                bll.Update(row);
                            }                                 
                        }                                     
                    }
                }
                catch (Exception ex)
                {
                    string a = _errors + " row error：" + ex.Message.ToString();
                    context.Response.Write(a);
                    return;
                }

                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }

        public void Update_PDXModelInfo_subtype(HttpContext context)
        {
            try
            {
                string filePath = updateInfo(context);
                BaseList data = bll.Select(typeof(PDXMODEL_INFO));
                Workbook book = new Workbook(filePath);
                Worksheet sheet = book.Worksheets[0];

                List<PDXMODEL_INFO> lists = data.ConvertAll(PDXMODEL_INFO.Convert);
                string _errors = "";
                try
                {

                    Cells cells = sheet.Cells;
                    for (int i = 0; i < cells.MaxDataRow + 1; i++)
                    {
                        if (cells[i, 0].StringValue != "Sq#")
                        {
                            PDXMODEL_INFO row = lists.Find(delegate (PDXMODEL_INFO perm) { return perm.MODEL_ID == cells[i, 2].StringValue; });
                            if (row != null)
                            {
                                row.CurModel = DealModel.Modify;
                                //row.SUBTYPE1 = cells[i, 3].StringValue;
                                row.SOURCE_NOTE = cells[i, 11].StringValue;
                                row.PDX_QC = cells[i, 12].StringValue;
                                row.STR_CONSISTENCE = cells[i, 17].StringValue;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string a = _errors + " row error：" + ex.Message.ToString();
                    context.Response.Write(a);
                    return;
                }
                bll.UpdateAllByParams(data);

                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }
        public void UpdateAnimalInfo(HttpContext context)
        {
            try
            {
                string filePath = updateInfo(context);

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
                    try
                    {
                        string Ongoing_Project = "";
                        string Source_Project = "";
                        string MODEL_ID = "";
                        string Rn = "";
                        string Pn = "";
                        string DOI = "";
                        int carcinoma = 13;
                        string project = "";
                        bool z = false;
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
                                            //#region 查询booking Project Number
                                            //ParamCollection pl1 = new ParamCollection();
                                            //pl1.Clause = "MODEL_ID= '" + MODEL_ID + "' and Animal_Number = '" + cells[i, 0].StringValue + "'";
                                            //BaseList _pndata = bll.Select(pl1, typeof(PROJECT_BOOKING));
                                            //string _pn = "";
                                            //if (_pndata.Count > 0)
                                            //{
                                            //    _pn = ((PROJECT_BOOKING)_pndata[0]).PROJECT_NUMBER;
                                            //}
                                            //#endregion


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
                                                    foreach (string nodes in row.DROPDOWNLIST_CONTEXT.Split(';'))
                                                    {
                                                        string[] aa = nodes.Split(',');
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
                                                            new1[10]= newRow.TVLB.ToString();
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
                                                            new1[10]= newRow.CLINICAL_OBSERVATION;
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
                                            foreach (string nodes in row.DROPDOWNLIST_CONTEXT.Split(';'))
                                            {
                                                string[] aa = nodes.Split(',');
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
                                                BaseList monitorData = bll.Select(p3,typeof(PROJECT_MONITOR));

                                                ParamCollection pl2 = new ParamCollection();
                                                pl2.Clause = "USER_NAME = '" + dr.SD + "'";
                                                BaseList user = bll.Select(pl2, typeof(SYS_USER));
                                                if (monitorData.Count>0 && user.Count > 0)
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
                    }
                    catch (Exception ex)
                    {
                        string a = _errors + " row error：" + ex.Message.ToString();
                        context.Response.Write(a);
                        return;
                    }
                    //bll.UpdateAllByParams(data_AnimalInfo);


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
                        string email_body = Note_EmailBody1(data,key);
                        string[] toMails = { key };
                        SendEmail.SendMail_SMTP("html", Subject,email_body, toMails, "Send successfully.");
                    }
                    foreach (string key in email_to2.Keys)
                    {
                        DataTable data = email_to2[key];
                        string Subject = string.Format("HuData Animal TV Warning");
                        string email_body = Note_EmailBody2(data, key);
                        string[] toMails = { key };
                        SendEmail.SendMail_SMTP("html", Subject, email_body, toMails, "Send successfully.");
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

                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }

        public string Note_EmailBody1(DataTable data,string key)
        {
            StringBuilder Body = new StringBuilder(); 
            Body.Append("Hi " + key + ",</br>");
            Body.Append("<span style=\"color: Red\">These animals had body weight/removal of tumor weight< 20! or weight loss rate > 10%!</span></br></br>");
            Body.Append("The Aniaml Info:</br>");
            Body.Append("<table cellpadding='0' cellspacing='0' width=\"1240\" border='1' style=\"word-break:keep-all;word-wrap:break-word\">");
            Body.Append("<tr>");
            foreach (DataColumn col in data.Columns)
            {
                Body.Append("<td>"+col.ColumnName+"</td>");
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


        public void AddAnimalInfo(HttpContext context)
        {
            try
            {
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
                
                BaseList data_AnimalInfo = new BaseList();
                ArrayList HaveModel = new ArrayList();
                ArrayList HaveModel_abbr = new ArrayList();
                string Ongoing_Project = "";
                string Source_Project = "";


                string filePath = updateInfo(context);
                using (CsvReader csv =
                  new CsvReader(new StreamReader(filePath), true))
                {
                    //字段数量
                    int fieldCount = csv.FieldCount;

                   // using (CsvReader csv =
                   //new CsvReader(new StreamReader(filePath), true))
                   // {
                   //     //标题数组
                        string[] headers = csv.GetFieldHeaders();

                        string MODEL_ID = "";
                        string Rn = "";
                        string Pn = "";
                        string DOI = "";
                        string carcinoma = "";
                        string project = "";
                      

                        //只进的游标读取
                        while (csv.ReadNextRecord())
                        {
                            try
                            {
                            if (Ongoing_Project == "")
                            {
                                Ongoing_Project = csv[0];

                            }
                            else if (Source_Project == "")
                            {
                                Source_Project = csv[0];
                            }
                            else if (csv[0].Length > 17)
                            {
                                ArrayList models = new ArrayList();
                                foreach (string model in csv[0].Split('-'))
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
                            else if (csv[0] == "M#")
                            {
                                carcinoma = csv[3];
                            }
                            else if (csv[0] != "M#" && csv[0] != "")
                            {
                                DataRow newRow = importData.NewRow();
                                newRow["MODEL_ID"] = MODEL_ID;
                                newRow["Rn"] = Rn;
                                newRow["Pn"] = Pn;
                                newRow["DOI"] = DOI == "" ? DateTime.MinValue : Convert.ToDateTime(DOI.Substring(0, 4) + "-" + DOI.Substring(4, 2) + "-" + DOI.Substring(6, 2));
                                newRow["Animal_Number"] = csv[0];
                                string[] list1 = csv[1].Split('-');
                                newRow["Location_of_live_animal"] = list1.Length > 1 ? list1[0] : "";
                                newRow["Animal_Room_Number"] = list1.Length > 1 ? list1[1] : "";
                                newRow["IVC_Location"] = list1.Length > 1 ? list1[2] : list1[0];
                                newRow["Date_of_Update"] = csv[2] == "" ? DateTime.MinValue : DateTime.Parse(csv[2]);


                                newRow["Ongoing_Project"] = Ongoing_Project;
                                newRow["Source_Project"] = Source_Project;

                                int begin = 3;
                                if (!carcinoma.Contains("Tumor Volume"))
                                {
                                    begin = begin + 1;//execl有Esophagus carcinoma 24505#这列的情况下
                                }
                                try
                                {
                                    decimal d1 = csv[begin] == "" ? 0 : decimal.Parse(csv[begin]);
                                    decimal d2 = csv[begin + 1] == "" ? 0 : decimal.Parse(csv[begin + 1]);
                                    decimal d3 = csv[begin + 2] == "" ? 0 : decimal.Parse(csv[begin + 2]);
                                    decimal d4 = csv[begin + 3] == "" ? 0 : decimal.Parse(csv[begin + 3]);
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
                                newRow["Body_Weight"] = csv[begin + 7];
                                newRow["Clinical_Observation"] = csv[begin + 8];
                                newRow["Mortality_Observation"] = csv[begin + 9];

                                newRow["Current_Project_Number"] = project;

                                //BaseList pdx = bll.Select(Querypdx(MODEL_ID), typeof(PDXMODEL_INFO));
                                //if (pdx.Count > 0)
                                //{
                                //    PDXMODEL_INFO row = (PDXMODEL_INFO)pdx[0];
                                //    newRow["Model_Fit_for_efficacy"] = row.MODEL_FIT_FOR_EFFICACY;
                                //    newRow["Time_of_Model_for_Transplant"] = row.TIME_OF_MODEL_FOR_TRANSPLANT;
                                //}
                                //else {
                                //    newRow["Model_Fit_for_efficacy"] = "";
                                //}
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


                                //if (newRow["Time_of_Model_for_Transplant"].ToString() == "ND")
                                //{
                                //    newRow["Estimated_DOT"] = "Depending on TV";
                                //}
                                //else
                                //{
                                //    if (newRow["Time_of_Model_for_Transplant"].ToString() != "" && newRow["Time_of_Model_for_Transplant"].ToString() != "??")
                                //    {
                                //        DateTime time = DateTime.Parse(newRow["DOI"].ToString()).AddDays(double.Parse(newRow["Time_of_Model_for_Transplant"].ToString()));
                                //        newRow["Estimated_DOT"] = time.ToShortDateString().ToString();//string.Format("{0:d}",time);
                                //    }
                                //    else {
                                //        newRow["Estimated_DOT"] = "N/A";
                                //    }
                                //}
                                importData.Rows.Add(newRow);

                                
                            }
                        }

                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    
                }
                #region no live animal
                BaseList pdx_nolive = bll.Select(Querypdx_nolive(HaveModel, HaveModel_abbr), typeof(PDXMODEL_INFO));
                foreach (PDXMODEL_INFO row in pdx_nolive)
                {
                    DataRow nolive = importData.NewRow();
                    nolive["MODEL_ID"] = row.MODEL_ID;
                    nolive["Current_Project_Number"] = "No live animals";
                    nolive["Rn"] = "";
                    nolive["Pn"] = "";
                    nolive["Model_Fit_for_efficacy"] = row.MODEL_CATEGORY;
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
                    nolive["Time_of_Model_for_Transplant"] = row.TIME_OF_MODEL_FOR_TRANSPLANT;
                    nolive["Body_Weight"] = "";
                    nolive["Mortality_Observation"] = "";
                    nolive["Ongoing_Project"] = Ongoing_Project;
                    nolive["Source_Project"] = Source_Project;
                    nolive["Clinical_Observation"] = "";
                    importData.Rows.Add(nolive);
                }
                #endregion

                if (context.Request["delete"] == "true")
                {
                    ojbRuleHuData.deleteAnimalInfo();
                }
                ArrayList columns = new ArrayList();
                foreach (DataColumn dc in importData.Columns)
                {
                    columns.Add(dc.ColumnName);
                }
                ojbReportRule.InsertBigSql(importData, columns, "ANIMAL_INFO");
                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }

        public void AddAnimalInfo_Logs(HttpContext context)
        {
            try
            {
                string filePath = updateInfo(context);

                Workbook book = new Workbook(filePath);
                foreach (Worksheet sheet in book.Worksheets)
                {
                    DataTable importData = new DataTable();
                    importData.Columns.Add("MODEL_ID");
                    importData.Columns.Add("DOI", typeof(DateTime));
                    importData.Columns.Add("Rn");
                    importData.Columns.Add("Pn");
                    importData.Columns.Add("Location_of_live_animal");
                    importData.Columns.Add("Animal_Room_Number");
                    importData.Columns.Add("IVC_Location");
                    importData.Columns.Add("Animal_Number");
                    importData.Columns.Add("Body_Weight");
                    importData.Columns.Add("TVLB", typeof(Int32));
                    importData.Columns.Add("TVLF", typeof(Int32));
                    importData.Columns.Add("TVRF", typeof(Int32));
                    importData.Columns.Add("TVRB", typeof(Int32));
                    importData.Columns.Add("TV_AVG", typeof(Int32));
                    importData.Columns.Add("Tumor_Number", typeof(Int32));
                    importData.Columns.Add("Date_of_Update", typeof(DateTime));
                    importData.Columns.Add("Duration", typeof(Int32));
                    importData.Columns.Add("Update_Time");
                    importData.Columns.Add("Update_Person");
                    importData.Columns.Add("Clinical_Observation");
                    importData.Columns.Add("Mortality_Observation");
                    ArrayList HaveModel = new ArrayList();
                    ArrayList HaveModel_abbr = new ArrayList();
                    try
                    {
                        string Ongoing_Project = "";
                        string Source_Project = "";
                        string MODEL_ID = "";
                        string Rn = "";
                        string Pn = "";
                        string DOI = "";
                        int carcinoma = 13;
                        string project = "";
                        bool z = false;
                        Cells cells = sheet.Cells;
                        for (int i = 0; i < cells.MaxDataRow + 1; i++)
                        {
                            if (cells[i, 0].StringValue != "AnimalInfo" && cells[i, 0].StringValue != "Animal info")
                            {
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
                                    #region
                                    ParamCollection paralist = new ParamCollection();
                                    paralist.Clause = "MODEL_ID= '" + MODEL_ID + "' and Animal_Number = '" + cells[i, 0].StringValue + "'";
                                    DateTime last_date =  cells[i, 2].StringValue == "" ? DateTime.MinValue : DateTime.Parse(cells[i, 2].StringValue);
                                    paralist.Clause += " and Date_of_Update = '" + last_date + "'";
                                    BaseList animaData = bll.Select(paralist, typeof(ANIMAL_INFO_LOGS));

                                    if (animaData.Count > 0)
                                    {
                                        ANIMAL_INFO_LOGS row = (ANIMAL_INFO_LOGS)animaData[0];
                                        row.CurModel = DealModel.Modify;
                                        int begin1 = 3;
                                        if (carcinoma == 14)//默认13
                                        {
                                            begin1 = begin1 + 1;
                                        }
                                        else if (carcinoma == 15)
                                        {
                                            begin1 = begin1 + 2;
                                        }
                                        row.MORTALITY_OBSERVATION = cells[i, begin1 + 9].StringValue;
                                        bll.Update(row);
                                    }
                                    else
                                    {
                                        DataRow newRow = importData.NewRow();//新增
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
                                            newRow["TV_AVG"] = 0;
                                            newRow["Tumor_Number"] = 0;
                                        }
                                        newRow["Body_Weight"] = cells[i, begin + 7].StringValue;
                                        newRow["Clinical_Observation"] = cells[i, begin + 8].StringValue;
                                        newRow["Mortality_Observation"] = cells[i, begin + 9].StringValue;

                                        if (RegHelper.IsDateTime(newRow["Date_of_Update"].ToString()) && RegHelper.IsDateTime(newRow["DOI"].ToString()))
                                        {
                                            TimeSpan ts = Convert.ToDateTime(newRow["Date_of_Update"].ToString()) - Convert.ToDateTime(newRow["DOI"].ToString());
                                            newRow["Duration"] = ts.Days;
                                        }

                                        newRow["Update_Time"] = System.DateTime.Now.ToString();

                                        SYS_USER userLogin = CacheHelper.getCurrentUser();
                                        newRow["Update_Person"] = userLogin.USER_CODE;
                                        importData.Rows.Add(newRow);
                                        #endregion
                                    }
                                }

                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }


                    ArrayList columns = new ArrayList();
                    foreach (DataColumn dc in importData.Columns)
                    {
                        columns.Add(dc.ColumnName);
                    }
                    ojbReportRule.InsertBigSql(importData, columns, "ANIMAL_INFO_LOGS");
                }
                context.Response.Write("Import successfully!");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }
    

  

        private ParamCollection queryAI(ArrayList HaveModel_abbr)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            foreach (string id in HaveModel_abbr)
            {
                Clause += " OR MODEL_ID like ('" + id + "%')";
            }
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }
        private ParamCollection Querypdx(string modelID)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = PDXMODEL_INFO.MODEL_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} = '{2}')", PDXMODEL_INFO.TABLE_NAME, column, modelID);

            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }
        private ParamCollection Querypdx_nolive(ArrayList HaveModel, ArrayList HaveModel_abbr)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = PDXMODEL_INFO.MODEL_CATEGORY_FIELD;
            Clause += string.Format("AND ({0}.{1} = 'Fit for efficacy')", PDXMODEL_INFO.TABLE_NAME, column);

            string ids2 = "";
            foreach (string id in HaveModel_abbr)
            {
                ids2 += "'" + id + "',";
            }
            column = PDXMODEL_INFO.CANCER_TYPE_ABBR_FIELD;
            Clause += string.Format("AND ({0}.{1} in ({2}) )", PDXMODEL_INFO.TABLE_NAME, column, ids2.TrimEnd(','));

            string ids = "";
            foreach (string id in HaveModel)
            {
                ids += "'" + id + "',";
            }

            column = PDXMODEL_INFO.MODEL_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} not in ({2}) )", PDXMODEL_INFO.TABLE_NAME, column, ids.TrimEnd(','));

            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

        public string updateInfo2(HttpContext context)
        {
            HttpPostedFile oFile = context.Request.Files["FileUpload2"];//获取上传的文件

            string tablename = context.Request.Form["Tablename"];
            Stream fs = oFile.InputStream;

            byte[] by = new byte[oFile.InputStream.Length];//分块读取

            string folderPath = context.Server.MapPath("~/UploadUser/");
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

        public string updateInfo(HttpContext context)
        {
            HttpPostedFile oFile = context.Request.Files["FileUpload"];//获取上传的文件

            string tablename = context.Request.Form["Tablename"];
            Stream fs = oFile.InputStream;

            byte[] by = new byte[oFile.InputStream.Length];//分块读取

            string folderPath = context.Server.MapPath("~/UploadUser/");
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}