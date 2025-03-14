using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crownbio.Language;
using Crownbio.DAL;
using Crownbio.Utility;
using Crownbio.Common;
using Crownbio.Model;
using System.Drawing;

namespace Crownbio.BLL
{
    public class ObjectBLLHelper
    {
        /// <summary>
        /// 生成并缓存一个DALObject访问对像
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static DALObject getTypeDAL(Type dataType)
        {
            if (CacheHelper.getCacheData(dataType.ToString()) != null)
            {
                try
                {
                    return (DALObject)CacheHelper.getCacheData(dataType.ToString());
                }
                catch
                {

                    DALObject dal = new DALObject(dataType);
                    LogHelper.Log("Generate the DAL For " + dataType.ToString());
                    CacheHelper.setCacheData(dataType.ToString(), dal);
                    return dal;
                }
            }
            else
            {
                DALObject dal = new DALObject(dataType);
                LogHelper.Log("Generate the DAL For " + dataType.ToString());
                CacheHelper.setCacheData(dataType.ToString(), dal);
                return dal;
            }
        }

        /// <summary>
        /// 根据动态页面地址返回生成的静态页的文件名
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public static string genHtml(string URL, string path, string fileName, string encoding)
        {
            string msg = "URL=" + URL + ";PATH=" + path + ";FILENAME=" + fileName + ";ENCODING=" + encoding;
            Crownbio.Utility.LoggingHelper.Log(msg);
            StreamWriter fs = null;
            string FileName = fileName;
            if (FileName == "" || FileName.ToString().ToUpper() == "NULL")
            {
                ObjectBLL bll = new ObjectBLL();
                FileName = bll.GetSysNo("ZF") + ".html";
            }
            try
            {
                StringWriter sw = new StringWriter();
                System.Web.HttpContext.Current.Server.Execute(URL, sw);
                string content = sw.ToString();

                fs = new StreamWriter(path + FileName, false, Encoding.GetEncoding(encoding));
                fs.WriteLine(content);
                sw.Close();
            }
            catch (Exception ex)
            {
                Crownbio.Utility.LoggingHelper.Log(ex.Message);
                Crownbio.Utility.LoggingHelper.Log(ex);
            }
            finally
            {
                try
                {
                    fs.Close();
                }
                catch
                {
                }

            }
            return FileName;
        }
    }
}
