using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crownbio.Utility;
using Crownbio.Common;
using Crownbio.Model;
using System.Data;
using Crownbio.BLL;
using System.IO;
using System.Collections;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mail;

namespace PDXmodelBase.HuData
{
    public partial class huprime : System.Web.UI.Page
    {
        ObjectBLL bll = new ObjectBLL();
        public StringBuilder NodesData = new StringBuilder();
        public string SOCdata = "";
        public string SOCgraphs = "";
        public string aid = "";
        public string Pathology_picture = "";
        public string IsUsers = "";
        public string ChangeUser = "";
        public string divtbAnimalinfo_Logs = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SYS_USER userLogin = CacheHelper.getCurrentUser();

            if (!userLogin.IS_Login)
            {
                Response.Write(" <script language='javascript'>top.location.href='../ErrorMsg.aspx?LoginType=1'</script>");
                return;
            }
            //bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "AnimalTree", "view");
            bool havePerm = ojbReportRule.GetUserFunctions2(userLogin.Permission, "AnimalTree", AppConfig.UserViewRightList);
            if (!havePerm)
            {
                Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                return;
            }
            if (!IsPostBack)
            {

                List<string> treenodes = new List<string>();

                BaseList data = bll.Select(queryFarther(), ANIMAL_TREE.MODEL_ID_FIELD, typeof(ANIMAL_TREE));
                foreach (ANIMAL_TREE row in data)
                {
                    //此处为了简化,并没有查询此级的类别是否有子类.直接设置 'isParent':true

                    string node = string.Format("{{ \"id\":{0}, \"pId\":{1}, \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}",
                     row.AID, row.PID, row.MODEL_ID);
                    treenodes.Add(node);
                }

                string Strtest = string.Join(",", treenodes.ToArray());

                NodesData.Append(Strtest);
            }


        }

        private static ParamCollection queryFarther()
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";
            column = ANIMAL_TREE.P_ID_FIELD;
            Clause += string.Format("AND ({0}.{1} = '0')", ANIMAL_TREE.TABLE_NAME, column);
            if (Clause.Length > 3)
            {
                Clause = Clause.Substring(3, Clause.Length - 3);
            }
            paraList.Clause = Clause;
            return paraList;
        }

        protected void btnShowData_OnClick(object sender, EventArgs e)
        {
           aid = Request["hfAID"].ToString();
           //ShowModelData(aid);

        }

        public void ShowModelData(string aid)
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
                    ANIMAL_INFO_LOGS row2 = (ANIMAL_INFO_LOGS)data2[0];
                    sb.Append("<tr>" + row2.MODEL_ID + "</tr>");
                    sb.Append("<tr>" + row2.RN + "</tr>");
                    sb.Append("<tr>" + row2.PN + "</tr>");
                    sb.Append("<tr>" + row2.LOCATION_OF_LIVE_ANIMAL + "</tr>");
                    sb.Append("<tr>" + row2.ANIMAL_ROOM_NUMBER + "</tr>");
                    sb.Append("<tr>" + row2.IVC_LOCATION + "</tr>");
                    sb.Append("<tr>" + row2.ANIMAL_NUMBER + "</tr>");
                    sb.Append("<tr>" + row2.BODY_WEIGHT + "</tr>");
                    sb.Append("<tr>" + row2.TVLB + "</tr>");
                    sb.Append("<tr>" + row2.TVLF + "</tr>");
                    sb.Append("<tr>" + row2.TVRF + "</tr>");
                    sb.Append("<tr>" + row2.TVRB + "</tr>");
                    sb.Append("<tr>" + row2.TV_AVG + "</tr>");
                    sb.Append("<tr>" + row2.TUMOR_NUMBER + "</tr>");
                    sb.Append("<tr>" + row2.DATE_OF_UPDATE + "</tr>");
                    sb.Append("<tr>" + row2.DURATION + "</tr>");
                }
            }

            divtbAnimalinfo_Logs = sb.ToString();
            //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key11", "alert('Wrong data format.');", true);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
           
            aid = Request["hfAID"].ToString();
            //#region 更新至Model_Tree
            //ArrayList lists = new ArrayList();
            //bool isCheck = true;
            //if (editModelID.Text.Trim() == "" || !RegHelper.IsNumber0(editRn.Text) || !RegHelper.IsNumber0(editPn.Text) || editLocation.Text.Trim() == "")
            //{
            //    isCheck = false;
            //}
            //if (!RegHelper.IsDateTime(editDOI.Text) || !RegHelper.IsDateTime(editDOT.Text))
            //{
            //    isCheck = false;
            //}
            //if (isCheck)
            //{
            //    lists.Add(editModelID.Text);
            //    lists.Add("");
            //    lists.Add(editRn.Text);
            //    lists.Add(editPn.Text);
            //    lists.Add(editDOI.Text);
            //    lists.Add(editDOT.Text);
            //    string location = editLocation.Text;
            //    lists.Add(location);
            //    AddToModelTree(lists);
            //}
            //else {
            //    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key2", "alert('Wrong data format.');", true);
     
            //}
            //#endregion
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


        protected void btnExport1_Click(object sender, EventArgs e)
        {
            if (Session["tbAnimalinfo_Logs"] != null)
            {
                DataTable dt = (DataTable)Session["tbAnimalinfo_Logs"];
                ToExport.TableToExcel2(dt, "Animalinfo_Logs");

            }
        }
    }
}