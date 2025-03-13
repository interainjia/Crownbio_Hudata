using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for GENEEXPRESSIONRNA_AFFYMETRIX Table
    /// </summary>
    [Serializable]
    [DataTable("GENEEXPRESSIONRNA_AFFYMETRIX", ResourceKey = "GENEEXPRESSIONRNA_AFFYMETRIX")]
    public class GENEEXPRESSIONRNA_AFFYMETRIX : BaseObject
    {
        public GENEEXPRESSIONRNA_AFFYMETRIX()
        {
        }
        public GENEEXPRESSIONRNA_AFFYMETRIX(DealModel initModel)
            : base(initModel)
        {
        }
        public static GENEEXPRESSIONRNA_AFFYMETRIX Convert(BaseObject from)
        {
            return (GENEEXPRESSIONRNA_AFFYMETRIX)from;
        }
        /// <summary>
        /// The GENEEXPRESSIONRNA_AFFYMETRIX_ID Field of GENEEXPRESSIONRNA_AFFYMETRIX Table
        /// </summary>
        private decimal _geneexpressionrna_affymetrix_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.GENEEXPRESSIONRNA_AFFYMETRIX_ID = value;
            }
            get { return GENEEXPRESSIONRNA_AFFYMETRIX_ID; }
        }

        [RecordIDField("GENEEXPRESSIONRNA_AFFYMETRIX_ID"
            , AliasName = "GENEEXPRESSIONRNA_AFFYMETRIX_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "GENEEXPRESSIONRNA_AFFYMETRIX_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal GENEEXPRESSIONRNA_AFFYMETRIX_ID
        {
            set { _geneexpressionrna_affymetrix_id = value; }
            get { return _geneexpressionrna_affymetrix_id; }
        }
        /// <summary>
        /// The TRANSCRIPT_ID Field of GENEEXPRESSIONRNA_AFFYMETRIX Table
        /// </summary>
        private string _transcript_id;
        [DataField("TRANSCRIPT_ID"
            , AliasName = "TRANSCRIPT_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TRANSCRIPT_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TRANSCRIPT_ID
        {
            set { _transcript_id = value; }
            get { return _transcript_id; }
        }
        /// <summary>
        /// The TRANSCRIPT_NAME Field of GENEEXPRESSIONRNA_AFFYMETRIX Table
        /// </summary>
        private string _transcript_name;
        [DataField("TRANSCRIPT_NAME"
            , AliasName = "TRANSCRIPT_NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TRANSCRIPT_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TRANSCRIPT_NAME
        {
            set { _transcript_name = value; }
            get { return _transcript_name; }
        }
        /// <summary>
        /// The GENE_NAME Field of GENEEXPRESSIONRNA_AFFYMETRIX Table
        /// </summary>
        private string _gene_name;
        [DataField("GENE_NAME"
            , AliasName = "GENE_NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "GENE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string GENE_NAME
        {
            set { _gene_name = value; }
            get { return _gene_name; }
        }
        /// <summary>
        /// The SAMPLE_NAME Field of GENEEXPRESSIONRNA_AFFYMETRIX Table
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
            , SelectSequence = 12
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
        /// The LOG_MU Field of GENEEXPRESSIONRNA_AFFYMETRIX Table
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
            , SelectSequence = 15
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
        /// The TRUE_LENGTH Field of GENEEXPRESSIONRNA_AFFYMETRIX Table
        /// </summary>
        private string _true_length;
        [DataField("TRUE_LENGTH"
            , AliasName = "TRUE_LENGTH"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TRUE_LENGTH"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TRUE_LENGTH
        {
            set { _true_length = value; }
            get { return _true_length; }
        }
        /// <summary>
        /// The UNIQ_HITS Field of GENEEXPRESSIONRNA_AFFYMETRIX Table
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
            , SelectSequence = 21
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
        /// The OBSERVED Field of GENEEXPRESSIONRNA_AFFYMETRIX Table
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
            , SelectSequence = 24
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
        /// GENEEXPRESSIONRNA_AFFYMETRIX Table 
        /// </summary>
        public const string TABLE_NAME = "GENEEXPRESSIONRNA_AFFYMETRIX";
        public const String GENEEXPRESSIONRNA_AFFYMETRIX_ID_FIELD = "GENEEXPRESSIONRNA_AFFYMETRIX_ID";
        public const String TRANSCRIPT_ID_FIELD = "TRANSCRIPT_ID";
        public const String TRANSCRIPT_NAME_FIELD = "TRANSCRIPT_NAME";
        public const String GENE_NAME_FIELD = "GENE_NAME";
        public const String SAMPLE_NAME_FIELD = "SAMPLE_NAME";
        public const String LOG_MU_FIELD = "LOG_MU";
        public const String TRUE_LENGTH_FIELD = "TRUE_LENGTH";
        public const String UNIQ_HITS_FIELD = "UNIQ_HITS";
        public const String OBSERVED_FIELD = "OBSERVED";
    }
}