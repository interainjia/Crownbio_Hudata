using System;
using System.Data;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;
using System.Reflection;
using Crownbio.Common;
namespace Crownbio.Model
{
    /// <summary>
    /// Object Data Class for SYS_PERM Table
    /// </summary>
    [Serializable]
    [DataTable("SYS_PERM", ResourceKey = "SYS_PERM")]
    public class SYS_PERM : BaseObject
    {
        public SYS_PERM()
        {
        }
        public SYS_PERM(DealModel initModel)
            : base(initModel)
        {
        }
        public static SYS_PERM Convert(BaseObject from)
        {
            return (SYS_PERM)from;
        }

        /// <summary>
        /// The PERM_ID Field of SYS_PERM Table
        /// </summary>
        private decimal _perm_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.PERM_ID = value;
            }
            get { return PERM_ID; }
        }


        /// <summary>
        /// 覆盖CODE的值
        /// </summary>
        public override string CODE
        {
            set
            {
                base.CODE = value;
                this.FUNCTION_ID = value;
            }
            get { return FUNCTION_ID; }
        }



        [RecordIDField("PERM_ID"
            , AliasName = "PERM_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PERM_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal PERM_ID
        {
            set { _perm_id = value; }
            get { return _perm_id; }
        }

        private decimal _user_id;
        public decimal USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        private string _role_no;
        [KeyField("ROLE_NO"
            , AliasName = "ROLE_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "ROLE_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 3
            , DialogSequence = 3
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 0
             )]
     
        public string ROLE_NO
        {
            set { _role_no = value; }
            get { return _role_no; }
        }

        /// <summary>
        /// The FUNCTION_ID Field of SYS_PERM Table
        /// </summary>
        private string _function_id;
        [KeyField("FUNCTION_ID"
            , AliasName = "FUNCTION_ID"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "FUNCTION_ID"
            , GroupFun = ""
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 6
            , DialogSequence = 6
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 1
             )]
      
        public string FUNCTION_ID
        {
            set { _function_id = value; }
            get { return _function_id; }
        }

     

      







    

        /// <summary>
        /// The CREATE_BY Field of SYS_PERM Table
        /// </summary>
        private decimal _create_by;
        [DataField("CREATE_BY"
            , AliasName = "CREATE_BY"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 9
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "CREATE_BY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 101
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = false
            , DefaultValue = "UserID"
             )]
        public decimal CREATE_BY
        {
            set { _create_by = value; }
            get { return _create_by; }
        }
        /// <summary>
        /// The CREATE_TIME Field of SYS_PERM Table
        /// </summary>
        private DateTime _create_time;
        [DataField("CREATE_TIME"
            , AliasName = "CREATE_TIME"
            , DataType = DbType.DateTime
            , IsNullable = false
            , Size = 20
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "CREATE_TIME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 102
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = false
            , DefaultValue = "SysDate"
             )]
        public DateTime CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// The UPDATE_BY Field of SYS_PERM Table
        /// </summary>
        private decimal _update_by;
        [DataField("UPDATE_BY"
            , AliasName = "UPDATE_BY"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 9
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "UPDATE_BY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 103
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "UserID"
             )]
        public decimal UPDATE_BY
        {
            set { _update_by = value; }
            get { return _update_by; }
        }
        /// <summary>
        /// The UPDATE_TIME Field of SYS_PERM Table
        /// </summary>
        private DateTime _update_time;
        [DataField("UPDATE_TIME"
            , AliasName = "UPDATE_TIME"
            , DataType = DbType.DateTime
            , IsNullable = false
            , Size = 20
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "UPDATE_TIME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , SelectSequence = 104
            , DialogSequence = -1
            , Frozen = false
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "SysDate"
             )]
        public DateTime UPDATE_TIME
        {
            set { _update_time = value; }
            get { return _update_time; }
        }
        /// <summary>
        /// SYS_PERM Table 
        /// </summary>
        public const string TABLE_NAME = "SYS_PERM";
        public const String CHECK_CODE_FIELD = "CHECK_CODE";
        public const String PERM_ID_FIELD = "PERM_ID";
        public const String ROLE_NO_FIELD = "ROLE_NO";
        public const String FUNCTION_ID_FIELD = "FUNCTION_ID";
        public const String CREATE_BY_FIELD = "CREATE_BY";
        public const String CREATE_TIME_FIELD = "CREATE_TIME";
        public const String UPDATE_BY_FIELD = "UPDATE_BY";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
    }


    /// <summary>
    /// 定义用户权限集
    /// </summary>
    [Serializable]
    public class PermCollection : List<SYS_PERM>, ILogicalThreadAffinative
    {
        private string _PermCode;


        public PermCollection()
        {

        }

        /// <summary>
        /// 查询符合条件的权限值
        /// </summary>
        /// <param name="v_PermCode"></param>
        /// <returns></returns>
        public SYS_PERM Find(string v_PermCode)
        {
            _PermCode = v_PermCode;
            return base.Find(CheckPerm);
        }

        private bool CheckPerm(SYS_PERM v_Perm)
        {
            if (v_Perm.FUNCTION_ID == _PermCode)
                return true;
            else return false;
        }

    

     
        /// <summary>
        /// 从BaseList转为PermList
        /// </summary>
        /// <param name="srclist"></param>
        /// <returns></returns>
        public static PermCollection converToPermList(BaseList srclist)
        {
            PermCollection permlist = new PermCollection();
            foreach (BaseObject obj in srclist)
            {
                permlist.Add((SYS_PERM)obj);
            }
            return permlist;
        }

        public static PermCollection converToBaseList(PermCollection srclist)
        {
            PermCollection permlist = new PermCollection();
            foreach (SYS_PERM obj in srclist)
            {
                permlist.Add(obj);
            }
            return permlist;
        }

        /// <summary>
        /// 将List<BaseObject>转为BaseList
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns></returns>
        public static BaseList convertToBaseList(List<SYS_PERM> dataList)
        {
            BaseList _data = new BaseList();
            foreach (SYS_PERM ob in dataList)
            {
                _data.Add(ob);
            }
            return _data;
        }

    }
}