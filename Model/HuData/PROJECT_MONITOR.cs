using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for PROJECT_MONITOR Table
    /// </summary>
    [Serializable]
    [DataTable("PROJECT_MONITOR", ResourceKey = "PROJECT_MONITOR")]
    public class PROJECT_MONITOR : BaseObject
    {
        public PROJECT_MONITOR()
        {
        }
        public PROJECT_MONITOR(DealModel initModel)
            : base(initModel)
        {
        }
        public static PROJECT_MONITOR Convert(BaseObject from)
        {
            return (PROJECT_MONITOR)from;
        }
        /// <summary>
        /// The PROJECT_MONITOR_ID Field of PROJECT_MONITOR Table
        /// </summary>
        private decimal _project_monitor_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.PROJECT_MONITOR_ID = value;
            }
            get { return PROJECT_MONITOR_ID; }
        }
        public override string CODE
        {
            set
            {
                base.CODE = value;
                this.MODEL_ID = value;
            }
            get { return MODEL_ID; }
        }
        [RecordIDField("PROJECT_MONITOR_ID"
            , AliasName = "PROJECT_MONITOR_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PROJECT_MONITOR_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal PROJECT_MONITOR_ID
        {
            set { _project_monitor_id = value; }
            get { return _project_monitor_id; }
        }
        /// <summary>
        /// The REQUEST_ID Field of PROJECT_MONITOR Table
        /// </summary>
        private decimal _request_id;
        [DataField("REQUEST_ID"
            , AliasName = "REQUEST_ID"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 18
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REQUEST_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal REQUEST_ID
        {
            set { _request_id = value; }
            get { return _request_id; }
        }
        /// <summary>
        /// The MODEL_ID Field of PROJECT_MONITOR Table
        /// </summary>
        private string _model_id;
        [DataField("MODEL_ID"
            , AliasName = "MODEL_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODEL_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
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
        /// The PROJECT_NUMBER Field of PROJECT_MONITOR Table
        /// </summary>
        private string _project_number;
        [DataField("PROJECT_NUMBER"
            , AliasName = "PROJECT_NUMBER"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROJECT_NUMBER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PROJECT_NUMBER
        {
            set { _project_number = value; }
            get { return _project_number; }
        }
        /// <summary>
        /// The POTENTIAL_STUDY_SIZE Field of PROJECT_MONITOR Table
        /// </summary>
        private string _potential_study_size;
        [DataField("POTENTIAL_STUDY_SIZE"
            , AliasName = "POTENTIAL_STUDY_SIZE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "POTENTIAL_STUDY_SIZE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string POTENTIAL_STUDY_SIZE
        {
            set { _potential_study_size = value; }
            get { return _potential_study_size; }
        }
        /// <summary>
        /// The CV40_TAKE_RATE Field of PROJECT_MONITOR Table
        /// </summary>
        private string _cv40_take_rate;
        [DataField("CV40_TAKE_RATE"
            , AliasName = "CV40_TAKE_RATE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CV40_TAKE_RATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CV40_TAKE_RATE
        {
            set { _cv40_take_rate = value; }
            get { return _cv40_take_rate; }
        }
        /// <summary>
        /// The DOSING_WINDOW Field of PROJECT_MONITOR Table
        /// </summary>
        private string _dosing_window;
        [DataField("DOSING_WINDOW"
            , AliasName = "DOSING_WINDOW"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOSING_WINDOW"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DOSING_WINDOW
        {
            set { _dosing_window = value; }
            get { return _dosing_window; }
        }

        /// <summary>
        /// The STR_CONSISTENCE Field of PROJECT_MONITOR Table
        /// </summary>
        private string _str_consistence;
        [DataField("STR_CONSISTENCE"
            , AliasName = "STR_CONSISTENCE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "STR_CONSISTENCE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string STR_CONSISTENCE
        {
            set { _str_consistence = value; }
            get { return _str_consistence; }
        }
        /// <summary>
        /// The ESTIMATED_DOI Field of PROJECT_MONITOR Table
        /// </summary>
        private string _estimated_doi;
        [DataField("ESTIMATED_DOI"
            , AliasName = "ESTIMATED_DOI"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ESTIMATED_DOI"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ESTIMATED_DOI
        {
            set { _estimated_doi = value; }
            get { return _estimated_doi; }
        }
        /// <summary>
        /// The ISDELETE Field of PROJECT_MONITOR Table
        /// </summary>
        private string _isdelete;
        [DataField("ISDELETE"
            , AliasName = "ISDELETE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 0
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ISDELETE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ISDELETE
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// The DOI Field of PROJECT_MONITOR Table
        /// </summary>
        private DateTime _doi;
        [DataField("DOI"
            , AliasName = "DOI"
            , DataType = DbType.Date
            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOI"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime DOI
        {
            set { _doi = value; }
            get { return _doi; }
        }
        public string DOI_F
        {
            get
            {
                if (_doi != DateTime.MinValue)
                {
                    return _doi.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// The DOR Field of PROJECT_MONITOR Table
        /// </summary>
        private DateTime _dor;
        [DataField("DOR"
            , AliasName = "DOR"
            , DataType = DbType.Date
            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOR"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime DOR
        {
            set { _dor = value; }
            get { return _dor; }
        }
        public string DOR_F
        {
            get
            {
                if (_dor != DateTime.MinValue)
                {
                    return _dor.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// The DOT Field of PROJECT_MONITOR Table
        /// </summary>
        private DateTime _dot;
        [DataField("DOT"
            , AliasName = "DOT"
            , DataType = DbType.Date
            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 39
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime DOT
        {
            set { _dot = value; }
            get { return _dot; }
        }
        public string DOT_F
        {
            get
            {
                if (_dot != DateTime.MinValue)
                {
                    return _dot.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }
        private DateTime _dos;
        [DataField("DOS"
            , AliasName = "DOS"
            , DataType = DbType.Date
            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 40
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime DOS
        {
            set { _dos = value; }
            get { return _dos; }
        }
        public string DOS_F
        {
            get
            {
                if (_dos != DateTime.MinValue)
                {
                    return _dos.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// The NUMBER_OF_ANIMAL_PURCHASE Field of PROJECT_MONITOR Table
        /// </summary>
        private Int32 _number_of_animal_purchase;
        [DataField("NUMBER_OF_ANIMAL_PURCHASE"
            , AliasName = "NUMBER_OF_ANIMAL_PURCHASE"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "NUMBER_OF_ANIMAL_PURCHASE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 40
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 NUMBER_OF_ANIMAL_PURCHASE
        {
            set { _number_of_animal_purchase = value; }
            get { return _number_of_animal_purchase; }
        }

      
        /// <summary>
        /// The SD Field of PROJECT_MONITOR Table
        /// </summary>
        private string _sd;
        [DataField("SD"
            , AliasName = "SD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 42
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SD
        {
            set { _sd = value; }
            get { return _sd; }
        }
        /// <summary>
        /// The JSD Field of PROJECT_MONITOR Table
        /// </summary>
        private string _jsd;
        [DataField("JSD"
            , AliasName = "JSD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "JSD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 45
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string JSD
        {
            set { _jsd = value; }
            get { return _jsd; }
        }
        /// <summary>
        /// The DT_GROUP Field of PROJECT_MONITOR Table
        /// </summary>
        private string _dt_group;
        [DataField("DT_GROUP"
            , AliasName = "DT_GROUP"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DT_GROUP"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 46
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DT_GROUP
        {
            set { _dt_group = value; }
            get { return _dt_group; }
        }
        /// <summary>
        /// The DT_ID Field of PROJECT_MONITOR Table
        /// </summary>
        private string _dt_id;
        [DataField("DT_ID"
            , AliasName = "DT_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DT_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 47
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DT_ID
        {
            set { _dt_id = value; }
            get { return _dt_id; }
        }

        /// <summary>
        /// The DT Field of PROJECT_MONITOR Table
        /// </summary>
        private string _dt;
        [DataField("DT"
            , AliasName = "DT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 48
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DT
        {
            set { _dt = value; }
            get { return _dt; }
        }
        /// <summary>
        /// The DM Field of PROJECT_MONITOR Table
        /// </summary>
        private string _dm;
        [DataField("DM"
            , AliasName = "DM"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DM"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 51
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
        /// The ROOM Field of PROJECT_MONITOR Table
        /// </summary>
        private string _room;
        [DataField("ROOM"
            , AliasName = "ROOM"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ROOM"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 54
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ROOM
        {
            set { _room = value; }
            get { return _room; }
        }
        /// <summary>
        /// The NUMER_OF_ANIMAL_INOCULATION Field of PROJECT_MONITOR Table
        /// </summary>
        private Int32 _number_of_animal_inoculation;
        [DataField("NUMBER_OF_ANIMAL_INOCULATION"
            , AliasName = "NUMBER_OF_ANIMAL_INOCULATION"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "NUMBER_OF_ANIMAL_INOCULATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 55
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 NUMBER_OF_ANIMAL_INOCULATION
        {
            set { _number_of_animal_inoculation = value; }
            get { return _number_of_animal_inoculation; }
        }

        /// <summary>
        /// The TUMOR_MONITOR_SCHEDULE Field of PROJECT_MONITOR Table
        /// </summary>
        private string _tumor_monitor_schedule;
        [DataField("TUMOR_MONITOR_SCHEDULE"
            , AliasName = "TUMOR_MONITOR_SCHEDULE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 2000
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TUMOR_MONITOR_SCHEDULE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 57
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TUMOR_MONITOR_SCHEDULE
        {
            set { _tumor_monitor_schedule = value; }
            get { return _tumor_monitor_schedule; }
        }
        /// <summary>
        /// The TUMOR_MONITOR_SCHEDULE2 Field of PROJECT_MONITOR Table
        /// </summary>
        private string _tumor_monitor_schedule2;
        [DataField("TUMOR_MONITOR_SCHEDULE2"
            , AliasName = "TUMOR_MONITOR_SCHEDULE2"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TUMOR_MONITOR_SCHEDULE2"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 72
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TUMOR_MONITOR_SCHEDULE2
        {
            set { _tumor_monitor_schedule2 = value; }
            get { return _tumor_monitor_schedule2; }
        }


      
        /// <summary>
        /// The SD_WORKLOAD Field of PROJECT_MONITOR Table
        /// </summary>
        private decimal _sd_workload;
        [DataField("SD_WORKLOAD"
            , AliasName = "SD_WORKLOAD"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 18
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SD_WORKLOAD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 66
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal SD_WORKLOAD
        {
            set { _sd_workload = value; }
            get { return _sd_workload; }
        }
        /// <summary>
        /// The DM_WORKLOAD Field of PROJECT_MONITOR Table
        /// </summary>
        private decimal _dm_workload;
        [DataField("DM_WORKLOAD"
            , AliasName = "DM_WORKLOAD"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 18
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DM_WORKLOAD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 69
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal DM_WORKLOAD
        {
            set { _dm_workload = value; }
            get { return _dm_workload; }
        }
        /// <summary>
        /// The DT_TEAM_WORKLOAD Field of PROJECT_MONITOR Table
        /// </summary>
        private decimal _dt_team_workload;
        [DataField("DT_TEAM_WORKLOAD"
            , AliasName = "DT_TEAM_WORKLOAD"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 18
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DT_TEAM_WORKLOAD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 72
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal DT_TEAM_WORKLOAD
        {
            set { _dt_team_workload = value; }
            get { return _dt_team_workload; }
        }
        /// <summary>
        /// The JSD_WORKLOAD Field of PROJECT_MONITOR Table
        /// </summary>
        private decimal _jsd_workload;
        [DataField("JSD_WORKLOAD"
            , AliasName = "JSD_WORKLOAD"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 18
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "JSD_WORKLOAD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 75
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal JSD_WORKLOAD
        {
            set { _jsd_workload = value; }
            get { return _jsd_workload; }
        }
        /// <summary>
        /// The OBSERVATION Field of PROJECT_MONITOR Table
        /// </summary>
        private Int32 _observation;
        [DataField("OBSERVATION"
            , AliasName = "OBSERVATION"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "OBSERVATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 75
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 OBSERVATION
        {
            set { _observation = value; }
            get { return _observation; }
        }
        /// <summary>
        /// The FFPE_TUMOR_SAMPLE_NUMBER Field of PROJECT_MONITOR Table
        /// </summary>
        private Int32 _ffpe_tumor_sample_number;
        [DataField("FFPE_TUMOR_SAMPLE_NUMBER"
            , AliasName = "FFPE_TUMOR_SAMPLE_NUMBER"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FFPE_TUMOR_SAMPLE_NUMBER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 78
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 FFPE_TUMOR_SAMPLE_NUMBER
        {
            set { _ffpe_tumor_sample_number = value; }
            get { return _ffpe_tumor_sample_number; }
        }
        /// <summary>
        /// The SNAP_FROZNE_SAMPLE_NUMBER Field of PROJECT_MONITOR Table
        /// </summary>
        private Int32 _snap_frozne_sample_number;
        [DataField("SNAP_FROZNE_SAMPLE_NUMBER"
            , AliasName = "SNAP_FROZNE_SAMPLE_NUMBER"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SNAP_FROZNE_SAMPLE_NUMBER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 81
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 SNAP_FROZNE_SAMPLE_NUMBER
        {
            set { _snap_frozne_sample_number = value; }
            get { return _snap_frozne_sample_number; }
        }
        /// <summary>
        /// The BLOOD_SAMPLE_NUMBER Field of PROJECT_MONITOR Table
        /// </summary>
        private string _blood_sample_number;
        [DataField("BLOOD_SAMPLE_NUMBER"
            , AliasName = "BLOOD_SAMPLE_NUMBER"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "BLOOD_SAMPLE_NUMBER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 84
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string BLOOD_SAMPLE_NUMBER
        {
            set { _blood_sample_number = value; }
            get { return _blood_sample_number; }
        }
        /// <summary>
        /// The BLOOD_SAMPLE_TYPE Field of PROJECT_MONITOR Table
        /// </summary>
        private string _blood_sample_type;
        [DataField("BLOOD_SAMPLE_TYPE"
            , AliasName = "BLOOD_SAMPLE_TYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "BLOOD_SAMPLE_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 87
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string BLOOD_SAMPLE_TYPE
        {
            set { _blood_sample_type = value; }
            get { return _blood_sample_type; }
        }
        /// <summary>
        /// The SAMPLE_AMOUNT Field of PROJECT_MONITOR Table
        /// </summary>
        private Int32 _sample_amount;
        [DataField("SAMPLE_AMOUNT"
            , AliasName = "SAMPLE_AMOUNT"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SAMPLE_AMOUNT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 88
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 SAMPLE_AMOUNT
        {
            set { _sample_amount = value; }
            get { return _sample_amount; }
        }

        /// <summary>
        /// The ESTIMATED_TIME Field of PROJECT_MONITOR Table
        /// </summary>
        private Int32 _estimated_time;
        [DataField("ESTIMATED_TIME"
            , AliasName = "ESTIMATED_TIME"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ESTIMATED_TIME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 90
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 ESTIMATED_TIME
        {
            set { _estimated_time = value; }
            get { return _estimated_time; }
        }
        /// <summary>
        /// The ARMS Field of PROJECT_MONITOR Table
        /// </summary>
        private Int32 _arms;
        [DataField("ARMS"
            , AliasName = "ARMS"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ARMS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 96
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 ARMS
        {
            set { _arms = value; }
            get { return _arms; }
        }

        /// <summary>
        /// The SIGNED_QUOTATION Field of PROJECT_MONITOR Table
        /// </summary>
        private string _signed_quotation;
        [DataField("SIGNED_QUOTATION"
            , AliasName = "SIGNED_QUOTATION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SIGNED_QUOTATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 97
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SIGNED_QUOTATION
        {
            set { _signed_quotation = value; }
            get { return _signed_quotation; }
        }
        /// <summary>
        /// The KICKOFF Field of PROJECT_MONITOR Table
        /// </summary>
        private string _kickoff;
        [DataField("KICKOFF"
            , AliasName = "KICKOFF"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "KICKOFF"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 99
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string KICKOFF
        {
            set { _kickoff = value; }
            get { return _kickoff; }
        }
        /// <summary>
        /// The REGISTER_PROJECT Field of PROJECT_MONITOR Table
        /// </summary>
        private string _register_project;
        [DataField("REGISTER_PROJECT"
            , AliasName = "REGISTER_PROJECT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REGISTER_PROJECT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 102
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REGISTER_PROJECT
        {
            set { _register_project = value; }
            get { return _register_project; }
        }
        /// <summary>
        /// The BOOKING_ANIMALS Field of PROJECT_MONITOR Table
        /// </summary>
        private string _booking_animals;
        [DataField("BOOKING_ANIMALS"
            , AliasName = "BOOKING_ANIMALS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "BOOKING_ANIMALS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 105
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string BOOKING_ANIMALS
        {
            set { _booking_animals = value; }
            get { return _booking_animals; }
        }
        /// <summary>
        /// The ORDER_ANIMAL Field of PROJECT_MONITOR Table
        /// </summary>
        private string _order_animal;
        [DataField("ORDER_ANIMAL"
            , AliasName = "ORDER_ANIMAL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ORDER_ANIMAL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 108
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ORDER_ANIMAL
        {
            set { _order_animal = value; }
            get { return _order_animal; }
        }
        /// <summary>
        /// The FINALIZE_PROTOCOL Field of PROJECT_MONITOR Table
        /// </summary>
        private string _finalize_protocol;
        [DataField("FINALIZE_PROTOCOL"
            , AliasName = "FINALIZE_PROTOCOL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FINALIZE_PROTOCOL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 111
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FINALIZE_PROTOCOL
        {
            set { _finalize_protocol = value; }
            get { return _finalize_protocol; }
        }
        /// <summary>
        /// The PROVIDE_SEEDING_ANIMAL Field of PROJECT_MONITOR Table
        /// </summary>
        private string _provide_seeding_animal;
        [DataField("PROVIDE_SEEDING_ANIMAL"
            , AliasName = "PROVIDE_SEEDING_ANIMAL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROVIDE_SEEDING_ANIMAL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 114
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PROVIDE_SEEDING_ANIMAL
        {
            set { _provide_seeding_animal = value; }
            get { return _provide_seeding_animal; }
        }
        /// <summary>
        /// The INOCULATION Field of PROJECT_MONITOR Table
        /// </summary>
        private string _inoculation;
        [DataField("INOCULATION"
            , AliasName = "INOCULATION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "INOCULATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 117
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string INOCULATION
        {
            set { _inoculation = value; }
            get { return _inoculation; }
        }
        /// <summary>
        /// The RANDOMIZATION Field of PROJECT_MONITOR Table
        /// </summary>
        private string _randomization;
        [DataField("RANDOMIZATION"
            , AliasName = "RANDOMIZATION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "RANDOMIZATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 120
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string RANDOMIZATION
        {
            set { _randomization = value; }
            get { return _randomization; }
        }
        /// <summary>
        /// The TREATMENT_START Field of PROJECT_MONITOR Table
        /// </summary>
        private string _treatment_start;
        [DataField("TREATMENT_START"
            , AliasName = "TREATMENT_START"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TREATMENT_START"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 123
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TREATMENT_START
        {
            set { _treatment_start = value; }
            get { return _treatment_start; }
        }
        /// <summary>
        /// The TREATMENT_FINISHED Field of PROJECT_MONITOR Table
        /// </summary>
        private string _treatment_finished;
        [DataField("TREATMENT_FINISHED"
            , AliasName = "TREATMENT_FINISHED"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TREATMENT_FINISHED"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 126
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TREATMENT_FINISHED
        {
            set { _treatment_finished = value; }
            get { return _treatment_finished; }
        }
        /// <summary>
        /// The OBSERVATION_POST_TREATMENT Field of PROJECT_MONITOR Table
        /// </summary>
        private string _observation_post_treatment;
        [DataField("OBSERVATION_POST_TREATMENT"
            , AliasName = "OBSERVATION_POST_TREATMENT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "OBSERVATION_POST_TREATMENT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 129
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string OBSERVATION_POST_TREATMENT
        {
            set { _observation_post_treatment = value; }
            get { return _observation_post_treatment; }
        }
        /// <summary>
        /// The TISSUE_COLLECTION Field of PROJECT_MONITOR Table
        /// </summary>
        private string _tissue_collection;
        [DataField("TISSUE_COLLECTION"
            , AliasName = "TISSUE_COLLECTION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TISSUE_COLLECTION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 132
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TISSUE_COLLECTION
        {
            set { _tissue_collection = value; }
            get { return _tissue_collection; }
        }
        /// <summary>
        /// The TISSUE_SENT_OUT Field of PROJECT_MONITOR Table
        /// </summary>
        private string _tissue_sent_out;
        [DataField("TISSUE_SENT_OUT"
            , AliasName = "TISSUE_SENT_OUT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TISSUE_SENT_OUT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 135
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TISSUE_SENT_OUT
        {
            set { _tissue_sent_out = value; }
            get { return _tissue_sent_out; }
        }
        /// <summary>
        /// The FINAL_DATA_SENT_OUT Field of PROJECT_MONITOR Table
        /// </summary>
        private string _final_data_sent_out;
        [DataField("FINAL_DATA_SENT_OUT"
            , AliasName = "FINAL_DATA_SENT_OUT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FINAL_DATA_SENT_OUT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 138
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FINAL_DATA_SENT_OUT
        {
            set { _final_data_sent_out = value; }
            get { return _final_data_sent_out; }
        }
        /// <summary>
        /// The DOCUMENT_ARCHIEVE Field of PROJECT_MONITOR Table
        /// </summary>
        private string _document_archieve;
        [DataField("DOCUMENT_ARCHIEVE"
            , AliasName = "DOCUMENT_ARCHIEVE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DOCUMENT_ARCHIEVE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 141
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DOCUMENT_ARCHIEVE
        {
            set { _document_archieve = value; }
            get { return _document_archieve; }
        }
        /// <summary>
        /// The REPORT_SENT_OUT Field of PROJECT_MONITOR Table
        /// </summary>
        private string _report_sent_out;
        [DataField("REPORT_SENT_OUT"
            , AliasName = "REPORT_SENT_OUT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REPORT_SENT_OUT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 144
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REPORT_SENT_OUT
        {
            set { _report_sent_out = value; }
            get { return _report_sent_out; }
        }
        /// <summary>
        /// The BALANCE_INVOICE_SENT_OUT Field of PROJECT_MONITOR Table
        /// </summary>
        private string _balance_invoice_sent_out;
        [DataField("BALANCE_INVOICE_SENT_OUT"
            , AliasName = "BALANCE_INVOICE_SENT_OUT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "BALANCE_INVOICE_SENT_OUT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 147
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string BALANCE_INVOICE_SENT_OUT
        {
            set { _balance_invoice_sent_out = value; }
            get { return _balance_invoice_sent_out; }
        }
        /// <summary>
        /// The COMPLETION_PROPORTIONS_PER_STUDY Field of PROJECT_MONITOR Table
        /// </summary>
        private Int32 _completion_proportions_per_study;
        [DataField("COMPLETION_PROPORTIONS_PER_STUDY"
            , AliasName = "COMPLETION_PROPORTIONS_PER_STUDY"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COMPLETION_PROPORTIONS_PER_STUDY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 150
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 COMPLETION_PROPORTIONS_PER_STUDY
        {
            set { _completion_proportions_per_study = value; }
            get { return _completion_proportions_per_study; }
        }
        /// <summary>
        /// The COMPLETION_PROPORTIONS_PER_PROJECT Field of PROJECT_MONITOR Table
        /// </summary>
        private Int32 _completion_proportions_per_project;
        [DataField("COMPLETION_PROPORTIONS_PER_PROJECT"
            , AliasName = "COMPLETION_PROPORTIONS_PER_PROJECT"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COMPLETION_PROPORTIONS_PER_PROJECT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 153
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 COMPLETION_PROPORTIONS_PER_PROJECT
        {
            set { _completion_proportions_per_project = value; }
            get { return _completion_proportions_per_project; }
        }
        /// <summary>
        /// The COMPLETE_STUDY Field of PROJECT_MONITOR Table
        /// </summary>
        private string _complete_study;
        [DataField("COMPLETE_STUDY"
            , AliasName = "COMPLETE_STUDY"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COMPLETE_STUDY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 154
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COMPLETE_STUDY
        {
            set { _complete_study = value; }
            get { return _complete_study; }
        }

        /// <summary>
        /// PROJECT_MONITOR Table 
        /// </summary>
        public const string TABLE_NAME = "PROJECT_MONITOR";
        public const String PROJECT_MONITOR_ID_FIELD = "PROJECT_MONITOR_ID";
        public const String REQUEST_ID_FIELD = "REQUEST_ID";
        public const String MODEL_ID_FIELD = "MODEL_ID";
        public const String PROJECT_NUMBER_FIELD = "PROJECT_NUMBER";
        public const String POTENTIAL_STUDY_SIZE_FIELD = "POTENTIAL_STUDY_SIZE";
        public const String CV40_TAKE_RATE_FIELD = "CV40_TAKE_RATE";
        public const String DOSING_WINDOW_FIELD = "DOSING_WINDOW";
        public const String STR_CONSISTENCE_FIELD = "STR_CONSISTENCE";
        public const String ESTIMATED_DOI_FIELD = "ESTIMATED_DOI";
        public const String ISDELETE_FIELD = "ISDELETE";
        public const String DOI_FIELD = "DOI";
        public const String DOI_F_FIELD = "DOI_F";
        public const String DOR_FIELD = "DOR";
        public const String DOR_F_FIELD = "DOR_F";
        public const String DOT_FIELD = "DOT";
        public const String DOT_F_FIELD = "DOT_F";
        public const String DOS_FIELD = "DOS";
        public const String DOS_F_FIELD = "DOS_F";
        public const String NUMBER_OF_ANIMAL_PURCHASE_FIELD = "NUMBER_OF_ANIMAL_PURCHASE";

        public const String SD_FIELD = "SD";
        public const String JSD_FIELD = "JSD";
        public const String DT_GROUP_FIELD = "DT_GROUP";
        public const String DT_ID_FIELD = "DT_ID";
        public const String DT_FIELD = "DT";
        public const String DM_FIELD = "DM";
        public const String ROOM_FIELD = "ROOM";
        public const String NUMBER_OF_ANIMAL_INOCULATION_FIELD = "NUMBER_OF_ANIMAL_INOCULATION";
        public const String TUMOR_MONITOR_SCHEDULE_FIELD = "TUMOR_MONITOR_SCHEDULE";
        public const String TUMOR_MONITOR_SCHEDULE2_FIELD = "TUMOR_MONITOR_SCHEDULE2";
        public const String SD_WORKLOAD_FIELD = "SD_WORKLOAD";
        public const String DM_WORKLOAD_FIELD = "DM_WORKLOAD";
        public const String DT_TEAM_WORKLOAD_FIELD = "DT_TEAM_WORKLOAD";
        public const String JSD_WORKLOAD_FIELD = "JSD_WORKLOAD";
        public const String OBSERVATION_FIELD = "OBSERVATION";
        public const String FFPE_TUMOR_SAMPLE_NUMBER_FIELD = "FFPE_TUMOR_SAMPLE_NUMBER";
        public const String SNAP_FROZNE_SAMPLE_NUMBER_FIELD = "SNAP_FROZNE_SAMPLE_NUMBER";
        public const String BLOOD_SAMPLE_NUMBER_FIELD = "BLOOD_SAMPLE_NUMBER";
        public const String BLOOD_SAMPLE_TYPE_FIELD = "BLOOD_SAMPLE_TYPE";
        public const String SAMPLE_AMOUNT_FIELD = "SAMPLE_AMOUNT";
        public const String ESTIMATED_TIME_FIELD = "ESTIMATED_TIME";
        public const String ARMS_FIELD = "ARMS";

        public const String SIGNED_QUOTATION_FIELD = "SIGNED_QUOTATION";
        public const String KICKOFF_FIELD = "KICKOFF";
        public const String REGISTER_PROJECT_FIELD = "REGISTER_PROJECT";
        public const String BOOKING_ANIMALS_FIELD = "BOOKING_ANIMALS";
        public const String ORDER_ANIMAL_FIELD = "ORDER_ANIMAL";
        public const String FINALIZE_PROTOCOL_FIELD = "FINALIZE_PROTOCOL";
        public const String PROVIDE_SEEDING_ANIMAL_FIELD = "PROVIDE_SEEDING_ANIMAL";
        public const String INOCULATION_FIELD = "INOCULATION";
        public const String RANDOMIZATION_FIELD = "RANDOMIZATION";
        public const String TREATMENT_START_FIELD = "TREATMENT_START";
        public const String TREATMENT_FINISHED_FIELD = "TREATMENT_FINISHED";
        public const String OBSERVATION_POST_TREATMENT_FIELD = "OBSERVATION_POST_TREATMENT";
        public const String TISSUE_COLLECTION_FIELD = "TISSUE_COLLECTION";
        public const String TISSUE_SENT_OUT_FIELD = "TISSUE_SENT_OUT";
        public const String FINAL_DATA_SENT_OUT_FIELD = "FINAL_DATA_SENT_OUT";
        public const String DOCUMENT_ARCHIEVE_FIELD = "DOCUMENT_ARCHIEVE";
        public const String REPORT_SENT_OUT_FIELD = "REPORT_SENT_OUT";
        public const String BALANCE_INVOICE_SENT_OUT_FIELD = "BALANCE_INVOICE_SENT_OUT";
        public const String COMPLETION_PROPORTIONS_PER_STUDY_FIELD = "COMPLETION_PROPORTIONS_PER_STUDY";
        public const String COMPLETION_PROPORTIONS_PER_PROJECT_FIELD = "COMPLETION_PROPORTIONS_PER_PROJECT";
        public const String COMPLETE_STUDY_FIELD = "COMPLETE_STUDY";
    
    }
}