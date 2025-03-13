using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for PROJECT_MONITOR_STUDY_DESIGN Table
    /// </summary>
    [Serializable]
    [DataTable("PROJECT_MONITOR_STUDY_DESIGN", ResourceKey = "PROJECT_MONITOR_STUDY_DESIGN")]
    public class PROJECT_MONITOR_STUDY_DESIGN : BaseObject
    {
        public PROJECT_MONITOR_STUDY_DESIGN()
        {
        }
        public PROJECT_MONITOR_STUDY_DESIGN(DealModel initModel)
            : base(initModel)
        {
        }
        public static PROJECT_MONITOR_STUDY_DESIGN Convert(BaseObject from)
        {
            return (PROJECT_MONITOR_STUDY_DESIGN)from;
        }
        /// <summary>
        /// The PROJECT_MONITOR_STUDY_DESIGN_ID Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private decimal _project_monitor_study_design_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.PROJECT_MONITOR_STUDY_DESIGN_ID = value;
            }
            get { return PROJECT_MONITOR_STUDY_DESIGN_ID; }
        }

        [RecordIDField("PROJECT_MONITOR_STUDY_DESIGN_ID"
            , AliasName = "PROJECT_MONITOR_STUDY_DESIGN_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PROJECT_MONITOR_STUDY_DESIGN_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal PROJECT_MONITOR_STUDY_DESIGN_ID
        {
            set { _project_monitor_study_design_id = value; }
            get { return _project_monitor_study_design_id; }
        }
        /// <summary>
        /// The PROJECT_MONITOR_ID Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private decimal _project_monitor_id;
        [DataField("PROJECT_MONITOR_ID"
            , AliasName = "PROJECT_MONITOR_ID"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 18
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROJECT_MONITOR_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal PROJECT_MONITOR_ID
        {
            set { _project_monitor_id = value; }
            get { return _project_monitor_id; }
        }
        /// <summary>
        /// The _GROUP Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private string __group;
        [DataField("_GROUP"
            , AliasName = "_GROUP"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "_GROUP"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string _GROUP
        {
            set { __group = value; }
            get { return __group; }
        }
        /// <summary>
        /// The MICE_GROUP Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private string _mice_group;
        [DataField("MICE_GROUP"
            , AliasName = "MICE_GROUP"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MICE_GROUP"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MICE_GROUP
        {
            set { _mice_group = value; }
            get { return _mice_group; }
        }
        /// <summary>
        /// The TYPE Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private string _type;
        [DataField("TYPE"
            , AliasName = "TYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TYPE
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// The ARTICLE Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private string _article;
        [DataField("ARTICLE"
            , AliasName = "ARTICLE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ARTICLE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ARTICLE
        {
            set { _article = value; }
            get { return _article; }
        }
        /// <summary>
        /// The VEHICLE Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private string _vehicle;
        [DataField("VEHICLE"
            , AliasName = "VEHICLE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "VEHICLE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string VEHICLE
        {
            set { _vehicle = value; }
            get { return _vehicle; }
        }
        /// <summary>
        /// The DOSE_LEVEL Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private string _dose_level;
        [DataField("DOSE_LEVEL"
            , AliasName = "DOSE_LEVEL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOSE_LEVEL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DOSE_LEVEL
        {
            set { _dose_level = value; }
            get { return _dose_level; }
        }
        /// <summary>
        /// The UNIT Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private string _unit;
        [DataField("UNIT"
            , AliasName = "UNIT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "UNIT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string UNIT
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// The DOSING_ROUTE Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private string _dosing_route;
        [DataField("DOSING_ROUTE"
            , AliasName = "DOSING_ROUTE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOSING_ROUTE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DOSING_ROUTE
        {
            set { _dosing_route = value; }
            get { return _dosing_route; }
        }
        /// <summary>
        /// The DOSING_ROUTE_VALUE Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private double _dosing_route_value;
        [DataField("DOSING_ROUTE_VALUE"
            , AliasName = "DOSING_ROUTE_VALUE"
            , DataType = DbType.Double
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOSING_ROUTE_VALUE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public double DOSING_ROUTE_VALUE
        {
            set { _dosing_route_value = value; }
            get { return _dosing_route_value; }
        }
        /// <summary>
        /// The DOSING_SCHEDULE Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private string _dosing_schedule;
        [DataField("DOSING_SCHEDULE"
            , AliasName = "DOSING_SCHEDULE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOSING_SCHEDULE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DOSING_SCHEDULE
        {
            set { _dosing_schedule = value; }
            get { return _dosing_schedule; }
        }
        /// <summary>
        /// The DOSING_SCHEDULE_VALUE Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private double _dosing_schedule_value;
        [DataField("DOSING_SCHEDULE_VALUE"
            , AliasName = "DOSING_SCHEDULE_VALUE"
            , DataType = DbType.Double
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOSING_SCHEDULE_VALUE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public double DOSING_SCHEDULE_VALUE
        {
            set { _dosing_schedule_value = value; }
            get { return _dosing_schedule_value; }
        }
        /// <summary>
        /// The DOSE_RULE Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private string _dose_rule;
        [DataField("DOSE_RULE"
            , AliasName = "DOSE_RULE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOSE_RULE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 39
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DOSE_RULE
        {
            set { _dose_rule = value; }
            get { return _dose_rule; }
        }
        /// <summary>
        /// The DOSING_PERIOD Field of PROJECT_MONITOR_STUDY_DESIGN Table
        /// </summary>
        private string _dosing_period;
        [DataField("DOSING_PERIOD"
            , AliasName = "DOSING_PERIOD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOSING_PERIOD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 42
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DOSING_PERIOD
        {
            set { _dosing_period = value; }
            get { return _dosing_period; }
        }
        /// <summary>
        /// PROJECT_MONITOR_STUDY_DESIGN Table 
        /// </summary>
        public const string TABLE_NAME = "PROJECT_MONITOR_STUDY_DESIGN";
        public const String PROJECT_MONITOR_STUDY_DESIGN_ID_FIELD = "PROJECT_MONITOR_STUDY_DESIGN_ID";
        public const String PROJECT_MONITOR_ID_FIELD = "PROJECT_MONITOR_ID";
        public const String _GROUP_FIELD = "_GROUP";
        public const String MICE_GROUP_FIELD = "MICE_GROUP";
        public const String TYPE_FIELD = "TYPE";
        public const String ARTICLE_FIELD = "ARTICLE";
        public const String VEHICLE_FIELD = "VEHICLE";
        public const String DOSE_LEVEL_FIELD = "DOSE_LEVEL";
        public const String UNIT_FIELD = "UNIT";
        public const String DOSING_ROUTE_FIELD = "DOSING_ROUTE";
        public const String DOSING_ROUTE_VALUE_FIELD = "DOSING_ROUTE_VALUE";
        public const String DOSING_SCHEDULE_FIELD = "DOSING_SCHEDULE";
        public const String DOSING_SCHEDULE_VALUE_FIELD = "DOSING_SCHEDULE_VALUE";
        public const String DOSE_RULE_FIELD = "DOSE_RULE";
        public const String DOSING_PERIOD_FIELD = "DOSING_PERIOD";
    }
}