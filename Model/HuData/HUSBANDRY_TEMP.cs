using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for HUSBANDRY_TEMP Table
	/// </summary>
	[Serializable]
	[DataTable("HUSBANDRY_TEMP",ResourceKey = "HUSBANDRY_TEMP")]
	public class HUSBANDRY_TEMP: BaseObject
	{
		public HUSBANDRY_TEMP()
		{
		}
		public HUSBANDRY_TEMP(DealModel initModel):base(initModel)
		{
		}
		public static HUSBANDRY_TEMP Convert(BaseObject from)
		{
			return (HUSBANDRY_TEMP)from;
		}
		/// <summary>
		/// The HUSBANDRY_TEMP_ID Field of HUSBANDRY_TEMP Table
		/// </summary>
		private decimal _HUSBANDRY_TEMP_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.HUSBANDRY_TEMP_ID = value; }
			get { return HUSBANDRY_TEMP_ID; }
		}

		[RecordIDField("HUSBANDRY_TEMP_ID"
			, AliasName = "HUSBANDRY_TEMP_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "HUSBANDRY_TEMP_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal HUSBANDRY_TEMP_ID
		{
			set { _HUSBANDRY_TEMP_id = value; }
			get { return _HUSBANDRY_TEMP_id; }
		}
		/// <summary>
		/// The CANCER_TYPE Field of HUSBANDRY_TEMP Table
		/// </summary>
		private string _cancer_type;
		[DataField("CANCER_TYPE"
			, AliasName = "CANCER_TYPE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "CANCER_TYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CANCER_TYPE
		{
			set { _cancer_type = value; }
			get { return _cancer_type; }
		}
		/// <summary>
		/// The MODEL_ID Field of HUSBANDRY_TEMP Table
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
		/// The RN Field of HUSBANDRY_TEMP Table
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
		/// The PN Field of HUSBANDRY_TEMP Table
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
		/// The DOI Field of HUSBANDRY_TEMP Table
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
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DOI
		{
			set { _doi = value; }
			get { return _doi; }
		}
		/// <summary>
		/// The CAGE Field of HUSBANDRY_TEMP Table
		/// </summary>
		private string _cage;
		[DataField("CAGE"
			, AliasName = "CAGE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "CAGE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CAGE
		{
			set { _cage = value; }
			get { return _cage; }
		}
		/// <summary>
		/// The NUMBER_IN_CAGE Field of HUSBANDRY_TEMP Table
		/// </summary>
		private Int32 _number_in_cage;
		[DataField("NUMBER_IN_CAGE"
			, AliasName = "NUMBER_IN_CAGE"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "NUMBER_IN_CAGE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 NUMBER_IN_CAGE
		{
			set { _number_in_cage = value; }
			get { return _number_in_cage; }
		}
		/// <summary>
		/// The DATE_OF_UPDATE Field of HUSBANDRY_TEMP Table
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
			, SelectSequence = 24
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
		/// The HUNBANDRY_DAYS Field of HUSBANDRY_TEMP Table
		/// </summary>
		private Int32 _hunbandry_days;
		[DataField("HUNBANDRY_DAYS"
			, AliasName = "HUNBANDRY_DAYS"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "HUNBANDRY_DAYS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 HUNBANDRY_DAYS
		{
			set { _hunbandry_days = value; }
			get { return _hunbandry_days; }
		}
		/// <summary>
		/// The COST_ACCUMULATION Field of HUSBANDRY_TEMP Table
		/// </summary>
		private string _cost_accumulation;
		[DataField("COST_ACCUMULATION"
			, AliasName = "COST_ACCUMULATION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "COST_ACCUMULATION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string COST_ACCUMULATION
		{
			set { _cost_accumulation = value; }
			get { return _cost_accumulation; }
		}
		/// <summary>
		/// The PROJECT Field of HUSBANDRY_TEMP Table
		/// </summary>
		private string _project;
		[DataField("PROJECT"
			, AliasName = "PROJECT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 5
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PROJECT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PROJECT
		{
			set { _project = value; }
			get { return _project; }
		}
        /// <summary>
        /// The ALIVE Field of HUSBANDRY_TEMP Table
        /// </summary>
        private string _alive;
        [DataField("ALIVE"
            , AliasName = "ALIVE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 5
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ALIVE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ALIVE
        {
            set { _alive = value; }
            get { return _alive; }
        }
        /// <summary>
        /// The HUNBANDRY_FINISH Field of HUSBANDRY_TEMP Table
        /// </summary>
        private string _hunbandry_finish;
        [DataField("HUNBANDRY_FINISH"
            , AliasName = "HUNBANDRY_FINISH"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "HUNBANDRY_FINISH"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 39
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string HUNBANDRY_FINISH
        {
            set { _hunbandry_finish = value; }
            get { return _hunbandry_finish; }
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
            , SelectSequence = 42
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
            , SelectSequence = 45
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
		/// HUSBANDRY_TEMP Table 
		/// </summary>
		public const string TABLE_NAME="HUSBANDRY_TEMP";
		public const String HUSBANDRY_TEMP_ID_FIELD  ="HUSBANDRY_TEMP_ID";
		public const String CANCER_TYPE_FIELD  ="CANCER_TYPE";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
		public const String RN_FIELD  ="RN";
		public const String PN_FIELD  ="PN";
		public const String DOI_FIELD  ="DOI";
		public const String CAGE_FIELD  ="CAGE";
		public const String NUMBER_IN_CAGE_FIELD  ="NUMBER_IN_CAGE";
		public const String DATE_OF_UPDATE_FIELD  ="DATE_OF_UPDATE";
		public const String HUNBANDRY_DAYS_FIELD  ="HUNBANDRY_DAYS";
		public const String COST_ACCUMULATION_FIELD  ="COST_ACCUMULATION";
		public const String PROJECT_FIELD  ="PROJECT";
        public const String ALIVE_FIELD = "ALIVE";
        public const String HUNBANDRY_FINISH_FIELD = "HUNBANDRY_FINISH";
        public const String ONGOING_PROJECT_FIELD = "ONGOING_PROJECT";
        public const String SOURCE_PROJECT_FIELD = "SOURCE_PROJECT";
	}
}