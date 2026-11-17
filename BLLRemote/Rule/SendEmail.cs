using System;
using System.Configuration;

namespace Crownbio.BLL.Rule
{
    public class SendEmail
    {
        // 旧 SMTP 账号/密码（已停用，仅为兼容未使用的 SendbyExchange 代码保留）
        public static string MailUserName => ConfigurationManager.AppSettings["MailUserName"];
        public static string MailPassword => ConfigurationManager.AppSettings["MailPassword"];

        /// <summary>
        /// 发送邮件。出于 IT 安全要求，已由 SMTP 账号密码方式改为 Microsoft Graph API（发件人 dbsupport@crownbio.com），
        /// 方法名与参数保持不变以兼容现有调用方。成功返回 msg，失败返回异常信息。
        /// </summary>
        public static string SendMail_SMTP(string code, string Subject, string Body, string[] To, string msg)
        {
            string resultVal = msg;
            try
            {
                //add by Jack 2026.06.23
                string[] bcc = { "runjun.jia@crownbio.com" };
                GraphMailSender.Send(Subject, Body, code == "html", To, bcc);
            }
            catch (Exception ex)
            {
                resultVal = ex.Message;
            }
            return resultVal;
        }

    }
}
