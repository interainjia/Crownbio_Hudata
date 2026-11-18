using System;
using System.Security.Cryptography;

namespace Crownbio.Utility
{
    /// <summary>
    /// 用户密码单向哈希：PBKDF2-HMAC-SHA256 + 每个密码独立的随机 salt。
    /// 存储格式：PBKDF2${迭代次数}${salt(Base64)}${hash(Base64)}，约 80 个字符。
    /// 兼容旧数据：不是该格式的值视为旧版 DEncryptHelper（可逆 DES）密文，校验时解密比对，
    /// 调用方应在校验成功后用 <see cref="NeedsRehash"/> 判断并重新哈希保存。
    /// </summary>
    public static class PasswordHasher
    {
        private const string Prefix = "PBKDF2$";
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int DefaultIterations = 100000;

        /// <summary>
        /// 生成密码哈希（每次调用 salt 都不同）
        /// </summary>
        public static string Hash(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            byte[] hash = Derive(password, salt, DefaultIterations, HashSize);
            return Prefix + DefaultIterations + "$" + Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(hash);
        }

        /// <summary>
        /// 校验明文密码与数据库中保存的值是否匹配（支持新格式哈希与旧版 DES 密文）
        /// </summary>
        public static bool Verify(string password, string stored)
        {
            if (password == null || string.IsNullOrEmpty(stored))
            {
                return false;
            }
            if (IsHashed(stored))
            {
                string[] parts = stored.Split('$');
                if (parts.Length != 4 || !int.TryParse(parts[1], out int iterations) || iterations <= 0)
                {
                    return false;
                }
                byte[] salt;
                byte[] expected;
                try
                {
                    salt = Convert.FromBase64String(parts[2]);
                    expected = Convert.FromBase64String(parts[3]);
                }
                catch (FormatException)
                {
                    return false;
                }
                byte[] actual = Derive(password, salt, iterations, expected.Length);
                return FixedTimeEquals(actual, expected);
            }

            // 旧版：可逆 DES 密文
            string legacyPlain = TryDecryptLegacy(stored);
            return legacyPlain != null && FixedTimeEquals(
                System.Text.Encoding.UTF8.GetBytes(legacyPlain),
                System.Text.Encoding.UTF8.GetBytes(password));
        }

        /// <summary>
        /// 已保存的值是否为新格式哈希
        /// </summary>
        public static bool IsHashed(string stored)
        {
            return stored != null && stored.StartsWith(Prefix, StringComparison.Ordinal);
        }

        /// <summary>
        /// 已保存的值是否需要重新哈希（旧版 DES 密文，或迭代次数低于当前默认值）
        /// </summary>
        public static bool NeedsRehash(string stored)
        {
            if (!IsHashed(stored))
            {
                return true;
            }
            string[] parts = stored.Split('$');
            return parts.Length != 4 || !int.TryParse(parts[1], out int iterations) || iterations < DefaultIterations;
        }

        /// <summary>
        /// 尝试把旧版 DES 密文解密为明文，失败返回 null（仅用于兼容和数据迁移）
        /// </summary>
        public static string TryDecryptLegacy(string stored)
        {
            if (string.IsNullOrEmpty(stored) || IsHashed(stored))
            {
                return null;
            }
            try
            {
                return DEncryptHelper.Decrypt(stored);
            }
            catch
            {
                return null;
            }
        }

        private static byte[] Derive(string password, byte[] salt, int iterations, int length)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(length);
            }
        }

        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            int diff = a.Length ^ b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }
            return diff == 0;
        }
    }
}
