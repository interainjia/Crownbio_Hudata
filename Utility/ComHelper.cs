using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Crownbio.Model;
using Crownbio.Common;

namespace Crownbio.Utility
{
    /// <summary>
    /// ComHelper 的摘要说明
    /// </summary>
    public class ComHelper
    {
        public ComHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 获取代号部分
        /// </summary>
        /// <param name="tbx"></param>
        /// <returns></returns>
        public static string getKeyCode(TextBox tbx)
        {
            return MathHelper.getCode(tbx.Text.Trim());
            string keyCode = tbx.Text.Trim();
            int offset = keyCode.IndexOf("|");
            if (offset > 0)
            {
                keyCode = keyCode.Substring(0, offset);
            }
            return keyCode;
        }
        /// <summary>
        /// 获取代号部分
        /// </summary>
        /// <param name="tbx"></param>
        /// <returns></returns>
        public static string getKeyCode1(TextBox tbx)
        {
            string keyCode = tbx.Text.Trim();
            int offset = keyCode.IndexOf("|");
            if (offset > 0)
            {
                keyCode = keyCode.Substring(0, offset);
            }
            return keyCode;
        }

        /// <summary>
        /// 获取名称部分
        /// </summary>
        /// <param name="tbx"></param>
        /// <returns></returns>
        public static string getKeyName(TextBox tbx)
        {
            return MathHelper.getKeyName(tbx.Text.Trim());
            string keyCode = tbx.Text.Trim();
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

