using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for PHARMACOLOGY_EFFECT Table
	/// </summary>
	[Serializable]
	[DataTable("PHARMACOLOGY_EFFECT",ResourceKey = "PHARMACOLOGY_EFFECT")]
	public class PHARMACOLOGY_EFFECT: BaseObject
	{
		public PHARMACOLOGY_EFFECT()
		{
		}
		public PHARMACOLOGY_EFFECT(DealModel initModel):base(initModel)
		{
		}
		public static PHARMACOLOGY_EFFECT Convert(BaseObject from)
		{
			return (PHARMACOLOGY_EFFECT)from;
		}
		/// <summary>
		/// The PHARMACOLOGY_EFFECT_ID Field of PHARMACOLOGY_EFFECT Table
		/// </summary>
		private decimal _pharmacology_effect_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.PHARMACOLOGY_EFFECT_ID = value; }
			get { return PHARMACOLOGY_EFFECT_ID; }
		}

		[RecordIDField("PHARMACOLOGY_EFFECT_ID"
			, AliasName = "PHARMACOLOGY_EFFECT_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "PHARMACOLOGY_EFFECT_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal PHARMACOLOGY_EFFECT_ID
		{
			set { _pharmacology_effect_id = value; }
			get { return _pharmacology_effect_id; }
		}
        /// <summary>
        /// The ANIMALTREE_ID Field of PHARMACOLOGY_EFFECT Table
        /// </summary>
        private string _animaltree_id;
        [DataField("ANIMALTREE_ID"
            , AliasName = "ANIMALTREE_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 18
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
		/// The MODEL_ID Field of PHARMACOLOGY_EFFECT Table
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
			, SelectSequence = 3
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
		/// The STUDY_NUMBER Field of PHARMACOLOGY_EFFECT Table
		/// </summary>
		private string _study_number;
		[DataField("STUDY_NUMBER"
			, AliasName = "STUDY_NUMBER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "STUDY_NUMBER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string STUDY_NUMBER
		{
			set { _study_number = value; }
			get { return _study_number; }
		}
		/// <summary>
		/// The INOCULATION_DATE Field of PHARMACOLOGY_EFFECT Table
		/// </summary>
		private DateTime _inoculation_date;
		[DataField("INOCULATION_DATE"
			, AliasName = "INOCULATION_DATE"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "INOCULATION_DATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public DateTime INOCULATION_DATE
		{
			set { _inoculation_date = value; }
			get { return _inoculation_date; }
		}
		/// <summary>
		/// The PN Field of PHARMACOLOGY_EFFECT Table
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
			, SelectSequence = 12
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
		/// PHARMACOLOGY_EFFECT Table 
		/// </summary>
		public const string TABLE_NAME="PHARMACOLOGY_EFFECT";
		public const String PHARMACOLOGY_EFFECT_ID_FIELD  ="PHARMACOLOGY_EFFECT_ID";
        public const String ANIMALTREE_ID_FIELD = "ANIMALTREE_ID";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
		public const String STUDY_NUMBER_FIELD  ="STUDY_NUMBER";
		public const String INOCULATION_DATE_FIELD  ="INOCULATION_DATE";
		public const String PN_FIELD  ="PN";
	}
}