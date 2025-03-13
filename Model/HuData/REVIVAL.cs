using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for REVIVAL Table
    /// </summary>
    [Serializable]
    [DataTable("REVIVAL", ResourceKey = "REVIVAL")]
    public class REVIVAL : BaseObject
    {
        public REVIVAL()
        {
        }
        public REVIVAL(DealModel initModel) : base(initModel)
        {
        }
        public static REVIVAL Convert(BaseObject from)
        {
            return (REVIVAL)from;
        }
        /// <summary>
        /// The REVIVAL_ID Field of REVIVAL Table
        /// </summary>
        private decimal _revival_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.REVIVAL_ID = value;
            }
            get { return REVIVAL_ID; }
        }

        [RecordIDField("REVIVAL_ID"
            , AliasName = "REVIVAL_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "REVIVAL_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal REVIVAL_ID
        {
            set { _revival_id = value; }
            get { return _revival_id; }
        }
        /// <summary>
        /// The SQ1 Field of REVIVAL Table
        /// </summary>
        private string _sq1;
        [DataField("SQ1"
            , AliasName = "SQ1"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SQ1"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SQ1
        {
            set { _sq1 = value; }
            get { return _sq1; }
        }
        /// <summary>
        /// The SQ Field of REVIVAL Table
        /// </summary>
        private string _sq;
        [DataField("SQ"
            , AliasName = "SQ"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SQ"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SQ
        {
            set { _sq = value; }
            get { return _sq; }
        }
        /// <summary>
        /// The CANCERTYPE Field of REVIVAL Table
        /// </summary>
        private string _cancertype;
        [DataField("CANCERTYPE"
            , AliasName = "CANCERTYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CANCERTYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CANCERTYPE
        {
            set { _cancertype = value; }
            get { return _cancertype; }
        }
        /// <summary>
        /// The MODELID Field of REVIVAL Table
        /// </summary>
        private string _modelid;
        [DataField("MODELID"
            , AliasName = "MODELID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODELID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODELID
        {
            set { _modelid = value; }
            get { return _modelid; }
        }
        /// <summary>
        /// The DATE_OF_TISSUE_COLLECTION Field of REVIVAL Table
        /// </summary>
        private DateTime _date_of_tissue_collection;
		[DataField("DATE_OF_TISSUE_COLLECTION"
            , AliasName = "DATE_OF_TISSUE_COLLECTION"
            , DataType = DbType.Date

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DATE_OF_TISSUE_COLLECTION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime DATE_OF_TISSUE_COLLECTION
		{
			set { _date_of_tissue_collection = value; }
    get { return _date_of_tissue_collection; }
		}
		/// <summary>
		/// The BATCH_OF_CRYO_P_TISSUE Field of REVIVAL Table
		/// </summary>
		private string _batch_of_cryo_p_tissue;
[DataField("BATCH_OF_CRYO_P_TISSUE"
    , AliasName = "BATCH_OF_CRYO_P_TISSUE"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 250
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "BATCH_OF_CRYO_P_TISSUE"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 18
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string BATCH_OF_CRYO_P_TISSUE
{
    set { _batch_of_cryo_p_tissue = value; }
    get { return _batch_of_cryo_p_tissue; }
}
/// <summary>
/// The DATE_OF_REVIVAL Field of REVIVAL Table
/// </summary>
private DateTime _date_of_revival;
		[DataField("DATE_OF_REVIVAL"
            , AliasName = "DATE_OF_REVIVAL"
            , DataType = DbType.Date

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DATE_OF_REVIVAL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
public DateTime DATE_OF_REVIVAL
		{
			set { _date_of_revival = value; }
			get { return _date_of_revival; }
		}
		/// <summary>
		/// The DURATION_IN_LIN2 Field of REVIVAL Table
		/// </summary>
		private string _duration_in_lin2;
[DataField("DURATION_IN_LIN2"
    , AliasName = "DURATION_IN_LIN2"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "DURATION_IN_LIN2"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 24
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string DURATION_IN_LIN2
{
    set { _duration_in_lin2 = value; }
    get { return _duration_in_lin2; }
}
/// <summary>
/// The LOCATION Field of REVIVAL Table
/// </summary>
private string _location;
[DataField("LOCATION"
    , AliasName = "LOCATION"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "LOCATION"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 27
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
/// The PRE_RN Field of REVIVAL Table
/// </summary>
private string _pre_rn;
[DataField("PRE_RN"
    , AliasName = "PRE_RN"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "PRE_RN"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 30
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string PRE_RN
{
    set { _pre_rn = value; }
    get { return _pre_rn; }
}
/// <summary>
/// The RN Field of REVIVAL Table
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
    , SelectSequence = 33
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
/// The PN Field of REVIVAL Table
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
    , SelectSequence = 36
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
/// The RN_MATCH Field of REVIVAL Table
/// </summary>
private string _rn_match;
[DataField("RN_MATCH"
    , AliasName = "RN_MATCH"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "RN_MATCH"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 39
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string RN_MATCH
{
    set { _rn_match = value; }
    get { return _rn_match; }
}
/// <summary>
/// The ANIMAL_STRAIN Field of REVIVAL Table
/// </summary>
private string _animal_strain;
[DataField("ANIMAL_STRAIN"
    , AliasName = "ANIMAL_STRAIN"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "ANIMAL_STRAIN"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 42
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string ANIMAL_STRAIN
{
    set { _animal_strain = value; }
    get { return _animal_strain; }
}
/// <summary>
/// The ANIMAL_QUANTITY Field of REVIVAL Table
/// </summary>
private string _animal_quantity;
[DataField("ANIMAL_QUANTITY"
    , AliasName = "ANIMAL_QUANTITY"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "ANIMAL_QUANTITY"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 45
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string ANIMAL_QUANTITY
{
    set { _animal_quantity = value; }
    get { return _animal_quantity; }
}
/// <summary>
/// The DATE_OF_REVIVAL_SUCEEDED Field of REVIVAL Table
/// </summary>
private DateTime _date_of_revival_suceeded;
		[DataField("DATE_OF_REVIVAL_SUCEEDED"
            , AliasName = "DATE_OF_REVIVAL_SUCEEDED"
            , DataType = DbType.Date

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DATE_OF_REVIVAL_SUCEEDED"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 48
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
public DateTime DATE_OF_REVIVAL_SUCEEDED
		{
			set { _date_of_revival_suceeded = value; }
			get { return _date_of_revival_suceeded; }
		}
		/// <summary>
		/// The OUTCOME Field of REVIVAL Table
		/// </summary>
		private string _outcome;
[DataField("OUTCOME"
    , AliasName = "OUTCOME"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "OUTCOME"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 51
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string OUTCOME
{
    set { _outcome = value; }
    get { return _outcome; }
}
/// <summary>
/// The DURATION_OF_REVIVAL Field of REVIVAL Table
/// </summary>
private string _duration_of_revival;
[DataField("DURATION_OF_REVIVAL"
    , AliasName = "DURATION_OF_REVIVAL"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 500
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "DURATION_OF_REVIVAL"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 54
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string DURATION_OF_REVIVAL
{
    set { _duration_of_revival = value; }
    get { return _duration_of_revival; }
}
/// <summary>
/// The STUDY Field of REVIVAL Table
/// </summary>
private string _study;
[DataField("STUDY"
    , AliasName = "STUDY"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 500
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "STUDY"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 57
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string STUDY
{
    set { _study = value; }
    get { return _study; }
}
/// <summary>
/// The PROJECT_NO Field of REVIVAL Table
/// </summary>
private string _project_no;
[DataField("PROJECT_NO"
    , AliasName = "PROJECT_NO"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 250
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "PROJECT_NO"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 60
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string PROJECT_NO
{
    set { _project_no = value; }
    get { return _project_no; }
}
/// <summary>
/// The COMMENT Field of REVIVAL Table
/// </summary>
private string _comment;
[DataField("COMMENT"
    , AliasName = "COMMENT"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 250
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "COMMENT"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 63
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string COMMENT
{
    set { _comment = value; }
    get { return _comment; }
}
/// <summary>
/// The PRE_RECOVERY_PATHOGEN Field of REVIVAL Table
/// </summary>
private string _pre_recovery_pathogen;
[DataField("PRE_RECOVERY_PATHOGEN"
    , AliasName = "PRE_RECOVERY_PATHOGEN"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 250
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "PRE_RECOVERY_PATHOGEN"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 66
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string PRE_RECOVERY_PATHOGEN
{
    set { _pre_recovery_pathogen = value; }
    get { return _pre_recovery_pathogen; }
}
/// <summary>
/// The RECOVERY_PATHOGEN Field of REVIVAL Table
/// </summary>
private string _recovery_pathogen;
[DataField("RECOVERY_PATHOGEN"
    , AliasName = "RECOVERY_PATHOGEN"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 250
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "RECOVERY_PATHOGEN"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 69
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string RECOVERY_PATHOGEN
{
    set { _recovery_pathogen = value; }
    get { return _recovery_pathogen; }
}
/// <summary>
/// The IMPLANTATION_PATHOGEN Field of REVIVAL Table
/// </summary>
private string _implantation_pathogen;
[DataField("IMPLANTATION_PATHOGEN"
    , AliasName = "IMPLANTATION_PATHOGEN"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 250
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "IMPLANTATION_PATHOGEN"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 72
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string IMPLANTATION_PATHOGEN
{
    set { _implantation_pathogen = value; }
    get { return _implantation_pathogen; }
}
/// <summary>
/// The RECOVERY_SNP Field of REVIVAL Table
/// </summary>
private string _recovery_snp;
[DataField("RECOVERY_SNP"
    , AliasName = "RECOVERY_SNP"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 250
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "RECOVERY_SNP"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 75
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string RECOVERY_SNP
{
    set { _recovery_snp = value; }
    get { return _recovery_snp; }
}
/// <summary>
/// The IMPLANTATION_SNP Field of REVIVAL Table
/// </summary>
private string _implantation_snp;
[DataField("IMPLANTATION_SNP"
    , AliasName = "IMPLANTATION_SNP"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 250
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "IMPLANTATION_SNP"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 78
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string IMPLANTATION_SNP
{
    set { _implantation_snp = value; }
    get { return _implantation_snp; }
}
/// <summary>
/// The TIME_OF_UPDATE Field of REVIVAL Table
/// </summary>
private DateTime _time_of_update;
		[DataField("TIME_OF_UPDATE"
            , AliasName = "TIME_OF_UPDATE"
            , DataType = DbType.Date

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TIME_OF_UPDATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 81
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
public DateTime TIME_OF_UPDATE
		{
			set { _time_of_update = value; }
			get { return _time_of_update; }
		}
		/// <summary>
		/// The NAME_OF_UPDATE Field of REVIVAL Table
		/// </summary>
		private String _name_of_update;
		[DataField("NAME_OF_UPDATE"
            , AliasName = "NAME_OF_UPDATE"
            , DataType = DbType.String

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "NAME_OF_UPDATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 84
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
public String NAME_OF_UPDATE
		{
			set { _name_of_update = value; }
			get { return _name_of_update; }
		}
		/// <summary>
		/// REVIVAL Table 
		/// </summary>
		public const string TABLE_NAME = "REVIVAL";
public const String REVIVAL_ID_FIELD = "REVIVAL_ID";
public const String SQ1_FIELD = "SQ1";
public const String SQ_FIELD = "SQ";
public const String CANCERTYPE_FIELD = "CANCERTYPE";
public const String MODELID_FIELD = "MODELID";
public const String DATE_OF_TISSUE_COLLECTION_FIELD = "DATE_OF_TISSUE_COLLECTION";
public const String BATCH_OF_CRYO_P_TISSUE_FIELD = "BATCH_OF_CRYO_P_TISSUE";
public const String DATE_OF_REVIVAL_FIELD = "DATE_OF_REVIVAL";
public const String DURATION_IN_LIN2_FIELD = "DURATION_IN_LIN2";
public const String LOCATION_FIELD = "LOCATION";
public const String PRE_RN_FIELD = "PRE_RN";
public const String RN_FIELD = "RN";
public const String PN_FIELD = "PN";
public const String RN_MATCH_FIELD = "RN_MATCH";
public const String ANIMAL_STRAIN_FIELD = "ANIMAL_STRAIN";
public const String ANIMAL_QUANTITY_FIELD = "ANIMAL_QUANTITY";
public const String DATE_OF_REVIVAL_SUCEEDED_FIELD = "DATE_OF_REVIVAL_SUCEEDED";
public const String OUTCOME_FIELD = "OUTCOME";
public const String DURATION_OF_REVIVAL_FIELD = "DURATION_OF_REVIVAL";
public const String STUDY_FIELD = "STUDY";
public const String PROJECT_NO_FIELD = "PROJECT_NO";
public const String COMMENT_FIELD = "COMMENT";
public const String PRE_RECOVERY_PATHOGEN_FIELD = "PRE_RECOVERY_PATHOGEN";
public const String RECOVERY_PATHOGEN_FIELD = "RECOVERY_PATHOGEN";
public const String IMPLANTATION_PATHOGEN_FIELD = "IMPLANTATION_PATHOGEN";
public const String RECOVERY_SNP_FIELD = "RECOVERY_SNP";
public const String IMPLANTATION_SNP_FIELD = "IMPLANTATION_SNP";
public const String TIME_OF_UPDATE_FIELD = "TIME_OF_UPDATE";
public const String NAME_OF_UPDATE_FIELD = "NAME_OF_UPDATE";
	}
}