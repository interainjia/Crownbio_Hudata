using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for SYS_USER_GENE Table
	/// </summary>
	[Serializable]
	[DataTable("SYS_USER_GENE",ResourceKey = "SYS_USER_GENE")]
	public class SYS_USER_GENE: BaseObject
	{
		public SYS_USER_GENE()
		{
		}
		public SYS_USER_GENE(DealModel initModel):base(initModel)
		{
		}
		public static SYS_USER_GENE Convert(BaseObject from)
		{
			return (SYS_USER_GENE)from;
		}
		/// <summary>
		/// The USER_GENE_ID Field of SYS_USER_GENE Table
		/// </summary>
		private decimal _user_gene_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.USER_GENE_ID = value; }
			get { return USER_GENE_ID; }
		}

		[RecordIDField("USER_GENE_ID"
			, AliasName = "USER_GENE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "USER_GENE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal USER_GENE_ID
		{
			set { _user_gene_id = value; }
			get { return _user_gene_id; }
		}
		/// <summary>
		/// The USER_ID Field of SYS_USER_GENE Table
		/// </summary>
		private decimal _user_id;
		[DataField("USER_ID"
			, AliasName = "USER_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USER_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal USER_ID
		{
			set { _user_id = value; }
			get { return _user_id; }
		}
		/// <summary>
		/// The USER_CODE Field of SYS_USER_GENE Table
		/// </summary>
		private string _user_code;
		[DataField("USER_CODE"
			, AliasName = "USER_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USER_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USER_CODE
		{
			set { _user_code = value; }
			get { return _user_code; }
		}
		/// <summary>
		/// The USER_NAME Field of SYS_USER_GENE Table
		/// </summary>
		private string _user_name;
		[DataField("USER_NAME"
			, AliasName = "USER_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USER_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USER_NAME
		{
			set { _user_name = value; }
			get { return _user_name; }
		}
		/// <summary>
		/// The GENENAME Field of SYS_USER_GENE Table
		/// </summary>
		private string _genename;
		[DataField("GENENAME"
			, AliasName = "GENENAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENENAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENENAME
		{
			set { _genename = value; }
			get { return _genename; }
		}
		/// <summary>
		/// The REMARK Field of SYS_USER_GENE Table
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
			, SelectSequence = 15
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
		/// SYS_USER_GENE Table 
		/// </summary>
		public const string TABLE_NAME="SYS_USER_GENE";
		public const String USER_GENE_ID_FIELD  ="USER_GENE_ID";
		public const String USER_ID_FIELD  ="USER_ID";
		public const String USER_CODE_FIELD  ="USER_CODE";
		public const String USER_NAME_FIELD  ="USER_NAME";
		public const String GENENAME_FIELD  ="GENENAME";
		public const String REMARK_FIELD  ="REMARK";
	}
}