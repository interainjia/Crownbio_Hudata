using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for TUMORMODEL_MU Table
    /// </summary>
    [Serializable]
    [DataTable("TUMORMODEL_MU", ResourceKey = "TUMORMODEL_MU")]
    public class TUMORMODEL_MU : BaseObject
    {
        public TUMORMODEL_MU()
        {
        }
        public TUMORMODEL_MU(DealModel initModel)
            : base(initModel)
        {
        }
        public static TUMORMODEL_MU Convert(BaseObject from)
        {
            return (TUMORMODEL_MU)from;
        }
        /// <summary>
        /// The TUMORMODEL_MU_ID Field of TUMORMODEL_MU Table
        /// </summary>
        private decimal _tumormodel_mu_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.TUMORMODEL_MU_ID = value;
            }
            get { return TUMORMODEL_MU_ID; }
        }

        [RecordIDField("TUMORMODEL_MU_ID"
            , AliasName = "TUMORMODEL_MU_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "TUMORMODEL_MU_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal TUMORMODEL_MU_ID
        {
            set { _tumormodel_mu_id = value; }
            get { return _tumormodel_mu_id; }
        }
        /// <summary>
        /// The CELLLINE Field of TUMORMODEL_MU Table
        /// </summary>
        private string _cellline;
        [DataField("CELLLINE"
            , AliasName = "CELLLINE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 25
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
        /// TUMORMODEL_MU Table 
        /// </summary>
        public const string TABLE_NAME = "TUMORMODEL_MU";
        public const String TUMORMODEL_MU_ID_FIELD = "TUMORMODEL_MU_ID";
        public const String CELLLINE_FIELD = "CELLLINE";
    }
}