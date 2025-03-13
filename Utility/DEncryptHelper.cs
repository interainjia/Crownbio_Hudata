using System;
using System.Collections.Generic;
using System.Text;
using LTP.Common.DEncrypt;

namespace Crownbio.Utility
{
    public class DEncryptHelper
    {
        private static string _keys = "www.ZebraSoft.com.cnCopyRight2005-2008";
        private const string symmProvider = "RijndaelManaged";

        /// <summary>
        /// 加密数据源
        /// </summary>
        /// <param name="source">加密前的字符串数据</param>
        /// <returns>密文数据</returns>
        public static string Encrypt(string source)
        {
            return DESEncrypt.Encrypt(source, _keys);
            //return Cryptographer.EncryptSymmetric(symmProvider, source);
        }

        /// <summary>
        /// 解密数据
        /// </summary>
        /// <param name="source">密文数据</param>
        /// <returns>解密后数据</returns>
        public static string Decrypt(string source)
        {
            return DESEncrypt.Decrypt(source, _keys);
            //return Cryptographer.DecryptSymmetric(symmProvider, source);
        }
    }
}
