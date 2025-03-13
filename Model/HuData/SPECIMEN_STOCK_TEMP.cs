using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for SPECIMEN_STOCK_TEMP Table
	/// </summary>
	[Serializable]
	[DataTable("SPECIMEN_STOCK_TEMP",ResourceKey = "SPECIMEN_STOCK_TEMP")]
	public class SPECIMEN_STOCK_TEMP: BaseObject
	{
		public SPECIMEN_STOCK_TEMP()
		{
		}
		public SPECIMEN_STOCK_TEMP(DealModel initModel):base(initModel)
		{
		}
		public static SPECIMEN_STOCK_TEMP Convert(BaseObject from)
		{
			return (SPECIMEN_STOCK_TEMP)from;
		}
		/// <summary>
		/// The SPECIMEN_STOCK_TEMP_ID Field of SPECIMEN_STOCK_TEMP Table
		/// </summary>
		private decimal _SPECIMEN_STOCK_TEMP_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.SPECIMEN_STOCK_TEMP_ID = value; }
			get { return SPECIMEN_STOCK_TEMP_ID; }
		}

		[RecordIDField("SPECIMEN_STOCK_TEMP_ID"
			, AliasName = "SPECIMEN_STOCK_TEMP_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "SPECIMEN_STOCK_TEMP_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal SPECIMEN_STOCK_TEMP_ID
		{
			set { _SPECIMEN_STOCK_TEMP_id = value; }
			get { return _SPECIMEN_STOCK_TEMP_id; }
		}
	
		/// <summary>
		/// The LOCATION_ID Field of SPECIMEN_STOCK_TEMP Table
		/// </summary>
		private string _location_id;
		[DataField("LOCATION_ID"
			, AliasName = "LOCATION_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "LOCATION_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LOCATION_ID
		{
			set { _location_id = value; }
			get { return _location_id; }
		}
		/// <summary>
		/// The WELL_ID Field of SPECIMEN_STOCK_TEMP Table
		/// </summary>
		private string _well_id;
		[DataField("WELL_ID"
			, AliasName = "WELL_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "WELL_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 36
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string WELL_ID
		{
			set { _well_id = value; }
			get { return _well_id; }
		}

     

		/// <summary>
		/// SPECIMEN_STOCK_TEMP Table 
		/// </summary>
		public const string TABLE_NAME="SPECIMEN_STOCK_TEMP";
		public const String SPECIMEN_STOCK_TEMP_ID_FIELD  ="SPECIMEN_STOCK_TEMP_ID";
	
		public const String LOCATION_ID_FIELD  ="LOCATION_ID";
		public const String WELL_ID_FIELD  ="WELL_ID";
	
	}
}