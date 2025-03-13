using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Collections;
using System.Data;
using Crownbio.BLL;
using System.Text;
using Crownbio.Common;
using Crownbio.Model;
using Crownbio.Utility;
using System.Web.SessionState;
namespace PDXmodelBase.HuData
{
    /// <summary>
    /// GetGenedata 的摘要说明
    /// </summary>
    public class GetGenedata : IHttpHandler, IRequiresSessionState
    {
        ObjectBLL bll = new ObjectBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Method = context.Request.Params["M"];
            int page = 1;
            int row = 10;
            if (context.Request["rows"] != null)
            {
                row = int.Parse(context.Request["rows"].ToString());
                page = int.Parse(context.Request["page"].ToString());
            }
            switch (Method)
            {
                case "AutoModelID":
                    ReturnAutocomplete3(context); //search model_id by cancer type
                    break;
                case "AutoModel_ID": //only search model_id
                    ReturnAutocomplete2(context, "AutoModel_ID");
                    break;
                    
                case "AutoProject":
                    ReturnAutocomplete2(context, "AutoProjectNumber");
                    break;
                case "ddlSubproject":
                    ReturnAutocomplete4(context);
                    break;
                case "txtPiggybacked":
                    AutoPiggybacked(context);
                    break;

                case "AutoSponsor":
                    ReturnAutocomplete2(context, "AutoSponsor");
                    break;


                #region monitor
                case "cbxToProject":
                    cbxToProject(context);
                    break;
                case "cbxToModelID":
                    cbxToModelID(context);
                    break;
                #endregion
               
                case "searchgene_only":
                    ReturnAutocomplete2(context, "GetGeneName_Custom_All");
                    break;
                case "Search_ModelIDMulti":
                    Search_ModelIDMulti(context, row, page);
                    break;
                case "AnimalTree":
                    AnimalTree(context);
                    break;
                case "bingCancerType":
                    bingCancerType(context);
                    break;


                #region Tissue bank
                case "Locations":
                    Locations(context);
                    break;
                case "LocationID_Select":
                    LocationID_Select(context);
                    break;
                case "Locations_getWellID":
                    Locations_getWellID(context);
                    break;

                #endregion

                

            }
        }

        public void bingCancerType(HttpContext context)
        {
            string resultStr = string.Empty;
            string pcode = "";
            if (!string.IsNullOrEmpty(context.Server.UrlDecode(context.Request.QueryString["pid"])))
            {
                pcode = context.Server.UrlDecode(context.Request.QueryString["pid"]).ToString();
            }
            if (pcode == "0")
            {
                DataTable typedata = ojbRuleHuData.GetCancerTypeTree();
                resultStr = "";
                resultStr += "[";
                foreach (DataRowView item in typedata.DefaultView)
                {
                    DataTable dt = new DataTable();
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\", \"state\": \"closed\"", item["abbr"].ToString(), item["Cancer_Type"].ToString());
                    resultStr += "},";
                }
                if (typedata.DefaultView.Count > 0)
                {
                    resultStr = resultStr.Substring(0, resultStr.Length - 1);
                }
                resultStr += "]";
            }
            else {
                DataTable dt = new DataTable();
                dt = ojbRuleHuData.GetCancerTypeTree_ModelID(pcode);
                resultStr = "";
                resultStr += "[";
                foreach (DataRowView item in dt.DefaultView)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", item["Model_ID"].ToString(), item["Model_ID"]);
                    resultStr += "},";
                }
                if (dt.DefaultView.Count > 0)
                {
                    resultStr = resultStr.Substring(0, resultStr.Length - 1);
                }
                resultStr += "]";
            }
            context.Response.Write(resultStr);
        }

        public void Search_ModelIDMulti(HttpContext context, int pageSize, int CurrentPageIndex)
        {
            if (context.Request["key"] != null)
            {
                string key = context.Request["key"].ToString();
                string cancertype = context.Request["cancertype"].ToString();
                string[] subtype = { };
                string[] subtype2 = { };
                if (context.Request["subtype"] != null)
                {
                    subtype = context.Request["subtype"].Split(',');
                }
                if (context.Request["subtype2"] != null)
                {
                    subtype2 = context.Request["subtype2"].Split(',');
                }
                BaseList datamodelid = new BaseList();

                datamodelid = bll.Select(queryMid(context, key, cancertype, subtype,subtype2), typeof(PDXMODEL_INFO));

                DataTable dtAll = UtitityHelper.ToDataTable(datamodelid);

                DataTable dt = UtitityHelper.GetPagedTable(dtAll, CurrentPageIndex, pageSize);
                string dd = ConvertDTToJson(dt, dtAll.Rows.Count.ToString());
                context.Response.Write(dd);

            }
            else
            {
                context.Response.Write("{ \"total\":0,\"rows\":[ ]}");
            }
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
        //autocomplete

        public void AutoPiggybacked(HttpContext context)
        {
            string key = context.Request["key"].ToString();
            ParamCollection paralist = new ParamCollection();
            if (key != "")
            {
                paralist.Clause += PIGGYBACKED.PIGGYBACKED_BY_FIELD + " like '" + key + "%'";
            }

            BaseList data = bll.Select(paralist, typeof(PIGGYBACKED));
            DataTable dt = UtitityHelper.ToDataTable(data);
            string dd = MStoJson(dt);
            context.Response.Write(dd);
        }

        public void ReturnAutocomplete4(HttpContext context)
        {
            string key = context.Request["key"].ToString();
            string ParentProject = context.Request["ParentProject"] ?? "";
            string requestID = context.Request["requestID"] ?? "";
            ParamCollection paralist = new ParamCollection();
            paralist.Clause = REQUEST.PARENT_PROJECT_FIELD + " = '" + ParentProject + "' and " + REQUEST.REQUEST_ID_FIELD + " <> '" + requestID + "'";
            if (key != "")
            {
                paralist.Clause += " and " + REQUEST.PROJECT_NUMBER_FIELD + " like '" + key + "%'";
            }
            if (ParentProject != "")
            {
                BaseList data = bll.Select(paralist, typeof(REQUEST));
                DataTable dt = UtitityHelper.ToDataTable(data);
                string dd = MStoJson(dt);
                context.Response.Write(dd);
            }
            else
            {
                context.Response.Write("");
            }
            
        }


        public void cbxToProject(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";

            BaseList data = bll.SelectGroup(new ParamCollection(), PROJECT_MONITOR.PROJECT_NUMBER_FIELD,PROJECT_MONITOR.PROJECT_NUMBER_FIELD, typeof(PROJECT_MONITOR));
            if (data.Count > 0)
            {
                foreach (PROJECT_MONITOR node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.PROJECT_NUMBER, node.PROJECT_NUMBER);
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

        public void cbxToModelID(HttpContext context)
        {

            string Project = context.Request["Project"] ?? "";
            string resultStr = "";
            resultStr += "[";
           
            resultStr += "{";
            resultStr += string.Format("\"id\": \"\", \"text\": \"{0}\", \"state\": \"open\"", "Select All");
            ParamCollection paralist = new ParamCollection();
            paralist.Clause = PROJECT_MONITOR.PROJECT_NUMBER_FIELD + "='" + Project + "'";
            BaseList data = bll.Select(paralist,  PROJECT_MONITOR.MODEL_ID_FIELD, typeof(PROJECT_MONITOR));


            if (data.Count > 0)
            {
                resultStr += ",\"children\":";
                resultStr += "[";
                foreach (PROJECT_MONITOR node in data)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node.MODEL_ID, node.MODEL_ID);
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
        
        public void ReturnAutocomplete3(HttpContext context)
        {
            string key = context.Request["key"].ToString();
            string cancertype = context.Request["cancertype"].ToString();
            string[] subtype = { };
            string[] subtype2 = { };
            if (context.Request["subtype"] != null)
            {
                subtype = context.Request["subtype"].Split(',');
            }
            if (context.Request["subtype2"] != null)
            {
                subtype2 = context.Request["subtype2"].Split(',');
            }
            BaseList datamodelid = new BaseList();

            datamodelid = bll.Select(queryMid(context, key, cancertype, subtype, subtype2), typeof(PDXMODEL_INFO));
           
            DataTable dt = new DataTable();
            dt.Columns.Add("MODEL_ID");
            foreach(PDXMODEL_INFO dr in datamodelid)
            {
                dt.Rows.Add(dr.MODEL_ID);
            }
            string dd = MStoJson(dt);
            context.Response.Write(dd);
        }
        private ParamCollection queryMid(HttpContext context, string key, string cancertype, string[] subtype, string[] subtype2)
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
            if (key != "")
            {
                column = PDXMODEL_INFO.MODEL_ID_FIELD;
                Clause += string.Format("AND ({0}.{1} like '{2}')", PDXMODEL_INFO.TABLE_NAME, column, "%" + key + "%");
            }
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

       

        public void ReturnAutocomplete2(HttpContext context, string proName)
        {
            string key = context.Request["key"].ToString();
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@name", key) };
            DataTable dt = ojbReportRule.GetGrid(proName, para);
            string dd = MStoJson(dt);
            context.Response.Write(dd);

        }
        public void ReturnAutocomplete(HttpContext context, string proName)
        {
            SqlParameter[] para = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid(proName, para);
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
            try
            {
                return jss.Serialize(dic);
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public void LocationID_Select(HttpContext context)
        {
            StringBuilder NodesData = new StringBuilder();
            SqlParameter[] para = new SqlParameter[] { };
            //DataTable dt = ojbReportRule.GetGrid("GetModelID", para);
            string aid = context.Request["id"] ?? "";
            string pId = context.Request["pId"] ?? "";

            List<string> treenodes = new List<string>();
            BaseList data = new BaseList();
            if (aid == "")
            {
                ParamCollection paraList = new ParamCollection();
                paraList.Clause += " Name ='CrownBio'";
                data = bll.Select(paraList, "Name", typeof(LOCATION));
            }
            else
            {
                data = bll.Select(queryChild2(aid), "Name", typeof(LOCATION));
            }
            List<LOCATION> sortData = data.ConvertAll<LOCATION>(LOCATION.Convert);
            for (int i = 0; i < sortData.Count; i++)
            {

                //全部冰箱
                double allbox = sortData[i].BOX_NUMBER;

                //占用的冰箱
                double havebox = sortData[i].USED_SPACE;

                //未用冰箱个数
                string empty = (allbox - havebox).ToString();

                if (allbox - havebox > 0)
                {
                    //已占百分比
                    double p = 0;
                    if (allbox != 0)
                    {
                        p = Math.Round(havebox / allbox * 100, 0, MidpointRounding.AwayFromZero);
                    }


                    //显示信息
                    string showName = "(" + p.ToString() + "%," + empty + ")";


                    if (sortData[i].ISPARENT)
                    {
                        string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}",
                                sortData[i].AID, sortData[i].P_ID, sortData[i].NAME + showName);
                        treenodes.Add(node);
                    }
                    else
                    {
                        string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":false}}",
                           sortData[i].AID, sortData[i].P_ID, sortData[i].NAME + showName);
                        treenodes.Add(node);
                    }
                }
            }
            string Strtest = string.Join(",", treenodes.ToArray());

            NodesData.Append(Strtest);
            context.Response.Write("[" + NodesData + "]");


        }


        public void Locations_getWellID(HttpContext context)
        {
            string resultStr = "";
            resultStr += "[";
            string id = context.Request["id"] ?? "";

            ParamCollection query = new ParamCollection();
            query.Clause = LOCATION.AID_FIELD + " = '" + id + "'";
            BaseList Ldata = bll.Select(query, typeof(LOCATION));
            ArrayList wells = new ArrayList();
            if (Ldata.Count > 0)
            {
                int rows = ((LOCATION)Ldata[0]).MAPS_ROWS != "" ? int.Parse(((LOCATION)Ldata[0]).MAPS_ROWS) : 0;
                int columns = ((LOCATION)Ldata[0]).MAPS_COLUMNS != "" ? int.Parse(((LOCATION)Ldata[0]).MAPS_COLUMNS) : 0;
                string[] arr = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                for (int i = 0; i < rows; i++)
                {

                    for (int j = 1; j < columns + 1; j++)
                    {
                        wells.Add(arr[i] + j.ToString());//全部wells
                    }
                }
            }


            ParamCollection query1 = new ParamCollection();
            query1.Clause = SPECIMEN_STOCK.LOCATION_ID_FIELD + " = '" + id.Split(';')[0] + "'";
            BaseList data = bll.Select(query1, typeof(SPECIMEN_STOCK));
            ArrayList have_wells = new ArrayList();
            foreach (SPECIMEN_STOCK well in data)
            {
                have_wells.Add(well.WELL_ID);//存在的wells
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("Location_ID");
            dt.Columns.Add("Well_ID");
            foreach (string well in wells)
            {
                if (!have_wells.Contains(well))
                {
                    DataRow dr = dt.NewRow();
                    dr["Location_ID"] = id.Split(';')[0];
                    dr["Well_ID"] = well;//不存在的wells
                    dt.Rows.Add(dr);
                }
            }

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow node in dt.Rows)
                {
                    resultStr += "{";
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\"", node["Location_ID"].ToString(), node["Well_ID"].ToString());
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
        public void Locations(HttpContext context)
        {
            StringBuilder NodesData = new StringBuilder();
            SqlParameter[] para = new SqlParameter[] { };
            //DataTable dt = ojbReportRule.GetGrid("GetModelID", para);
            string aid = context.Request["id"] ?? "";
            string pId = context.Request["pId"] ?? "";

            List<string> treenodes = new List<string>();
            BaseList data = new BaseList();
            if (aid == "")
            {
                ParamCollection paraList = new ParamCollection();
                paraList.Clause += " Name ='CrownBio'";
                data = bll.Select(paraList, "Name", typeof(LOCATION));
            }
            else
            {
                data = bll.Select(queryChild2(aid), "Name", typeof(LOCATION));
            }
            List<LOCATION> sortData = data.ConvertAll<LOCATION>(LOCATION.Convert);
            for (int i = 0; i < sortData.Count; i++)
            {

                //全部冰箱
                double allbox = sortData[i].BOX_NUMBER;

                //占用的冰箱
                double havebox = sortData[i].USED_SPACE;

                //已占百分比
                double p = 0;
                if (allbox != 0)
                {
                    p = Math.Round(havebox / allbox * 100, 0, MidpointRounding.AwayFromZero);
                }
                //未用冰箱个数
                string empty = (allbox - havebox).ToString();

                //显示信息
                string showName = "(" + p.ToString() + "%," + empty + ")";


                if (sortData[i].ISPARENT)
                {
                    string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}",
                            sortData[i].AID, sortData[i].P_ID, sortData[i].NAME + showName);
                    treenodes.Add(node);
                }
                else
                {
                    string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":false}}",
                       sortData[i].AID, sortData[i].P_ID, sortData[i].NAME + showName);
                    treenodes.Add(node);
                }
            }
            string Strtest = string.Join(",", treenodes.ToArray());

            NodesData.Append(Strtest);
            context.Response.Write("[" + NodesData + "]");


        }

        public void AnimalTree(HttpContext context)
        {
            StringBuilder NodesData = new StringBuilder();
            SqlParameter[] para = new SqlParameter[] { };
            //DataTable dt = ojbReportRule.GetGrid("GetModelID", para);
            string aid = context.Request["id"].ToString();
            string pId = context.Request["pId"].ToString();
            //string name = context.Request["name"].ToString();
            
            string Search = context.Request["Search"] ?? "";
            string model_id = context.Request["ModelID"] ?? "";
            string Rn = context.Request["Rn"] ?? "";
            string Pn = context.Request["Pn"] ?? "";
            
            if (Search == "true")
            {
             
                List<string> treenodes = new List<string>();
                BaseList data = bll.Select(querySearchChild(model_id, Rn, Pn), "MODEL_ID", typeof(ANIMAL_TREE));
                List<ANIMAL_TREE> sortData = data.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert);
                sortData = sortData.OrderBy(s => s.RN.Length).ThenBy(s => s.RN).ToList();
                sortData = sortData.OrderBy(s => s.PN.Length).ThenBy(s => s.PN).ToList();

                if (sortData.Count > 0)
                {

                    for (int i = 0; i < sortData.Count; i++)
                    {
                        //此处为了简化,并没有查询此级的类别是否有子类.直接设置 'isParent':true
                        if (sortData[i].P_ID.ToString() == "0")
                        {
                            string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}",
                            sortData[i].AID, sortData[i].P_ID, sortData[i].MODEL_ID);
                            treenodes.Add(node);
                        }
                        else if (sortData[i].DOI != "" && sortData[i].LOCATION == "")
                        {
                            string _dot = "";
                            if (sortData[i].DOT != "")
                            {
                                _dot = "-" + sortData[i].DOT;
                            }
                            string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}",
                           sortData[i].AID, sortData[i].P_ID, sortData[i].DOI + _dot);
                            treenodes.Add(node);
                        }
                        else if (sortData[i].DOI != "" && sortData[i].LOCATION != "")
                        {
                            string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":false}}",
                            sortData[i].AID, sortData[i].P_ID, sortData[i].LOCATION);
                            treenodes.Add(node);
                        }
                        else
                        {
                            string pn = sortData[i].PN;
                            if (pn != "")
                            {
                                pn = "P" + pn;
                            }
                            string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}",
                              sortData[i].AID, sortData[i].P_ID, "R" + sortData[i].RN + pn);
                            treenodes.Add(node);
                        }
                    }
                    string Strtest = string.Join(",", treenodes.ToArray());
                    NodesData.Append(Strtest);
                    context.Response.Write("[" + NodesData + "]");
                }
                else
                {
                    context.Response.Write("[]");
                }
            }
            else
            {
                List<string> treenodes = new List<string>();
                BaseList data = new BaseList();
                data = bll.Select(queryChild(aid),"MODEL_ID", typeof(ANIMAL_TREE));
                List<ANIMAL_TREE> sortData = data.ConvertAll<ANIMAL_TREE>(ANIMAL_TREE.Convert);
                sortData = sortData.OrderBy(s => s.RN.Length).ThenBy(s => s.RN).ToList();
                sortData = sortData.OrderBy(s => s.PN.Length).ThenBy(s => s.PN).ToList(); 
                //DataTable dt = UtitityHelper.ToDataTable(data);


                for (int i = 0; i < sortData.Count; i++)
                {
                    //此处为了简化,并没有查询此级的类别是否有子类.直接设置 'isParent':true
                    string _dot = "";
                    if (sortData[i].DOT != "")
                    {
                        _dot = "-" + sortData[i].DOT;
                    }
                    if (sortData[i].DOI.ToString() != "" && sortData[i].LOCATION == "")
                    {
                        string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}",
                        sortData[i].AID, sortData[i].P_ID, sortData[i].DOI + _dot);
                        treenodes.Add(node);
                    }
                    else if (sortData[i].DOI != "" && sortData[i].LOCATION != "")
                    {
                        string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":false}}",
                         sortData[i].AID, sortData[i].P_ID, sortData[i].LOCATION);
                        treenodes.Add(node);
                    }
                    else
                    {
                        string pn = sortData[i].PN;
                        if (pn != "")
                        {
                            pn = "P" + pn;
                        }
                        string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}",
                        sortData[i].AID, sortData[i].P_ID, "R" + sortData[i].RN + pn);
                        treenodes.Add(node);
                    }
                }
                string Strtest = string.Join(",", treenodes.ToArray());

                NodesData.Append(Strtest);
                context.Response.Write("[" + NodesData + "]");
            }
           
        }

        public List<string> getAnimalChilds(ANIMAL_TREE row, List<ANIMAL_TREE> tempdata, List<string> childNode)
        {
           
            ANIMAL_TREE row1 = tempdata.Find(delegate(ANIMAL_TREE perm) { return perm.AID == row.P_ID; });
            if (row1 != null)
            {
                string name = "";
                if (row1.P_ID == "0")
                {
                    name = row1.MODEL_ID;
                    childNode.Add(string.Format("{{ \"id\":{0}, \"pId\":{1}, \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}",
                        row1.AID, row1.P_ID, name));
                }
                else {
                    if (row1.DOI != "" && row1.LOCATION == "")
                    {
                        string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}",
                       row1.AID, row1.P_ID, row1.DOI);
                        childNode.Add(node);
                    }
                    else if (row1.DOI != "" && row1.LOCATION != "")
                    {
                        string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}",
                        row1.AID, row1.P_ID, row1.LOCATION);
                        childNode.Add(node);
                    }
                    else
                    {
                        string pn = row1.PN;
                        string isParent = "true";
                        if (pn != "")
                        {
                            isParent = "false";
                            pn = "P" + pn;
                        }
                        string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":" + isParent + "}}",
                        row1.AID, row1.P_ID, "R" + row1.RN + pn);
                        childNode.Add(node);
                    }
                }
               
                childNode =getAnimalChilds(row1, tempdata, childNode);
            }
            return childNode;
        }

        private static ParamCollection queryModels(string model_id)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = ANIMAL_TREE.MODEL_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} = '{2}')", ANIMAL_TREE.TABLE_NAME, column, model_id);

            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

        private static ParamCollection querySearchChild(string model_id, string Rn, string Pn)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            if (model_id != "")
            {
                Clause += " (Model_ID LIKE '%" + model_id + "%' and Rn='' and P_ID ='0')";

                Clause += " or (Model_ID LIKE '%" + model_id + "%' ";
                if (Rn != "")
                {
                    Clause += " and Rn='" + Rn + "' ";
                    if (Pn != "")
                    {
                        Clause += " and (Pn ='" + Pn + "' or Pn=''))";
                    }
                    else {
                        Clause += ")";
                    }
                }
                else
                {
                    Clause += ")";
                }
            }
            paraList.Clause = Clause;
            return paraList;
        }
        private static ParamCollection queryChild(string aid)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";

            column = ANIMAL_TREE.P_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} = '{2}')", ANIMAL_TREE.TABLE_NAME, column, aid);
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

        private static ParamCollection queryChild2(string aid)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";

            column = LOCATION.P_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} = '{2}')", LOCATION.TABLE_NAME, column, aid);
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }
        //json处理
        #region
        /// <summary>
        /// 表格数据生成指定格式的json数据
        /// </summary>
        /// <param name="dt">生成json数据的报表</param>
        /// <returns></returns>
        //public static string DtToJson(DataTable dt)
        //{
        //    string result = string.Empty;

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        ObjectBLL bll = new ObjectBLL();
        //        BaseList data = bll.Select(queryANIMAL(dr["MODEL_ID"].ToString().Trim()), typeof(ANIMAL_TREE));
        //        if (data.Count > 0)
        //        {
        //            DataTable dtanimal = UtitityHelper.ToDataTable(data);
        //            foreach (DataRow drr in dtanimal.Select("PID=0"))
        //            {
        //                result += "," + AppendJson(drr, dtanimal);
        //            }
        //        }

        //    }
        //    if (result.Length > 0)
        //        result = "[\r\n" + result.Substring(1) + "\r\n]";
        //    return result;
        //}
        /// <summary>
        /// 生成指定的Json数据
        /// </summary>
        /// <param name="dr">报表行对象</param>
        /// <param name="dtAll">报表对象</param>
        /// <returns></returns>
        private static string AppendJson(DataTable dt)
        {
            string parentNode = "[";
            foreach (DataRow dr in dt.Rows)
            {
                parentNode += "{id:'" + dr["Aid"].ToString() + "',name:'" + dr["Rn"].ToString() + dr["Pn"].ToString() + "',isParent: true},";

            }
            if (parentNode != "")
            {
                parentNode =parentNode.TrimEnd(',');
            }
            parentNode += "]";
            return parentNode;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


       
    }
}