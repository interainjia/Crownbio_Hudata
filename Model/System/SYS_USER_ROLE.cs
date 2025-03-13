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
	[DataTable("SYS_USER_ROLE",ResourceKey = "SYS_USER_ROLE")]
	public class SYS_USER_ROLE: BaseObject
	{
		public SYS_USER_ROLE()
		{
		}
		public SYS_USER_ROLE(DealModel initModel):base(initModel)
		{
		}
		public static SYS_USER_ROLE Convert(BaseObject from)
		{
			return (SYS_USER_ROLE)from;
		}
		/// <summary>
		/// The USER_ROLE_ID Field of SYS_USER_ROLE Table
		/// </summary>
		private decimal _user_role_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.USER_ROLE_ID = value; }
			get { return USER_ROLE_ID; }
		}

        /// <summary>
        /// 覆盖P_ID的值
        /// </summary>
        public override decimal PID
        {
            set
            {
                base.PID = value;
                this.USER_ID = value;
            }
            get { return USER_ID; }
        }

        /// <summary>
        /// 覆盖CODE的值
        /// </summary>
        public override string CODE
        {
            set
            {
                base.CODE = value;
                this.ROLE_NO = value;
            }
            get { return ROLE_NO; }
        }

		[RecordIDField("USER_ROLE_ID"
			, AliasName = "USER_ROLE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "USER_ROLE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal USER_ROLE_ID
		{
			set { _user_role_id = value; }
			get { return _user_role_id; }
		}
		/// <summary>
		/// The USER_ID Field of SYS_USER_ROLE Table
		/// </summary>
		private decimal _user_id;
		[KeyField("USER_ID"
			, AliasName = "USER_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width =100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "USER_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public decimal USER_ID
		{
			set { _user_id = value; }
			get { return _user_id; }
		}
		/// <summary>
		/// The ROLE_NO Field of SYS_USER_ROLE Table
		/// </summary>
		private string _role_no;
		[KeyField("ROLE_NO"
			, AliasName = "ROLE_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "ROLE_NO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 6
			, DialogSequence = 6
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 1
			 )]
        [ForeignKeyField("ROLE_NO"
           , AliasName = "ROLE_NO"
           , DataType = DbType.Decimal
           , IsNullable = false
           , Size = 20
           , Width = 100
           , DisplayInCondition = false
           , DisplayInMaintain = false
           , ResourceKey = "ROLE_NO"
           , AllowEdit = false
           , Frozen = false
           , SelectSequence = -1
           , IsInsertField = false
           , IsUpdateField = false
           , ForeignTableName = SYS_ROLE.TABLE_NAME
           , ForeignTableAliasName = SYS_ROLE.TABLE_NAME
           , ForeignColumnName = SYS_ROLE.ROLE_NO_FIELD
           , IsMainTableKey = true
           , ForeignTableJoinType = TableJoinType.LeftOuterJoin
           , TableJoinSequence = 0
            )]
        public string ROLE_NO
        {
            set { _role_no = value; }
            get { return _role_no; }
        }

        //private string _role_type;
        //[ForeignField("ROLE_TYPE"
        //    , AliasName = "ROLE_TYPE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 80
        //    , Width = 100
        //    , DisplayInCondition = false
        //    , DisplayInMaintain = false
        //    , ResourceKey = "ROLE_TYPE"
        //    , AllowEdit = false
        //    , SelectSequence = 7
        //    , IsInsertField = false
        //    , IsUpdateField = false
        //    , ForeignTableName = SYS_ROLE.TABLE_NAME
        //    , ForeignTableAliasName = SYS_ROLE.TABLE_NAME
        //    , ForeignColumnName = SYS_ROLE.ROLE_TYPE_FIELD
        //     )]
        //public string ROLE_TYPE
        //{
        //    set { _role_type = value; }
        //    get { return _role_type; }
        //}
	
		/// <summary>
		/// The CREATE_BY Field of SYS_USER_ROLE Table
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
		/// The CREATE_TIME Field of SYS_USER_ROLE Table
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
		/// The UPDATE_BY Field of SYS_USER_ROLE Table
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
		/// The UPDATE_TIME Field of SYS_USER_ROLE Table
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
		/// SYS_USER_ROLE Table 
		/// </summary>
		public const string TABLE_NAME="SYS_USER_ROLE";
		public const String USER_ROLE_ID_FIELD  ="USER_ROLE_ID";
		public const String USER_ID_FIELD  ="USER_ID";
		public const String ROLE_NO_FIELD  ="ROLE_NO";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}