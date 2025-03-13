using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for PROJECT_MONITOR_DOSING_ROUTE Table
    /// </summary>
    [Serializable]
    [DataTable("PROJECT_MONITOR_DOSING_ROUTE", ResourceKey = "PROJECT_MONITOR_DOSING_ROUTE")]
    public class PROJECT_MONITOR_DOSING_ROUTE : BaseObject
    {
        public PROJECT_MONITOR_DOSING_ROUTE()
        {
        }
        public PROJECT_MONITOR_DOSING_ROUTE(DealModel initModel)
            : base(initModel)
        {
        }
        public static PROJECT_MONITOR_DOSING_ROUTE Convert(BaseObject from)
        {
            return (PROJECT_MONITOR_DOSING_ROUTE)from;
        }
        /// <summary>
        /// The PROJECT_MONITOR_DOSING_ROUTE_ID Field of PROJECT_MONITOR_DOSING_ROUTE Table
        /// </summary>
        private decimal _project_monitor_dosing_route_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.PROJECT_MONITOR_DOSING_ROUTE_ID = value;
            }
            get { return PROJECT_MONITOR_DOSING_ROUTE_ID; }
        }

        [RecordIDField("PROJECT_MONITOR_DOSING_ROUTE_ID"
            , AliasName = "PROJECT_MONITOR_DOSING_ROUTE_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PROJECT_MONITOR_DOSING_ROUTE_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal PROJECT_MONITOR_DOSING_ROUTE_ID
        {
            set { _project_monitor_dosing_route_id = value; }
            get { return _project_monitor_dosing_route_id; }
        }
        /// <summary>
        /// The CODE Field of PROJECT_MONITOR_DOSING_ROUTE Table
        /// </summary>
        private string _code;
        [DataField("CODE"
            , AliasName = "CODE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CODE
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// The UNIT_TIME Field of PROJECT_MONITOR_DOSING_ROUTE Table
        /// </summary>
        private string _unit_time;
        [DataField("UNIT_TIME"
            , AliasName = "UNIT_TIME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "UNIT_TIME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string UNIT_TIME
        {
            set { _unit_time = value; }
            get { return _unit_time; }
        }
        /// <summary>
        /// PROJECT_MONITOR_DOSING_ROUTE Table 
        /// </summary>
        public const string TABLE_NAME = "PROJECT_MONITOR_DOSING_ROUTE";
        public const String PROJECT_MONITOR_DOSING_ROUTE_ID_FIELD = "PROJECT_MONITOR_DOSING_ROUTE_ID";
        public const String CODE_FIELD = "CODE";
        public const String UNIT_TIME_FIELD = "UNIT_TIME";
    }
}