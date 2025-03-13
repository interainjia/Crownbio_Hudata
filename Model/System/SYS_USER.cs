using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for SYS_USER Table
    /// </summary>
    [Serializable]
    [DataTable("SYS_USER", ResourceKey = "SYS_USER")]
    public class SYS_USER : BaseObject
    {
        public SYS_USER()
        {
        }
        public SYS_USER(DealModel initModel)
            : base(initModel)
        {
        }
        public static SYS_USER Convert(BaseObject from)
        {
            return (SYS_USER)from;
        }
        /// <summary>
        /// The USER_ID Field of SYS_USER Table
        /// </summary>
        private decimal _user_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.USER_ID = value;
            }
            get { return USER_ID; }
        }
        public override string CODE
        {
            set
            {
                base.CODE = value;
                this.USER_CODE = value;
            }
            get { return USER_CODE; }
        }
        [RecordIDField("USER_ID"
            , AliasName = "USER_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "USER_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// The USER_CODE Field of SYS_USER Table
        /// </summary>
        private string _user_code;
        [KeyField("USER_CODE"
            , AliasName = "USER_CODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "USER_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string USER_CODE
        {
            set { _user_code = value; }
            get { return _user_code; }
        }
        /// <summary>
        /// The USER_PWD Field of SYS_USER Table
        /// </summary>
        private string _user_pwd;
        [DataField("USER_PWD"
            , AliasName = "USER_PWD"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 120
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "USER_PWD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string USER_PWD
        {
            set { _user_pwd = value; }
            get { return _user_pwd; }
        }
        /// <summary>
        /// The USER_NAME Field of SYS_USER Table
        /// </summary>
        private string _user_name;
        [DataField("USER_NAME"
            , AliasName = "USER_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "USER_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
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
        /// The ROLE_TYPE Field of SYS_USER Table
        /// </summary>
        private string _role_type;
        [DataField("ROLE_TYPE"
            , AliasName = "ROLE_TYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 2
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ROLE_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ROLE_TYPE
        {
            set { _role_type = value; }
            get { return _role_type; }
        }
        /// <summary>
        /// The PROJECT_CODE Field of SYS_USER Table
        /// </summary>
        private string _project_code;
        [DataField("PROJECT_CODE"
            , AliasName = "PROJECT_CODE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROJECT_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PROJECT_CODE
        {
            set { _project_code = value; }
            get { return _project_code; }
        }
        /// <summary>
        /// The EMAIL Field of SYS_USER Table
        /// </summary>
        private string _email;
        [DataField("EMAIL"
            , AliasName = "EMAIL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "EMAIL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// The IS_AVAILABLE Field of SYS_USER Table
        /// </summary>
        private string _is_available;
        [DataField("IS_AVAILABLE"
            , AliasName = "IS_AVAILABLE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 1
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_AVAILABLE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
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
        /// The IS_ADMIN Field of SYS_USER Table
        /// </summary>
        private string _is_admin;
        [DataField("IS_ADMIN"
            , AliasName = "IS_ADMIN"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 1
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_ADMIN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string IS_ADMIN
        {
            set { _is_admin = value; }
            get { return _is_admin; }
        }
        /// <summary>
        /// The REMARK Field of SYS_USER Table
        /// </summary>
        private string _remark;
        [DataField("REMARK"
            , AliasName = "REMARK"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REMARK"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
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
        /// The CREATE_BY Field of SYS_USER Table
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
        /// The CREATE_TIME Field of SYS_USER Table
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
        /// The UPDATE_BY Field of SYS_USER Table
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
        /// The UPDATE_TIME Field of SYS_USER Table
        /// </summary>
        private DateTime _update_time;
        [DataField("UPDATE_TIME"
            , AliasName = "UPDATE_TIME"
            , DataType = DbType.DateTime
            , IsNullable = false
            , Size = 20
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "UPDATE_TIME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , SelectSequence = 104
            , DialogSequence = -1
            , Frozen = false
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "SysDate"
             )]
        public DateTime UPDATE_TIME
        {
            set { _update_time = value; }
            get { return _update_time; }
        }
        /// <summary>
        /// The PART_MENT Field of SYS_USER Table
        /// </summary>
        private string _part_ment;
        [DataField("PART_MENT"
            , AliasName = "PART_MENT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PART_MENT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 42
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PART_MENT
        {
            set { _part_ment = value; }
            get { return _part_ment; }
        }
        /// <summary>
        /// The FIRST_NAME Field of SYS_USER Table
        /// </summary>
        private string _first_name;
        [DataField("FIRST_NAME"
            , AliasName = "FIRST_NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FIRST_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 45
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FIRST_NAME
        {
            set { _first_name = value; }
            get { return _first_name; }
        }
        /// <summary>
        /// The LAST_NAME Field of SYS_USER Table
        /// </summary>
        private string _last_name;
        [DataField("LAST_NAME"
            , AliasName = "LAST_NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "LAST_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 48
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string LAST_NAME
        {
            set { _last_name = value; }
            get { return _last_name; }
        }
        /// <summary>
        /// The POSITION Field of SYS_USER Table
        /// </summary>
        private string _position;
        [DataField("POSITION"
            , AliasName = "POSITION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "POSITION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 51
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string POSITION
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// The DEPARTMENT Field of SYS_USER Table
        /// </summary>
        private string _department;
        [DataField("DEPARTMENT"
            , AliasName = "DEPARTMENT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DEPARTMENT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 54
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DEPARTMENT
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// The INSTITUTION Field of SYS_USER Table
        /// </summary>
        private string _institution;
        [DataField("INSTITUTION"
            , AliasName = "INSTITUTION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "INSTITUTION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 57
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string INSTITUTION
        {
            set { _institution = value; }
            get { return _institution; }
        }
        /// <summary>
        /// The STREET_ADDRESS Field of SYS_USER Table
        /// </summary>
        private string _street_address;
        [DataField("STREET_ADDRESS"
            , AliasName = "STREET_ADDRESS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "STREET_ADDRESS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 60
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string STREET_ADDRESS
        {
            set { _street_address = value; }
            get { return _street_address; }
        }
        /// <summary>
        /// The CITY Field of SYS_USER Table
        /// </summary>
        private string _city;
        [DataField("CITY"
            , AliasName = "CITY"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CITY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 63
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CITY
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// The COUNTRY Field of SYS_USER Table
        /// </summary>
        private string _country;
        [DataField("COUNTRY"
            , AliasName = "COUNTRY"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COUNTRY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 66
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COUNTRY
        {
            set { _country = value; }
            get { return _country; }
        }
        /// <summary>
        /// The PHONE Field of SYS_USER Table
        /// </summary>
        private string _phone;
        [DataField("PHONE"
            , AliasName = "PHONE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PHONE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 69
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PHONE
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// The FAX Field of SYS_USER Table
        /// </summary>
        private string _fax;
        [DataField("FAX"
            , AliasName = "FAX"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FAX"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 72
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FAX
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// The INTEREST Field of SYS_USER Table
        /// </summary>
        private string _interest;
        [DataField("INTEREST"
            , AliasName = "INTEREST"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "INTEREST"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 75
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string INTEREST
        {
            set { _interest = value; }
            get { return _interest; }
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

        private PermCollection _permission;
        /// <summary>
        /// 当前用户权限列表
        /// </summary>
        public PermCollection Permission
        {
            get { return _permission; }
            set { _permission = value; }
        }
        private SYS_USER_OPTION _option = new SYS_USER_OPTION();
        /// <summary>
        /// 用户当前选项
        /// </summary>
        public SYS_USER_OPTION Option
        {
            get { return _option; }
            set { _option = value; }
        }



        private DateTime _loginTime;
        public DateTime LoginTime
        {
            get { return _loginTime; }
            set { _loginTime = value; }
        }
        /// <summary>
        /// SYS_USER Table 
        /// </summary>
        public const string TABLE_NAME = "SYS_USER";
        public const String USER_ID_FIELD = "USER_ID";
        public const String USER_CODE_FIELD = "USER_CODE";
        public const String USER_PWD_FIELD = "USER_PWD";
        public const String USER_NAME_FIELD = "USER_NAME";
        public const String ROLE_TYPE_FIELD = "ROLE_TYPE";
        public const String PROJECT_CODE_FIELD = "PROJECT_CODE";
        public const String EMAIL_FIELD = "EMAIL";
        public const String IS_AVAILABLE_FIELD = "IS_AVAILABLE";
        public const String IS_ADMIN_FIELD = "IS_ADMIN";
        public const String REMARK_FIELD = "REMARK";
        public const String CREATE_BY_FIELD = "CREATE_BY";
        public const String CREATE_TIME_FIELD = "CREATE_TIME";
        public const String UPDATE_BY_FIELD = "UPDATE_BY";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
        public const String PART_MENT_FIELD = "PART_MENT";
        public const String FIRST_NAME_FIELD = "FIRST_NAME";
        public const String LAST_NAME_FIELD = "LAST_NAME";
        public const String POSITION_FIELD = "POSITION";
        public const String DEPARTMENT_FIELD = "DEPARTMENT";
        public const String INSTITUTION_FIELD = "INSTITUTION";
        public const String STREET_ADDRESS_FIELD = "STREET_ADDRESS";
        public const String CITY_FIELD = "CITY";
        public const String COUNTRY_FIELD = "COUNTRY";
        public const String PHONE_FIELD = "PHONE";
        public const String FAX_FIELD = "FAX";
        public const String INTEREST_FIELD = "INTEREST";
    }
}