using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for ANIMAL_INFO Table
	/// </summary>
	[Serializable]
	[DataTable("ANIMAL_INFO",ResourceKey = "ANIMAL_INFO")]
	public class ANIMAL_INFO: BaseObject
	{
		public ANIMAL_INFO()
		{
		}
		public ANIMAL_INFO(DealModel initModel):base(initModel)
		{
		}
		public static ANIMAL_INFO Convert(BaseObject from)
		{
			return (ANIMAL_INFO)from;
		}
		/// <summary>
		/// The ANIMAL_INFO_ID Field of ANIMAL_INFO Table
		/// </summary>
		private decimal _animal_info_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.ANIMAL_INFO_ID = value; }
			get { return ANIMAL_INFO_ID; }
		}

		[RecordIDField("ANIMAL_INFO_ID"
			, AliasName = "ANIMAL_INFO_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "ANIMAL_INFO_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal ANIMAL_INFO_ID
		{
			set { _animal_info_id = value; }
			get { return _animal_info_id; }
		}
		/// <summary>
		/// The MODEL_ID Field of ANIMAL_INFO Table
		/// </summary>
		private string _model_id;
		[DataField("MODEL_ID"
			, AliasName = "MODEL_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MODEL_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
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
		/// The CURRENT_PROJECT_NUMBER Field of ANIMAL_INFO Table
		/// </summary>
		private string _current_project_number;
		[DataField("CURRENT_PROJECT_NUMBER"
			, AliasName = "CURRENT_PROJECT_NUMBER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "CURRENT_PROJECT_NUMBER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CURRENT_PROJECT_NUMBER
		{
			set { _current_project_number = value; }
			get { return _current_project_number; }
		}
		/// <summary>
		/// The RN Field of ANIMAL_INFO Table
		/// </summary>
		private string _rn;
		[DataField("RN"
			, AliasName = "RN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "RN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string RN
		{
			set { _rn = value; }
			get { return _rn; }
		}
		/// <summary>
		/// The PN Field of ANIMAL_INFO Table
		/// </summary>
		private string _pn;
		[DataField("PN"
			, AliasName = "PN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PN
		{
			set { _pn = value; }
			get { return _pn; }
		}
		/// <summary>
		/// The MODEL_FIT_FOR_EFFICACY Field of ANIMAL_INFO Table
		/// </summary>
		private string _model_fit_for_efficacy;
		[DataField("MODEL_FIT_FOR_EFFICACY"
			, AliasName = "MODEL_FIT_FOR_EFFICACY"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MODEL_FIT_FOR_EFFICACY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MODEL_FIT_FOR_EFFICACY
		{
			set { _model_fit_for_efficacy = value; }
			get { return _model_fit_for_efficacy; }
		}
		/// <summary>
		/// The LOCATION_OF_LIVE_ANIMAL Field of ANIMAL_INFO Table
		/// </summary>
		private string _location_of_live_animal;
		[DataField("LOCATION_OF_LIVE_ANIMAL"
			, AliasName = "LOCATION_OF_LIVE_ANIMAL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "LOCATION_OF_LIVE_ANIMAL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LOCATION_OF_LIVE_ANIMAL
		{
			set { _location_of_live_animal = value; }
			get { return _location_of_live_animal; }
		}
		/// <summary>
		/// The ANIMAL_ROOM_NUMBER Field of ANIMAL_INFO Table
		/// </summary>
		private string _animal_room_number;
		[DataField("ANIMAL_ROOM_NUMBER"
			, AliasName = "ANIMAL_ROOM_NUMBER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANIMAL_ROOM_NUMBER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANIMAL_ROOM_NUMBER
		{
			set { _animal_room_number = value; }
			get { return _animal_room_number; }
		}
		/// <summary>
		/// The IVC_LOCATION Field of ANIMAL_INFO Table
		/// </summary>
		private string _ivc_location;
		[DataField("IVC_LOCATION"
			, AliasName = "IVC_LOCATION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "IVC_LOCATION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string IVC_LOCATION
		{
			set { _ivc_location = value; }
			get { return _ivc_location; }
		}
		/// <summary>
		/// The DOI Field of ANIMAL_INFO Table
		/// </summary>
		private DateTime _doi;
		[DataField("DOI"
			, AliasName = "DOI"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DOI"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DOI
		{
			set { _doi = value; }
			get { return _doi; }
		}
        public string DOI_F
        {
            get
            {
                if (_doi != DateTime.MinValue)
                {
                    return _doi.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }
		/// <summary>
		/// The MODEL_STATUS Field of ANIMAL_INFO Table
		/// </summary>
		private string _model_status;
		[DataField("MODEL_STATUS"
			, AliasName = "MODEL_STATUS"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MODEL_STATUS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MODEL_STATUS
		{
			set { _model_status = value; }
			get { return _model_status; }
		}
		/// <summary>
		/// The ANIMAL_NUMBER Field of ANIMAL_INFO Table
		/// </summary>
		private string _animal_number;
		[DataField("ANIMAL_NUMBER"
			, AliasName = "ANIMAL_NUMBER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANIMAL_NUMBER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANIMAL_NUMBER
		{
			set { _animal_number = value; }
			get { return _animal_number; }
		}
		/// <summary>
		/// The DATE_OF_UPDATE Field of ANIMAL_INFO Table
		/// </summary>
		private DateTime _date_of_update;
		[DataField("DATE_OF_UPDATE"
			, AliasName = "DATE_OF_UPDATE"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_UPDATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 36
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public DateTime DATE_OF_UPDATE
		{
			set { _date_of_update = value; }
			get { return _date_of_update; }
		}
		/// <summary>
		/// The TV Field of ANIMAL_INFO Table
		/// </summary>
		private Int32 _tv;
		[DataField("TV"
			, AliasName = "TV"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TV"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 39
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public Int32 TV
		{
			set { _tv = value; }
			get { return _tv; }
		}
        /// <summary>
        /// The TVLB Field of ANIMAL_INFO Table
        /// </summary>
        private Int32 _tvlb;
        [DataField("TVLB"
            , AliasName = "TVLB"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TVLB"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 40
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 TVLB
        {
            set { _tvlb = value; }
            get { return _tvlb; }
        }
        /// <summary>
        /// The TVLF Field of ANIMAL_INFO Table
        /// </summary>
        private Int32 _tvlf;
        [DataField("TVLF"
            , AliasName = "TVLF"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TVLF"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 41
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 TVLF
        {
            set { _tvlf = value; }
            get { return _tvlf; }
        }
        /// <summary>
        /// The TVRF Field of ANIMAL_INFO Table
        /// </summary>
        private Int32 _tvrf;
        [DataField("TVRF"
            , AliasName = "TVRF"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TVRF"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 42
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 TVRF
        {
            set { _tvrf = value; }
            get { return _tvrf; }
        }
        /// <summary>
        /// The TVRB Field of ANIMAL_INFO Table
        /// </summary>
        private Int32 _tvrb;
        [DataField("TVRB"
            , AliasName = "TVRB"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TVRB"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 43
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 TVRB
        {
            set { _tvrb = value; }
            get { return _tvrb; }
        }

        /// <summary>
        /// The TV_AVG Field of ANIMAL_INFO Table
        /// </summary>
        private Int32 _tv_avg;
        [DataField("TV_AVG"
            , AliasName = "TV_AVG"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TV_AVG"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 44
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 TV_AVG
        {
            set { _tv_avg = value; }
            get { return _tv_avg; }
        }

        /// <summary>
        /// The TUMOR_NUMBER Field of ANIMAL_INFO Table
        /// </summary>
        private Int32 _tumor_number;
        [DataField("TUMOR_NUMBER"
            , AliasName = "TUMOR_NUMBER"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TUMOR_NUMBER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 45
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 TUMOR_NUMBER
        {
            set { _tumor_number = value; }
            get { return _tumor_number; }
        }

		/// <summary>
		/// The Estimated_DOT Field of ANIMAL_INFO Table
		/// </summary>
		private string _Estimated_dot;
		[DataField("Estimated_DOT"
			, AliasName = "Estimated_DOT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "Estimated_DOT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 46
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string Estimated_DOT
		{
			set { _Estimated_dot = value; }
			get { return _Estimated_dot; }
		}
		/// <summary>
		/// The TIME_OF_MODEL_FOR_TRANSPLANT Field of ANIMAL_INFO Table
		/// </summary>
		private string _time_of_model_for_transplant;
		[DataField("TIME_OF_MODEL_FOR_TRANSPLANT"
			, AliasName = "TIME_OF_MODEL_FOR_TRANSPLANT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TIME_OF_MODEL_FOR_TRANSPLANT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 47
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TIME_OF_MODEL_FOR_TRANSPLANT
		{
			set { _time_of_model_for_transplant = value; }
			get { return _time_of_model_for_transplant; }
		}
        private string _body_weight;
        [DataField("BODY_WEIGHT"
            , AliasName = "BODY_WEIGHT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
            , ResourceKey = "BODY_WEIGHT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 48
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public string BODY_WEIGHT
		{
            set { _body_weight = value; }
            get { return _body_weight; }
		}
        /// <summary>
        /// The MORTALITY_OBSERVATION Field of ANIMAL_INFO Table
        /// </summary>
        private string _mortality_observation;
        [DataField("MORTALITY_OBSERVATION"
            , AliasName = "MORTALITY_OBSERVATION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 25
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MORTALITY_OBSERVATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 57
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MORTALITY_OBSERVATION
        {
            set { _mortality_observation = value; }
            get { return _mortality_observation; }
        }

        /// <summary>
        /// The ANIMAL_BOOKING Field of ANIMAL_INFO Table
        /// </summary>
        private string _animal_booking;
        [DataField("ANIMAL_BOOKING"
            , AliasName = "ANIMAL_BOOKING"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 25
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ANIMAL_BOOKING"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 51
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ANIMAL_BOOKING
        {
            set { _animal_booking = value; }
            get { return _animal_booking; }
        }
        /// <summary>
        /// The FURTHER_EXPANDING Field of ANIMAL_INFO Table
        /// </summary>
        private string _further_expanding;
        [DataField("FURTHER_EXPANDING"
            , AliasName = "FURTHER_EXPANDING"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 25
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FURTHER_EXPANDING"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 54
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FURTHER_EXPANDING
        {
            set { _further_expanding = value; }
            get { return _further_expanding; }
        }

        /// <summary>
        /// The ONGOING_PROJECT Field of ANIMAL_INFO Table
        /// </summary>
        private string _ongoing_project;
        [DataField("ONGOING_PROJECT"
            , AliasName = "ONGOING_PROJECT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ONGOING_PROJECT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 66
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ONGOING_PROJECT
        {
            set { _ongoing_project = value; }
            get { return _ongoing_project; }
        }
        /// <summary>
        /// The SOURCE_PROJECT Field of ANIMAL_INFO Table
        /// </summary>
        private string _source_project;
        [DataField("SOURCE_PROJECT"
            , AliasName = "SOURCE_PROJECT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SOURCE_PROJECT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 69
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SOURCE_PROJECT
        {
            set { _source_project = value; }
            get { return _source_project; }
        }

        /// <summary>
        /// The CLINICAL_OBSERVATION Field of ANIMAL_INFO Table
        /// </summary>
        private string _clinical_observation;
        [DataField("CLINICAL_OBSERVATION"
            , AliasName = "CLINICAL_OBSERVATION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 400
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CLINICAL_OBSERVATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 84
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CLINICAL_OBSERVATION
        {
            set { _clinical_observation = value; }
            get { return _clinical_observation; }
        }

		/// <summary>
		/// ANIMAL_INFO Table 
		/// </summary>
		public const string TABLE_NAME="ANIMAL_INFO";
		public const String ANIMAL_INFO_ID_FIELD  ="ANIMAL_INFO_ID";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
		public const String CURRENT_PROJECT_NUMBER_FIELD  ="CURRENT_PROJECT_NUMBER";
		public const String RN_FIELD  ="RN";
		public const String PN_FIELD  ="PN";
		public const String MODEL_FIT_FOR_EFFICACY_FIELD  ="MODEL_FIT_FOR_EFFICACY";
		public const String LOCATION_OF_LIVE_ANIMAL_FIELD  ="LOCATION_OF_LIVE_ANIMAL";
		public const String ANIMAL_ROOM_NUMBER_FIELD  ="ANIMAL_ROOM_NUMBER";
		public const String IVC_LOCATION_FIELD  ="IVC_LOCATION";
		public const String DOI_FIELD  ="DOI";
        public const String DOI_F_FIELD = "DOI_F";
        
		public const String MODEL_STATUS_FIELD  ="MODEL_STATUS";
		public const String ANIMAL_NUMBER_FIELD  ="ANIMAL_NUMBER";
		public const String DATE_OF_UPDATE_FIELD  ="DATE_OF_UPDATE";
		public const String TV_FIELD  ="TV";
        public const String TVLB_FIELD = "TVLB";
        public const String TVLF_FIELD = "TVLF";
        public const String TVRF_FIELD = "TVRF";
        public const String TVRB_FIELD = "TVRB";
        public const String TV_AVG_FIELD = "TV_AVG";
        public const String TUMOR_NUMBER_FIELD = "TUMOR_NUMBER";
		public const String Estimated_DOT_FIELD  ="Estimated_DOT";
		public const String TIME_OF_MODEL_FOR_TRANSPLANT_FIELD  ="TIME_OF_MODEL_FOR_TRANSPLANT";
        public const String BODY_WEIGHT_FIELD = "BODY_WEIGHT";
        public const String MORTALITY_OBSERVATION_FIELD = "MORTALITY_OBSERVATION";
        public const String ANIMAL_BOOKING_FIELD = "ANIMAL_BOOKING";
        public const String FURTHER_EXPANDING_FIELD = "FURTHER_EXPANDING";
        public const String ONGOING_PROJECT_FIELD = "ONGOING_PROJECT";
        public const String SOURCE_PROJECT_FIELD = "SOURCE_PROJECT";
        public const String CLINICAL_OBSERVATION_FIELD = "CLINICAL_OBSERVATION";
	}
}