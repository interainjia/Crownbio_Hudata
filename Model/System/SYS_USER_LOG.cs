using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for SYS_USER_LOG Table
	/// </summary>
	[Serializable]
	[DataTable("SYS_USER_LOG",ResourceKey = "SYS_USER_LOG")]
	public class SYS_USER_LOG: BaseObject
	{
		public SYS_USER_LOG()
		{
		}
		public SYS_USER_LOG(DealModel initModel):base(initModel)
		{
		}
		public static SYS_USER_LOG Convert(BaseObject from)
		{
			return (SYS_USER_LOG)from;
		}
		/// <summary>
		/// The USER_LOG_ID Field of SYS_USER_LOG Table
		/// </summary>
		private decimal _user_log_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.USER_LOG_ID = value; }
			get { return USER_LOG_ID; }
		}

		[RecordIDField("USER_LOG_ID"
			, AliasName = "USER_LOG_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "USER_LOG_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal USER_LOG_ID
		{
			set { _user_log_id = value; }
			get { return _user_log_id; }
		}
		/// <summary>
		/// The USER_CODE Field of SYS_USER_LOG Table
		/// </summary>
		private string _user_code;
		[KeyField("USER_CODE"
			, AliasName = "USER_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 10
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
		/// The USER_NAME Field of SYS_USER_LOG Table
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
			, SelectSequence = 6
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
		/// The ROLE_TYPE Field of SYS_USER_LOG Table
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
			, SelectSequence = 9
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
		/// The EMAIL Field of SYS_USER_LOG Table
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
			, SelectSequence = 12
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
		/// The REMARK Field of SYS_USER_LOG Table
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
			, SelectSequence = 15
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
		/// The IP Field of SYS_USER_LOG Table
		/// </summary>
		private string _ip;
		[DataField("IP"
			, AliasName = "IP"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "IP"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string IP
		{
			set { _ip = value; }
			get { return _ip; }
		}
		/// <summary>
		/// The LOGIN_TIME Field of SYS_USER_LOG Table
		/// </summary>
		private DateTime _login_time;
		[DataField("LOGIN_TIME"
			, AliasName = "LOGIN_TIME"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "LOGIN_TIME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime LOGIN_TIME
		{
			set { _login_time = value; }
			get { return _login_time; }
		}
		/// <summary>
		/// The LOGOUT_TIME Field of SYS_USER_LOG Table
		/// </summary>
		private DateTime _logout_time;
		[DataField("LOGOUT_TIME"
			, AliasName = "LOGOUT_TIME"
			, DataType = DbType.DateTime
            , IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "LOGOUT_TIME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime LOGOUT_TIME
		{
			set { _logout_time = value; }
			get { return _logout_time; }
		}
		/// <summary>
		/// SYS_USER_LOG Table 
		/// </summary>
		public const string TABLE_NAME="SYS_USER_LOG";
		public const String USER_LOG_ID_FIELD  ="USER_LOG_ID";
		public const String USER_CODE_FIELD  ="USER_CODE";
		public const String USER_NAME_FIELD  ="USER_NAME";
		public const String ROLE_TYPE_FIELD  ="ROLE_TYPE";
		public const String EMAIL_FIELD  ="EMAIL";
		public const String REMARK_FIELD  ="REMARK";
		public const String IP_FIELD  ="IP";
		public const String LOGIN_TIME_FIELD  ="LOGIN_TIME";
		public const String LOGOUT_TIME_FIELD  ="LOGOUT_TIME";
	}
}