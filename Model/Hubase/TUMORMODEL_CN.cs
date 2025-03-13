using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for TUMORMODEL_CN Table
	/// </summary>
	[Serializable]
	[DataTable("TUMORMODEL_CN",ResourceKey = "TUMORMODEL_CN")]
	public class TUMORMODEL_CN: BaseObject
	{
		public TUMORMODEL_CN()
		{
		}
		public TUMORMODEL_CN(DealModel initModel):base(initModel)
		{
		}
		public static TUMORMODEL_CN Convert(BaseObject from)
		{
			return (TUMORMODEL_CN)from;
		}
		/// <summary>
		/// The TUMORMODEL_CN_ID Field of TUMORMODEL_CN Table
		/// </summary>
		private decimal _tumormodel_cn_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.TUMORMODEL_CN_ID = value; }
			get { return TUMORMODEL_CN_ID; }
		}

		[RecordIDField("TUMORMODEL_CN_ID"
			, AliasName = "TUMORMODEL_CN_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "TUMORMODEL_CN_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal TUMORMODEL_CN_ID
		{
			set { _tumormodel_cn_id = value; }
			get { return _tumormodel_cn_id; }
		}
		/// <summary>
		/// The CN_MODELID Field of TUMORMODEL_CN Table
		/// </summary>
		private string _cn_modelid;
		[DataField("CN_MODELID"
			, AliasName = "CN_MODELID"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 25
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "CN_MODELID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CN_MODELID
		{
			set { _cn_modelid = value; }
			get { return _cn_modelid; }
		}
		/// <summary>
		/// TUMORMODEL_CN Table 
		/// </summary>
		public const string TABLE_NAME="TUMORMODEL_CN";
		public const String TUMORMODEL_CN_ID_FIELD  ="TUMORMODEL_CN_ID";
		public const String CN_MODELID_FIELD  ="CN_MODELID";
	}
}