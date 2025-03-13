using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for CANCERMODEL Table
	/// </summary>
	[Serializable]
	[DataTable("CANCERMODEL",ResourceKey = "CANCERMODEL")]
	public class CANCERMODEL: BaseObject
	{
		public CANCERMODEL()
		{
		}
		public CANCERMODEL(DealModel initModel):base(initModel)
		{
		}
		public static CANCERMODEL Convert(BaseObject from)
		{
			return (CANCERMODEL)from;
		}
		/// <summary>
		/// The CANCERMODEL_ID Field of CANCERMODEL Table
		/// </summary>
		private decimal _cancermodel_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.CANCERMODEL_ID = value; }
			get { return CANCERMODEL_ID; }
		}

		[RecordIDField("CANCERMODEL_ID"
			, AliasName = "CANCERMODEL_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "CANCERMODEL_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal CANCERMODEL_ID
		{
			set { _cancermodel_id = value; }
			get { return _cancermodel_id; }
		}
		/// <summary>
		/// The SAMPLE_NAME Field of CANCERMODEL Table
		/// </summary>
		private string _sample_name;
		[DataField("SAMPLE_NAME"
			, AliasName = "SAMPLE_NAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SAMPLE_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SAMPLE_NAME
		{
			set { _sample_name = value; }
			get { return _sample_name; }
		}
        /// <summary>
        /// The SAMPLE_NAME Field of CANCERMODEL Table
        /// </summary>
        private string _isdelete;
        [DataField("ISDELETE"
            , AliasName = "ISDELETE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 1
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ISDELETE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 4
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
		/// The ORIGINAL_ID Field of CANCERMODEL Table
		/// </summary>
		private string _original_id;
		[DataField("ORIGINAL_ID"
			, AliasName = "ORIGINAL_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ORIGINAL_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ORIGINAL_ID
		{
			set { _original_id = value; }
			get { return _original_id; }
		}
		/// <summary>
		/// The CANCER_TYPE Field of CANCERMODEL Table
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
			, SelectSequence = 9
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
		/// The SUBTYPE Field of CANCERMODEL Table
		/// </summary>
		private string _subtype;
		[DataField("SUBTYPE"
			, AliasName = "SUBTYPE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SUBTYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SUBTYPE
		{
			set { _subtype = value; }
			get { return _subtype; }
		}
		/// <summary>
		/// The GENDER Field of CANCERMODEL Table
		/// </summary>
		private string _gender;
		[DataField("GENDER"
			, AliasName = "GENDER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENDER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENDER
		{
			set { _gender = value; }
			get { return _gender; }
		}
		/// <summary>
		/// The AGE Field of CANCERMODEL Table
		/// </summary>
		private string _age;
		[DataField("AGE"
			, AliasName = "AGE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "AGE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string AGE
		{
			set { _age = value; }
			get { return _age; }
		}
		/// <summary>
		/// The STAGE Field of CANCERMODEL Table
		/// </summary>
		private string _stage;
		[DataField("STAGE"
			, AliasName = "STAGE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "STAGE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string STAGE
		{
			set { _stage = value; }
			get { return _stage; }
		}
		/// <summary>
		/// The GRADE Field of CANCERMODEL Table
		/// </summary>
		private string _grade;
		[DataField("GRADE"
			, AliasName = "GRADE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GRADE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GRADE
		{
			set { _grade = value; }
			get { return _grade; }
		}
		/// <summary>
		/// The SOURCE_ID Field of CANCERMODEL Table
		/// </summary>
		private string _source_id;
		[DataField("SOURCE_ID"
			, AliasName = "SOURCE_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 1000
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SOURCE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SOURCE_ID
		{
			set { _source_id = value; }
			get { return _source_id; }
		}
		/// <summary>
		/// The TREATMENT_HISTORY Field of CANCERMODEL Table
		/// </summary>
		private string _treatment_history;
		[DataField("TREATMENT_HISTORY"
			, AliasName = "TREATMENT_HISTORY"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TREATMENT_HISTORY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TREATMENT_HISTORY
		{
			set { _treatment_history = value; }
			get { return _treatment_history; }
		}
		/// <summary>
		/// The OTHER Field of CANCERMODEL Table
		/// </summary>
		private string _other;
		[DataField("OTHER"
			, AliasName = "OTHER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "OTHER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string OTHER
		{
			set { _other = value; }
			get { return _other; }
		}
		/// <summary>
		/// The AFFY_U219_DATA Field of CANCERMODEL Table
		/// </summary>
		private string _affy_u219_data;
		[DataField("AFFY_U219_DATA"
			, AliasName = "AFFY_U219_DATA"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "AFFY_U219_DATA"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 36
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string AFFY_U219_DATA
		{
			set { _affy_u219_data = value; }
			get { return _affy_u219_data; }
		}
		/// <summary>
		/// The AFFY_SNP6_DATA Field of CANCERMODEL Table
		/// </summary>
		private string _affy_snp6_data;
		[DataField("AFFY_SNP6_DATA"
			, AliasName = "AFFY_SNP6_DATA"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "AFFY_SNP6_DATA"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 39
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string AFFY_SNP6_DATA
		{
			set { _affy_snp6_data = value; }
			get { return _affy_snp6_data; }
		}
		/// <summary>
		/// The TMA Field of CANCERMODEL Table
		/// </summary>
		private string _tma;
		[DataField("TMA"
			, AliasName = "TMA"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TMA"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 42
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TMA
		{
			set { _tma = value; }
			get { return _tma; }
		}
		/// <summary>
		/// The FIT_FOR_EFFICACY Field of CANCERMODEL Table
		/// </summary>
		private string _fit_for_efficacy;
		[DataField("FIT_FOR_EFFICACY"
			, AliasName = "FIT_FOR_EFFICACY"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FIT_FOR_EFFICACY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 45
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FIT_FOR_EFFICACY
		{
			set { _fit_for_efficacy = value; }
			get { return _fit_for_efficacy; }
		}
		/// <summary>
		/// The SOC_DATA Field of CANCERMODEL Table
		/// </summary>
		private string _soc_data;
		[DataField("SOC_DATA"
			, AliasName = "SOC_DATA"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SOC_DATA"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 48
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SOC_DATA
		{
			set { _soc_data = value; }
			get { return _soc_data; }
		}
		/// <summary>
		/// The TIME_TO_100_MM3 Field of CANCERMODEL Table
		/// </summary>
		private string _time_to_100_mm3;
		[DataField("TIME_TO_100_MM3"
			, AliasName = "TIME_TO_100_MM3"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TIME_TO_100_MM3"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 51
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TIME_TO_100_MM3
		{
			set { _time_to_100_mm3 = value; }
			get { return _time_to_100_mm3; }
		}
		/// <summary>
		/// The DOUBLING_TIME Field of CANCERMODEL Table
		/// </summary>
		private string _doubling_time;
		[DataField("DOUBLING_TIME"
			, AliasName = "DOUBLING_TIME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DOUBLING_TIME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 54
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string DOUBLING_TIME
		{
			set { _doubling_time = value; }
			get { return _doubling_time; }
		}
		/// <summary>
		/// The TIME_TO_500_MM3 Field of CANCERMODEL Table
		/// </summary>
		private string _time_to_500_mm3;
		[DataField("TIME_TO_500_MM3"
			, AliasName = "TIME_TO_500_MM3"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TIME_TO_500_MM3"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 57
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TIME_TO_500_MM3
		{
			set { _time_to_500_mm3 = value; }
			get { return _time_to_500_mm3; }
		}
		/// <summary>
		/// CANCERMODEL Table 
		/// </summary>
		public const string TABLE_NAME="CANCERMODEL";
		public const String CANCERMODEL_ID_FIELD  ="CANCERMODEL_ID";
		public const String SAMPLE_NAME_FIELD  ="SAMPLE_NAME";
        public const String ISDELETE_FIELD = "ISDELETE";
		public const String ORIGINAL_ID_FIELD  ="ORIGINAL_ID";
		public const String CANCER_TYPE_FIELD  ="CANCER_TYPE";
		public const String SUBTYPE_FIELD  ="SUBTYPE";
		public const String GENDER_FIELD  ="GENDER";
		public const String AGE_FIELD  ="AGE";
		public const String STAGE_FIELD  ="STAGE";
		public const String GRADE_FIELD  ="GRADE";
		public const String SOURCE_ID_FIELD  ="SOURCE_ID";
		public const String TREATMENT_HISTORY_FIELD  ="TREATMENT_HISTORY";
		public const String OTHER_FIELD  ="OTHER";
		public const String AFFY_U219_DATA_FIELD  ="AFFY_U219_DATA";
		public const String AFFY_SNP6_DATA_FIELD  ="AFFY_SNP6_DATA";
		public const String TMA_FIELD  ="TMA";
		public const String FIT_FOR_EFFICACY_FIELD  ="FIT_FOR_EFFICACY";
		public const String SOC_DATA_FIELD  ="SOC_DATA";
		public const String TIME_TO_100_MM3_FIELD  ="TIME_TO_100_MM3";
		public const String DOUBLING_TIME_FIELD  ="DOUBLING_TIME";
		public const String TIME_TO_500_MM3_FIELD  ="TIME_TO_500_MM3";
	}
}