using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for APP_LANG Table
	/// </summary>
	[Serializable]
	[DataTable("APP_LANG",ResourceKey = "APP_LANG")]
	public class APP_LANG: BaseObject
	{
		public APP_LANG()
		{
		}
		public APP_LANG(DealModel initModel):base(initModel)
		{
		}
		public static APP_LANG Convert(BaseObject from)
		{
			return (APP_LANG)from;
		}
		/// <summary>
		/// The LANG_ID Field of APP_LANG Table
		/// </summary>
		private decimal _lang_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.LANG_ID = value; }
			get { return LANG_ID; }
		}

		[RecordIDField("LANG_ID"
			, AliasName = "LANG_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "LANG_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal LANG_ID
		{
			set { _lang_id = value; }
			get { return _lang_id; }
		}
		/// <summary>
		/// The LANG_CODE Field of APP_LANG Table
		/// </summary>
		private string _lang_code;
		[KeyField("LANG_CODE"
			, AliasName = "LANG_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 10
			, Width =100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "LANG_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string LANG_CODE
		{
			set { _lang_code = value; }
			get { return _lang_code; }
		}
		/// <summary>
		/// The LANG_NAME Field of APP_LANG Table
		/// </summary>
		private string _lang_name;
		[DataField("LANG_NAME"
			, AliasName = "LANG_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 1000
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "LANG_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LANG_NAME
		{
			set { _lang_name = value; }
			get { return _lang_name; }
		}
		/// <summary>
		/// APP_LANG Table 
		/// </summary>
		public const string TABLE_NAME="APP_LANG";
		public const String LANG_ID_FIELD  ="LANG_ID";
		public const String LANG_CODE_FIELD  ="LANG_CODE";
		public const String LANG_NAME_FIELD  ="LANG_NAME";
	}
}