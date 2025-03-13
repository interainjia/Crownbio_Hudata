using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for SYS_USER_OPTION Table
    /// </summary>
    [Serializable]
    [DataTable("SYS_USER_OPTION", ResourceKey = "SYS_USER_OPTION")]
    public class SYS_USER_OPTION : BaseObject
    {
        public SYS_USER_OPTION()
        {
        }
        public SYS_USER_OPTION(DealModel initModel)
            : base(initModel)
        {
        }
        public static SYS_USER_OPTION Convert(BaseObject from)
        {
            return (SYS_USER_OPTION)from;
        }
        /// <summary>
        /// The USER_ID Field of SYS_USER_OPTION Table
        /// </summary>
        private decimal _user_id = -1;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.USER_ID = value;
            }
            get { return USER_ID; }
        }

        [RecordIDField("USER_ID"
            , AliasName = "USER_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "USER_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = true
            , IsUpdateField = false
             )]
        [KeyField("USER_ID"
            , AliasName = "USER_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 10
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "USER_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = -1
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , KeySequence = 0
             )]
        public decimal USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// The COLOR_REQUIRED Field of SYS_USER_OPTION Table
        /// </summary>
        private string _color_required = "255,255,192";
        [DataField("COLOR_REQUIRED"
            , AliasName = "COLOR_REQUIRED"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COLOR_REQUIRED"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COLOR_REQUIRED
        {
            set { _color_required = value; }
            get { return _color_required; }
        }
        /// <summary>
        /// The COLOR_OPTION Field of SYS_USER_OPTION Table
        /// </summary>
        private string _color_option = "192,192,255";
        [DataField("COLOR_OPTION"
            , AliasName = "COLOR_OPTION"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COLOR_OPTION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COLOR_OPTION
        {
            set { _color_option = value; }
            get { return _color_option; }
        }
        /// <summary>
        /// The COLOR_READONLY Field of SYS_USER_OPTION Table
        /// </summary>
        private string _color_readonly = "255,255,255";
        [DataField("COLOR_READONLY"
            , AliasName = "COLOR_READONLY"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COLOR_READONLY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COLOR_READONLY
        {
            set { _color_readonly = value; }
            get { return _color_readonly; }
        }
        /// <summary>
        /// The COLOR_BACK Field of SYS_USER_OPTION Table
        /// </summary>
        private string _color_back = "236, 240, 245";
        [DataField("COLOR_BACK"
            , AliasName = "COLOR_BACK"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COLOR_BACK"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COLOR_BACK
        {
            set { _color_back = value; }
            get { return _color_back; }
        }
        /// <summary>
        /// The COLOR_ALTER1 Field of SYS_USER_OPTION Table
        /// </summary>
        private string _color_alter1 = "255,255,255";
        [DataField("COLOR_ALTER1"
            , AliasName = "COLOR_ALTER1"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COLOR_ALTER1"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COLOR_ALTER1
        {
            set { _color_alter1 = value; }
            get { return _color_alter1; }
        }
        /// <summary>
        /// The COLOR_ALTER2 Field of SYS_USER_OPTION Table
        /// </summary>
        private string _color_alter2 = "236, 240, 245";
        [DataField("COLOR_ALTER2"
            , AliasName = "COLOR_ALTER2"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COLOR_ALTER2"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COLOR_ALTER2
        {
            set { _color_alter2 = value; }
            get { return _color_alter2; }
        }
        /// <summary>
        /// The COLOR_GRID Field of SYS_USER_OPTION Table
        /// </summary>
        private string _color_grid = "255,255,255";
        [DataField("COLOR_GRID"
            , AliasName = "COLOR_GRID"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COLOR_GRID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COLOR_GRID
        {
            set { _color_grid = value; }
            get { return _color_grid; }
        }
        /// <summary>
        /// The COLOR_SEARCH Field of SYS_USER_OPTION Table
        /// </summary>
        private string _color_search = "0,64,128";
        [DataField("COLOR_SEARCH"
            , AliasName = "COLOR_SEARCH"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COLOR_SEARCH"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COLOR_SEARCH
        {
            set { _color_search = value; }
            get { return _color_search; }
        }
        /// <summary>
        /// The IMPORT_PATH Field of SYS_USER_OPTION Table
        /// </summary>
        private string _import_path = "C:\\";
        [DataField("IMPORT_PATH"
            , AliasName = "IMPORT_PATH"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 120
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IMPORT_PATH"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string IMPORT_PATH
        {
            set { _import_path = value; }
            get { return _import_path; }
        }
        /// <summary>
        /// The EXPORT_PATH Field of SYS_USER_OPTION Table
        /// </summary>
        private string _export_path = "C:\\";
        [DataField("EXPORT_PATH"
            , AliasName = "EXPORT_PATH"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 120
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "EXPORT_PATH"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string EXPORT_PATH
        {
            set { _export_path = value; }
            get { return _export_path; }
        }
        /// <summary>
        /// SYS_USER_OPTION Table 
        /// </summary>
        public const string TABLE_NAME = "SYS_USER_OPTION";
        public const String USER_ID_FIELD = "USER_ID";
        public const String COLOR_REQUIRED_FIELD = "COLOR_REQUIRED";
        public const String COLOR_OPTION_FIELD = "COLOR_OPTION";
        public const String COLOR_READONLY_FIELD = "COLOR_READONLY";
        public const String COLOR_BACK_FIELD = "COLOR_BACK";
        public const String COLOR_ALTER1_FIELD = "COLOR_ALTER1";
        public const String COLOR_ALTER2_FIELD = "COLOR_ALTER2";
        public const String COLOR_GRID_FIELD = "COLOR_GRID";
        public const String COLOR_SEARCH_FIELD = "COLOR_SEARCH";
        public const String IMPORT_PATH_FIELD = "IMPORT_PATH";
        public const String EXPORT_PATH_FIELD = "EXPORT_PATH";
    }
}