using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for ROUTINEMAINTAIN Table
	/// </summary>
	[Serializable]
	[DataTable("ROUTINEMAINTAIN",ResourceKey = "ROUTINEMAINTAIN")]
	public class ROUTINEMAINTAIN: BaseObject
	{
		public ROUTINEMAINTAIN()
		{
		}
		public ROUTINEMAINTAIN(DealModel initModel):base(initModel)
		{
		}
		public static ROUTINEMAINTAIN Convert(BaseObject from)
		{
			return (ROUTINEMAINTAIN)from;
		}
		/// <summary>
		/// The ROUTINEMAINTAIN_ID Field of ROUTINEMAINTAIN Table
		/// </summary>
		private decimal _routinemaintain_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.ROUTINEMAINTAIN_ID = value; }
			get { return ROUTINEMAINTAIN_ID; }
		}

		[RecordIDField("ROUTINEMAINTAIN_ID"
			, AliasName = "ROUTINEMAINTAIN_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "ROUTINEMAINTAIN_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal ROUTINEMAINTAIN_ID
		{
			set { _routinemaintain_id = value; }
			get { return _routinemaintain_id; }
		}
		/// <summary>
		/// The SERIAL Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _serial;
        [KeyField("SERIAL"
			, AliasName = "SERIAL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SERIAL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SERIAL
		{
			set { _serial = value; }
			get { return _serial; }
		}
		/// <summary>
		/// The MODEL_TYPE Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _model_type;
		[DataField("MODEL_TYPE"
			, AliasName = "MODEL_TYPE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MODEL_TYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MODEL_TYPE
		{
			set { _model_type = value; }
			get { return _model_type; }
		}
		/// <summary>
		/// The CANCER_TYPE_ABBR Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _cancer_type_abbr;
		[DataField("CANCER_TYPE_ABBR"
			, AliasName = "CANCER_TYPE_ABBR"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "CANCER_TYPE_ABBR"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CANCER_TYPE_ABBR
		{
			set { _cancer_type_abbr = value; }
			get { return _cancer_type_abbr; }
		}
		/// <summary>
		/// The SUBTYPE1 Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _subtype1;
		[DataField("SUBTYPE1"
			, AliasName = "SUBTYPE1"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SUBTYPE1"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SUBTYPE1
		{
			set { _subtype1 = value; }
			get { return _subtype1; }
		}
		/// <summary>
		/// The SUBTYPE2 Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _subtype2;
		[DataField("SUBTYPE2"
			, AliasName = "SUBTYPE2"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SUBTYPE2"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
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
		/// The MODEL_ID Field of ROUTINEMAINTAIN Table
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
			, SelectSequence = 18
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
		/// The PROJECT Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _project;
		[DataField("PROJECT"
			, AliasName = "PROJECT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PROJECT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
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
		/// The LOCATION Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _location;
		[DataField("LOCATION"
			, AliasName = "LOCATION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "LOCATION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LOCATION
		{
			set { _location = value; }
			get { return _location; }
		}
		/// <summary>
		/// The SOURCE_ANIMAL Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _source_animal;
		[DataField("SOURCE_ANIMAL"
			, AliasName = "SOURCE_ANIMAL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SOURCE_ANIMAL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SOURCE_ANIMAL
		{
			set { _source_animal = value; }
			get { return _source_animal; }
		}
		/// <summary>
		/// The OPREATION Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _opreation;
		[DataField("OPREATION"
			, AliasName = "OPREATION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "OPREATION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string OPREATION
		{
			set { _opreation = value; }
			get { return _opreation; }
		}
		/// <summary>
		/// The RN Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _rn;
		[DataField("RN"
			, AliasName = "RN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 25
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "RN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
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
		/// The PN Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _pn;
		[DataField("PN"
			, AliasName = "PN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 25
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 36
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
		/// The DATE_OF_PASSAGE_INOCULATION Field of ROUTINEMAINTAIN Table
		/// </summary>
		private DateTime _date_of_passage_inoculation;
		[DataField("DATE_OF_PASSAGE_INOCULATION"
			, AliasName = "DATE_OF_PASSAGE_INOCULATION"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_PASSAGE_INOCULATION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 39
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_OF_PASSAGE_INOCULATION
		{
			set { _date_of_passage_inoculation = value; }
			get { return _date_of_passage_inoculation; }
		}
		/// <summary>
		/// The STUDY Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _study;
		[DataField("STUDY"
			, AliasName = "STUDY"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "STUDY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 42
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string STUDY
		{
			set { _study = value; }
			get { return _study; }
		}
		/// <summary>
		/// The ANIMAL_STRAIN Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _animal_strain;
		[DataField("ANIMAL_STRAIN"
			, AliasName = "ANIMAL_STRAIN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANIMAL_STRAIN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 45
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANIMAL_STRAIN
		{
			set { _animal_strain = value; }
			get { return _animal_strain; }
		}
		/// <summary>
		/// The ANIMAL_SEX Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _animal_sex;
		[DataField("ANIMAL_SEX"
			, AliasName = "ANIMAL_SEX"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANIMAL_SEX"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 48
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANIMAL_SEX
		{
			set { _animal_sex = value; }
			get { return _animal_sex; }
		}
		/// <summary>
		/// The CURRENT_ANIMAL_EAR_TAG Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _current_animal_ear_tag;
        [KeyField("CURRENT_ANIMAL_EAR_TAG"
			, AliasName = "CURRENT_ANIMAL_EAR_TAG"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "CURRENT_ANIMAL_EAR_TAG"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 51
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CURRENT_ANIMAL_EAR_TAG
		{
			set { _current_animal_ear_tag = value; }
			get { return _current_animal_ear_tag; }
		}
		/// <summary>
		/// The ANIMAL_QUANTITY Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _animal_quantity;
		[DataField("ANIMAL_QUANTITY"
			, AliasName = "ANIMAL_QUANTITY"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANIMAL_QUANTITY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 54
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANIMAL_QUANTITY
		{
			set { _animal_quantity = value; }
			get { return _animal_quantity; }
		}
		/// <summary>
		/// The PDX_GROWTH_STATUS Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _pdx_growth_status;
		[DataField("PDX_GROWTH_STATUS"
			, AliasName = "PDX_GROWTH_STATUS"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PDX_GROWTH_STATUS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 57
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PDX_GROWTH_STATUS
		{
			set { _pdx_growth_status = value; }
			get { return _pdx_growth_status; }
		}
		/// <summary>
		/// The DATE_OF_PASSAGE_TERMINATION Field of ROUTINEMAINTAIN Table
		/// </summary>
		private DateTime _date_of_passage_termination;
		[DataField("DATE_OF_PASSAGE_TERMINATION"
			, AliasName = "DATE_OF_PASSAGE_TERMINATION"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_PASSAGE_TERMINATION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 60
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_OF_PASSAGE_TERMINATION
		{
			set { _date_of_passage_termination = value; }
			get { return _date_of_passage_termination; }
		}
		/// <summary>
		/// The DURATION Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _duration;
		[DataField("DURATION"
			, AliasName = "DURATION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DURATION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 63
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string DURATION
		{
			set { _duration = value; }
			get { return _duration; }
		}
		/// <summary>
		/// The SOURCE_HOSPITAL Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _source_hospital;
		[DataField("SOURCE_HOSPITAL"
			, AliasName = "SOURCE_HOSPITAL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SOURCE_HOSPITAL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 66
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SOURCE_HOSPITAL
		{
			set { _source_hospital = value; }
			get { return _source_hospital; }
		}
		/// <summary>
		/// The PATHOLOGY_INFO_AVAILABLE Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _pathology_info_available;
		[DataField("PATHOLOGY_INFO_AVAILABLE"
			, AliasName = "PATHOLOGY_INFO_AVAILABLE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PATHOLOGY_INFO_AVAILABLE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 69
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PATHOLOGY_INFO_AVAILABLE
		{
			set { _pathology_info_available = value; }
			get { return _pathology_info_available; }
		}
		/// <summary>
		/// The DATE_OF_PATHOLOGY_INFO_RECEIVED Field of ROUTINEMAINTAIN Table
		/// </summary>
		private DateTime _date_of_pathology_info_received;
		[DataField("DATE_OF_PATHOLOGY_INFO_RECEIVED"
			, AliasName = "DATE_OF_PATHOLOGY_INFO_RECEIVED"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_PATHOLOGY_INFO_RECEIVED"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 72
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_OF_PATHOLOGY_INFO_RECEIVED
		{
			set { _date_of_pathology_info_received = value; }
			get { return _date_of_pathology_info_received; }
		}
		/// <summary>
		/// The PATIENT_NO Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _patient_no;
		[DataField("PATIENT_NO"
			, AliasName = "PATIENT_NO"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PATIENT_NO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 75
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PATIENT_NO
		{
			set { _patient_no = value; }
			get { return _patient_no; }
		}
		/// <summary>
		/// The PATIENT_NAME Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _patient_name;
		[DataField("PATIENT_NAME"
			, AliasName = "PATIENT_NAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PATIENT_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 78
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PATIENT_NAME
		{
			set { _patient_name = value; }
			get { return _patient_name; }
		}
		/// <summary>
		/// The PATIENT_AGE Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _patient_age;
		[DataField("PATIENT_AGE"
			, AliasName = "PATIENT_AGE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PATIENT_AGE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 81
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PATIENT_AGE
		{
			set { _patient_age = value; }
			get { return _patient_age; }
		}
		/// <summary>
		/// The PATIENT_SEX Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _patient_sex;
		[DataField("PATIENT_SEX"
			, AliasName = "PATIENT_SEX"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PATIENT_SEX"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 84
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PATIENT_SEX
		{
			set { _patient_sex = value; }
			get { return _patient_sex; }
		}
		/// <summary>
		/// The PATIENT_PATHOLOGY_INFO_QCED Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _patient_pathology_info_qced;
		[DataField("PATIENT_PATHOLOGY_INFO_QCED"
			, AliasName = "PATIENT_PATHOLOGY_INFO_QCED"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PATIENT_PATHOLOGY_INFO_QCED"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 87
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PATIENT_PATHOLOGY_INFO_QCED
		{
			set { _patient_pathology_info_qced = value; }
			get { return _patient_pathology_info_qced; }
		}
		/// <summary>
		/// The PATHOLOGY_INFO_QCED Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _pathology_info_qced;
		[DataField("PATHOLOGY_INFO_QCED"
			, AliasName = "PATHOLOGY_INFO_QCED"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PATHOLOGY_INFO_QCED"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 90
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PATHOLOGY_INFO_QCED
		{
			set { _pathology_info_qced = value; }
			get { return _pathology_info_qced; }
		}
		/// <summary>
		/// The COMMENTS Field of ROUTINEMAINTAIN Table
		/// </summary>
		private string _comments;
		[DataField("COMMENTS"
			, AliasName = "COMMENTS"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "COMMENTS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 93
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string COMMENTS
		{
			set { _comments = value; }
			get { return _comments; }
		}
		/// <summary>
		/// The EDITOR Field of ROUTINEMAINTAIN Table
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
			, SelectSequence = 96
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
		/// The DATE_OF_CREATE Field of ROUTINEMAINTAIN Table
		/// </summary>
		private DateTime _date_of_create;
		[DataField("DATE_OF_CREATE"
			, AliasName = "DATE_OF_CREATE"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_CREATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 99
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_OF_CREATE
		{
			set { _date_of_create = value; }
			get { return _date_of_create; }
		}
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
            , SelectSequence = 102
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
        /// The MODEL_TUMOR_CHARACTERISTICS Field of NEWMODEL Table
        /// </summary>
        private string _model_tumor_characteristics;
        [DataField("MODEL_TUMOR_CHARACTERISTICS"
            , AliasName = "MODEL_TUMOR_CHARACTERISTICS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 1000
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODEL_TUMOR_CHARACTERISTICS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 105
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODEL_TUMOR_CHARACTERISTICS
        {
            set { _model_tumor_characteristics = value; }
            get { return _model_tumor_characteristics; }
        }
        /// <summary>
        /// ROUTINEMAINTAIN Table 
        /// </summary>
        public const string TABLE_NAME="ROUTINEMAINTAIN";
		public const String ROUTINEMAINTAIN_ID_FIELD  ="ROUTINEMAINTAIN_ID";
		public const String SERIAL_FIELD  ="SERIAL";
		public const String MODEL_TYPE_FIELD  ="MODEL_TYPE";
		public const String CANCER_TYPE_ABBR_FIELD  ="CANCER_TYPE_ABBR";
		public const String SUBTYPE1_FIELD  ="SUBTYPE1";
		public const String SUBTYPE2_FIELD  ="SUBTYPE2";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
		public const String PROJECT_FIELD  ="PROJECT";
		public const String LOCATION_FIELD  ="LOCATION";
		public const String SOURCE_ANIMAL_FIELD  ="SOURCE_ANIMAL";
		public const String OPREATION_FIELD  ="OPREATION";
		public const String RN_FIELD  ="RN";
		public const String PN_FIELD  ="PN";
		public const String DATE_OF_PASSAGE_INOCULATION_FIELD  ="DATE_OF_PASSAGE_INOCULATION";
		public const String STUDY_FIELD  ="STUDY";
		public const String ANIMAL_STRAIN_FIELD  ="ANIMAL_STRAIN";
		public const String ANIMAL_SEX_FIELD  ="ANIMAL_SEX";
		public const String CURRENT_ANIMAL_EAR_TAG_FIELD  ="CURRENT_ANIMAL_EAR_TAG";
		public const String ANIMAL_QUANTITY_FIELD  ="ANIMAL_QUANTITY";
		public const String PDX_GROWTH_STATUS_FIELD  ="PDX_GROWTH_STATUS";
		public const String DATE_OF_PASSAGE_TERMINATION_FIELD  ="DATE_OF_PASSAGE_TERMINATION";
		public const String DURATION_FIELD  ="DURATION";
		public const String SOURCE_HOSPITAL_FIELD  ="SOURCE_HOSPITAL";
		public const String PATHOLOGY_INFO_AVAILABLE_FIELD  ="PATHOLOGY_INFO_AVAILABLE";
		public const String DATE_OF_PATHOLOGY_INFO_RECEIVED_FIELD  ="DATE_OF_PATHOLOGY_INFO_RECEIVED";
		public const String PATIENT_NO_FIELD  ="PATIENT_NO";
		public const String PATIENT_NAME_FIELD  ="PATIENT_NAME";
		public const String PATIENT_AGE_FIELD  ="PATIENT_AGE";
		public const String PATIENT_SEX_FIELD  ="PATIENT_SEX";
		public const String PATIENT_PATHOLOGY_INFO_QCED_FIELD  ="PATIENT_PATHOLOGY_INFO_QCED";
		public const String PATHOLOGY_INFO_QCED_FIELD  ="PATHOLOGY_INFO_QCED";
		public const String COMMENTS_FIELD  ="COMMENTS";
		public const String EDITOR_FIELD  ="EDITOR";
		public const String DATE_OF_CREATE_FIELD  ="DATE_OF_CREATE";
        public const String ANIMAL_ROOM_NUMBER_FIELD = "ANIMAL_ROOM_NUMBER";
        public const String MODEL_TUMOR_CHARACTERISTICS_FIELD = "MODEL_TUMOR_CHARACTERISTICS";
    }
}