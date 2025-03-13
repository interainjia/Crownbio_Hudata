using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for XENO_SOC Table
    /// </summary>
    [Serializable]
    [DataTable("XENO_SOC", ResourceKey = "XENO_SOC")]
    public class XENO_SOC : BaseObject
    {
        public XENO_SOC()
        {
        }
        public XENO_SOC(DealModel initModel)
            : base(initModel)
        {
        }
        public static XENO_SOC Convert(BaseObject from)
        {
            return (XENO_SOC)from;
        }
        /// <summary>
        /// The XENO_SOC_ID Field of XENO_SOC Table
        /// </summary>
        private decimal _xeno_soc_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.XENO_SOC_ID = value;
            }
            get { return XENO_SOC_ID; }
        }

        [RecordIDField("XENO_SOC_ID"
            , AliasName = "XENO_SOC_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "XENO_SOC_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal XENO_SOC_ID
        {
            set { _xeno_soc_id = value; }
            get { return _xeno_soc_id; }
        }
        /// <summary>
        /// The SOC_URL Field of XENO_SOC Table
        /// </summary>
        private string _soc_url;
        [DataField("SOC_URL"
            , AliasName = "SOC_URL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SOC_URL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SOC_URL
        {
            set { _soc_url = value; }
            get { return _soc_url; }
        }
        /// <summary>
        /// The CELLLINE Field of XENO_SOC Table
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
            , SelectSequence = 6
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
        /// XENO_SOC Table 
        /// </summary>
        public const string TABLE_NAME = "XENO_SOC";
        public const String XENO_SOC_ID_FIELD = "XENO_SOC_ID";
        public const String SOC_URL_FIELD = "SOC_URL";
        public const String CELLLINE_FIELD = "CELLLINE";
        public const String XENOID_FIELD = "XENOID";
    }
}