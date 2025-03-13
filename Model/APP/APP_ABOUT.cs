using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for APP_ABOUT Table
	/// </summary>
	[Serializable]
	[DataTable("APP_ABOUT",ResourceKey = "APP_ABOUT")]
	public class APP_ABOUT: BaseObject
	{
		public APP_ABOUT()
		{
		}
		public APP_ABOUT(DealModel initModel):base(initModel)
		{
		}
		public static APP_ABOUT Convert(BaseObject from)
		{
			return (APP_ABOUT)from;
		}
		/// <summary>
		/// The ABOUT_ID Field of APP_ABOUT Table
		/// </summary>
		private decimal _about_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.ABOUT_ID = value; }
			get { return ABOUT_ID; }
		}

		[RecordIDField("ABOUT_ID"
			, AliasName = "ABOUT_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "ABOUT_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal ABOUT_ID
		{
			set { _about_id = value; }
			get { return _about_id; }
		}
		/// <summary>
		/// The ABOUT_CODE Field of APP_ABOUT Table
		/// </summary>
		private string _about_code;
		[KeyField("ABOUT_CODE"
			, AliasName = "ABOUT_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "ABOUT_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string ABOUT_CODE
		{
			set { _about_code = value; }
			get { return _about_code; }
		}
		/// <summary>
		/// The ABOUT_TITLE Field of APP_ABOUT Table
		/// </summary>
		private string _about_title;
		[DataField("ABOUT_TITLE"
			, AliasName = "ABOUT_TITLE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ABOUT_TITLE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ABOUT_TITLE
		{
			set { _about_title = value; }
			get { return _about_title; }
		}
		/// <summary>
		/// The ABOUT_DESC Field of APP_ABOUT Table
		/// </summary>
		private string _about_desc;
		[DataField("ABOUT_DESC"
			, AliasName = "ABOUT_DESC"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 500
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ABOUT_DESC"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ABOUT_DESC
		{
			set { _about_desc = value; }
			get { return _about_desc; }
		}
		/// <summary>
		/// The KEYLIST Field of APP_ABOUT Table
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
		/// The LANG_CODE Field of APP_ABOUT Table
		/// </summary>
		private string _lang_code;
        //[DataField("LANG_CODE"
        //    , AliasName = "LANG_CODE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 10
        //    , Width = 100
        //    , DisplayInCondition = true
        //    , DisplayInMaintain = true
        //    , DisplayInDialog = false
        //    , ResourceKey = "LANG_CODE"
        //    , GroupFun = "MAX"
        //    , AllowEdit = false
        //    , Frozen = false
        //    , SelectSequence = 15
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
            , SelectSequence = 15
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
            , DisplayInCondition = false
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
		/// The HTML_URL Field of APP_ABOUT Table
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
			, SelectSequence = 18
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
        /// The Video_MINI Field of APP_ABOUT Table
        /// </summary>
        //private string _video_mini;
        //[DataField("Video_MINI"
        //    , AliasName = "Video_MINI"
        //    , DataType = DbType.String
        //    , IsNullable = true
        //    , Size = 100
        //    , Width = 100
        //    , DisplayInCondition = false
        //    , DisplayInMaintain = true
        //    , DisplayInDialog = false
        //    , ResourceKey = "Video_MINI"
        //    , GroupFun = "MAX"
        //    , AllowEdit = false
        //    , Frozen = false
        //    , SelectSequence = 18
        //    , DialogSequence = -1
        //    , IsInsertField = true
        //    , IsUpdateField = true
        //     )]
        //public string Video_MINI
        //{
        //    set { _video_mini = value; }
        //    get { return _video_mini; }
        //}
		/// <summary>
		/// The CONTENT Field of APP_ABOUT Table
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
			, SelectSequence = 21
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
		/// The CREATE_BY Field of APP_ABOUT Table
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
		/// The CREATE_TIME Field of APP_ABOUT Table
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
		/// The UPDATE_BY Field of APP_ABOUT Table
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
		/// The UPDATE_TIME Field of APP_ABOUT Table
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
		/// APP_ABOUT Table 
		/// </summary>
		public const string TABLE_NAME="APP_ABOUT";
		public const String ABOUT_ID_FIELD  ="ABOUT_ID";
		public const String ABOUT_CODE_FIELD  ="ABOUT_CODE";
		public const String ABOUT_TITLE_FIELD  ="ABOUT_TITLE";
		public const String ABOUT_DESC_FIELD  ="ABOUT_DESC";
		public const String KEYLIST_FIELD  ="KEYLIST";
		public const String LANG_CODE_FIELD  ="LANG_CODE";
		public const String HTML_URL_FIELD  ="HTML_URL";
        //public const String Video_MINI_FIELD  ="Video_MINI";
		public const String CONTENT_FIELD  ="CONTENT";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}