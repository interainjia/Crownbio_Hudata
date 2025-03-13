using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for APP_HR Table
	/// </summary>
	[Serializable]
	[DataTable("APP_HR",ResourceKey = "APP_HR")]
	public class APP_HR: BaseObject
	{
		public APP_HR()
		{
		}
		public APP_HR(DealModel initModel):base(initModel)
		{
		}
		public static APP_HR Convert(BaseObject from)
		{
			return (APP_HR)from;
		}
		/// <summary>
		/// The HR_ID Field of APP_HR Table
		/// </summary>
		private decimal _hr_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.HR_ID = value; }
			get { return HR_ID; }
		}

		[RecordIDField("HR_ID"
			, AliasName = "HR_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "HR_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal HR_ID
		{
			set { _hr_id = value; }
			get { return _hr_id; }
		}
		/// <summary>
		/// The HR_CODE Field of APP_HR Table
		/// </summary>
		private string _hr_code;
		[KeyField("HR_CODE"
			, AliasName = "HR_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "HR_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string HR_CODE
		{
			set { _hr_code = value; }
			get { return _hr_code; }
		}
		/// <summary>
		/// The HR_NAME Field of APP_HR Table
		/// </summary>
		private string _hr_name;
		[DataField("HR_NAME"
			, AliasName = "HR_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "HR_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string HR_NAME
		{
			set { _hr_name = value; }
			get { return _hr_name; }
		}
		/// <summary>
		/// The LANG_CODE Field of APP_HR Table
		/// </summary>
		private string _lang_code;
		[DataField("LANG_CODE"
			, AliasName = "LANG_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "LANG_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LANG_CODE
		{
			set { _lang_code = value; }
			get { return _lang_code; }
		}
		/// <summary>
		/// The HR_REQ Field of APP_HR Table
		/// </summary>
		private string _hr_req;
		[DataField("HR_REQ"
			, AliasName = "HR_REQ"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 500
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "HR_REQ"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string HR_REQ
		{
			set { _hr_req = value; }
			get { return _hr_req; }
		}
		/// <summary>
		/// The HR_NUM Field of APP_HR Table
		/// </summary>
		private string _hr_num;
		[DataField("HR_NUM"
			, AliasName = "HR_NUM"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "HR_NUM"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string HR_NUM
		{
			set { _hr_num = value; }
			get { return _hr_num; }
		}
		/// <summary>
		/// The DATE_PUBLISH Field of APP_HR Table
		/// </summary>
		private DateTime _date_publish;
		[DataField("DATE_PUBLISH"
			, AliasName = "DATE_PUBLISH"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_PUBLISH"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_PUBLISH
		{
			set { _date_publish = value; }
			get { return _date_publish; }
		}
		/// <summary>
		/// The CREATE_BY Field of APP_HR Table
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
		/// The CREATE_TIME Field of APP_HR Table
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
		/// The UPDATE_BY Field of APP_HR Table
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
		/// The UPDATE_TIME Field of APP_HR Table
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
		/// APP_HR Table 
		/// </summary>
		public const string TABLE_NAME="APP_HR";
		public const String HR_ID_FIELD  ="HR_ID";
		public const String HR_CODE_FIELD  ="HR_CODE";
		public const String HR_NAME_FIELD  ="HR_NAME";
		public const String LANG_CODE_FIELD  ="LANG_CODE";
		public const String HR_REQ_FIELD  ="HR_REQ";
		public const String HR_NUM_FIELD  ="HR_NUM";
		public const String DATE_PUBLISH_FIELD  ="DATE_PUBLISH";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}