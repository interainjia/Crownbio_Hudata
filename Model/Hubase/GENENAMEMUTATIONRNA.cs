using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for GENENAME_MUTATIONRNA Table
    /// </summary>
    [Serializable]
    [DataTable("GENENAME_MUTATIONRNA", ResourceKey = "GENENAME_MUTATIONRNA")]
    public class GENENAME_MUTATIONRNA : BaseObject
    {
        public GENENAME_MUTATIONRNA()
        {
        }
        public GENENAME_MUTATIONRNA(DealModel initModel)
            : base(initModel)
        {
        }
        public static GENENAME_MUTATIONRNA Convert(BaseObject from)
        {
            return (GENENAME_MUTATIONRNA)from;
        }
        /// <summary>
        /// The GENENAME_MUTATIONRNA_ID Field of GENENAME_MUTATIONRNA Table
        /// </summary>
        private decimal _genename_mutationrna_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.GENENAME_MUTATIONRNA_ID = value;
            }
            get { return GENENAME_MUTATIONRNA_ID; }
        }

        [RecordIDField("GENENAME_MUTATIONRNA_ID"
            , AliasName = "GENENAME_MUTATIONRNA_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "GENENAME_MUTATIONRNA_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal GENENAME_MUTATIONRNA_ID
        {
            set { _genename_mutationrna_id = value; }
            get { return _genename_mutationrna_id; }
        }
        /// <summary>
        /// The GENENAME Field of GENENAME_MUTATIONRNA Table
        /// </summary>
        private string _genename;
        [DataField("GENENAME"
            , AliasName = "GENENAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "GENENAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string GENENAME
        {
            set { _genename = value; }
            get { return _genename; }
        }
        /// <summary>
        /// GENENAME_MUTATIONRNA Table 
        /// </summary>
        public const string TABLE_NAME = "GENENAME_MUTATIONRNA";
        public const String GENENAME_MUTATIONRNA_ID_FIELD = "GENENAME_MUTATIONRNA_ID";
        public const String GENENAME_FIELD = "GENENAME";
    }
}