using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for CANCER_SUBTYPE2 Table
    /// </summary>
    [Serializable]
    [DataTable("CANCER_SUBTYPE2", ResourceKey = "CANCER_SUBTYPE2")]
    public class CANCER_SUBTYPE2 : BaseObject
    {
        public CANCER_SUBTYPE2()
        {
        }
        public CANCER_SUBTYPE2(DealModel initModel)
            : base(initModel)
        {
        }
        public static CANCER_SUBTYPE2 Convert(BaseObject from)
        {
            return (CANCER_SUBTYPE2)from;
        }
        /// <summary>
        /// The SUBTYPE2 Field of CANCER_SUBTYPE2 Table
        /// </summary>
        private string _subtype2;
        [DataField("SUBTYPE2"
            , AliasName = "SUBTYPE2"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 300
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SUBTYPE2"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 0
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SUBTYPE2
        {
            set { _subtype2 = value; }
            get { return _subtype2; }
        }
        /// <summary>
        /// CANCER_SUBTYPE2 Table 
        /// </summary>
        public const string TABLE_NAME = "CANCER_SUBTYPE2";
        public const String SUBTYPE2_FIELD = "SUBTYPE2";
    }
}