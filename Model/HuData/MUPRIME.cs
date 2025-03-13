using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for MUPRIME Table
    /// </summary>
    [Serializable]
    [DataTable("MUPRIME", ResourceKey = "MUPRIME")]
    public class MUPRIME : BaseObject
    {
        public MUPRIME()
        {
        }
        public MUPRIME(DealModel initModel)
            : base(initModel)
        {
        }
        public static MUPRIME Convert(BaseObject from)
        {
            return (MUPRIME)from;
        }
        /// <summary>
        /// The MUPRIME_ID Field of MUPRIME Table
        /// </summary>
        private decimal _muprime_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.MUPRIME_ID = value;
            }
            get { return MUPRIME_ID; }
        }

        [RecordIDField("MUPRIME_ID"
            , AliasName = "MUPRIME_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "MUPRIME_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal MUPRIME_ID
        {
            set { _muprime_id = value; }
            get { return _muprime_id; }
        }
        /// <summary>
        /// The SQ_NUMBER Field of MUPRIME Table
        /// </summary>
        private string _sq_number;
        [KeyField("SQ_NUMBER"
            , AliasName = "SQ_NUMBER"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SQ_NUMBER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SQ_NUMBER
        {
            set { _sq_number = value; }
            get { return _sq_number; }
        }
        /// <summary>
        /// The CANCER_TYPE_ABBR Field of MUPRIME Table
        /// </summary>
        private string _cancer_type_abbr;
        [DataField("CANCER_TYPE_ABBR"
            , AliasName = "CANCER_TYPE_ABBR"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CANCER_TYPE_ABBR"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CANCER_TYPE_ABBR
        {
            set { _cancer_type_abbr = value; }
            get { return _cancer_type_abbr; }
        }
        /// <summary>
        /// The MODEL_ID Field of MUPRIME Table
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
            , SelectSequence = 9
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
        /// The SOURCE Field of MUPRIME Table
        /// </summary>
        private string _model_from;
        [DataField("MODEL_FROM"
            , AliasName = "MODEL_FROM"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODEL_FROM"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODEL_FROM
        {
            set { _model_from = value; }
            get { return _model_from; }
        }

        private string _source;
        [DataField("SOURCE"
            , AliasName = "SOURCE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SOURCE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 13
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SOURCE
        {
            set { _source = value; }
            get { return _source; }
        }

        /// <summary>
        /// The MOUSE_STRAIN Field of MUPRIME Table
        /// </summary>
        private string _mouse_strain;
        [DataField("MOUSE_STRAIN"
            , AliasName = "MOUSE_STRAIN"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MOUSE_STRAIN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MOUSE_STRAIN
        {
            set { _mouse_strain = value; }
            get { return _mouse_strain; }
        }
        /// <summary>
        /// The CANCER_TYPE Field of MUPRIME Table
        /// </summary>
        private string _cancer_type;
        [DataField("CANCER_TYPE"
            , AliasName = "CANCER_TYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CANCER_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CANCER_TYPE
        {
            set { _cancer_type = value; }
            get { return _cancer_type; }
        }
        /// <summary>
        /// The SUBTYPE1 Field of MUPRIME Table
        /// </summary>
        private string _subtype1;
        [DataField("SUBTYPE1"
            , AliasName = "SUBTYPE1"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SUBTYPE1"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SUBTYPE1
        {
            set { _subtype1 = value; }
            get { return _subtype1; }
        }
        /// <summary>
        /// The SUBTYPE2 Field of MUPRIME Table
        /// </summary>
        private string _subtype2;
        [DataField("SUBTYPE2"
            , AliasName = "SUBTYPE2"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SUBTYPE2"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SUBTYPE2
        {
            set { _subtype2 = value; }
            get { return _subtype2; }
        }
        /// <summary>
        /// The MODEL_CATEGORY Field of MUPRIME Table
        /// </summary>
        private string _model_category;
        [DataField("MODEL_CATEGORY"
            , AliasName = "MODEL_CATEGORY"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODEL_CATEGORY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODEL_CATEGORY
        {
            set { _model_category = value; }
            get { return _model_category; }
        }
        /// <summary>
        /// The MODEL_STATUS Field of MUPRIME Table
        /// </summary>
        private string _model_status;
        [DataField("MODEL_STATUS"
            , AliasName = "MODEL_STATUS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODEL_STATUS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODEL_STATUS
        {
            set { _model_status = value; }
            get { return _model_status; }
        }
        /// <summary>
        /// The SOURCE_ID Field of MUPRIME Table
        /// </summary>
        private string _source_id;
        [DataField("SOURCE_ID"
            , AliasName = "SOURCE_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SOURCE_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SOURCE_ID
        {
            set { _source_id = value; }
            get { return _source_id; }
        }
        /// <summary>
        /// The SOURCE_NOTE Field of MUPRIME Table
        /// </summary>
        private string _source_note;
        [DataField("SOURCE_NOTE"
            , AliasName = "SOURCE_NOTE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SOURCE_NOTE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SOURCE_NOTE
        {
            set { _source_note = value; }
            get { return _source_note; }
        }
        /// <summary>
        /// The PDX_QC Field of MUPRIME Table
        /// </summary>
        private string _pdx_qc;
        [DataField("PDX_QC"
            , AliasName = "PDX_QC"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PDX_QC"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 39
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PDX_QC
        {
            set { _pdx_qc = value; }
            get { return _pdx_qc; }
        }
        /// <summary>
        /// The TOTAL_REVIVAL_SUCCESS_RATE Field of MUPRIME Table
        /// </summary>
        private string _total_revival_success_rate;
        [DataField("TOTAL_REVIVAL_SUCCESS_RATE"
            , AliasName = "TOTAL_REVIVAL_SUCCESS_RATE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TOTAL_REVIVAL_SUCCESS_RATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 42
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TOTAL_REVIVAL_SUCCESS_RATE
        {
            set { _total_revival_success_rate = value; }
            get { return _total_revival_success_rate; }
        }
        /// <summary>
        /// The REVIVAL_RECOMMENDED_STRAIN Field of MUPRIME Table
        /// </summary>
        private string _revival_recommended_strain;
        [DataField("REVIVAL_RECOMMENDED_STRAIN"
            , AliasName = "REVIVAL_RECOMMENDED_STRAIN"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REVIVAL_RECOMMENDED_STRAIN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 45
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REVIVAL_RECOMMENDED_STRAIN
        {
            set { _revival_recommended_strain = value; }
            get { return _revival_recommended_strain; }
        }
        /// <summary>
        /// The TIME_OF_REVIVAL Field of MUPRIME Table
        /// </summary>
        private string _time_of_revival;
        [DataField("TIME_OF_REVIVAL"
            , AliasName = "TIME_OF_REVIVAL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TIME_OF_REVIVAL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 48
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TIME_OF_REVIVAL
        {
            set { _time_of_revival = value; }
            get { return _time_of_revival; }
        }
        /// <summary>
        /// The MAINTAIN_RECOMMENDED_STRAIN Field of MUPRIME Table
        /// </summary>
        private string _maintain_recommended_strain;
        [DataField("MAINTAIN_RECOMMENDED_STRAIN"
            , AliasName = "MAINTAIN_RECOMMENDED_STRAIN"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MAINTAIN_RECOMMENDED_STRAIN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 51
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MAINTAIN_RECOMMENDED_STRAIN
        {
            set { _maintain_recommended_strain = value; }
            get { return _maintain_recommended_strain; }
        }
        /// <summary>
        /// The GENOTYPE_CONSISTENCE Field of MUPRIME Table
        /// </summary>
        private string _genotype_consistence;
        [DataField("GENOTYPE_CONSISTENCE"
            , AliasName = "GENOTYPE_CONSISTENCE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "GENOTYPE_CONSISTENCE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 54
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string GENOTYPE_CONSISTENCE
        {
            set { _genotype_consistence = value; }
            get { return _genotype_consistence; }
        }
        /// <summary>
        /// The IN_HUBA Field of PDXMODEL_INFO Table
        /// </summary>
        private string _in_huba;
        [DataField("IN_HUBA"
            , AliasName = "IN_HUBA"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IN_HUBA"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 57
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string IN_HUBA
        {
            set { _in_huba = value; }
            get { return _in_huba; }
        }
        /// <summary>
        /// The TIME_OF_MODEL_FOR_TRANSPLANT Field of MUPRIME Table
        /// </summary>
        private string _time_of_model_for_transplant;
        [DataField("TIME_OF_MODEL_FOR_TRANSPLANT"
            , AliasName = "TIME_OF_MODEL_FOR_TRANSPLANT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TIME_OF_MODEL_FOR_TRANSPLANT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 60
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TIME_OF_MODEL_FOR_TRANSPLANT
        {
            set { _time_of_model_for_transplant = value; }
            get { return _time_of_model_for_transplant; }
        }
        /// <summary>
        /// The CV40_TAKE_RATE Field of MUPRIME Table
        /// </summary>
        private string _cv40_take_rate;
        [DataField("CV40_TAKE_RATE"
            , AliasName = "CV40_TAKE_RATE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CV40_TAKE_RATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 63
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CV40_TAKE_RATE
        {
            set { _cv40_take_rate = value; }
            get { return _cv40_take_rate; }
        }
        /// <summary>
        /// The CV30_TAKE_RATE Field of MUPRIME Table
        /// </summary>
        private string _cv30_take_rate;
        [DataField("CV30_TAKE_RATE"
            , AliasName = "CV30_TAKE_RATE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CV30_TAKE_RATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 66
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CV30_TAKE_RATE
        {
            set { _cv30_take_rate = value; }
            get { return _cv30_take_rate; }
        }
        /// <summary>
		/// The OPTIMAL_OVERAGE Field of PDXMODEL_INFO Table
		/// </summary>
		private string _optimal_overage;
        [DataField("OPTIMAL_OVERAGE"
            , AliasName = "OPTIMAL_OVERAGE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "OPTIMAL_OVERAGE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 67
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string OPTIMAL_OVERAGE
        {
            set { _optimal_overage = value; }
            get { return _optimal_overage; }
        }

        /// <summary>
        /// The DOSING_WINDOW Field of MUPRIME Table
        /// </summary>
        private string _dosing_window;
        [DataField("DOSING_WINDOW"
            , AliasName = "DOSING_WINDOW"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOSING_WINDOW"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 69
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DOSING_WINDOW
        {
            set { _dosing_window = value; }
            get { return _dosing_window; }
        }
        /// <summary>
        /// The CRYO_P Field of MUPRIME Table
        /// </summary>
        private Int32 _cryo_p;
        [DataField("CRYO_P"
            , AliasName = "CRYO_P"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CRYO_P"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 72
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 CRYO_P
        {
            set { _cryo_p = value; }
            get { return _cryo_p; }
        }
        /// <summary>
        /// The SNAP_FROZEN Field of MUPRIME Table
        /// </summary>
        private Int32 _snap_frozen;
        [DataField("SNAP_FROZEN"
            , AliasName = "SNAP_FROZEN"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SNAP_FROZEN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 75
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 SNAP_FROZEN
        {
            set { _snap_frozen = value; }
            get { return _snap_frozen; }
        }
        /// <summary>
        /// The FFPE Field of MUPRIME Table
        /// </summary>
        private Int32 _ffpe;
        [DataField("FFPE"
            , AliasName = "FFPE"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FFPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 78
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 FFPE
        {
            set { _ffpe = value; }
            get { return _ffpe; }
        }
        /// <summary>
        /// The TIMES_USED_IN_STUDY Field of MUPRIME Table
        /// </summary>
        private string _times_used_in_study;
        [DataField("TIMES_USED_IN_STUDY"
            , AliasName = "TIMES_USED_IN_STUDY"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TIMES_USED_IN_STUDY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 81
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TIMES_USED_IN_STUDY
        {
            set { _times_used_in_study = value; }
            get { return _times_used_in_study; }
        }
        /// <summary>
        /// The UPDATE_TIME Field of MUPRIME Table
        /// </summary>
        private DateTime _update_time;
        [DataField("UPDATE_TIME"
            , AliasName = "UPDATE_TIME"
            , DataType = DbType.DateTime
            , IsNullable = false
            , Size = 20
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "UPDATE_TIME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , SelectSequence = 104
            , DialogSequence = -1
            , Frozen = false
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "SysDate"
             )]
        public DateTime UPDATE_TIME
        {
            set { _update_time = value; }
            get { return _update_time; }
        }
        /// <summary>
        /// The Cachexia_Label Field of MUPRIME Table
        /// </summary>
        private string _Cachexia_Label;
        [DataField("Cachexia_Label"
            , AliasName = "Cachexia_Label"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "Cachexia_Label"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 87
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string Cachexia_Label
        {
            set { _Cachexia_Label = value; }
            get { return _Cachexia_Label; }
        }
        /// <summary>
        /// The SURVIVAL_CURVE Field of MUPRIME Table
        /// </summary>
        private string _survival_curve;
        [DataField("SURVIVAL_CURVE"
            , AliasName = "SURVIVAL_CURVE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SURVIVAL_CURVE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 90
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SURVIVAL_CURVE
        {
            set { _survival_curve = value; }
            get { return _survival_curve; }
        }
        /// <summary>
        /// The SOC Field of MUPRIME Table
        /// </summary>
        private string _soc;
        [DataField("SOC"
            , AliasName = "SOC"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 1000
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SOC"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 93
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SOC
        {
            set { _soc = value; }
            get { return _soc; }
        }
        /// <summary>
        /// MUPRIME Table 
        /// </summary>
        public const string TABLE_NAME = "MUPRIME";
        public const String MUPRIME_ID_FIELD = "MUPRIME_ID";
        public const String SQ_NUMBER_FIELD = "SQ_NUMBER";
        public const String CANCER_TYPE_ABBR_FIELD = "CANCER_TYPE_ABBR";
        public const String MODEL_ID_FIELD = "MODEL_ID";
        public const String MODEL_FROM_FIELD = "MODEL_FROM";
        public const String MOUSE_STRAIN_FIELD = "MOUSE_STRAIN";
        public const String CANCER_TYPE_FIELD = "CANCER_TYPE";
        public const String SUBTYPE1_FIELD = "SUBTYPE1";
        public const String SUBTYPE2_FIELD = "SUBTYPE2";
        public const String MODEL_CATEGORY_FIELD = "MODEL_CATEGORY";
        public const String MODEL_STATUS_FIELD = "MODEL_STATUS";
        public const String SOURCE_ID_FIELD = "SOURCE_ID";
        public const String SOURCE_NOTE_FIELD = "SOURCE_NOTE";
        public const String PDX_QC_FIELD = "PDX_QC";
        public const String TOTAL_REVIVAL_SUCCESS_RATE_FIELD = "TOTAL_REVIVAL_SUCCESS_RATE";
        public const String REVIVAL_RECOMMENDED_STRAIN_FIELD = "REVIVAL_RECOMMENDED_STRAIN";
        public const String TIME_OF_REVIVAL_FIELD = "TIME_OF_REVIVAL";
        public const String MAINTAIN_RECOMMENDED_STRAIN_FIELD = "MAINTAIN_RECOMMENDED_STRAIN";
        public const String GENOTYPE_CONSISTENCE_FIELD = "GENOTYPE_CONSISTENCE";
        public const String IN_HUBA_FIELD = "IN_HUBA";
        public const String TIME_OF_MODEL_FOR_TRANSPLANT_FIELD = "TIME_OF_MODEL_FOR_TRANSPLANT";
        public const String CV40_TAKE_RATE_FIELD = "CV40_TAKE_RATE";
        public const String CV30_TAKE_RATE_FIELD = "CV30_TAKE_RATE";
        public const String OPTIMAL_OVERAGE_FIELD = "OPTIMAL_OVERAGE";
        public const String DOSING_WINDOW_FIELD = "DOSING_WINDOW";
        public const String CRYO_P_FIELD = "CRYO_P";
        public const String SNAP_FROZEN_FIELD = "SNAP_FROZEN";
        public const String FFPE_FIELD = "FFPE";
        public const String TIMES_USED_IN_STUDY_FIELD = "TIMES_USED_IN_STUDY";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
        public const String Cachexia_Label_FIELD = "Cachexia_Label";
        public const String SURVIVAL_CURVE_FIELD = "SURVIVAL_CURVE";
        public const String SOC_FIELD = "SOC";
        public const String SOURCE_FIELD = "SOURCE";
    }
}