using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for APP_FILE Table
    /// </summary>
    [Serializable]
    [DataTable("PRO_CHANGE", ResourceKey = "PRO_CHANGE")]
    public class PRO_TITLE_ITEM : BaseObject
    {
        public PRO_TITLE_ITEM()
        {
        }
        public PRO_TITLE_ITEM(DealModel initModel)
            : base(initModel)
        {
        }
        public static PRO_TITLE_ITEM Convert(BaseObject from)
        {
            return (PRO_TITLE_ITEM)from;
        }



        /// <summary>
        /// 变更版本、咨询编号
        /// </summary>
        /// 
        private string change_no;
        public string Value
        {
            set
            {
                change_no = value;
            }
            get { return change_no; }
        }
        /// <summary>
        /// 变更类别
        /// 项目名称
        /// </summary>
        private string change_name;
        public string Text
        {
            set
            {
                change_name = value;
            }
            get { return change_name; }
        }    
         private string _format;
        public string Format
        {
            set
            {
                _format = value;
            }
            get { return _format; }
        }    
        
        /// <summary>
        /// 委托单位
        /// </summary>
        private bool _is_selected = false;
        public bool IS_SELECTED
        {
            set
            {
                _is_selected = value;
            }
            get { return _is_selected; }
        }
        public DateTime  _finish_date;
        //public DateTime FINISH_DATE

        public string FINISH_DATE_F
        {
            get
            {

                if (_finish_date != DateTime.MinValue)
                {
                    return _finish_date.ToShortDateString();
                }
                else
                {
                    return "---";
                }
            }
        }
       
    }
}