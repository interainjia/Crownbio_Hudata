using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for ENDMODELS Table
    /// </summary>
    [Serializable]
    [DataTable("ENDMODELS", ResourceKey = "ENDMODELS")]
    public class ENDMODELS : BaseObject
    {
        public ENDMODELS()
        {
        }
        public ENDMODELS(DealModel initModel) : base(initModel)
        {
        }
        public static ENDMODELS Convert(BaseObject from)
        {
            return (ENDMODELS)from;
        }
        /// <summary>
        /// The ENDMODELS_ID Field of ENDMODELS Table
        /// </summary>
        private decimal _endmodels_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.ENDMODELS_ID = value;
            }
            get { return ENDMODELS_ID; }
        }

        [RecordIDField("ENDMODELS_ID"
            , AliasName = "ENDMODELS_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "ENDMODELS_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal ENDMODELS_ID
        {
            set { _endmodels_id = value; }
            get { return _endmodels_id; }
        }
        /// <summary>
        /// The DATE_OF_UPDATE Field of ENDMODELS Table
        /// </summary>
        private DateTime _date_of_update;
		[DataField("DATE_OF_UPDATE"
            , AliasName = "DATE_OF_UPDATE"
            , DataType = DbType.Date

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DATE_OF_UPDATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime DATE_OF_UPDATE
		{
			set { _date_of_update = value; }
    get { return _date_of_update; }
		}
		/// <summary>
		/// The LEADER Field of ENDMODELS Table
		/// </summary>
		private string _leader;
[DataField("LEADER"
    , AliasName = "LEADER"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 100
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "LEADER"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 6
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
/// The GROUP_NAME Field of ENDMODELS Table
/// </summary>
private string _group_name;
[DataField("GROUP_NAME"
    , AliasName = "GROUP_NAME"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 100
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "GROUP_NAME"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 9
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string GROUP_NAME
{
    set { _group_name = value; }
    get { return _group_name; }
}
/// <summary>
/// The RN Field of ENDMODELS Table
/// </summary>
private string _rn;
[DataField("RN"
    , AliasName = "RN"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 100
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "RN"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 12
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
/// The PN Field of ENDMODELS Table
/// </summary>
private string _pn;
[DataField("PN"
    , AliasName = "PN"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 100
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "PN"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 15
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
/// The HUSBANDRY_START Field of ENDMODELS Table
/// </summary>
private DateTime _husbandry_start;
[DataField("HUSBANDRY_START"
    , AliasName = "HUSBANDRY_START"
    , DataType = DbType.Date
    , IsNullable = true
    , Size = 100
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "HUSBANDRY_START"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 18
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public DateTime HUSBANDRY_START
{
    set { _husbandry_start = value; }
    get { return _husbandry_start; }
}
/// <summary>
/// The DATE_OF_DEAD Field of ENDMODELS Table
/// </summary>
private DateTime _date_of_dead;
		[DataField("DATE_OF_DEAD"
            , AliasName = "DATE_OF_DEAD"
            , DataType = DbType.Date

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DATE_OF_DEAD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
public DateTime DATE_OF_DEAD
		{
			set { _date_of_dead = value; }
			get { return _date_of_dead; }
		}
		/// <summary>
		/// The LOCATION Field of ENDMODELS Table
		/// </summary>
		private string _location;
[DataField("LOCATION"
    , AliasName = "LOCATION"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 100
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
/// The IVC Field of ENDMODELS Table
/// </summary>
private string _ivc;
[DataField("IVC"
    , AliasName = "IVC"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 100
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "IVC"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 27
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
/// The REVIVAL Field of ENDMODELS Table
/// </summary>
private string _revival;
[DataField("REVIVAL"
    , AliasName = "REVIVAL"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 100
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "REVIVAL"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 30
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string REVIVAL
{
    set { _revival = value; }
    get { return _revival; }
}
/// <summary>
/// The ANIMAL Field of ENDMODELS Table
/// </summary>
private string _animal;
[DataField("ANIMAL"
    , AliasName = "ANIMAL"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 1000
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "ANIMAL"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 33
    , DialogSequence = -1
    , IsInsertField = true
    , IsUpdateField = true
     )]
public string ANIMAL
{
    set { _animal = value; }
    get { return _animal; }
}
/// <summary>
/// The COMMENTS Field of ENDMODELS Table
/// </summary>
private string _comments;
[DataField("COMMENTS"
    , AliasName = "COMMENTS"
    , DataType = DbType.String
    , IsNullable = true
    , Size = 1000
    , Width = 100
    , DisplayInCondition = true
    , DisplayInMaintain = true
    , DisplayInDialog = false
    , ResourceKey = "COMMENTS"
    , GroupFun = "MAX"
    , AllowEdit = false
    , Frozen = false
    , SelectSequence = 36
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
/// ENDMODELS Table 
/// </summary>
public const string TABLE_NAME = "ENDMODELS";
public const String ENDMODELS_ID_FIELD = "ENDMODELS_ID";
public const String DATE_OF_UPDATE_FIELD = "DATE_OF_UPDATE";
public const String LEADER_FIELD = "LEADER";
public const String GROUP_NAME_FIELD = "GROUP_NAME";
public const String RN_FIELD = "RN";
public const String PN_FIELD = "PN";
public const String HUSBANDRY_START_FIELD = "HUSBANDRY_START";
public const String DATE_OF_DEAD_FIELD = "DATE_OF_DEAD";
public const String LOCATION_FIELD = "LOCATION";
public const String IVC_FIELD = "IVC";
public const String REVIVAL_FIELD = "REVIVAL";
public const String ANIMAL_FIELD = "ANIMAL";
public const String COMMENTS_FIELD = "COMMENTS";
	}
}