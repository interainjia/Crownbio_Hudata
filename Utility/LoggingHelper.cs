using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Data.SqlClient;

namespace Crownbio.Utility
{
    /// <summary>
    /// 提供日志记录的通用方法
    /// </summary>
    public class LoggingHelper
    {
        #region log4net
        private static log4net.ILog log = null;

        /// <summary>
        /// 初始化日志器
        /// </summary>
        private static void initConfigue()
        {
            if (log == null)
            {
                log4net.Config.XmlConfigurator.Configure();
                log = log4net.LogManager.GetLogger("ExceptionLogger");
            }
        }

        /// <summary>
        /// 返回记录日志到文件的Logger
        /// </summary>
        public static log4net.ILog FileLogger()
        {
            initConfigue();
            return log;
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Log(string msg)
        {
            initConfigue();
            if (log.IsInfoEnabled)
            {
                log.Info(msg);
            }
        }


        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex"></param>
        public static void Log(Exception ex)
        {
            initConfigue();
            StringBuilder msgBuilder = new StringBuilder();
            msgBuilder.Append(ex.Message + "\r\n");
            msgBuilder.Append(ex.StackTrace + "\r\n");
            //msgBuilder.Append("USER CODE=" + CacheHelper.getCurrentUser().USER_CODE + "\r\n");
            log.Error(msgBuilder.ToString());
        }

        /// <summary>
        /// 异常信息，并加附加的信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="formatInfo"></param>
        public static void Log(Exception ex, string msg)
        {
            initConfigue();
            StringBuilder msgBuilder = new StringBuilder();
            msgBuilder.Append(ex.Message + "\r\n");
            msgBuilder.Append(ex.StackTrace + "\r\n");
            msgBuilder.Append(msg + "\r\n");
            //msgBuilder.Append("USER CODE=" + CacheHelper.getCurrentUser().USER_CODE + "\r\n");
            log.Error(msgBuilder.ToString());
        }

        /// <summary>
        /// 将SQL语句及其参数写入日志信息中
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="msg"></param>
        /// <param name="cmdParms"></param>
        public static void Log(Exception ex, string msg, params SqlParameter[] cmdParms)
        {
            initConfigue();
            StringBuilder msgBuilder = new StringBuilder();
            msgBuilder.Append(ex.Message);
            msgBuilder.Append(ex.StackTrace);
            msgBuilder.Append(msg);
            msgBuilder.Append(ParseParms(cmdParms));
            //msgBuilder.Append("USER CODE=" + CacheHelper.getCurrentUser().USER_CODE + "\r\n");
            log.Error(msgBuilder.ToString());
        }

        /// <summary>
        /// 将参数转换成指定格式的字符串
        /// </summary>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        private static string ParseParms(params SqlParameter[] cmdParms)
        {
            StringBuilder parmsBuilder = new StringBuilder();
            parmsBuilder.Append("PARAMETERS:\r\n");
            if (cmdParms != null && cmdParms.Length > 0)
            {
                for (int i = 0; i < cmdParms.Length; i++)
                {
                    parmsBuilder.Append("(" + cmdParms[i].DbType.ToString() + ")" + cmdParms[i].ParameterName + "=" + cmdParms[i].Value + "\r\n");
                }
            }
            return parmsBuilder.ToString();
        }


        public static void LogDB(string title, string Message)
        {
            initConfigue();
            StringBuilder msgBuilder = new StringBuilder();
            msgBuilder.Append(title + "\r\n");
            msgBuilder.Append(Message + "\r\n");
            //msgBuilder.Append("USER CODE=" + CacheHelper.getCurrentUser().USER_CODE + "\r\n");
            log.Error(msgBuilder.ToString());
        }

        public static void LogDB(string title, string Message, params SqlParameter[] cmdParms)
        {
            initConfigue();
            StringBuilder msgBuilder = new StringBuilder();
            msgBuilder.Append(title + "\r\n");
            msgBuilder.Append(Message + "\r\n");
            msgBuilder.Append(ParseParms(cmdParms) + "\r\n");
            //msgBuilder.Append("USER CODE=" + CacheHelper.getCurrentUser().USER_CODE + "\r\n");
            log.Error(msgBuilder.ToString());
        }

        #endregion





    }
}
