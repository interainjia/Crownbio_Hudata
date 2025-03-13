using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for XENO_DATA Table
	/// </summary>
	[Serializable]
	[DataTable("XENO_DATA",ResourceKey = "XENO_DATA")]
	public class XENO_DATA: BaseObject
	{
		public XENO_DATA()
		{
		}
		public XENO_DATA(DealModel initModel):base(initModel)
		{
		}
		public static XENO_DATA Convert(BaseObject from)
		{
			return (XENO_DATA)from;
		}
		/// <summary>
		/// The XENO_DATA_ID Field of XENO_DATA Table
		/// </summary>
		private decimal _xeno_data_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.XENO_DATA_ID = value; }
			get { return XENO_DATA_ID; }
		}

		[RecordIDField("XENO_DATA_ID"
			, AliasName = "XENO_DATA_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "XENO_DATA_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal XENO_DATA_ID
		{
			set { _xeno_data_id = value; }
			get { return _xeno_data_id; }
		}
		/// <summary>
		/// The CELLLINE Field of XENO_DATA Table
		/// </summary>
		private string _cellline;
		[DataField("CELLLINE"
			, AliasName = "CELLLINE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "CELLLINE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CELLLINE
		{
			set { _cellline = value; }
			get { return _cellline; }
		}
		/// <summary>
		/// The MODELCLASS Field of XENO_DATA Table
		/// </summary>
		private string _modelclass;
		[DataField("MODELCLASS"
			, AliasName = "MODELCLASS"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MODELCLASS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MODELCLASS
		{
			set { _modelclass = value; }
			get { return _modelclass; }
		}
        /// <summary>
        /// The DRUG Field of XENO_SOCDATA Table
        /// </summary>
        private string _drug;
        [DataField("DRUG"
            , AliasName = "DRUG"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DRUG"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DRUG
        {
            set { _drug = value; }
            get { return _drug; }
        }
		/// <summary>
		/// XENO_DATA Table 
		/// </summary>
		public const string TABLE_NAME="XENO_DATA";
		public const String XENO_DATA_ID_FIELD  ="XENO_DATA_ID";
		public const String CELLLINE_FIELD  ="CELLLINE";
		public const String MODELCLASS_FIELD  ="MODELCLASS";
        public const String DRUG_FIELD = "DRUG";
	}
}