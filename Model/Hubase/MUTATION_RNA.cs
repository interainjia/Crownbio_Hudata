using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for MUTATION_RNA Table
    /// </summary>
    [Serializable]
    [DataTable("MUTATION_RNA", ResourceKey = "MUTATION_RNA")]
    public class MUTATION_RNA : BaseObject
    {
        public MUTATION_RNA()
        {
        }
        public MUTATION_RNA(DealModel initModel)
            : base(initModel)
        {
        }
        public static MUTATION_RNA Convert(BaseObject from)
        {
            return (MUTATION_RNA)from;
        }
        /// <summary>
        /// The MUTATION_RNA_ID Field of MUTATION_RNA Table
        /// </summary>
        private decimal _mutation_rna_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.MUTATION_RNA_ID = value;
            }
            get { return MUTATION_RNA_ID; }
        }

        [RecordIDField("MUTATION_RNA_ID"
            , AliasName = "MUTATION_RNA_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "MUTATION_RNA_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal MUTATION_RNA_ID
        {
            set { _mutation_rna_id = value; }
            get { return _mutation_rna_id; }
        }
        /// <summary>
        /// The CELLLINE Field of MUTATION_RNA Table
        /// </summary>
        private string _cellline;
        [DataField("CELLLINE"
            , AliasName = "CELLLINE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CELLLINE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CELLLINE
        {
            set { _cellline = value; }
            get { return _cellline; }
        }
        /// <summary>
        /// The GENE Field of MUTATION_RNA Table
        /// </summary>
        private string _gene;
        [DataField("GENE"
            , AliasName = "GENE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "GENE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string GENE
        {
            set { _gene = value; }
            get { return _gene; }
        }
        /// <summary>
        /// The MRNA_POS Field of MUTATION_RNA Table
        /// </summary>
        private string _mrna_pos;
        [DataField("MRNA_POS"
            , AliasName = "MRNA_POS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MRNA_POS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MRNA_POS
        {
            set { _mrna_pos = value; }
            get { return _mrna_pos; }
        }
        /// <summary>
        /// The DBSNP_ID Field of MUTATION_RNA Table
        /// </summary>
        private string _dbsnp_id;
        [DataField("DBSNP_ID"
            , AliasName = "DBSNP_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DBSNP_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DBSNP_ID
        {
            set { _dbsnp_id = value; }
            get { return _dbsnp_id; }
        }
        /// <summary>
        /// The CDS_POS Field of MUTATION_RNA Table
        /// </summary>
        private string _cds_pos;
        [DataField("CDS_POS"
            , AliasName = "CDS_POS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CDS_POS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CDS_POS
        {
            set { _cds_pos = value; }
            get { return _cds_pos; }
        }
        /// <summary>
        /// The REF Field of MUTATION_RNA Table
        /// </summary>
        private string _ref;
        [DataField("REF"
            , AliasName = "REF"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REF"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REF
        {
            set { _ref = value; }
            get { return _ref; }
        }
        /// <summary>
        /// The ALT Field of MUTATION_RNA Table
        /// </summary>
        private string _alt;
        [DataField("ALT"
            , AliasName = "ALT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ALT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ALT
        {
            set { _alt = value; }
            get { return _alt; }
        }
        /// <summary>
        /// The DEPTH Field of MUTATION_RNA Table
        /// </summary>
        private string _depth;
        [DataField("DEPTH"
            , AliasName = "DEPTH"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DEPTH"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DEPTH
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// The AMINO_ACID_CHANGE Field of MUTATION_RNA Table
        /// </summary>
        private string _amino_acid_change;
        [DataField("AMINO_ACID_CHANGE"
            , AliasName = "AMINO_ACID_CHANGE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "AMINO_ACID_CHANGE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string AMINO_ACID_CHANGE
        {
            set { _amino_acid_change = value; }
            get { return _amino_acid_change; }
        }
        /// <summary>
        /// The CONFIDENCE Field of MUTATION_RNA Table
        /// </summary>
        private string _confidence;
        [DataField("CONFIDENCE"
            , AliasName = "CONFIDENCE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CONFIDENCE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CONFIDENCE
        {
            set { _confidence = value; }
            get { return _confidence; }
        }
        /// <summary>
        /// The MUTATIONTYPE Field of MUTATION_RNA Table
        /// </summary>
        private string _mutationtype;
        [DataField("MUTATIONTYPE"
            , AliasName = "MUTATIONTYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MUTATIONTYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MUTATIONTYPE
        {
            set { _mutationtype = value; }
            get { return _mutationtype; }
        }
        /// <summary>
        /// MUTATION_RNA Table 
        /// </summary>
        public const string TABLE_NAME = "MUTATION_RNA";
        public const String MUTATION_RNA_ID_FIELD = "MUTATION_RNA_ID";
        public const String CELLLINE_FIELD = "CELLLINE";
        public const String GENE_FIELD = "GENE";
        public const String MRNA_POS_FIELD = "MRNA_POS";
        public const String DBSNP_ID_FIELD = "DBSNP_ID";
        public const String CDS_POS_FIELD = "CDS_POS";
        public const String REF_FIELD = "REF";
        public const String ALT_FIELD = "ALT";
        public const String DEPTH_FIELD = "DEPTH";
        public const String AMINO_ACID_CHANGE_FIELD = "AMINO_ACID_CHANGE";
        public const String CONFIDENCE_FIELD = "CONFIDENCE";
        public const String MUTATIONTYPE_FIELD = "MUTATIONTYPE";
    }
}