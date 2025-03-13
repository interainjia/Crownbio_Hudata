using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for TUMORMODEL Table
    /// </summary>
    [Serializable]
    [DataTable("TUMORMODEL", ResourceKey = "TUMORMODEL")]
    public class TUMORMODEL : BaseObject
    {
        public TUMORMODEL()
        {
        }
        public TUMORMODEL(DealModel initModel)
            : base(initModel)
        {
        }
        public static TUMORMODEL Convert(BaseObject from)
        {
            return (TUMORMODEL)from;
        }
        /// <summary>
        /// The TUMORMODEL_ID Field of TUMORMODEL Table
        /// </summary>
        private decimal _tumormodel_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.TUMORMODEL_ID = value;
            }
            get { return TUMORMODEL_ID; }
        }

        [RecordIDField("TUMORMODEL_ID"
            , AliasName = "TUMORMODEL_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "TUMORMODEL_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal TUMORMODEL_ID
        {
            set { _tumormodel_id = value; }
            get { return _tumormodel_id; }
        }
        /// <summary>
        /// The MODELID Field of TUMORMODEL Table
        /// </summary>
        private string _modelid;
        [DataField("MODELID"
            , AliasName = "MODELID"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 25
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODELID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODELID
        {
            set { _modelid = value; }
            get { return _modelid; }
        }
        /// <summary>
        /// TUMORMODEL Table 
        /// </summary>
        public const string TABLE_NAME = "TUMORMODEL";
        public const String TUMORMODEL_ID_FIELD = "TUMORMODEL_ID";
        public const String MODELID_FIELD = "MODELID";
    }
}