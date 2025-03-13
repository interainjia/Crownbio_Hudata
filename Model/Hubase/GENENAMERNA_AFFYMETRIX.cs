using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for GENENAMERNA_AFFYMETRIX Table
	/// </summary>
	[Serializable]
	[DataTable("GENENAMERNA_AFFYMETRIX",ResourceKey = "GENENAMERNA_AFFYMETRIX")]
	public class GENENAMERNA_AFFYMETRIX: BaseObject
	{
		public GENENAMERNA_AFFYMETRIX()
		{
		}
		public GENENAMERNA_AFFYMETRIX(DealModel initModel):base(initModel)
		{
		}
		public static GENENAMERNA_AFFYMETRIX Convert(BaseObject from)
		{
			return (GENENAMERNA_AFFYMETRIX)from;
		}
		/// <summary>
		/// The GENENAMERNA_AFFYMETRIX_ID Field of GENENAMERNA_AFFYMETRIX Table
		/// </summary>
		private decimal _genenamerna_affymetrix_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.GENENAMERNA_AFFYMETRIX_ID = value; }
			get { return GENENAMERNA_AFFYMETRIX_ID; }
		}

		[RecordIDField("GENENAMERNA_AFFYMETRIX_ID"
			, AliasName = "GENENAMERNA_AFFYMETRIX_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "GENENAMERNA_AFFYMETRIX_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal GENENAMERNA_AFFYMETRIX_ID
		{
			set { _genenamerna_affymetrix_id = value; }
			get { return _genenamerna_affymetrix_id; }
		}
		/// <summary>
		/// The GENENAME Field of GENENAMERNA_AFFYMETRIX Table
		/// </summary>
		private string _genename;
		[DataField("GENENAME"
			, AliasName = "GENENAME"
			, DataType = DbType.String
			, IsNullable = true
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
		/// GENENAMERNA_AFFYMETRIX Table 
		/// </summary>
		public const string TABLE_NAME="GENENAMERNA_AFFYMETRIX";
		public const String GENENAMERNA_AFFYMETRIX_ID_FIELD  ="GENENAMERNA_AFFYMETRIX_ID";
		public const String GENENAME_FIELD  ="GENENAME";
	}
}