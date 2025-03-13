using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for APP_MSG Table
	/// </summary>
	[Serializable]
	[DataTable("APP_MSG",ResourceKey = "APP_MSG")]
	public class APP_MSG: BaseObject
	{
		public APP_MSG()
		{
		}
		public APP_MSG(DealModel initModel):base(initModel)
		{
		}
		public static APP_MSG Convert(BaseObject from)
		{
			return (APP_MSG)from;
		}
		/// <summary>
		/// The MSG_ID Field of APP_MSG Table
		/// </summary>
		private decimal _msg_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.MSG_ID = value; }
			get { return MSG_ID; }
		}

		[RecordIDField("MSG_ID"
			, AliasName = "MSG_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "MSG_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal MSG_ID
		{
			set { _msg_id = value; }
			get { return _msg_id; }
		}
		/// <summary>
		/// The SYS_NO Field of APP_MSG Table
		/// </summary>
		private string _sys_no;
		[KeyField("SYS_NO"
			, AliasName = "SYS_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "SYS_NO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string SYS_NO
		{
			set { _sys_no = value; }
			get { return _sys_no; }
		}
		/// <summary>
		/// The MSG_TYPE Field of APP_MSG Table
		/// </summary>
		private string _msg_type;
        [DataField("MSG_TYPE"
            , AliasName = "MSG_TYPE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 2
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MSG_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MSG_TYPE
        {
            set { _msg_type = value; }
            get { return _msg_type; }
        }
        //[ForeignKeyField("MSG_TYPE"
        //    , AliasName = "MSG_TYPE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 20
        //    , Width = 100
        //    , DisplayInCondition = false
        //    , DisplayInMaintain = false
        //    , DisplayInDialog = false
        //    , ResourceKey = "MSG_TYPE"
        //    , AllowEdit = false
        //    , Frozen = false
        //    , SelectSequence = 6
        //    , IsInsertField = true
        //    , IsUpdateField = true
        //    , ForeignTableName = MG_TYPE.TABLE_NAME
        //    , ForeignTableAliasName = MG_TYPE.TABLE_NAME
        //    , ForeignColumnName = MG_TYPE.MSG_TYPE_FIELD
        //    , IsMainTableKey = true
        //    , ForeignTableJoinType = TableJoinType.InnerJoin
        //    , TableJoinSequence = 0
        //     )]
        //public string MSG_TYPE
        //{
        //    set { _msg_type = value; }
        //    get { return _msg_type; }
        //}

        //private string _msg_type_name;
        //[ForeignField("MSG_TYPE_NAME"
        //    , AliasName = "MSG_TYPE_NAME"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 200
        //    , Width = 100
        //    , DisplayInCondition = false
        //    , DisplayInMaintain = false
        //    , ResourceKey = "MSG_TYPE_NAME"
        //    , AllowEdit = false
        //    , SelectSequence = 4
        //    , IsInsertField = false
        //    , IsUpdateField = false
        //    , ForeignTableName = MG_TYPE.TABLE_NAME
        //    , ForeignTableAliasName = MG_TYPE.TABLE_NAME
        //    , ForeignColumnName = MG_TYPE.MSG_TYPE_NAME_FIELD
        //     )]
        //public string MSG_TYPE_NAME
        //{
        //    set { _msg_type_name = value; }
        //    get { return _msg_type_name; }
        //}

		/// <summary>
		/// The USER_ID Field of APP_MSG Table
		/// </summary>
		private string _user_id;
		[DataField("USER_ID"
			, AliasName = "USER_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USER_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USER_ID
		{
			set { _user_id = value; }
			get { return _user_id; }
		}
		/// <summary>
		/// The USER_NAME Field of APP_MSG Table
		/// </summary>
		private string _user_name;
		[DataField("USER_NAME"
			, AliasName = "USER_NAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
            , DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USER_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USER_NAME
		{
			set { _user_name = value; }
			get { return _user_name; }
		}
		/// <summary>
		/// The TITLE Field of APP_MSG Table
		/// </summary>
		private string _title;
		[DataField("TITLE"
			, AliasName = "TITLE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 100
			, Width = 100
            , DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TITLE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TITLE
		{
			set { _title = value; }
			get { return _title; }
		}
		/// <summary>
		/// The CONTENT Field of APP_MSG Table
		/// </summary>
		private string _content;
		[DataField("CONTENT"
			, AliasName = "CONTENT"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 2000
			, Width = 300
            , DisplayInCondition = true
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
		/// The REPLY Field of APP_MSG Table
		/// </summary>
		private string _reply;
		[DataField("REPLY"
			, AliasName = "REPLY"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 2000
			, Width = 300
            , DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REPLY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string REPLY
		{
			set { _reply = value; }
			get { return _reply; }
		}
		/// <summary>
		/// The CREATE_BY Field of APP_MSG Table
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
		/// The CREATE_TIME Field of APP_MSG Table
		/// </summary>
		private DateTime _create_time;
		[DataField("CREATE_TIME"
			, AliasName = "CREATE_TIME"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
            , DisplayInCondition = true
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
		/// The UPDATE_BY Field of APP_MSG Table
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
		/// The UPDATE_TIME Field of APP_MSG Table
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
		/// APP_MSG Table 
		/// </summary>
		public const string TABLE_NAME="APP_MSG";
		public const String MSG_ID_FIELD  ="MSG_ID";
		public const String SYS_NO_FIELD  ="SYS_NO";
		public const String MSG_TYPE_FIELD  ="MSG_TYPE";
		public const String USER_ID_FIELD  ="USER_ID";
		public const String USER_NAME_FIELD  ="USER_NAME";
		public const String TITLE_FIELD  ="TITLE";
		public const String CONTENT_FIELD  ="CONTENT";
		public const String REPLY_FIELD  ="REPLY";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}