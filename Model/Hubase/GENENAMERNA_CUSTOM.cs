using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for GENENAMERNA_CUSTOM Table
	/// </summary>
	[Serializable]
	[DataTable("GENENAMERNA_CUSTOM",ResourceKey = "GENENAMERNA_CUSTOM")]
	public class GENENAMERNA_CUSTOM: BaseObject
	{
		public GENENAMERNA_CUSTOM()
		{
		}
		public GENENAMERNA_CUSTOM(DealModel initModel):base(initModel)
		{
		}
		public static GENENAMERNA_CUSTOM Convert(BaseObject from)
		{
			return (GENENAMERNA_CUSTOM)from;
		}
		/// <summary>
		/// The GENENAMERNA_CUSTOM_ID Field of GENENAMERNA_CUSTOM Table
		/// </summary>
		private decimal _genenamerna_custom_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.GENENAMERNA_CUSTOM_ID = value; }
			get { return GENENAMERNA_CUSTOM_ID; }
		}

		[RecordIDField("GENENAMERNA_CUSTOM_ID"
			, AliasName = "GENENAMERNA_CUSTOM_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "GENENAMERNA_CUSTOM_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal GENENAMERNA_CUSTOM_ID
		{
			set { _genenamerna_custom_id = value; }
			get { return _genenamerna_custom_id; }
		}
		/// <summary>
		/// The GENENAME Field of GENENAMERNA_CUSTOM Table
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
		/// GENENAMERNA_CUSTOM Table 
		/// </summary>
		public const string TABLE_NAME="GENENAMERNA_CUSTOM";
		public const String GENENAMERNA_CUSTOM_ID_FIELD  ="GENENAMERNA_CUSTOM_ID";
		public const String GENENAME_FIELD  ="GENENAME";
	}
}