using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for APP_ORDER Table
	/// </summary>
	[Serializable]
	[DataTable("APP_ORDER",ResourceKey = "APP_ORDER")]
	public class APP_ORDER: BaseObject
	{
		public APP_ORDER()
		{
		}
		public APP_ORDER(DealModel initModel):base(initModel)
		{
		}
		public static APP_ORDER Convert(BaseObject from)
		{
			return (APP_ORDER)from;
		}
		/// <summary>
		/// The ORDER_ID Field of APP_ORDER Table
		/// </summary>
		private decimal _order_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.ORDER_ID = value; }
			get { return ORDER_ID; }
		}

		[RecordIDField("ORDER_ID"
			, AliasName = "ORDER_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "ORDER_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal ORDER_ID
		{
			set { _order_id = value; }
			get { return _order_id; }
		}
		/// <summary>
		/// The ORDER_CODE Field of APP_ORDER Table
		/// </summary>
		private string _order_code;
		[KeyField("ORDER_CODE"
			, AliasName = "ORDER_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "ORDER_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string ORDER_CODE
		{
			set { _order_code = value; }
			get { return _order_code; }
		}
		/// <summary>
		/// The PRODUCT_CODE Field of APP_ORDER Table
		/// </summary>
		private string _product_code;
        //[DataField("PRODUCT_CODE"
        //    , AliasName = "PRODUCT_CODE"
        //    , DataType = DbType.String
        //    , IsNullable = false
        //    , Size = 20
        //    , Width = 100
        //    , DisplayInCondition = true
        //    , DisplayInMaintain = true
        //    , DisplayInDialog = false
        //    , ResourceKey = "PRODUCT_CODE"
        //    , GroupFun = "MAX"
        //    , AllowEdit = false
        //    , Frozen = false
        //    , SelectSequence = 6
        //    , DialogSequence = -1
        //    , IsInsertField = true
        //    , IsUpdateField = true
        //     )]
        //public string PRODUCT_CODE
        //{
        //    set { _product_code = value; }
        //    get { return _product_code; }
        //}

        [ForeignKeyField("PRODUCT_CODE"
            , AliasName = "PRODUCT_CODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PRODUCT_CODE"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = APP_PRODUCT.TABLE_NAME
            , ForeignTableAliasName = APP_PRODUCT.TABLE_NAME
            , ForeignColumnName = APP_PRODUCT.PRODUCT_CODE_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.InnerJoin
            , TableJoinSequence = 0
             )]
        public string PRODUCT_CODE
        {
            set { _product_code = value; }
            get { return _product_code; }
        }

        private string _product_name;
        [ForeignField("PRODUCT_NAME"
            , AliasName = "PRODUCT_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 200
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , ResourceKey = "PRODUCT_NAME"
            , AllowEdit = false
            , SelectSequence = 4
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = APP_PRODUCT.TABLE_NAME
            , ForeignTableAliasName = APP_PRODUCT.TABLE_NAME
            , ForeignColumnName = APP_PRODUCT.PRODUCT_NAME_FIELD
             )]
        public string PRODUCT_NAME
        {
            set { _product_name = value; }
            get { return _product_name; }
        }

		/// <summary>
		/// The ORDER_SUM Field of APP_ORDER Table
		/// </summary>
		private string _order_sum;
		[DataField("ORDER_SUM"
			, AliasName = "ORDER_SUM"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 500
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ORDER_SUM"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ORDER_SUM
		{
			set { _order_sum = value; }
			get { return _order_sum; }
		}
		/// <summary>
		/// The ORDER_TIME Field of APP_ORDER Table
		/// </summary>
		private DateTime _order_time;
		[DataField("ORDER_TIME"
			, AliasName = "ORDER_TIME"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ORDER_TIME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime ORDER_TIME
		{
			set { _order_time = value; }
			get { return _order_time; }
		}
		/// <summary>
		/// The USR_CODE Field of APP_ORDER Table
		/// </summary>
		private string _usr_code;
		[DataField("USR_CODE"
			, AliasName = "USR_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USR_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USR_CODE
		{
			set { _usr_code = value; }
			get { return _usr_code; }
		}
		/// <summary>
		/// The REMARK Field of APP_ORDER Table
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
			, SelectSequence = 18
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
		/// The CREATE_BY Field of APP_ORDER Table
		/// </summary>
		private decimal _create_by;
		[DataField("CREATE_BY"
			, AliasName = "CREATE_BY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 9
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "CREATE_BY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 101
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = false
			, DefaultValue = "UserID"
			 )]
		public decimal CREATE_BY
		{
			set { _create_by = value; }
			get { return _create_by; }
		}
		/// <summary>
		/// The CREATE_TIME Field of APP_ORDER Table
		/// </summary>
		private DateTime _create_time;
		[DataField("CREATE_TIME"
			, AliasName = "CREATE_TIME"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "CREATE_TIME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 102
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = false
			, DefaultValue = "SysDate"
			 )]
		public DateTime CREATE_TIME
		{
			set { _create_time = value; }
			get { return _create_time; }
		}
		/// <summary>
		/// The UPDATE_BY Field of APP_ORDER Table
		/// </summary>
		private decimal _update_by;
		[DataField("UPDATE_BY"
			, AliasName = "UPDATE_BY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 9
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "UPDATE_BY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 103
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			, DefaultValue = "UserID"
			 )]
		public decimal UPDATE_BY
		{
			set { _update_by = value; }
			get { return _update_by; }
		}
		/// <summary>
		/// The UPDATE_TIME Field of APP_ORDER Table
		/// </summary>
		private DateTime _update_time;
		[DataField("UPDATE_TIME"
			,AliasName = "UPDATE_TIME"
			,DataType = DbType.DateTime
			,IsNullable = false
			,Size = 20
			,DisplayInCondition = false
			,DisplayInMaintain = false
			, DisplayInDialog = false
			,ResourceKey = "UPDATE_TIME"
			, GroupFun = "MAX"
			,AllowEdit = false
			,SelectSequence = 104
			, DialogSequence = -1
			,Frozen = false
			,IsInsertField = true
			,IsUpdateField = true
			,DefaultValue = "SysDate"
			 )]
		public DateTime UPDATE_TIME
		{
			set { _update_time = value; }
			get { return _update_time; }
		}
		/// <summary>
		/// APP_ORDER Table 
		/// </summary>
		public const string TABLE_NAME="APP_ORDER";
		public const String ORDER_ID_FIELD  ="ORDER_ID";
		public const String ORDER_CODE_FIELD  ="ORDER_CODE";
		public const String PRODUCT_CODE_FIELD  ="PRODUCT_CODE";
		public const String ORDER_SUM_FIELD  ="ORDER_SUM";
		public const String ORDER_TIME_FIELD  ="ORDER_TIME";
		public const String USR_CODE_FIELD  ="USR_CODE";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}