using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for COPYNUMBER_PENNCNV Table
	/// </summary>
	[Serializable]
	[DataTable("COPYNUMBER_PENNCNV",ResourceKey = "COPYNUMBER_PENNCNV")]
	public class COPYNUMBER_PENNCNV: BaseObject
	{
		public COPYNUMBER_PENNCNV()
		{
		}
		public COPYNUMBER_PENNCNV(DealModel initModel):base(initModel)
		{
		}
		public static COPYNUMBER_PENNCNV Convert(BaseObject from)
		{
			return (COPYNUMBER_PENNCNV)from;
		}
		/// <summary>
		/// The COPYNUMBER_PENNCNV_ID Field of COPYNUMBER_PENNCNV Table
		/// </summary>
		private decimal _copynumber_penncnv_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.COPYNUMBER_PENNCNV_ID = value; }
			get { return COPYNUMBER_PENNCNV_ID; }
		}

		[RecordIDField("COPYNUMBER_PENNCNV_ID"
			, AliasName = "COPYNUMBER_PENNCNV_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "COPYNUMBER_PENNCNV_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal COPYNUMBER_PENNCNV_ID
		{
			set { _copynumber_penncnv_id = value; }
			get { return _copynumber_penncnv_id; }
		}
		/// <summary>
		/// The GENE Field of COPYNUMBER_PENNCNV Table
		/// </summary>
		private string _gene;
		[DataField("GENE"
			, AliasName = "GENE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENE
		{
			set { _gene = value; }
			get { return _gene; }
		}
		/// <summary>
		/// The PDXMODEL Field of COPYNUMBER_PENNCNV Table
		/// </summary>
		private string _pdxmodel;
		[DataField("PDXMODEL"
			, AliasName = "PDXMODEL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PDXMODEL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PDXMODEL
		{
			set { _pdxmodel = value; }
			get { return _pdxmodel; }
		}
		/// <summary>
		/// The VALUE Field of COPYNUMBER_PENNCNV Table
		/// </summary>
		private double _value;
		[DataField("VALUE"
			, AliasName = "VALUE"
			, DataType = DbType.Double
			, IsNullable = true
			, Size = 8
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "VALUE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public double VALUE
		{
			set { _value = value; }
			get { return _value; }
		}
		/// <summary>
		/// COPYNUMBER_PENNCNV Table 
		/// </summary>
		public const string TABLE_NAME="COPYNUMBER_PENNCNV";
		public const String COPYNUMBER_PENNCNV_ID_FIELD  ="COPYNUMBER_PENNCNV_ID";
		public const String GENE_FIELD  ="GENE";
		public const String PDXMODEL_FIELD  ="PDXMODEL";
		public const String VALUE_FIELD  ="VALUE";
	}
}