using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for APP_KEY Table
	/// </summary>
	[Serializable]
	[DataTable("APP_KEY",ResourceKey = "APP_KEY")]
	public class APP_KEY: BaseObject
	{
		public APP_KEY()
		{
		}
		public APP_KEY(DealModel initModel):base(initModel)
		{
		}
		public static APP_KEY Convert(BaseObject from)
		{
			return (APP_KEY)from;
		}
		/// <summary>
		/// The KEY_ID Field of APP_KEY Table
		/// </summary>
		private decimal _key_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.KEY_ID = value; }
			get { return KEY_ID; }
		}

		[RecordIDField("KEY_ID"
			, AliasName = "KEY_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "KEY_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal KEY_ID
		{
			set { _key_id = value; }
			get { return _key_id; }
		}
		/// <summary>
		/// The COLUMN_CODE Field of APP_KEY Table
		/// </summary>
		private string _column_code;
		[KeyField("COLUMN_CODE"
			, AliasName = "COLUMN_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "COLUMN_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string COLUMN_CODE
		{
			set { _column_code = value; }
			get { return _column_code; }
		}
		/// <summary>
		/// The COLUMN_NAME Field of APP_KEY Table
		/// </summary>
		private string _column_name;
		[DataField("COLUMN_NAME"
			, AliasName = "COLUMN_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "COLUMN_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string COLUMN_NAME
		{
			set { _column_name = value; }
			get { return _column_name; }
		}
		/// <summary>
		/// The COLUMN_DESC Field of APP_KEY Table
		/// </summary>
		private string _column_desc;
		[DataField("COLUMN_DESC"
			, AliasName = "COLUMN_DESC"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 500
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "COLUMN_DESC"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string COLUMN_DESC
		{
			set { _column_desc = value; }
			get { return _column_desc; }
		}
		/// <summary>
		/// The KEYLIST Field of APP_KEY Table
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
			, SelectSequence = 12
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
		/// The REMARK Field of APP_KEY Table
		/// </summary>
		private string _remark;
		[DataField("REMARK"
			, AliasName = "REMARK"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REMARK"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string REMARK
		{
			set { _remark = value; }
			get { return _remark; }
		}
		/// <summary>
		/// The CREATE_BY Field of APP_KEY Table
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
		/// The CREATE_TIME Field of APP_KEY Table
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
		/// The UPDATE_BY Field of APP_KEY Table
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
		/// The UPDATE_TIME Field of APP_KEY Table
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
		/// APP_KEY Table 
		/// </summary>
		public const string TABLE_NAME="APP_KEY";
		public const String KEY_ID_FIELD  ="KEY_ID";
		public const String COLUMN_CODE_FIELD  ="COLUMN_CODE";
		public const String COLUMN_NAME_FIELD  ="COLUMN_NAME";
		public const String COLUMN_DESC_FIELD  ="COLUMN_DESC";
		public const String KEYLIST_FIELD  ="KEYLIST";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}