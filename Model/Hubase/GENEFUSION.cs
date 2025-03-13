using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for GENEFUSION Table
    /// </summary>
    [Serializable]
    [DataTable("GENEFUSION", ResourceKey = "GENEFUSION")]
    public class GENEFUSION : BaseObject
    {
        public GENEFUSION()
        {
        }
        public GENEFUSION(DealModel initModel)
            : base(initModel)
        {
        }
        public static GENEFUSION Convert(BaseObject from)
        {
            return (GENEFUSION)from;
        }
        /// <summary>
        /// The GENEFUSION_ID Field of GENEFUSION Table
        /// </summary>
        private decimal _genefusion_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.GENEFUSION_ID = value;
            }
            get { return GENEFUSION_ID; }
        }

        [RecordIDField("GENEFUSION_ID"
            , AliasName = "GENEFUSION_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "GENEFUSION_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal GENEFUSION_ID
        {
            set { _genefusion_id = value; }
            get { return _genefusion_id; }
        }
        /// <summary>
        /// The SAMPLE_NAME Field of GENEFUSION Table
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
            , SelectSequence = 3
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
        /// The UP_GENE Field of GENEFUSION Table
        /// </summary>
        private string _up_gene;
        [DataField("UP_GENE"
            , AliasName = "UP_GENE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "UP_GENE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string UP_GENE
        {
            set { _up_gene = value; }
            get { return _up_gene; }
        }
        /// <summary>
        /// The UP_CHR Field of GENEFUSION Table
        /// </summary>
        private string _up_chr;
        [DataField("UP_CHR"
            , AliasName = "UP_CHR"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "UP_CHR"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string UP_CHR
        {
            set { _up_chr = value; }
            get { return _up_chr; }
        }
        /// <summary>
        /// The UP_STRAND Field of GENEFUSION Table
        /// </summary>
        private string _up_strand;
        [DataField("UP_STRAND"
            , AliasName = "UP_STRAND"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "UP_STRAND"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string UP_STRAND
        {
            set { _up_strand = value; }
            get { return _up_strand; }
        }
        /// <summary>
        /// The UP_GENOME_POS Field of GENEFUSION Table
        /// </summary>
        private string _up_genome_pos;
        [DataField("UP_GENOME_POS"
            , AliasName = "UP_GENOME_POS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "UP_GENOME_POS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string UP_GENOME_POS
        {
            set { _up_genome_pos = value; }
            get { return _up_genome_pos; }
        }
        /// <summary>
        /// The DW_GENE Field of GENEFUSION Table
        /// </summary>
        private string _dw_gene;
        [DataField("DW_GENE"
            , AliasName = "DW_GENE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DW_GENE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DW_GENE
        {
            set { _dw_gene = value; }
            get { return _dw_gene; }
        }
        /// <summary>
        /// The DW_CHR Field of GENEFUSION Table
        /// </summary>
        private string _dw_chr;
        [DataField("DW_CHR"
            , AliasName = "DW_CHR"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DW_CHR"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DW_CHR
        {
            set { _dw_chr = value; }
            get { return _dw_chr; }
        }
        /// <summary>
        /// The DW_STRAND Field of GENEFUSION Table
        /// </summary>
        private string _dw_strand;
        [DataField("DW_STRAND"
            , AliasName = "DW_STRAND"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DW_STRAND"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DW_STRAND
        {
            set { _dw_strand = value; }
            get { return _dw_strand; }
        }
        /// <summary>
        /// The DW_GENOME_POS Field of GENEFUSION Table
        /// </summary>
        private string _dw_genome_pos;
        [DataField("DW_GENOME_POS"
            , AliasName = "DW_GENOME_POS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DW_GENOME_POS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DW_GENOME_POS
        {
            set { _dw_genome_pos = value; }
            get { return _dw_genome_pos; }
        }
        /// <summary>
        /// The SPANNUMBYSOAPFUSE Field of GENEFUSION Table
        /// </summary>
        private string _spannumbysoapfuse;
        [DataField("SPANNUMBYSOAPFUSE"
            , AliasName = "SPANNUMBYSOAPFUSE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SPANNUMBYSOAPFUSE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SPANNUMBYSOAPFUSE
        {
            set { _spannumbysoapfuse = value; }
            get { return _spannumbysoapfuse; }
        }
        /// <summary>
        /// The JUNCNUMBYSOAPFUSE Field of GENEFUSION Table
        /// </summary>
        private string _juncnumbysoapfuse;
        [DataField("JUNCNUMBYSOAPFUSE"
            , AliasName = "JUNCNUMBYSOAPFUSE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "JUNCNUMBYSOAPFUSE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string JUNCNUMBYSOAPFUSE
        {
            set { _juncnumbysoapfuse = value; }
            get { return _juncnumbysoapfuse; }
        }
        /// <summary>
        /// The SPANNUMBYDEFUSE Field of GENEFUSION Table
        /// </summary>
        private string _spannumbydefuse;
        [DataField("SPANNUMBYDEFUSE"
            , AliasName = "SPANNUMBYDEFUSE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SPANNUMBYDEFUSE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SPANNUMBYDEFUSE
        {
            set { _spannumbydefuse = value; }
            get { return _spannumbydefuse; }
        }
        /// <summary>
        /// The JUNCNUMBYDEFUSE Field of GENEFUSION Table
        /// </summary>
        private string _juncnumbydefuse;
        [DataField("JUNCNUMBYDEFUSE"
            , AliasName = "JUNCNUMBYDEFUSE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "JUNCNUMBYDEFUSE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 39
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string JUNCNUMBYDEFUSE
        {
            set { _juncnumbydefuse = value; }
            get { return _juncnumbydefuse; }
        }
        /// <summary>
        /// The FORPCR Field of GENEFUSION Table
        /// </summary>
        private string _forpcr;
        [DataField("FORPCR"
            , AliasName = "FORPCR"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 500
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FORPCR"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 42
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FORPCR
        {
            set { _forpcr = value; }
            get { return _forpcr; }
        }
        /// <summary>
        /// The URL_LEFT Field of GENEFUSION Table
        /// </summary>
        private string _url_left;
        [DataField("URL_LEFT"
            , AliasName = "URL_LEFT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "URL_LEFT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 45
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string URL_LEFT
        {
            set { _url_left = value; }
            get { return _url_left; }
        }
        /// <summary>
        /// The URL_RIGHT Field of GENEFUSION Table
        /// </summary>
        private string _url_right;
        [DataField("URL_RIGHT"
            , AliasName = "URL_RIGHT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "URL_RIGHT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 48
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string URL_RIGHT
        {
            set { _url_right = value; }
            get { return _url_right; }
        }
        /// <summary>
        /// GENEFUSION Table 
        /// </summary>
        public const string TABLE_NAME = "GENEFUSION";
        public const String GENEFUSION_ID_FIELD = "GENEFUSION_ID";
        public const String SAMPLE_NAME_FIELD = "SAMPLE_NAME";
        public const String UP_GENE_FIELD = "UP_GENE";
        public const String UP_CHR_FIELD = "UP_CHR";
        public const String UP_STRAND_FIELD = "UP_STRAND";
        public const String UP_GENOME_POS_FIELD = "UP_GENOME_POS";
        public const String DW_GENE_FIELD = "DW_GENE";
        public const String DW_CHR_FIELD = "DW_CHR";
        public const String DW_STRAND_FIELD = "DW_STRAND";
        public const String DW_GENOME_POS_FIELD = "DW_GENOME_POS";
        public const String SPANNUMBYSOAPFUSE_FIELD = "SPANNUMBYSOAPFUSE";
        public const String JUNCNUMBYSOAPFUSE_FIELD = "JUNCNUMBYSOAPFUSE";
        public const String SPANNUMBYDEFUSE_FIELD = "SPANNUMBYDEFUSE";
        public const String JUNCNUMBYDEFUSE_FIELD = "JUNCNUMBYDEFUSE";
        public const String FORPCR_FIELD = "FORPCR";
        public const String URL_LEFT_FIELD = "URL_LEFT";
        public const String URL_RIGHT_FIELD = "URL_RIGHT";
    }
}