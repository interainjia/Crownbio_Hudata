using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for SPECIMEN_STOCK Table
	/// </summary>
	[Serializable]
	[DataTable("SPECIMEN_STOCK",ResourceKey = "SPECIMEN_STOCK")]
	public class SPECIMEN_STOCK: BaseObject
	{
		public SPECIMEN_STOCK()
		{
		}
		public SPECIMEN_STOCK(DealModel initModel):base(initModel)
		{
		}
		public static SPECIMEN_STOCK Convert(BaseObject from)
		{
			return (SPECIMEN_STOCK)from;
		}
		/// <summary>
		/// The SPECIMEN_STOCK_ID Field of SPECIMEN_STOCK Table
		/// </summary>
		private decimal _specimen_stock_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.SPECIMEN_STOCK_ID = value; }
			get { return SPECIMEN_STOCK_ID; }
		}

		[RecordIDField("SPECIMEN_STOCK_ID"
			, AliasName = "SPECIMEN_STOCK_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "SPECIMEN_STOCK_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal SPECIMEN_STOCK_ID
		{
			set { _specimen_stock_id = value; }
			get { return _specimen_stock_id; }
		}
		/// <summary>
		/// The MODEL_ID Field of SPECIMEN_STOCK Table
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
		/// The RN Field of SPECIMEN_STOCK Table
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
			, SelectSequence = 6
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
		/// The PN Field of SPECIMEN_STOCK Table
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
			, SelectSequence = 9
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
		/// The DATE_OF_INOCULATION Field of SPECIMEN_STOCK Table
		/// </summary>
		private DateTime _date_of_inoculation;
		[DataField("DATE_OF_INOCULATION"
			, AliasName = "DATE_OF_INOCULATION"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_INOCULATION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_OF_INOCULATION
		{
			set { _date_of_inoculation = value; }
			get { return _date_of_inoculation; }
		}
		/// <summary>
		/// The ANIMAL_NUMBER Field of SPECIMEN_STOCK Table
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
			, SelectSequence = 15
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
        /// The TOTAL_TUMOR_VOLUME Field of SPECIMEN_STOCK Table
        /// </summary>
        private string _total_tumor_volume;
        [DataField("TOTAL_TUMOR_VOLUME"
            , AliasName = "TOTAL_TUMOR_VOLUME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TOTAL_TUMOR_VOLUME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 16
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TOTAL_TUMOR_VOLUME
        {
            set { _total_tumor_volume = value; }
            get { return _total_tumor_volume; }
        }

		/// <summary>
		/// The DATE_OF_TISSUE_COLLECTION Field of SPECIMEN_STOCK Table
		/// </summary>
		private DateTime _date_of_tissue_collection;
		[DataField("DATE_OF_TISSUE_COLLECTION"
			, AliasName = "DATE_OF_TISSUE_COLLECTION"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_TISSUE_COLLECTION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_OF_TISSUE_COLLECTION
		{
			set { _date_of_tissue_collection = value; }
			get { return _date_of_tissue_collection; }
		}
		/// <summary>
		/// The SITE_OF_TISSUE_COLLECTION Field of SPECIMEN_STOCK Table
		/// </summary>
		private string _site_of_tissue_collection;
		[DataField("SITE_OF_TISSUE_COLLECTION"
			, AliasName = "SITE_OF_TISSUE_COLLECTION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SITE_OF_TISSUE_COLLECTION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SITE_OF_TISSUE_COLLECTION
		{
			set { _site_of_tissue_collection = value; }
			get { return _site_of_tissue_collection; }
		}
		/// <summary>
		/// The TISSUE_TYPE Field of SPECIMEN_STOCK Table
		/// </summary>
		private string _tissue_type;
		[DataField("TISSUE_TYPE"
			, AliasName = "TISSUE_TYPE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TISSUE_TYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TISSUE_TYPE
		{
			set { _tissue_type = value; }
			get { return _tissue_type; }
		}
		/// <summary>
		/// The PRESERVE_METHOD Field of SPECIMEN_STOCK Table
		/// </summary>
		private string _preserve_method;
		[DataField("PRESERVE_METHOD"
			, AliasName = "PRESERVE_METHOD"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PRESERVE_METHOD"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PRESERVE_METHOD
		{
			set { _preserve_method = value; }
			get { return _preserve_method; }
		}
		/// <summary>
		/// The TREATMENT_TO_MICE Field of SPECIMEN_STOCK Table
		/// </summary>
		private string _treatment_to_mice;
		[DataField("TREATMENT_TO_MICE"
			, AliasName = "TREATMENT_TO_MICE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TREATMENT_TO_MICE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TREATMENT_TO_MICE
		{
			set { _treatment_to_mice = value; }
			get { return _treatment_to_mice; }
		}
		/// <summary>
		/// The LOCATION_ID Field of SPECIMEN_STOCK Table
		/// </summary>
		private string _location_id;
		[DataField("LOCATION_ID"
			, AliasName = "LOCATION_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "LOCATION_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LOCATION_ID
		{
			set { _location_id = value; }
			get { return _location_id; }
		}
		/// <summary>
		/// The WELL_ID Field of SPECIMEN_STOCK Table
		/// </summary>
		private string _well_id;
		[DataField("WELL_ID"
			, AliasName = "WELL_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "WELL_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 36
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string WELL_ID
		{
			set { _well_id = value; }
			get { return _well_id; }
		}

        /// <summary>
		/// The IMPORT_DATE Field of SPECIMEN_STOCK Table
		/// </summary>
		private DateTime _import_date;
		[DataField("IMPORT_DATE"
			, AliasName = "IMPORT_DATE"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "IMPORT_DATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 39
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public DateTime IMPORT_DATE
		{
			set { _import_date = value; }
			get { return _import_date; }
		}
		/// <summary>
		/// The IMPORT_PROJECT_NUMBER Field of SPECIMEN_STOCK Table
		/// </summary>
		private string _import_project_number;
		[DataField("IMPORT_PROJECT_NUMBER"
			, AliasName = "IMPORT_PROJECT_NUMBER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "IMPORT_PROJECT_NUMBER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 42
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string IMPORT_PROJECT_NUMBER
		{
			set { _import_project_number = value; }
			get { return _import_project_number; }
		}


        private string _str;
        [DataField("STR"
            , AliasName = "STR"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "STR"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 45
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string STR
        {
            set { _str = value; }
            get { return _str; }
        }

        private string _region;
        public string REGION
        {
            set { _region = value; }
            get { return _region; }
        }
		/// <summary>
		/// SPECIMEN_STOCK Table 
		/// </summary>
		public const string TABLE_NAME="SPECIMEN_STOCK";
		public const String SPECIMEN_STOCK_ID_FIELD  ="SPECIMEN_STOCK_ID";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
		public const String RN_FIELD  ="RN";
		public const String PN_FIELD  ="PN";
		public const String DATE_OF_INOCULATION_FIELD  ="DATE_OF_INOCULATION";
		public const String ANIMAL_NUMBER_FIELD  ="ANIMAL_NUMBER";
        public const String TOTAL_TUMOR_VOLUME_FIELD = "TOTAL_TUMOR_VOLUME";
		public const String DATE_OF_TISSUE_COLLECTION_FIELD  ="DATE_OF_TISSUE_COLLECTION";
		public const String SITE_OF_TISSUE_COLLECTION_FIELD  ="SITE_OF_TISSUE_COLLECTION";
		public const String TISSUE_TYPE_FIELD  ="TISSUE_TYPE";
		public const String PRESERVE_METHOD_FIELD  ="PRESERVE_METHOD";
		public const String TREATMENT_TO_MICE_FIELD  ="TREATMENT_TO_MICE";
		public const String LOCATION_ID_FIELD  ="LOCATION_ID";
		public const String WELL_ID_FIELD  ="WELL_ID";
		public const String IMPORT_DATE_FIELD  ="IMPORT_DATE";
		public const String IMPORT_PROJECT_NUMBER_FIELD  ="IMPORT_PROJECT_NUMBER";
        public const String STR_FIELD = "STR";
        public const String REGION_FIELD = "REGION";
        
	}
}