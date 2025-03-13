using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for TABLEDISPLAYCOLUMNS Table
    /// </summary>
    [Serializable]
    [DataTable("TABLEDISPLAYCOLUMNS", ResourceKey = "TABLEDISPLAYCOLUMNS")]
    public class TABLEDISPLAYCOLUMNS : BaseObject
    {
        public TABLEDISPLAYCOLUMNS()
        {
        }
        public TABLEDISPLAYCOLUMNS(DealModel initModel)
            : base(initModel)
        {
        }
        public static TABLEDISPLAYCOLUMNS Convert(BaseObject from)
        {
            return (TABLEDISPLAYCOLUMNS)from;
        }
        /// <summary>
        /// The TABLEDISPLAYCOLUMNS_ID Field of TABLEDISPLAYCOLUMNS Table
        /// </summary>
        private decimal _tabledisplaycolumns_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.TABLEDISPLAYCOLUMNS_ID = value;
            }
            get { return TABLEDISPLAYCOLUMNS_ID; }
        }

        [RecordIDField("TABLEDISPLAYCOLUMNS_ID"
            , AliasName = "TABLEDISPLAYCOLUMNS_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "TABLEDISPLAYCOLUMNS_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal TABLEDISPLAYCOLUMNS_ID
        {
            set { _tabledisplaycolumns_id = value; }
            get { return _tabledisplaycolumns_id; }
        }
        /// <summary>
        /// The TABLENAME Field of TABLEDISPLAYCOLUMNS Table
        /// </summary>
        private string _tablename;
        [DataField("TABLENAME"
            , AliasName = "TABLENAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TABLENAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TABLENAME
        {
            set { _tablename = value; }
            get { return _tablename; }
        }
        /// <summary>
        /// The TABLECOLUMNS Field of TABLEDISPLAYCOLUMNS Table
        /// </summary>
        private string _tablecolumns;
        [DataField("TABLECOLUMNS"
            , AliasName = "TABLECOLUMNS"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 500
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TABLECOLUMNS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TABLECOLUMNS
        {
            set { _tablecolumns = value; }
            get { return _tablecolumns; }
        }
        /// <summary>
        /// TABLEDISPLAYCOLUMNS Table 
        /// </summary>
        public const string TABLE_NAME = "TABLEDISPLAYCOLUMNS";
        public const String TABLEDISPLAYCOLUMNS_ID_FIELD = "TABLEDISPLAYCOLUMNS_ID";
        public const String TABLENAME_FIELD = "TABLENAME";
        public const String TABLECOLUMNS_FIELD = "TABLECOLUMNS";
    }
}