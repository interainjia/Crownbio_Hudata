using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for MODELTREE_MAINTAIN Table
	/// </summary>
	[Serializable]
	[DataTable("MODELTREE_MAINTAIN",ResourceKey = "MODELTREE_MAINTAIN")]
	public class MODELTREE_MAINTAIN: BaseObject
	{
		public MODELTREE_MAINTAIN()
		{
		}
		public MODELTREE_MAINTAIN(DealModel initModel):base(initModel)
		{
		}
		public static MODELTREE_MAINTAIN Convert(BaseObject from)
		{
			return (MODELTREE_MAINTAIN)from;
		}
		/// <summary>
		/// The MODELTREE_MAINTAIN_ID Field of MODELTREE_MAINTAIN Table
		/// </summary>
		private decimal _modeltree_maintain_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.MODELTREE_MAINTAIN_ID = value; }
			get { return MODELTREE_MAINTAIN_ID; }
		}

		[RecordIDField("MODELTREE_MAINTAIN_ID"
			, AliasName = "MODELTREE_MAINTAIN_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "MODELTREE_MAINTAIN_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal MODELTREE_MAINTAIN_ID
		{
			set { _modeltree_maintain_id = value; }
			get { return _modeltree_maintain_id; }
		}
		/// <summary>
		/// The ANIMALTREE_ID Field of MODELTREE_MAINTAIN Table
		/// </summary>
		private string _animaltree_id;
		[DataField("ANIMALTREE_ID"
			, AliasName = "ANIMALTREE_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANIMALTREE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANIMALTREE_ID
		{
			set { _animaltree_id = value; }
			get { return _animaltree_id; }
		}
		/// <summary>
		/// The MODEL_ID Field of MODELTREE_MAINTAIN Table
		/// </summary>
		private string _model_id;
		[DataField("MODEL_ID"
			, AliasName = "MODEL_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MODEL_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MODEL_ID
		{
			set { _model_id = value; }
			get { return _model_id; }
		}
		/// <summary>
		/// The MAINTAIN Field of MODELTREE_MAINTAIN Table
		/// </summary>
		private string _maintain;
		[DataField("MAINTAIN"
			, AliasName = "MAINTAIN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 25
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MAINTAIN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MAINTAIN
		{
			set { _maintain = value; }
			get { return _maintain; }
		}
		/// <summary>
		/// The DOI Field of MODELTREE_MAINTAIN Table
		/// </summary>
		private DateTime _doi;
		[DataField("DOI"
			, AliasName = "DOI"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DOI"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public DateTime DOI
		{
			set { _doi = value; }
			get { return _doi; }
		}
		/// <summary>
		/// The RN Field of MODELTREE_MAINTAIN Table
		/// </summary>
		private string _rn;
		[DataField("RN"
			, AliasName = "RN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "RN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string RN
		{
			set { _rn = value; }
			get { return _rn; }
		}
		/// <summary>
		/// The PN Field of MODELTREE_MAINTAIN Table
		/// </summary>
		private string _pn;
		[DataField("PN"
			, AliasName = "PN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PN
		{
			set { _pn = value; }
			get { return _pn; }
		}
		/// <summary>
		/// MODELTREE_MAINTAIN Table 
		/// </summary>
		public const string TABLE_NAME="MODELTREE_MAINTAIN";
		public const String MODELTREE_MAINTAIN_ID_FIELD  ="MODELTREE_MAINTAIN_ID";
		public const String ANIMALTREE_ID_FIELD  ="ANIMALTREE_ID";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
		public const String MAINTAIN_FIELD  ="MAINTAIN";
		public const String DOI_FIELD  ="DOI";
		public const String RN_FIELD  ="RN";
		public const String PN_FIELD  ="PN";
	}
}