using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for REQUEST Table
	/// </summary>
	[Serializable]
	[DataTable("REQUEST",ResourceKey = "REQUEST")]
	public class REQUEST: BaseObject
	{
		public REQUEST()
		{
		}
		public REQUEST(DealModel initModel):base(initModel)
		{
		}
		public static REQUEST Convert(BaseObject from)
		{
			return (REQUEST)from;
		}
		/// <summary>
		/// The REQUEST_ID Field of REQUEST Table
		/// </summary>
		private decimal _request_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.REQUEST_ID = value; }
			get { return REQUEST_ID; }
		}

		[RecordIDField("REQUEST_ID"
			, AliasName = "REQUEST_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "REQUEST_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal REQUEST_ID
		{
			set { _request_id = value; }
			get { return _request_id; }
		}
        /// <summary>
        /// The PARENT_PROJECT Field of REQUEST Table
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
            , SelectSequence = 1
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
		/// The PROJECT_NUMBER Field of REQUEST Table
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
			, SelectSequence = 3
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
		/// The DATE_REQUEST Field of REQUEST Table
		/// </summary>
		private DateTime _date_request;
		[DataField("DATE_REQUEST"
			, AliasName = "DATE_REQUEST"
			, DataType = DbType.Date
			, IsNullable = false
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_REQUEST"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_REQUEST
		{
			set { _date_request = value; }
			get { return _date_request; }
		}
          public string DATE_REQUEST_F
        {
            get
            {
                if (_date_request != DateTime.MinValue)
                {
                    return _date_request.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
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
			, SelectSequence = 9
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

        private string _ax_code;
        [ForeignField("AX_CODE"
            , AliasName = "AX_CODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 80
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , ResourceKey = "AX_CODE"
            , AllowEdit = false
            , SelectSequence = 10
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = SPONSOR_AX_CODE.TABLE_NAME
            , ForeignTableAliasName = SPONSOR_AX_CODE.TABLE_NAME
            , ForeignColumnName = SPONSOR_AX_CODE.AX_CODE_FIELD
             )]
        public string AX_CODE
        {
            set { _ax_code = value; }
            get { return _ax_code; }
        }
		/// <summary>
		/// The BD Field of REQUEST Table
		/// </summary>
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
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string BD
		{
			set { _bd = value; }
			get { return _bd; }
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
            , SelectSequence = 13
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
        /// The LEADING_SD Field of REQUEST Table
        /// </summary>
        private string _leading_sd;
        [DataField("LEADING_SD"
            , AliasName = "LEADING_SD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 250
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "LEADING_SD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 14
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
			, SelectSequence = 15
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
            , SelectSequence = 16
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
		/// The TUMOR_TYPE Field of REQUEST Table
		/// </summary>
		private string _tumor_type;
		[DataField("TUMOR_TYPE"
			, AliasName = "TUMOR_TYPE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 500
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TUMOR_TYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TUMOR_TYPE
		{
			set { _tumor_type = value; }
			get { return _tumor_type; }
		}
		/// <summary>
		/// The SUBTYPE Field of REQUEST Table
		/// </summary>
		private string _subtype1;
		[DataField("SUBTYPE1"
			, AliasName = "SUBTYPE1"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 500
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SUBTYPE1"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SUBTYPE1
		{
			set { _subtype1 = value; }
			get { return _subtype1; }
		}
        private string _subtype2;
        [DataField("SUBTYPE2"
            , AliasName = "SUBTYPE2"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 500
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SUBTYPE2"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 22
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SUBTYPE2
        {
            set { _subtype2 = value; }
            get { return _subtype2; }
        }
		/// <summary>
		/// The MODEL_ID Field of REQUEST Table
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
			, SelectSequence = 24
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
        /// The COMPLETED_MODEL_ID Field of REQUEST Table
        /// </summary>
        private string _completed_model_id;
        [DataField("COMPLETED_MODEL_ID"
            , AliasName = "COMPLETED_MODEL_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 1000
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COMPLETED_MODEL_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 25
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COMPLETED_MODEL_ID
        {
            set { _completed_model_id = value; }
            get { return _completed_model_id; }
        }


		/// <summary>
		/// The SPECIAL_REQUIREMENTS Field of REQUEST Table
		/// </summary>
		private string _special_requirements;
		[DataField("SPECIAL_REQUIREMENTS"
			, AliasName = "SPECIAL_REQUIREMENTS"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 1000
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SPECIAL_REQUIREMENTS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SPECIAL_REQUIREMENTS
		{
			set { _special_requirements = value; }
			get { return _special_requirements; }
		}
		/// <summary>
		/// The POTENTIAL_STUDY_SIZE Field of REQUEST Table
		/// </summary>
        private string _potential_study_size;
		[DataField("POTENTIAL_STUDY_SIZE"
			, AliasName = "POTENTIAL_STUDY_SIZE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "POTENTIAL_STUDY_SIZE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public string POTENTIAL_STUDY_SIZE
		{
			set { _potential_study_size = value; }
			get { return _potential_study_size; }
		}
		/// <summary>
		/// The OTHERS_TO_NOTIFY Field of REQUEST Table
		/// </summary>
		private string _signed;
        [DataField("SIGNED"
            , AliasName = "SIGNED"
			, DataType = DbType.String
			, IsNullable = true
            , Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
            , ResourceKey = "SIGNED"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
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
		/// The REQUESTER_ID Field of REQUEST Table
		/// </summary>
		private string _requester_id;
		[DataField("REQUESTER_ID"
			, AliasName = "REQUESTER_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REQUESTER_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 36
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string REQUESTER_ID
		{
			set { _requester_id = value; }
			get { return _requester_id; }
		}
		/// <summary>
		/// The RESPONDER_ID Field of REQUEST Table
		/// </summary>
		private string _responder_id;
		[DataField("RESPONDER_ID"
			, AliasName = "RESPONDER_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "RESPONDER_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 39
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string RESPONDER_ID
		{
			set { _responder_id = value; }
			get { return _responder_id; }
		}
		/// <summary>
		/// The RESPONDER Field of REQUEST Table
		/// </summary>
		private string _responder;
		[DataField("RESPONDER"
			, AliasName = "RESPONDER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "RESPONDER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 42
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string RESPONDER
		{
			set { _responder = value; }
			get { return _responder; }
		}
        public string HAVE_RESPONDED
        {
            get
            {
                if (_responder != "")
                {
                    return "Y";
                }
                else
                {
                    return "N";
                }
            }
        }
		/// <summary>
		/// The DATE_RESPONDING Field of REQUEST Table
		/// </summary>
		private DateTime _date_responding;
		[DataField("DATE_RESPONDING"
			, AliasName = "DATE_RESPONDING"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_RESPONDING"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 45
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public DateTime DATE_RESPONDING
		{
			set { _date_responding = value; }
			get { return _date_responding; }
		}
        public string DATE_RESPONDING_F
        {
            get
            {
                if (_date_responding != DateTime.MinValue)
                {
                    return _date_responding.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// The HAVE_CONFIRMED Field of REQUEST Table
        /// </summary>
        private string _have_confirmed;
        [DataField("HAVE_CONFIRMED"
            , AliasName = "HAVE_CONFIRMED"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "HAVE_CONFIRMED"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 48
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string HAVE_CONFIRMED
        {
            set { _have_confirmed = value; }
            get { return _have_confirmed; }
        }
        /// <summary>
        /// The CONFIRM_DATE Field of PROJECT_BOOKING Table
        /// </summary>
        private DateTime _confirm_date;
        [DataField("CONFIRM_DATE"
            , AliasName = "CONFIRM_DATE"
            , DataType = DbType.Date
            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CONFIRM_DATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 49
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime CONFIRM_DATE
        {
            set { _confirm_date = value; }
            get { return _confirm_date; }
        }
        public string CONFIRM_DATE_F
        {
            get
            {
                if (_confirm_date != DateTime.MinValue)
                {
                    return _confirm_date.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }

        private string _remark;
        [DataField("REMARK"
            , AliasName = "REMARK"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 2000
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REMARK"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 52
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
            , SelectSequence = 53
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
        /// <summary>
        /// The REQUEST_ONLY Field of REQUEST Table
        /// </summary>
        private string _request_only;
        [DataField("REQUEST_ONLY"
            , AliasName = "REQUEST_ONLY"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 5
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REQUEST_ONLY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 54
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REQUEST_ONLY
        {
            set { _request_only = value; }
            get { return _request_only; }
        }


        /// <summary>
        /// The ISDELETE Field of REQUEST Table
        /// </summary>
        private string _isdelete;
        [DataField("ISDELETE"
            , AliasName = "ISDELETE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 5
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ISDELETE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 57
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ISDELETE
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }

      

    


		/// <summary>
		/// REQUEST Table 
		/// </summary>
		public const string TABLE_NAME="REQUEST";
		public const String REQUEST_ID_FIELD  ="REQUEST_ID";
		public const String PROJECT_NUMBER_FIELD  ="PROJECT_NUMBER";
		public const String DATE_REQUEST_FIELD  ="DATE_REQUEST";
		public const String CLIENT_FIELD  ="CLIENT";
        public const String AX_CODE_FIELD = "AX_CODE";
		public const String BD_FIELD  ="BD";
		public const String SD_FIELD  ="SD";
        public const String TYPE_OF_STUDY_FIELD = "TYPE_OF_STUDY";
		public const String TUMOR_TYPE_FIELD  ="TUMOR_TYPE";
		public const String SUBTYPE1_FIELD  ="SUBTYPE1";
        public const String SUBTYPE2_FIELD = "SUBTYPE2";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
        public const String COMPLETED_MODEL_ID_FIELD = "COMPLETED_MODEL_ID";
		public const String SPECIAL_REQUIREMENTS_FIELD  ="SPECIAL_REQUIREMENTS";
		public const String POTENTIAL_STUDY_SIZE_FIELD  ="POTENTIAL_STUDY_SIZE";
        public const String SIGNED_FIELD = "SIGNED";
		public const String REQUESTER_ID_FIELD  ="REQUESTER_ID";
		public const String RESPONDER_ID_FIELD  ="RESPONDER_ID";
		public const String RESPONDER_FIELD  ="RESPONDER";
		public const String DATE_RESPONDING_FIELD  ="DATE_RESPONDING";
        public const String DATE_REQUEST_F_FIELD = "DATE_REQUEST_F";
        public const String DATE_RESPONDING_F_FIELD = "DATE_RESPONDING_F";
        public const String HAVE_RESPONDED_FIELD = "HAVE_RESPONDED";
        public const String HAVE_CONFIRMED_FIELD = "HAVE_CONFIRMED";
        public const String CONFIRM_DATE_FIELD = "CONFIRM_DATE";
        public const String CONFIRM_DATE_F_FIELD = "CONFIRM_DATE_F";
        public const String REMARK_FIELD = "REMARK";
        public const String CREATE_OF_DATE_FIELD = "CREATE_OF_DATE";
        public const String CREATE_OF_DATE_F_FIELD = "CREATE_OF_DATE_F";
        public const String REQUEST_ONLY_FIELD = "REQUEST_ONLY";
        public const String PARENT_PROJECT_FIELD = "PARENT_PROJECT";
        public const String LEADING_SD_FIELD = "LEADING_SD";
        public const String PM_FIELD = "PM";
        public const String ISDELETE_FIELD = "ISDELETE";


	}
}