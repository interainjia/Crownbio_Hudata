using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for SYS_COLUMN Table
	/// </summary>
	[Serializable]
	[DataTable("SYS_COLUMN",ResourceKey = "SYS_COLUMN")]
	public class SYS_COLUMN: BaseObject
	{
		public SYS_COLUMN()
		{
		}
		public SYS_COLUMN(DealModel initModel):base(initModel)
		{
		}
		public static SYS_COLUMN Convert(BaseObject from)
		{
			return (SYS_COLUMN)from;
		}
		/// <summary>
		/// The COLUMN_ID Field of SYS_COLUMN Table
		/// </summary>
		private decimal _column_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.COLUMN_ID = value; }
			get { return COLUMN_ID; }
		}

		[RecordIDField("COLUMN_ID"
			, AliasName = "COLUMN_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "COLUMN_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal COLUMN_ID
		{
			set { _column_id = value; }
			get { return _column_id; }
		}
		/// <summary>
		/// The COLUMN_CODE Field of SYS_COLUMN Table
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
        /// The COLUMN_PCODE Field of SYS_COLUMN Table
        /// </summary>
        private string _column_pcode;
        [ForeignKeyField("COLUMN_PCODE"
            , AliasName = "COLUMN_PCODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COLUMN_PCODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 5
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = SYS_COLUMN.TABLE_NAME  
          , ForeignTableAliasName = SYS_COLUMN.TABLE_NAME + "1"
          , ForeignColumnName = SYS_COLUMN.COLUMN_CODE_FIELD
          , IsMainTableKey = true
          , ForeignTableJoinType = TableJoinType.LeftOuterJoin
          , TableJoinSequence = 0
           )]
        public string COLUMN_PCODE
        {
            set { _column_pcode = value; }
            get { return _column_pcode; }
        }
        private string _column_pcode_name;
        [ForeignField("COLUMN_PCODE_NAME"
            , AliasName = "COLUMN_PCODE_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = false
            , ResourceKey = "COLUMN_PCODE_NAME"
            , AllowEdit = false
            , SelectSequence = 106
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = SYS_COLUMN.TABLE_NAME
            , ForeignTableAliasName = SYS_COLUMN.TABLE_NAME + "1"
            , ForeignColumnName = SYS_COLUMN.COLUMN_NAME_FIELD
             )]
        public string COLUMN_PCODE_NAME
        {
            set { _column_pcode_name = value; }
            get { return _column_pcode_name; }
        }

		/// <summary>
		/// The COLUMN_NAME Field of SYS_COLUMN Table
		/// </summary>
		private string _column_name;
		[DataField("COLUMN_NAME"
			, AliasName = "COLUMN_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
            , DisplayInCondition = true
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
		/// The COLUMN_DESC Field of SYS_COLUMN Table
		/// </summary>
		private string _column_desc;
		[DataField("COLUMN_DESC"
			, AliasName = "COLUMN_DESC"
			, DataType = DbType.String
			, IsNullable = true
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
		/// The COLUMN_URL Field of SYS_COLUMN Table
		/// </summary>
		private string _column_url;
		[DataField("COLUMN_URL"
			, AliasName = "COLUMN_URL"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 200
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "COLUMN_URL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string COLUMN_URL
		{
			set { _column_url = value; }
			get { return _column_url; }
		}
		/// <summary>
		/// The RIGHT_CLASS Field of SYS_COLUMN Table
		/// </summary>
		private string _right_class;
		[DataField("RIGHT_CLASS"
			, AliasName = "RIGHT_CLASS"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 2
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "RIGHT_CLASS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string RIGHT_CLASS
		{
			set { _right_class = value; }
			get
            {
                return _right_class;
            }
		}
        /// <summary>
        /// The COLUMN_ORDER Field of SYS_COLUMN Table
        /// </summary>
        private string _column_order;
        [DataField("COLUMN_ORDER"
            , AliasName = "COLUMN_ORDER"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 2
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COLUMN_ORDER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 16
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COLUMN_ORDER
        {
            set { _column_order = value; }
            get { return _column_order; }
           
        }
        /// <summary>
        /// The COLUMN_ORDER Field of SYS_COLUMN Table
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
            , SelectSequence = 17
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string IS_SHOW
        {
            set { _is_show = value; }
            get 
            {
                if (_is_show == "Y" || _is_show == "ÊÇ")
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
		/// The CREATE_BY Field of SYS_COLUMN Table
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
		/// The CREATE_TIME Field of SYS_COLUMN Table
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
		/// The UPDATE_BY Field of SYS_COLUMN Table
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
		/// The UPDATE_TIME Field of SYS_COLUMN Table
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
        private string _lang_code;
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
          , SelectSequence = 105
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
            , SelectSequence = 106
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
		/// SYS_COLUMN Table 
		/// </summary>
		public const string TABLE_NAME="SYS_COLUMN";
		public const String COLUMN_ID_FIELD  ="COLUMN_ID";
		public const String COLUMN_CODE_FIELD  ="COLUMN_CODE";
        public const String COLUMN_PCODE_FIELD  ="COLUMN_PCODE";
		public const String COLUMN_NAME_FIELD  ="COLUMN_NAME";
		public const String COLUMN_DESC_FIELD  ="COLUMN_DESC";
		public const String COLUMN_URL_FIELD  ="COLUMN_URL";
		public const String RIGHT_CLASS_FIELD  ="RIGHT_CLASS";
        public const String COLUMN_ORDER_FIELD  ="COLUMN_ORDER";
        public const String IS_SHOW_FIELD  ="IS_SHOW";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
        public const String LANG_CODE_FIELD = "LANG_CODE";
	}
}