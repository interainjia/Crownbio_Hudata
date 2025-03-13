using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for LOCATION Table
    /// </summary>
    [Serializable]
    [DataTable("LOCATION", ResourceKey = "LOCATION")]
    public class LOCATION : BaseObject
    {
        public LOCATION()
        {
        }
        public LOCATION(DealModel initModel)
            : base(initModel)
        {
        }
        public static LOCATION Convert(BaseObject from)
        {
            return (LOCATION)from;
        }
        /// <summary>
        /// The LOCATION_ID Field of LOCATION Table
        /// </summary>
        private decimal _location_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.LOCATION_ID = value;
            }
            get { return LOCATION_ID; }
        }

        [RecordIDField("LOCATION_ID"
            , AliasName = "LOCATION_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "LOCATION_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal LOCATION_ID
        {
            set { _location_id = value; }
            get { return _location_id; }
        }
        /// <summary>
        /// The NAME Field of LOCATION Table
        /// </summary>
        private string _name;
        [DataField("NAME"
            , AliasName = "NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// The LOCATION_TYPE Field of LOCATION Table
        /// </summary>
        private string _location_type;
        [DataField("LOCATION_TYPE"
            , AliasName = "LOCATION_TYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "LOCATION_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string LOCATION_TYPE
        {
            set { _location_type = value; }
            get { return _location_type; }
        }
        /// <summary>
        /// The ISPARENT Field of LOCATION Table
        /// </summary>
        private bool _isparent;
        [DataField("ISPARENT"
            , AliasName = "ISPARENT"
            , DataType = DbType.Boolean
            , IsNullable = true
            , Size = 1
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ISPARENT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 7
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public bool ISPARENT
        {
            set { _isparent = value; }
            get { return _isparent; }
        }

        /// <summary>
        /// The MAPS_ROWS Field of LOCATION Table
        /// </summary>
        private string _maps_rows;
        [DataField("MAPS_ROWS"
            , AliasName = "MAPS_ROWS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MAPS_ROWS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MAPS_ROWS
        {
            set { _maps_rows = value; }
            get { return _maps_rows; }
        }
        /// <summary>
        /// The MAPS_COLUMNS Field of LOCATION Table
        /// </summary>
        private string _maps_columns;
        [DataField("MAPS_COLUMNS"
            , AliasName = "MAPS_COLUMNS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MAPS_COLUMNS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MAPS_COLUMNS
        {
            set { _maps_columns = value; }
            get { return _maps_columns; }
        }
        /// <summary>
        /// The AID Field of LOCATION Table
        /// </summary>
        private string _aid;
        [DataField("AID"
            , AliasName = "AID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "AID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string AID
        {
            set { _aid = value; }
            get { return _aid; }
        }
        /// <summary>
        /// The P_ID Field of LOCATION Table
        /// </summary>
        private string _p_id;
        [DataField("P_ID"
            , AliasName = "P_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "P_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string P_ID
        {
            set { _p_id = value; }
            get { return _p_id; }
        }
        /// <summary>
        /// The BOX_NUMBER Field of LOCATION Table
        /// </summary>
        private double _box_number;
        [DataField("BOX_NUMBER"
            , AliasName = "BOX_NUMBER"
            , DataType = DbType.Double
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "BOX_NUMBER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public double BOX_NUMBER
        {
            set { _box_number = value; }
            get { return _box_number; }
        }
        /// <summary>
        /// The USED_SPACE Field of LOCATION Table
        /// </summary>
        private double _used_space;
        [DataField("USED_SPACE"
            , AliasName = "USED_SPACE"
            , DataType = DbType.Double
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "USED_SPACE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public double USED_SPACE
        {
            set { _used_space = value; }
            get { return _used_space; }
        }

        /// <summary>
        /// LOCATION Table 
        /// </summary>
        public const string TABLE_NAME = "LOCATION";
        public const String LOCATION_ID_FIELD = "LOCATION_ID";
        public const String NAME_FIELD = "NAME";
        public const String LOCATION_TYPE_FIELD = "LOCATION_TYPE";
        public const String ISPARENT_FIELD = "ISPARENT";
        public const String MAPS_ROWS_FIELD = "MAPS_ROWS";
        public const String MAPS_COLUMNS_FIELD = "MAPS_COLUMNS";
        public const String AID_FIELD = "AID";
        public const String P_ID_FIELD = "P_ID";
        public const String BOX_NUMBER_FIELD = "BOX_NUMBER";
        public const String USED_SPACE_FIELD = "USED_SPACE";
    }
}