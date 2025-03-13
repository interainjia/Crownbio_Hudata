using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Crownbio.Language;
using Crownbio.Common;
using Crownbio.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Reflection;

namespace Crownbio.Utility
{
    public class UtitityHelper
    {
        /// <summary>
        /// 获取指定颜色的"R,G,B"
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ColorTostring(Color color)
        {
            string colorstr = color.R + "," + color.G + "," + color.B;
            return colorstr;
        }

        /// <summary>
        /// 通过格式化的"R,G,B"字符串获取其对就的Color
        /// </summary>
        /// <param name="rgbString"></param>
        /// <returns></returns>
        public static Color getColor(string rgbString)
        {
            string[] rgb = rgbString.Split(new char[] { ',' });
            Color color = Color.White;
            try
            {
                int r = int.Parse(rgb[0]);
                int g = int.Parse(rgb[1]);
                int b = int.Parse(rgb[2]);
                color = Color.FromArgb(r, g, b);
            }
            catch
            {
            }
            return color;
        }
        #region gene compare vs title
        public static string GeneTitle(string first, IEnumerable datalist, int longer)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(first);
            int k = 1;
            foreach (string a in datalist)
            {
                if (k == 1)
                {
                    sb.Append(a);
                }
                else
                {
                    string[] vs = a.Replace("///", "#").Split('#');
                    foreach (string s in vs)
                    {
                        int index = sb.ToString().LastIndexOf("\n");
                        int length = 0;
                        if (index == -1)
                        {
                            length = sb.Length + a.Length + 4;
                        }
                        else
                        {
                            length = sb.ToString().Substring(index, (sb.ToString().Length - index)).Length;
                        }
                        if (length >= longer)
                        {
                            sb.Append(" \n ");
                            sb.Append("vs " + s.Trim());
                        }
                        else
                        {
                            sb.Append(" vs " + s.Trim());
                        }

                    }
                }
                k++;
            }
            return sb.ToString();
        }
        #endregion
        #region 序列化与反序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Serialize(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binaryF = new BinaryFormatter();
                binaryF.Serialize(ms, obj);
                byte[] buffer = ms.GetBuffer();
                return buffer;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static object Deserialize(byte[] buffer)
        {
            using (MemoryStream ms = new MemoryStream(buffer, 0, buffer.Length, false))
            {
                try
                {
                    BinaryFormatter binaryF = new BinaryFormatter();
                    object obj = binaryF.Deserialize(ms);
                    return obj;
                }
                catch
                {
                    return null;
                }
            }
        }

        #endregion

        /// <summary>
        /// 初始化下拉选择框
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="displayField"></param>
        /// <param name="valueField"></param>
        /// <param name="dataSource"></param>
        /// <param name="isInsertNullRow"></param>
        /// <param name="rowAt"></param>
        public static void InitCombox(DropDownList cmb, string displayField, string valueField, BaseList dataSource, bool isInsertNullRow, int rowAt)
        {
            try
            {
                List<COMBOX_INFO> com = new List<COMBOX_INFO>();
                if (dataSource != null && dataSource.Count > 0)
                {
                    com = ToComBox(dataSource, valueField, displayField);
                }
                if (isInsertNullRow)
                {
                    COMBOX_INFO insert = new COMBOX_INFO("0", LanguageHelper.GetResourceText("PleaseSelect"));
                    com.Insert(rowAt, insert);
                }
                cmb.DataTextField = COMBOX_INFO.DISPLAY_TEXT_FIELD;
                cmb.DataValueField = COMBOX_INFO.DISPLAY_VALUE_FIELD;
                cmb.DataSource = com;
                cmb.DataBind();

            }
            catch
            {
                cmb.Items.Clear();
            }
            if (dataSource.Count > rowAt)
            {
                cmb.SelectedIndex = rowAt;
            }
        }

        public static void InitCombox(DropDownList cmb, string displayField, string valueField, BaseList dataSource, bool isInsertNullRow)
        {
            InitCombox(cmb, displayField, valueField, dataSource, isInsertNullRow, 0);
        }

        /// <summary>
        /// 将BaseList转换成ComBox专用数据类型
        /// </summary>
        /// <param name="_data">BaseList</param>
        /// <param name="codeFields">DisplayValue</param>
        /// <param name="nameFields">DisplayText</param>
        /// <returns></returns>
        public static List<Crownbio.Model.COMBOX_INFO> ToComBox(BaseList _data, string codeFields, string nameFields)
        {
            List<Crownbio.Model.COMBOX_INFO> com = new List<Crownbio.Model.COMBOX_INFO>();
            if (_data.Count > 0)
            {
                foreach (BaseObject _row in _data)
                {
                    System.Reflection.PropertyInfo propertyValue = _row.GetType().GetProperty(codeFields);
                    System.Reflection.PropertyInfo propertyText = _row.GetType().GetProperty(nameFields);
                    string _strValue = propertyValue.GetValue(_row, null).ToString();
                    string _strText = propertyText.GetValue(_row, null).ToString();
                    com.Add(new Crownbio.Model.COMBOX_INFO(_strValue, _strText));
                }
            }
            return com;
        }

        /// <summary>
        /// 初始化界面标签
        /// </summary>
        /// <param name="parentCtrl"></param>
        public static void InitUi(Control parentCtrl)
        {
            if (parentCtrl != null)
            {
                foreach (Control ctrl in parentCtrl.Controls)
                {
                    InitUi(ctrl);
                    if ((ctrl is Label) || (ctrl is Button) || (ctrl is System.Web.UI.WebControls.Image) || (ctrl is HyperLink) || (ctrl is CheckBox) || (ctrl is TextBox) || (ctrl is LinkButton))
                    {
                        string name = ctrl.ID;
                        if (name != null)
                        {
                            if (name.Length > 3)
                            {
                                name = name.Substring(3, name.Length - 3);
                                if (ctrl is Label)
                                {
                                    if (LanguageHelper.GetResourceText(name) != name)
                                    {
                                        ((Label)ctrl).Text = LanguageHelper.GetResourceText(name);
                                    }
                                }
                                if (ctrl is Button)
                                {
                                    if (LanguageHelper.GetResourceText(name) != name)
                                    {
                                        ((Button)ctrl).Text = LanguageHelper.GetResourceText(name);
                                    }
                                }
                                else if (ctrl is System.Web.UI.WebControls.Image)
                                {
                                    // ((System.Web.UI.WebControls.Image)ctrl).ImageUrl = LanguageHelper.GetResourceText(name);
                                }
                                else if (ctrl is HyperLink)
                                {
                                    if (LanguageHelper.GetResourceText(name) != name)
                                    {
                                        ((HyperLink)ctrl).Text = LanguageHelper.GetResourceText(name);
                                    }
                                }
                                else if (ctrl is CheckBox)
                                {
                                    ((CheckBox)ctrl).Text = LanguageHelper.GetResourceText(name);
                                }
                                else if (ctrl is LinkButton)
                                {
                                    ((LinkButton)ctrl).Text = LanguageHelper.GetResourceText(name);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 初始始化初始值
        /// </summary>
        /// <param name="parentCtrl"></param>
        public static void ClearUi(Control parentCtrl)
        {
            if (parentCtrl != null)
            {
                foreach (Control ctrl in parentCtrl.Controls)
                {
                    InitUi(ctrl);
                    if ((ctrl is TextBox))
                    {
                        ((TextBox)ctrl).Text = "";
                    }
                    else if ((ctrl is CheckBox))
                    {
                        ((CheckBox)ctrl).Checked = false;
                    }
                    else if ((ctrl is HiddenField))
                    {
                        ((HiddenField)ctrl).Value = "-1";
                    }
                }
            }
        }

        /// <summary>
        /// 验证控件输入值
        /// </summary>
        /// <param name="ctrl">控件</param>
        /// <param name="checkNull">是否检查为空</param>
        /// <param name="CheckType">检查类别</param>
        /// <returns></returns>
        public static string CheckValid(TextBox ctrl, bool checkNull, FieldRegType CheckType)
        {
            string result = "";
            string name = ctrl.ID;
            if (name != null)
            {
                if (name.Length > 3)
                {
                    name = name.Substring(3, name.Length - 3);
                }
            }
            else
            {
                name = "";
            }

            if (checkNull)
            {
                if (ctrl.Text.Trim() == "")
                {
                    result += LanguageHelper.GetResourceText(name) + LanguageHelper.GetResourceText("CanNotNull") + "\\n";
                }
                //else
                //{
                //    if (UrnHtml(ctrl.Text.Trim()))
                //    {
                //        result += LanguageHelper.GetResourceText(name) + LanguageHelper.GetResourceText("CanNotHtmlInput") + "\\n";
                //    }
                //}
            }

            if (ctrl.Text.Trim() != "")
            {
                if (CheckType == FieldRegType.DecimalReg)
                {
                    if (!RegHelper.IsDecimal(ctrl.Text))
                    {
                        result += LanguageHelper.GetResourceText(name) + LanguageHelper.GetResourceText("InvalidInput") + "\\n";
                    }
                }
                else if (CheckType == FieldRegType.NumberReg)
                {
                    if (!RegHelper.IsNumber(ctrl.Text))
                    {
                        result += LanguageHelper.GetResourceText(name) + LanguageHelper.GetResourceText("InvalidInput") + "\\n";
                    }
                }
                else if (CheckType == FieldRegType.EmailReg)
                {
                    if (!RegHelper.IsEmail(ctrl.Text))
                    {
                        result += LanguageHelper.GetResourceText(name) + LanguageHelper.GetResourceText("InvalidInput") + "\\n";
                    }
                }
                else if (CheckType == FieldRegType.DateTimeReg)
                {
                    if (!RegHelper.IsDateTime(ctrl.Text))
                    {
                        result += LanguageHelper.GetResourceText(name) + LanguageHelper.GetResourceText("InvalidInput") + "\\n";
                    }
                }
                else if (CheckType == FieldRegType.NumberSignReg)
                {
                    if (!RegHelper.IsNumberSign(ctrl.Text))
                    {
                        result += LanguageHelper.GetResourceText(name) + LanguageHelper.GetResourceText("InvalidInput") + "\\n";
                    }
                }
                else if (CheckType == FieldRegType.DecimalSignReg)
                {
                    if (!RegHelper.IsDecimalSign(ctrl.Text))
                    {
                        result += LanguageHelper.GetResourceText(name) + LanguageHelper.GetResourceText("InvalidInput") + "\\n";
                    }
                }
                else if (CheckType == FieldRegType.PhoneReg)
                {
                    if (!RegHelper.IsPhone(ctrl.Text))
                    {
                        result += LanguageHelper.GetResourceText(name) + LanguageHelper.GetResourceText("InvalidInput") + "\\n";
                    }
                }
                else if (CheckType == FieldRegType.IdCardReg)
                {
                    if (!RegHelper.IsIdCard(ctrl.Text))
                    {
                        result += LanguageHelper.GetResourceText(name) + LanguageHelper.GetResourceText("InvalidInput") + "\\n";
                    }
                }
            }

            return result;

        }


        public static bool UrnHtml(string strHtml)
        {
            string[] aryReg = { "'", "<", ">", "%", "\"\"", ">=", "=<", "_", "||", "[", "]", "&", "*", };
            bool isHtml = false;
            for (int i = 0; i < aryReg.Length; i++)
            {
                if (strHtml.IndexOf(aryReg[i]) >= 0)
                {
                    isHtml = true;
                    break;
                }
            }
            return isHtml;
        }


        /// <summary>
        /// 将泛型转换为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(List<BaseObject> list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        /// <summary>
        /// 将泛型转换为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTableBySelect(List<BaseObject> list, List<PRO_TITLE_ITEM> items)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                foreach (PRO_TITLE_ITEM pi in items)
                {
                    if (pi.IS_SELECTED)
                    {
                        DataColumn col = new DataColumn();
                        col.Caption = pi.Text;
                        col.ColumnName = pi.Value;
                        result.Columns.Add(col);
                    }
                }
                DataRow dr = null;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = result.NewRow();
                    foreach (PRO_TITLE_ITEM pi in items)
                    {
                        if (pi.IS_SELECTED)
                        {
                            System.Reflection.PropertyInfo propertyValue = list[i].GetType().GetProperty(pi.Value);
                            if (propertyValue != null)
                            {
                                object _Value = propertyValue.GetValue(list[i], null);
                                dr[pi.Value] = _Value;
                            }
                        }
                    }
                    result.Rows.Add(dr);
                }
            }
            return result;
        }

        /// 判断多语言
        public static string LangName()
        {
            System.Resources.ResourceManager rm = LanguageHelper.GetResourceManager();
            if (rm.BaseName == "Crownbio.Language.Resource_zh-CN")
            {
                return "CN";
            }
            else if (rm.BaseName == "Crownbio.Language.Resource_en-US")
            {
                return "EN";
            }
            else
            {
                return "CN";
            }
        }

        #region datatbale分页
        public static DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0) { return dt; }
            DataTable newdt = dt.Copy();
            newdt.Clear();
            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
            { return newdt; }

            if (rowend > dt.Rows.Count)
            { rowend = dt.Rows.Count; }
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }
            return newdt;
        }
        #endregion



        private static char[] constant =
      {
        '0','1','2','3','4','5','6','7','8','9',
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
      };
        /// <summary>
        /// 随机生成length位子母数字组合
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }

        /// <summary>
        /// datatable增加自增列
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable AddAutoIdColumn(DataTable dt)
        {

            if (dt != null)
            {

                DataColumn autoColumn = new DataColumn("AutoID", System.Type.GetType("System.Int32"));

                dt.Columns.Add(autoColumn);

                dt.Columns["AutoID"].SetOrdinal(0);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = i + 1;
                }

            }

            return dt;

        }
    }
}
