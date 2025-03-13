using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for VALIDATIONSTATUS_HUKIME Table
    /// </summary>
    [Serializable]
    [DataTable("VALIDATIONSTATUS_HUKIME", ResourceKey = "VALIDATIONSTATUS_HUKIME")]
    public class VALIDATIONSTATUS_HUKIME : BaseObject
    {
        public VALIDATIONSTATUS_HUKIME()
        {
        }
        public VALIDATIONSTATUS_HUKIME(DealModel initModel) : base(initModel)
        {
        }
        public static VALIDATIONSTATUS_HUKIME Convert(BaseObject from)
        {
            return (VALIDATIONSTATUS_HUKIME)from;
        }
        /// <summary>
        /// The VALIDATIONSTATUS_HUKIME_ID Field of VALIDATIONSTATUS_HUKIME Table
        /// </summary>
        private decimal _validationstatus_hukime_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.VALIDATIONSTATUS_HUKIME_ID = value;
            }
            get { return VALIDATIONSTATUS_HUKIME_ID; }
        }

        [RecordIDField("VALIDATIONSTATUS_HUKIME_ID"
            , AliasName = "VALIDATIONSTATUS_HUKIME_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "VALIDATIONSTATUS_HUKIME_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal VALIDATIONSTATUS_HUKIME_ID
        {
            set { _validationstatus_hukime_id = value; }
            get { return _validationstatus_hukime_id; }
        }
        /// <summary>
        /// The SQ Field of VALIDATIONSTATUS_HUKIME Table
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
            , SelectSequence = 3
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
        /// The CANCERTYPE Field of VALIDATIONSTATUS_HUKIME Table
        /// </summary>
        private string _cancertype;
        [DataField("CANCERTYPE"
            , AliasName = "CANCERTYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 250
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CANCERTYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
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
        /// The CANCERTYPEABBR Field of VALIDATIONSTATUS_HUKIME Table
        /// </summary>
        private string _cancertypeabbr;
        [DataField("CANCERTYPEABBR"
            , AliasName = "CANCERTYPEABBR"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CANCERTYPEABBR"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CANCERTYPEABBR
        {
            set { _cancertypeabbr = value; }
            get { return _cancertypeabbr; }
        }
        /// <summary>
        /// The MODELID Field of VALIDATIONSTATUS_HUKIME Table
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
        /// The MODEL_TYPE Field of VALIDATIONSTATUS_HUKIME Table
        /// </summary>
        private string _model_type;
        [DataField("MODEL_TYPE"
            , AliasName = "MODEL_TYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODEL_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODEL_TYPE
        {
            set { _model_type = value; }
            get { return _model_type; }
        }
        /// <summary>
        /// The SOURCE Field of VALIDATIONSTATUS_HUKIME Table
        /// </summary>
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
            , SelectSequence = 18
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
        /// The SUBTYPE Field of VALIDATIONSTATUS_HUKIME Table
        /// </summary>
        private string _subtype;
        [DataField("SUBTYPE"
            , AliasName = "SUBTYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SUBTYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SUBTYPE
        {
            set { _subtype = value; }
            get { return _subtype; }
        }
        /// <summary>
        /// The ESTABLISHED_DATE Field of VALIDATIONSTATUS_HUKIME Table
        /// </summary>
        private DateTime _established_date;
		[DataField("ESTABLISHED_DATE"
            , AliasName = "ESTABLISHED_DATE"
            , DataType = DbType.Date

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ESTABLISHED_DATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime ESTABLISHED_DATE
		{
			set { _established_date = value; }
    get { return _established_date; }
		}
		/// <summary>
		/// The ESTABLISHED_LOCATION Field of VALIDATIONSTATUS_HUKIME Table
		/// </summary>
		private string _established_location;
[DataField("ESTABLISHED_LOCATION"
    , AliasName = "ESTABLISHED_LOCATION"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "ESTABLISHED_LOCATION"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 27
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string ESTABLISHED_LOCATION
{
    set { _established_location = value; }
    get { return _established_location; }
}
/// <summary>
/// The VALIDATIONSTATUS Field of VALIDATIONSTATUS_HUKIME Table
/// </summary>
private string _validationstatus;
[DataField("VALIDATIONSTATUS"
    , AliasName = "VALIDATIONSTATUS"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "VALIDATIONSTATUS"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 30
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string VALIDATIONSTATUS
{
    set { _validationstatus = value; }
    get { return _validationstatus; }
}
/// <summary>
/// The FINALDATEOFVALIDATION Field of VALIDATIONSTATUS_HUKIME Table
/// </summary>
private DateTime _finaldateofvalidation;
		[DataField("FINALDATEOFVALIDATION"
            , AliasName = "FINALDATEOFVALIDATION"
            , DataType = DbType.Date

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FINALDATEOFVALIDATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
public DateTime FINALDATEOFVALIDATION
		{
			set { _finaldateofvalidation = value; }
			get { return _finaldateofvalidation; }
		}
		/// <summary>
		/// The TU Field of VALIDATIONSTATUS_HUKIME Table
		/// </summary>
		private string _tu;
[DataField("TU"
    , AliasName = "TU"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "TU"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 36
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string TU
{
    set { _tu = value; }
    get { return _tu; }
}
/// <summary>
/// The FACS Field of VALIDATIONSTATUS_HUKIME Table
/// </summary>
private string _facs;
[DataField("FACS"
    , AliasName = "FACS"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 250
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "FACS"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 39
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string FACS
{
    set { _facs = value; }
    get { return _facs; }
}
/// <summary>
/// The BANK Field of VALIDATIONSTATUS_HUKIME Table
/// </summary>
private string _bank;
[DataField("BANK"
    , AliasName = "BANK"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "BANK"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 42
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string BANK
{
    set { _bank = value; }
    get { return _bank; }
}
/// <summary>
/// The REVIVAL Field of VALIDATIONSTATUS_HUKIME Table
/// </summary>
private string _revival;
[DataField("REVIVAL"
    , AliasName = "REVIVAL"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "REVIVAL"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 45
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string REVIVAL
{
    set { _revival = value; }
    get { return _revival; }
}
/// <summary>
/// The PASSAGE Field of VALIDATIONSTATUS_HUKIME Table
/// </summary>
private string _passage;
[DataField("PASSAGE"
    , AliasName = "PASSAGE"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "PASSAGE"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 48
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string PASSAGE
{
    set { _passage = value; }
    get { return _passage; }
}
/// <summary>
/// The SNP Field of VALIDATIONSTATUS_HUKIME Table
/// </summary>
private string _snp;
[DataField("SNP"
    , AliasName = "SNP"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 50
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "SNP"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 51
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string SNP
{
    set { _snp = value; }
    get { return _snp; }
}
/// <summary>
/// The DATEOFUPDATE Field of VALIDATIONSTATUS_HUKIME Table
/// </summary>
private DateTime _dateofupdate;
		[DataField("DATEOFUPDATE"
            , AliasName = "DATEOFUPDATE"
            , DataType = DbType.Date

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DATEOFUPDATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 54
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
public DateTime DATEOFUPDATE
		{
			set { _dateofupdate = value; }
			get { return _dateofupdate; }
		}
		/// <summary>
		/// The COMMENT Field of VALIDATIONSTATUS_HUKIME Table
		/// </summary>
		private string _comment;
[DataField("COMMENT"
    , AliasName = "COMMENT"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 500
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "COMMENT"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 57
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
/// VALIDATIONSTATUS_HUKIME Table 
/// </summary>
public const string TABLE_NAME = "VALIDATIONSTATUS_HUKIME";
public const String VALIDATIONSTATUS_HUKIME_ID_FIELD = "VALIDATIONSTATUS_HUKIME_ID";
public const String SQ_FIELD = "SQ";
public const String CANCERTYPE_FIELD = "CANCERTYPE";
public const String CANCERTYPEABBR_FIELD = "CANCERTYPEABBR";
public const String MODELID_FIELD = "MODELID";
public const String MODEL_TYPE_FIELD = "MODEL_TYPE";
public const String SOURCE_FIELD = "SOURCE";
public const String SUBTYPE_FIELD = "SUBTYPE";
public const String ESTABLISHED_DATE_FIELD = "ESTABLISHED_DATE";
public const String ESTABLISHED_LOCATION_FIELD = "ESTABLISHED_LOCATION";
public const String VALIDATIONSTATUS_FIELD = "VALIDATIONSTATUS";
public const String FINALDATEOFVALIDATION_FIELD = "FINALDATEOFVALIDATION";
public const String TU_FIELD = "TU";
public const String FACS_FIELD = "FACS";
public const String BANK_FIELD = "BANK";
public const String REVIVAL_FIELD = "REVIVAL";
public const String PASSAGE_FIELD = "PASSAGE";
public const String SNP_FIELD = "SNP";
public const String DATEOFUPDATE_FIELD = "DATEOFUPDATE";
public const String COMMENT_FIELD = "COMMENT";
	}
}