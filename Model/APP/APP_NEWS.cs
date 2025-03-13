using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for APP_NEWS Table
	/// </summary>
	[Serializable]
	[DataTable("APP_NEWS",ResourceKey = "APP_NEWS")]
	public class APP_NEWS: BaseObject
	{
		public APP_NEWS()
		{
		}
		public APP_NEWS(DealModel initModel):base(initModel)
		{
		}
		public static APP_NEWS Convert(BaseObject from)
		{
			return (APP_NEWS)from;
		}
		/// <summary>
		/// The NEWS_ID Field of APP_NEWS Table
		/// </summary>
		private decimal _news_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.NEWS_ID = value; }
			get { return NEWS_ID; }
		}

		[RecordIDField("NEWS_ID"
			, AliasName = "NEWS_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "NEWS_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal NEWS_ID
		{
			set { _news_id = value; }
			get { return _news_id; }
		}
		/// <summary>
		/// The SYS_NO Field of APP_NEWS Table
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
		/// The NEWS_TYPE Field of APP_NEWS Table
		/// </summary>
		private string _news_type;
        //[DataField("NEWS_TYPE"
        //    , AliasName = "NEWS_TYPE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 20
        //    , Width = 100
        //    , DisplayInCondition = false
        //    , DisplayInMaintain = true
        //    , DisplayInDialog = false
        //    , ResourceKey = "NEWS_TYPE"
        //    , GroupFun = "MAX"
        //    , AllowEdit = false
        //    , Frozen = false
        //    , SelectSequence = 6
        //    , DialogSequence = -1
        //    , IsInsertField = true
        //    , IsUpdateField = true
        //     )]
        //public string NEWS_TYPE
        //{
        //    set { _news_type = value; }
        //    get { return _news_type; }
        //}
        [ForeignKeyField("NEWS_TYPE"
            , AliasName = "NEWS_TYPE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "NEWS_TYPE"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = APP_NEWS_TYPE.TABLE_NAME
            , ForeignTableAliasName = APP_NEWS_TYPE.TABLE_NAME
            , ForeignColumnName = APP_NEWS_TYPE.NEWS_TYPE_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.InnerJoin
            , TableJoinSequence = 0
             )]
        public string NEWS_TYPE
        {
            set { _news_type = value; }
            get { return _news_type; }
        }

        private string _news_type_name;
        [ForeignField("NEWS_TYPE_NAME"
            , AliasName = "NEWS_TYPE_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = false
            , ResourceKey = "NEWS_TYPE_NAME"
            , AllowEdit = false
            , SelectSequence = 4
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = APP_NEWS_TYPE.TABLE_NAME
            , ForeignTableAliasName = APP_NEWS_TYPE.TABLE_NAME
            , ForeignColumnName = APP_NEWS_TYPE.NEWS_TYPE_NAME_FIELD
             )]
        public string NEWS_TYPE_NAME
        {
            set { _news_type_name = value; }
            get { return _news_type_name; }
        }
		/// <summary>
		/// The SOURCE Field of APP_NEWS Table
		/// </summary>
		private string _source;
		[DataField("SOURCE"
			, AliasName = "SOURCE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
            , DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SOURCE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SOURCE
		{
			set { _source = value; }
			get { return _source; }
		}
		/// <summary>
		/// The TITLE Field of APP_NEWS Table
		/// </summary>
		private string _title;
		[DataField("TITLE"
			, AliasName = "TITLE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 100
			, Width = 200
            , DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TITLE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
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
		/// The DATE_PUBLISH Field of APP_NEWS Table
		/// </summary>
        private DateTime _date_publish = DateTime.MinValue;
		[DataField("DATE_PUBLISH"
			, AliasName = "DATE_PUBLISH"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, Width = 100
            , DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_PUBLISH"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_PUBLISH
		{
			set { _date_publish = value; }
			get { return _date_publish; }
		}

        public string DATE_PUBLISH_F
        {
            get
            {
                if (_date_publish != DateTime.MinValue)
                {
                    return _date_publish.ToShortDateString();
                }
                else
                {
                    return "";
                }
            }
        }

		/// <summary>
		/// The KEYLIST Field of APP_NEWS Table
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
			, SelectSequence = 18
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
		/// The LANG_CODE Field of APP_NEWS Table
		/// </summary>
		private string _lang_code;
        //[DataField("LANG_CODE"
        //    , AliasName = "LANG_CODE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 10
        //    , Width = 100
        //    , DisplayInCondition = false
        //    , DisplayInMaintain = true
        //    , DisplayInDialog = false
        //    , ResourceKey = "LANG_CODE"
        //    , GroupFun = "MAX"
        //    , AllowEdit = false
        //    , Frozen = false
        //    , SelectSequence = 21
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
            , SelectSequence = 21
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
        /// The PICTUR_MINI Field of APP_NEWS Table
        /// </summary>
        private string _pictur_mini;
        [DataField("PICTUR_MINI"
            , AliasName = "PICTUR_MINI"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PICTUR_MINI"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 22
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PICTUR_MINI
        {
            set { _pictur_mini = value; }
            get { return _pictur_mini; }
        }
		/// <summary>
		/// The HTML_URL Field of APP_NEWS Table
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
			, SelectSequence = 24
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
		/// The CONTENT Field of APP_NEWS Table
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
			, SelectSequence = 27
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
		/// The IS_HEAD Field of APP_NEWS Table
		/// </summary>
		private string _is_head;
        [DataField("IS_HEAD"
            , AliasName = "IS_HEAD"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 2
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_HEAD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
   
        public string IS_HEAD
        {
            set { _is_head = value; }
            get
            {
                if (_is_head =="Y" ||_is_head =="ÊÇ")
                {
                    return Crownbio.Language.LanguageHelper.GetResourceText("Y");
                }
                else
                {
                    return Crownbio.Language.LanguageHelper.GetResourceText("N");
                }
            }
        }
		/// <summary>
		/// The CREATE_BY Field of APP_NEWS Table
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
		/// The CREATE_TIME Field of APP_NEWS Table
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
		/// The UPDATE_BY Field of APP_NEWS Table
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
		/// The UPDATE_TIME Field of APP_NEWS Table
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
        private string _doc_no;
        [DataField("DOC_NO"
            , AliasName = "DOC_NO"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "DOC_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 105
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DOC_NO
        {
            set { _doc_no = value; }
            get { return _doc_no; }
        }
		/// <summary>
		/// APP_NEWS Table 
		/// </summary>
		public const string TABLE_NAME="APP_NEWS";
		public const String NEWS_ID_FIELD  ="NEWS_ID";
		public const String SYS_NO_FIELD  ="SYS_NO";
		public const String NEWS_TYPE_FIELD  ="NEWS_TYPE";
		public const String SOURCE_FIELD  ="SOURCE";
		public const String TITLE_FIELD  ="TITLE";
		public const String DATE_PUBLISH_FIELD  ="DATE_PUBLISH";
		public const String KEYLIST_FIELD  ="KEYLIST";
		public const String LANG_CODE_FIELD  ="LANG_CODE";
		public const String HTML_URL_FIELD  ="HTML_URL";
		public const String CONTENT_FIELD  ="CONTENT";
		public const String IS_HEAD_FIELD  ="IS_HEAD";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
        public const String DOC_NO_FIELD = "DOC_NO";
        public const String NEWS_TYPE_NAME_FIELD = "NEWS_TYPE_NAME";
        public const String PICTUR_MINI_FIELD = "PICTUR_MINI";
	}
}