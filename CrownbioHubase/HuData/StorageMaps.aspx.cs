using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crownbio.Model;
using Crownbio.BLL;
using Crownbio.Utility;
using Crownbio.Common;
using System.Text;
using System.Collections;
using System.Data;

namespace PDXmodelBase.HuData
{
    public partial class StorageMaps : System.Web.UI.Page
    {
        ObjectBLL bll = new ObjectBLL();
        public StringBuilder NodesData = new StringBuilder();
        public string SOCdata = "";
        public string SOCgraphs = "";
        public string cln = "";
        public string Pathology_picture = "";
        public string IsUsers = "";
        public string ChangeUser = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SYS_USER userLogin = CacheHelper.getCurrentUser();

            if (!userLogin.IS_Login)
            {
                Response.Write(" <script language='javascript'>top.location.href='../ErrorMsg.aspx?LoginType=1'</script>");
                return;
            }
            //bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "StorageMaps", "view");
            bool havePerm = ojbReportRule.GetUserFunctions2(userLogin.Permission, "StorageMaps", AppConfig.UserViewRightList);
            if (!havePerm)
            {
                Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                return;
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["Location_id"] != null)
                {
                    ParamCollection paralist = new ParamCollection();
                    paralist.Clause = LOCATION.AID_FIELD + " like '" + Request.QueryString["Location_id"].ToString() + "%'";
                    BaseList data = bll.Select(paralist, typeof(LOCATION));
                    if (data.Count > 0)
                    {
                        MessageHelper.ResponseClientScript(this, "AutoTree('" + ((LOCATION)data[0]).AID + "');");
                    }
                    else {
                        MessageHelper.ResponseClientScript(this, "AutoTree();");
                    }
                }
                else {
                    MessageHelper.ResponseClientScript(this, "AutoTree();");
                }
                //List<string> treenodes = new List<string>();
                //BaseList data = bll.Select(typeof(LOCATION));
                //foreach (LOCATION row in data)
                //{
                //    if (row.ISPARENT)
                //    {
                //        string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}", row.AID, row.P_ID, row.NAME);
                //        treenodes.Add(node);
                //    }
                //    else
                //    {
                //        string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":false}}", row.AID, row.P_ID, row.NAME);
                //        treenodes.Add(node);
                //    }                
                //}
                //string Strtest = string.Join(",", treenodes.ToArray());
                //NodesData.Append(Strtest);
            }

        }

        private static ParamCollection queryFarther()
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = LOCATION.P_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} = '0')", LOCATION.TABLE_NAME, column);
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

        protected void btnExport1_Click(object sender, EventArgs e)
        {
            if (Request.Form["hfAID"] != null)
            {
                ParamCollection query = new ParamCollection();
                query.Clause = LOCATION.AID_FIELD + " like '" + Request.Form["hfAID"].ToString() + "%'";
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
                query1.Clause = SPECIMEN_STOCK.LOCATION_ID_FIELD + " = '" + Request.Form["hfAID"].ToString() + "'";
                BaseList data = bll.Select(query1, typeof(SPECIMEN_STOCK));
                ArrayList have_wells = new ArrayList();
                foreach (SPECIMEN_STOCK well in data)
                {
                    have_wells.Add(well.WELL_ID);//存在的wells
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Model_ID");
                dt.Columns.Add("Rn");
                dt.Columns.Add("Pn");
                dt.Columns.Add("Date_of_Inoculation");
                dt.Columns.Add("Animal_Number");
                dt.Columns.Add("Total_Tumor_Volume");
                dt.Columns.Add("Date_of_Tissue_Collection");
                dt.Columns.Add("Site_of_Tissue_Collection");
                dt.Columns.Add("Tissue_Type");
                dt.Columns.Add("Preserve_Method");
                dt.Columns.Add("Treatment_To_Mice");
                dt.Columns.Add("Location_ID");
                dt.Columns.Add("Well_ID");
                dt.Columns.Add("Import_Date");
                dt.Columns.Add("Import_Project_Number");
                foreach (string well in wells)
                {
                    if (!have_wells.Contains(well))
                    {
                        DataRow dr = dt.NewRow();
                        dr["Location_ID"] = Request.Form["hfAID"].ToString();
                        dr["Well_ID"] = well;//不存在的wells
                        dt.Rows.Add(dr);
                    }
                }
                ToExport.TableToExcel(dt, "Specimen_Stocks");
            }
        }
    }
}