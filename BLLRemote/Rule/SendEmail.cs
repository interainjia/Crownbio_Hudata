using System;
using System.Net;
using System.Net.Mail;

namespace Crownbio.BLL.Rule
{
    public class SendEmail
    {
        public static string SendMail_SMTP(string code, string Subject, string Body, string[] To, string msg)
        {
            string resultVal = msg;
            try
            {
                MailMessage mailMessage = new MailMessage();//定义邮件
                SmtpClient smtpClient = new SmtpClient();//定义发件客户端
                mailMessage.From = new MailAddress("HuDataAdmin@crownbio.com");//邮件发送人地址
                mailMessage.Subject = Subject;//邮件主题
                mailMessage.Body = Body;//邮件内容
                if (code == "html")
                {
                    mailMessage.IsBodyHtml = true;//HTML格式
                }
                else
                {
                    mailMessage.IsBodyHtml = false;//text格式
                }
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;//编码UTF8
                mailMessage.Priority = MailPriority.Normal;//邮件发送的优先性为正常
                foreach (var name in To)
                {
                    mailMessage.To.Add(name);
                }
                //add by Jack 2026.06.23
                mailMessage.Bcc.Add(new MailAddress("runjun.jia@crownbio.com"));
                smtpClient.UseDefaultCredentials = false;//使用默认凭据
                smtpClient.EnableSsl = true;//启动SSL，即安全发送
                smtpClient.Credentials = new NetworkCredential("HuDataAdmin@crownbio.com", "xba-12");
                smtpClient.Host = "smtp.office365.com";//发送连接服务器主机IP
                smtpClient.Port = 587;//端口号 
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//传递电子邮件消息，通过网络发送电子邮件到SMTP
                smtpClient.Send(mailMessage);//确认发送按钮

            }
            catch (Exception ex)
            {
                resultVal = ex.Message;
            }
            return resultVal;
        }

    }
}
