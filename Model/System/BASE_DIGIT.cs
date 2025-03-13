using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for BASE_DIGIT Table
	/// </summary>
	[Serializable]
	[DataTable("BASE_DIGIT",ResourceKey = "BASE_DIGIT")]
	public class BASE_DIGIT: BaseObject
	{
		public BASE_DIGIT()
		{
		}
		public BASE_DIGIT(DealModel initModel):base(initModel)
		{
		}
		public static BASE_DIGIT Convert(BaseObject from)
		{
			return (BASE_DIGIT)from;
		}
		/// <summary>
		/// The DIGIT_ID Field of BASE_DIGIT Table
		/// </summary>
		private decimal _digit_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.DIGIT_ID = value; }
			get { return DIGIT_ID; }
		}

		[RecordIDField("DIGIT_ID"
			, AliasName = "DIGIT_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "DIGIT_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal DIGIT_ID
		{
			set { _digit_id = value; }
			get { return _digit_id; }
		}
		/// <summary>
		/// The COLUMN_CODE Field of BASE_DIGIT Table
		/// </summary>
		private string _column_code;
		[KeyField("COLUMN_CODE"
			, AliasName = "COLUMN_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = false
            , DisplayInMaintain = false
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
		/// The FORM_NAME Field of BASE_DIGIT Table
		/// </summary>
		private string _form_name;
		[KeyField("FORM_NAME"
			, AliasName = "FORM_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 200
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "FORM_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 6
			, DialogSequence = 6
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 1
			 )]
		public string FORM_NAME
		{
			set { _form_name = value; }
			get { return _form_name; }
		}
		/// <summary>
		/// The COLUMN_DESC Field of BASE_DIGIT Table
		/// </summary>
		private string _column_desc;
		[DataField("COLUMN_DESC"
			, AliasName = "COLUMN_DESC"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
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
		/// The DIGIT_LEN Field of BASE_DIGIT Table
		/// </summary>
		private decimal _digit_len;
		[DataField("DIGIT_LEN"
			, AliasName = "DIGIT_LEN"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "DIGIT_LEN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal DIGIT_LEN
		{
			set { _digit_len = value; }
			get { return _digit_len; }
		}
		/// <summary>
		/// The REMARK Field of BASE_DIGIT Table
		/// </summary>
		private string _remark;
		[DataField("REMARK"
			, AliasName = "REMARK"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = -1
            , DisplayInCondition = true
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
		/// The UPDATE_BY Field of BASE_DIGIT Table
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
		/// The UPDATE_TIME Field of BASE_DIGIT Table
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
		/// BASE_DIGIT Table 
		/// </summary>
		public const string TABLE_NAME="BASE_DIGIT";
		public const String DIGIT_ID_FIELD  ="DIGIT_ID";
		public const String COLUMN_CODE_FIELD  ="COLUMN_CODE";
		public const String FORM_NAME_FIELD  ="FORM_NAME";
		public const String COLUMN_DESC_FIELD  ="COLUMN_DESC";
		public const String DIGIT_LEN_FIELD  ="DIGIT_LEN";
		public const String REMARK_FIELD  ="REMARK";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}