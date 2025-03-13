using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for USER_TYPE Table
	/// </summary>
	[Serializable]
	[DataTable("USER_TYPE",ResourceKey = "USER_TYPE")]
	public class USER_TYPE: BaseObject
	{
		public USER_TYPE()
		{
		}
		public USER_TYPE(DealModel initModel):base(initModel)
		{
		}
		public static USER_TYPE Convert(BaseObject from)
		{
			return (USER_TYPE)from;
		}
		/// <summary>
		/// The USER_TYPE_ID Field of USER_TYPE Table
		/// </summary>
		private decimal _user_type_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.USER_TYPE_ID = value; }
			get { return USER_TYPE_ID; }
		}

		[RecordIDField("USER_TYPE_ID"
			, AliasName = "USER_TYPE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "USER_TYPE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal USER_TYPE_ID
		{
			set { _user_type_id = value; }
			get { return _user_type_id; }
		}
		/// <summary>
		/// The USER_TYPE Field of USER_TYPE Table
		/// </summary>
		private string _u_type;
		[KeyField("U_TYPE"
			, AliasName = "U_TYPE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 10
			, Width =100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "U_TYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string U_TYPE
		{
			set { _u_type = value; }
			get { return _u_type; }
		}
		/// <summary>
		/// The USER_TYPE_NAME Field of USER_TYPE Table
		/// </summary>
		private string _user_type_name;
		[DataField("USER_TYPE_NAME"
			, AliasName = "USER_TYPE_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USER_TYPE_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USER_TYPE_NAME
		{
			set { _user_type_name = value; }
			get { return _user_type_name; }
		}
		/// <summary>
		/// USER_TYPE Table 
		/// </summary>
		public const string TABLE_NAME="USER_TYPE";
		public const String USER_TYPE_ID_FIELD  ="USER_TYPE_ID";
		public const String U_TYPE_FIELD  ="U_TYPE";
		public const String USER_TYPE_NAME_FIELD  ="USER_TYPE_NAME";
	}
}