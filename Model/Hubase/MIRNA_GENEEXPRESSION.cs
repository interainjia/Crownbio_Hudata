using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for MIRNA_GENEEXPRESSION Table
    /// </summary>
    [Serializable]
    [DataTable("MIRNA_GENEEXPRESSION", ResourceKey = "MIRNA_GENEEXPRESSION")]
    public class MIRNA_GENEEXPRESSION : BaseObject
    {
        public MIRNA_GENEEXPRESSION()
        {
        }
        public MIRNA_GENEEXPRESSION(DealModel initModel)
            : base(initModel)
        {
        }
        public static MIRNA_GENEEXPRESSION Convert(BaseObject from)
        {
            return (MIRNA_GENEEXPRESSION)from;
        }
        /// <summary>
        /// The MIRNA_GENEEXPRESSION_ID Field of MIRNA_GENEEXPRESSION Table
        /// </summary>
        private decimal _mirna_geneexpression_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.MIRNA_GENEEXPRESSION_ID = value;
            }
            get { return MIRNA_GENEEXPRESSION_ID; }
        }

        [RecordIDField("MIRNA_GENEEXPRESSION_ID"
            , AliasName = "MIRNA_GENEEXPRESSION_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "MIRNA_GENEEXPRESSION_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal MIRNA_GENEEXPRESSION_ID
        {
            set { _mirna_geneexpression_id = value; }
            get { return _mirna_geneexpression_id; }
        }
        /// <summary>
        /// The GENE Field of MIRNA_GENEEXPRESSION Table
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
            , SelectSequence = 3
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
        /// The PROBESET Field of MIRNA_GENEEXPRESSION Table
        /// </summary>
        private string _probeset;
        [DataField("PROBESET"
            , AliasName = "PROBESET"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROBESET"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PROBESET
        {
            set { _probeset = value; }
            get { return _probeset; }
        }
        /// <summary>
        /// The PDXMODEL Field of MIRNA_GENEEXPRESSION Table
        /// </summary>
        private string _pdxmodel;
        [DataField("PDXMODEL"
            , AliasName = "PDXMODEL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PDXMODEL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PDXMODEL
        {
            set { _pdxmodel = value; }
            get { return _pdxmodel; }
        }
        /// <summary>
        /// The VALUE Field of MIRNA_GENEEXPRESSION Table
        /// </summary>
        private double _value;
        [DataField("VALUE"
            , AliasName = "VALUE"
            , DataType = DbType.Double
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "VALUE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public double VALUE
        {
            set { _value = value; }
            get { return _value; }
        }
        /// <summary>
        /// MIRNA_GENEEXPRESSION Table 
        /// </summary>
        public const string TABLE_NAME = "MIRNA_GENEEXPRESSION";
        public const String MIRNA_GENEEXPRESSION_ID_FIELD = "MIRNA_GENEEXPRESSION_ID";
        public const String GENE_FIELD = "GENE";
        public const String PROBESET_FIELD = "PROBESET";
        public const String PDXMODEL_FIELD = "PDXMODEL";
        public const String VALUE_FIELD = "VALUE";
    }
}