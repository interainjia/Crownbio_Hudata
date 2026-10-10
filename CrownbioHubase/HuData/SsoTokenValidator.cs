using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Crownbio.Utility;
using Microsoft.IdentityModel.Tokens;

namespace PDXmodelBase.HuData
{
    /// <summary>
    /// 校验 UC（uc.crownbio.com）Azure 登录后写入的 identity_token Cookie（JWT）
    /// 配置项（Web.config appSettings）：
    ///   SsoJwtSecurityKey      UC 的 Jwt:SecurityKey
    ///   SsoJwtAlgorithm        HS256（默认，SecurityKey 作为 HMAC 密钥）或 RS256（SecurityKey 作为 RSA 公钥）
    ///   SsoJwtIssuer           为空则不校验 iss
    ///   SsoJwtAudience         为空则不校验 aud
    ///   SsoJwtValidateLifetime 默认 true
    ///   SsoJwtClockSkewSeconds 允许的时钟误差（秒），默认 300
    /// </summary>
    public static class SsoTokenValidator
    {
        public const string CookieName = "identity_token";
        private const string EmailClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";

        /// <summary>
        /// 从请求 Cookie 中读取并校验 Token，成功时返回 Token 中的邮箱
        /// </summary>
        public static bool TryValidateRequest(HttpRequest request, out string email, out string error)
        {
            email = "";
            string rawCookieValue = request.Cookies[CookieName]?.Value;
            if (string.IsNullOrEmpty(rawCookieValue))
            {
                error = "SSO token not found.";
                return false;
            }
            string token = HttpUtility.UrlDecode(rawCookieValue).Trim('"', ' ', '\t', '\r', '\n');
            // 兼容 "Bearer xxx" 这类带前缀的写法
            int spaceIndex = token.LastIndexOf(' ');
            if (spaceIndex >= 0) token = token.Substring(spaceIndex + 1);
            return TryValidate(token, out email, out error);
        }

        public static bool TryValidate(string token, out string email, out string error)
        {
            email = "";
            error = "";
            try
            {
                string securityKey = ConfigurationManager.AppSettings["SsoJwtSecurityKey"];
                if (string.IsNullOrEmpty(securityKey))
                {
                    error = "SSO is not configured.";
                    return false;
                }
                string algorithm = ConfigurationManager.AppSettings["SsoJwtAlgorithm"];
                if (string.IsNullOrEmpty(algorithm)) algorithm = SecurityAlgorithms.HmacSha256;
                string issuer = ConfigurationManager.AppSettings["SsoJwtIssuer"];
                string audience = ConfigurationManager.AppSettings["SsoJwtAudience"];
                bool validateLifetime = !string.Equals(ConfigurationManager.AppSettings["SsoJwtValidateLifetime"], "false", StringComparison.OrdinalIgnoreCase);
                if (!int.TryParse(ConfigurationManager.AppSettings["SsoJwtClockSkewSeconds"], out int clockSkewSeconds) || clockSkewSeconds < 0)
                {
                    clockSkewSeconds = 300;
                }

                SecurityKey key;
                if (string.Equals(algorithm, SecurityAlgorithms.RsaSha256, StringComparison.OrdinalIgnoreCase))
                {
                    algorithm = SecurityAlgorithms.RsaSha256;
                    key = new RsaSecurityKey(ParseRsaPublicKey(Convert.FromBase64String(securityKey)));
                }
                else
                {
                    algorithm = SecurityAlgorithms.HmacSha256;
                    key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                }

                var parameters = new TokenValidationParameters
                {
                    IssuerSigningKey = key,
                    ValidateIssuerSigningKey = true,
                    RequireSignedTokens = true,
                    // 只接受配置的算法，防止 alg=none / 算法混淆
                    ValidAlgorithms = new[] { algorithm },
                    ValidateIssuer = !string.IsNullOrEmpty(issuer),
                    ValidIssuer = issuer,
                    ValidateAudience = !string.IsNullOrEmpty(audience),
                    ValidAudience = audience,
                    ValidateLifetime = validateLifetime,
                    RequireExpirationTime = validateLifetime,
                    ClockSkew = TimeSpan.FromSeconds(clockSkewSeconds)
                };

                var handler = new JwtSecurityTokenHandler { MapInboundClaims = false };
                handler.ValidateToken(token, parameters, out SecurityToken validatedToken);

                var jwt = (JwtSecurityToken)validatedToken;
                email = jwt.Claims.FirstOrDefault(c => c.Type == EmailClaim)?.Value ?? "";
                if (string.IsNullOrEmpty(email))
                {
                    error = "SSO token has no email. Claims: " + string.Join(", ", jwt.Claims.Select(c => c.Type).Distinct());
                    LogHelper.Log("SSO token 校验失败: " + error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                error = "Invalid SSO token. " + ex.GetType().Name + ": " + ex.Message + " | " + DescribeToken(token);
                LogHelper.Log("SSO token 校验失败: " + error);
                return false;
            }
        }

        // ==============================================
        // 诊断用：输出 Token 中未经校验的关键字段（不含签名），便于排查与 UC 配置不一致的问题
        // ==============================================
        private static string DescribeToken(string token)
        {
            try
            {
                var jwt = new JwtSecurityTokenHandler { MapInboundClaims = false }.ReadJwtToken(token);
                string desc = string.Format("alg={0}; iss={1}; aud={2}; exp={3}; now={4:u}; hasEmail={5}",
                    jwt.Header.Alg, jwt.Issuer, string.Join(",", jwt.Audiences),
                    jwt.Payload.Expiration.HasValue ? jwt.ValidTo.ToString("u") : "none", DateTime.UtcNow,
                    jwt.Claims.Any(c => c.Type == EmailClaim));

                // HS256 签名不通过时，检查 UC 是否把 SecurityKey 按 Base64 解码后作为密钥
                string securityKey = ConfigurationManager.AppSettings["SsoJwtSecurityKey"];
                string[] parts = token.Split('.');
                if (jwt.Header.Alg == SecurityAlgorithms.HmacSha256 && parts.Length == 3 && !string.IsNullOrEmpty(securityKey))
                {
                    byte[] data = Encoding.ASCII.GetBytes(parts[0] + "." + parts[1]);
                    desc += "; keyUtf8Match=" + HmacMatches(Encoding.UTF8.GetBytes(securityKey), data, parts[2]);
                    try { desc += "; keyBase64Match=" + HmacMatches(Convert.FromBase64String(securityKey), data, parts[2]); }
                    catch (FormatException) { }
                }
                return desc;
            }
            catch (Exception ex)
            {
                return "unreadable token (" + ex.Message + "), length=" + token.Length;
            }
        }

        private static bool HmacMatches(byte[] key, byte[] data, string signature)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return Base64UrlEncoder.Encode(hmac.ComputeHash(data)) == signature;
            }
        }

        // ==============================================
        // 解析 X.509 SubjectPublicKeyInfo（"MIGfMA0G..." 格式）RSA 公钥
        // .NET Framework 4.8 没有 ImportSubjectPublicKeyInfo，这里手动解析 DER
        // SEQUENCE { SEQUENCE { OID, NULL }, BIT STRING { SEQUENCE { INTEGER n, INTEGER e } } }
        // ==============================================
        private static RSAParameters ParseRsaPublicKey(byte[] der)
        {
            int pos = 0;
            ReadTag(der, ref pos, 0x30);            // SubjectPublicKeyInfo
            int algLen = ReadTag(der, ref pos, 0x30); // AlgorithmIdentifier
            pos += algLen;
            ReadTag(der, ref pos, 0x03);            // BIT STRING
            pos++;                                  // unused bits
            ReadTag(der, ref pos, 0x30);            // RSAPublicKey
            byte[] modulus = ReadInteger(der, ref pos);
            byte[] exponent = ReadInteger(der, ref pos);
            return new RSAParameters { Modulus = modulus, Exponent = exponent };
        }

        private static byte[] ReadInteger(byte[] der, ref int pos)
        {
            int len = ReadTag(der, ref pos, 0x02);
            int start = pos;
            pos += len;
            while (len > 1 && der[start] == 0x00) { start++; len--; }
            byte[] value = new byte[len];
            Buffer.BlockCopy(der, start, value, 0, len);
            return value;
        }

        private static int ReadTag(byte[] der, ref int pos, byte expectedTag)
        {
            if (der[pos++] != expectedTag) throw new FormatException("Invalid RSA public key.");
            int len = der[pos++];
            if ((len & 0x80) != 0)
            {
                int count = len & 0x7F;
                len = 0;
                for (int i = 0; i < count; i++) len = (len << 8) | der[pos++];
            }
            return len;
        }
    }
}
