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
    public partial class RoleFunction : System.Web.UI.Page
    {
        ObjectBLL bll = new ObjectBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["roleID"].ToString() != "")
                {
                    BindDatalist(Request.QueryString["roleID"].ToString());

                  
                }
            }
           
        }
        public void BindDatalist(string rid)
        {
            if (rid != "-1")
            {
                BaseList data = bll.Select(queryUser(rid), typeof(SYS_ROLE));
                txtROLE_NAME.Text = ((SYS_ROLE)data[0]).ROLE_NAME;


                ParamCollection paraList = new ParamCollection();
                paraList.Clause = "SYS_USER_ROLE.ROLE_NO='" + ((SYS_ROLE)data[0]).ROLE_NO + "'";
                BaseList data1 = bll.Select(paraList, typeof(SYS_USER_ROLE));
                string RoleUser = "";
                foreach (SYS_USER_ROLE row in data1)
                {
                    RoleUser += row.USER_ID + ",";
                }
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key", "setTimeout(function(){$('#cbxUserName').combotree('setValues',[" + RoleUser.TrimEnd(',') + "]);},300)", true);
            }
            //ParamCollection paraList = new ParamCollection();
            //paraList.Clause = string.Format("({0}.{1} = '{2}')", HUBASE_FUNCTION.TABLE_NAME,HUBASE_FUNCTION.FUNCTION_NAME_FIELD, "ModelColumn");
            //BaseList fdata = bll.Select(paraList,typeof(HUBASE_FUNCTION));
            BaseList fdata = bll.Select(typeof(HUBASE_FUNCTION));

            var fname = fdata.GroupBy(a => ((HUBASE_FUNCTION)a).FUNCTION_NAME).Select(g => g.Key).ToList(); ;
            dlUserFunction.DataSource = fname;
            dlUserFunction.DataBind();
            

 
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
            BaseList data = bll.Select(queryUF(row.HUBASE_FUNCTION_ID), typeof(SYS_PERM));
            if (data.Count > 0)
            {
                cbx.Checked = true;
            }
        }
        //protected void cbx1_CheckedChanged(object sender, EventArgs e)
        //{
        //    checkbox_bind(cbx1);
        //}
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

            column = SYS_ROLE.ROLE_ID_FIELD;
            Clause += string.Format("({0}.{1} =@{1})", SYS_ROLE.TABLE_NAME, column);
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

            column = SYS_PERM.FUNCTION_ID_FIELD;
            Clause += string.Format("({0}.{1} =@{1})", SYS_PERM.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, name.ToString()));

            column = SYS_PERM.ROLE_NO_FIELD;
            Clause += string.Format(" AND ({0}.{1} =@{1})", SYS_PERM.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, Request.QueryString["roleNo"].ToString()));

            paraList.Clause = Clause;
            return paraList;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "";
            string reload = "";
            if (txtROLE_NAME.Text.Trim() != "")
            {
                decimal rid = decimal.Parse(Request.QueryString["roleID"].ToString());
                if (!bll.Find(rid, txtROLE_NAME.Text.Trim(), typeof(SYS_ROLE)))
                {
                    BaseList dataRole = bll.Select(typeof(SYS_ROLE));
                    SYS_ROLE row = null;
                    row = (SYS_ROLE)dataRole.Find(rid);
                    if (row == null)
                    {
                        row = new SYS_ROLE(DealModel.New);
                        row.ROLE_NO = bll.GetSysNo("R", 5);
                        row.IS_ADMIN = "N";
                        row.IS_ENABLED = "Y";
                    }
                    if (row.CurModel != DealModel.New)
                    {
                        row.CurModel = DealModel.Modify;
                    }
                    row.ROLE_NAME = txtROLE_NAME.Text.Trim();
                    bll.Update(row);

                    foreach (DataListItem items in dlUserFunction.Items)
                    {
                        DataList dl = items.FindControl("newdatalit") as DataList;
                        foreach (DataListItem item in dl.Items)
                        {
                            CheckBox CheckBox1 = item.FindControl("CheckBox1") as CheckBox;
                            HiddenField operate_id = item.FindControl("hffid") as HiddenField;

                            BaseList data = bll.Select(queryUF(decimal.Parse(operate_id.Value)), typeof(SYS_PERM));
                         
                            if (CheckBox1.Checked == true)
                            {
                                if (data.Count == 0)
                                {
                                    SYS_PERM prow = new SYS_PERM(DealModel.New);
                                    prow.ROLE_NO = row.ROLE_NO;
                                    prow.FUNCTION_ID = operate_id.Value;
                                    decimal id = bll.Update(prow);
                                    if (prow.CurModel == DealModel.New)
                                        prow.ID = id;
                                    prow.CurModel = DealModel.None;
                                }
                            }
                            else
                            {
                                if (data.Count == 1)
                                {
                                    SYS_PERM prow = (SYS_PERM)data[0];
                                    prow.CurModel = DealModel.Delete;
                                    bll.Delete(prow);
                                }
                            }
                        }
                    }

                    #region update user in role
                    if (hfRoleUserName.Value != "" || hfRoleUserName.Value == "")
                    {
                        string[] roleUsers = hfRoleUserName.Value.Split(',');
                        ParamCollection paralist = new ParamCollection();
                        paralist.Clause = "SYS_USER_ROLE.ROLE_NO ='" + row.ROLE_NO + "'";

                        BaseList dataRoleUser = bll.Select(paralist, typeof(SYS_USER_ROLE));
                        foreach (SYS_USER_ROLE old in dataRoleUser)
                        {
                            old.CurModel = DealModel.Delete;
                        }
                        foreach (string id in roleUsers)
                        {
                            if (id != "")
                            {
                                SYS_USER_ROLE newRow = new SYS_USER_ROLE(DealModel.New);
                                newRow.ROLE_NO = row.ROLE_NO;
                                newRow.USER_ID = decimal.Parse(id);
                                dataRoleUser.Add(newRow);
                            }
                        }
                        bll.UpdateAllByParams(dataRoleUser);
                    }
                    #endregion


                    reload = "addtime();";
                    msg = "It is successfully saved.";
                }
                else {
                    msg = "Role Name already exists!";
                }               
            }
            else
            {
                msg = "Role Name can not be empty.";
                
            }
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key", reload + "alert('" + msg + "')", true);
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