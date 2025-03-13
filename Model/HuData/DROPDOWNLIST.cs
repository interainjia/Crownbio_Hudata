using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for DROPDOWNLIST Table
    /// </summary>
    [Serializable]
    [DataTable("DROPDOWNLIST", ResourceKey = "DROPDOWNLIST")]
    public class DROPDOWNLIST : BaseObject
    {
        public DROPDOWNLIST()
        {
        }
        public DROPDOWNLIST(DealModel initModel)
            : base(initModel)
        {
        }
        public static DROPDOWNLIST Convert(BaseObject from)
        {
            return (DROPDOWNLIST)from;
        }
        /// <summary>
        /// The DROPDOWNLIST_ID Field of DROPDOWNLIST Table
        /// </summary>
        private decimal _dropdownlist_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.DROPDOWNLIST_ID = value;
            }
            get { return DROPDOWNLIST_ID; }
        }

        [RecordIDField("DROPDOWNLIST_ID"
            , AliasName = "DROPDOWNLIST_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "DROPDOWNLIST_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal DROPDOWNLIST_ID
        {
            set { _dropdownlist_id = value; }
            get { return _dropdownlist_id; }
        }
        /// <summary>
        /// The DROPDOWNLIST_NAME Field of DROPDOWNLIST Table
        /// </summary>
        private string _dropdownlist_name;
        [DataField("DROPDOWNLIST_NAME"
            , AliasName = "DROPDOWNLIST_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DROPDOWNLIST_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DROPDOWNLIST_NAME
        {
            set { _dropdownlist_name = value; }
            get { return _dropdownlist_name; }
        }
        /// <summary>
        /// The DROPDOWNLIST_CONTEXT Field of DROPDOWNLIST Table
        /// </summary>
        private string _dropdownlist_context;
        [DataField("DROPDOWNLIST_CONTEXT"
            , AliasName = "DROPDOWNLIST_CONTEXT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DROPDOWNLIST_CONTEXT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DROPDOWNLIST_CONTEXT
        {
            set { _dropdownlist_context = value; }
            get { return _dropdownlist_context; }
        }
        /// <summary>
        /// DROPDOWNLIST Table 
        /// </summary>
        public const string TABLE_NAME = "DROPDOWNLIST";
        public const String DROPDOWNLIST_ID_FIELD = "DROPDOWNLIST_ID";
        public const String DROPDOWNLIST_NAME_FIELD = "DROPDOWNLIST_NAME";
        public const String DROPDOWNLIST_CONTEXT_FIELD = "DROPDOWNLIST_CONTEXT";
    }
}