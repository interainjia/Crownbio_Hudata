using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for HUBASE_FUNCTION Table
    /// </summary>
    [Serializable]
    [DataTable("HUBASE_FUNCTION", ResourceKey = "HUBASE_FUNCTION")]
    public class HUBASE_FUNCTION : BaseObject
    {
        public HUBASE_FUNCTION()
        {
        }
        public HUBASE_FUNCTION(DealModel initModel)
            : base(initModel)
        {
        }
        public static HUBASE_FUNCTION Convert(BaseObject from)
        {
            return (HUBASE_FUNCTION)from;
        }
        /// <summary>
        /// The HUBASE_FUNCTION_ID Field of HUBASE_FUNCTION Table
        /// </summary>
        private decimal _hubase_function_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.HUBASE_FUNCTION_ID = value;
            }
            get { return HUBASE_FUNCTION_ID; }
        }

        [RecordIDField("HUBASE_FUNCTION_ID"
            , AliasName = "HUBASE_FUNCTION_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "HUBASE_FUNCTION_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal HUBASE_FUNCTION_ID
        {
            set { _hubase_function_id = value; }
            get { return _hubase_function_id; }
        }
        /// <summary>
        /// The FUNCTION_NAME Field of HUBASE_FUNCTION Table
        /// </summary>
        private string _function_name;
        [DataField("FUNCTION_NAME"
            , AliasName = "FUNCTION_NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FUNCTION_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FUNCTION_NAME
        {
            set { _function_name = value; }
            get { return _function_name; }
        }
        /// <summary>
        /// The OPERATE Field of HUBASE_FUNCTION Table
        /// </summary>
        private string _operate;
        [DataField("OPERATE"
            , AliasName = "OPERATE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "OPERATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string OPERATE
        {
            set { _operate = value; }
            get { return _operate; }
        }
        /// <summary>
        /// HUBASE_FUNCTION Table 
        /// </summary>
        public const string TABLE_NAME = "HUBASE_FUNCTION";
        public const String HUBASE_FUNCTION_ID_FIELD = "HUBASE_FUNCTION_ID";
        public const String FUNCTION_NAME_FIELD = "FUNCTION_NAME";
        public const String OPERATE_FIELD = "OPERATE";
    }
}