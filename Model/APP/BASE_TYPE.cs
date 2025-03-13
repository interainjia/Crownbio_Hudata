using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for BASE_TYPE Table
    /// </summary>
    [Serializable]
    [DataTable("BASE_TYPE", ResourceKey = "BASE_TYPE")]
    public class BASE_TYPE : BaseObject
    {
        public BASE_TYPE()
        {
        }
        public BASE_TYPE(DealModel initModel)
            : base(initModel)
        {
        }
        public static BASE_TYPE Convert(BaseObject from)
        {
            return (BASE_TYPE)from;
        }
        private bool isSelect = false;
        public bool IS_SELECT
        {
            set { isSelect = value; }
            get { return isSelect; }
        }
        /// <summary>
        /// The TYPE_ID Field of BASE_TYPE Table
        /// </summary>
        private decimal _type_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.TYPE_ID = value;
            }
            get { return TYPE_ID; }
        }

        [RecordIDField("TYPE_ID"
            , AliasName = "TYPE_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 10
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "TYPE_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal TYPE_ID
        {
            set { _type_id = value; }
            get { return _type_id; }
        }
        /// <summary>
        /// The TYPE_NO Field of BASE_TYPE Table
        /// </summary>
        private string _type_no;
        [KeyField("TYPE_NO"
            , AliasName = "TYPE_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
           , DisplayInMaintain = false
            , DisplayInDialog = true
            , ResourceKey = "TYPE_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 3
            , DialogSequence = 3
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 0
             )]
        public string TYPE_NO
        {
            set { _type_no = value; }
            get { return _type_no; }
        }
        /// <summary>
        /// The TYPE_CLASS Field of BASE_TYPE Table
        /// </summary>
        private string _type_class;
        [DataField("TYPE_CLASS"
            , AliasName = "TYPE_CLASS"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "TYPE_CLASS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TYPE_CLASS
        {
            set { _type_class = value; }
            get { return _type_class; }
        }
        /// <summary>
        /// The TYPE_NAME Field of BASE_TYPE Table
        /// </summary>
        private string _type_name;
        [DataField("TYPE_NAME"
            , AliasName = "TYPE_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 60
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TYPE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TYPE_NAME
        {
            set { _type_name = value; }
            get { return _type_name; }
        }
        /// <summary>
        /// The REMARK Field of BASE_TYPE Table
        /// </summary>
        private string _remark;
        [DataField("REMARK"
            , AliasName = "REMARK"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = -1
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REMARK"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REMARK
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// The CREATE_BY Field of BASE_TYPE Table
        /// </summary>
        private decimal _create_by;
        [DataField("CREATE_BY"
            , AliasName = "CREATE_BY"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 9
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "CREATE_BY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 101
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = false
            , DefaultValue = "UserID"
             )]
        public decimal CREATE_BY
        {
            set { _create_by = value; }
            get { return _create_by; }
        }
        /// <summary>
        /// The CREATE_TIME Field of BASE_TYPE Table
        /// </summary>
        private DateTime _create_time;
        [DataField("CREATE_TIME"
            , AliasName = "CREATE_TIME"
            , DataType = DbType.DateTime
            , IsNullable = false
            , Size = 20
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "CREATE_TIME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 102
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = false
            , DefaultValue = "SysDate"
             )]
        public DateTime CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// The UPDATE_BY Field of BASE_TYPE Table
        /// </summary>
        private decimal _update_by;
        [DataField("UPDATE_BY"
            , AliasName = "UPDATE_BY"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 9
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "UPDATE_BY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 103
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "UserID"
             )]
        public decimal UPDATE_BY
        {
            set { _update_by = value; }
            get { return _update_by; }
        }
        /// <summary>
        /// The UPDATE_TIME Field of BASE_TYPE Table
        /// </summary>
        private DateTime _update_time;
        [DataField("UPDATE_TIME"
            , AliasName = "UPDATE_TIME"
            , DataType = DbType.DateTime
            , IsNullable = false
            , Size = 20
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "UPDATE_TIME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , SelectSequence = 104
            , DialogSequence = -1
            , Frozen = false
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "SysDate"
             )]
        public DateTime UPDATE_TIME
        {
            set { _update_time = value; }
            get { return _update_time; }
        }

        /// <summary>
        /// BASE_TYPE Table 
        /// </summary>
        public const string TABLE_NAME = "BASE_TYPE";
        public const String TYPE_ID_FIELD = "TYPE_ID";
        public const String TYPE_NO_FIELD = "TYPE_NO";
        public const String TYPE_CLASS_FIELD = "TYPE_CLASS";
        public const String REMARK_FIELD = "REMARK";
        public const String CREATE_BY_FIELD = "CREATE_BY";
        public const String CREATE_TIME_FIELD = "CREATE_TIME";
        public const String UPDATE_BY_FIELD = "UPDATE_BY";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
        public const String TYPE_NAME_FIELD = "TYPE_NAME";
    }
}