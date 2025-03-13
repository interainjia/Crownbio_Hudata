using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for SYS_USER_ROLE Table
	/// </summary>
	[Serializable]
    [DataTable("COMBOX_INFO", ResourceKey = "COMBOX_INFO")]
	public class COMBOX_INFO: BaseObject
	{
        public COMBOX_INFO(string _value,string _text)
		{
            this._display_value = _value;
            this._display_text = _text;
		}
        public static COMBOX_INFO Convert(BaseObject from)
		{
            return (COMBOX_INFO)from;
		}
        private string _display_value;
        public string DISPLAY_VALUE
        {
           // set { _display_value = value; }
            get { return _display_value; }
        }
        public const String DISPLAY_VALUE_FIELD = "DISPLAY_VALUE";
        private string _display_text;
        public string DISPLAY_TEXT
        {
          //  set { _display_text = value; }
            get { return _display_text; }
        }
        public const String DISPLAY_TEXT_FIELD = "DISPLAY_TEXT";
	}
}