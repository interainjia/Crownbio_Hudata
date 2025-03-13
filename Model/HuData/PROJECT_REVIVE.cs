using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for PROJECT_REVIVE Table
	/// </summary>
	[Serializable]
	[DataTable("PROJECT_REVIVE",ResourceKey = "PROJECT_REVIVE")]
	public class PROJECT_REVIVE: BaseObject
	{
		public PROJECT_REVIVE()
		{
		}
		public PROJECT_REVIVE(DealModel initModel):base(initModel)
		{
		}
		public static PROJECT_REVIVE Convert(BaseObject from)
		{
			return (PROJECT_REVIVE)from;
		}
		/// <summary>
		/// The PROJECT_REVIVE_ID Field of PROJECT_REVIVE Table
		/// </summary>
		private decimal _project_revive_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.PROJECT_REVIVE_ID = value; }
			get { return PROJECT_REVIVE_ID; }
		}

		[RecordIDField("PROJECT_REVIVE_ID"
			, AliasName = "PROJECT_REVIVE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "PROJECT_REVIVE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal PROJECT_REVIVE_ID
		{
			set { _project_revive_id = value; }
			get { return _project_revive_id; }
		}
		/// <summary>
		/// The REQUEST_ID Field of PROJECT_REVIVE Table
		/// </summary>
		private decimal _request_id;
		[DataField("REQUEST_ID"
			, AliasName = "REQUEST_ID"
			, DataType = DbType.Decimal
			, IsNullable = true
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
		/// The MODEL_ID Field of PROJECT_REVIVE Table
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
		/// The BOOKING Field of PROJECT_REVIVE Table
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
		/// The PROJECT_NUMBER Field of PROJECT_REVIVE Table
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
		/// The DATE_OF_REVIVE Field of PROJECT_REVIVE Table
		/// </summary>
		private DateTime _date_of_revive;
		[DataField("DATE_OF_REVIVE"
			, AliasName = "DATE_OF_REVIVE"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_REVIVE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public DateTime DATE_OF_REVIVE
		{
			set { _date_of_revive = value; }
			get { return _date_of_revive; }
		}
		/// <summary>
		/// The ANIMAL_NUMBER Field of PROJECT_REVIVE Table
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
		/// The BD Field of PROJECT_REVIVE Table
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
		/// The SD Field of PROJECT_REVIVE Table
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
		/// PROJECT_REVIVE Table 
		/// </summary>
		public const string TABLE_NAME="PROJECT_REVIVE";
		public const String PROJECT_REVIVE_ID_FIELD  ="PROJECT_REVIVE_ID";
        public const String REQUEST_ID_FIELD = "REQUEST_ID";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
		public const String BOOKING_FIELD  ="BOOKING";
		public const String PROJECT_NUMBER_FIELD  ="PROJECT_NUMBER";
		public const String DATE_OF_REVIVE_FIELD  ="DATE_OF_REVIVE";
		public const String ANIMAL_NUMBER_FIELD  ="ANIMAL_NUMBER";
		public const String BD_FIELD  ="BD";
		public const String SD_FIELD  ="SD";
	}
}