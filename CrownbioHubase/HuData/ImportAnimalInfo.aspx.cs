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
    public partial class ImportAnimalInfo : System.Web.UI.Page
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
                //bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "DataImport", "view");
                bool havePerm = ojbReportRule.GetUserFunctions2(userLogin.Permission, "DataImport", AppConfig.UserViewRightList);
                if (!havePerm)
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                    return;
                }
              
            }
        }


     
 

        

       

       
      

     

    
    }
}