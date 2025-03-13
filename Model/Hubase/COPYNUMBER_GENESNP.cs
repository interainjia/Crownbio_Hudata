using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for COPYNUMBER_GENESNP Table
	/// </summary>
	[Serializable]
	[DataTable("COPYNUMBER_GENESNP",ResourceKey = "COPYNUMBER_GENESNP")]
	public class COPYNUMBER_GENESNP: BaseObject
	{
		public COPYNUMBER_GENESNP()
		{
		}
		public COPYNUMBER_GENESNP(DealModel initModel):base(initModel)
		{
		}
		public static COPYNUMBER_GENESNP Convert(BaseObject from)
		{
			return (COPYNUMBER_GENESNP)from;
		}
		/// <summary>
		/// The COPYNUMBER_GENESNP_ID Field of COPYNUMBER_GENESNP Table
		/// </summary>
		private decimal _copynumber_genesnp_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.COPYNUMBER_GENESNP_ID = value; }
			get { return COPYNUMBER_GENESNP_ID; }
		}

		[RecordIDField("COPYNUMBER_GENESNP_ID"
			, AliasName = "COPYNUMBER_GENESNP_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "COPYNUMBER_GENESNP_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal COPYNUMBER_GENESNP_ID
		{
			set { _copynumber_genesnp_id = value; }
			get { return _copynumber_genesnp_id; }
		}
		/// <summary>
		/// The GENESNP Field of COPYNUMBER_GENESNP Table
		/// </summary>
		private string _genesnp;
		[DataField("GENESNP"
			, AliasName = "GENESNP"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENESNP"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENESNP
		{
			set { _genesnp = value; }
			get { return _genesnp; }
		}
		/// <summary>
		/// COPYNUMBER_GENESNP Table 
		/// </summary>
		public const string TABLE_NAME="COPYNUMBER_GENESNP";
		public const String COPYNUMBER_GENESNP_ID_FIELD  ="COPYNUMBER_GENESNP_ID";
		public const String GENESNP_FIELD  ="GENESNP";
	}
}