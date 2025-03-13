using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for TISSUE_WITHDRAW Table
	/// </summary>
	[Serializable]
	[DataTable("TISSUE_WITHDRAW",ResourceKey = "TISSUE_WITHDRAW")]
	public class TISSUE_WITHDRAW: BaseObject
	{
		public TISSUE_WITHDRAW()
		{
		}
		public TISSUE_WITHDRAW(DealModel initModel):base(initModel)
		{
		}
		public static TISSUE_WITHDRAW Convert(BaseObject from)
		{
			return (TISSUE_WITHDRAW)from;
		}
		/// <summary>
		/// The TISSUE_WITHDRAW_ID Field of TISSUE_WITHDRAW Table
		/// </summary>
		private decimal _tissue_withdraw_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.TISSUE_WITHDRAW_ID = value; }
			get { return TISSUE_WITHDRAW_ID; }
		}
        public override string CODE
        {
            set
            {
                base.CODE = value;
                this.SPECIMEN_STOCK_ID = value;
            }
            get { return SPECIMEN_STOCK_ID; }
        }
		[RecordIDField("TISSUE_WITHDRAW_ID"
			, AliasName = "TISSUE_WITHDRAW_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "TISSUE_WITHDRAW_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal TISSUE_WITHDRAW_ID
		{
			set { _tissue_withdraw_id = value; }
			get { return _tissue_withdraw_id; }
		}
		/// <summary>
		/// The SPECIMEN_STOCK_ID Field of TISSUE_WITHDRAW Table
		/// </summary>
		private string _specimen_stock_id;
		[KeyField("SPECIMEN_STOCK_ID"
			, AliasName = "SPECIMEN_STOCK_ID"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SPECIMEN_STOCK_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public string SPECIMEN_STOCK_ID
		{
			set { _specimen_stock_id = value; }
			get { return _specimen_stock_id; }
		}
		/// <summary>
		/// The MODEL_ID Field of TISSUE_WITHDRAW Table
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
        /// The CONFIRM Field of TISSUE_WITHDRAW Table
        /// </summary>
        private string _confirm;
        [DataField("CONFIRM"
            , AliasName = "CONFIRM"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 5
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CONFIRM"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 7
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CONFIRM
        {
            set { _confirm = value; }
            get { return _confirm; }
        }
		/// <summary>
		/// The RN Field of TISSUE_WITHDRAW Table
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
		/// The PN Field of TISSUE_WITHDRAW Table
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
		/// The DATE_OF_INOCULATION Field of TISSUE_WITHDRAW Table
		/// </summary>
		private  DateTime _date_of_inoculation;
		[DataField("DATE_OF_INOCULATION"
			, AliasName = "DATE_OF_INOCULATION"
			, DataType =  DbType.DateTime2
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
			, SelectSequence = 15
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
		/// The ANIMAL_NUMBER Field of TISSUE_WITHDRAW Table
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
        /// The TOTAL_TUMOR_VOLUME Field of TISSUE_WITHDRAW Table
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
            , SelectSequence = 21
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
		/// The DATE_OF_TISSUE_COLLECTION Field of TISSUE_WITHDRAW Table
		/// </summary>
		private DateTime _date_of_tissue_collection;
		[DataField("DATE_OF_TISSUE_COLLECTION"
			, AliasName = "DATE_OF_TISSUE_COLLECTION"
            , DataType = DbType.DateTime2
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
			, SelectSequence = 24
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
		/// The SITE_OF_TISSUE_COLLECTION Field of TISSUE_WITHDRAW Table
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
			, SelectSequence = 27
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
		/// The TISSUE_TYPE Field of TISSUE_WITHDRAW Table
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
			, SelectSequence = 30
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
		/// The PRESERVE_METHOD Field of TISSUE_WITHDRAW Table
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
			, SelectSequence = 33
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
		/// The TREATMENT_TO_MICE Field of TISSUE_WITHDRAW Table
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
			, SelectSequence = 36
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
		/// The LOCATION_ID Field of TISSUE_WITHDRAW Table
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
			, SelectSequence = 39
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
		/// The WELL_ID Field of TISSUE_WITHDRAW Table
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
			, SelectSequence = 42
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
		/// The WITHDRAW_DATE Field of TISSUE_WITHDRAW Table
		/// </summary>
		private DateTime _withdraw_date;
		[DataField("WITHDRAW_DATE"
			, AliasName = "WITHDRAW_DATE"
			, DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "WITHDRAW_DATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 45
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime WITHDRAW_DATE
		{
			set { _withdraw_date = value; }
			get { return _withdraw_date; }
		}
		/// <summary>
		/// The WITHDRAW_PROJECT_NUMBER Field of TISSUE_WITHDRAW Table
		/// </summary>
		private string _withdraw_project_number;
		[DataField("WITHDRAW_PROJECT_NUMBER"
			, AliasName = "WITHDRAW_PROJECT_NUMBER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "WITHDRAW_PROJECT_NUMBER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 48
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string WITHDRAW_PROJECT_NUMBER
		{
			set { _withdraw_project_number = value; }
			get { return _withdraw_project_number; }
		}
		/// <summary>
		/// TISSUE_WITHDRAW Table 
		/// </summary>
		public const string TABLE_NAME="TISSUE_WITHDRAW";
		public const String TISSUE_WITHDRAW_ID_FIELD  ="TISSUE_WITHDRAW_ID";
		public const String SPECIMEN_STOCK_ID_FIELD  ="SPECIMEN_STOCK_ID";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
        public const String CONFIRM_FIELD = "CONFIRM";
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
        public const String WITHDRAW_DATE_FIELD = "WITHDRAW_DATE";
        public const String WITHDRAW_PROJECT_NUMBER_FIELD = "WITHDRAW_PROJECT_NUMBER";
	}
}