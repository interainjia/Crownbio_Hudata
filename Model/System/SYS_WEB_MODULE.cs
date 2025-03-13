using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for SYS_WEB_MODULE Table
    /// </summary>
    [Serializable]
    [DataTable("SYS_WEB_MODULE", ResourceKey = "SYS_WEB_MODULE")]
    public class SYS_WEB_MODULE : BaseObject
    {
        public SYS_WEB_MODULE()
        {
        }
        public SYS_WEB_MODULE(DealModel initModel)
            : base(initModel)
        {
        }
        public static SYS_WEB_MODULE Convert(BaseObject from)
        {
            return (SYS_WEB_MODULE)from;
        }
        /// <summary>
        /// The MODULE_ID Field of SYS_WEB_MODULE Table
        /// </summary>
        private decimal _module_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.MODULE_ID = value;
            }
            get { return MODULE_ID; }
        }

        [RecordIDField("MODULE_ID"
            , AliasName = "MODULE_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "MODULE_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal MODULE_ID
        {
            set { _module_id = value; }
            get { return _module_id; }
        }
        /// <summary>
        /// The MODULE_TYPE Field of SYS_WEB_MODULE Table
        /// </summary>
        //private string _module_type;
        //[DataField("MODULE_TYPE"
        //    , AliasName = "MODULE_TYPE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 2
        //    , Width = 100
        //    , DisplayInCondition = true
        //    , DisplayInMaintain = true
        //    , DisplayInDialog = false
        //    , ResourceKey = "MODULE_TYPE"
        //    , GroupFun = "MAX"
        //    , AllowEdit = false
        //    , Frozen = false
        //    , SelectSequence = 3
        //    , DialogSequence = -1
        //    , IsInsertField = true
        //    , IsUpdateField = true
        //     )]
        //public string MODULE_TYPE
        //{
        //    set { _module_type = value; }
        //    get { return _module_type; }
        //}
        /// <summary>
        /// The MODULE_CODE Field of SYS_WEB_MODULE Table
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
            , SelectSequence = 6
            , DialogSequence = 6
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 0
             )]
        public string MODULE_CODE
        {
            set { _module_code = value; }
            get { return _module_code; }
        }
        /// <summary>
        /// The MODULE_NAME Field of SYS_WEB_MODULE Table
        /// </summary>
        private string _module_name;
        [DataField("MODULE_NAME"
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
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODULE_NAME
        {
            set { _module_name = value; }
            get { return _module_name; }
        }
        /// <summary>
        /// The MODULE_URL Field of SYS_WEB_MODULE Table
        /// </summary>
        private string _module_url;
        [DataField("MODULE_URL"
            , AliasName = "MODULE_URL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODULE_URL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODULE_URL
        {
            set { _module_url = value; }
            get { return _module_url; }
        }
        /// <summary>
        /// The MODULE_FILE Field of SYS_WEB_MODULE Table
        /// </summary>
        private string _module_file;
        [DataField("MODULE_FILE"
            , AliasName = "MODULE_FILE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODULE_FILE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODULE_FILE
        {
            set { _module_file = value; }
            get { return _module_file; }
        }
        /// <summary>
        /// The PARENT_CODE Field of SYS_WEB_MODULE Table
        /// </summary>
        private string _parent_code;
        [DataField("PARENT_CODE"
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
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PARENT_CODE
        {
            set { _parent_code = value; }
            get { return _parent_code; }
        }
        /// <summary>
        /// The IS_GROUP Field of SYS_WEB_MODULE Table
        /// </summary>
        private string _is_group;
        [DataField("IS_GROUP"
            , AliasName = "IS_GROUP"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 1
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_GROUP"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string IS_GROUP
        {
            set { _is_group = value; }
            get { return _is_group; }
        }
        /// <summary>
        /// The PICTURE_NAME Field of SYS_WEB_MODULE Table
        /// </summary>
        private string _picture_name;
        [DataField("PICTURE_NAME"
            , AliasName = "PICTURE_NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PICTURE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PICTURE_NAME
        {
            set { _picture_name = value; }
            get { return _picture_name; }
        }
        /// <summary>
        /// The IS_AVAILABLE Field of SYS_WEB_MODULE Table
        /// </summary>
        private string _is_available;
        [DataField("IS_AVAILABLE"
            , AliasName = "IS_AVAILABLE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 1
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_AVAILABLE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string IS_AVAILABLE
        {
            set { _is_available = value; }
            get { return _is_available; }
        }
        /// <summary>
        /// The IS_SPECIAL Field of SYS_WEB_MODULE Table
        /// </summary>
        private string _is_special;
        [DataField("IS_SPECIAL"
            , AliasName = "IS_SPECIAL"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 1
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_SPECIAL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string IS_SPECIAL
        {
            set { _is_special = value; }
            get { return _is_special; }
        }
        /// <summary>
        /// SYS_WEB_MODULE Table 
        /// </summary>
        public const string TABLE_NAME = "SYS_WEB_MODULE";
        public const String MODULE_ID_FIELD = "MODULE_ID";
        //public const String MODULE_TYPE_FIELD = "MODULE_TYPE";
        public const String MODULE_CODE_FIELD = "MODULE_CODE";
        public const String MODULE_NAME_FIELD = "MODULE_NAME";
        public const String MODULE_URL_FIELD = "MODULE_URL";
        public const String MODULE_FILE_FIELD = "MODULE_FILE";
        public const String PARENT_CODE_FIELD = "PARENT_CODE";
        public const String IS_GROUP_FIELD = "IS_GROUP";
        public const String PICTURE_NAME_FIELD = "PICTURE_NAME";
        public const String IS_AVAILABLE_FIELD = "IS_AVAILABLE";
        public const String IS_SPECIAL_FIELD = "IS_SPECIAL";
    }
}