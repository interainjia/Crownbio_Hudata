using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for GENEEXPRESSIONRNA_CUSTOM Table
    /// </summary>
    [Serializable]
    [DataTable("GENEEXPRESSIONRNA_CUSTOM", ResourceKey = "GENEEXPRESSIONRNA_CUSTOM")]
    public class GENEEXPRESSIONRNA_CUSTOM : BaseObject
    {
        public GENEEXPRESSIONRNA_CUSTOM()
        {
        }
        public GENEEXPRESSIONRNA_CUSTOM(DealModel initModel)
            : base(initModel)
        {
        }
        public static GENEEXPRESSIONRNA_CUSTOM Convert(BaseObject from)
        {
            return (GENEEXPRESSIONRNA_CUSTOM)from;
        }
        /// <summary>
        /// The GENEEXPRESSIONRNA_CUSTOM_ID Field of GENEEXPRESSIONRNA_CUSTOM Table
        /// </summary>
        private decimal _geneexpressionrna_custom_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.GENEEXPRESSIONRNA_CUSTOM_ID = value;
            }
            get { return GENEEXPRESSIONRNA_CUSTOM_ID; }
        }

        [RecordIDField("GENEEXPRESSIONRNA_CUSTOM_ID"
            , AliasName = "GENEEXPRESSIONRNA_CUSTOM_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "GENEEXPRESSIONRNA_CUSTOM_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal GENEEXPRESSIONRNA_CUSTOM_ID
        {
            set { _geneexpressionrna_custom_id = value; }
            get { return _geneexpressionrna_custom_id; }
        }
        /// <summary>
        /// The FEATURE_ID Field of GENEEXPRESSIONRNA_CUSTOM Table
        /// </summary>
        private string _feature_id;
        [DataField("FEATURE_ID"
            , AliasName = "FEATURE_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FEATURE_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FEATURE_ID
        {
            set { _feature_id = value; }
            get { return _feature_id; }
        }
        /// <summary>
        /// The FEATURE_NAME Field of GENEEXPRESSIONRNA_CUSTOM Table
        /// </summary>
        private string _feature_name;
        [DataField("FEATURE_NAME"
            , AliasName = "FEATURE_NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FEATURE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FEATURE_NAME
        {
            set { _feature_name = value; }
            get { return _feature_name; }
        }
        /// <summary>
        /// The SAMPLE_NAME Field of GENEEXPRESSIONRNA_CUSTOM Table
        /// </summary>
        private string _sample_name;
        [DataField("SAMPLE_NAME"
            , AliasName = "SAMPLE_NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SAMPLE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SAMPLE_NAME
        {
            set { _sample_name = value; }
            get { return _sample_name; }
        }
        /// <summary>
        /// The LOG_MU Field of GENEEXPRESSIONRNA_CUSTOM Table
        /// </summary>
        private double _log_mu;
        [DataField("LOG_MU"
            , AliasName = "LOG_MU"
            , DataType = DbType.Double
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "LOG_MU"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public double LOG_MU
        {
            set { _log_mu = value; }
            get { return _log_mu; }
        }
        /// <summary>
        /// The UNIQ_HITS Field of GENEEXPRESSIONRNA_CUSTOM Table
        /// </summary>
        private string _uniq_hits;
        [DataField("UNIQ_HITS"
            , AliasName = "UNIQ_HITS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "UNIQ_HITS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string UNIQ_HITS
        {
            set { _uniq_hits = value; }
            get { return _uniq_hits; }
        }
        /// <summary>
        /// The NTRANSCRIPTS Field of GENEEXPRESSIONRNA_CUSTOM Table
        /// </summary>
        private string _ntranscripts;
        [DataField("NTRANSCRIPTS"
            , AliasName = "NTRANSCRIPTS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "NTRANSCRIPTS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string NTRANSCRIPTS
        {
            set { _ntranscripts = value; }
            get { return _ntranscripts; }
        }
        /// <summary>
        /// The OBSERVED Field of GENEEXPRESSIONRNA_CUSTOM Table
        /// </summary>
        private string _observed;
        [DataField("OBSERVED"
            , AliasName = "OBSERVED"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "OBSERVED"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string OBSERVED
        {
            set { _observed = value; }
            get { return _observed; }
        }
        /// <summary>
        /// GENEEXPRESSIONRNA_CUSTOM Table 
        /// </summary>
        public const string TABLE_NAME = "GENEEXPRESSIONRNA_CUSTOM";
        public const String GENEEXPRESSIONRNA_CUSTOM_ID_FIELD = "GENEEXPRESSIONRNA_CUSTOM_ID";
        public const String FEATURE_ID_FIELD = "FEATURE_ID";
        public const String FEATURE_NAME_FIELD = "FEATURE_NAME";
        public const String SAMPLE_NAME_FIELD = "SAMPLE_NAME";
        public const String LOG_MU_FIELD = "LOG_MU";
        public const String UNIQ_HITS_FIELD = "UNIQ_HITS";
        public const String NTRANSCRIPTS_FIELD = "NTRANSCRIPTS";
        public const String OBSERVED_FIELD = "OBSERVED";
    }
}