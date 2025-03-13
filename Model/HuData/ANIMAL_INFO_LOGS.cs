using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for ANIMAL_INFO_LOGS Table
	/// </summary>
	[Serializable]
	[DataTable("ANIMAL_INFO_LOGS",ResourceKey = "ANIMAL_INFO_LOGS")]
	public class ANIMAL_INFO_LOGS: BaseObject
	{
		public ANIMAL_INFO_LOGS()
		{
		}
		public ANIMAL_INFO_LOGS(DealModel initModel):base(initModel)
		{
		}
		public static ANIMAL_INFO_LOGS Convert(BaseObject from)
		{
			return (ANIMAL_INFO_LOGS)from;
		}
		/// <summary>
		/// The ANIMAL_INFO_LOGS_ID Field of ANIMAL_INFO_LOGS Table
		/// </summary>
		private decimal _animal_info_logs_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.ANIMAL_INFO_LOGS_ID = value; }
			get { return ANIMAL_INFO_LOGS_ID; }
		}

		[RecordIDField("ANIMAL_INFO_LOGS_ID"
			, AliasName = "ANIMAL_INFO_LOGS_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "ANIMAL_INFO_LOGS_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal ANIMAL_INFO_LOGS_ID
		{
			set { _animal_info_logs_id = value; }
			get { return _animal_info_logs_id; }
		}
		/// <summary>
		/// The MODEL_ID Field of ANIMAL_INFO_LOGS Table
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
		/// The DOI Field of ANIMAL_INFO_LOGS Table
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
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DOI
		{
			set { _doi = value; }
			get { return _doi; }
		}

        private string _doi_f;
        public string DOI_F
        {
            set { _doi_f = value; }
            get
            {
                if (_doi != DateTime.MinValue)
                {
                    return _doi.ToShortDateString();
                }
                else
                {
                    return "";
                }
            }
        }

		/// <summary>
		/// The RN Field of ANIMAL_INFO_LOGS Table
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
		/// The PN Field of ANIMAL_INFO_LOGS Table
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
		/// The LOCATION_OF_LIVE_ANIMAL Field of ANIMAL_INFO_LOGS Table
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
			, SelectSequence = 15
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
		/// The ANIMAL_ROOM_NUMBER Field of ANIMAL_INFO_LOGS Table
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
			, SelectSequence = 18
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
		/// The IVC_LOCATION Field of ANIMAL_INFO_LOGS Table
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
			, SelectSequence = 21
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
		/// The ANIMAL_NUMBER Field of ANIMAL_INFO_LOGS Table
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
			, SelectSequence = 24
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
		/// The BODY_WEIGHT Field of ANIMAL_INFO_LOGS Table
		/// </summary>
		private string _body_weight;
		[DataField("BODY_WEIGHT"
			, AliasName = "BODY_WEIGHT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 25
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "BODY_WEIGHT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
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
		/// The TVLB Field of ANIMAL_INFO_LOGS Table
		/// </summary>
		private Int32 _tvlb;
		[DataField("TVLB"
			, AliasName = "TVLB"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TVLB"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
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
		/// The TVLF Field of ANIMAL_INFO_LOGS Table
		/// </summary>
		private Int32 _tvlf;
		[DataField("TVLF"
			, AliasName = "TVLF"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TVLF"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
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
		/// The TVRF Field of ANIMAL_INFO_LOGS Table
		/// </summary>
		private Int32 _tvrf;
		[DataField("TVRF"
			, AliasName = "TVRF"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TVRF"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 36
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
		/// The TVRB Field of ANIMAL_INFO_LOGS Table
		/// </summary>
		private Int32 _tvrb;
		[DataField("TVRB"
			, AliasName = "TVRB"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TVRB"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 39
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
		/// The TV_AVG Field of ANIMAL_INFO_LOGS Table
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
			, SelectSequence = 42
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
		/// The TUMOR_NUMBER Field of ANIMAL_INFO_LOGS Table
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
		/// The DATE_OF_UPDATE Field of ANIMAL_INFO_LOGS Table
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
			, SelectSequence = 48
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public DateTime DATE_OF_UPDATE
		{
			set { _date_of_update = value; }
			get { return _date_of_update; }
		}

        private string _date_of_update_f;
        public string DATE_OF_UPDATE_F
        {
            set { _date_of_update_f = value; }
            get {
                if (_date_of_update != DateTime.MinValue)
                {
                    return  _date_of_update.ToShortDateString();
                }
                else
                {
                    return "";
                }
            }
        }
		/// <summary>
		/// The DURATION Field of ANIMAL_INFO_LOGS Table
		/// </summary>
		private Int32 _duration;
		[DataField("DURATION"
			, AliasName = "DURATION"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DURATION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 51
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 DURATION
		{
			set { _duration = value; }
			get { return _duration; }
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
            , SelectSequence = 53
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
            , SelectSequence = 56
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
        /// ANIMAL_INFO_LOGS Table 
        /// </summary>
        public const string TABLE_NAME="ANIMAL_INFO_LOGS";
		public const String ANIMAL_INFO_LOGS_ID_FIELD  ="ANIMAL_INFO_LOGS_ID";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
		public const String DOI_FIELD  ="DOI";
		public const String RN_FIELD  ="RN";
		public const String PN_FIELD  ="PN";
		public const String LOCATION_OF_LIVE_ANIMAL_FIELD  ="LOCATION_OF_LIVE_ANIMAL";
		public const String ANIMAL_ROOM_NUMBER_FIELD  ="ANIMAL_ROOM_NUMBER";
		public const String IVC_LOCATION_FIELD  ="IVC_LOCATION";
		public const String ANIMAL_NUMBER_FIELD  ="ANIMAL_NUMBER";
		public const String BODY_WEIGHT_FIELD  ="BODY_WEIGHT";
		public const String TVLB_FIELD  ="TVLB";
		public const String TVLF_FIELD  ="TVLF";
		public const String TVRF_FIELD  ="TVRF";
		public const String TVRB_FIELD  ="TVRB";
		public const String TV_AVG_FIELD  ="TV_AVG";
		public const String TUMOR_NUMBER_FIELD  ="TUMOR_NUMBER";
		public const String DATE_OF_UPDATE_FIELD  ="DATE_OF_UPDATE";
		public const String DURATION_FIELD  ="DURATION";
        public const String CLINICAL_OBSERVATION_FIELD = "CLINICAL_OBSERVATION";
        public const String MORTALITY_OBSERVATION_FIELD = "MORTALITY_OBSERVATION";
    }
}