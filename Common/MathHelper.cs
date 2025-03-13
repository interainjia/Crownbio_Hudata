using System;
using System.Collections.Generic;
using System.Text;

namespace Crownbio.Common
{
    public class MathHelper
    {
        /// <summary>
        /// 将数值转换为指定位数的小数
        /// </summary>
        /// <param name="d"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static decimal Round(decimal d, int decimals)
        {
            int num1 = 1;
            for (int i = 0; i < decimals + 1; i++)
                num1 *= 10;
            decimal num2 = 5M / num1;

            if (d < 0)
                d += (-1 * num2);
            else
                d += num2;

            int dotpos = d.ToString().IndexOf(".");
            if (dotpos == -1)
                return d;

            return Convert.ToDecimal(d.ToString().Substring(0, dotpos + 1 + decimals));
        }

        /// <summary>
        /// 将Object类型的值进行转换，并返回指定位数的数值
        /// </summary>
        /// <param name="d"></param>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static decimal Round(object decimalValue, int decimals)
        {
            decimal value = Convert.ToDecimal(decimalValue);
            return Round(value, decimals);
        }

        /// <summary>
        /// 返回代码
        /// </summary>
        /// <param name="codeName"></param>
        /// <returns></returns>
        public static string getCode(string codeName)
        {
            string keyCode = codeName;
            int offset = codeName.IndexOf("|");
            if (offset > 0)
            {
                keyCode = codeName.Substring(0, offset);
            }
            return keyCode;
        }

        /// <summary>
        /// 返回名称
        /// </summary>
        /// <param name="codeName"></param>
        /// <returns></returns>
        public static string getKeyName(string codeName)
        {
            string keyCode = codeName;
            int offset = keyCode.IndexOf("|");
            if (offset > 0)
            {
                keyCode = keyCode.Substring(offset + 1, keyCode.Length - offset - 1);
            }
            else
            {
                keyCode = "";
            }
            return keyCode;
        }

    }
}
