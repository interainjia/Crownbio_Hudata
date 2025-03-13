using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for GENE_TWO Table
    /// </summary>
    [Serializable]
    [DataTable("GENE_TWO", ResourceKey = "GENE_TWO")]
    public class GENE_TWO : BaseObject
    {
        public GENE_TWO()
        {
        }
        public GENE_TWO(DealModel initModel)
            : base(initModel)
        {
        }
        public static GENE_TWO Convert(BaseObject from)
        {
            return (GENE_TWO)from;
        }
        /// <summary>
        /// The GENE_TWO_ID Field of GENE_TWO Table
        /// </summary>
        private decimal _gene_two_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.GENE_TWO_ID = value;
            }
            get { return GENE_TWO_ID; }
        }

        [RecordIDField("GENE_TWO_ID"
            , AliasName = "GENE_TWO_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "GENE_TWO_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal GENE_TWO_ID
        {
            set { _gene_two_id = value; }
            get { return _gene_two_id; }
        }
        /// <summary>
        /// The PROBESET Field of GENE_TWO Table
        /// </summary>
        private string _probeset;
        [DataField("PROBESET"
            , AliasName = "PROBESET"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 25
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROBESET"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
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
        /// The GENE Field of GENE_TWO Table
        /// </summary>
        private string _gene;
        [DataField("GENE"
            , AliasName = "GENE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 25
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
        /// The DESCRIPTION Field of GENE_TWO Table
        /// </summary>
        private string _description;
        [DataField("DESCRIPTION"
            , AliasName = "DESCRIPTION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 250
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DESCRIPTION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// GENE_TWO Table 
        /// </summary>
        public const string TABLE_NAME = "GENE_TWO";
        public const String GENE_TWO_ID_FIELD = "GENE_TWO_ID";
        public const String PROBESET_FIELD = "PROBESET";
        public const String GENE_FIELD = "GENE";
        public const String DESCRIPTION_FIELD = "DESCRIPTION";
    }
}