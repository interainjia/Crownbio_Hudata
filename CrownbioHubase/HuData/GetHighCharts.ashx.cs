using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using iTextSharp.text;
using System.Collections;
using System.Web.Script.Serialization;
using Crownbio.BLL;
using Crownbio.Common;
using Crownbio.Model;
using Crownbio.Utility;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace PDXmodelBase.HuData
{
    /// <summary>
    /// GetHighCharts 的摘要说明
    /// </summary>
    public class GetHighCharts : IHttpHandler, IRequiresSessionState
    {
        ObjectBLL bll = new ObjectBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Method = context.Request.Params["M"];
            switch (Method)
            {
                case "showBWchart":
                    showBWchart(context);
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void showBWchart(HttpContext context)
        {
            List<dynamic> series = new List<dynamic>();
            try
            {
                string mid = context.Request["mid"].ToString();
                string a_num = context.Request["a_num"].ToString();
              
                ParamCollection paralist = new ParamCollection();
                paralist.Clause = ANIMAL_INFO_LOGS.MODEL_ID_FIELD + " = '" + mid + "' and DURATION > 0";
                if (a_num != "")
                {
                    string ids = "";
                    foreach (string a in a_num.Split(','))
                    {
                        if (a != "")
                        {
                            ids += "'" + a + "',";
                        }
                    }
                    paralist.Clause += string.Format("AND ({0}.{1} in ({2}) )", ANIMAL_INFO_LOGS.TABLE_NAME, "ANIMAL_NUMBER", ids.TrimEnd(','));
                }

                BaseList data = bll.Select(paralist, typeof(ANIMAL_INFO_LOGS));
                if (data.Count > 0)
                {
                    List<dynamic> xValue1 = new List<dynamic>();
                    List<dynamic> yValue1 = new List<dynamic>();
                    List<dynamic> animal = new List<dynamic>();
                    foreach (ANIMAL_INFO_LOGS row in data)
                    {
                        xValue1.Add(row.DURATION);
                        yValue1.Add(row.BODY_WEIGHT);
                        animal.Add(row.ANIMAL_NUMBER);
                    }
                    series.Add(new { x = xValue1, y = yValue1, animal = animal });
                }
            }
            catch(Exception ex)
            {
                context.Response.Write(ex.Message.ToString());
            }
            string dd = MStoJson(series);
            context.Response.Write(dd);
        }


        public string MStoJson(List<dynamic> dt)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Serialize(dt);
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }


        private void Write(ArrayList tb, string sPath)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (string dr in tb)
                {
                    sb.Append(dr);
                    sb.Append(System.Environment.NewLine);
                }
                byte[] s = System.Text.Encoding.UTF8.GetBytes(sb.ToString());

                //表名， 打开方式：新建/已存在则覆盖，访问方式：文件的写访问
                string p = sPath;
                FileStream fs = new FileStream(p, FileMode.Create, FileAccess.Write);
                fs.Write(s, 0, s.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}