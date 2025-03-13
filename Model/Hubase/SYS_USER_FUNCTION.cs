using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for SYS_USER_FUNCTION Table
	/// </summary>
	[Serializable]
	[DataTable("SYS_USER_FUNCTION",ResourceKey = "SYS_USER_FUNCTION")]
	public class SYS_USER_FUNCTION: BaseObject
	{
		public SYS_USER_FUNCTION()
		{
		}
		public SYS_USER_FUNCTION(DealModel initModel):base(initModel)
		{
		}
		public static SYS_USER_FUNCTION Convert(BaseObject from)
		{
			return (SYS_USER_FUNCTION)from;
		}
		/// <summary>
		/// The SYS_USER_FUNCTION_ID Field of SYS_USER_FUNCTION Table
		/// </summary>
		private decimal _sys_user_function_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.SYS_USER_FUNCTION_ID = value; }
			get { return SYS_USER_FUNCTION_ID; }
		}

		[RecordIDField("SYS_USER_FUNCTION_ID"
			, AliasName = "SYS_USER_FUNCTION_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "SYS_USER_FUNCTION_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal SYS_USER_FUNCTION_ID
		{
			set { _sys_user_function_id = value; }
			get { return _sys_user_function_id; }
		}
		/// <summary>
		/// The USER_ID Field of SYS_USER_FUNCTION Table
		/// </summary>
		private decimal _user_id;
		[DataField("USER_ID"
			, AliasName = "USER_ID"
			, DataType = DbType.Decimal
			, IsNullable = true
			, Size = 18
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USER_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal USER_ID
		{
			set { _user_id = value; }
			get { return _user_id; }
		}
		/// <summary>
		/// The FUNCTION_ID Field of SYS_USER_FUNCTION Table
		/// </summary>
		private decimal _function_id;
        [ForeignKeyField("FUNCTION_ID"
			, AliasName = "FUNCTION_ID"
			, DataType = DbType.Decimal
			, IsNullable = true
			, Size = 18
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FUNCTION_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
                  , ForeignTableName = HUBASE_FUNCTION.TABLE_NAME
            , ForeignTableAliasName = HUBASE_FUNCTION.TABLE_NAME
            , ForeignColumnName = HUBASE_FUNCTION.HUBASE_FUNCTION_ID_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 0
             )]
		public decimal FUNCTION_ID
		{
			set { _function_id = value; }
			get { return _function_id; }
		}
        private string _fuction_name;
        [ForeignField("FUNCTION_NAME"
            , AliasName = "FUNCTION_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = false
            , ResourceKey = "FUNCTION_NAME"
            , AllowEdit = false
            , SelectSequence = 9
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = HUBASE_FUNCTION.TABLE_NAME
            , ForeignTableAliasName = HUBASE_FUNCTION.TABLE_NAME
            , ForeignColumnName = HUBASE_FUNCTION.FUNCTION_NAME_FIELD
             )]
        public string FUNCTION_NAME
        {
            set { _fuction_name = value; }
            get { return _fuction_name; }
        }
        private string _operate;
        [ForeignField("OPERATE"
            , AliasName = "OPERATE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = false
            , ResourceKey = "OPERATE"
            , AllowEdit = false
            , SelectSequence = 11
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = HUBASE_FUNCTION.TABLE_NAME
            , ForeignTableAliasName = HUBASE_FUNCTION.TABLE_NAME
            , ForeignColumnName = HUBASE_FUNCTION.OPERATE_FIELD
             )]
        public string OPERATE
        {
            set { _operate = value; }
            get { return _operate; }
        }
		/// <summary>
		/// SYS_USER_FUNCTION Table 
		/// </summary>
		public const string TABLE_NAME="SYS_USER_FUNCTION";
		public const String SYS_USER_FUNCTION_ID_FIELD  ="SYS_USER_FUNCTION_ID";
		public const String USER_ID_FIELD  ="USER_ID";
		public const String FUNCTION_ID_FIELD  ="FUNCTION_ID";
        public const String FUNCTION_NAME_FIELD = "FUNCTION_NAME";
        public const String OPERATE_FIELD = "OPERATE";
	}
}