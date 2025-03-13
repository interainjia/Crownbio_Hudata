using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Crownbio.Common;
using Crownbio.Model;
using System.Text.RegularExpressions;

namespace Crownbio.Utility
{
    /// <summary>
    /// 提供格式化的各类方法
    /// </summary>
    public class FormatHelper
    {
        /// <summary>
        /// 获取指定窗体及栏位的格式化字符串
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static string getFormat(string Code, string formName)
        {
            //DataView dv = CacheHelper.getDigitData().Tables[0].DefaultView;
            //dv.RowFilter = "FORM_NAME='" + formName + "' AND COLUMN_CODE='" + Code + "'";

            string format = "0";//"#,#,0.00";
            //if (dv.Count > 0)
            //{
            //    decimal digit = (decimal)dv[0]["DIGIT_LEN"];
            //    format = "0";
            //    if (digit > 0)
            //    {
            //        format = "0.";
            //        decimal len = 0;
            //        while (len < digit)
            //        {
            //            format = format + "0";
            //            len = len + 1;
            //        }
            //    }
            //}
            return format;

        }

        /// <summary>
        /// 获取指定栏位的格式化字符串
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static string getFormat(string Code)
        {
            return getFormat(Code, "N");
        }

        /// <summary>
        /// 返回栏位小数位数
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static int getDigitLen(string Code, string formName)
        {
            BaseList dv = CacheHelper.getDigitData();
            BASE_DIGIT _row = (BASE_DIGIT)dv.Find(delegate (BaseObject _c) { return ((BASE_DIGIT)_c).FORM_NAME == formName && ((BASE_DIGIT)_c).COLUMN_CODE == Code; });

            int len = 2;
            if (_row != null)
            {
                decimal digit = _row.DIGIT_LEN;
                len = (int)digit;
            }
            return len;
        }

        /// <summary>
        /// 返回指定栏位小数位
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static int getDigitLen(string Code)
        {
            return getDigitLen(Code, "N");
        }

        /// <summary>
        /// 将数值格式为指定栏位的小数位数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="Code"></param>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static decimal getFormatDecimal(decimal value, string Code, string formName)
        {
            return MathHelper.Round(value, getDigitLen(Code, formName));
        }

        /// <summary>
        /// 将数值格式化为指定栏位的小数位数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static decimal getFormatDecimal(decimal value, string Code)
        {
            return MathHelper.Round(value, getDigitLen(Code));
        }

        /// <summary>
        /// 将对像格式化为指定位数小数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="Code"></param>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static decimal getFormatDecimal(Object value, string Code, string formName)
        {
            return MathHelper.Round(value, getDigitLen(Code, formName));
        }

        /// <summary>
        /// 将数值格式化为指定位数小数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static decimal getFormatDecimal(Object value, string Code)
        {
            return MathHelper.Round(value, getDigitLen(Code));
        }

        /// <summary>
        /// 返回日期字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string getFormatDate(Object value)
        {
            if (((DateTime)value) != DateTime.MinValue)
            {
                return ((DateTime)value).ToString(Const.dateFormat);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 返回日期时间字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string getFormatDateTime(Object value)
        {
            return ((DateTime)value).ToString(Const.datetimeFormat);
        }


        /**/
        /// <summary>
        /// 求某年有多少周
        /// 返回 int
        /// </summary>
        /// <param name="strYear"></param>
        /// <returns>int</returns>
        public static int GetYearWeekCount(int strYear)
        {
            System.DateTime fDt = DateTime.Parse(strYear.ToString() + "-01-01");
            int k = Convert.ToInt32(fDt.DayOfWeek);//得到该年的第一天是周几 
            if (k == 1)
            {
                int countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                int countWeek = countDay / 7 + 1;
                return countWeek;

            }
            else
            {
                int countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                int countWeek = countDay / 7 + 2;
                return countWeek;
            }

        }

        /**/
        /// <summary>
        /// 求当前日期是一年的中第几周
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int WeekOfYear(DateTime curDay)
        {
            int firstdayofweek = Convert.ToInt32(Convert.ToDateTime(curDay.Year.ToString() + "- " + "1-1 ").DayOfWeek);

            int days = curDay.DayOfYear;
            int daysOutOneWeek = days - (7 - firstdayofweek);

            if (daysOutOneWeek <= 0)
            {
                return 1;
            }
            else
            {
                int weeks = daysOutOneWeek / 7;
                if (daysOutOneWeek % 7 != 0)
                    weeks++;

                return weeks + 1;

            }

        }
        /// <summary>
        /// 转换Json 换行符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string doTran(string str)
        {
            str = str.Replace("\\", "\\\\");
            str = str.Replace("\r", "\\r");
            str = str.Replace("\n", "\\n");
            str = str.Replace("\t", "\\t");
            str = str.Replace("\"", "'");
            return str;
        }

        /// <summary>
        /// 正则去除空字符tab,空格,换行符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string doRemoveEmpty(string str)
        {
            str = Regex.Replace(str, @"\s", "");
            return str;
        }
    }
}
