using System;
using System.Collections.Generic;
using System.Text;

namespace Crownbio.Common
{
    public class Const
    {
        /// <summary>
        /// 自动ID Default值
        /// </summary>
        public const decimal PID = -1;

        /// <summary>
        /// CODE值
        /// </summary>
        public const string PCODE = "";

        /// <summary>
        /// Decimal值
        /// </summary>
        public const decimal PDecimal = -1;

        /// <summary>
        /// 默认时间
        /// </summary>
        public static DateTime PDate
        {
            get { return new DateTime(1900, 1, 1).AddDays(1); }
        }


        public const string rootCode = "0000000";

        /// <summary>
        /// 日期格式
        /// </summary>
        public const string dateFormat = "yyyy/MM/dd";

        /// <summary>
        /// 日期时间格式
        /// </summary>
        public const string datetimeFormat = "yyyy/MM/dd HH:mm:ss";

    }
}
