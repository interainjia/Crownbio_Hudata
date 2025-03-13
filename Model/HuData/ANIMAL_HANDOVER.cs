using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for ANIMAL_HANDOVER Table
	/// </summary>
	[Serializable]
	[DataTable("ANIMAL_HANDOVER",ResourceKey = "ANIMAL_HANDOVER")]
	public class ANIMAL_HANDOVER: BaseObject
	{
		public ANIMAL_HANDOVER()
		{
		}
		public ANIMAL_HANDOVER(DealModel initModel):base(initModel)
		{
		}
		public static ANIMAL_HANDOVER Convert(BaseObject from)
		{
			return (ANIMAL_HANDOVER)from;
		}
		/// <summary>
		/// The ANIMAL_HANDOVER_ID Field of ANIMAL_HANDOVER Table
		/// </summary>
		private decimal _animal_handover_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.ANIMAL_HANDOVER_ID = value; }
			get { return ANIMAL_HANDOVER_ID; }
		}

		[RecordIDField("ANIMAL_HANDOVER_ID"
			, AliasName = "ANIMAL_HANDOVER_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "ANIMAL_HANDOVER_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal ANIMAL_HANDOVER_ID
		{
			set { _animal_handover_id = value; }
			get { return _animal_handover_id; }
		}
		/// <summary>
		/// The REQUEST_ID Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _request_id;
		[DataField("REQUEST_ID"
			, AliasName = "REQUEST_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
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
		public string REQUEST_ID
		{
			set { _request_id = value; }
			get { return _request_id; }
		}
		/// <summary>
		/// The MODEL_ID Field of ANIMAL_HANDOVER Table
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
		/// The TISSUE_BATCH Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _tissue_batch;
		[DataField("TISSUE_BATCH"
			, AliasName = "TISSUE_BATCH"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TISSUE_BATCH"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TISSUE_BATCH
		{
			set { _tissue_batch = value; }
			get { return _tissue_batch; }
		}
		/// <summary>
		/// The DATE_OF_TISSUE Field of ANIMAL_HANDOVER Table
		/// </summary>
		private DateTime _date_of_tissue;
		[DataField("DATE_OF_TISSUE"
			, AliasName = "DATE_OF_TISSUE"
            , DataType = DbType.Date
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_TISSUE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_OF_TISSUE
		{
			set { _date_of_tissue = value; }
			get { return _date_of_tissue; }
		}
		/// <summary>
		/// The ANIMAL_BY_TISSUE Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _animal_by_tissue;
		[DataField("ANIMAL_BY_TISSUE"
			, AliasName = "ANIMAL_BY_TISSUE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANIMAL_BY_TISSUE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANIMAL_BY_TISSUE
		{
			set { _animal_by_tissue = value; }
			get { return _animal_by_tissue; }
		}
		/// <summary>
		/// The SOURCE_PROJECT Field of ANIMAL_HANDOVER Table
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
			, SelectSequence = 18
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
		/// The LEADER Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _leader;
		[DataField("LEADER"
			, AliasName = "LEADER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "LEADER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LEADER
		{
			set { _leader = value; }
			get { return _leader; }
		}
		/// <summary>
		/// The MODELBATCH1 Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _modelbatch1;
		[DataField("MODELBATCH1"
			, AliasName = "MODELBATCH1"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MODELBATCH1"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MODELBATCH1
		{
			set { _modelbatch1 = value; }
			get { return _modelbatch1; }
		}
		/// <summary>
		/// The ANIMAL_BY_LIVE Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _animal_by_live;
		[DataField("ANIMAL_BY_LIVE"
			, AliasName = "ANIMAL_BY_LIVE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANIMAL_BY_LIVE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANIMAL_BY_LIVE
		{
			set { _animal_by_live = value; }
			get { return _animal_by_live; }
		}
		/// <summary>
		/// The IVC Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _ivc;
		[DataField("IVC"
			, AliasName = "IVC"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "IVC"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string IVC
		{
			set { _ivc = value; }
			get { return _ivc; }
		}
		/// <summary>
		/// The EXPECTED_DATE_TO_SUPPORT Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _expected_date_to_support;
		[DataField("EXPECTED_DATE_TO_SUPPORT"
			, AliasName = "EXPECTED_DATE_TO_SUPPORT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 25
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "EXPECTED_DATE_TO_SUPPORT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string EXPECTED_DATE_TO_SUPPORT
		{
			set { _expected_date_to_support = value; }
			get { return _expected_date_to_support; }
		}
		/// <summary>
		/// The DATE_OF_DELIVER Field of ANIMAL_HANDOVER Table
		/// </summary>
        private string _date_of_deliver;
		[DataField("DATE_OF_DELIVER"
			, AliasName = "DATE_OF_DELIVER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_DELIVER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 36
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
        public string DATE_OF_DELIVER
		{
			set { _date_of_deliver = value; }
			get { return _date_of_deliver; }
		}
		/// <summary>
		/// The RECEIVING_PROJECT Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _receiving_project;
		[DataField("RECEIVING_PROJECT"
			, AliasName = "RECEIVING_PROJECT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 25
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "RECEIVING_PROJECT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 39
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string RECEIVING_PROJECT
		{
			set { _receiving_project = value; }
			get { return _receiving_project; }
		}
		/// <summary>
		/// The JSD Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _jsd;
		[DataField("JSD"
			, AliasName = "JSD"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 25
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "JSD"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 42
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string JSD
		{
			set { _jsd = value; }
			get { return _jsd; }
		}
		/// <summary>
		/// The MODELBATCH2 Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _modelbatch2;
		[DataField("MODELBATCH2"
			, AliasName = "MODELBATCH2"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MODELBATCH2"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 45
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MODELBATCH2
		{
			set { _modelbatch2 = value; }
			get { return _modelbatch2; }
		}
		/// <summary>
		/// The HEALTHY_AND_ALIVE Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _healthy_and_alive;
		[DataField("HEALTHY_AND_ALIVE"
			, AliasName = "HEALTHY_AND_ALIVE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "HEALTHY_AND_ALIVE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 48
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string HEALTHY_AND_ALIVE
		{
			set { _healthy_and_alive = value; }
			get { return _healthy_and_alive; }
		}
		/// <summary>
		/// The ANIMAL_DEAD Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _animal_dead;
		[DataField("ANIMAL_DEAD"
			, AliasName = "ANIMAL_DEAD"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANIMAL_DEAD"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 51
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANIMAL_DEAD
		{
			set { _animal_dead = value; }
			get { return _animal_dead; }
		}
		/// <summary>
		/// The DATE_OF_RECEIVE Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _date_of_receive;
		[DataField("DATE_OF_RECEIVE"
			, AliasName = "DATE_OF_RECEIVE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 3
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DATE_OF_RECEIVE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 54
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string DATE_OF_RECEIVE
		{
			set { _date_of_receive = value; }
			get { return _date_of_receive; }
		}
		/// <summary>
		/// The INOCULATION_USED Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _inoculation_used;
		[DataField("INOCULATION_USED"
			, AliasName = "INOCULATION_USED"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "INOCULATION_USED"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 57
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string INOCULATION_USED
		{
			set { _inoculation_used = value; }
			get { return _inoculation_used; }
		}
		/// <summary>
		/// The TISSUE_COLLECTION Field of ANIMAL_HANDOVER Table
		/// </summary>
		private string _tissue_collection;
		[DataField("TISSUE_COLLECTION"
			, AliasName = "TISSUE_COLLECTION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TISSUE_COLLECTION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 60
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TISSUE_COLLECTION
		{
			set { _tissue_collection = value; }
			get { return _tissue_collection; }
		}
		/// <summary>
		/// ANIMAL_HANDOVER Table 
		/// </summary>
		public const string TABLE_NAME="ANIMAL_HANDOVER";
		public const String ANIMAL_HANDOVER_ID_FIELD  ="ANIMAL_HANDOVER_ID";
		public const String REQUEST_ID_FIELD  ="REQUEST_ID";
		public const String MODEL_ID_FIELD  ="MODEL_ID";
		public const String TISSUE_BATCH_FIELD  ="TISSUE_BATCH";
		public const String DATE_OF_TISSUE_FIELD  ="DATE_OF_TISSUE";
		public const String ANIMAL_BY_TISSUE_FIELD  ="ANIMAL_BY_TISSUE";
		public const String SOURCE_PROJECT_FIELD  ="SOURCE_PROJECT";
		public const String LEADER_FIELD  ="LEADER";
		public const String MODELBATCH1_FIELD  ="MODELBATCH1";
		public const String ANIMAL_BY_LIVE_FIELD  ="ANIMAL_BY_LIVE";
		public const String IVC_FIELD  ="IVC";
		public const String EXPECTED_DATE_TO_SUPPORT_FIELD  ="EXPECTED_DATE_TO_SUPPORT";
		public const String DATE_OF_DELIVER_FIELD  ="DATE_OF_DELIVER";
		public const String RECEIVING_PROJECT_FIELD  ="RECEIVING_PROJECT";
		public const String JSD_FIELD  ="JSD";
		public const String MODELBATCH2_FIELD  ="MODELBATCH2";
		public const String HEALTHY_AND_ALIVE_FIELD  ="HEALTHY_AND_ALIVE";
		public const String ANIMAL_DEAD_FIELD  ="ANIMAL_DEAD";
		public const String DATE_OF_RECEIVE_FIELD  ="DATE_OF_RECEIVE";
		public const String INOCULATION_USED_FIELD  ="INOCULATION_USED";
		public const String TISSUE_COLLECTION_FIELD  ="TISSUE_COLLECTION";
	}
}