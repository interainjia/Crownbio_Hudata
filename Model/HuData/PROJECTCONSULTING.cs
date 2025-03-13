using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for PROJECTCONSULTING Table
    /// </summary>
    [Serializable]
    [DataTable("PROJECTCONSULTING", ResourceKey = "PROJECTCONSULTING")]
    public class PROJECTCONSULTING : BaseObject
    {
        public PROJECTCONSULTING()
        {
        }
        public PROJECTCONSULTING(DealModel initModel) : base(initModel)
        {
        }
        public static PROJECTCONSULTING Convert(BaseObject from)
        {
            return (PROJECTCONSULTING)from;
        }
        /// <summary>
        /// The PROJECTCONSULTING_ID Field of PROJECTCONSULTING Table
        /// </summary>
        private decimal _projectconsulting_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.PROJECTCONSULTING_ID = value;
            }
            get { return PROJECTCONSULTING_ID; }
        }

        [RecordIDField("PROJECTCONSULTING_ID"
            , AliasName = "PROJECTCONSULTING_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PROJECTCONSULTING_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal PROJECTCONSULTING_ID
        {
            set { _projectconsulting_id = value; }
            get { return _projectconsulting_id; }
        }
        /// <summary>
        /// The MODELID Field of PROJECTCONSULTING Table
        /// </summary>
        private string _modelid;
        [DataField("MODELID"
            , AliasName = "MODELID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODELID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MODELID
        {
            set { _modelid = value; }
            get { return _modelid; }
        }
        /// <summary>
        /// The CANCERTYPE Field of PROJECTCONSULTING Table
        /// </summary>
        private string _cancertype;
        [DataField("CANCERTYPE"
            , AliasName = "CANCERTYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CANCERTYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CANCERTYPE
        {
            set { _cancertype = value; }
            get { return _cancertype; }
        }
        /// <summary>
        /// The LIVESTATUS Field of PROJECTCONSULTING Table
        /// </summary>
        private string _livestatus;
        [DataField("LIVESTATUS"
            , AliasName = "LIVESTATUS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "LIVESTATUS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string LIVESTATUS
        {
            set { _livestatus = value; }
            get { return _livestatus; }
        }
        /// <summary>
        /// The PN Field of PROJECTCONSULTING Table
        /// </summary>
        private string _pn;
        [DataField("PN"
            , AliasName = "PN"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
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
        /// The LOCATION Field of PROJECTCONSULTING Table
        /// </summary>
        private string _location;
        [DataField("LOCATION"
            , AliasName = "LOCATION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "LOCATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
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
        /// The ESTIMATED_TIMEFRAME_OF_INOCULATION Field of PROJECTCONSULTING Table
        /// </summary>
        private string _estimated_timeframe_of_inoculation;
        [DataField("ESTIMATED_TIMEFRAME_OF_INOCULATION"
            , AliasName = "ESTIMATED_TIMEFRAME_OF_INOCULATION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ESTIMATED_TIMEFRAME_OF_INOCULATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ESTIMATED_TIMEFRAME_OF_INOCULATION
        {
            set { _estimated_timeframe_of_inoculation = value; }
            get { return _estimated_timeframe_of_inoculation; }
        }
        /// <summary>
        /// The CONFIDENCESCORE Field of PROJECTCONSULTING Table
        /// </summary>
        private string _confidencescore;
        [DataField("CONFIDENCESCORE"
            , AliasName = "CONFIDENCESCORE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CONFIDENCESCORE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CONFIDENCESCORE
        {
            set { _confidencescore = value; }
            get { return _confidencescore; }
        }
        /// <summary>
        /// The AVAILABLEIN Field of PROJECTCONSULTING Table
        /// </summary>
        private string _availablein;
        [DataField("AVAILABLEIN"
            , AliasName = "AVAILABLEIN"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "AVAILABLEIN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string AVAILABLEIN
        {
            set { _availablein = value; }
            get { return _availablein; }
        }
        /// <summary>
        /// The SPECIALFEATURE Field of PROJECTCONSULTING Table
        /// </summary>
        private string _specialfeature;
        [DataField("SPECIALFEATURE"
            , AliasName = "SPECIALFEATURE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SPECIALFEATURE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SPECIALFEATURE
        {
            set { _specialfeature = value; }
            get { return _specialfeature; }
        }
        /// <summary>
        /// The COMMENT Field of PROJECTCONSULTING Table
        /// </summary>
        private string _comment;
        [DataField("COMMENT"
            , AliasName = "COMMENT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 500
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COMMENT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COMMENT
        {
            set { _comment = value; }
            get { return _comment; }
        }
        /// <summary>
        /// The BD Field of PROJECTCONSULTING Table
        /// </summary>
        private string _bd;
        [DataField("BD"
            , AliasName = "BD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "BD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string BD
        {
            set { _bd = value; }
            get { return _bd; }
        }
        /// <summary>
        /// The CUSTOMER Field of PROJECTCONSULTING Table
        /// </summary>
        private string _customer;
        [DataField("CUSTOMER"
            , AliasName = "CUSTOMER"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CUSTOMER"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CUSTOMER
        {
            set { _customer = value; }
            get { return _customer; }
        }
        /// <summary>
        /// The CONSULTATIONDATE Field of PROJECTCONSULTING Table
        /// </summary>
        private DateTime _consultationdate;
        [DataField("CONSULTATIONDATE"
            , AliasName = "CONSULTATIONDATE"
            , DataType = DbType.Date
            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CONSULTATIONDATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 39
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime CONSULTATIONDATE
        {
            set { _consultationdate = value; }
            get { return _consultationdate; }
        }
        /// <summary>
        /// The CONSULTATIONDAYS Field of PROJECTCONSULTING Table
        /// </summary>
        private string _consultationdays;
        [DataField("CONSULTATIONDAYS"
            , AliasName = "CONSULTATIONDAYS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CONSULTATIONDAYS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 42
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CONSULTATIONDAYS
        {
            set { _consultationdays = value; }
            get { return _consultationdays; }
        }
        /// <summary>
        /// The ISENABLED Field of PROJECTCONSULTING Table
        /// </summary>
        private string _isenabled;
        [DataField("ISENABLED"
            , AliasName = "ISENABLED"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ISENABLED"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 45
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ISENABLED
        {
            set { _isenabled = value; }
            get { return _isenabled; }
        }
        /// <summary>
        /// The CAUSE Field of PROJECTCONSULTING Table
        /// </summary>
        private string _cause;
        [DataField("CAUSE"
            , AliasName = "CAUSE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CAUSE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 48
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CAUSE
        {
            set { _cause = value; }
            get { return _cause; }
        }
        /// <summary>
        /// The PROJECTNO Field of PROJECTCONSULTING Table
        /// </summary>
        private string _projectno;
        [DataField("PROJECTNO"
            , AliasName = "PROJECTNO"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROJECTNO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 51
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PROJECTNO
        {
            set { _projectno = value; }
            get { return _projectno; }
        }
        /// <summary>
        /// The EMAILLINK Field of PROJECTCONSULTING Table
        /// </summary>
        private string _emaillink;
        [DataField("EMAILLINK"
            , AliasName = "EMAILLINK"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "EMAILLINK"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 54
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string EMAILLINK
        {
            set { _emaillink = value; }
            get { return _emaillink; }
        }
        /// <summary>
		/// The TIME_OF_UPDATE Field of PROJECTCONSULTING Table
		/// </summary>
		private DateTime _time_of_update;
        [DataField("TIME_OF_UPDATE"
            , AliasName = "TIME_OF_UPDATE"
            , DataType = DbType.Date

            , IsNullable = true
            , Size = 3
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TIME_OF_UPDATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 57
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime TIME_OF_UPDATE
        {
            set { _time_of_update = value; }
            get { return _time_of_update; }
        }
        /// <summary>
        /// The NAME_OF_UPDATE Field of PROJECTCONSULTING Table
        /// </summary>
        private string _name_of_update;
        [DataField("NAME_OF_UPDATE"
            , AliasName = "NAME_OF_UPDATE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 127
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "NAME_OF_UPDATE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 60
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string NAME_OF_UPDATE
        {
            set { _name_of_update = value; }
            get { return _name_of_update; }
        }

        /// <summary>
        /// PROJECTCONSULTING Table 
        /// </summary>
        public const string TABLE_NAME = "PROJECTCONSULTING";
        public const String PROJECTCONSULTING_ID_FIELD = "PROJECTCONSULTING_ID";
        public const String MODELID_FIELD = "MODELID";
        public const String CANCERTYPE_FIELD = "CANCERTYPE";
        public const String LIVESTATUS_FIELD = "LIVESTATUS";
        public const String PN_FIELD = "PN";
        public const String LOCATION_FIELD = "LOCATION";
        public const String ESTIMATED_TIMEFRAME_OF_INOCULATION_FIELD = "ESTIMATED_TIMEFRAME_OF_INOCULATION";
        public const String CONFIDENCESCORE_FIELD = "CONFIDENCESCORE";
        public const String AVAILABLEIN_FIELD = "AVAILABLEIN";
        public const String SPECIALFEATURE_FIELD = "SPECIALFEATURE";
        public const String COMMENT_FIELD = "COMMENT";
        public const String BD_FIELD = "BD";
        public const String CUSTOMER_FIELD = "CUSTOMER";
        public const String CONSULTATIONDATE_FIELD = "CONSULTATIONDATE";
        public const String CONSULTATIONDAYS_FIELD = "CONSULTATIONDAYS";
        public const String ISENABLED_FIELD = "ISENABLED";
        public const String CAUSE_FIELD = "CAUSE";
        public const String PROJECTNO_FIELD = "PROJECTNO";
        public const String EMAILLINK_FIELD = "EMAILLINK";
        public const String TIME_OF_UPDATE_FIELD = "TIME_OF_UPDATE";
        public const String NAME_OF_UPDATE_FIELD = "NAME_OF_UPDATE";
    }
}