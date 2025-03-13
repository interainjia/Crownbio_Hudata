using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for XENO_PIC Table
	/// </summary>
	[Serializable]
	[DataTable("XENO_PIC",ResourceKey = "XENO_PIC")]
	public class XENO_PIC: BaseObject
	{
		public XENO_PIC()
		{
		}
		public XENO_PIC(DealModel initModel):base(initModel)
		{
		}
		public static XENO_PIC Convert(BaseObject from)
		{
			return (XENO_PIC)from;
		}
		/// <summary>
		/// The XENO_PIC_ID Field of XENO_PIC Table
		/// </summary>
		private decimal _xeno_pic_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.XENO_PIC_ID = value; }
			get { return XENO_PIC_ID; }
		}

		[RecordIDField("XENO_PIC_ID"
			, AliasName = "XENO_PIC_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "XENO_PIC_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal XENO_PIC_ID
		{
			set { _xeno_pic_id = value; }
			get { return _xeno_pic_id; }
		}
		/// <summary>
		/// The PIC_URL Field of XENO_PIC Table
		/// </summary>
		private string _pic_url;
		[DataField("PIC_URL"
			, AliasName = "PIC_URL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PIC_URL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PIC_URL
		{
			set { _pic_url = value; }
			get { return _pic_url; }
		}
		/// <summary>
		/// The CELLLINE Field of XENO_PIC Table
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
			, SelectSequence = 6
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
        /// The XENOID Field of XENO_PIC Table
        /// </summary>
        private string _xenoid;
        [DataField("XENOID"
            , AliasName = "XENOID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "XENOID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string XENOID
        {
            set { _xenoid = value; }
            get { return _xenoid; }
        }
        /// <summary>
        /// The REMARK Field of XENO_PIC Table
        /// </summary>
        private string _remark;
        [DataField("REMARK"
            , AliasName = "REMARK"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REMARK"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REMARK
        {
            set { _remark = value; }
            get { return _remark; }
        }

		/// <summary>
		/// XENO_PIC Table 
		/// </summary>
		public const string TABLE_NAME="XENO_PIC";
		public const String XENO_PIC_ID_FIELD  ="XENO_PIC_ID";
		public const String PIC_URL_FIELD  ="PIC_URL";
		public const String CELLLINE_FIELD  ="CELLLINE";
        public const String XENOID_FIELD = "XENOID";
        public const String REMARK_FIELD = "REMARK";
	}
}