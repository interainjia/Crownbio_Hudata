using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for SPONSOR_AX_CODE Table
    /// </summary>
    [Serializable]
    [DataTable("SPONSOR_AX_CODE", ResourceKey = "SPONSOR_AX_CODE")]
    public class SPONSOR_AX_CODE : BaseObject
    {
        public SPONSOR_AX_CODE()
        {
        }
        public SPONSOR_AX_CODE(DealModel initModel)
            : base(initModel)
        {
        }
        public static SPONSOR_AX_CODE Convert(BaseObject from)
        {
            return (SPONSOR_AX_CODE)from;
        }
        /// <summary>
        /// The SPONSOR_AX_CODE_ID Field of SPONSOR_AX_CODE Table
        /// </summary>
        private decimal _sponsor_ax_code_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.SPONSOR_AX_CODE_ID = value;
            }
            get { return SPONSOR_AX_CODE_ID; }
        }

        [RecordIDField("SPONSOR_AX_CODE_ID"
            , AliasName = "SPONSOR_AX_CODE_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "SPONSOR_AX_CODE_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal SPONSOR_AX_CODE_ID
        {
            set { _sponsor_ax_code_id = value; }
            get { return _sponsor_ax_code_id; }
        }
        /// <summary>
        /// The SPONSOR Field of SPONSOR_AX_CODE Table
        /// </summary>
        private string _sponsor;
        [DataField("SPONSOR"
            , AliasName = "SPONSOR"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SPONSOR"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SPONSOR
        {
            set { _sponsor = value; }
            get { return _sponsor; }
        }
        /// <summary>
        /// The AX_CODE Field of SPONSOR_AX_CODE Table
        /// </summary>
        private string _ax_code;
        [DataField("AX_CODE"
            , AliasName = "AX_CODE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "AX_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string AX_CODE
        {
            set { _ax_code = value; }
            get { return _ax_code; }
        }
        /// <summary>
        /// SPONSOR_AX_CODE Table 
        /// </summary>
        public const string TABLE_NAME = "SPONSOR_AX_CODE";
        public const String SPONSOR_AX_CODE_ID_FIELD = "SPONSOR_AX_CODE_ID";
        public const String SPONSOR_FIELD = "SPONSOR";
        public const String AX_CODE_FIELD = "AX_CODE";
    }
}