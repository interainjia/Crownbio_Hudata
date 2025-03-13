using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for PIGGYBACKED Table
    /// </summary>
    [Serializable]
    [DataTable("PIGGYBACKED", ResourceKey = "PIGGYBACKED")]
    public class PIGGYBACKED : BaseObject
    {
        public PIGGYBACKED()
        {
        }
        public PIGGYBACKED(DealModel initModel)
            : base(initModel)
        {
        }
        public static PIGGYBACKED Convert(BaseObject from)
        {
            return (PIGGYBACKED)from;
        }
        /// <summary>
        /// The PIGGYBACKED_ID Field of PIGGYBACKED Table
        /// </summary>
        private decimal _piggybacked_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.PIGGYBACKED_ID = value;
            }
            get { return PIGGYBACKED_ID; }
        }

        [RecordIDField("PIGGYBACKED_ID"
            , AliasName = "PIGGYBACKED_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PIGGYBACKED_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal PIGGYBACKED_ID
        {
            set { _piggybacked_id = value; }
            get { return _piggybacked_id; }
        }
        /// <summary>
        /// The REQUEST_ID Field of PIGGYBACKED Table
        /// </summary>
        private decimal _request_id;
        [DataField("REQUEST_ID"
            , AliasName = "REQUEST_ID"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 18
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REQUEST_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal REQUEST_ID
        {
            set { _request_id = value; }
            get { return _request_id; }
        }
        /// <summary>
        /// The MODEL_ID Field of PIGGYBACKED Table
        /// </summary>
        private string _model_id;
        [DataField("MODEL_ID"
            , AliasName = "MODEL_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODEL_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODEL_ID
        {
            set { _model_id = value; }
            get { return _model_id; }
        }
        /// <summary>
        /// The PIGGYBACKED_BY Field of PIGGYBACKED Table
        /// </summary>
        private string _piggybacked_by;
        [DataField("PIGGYBACKED_BY"
            , AliasName = "PIGGYBACKED_BY"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PIGGYBACKED_BY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PIGGYBACKED_BY
        {
            set { _piggybacked_by = value; }
            get { return _piggybacked_by; }
        }
        /// <summary>
        /// PIGGYBACKED Table 
        /// </summary>
        public const string TABLE_NAME = "PIGGYBACKED";
        public const String PIGGYBACKED_ID_FIELD = "PIGGYBACKED_ID";
        public const String REQUEST_ID_FIELD = "REQUEST_ID";
        public const String MODEL_ID_FIELD = "MODEL_ID";
        public const String PIGGYBACKED_BY_FIELD = "PIGGYBACKED_BY";
    }
}