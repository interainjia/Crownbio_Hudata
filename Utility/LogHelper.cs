using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Data.SqlClient;
using Crownbio.Model;



namespace Crownbio.Utility
{
    /// <summary>
    /// 通用日志处理器
    /// </summary>
    public class LogHelper
    {
        #region Logger
        private static log4net.ILog log = null;
        private static log4net.ILog logDB = null;

        /// <summary>
        /// 初始化日志
        /// </summary>
        private static void initConfigue()
        {
            if (log == null || logDB == null)
            {
                log4net.Config.XmlConfigurator.Configure();
                log = log4net.LogManager.GetLogger("ExceptionLogger");
                logDB = log4net.LogManager.GetLogger("DealLogger");
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
        /// 返回记录日志到数据库的Logger
        /// </summary>
        /// <returns></returns>
        public static log4net.ILog DBLogger()
        {
            initConfigue();
            return logDB;
        }

        #endregion

        #region 记录日志到文本文件中
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
            msgBuilder.Append("USER CODE=" + CacheHelper.getCurrentUser().USER_CODE + "\r\n");
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
                    //if (cmdParms[i].Value == null)
                    //{
                    //    parmsBuilder.Append("(" + cmdParms[i].DbType.ToString() + ")" + cmdParms[i].ParameterName + "=Null\r\n");
                    //}
                    //else
                    //{
                    parmsBuilder.Append("(" + cmdParms[i].DbType.ToString() + ")" + cmdParms[i].ParameterName + "=" + cmdParms[i].Value + "\r\n");
                    //}
                }
            }
            return parmsBuilder.ToString();
        }

        #endregion

        #region 记录日志到数据库中
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg"></param>
        public static void LogDB(string msg)
        {
            initConfigue();
            if (logDB.IsInfoEnabled)
            {
                logDB.Info(msg);
            }
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex"></param>
        public static void LogDB(Exception ex)
        {
            initConfigue();
            StringBuilder msgBuilder = new StringBuilder();
            msgBuilder.Append(ex.Message + "\r\n");
            msgBuilder.Append(ex.StackTrace + "\r\n");
            //msgBuilder.Append("USER CODE=" + CacheHelper.getCurrentUser().USER_CODE + "\r\n");
            logDB.Error(msgBuilder.ToString());
        }

        /// <summary>
        /// 异常信息，并加附加的信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="formatInfo"></param>
        public static void LogDB(Exception ex, string msg)
        {
            initConfigue();
            StringBuilder msgBuilder = new StringBuilder();
            msgBuilder.Append(ex.Message + "\r\n");
            msgBuilder.Append(ex.StackTrace + "\r\n");
            msgBuilder.Append(msg + "\r\n");
            //msgBuilder.Append("USER CODE=" + CacheHelper.getCurrentUser().USER_CODE + "\r\n");
            logDB.Error(msgBuilder.ToString());
        }

        /// <summary>
        /// 将SQL语句及其参数写入日志信息中
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="msg"></param>
        /// <param name="cmdParms"></param>
        public static void LogDB(Exception ex, string msg, params SqlParameter[] cmdParms)
        {
            initConfigue();
            StringBuilder msgBuilder = new StringBuilder();
            msgBuilder.Append(ex.Message + "\r\n");
            msgBuilder.Append(ex.StackTrace + "\r\n");
            msgBuilder.Append(msg + "\r\n");
            msgBuilder.Append(ParseParms(cmdParms) + "\r\n");
            //  msgBuilder.Append("USER CODE=" + CacheHelper.getCurrentUser().USER_CODE + "\r\n");
            logDB.Error(msgBuilder.ToString());
        }

        /// <summary>
        /// 记录操作信息
        /// </summary>
        /// <param name="deal"></param>
        /// <param name="sql"></param>
        public static void LogDB(string deal, string msg)
        {
            initConfigue();
            StringBuilder msgBuilder = new StringBuilder();
            msgBuilder.Append(msg + "\r\n");
            //  msgBuilder.Append("USER CODE=" + CacheHelper.getCurrentUser().USER_CODE + "\r\n");
            msgBuilder.Append(deal + "\r\n");
            logDB.Info(msgBuilder.ToString());
        }

        /// <summary>
        /// 记录带参数的操作信息
        /// </summary>
        /// <param name="deal"></param>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        public static void LogDB(string deal, string msg, params SqlParameter[] cmdParms)
        {
            initConfigue();
            StringBuilder msgBuilder = new StringBuilder();
            msgBuilder.Append(msg + "\r\n");
            //  msgBuilder.Append("USER CODE=" + CacheHelper.getCurrentUser().USER_CODE + "\r\n");
            msgBuilder.Append(deal + "\r\n");
            msgBuilder.Append(ParseParms(cmdParms));
            logDB.Info(msgBuilder.ToString());
        }


        #endregion

        #region 使用Logging Application Block进行Log

        /// <summary>
        /// 使用Logging Application Block进行Log
        /// </summary>
        /// <param name="sql"></param>
        public static void WriteLogToDB(string sql)
        {
            LogEntry log = new LogEntry();
            log.Message = sql;
            log.EventId = 2000;
            log.Priority = 2;

            log.Title = "aaaa";
            log.Categories.Add("LOGCategory");
            Logger.Write(log);
        }

        #endregion
    }
}
