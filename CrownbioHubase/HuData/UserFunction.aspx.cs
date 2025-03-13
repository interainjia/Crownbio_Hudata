using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crownbio.Common;
using Crownbio.BLL;
using Crownbio.Model;
using System.Data;
using System.Collections;
using System.Web.UI.HtmlControls;
using Crownbio.Utility;

namespace PDXmodelBase.HuData
{
    public partial class UserFunction1 : System.Web.UI.Page
    {
        ObjectBLL bll = new ObjectBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["uid"].ToString() != "")
                {
                    BindDatalist(Request.QueryString["uid"].ToString());
                }
            }
           
        }
        public void BindDatalist(string uid)
        {
            BaseList data = bll.Select(queryUser(Request.QueryString["uid"].ToString()), typeof(SYS_USER));
            SYS_USER row = (SYS_USER)data[0];
           
            BaseList fdata = bll.Select(typeof(HUBASE_FUNCTION));
            //BaseList fdata1 = bll.SelectGroup(new ParamCollection(), HUBASE_FUNCTION.FUNCTION_NAME_FIELD, HUBASE_FUNCTION.FUNCTION_NAME_FIELD,typeof(HUBASE_FUNCTION));
            var fname = fdata.GroupBy(a => ((HUBASE_FUNCTION)a).FUNCTION_NAME).Select(g => g.Key ).ToList();

            dlUserFunction.DataSource = fname;
            dlUserFunction.DataBind();


            ddlRole.SelectedValue = row.DEPARTMENT;
            //System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "$('#open_userFunction').click();", true);
        }

        protected void dlUserFunction_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            BaseList fdata = bll.Select(query(e.Item.DataItem.ToString()), typeof(HUBASE_FUNCTION));
            DataList newlist = e.Item.FindControl("newdatalit") as DataList;
            newlist.DataSource = fdata;
            newlist.DataBind();
     
        }
        protected void newdatalit_ItemDataBound(object sender, DataListItemEventArgs e)
        {
         
            CheckBox cbx = e.Item.FindControl("CheckBox1") as CheckBox;
            HUBASE_FUNCTION row = (HUBASE_FUNCTION)e.Item.DataItem;
            BaseList data = bll.Select(queryUF(row.HUBASE_FUNCTION_ID), typeof(SYS_USER_FUNCTION));
            if (data.Count > 0)
            {
                cbx.Checked = true;
            }
        }
        protected void cbx1_CheckedChanged(object sender, EventArgs e)
        {
            checkbox_bind(cbx1);
        }
        public void checkbox_bind(CheckBox cbx_id)
        {
            foreach (DataListItem items in dlUserFunction.Items)
            {
                DataList dl = items.FindControl("newdatalit") as DataList;
                foreach (DataListItem item in dl.Items)
                {
                    CheckBox CheckBox1 = item.FindControl("CheckBox1") as CheckBox;
                    HiddenField hfFN = item.FindControl("hfFN") as HiddenField;

                    if (hfFN.Value == "PDXModelInfo-show")
                    {
                        if (cbx_id.Checked)
                        {
                            CheckBox1.Checked = true;
                        }
                        else
                        {
                            CheckBox1.Checked = false;
                        }
                    }
                }
            }
        }

        private ParamCollection queryUser(string id)
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

        private ParamCollection query(string name)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";

            column = HUBASE_FUNCTION.FUNCTION_NAME_FIELD;
            Clause += string.Format("({0}.{1} =@{1})", HUBASE_FUNCTION.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, name));

            paraList.Clause = Clause;
            return paraList;
        }

        private ParamCollection queryUF(decimal name)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";

            column = SYS_USER_FUNCTION.FUNCTION_ID_FIELD;
            Clause += string.Format("({0}.{1} =@{1})", SYS_USER_FUNCTION.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Decimal, name));

            column = SYS_USER_FUNCTION.USER_ID_FIELD;
            Clause += string.Format(" AND ({0}.{1} =@{1})", SYS_USER_FUNCTION.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.Single, Request.QueryString["uid"].ToString()));

            paraList.Clause = Clause;
            return paraList;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["uid"].ToString() != "")
            {
                BaseList data = bll.Select(queryUser(Request.QueryString["uid"].ToString()), typeof(SYS_USER));
                SYS_USER user = (SYS_USER)data[0];
                user.CurModel = DealModel.Modify;
                user.DEPARTMENT = ddlRole.SelectedValue;
                bll.UpdateAllByParams(data);
            }
          
            foreach (DataListItem items in dlUserFunction.Items)
            {
                DataList dl = items.FindControl("newdatalit") as DataList;
                foreach (DataListItem item in dl.Items)
                {
                    CheckBox CheckBox1 = item.FindControl("CheckBox1") as CheckBox;
                    HiddenField operate_id = item.FindControl("hffid") as HiddenField;

                    BaseList data = bll.Select(queryUF(decimal.Parse(operate_id.Value)), typeof(SYS_USER_FUNCTION));
                    BaseList deletedata = new BaseList();
                    if (CheckBox1.Checked == true)
                    {
                        if (data.Count == 0)
                        {
                            SYS_USER_FUNCTION row = new SYS_USER_FUNCTION(DealModel.New);
                            row.USER_ID = decimal.Parse(Request.QueryString["uid"].ToString());
                            row.FUNCTION_ID = decimal.Parse(operate_id.Value);
                            decimal id = bll.Update(row);
                            if (row.CurModel == DealModel.New)
                                row.ID = id;
                            row.CurModel = DealModel.None;
                        }
                    }
                    else {
                        if (data.Count == 1)
                        {
                            SYS_USER_FUNCTION row = (SYS_USER_FUNCTION)data[0];
                            row.CurModel = DealModel.Delete;
                            deletedata.Add(row);
                            bll.UpdateAllByParams(deletedata);
                        }
                    }
                }
            }

            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key", "addtime();alert('It is successfully saved.')", true);
        }

    
        public void checkbox_bind(CheckBox cbx_id, string name)
        {
            foreach (DataListItem items in dlUserFunction.Items)
            {
                DataList dl = items.FindControl("newdatalit") as DataList;
                foreach (DataListItem item in dl.Items)
                {
                    CheckBox CheckBox1 = item.FindControl("CheckBox1") as CheckBox;
                    HiddenField fname = item.FindControl("hffname") as HiddenField;

                    if (fname.Value == name)
                    {
                        if (cbx_id.Checked)
                        {
                            CheckBox1.Checked = true;
                        }
                        else
                        {
                            CheckBox1.Checked = false;
                        }
                    }
                }
            }
        }

       

    }
}