using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crownbio.BLL;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections;
using System.Data.SqlClient;
using Crownbio.Common;
using Crownbio.Model;
using System.Web.SessionState;
using System.Reflection;
using Crownbio.Utility;
namespace PDXmodelBase.HuData
{
    /// <summary>
    /// UserFunction 的摘要说明
    /// </summary>
    public class UserFunction : IHttpHandler, IRequiresSessionState
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
                //用户添加
                case "PRO_SYS_USER":
                    ReturnPRO_SYS_USER(context, row, page);
                    break;
                case "CheckExport":
                    CheckExport(context);
                    break;
                case "Export":
                    Export(context);
                    break;
                case "EditUser":
                    EditUser(context);
                    break;
                //case "Ins":
                //    AddUser(context, context.Request.Params["USER_ID"], context.Request.Params["USER_CODE"], context.Request.Params["USER_PWD"], context.Request.Params["ROLE_TYPE"], context.Request.Params["PROJECT_CODE"]
                //        , context.Request.Params["PART_MENT"], context.Request.Params["EMAIL"], context.Request.Params["REMARK"]);
                //    break;
                case "DeleteUser":
                    DeleteUser(context);
                    break;
                case "show":
                    string id = context.Request.Params["USER_ID"];
                    ShowUser(context, id);
                    break;
                case "getdgUserRole":
                    getdgUserRole(context, row, page);
                    break;
                case "DeleteRole":
                    DeleteRole(context);
                    break;

                case "getdgDropDownList":
                    getdgDropDownList(context, row, page);
                    break;
                case "SaveDropDownList":
                    SaveDropDownList(context);
                    break;
                    
            }
        }

        public void SaveDropDownList(HttpContext context)
        {
            string msg = "";
            string hfddlID = context.Request["hfddlID"] ?? "";
            string ddlcontext = context.Request["txtContext"] ?? "";
            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (DropDownList_ID = '{0}' )", hfddlID);

            BaseList data = bll.Select(paraList, typeof(DROPDOWNLIST));
            if (data.Count > 0)
            {
                DROPDOWNLIST row = (DROPDOWNLIST)data[0];
                row.CurModel = DealModel.Modify;
                row.DROPDOWNLIST_CONTEXT = FormatHelper.doTran(ddlcontext);
                bll.Update(row);
                msg = "";

                try
                {
                    if (hfddlID == "4")//Cancer Type
                    {
                        ojbRuleHuData.deleteCancerType();
                        BaseList cancerData = new BaseList();
                        foreach (string strs in ddlcontext.Split(';'))
                        {
                            if (strs != "")
                            {
                                string[] str = strs.Split(',');
                                CANCERTYPE_ABBR newRow = new CANCERTYPE_ABBR(DealModel.New);
                                newRow.CANCER_TYPE = str[0].Replace("\n", "");
                                newRow.ABBREVIATION = str[1];
                                cancerData.Add(newRow);
                            }
                        }
                        bll.UpdateAllByParams(cancerData);
                    }
                    else if (hfddlID == "5")//Subtype1
                    {
                        ojbRuleHuData.deleteSubtype1();
                        BaseList cancerData = new BaseList();
                        foreach (string strs in ddlcontext.Split(';'))
                        {
                            if (strs != "" && strs != "\n")
                            {
                                CANCER_SUBTYPE1 newRow = new CANCER_SUBTYPE1(DealModel.New);
                                newRow.SUBTYPE1 = strs.Replace("\n", "");
                                cancerData.Add(newRow);
                            }
                        }
                        bll.UpdateAllByParams(cancerData);
                    }
                    else if (hfddlID == "6")//Subtype2
                    {
                        ojbRuleHuData.deleteSubtype2();
                        BaseList cancerData = new BaseList();
                        foreach (string strs in ddlcontext.Split(';'))
                        {
                            if (strs != "" && strs != "\n")
                            {
                                CANCER_SUBTYPE2 newRow = new CANCER_SUBTYPE2(DealModel.New);
                                newRow.SUBTYPE2 = strs.Replace("\n", "");
                                cancerData.Add(newRow);
                            }
                        }
                        bll.UpdateAllByParams(cancerData);
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                }
            }
            context.Response.Write(msg);
        }

        public void DeleteUser(HttpContext context)
        {
            string msg = "";
            string uid = context.Request["USER_ID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (USER_ID = '{0}' )", uid);

            BaseList data = bll.Select(paraList, typeof(SYS_USER));
            if (data.Count > 0)
            {
                SYS_USER row = (SYS_USER)data[0];
                row.CurModel = DealModel.Delete;
                bll.Delete(row);
                msg = "Delete successfully";
            }
            context.Response.Write(msg);
        }
        public void DeleteRole(HttpContext context)
        {
            string msg = "";
            string uid = context.Request["roleID"] ?? "";

            ParamCollection paraList = new ParamCollection();
            paraList.Clause += string.Format(" (ROLE_ID = '{0}' )", uid);

            BaseList dataRole = bll.Select(paraList, typeof(SYS_ROLE));
            List<BaseObject> deldata = new List<BaseObject>();
            List<SYS_ROLE> dv = dataRole.ConvertAll<SYS_ROLE>(SYS_ROLE.Convert);
            if (dv.Count > 0)
            {
                SYS_ROLE row = (SYS_ROLE)dv[0];
                row.CurModel = DealModel.Delete;
                deldata.Add(row);
            }
            bll.DeleteMasterDetail(dataRole, new Type[] { typeof(SYS_PERM), typeof(SYS_USER_ROLE) }, SYS_ROLE.ROLE_NO_FIELD);
            dataRole.RemoveAll(BaseObject.IsDelete);
            msg = "Delete successfully";
            context.Response.Write(msg);
        }

        /// <summary>
        /// 查看用户信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        public void ShowUser(HttpContext context, string id)
        {
            ParamCollection _paramCollection = new ParamCollection();
            _paramCollection.Clause = String.Format("{0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.USER_ID = {3} ) "
                , new object[] { SYS_ROLE.TABLE_NAME, SYS_ROLE.ROLE_NO_FIELD, SYS_USER_ROLE.TABLE_NAME, id });
            BaseList perdata = bll.Select(_paramCollection,typeof(SYS_ROLE));
            ArrayList rolename = new ArrayList();
            foreach (SYS_ROLE name in perdata)
            {
                rolename.Add(name.ROLE_NAME);
            }

            BaseList data = bll.Select(QueryCollection(id), typeof(SYS_USER));
            DataTable dt = UtitityHelper.ToDataTable(data);
            dt.Columns.Add("ROLE_NAME");
            dt.Rows[0]["ROLE_NAME"] = string.Join(",", rolename.ToArray());
            string dd = MStoJson(dt);
            context.Response.Write(dd);
        }
        public void getdgUserRole(HttpContext context, int pageSize, int CurrentPageIndex)
        {
            BaseList data = bll.Select(typeof(SYS_ROLE));
            DataTable Alldata = UtitityHelper.ToDataTable(data);
            DataTable dt = UtitityHelper.GetPagedTable(Alldata, CurrentPageIndex, pageSize);
            string dd = ConvertDTToJson(dt, data.Count.ToString());
            context.Response.Write(dd);
        }

        
        private ParamCollection QueryCollection(string id)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";

            column = SYS_USER.USER_ID_FIELD;
            Clause += string.Format("({0}.{1} =@{1})", SYS_USER.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, id));

            paraList.Clause = Clause;
            return paraList;
        }



        public void getdgDropDownList(HttpContext context, int pageSize, int CurrentPageIndex)
        {
            BaseList alldata = bll.Select(typeof(DROPDOWNLIST));
            DataTable Alldata = UtitityHelper.ToDataTable(alldata);
            DataTable dt = UtitityHelper.GetPagedTable(Alldata, CurrentPageIndex, pageSize);
            string dd = ConvertDTToJson(dt, alldata.Count.ToString());
            context.Response.Write(dd);
        }
        public void ReturnPRO_SYS_USER(HttpContext context, int pageSize, int CurrentPageIndex)
        {
            string searchUser = context.Request["searchUser"] ?? "";
            //BaseList userdata = bll.SelectByPageIndex(queryUser(searchUser), "USER_ID DESC", CurrentPageIndex, pageSize, typeof(SYS_USER));
            BaseList alldata = bll.Select(queryUser(searchUser), "USER_ID DESC", typeof(SYS_USER));
            foreach (SYS_USER user in alldata)
            {
                ParamCollection _paramCollection = new ParamCollection();
                _paramCollection.Clause = String.Format("{0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.USER_ID = {3} ) "
                    , new object[] { SYS_ROLE.TABLE_NAME, SYS_ROLE.ROLE_NO_FIELD, SYS_USER_ROLE.TABLE_NAME, user.USER_ID });
                BaseList perdata = bll.Select(_paramCollection, typeof(SYS_ROLE));
                ArrayList rolename = new ArrayList();
                foreach (SYS_ROLE name in perdata)
                {
                    rolename.Add(name.ROLE_NAME);
                }
                user.ROLE_TYPE = string.Join(",", rolename.ToArray());
            }
            DataTable Alldata = UtitityHelper.ToDataTable(alldata);
            DataTable dt = UtitityHelper.GetPagedTable(Alldata, CurrentPageIndex, pageSize);
            string dd = ConvertDTToJson(dt, alldata.Count.ToString());
            context.Response.Write(dd);
        }

        public void EditUser(HttpContext context)
        {
            string msg = "";
            string uid = context.Request["User_ID"] ?? "";
            ParamCollection paralist = new ParamCollection();
            paralist.Clause += SYS_USER.USER_ID_FIELD + "='" + uid + "'";
            BaseList data = bll.Select(paralist,  typeof(SYS_USER));
            if (data.Count > 0)
            {
                SYS_USER row = (SYS_USER)data[0];
                row.CurModel = DealModel.Modify;
                row.FIRST_NAME = context.Request["txsFIRST_NAME"] ?? "";
                row.LAST_NAME = context.Request["txsLAST_NAME"] ?? "";
                row.POSITION = context.Request["txsPOSITION"] ?? "";
                row.DEPARTMENT = context.Request["txsDEPARTMENT"] ?? "";
                row.STREET_ADDRESS = context.Request["txsSTREET_ADDRESS"] ?? "";
                row.CITY = context.Request["txsCITY"] ?? "";
                row.COUNTRY = context.Request["txsCOUNTRY"] ?? "";
                row.PHONE = context.Request["txsPHONE"] ?? "";
                row.FAX = context.Request["txsFAX"] ?? "";
                row.EMAIL = context.Request["txsEMAIL"] ?? "";
                row.USER_CODE = context.Request["txsEMAIL"] ?? "";
                row.INSTITUTION = context.Request["txsINSTITUTION"] ?? "";
                bll.Update(row);
                msg = "save successfully";
            }
            context.Response.Write(msg);
        }

        private ParamCollection queryUser(string searchUser)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            if (searchUser != "")
            {
                //column = SYS_USER.FIRST_NAME_FIELD;
                //column1 = SYS_USER.LAST_NAME_FIELD;
                //Clause += string.Format("AND ({0}.{1} like @{1} or {0}.{2} like @{1})", SYS_USER.TABLE_NAME, column, column1);
                column = SYS_USER.EMAIL_FIELD;
                Clause += string.Format("AND ({0}.{1} like @{1})", SYS_USER.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, "%" + searchUser + "%"));
            }
           
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
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
        public void Export(HttpContext context)
        {
            if (context.Session["dgModelInfo"] != null)
            {
                DataTable dt = (DataTable)context.Session["dgModelInfo"];
                ToExport.TableToExcel(dt, "PDXmodelInfo");
            }
        }
        public void CheckExport(HttpContext context)
        {
            string fname = "";
            if (context.Request["fname"] != null)
            {
                fname = context.Request["fname"].ToString();             
            }
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, fname, "export");
            if (havePerm)
            {
                context.Response.Write("1");
            }
            else {
                context.Response.Write("0");
            }
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