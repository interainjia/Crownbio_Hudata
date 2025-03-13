using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for XENO_SOCDATA Table
    /// </summary>
    [Serializable]
    [DataTable("XENO_SOCDATA", ResourceKey = "XENO_SOCDATA")]
    public class XENO_SOCDATA : BaseObject
    {
        public XENO_SOCDATA()
        {
        }
        public XENO_SOCDATA(DealModel initModel)
            : base(initModel)
        {
        }
        public static XENO_SOCDATA Convert(BaseObject from)
        {
            return (XENO_SOCDATA)from;
        }
        /// <summary>
        /// The XENO_SOCDATA_ID Field of XENO_SOCDATA Table
        /// </summary>
        private decimal _xeno_socdata_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.XENO_SOCDATA_ID = value;
            }
            get { return XENO_SOCDATA_ID; }
        }

        [RecordIDField("XENO_SOCDATA_ID"
            , AliasName = "XENO_SOCDATA_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "XENO_SOCDATA_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal XENO_SOCDATA_ID
        {
            set { _xeno_socdata_id = value; }
            get { return _xeno_socdata_id; }
        }
        /// <summary>
        /// The TREATMENT Field of XENO_SOCDATA Table
        /// </summary>
        private string _treatment;
        [DataField("TREATMENT"
            , AliasName = "TREATMENT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TREATMENT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TREATMENT
        {
            set { _treatment = value; }
            get { return _treatment; }
        }
        /// <summary>
        /// The TUMORSIZE Field of XENO_SOCDATA Table
        /// </summary>
        private string _tumorsize;
        [DataField("TUMORSIZE"
            , AliasName = "TUMORSIZE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TUMORSIZE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TUMORSIZE
        {
            set { _tumorsize = value; }
            get { return _tumorsize; }
        }
        /// <summary>
        /// The TC_VALUE Field of XENO_SOCDATA Table
        /// </summary>
        private string _tc_value;
        [DataField("TC_VALUE"
            , AliasName = "TC_VALUE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TC_VALUE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TC_VALUE
        {
            set { _tc_value = value; }
            get { return _tc_value; }
        }
        /// <summary>
        /// The T_CDAYS Field of XENO_SOCDATA Table
        /// </summary>
        private string _t_cdays;
        [DataField("T_CDAYS"
            , AliasName = "T_CDAYS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "T_CDAYS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string T_CDAYS
        {
            set { _t_cdays = value; }
            get { return _t_cdays; }
        }
        /// <summary>
        /// The P_VALUE Field of XENO_SOCDATA Table
        /// </summary>
        private string _p_value;
        [DataField("P_VALUE"
            , AliasName = "P_VALUE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "P_VALUE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string P_VALUE
        {
            set { _p_value = value; }
            get { return _p_value; }
        }
        /// <summary>
        /// The CELLLINE Field of XENO_SOCDATA Table
        /// </summary>
        private string _cellline;
        [DataField("CELLLINE"
            , AliasName = "CELLLINE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CELLLINE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CELLLINE
        {
            set { _cellline = value; }
            get { return _cellline; }
        }
      
        /// <summary>
        /// The XENOID Field of XENO_PIC Table
        /// </summary>
        private string _xenoid;
        [DataField("XENOID"
            , AliasName = "XENOID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "XENOID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string XENOID
        {
            set { _xenoid = value; }
            get { return _xenoid; }
        }

        /// <summary>
        /// XENO_SOCDATA Table 
        /// </summary>
        public const string TABLE_NAME = "XENO_SOCDATA";
        public const String XENO_SOCDATA_ID_FIELD = "XENO_SOCDATA_ID";
        public const String TREATMENT_FIELD = "TREATMENT";
        public const String TUMORSIZE_FIELD = "TUMORSIZE";
        public const String TC_VALUE_FIELD = "TC_VALUE";
        public const String T_CDAYS_FIELD = "T_CDAYS";
        public const String P_VALUE_FIELD = "P_VALUE";
        public const String CELLLINE_FIELD = "CELLLINE";
        public const String XENOID_FIELD = "XENOID";
    }
}