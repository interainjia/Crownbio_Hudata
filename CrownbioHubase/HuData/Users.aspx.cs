using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crownbio.Model;
using Crownbio.Utility;
using Crownbio.BLL;
using Crownbio.Common;
using System.Data;
using System.Collections;

namespace PDXmodelBase.HuData
{
    public partial class Users : System.Web.UI.Page
    {
        ObjectBLL bll = new ObjectBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            if (!userLogin.IS_Login)
            {
                Response.Write(" <script language='javascript'>parent.parent.document.location.href='../ErrorMsg.aspx?LoginType=1'</script>");
            }
            else
            {
                if (userLogin.IS_ADMIN != "Y" && !ojbRuleHuData.CheckIsAdmin(userLogin.USER_ID, "Admin"))
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                }
            }
        }

        protected void btnExport1_Click(object sender, EventArgs e)
        {
            DataTable dt = ojbReportRule.getAllUsers();
            dt.Columns.Add("Role");
            foreach (DataRow user in dt.Rows)
            {
                ParamCollection _paramCollection = new ParamCollection();
                _paramCollection.Clause = String.Format("{0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.USER_ID = {3} ) "
                    , new object[] { SYS_ROLE.TABLE_NAME, SYS_ROLE.ROLE_NO_FIELD, SYS_USER_ROLE.TABLE_NAME, user["USER_ID"] });
                BaseList perdata = bll.Select(_paramCollection, typeof(SYS_ROLE));
                ArrayList rolename = new ArrayList();
                foreach (SYS_ROLE name in perdata)
                {
                    rolename.Add(name.ROLE_NAME);
                }

                user["Role"] = string.Join(",", rolename.ToArray());
            }
            dt.Columns.Remove("USER_ID");
            ToExport.TableToExcel(dt, "HuData_Users");
        }

     
    }
}