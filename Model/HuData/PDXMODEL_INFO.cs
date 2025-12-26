using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for PDXMODEL_INFO Table
    /// </summary>
    [Serializable]
    [DataTable("PDXMODEL_INFO", ResourceKey = "PDXMODEL_INFO")]
    public class PDXMODEL_INFO : BaseObject
    {
        public PDXMODEL_INFO()
        {
        }
        public PDXMODEL_INFO(DealModel initModel) : base(initModel)
        {
        }
        public static PDXMODEL_INFO Convert(BaseObject from)
        {
            return (PDXMODEL_INFO)from;
        }
        /// <summary>
        /// The PDXMODEL_INFO_ID Field of PDXMODEL_INFO Table
        /// </summary>
        private decimal _pdxmodel_info_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.PDXMODEL_INFO_ID = value;
            }
            get { return PDXMODEL_INFO_ID; }
        }
        public override string CODE
        {
            set
            {
                base.CODE = value;
                this.MODEL_ID = value;
            }
            get { return MODEL_ID; }
        }
        [RecordIDField("PDXMODEL_INFO_ID"
            , AliasName = "PDXMODEL_INFO_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PDXMODEL_INFO_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal PDXMODEL_INFO_ID
        {
            set { _pdxmodel_info_id = value; }
            get { return _pdxmodel_info_id; }
        }
        /// <summary>
        /// The SQ_NUMBER Field of PDXMODEL_INFO Table
        /// </summary>
        private string _sq_number;
        [DataField("SQ_NUMBER"
            , AliasName = "SQ_NUMBER"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 5
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
        /// The CANCER_TYPE_ABBR Field of PDXMODEL_INFO Table
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
        /// The MODEL_ID Field of PDXMODEL_INFO Table
        /// </summary>
        private string _model_id;
        [KeyField("MODEL_ID"
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
        /// The PATIENT_ID Field of PDXMODEL_INFO Table
        /// </summary>
        private string _patient_id;
        [DataField("PATIENT_ID"
            , AliasName = "PATIENT_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PATIENT_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// The SOURCE Field of PDXMODEL_INFO Table
        /// </summary>
        private string _source;
        [DataField("SOURCE"
            , AliasName = "SOURCE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SOURCE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 14
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
        /// The ORIGIN Field of PDXMODEL_INFO Table
        /// </summary>
        private string _origin;
        [DataField("ORIGIN"
            , AliasName = "ORIGIN"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ORIGIN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ORIGIN
        {
            set { _origin = value; }
            get { return _origin; }
        }
        /// <summary>
        /// The CANCER_TYPE Field of PDXMODEL_INFO Table
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
        /// The SUBTYPE1 Field of PDXMODEL_INFO Table
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
        /// The SUBTYPE2 Field of PDXMODEL_INFO Table
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
        /// The MODEL_CATEGORY Field of PDXMODEL_INFO Table
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
        /// The MODEL_STATUS Field of PDXMODEL_INFO Table
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
        /// The SOURCE_ID Field of PDXMODEL_INFO Table
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
        /// The SOURCE_NOTE Field of PDXMODEL_INFO Table
        /// </summary>
        private string _source_note;
        [DataField("SOURCE_NOTE"
            , AliasName = "SOURCE_NOTE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
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
        /// The PDX_QC Field of PDXMODEL_INFO Table
        /// </summary>
        private string _pdx_qc;
        [DataField("PDX_QC"
            , AliasName = "PDX_QC"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
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
        /// The STR_CONSISTENCE Field of PDXMODEL_INFO Table
        /// </summary>
        private string _str_consistence;
        [DataField("STR_CONSISTENCE"
            , AliasName = "STR_CONSISTENCE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "STR_CONSISTENCE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 40
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string STR_CONSISTENCE
        {
            set { _str_consistence = value; }
            get { return _str_consistence; }
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
            , SelectSequence = 41
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
        /// The TOTAL_REVIVAL_SUCCESS_RATE Field of PDXMODEL_INFO Table
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
        /// The TIME_OF_REVIVAL Field of PDXMODEL_INFO Table
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
            , SelectSequence = 43
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
        /// The REVIVAL_RECOMMENDED_STRAIN Field of PDXMODEL_INFO Table
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
        /// The TIME_OF_MODEL_FOR_TRANSPLANT Field of PDXMODEL_INFO Table
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
            , SelectSequence = 46
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
        /// The MAINTAIN_RECOMMENDED_STRAIN Field of PDXMODEL_INFO Table
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
        /// The IMPLANTATION_METHOD Field of PDXMODEL_INFO Table
        /// </summary>
        private string _implantation_method;
        [DataField("IMPLANTATION_METHOD"
            , AliasName = "IMPLANTATION_METHOD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IMPLANTATION_METHOD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 52
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string IMPLANTATION_METHOD
        {
            set { _implantation_method = value; }
            get { return _implantation_method; }
        }
        /// <summary>
        /// The CV40_TAKE_RATE Field of PDXMODEL_INFO Table
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
        /// The CV30_TAKE_RATE Field of PDXMODEL_INFO Table
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
            , SelectSequence = 69
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
        /// The DOSING_WINDOW Field of PDXMODEL_INFO Table
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
            , SelectSequence = 72
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
        /// The CRYO_P Field of PDXMODEL_INFO Table
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
            , SelectSequence = 75
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
        /// The SNAP_FROZEN Field of PDXMODEL_INFO Table
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
            , SelectSequence = 78
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
        /// The FFPE Field of PDXMODEL_INFO Table
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
            , SelectSequence = 81
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
        /// The HP2 Field of PDXMODEL_INFO Table
        /// </summary>
        private string _hp2;
        [DataField("HP2"
            , AliasName = "HP2"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "HP2"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 84
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string HP2
        {
            set { _hp2 = value; }
            get { return _hp2; }
        }
        /// <summary>
        /// The TIMES_USED_IN_STUDY Field of PDXMODEL_INFO Table
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
            , SelectSequence = 87
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
        /// The UPDATE_TIME Field of PDXMODEL_INFO Table
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
        /// The CACHEXIA_LABEL Field of PDXMODEL_INFO Table
        /// </summary>
        private string _cachexia_label;
        [DataField("CACHEXIA_LABEL"
            , AliasName = "CACHEXIA_LABEL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CACHEXIA_LABEL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 93
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CACHEXIA_LABEL
        {
            set { _cachexia_label = value; }
            get { return _cachexia_label; }
        }
        /// <summary>
        /// The CACHEXIA Field of PDXMODEL_INFO Table
        /// </summary>
        private string _cachexia;
        [DataField("CACHEXIA"
            , AliasName = "CACHEXIA"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CACHEXIA"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 96
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CACHEXIA
        {
            set { _cachexia = value; }
            get { return _cachexia; }
        }
        /// <summary>
        /// The SLIGHT_BW_LOSS Field of PDXMODEL_INFO Table
        /// </summary>
        private string _slight_bw_loss;
        [DataField("SLIGHT_BW_LOSS"
            , AliasName = "SLIGHT_BW_LOSS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SLIGHT_BW_LOSS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 99
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SLIGHT_BW_LOSS
        {
            set { _slight_bw_loss = value; }
            get { return _slight_bw_loss; }
        }
        /// <summary>
        /// The NORMAL Field of PDXMODEL_INFO Table
        /// </summary>
        private string _normal;
        [DataField("NORMAL"
            , AliasName = "NORMAL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "NORMAL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 102
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string NORMAL
        {
            set { _normal = value; }
            get { return _normal; }
        }
        /// <summary>
        /// The ULCERATION_LABEL Field of PDXMODEL_INFO Table
        /// </summary>
        private string _ulceration_label;
        [DataField("ULCERATION_LABEL"
            , AliasName = "ULCERATION_LABEL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ULCERATION_LABEL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 105
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ULCERATION_LABEL
        {
            set { _ulceration_label = value; }
            get { return _ulceration_label; }
        }
        /// <summary>
        /// The SURVIVAL_CURVE Field of PDXMODEL_INFO Table
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
            , SelectSequence = 108
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
        /// The SOC Field of PDXMODEL_INFO Table
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
            , SelectSequence = 111
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
        /// The EXOMESEQ Field of PDXMODEL_INFO Table
        /// </summary>
        private string _exomeseq;
        [DataField("EXOMESEQ"
            , AliasName = "EXOMESEQ"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "EXOMESEQ"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 112
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string EXOMESEQ
        {
            set { _exomeseq = value; }
            get { return _exomeseq; }
        }

        /// <summary>
        /// The DATA_TYPE Field of PDXMODEL_INFO Table
        /// </summary>
        private string _data_type;
        [DataField("DATA_TYPE"
            , AliasName = "DATA_TYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 5
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DATA_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 114
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DATA_TYPE
        {
            set { _data_type = value; }
            get { return _data_type; }
        }
        /// <summary>
        /// The COMMENTS Field of PDXMODEL_INFO Table
        /// </summary>
        private string _comments;
        [DataField("COMMENTS"
            , AliasName = "COMMENTS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 1000
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COMMENTS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 117
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COMMENTS
        {
            set { _comments = value; }
            get { return _comments; }
        }
        /// <summary>
        /// The LOCATION Field of PDXMODEL_INFO Table
        /// </summary>
        private string _location;
        [DataField("LOCATION"
            , AliasName = "LOCATION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 5
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "LOCATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 120
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string LOCATION
        {
            set { _location = value; }
            get { return _location; }
        }
        /// <summary>
        /// The TOTAL_REVIVAL_SUCCESS_RATE_CBNC Field of PDXMODEL_INFO Table
        /// </summary>
        private string _total_revival_success_rate_cbsd;
        [DataField("TOTAL_REVIVAL_SUCCESS_RATE_CBNC"
            , AliasName = "TOTAL_REVIVAL_SUCCESS_RATE_CBNC"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TOTAL_REVIVAL_SUCCESS_RATE_CBNC"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 123
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TOTAL_REVIVAL_SUCCESS_RATE_CBNC
        {
            set { _total_revival_success_rate_cbsd = value; }
            get { return _total_revival_success_rate_cbsd; }
        }
        /// <summary>
        /// The TIME_OF_REVIVAL_CBNC Field of PDXMODEL_INFO Table
        /// </summary>
        private string _time_of_revival_cbsd;
        [DataField("TIME_OF_REVIVAL_CBNC"
            , AliasName = "TIME_OF_REVIVAL_CBNC"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TIME_OF_REVIVAL_CBNC"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 126
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TIME_OF_REVIVAL_CBNC
        {
            set { _time_of_revival_cbsd = value; }
            get { return _time_of_revival_cbsd; }
        }
        /// <summary>
        /// The REVIVAL_RECOMMENDED_STRAIN_CBNC Field of PDXMODEL_INFO Table
        /// </summary>
        private string _revival_recommended_strain_cbsd;
        [DataField("REVIVAL_RECOMMENDED_STRAIN_CBNC"
            , AliasName = "REVIVAL_RECOMMENDED_STRAIN_CBNC"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REVIVAL_RECOMMENDED_STRAIN_CBNC"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 129
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REVIVAL_RECOMMENDED_STRAIN_CBNC
        {
            set { _revival_recommended_strain_cbsd = value; }
            get { return _revival_recommended_strain_cbsd; }
        }
     
        /// <summary>
        /// The TREATMENT_HISTORY_1 Field of PDXMODEL_INFO Table
        /// </summary>
        private string _treatment_history_1;
        [DataField("TREATMENT_HISTORY_1"
            , AliasName = "TREATMENT_HISTORY_1"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 500
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TREATMENT_HISTORY_1"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 135
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TREATMENT_HISTORY_1
        {
            set { _treatment_history_1 = value; }
            get { return _treatment_history_1; }
        }
        /// <summary>
        /// The TREATMENT_HISTORY_2 Field of PDXMODEL_INFO Table
        /// </summary>
        private string _treatment_history_2;
        [DataField("TREATMENT_HISTORY_2"
            , AliasName = "TREATMENT_HISTORY_2"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 500
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TREATMENT_HISTORY_2"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 138
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TREATMENT_HISTORY_2
        {
            set { _treatment_history_2 = value; }
            get { return _treatment_history_2; }
        }
   

        /// <summary>
        /// The MODEL_FROM Field of PDXMODEL_INFO Table
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
            , SelectSequence = 143
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODEL_FROM
        {
            set { _model_from = value; }
            get { return _model_from; }
        }

        /// <summary>
		/// The DEATHRATE Field of PDXMODEL_INFO Table
		/// </summary>
		private string _deathrate;
        [DataField("DEATHRATE"
            , AliasName = "DEATHRATE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DEATHRATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 147
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DEATHRATE
        {
            set { _deathrate = value; }
            get { return _deathrate; }
        }


        /// <summary>
        /// PDXMODEL_INFO Table 
        /// </summary>
        public const string TABLE_NAME = "PDXMODEL_INFO";
        public const String PDXMODEL_INFO_ID_FIELD = "PDXMODEL_INFO_ID";
        public const String SQ_NUMBER_FIELD = "SQ_NUMBER";
        public const String CANCER_TYPE_ABBR_FIELD = "CANCER_TYPE_ABBR";
        public const String MODEL_ID_FIELD = "MODEL_ID";
        public const String SOURCE_FIELD = "SOURCE";
        public const String ORIGIN_FIELD = "ORIGIN";
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
        public const String STR_CONSISTENCE_FIELD = "STR_CONSISTENCE";
        public const String IN_HUBA_FIELD = "IN_HUBA";
        public const String TIME_OF_MODEL_FOR_TRANSPLANT_FIELD = "TIME_OF_MODEL_FOR_TRANSPLANT";
        public const String CV40_TAKE_RATE_FIELD = "CV40_TAKE_RATE";
        public const String CV30_TAKE_RATE_FIELD = "CV30_TAKE_RATE";
        public const String OPTIMAL_OVERAGE_FIELD = "OPTIMAL_OVERAGE";
        public const String DOSING_WINDOW_FIELD = "DOSING_WINDOW";
        public const String CRYO_P_FIELD = "CRYO_P";
        public const String SNAP_FROZEN_FIELD = "SNAP_FROZEN";
        public const String FFPE_FIELD = "FFPE";
        public const String HP2_FIELD = "HP2";
        public const String TIMES_USED_IN_STUDY_FIELD = "TIMES_USED_IN_STUDY";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
        public const String CACHEXIA_LABEL_FIELD = "CACHEXIA_LABEL";
        public const String CACHEXIA_FIELD = "CACHEXIA";
        public const String SLIGHT_BW_LOSS_FIELD = "SLIGHT_BW_LOSS";
        public const String NORMAL_FIELD = "NORMAL";
        public const String ULCERATION_LABEL_FIELD = "ULCERATION_LABEL";
        public const String SURVIVAL_CURVE_FIELD = "SURVIVAL_CURVE";
        public const String SOC_FIELD = "SOC";
        public const String DATA_TYPE_FIELD = "DATA_TYPE";
        public const String COMMENTS_FIELD = "COMMENTS";
        public const String LOCATION_FIELD = "LOCATION";
        public const String TOTAL_REVIVAL_SUCCESS_RATE_CBNC_FIELD = "TOTAL_REVIVAL_SUCCESS_RATE_CBNC";
        public const String TIME_OF_REVIVAL_CBNC_FIELD = "TIME_OF_REVIVAL_CBNC";
        public const String REVIVAL_RECOMMENDED_STRAIN_CBNC_FIELD = "REVIVAL_RECOMMENDED_STRAIN_CBNC";
        public const String EXOMESEQ_FIELD = "EXOMESEQ";
        public const String TREATMENT_HISTORY_1_FIELD = "TREATMENT_HISTORY_1";
        public const String TREATMENT_HISTORY_2_FIELD = "TREATMENT_HISTORY_2";
     
        public const String MODEL_FROM_FIELD = "MODEL_FROM";
        public const String IMPLANTATION_METHOD_FIELD = "IMPLANTATION_METHOD";
        public const String DEATHRATE_FIELD = "DEATHRATE";
        public const String PATIENT_ID_FIELD = "PATIENT_ID";
    }
}