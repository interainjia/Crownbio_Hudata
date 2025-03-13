using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for APP_FILE Table
    /// </summary>
    [Serializable]
    [DataTable("APP_FILE", ResourceKey = "APP_FILE")]
    public class APP_FILE : BaseObject
    {
        public APP_FILE()
        {
        }
        public APP_FILE(DealModel initModel)
            : base(initModel)
        {
        }
        public static APP_FILE Convert(BaseObject from)
        {
            return (APP_FILE)from;
        }
        /// <summary>
        /// ½«List<BaseObject>×ªÎªBaseList
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns></returns>
        public static BaseList convertToBaseList(List<APP_FILE> dataList)
        {
            BaseList _data = new BaseList();
            foreach (APP_FILE ob in dataList)
            {
                _data.Add(ob);
            }
            return _data;
        }
        /// <summary>
        /// The FILE_ID Field of APP_FILE Table
        /// </summary>
        private decimal _file_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.FILE_ID = value;
            }
            get { return FILE_ID; }
        }
        public override string CODE
        {
            set
            {
                base.CODE = value;
                this.DOC_NO = value;
            }
            get { return DOC_NO; }
        }

        [RecordIDField("FILE_ID"
            , AliasName = "FILE_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "FILE_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal FILE_ID
        {
            set { _file_id = value; }
            get { return _file_id; }
        }
        /// <summary>
        /// The DOC_NO Field of APP_FILE Table
        /// </summary>
        private string _doc_no;
        [KeyField("DOC_NO"
            , AliasName = "DOC_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "DOC_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 3
            , DialogSequence = 3
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 0
             )]
        public string DOC_NO
        {
            set { _doc_no = value; }
            get { return _doc_no; }
        }

        /// <summary>
        /// The PROJECT_CODE Field of APP_FILE Table
        /// </summary>
        //private string _project_code;
        //[DataField("PROJECT_CODE"
        //    , AliasName = "PROJECT_CODE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 20
        //    , Width = 100
        //    , DisplayInCondition = true
        //    , DisplayInMaintain = true
        //    , DisplayInDialog = true
        //    , ResourceKey = "PROJECT_CODE"
        //    , GroupFun = "MAX"
        //    , AllowEdit = false
        //    , Frozen = true
        //    , SelectSequence = 4
        //    , DialogSequence = 4
        //    , IsInsertField = true
        //    , IsUpdateField = true
        //)]
        //public string PROJECT_CODE
        //{
        //    set { _project_code = value; }
        //    get { return _project_code; }
        //}

        /// <summary>
        /// The PROJECT_CODE Field of APP_FILE Table
        /// </summary>
        private string _project_code;
        [DataField("PROJECT_CODE"
            , AliasName = "PROJECT_CODE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "PROJECT_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 4
            , DialogSequence = 4
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PROJECT_CODE
        {
            set { _project_code = value; }
            get { return _project_code; }
        }

        //private string _project_name;
        //[ForeignField("PROJECT_NAME"
        //    , AliasName = "PROJECT_NAME"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 80
        //    , Width = 100
        //    , DisplayInCondition = false
        //    , DisplayInMaintain = false
        //    , ResourceKey = "PROJECT_NAME"
        //    , AllowEdit = false
        //    , SelectSequence = 4
        //    , IsInsertField = false
        //    , IsUpdateField = false
        //    , ForeignTableName = APP_FW.TABLE_NAME
        //    , ForeignTableAliasName = APP_FW.TABLE_NAME
        //    , ForeignColumnName = APP_FW.FW_NAME_FIELD
        //     )]
        //public string PROJECT_NAME
        //{
        //    set { _project_name = value; }
        //    get { return _project_name; }
        //}
    
        /// <summary>
        /// The SEQ_NO Field of APP_FILE Table
        /// </summary>
        private decimal _seq_no;
        [KeyField("SEQ_NO"
            , AliasName = "SEQ_NO"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 10
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "SEQ_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 9
            , DialogSequence = 9
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 1
             )]
        public decimal SEQ_NO
        {
            set { _seq_no = value; }
            get { return _seq_no; }
        }
        /// <summary>
        /// The FILE_TYPE Field of APP_FILE Table
        /// </summary>
        private string _file_type;
        [KeyField("FILE_TYPE"
            , AliasName = "FILE_TYPE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "FILE_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 12
            , DialogSequence = 12
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 2
             )]
        //[ForeignKeyField("FILE_TYPE"
        //    , AliasName = "FILE_TYPE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 20
        //    , Width = 100
        //    , DisplayInCondition = true
        //    , DisplayInMaintain = true
        //    , DisplayInDialog = true
        //    , ResourceKey = "FILE_TYPE"
        //    , GroupFun = "MAX"
        //    , AllowEdit = false
        //    , Frozen = true
        //    , SelectSequence = 4
        //    , DialogSequence = 4
        //    , IsInsertField = false
        //    , IsUpdateField = false
        //    , ForeignTableName = BASE_TYPE.TABLE_NAME
        //    , ForeignTableAliasName = BASE_TYPE.TABLE_NAME
        //    , ForeignColumnName = BASE_TYPE.TYPE_NO_FIELD
        //    , IsMainTableKey = true
        //    , ForeignTableJoinType = TableJoinType.LeftOuterJoin
        //    , TableJoinSequence = 5
        //)]
        public string FILE_TYPE
        {
            set { _file_type = value; }
            get { return _file_type; }
        }
        //private string _type_name;
        //[ForeignField("TYPE_NAME"
        //    , AliasName = "TYPE_NAME"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 80
        //    , Width = 100
        //    , DisplayInCondition = false
        //    , DisplayInMaintain = false
        //    , ResourceKey = "TYPE_NAME"
        //    , AllowEdit = false
        //    , SelectSequence = 4
        //    , IsInsertField = false
        //    , IsUpdateField = false
        //    , ForeignTableName = BASE_TYPE.TABLE_NAME
        //    , ForeignTableAliasName = BASE_TYPE.TABLE_NAME
        //    , ForeignColumnName = BASE_TYPE.TYPE_NAME_FIELD
        //     )]
        //public string TYPE_NAME
        //{
        //    set { _type_name = value; }
        //    get { return _type_name; }
        //}

        /// <summary>
        /// The FILE_NAME Field of APP_FILE Table
        /// </summary>
        private string _file_name;
        [DataField("FILE_NAME"
            , AliasName = "FILE_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FILE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FILE_NAME
        {
            set { _file_name = value; }
            get { return _file_name; }
            //get
            //{
            //    if (_file_name != "" && this.PROJECT_NAME == null)
            //    {
            //        return _file_name;
            //    }
            //    else
            //    {
            //        return String.Format("{0}_{1}", PROJECT_NAME, REMARK);
            //    }
            //}
        }

        /// <summary>
        /// The FILE_DESC Field of APP_FILE Table
        /// </summary>
        private string _file_desc;
        [DataField("FILE_DESC"
            , AliasName = "FILE_DESC"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FILE_DESC"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FILE_DESC
        {
            set { _file_desc = value; }
            get { return _file_desc; }
        }
        /// <summary>
        /// The FILE_PATH Field of APP_FILE Table
        /// </summary>
        private string _file_path;
        [DataField("FILE_PATH"
            , AliasName = "FILE_PATH"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FILE_PATH"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FILE_PATH
        {
            set { _file_path = value; }
            get { return _file_path; }
        }
        /// <summary>
        /// The REMARK Field of APP_FILE Table
        /// </summary>
        private byte[] _remark;
        [DataField("REMARK"
            , AliasName = "REMARK"
            , DataType = DbType.Binary
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REMARK"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public byte[] REMARK
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// The CREATE_BY Field of APP_FILE Table
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
        /// The CREATE_TIME Field of APP_FILE Table
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
        /// The UPDATE_BY Field of APP_FILE Table
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
        /// The UPDATE_TIME Field of APP_FILE Table
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

        private string serverpath = "";
        public string ServerPath
        {
            get { return serverpath; }
            set { serverpath = value; }
        }
        private string clientpath = "";
        public string ClientPath
        {
            get { return clientpath; }
            set { clientpath = value; }
        }

        /// <summary>
        /// APP_FILE Table 
        /// </summary>
        public const string TABLE_NAME = "APP_FILE";
        public const String FILE_ID_FIELD = "FILE_ID";
        public const String DOC_NO_FIELD = "DOC_NO";
        public const String PROJECT_CODE_FIELD = "PROJECT_CODE";
        public const String SEQ_NO_FIELD = "SEQ_NO";
        public const String FILE_TYPE_FIELD = "FILE_TYPE";
        public const String FILE_NAME_FIELD = "FILE_NAME";
        public const String FILE_DESC_FIELD = "FILE_DESC";
        public const String FILE_PATH_FIELD = "FILE_PATH";
        public const String REMARK_FIELD = "REMARK";
        public const String CREATE_BY_FIELD = "CREATE_BY";
        public const String CREATE_TIME_FIELD = "CREATE_TIME";
        public const String UPDATE_BY_FIELD = "UPDATE_BY";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
    }
}