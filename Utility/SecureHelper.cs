using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Crownbio.Utility
{
    /// <summary>
    /// 与用户中心(UC)登录接口对接所需的哈希/加密方法，算法需与 UC 后端保持一致，不可自行调整。
    /// </summary>
    public class SecureHelper
    {
        /// <summary>
        /// 获取SHA1加密结果（大写十六进制，不含分隔符）
        /// </summary>
        public static string GetSHA1(string text)
        {
            using (var sha1 = SHA1.Create())
            {
                var result = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(result).Replace("-", "");
            }
        }

        /// <summary>
        /// 获取MD5加密结果（大写十六进制，不含分隔符）
        /// </summary>
        public static string GetMD5(string text)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(result).Replace("-", "");
            }
        }

        /// <summary>
        /// 生成传给 UC 登录接口的 po 参数：用一次性随机 DES key 加密明文密码，
        /// 并附带用共享密钥(ucApiKey)计算出的校验片段，供 UC 后端解密还原明文密码。
        /// </summary>
        public static string EncPwd(string password, string ucApiKey)
        {
            string key = GetMD5(GetRandom(8)).Substring(6, 8);
            string pwd = DesEncryptHex(password, key);
            string pwdSha1 = GetSHA1(pwd + ucApiKey).Substring(8, 6);
            return $"{pwdSha1}{pwd}{key}";
        }

        private static string DesEncryptHex(string plainText, string key8)
        {
            try
            {
                using (var des = new DESCryptoServiceProvider())
                {
                    byte[] inputByteArray = Encoding.Default.GetBytes(plainText);
                    des.Key = Encoding.ASCII.GetBytes(key8);
                    des.IV = Encoding.ASCII.GetBytes(key8);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(inputByteArray, 0, inputByteArray.Length);
                            cs.FlushFinalBlock();
                        }
                        var ret = new StringBuilder();
                        foreach (byte b in ms.ToArray())
                        {
                            ret.AppendFormat("{0:X2}", b);
                        }
                        return ret.ToString();
                    }
                }
            }
            catch
            {
                return plainText;
            }
        }

        private static string GetRandom(int stringLength)
        {
            if (stringLength < 1 || stringLength > 8)
            {
                throw new ArgumentException("Length error(1-8)");
            }
            var ran = new Random(Guid.NewGuid().GetHashCode());
            long max = 1;
            for (int i = 0; i < stringLength; i++)
            {
                max *= 10;
            }
            return ran.Next((int)(max / 10), (int)(max - 1)).ToString();
        }
    }
}
