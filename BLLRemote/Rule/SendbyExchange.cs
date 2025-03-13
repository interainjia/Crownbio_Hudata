using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crownbio.BLL
{
    public class SendbyExchange
    {
        public static string SendMail3(string code, string Subject, string Body, string[] To, string msg)
        {
            string address = "https://outlook.office365.com/ews/exchange.asmx";
            string resultVal = SendByExchange(code, "HuDataAdmin@crownbio.com",
                                  "xba-12",
                                      "HuDataAdmin@crownbio.com",
                                         To,
                                              "crownbio.com",
                                                  address,
                                                      Subject,
                                                          Body, msg);

            return resultVal;
        }

        public static DataTable GetMail()
        {
            string address = "https://outlook.office365.com/ews/exchange.asmx";
           
            return GetMailMessageNew("lijun@crownbio.com", "tsxcrvvfqyxcpybz", "crownbio.com", address);

        }

        public static string SendByExchange(string code, string credentialUserName, string credentialUserPwd, string senderEmail, string[] recipientEmail, string domainName, string ewsUrl, string subjectName, string bodyVal, string msg)
        {
            string result = "";
            try
            {
                ExchangeService service = new ExchangeService();
                service.Url = new Uri(ewsUrl);
                service.Credentials = new WebCredentials(credentialUserName, credentialUserPwd, domainName);
                EmailMessage message = new EmailMessage(service);

                message.Subject = subjectName;
                if (code == "html")
                {
                    message.Body = new MessageBody(BodyType.HTML, bodyVal);
                }
                else
                {
                    message.Body = new MessageBody(BodyType.Text, bodyVal);
                }

                //message.Body = bodyVal;
                foreach (string to in recipientEmail)
                {
                    message.ToRecipients.Add(to);
                }
                //for (int i = 0; i < attachments.Count; i++)
                //{
                //    message.Attachments.AddFileAttachment(attachments[i]);
                //}
                message.Save();
                message.SendAndSaveCopy();
                result = msg;
            }
            catch (XmlSyntaxException e)
            {
                result = ("邮件服务器地址错误");

            }
            catch (ServiceLocalException e)
            {
                result = ("邮件对象生成错误");

            }
            catch (Exception e)
            {
                result = ("发送邮件错误");

            }
            return result;
        }

        public static DataTable GetMailMessageNew(string userName, string passWord, string domain, string url)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("First Name");
            dt.Columns.Add("Last Name");
            dt.Columns.Add("Company Email");
            dt.Columns.Add("Username");
            dt.Columns.Add("Password");
            dt.Columns.Add("Institution");
            dt.Columns.Add("Country");
            dt.Columns.Add("State");
            dt.Columns.Add("City");
            dt.Columns.Add("Source");
            try
            {

                ExchangeService _service = new ExchangeService();
                _service.Url = new Uri(url);
                _service.Credentials = new WebCredentials(userName, passWord, domain);
               
              
                //声明一个分页器之类的玩意
                var itemView = new ItemView(10);
                //var folders = _service.FindFolders(WellKnownFolderName.Inbox, folderVw);
                //我们只需要获取未读邮件

                SearchFilter.IsEqualTo unreadFilter =
        new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false);
                try
                {
                    //指定收件箱，并绑定到Service 
                    var folder = Folder.Bind(_service, WellKnownFolderName.Inbox, BasePropertySet.IdOnly);
                    //调用api 获取未读邮件清单
                    var items = folder.FindItems(unreadFilter, itemView);
                    //var items = _service.FindItems(WellKnownFolderName.Inbox, unreadFilter, itemView);
                    //需要指定要解析的属性，更多属性参考该类定义  ！！
                    PropertySet propSet = new PropertySet(
                        EmailMessageSchema.TextBody,
                        EmailMessageSchema.Body,
                        EmailMessageSchema.IsRead,
                        EmailMessageSchema.Sender,
                        EmailMessageSchema.From,
                        EmailMessageSchema.Subject);
                    //遍历未读邮件
                    foreach (EmailMessage item in items)
                    {
                        //这里必须指定上面定义的需要解析的架构，重新绑定才可以解析，不然某些属性会报错，比如  You must load or assign this property before you can read its value.
                        EmailMessage message = (EmailMessage)Item.Bind(_service, item.Id, propSet);

                        Console.WriteLine($"{message.Subject},Body:" + message.TextBody);

                        if (!message.IsRead && message.Subject.Contains("Database Notification:") &&
                               (message.Subject.Contains("Request Submitted") || message.Subject.Contains("Submitted Database Request")))
                        {
                            DataRow dr = dt.NewRow();
                            //string[] strs = getItemResponseMessage.Items.Items[0].Body.Value.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                            string strs = message.Body;
                            string str1 = ParseHtml("<p style=\"margin-bottom: 1em; \">First Name: (.*?)</p>", strs);
                            string str2 = ParseHtml("<p style=\"margin-bottom: 1em; \">Last Name: (.*?)</p>", strs);
                            string str3 = ParseHtml("<p style=\"margin-bottom: 1em; \">Email: (.*?)</p>", strs);
                            string str4 = ParseHtml("<p style=\"margin-bottom: 1em; \">Password: (.*?)</p>", strs);
                            string str5 = ParseHtml("<p style=\"margin-bottom: 1em; \">Institution: (.*?)</p>", strs);
                            string str6 = ParseHtml("<p style=\"margin-bottom: 1em; \">Country: (.*?)</p>", strs);
                            string str7 = ParseHtml("<p style=\"margin-bottom: 1em; \">State: (.*?)</p>", strs);
                            string str8 = ParseHtml("<p style=\"margin-bottom: 1em; \">City: (.*?)</p>", strs);
                            string str9 = ParseHtml("<p style=\"margin-bottom: 1em; \">Origin DB: (.*?)</p>", strs);

                            dr["First Name"] = str1.Replace("<p style=\"margin-bottom: 1em; \">First Name: ", "").Replace("</p>", "");
                            dr["Last Name"] = str2.Replace("<p style=\"margin-bottom: 1em; \">Last Name: ", "").Replace("</p>", "");
                            dr["Company Email"] = str3.Replace("<p style=\"margin-bottom: 1em; \">Email: ", "").Replace("</p>", "");
                            dr["Username"] = str3.Replace("<p style=\"margin-bottom: 1em; \">Email: ", "").Replace("</p>", "");
                            dr["Password"] = str4.Replace("<p style=\"margin-bottom: 1em; \">Password: ", "").Replace("</p>", "");
                            dr["Institution"] = str5.Replace("<p style=\"margin-bottom: 1em; \">Institution: ", "").Replace("</p>", "");
                            dr["Country"] = str6.Replace("<p style=\"margin-bottom: 1em; \">Country: ", "").Replace("</p>", "");
                            dr["State"] = str7.Replace("<p style=\"margin-bottom: 1em; \">State: ", "").Replace("</p>", "");
                            dr["City"] = str8.Replace("<p style=\"margin-bottom: 1em; \">City: ", "").Replace("</p>", "");
                            dr["Source"] = str9.Replace("<p style=\"margin-bottom: 1em; \">Origin DB: ", "").Replace("</p>", "");
                            dt.Rows.Add(dr);

                            //设为已读
                            item.IsRead = true; //设置为已读
                            item.Update(ConflictResolutionMode.AlwaysOverwrite);//调用API更新
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

            catch (Exception ex)
            {
                throw new Exception("receive error", ex);
            }
            return dt;

        }

        private static string ParseHtml(string pattern, string htmlStr)
        {
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            Match m = r.Match(htmlStr);


            if (m.Success)
            {
                return m.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
