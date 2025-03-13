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
                script.Append("$('#First_name').val('" + userLogin.FIRST_NAME + "');");
                script.Append("$('#Last_name').val('" + userLogin.LAST_NAME + "');");
                script.Append("$('#Position').val('" + userLogin.POSITION + "');");
                script.Append("$('#Department').val('" + userLogin.DEPARTMENT + "');");
                script.Append("$('#Institution').val('" + userLogin.INSTITUTION + "');");
                script.Append("$('#Street_Address').val('" + userLogin.STREET_ADDRESS + "');");
                script.Append("$('#City').val('" + userLogin.CITY + "');");
                script.Append("getCountry('" + userLogin.COUNTRY + "');");
                script.Append("$('#Phone').val('" + userLogin.PHONE + "');");
                script.Append("$('#Fax').val('" + userLogin.FAX + "');");
                script.Append("$('#Password').val('" + DEncryptHelper.Decrypt(userLogin.USER_PWD) + "');");
                script.Append("$('#ConfirmPassword').val('" + DEncryptHelper.Decrypt(userLogin.USER_PWD) + "');");
                if (userLogin.EMAIL == "trial@crownbio.com")
                {
                    script.Append("document.getElementById(\"changeInfo\").style.display = \"none\";");
                }
                MessageHelper.ResponseClientScript(this, script.ToString());
            }
        }
    }
}