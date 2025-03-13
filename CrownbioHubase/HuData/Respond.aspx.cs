using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crownbio.BLL;
using Crownbio.Model;
using Crownbio.Common;
using Crownbio.Utility;
using System.Data;

namespace PDXmodelBase.HuData
{
    public partial class Respond : System.Web.UI.Page
    {
        ObjectBLL bll = new ObjectBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SYS_USER userLogin = CacheHelper.getCurrentUser();
                if (!userLogin.IS_Login)
                {
                    Response.Write(" <script language='javascript'>top.location.href='../ErrorMsg.aspx?LoginType=1'</script>");
                    return;
                }
                bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "Respond", "view");
                if (!havePerm)
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                    return;
                }
                if (userLogin.DEPARTMENT == "HP")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key", "$('#txtResponder').val('" + userLogin.USER_NAME + "');", true);
                }
                if (Request.QueryString["model_ids"] != null)
                {
                    if (Request.QueryString["model_ids"].ToString() != "")
                    {
                        string model_ids = Request.QueryString["model_ids"].ToString();
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key1", "bindGridMice();getdgSelectMice('','" + model_ids + "');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "key1", "bindGridMice();", true);
           
                }
               
            }
        }


     
 

        #region btnSend_OnClick
        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            //REQUEST row = new REQUEST(DealModel.New);
            //row.CLIENT = Request.Form["txtClient"];
            //row.DATE_REQUEST = DateTime.Parse(Request["txtDate_Request"]);

            //List<SYS_USER> dataUser = bll.Select(typeof(SYS_USER)).ConvertAll<SYS_USER>(SYS_USER.Convert);
            //string[] bd = Request.Form.GetValues("cc1");

            //string strBD = "";
            //if (bd != null)
            //{
            //    foreach (string id in bd)
            //    {
            //        SYS_USER user = dataUser.Find(delegate(SYS_USER perm) { return perm.USER_ID.ToString() == id; });
            //        if (user != null)
            //        {
            //            strBD += user.FIRST_NAME + " " + user.LAST_NAME + ",";
            //            //SendEmail.SendExchangeEmail("Subject", "Body.ToString()", user.EMAIL, "");
            //        }
            //    }
            //}
            //row.BD = strBD != "" ? strBD.TrimEnd(',') : "";

            //string[] sd = Request.Form.GetValues("cc2");
            //string strSD = "";
            //if (sd != null)
            //{
            //    foreach (string id in sd)
            //    {
            //        SYS_USER user = dataUser.Find(delegate(SYS_USER perm) { return perm.USER_ID.ToString() == id; });
            //        if (user != null)
            //        {
            //            strSD += user.FIRST_NAME + " " + user.LAST_NAME + ",";
            //            //SendEmail.SendExchangeEmail("Subject", "Body.ToString()", user.EMAIL, "");
            //        }
            //    }
            //}
            //row.SD = strSD != "" ? strSD.TrimEnd(',') : "";
            //row.OTHERS_TO_NOTIFY = txtOthers.Text.Trim();
            //row.TUMOR_TYPE = ddlTumor_Type.SelectedIndex == 0 ? "" : ddlTumor_Type.SelectedValue;
            //row.SUBTYPE = ddlSubtype.SelectedIndex == 0 ? "" : ddlSubtype.SelectedValue;
            //row.MODEL_ID = Request.Form["txtModel_ID"].ToString();
            //row.POTENTIAL_STUDY_SIZE = int.Parse(txtPotential_Study_Size.Text.Trim());
            //row.SPECIAL_REQUIREMENTS = txtRequirements.Text.Trim();
            //bll.Update(row);
            //row.CurModel = DealModel.None;

            //string emails = txtOthers.Text.Trim();
            //foreach (string email in emails.Split(','))
            //{
            //    if (RegHelper.IsEmail(email))
            //    {
            //        //SendEmail.SendExchangeEmail("Subject", "Body.ToString()", email, "");
            //    }
            //}
        }
        #endregion

       
      

     

    
    }
}