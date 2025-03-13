using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Crownbio.Utility
{
    /// <summary>
    /// 提供对通用数据的格式正确性验证
    /// </summary>
    public class RegHelper
    {
        public const string DATE_MM_DD_YY = @"^(1[0-2]|0[1-9])/(([1-2][0-9]|3[0-1]|0[1-9])/\d\d)$";
        private static Regex RegNumber0 = new Regex("^[0-9]+$");//非负整数
        private static Regex RegNumber = new Regex("^[1-9]+$");//正整数
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");//正负整数
        private static Regex RegFloat = new Regex("^[0-9]+[.]?[0-9]+$");//@"^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$");//^[0-9]+[.]?[0-9]+$
        private static Regex RegDecimalSign = new Regex(@"^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$"); //"^[+-]?[0-9]+[.]?[0-9]+$"
        private static Regex RegEmail = new Regex("^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        private static string RegPhone = @"((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)";
        private static string RegTel = @"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$";
        private static string RegIdCard = @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";
        /// <summary>
        /// 正整数
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber0.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 非负整数验证
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsNumber0(string inputData)
        {
            Match m = RegNumber0.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 正负整数验证
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }


        /// <summary>
        /// 是否浮点数，包括整数及带小数位数值
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegNumber0.Match(inputData);
            if (!m.Success)
            {
                m = RegFloat.Match(inputData);
            }
            return m.Success;
        }

        /// <summary>
        /// 带正负号的浮点数
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否含有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 邮件地址检测
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 验证日期时间型数据
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static bool IsDateTime(string dateStr)
        {
            try
            {
                DateTime dt = DateTime.Parse(dateStr);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 手机检测
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsPhone(string inputPhone)
        {
            Match m = Regex.Match(inputPhone, RegPhone);//
            return m.Success;
        }
        /// <summary>
        /// 电话检测
        /// </summary>
        /// <param name="inputPhone"></param>
        /// <returns></returns>
        public static bool IsPhoneTEL(string inputPhone)
        {
            Match m = Regex.Match(inputPhone, RegTel);//
            return m.Success;
        }
        /// <summary>
        /// 身份证检测
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsIdCard(string inputData)
        {
            Match m = Regex.Match(inputData, RegIdCard);//
            return m.Success;
        }



    }
}
