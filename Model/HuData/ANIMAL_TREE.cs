using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for ANIMAL_TREE Table
    /// </summary>
    [Serializable]
    [DataTable("ANIMAL_TREE", ResourceKey = "ANIMAL_TREE")]
    public class ANIMAL_TREE : BaseObject
    {
        public ANIMAL_TREE()
        {
        }
        public ANIMAL_TREE(DealModel initModel)
            : base(initModel)
        {
        }
        public static ANIMAL_TREE Convert(BaseObject from)
        {
            return (ANIMAL_TREE)from;
        }
        /// <summary>
        /// The ANIMAL_TREE_ID Field of ANIMAL_TREE Table
        /// </summary>
        private decimal _animal_tree_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.ANIMAL_TREE_ID = value;
            }
            get { return ANIMAL_TREE_ID; }
        }

        [RecordIDField("ANIMAL_TREE_ID"
            , AliasName = "ANIMAL_TREE_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "ANIMAL_TREE_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal ANIMAL_TREE_ID
        {
            set { _animal_tree_id = value; }
            get { return _animal_tree_id; }
        }
      
        /// <summary>
        /// The MODEL_ID Field of ANIMAL_TREE Table
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
        /// The STATUS Field of ANIMAL_TREE Table
        /// </summary>
        private string _status;
        [DataField("STATUS"
            , AliasName = "STATUS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "STATUS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string STATUS
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// The RN Field of ANIMAL_TREE Table
        /// </summary>
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
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string RN
        {
            set { _rn = value; }
            get { return _rn; }
        }
        /// <summary>
        /// The PN Field of ANIMAL_TREE Table
        /// </summary>
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
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PN
        {
            set { _pn = value; }
            get { return _pn; }
        }
        /// <summary>
        /// The DOI Field of ANIMAL_TREE Table
        /// </summary>
        private string _doi;
        [DataField("DOI"
            , AliasName = "DOI"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOI"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DOI
        {
            set { _doi = value; }
            get { return _doi; }
        }
        /// <summary>
        /// The LOCATION Field of ANIMAL_TREE Table
        /// </summary>
        private string _location;
        [DataField("LOCATION"
            , AliasName = "LOCATION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "LOCATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string LOCATION
        {
            set { _location = value; }
            get { return _location; }
        }
      
        /// <summary>
        /// The AID Field of ANIMAL_TREE Table
        /// </summary>
        private string _aid;
        [DataField("AID"
            , AliasName = "AID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "AID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string AID
        {
            set { _aid = value; }
            get { return _aid; }
        }
        /// <summary>
        /// The P_ID Field of ANIMAL_TREE Table
        /// </summary>
        private string _p_id;
        [DataField("P_ID"
            , AliasName = "P_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "P_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string P_ID
        {
            set { _p_id = value; }
            get { return _p_id; }
        }
        /// <summary>
        /// The DOT Field of ANIMAL_TREE Table
        /// </summary>
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
            , SelectSequence = 27
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
        /// ANIMAL_TREE Table 
        /// </summary>
        public const string TABLE_NAME = "ANIMAL_TREE";
        public const String ANIMAL_TREE_ID_FIELD = "ANIMAL_TREE_ID";

        public const String MODEL_ID_FIELD = "MODEL_ID";
        public const String STATUS_FIELD = "STATUS";
        public const String RN_FIELD = "RN";
        public const String PN_FIELD = "PN";
        public const String DOI_FIELD = "DOI";
        public const String LOCATION_FIELD = "LOCATION";
 
        public const String AID_FIELD = "AID";
        public const String P_ID_FIELD = "P_ID";
        public const String DOT_FIELD = "DOT";


    }
}