using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for GENEEXPRESSION_AFFYMETRIX Table
    /// </summary>
    [Serializable]
    [DataTable("GENEEXPRESSION_AFFYMETRIX", ResourceKey = "GENEEXPRESSION_AFFYMETRIX")]
    public class GENEEXPRESSION_AFFYMETRIX : BaseObject
    {
        public GENEEXPRESSION_AFFYMETRIX()
        {
        }
        public GENEEXPRESSION_AFFYMETRIX(DealModel initModel)
            : base(initModel)
        {
        }
        public static GENEEXPRESSION_AFFYMETRIX Convert(BaseObject from)
        {
            return (GENEEXPRESSION_AFFYMETRIX)from;
        }
        /// <summary>
        /// The GENEEXPRESSION_AFFYMETRIX_ID Field of GENEEXPRESSION_AFFYMETRIX Table
        /// </summary>
        private decimal _geneexpression_affymetrix_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.GENEEXPRESSION_AFFYMETRIX_ID = value;
            }
            get { return GENEEXPRESSION_AFFYMETRIX_ID; }
        }

        [RecordIDField("GENEEXPRESSION_AFFYMETRIX_ID"
            , AliasName = "GENEEXPRESSION_AFFYMETRIX_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "GENEEXPRESSION_AFFYMETRIX_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal GENEEXPRESSION_AFFYMETRIX_ID
        {
            set { _geneexpression_affymetrix_id = value; }
            get { return _geneexpression_affymetrix_id; }
        }
        /// <summary>
        /// The GENE Field of GENEEXPRESSION_AFFYMETRIX Table
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
        /// The PROBESET Field of GENEEXPRESSION_AFFYMETRIX Table
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
        /// The PDXMODEL Field of GENEEXPRESSION_AFFYMETRIX Table
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
        /// The VALUE Field of GENEEXPRESSION_AFFYMETRIX Table
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
        /// GENEEXPRESSION_AFFYMETRIX Table 
        /// </summary>
        public const string TABLE_NAME = "GENEEXPRESSION_AFFYMETRIX";
        public const String GENEEXPRESSION_AFFYMETRIX_ID_FIELD = "GENEEXPRESSION_AFFYMETRIX_ID";
        public const String GENE_FIELD = "GENE";
        public const String PROBESET_FIELD = "PROBESET";
        public const String PDXMODEL_FIELD = "PDXMODEL";
        public const String VALUE_FIELD = "VALUE";
    }
}