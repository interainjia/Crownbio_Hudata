using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for SYS_USER_ROLE Table
	/// </summary>
	[Serializable]
    [DataTable("SYS_USER_PROJECT", ResourceKey = "SYS_USER_PROJECT")]
	public class SYS_USER_PROJECT: BaseObject
	{
        public SYS_USER_PROJECT()
		{
		}
		public SYS_USER_PROJECT(DealModel initModel):base(initModel)
		{
		}
		public static SYS_USER_PROJECT Convert(BaseObject from)
		{
            return (SYS_USER_PROJECT)from;
		}
		/// <summary>
		/// The USER_ROLE_ID Field of SYS_USER_ROLE Table
		/// </summary>
		private decimal _user_role_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.USER_ROLE_ID = value; }
			get { return USER_ROLE_ID; }
		}


        /// <summary>
        /// ¸²¸ÇCODEµÄÖµ
        /// </summary>
        public override string CODE
        {
            set
            {
                base.CODE = value;
                this.ROLE_NO = value;
            }
            get { return ROLE_NO; }
        }

		public decimal USER_ROLE_ID
		{
			set { _user_role_id = value; }
			get { return _user_role_id; }
		}
		/// <summary>
		/// The USER_ID Field of SYS_USER_ROLE Table
		/// </summary>
		private decimal _user_id;

		public decimal USER_ID
		{
			set { _user_id = value; }
			get { return _user_id; }
		}
		/// <summary>
		/// The ROLE_NO Field of SYS_USER_ROLE Table
		/// </summary>
		private string _role_no;
        public string ROLE_NO
        {
            set { _role_no = value; }
            get { return _role_no; }
        }

        private string _role_type;
        public string ROLE_TYPE
        {
            set { _role_type = value; }
            get { return _role_type; }
        }
        private string _project_code;
        public string PROJECT_CODE
        {
            set { _project_code = value; }
            get { return _project_code; }
        }
        private string _admin_type;
        public string ADMIN_TYPE
        {
            set { _admin_type = value; }
            get { return _admin_type; }
        }
        private string _project_name;
        public string PROJECT_NAME
        {
            set { _project_name = value; }
            get { return _project_name; }
        }
        private string _beling_co_code;
        public string BELING_CO_CODE
        {
            set { _beling_co_code = value; }
            get { return _beling_co_code; }
        }
        private string _beling_co_name;
        public string BELING_CO_NAME
        {
            set { _beling_co_name = value; }
            get { return _beling_co_name; }
        }
        [DataField("ADMIN_TYPE"
          , AliasName = "ADMIN_TYPE"
          , DataType = DbType.String
          , IsNullable = false
          , Size = 1
          , Width = 240
          , DisplayInCondition = true
          , DisplayInMaintain = true
          , DisplayInDialog = false
          , ResourceKey = "ADMIN_TYPE"
          , AllowEdit = true
          , Frozen = false
          , SelectSequence = 1
          , IsInsertField = false
          , IsUpdateField = false
           )]
        public const String ADMIN_TYPE_FIELD = "ADMIN_TYPE";

        [DataField("PROJECT_NAME"
           , AliasName = "PROJECT_NAME"
           , DataType = DbType.String
           , IsNullable = false
           , Size = 1
           , Width = 240
           , DisplayInCondition = true
           , DisplayInMaintain = true
           , DisplayInDialog = false
           , ResourceKey = "PROJECT_NAME"
           , AllowEdit = true
           , Frozen = false
           , SelectSequence = 1
           , IsInsertField = false
           , IsUpdateField = false
            )]
        public const String PROJECT_NAME_FIELD = "PROJECT_NAME";

        [DataField("BELING_CO_NAME"
             , AliasName = "BELING_CO_NAME"
             , DataType = DbType.String
             , IsNullable = false
             , Size = 1
             , Width = 240
             , DisplayInCondition = true
             , DisplayInMaintain = true
             , DisplayInDialog = false
             , ResourceKey = "BELING_CO_NAME"
             , AllowEdit = true
             , Frozen = false
             , SelectSequence = 1
             , IsInsertField = false
             , IsUpdateField = false
              )]

        public const String BELING_CO_NAME_FIELD = "BELING_CO_NAME";
		/// <summary>
		/// SYS_USER_ROLE Table 
		/// </summary>
        public const string TABLE_NAME = "SYS_USER_PROJECT";
		public const String USER_ROLE_ID_FIELD  ="USER_ROLE_ID";
		public const String USER_ID_FIELD  ="USER_ID";
		public const String ROLE_NO_FIELD  ="ROLE_NO";
	}
}