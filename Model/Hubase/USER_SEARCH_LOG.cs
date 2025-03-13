using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for USER_SEARCH_LOG Table
    /// </summary>
    [Serializable]
    [DataTable("USER_SEARCH_LOG", ResourceKey = "USER_SEARCH_LOG")]
    public class USER_SEARCH_LOG : BaseObject
    {
        public USER_SEARCH_LOG()
        {
        }
        public USER_SEARCH_LOG(DealModel initModel)
            : base(initModel)
        {
        }
        public static USER_SEARCH_LOG Convert(BaseObject from)
        {
            return (USER_SEARCH_LOG)from;
        }
        /// <summary>
        /// The USER_SEARCH_LOG_ID Field of USER_SEARCH_LOG Table
        /// </summary>
        private decimal _user_search_log_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.USER_SEARCH_LOG_ID = value;
            }
            get { return USER_SEARCH_LOG_ID; }
        }

        [RecordIDField("USER_SEARCH_LOG_ID"
            , AliasName = "USER_SEARCH_LOG_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "USER_SEARCH_LOG_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal USER_SEARCH_LOG_ID
        {
            set { _user_search_log_id = value; }
            get { return _user_search_log_id; }
        }
        /// <summary>
        /// The EMAIL Field of USER_SEARCH_LOG Table
        /// </summary>
        private string _email;
        [DataField("EMAIL"
            , AliasName = "EMAIL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "EMAIL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// The SEARCH_TIME Field of USER_SEARCH_LOG Table
        /// </summary>
        private DateTime _search_time;
        [DataField("SEARCH_TIME"
            , AliasName = "SEARCH_TIME"
            , DataType = DbType.DateTime
            , IsNullable = true
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SEARCH_TIME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime SEARCH_TIME
        {
            set { _search_time = value; }
            get { return _search_time; }
        }
        /// <summary>
        /// The SEARCH_GENE Field of USER_SEARCH_LOG Table
        /// </summary>
        private string _search_gene;
        [DataField("SEARCH_GENE"
            , AliasName = "SEARCH_GENE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SEARCH_GENE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SEARCH_GENE
        {
            set { _search_gene = value; }
            get { return _search_gene; }
        }
        /// <summary>
        /// The SEARCH_CELLLINE Field of USER_SEARCH_LOG Table
        /// </summary>
        private string _search_cellline;
        [DataField("SEARCH_CELLLINE"
            , AliasName = "SEARCH_CELLLINE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SEARCH_CELLLINE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SEARCH_CELLLINE
        {
            set { _search_cellline = value; }
            get { return _search_cellline; }
        }
        /// <summary>
        /// The SEARCH_TYPE Field of USER_SEARCH_LOG Table
        /// </summary>
        private string _search_type;
        [DataField("SEARCH_TYPE"
            , AliasName = "SEARCH_TYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SEARCH_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SEARCH_TYPE
        {
            set { _search_type = value; }
            get { return _search_type; }
        }
        /// <summary>
        /// The COLLECTION Field of USER_SEARCH_LOG Table
        /// </summary>
        private string _collection;
        [DataField("COLLECTION"
            , AliasName = "COLLECTION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COLLECTION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COLLECTION
        {
            set { _collection = value; }
            get { return _collection; }
        }
        /// <summary>
        /// USER_SEARCH_LOG Table 
        /// </summary>
        public const string TABLE_NAME = "USER_SEARCH_LOG";
        public const String USER_SEARCH_LOG_ID_FIELD = "USER_SEARCH_LOG_ID";
        public const String EMAIL_FIELD = "EMAIL";
        public const String SEARCH_TIME_FIELD = "SEARCH_TIME";
        public const String SEARCH_GENE_FIELD = "SEARCH_GENE";
        public const String SEARCH_CELLLINE_FIELD = "SEARCH_CELLLINE";
        public const String SEARCH_TYPE_FIELD = "SEARCH_TYPE";
        public const String COLLECTION_FIELD = "COLLECTION";
    }
}