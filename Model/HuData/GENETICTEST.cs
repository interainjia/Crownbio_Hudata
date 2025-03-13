using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for GENETICTEST Table
    /// </summary>
    [Serializable]
    [DataTable("GENETICTEST", ResourceKey = "GENETICTEST")]
    public class GENETICTEST : BaseObject
    {
        public GENETICTEST()
        {
        }
        public GENETICTEST(DealModel initModel) : base(initModel)
        {
        }
        public static GENETICTEST Convert(BaseObject from)
        {
            return (GENETICTEST)from;
        }
        /// <summary>
        /// The GENETICTEST_ID Field of GENETICTEST Table
        /// </summary>
        private decimal _genetictest_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.GENETICTEST_ID = value;
            }
            get { return GENETICTEST_ID; }
        }

        [RecordIDField("GENETICTEST_ID"
            , AliasName = "GENETICTEST_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "GENETICTEST_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal GENETICTEST_ID
        {
            set { _genetictest_id = value; }
            get { return _genetictest_id; }
        }
        /// <summary>
        /// The SQ_NUMBER Field of GENETICTEST Table
        /// </summary>
        private string _sq_number;
        [DataField("SQ_NUMBER"
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
        /// The MODEL_ID Field of GENETICTEST Table
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
        /// The SOURCE Field of GENETICTEST Table
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
            , SelectSequence = 9
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
        /// The RNASEQ Field of GENETICTEST Table
        /// </summary>
        private string _rnaseq;
        [DataField("RNASEQ"
            , AliasName = "RNASEQ"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 500
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "RNASEQ"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string RNASEQ
        {
            set { _rnaseq = value; }
            get { return _rnaseq; }
        }
        /// <summary>
        /// The WES Field of GENETICTEST Table
        /// </summary>
        private string _wes;
        [DataField("WES"
            , AliasName = "WES"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 500
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "WES"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string WES
        {
            set { _wes = value; }
            get { return _wes; }
        }
        /// <summary>
        /// The WGS Field of GENETICTEST Table
        /// </summary>
        private string _wgs;
        [DataField("WGS"
            , AliasName = "WGS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 500
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "WGS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string WGS
        {
            set { _wgs = value; }
            get { return _wgs; }
        }
        /// <summary>
        /// The COMMENT Field of GENETICTEST Table
        /// </summary>
        private string _comment;
        [DataField("COMMENT"
            , AliasName = "COMMENT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 1000
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COMMENT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
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
        /// The TIME_OF_UPDATE Field of GENETICTEST Table
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
            , SelectSequence = 24
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
        /// The NAME_OF_UPDATE Field of GENETICTEST Table
        /// </summary>
        private string _name_of_update;
        [DataField("NAME_OF_UPDATE"
            , AliasName = "NAME_OF_UPDATE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "NAME_OF_UPDATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string NAME_OF_UPDATE
        {
            set { _name_of_update = value; }
            get { return _name_of_update; }
        }

        /// <summary>
        /// The GENETIC_TYPE_UPDATA Field of GENETICTEST Table
        /// </summary>
        private string _genetic_type_updata;
        [DataField("GENETIC_TYPE_UPDATA"
            , AliasName = "GENETIC_TYPE_UPDATA"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "GENETIC_TYPE_UPDATA"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string GENETIC_TYPE_UPDATA
        {
            set { _genetic_type_updata = value; }
            get { return _genetic_type_updata; }
        }
        /// <summary>
        /// The PATHOLOGY Field of GENETICTEST Table
        /// </summary>
        private string _pathology;
        [DataField("PATHOLOGY"
            , AliasName = "PATHOLOGY"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PATHOLOGY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PATHOLOGY
        {
            set { _pathology = value; }
            get { return _pathology; }
        }
        /// <summary>
        /// The PATHOLOG_UPDATA Field of GENETICTEST Table
        /// </summary>
        private string _patholog_updata;
        [DataField("PATHOLOG_UPDATA"
            , AliasName = "PATHOLOG_UPDATA"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PATHOLOG_UPDATA"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PATHOLOG_UPDATA
        {
            set { _patholog_updata = value; }
            get { return _patholog_updata; }
        }
        /// <summary>
        /// The COMMENT_ALL Field of GENETICTEST Table
        /// </summary>
        private string _comment_all;
        [DataField("COMMENT_ALL"
            , AliasName = "COMMENT_ALL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COMMENT_ALL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 39
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COMMENT_ALL
        {
            set { _comment_all = value; }
            get { return _comment_all; }
        }
        /// <summary>
        /// GENETICTEST Table 
        /// </summary>
        public const string TABLE_NAME = "GENETICTEST";
        public const String GENETICTEST_ID_FIELD = "GENETICTEST_ID";
        public const String SQ_NUMBER_FIELD = "SQ_NUMBER";
        public const String MODEL_ID_FIELD = "MODEL_ID";
        public const String SOURCE_FIELD = "SOURCE";
        public const String RNASEQ_FIELD = "RNASEQ";
        public const String WES_FIELD = "WES";
        public const String WGS_FIELD = "WGS";
        public const String COMMENT_FIELD = "COMMENT";
        public const String TIME_OF_UPDATE_FIELD = "TIME_OF_UPDATE";
        public const String NAME_OF_UPDATE_FIELD = "NAME_OF_UPDATE";
        public const String GENETIC_TYPE_UPDATA_FIELD = "GENETIC_TYPE_UPDATA";
        public const String PATHOLOGY_FIELD = "PATHOLOGY";
        public const String PATHOLOG_UPDATA_FIELD = "PATHOLOG_UPDATA";
        public const String COMMENT_ALL_FIELD = "COMMENT_ALL";
    }
}