using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for MIRNAGENE Table
	/// </summary>
	[Serializable]
	[DataTable("MIRNAGENE",ResourceKey = "MIRNAGENE")]
	public class MIRNAGENE: BaseObject
	{
		public MIRNAGENE()
		{
		}
		public MIRNAGENE(DealModel initModel):base(initModel)
		{
		}
		public static MIRNAGENE Convert(BaseObject from)
		{
			return (MIRNAGENE)from;
		}
		/// <summary>
		/// The MIRNAGENE_ID Field of MIRNAGENE Table
		/// </summary>
		private decimal _mirnagene_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.MIRNAGENE_ID = value; }
			get { return MIRNAGENE_ID; }
		}

		[RecordIDField("MIRNAGENE_ID"
			, AliasName = "MIRNAGENE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "MIRNAGENE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal MIRNAGENE_ID
		{
			set { _mirnagene_id = value; }
			get { return _mirnagene_id; }
		}
		/// <summary>
		/// The GENENAME Field of MIRNAGENE Table
		/// </summary>
		private string _genename;
		[DataField("GENENAME"
			, AliasName = "GENENAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENENAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENENAME
		{
			set { _genename = value; }
			get { return _genename; }
		}
		/// <summary>
		/// MIRNAGENE Table 
		/// </summary>
		public const string TABLE_NAME="MIRNAGENE";
		public const String MIRNAGENE_ID_FIELD  ="MIRNAGENE_ID";
		public const String GENENAME_FIELD  ="GENENAME";
	}
}