using System;
using System.Collections;
using System.Text;
using System.Data;

namespace Crownbio.Common
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class BaseFieldAttribute : Attribute, IComparable
    {
        string columnName;
        string aliasName = "";
        DbType dataType = DbType.String;
        int size = 0;
        int width = 0;
        bool displayInCondition = true;
        bool displayInMaintain = true;
        bool displayInDialog = true;
        string resourceKey = "";
        string groupfun = "";
        bool allowEdit = true;
        bool frozen = false;
        int selectSequence = 0;
        int dialogSequence = 0;
        bool isInsertField = true;
        bool isUpdateField = true;
        bool isNullable = true;
        string defaultValue = "";
        string[] paraDefaultValue = null;
        string displayFormat = "";
        string tableName = "";
        string tableAliasName = "";
        Byte precision = 13;
        Byte scale = 0;

        #region Constructor

        public BaseFieldAttribute(string columnName)
        {
            this.columnName = columnName;
        }

        #endregion

        #region Property

        /// <summary>
        /// 数据库表中的字段名，也可以是表达式
        /// </summary>
        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        /// <summary>
        /// 数据库表中的字段名、表达式对应的别名
        /// </summary>
        public string AliasName
        {
            get { return aliasName; }
            set { aliasName = value; }
        }

        /// <summary>
        /// 数据库表中的字段名、表达式的数据类型
        /// </summary>
        public DbType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }

        /// <summary>
        /// 数据字段长度，也作为输入时的长度限制
        /// </summary>
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// 数据在控件中显示时要求控件的宽度，如DataGridView的Colomn Width等
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// 该值在查询页中是否要显示
        /// </summary>
        public bool DisplayInCondition
        {
            get { return displayInCondition; }
            set { displayInCondition = value; }
        }

        /// <summary>
        /// 该值是否显示在维护界面中
        /// </summary>
        public bool DisplayInMaintain
        {
            get { return displayInMaintain; }
            set { displayInMaintain = value; }
        }

        /// <summary>
        /// 是否对话选择界面中的字段
        /// </summary>
        public bool DisplayInDialog
        {
            get { return displayInDialog; }
            set { displayInDialog = value; }
        }

        /// <summary>
        /// 栏位对应的信息提示，如Lable控件中的Text属性及DataGrid中的HeaderText属性
        /// </summary>
        public string ResourceKey
        {
            get { return resourceKey; }
            set { resourceKey = value; }
        }

        /// <summary>
        /// Group  by语句中的聚合方法
        /// </summary>
        public string GroupFun
        {
            get { return groupfun; }
            set { groupfun = value; }
        }

        /// <summary>
        /// 该栏位的值是否允许进行编辑
        /// </summary>
        public bool AllowEdit
        {
            get { return allowEdit; }
            set { allowEdit = value; }
        }

        /// <summary>
        /// 左右移动其他列时该列是否处于固定状态
        /// </summary>
        public bool Frozen
        {
            get { return frozen; }
            set { frozen = value; }
        }

        /// <summary>
        /// 该值在DataGridView等网格中的显示顺序
        /// </summary>
        public int SelectSequence
        {
            get { return selectSequence; }
            set { selectSequence = value; }
        }

        /// <summary>
        /// 确定值在Dialog对话框中的显示顺序
        /// </summary>
        public int DialogSequence
        {
            get { return dialogSequence; }
            set { dialogSequence = value; }
        }

        /// <summary>
        /// 是否插入字段
        /// </summary>
        public bool IsInsertField
        {
            get { return isInsertField; }
            set { isInsertField = value; }
        }

        /// <summary>
        /// 是否更新字段
        /// </summary>
        public bool IsUpdateField
        {
            get { return isUpdateField; }
            set { isUpdateField = value; }
        }

        /// <summary>
        /// 是否允许为空
        /// </summary>
        public bool IsNullable
        {
            get { return isNullable; }
            set { isNullable = value; }
        }

        /// <summary>
        /// 如果该字段未进行赋值时使用的默认值
        /// </summary>
        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }

        /// <summary>
        /// 如果该字段有参数，则设置参数的默认值
        /// </summary>
        public string[] ParaDefaultValue
        {
            get { return paraDefaultValue; }
            set { paraDefaultValue = value; }
        }

        /// <summary>
        /// 数据的DisplayFormat
        /// </summary>
        public string DisplayFormat
        {
            get { return displayFormat; }
            set { displayFormat = value; }
        }

        /// <summary>
        /// 数值字段的小数位
        /// </summary>
        public Byte Precision
        {
            get { return precision; }
            set { precision = value; }
        }

        // scale
        public Byte Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        /// <summary>
        /// 表别名
        /// </summary>
        public string TableAliasName
        {
            get
            {
                if (tableAliasName == "")
                {
                    return tableName;
                }
                else
                {
                    return tableAliasName;
                }
            }
            set { tableAliasName = value; }
        }

        #endregion

        #region IComparable Θ

        /// <summary>
        /// 比较当前BaseFieldAttribute与指定BaseFieldAttribute的SelectSequence大小
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            BaseFieldAttribute baseField2 = (BaseFieldAttribute)obj;
            if (this.SelectSequence > baseField2.SelectSequence)
                return 1;
            if (this.SelectSequence < baseField2.SelectSequence)
                return -1;
            else
                return 0;
        }

        #endregion

        #region IComparer

        public static IComparer SortByColumnName
        {
            get { return ((IComparer)new SortByColumnNameComparer()); }
        }

        public static IComparer SortBySelectSequence
        {
            get { return ((IComparer)new SortBySelectSequenceComparer()); }
        }

        #endregion

        #region Nested Class

        public class SortByColumnNameComparer : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                BaseFieldAttribute baseField1 = (BaseFieldAttribute)obj1;
                BaseFieldAttribute baseField2 = (BaseFieldAttribute)obj2;
                return (string.Compare(baseField1.ColumnName, baseField2.ColumnName));
            }
        }

        public class SortBySelectSequenceComparer : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                BaseFieldAttribute baseField1 = (BaseFieldAttribute)obj1;
                BaseFieldAttribute baseField2 = (BaseFieldAttribute)obj2;
                return (((IComparable)baseField1).CompareTo(baseField2));
            }
        }

        #endregion

    }

    [Serializable]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DataFieldAttribute : BaseFieldAttribute
    {
        public DataFieldAttribute(string columnName)
            : base(columnName)
        {
        }
    }

    [Serializable]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class RecordIDFieldAttribute : BaseFieldAttribute
    {
        bool isMainTableKey = false;

        public RecordIDFieldAttribute(string columnName)
            : base(columnName)
        {
            this.DataType = DbType.Decimal;
        }

        public bool IsMainTableKey
        {
            get { return isMainTableKey; }
            set { isMainTableKey = value; }
        }
    }

    [Serializable]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class KeyFieldAttribute : BaseFieldAttribute
    {
        int keySequence = 0;

        #region Constructor

        public KeyFieldAttribute(string columnName)
            : base(columnName)
        {
        }

        #endregion

        #region Property

        // must begin from 0
        public int KeySequence
        {
            get { return keySequence; }
            set { keySequence = value; }
        }

        #endregion

        #region IComparer

        public static IComparer SortByKeySequence
        {
            get { return ((IComparer)new SortByKeySequenceComparer()); }
        }

        #endregion

        #region Nested Class

        public class SortByKeySequenceComparer : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                KeyFieldAttribute keyField1 = (KeyFieldAttribute)obj1;
                KeyFieldAttribute keyField2 = (KeyFieldAttribute)obj2;

                if (keyField1.KeySequence > keyField2.KeySequence)
                    return 1;
                if (keyField1.KeySequence < keyField2.KeySequence)
                    return -1;
                else
                    return 0;
            }
        }

        #endregion

    }

    [Serializable]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ForeignKeyFieldAttribute : BaseFieldAttribute
    {
        string foreignTableName = "";
        string foreignTableAliasName = "";
        string foreignColumnName = "";
        string relationExpression = "";
        bool isMainTableKey = false;
        TableJoinType foreignTableJoinType = TableJoinType.InnerJoin;
        int tableJoinSequence = 0;

        #region Constructor

        public ForeignKeyFieldAttribute(string columnName)
            : base(columnName)
        {
        }

        #endregion

        #region Property

        public string ForeignTableName
        {
            get { return foreignTableName; }
            set { foreignTableName = value; }
        }

        public string ForeignTableAliasName
        {
            get { return foreignTableAliasName; }
            set { foreignTableAliasName = value; }
        }

        public string ForeignColumnName
        {
            get { return foreignColumnName; }
            set { foreignColumnName = value; }
        }

        public string RelationExpression
        {
            get { return relationExpression; }
            set { relationExpression = value; }
        }

        public TableJoinType ForeignTableJoinType
        {
            get { return foreignTableJoinType; }
            set { foreignTableJoinType = value; }
        }

        public bool IsMainTableKey
        {
            get { return isMainTableKey; }
            set { isMainTableKey = value; }
        }

        public int TableJoinSequence
        {
            get { return tableJoinSequence; }
            set { tableJoinSequence = value; }
        }

        #endregion


        #region IComparer

        public static IComparer SortByForeignTableName
        {
            get { return ((IComparer)new SortByForeignTableComparer()); }
        }

        public static IComparer SortByTableJoinSequence
        {
            get { return ((IComparer)new SortByTableJoinSeqComparer()); }
        }

        #endregion

        #region Nested Class

        public class SortByForeignTableComparer : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                ForeignKeyFieldAttribute foreignKeyField1 = (ForeignKeyFieldAttribute)obj1;
                ForeignKeyFieldAttribute foreignKeyField2 = (ForeignKeyFieldAttribute)obj2;
                return (string.Compare(foreignKeyField1.ForeignTableName, foreignKeyField2.ForeignTableName));
            }
        }

        public class SortByTableJoinSeqComparer : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                ForeignKeyFieldAttribute foreignKeyField1 = (ForeignKeyFieldAttribute)obj1;
                ForeignKeyFieldAttribute foreignKeyField2 = (ForeignKeyFieldAttribute)obj2;

                //ㄌ TableJoinSequence 逼ㄌ TableName 逼
                if (foreignKeyField1.TableJoinSequence > foreignKeyField2.TableJoinSequence)
                    return 1;
                if (foreignKeyField1.TableJoinSequence < foreignKeyField2.TableJoinSequence)
                    return -1;
                else
                    return (string.Compare(foreignKeyField1.ForeignTableName, foreignKeyField2.ForeignTableName));
            }
        }

        #endregion

    }

    [Serializable]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ForeignFieldAttribute : BaseFieldAttribute
    {
        string foreignTableName = "";
        string foreignTableAliasName = "";
        string foreignColumnName = "";

        public ForeignFieldAttribute(string columnName)
            : base(columnName)
        {
        }

        public string ForeignTableName
        {
            get { return foreignTableName; }
            set { foreignTableName = value; }
        }

        public string ForeignTableAliasName
        {
            get { return foreignTableAliasName; }
            set { foreignTableAliasName = value; }
        }

        public string ForeignColumnName
        {
            get { return foreignColumnName; }
            set { foreignColumnName = value; }
        }
    }

    [Serializable]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ExpressionFieldAttribute : BaseFieldAttribute
    {
        public ExpressionFieldAttribute(string columnName)
            : base(columnName)
        {
            this.IsInsertField = false;
            this.IsUpdateField = false;
            this.AllowEdit = false;
        }
    }

    [Serializable]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class DataTableAttribute : Attribute
    {
        string tableName = "";
        string tableAliasName = "";
        string updateStoredProcedure = "";
        string resourceKey = "";

        public DataTableAttribute(string tableName)
        {
            this.tableName = tableName;
        }

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public string TableAliasName
        {
            get
            {
                if (tableAliasName.Trim() == "")
                {
                    return tableName;
                }
                else
                {
                    return tableAliasName;
                }
            }
            set { tableAliasName = value; }
        }

        public string UpdateStoredProcedure
        {
            get { return updateStoredProcedure; }
            set { updateStoredProcedure = value; }
        }

        // Resource Key
        public string ResourceKey
        {
            get { return resourceKey; }
            set { resourceKey = value; }
        }
    }
}
