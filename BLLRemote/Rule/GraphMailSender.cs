using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Crownbio.BLL.Rule
{
    /// <summary>
    /// 通过 Microsoft Graph API 发送邮件（OAuth 2.0 client credentials，app-only）
    /// 发件邮箱为共享邮箱 dbsupport@crownbio.com，应用只被授权以该邮箱发信（Exchange RBAC 限定范围）。
    /// 配置项（Web.config appSettings）：
    ///   GraphMailTenantId / GraphMailClientId / GraphMailClientSecret / GraphMailSenderAddress
    ///   GraphMailSenderName（可选，发件人显示名，默认 "Hudata"）
    /// ClientSecret 优先读取环境变量 GRAPHMAIL_CLIENTSECRET，未设置时再读 Web.config。
    /// 直接调用 REST 接口，不依赖 Microsoft.Graph / Azure.Identity NuGet 包。
    /// </summary>
    public static class GraphMailSender
    {
        private const string GraphSendMailUrl = "https://graph.microsoft.com/v1.0/users/{0}/sendMail";
        private const string TokenUrl = "https://login.microsoftonline.com/{0}/oauth2/v2.0/token";
        private const string GraphScope = "https://graph.microsoft.com/.default";

        private static readonly object TokenLock = new object();
        private static string _cachedToken;
        private static DateTime _cachedTokenExpiresUtc = DateTime.MinValue;

        static GraphMailSender()
        {
            // login.microsoftonline.com / graph.microsoft.com 要求 TLS 1.2
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }

        public static string TenantId => ConfigurationManager.AppSettings["GraphMailTenantId"];
        public static string ClientId => ConfigurationManager.AppSettings["GraphMailClientId"];
        public static string SenderAddress => ConfigurationManager.AppSettings["GraphMailSenderAddress"];

        /// <summary>
        /// 发件人显示名，可用 Web.config 的 GraphMailSenderName 覆盖，默认 "Hudata"
        /// </summary>
        public static string SenderName
        {
            get
            {
                string name = ConfigurationManager.AppSettings["GraphMailSenderName"];
                return string.IsNullOrWhiteSpace(name) ? "Hudata" : name.Trim();
            }
        }

        public static string ClientSecret
        {
            get
            {
                string fromEnv = Environment.GetEnvironmentVariable("GRAPHMAIL_CLIENTSECRET");
                return string.IsNullOrEmpty(fromEnv) ? ConfigurationManager.AppSettings["GraphMailClientSecret"] : fromEnv;
            }
        }

        /// <summary>
        /// 发送邮件，失败时抛出异常（异常信息含 Graph 返回的错误描述）
        /// </summary>
        public static void Send(string subject, string body, bool isHtml, IEnumerable<string> to, IEnumerable<string> bcc = null)
        {
            if (string.IsNullOrEmpty(TenantId) || string.IsNullOrEmpty(ClientId) ||
                string.IsNullOrEmpty(ClientSecret) || string.IsNullOrEmpty(SenderAddress))
            {
                throw new InvalidOperationException("Graph mail is not configured (GraphMailTenantId/ClientId/ClientSecret/SenderAddress).");
            }

            var toList = (to ?? Enumerable.Empty<string>()).Where(a => !string.IsNullOrWhiteSpace(a)).Select(a => a.Trim()).ToList();
            if (toList.Count == 0)
            {
                throw new ArgumentException("No recipient.");
            }
            var bccList = (bcc ?? Enumerable.Empty<string>()).Where(a => !string.IsNullOrWhiteSpace(a)).Select(a => a.Trim()).ToList();

            var message = new Dictionary<string, object>
            {
                ["subject"] = subject ?? "",
                ["from"] = new Dictionary<string, object>
                {
                    ["emailAddress"] = new Dictionary<string, object>
                    {
                        ["address"] = SenderAddress,
                        ["name"] = SenderName
                    }
                },
                ["body"] = new Dictionary<string, object>
                {
                    ["contentType"] = isHtml ? "HTML" : "Text",
                    ["content"] = body ?? ""
                },
                ["toRecipients"] = ToRecipients(toList)
            };
            if (bccList.Count > 0)
            {
                message["bccRecipients"] = ToRecipients(bccList);
            }
            var payload = new Dictionary<string, object>
            {
                ["message"] = message,
                ["saveToSentItems"] = true
            };
            string json = new JavaScriptSerializer { MaxJsonLength = int.MaxValue }.Serialize(payload);
            string url = string.Format(GraphSendMailUrl, Uri.EscapeDataString(SenderAddress));

            string accessToken = GetAccessToken();
            try
            {
                PostJson(url, json, accessToken);
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Token 可能已被吊销/过期，清缓存后重试一次
                lock (TokenLock) { _cachedToken = null; }
                PostJson(url, json, GetAccessToken());
            }
        }

        private static List<object> ToRecipients(IEnumerable<string> addresses)
        {
            return addresses.Select(a => (object)new Dictionary<string, object>
            {
                ["emailAddress"] = new Dictionary<string, object> { ["address"] = a }
            }).ToList();
        }

        private static string GetAccessToken()
        {
            lock (TokenLock)
            {
                // 提前 5 分钟刷新
                if (!string.IsNullOrEmpty(_cachedToken) && DateTime.UtcNow < _cachedTokenExpiresUtc.AddMinutes(-5))
                {
                    return _cachedToken;
                }

                string form = "client_id=" + HttpUtility.UrlEncode(ClientId) +
                              "&client_secret=" + HttpUtility.UrlEncode(ClientSecret) +
                              "&scope=" + HttpUtility.UrlEncode(GraphScope) +
                              "&grant_type=client_credentials";

                var request = (HttpWebRequest)WebRequest.Create(string.Format(TokenUrl, Uri.EscapeDataString(TenantId)));
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = 30000;
                string responseText = Send(request, Encoding.UTF8.GetBytes(form), "Get Graph token failed", false);

                var result = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(responseText);
                _cachedToken = result["access_token"].ToString();
                int expiresIn = result.ContainsKey("expires_in") ? Convert.ToInt32(result["expires_in"]) : 3600;
                _cachedTokenExpiresUtc = DateTime.UtcNow.AddSeconds(expiresIn);
                return _cachedToken;
            }
        }

        private static void PostJson(string url, string json, string accessToken)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers[HttpRequestHeader.Authorization] = "Bearer " + accessToken;
            request.Timeout = 60000;
            Send(request, Encoding.UTF8.GetBytes(json), "Graph sendMail failed", true); // 成功返回 202 Accepted，无响应体
        }

        private static string Send(HttpWebRequest request, byte[] body, string errorPrefix, bool rethrowUnauthorized)
        {
            request.ContentLength = body.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(body, 0, body.Length);
            }
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex) when (ex.Response is HttpWebResponse errorResponse
                                          && !(rethrowUnauthorized && errorResponse.StatusCode == HttpStatusCode.Unauthorized))
            {
                string detail;
                using (var reader = new StreamReader(errorResponse.GetResponseStream(), Encoding.UTF8))
                {
                    detail = reader.ReadToEnd();
                }
                // sendMail 的 401 不进这里（由调用方清 Token 后重试）；其余带上 Graph 的错误描述抛出（不含密钥/Token）
                throw new WebException(string.Format("{0}: {1} {2}", errorPrefix, (int)errorResponse.StatusCode, detail), ex);
            }
        }
    }
}
