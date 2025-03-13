using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for CANCER_SUBTYPE1 Table
    /// </summary>
    [Serializable]
    [DataTable("CANCER_SUBTYPE1", ResourceKey = "CANCER_SUBTYPE1")]
    public class CANCER_SUBTYPE1 : BaseObject
    {
        public CANCER_SUBTYPE1()
        {
        }
        public CANCER_SUBTYPE1(DealModel initModel)
            : base(initModel)
        {
        }
        public static CANCER_SUBTYPE1 Convert(BaseObject from)
        {
            return (CANCER_SUBTYPE1)from;
        }
        /// <summary>
        /// The SUBTYPE1 Field of CANCER_SUBTYPE1 Table
        /// </summary>
        private string _subtype1;
        [DataField("SUBTYPE1"
            , AliasName = "SUBTYPE1"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 300
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SUBTYPE1"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 0
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SUBTYPE1
        {
            set { _subtype1 = value; }
            get { return _subtype1; }
        }
        /// <summary>
        /// CANCER_SUBTYPE1 Table 
        /// </summary>
        public const string TABLE_NAME = "CANCER_SUBTYPE1";
        public const String SUBTYPE1_FIELD = "SUBTYPE1";
    }
}