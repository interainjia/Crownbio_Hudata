using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for CANCERTYPE_ABBR Table
    /// </summary>
    [Serializable]
    [DataTable("CANCERTYPE_ABBR", ResourceKey = "CANCERTYPE_ABBR")]
    public class CANCERTYPE_ABBR : BaseObject
    {
        public CANCERTYPE_ABBR()
        {
        }
        public CANCERTYPE_ABBR(DealModel initModel)
            : base(initModel)
        {
        }
        public static CANCERTYPE_ABBR Convert(BaseObject from)
        {
            return (CANCERTYPE_ABBR)from;
        }
        /// <summary>
        /// The CANCER_TYPE Field of CANCERTYPE_ABBR Table
        /// </summary>
        private string _cancer_type;
        [DataField("CANCER_TYPE"
            , AliasName = "CANCER_TYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CANCER_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 0
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CANCER_TYPE
        {
            set { _cancer_type = value; }
            get { return _cancer_type; }
        }
        /// <summary>
        /// The ABBREVIATION Field of CANCERTYPE_ABBR Table
        /// </summary>
        private string _abbreviation;
        [DataField("ABBREVIATION"
            , AliasName = "ABBREVIATION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ABBREVIATION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ABBREVIATION
        {
            set { _abbreviation = value; }
            get { return _abbreviation; }
        }
        /// <summary>
        /// CANCERTYPE_ABBR Table 
        /// </summary>
        public const string TABLE_NAME = "CANCERTYPE_ABBR";
        public const String CANCER_TYPE_FIELD = "CANCER_TYPE";
        public const String ABBREVIATION_FIELD = "ABBREVIATION";
    }
}