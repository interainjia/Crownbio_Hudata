using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for RESPOND_MODELS Table
    /// </summary>
    [Serializable]
    [DataTable("RESPOND_MODELS", ResourceKey = "RESPOND_MODELS")]
    public class RESPOND_MODELS : BaseObject
    {
        public RESPOND_MODELS()
        {
        }
        public RESPOND_MODELS(DealModel initModel)
            : base(initModel)
        {
        }
        public static RESPOND_MODELS Convert(BaseObject from)
        {
            return (RESPOND_MODELS)from;
        }
        /// <summary>
        /// The RESPOND_MODELS_ID Field of RESPOND_MODELS Table
        /// </summary>
        private decimal _respond_models_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.RESPOND_MODELS_ID = value;
            }
            get { return RESPOND_MODELS_ID; }
        }
        public override decimal PID
        {
            set
            {
                base.PID = value;
                this.REQUEST_ID = value;
            }
            get { return REQUEST_ID; }
        }
        [RecordIDField("RESPOND_MODELS_ID"
            , AliasName = "RESPOND_MODELS_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "RESPOND_MODELS_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal RESPOND_MODELS_ID
        {
            set { _respond_models_id = value; }
            get { return _respond_models_id; }
        }
        /// <summary>
        /// The REQUEST_ID Field of RESPOND_MODELS Table
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
        /// The PDXMODEL_INFO_ID Field of RESPOND_MODELS Table
        /// </summary>
        private string _pdxmodel_info_id;
        [DataField("PDXMODEL_INFO_ID"
            , AliasName = "PDXMODEL_INFO_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 18
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PDXMODEL_INFO_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 4
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PDXMODEL_INFO_ID
        {
            set { _pdxmodel_info_id = value; }
            get { return _pdxmodel_info_id; }
        }
      
        /// <summary>
        /// The MODEL_ID Field of RESPOND_MODELS Table
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
        private string _rn;
        [DataField("RN"
            , AliasName = "RN"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "RN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string RN
        {
            set { _rn = value; }
            get { return _rn; }
        }
        private string _pn;
        [DataField("PN"
            , AliasName = "PN"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PN
        {
            set { _pn = value; }
            get { return _pn; }
        }
        private string _dot;
        [DataField("DOT"
            , AliasName = "DOT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DOT
        {
            set { _dot = value; }
            get { return _dot; }
        }
        /// <summary>
        /// RESPOND_MODELS Table 
        /// </summary>
        public const string TABLE_NAME = "RESPOND_MODELS";
        public const String RESPOND_MODELS_ID_FIELD = "RESPOND_MODELS_ID";
        public const String REQUEST_ID_FIELD = "REQUEST_ID";
        public const String PDXMODEL_INFO_ID_FIELD = "PDXMODEL_INFO_ID";
        public const String MODEL_ID_FIELD = "MODEL_ID";
        public const String RN_FIELD = "RN";
        public const String PN_FIELD = "PN";
        public const String DOT_FIELD = "DOT";
        
    }
}