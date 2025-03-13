using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for APP_PRODUCT Table
	/// </summary>
	[Serializable]
	[DataTable("APP_PRODUCT",ResourceKey = "APP_PRODUCT")]
	public class APP_PRODUCT: BaseObject
	{
		public APP_PRODUCT()
		{
		}
		public APP_PRODUCT(DealModel initModel):base(initModel)
		{
		}
		public static APP_PRODUCT Convert(BaseObject from)
		{
			return (APP_PRODUCT)from;
		}
		/// <summary>
		/// The PRODCUT_ID Field of APP_PRODUCT Table
		/// </summary>
		private decimal _prodcut_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.PRODCUT_ID = value; }
			get { return PRODCUT_ID; }
		}

		[RecordIDField("PRODCUT_ID"
			, AliasName = "PRODCUT_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "PRODCUT_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal PRODCUT_ID
		{
			set { _prodcut_id = value; }
			get { return _prodcut_id; }
		}
		/// <summary>
		/// The PRODUCT_CODE Field of APP_PRODUCT Table
		/// </summary>
		private string _product_code;
		[KeyField("PRODUCT_CODE"
			, AliasName = "PRODUCT_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "PRODUCT_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string PRODUCT_CODE
		{
			set { _product_code = value; }
			get { return _product_code; }
		}

        /// <summary>
        /// The PRODUCT_MODEL Field of APP_PRODUCT Table
        /// </summary>
        private string _product_model;
        [DataField("PRODUCT_MODEL"
            , AliasName = "PRODUCT_MODEL"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PRODUCT_MODEL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 4
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PRODUCT_MODEL
        {
            set { _product_model = value; }
            get { return _product_model; }
        }

        /// <summary>
        /// The PRODUCT_MODEL Field of APP_PRODUCT Table
        /// </summary>
        private decimal _product_price;
        [DataField("PRODUCT_PRICE"
           , AliasName = "PRODUCT_PRICE"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 10
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = true
            , DisplayInDialog = false
           , ResourceKey = "PRODUCT_PRICE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 5
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal PRODUCT_PRICE
        {
            set { _product_price = value; }
            get { return _product_price; }
        }

		/// <summary>
		/// The PRODUCT_TYPE Field of APP_PRODUCT Table
		/// </summary>
		private string _product_type;
        //[DataField("PRODUCT_TYPE"
        //    , AliasName = "PRODUCT_TYPE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 20
        //    , Width = 100
        //    , DisplayInCondition = true
        //    , DisplayInMaintain = true
        //    , DisplayInDialog = false
        //    , ResourceKey = "PRODUCT_TYPE"
        //    , GroupFun = "MAX"
        //    , AllowEdit = false
        //    , Frozen = false
        //    , SelectSequence = 6
        //    , DialogSequence = -1
        //    , IsInsertField = true
        //    , IsUpdateField = true
        //     )]
        //public string PRODUCT_TYPE
        //{
        //    set { _product_type = value; }
        //    get { return _product_type; }
        //}
        [ForeignKeyField("PRODUCT_TYPE"
            , AliasName = "PRODUCT_TYPE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PRODUCT_TYPE"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = APP_PRODUCT_TYPE.TABLE_NAME
            , ForeignTableAliasName = APP_PRODUCT_TYPE.TABLE_NAME
            , ForeignColumnName = APP_PRODUCT_TYPE.PRODUCT_TYPE_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.InnerJoin
            , TableJoinSequence = 0
             )]
        public string PRODUCT_TYPE
        {
            set { _product_type = value; }
            get { return _product_type; }
        }

        private string _product_type_name;
        [ForeignField("PRODUCT_TYPE_NAME"
            , AliasName = "PRODUCT_TYPE_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 200
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , ResourceKey = "PRODUCT_TYPE_NAME"
            , AllowEdit = false
            , SelectSequence = 4
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = APP_PRODUCT_TYPE.TABLE_NAME
            , ForeignTableAliasName = APP_PRODUCT_TYPE.TABLE_NAME
            , ForeignColumnName = APP_PRODUCT_TYPE.PRODUCT_TYPE_NAME_FIELD
             )]
        public string PRODUCT_TYPE_NAME
        {
            set { _product_type_name = value; }
            get { return _product_type_name; }
        }
		/// <summary>
		/// The PRODUCT_NAME Field of APP_PRODUCT Table
		/// </summary>
		private string _product_name;
		[DataField("PRODUCT_NAME"
			, AliasName = "PRODUCT_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PRODUCT_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PRODUCT_NAME
		{
			set { _product_name = value; }
			get { return _product_name; }
		}
		/// <summary>
		/// The KEYLIST Field of APP_PRODUCT Table
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
		/// The PRODUCT_DESC Field of APP_PRODUCT Table
		/// </summary>
		private string _product_desc;
		[DataField("PRODUCT_DESC"
			, AliasName = "PRODUCT_DESC"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 500
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PRODUCT_DESC"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PRODUCT_DESC
		{
			set { _product_desc = value; }
			get { return _product_desc; }
		}
		/// <summary>
		/// The PICTUR_MINI Field of APP_PRODUCT Table
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
			, SelectSequence = 18
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
		/// The LANG_CODE Field of APP_PRODUCT Table
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
        /// The IS_SHOW Field of APP_PRODUCT Table
        /// </summary>
        private string _is_show;
        [DataField("IS_SHOW"
            , AliasName = "IS_SHOW"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 2
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_SHOW"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 23
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string IS_SHOW
        {
            set { _is_show = value; }
            get { return _is_show; }
        }

		/// <summary>
		/// The HTML_URL Field of APP_PRODUCT Table
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
		/// The CONTENT Field of APP_PRODUCT Table
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
		/// The CREATE_BY Field of APP_PRODUCT Table
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
		/// The CREATE_TIME Field of APP_PRODUCT Table
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
		/// The UPDATE_BY Field of APP_PRODUCT Table
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
		/// The UPDATE_TIME Field of APP_PRODUCT Table
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
		/// APP_PRODUCT Table 
		/// </summary>
		public const string TABLE_NAME="APP_PRODUCT";
		public const String PRODCUT_ID_FIELD  ="PRODCUT_ID";
		public const String PRODUCT_CODE_FIELD  ="PRODUCT_CODE";

        public const String PRODUCT_MODEL_FIELD = "PRODUCT_MODEL";
        public const String PRODUCT_PRICE_FIELD = "PRODUCT_PRICE";

		public const String PRODUCT_TYPE_FIELD  ="PRODUCT_TYPE";
		public const String PRODUCT_NAME_FIELD  ="PRODUCT_NAME";
		public const String KEYLIST_FIELD  ="KEYLIST";
		public const String PRODUCT_DESC_FIELD  ="PRODUCT_DESC";
		public const String PICTUR_MINI_FIELD  ="PICTUR_MINI";
		public const String LANG_CODE_FIELD  ="LANG_CODE";
        public const String IS_SHOW_FIELD  ="IS_SHOW";
		public const String HTML_URL_FIELD  ="HTML_URL";
		public const String CONTENT_FIELD  ="CONTENT";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}