using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using OpenFlashChart;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Crownbio.BLL;
using Crownbio.Common;
using Crownbio.Utility;
using Crownbio.Model;
using System.Data.OleDb;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using OpenFlashChart;

namespace PDXmodelBase.HuData
{
    public partial class Workload : System.Web.UI.Page
    {
        ObjectBLL bll = new ObjectBLL();
        public string hlGeneSymbol = "";
        public string hlRefSeqProteinID = "";
        public string hlRefSeqTranscriptID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SYS_USER userLogin = CacheHelper.getCurrentUser();
                if (!userLogin.IS_Login)
                {
                    Response.Write(" <script language='javascript'>top.location.href='../ErrorMsg.aspx?LoginType=1'</script>");
                    return;
                }
                bool havePerm = ojbReportRule.GetUserFunctions(userLogin.Permission, "Workload", "view");
                if (!havePerm)
                {
                    Response.Write(" <script language='javascript'>location.href='../Error.aspx?LoginType=2'</script>");
                    return;
                }
                if (Request.QueryString["M"] == "workload")
                {

                    show(Request["txtName"].ToString(), Request["cbxDep"].ToString());
                }
                //DTgroup_workload();
                //DM_workload();
            }
        }
        public void show(string txtName, string cbxDep)
        {
            string genedata = "";
            OpenFlashChart.OpenFlashChart chart = new OpenFlashChart.OpenFlashChart();
            ArrayList list = new ArrayList();

            List<string> data = new List<string>(txtName.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
            IEnumerable<string> datalist = data.Distinct();
            genedata = "";
            foreach (string a in datalist)
            {
                genedata += a + ",";
            }
            genedata = genedata.TrimEnd(',');
            List<string> al = new List<string>();

            String[] colors = {  "#FF0000","#F75D59","#FF00FF","#9F35FF","#4A4AFF","#0080FF","#00E3E3","#02F78E", 
                              "#00EC00","#6CC417","#F9F900","#977C00","#FFA042","#FF5809","#7D2252","#AD5A5A","#949449",
                              "#4F9D9D","#5A5AAD","#AE57A4","#951411","#FF0080","#0000E3","#00FFFF","#7AFEC6","#A6FFA6",
                              "#CCFF80","#FFFF93","#FFE66F","#FFC78E","#FFAD86","#CF9E9E","#95CACA","#8F4586"
                              };

            List<double> maxYlist = new List<double>();
            for (int j = 0; j < genedata.Split(',').Length; j++)
            {
                string ProbeSet = genedata.Split(',')[j].Trim();

                //DataTable dt1 = new DataTable();
                if (ProbeSet != "")
                {
                    ParamCollection paralist = new ParamCollection();
                    paralist.Clause = cbxDep + "='" + ProbeSet + "'";
                    List<PROJECT_MONITOR> workdata = bll.Select(paralist, typeof(PROJECT_MONITOR)).ConvertAll<PROJECT_MONITOR>(PROJECT_MONITOR.Convert);
                    if (workdata.Count > 0)
                    {
                        List<LineDotValue> values = new List<LineDotValue>();

                        int mm = FormatHelper.GetYearWeekCount(DateTime.Now.Year);

                        for (int m = 0; m <= mm; m += 2)
                        {
                            List<PROJECT_MONITOR> workload = workdata.FindAll(delegate(PROJECT_MONITOR perm) { return FormatHelper.WeekOfYear(perm.DOI) <= m && FormatHelper.WeekOfYear(perm.DOI) > m - 2; });
                            if (workload.Count > 0)
                            {
                                double sum = 0;
                                foreach (PROJECT_MONITOR row in workload)
                                {
                                    if (cbxDep == "SD" || cbxDep == "JSD")
                                    {
                                        sum += row.ARMS;
                                    }
                                    else if (cbxDep == "DM")
                                    {
                                        sum += double.Parse(row.DM_WORKLOAD.ToString());
                                    }
                                    else if (cbxDep == "DT")
                                    {
                                        sum += double.Parse(row.DT_TEAM_WORKLOAD.ToString());
                                    }
                                }
                                maxYlist.Add(Math.Ceiling(sum));
                                LineDotValue bv = new LineDotValue(sum);

                                bv.Color = "#FF0000";
                                if (sum != 0)
                                {
                                    bv.Tip = "Workload:" + sum + "<br>" + "Week of Year:" + m.ToString();
                                    values.Add(bv);
                                }
                            }
                            else
                            {
                                values.Add(null);
                            }
                            al.Add(m.ToString());
                        }

                        //Bar图的设置
                        OpenFlashChart.LineScatter bar = new LineScatter();
                        //bar.Text = "Bar的说明";
                        bar.Values = values;
                        //bar.BarType = BarType.BAR_FILLED;
                        //bar.Tooltip = "Tumor Model:#x_label#" + "<br>" + "Gene:" + genedata.Split(',')[j] + "<br>" + "Cancer Type:" + "?" + "<br>" + "Gene Expression:#val#";
                        //bar.OnShowAnimation = new Animation("grow-up", 1, 0.2);
                        chart.AddElement(bar);
                    }
                    else
                    {
                        chart.Bgcolor = "FFFFFF";
                        chart.Title = new Title(cbxDep + " Workload");
                        chart.Title.Style = "font-size:12px;color:#0000ff;font-weight:bold";
                        Response.Clear();
                        Response.CacheControl = "no-cache";
                        Response.Write(chart.ToPrettyString());
                        Response.End();
                    }
                }
                else
                {
                    chart.Bgcolor = "FFFFFF";
                    chart.Title = new Title(cbxDep + " Workload");
                    chart.Title.Style = "font-size:12px;color:#0000ff;font-weight:bold";
                    Response.Clear();
                    Response.CacheControl = "no-cache";
                    Response.Write(chart.ToPrettyString());
                    Response.End();
                }
            }

            chart.X_Axis.Labels.SetLabels(new List<string>());
            chart.X_Axis.Labels.SetLabels(al);
            chart.X_Legend = new Legend("Week of Year");


            //chart.X_Axis.Labels.Rotate = "-80";
            chart.Y_Axis.Offset = false;
            string title = cbxDep + "-" + txtName + " Workload";
            chart.Title = new Title(title);
            chart.X_Legend.Style = "font-size:12px;color:#0000ff;font-weight:bold";
            chart.Y_Legend = new Legend("Workload");
            chart.Y_Legend.Style = "font-size:12px;color:#0000ff;font-weight:bold";
            chart.Y_Axis.Max = maxYlist.Max();
            //chart.Y_Axis.Steps = 0.5;

            chart.Bgcolor = "FFFFFF";

            chart.Title.Style = "font-size:12px;color:#0000ff;";
            Response.Clear();
            Response.CacheControl = "no-cache";
            Response.Write(chart.ToPrettyString());
            Response.End();

        }


        #region //算分钟
        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public double SearchRoute(List<PROJECT_MONITOR_DOSING_ROUTE> data, string codes)
        {
            double time = 0;
            foreach (string code in codes.Split(','))
            {
                PROJECT_MONITOR_DOSING_ROUTE ds = data.Find(delegate(PROJECT_MONITOR_DOSING_ROUTE perm) { return perm.CODE == code; });
                if (ds != null)
                {
                    time += double.Parse(ds.UNIT_TIME);
                }
               
            }
            return time;
        }
        #endregion



        public void saveDM_work(PROJECT_MONITOR row, string role, string person, double workload, DateTime day, string phase, BaseList newGroupData)
        {
            PROJECT_MONITOR_DM_WORKLOAD newday = new PROJECT_MONITOR_DM_WORKLOAD(DealModel.New);
            newday.PROJECT_MONITOR_ID = row.PROJECT_MONITOR_ID;
            newday.SUB_PROJECT = row.PROJECT_NUMBER;
            newday.MODEL_ID = row.MODEL_ID;
            newday.ROLE_NAME = role;
            newday.PERSON = person;
            newday.STUDY_DESIGN_DAY = day;
            newday.STUDY_WORKLOAD = workload;
            newday.DM = row.DM;
            newday.PHASE = phase;
            newGroupData.Add(newday);
        }

        //public void DM_workload()
        //{
        //    string role = "DM";
        //    string person = "bai yuyang";
        //    List<PROJECT_MONITOR_DOSING_ROUTE> dataRoute = bll.Select(typeof(PROJECT_MONITOR_DOSING_ROUTE)).ConvertAll<PROJECT_MONITOR_DOSING_ROUTE>(PROJECT_MONITOR_DOSING_ROUTE.Convert);

        //    ParamCollection paraList = new ParamCollection();
        //    paraList.Clause = PROJECT_MONITOR.DM_FIELD + "='" + person + "' and Order_Animal <> ''";
        //    BaseList allData = bll.Select(paraList, typeof(PROJECT_MONITOR));
        //    foreach (PROJECT_MONITOR row in allData)
        //    {
        //        BaseList newGroupData = new BaseList();
        //        double time = 1;//1天1次
        //        if (row.TUMOR_MONITOR_SCHEDULE == "TID")//1天3次
        //        {
        //            time = 3;
        //        }
        //        else if (row.TUMOR_MONITOR_SCHEDULE == "BID")//1天2次
        //        {
        //            time = 2;
        //        }

        //        #region 计算mice_number
        //        double mice_number = 0;
        //        ParamCollection paraList2 = new ParamCollection();
        //        paraList2.Clause = PROJECT_MONITOR_STUDY_DESIGN.PROJECT_MONITOR_ID_FIELD + "='" + row.PROJECT_MONITOR_ID + "'";
        //        BaseList dataGroup = bll.Select(paraList2, typeof(PROJECT_MONITOR_STUDY_DESIGN));

        //        if (dataGroup.Count > 0)
        //        {
        //            foreach (PROJECT_MONITOR_STUDY_DESIGN dr in dataGroup)
        //            {
        //                mice_number += int.Parse(dr.MICE_GROUP);
        //            }
        //        }
        //        #endregion

        //        #region 计算beforeGroup5,6,7,8,9,10,11,12
        //        for (int i = 0; i < 8; i++)
        //        {
        //            string day2 = "";
        //            string phase = "";
        //            if (i == 0)
        //            {
        //                day2 = row.ORDER_ANIMAL;
        //                phase = "5";
        //            }
        //            else if (i == 1)
        //            {
        //                day2 = row.FINALIZE_PROTOCOL;
        //                phase = "6";
        //            }
        //            else if (i == 2)
        //            {
        //                day2 = row.PROVIDE_SEEDING_ANIMAL;
        //                phase = "7";
        //            }
        //            else if (i == 3)
        //            {
        //                day2 = row.INOCULATION;
        //                phase = "8";
        //            }
        //            else if (i == 4)
        //            {
        //                day2 = row.RANDOMIZATION;
        //                phase = "9";
        //            }
        //            else if (i == 5)
        //            {
        //                day2 = row.TREATMENT_START;
        //                phase = "10";
        //            }
        //            else if (i == 6)
        //            {
        //                day2 = row.TREATMENT_FINISHED;
        //                phase = "11";
        //            }
        //            else if (i == 7)
        //            {
        //                day2 = row.OBSERVATION_POST_TREATMENT;
        //                phase = "12";
        //            }


        //            if (RegHelper.IsDateTime(day2))
        //            {
                       
        //                DateTime day = DateTime.Parse(day2);
        //                double workload = 0;
        //                if (phase == "5" || phase == "6" || phase == "7")
        //                {
        //                    workload = SearchRoute(dataRoute, "1.07") * row.NUMBER_OF_ANIMAL_PURCHASE * time;
        //                }
        //                else if (phase == "8" || phase == "9")
        //                {
        //                    workload = SearchRoute(dataRoute, "1.04") * row.NUMBER_OF_ANIMAL_INOCULATION * time;
        //                    if (phase == "8")
        //                    {
        //                        workload += SearchRoute(dataRoute, "1.03") * row.NUMBER_OF_ANIMAL_PURCHASE;
        //                    }
        //                }
        //                else if (phase == "10" || phase == "11" || phase == "12")
        //                {
        //                    workload = SearchRoute(dataRoute, "1.05") * mice_number * time;
        //                }
                      

        //                #region Q2D,Q3D,Q4D//每2天1次,每3天1次,每4天1次
        //                if (row.TUMOR_MONITOR_SCHEDULE == "Q2D" || row.TUMOR_MONITOR_SCHEDULE == "Q3D" || row.TUMOR_MONITOR_SCHEDULE == "Q4D")
        //                {
        //                    for (int d = 0; d < period; d++)
        //                    {
        //                        PROJECT_MONITOR_DM_WORKLOAD newday = new PROJECT_MONITOR_DM_WORKLOAD(DealModel.New);
        //                        newday.PROJECT_MONITOR_ID = row.PROJECT_MONITOR_ID;
        //                        newday.SUB_PROJECT = row.PROJECT_NUMBER;
        //                        newday.MODEL_ID = row.MODEL_ID;
        //                        newday.ROLE_NAME = role;
        //                        newday.PERSON = person;
        //                        if (row.TUMOR_MONITOR_SCHEDULE == "Q2D")
        //                        {
        //                            newday.STUDY_DESIGN_DAY = day.AddDays(i * 2);
        //                        }
        //                        else if (row.TUMOR_MONITOR_SCHEDULE == "Q3D")
        //                        {
        //                            newday.STUDY_DESIGN_DAY = day.AddDays(i * 3);
        //                        }
        //                        else if (row.TUMOR_MONITOR_SCHEDULE == "Q3D")
        //                        {
        //                            newday.STUDY_DESIGN_DAY = day.AddDays(i * 4);
        //                        }
        //                        newday.STUDY_WORKLOAD = workload;
        //                        newday.DM = row.DM;
        //                        newday.PHASE = phase;
        //                        newGroupData.Add(newday);
        //                    }
        //                }
        //                #endregion

        //                #region 5 Days on and 2 days off//每天一次，固定在Monday/Tuesday开始。按照Date of treatment自动选择
        //                else if (row.TUMOR_MONITOR_SCHEDULE == "5 Days on and 2 days off")
        //                {
        //                    int totalDay = period * 7;
        //                    for (int d = 0; d < totalDay; d++)
        //                    {
        //                        if (day.AddDays(d).DayOfWeek != DayOfWeek.Saturday && day.AddDays(d).DayOfWeek != DayOfWeek.Sunday)
        //                        {
        //                            saveDM_work(row, role, person, workload, day.AddDays(d), phase, newGroupData);
        //                        }

        //                    }
        //                }
        //                #endregion

        //                #region TIW//每周三次，固定在Monday, Wednesday, Friday。按照Date of treatment自动选择
        //                else if (row.TUMOR_MONITOR_SCHEDULE == "TIW")
        //                {
        //                    int totalDay = period * 7;
        //                    for (int d = 0; d < totalDay; d++)
        //                    {
        //                        if (day.AddDays(d).DayOfWeek == DayOfWeek.Monday || day.AddDays(d).DayOfWeek == DayOfWeek.Friday || day.AddDays(d).DayOfWeek == DayOfWeek.Wednesday)
        //                        {
        //                            saveDM_work(row, role, person, workload, day.AddDays(d), phase, newGroupData);
        //                        }
        //                    }
        //                }
        //                #endregion

        //                #region BIW//每周两次，固定在Monday/Thursday或Tuesday/Friday。按照Date of treatment自动选择
        //                else if (row.TUMOR_MONITOR_SCHEDULE == "BIW")
        //                {
        //                    int totalDay = period * 7;
        //                    if (day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Thursday)
        //                    {
        //                        for (int d = 0; d < totalDay; d++)
        //                        {
        //                            if (day.AddDays(d).DayOfWeek == DayOfWeek.Monday || day.AddDays(d).DayOfWeek == DayOfWeek.Thursday)
        //                            {
        //                                saveDM_work(row, role, person, workload, day.AddDays(d), phase, newGroupData);
        //                            }
        //                        }
        //                    }
        //                    else if (day.DayOfWeek == DayOfWeek.Tuesday || day.DayOfWeek == DayOfWeek.Friday)
        //                    {
        //                        for (int d = 0; d < totalDay; d++)
        //                        {
        //                            if (day.AddDays(d).DayOfWeek == DayOfWeek.Tuesday || day.AddDays(d).DayOfWeek == DayOfWeek.Friday)
        //                            {
        //                                saveDM_work(row, role, person, workload, day.AddDays(d), phase, newGroupData);
        //                            }
        //                        }
        //                    }
        //                }
        //                #endregion

        //                #region QW//每周一次，固定在Date of treatment当天。按照Date of treatment自动选择
        //                else if (row.TUMOR_MONITOR_SCHEDULE == "QW")
        //                {
        //                    int week = period;
        //                    for (int d = 0; d < week; d++)
        //                    {
        //                        if (day.AddDays(d).DayOfWeek == day.DayOfWeek)
        //                        {
        //                            saveDM_work(row, role, person, workload, day.AddDays(d * 7), phase, newGroupData);

        //                        }
        //                    }
        //                }
        //                #endregion

        //                #region Q2W//每两周一次，固定在Date of treatment当天。按照Date of treatment自动选择
        //                else if (row.TUMOR_MONITOR_SCHEDULE == "Q2W")
        //                {
        //                    int week = period;
        //                    for (int d = 0; d < week; d++)
        //                    {
        //                        if (day.AddDays(d).DayOfWeek == day.DayOfWeek)
        //                        {

        //                            saveDM_work(row, role, person, workload, day.AddDays(d * 14), phase, newGroupData);
        //                        }
        //                    }
        //                }
        //                #endregion

        //                #region Q3W//每3周一次，固定在Date of treatment当天。按照Date of treatment自动选择
        //                else if (row.TUMOR_MONITOR_SCHEDULE == "Q3W")
        //                {
        //                    int week = period;
        //                    for (int d = 0; d < week; d++)
        //                    {
        //                        if (day.AddDays(d).DayOfWeek == day.DayOfWeek)
        //                        {
        //                            saveDM_work(row, role, person, workload, day.AddDays(d * 21), phase, newGroupData);
        //                        }
        //                    }
        //                }
        //                #endregion

        //                #region  Once//整个实验过程只有一次给药，根据选择日期确定。
        //                else if (row.TUMOR_MONITOR_SCHEDULE == "Once")
        //                {
        //                    saveDM_work(row, role, person, workload, day, phase, newGroupData);
        //                }
        //                #endregion
        //                else
        //                {
        //                    for (int d = 0; d < period; d++)
        //                    {
        //                        saveDM_work(row, role, person, workload, day.AddDays(d), phase, newGroupData);
        //                    }
        //                }
        //            }
                    
        //        }
        //        #endregion

        //        bll.UpdateAllByParams(newGroupData);
        //    }

        //}

      

        public void DTgroup_workload()
        {
            string role = "DT group";
            string person = "DT group1";
            List<PROJECT_MONITOR_DOSING_ROUTE> dataRoute = bll.Select(typeof(PROJECT_MONITOR_DOSING_ROUTE)).ConvertAll<PROJECT_MONITOR_DOSING_ROUTE>(PROJECT_MONITOR_DOSING_ROUTE.Convert);

            ParamCollection paraList = new ParamCollection();
            paraList.Clause = PROJECT_MONITOR.DT_GROUP_FIELD + "='" + person + "' and Randomization <> ''";

            BaseList allData = bll.Select(paraList, typeof(PROJECT_MONITOR));
            foreach (PROJECT_MONITOR dr in allData)
            {

                #region 计算beforeGroup7
                double beforeGroup7 = 0;
                if (RegHelper.IsDateTime(dr.PROVIDE_SEEDING_ANIMAL))
                {
                    beforeGroup7 = SearchRoute(dataRoute, "2.08");
                    saveDTgroup_work("7", dr, role, person, beforeGroup7, dataRoute, DateTime.Parse(dr.PROVIDE_SEEDING_ANIMAL));
                }

                #endregion

                #region 计算beforeGroup8
                double beforeGroup8 = 0;
                if (RegHelper.IsDateTime(dr.INOCULATION))
                {
                    beforeGroup8 = SearchRoute(dataRoute, "2.10") * dr.NUMBER_OF_ANIMAL_INOCULATION;
                    saveDTgroup_work("8", dr, role, person, beforeGroup8, dataRoute, DateTime.Parse(dr.INOCULATION));
                }

                #endregion



                ParamCollection paraList2 = new ParamCollection();
                paraList2.Clause = PROJECT_MONITOR_STUDY_DESIGN.PROJECT_MONITOR_ID_FIELD + "='" + dr.PROJECT_MONITOR_ID + "'";
                BaseList dataGroup = bll.Select(paraList2, typeof(PROJECT_MONITOR_STUDY_DESIGN));
                double mice_number = 0;
                if (dataGroup.Count > 0)
                {
                    double workload = 0;

                    #region 计算mice_number
                    foreach (PROJECT_MONITOR_STUDY_DESIGN row in dataGroup)
                    {
                        mice_number += int.Parse(row.MICE_GROUP);

                    }
                    #endregion
                  
                    #region 计算beforeGroup9
                    double beforeGroup9 = 0;
                    if (RegHelper.IsDateTime(dr.RANDOMIZATION))
                    {
                        beforeGroup9 = SearchRoute(dataRoute, "2.01,2.23") * mice_number;
                        saveDTgroup_work("9", dr, role, person, beforeGroup9, dataRoute, DateTime.Parse(dr.RANDOMIZATION));
                    }


                    #endregion

                    #region 计算workload_Group10
                    #region beforeGroup10
                    double beforeGroup10 = 0;

                    if (dr.TREATMENT_START != "")
                    {
                        if (dr.SAMPLE_AMOUNT != 0)
                        {
                            beforeGroup10 = SearchRoute(dataRoute, "2.09") * 1;
                        }
                    }

        
                    #endregion



                    if (RegHelper.IsDateTime(dr.TREATMENT_START))
                    {
                        BaseList newGroupData = new BaseList();
                        foreach (PROJECT_MONITOR_STUDY_DESIGN row in dataGroup)
                        {

                            DateTime day = DateTime.Parse(dr.TREATMENT_START);
                            //循环周期
                            int period = 0;
                            if (row.DOSING_PERIOD != "")
                            {
                                period = int.Parse(row.DOSING_PERIOD);
                            }
                            double time = 1;//1天1次
                            if (row.DOSING_SCHEDULE == "TID")//1天3次
                            {
                                time = 3;
                            }
                            else if (row.DOSING_SCHEDULE == "BID")//1天2次
                            {
                                time = 2;
                            }
                            //每天的工作量
                            workload = beforeGroup10+ SearchRoute(dataRoute, row.DOSING_ROUTE_VALUE.ToString()) * double.Parse(row.MICE_GROUP) * time;

                            #region Q2D,Q3D,Q4D//每2天1次,每3天1次,每4天1次
                            if (row.DOSING_SCHEDULE == "Q2D" || row.DOSING_SCHEDULE == "Q3D" || row.DOSING_SCHEDULE == "Q4D")
                            {
                                for (int i = 0; i < period; i++)
                                {
                                    PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                    newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                    newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                    newday.MODEL_ID = dr.MODEL_ID;
                                    newday.ROLE_NAME = role;
                                    newday.PERSON = person;
                                    if (row.DOSING_SCHEDULE == "Q2D")
                                    {
                                        newday.STUDY_DESIGN_DAY = day.AddDays(i * 2);
                                    }
                                    else if (row.DOSING_SCHEDULE == "Q3D")
                                    {
                                        newday.STUDY_DESIGN_DAY = day.AddDays(i * 3);
                                    }
                                    else if (row.DOSING_SCHEDULE == "Q3D")
                                    {
                                        newday.STUDY_DESIGN_DAY = day.AddDays(i * 4);
                                    }
                                    newday.STUDY_WORKLOAD = workload;
                                    newday.DM = dr.DM;
                                    newday.PHASE = "10";
                                    newGroupData.Add(newday);
                                }
                            }
                            #endregion

                            #region 5 Days on and 2 days off//每天一次，固定在Monday/Tuesday开始。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "5 Days on and 2 days off")
                            {
                                int totalDay = period * 7;
                                for (int d = 0; d < totalDay; d++)
                                {
                                    if (day.AddDays(d).DayOfWeek != DayOfWeek.Saturday && day.AddDays(d).DayOfWeek != DayOfWeek.Sunday)
                                    {
                                        PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                        newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                        newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                        newday.MODEL_ID = dr.MODEL_ID;
                                        newday.ROLE_NAME = role;
                                        newday.PERSON = person;
                                        newday.STUDY_DESIGN_DAY = day.AddDays(d);
                                        newday.STUDY_WORKLOAD = workload;
                                        newday.DM = dr.DM;
                                        newday.PHASE = "10";
                                        newGroupData.Add(newday);
                                    }

                                }
                            }
                            #endregion

                            #region TIW//每周三次，固定在Monday, Wednesday, Friday。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "TIW")
                            {
                                int totalDay = period * 7;
                                for (int d = 0; d < totalDay; d++)
                                {
                                    if (day.AddDays(d).DayOfWeek == DayOfWeek.Monday || day.AddDays(d).DayOfWeek == DayOfWeek.Friday || day.AddDays(d).DayOfWeek == DayOfWeek.Wednesday)
                                    {
                                        PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                        newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                        newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                        newday.MODEL_ID = dr.MODEL_ID;
                                        newday.ROLE_NAME = role;
                                        newday.PERSON = person;
                                        newday.STUDY_DESIGN_DAY = day.AddDays(d);
                                        newday.STUDY_WORKLOAD = workload;
                                        newday.DM = dr.DM;
                                        newday.PHASE = "10";
                                        newGroupData.Add(newday);
                                    }
                                }
                            }
                            #endregion

                            #region BIW//每周两次，固定在Monday/Thursday或Tuesday/Friday。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "BIW")
                            {
                                int totalDay = period * 7;
                                if (day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Thursday)
                                {
                                    for (int d = 0; d < totalDay; d++)
                                    {
                                        if (day.AddDays(d).DayOfWeek == DayOfWeek.Monday || day.AddDays(d).DayOfWeek == DayOfWeek.Thursday)
                                        {
                                            PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                            newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                            newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                            newday.MODEL_ID = dr.MODEL_ID;
                                            newday.ROLE_NAME = role;
                                            newday.PERSON = person;
                                            newday.STUDY_DESIGN_DAY = day.AddDays(d);
                                            newday.STUDY_WORKLOAD = workload;
                                            newday.DM = dr.DM;
                                            newday.PHASE = "10";
                                            newGroupData.Add(newday);
                                        }
                                    }
                                }
                                else if (day.DayOfWeek == DayOfWeek.Tuesday || day.DayOfWeek == DayOfWeek.Friday)
                                {
                                    for (int d = 0; d < totalDay; d++)
                                    {
                                        if (day.AddDays(d).DayOfWeek == DayOfWeek.Tuesday || day.AddDays(d).DayOfWeek == DayOfWeek.Friday)
                                        {
                                            PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                            newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                            newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                            newday.MODEL_ID = dr.MODEL_ID;
                                            newday.ROLE_NAME = role;
                                            newday.PERSON = person;
                                            newday.STUDY_DESIGN_DAY = day.AddDays(d);
                                            newday.STUDY_WORKLOAD = workload;
                                            newday.DM = dr.DM;
                                            newGroupData.Add(newday);
                                        }
                                    }
                                }
                            }
                            #endregion

                            #region QW//每周一次，固定在Date of treatment当天。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "QW")
                            {
                                int week = period;
                                for (int d = 0; d < week; d++)
                                {
                                    if (day.AddDays(d).DayOfWeek == day.DayOfWeek)
                                    {
                                        PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                        newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                        newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                        newday.MODEL_ID = dr.MODEL_ID;
                                        newday.ROLE_NAME = role;
                                        newday.PERSON = person;
                                        newday.STUDY_DESIGN_DAY = day.AddDays(d * 7);
                                        newday.STUDY_WORKLOAD = workload;
                                        newday.DM = dr.DM;
                                        newday.PHASE = "10";
                                        newGroupData.Add(newday);
                                    }
                                }
                            }
                            #endregion

                            #region Q2W//每两周一次，固定在Date of treatment当天。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "Q2W")
                            {
                                int week = period;
                                for (int d = 0; d < week; d++)
                                {
                                    if (day.AddDays(d).DayOfWeek == day.DayOfWeek)
                                    {
                                        PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                        newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                        newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                        newday.MODEL_ID = dr.MODEL_ID;
                                        newday.ROLE_NAME = role;
                                        newday.PERSON = person;
                                        newday.STUDY_DESIGN_DAY = day.AddDays(d * 14);
                                        newday.STUDY_WORKLOAD = workload;
                                        newday.DM = dr.DM;
                                        newday.PHASE = "10";
                                        newGroupData.Add(newday);
                                    }
                                }
                            }
                            #endregion

                            #region Q3W//每3周一次，固定在Date of treatment当天。按照Date of treatment自动选择
                            else if (row.DOSING_SCHEDULE == "Q3W")
                            {
                                int week = period;
                                for (int d = 0; d < week; d++)
                                {
                                    if (day.AddDays(d).DayOfWeek == day.DayOfWeek)
                                    {
                                        PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                        newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                        newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                        newday.MODEL_ID = dr.MODEL_ID;
                                        newday.ROLE_NAME = role;
                                        newday.PERSON = person;
                                        newday.STUDY_DESIGN_DAY = day.AddDays(d * 21);
                                        newday.STUDY_WORKLOAD = workload;
                                        newday.DM = dr.DM;
                                        newday.PHASE = "10";
                                        newGroupData.Add(newday);
                                    }
                                }
                            }
                            #endregion

                            #region  Once//整个实验过程只有一次给药，根据选择日期确定。
                            else if (row.DOSING_SCHEDULE == "Once")
                            {
                                PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                newday.MODEL_ID = dr.MODEL_ID;
                                newday.ROLE_NAME = role;
                                newday.PERSON = person;
                                newday.STUDY_DESIGN_DAY = day;
                                newday.STUDY_WORKLOAD = workload;
                                newday.DM = dr.DM;
                                newday.PHASE = "10";
                                newGroupData.Add(newday);
                            }
                            #endregion
                            else
                            {
                                for (int i = 0; i < period; i++)
                                {
                                    PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
                                    newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
                                    newday.SUB_PROJECT = dr.PROJECT_NUMBER;
                                    newday.MODEL_ID = dr.MODEL_ID;
                                    newday.ROLE_NAME = role;
                                    newday.PERSON = person;
                                    newday.STUDY_DESIGN_DAY = day.AddDays(i);
                                    newday.STUDY_WORKLOAD = workload;
                                    newday.DM = dr.DM;
                                    newday.PHASE = "10";
                                    newGroupData.Add(newday);
                                }
                            }
                        }
                        bll.UpdateAllByParams(newGroupData);
                    }
                    #endregion
                }

                #region 计算beforeGroup11
                double beforeGroup11 = 0;
                if (RegHelper.IsDateTime(dr.TREATMENT_FINISHED))
                {
                    beforeGroup11 = SearchRoute(dataRoute, "2.16") * dr.SAMPLE_AMOUNT;
                    beforeGroup11 += SearchRoute(dataRoute, "2.23") * mice_number;
                    saveDTgroup_work("11", dr, role, person, beforeGroup11, dataRoute, DateTime.Parse(dr.TREATMENT_FINISHED));
                }

                #endregion

                #region 计算beforeGroup12
                if (RegHelper.IsDateTime(dr.OBSERVATION_POST_TREATMENT))
                {
                   // List<PROJECT_MONITOR> mdata = allData.ConvertAll<PROJECT_MONITOR>(PROJECT_MONITOR.Convert).FindAll(delegate(PROJECT_MONITOR perm) { return perm.TISSUE_COLLECTION == dr.OBSERVATION_POST_TREATMENT; });
                    //if (mdata.Count > 0)
                    //{
                    //   
                    if (dr.TISSUE_COLLECTION != "")
                    {
                        double beforeGroup12 = SearchRoute(dataRoute, "2.18");
                        saveDTgroup_work("12", dr, role, person, beforeGroup12, dataRoute, DateTime.Parse(dr.OBSERVATION_POST_TREATMENT));
                    }
                   // }
                }

                #endregion
            }
          
           
        }

    
        public void saveDTgroup_work(string phase,PROJECT_MONITOR dr, string role, string person, double beforeGroup, List<PROJECT_MONITOR_DOSING_ROUTE> dataRoute, DateTime day)
        {
            BaseList newGroupData = new BaseList();
            PROJECT_MONITOR_DAY newday = new PROJECT_MONITOR_DAY(DealModel.New);
            newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
            newday.SUB_PROJECT = dr.PROJECT_NUMBER;
            newday.MODEL_ID = dr.MODEL_ID;
            newday.ROLE_NAME = role;
            newday.PERSON = person;
            newday.STUDY_DESIGN_DAY = day;
            newday.DM = dr.DM;
            newday.PHASE = phase;
            newday.STUDY_WORKLOAD = beforeGroup;
            newGroupData.Add(newday);
            bll.UpdateAllByParams(newGroupData);
        }
        public void saveDM_workload(PROJECT_MONITOR dr, string role, string person, double beforeGroup, List<PROJECT_MONITOR_DOSING_ROUTE> dataRoute, DateTime day)
        {
            BaseList newGroupData = new BaseList();
            PROJECT_MONITOR_DM_WORKLOAD newday = new PROJECT_MONITOR_DM_WORKLOAD(DealModel.New);
            newday.PROJECT_MONITOR_ID = dr.PROJECT_MONITOR_ID;
            newday.SUB_PROJECT = dr.PROJECT_NUMBER;
            newday.MODEL_ID = dr.MODEL_ID;
            newday.ROLE_NAME = role;
            newday.PERSON = person;
            newday.STUDY_DESIGN_DAY = day;
            newday.DM = dr.DM;
        
            newday.STUDY_WORKLOAD = beforeGroup;
            newGroupData.Add(newday);
            bll.UpdateAllByParams(newGroupData);
        }
      
        protected void btnExport1_Click(object sender, EventArgs e)
        {
            if (Session["dgWorkload"] != null)
            {
                DataTable dt = (DataTable)Session["dgWorkload"];
                ToExport.TableToExcel(dt, "Workload");
            }
        }
    }

}