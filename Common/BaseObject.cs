using System;
using System.Data;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;
using System.Reflection;

namespace Crownbio.Common
{
    /// <summary>
    /// 用于在Client与Server间传递的基础Data
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    [Serializable]
    public class BaseObject : ILogicalThreadAffinative
    {
        public BaseObject()
        {
            this._curModel = DealModel.None;
        }

        public BaseObject(DealModel initModel)
        {
            this._curModel = initModel;

        }

        #region 委托方法
        /// <summary>
        /// 所有已选择的数据资料
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool IsChecked(BaseObject from)
        {
            if (from.CHECK_CODE == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是否删除的数据
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool IsDelete(BaseObject from)
        {
            if (from.CurModel == DealModel.Delete)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是否新增的数据
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool IsNew(BaseObject from)
        {
            if (from.CurModel == DealModel.New)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是否修改的数据
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool IsModify(BaseObject from)
        {
            if (from.CurModel == DealModel.Modify)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是否无状态的数据
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool IsNoChange(BaseObject from)
        {
            if (from.CurModel == DealModel.None)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是否搜索状态的数据
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool IsSearch(BaseObject from)
        {
            if (from.CurModel == DealModel.Search)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 非删除状态的数据
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool IsNotDelete(BaseObject from)
        {
            if (from.CurModel != DealModel.Delete)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 清空当前数据行状态
        /// </summary>
        /// <param name="obj"></param>
        public static void NoneFlag(BaseObject obj)
        {
            obj.CurModel = DealModel.None;
        }

        /// <summary>
        /// 标记需要删除的数据
        /// </summary>
        /// <param name="obj"></param>
        public static void DeleteFlag(BaseObject obj)
        {
            obj.CurModel = DealModel.Delete;
        }
        #endregion
        /// <summary>
        /// 当前操作模式
        /// </summary>
        private DealModel _curModel = new DealModel();
        public DealModel CurModel
        {
            set { _curModel = value; }
            get { return _curModel; }
        }

        private decimal _id;
        public virtual decimal ID
        {
            set { _id = value; }
            get { return _id; }
        }

        private decimal pid;
        public virtual decimal PID
        {
            set { pid = value; }
            get { return pid; }
        }

        private string _code;
        public virtual string CODE
        {
            set { _code = value; }
            get { return _code; }
        }

        #region 下拉框
        private string _desc;
        public virtual string DESC
        {
            set { _desc = value; }
            get { return _desc; }
        }
        #endregion

        private int _check_code = 0;
        [ExpressionField("{0}"
            , AliasName = "CHECK_CODE"
            , DataType = DbType.Boolean
            , IsNullable = false
            , Size = 1
            , Width = 50
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SELECT_COLUMN"
            , GroupFun = ""
            , AllowEdit = true
            , Frozen = true
            , SelectSequence = 1
            , DialogSequence = 0
            , ParaDefaultValue = new string[] { "0" }
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public virtual int CHECK_CODE
        {
            set { _check_code = value; }
            get { return _check_code; }
        }

    }

    [Serializable]
    public class BaseList : List<BaseObject>, ILogicalThreadAffinative
    {
        private decimal _id;
        private string _code;
        public BaseList()
        {

        }
        /// <summary>
        /// 根据ID返回BaseObject
        /// </summary>
        /// <param name="v_id"></param>
        /// <returns></returns>
        public BaseObject Find(decimal v_id)
        {
            _id = v_id;
            return base.Find(getID);
        }

        private bool getID(BaseObject obj)
        {
            if (obj.ID == _id)
                return true;
            else return false;
        }

        /// <summary>
        /// 根据CODE返回BaseObject
        /// </summary>
        /// <param name="v_code"></param>
        /// <returns></returns>
        public BaseObject Find(string v_code)
        {
            _code = v_code;
            return base.Find(getCODE);
        }
        /// <summary>
        /// 根据code返回ListBaseObject
        /// </summary>
        /// <param name="v_code"></param>
        /// <returns></returns>
        public List<BaseObject> FindAll(string v_code)
        {
            _code = v_code;
            return base.FindAll(getCODE);
        }

        private bool getCODE(BaseObject obj)
        {
            if (obj.CODE == _code)
                return true;
            else return false;
        }

        private int _count = 0;

        /// <summary>
        /// 当前页面实际查询记录数
        /// </summary>
        public int ListCount
        {
            get { return _count; }
            set { _count = value; }
        }
        /// <summary>
        /// 将List<BaseObject>转为BaseList
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns></returns>
        public static BaseList convertToBaseList(List<BaseObject> dataList)
        {
            BaseList _data = new BaseList();
            foreach (BaseObject ob in dataList)
            {
                _data.Add(ob);
            }
            return _data;
        }

    }

    /// <summary>
    /// 可排序的数据列表
    /// </summary>
    [Serializable]
    public class SortList<T> : BindingList<T>, ILogicalThreadAffinative
    {


        private bool isSortedCore = true;
        private ListSortDirection sortDirectionCore = ListSortDirection.Ascending;
        private PropertyDescriptor sortPropertyCore = null;
        private string defaultSortItem;
        public SortList()
            : base()
        {
        }
        public SortList(IList<T> list)
            : base(list)
        {
        }
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }
        protected override bool IsSortedCore
        {
            get { return isSortedCore; }
        }
        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirectionCore; }
        }
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortPropertyCore; }
        }
        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (Equals(prop.GetValue(this[i]), key))
                    return i;
            }
            return -1;
        }
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            isSortedCore = true;
            sortPropertyCore = prop;
            sortDirectionCore = direction;
            Sort();
        }
        protected override void RemoveSortCore()
        {
            if (isSortedCore)
            {
                isSortedCore = false;
                sortPropertyCore = null;
                sortDirectionCore = ListSortDirection.Ascending;
                Sort();
            }
        }
        public string DefaultSortItem
        {
            get { return defaultSortItem; }
            set
            {
                if (defaultSortItem != value)
                {
                    defaultSortItem = value;
                    Sort();
                }
            }
        }
        public void DoSort(string SortItem, ListSortDirection direction)
        {
            sortDirectionCore = direction;
            this.DefaultSortItem = SortItem;
        }

        private void Sort()
        {
            List<T> list = (this.Items as List<T>);
            list.Sort(CompareCore); ResetBindings();
        }
        private int CompareCore(T o1, T o2)
        {
            int ret = 0;
            if (SortPropertyCore != null)
            {
                ret = CompareValue(SortPropertyCore.GetValue(o1), SortPropertyCore.GetValue(o2), SortPropertyCore.PropertyType);
            }
            if (ret == 0 && DefaultSortItem != null)
            {
                PropertyInfo property = typeof(T).GetProperty(DefaultSortItem, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase, null, null, new Type[0], null);
                if (property != null)
                {
                    ret = CompareValue(property.GetValue(o1, null), property.GetValue(o2, null), property.PropertyType);
                }
            }
            if (SortDirectionCore == ListSortDirection.Descending)
                ret = -ret;
            return ret;
        }
        private static int CompareValue(object o1, object o2, Type type)
        {
            //这里改成自己定义的比较  
            if (o1 == null)
                return o2 == null ? 0 : -1;
            else if (o2 == null)
                return 1;
            else if (type.IsPrimitive || type.IsEnum)
                return Convert.ToDouble(o1).CompareTo(Convert.ToDouble(o2));
            else if (type == typeof(DateTime))
                return Convert.ToDateTime(o1).CompareTo(o2);
            else
                return String.Compare(o1.ToString().Trim(), o2.ToString().Trim());
        }
    }

}
