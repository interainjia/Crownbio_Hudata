using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for SHOP Table
	/// </summary>
	[Serializable]
	[DataTable("SHOP",ResourceKey = "SHOP")]
	public class SHOP: BaseObject
	{
		public SHOP()
		{
		}
		public SHOP(DealModel initModel):base(initModel)
		{
		}
		public static SHOP Convert(BaseObject from)
		{
			return (SHOP)from;
		}
		/// <summary>
		/// The SHOP_ID Field of SHOP Table
		/// </summary>
		private decimal _shop_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.SHOP_ID = value; }
			get { return SHOP_ID; }
		}

		[RecordIDField("SHOP_ID"
			, AliasName = "SHOP_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "SHOP_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal SHOP_ID
		{
			set { _shop_id = value; }
			get { return _shop_id; }
		}
		/// <summary>
		/// The AREA Field of SHOP Table
		/// </summary>
		private string _area;
		[DataField("AREA"
			, AliasName = "AREA"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "AREA"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string AREA
		{
			set { _area = value; }
			get { return _area; }
		}
		/// <summary>
		/// The PID Field of SHOP Table
		/// </summary>
		private decimal _pid;
		[DataField("PID"
			, AliasName = "PID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal PID
		{
			set { _pid = value; }
			get { return _pid; }
		}
		/// <summary>
		/// SHOP Table 
		/// </summary>
		public const string TABLE_NAME="SHOP";
		public const String SHOP_ID_FIELD  ="SHOP_ID";
		public const String AREA_FIELD  ="AREA";
		public const String PID_FIELD  ="PID";
	}
}