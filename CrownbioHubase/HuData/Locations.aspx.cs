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

namespace PDXmodelBase.HuData
{
    public partial class Locations : System.Web.UI.Page
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
            //bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "Locations", "view");
            bool havePerm = ojbReportRule.GetUserFunctions2(userLogin.Permission, "Locations", AppConfig.UserViewRightList);
            if (!havePerm)
            {
                Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                return;
            }
            //if (!IsPostBack)
            //{

            //    List<string> treenodes = new List<string>();
            //    BaseList data = bll.Select(typeof(LOCATION));
            //    foreach (LOCATION row in data)
            //    {
            //        if (row.ISPARENT)
            //        {
            //            string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":true}}", row.AID, row.P_ID, row.NAME);
            //            treenodes.Add(node);
            //        }
            //        else
            //        {
            //            string node = string.Format("{{ \"id\":\"{0}\", \"pId\":\"{1}\", \"name\":\"{2}\",\"url\":\"\",\"isParent\":false}}", row.AID, row.P_ID, row.NAME);
            //            treenodes.Add(node);
            //        }                
            //    }
            //    string Strtest = string.Join(",", treenodes.ToArray());
            //    NodesData.Append(Strtest);
            //}

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
    }
}