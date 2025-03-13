using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for S_ORDER Table
	/// </summary>
	[Serializable]
	[DataTable("S_ORDER",ResourceKey = "S_ORDER")]
	public class S_ORDER: BaseObject
	{
		public S_ORDER()
		{
		}
		public S_ORDER(DealModel initModel):base(initModel)
		{
		}
		public static S_ORDER Convert(BaseObject from)
		{
			return (S_ORDER)from;
		}
		/// <summary>
		/// The FID Field of S_ORDER Table
		/// </summary>
		private Int32 _fid;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.FID = int.Parse(value.ToString()); }
			get { return FID; }
		}

		[RecordIDField("FID"
			, AliasName = "FID"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "FID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public Int32 FID
		{
			set { _fid = value; }
			get { return _fid; }
		}
		/// <summary>
		/// The FNUMBER Field of S_ORDER Table
		/// </summary>
		private string _fnumber;
		[DataField("FNUMBER"
			, AliasName = "FNUMBER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 10
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FNUMBER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FNUMBER
		{
			set { _fnumber = value; }
			get { return _fnumber; }
		}
		/// <summary>
		/// The FSN Field of S_ORDER Table
		/// </summary>
		private string _fsn;
		[DataField("FSN"
			, AliasName = "FSN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 10
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FSN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FSN
		{
			set { _fsn = value; }
			get { return _fsn; }
		}
		/// <summary>
		/// The FFHSTATUS Field of S_ORDER Table
		/// </summary>
		private string _ffhstatus;
		[DataField("FFHSTATUS"
			, AliasName = "FFHSTATUS"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 10
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FFHSTATUS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FFHSTATUS
		{
			set { _ffhstatus = value; }
			get { return _ffhstatus; }
		}
		/// <summary>
		/// The FCUSTOMERID Field of S_ORDER Table
		/// </summary>
		private Int32 _fcustomerid;
		[DataField("FCUSTOMERID"
			, AliasName = "FCUSTOMERID"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FCUSTOMERID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FCUSTOMERID
		{
			set { _fcustomerid = value; }
			get { return _fcustomerid; }
		}
		/// <summary>
		/// The FSALEMANID Field of S_ORDER Table
		/// </summary>
		private Int32 _fsalemanid;
		[DataField("FSALEMANID"
			, AliasName = "FSALEMANID"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FSALEMANID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FSALEMANID
		{
			set { _fsalemanid = value; }
			get { return _fsalemanid; }
		}
		/// <summary>
		/// The FREGIONID Field of S_ORDER Table
		/// </summary>
		private Int32 _fregionid;
		[DataField("FREGIONID"
			, AliasName = "FREGIONID"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FREGIONID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FREGIONID
		{
			set { _fregionid = value; }
			get { return _fregionid; }
		}
		/// <summary>
		/// The FYSTYPE Field of S_ORDER Table
		/// </summary>
		private Int32 _fystype;
		[DataField("FYSTYPE"
			, AliasName = "FYSTYPE"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FYSTYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FYSTYPE
		{
			set { _fystype = value; }
			get { return _fystype; }
		}
		/// <summary>
		/// The FPROJECTID Field of S_ORDER Table
		/// </summary>
		private Int32 _fprojectid;
		[DataField("FPROJECTID"
			, AliasName = "FPROJECTID"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FPROJECTID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FPROJECTID
		{
			set { _fprojectid = value; }
			get { return _fprojectid; }
		}
		/// <summary>
		/// The FCTCUSTID Field of S_ORDER Table
		/// </summary>
		private Int32 _fctcustid;
		[DataField("FCTCUSTID"
			, AliasName = "FCTCUSTID"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FCTCUSTID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FCTCUSTID
		{
			set { _fctcustid = value; }
			get { return _fctcustid; }
		}
		/// <summary>
		/// The FORIORDERID Field of S_ORDER Table
		/// </summary>
		private Int32 _foriorderid;
		[DataField("FORIORDERID"
			, AliasName = "FORIORDERID"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FORIORDERID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FORIORDERID
		{
			set { _foriorderid = value; }
			get { return _foriorderid; }
		}
		/// <summary>
		/// The FORIORDERNO Field of S_ORDER Table
		/// </summary>
		private string _foriorderno;
		[DataField("FORIORDERNO"
			, AliasName = "FORIORDERNO"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 25
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FORIORDERNO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FORIORDERNO
		{
			set { _foriorderno = value; }
			get { return _foriorderno; }
		}
		/// <summary>
		/// The FDHDATE Field of S_ORDER Table
		/// </summary>
		private DateTime _fdhdate;
		[DataField("FDHDATE"
			, AliasName = "FDHDATE"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FDHDATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 36
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime FDHDATE
		{
			set { _fdhdate = value; }
			get { return _fdhdate; }
		}
		/// <summary>
		/// The FJHDATE Field of S_ORDER Table
		/// </summary>
		private DateTime _fjhdate;
		[DataField("FJHDATE"
			, AliasName = "FJHDATE"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FJHDATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 39
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime FJHDATE
		{
			set { _fjhdate = value; }
			get { return _fjhdate; }
		}
		/// <summary>
		/// The FOUTTYPEID Field of S_ORDER Table
		/// </summary>
		private Int32 _fouttypeid;
		[DataField("FOUTTYPEID"
			, AliasName = "FOUTTYPEID"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FOUTTYPEID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 42
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FOUTTYPEID
		{
			set { _fouttypeid = value; }
			get { return _fouttypeid; }
		}
		/// <summary>
		/// The FFYCD Field of S_ORDER Table
		/// </summary>
		private decimal _ffycd;
		[DataField("FFYCD"
			, AliasName = "FFYCD"
			, DataType = DbType.Decimal
			, IsNullable = true
			, Size = 18
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FFYCD"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 45
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal FFYCD
		{
			set { _ffycd = value; }
			get { return _ffycd; }
		}
		/// <summary>
		/// The FYFDJ Field of S_ORDER Table
		/// </summary>
		private string _fyfdj;
		[DataField("FYFDJ"
			, AliasName = "FYFDJ"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FYFDJ"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 48
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FYFDJ
		{
			set { _fyfdj = value; }
			get { return _fyfdj; }
		}
		/// <summary>
		/// The FSCZQ Field of S_ORDER Table
		/// </summary>
		private Int32 _fsczq;
		[DataField("FSCZQ"
			, AliasName = "FSCZQ"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FSCZQ"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 51
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FSCZQ
		{
			set { _fsczq = value; }
			get { return _fsczq; }
		}
		/// <summary>
		/// The FKDFH Field of S_ORDER Table
		/// </summary>
		private Int32 _fkdfh;
		[DataField("FKDFH"
			, AliasName = "FKDFH"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FKDFH"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 54
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FKDFH
		{
			set { _fkdfh = value; }
			get { return _fkdfh; }
		}
		/// <summary>
		/// The FINDATE Field of S_ORDER Table
		/// </summary>
		private DateTime _findate;
		[DataField("FINDATE"
			, AliasName = "FINDATE"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FINDATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 57
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime FINDATE
		{
			set { _findate = value; }
			get { return _findate; }
		}
		/// <summary>
		/// The FBILLERID Field of S_ORDER Table
		/// </summary>
		private Int32 _fbillerid;
		[DataField("FBILLERID"
			, AliasName = "FBILLERID"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FBILLERID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 60
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FBILLERID
		{
			set { _fbillerid = value; }
			get { return _fbillerid; }
		}
		/// <summary>
		/// The FBILLDATE Field of S_ORDER Table
		/// </summary>
		private DateTime _fbilldate;
		[DataField("FBILLDATE"
			, AliasName = "FBILLDATE"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FBILLDATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 63
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime FBILLDATE
		{
			set { _fbilldate = value; }
			get { return _fbilldate; }
		}
		/// <summary>
		/// The FCHECKERID Field of S_ORDER Table
		/// </summary>
		private Int32 _fcheckerid;
		[DataField("FCHECKERID"
			, AliasName = "FCHECKERID"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FCHECKERID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 66
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FCHECKERID
		{
			set { _fcheckerid = value; }
			get { return _fcheckerid; }
		}
		/// <summary>
		/// The FCHECKDATE Field of S_ORDER Table
		/// </summary>
		private DateTime _fcheckdate;
		[DataField("FCHECKDATE"
			, AliasName = "FCHECKDATE"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FCHECKDATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 69
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime FCHECKDATE
		{
			set { _fcheckdate = value; }
			get { return _fcheckdate; }
		}
		/// <summary>
		/// The FTOTALAMOUNT Field of S_ORDER Table
		/// </summary>
		private decimal _ftotalamount;
		[DataField("FTOTALAMOUNT"
			, AliasName = "FTOTALAMOUNT"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FTOTALAMOUNT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 72
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal FTOTALAMOUNT
		{
			set { _ftotalamount = value; }
			get { return _ftotalamount; }
		}
		/// <summary>
		/// The FREMARK Field of S_ORDER Table
		/// </summary>
		private string _fremark;
		[DataField("FREMARK"
			, AliasName = "FREMARK"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FREMARK"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 75
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FREMARK
		{
			set { _fremark = value; }
			get { return _fremark; }
		}
		/// <summary>
		/// The FFHINFO Field of S_ORDER Table
		/// </summary>
		private string _ffhinfo;
		[DataField("FFHINFO"
			, AliasName = "FFHINFO"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FFHINFO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 78
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FFHINFO
		{
			set { _ffhinfo = value; }
			get { return _ffhinfo; }
		}
		/// <summary>
		/// The FHTPD Field of S_ORDER Table
		/// </summary>
		private string _fhtpd;
		[DataField("FHTPD"
			, AliasName = "FHTPD"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FHTPD"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 81
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FHTPD
		{
			set { _fhtpd = value; }
			get { return _fhtpd; }
		}
		/// <summary>
		/// The FISFY Field of S_ORDER Table
		/// </summary>
		private Int32 _fisfy;
		[DataField("FISFY"
			, AliasName = "FISFY"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FISFY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 84
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FISFY
		{
			set { _fisfy = value; }
			get { return _fisfy; }
		}
		/// <summary>
		/// The FISKP Field of S_ORDER Table
		/// </summary>
		private Int32 _fiskp;
		[DataField("FISKP"
			, AliasName = "FISKP"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FISKP"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 87
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FISKP
		{
			set { _fiskp = value; }
			get { return _fiskp; }
		}
		/// <summary>
		/// The FISPRINT Field of S_ORDER Table
		/// </summary>
		private Int32 _fisprint;
		[DataField("FISPRINT"
			, AliasName = "FISPRINT"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FISPRINT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 90
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FISPRINT
		{
			set { _fisprint = value; }
			get { return _fisprint; }
		}
		/// <summary>
		/// The FPRINTER Field of S_ORDER Table
		/// </summary>
		private Int32 _fprinter;
		[DataField("FPRINTER"
			, AliasName = "FPRINTER"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FPRINTER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 93
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 FPRINTER
		{
			set { _fprinter = value; }
			get { return _fprinter; }
		}
		/// <summary>
		/// S_ORDER Table 
		/// </summary>
		public const string TABLE_NAME="S_ORDER";
		public const String FID_FIELD  ="FID";
		public const String FNUMBER_FIELD  ="FNUMBER";
		public const String FSN_FIELD  ="FSN";
		public const String FFHSTATUS_FIELD  ="FFHSTATUS";
		public const String FCUSTOMERID_FIELD  ="FCUSTOMERID";
		public const String FSALEMANID_FIELD  ="FSALEMANID";
		public const String FREGIONID_FIELD  ="FREGIONID";
		public const String FYSTYPE_FIELD  ="FYSTYPE";
		public const String FPROJECTID_FIELD  ="FPROJECTID";
		public const String FCTCUSTID_FIELD  ="FCTCUSTID";
		public const String FORIORDERID_FIELD  ="FORIORDERID";
		public const String FORIORDERNO_FIELD  ="FORIORDERNO";
		public const String FDHDATE_FIELD  ="FDHDATE";
		public const String FJHDATE_FIELD  ="FJHDATE";
		public const String FOUTTYPEID_FIELD  ="FOUTTYPEID";
		public const String FFYCD_FIELD  ="FFYCD";
		public const String FYFDJ_FIELD  ="FYFDJ";
		public const String FSCZQ_FIELD  ="FSCZQ";
		public const String FKDFH_FIELD  ="FKDFH";
		public const String FINDATE_FIELD  ="FINDATE";
		public const String FBILLERID_FIELD  ="FBILLERID";
		public const String FBILLDATE_FIELD  ="FBILLDATE";
		public const String FCHECKERID_FIELD  ="FCHECKERID";
		public const String FCHECKDATE_FIELD  ="FCHECKDATE";
		public const String FTOTALAMOUNT_FIELD  ="FTOTALAMOUNT";
		public const String FREMARK_FIELD  ="FREMARK";
		public const String FFHINFO_FIELD  ="FFHINFO";
		public const String FHTPD_FIELD  ="FHTPD";
		public const String FISFY_FIELD  ="FISFY";
		public const String FISKP_FIELD  ="FISKP";
		public const String FISPRINT_FIELD  ="FISPRINT";
		public const String FPRINTER_FIELD  ="FPRINTER";
	}
}