using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for XENO_ONCOMAP Table
    /// </summary>
    [Serializable]
    [DataTable("XENO_ONCOMAP", ResourceKey = "XENO_ONCOMAP")]
    public class XENO_ONCOMAP : BaseObject
    {
        public XENO_ONCOMAP()
        {
        }
        public XENO_ONCOMAP(DealModel initModel)
            : base(initModel)
        {
        }
        public static XENO_ONCOMAP Convert(BaseObject from)
        {
            return (XENO_ONCOMAP)from;
        }
        /// <summary>
        /// The XENO_ONCOMAP_ID Field of XENO_ONCOMAP Table
        /// </summary>
        private decimal _xeno_oncomap_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.XENO_ONCOMAP_ID = value;
            }
            get { return XENO_ONCOMAP_ID; }
        }

        [RecordIDField("XENO_ONCOMAP_ID"
            , AliasName = "XENO_ONCOMAP_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "XENO_ONCOMAP_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal XENO_ONCOMAP_ID
        {
            set { _xeno_oncomap_id = value; }
            get { return _xeno_oncomap_id; }
        }
        /// <summary>
        /// The HUGO_SYMBOL Field of XENO_ONCOMAP Table
        /// </summary>
        private string _hugo_symbol;
        [DataField("HUGO_SYMBOL"
            , AliasName = "HUGO_SYMBOL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "HUGO_SYMBOL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string HUGO_SYMBOL
        {
            set { _hugo_symbol = value; }
            get { return _hugo_symbol; }
        }
        /// <summary>
        /// The CDNA_CHANGE Field of XENO_ONCOMAP Table
        /// </summary>
        private string _cdna_change;
        [DataField("CDNA_CHANGE"
            , AliasName = "CDNA_CHANGE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CDNA_CHANGE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CDNA_CHANGE
        {
            set { _cdna_change = value; }
            get { return _cdna_change; }
        }
        /// <summary>
        /// The PROTEIN_CHANGE Field of XENO_ONCOMAP Table
        /// </summary>
        private string _protein_change;
        [DataField("PROTEIN_CHANGE"
            , AliasName = "PROTEIN_CHANGE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROTEIN_CHANGE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PROTEIN_CHANGE
        {
            set { _protein_change = value; }
            get { return _protein_change; }
        }
        /// <summary>
        /// XENO_ONCOMAP Table 
        /// </summary>
        public const string TABLE_NAME = "XENO_ONCOMAP";
        public const String XENO_ONCOMAP_ID_FIELD = "XENO_ONCOMAP_ID";
        public const String HUGO_SYMBOL_FIELD = "HUGO_SYMBOL";
        public const String CDNA_CHANGE_FIELD = "CDNA_CHANGE";
        public const String PROTEIN_CHANGE_FIELD = "PROTEIN_CHANGE";
    }
}