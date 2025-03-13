using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for VALIDATIONSTATUS_HUPRIME Table
    /// </summary>
    [Serializable]
    [DataTable("VALIDATIONSTATUS_HUPRIME", ResourceKey = "VALIDATIONSTATUS_HUPRIME")]
    public class VALIDATIONSTATUS_HUPRIME : BaseObject
    {
        public VALIDATIONSTATUS_HUPRIME()
        {
        }
        public VALIDATIONSTATUS_HUPRIME(DealModel initModel) : base(initModel)
        {
        }
        public static VALIDATIONSTATUS_HUPRIME Convert(BaseObject from)
        {
            return (VALIDATIONSTATUS_HUPRIME)from;
        }
        /// <summary>
        /// The VALIDATIONSTATUS_HUPRIME_ID Field of VALIDATIONSTATUS_HUPRIME Table
        /// </summary>
        private decimal _validationstatus_huprime_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.VALIDATIONSTATUS_HUPRIME_ID = value;
            }
            get { return VALIDATIONSTATUS_HUPRIME_ID; }
        }

        [RecordIDField("VALIDATIONSTATUS_HUPRIME_ID"
            , AliasName = "VALIDATIONSTATUS_HUPRIME_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "VALIDATIONSTATUS_HUPRIME_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal VALIDATIONSTATUS_HUPRIME_ID
        {
            set { _validationstatus_huprime_id = value; }
            get { return _validationstatus_huprime_id; }
        }
        /// <summary>
        /// The SQ Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// The CANCERTYPE Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// The CANCERTYPEABBR Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// The MODELID Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// The MODEL_TYPE Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// The SOURCE Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// The PROJECT Field of VALIDATIONSTATUS_HUPRIME Table
        /// </summary>
        private string _project;
        [DataField("PROJECT"
            , AliasName = "PROJECT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROJECT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PROJECT
        {
            set { _project = value; }
            get { return _project; }
        }
        /// <summary>
        /// The ESTABLISHED_DATE Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// The ESTABLISHED_LOCATION Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// The VALIDATIONSTATUS Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// The FINALDATEOFVALIDATION Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// The CRYO_PTISSUE Field of VALIDATIONSTATUS_HUPRIME Table
        /// </summary>
        private DateTime _cryo_ptissue;
        [DataField("CRYO_PTISSUE"
            , AliasName = "CRYO_PTISSUE"
            , DataType = DbType.Date

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CRYO_PTISSUE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime CRYO_PTISSUE
        {
            set { _cryo_ptissue = value; }
            get { return _cryo_ptissue; }
        }
        /// <summary>
        /// The CRYO_PTISSUE_NUMBER Field of VALIDATIONSTATUS_HUPRIME Table
        /// </summary>
        private string _cryo_ptissue_number;
        [DataField("CRYO_PTISSUE_NUMBER"
            , AliasName = "CRYO_PTISSUE_NUMBER"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CRYO_PTISSUE_NUMBER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 39
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CRYO_PTISSUE_NUMBER
        {
            set { _cryo_ptissue_number = value; }
            get { return _cryo_ptissue_number; }
        }
        /// <summary>
        /// The FROZEN_STORAGE Field of VALIDATIONSTATUS_HUPRIME Table
        /// </summary>
        private string _frozen_storage;
        [DataField("FROZEN_STORAGE"
            , AliasName = "FROZEN_STORAGE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FROZEN_STORAGE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 42
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FROZEN_STORAGE
        {
            set { _frozen_storage = value; }
            get { return _frozen_storage; }
        }
        /// <summary>
        /// The 1STREVIVAL Field of VALIDATIONSTATUS_HUPRIME Table
        /// </summary>
        private string _first_revival;
        [DataField("FIRST_REVIVAL"
            , AliasName = "FIRST_REVIVAL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FIRST_REVIVAL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 45
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FIRST_REVIVAL
        {
            set { _first_revival = value; }
            get { return _first_revival; }
        }
        /// <summary>
        /// The GC Field of VALIDATIONSTATUS_HUPRIME Table
        /// </summary>
        private string _gc;
        [DataField("GC"
            , AliasName = "GC"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "GC"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 48
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string GC
        {
            set { _gc = value; }
            get { return _gc; }
        }
        /// <summary>
        /// The ANIMALROOMNUMBER Field of VALIDATIONSTATUS_HUPRIME Table
        /// </summary>
        private string _animalroomnumber;
        [DataField("ANIMALROOMNUMBER"
            , AliasName = "ANIMALROOMNUMBER"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ANIMALROOMNUMBER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 51
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ANIMALROOMNUMBER
        {
            set { _animalroomnumber = value; }
            get { return _animalroomnumber; }
        }
        /// <summary>
        /// The DATEOFUPDATE Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// The COMMENT Field of VALIDATIONSTATUS_HUPRIME Table
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
        /// VALIDATIONSTATUS_HUPRIME Table 
        /// </summary>
        public const string TABLE_NAME = "VALIDATIONSTATUS_HUPRIME";
        public const String VALIDATIONSTATUS_HUPRIME_ID_FIELD = "VALIDATIONSTATUS_HUPRIME_ID";
        public const String SQ_FIELD = "SQ";
        public const String CANCERTYPE_FIELD = "CANCERTYPE";
        public const String CANCERTYPEABBR_FIELD = "CANCERTYPEABBR";
        public const String MODELID_FIELD = "MODELID";
        public const String MODEL_TYPE_FIELD = "MODEL_TYPE";
        public const String SOURCE_FIELD = "SOURCE";
        public const String PROJECT_FIELD = "PROJECT";
        public const String ESTABLISHED_DATE_FIELD = "ESTABLISHED_DATE";
        public const String ESTABLISHED_LOCATION_FIELD = "ESTABLISHED_LOCATION";
        public const String VALIDATIONSTATUS_FIELD = "VALIDATIONSTATUS";
        public const String FINALDATEOFVALIDATION_FIELD = "FINALDATEOFVALIDATION";
        public const String CRYO_PTISSUE_FIELD = "CRYO_PTISSUE";
        public const String CRYO_PTISSUE_NUMBER_FIELD = "CRYO_PTISSUE_NUMBER";
        public const String FROZEN_STORAGE_FIELD = "FROZEN_STORAGE";
        public const String FIRST_REVIVAL_FIELD = "FIRST_REVIVAL";
        public const String GC_FIELD = "GC";
        public const String ANIMALROOMNUMBER_FIELD = "ANIMALROOMNUMBER";
        public const String DATEOFUPDATE_FIELD = "DATEOFUPDATE";
        public const String COMMENT_FIELD = "COMMENT";
    }
}