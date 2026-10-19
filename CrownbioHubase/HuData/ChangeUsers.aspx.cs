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
                // AD 域用户登录时不校验库里的 USER_PWD，可能为空或不是有效密文，解密失败时不预填密码
                string password = "";
                try
                {
                    if (!string.IsNullOrEmpty(userLogin.USER_PWD))
                    {
                        password = DEncryptHelper.Decrypt(userLogin.USER_PWD);
                    }
                }
                catch (System.Security.Cryptography.CryptographicException)
                {
                    password = "";
                }
                catch (FormatException)
                {
                    password = "";
                }
                script.Append("$('#Password').val('" + HttpUtility.JavaScriptStringEncode(password) + "');");
                script.Append("$('#ConfirmPassword').val('" + HttpUtility.JavaScriptStringEncode(password) + "');");
                if (userLogin.EMAIL == "trial@crownbio.com")
                {
                    script.Append("document.getElementById(\"changeInfo\").style.display = \"none\";");
                }
                MessageHelper.ResponseClientScript(this, script.ToString());
            }
        }
    }
}