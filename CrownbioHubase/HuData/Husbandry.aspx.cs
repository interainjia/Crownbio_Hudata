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
    public partial class Husbandry : System.Web.UI.Page
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
                else
                {
                    if (userLogin.IS_ADMIN != "Y" && !ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin"))
                    {
                        Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                        return;
                    }
                }
              
            }
        }





        protected void btnExport1_Click(object sender, EventArgs e)
        {
            if (Session["dgHusbandry"] != null)
            {
                DataTable dt = (DataTable)Session["dgHusbandry"];

                ToExport.TableToExcel(dt, "Husbandry_Analysis");
            }
        }
     

       

       
      

     

    
    }
}