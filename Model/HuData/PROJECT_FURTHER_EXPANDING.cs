using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for PROJECT_FURTHER_EXPANDING Table
	/// </summary>
	[Serializable]
	[DataTable("PROJECT_FURTHER_EXPANDING",ResourceKey = "PROJECT_FURTHER_EXPANDING")]
	public class PROJECT_FURTHER_EXPANDING: BaseObject
	{
		public PROJECT_FURTHER_EXPANDING()
		{
		}
		public PROJECT_FURTHER_EXPANDING(DealModel initModel):base(initModel)
		{
		}
		public static PROJECT_FURTHER_EXPANDING Convert(BaseObject from)
		{
			return (PROJECT_FURTHER_EXPANDING)from;
		}
		/// <summary>
		/// The PROJECT_FURTHER_EXPANDING_ID Field of PROJECT_FURTHER_EXPANDING Table
		/// </summary>
		private decimal _project_further_expanding_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.PROJECT_FURTHER_EXPANDING_ID = value; }
			get { return PROJECT_FURTHER_EXPANDING_ID; }
		}

		[RecordIDField("PROJECT_FURTHER_EXPANDING_ID"
			, AliasName = "PROJECT_FURTHER_EXPANDING_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "PROJECT_FURTHER_EXPANDING_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal PROJECT_FURTHER_EXPANDING_ID
		{
			set { _project_further_expanding_id = value; }
			get { return _project_further_expanding_id; }
		}
		/// <summary>
		/// The REQUEST_ID Field of PROJECT_FURTHER_EXPANDING Table
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
		/// The MODEL_ID Field of PROJECT_FURTHER_EXPANDING Table
		/// </summary>
		private string _model_id;
		[DataField("MODEL_ID"
			, AliasName = "MODEL_ID"
			, DataType = DbType.String
			, IsNullable = false
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
		/// The BOOKING Field of PROJECT_FURTHER_EXPANDING Table
		/// </summary>
		private string _booking;
		[DataField("BOOKING"
			, AliasName = "BOOKING"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "BOOKING"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string BOOKING
		{
			set { _booking = value; }
			get { return _booking; }
		}
		/// <summary>
		/// The PROJECT_NUMBER Field of PROJECT_FURTHER_EXPANDING Table
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
			, SelectSequence = 12
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
		/// The DATE_OF_FURTHER_EXPANDING Field of PROJECT_FURTHER_EXPANDING Table
		/// </summary>
		private DateTime _date_of_further_expanding;
		[DataField("DATE_OF_FURTHER_EXPANDING"
			, AliasName = "DATE_OF_FURTHER_EXPANDING"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_FURTHER_EXPANDING"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_OF_FURTHER_EXPANDING
		{
			set { _date_of_further_expanding = value; }
			get { return _date_of_further_expanding; }
		}
        public string DATE_OF_FURTHER_EXPANDING_F
        {
            get
            {
                if (_date_of_further_expanding != DateTime.MinValue)
                {
                    return _date_of_further_expanding.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }
		/// <summary>
		/// The ANIMAL_NUMBER Field of PROJECT_FURTHER_EXPANDING Table
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
			, SelectSequence = 18
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
        /// The BD Field of PROJECT_BOOKING Table
        /// </summary>
        private string _bd;
        [DataField("BD"
            , AliasName = "BD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "BD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
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
        /// The SD Field of PROJECT_BOOKING Table
        /// </summary>
        private string _sd;
        [DataField("SD"
            , AliasName = "SD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
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
		/// PROJECT_FURTHER_EXPANDING Table 
		/// </summary>
		public const string TABLE_NAME="PROJECT_FURTHER_EXPANDING";
		public const String PROJECT_FURTHER_EXPANDING_ID_FIELD  ="PROJECT_FURTHER_EXPANDING_ID";
		public const String REQUEST_ID_FIELD  ="REQUEST_ID";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
		public const String BOOKING_FIELD  ="BOOKING";
		public const String PROJECT_NUMBER_FIELD  ="PROJECT_NUMBER";
		public const String DATE_OF_FURTHER_EXPANDING_FIELD  ="DATE_OF_FURTHER_EXPANDING";
        public const String DATE_OF_FURTHER_EXPANDING_F_FIELD = "DATE_OF_FURTHER_EXPANDING_F";
        
		public const String ANIMAL_NUMBER_FIELD  ="ANIMAL_NUMBER";
        public const String BD_FIELD = "BD";
        public const String SD_FIELD = "SD";

	}
}