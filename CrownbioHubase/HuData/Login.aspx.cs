using Crownbio.Utility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDXmodelBase.HuData
{
    public partial class Login : System.Web.UI.Page
    {
        string username = "";
        string password = "";

        // 新增：Azure AD 用户信息（从Token解析出来）
        string azureAdUserId = "";    // 用户唯一ID
        string azureAdUserName = "";  // 姓名
        string azureAdEmail = "";     // 邮箱
        string azureAdUpn = "";       // 登录账号
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. 优先尝试 Azure AD 登录
            ParseAzureAdUserInfo();

            // 2. 如果没有走 Azure AD（比如直接打开登录页），则走原来的本地 Cookie 逻辑
            if (string.IsNullOrEmpty(azureAdUserName) && !IsPostBack)
            {
                if (Request.Cookies["Hudatausername"] != null)
                {
                    username = Request.Cookies["Hudatausername"].Value;
                    password = Request.Cookies["Hudatapassword"].Value;
                    MessageHelper.ResponseClientScript(this,
                        $"$('#username').val('{username}');$('#password').val('{password}');");
                }
            }
        }

        // ==============================================
        // 核心方法：手动解析 JWT Payload (带全流程网页调试输出)
        // ==============================================
        /*
        private void ParseAzureAdUserInfo()
        {
            try
            {
                // 1. 获取原始 Cookie
                string rawCookieValue = Request.Cookies["identity_token"]?.Value;

                // 【调试阶段 1】
                if (string.IsNullOrEmpty(rawCookieValue))
                {
                    Response.Write("<div style='background-color:red; color:white; padding:15px; font-weight:bold; z-index:9999; position:relative;'>");
                    Response.Write("【阶段1 失败】没有拿到 identity_token Cookie！");
                    Response.Write("</div>");
                    return;
                }

                string debugCookie = rawCookieValue.Length > 30 ? rawCookieValue.Substring(0, 30) : rawCookieValue;
                Response.Write("<div style='background-color:green; color:white; padding:15px; font-weight:bold; z-index:9999; position:relative;'>");
                Response.Write($"【阶段1 成功】拿到 Cookie！头部：{debugCookie}...");
                Response.Write("</div>");

                // 防一手 URL 编码（即使看起来没编码，解码一下也不受影响）
                string idToken = HttpUtility.UrlDecode(rawCookieValue);

                // 2. 清除可能附带的引号和空格，并按点(.)分割 JWT
                string jwtToken = idToken.Trim('"', ' ', '\t', '\r', '\n');
                string[] parts = jwtToken.Split('.');

                // 【调试阶段 2】
                if (parts.Length < 2)
                {
                    Response.Write("<div style='background-color:red; color:white; padding:15px; font-weight:bold; z-index:9999; position:relative;'>");
                    Response.Write($"【阶段2 失败】Token 格式不对，找不到 Payload！拆分后长度：{parts.Length}");
                    Response.Write("</div>");
                    return;
                }

                // 3. 取出第二部分 (Payload) 并手动修复 Base64Url 编码为标准 Base64
                string payloadBase64 = parts[1].Replace('-', '+').Replace('_', '/');

                // 补全 Base64 缺少的等号（=）填充
                switch (payloadBase64.Length % 4)
                {
                    case 2: payloadBase64 += "=="; break;
                    case 3: payloadBase64 += "="; break;
                }

                // 解码为原生 JSON 字符串
                byte[] payloadBytes = Convert.FromBase64String(payloadBase64);
                string jsonPayload = System.Text.Encoding.UTF8.GetString(payloadBytes);

                // 【调试阶段 3】输出解密后的真实 JSON
                Response.Write("<div style='background-color:teal; color:white; padding:15px; font-weight:bold; z-index:9999; position:relative;'>");
                Response.Write($"【阶段3 成功】Base64 手动解码成功！<br/>拿到的原生 JSON 是：<br/>{jsonPayload}");
                Response.Write("</div>");

                // 4. 从 JSON 中提取你要的字段
                // 4. 从 JSON 中提取你要的字段 (换成 JSON 里实际存在的长键名)
                azureAdUserName = ExtractJsonStringValue(jsonPayload, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
                azureAdEmail = ExtractJsonStringValue(jsonPayload, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
                azureAdUserId = ExtractJsonStringValue(jsonPayload, "/userid");

                // 兜底逻辑
                //if (string.IsNullOrEmpty(azureAdUserName) && !string.IsNullOrEmpty(azureAdEmail))
                //{
                //    azureAdUserName = azureAdEmail;
                //}
                azureAdUserName = azureAdEmail;

                // 【调试阶段 4】确认最终变量赋值
                Response.Write("<div style='background-color:blue; color:white; padding:15px; font-weight:bold; z-index:9999; position:relative;'>");
                Response.Write($"【阶段4 成功】字段提取完成！<br/>");
                Response.Write($"准备自动登录的账号 (azureAdUserName) = {azureAdUserName}<br/>");
                Response.Write($"邮箱 (azureAdEmail) = {azureAdEmail}");
                Response.Write("</div>");
            }
            catch (Exception ex)
            {
                // 【调试阶段 5】报错拦截
                Response.Write("<div style='background-color:orange; color:black; padding:15px; font-weight:bold; z-index:9999; position:relative;'>");
                Response.Write($"【代码执行报错】手动解析发生异常：<br/>{ex.Message}");
                Response.Write("</div>");
            }
        }

        // ==============================================
        // 辅助方法：从 JSON 字符串中提取指定的 Value
        // (轻量级提取，不依赖任何第三方库，必须一起复制)
        // ==============================================
        private string ExtractJsonStringValue(string json, string key)
        {
            try
            {
                string searchKey = "\"" + key + "\":";
                int startIndex = json.IndexOf(searchKey, StringComparison.OrdinalIgnoreCase);
                if (startIndex == -1) return "";

                startIndex += searchKey.Length;

                // 找值的起始引号
                int quoteStart = json.IndexOf("\"", startIndex);
                if (quoteStart == -1) return "";

                // 找值的结束引号
                int quoteEnd = json.IndexOf("\"", quoteStart + 1);
                if (quoteEnd == -1) return "";

                return json.Substring(quoteStart + 1, quoteEnd - quoteStart - 1);
            }
            catch
            {
                return ""; // 提取失败时不报错，直接返回空
            }
        }
        */

        // ==============================================
        // 核心方法：手动解析 JWT Payload (最终生产版)
        // ==============================================
        private void ParseAzureAdUserInfo()
        {
            try
            {
                string rawCookieValue = Request.Cookies["identity_token"]?.Value;
                if (string.IsNullOrEmpty(rawCookieValue)) return;

                string idToken = HttpUtility.UrlDecode(rawCookieValue);
                string jwtToken = idToken.Trim('"', ' ', '\t', '\r', '\n');
                string[] parts = jwtToken.Split('.');
                if (parts.Length < 2) return;

                string payloadBase64 = parts[1].Replace('-', '+').Replace('_', '/');
                switch (payloadBase64.Length % 4)
                {
                    case 2: payloadBase64 += "=="; break;
                    case 3: payloadBase64 += "="; break;
                }

                byte[] payloadBytes = Convert.FromBase64String(payloadBase64);
                string jsonPayload = System.Text.Encoding.UTF8.GetString(payloadBytes);

                // 提取精准的字段名
                azureAdUserName = ExtractJsonStringValue(jsonPayload, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
                azureAdEmail = ExtractJsonStringValue(jsonPayload, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
                azureAdUserId = ExtractJsonStringValue(jsonPayload, "/userid");

                // 兜底：如果没拿到 name，或者你想统一用 runjun.jia 格式作为登录名
                //if (string.IsNullOrEmpty(azureAdUserName) && !string.IsNullOrEmpty(azureAdEmail))
                //{
                //    azureAdUserName = azureAdEmail.Split('@')[0]; // 把 runjun.jia@crownbio.com 截取为 runjun.jia
                //}
                azureAdUserName = azureAdEmail;

                // ==============================================
                // 关键：拿到账号后，自动触发前端登录
                // ==============================================
                if (!string.IsNullOrEmpty(azureAdUserName))
                {
                    username = azureAdUserName;

                    // 必须包裹在 $(function(){}) 中，确保页面元素加载完毕后再执行
                    string autoLoginScript = $@"
                $(function() {{
                    $('#username').val('{username}');
                    $('#password').val('');
                    
                    // 延迟 200 毫秒执行，给浏览器一点时间渲染输入框的值
                    setTimeout(function() {{
                        if (typeof userLogin_auto === 'function') {{
                            userLogin_auto(true);
                        }}
                    }}, 200);
                }});
            ";
                    MessageHelper.ResponseClientScript(this, autoLoginScript);
                }
            }
            catch (Exception ex)
            {
                // 生产环境静默处理或记录到系统日志
                System.Diagnostics.Debug.WriteLine("Azure AD 解析失败: " + ex.Message);
            }
        }

        private string ExtractJsonStringValue(string json, string key)
        {
            try
            {
                string searchKey = "\"" + key + "\":";
                int startIndex = json.IndexOf(searchKey, StringComparison.OrdinalIgnoreCase);
                if (startIndex == -1) return "";

                startIndex += searchKey.Length;
                int quoteStart = json.IndexOf("\"", startIndex);
                if (quoteStart == -1) return "";
                int quoteEnd = json.IndexOf("\"", quoteStart + 1);
                if (quoteEnd == -1) return "";

                return json.Substring(quoteStart + 1, quoteEnd - quoteStart - 1);
            }
            catch { return ""; }
        }
    }
}