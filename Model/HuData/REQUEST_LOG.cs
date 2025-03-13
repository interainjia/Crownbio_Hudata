using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for REQUEST_LOG Table
	/// </summary>
	[Serializable]
	[DataTable("REQUEST_LOG",ResourceKey = "REQUEST_LOG")]
	public class REQUEST_LOG: BaseObject
	{
		public REQUEST_LOG()
		{
		}
		public REQUEST_LOG(DealModel initModel):base(initModel)
		{
		}
		public static REQUEST_LOG Convert(BaseObject from)
		{
			return (REQUEST_LOG)from;
		}
		/// <summary>
		/// The REQUEST_LOG_ID Field of REQUEST_LOG Table
		/// </summary>
		private decimal _request_log_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.REQUEST_LOG_ID = value; }
			get { return REQUEST_LOG_ID; }
		}

		[RecordIDField("REQUEST_LOG_ID"
			, AliasName = "REQUEST_LOG_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "REQUEST_LOG_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal REQUEST_LOG_ID
		{
			set { _request_log_id = value; }
			get { return _request_log_id; }
		}
		/// <summary>
		/// The REQUEST_ID Field of REQUEST_LOG Table
		/// </summary>
		private decimal _request_id;
		[DataField("REQUEST_ID"
			, AliasName = "REQUEST_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REQUEST_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal REQUEST_ID
		{
			set { _request_id = value; }
			get { return _request_id; }
		}
		/// <summary>
		/// The MODEL_ID Field of REQUEST_LOG Table
		/// </summary>
		private string _model_id;
		[DataField("MODEL_ID"
			, AliasName = "MODEL_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 1000
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MODEL_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MODEL_ID
		{
			set { _model_id = value; }
			get { return _model_id; }
		}
        /// <summary>
        /// The PROJECT_NUMBER Field of REQUEST_LOG Table
        /// </summary>
        private string _project_number;
        [DataField("PROJECT_NUMBER"
            , AliasName = "PROJECT_NUMBER"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROJECT_NUMBER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 7
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PROJECT_NUMBER
        {
            set { _project_number = value; }
            get { return _project_number; }
        }

		/// <summary>
		/// The DATE_OF_1ST_RESPONDING Field of REQUEST_LOG Table
		/// </summary>
		private DateTime _date_of_1st_responding;
		[DataField("DATE_OF_1ST_RESPONDING"
			, AliasName = "DATE_OF_1ST_RESPONDING"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_1ST_RESPONDING"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_OF_1ST_RESPONDING
		{
			set { _date_of_1st_responding = value; }
			get { return _date_of_1st_responding; }
		}
        public string DATE_OF_1ST_RESPONDING_F
        {
            get
            {
                if (_date_of_1st_responding != DateTime.MinValue)
                {
                    return _date_of_1st_responding.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }
		/// <summary>
		/// The STUDY_SIZE Field of REQUEST_LOG Table
		/// </summary>
		private string _study_size;
		[DataField("STUDY_SIZE"
			, AliasName = "STUDY_SIZE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "STUDY_SIZE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string STUDY_SIZE
		{
			set { _study_size = value; }
			get { return _study_size; }
		}
        /// <summary>
        /// The SIGNED Field of REQUEST_LOG Table
        /// </summary>
        private string _signed;
        [DataField("SIGNED"
            , AliasName = "SIGNED"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 5
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SIGNED"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 13
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SIGNED
        {
            set { _signed = value; }
            get { return _signed; }
        }

		/// <summary>
		/// The REMARK Field of REQUEST_LOG Table
		/// </summary>
		private string _remark;
		[DataField("REMARK"
			, AliasName = "REMARK"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 1000
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REMARK"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
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
		/// The CREATE_OF_DATE Field of REQUEST_LOG Table
		/// </summary>
		private DateTime _create_of_date;
		[DataField("CREATE_OF_DATE"
			, AliasName = "CREATE_OF_DATE"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "CREATE_OF_DATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public DateTime CREATE_OF_DATE
		{
			set { _create_of_date = value; }
			get { return _create_of_date; }
		}
        public string CREATE_OF_DATE_F
        {
            get
            {
                if (_create_of_date != DateTime.MinValue)
                {
                    return _create_of_date.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }

        private string _bd;
        [DataField("BD"
            , AliasName = "BD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 250
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "BD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string BD
        {
            set { _bd = value; }
            get { return _bd; }
        }
        /// <summary>
        /// The SD Field of REQUEST Table
        /// </summary>
        private string _sd;
        [DataField("SD"
            , AliasName = "SD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 250
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SD
        {
            set { _sd = value; }
            get { return _sd; }
        }
        /// <summary>
        /// The TYPE_OF_STUDY Field of REQUEST Table
        /// </summary>
        private string _type_of_study;
        [DataField("TYPE_OF_STUDY"
            , AliasName = "TYPE_OF_STUDY"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TYPE_OF_STUDY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TYPE_OF_STUDY
        {
            set { _type_of_study = value; }
            get { return _type_of_study; }
        }
        /// <summary>
        /// The PARENT_PROJECT Field of REQUEST_LOG Table
        /// </summary>
        private string _parent_project;
        [DataField("PARENT_PROJECT"
            , AliasName = "PARENT_PROJECT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PARENT_PROJECT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PARENT_PROJECT
        {
            set { _parent_project = value; }
            get { return _parent_project; }
        }
        /// <summary>
        /// The LEADING_SD Field of REQUEST_LOG Table
        /// </summary>
        private string _leading_sd;
        [DataField("LEADING_SD"
            , AliasName = "LEADING_SD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "LEADING_SD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 39
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string LEADING_SD
        {
            set { _leading_sd = value; }
            get { return _leading_sd; }
        }


		/// <summary>
		/// The EDITOR Field of REQUEST_LOG Table
		/// </summary>
		private string _editor;
		[DataField("EDITOR"
			, AliasName = "EDITOR"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "EDITOR"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 45
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string EDITOR
		{
			set { _editor = value; }
			get { return _editor; }
		}
        /// <summary>
        /// The CLIENT Field of REQUEST Table
        /// </summary>
        private string _client;
        [ForeignKeyField("CLIENT"
            , AliasName = "CLIENT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CLIENT"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 48
            , IsInsertField = true
            , IsUpdateField = true
           , ForeignTableName = SPONSOR_AX_CODE.TABLE_NAME
           , ForeignTableAliasName = SPONSOR_AX_CODE.TABLE_NAME
           , ForeignColumnName = SPONSOR_AX_CODE.SPONSOR_FIELD
           , IsMainTableKey = true
           , ForeignTableJoinType = TableJoinType.LeftOuterJoin
           , TableJoinSequence = 0
             )]
        public string CLIENT
        {
            set { _client = value; }
            get { return _client; }
        }
        private string _pm;
        [DataField("PM"
            , AliasName = "PM"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PM"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 51
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PM
        {
            set { _pm = value; }
            get { return _pm; }
        }
		/// <summary>
		/// REQUEST_LOG Table 
		/// </summary>
		public const string TABLE_NAME="REQUEST_LOG";
		public const String REQUEST_LOG_ID_FIELD  ="REQUEST_LOG_ID";
		public const String REQUEST_ID_FIELD  ="REQUEST_ID";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
        public const String PROJECT_NUMBER_FIELD = "PROJECT_NUMBER";
		public const String DATE_OF_1ST_RESPONDING_FIELD  ="DATE_OF_1ST_RESPONDING";
        public const String DATE_OF_1ST_RESPONDING_F_FIELD = "DATE_OF_1ST_RESPONDING_F";
		public const String STUDY_SIZE_FIELD  ="STUDY_SIZE";
        public const String SIGNED_FIELD = "SIGNED";
		public const String REMARK_FIELD  ="REMARK";
        public const String CREATE_OF_DATE_FIELD = "CREATE_OF_DATE";
        public const String CREATE_OF_DATE_F_FIELD = "CREATE_OF_DATE_F";
        public const String BD_FIELD = "BD";
        public const String SD_FIELD = "SD";
        public const String TYPE_OF_STUDY_FIELD = "TYPE_OF_STUDY";
        public const String PARENT_PROJECT_FIELD = "PARENT_PROJECT";
        public const String LEADING_SD_FIELD = "LEADING_SD";
        public const String EDITOR_FIELD = "EDITOR";
        public const String CLIENT_FIELD = "CLIENT";
        public const String PM_FIELD = "PM";
	}
}