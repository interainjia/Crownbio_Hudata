using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for APP_NEWS_TYPE Table
	/// </summary>
	[Serializable]
	[DataTable("APP_NEWS_TYPE",ResourceKey = "APP_NEWS_TYPE")]
	public class APP_NEWS_TYPE: BaseObject
	{
		public APP_NEWS_TYPE()
		{
		}
		public APP_NEWS_TYPE(DealModel initModel):base(initModel)
		{
		}
		public static APP_NEWS_TYPE Convert(BaseObject from)
		{
			return (APP_NEWS_TYPE)from;
		}
		/// <summary>
		/// The NEWS_TYPE_ID Field of APP_NEWS_TYPE Table
		/// </summary>
		private decimal _news_type_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.NEWS_TYPE_ID = value; }
			get { return NEWS_TYPE_ID; }
		}

		[RecordIDField("NEWS_TYPE_ID"
			, AliasName = "NEWS_TYPE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "NEWS_TYPE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal NEWS_TYPE_ID
		{
			set { _news_type_id = value; }
			get { return _news_type_id; }
		}
		/// <summary>
		/// The NEWS_TYPE Field of APP_NEWS_TYPE Table
		/// </summary>
		private string _news_type;
		[KeyField("NEWS_TYPE"
			, AliasName = "NEWS_TYPE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 10
			, Width =100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "NEWS_TYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string NEWS_TYPE
		{
			set { _news_type = value; }
			get { return _news_type; }
		}
		/// <summary>
		/// The NEWS_TYPE_NAME Field of APP_NEWS_TYPE Table
		/// </summary>
		private string _news_type_name;
		[DataField("NEWS_TYPE_NAME"
			, AliasName = "NEWS_TYPE_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
            , DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "NEWS_TYPE_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string NEWS_TYPE_NAME
		{
			set { _news_type_name = value; }
			get { return _news_type_name; }
		}
		/// <summary>
		/// The LANG_CODE Field of APP_NEWS_TYPE Table
		/// </summary>
        private string _lang_code;
        //[DataField("LANG_CODE"
        //    , AliasName = "LANG_CODE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 50
        //    , Width = 100
        //    , DisplayInCondition = true
        //    , DisplayInMaintain = true
        //    , DisplayInDialog = false
        //    , ResourceKey = "LANG_CODE"
        //    , GroupFun = "MAX"
        //    , AllowEdit = false
        //    , Frozen = false
        //    , SelectSequence = 9
        //    , DialogSequence = -1
        //    , IsInsertField = true
        //    , IsUpdateField = true
        //     )]
        //public string LANG_CODE
        //{
        //    set { _lang_code = value; }
        //    get { return _lang_code; }
        //}
        [ForeignKeyField("LANG_CODE"
            , AliasName = "LANG_CODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "LANG_CODE"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = APP_LANG.TABLE_NAME
            , ForeignTableAliasName = APP_LANG.TABLE_NAME
            , ForeignColumnName = APP_LANG.LANG_CODE_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.InnerJoin
            , TableJoinSequence = 0
             )]
        public string LANG_CODE
        {
            set { _lang_code = value; }
            get { return _lang_code; }
        }

        private string _lang_name;
        [ForeignField("LANG_NAME"
            , AliasName = "LANG_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = false
            , ResourceKey = "LANG_NAME"
            , AllowEdit = false
            , SelectSequence = 4
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = APP_LANG.TABLE_NAME
            , ForeignTableAliasName = APP_LANG.TABLE_NAME
            , ForeignColumnName = APP_LANG.LANG_NAME_FIELD
             )]
        public string LANG_NAME
        {
            set { _lang_name = value; }
            get { return _lang_name; }
        }
		/// <summary>
		/// The CREATE_BY Field of APP_NEWS_TYPE Table
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
		/// The CREATE_TIME Field of APP_NEWS_TYPE Table
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
		/// The UPDATE_BY Field of APP_NEWS_TYPE Table
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
		/// The UPDATE_TIME Field of APP_NEWS_TYPE Table
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
		/// APP_NEWS_TYPE Table 
		/// </summary>
		public const string TABLE_NAME="APP_NEWS_TYPE";
		public const String NEWS_TYPE_ID_FIELD  ="NEWS_TYPE_ID";
		public const String NEWS_TYPE_FIELD  ="NEWS_TYPE";
		public const String NEWS_TYPE_NAME_FIELD  ="NEWS_TYPE_NAME";
		public const String LANG_CODE_FIELD  ="LANG_CODE";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}