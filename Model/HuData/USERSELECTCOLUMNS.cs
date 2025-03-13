using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for USERSELECTCOLUMNS Table
    /// </summary>
    [Serializable]
    [DataTable("USERSELECTCOLUMNS", ResourceKey = "USERSELECTCOLUMNS")]
    public class USERSELECTCOLUMNS : BaseObject
    {
        public USERSELECTCOLUMNS()
        {
        }
        public USERSELECTCOLUMNS(DealModel initModel)
            : base(initModel)
        {
        }
        public static USERSELECTCOLUMNS Convert(BaseObject from)
        {
            return (USERSELECTCOLUMNS)from;
        }
        /// <summary>
        /// The USERSELECTCOLUMNS_ID Field of USERSELECTCOLUMNS Table
        /// </summary>
        private decimal _userselectcolumns_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.USERSELECTCOLUMNS_ID = value;
            }
            get { return USERSELECTCOLUMNS_ID; }
        }

        [RecordIDField("USERSELECTCOLUMNS_ID"
            , AliasName = "USERSELECTCOLUMNS_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "USERSELECTCOLUMNS_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal USERSELECTCOLUMNS_ID
        {
            set { _userselectcolumns_id = value; }
            get { return _userselectcolumns_id; }
        }
        /// <summary>
        /// The USER_ID Field of USERSELECTCOLUMNS Table
        /// </summary>
        private decimal _user_id;
        [DataField("USER_ID"
            , AliasName = "USER_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "USER_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// The SELECTTABLENAME Field of USERSELECTCOLUMNS Table
        /// </summary>
        private string _selecttablename;
        [DataField("SELECTTABLENAME"
            , AliasName = "SELECTTABLENAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SELECTTABLENAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SELECTTABLENAME
        {
            set { _selecttablename = value; }
            get { return _selecttablename; }
        }
        /// <summary>
        /// The DISPLAYCOLUMNS Field of USERSELECTCOLUMNS Table
        /// </summary>
        private string _displaycolumns;
        [DataField("DISPLAYCOLUMNS"
            , AliasName = "DISPLAYCOLUMNS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DISPLAYCOLUMNS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DISPLAYCOLUMNS
        {
            set { _displaycolumns = value; }
            get { return _displaycolumns; }
        }
        /// <summary>
        /// The HIDDENCOLUMNS Field of USERSELECTCOLUMNS Table
        /// </summary>
        private string _hiddencolumns;
        [DataField("HIDDENCOLUMNS"
            , AliasName = "HIDDENCOLUMNS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "HIDDENCOLUMNS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string HIDDENCOLUMNS
        {
            set { _hiddencolumns = value; }
            get { return _hiddencolumns; }
        }
        /// <summary>
        /// USERSELECTCOLUMNS Table 
        /// </summary>
        public const string TABLE_NAME = "USERSELECTCOLUMNS";
        public const String USERSELECTCOLUMNS_ID_FIELD = "USERSELECTCOLUMNS_ID";
        public const String USER_ID_FIELD = "USER_ID";
        public const String SELECTTABLENAME_FIELD = "SELECTTABLENAME";
        public const String DISPLAYCOLUMNS_FIELD = "DISPLAYCOLUMNS";
        public const String HIDDENCOLUMNS_FIELD = "HIDDENCOLUMNS";
    }
}