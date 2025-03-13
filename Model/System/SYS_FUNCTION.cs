using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for SYS_FUNCTION Table
    /// </summary>
    [Serializable]
    [DataTable("SYS_FUNCTION", ResourceKey = "SYS_FUNCTION")]
    public class SYS_FUNCTION : BaseObject
    {
        public SYS_FUNCTION()
        {
        }
        public SYS_FUNCTION(DealModel initModel)
            : base(initModel)
        {
        }
        public static SYS_FUNCTION Convert(BaseObject from)
        {
            return (SYS_FUNCTION)from;
        }
        /// <summary>
        /// The FUNCTION_ID Field of SYS_FUNCTION Table
        /// </summary>
        private string _function_id;
        //public override decimal ID 
        //{
        //    set {
        //        base.ID = value;
        //         this.FUNCTION_ID = value; }
        //    get { return FUNCTION_ID; }
        //}

        [RecordIDField("FUNCTION_ID"
            , AliasName = "FUNCTION_ID"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "FUNCTION_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public string FUNCTION_ID
        {
            set { _function_id = value; }
            get { return _function_id; }
        }
        /// <summary>
        /// The MODULE_CODE Field of SYS_FUNCTION Table
        /// </summary>
        private string _module_code;
        [KeyField("MODULE_CODE"
            , AliasName = "MODULE_CODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "MODULE_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 3
            , DialogSequence = 3
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 0
             )]
        [ForeignKeyField("MODULE_CODE"
            , AliasName = "MODULE_CODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 100
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "MODULE_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = -1
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
            , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
            , ForeignColumnName = SYS_WEB_MODULE.MODULE_CODE_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 0
         )]
        public string MODULE_CODE
        {
            set { _module_code = value; }
            get { return _module_code; }
        }



        /// <summary>
        /// The MODULE_NAME Field of SYS_MODULE Table
        /// </summary>
        private string _module_name;
        [ForeignField("MODULE_NAME"
            , AliasName = "MODULE_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 30
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODULE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 4
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
           , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignColumnName = SYS_WEB_MODULE.MODULE_NAME_FIELD
             )]
        public string MODULE_NAME
        {
            set { _module_name = value; }
            get { return _module_name; }
        }


        /// <summary>
        /// The PARENT_CODE Field of SYS_MODULE Table
        /// </summary>
        private string _parent_code;
        [ForeignField("PARENT_CODE"
            , AliasName = "PARENT_CODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PARENT_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 5
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
           , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignColumnName = SYS_WEB_MODULE.PARENT_CODE_FIELD
             )]
        public string PARENT_CODE
        {
            set { _parent_code = value; }
            get { return _parent_code; }
        }

        /// <summary>
        /// The FUNCTION_CODE Field of SYS_FUNCTION Table
        /// </summary>
        private decimal _function_code;
        [KeyField("FUNCTION_CODE"
            , AliasName = "FUNCTION_CODE"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "FUNCTION_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 6
            , DialogSequence = 6
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 1
             )]
        public decimal FUNCTION_CODE
        {
            set { _function_code = value; }
            get { return _function_code; }
        }
        /// <summary>
        /// The FUNCTION_NAME Field of SYS_FUNCTION Table
        /// </summary>
        private string _function_name;
        [DataField("FUNCTION_NAME"
            , AliasName = "FUNCTION_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 30
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FUNCTION_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
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
        /// SYS_FUNCTION Table 
        /// </summary>
        public const string TABLE_NAME = "SYS_FUNCTION";
        public const String FUNCTION_ID_FIELD = "FUNCTION_ID";
        public const String MODULE_CODE_FIELD = "MODULE_CODE";
        public const String FUNCTION_CODE_FIELD = "FUNCTION_CODE";
        public const String FUNCTION_NAME_FIELD = "FUNCTION_NAME";
    }


    /// <summary>
    /// 目录、模块、功能集合
    /// </summary>
    [Serializable]
    public class FunctionCollection : List<SYS_FUNCTION>
    {
        public FunctionCollection()
        {
        }
    }
}