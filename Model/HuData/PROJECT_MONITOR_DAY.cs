using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for PROJECT_MONITOR_DAY Table
    /// </summary>
    [Serializable]
    [DataTable("PROJECT_MONITOR_DAY", ResourceKey = "PROJECT_MONITOR_DAY")]
    public class PROJECT_MONITOR_DAY : BaseObject
    {
        public PROJECT_MONITOR_DAY()
        {
        }
        public PROJECT_MONITOR_DAY(DealModel initModel)
            : base(initModel)
        {
        }
        public static PROJECT_MONITOR_DAY Convert(BaseObject from)
        {
            return (PROJECT_MONITOR_DAY)from;
        }
        /// <summary>
        /// The PROJECT_MONITOR_DAY_ID Field of PROJECT_MONITOR_DAY Table
        /// </summary>
        private decimal _project_monitor_day_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.PROJECT_MONITOR_DAY_ID = value;
            }
            get { return PROJECT_MONITOR_DAY_ID; }
        }

        [RecordIDField("PROJECT_MONITOR_DAY_ID"
            , AliasName = "PROJECT_MONITOR_DAY_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PROJECT_MONITOR_DAY_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal PROJECT_MONITOR_DAY_ID
        {
            set { _project_monitor_day_id = value; }
            get { return _project_monitor_day_id; }
        }
        /// <summary>
        /// The PROJECT_MONITOR_ID Field of PROJECT_MONITOR_DAY Table
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
        /// The SUB_PROJECT Field of PROJECT_MONITOR_DAY Table
        /// </summary>
        private string _sub_project;
        [DataField("SUB_PROJECT"
            , AliasName = "SUB_PROJECT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SUB_PROJECT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SUB_PROJECT
        {
            set { _sub_project = value; }
            get { return _sub_project; }
        }
        /// <summary>
        /// The MODEL_ID Field of PROJECT_MONITOR_DAY Table
        /// </summary>
        private string _model_id;
        [DataField("MODEL_ID"
            , AliasName = "MODEL_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODEL_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
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
        /// The ROLE_NAME Field of PROJECT_MONITOR_DAY Table
        /// </summary>
        private string _role_name;
        [DataField("ROLE_NAME"
            , AliasName = "ROLE_NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ROLE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ROLE_NAME
        {
            set { _role_name = value; }
            get { return _role_name; }
        }
        /// <summary>
        /// The PERSON Field of PROJECT_MONITOR_DAY Table
        /// </summary>
        private string _person;
        [DataField("PERSON"
            , AliasName = "PERSON"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PERSON"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PERSON
        {
            set { _person = value; }
            get { return _person; }
        }
        /// <summary>
        /// The STUDY_DESIGN_DAY Field of PROJECT_MONITOR_DAY Table
        /// </summary>
        private DateTime _study_design_day;
        [DataField("STUDY_DESIGN_DAY"
            , AliasName = "STUDY_DESIGN_DAY"
            , DataType = DbType.DateTime
            , IsNullable = true
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "STUDY_DESIGN_DAY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime STUDY_DESIGN_DAY
        {
            set { _study_design_day = value; }
            get { return _study_design_day; }
        }
        /// <summary>
        /// The DM Field of PROJECT_MONITOR_DAY Table
        /// </summary>
        private string _dm;
        [DataField("DM"
            , AliasName = "DM"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DM"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DM
        {
            set { _dm = value; }
            get { return _dm; }
        }
        /// <summary>
        /// The STUDY_WORKLOAD Field of PROJECT_MONITOR_DAY Table
        /// </summary>
        private double _study_workload;
        [DataField("STUDY_WORKLOAD"
            , AliasName = "STUDY_WORKLOAD"
            , DataType = DbType.Double
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "STUDY_WORKLOAD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public double STUDY_WORKLOAD
        {
            set { _study_workload = value; }
            get { return _study_workload; }
        }
        /// <summary>
        /// The PHASE Field of PROJECT_MONITOR_DAY Table
        /// </summary>
        private string _phase;
        [DataField("PHASE"
            , AliasName = "PHASE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PHASE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PHASE
        {
            set { _phase = value; }
            get { return _phase; }
        }
        /// <summary>
        /// PROJECT_MONITOR_DAY Table 
        /// </summary>
        public const string TABLE_NAME = "PROJECT_MONITOR_DAY";
        public const String PROJECT_MONITOR_DAY_ID_FIELD = "PROJECT_MONITOR_DAY_ID";
        public const String PROJECT_MONITOR_ID_FIELD = "PROJECT_MONITOR_ID";
        public const String SUB_PROJECT_FIELD = "SUB_PROJECT";
        public const String MODEL_ID_FIELD = "MODEL_ID";
        public const String ROLE_NAME_FIELD = "ROLE_NAME";
        public const String PERSON_FIELD = "PERSON";
        public const String STUDY_DESIGN_DAY_FIELD = "STUDY_DESIGN_DAY";
        public const String DM_FIELD = "DM";
        public const String STUDY_WORKLOAD_FIELD = "STUDY_WORKLOAD";
        public const String PHASE_FIELD = "PHASE";
    }
}