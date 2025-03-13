using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for APP_USR Table
	/// </summary>
	[Serializable]
	[DataTable("APP_USR",ResourceKey = "APP_USR")]
	public class APP_USR: BaseObject
	{
		public APP_USR()
		{
		}
		public APP_USR(DealModel initModel):base(initModel)
		{
		}
		public static APP_USR Convert(BaseObject from)
		{
			return (APP_USR)from;
		}
		/// <summary>
		/// The USR_ID Field of APP_USR Table
		/// </summary>
		private decimal _usr_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.USR_ID = value; }
			get { return USR_ID; }
		}

		[RecordIDField("USR_ID"
			, AliasName = "USR_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "USR_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal USR_ID
		{
			set { _usr_id = value; }
			get { return _usr_id; }
		}
		/// <summary>
		/// The USR_CODE Field of APP_USR Table
		/// </summary>
		private string _usr_code;
		[KeyField("USR_CODE"
			, AliasName = "USR_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "USR_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string USR_CODE
		{
			set { _usr_code = value; }
			get { return _usr_code; }
		}
		/// <summary>
		/// The USR_NAME Field of APP_USR Table
		/// </summary>
		private string _usr_name;
		[DataField("USR_NAME"
			, AliasName = "USR_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USR_NAME
		{
			set { _usr_name = value; }
			get { return _usr_name; }
		}
		/// <summary>
		/// The USR_ORDER Field of APP_USR Table
		/// </summary>
		private decimal _usr_order;
		[DataField("USR_ORDER"
			, AliasName = "USR_ORDER"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_ORDER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal USR_ORDER
		{
			set { _usr_order = value; }
			get { return _usr_order; }
		}
		/// <summary>
		/// The USR_PASSWORD Field of APP_USR Table
		/// </summary>
		private string _usr_password;
		[DataField("USR_PASSWORD"
			, AliasName = "USR_PASSWORD"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_PASSWORD"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USR_PASSWORD
		{
			set { _usr_password = value; }
			get { return _usr_password; }
		}
        /// <summary>
        /// The USR_PASSWORD Field of APP_USR Table
        /// </summary>
        private string _question;
        [DataField("QUESTION"
            , AliasName = "QUESTION"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 50
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "QUESTION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 13
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string QUESTION
        {
            set { _question = value; }
            get { return _question; }
        }
        /// <summary>
        /// The USR_PASSWORD Field of APP_USR Table
        /// </summary>
        private string _answer;
        [DataField("ANSWER"
            , AliasName = "ANSWER"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ANSWER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 14
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ANSWER
        {
            set { _answer = value; }
            get { return _answer; }
        }
		/// <summary>
		/// The USR_SEX Field of APP_USR Table
		/// </summary>
		private string _usr_sex;
		[DataField("USR_SEX"
			, AliasName = "USR_SEX"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_SEX"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USR_SEX
		{
			set { _usr_sex = value; }
			get { return _usr_sex; }
		}
		/// <summary>
		/// The USR_STATUS Field of APP_USR Table
		/// </summary>
		private decimal _usr_status;
		[DataField("USR_STATUS"
			, AliasName = "USR_STATUS"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_STATUS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal USR_STATUS
		{
			set { _usr_status = value; }
			get { return _usr_status; }
		}
		/// <summary>
		/// The USR_TYPE Field of APP_USR Table
		/// </summary>
		private string _usr_type;
        [DataField("USR_TYPE"
            , AliasName = "USR_TYPE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "USR_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string USR_TYPE
        {
            set { _usr_type = value; }
            get { return _usr_type; }
        }
        //[ForeignKeyField("USR_TYPE"
        //    , AliasName = "USR_TYPE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 20
        //    , Width = 100
        //    , DisplayInCondition = false
        //    , DisplayInMaintain = false
        //    , DisplayInDialog = false
        //    , ResourceKey = "USR_TYPE"
        //    , AllowEdit = false
        //    , Frozen = false
        //    , SelectSequence = 15
        //    , IsInsertField = true
        //    , IsUpdateField = true
        //    , ForeignTableName = USER_TYPE.TABLE_NAME
        //    , ForeignTableAliasName = USER_TYPE.TABLE_NAME
        //    , ForeignColumnName = USER_TYPE.U_TYPE_FIELD
        //    , IsMainTableKey = true
        //    , ForeignTableJoinType = TableJoinType.InnerJoin
        //    , TableJoinSequence = 0
        //     )]
        //public string USR_TYPE
        //{
        //    set { _usr_type = value; }
        //    get { return _usr_type; }
        //}

        //private string _user_type_name;
        //[ForeignField("USER_TYPE_NAME"
        //    , AliasName = "USER_TYPE_NAME"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 200
        //    , Width = 100
        //    , DisplayInCondition = false
        //    , DisplayInMaintain = false
        //    , ResourceKey = "USR_TYPE_NAME"
        //    , AllowEdit = false
        //    , SelectSequence = 4
        //    , IsInsertField = false
        //    , IsUpdateField = false
        //    , ForeignTableName = USER_TYPE.TABLE_NAME
        //    , ForeignTableAliasName = USER_TYPE.TABLE_NAME
        //    , ForeignColumnName = USER_TYPE.USER_TYPE_NAME_FIELD
        //     )]
        //public string USER_TYPE_NAME
        //{
        //    set { _user_type_name = value; }
        //    get { return _user_type_name; }
        //}
		/// <summary>
		/// The USR_BIRTHDAY Field of APP_USR Table
		/// </summary>
		private DateTime _usr_birthday;
		[DataField("USR_BIRTHDAY"
			, AliasName = "USR_BIRTHDAY"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_BIRTHDAY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime USR_BIRTHDAY
		{
			set { _usr_birthday = value; }
			get { return _usr_birthday; }
		}
		/// <summary>
		/// The USR_MOBILE Field of APP_USR Table
		/// </summary>
		private string _usr_mobile;
		[DataField("USR_MOBILE"
			, AliasName = "USR_MOBILE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_MOBILE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USR_MOBILE
		{
			set { _usr_mobile = value; }
			get { return _usr_mobile; }
		}
		/// <summary>
		/// The USR_PHOTO Field of APP_USR Table
		/// </summary>
		private string _usr_photo;
		[DataField("USR_PHOTO"
			, AliasName = "USR_PHOTO"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_PHOTO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USR_PHOTO
		{
			set { _usr_photo = value; }
			get { return _usr_photo; }
		}
		/// <summary>
		/// The USR_HOME_EMAIL Field of APP_USR Table
		/// </summary>
		private string _usr_home_email;
		[DataField("USR_HOME_EMAIL"
			, AliasName = "USR_HOME_EMAIL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_HOME_EMAIL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USR_HOME_EMAIL
		{
			set { _usr_home_email = value; }
			get { return _usr_home_email; }
		}
		/// <summary>
		/// The QQ Field of APP_USR Table
		/// </summary>
		private string _qq;
		[DataField("QQ"
			, AliasName = "QQ"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "QQ"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 36
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string QQ
		{
			set { _qq = value; }
			get { return _qq; }
		}
		/// <summary>
		/// The REG_TIME Field of APP_USR Table
		/// </summary>
		private DateTime _reg_time;
		[DataField("REG_TIME"
			, AliasName = "REG_TIME"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REG_TIME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 39
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime REG_TIME
		{
			set { _reg_time = value; }
			get { return _reg_time; }
		}
		/// <summary>
		/// The UP_DATE Field of APP_USR Table
		/// </summary>
		private DateTime _up_date;
		[DataField("UP_DATE"
			, AliasName = "UP_DATE"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "UP_DATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 42
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime UP_DATE
		{
			set { _up_date = value; }
			get { return _up_date; }
		}
		/// <summary>
		/// The ROUND_NUM Field of APP_USR Table
		/// </summary>
		private string _round_num;
		[DataField("ROUND_NUM"
			, AliasName = "ROUND_NUM"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ROUND_NUM"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 45
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ROUND_NUM
		{
			set { _round_num = value; }
			get { return _round_num; }
		}
		/// <summary>
		/// The IS_AVAILABLE Field of APP_USR Table
		/// </summary>
		private string _is_available;
		[DataField("IS_AVAILABLE"
			, AliasName = "IS_AVAILABLE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 2
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "IS_AVAILABLE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 48
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string IS_AVAILABLE
		{
			set { _is_available = value; }
			get { return _is_available; }
		}
		/// <summary>
		/// The USR_HOME_PAGE Field of APP_USR Table
		/// </summary>
		private string _usr_home_page;
		[DataField("USR_HOME_PAGE"
			, AliasName = "USR_HOME_PAGE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_HOME_PAGE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 51
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USR_HOME_PAGE
		{
			set { _usr_home_page = value; }
			get { return _usr_home_page; }
		}
		/// <summary>
		/// The USR_HOME_ADDRESS Field of APP_USR Table
		/// </summary>
		private string _usr_home_address;
		[DataField("USR_HOME_ADDRESS"
			, AliasName = "USR_HOME_ADDRESS"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_HOME_ADDRESS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 54
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USR_HOME_ADDRESS
		{
			set { _usr_home_address = value; }
			get { return _usr_home_address; }
		}
		/// <summary>
		/// The USR_LEAVEWORD Field of APP_USR Table
		/// </summary>
		private string _usr_leaveword;
		[DataField("USR_LEAVEWORD"
			, AliasName = "USR_LEAVEWORD"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 500
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_LEAVEWORD"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 57
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USR_LEAVEWORD
		{
			set { _usr_leaveword = value; }
			get { return _usr_leaveword; }
		}
		/// <summary>
		/// The USR_IDCARD Field of APP_USR Table
		/// </summary>
		private string _usr_idcard;
		[DataField("USR_IDCARD"
			, AliasName = "USR_IDCARD"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_IDCARD"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 60
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USR_IDCARD
		{
			set { _usr_idcard = value; }
			get { return _usr_idcard; }
		}
		/// <summary>
		/// The REMARK Field of APP_USR Table
		/// </summary>
		private string _remark;
		[DataField("REMARK"
			, AliasName = "REMARK"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REMARK"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 63
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
		/// The CREATE_BY Field of APP_USR Table
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
		/// The CREATE_TIME Field of APP_USR Table
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
		/// The UPDATE_BY Field of APP_USR Table
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
		/// The UPDATE_TIME Field of APP_USR Table
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

        private string _token = string.Empty;
        /// <summary>
        /// 登录标记
        /// </summary>
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        private bool _is_login = false;
        /// <summary>
        /// 登录是否成功
        /// </summary>
        public bool IS_Login
        {
            get { return _is_login; }
            set { _is_login = value; }
        }

        private string _err_msg;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string ErrMsg
        {
            get { return _err_msg; }
            set { _err_msg = value; }
        }

		/// <summary>
		/// APP_USR Table 
		/// </summary>
		public const string TABLE_NAME="APP_USR";
		public const String USR_ID_FIELD  ="USR_ID";
		public const String USR_CODE_FIELD  ="USR_CODE";
		public const String USR_NAME_FIELD  ="USR_NAME";
		public const String USR_ORDER_FIELD  ="USR_ORDER";
		public const String USR_PASSWORD_FIELD  ="USR_PASSWORD";
        public const String QUESTION_FIELD = "QUESTION";
        public const String ANSWER_FIELD = "ANSWER";
		public const String USR_SEX_FIELD  ="USR_SEX";
		public const String USR_STATUS_FIELD  ="USR_STATUS";
		public const String USR_TYPE_FIELD  ="USR_TYPE";
		public const String USR_BIRTHDAY_FIELD  ="USR_BIRTHDAY";
		public const String USR_MOBILE_FIELD  ="USR_MOBILE";
		public const String USR_PHOTO_FIELD  ="USR_PHOTO";
		public const String USR_HOME_EMAIL_FIELD  ="USR_HOME_EMAIL";
		public const String QQ_FIELD  ="QQ";
		public const String REG_TIME_FIELD  ="REG_TIME";
		public const String UP_DATE_FIELD  ="UP_DATE";
		public const String ROUND_NUM_FIELD  ="ROUND_NUM";
		public const String IS_AVAILABLE_FIELD  ="IS_AVAILABLE";
		public const String USR_HOME_PAGE_FIELD  ="USR_HOME_PAGE";
		public const String USR_HOME_ADDRESS_FIELD  ="USR_HOME_ADDRESS";
		public const String USR_LEAVEWORD_FIELD  ="USR_LEAVEWORD";
		public const String USR_IDCARD_FIELD  ="USR_IDCARD";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}