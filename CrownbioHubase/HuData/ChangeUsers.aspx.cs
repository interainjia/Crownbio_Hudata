using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crownbio.Model;
using Crownbio.Utility;
using System.Text;

namespace CrownbioHuData.HuData
{
    public partial class ChangeUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SYS_USER userLogin = CacheHelper.getCurrentUser();
            if (!userLogin.IS_Login)
            {
                Response.Write(" <script language='javascript'>parent.parent.document.location.href='../ErrorMsg.aspx?LoginType=1'</script>");
            }
            else {
                StringBuilder script = new StringBuilder();
                script.Append("$('#First_name').val('" + HttpUtility.JavaScriptStringEncode(userLogin.FIRST_NAME) + "');");
                script.Append("$('#Last_name').val('" + HttpUtility.JavaScriptStringEncode(userLogin.LAST_NAME) + "');");
                script.Append("$('#Position').val('" + HttpUtility.JavaScriptStringEncode(userLogin.POSITION) + "');");
                script.Append("$('#Department').val('" + HttpUtility.JavaScriptStringEncode(userLogin.DEPARTMENT) + "');");
                script.Append("$('#Institution').val('" + HttpUtility.JavaScriptStringEncode(userLogin.INSTITUTION) + "');");
                script.Append("$('#Street_Address').val('" + HttpUtility.JavaScriptStringEncode(userLogin.STREET_ADDRESS) + "');");
                script.Append("$('#City').val('" + HttpUtility.JavaScriptStringEncode(userLogin.CITY) + "');");
                script.Append("getCountry('" + HttpUtility.JavaScriptStringEncode(userLogin.COUNTRY) + "');");
                script.Append("$('#Phone').val('" + HttpUtility.JavaScriptStringEncode(userLogin.PHONE) + "');");
                script.Append("$('#Fax').val('" + HttpUtility.JavaScriptStringEncode(userLogin.FAX) + "');");
                // 仅支持 Sign In With Azure，密码字段已停用：不再解密、不再把密码输出到页面
                if (userLogin.EMAIL == "trial@crownbio.com")
                {
                    script.Append("document.getElementById(\"changeInfo\").style.display = \"none\";");
                }
                MessageHelper.ResponseClientScript(this, script.ToString());
            }
        }
    }
}