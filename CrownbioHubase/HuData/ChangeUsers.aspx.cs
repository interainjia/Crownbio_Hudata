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
                // 密码不再解密、不输出到页面（库中只存哈希）。外部客户可在此设置新密码（留空不修改），
                // 公司域账号（@crownbio.com）密码由 Azure AD 管理，密码框保持禁用
                if (!PDXmodelBase.HuData.userLogin.IsCrownbioEmail(userLogin.EMAIL))
                {
                    script.Append("$('#Password, #ConfirmPassword').prop('disabled', false).attr('placeholder', 'Leave blank to keep current password');");
                }
                if (userLogin.EMAIL == "trial@crownbio.com")
                {
                    script.Append("document.getElementById(\"changeInfo\").style.display = \"none\";");
                }
                MessageHelper.ResponseClientScript(this, script.ToString());
            }
        }
    }
}