using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for APP_HELP Table
	/// </summary>
	[Serializable]
	[DataTable("APP_HELP",ResourceKey = "APP_HELP")]
	public class APP_HELP: BaseObject
	{
		public APP_HELP()
		{
		}
		public APP_HELP(DealModel initModel):base(initModel)
		{
		}
		public static APP_HELP Convert(BaseObject from)
		{
			return (APP_HELP)from;
		}
		/// <summary>
		/// The HELP_ID Field of APP_HELP Table
		/// </summary>
		private decimal _help_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.HELP_ID = value; }
			get { return HELP_ID; }
		}

		[RecordIDField("HELP_ID"
			, AliasName = "HELP_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "HELP_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal HELP_ID
		{
			set { _help_id = value; }
			get { return _help_id; }
		}
		/// <summary>
		/// The HELP_CODE Field of APP_HELP Table
		/// </summary>
		private string _help_code;
		[KeyField("HELP_CODE"
			, AliasName = "HELP_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "HELP_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string HELP_CODE
		{
			set { _help_code = value; }
			get { return _help_code; }
		}
		/// <summary>
		/// The HELP_NAME Field of APP_HELP Table
		/// </summary>
		private string _help_name;
		[DataField("HELP_NAME"
			, AliasName = "HELP_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 100
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "HELP_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string HELP_NAME
		{
			set { _help_name = value; }
			get { return _help_name; }
		}
		/// <summary>
		/// The KEYLIST Field of APP_HELP Table
		/// </summary>
		private string _keylist;
		[DataField("KEYLIST"
			, AliasName = "KEYLIST"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 500
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "KEYLIST"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string KEYLIST
		{
			set { _keylist = value; }
			get { return _keylist; }
		}
		/// <summary>
		/// The HELP_DESC Field of APP_HELP Table
		/// </summary>
		private string _help_desc;
		[DataField("HELP_DESC"
			, AliasName = "HELP_DESC"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 500
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "HELP_DESC"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string HELP_DESC
		{
			set { _help_desc = value; }
			get { return _help_desc; }
		}
		/// <summary>
		/// The HTML_URL Field of APP_HELP Table
		/// </summary>
		private string _html_url;
		[DataField("HTML_URL"
			, AliasName = "HTML_URL"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 100
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "HTML_URL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string HTML_URL
		{
			set { _html_url = value; }
			get { return _html_url; }
		}
		/// <summary>
		/// The CONTENT Field of APP_HELP Table
		/// </summary>
		private string _content;
		[DataField("CONTENT"
			, AliasName = "CONTENT"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 8
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "CONTENT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CONTENT
		{
			set { _content = value; }
			get { return _content; }
		}
		/// <summary>
		/// The CREATE_BY Field of APP_HELP Table
		/// </summary>
		private decimal _create_by;
		[DataField("CREATE_BY"
			, AliasName = "CREATE_BY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 9
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "CREATE_BY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 101
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = false
			, DefaultValue = "UserID"
			 )]
		public decimal CREATE_BY
		{
			set { _create_by = value; }
			get { return _create_by; }
		}
		/// <summary>
		/// The CREATE_TIME Field of APP_HELP Table
		/// </summary>
		private DateTime _create_time;
		[DataField("CREATE_TIME"
			, AliasName = "CREATE_TIME"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "CREATE_TIME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 102
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = false
			, DefaultValue = "SysDate"
			 )]
		public DateTime CREATE_TIME
		{
			set { _create_time = value; }
			get { return _create_time; }
		}
		/// <summary>
		/// The UPDATE_BY Field of APP_HELP Table
		/// </summary>
		private decimal _update_by;
		[DataField("UPDATE_BY"
			, AliasName = "UPDATE_BY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 9
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "UPDATE_BY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 103
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			, DefaultValue = "UserID"
			 )]
		public decimal UPDATE_BY
		{
			set { _update_by = value; }
			get { return _update_by; }
		}
		/// <summary>
		/// The UPDATE_TIME Field of APP_HELP Table
		/// </summary>
		private DateTime _update_time;
		[DataField("UPDATE_TIME"
			,AliasName = "UPDATE_TIME"
			,DataType = DbType.DateTime
			,IsNullable = false
			,Size = 20
			,DisplayInCondition = false
			,DisplayInMaintain = false
			, DisplayInDialog = false
			,ResourceKey = "UPDATE_TIME"
			, GroupFun = "MAX"
			,AllowEdit = false
			,SelectSequence = 104
			, DialogSequence = -1
			,Frozen = false
			,IsInsertField = true
			,IsUpdateField = true
			,DefaultValue = "SysDate"
			 )]
		public DateTime UPDATE_TIME
		{
			set { _update_time = value; }
			get { return _update_time; }
		}
		/// <summary>
		/// APP_HELP Table 
		/// </summary>
		public const string TABLE_NAME="APP_HELP";
		public const String HELP_ID_FIELD  ="HELP_ID";
		public const String HELP_CODE_FIELD  ="HELP_CODE";
		public const String HELP_NAME_FIELD  ="HELP_NAME";
		public const String KEYLIST_FIELD  ="KEYLIST";
		public const String HELP_DESC_FIELD  ="HELP_DESC";
		public const String HTML_URL_FIELD  ="HTML_URL";
		public const String CONTENT_FIELD  ="CONTENT";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}