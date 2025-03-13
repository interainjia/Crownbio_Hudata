using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for MUTATION Table
    /// </summary>
    [Serializable]
    [DataTable("MUTATION", ResourceKey = "MUTATION")]
    public class MUTATION : BaseObject
    {
        public MUTATION()
        {
        }
        public MUTATION(DealModel initModel)
            : base(initModel)
        {
        }
        public static MUTATION Convert(BaseObject from)
        {
            return (MUTATION)from;
        }
        /// <summary>
        /// The MUTATION_ID Field of MUTATION Table
        /// </summary>
        private decimal _mutation_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.MUTATION_ID = value;
            }
            get { return MUTATION_ID; }
        }

        [RecordIDField("MUTATION_ID"
            , AliasName = "MUTATION_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "MUTATION_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal MUTATION_ID
        {
            set { _mutation_id = value; }
            get { return _mutation_id; }
        }
        /// <summary>
        /// The SAMPLE_NAME Field of MUTATION Table
        /// </summary>
        private string _sample_name;
        [DataField("SAMPLE_NAME"
            , AliasName = "SAMPLE_NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SAMPLE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SAMPLE_NAME
        {
            set { _sample_name = value; }
            get { return _sample_name; }
        }
        /// <summary>
        /// The ORIGINAL_ID Field of MUTATION Table
        /// </summary>
        private string _original_id;
        [DataField("ORIGINAL_ID"
            , AliasName = "ORIGINAL_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ORIGINAL_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ORIGINAL_ID
        {
            set { _original_id = value; }
            get { return _original_id; }
        }
        /// <summary>
        /// The TUMOR_TYPE Field of MUTATION Table
        /// </summary>
        private string _tumor_type;
        [DataField("TUMOR_TYPE"
            , AliasName = "TUMOR_TYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TUMOR_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TUMOR_TYPE
        {
            set { _tumor_type = value; }
            get { return _tumor_type; }
        }
        /// <summary>
        /// The KRAS Field of MUTATION Table
        /// </summary>
        private string _kras;
        [DataField("KRAS"
            , AliasName = "KRAS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "KRAS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string KRAS
        {
            set { _kras = value; }
            get { return _kras; }
        }
        /// <summary>
        /// The EGFR Field of MUTATION Table
        /// </summary>
        private string _egfr;
        [DataField("EGFR"
            , AliasName = "EGFR"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "EGFR"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string EGFR
        {
            set { _egfr = value; }
            get { return _egfr; }
        }
        /// <summary>
        /// The PIK3CA Field of MUTATION Table
        /// </summary>
        private string _pik3ca;
        [DataField("PIK3CA"
            , AliasName = "PIK3CA"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PIK3CA"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PIK3CA
        {
            set { _pik3ca = value; }
            get { return _pik3ca; }
        }
        /// <summary>
        /// The MET Field of MUTATION Table
        /// </summary>
        private string _met;
        [DataField("MET"
            , AliasName = "MET"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MET"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MET
        {
            set { _met = value; }
            get { return _met; }
        }
        /// <summary>
        /// The AKT1 Field of MUTATION Table
        /// </summary>
        private string _akt1;
        [DataField("AKT1"
            , AliasName = "AKT1"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "AKT1"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string AKT1
        {
            set { _akt1 = value; }
            get { return _akt1; }
        }
        /// <summary>
        /// The BRAF Field of MUTATION Table
        /// </summary>
        private string _braf;
        [DataField("BRAF"
            , AliasName = "BRAF"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "BRAF"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string BRAF
        {
            set { _braf = value; }
            get { return _braf; }
        }
        /// <summary>
        /// The MAPK1 Field of MUTATION Table
        /// </summary>
        private string _mapk1;
        [DataField("MAPK1"
            , AliasName = "MAPK1"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MAPK1"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MAPK1
        {
            set { _mapk1 = value; }
            get { return _mapk1; }
        }
        /// <summary>
        /// The TP53 Field of MUTATION Table
        /// </summary>
        private string _tp53;
        [DataField("TP53"
            , AliasName = "TP53"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "TP53"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TP53
        {
            set { _tp53 = value; }
            get { return _tp53; }
        }
        /// <summary>
        /// The PTEN Field of MUTATION Table
        /// </summary>
        private string _pten;
        [DataField("PTEN"
            , AliasName = "PTEN"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PTEN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PTEN
        {
            set { _pten = value; }
            get { return _pten; }
        }
        /// <summary>
        /// The CTNNB1 Field of MUTATION Table
        /// </summary>
        private string _ctnnb1;
        [DataField("CTNNB1"
            , AliasName = "CTNNB1"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CTNNB1"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 39
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CTNNB1
        {
            set { _ctnnb1 = value; }
            get { return _ctnnb1; }
        }
        /// <summary>
        /// MUTATION Table 
        /// </summary>
        public const string TABLE_NAME = "MUTATION";
        public const String MUTATION_ID_FIELD = "MUTATION_ID";
        public const String SAMPLE_NAME_FIELD = "SAMPLE_NAME";
        public const String ORIGINAL_ID_FIELD = "ORIGINAL_ID";
        public const String TUMOR_TYPE_FIELD = "TUMOR_TYPE";
        public const String KRAS_FIELD = "KRAS";
        public const String EGFR_FIELD = "EGFR";
        public const String PIK3CA_FIELD = "PIK3CA";
        public const String MET_FIELD = "MET";
        public const String AKT1_FIELD = "AKT1";
        public const String BRAF_FIELD = "BRAF";
        public const String MAPK1_FIELD = "MAPK1";
        public const String TP53_FIELD = "TP53";
        public const String PTEN_FIELD = "PTEN";
        public const String CTNNB1_FIELD = "CTNNB1";
    }
}