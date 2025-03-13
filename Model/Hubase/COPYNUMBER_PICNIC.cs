using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for COPYNUMBER_PICNIC Table
    /// </summary>
    [Serializable]
    [DataTable("COPYNUMBER_PICNIC", ResourceKey = "COPYNUMBER_PICNIC")]
    public class COPYNUMBER_PICNIC : BaseObject
    {
        public COPYNUMBER_PICNIC()
        {
        }
        public COPYNUMBER_PICNIC(DealModel initModel)
            : base(initModel)
        {
        }
        public static COPYNUMBER_PICNIC Convert(BaseObject from)
        {
            return (COPYNUMBER_PICNIC)from;
        }
        /// <summary>
        /// The COPYNUMBER_PICNIC_ID Field of COPYNUMBER_PICNIC Table
        /// </summary>
        private decimal _copynumber_picnic_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.COPYNUMBER_PICNIC_ID = value;
            }
            get { return COPYNUMBER_PICNIC_ID; }
        }

        [RecordIDField("COPYNUMBER_PICNIC_ID"
            , AliasName = "COPYNUMBER_PICNIC_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "COPYNUMBER_PICNIC_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal COPYNUMBER_PICNIC_ID
        {
            set { _copynumber_picnic_id = value; }
            get { return _copynumber_picnic_id; }
        }
        /// <summary>
        /// The GENE Field of COPYNUMBER_PICNIC Table
        /// </summary>
        private string _gene;
        [DataField("GENE"
            , AliasName = "GENE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "GENE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string GENE
        {
            set { _gene = value; }
            get { return _gene; }
        }
        /// <summary>
        /// The PDXMODEL Field of COPYNUMBER_PICNIC Table
        /// </summary>
        private string _pdxmodel;
        [DataField("PDXMODEL"
            , AliasName = "PDXMODEL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PDXMODEL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PDXMODEL
        {
            set { _pdxmodel = value; }
            get { return _pdxmodel; }
        }
        /// <summary>
        /// The MINOR Field of COPYNUMBER_PICNIC Table
        /// </summary>
        private double _minor;
        [DataField("MINOR"
            , AliasName = "MINOR"
            , DataType = DbType.Double
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MINOR"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public double MINOR
        {
            set { _minor = value; }
            get { return _minor; }
        }
        /// <summary>
        /// The VALUE Field of COPYNUMBER_PICNIC Table
        /// </summary>
        private double _value;
        [DataField("VALUE"
            , AliasName = "VALUE"
            , DataType = DbType.Double
            , IsNullable = true
            , Size = 8
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "VALUE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public double VALUE
        {
            set { _value = value; }
            get { return _value; }
        }
        /// <summary>
        /// COPYNUMBER_PICNIC Table 
        /// </summary>
        public const string TABLE_NAME = "COPYNUMBER_PICNIC";
        public const String COPYNUMBER_PICNIC_ID_FIELD = "COPYNUMBER_PICNIC_ID";
        public const String GENE_FIELD = "GENE";
        public const String PDXMODEL_FIELD = "PDXMODEL";
        public const String MINOR_FIELD = "MINOR";
        public const String VALUE_FIELD = "VALUE";
    }
}