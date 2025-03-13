using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.Transactions;
using Crownbio.Common;
using Crownbio.Model;
using Crownbio.Utility;


namespace Crownbio.DAL
{

    /// <summary>
    /// 生成操作数据表所需要的语句
    /// </summary>
    [Serializable]
    public class DALObject : IDisposable
    {
        #region member

        protected string _SelectCMD;
        protected string _SelectPageCountCMD;
        protected string _SelectDialogCMD;
        protected string _InsertCMD;
        protected string _UpdateCMD;
        protected string _DeleteCMD;

        protected Type _dataType = null;
        protected string _tableName;
        protected string _tableAliasName;
        protected string _SQLSelect = "";
        protected string _SQLDialog = "";
        protected string _SQLGroup = "";

        protected ArrayList _RecordIDFields = new ArrayList();
        protected ArrayList _KeyFields = new ArrayList();
        protected ArrayList _ForeignKeyFields = new ArrayList();
        protected ArrayList _ForeignFields = new ArrayList();
        protected ArrayList _DataFields = new ArrayList();
        protected ArrayList _SelectFields = new ArrayList();
        protected ArrayList _DialogFields = new ArrayList();
        protected ArrayList _InsertFields = new ArrayList();
        protected ArrayList _UpdateFields = new ArrayList();
        protected string _RecordIDFieldName = "";
        protected string _ForeignKeyRelations = "";
        protected object[] selectPara = null;
        protected object[] dialogPara = null;


        private List<PropertyInfo> selectPropertyInfo = new List<PropertyInfo>();

        private string _errMsg = "";
        //private string _errMsgInsertFailed = "";
        //private string _errMsgUpdateFailed = "";
        //private string _errMsgDeleteFailed = "";

        #endregion member

        #region Constructor and dispose
        static DALObject()
        {

        }

        public DALObject()
        {
        }

        public DALObject(Type dataType)
        {
            _dataType = dataType;
            Init();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return; // we're being collected, so let the GC take care of this object
        }

        #endregion Constructor and dispose

        #region 构建基本信息

        /// <summary>
        /// 初始化带类型的DALBase
        /// </summary>
        private void Init()
        {
            GetDataInfo();
            InitInsertCommand();
            InitUpdateCommand();
            InitDeleteCommand();
            InitSelectCommand();
            InitDialogSelectCommand();
            InitSelectPageCountCommand();
        }


        /// <summary>
        /// 获取表及字段信息
        /// </summary>
        private void GetDataInfo()
        {
            // 获取表相关信息
            DataTableAttribute[] tableAttributes = (DataTableAttribute[])_dataType.GetCustomAttributes(typeof(DataTableAttribute), false);
            if (tableAttributes.Length > 0)
            {
                _tableName = tableAttributes[0].TableName;
                _tableAliasName = tableAttributes[0].TableAliasName;
            }

            // 获取字段相关信息
            RecordIDFieldAttribute recordIDField;
            KeyFieldAttribute keyField;
            ForeignKeyFieldAttribute foreignKeyField;
            ForeignFieldAttribute foreignField;
            DataFieldAttribute dataField;

            //FieldInfo[] fields = _dataType.GetFields();
            PropertyInfo[] fields = _dataType.GetProperties();

            #region 字段类型属性
            foreach (PropertyInfo field in fields)
            {

                BaseFieldAttribute[] baseFieldAttributes = (BaseFieldAttribute[])field.GetCustomAttributes(typeof(BaseFieldAttribute), true);
                if (baseFieldAttributes.Length > 0)
                {
                    foreach (BaseFieldAttribute baseField in baseFieldAttributes)
                    {
                        if (baseField is RecordIDFieldAttribute)
                        {
                            recordIDField = (RecordIDFieldAttribute)baseField;
                            _RecordIDFields.Add(recordIDField);
                            if (baseField is KeyFieldAttribute)
                            {
                                keyField = (KeyFieldAttribute)baseField;
                                _KeyFields.Add(keyField);
                            }
                        }
                        else if (baseField is ForeignKeyFieldAttribute)
                        {
                            foreignKeyField = (ForeignKeyFieldAttribute)baseField;
                            _ForeignKeyFields.Add(foreignKeyField);
                            if (baseField is KeyFieldAttribute)
                            {
                                keyField = (KeyFieldAttribute)baseField;
                                _KeyFields.Add(keyField);
                            }
                        }
                        else if (baseField is KeyFieldAttribute)
                        {
                            keyField = (KeyFieldAttribute)baseField;
                            _KeyFields.Add(keyField);
                        }
                        else if (baseField is ForeignFieldAttribute)
                        {
                            foreignField = (ForeignFieldAttribute)baseField;
                            _ForeignFields.Add(foreignField);
                        }
                        else if (baseField is DataFieldAttribute)
                        {
                            dataField = (DataFieldAttribute)baseField;
                            _DataFields.Add(dataField);
                        }
                        else
                        {
                        }

                        // Get Select Fields
                        if (baseField.SelectSequence >= 0)
                        {
                            _SelectFields.Add(baseField);
                            //selectPropertyInfo.Add(field);
                        }
                        // Get Dialog Fields
                        if (baseField.DialogSequence >= 0)
                        {
                            _DialogFields.Add(baseField);
                        }
                        // Get Insert Fields
                        if (baseField.IsInsertField)
                        {
                            _InsertFields.Add(baseField);
                        }
                        // Get Update Fields
                        if (baseField.IsUpdateField)
                        {
                            _UpdateFields.Add(baseField);
                        }
                    }
                }

            }

            #endregion


            // 获取ID字段名
            if (_RecordIDFields.Count > 0)
            {
                _RecordIDFields.Sort(RecordIDFieldAttribute.SortBySelectSequence);
                _RecordIDFieldName = ((RecordIDFieldAttribute)_RecordIDFields[0]).ColumnName;
            }

            #region  获取外键字段及联接类型
            if (_ForeignKeyFields.Count > 0)
            {
                StringBuilder sbForeignKeyRelations = new StringBuilder();
                string strTable = "";
                //sort ArrayList
                _ForeignKeyFields.Sort(ForeignKeyFieldAttribute.SortByTableJoinSequence);
                foreach (ForeignKeyFieldAttribute foreignKey in _ForeignKeyFields)
                {
                    // Foreign Table
                    strTable = foreignKey.ForeignTableName + " " + foreignKey.ForeignTableAliasName;
                    if (sbForeignKeyRelations.ToString().IndexOf(strTable) >= 0)
                    {
                        sbForeignKeyRelations.Append(" AND ");

                        if (foreignKey.RelationExpression.Trim() != "")
                        {
                            sbForeignKeyRelations.Append(" " + foreignKey.RelationExpression.Trim() + " ");
                            continue;
                        }
                        if (foreignKey.TableName == "" && foreignKey.TableAliasName == "")
                        {
                            sbForeignKeyRelations.Append(_tableAliasName);	//as a main table column
                        }
                        else
                        {
                            sbForeignKeyRelations.Append(foreignKey.TableAliasName);
                        }
                        sbForeignKeyRelations.Append(".");
                        sbForeignKeyRelations.Append(foreignKey.ColumnName);
                        sbForeignKeyRelations.Append(" = ");
                        sbForeignKeyRelations.Append(foreignKey.ForeignTableAliasName);
                        sbForeignKeyRelations.Append(".");
                        sbForeignKeyRelations.Append(foreignKey.ForeignColumnName);
                    }
                    else
                    {
                        if (foreignKey.ForeignTableJoinType != TableJoinType.None)
                        {
                            switch (foreignKey.ForeignTableJoinType)
                            {
                                case TableJoinType.InnerJoin:
                                    sbForeignKeyRelations.Append(" INNER JOIN ");
                                    break;
                                case TableJoinType.LeftOuterJoin:
                                    sbForeignKeyRelations.Append(" LEFT JOIN ");
                                    break;
                                case TableJoinType.RightOuterJoin:
                                    sbForeignKeyRelations.Append(" RIGHT JOIN ");
                                    break;
                                case TableJoinType.FullOuterJoin:
                                    sbForeignKeyRelations.Append(" FULL OUTER JOIN ");
                                    break;
                            }
                            sbForeignKeyRelations.Append(strTable);
                            sbForeignKeyRelations.Append(" ON ");

                            if (foreignKey.RelationExpression.Trim() != "")
                            {
                                sbForeignKeyRelations.Append(" " + foreignKey.RelationExpression.Trim() + " ");
                                continue;
                            }

                            if (foreignKey.TableName == "" && foreignKey.TableAliasName == "")
                            {
                                sbForeignKeyRelations.Append(_tableAliasName);	//as a main table column
                            }
                            else
                            {
                                sbForeignKeyRelations.Append(foreignKey.TableAliasName);
                            }
                            sbForeignKeyRelations.Append(".");
                            sbForeignKeyRelations.Append(foreignKey.ColumnName);
                            sbForeignKeyRelations.Append(" = ");
                            sbForeignKeyRelations.Append(foreignKey.ForeignTableAliasName);
                            sbForeignKeyRelations.Append(".");
                            sbForeignKeyRelations.Append(foreignKey.ForeignColumnName);
                        }
                    }
                }
                _ForeignKeyRelations = sbForeignKeyRelations.ToString();
                sbForeignKeyRelations = null;
            }

            #endregion

            #region 生成查询语句
            if (_SelectFields.Count > 0)
            {
                List<Object> _paraList = new List<Object>();
                StringBuilder sbSelectFields = new StringBuilder();
                StringBuilder sbGroupFields = new StringBuilder();
                ForeignFieldAttribute refField;
                // sort ArrayList
                _SelectFields.Sort(BaseFieldAttribute.SortBySelectSequence);
                foreach (BaseFieldAttribute baseField in _SelectFields)
                {
                    sbGroupFields.Append(baseField.GroupFun + "(");
                    if (baseField is ForeignFieldAttribute)
                    {
                        refField = (ForeignFieldAttribute)baseField;
                        sbSelectFields.Append(refField.ForeignTableAliasName + "." + refField.ForeignColumnName + " AS " + baseField.AliasName);
                        sbGroupFields.Append(refField.ForeignTableAliasName + "." + refField.ForeignColumnName + ") AS " + baseField.AliasName);
                    }
                    else if (baseField is ExpressionFieldAttribute)
                    {
                        sbSelectFields.Append(baseField.ColumnName + " AS " + baseField.AliasName);
                        sbGroupFields.Append(baseField.ColumnName + ") AS " + baseField.AliasName);
                    }
                    else
                    {
                        if (baseField.TableName == "" && baseField.TableAliasName == "")
                        {
                            sbSelectFields.Append(_tableAliasName + "." + baseField.ColumnName + " AS " + baseField.AliasName);
                            sbGroupFields.Append(_tableAliasName + "." + baseField.ColumnName + ") AS " + baseField.AliasName);
                        }
                        else
                        {
                            sbSelectFields.Append(baseField.TableAliasName + "." + baseField.ColumnName + " AS " + baseField.AliasName);
                            sbGroupFields.Append(baseField.TableAliasName + "." + baseField.ColumnName + ") AS " + baseField.AliasName);
                        }
                    }
                    if (baseField.ParaDefaultValue != null)
                    {
                        for (int i = 0; i < baseField.ParaDefaultValue.Length; i++)
                        {
                            _paraList.Add(baseField.ParaDefaultValue[i]);
                        }
                    }
                    sbSelectFields.Append(",");
                    sbGroupFields.Append(",");
                }
                selectPara = _paraList.ToArray();
                // Select Fields  
                sbSelectFields.Remove(sbSelectFields.Length - 1, 1);
                sbGroupFields.Remove(sbGroupFields.Length - 1, 1);
                _SQLSelect = sbSelectFields.ToString();
                _SQLGroup = sbGroupFields.ToString();
                sbSelectFields = null;
                sbGroupFields = null;
            }

            #endregion

            #region 生成对话框语句
            if (_DialogFields.Count > 0)
            {
                List<Object> _paraList = new List<Object>();
                StringBuilder sbSelectFields = new StringBuilder();
                ForeignFieldAttribute refField;
                // sort ArrayList
                _DialogFields.Sort(BaseFieldAttribute.SortBySelectSequence);
                foreach (BaseFieldAttribute baseField in _DialogFields)
                {
                    if (baseField is ForeignFieldAttribute)
                    {
                        refField = (ForeignFieldAttribute)baseField;
                        sbSelectFields.Append(refField.ForeignTableAliasName + "." + refField.ForeignColumnName + " AS " + baseField.AliasName);
                    }
                    else if (baseField is ExpressionFieldAttribute)
                    {
                        sbSelectFields.Append(baseField.ColumnName + " AS " + baseField.AliasName);
                    }
                    else
                    {
                        if (baseField.TableName == "" && baseField.TableAliasName == "")
                        {
                            sbSelectFields.Append(_tableAliasName + "." + baseField.ColumnName + " AS " + baseField.AliasName);
                        }
                        else
                        {
                            sbSelectFields.Append(baseField.TableAliasName + "." + baseField.ColumnName + " AS " + baseField.AliasName);
                        }
                    }
                    if (baseField.ParaDefaultValue != null)
                    {
                        for (int i = 0; i < baseField.ParaDefaultValue.Length; i++)
                        {
                            _paraList.Add(baseField.ParaDefaultValue[i]);
                        }
                    }
                    sbSelectFields.Append(",");
                }
                dialogPara = _paraList.ToArray();
                // Dialog Fields
                sbSelectFields.Remove(sbSelectFields.Length - 1, 1);
                _SQLDialog = sbSelectFields.ToString();
                sbSelectFields = null;
            }

            #endregion
        }

        /// <summary>
        /// 生成基本Select语句
        /// </summary>
        private void InitSelectCommand()
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT ");
            if (_SelectFields.Count > 0)
            {
                strSQL.Append(_SQLSelect);
            }
            else
            {
                strSQL.Append(_tableAliasName + ".* ");
            }
            strSQL.Append(" FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" ");
            strSQL.Append(_tableAliasName);

            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" ");

            _SelectCMD = strSQL.ToString();
        }

        /// <summary>
        /// 生成基本Select语句,带分页排序参数
        /// </summary>
        private void InitSelectPageCountCommand()
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Append("SELECT * FROM ");

            strSQL.Append("(SELECT ");
            if (_SelectFields.Count > 0)
            {
                strSQL.Append(_SQLSelect);
            }
            else
            {
                strSQL.Append(_tableAliasName + ".* ");
            }
            strSQL.Append(",ROW_NUMBER() OVER({1}) AS ROW_NUM ");//order by
            strSQL.Append(" FROM ");
            strSQL.Append(_tableName);
            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" {2} ");//where
            strSQL.Append(" ) ");
            strSQL.Append(" AS ");
            strSQL.Append(_tableAliasName+"1");
            strSQL.Append(" WHERE ROW_NUM BETWEEN {3} AND {4} ");

            _SelectPageCountCMD = strSQL.ToString();
        }

        /// <summary>
        /// 返回Group by语句
        /// </summary>
        /// <returns></returns>
        public string GetGroupCommand()
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT ");
            if (_SelectFields.Count > 0)
            {
                strSQL.Append(_SQLGroup);
            }
            else
            {
                strSQL.Append(_tableAliasName + ".* ");
            }
            strSQL.Append(" FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" ");
            strSQL.Append(_tableAliasName);

            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" ");

            return strSQL.ToString();
        }
        /// <summary>
        /// 返回查询结果数
        /// </summary>
        /// <returns></returns>
        private string GetCountCommand()
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT count(1) FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" ");
            strSQL.Append(_tableAliasName);

            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" ");

            return strSQL.ToString();
        }



        /// <summary>
        /// 生成Dialog查询语句
        /// </summary>
        private void InitDialogSelectCommand()
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT ");
            if (_SelectFields.Count > 0)
            {
                strSQL.Append(_SQLSelect);
            }
            else
            {
                strSQL.Append(_tableAliasName + ".* ");
            }
            strSQL.Append(" FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" ");
            strSQL.Append(_tableAliasName);

            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" ");

            _SelectDialogCMD = strSQL.ToString();
        }
        /// <summary>
        /// 返回前N条记录的查询语句
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private string InitTopSelectCommand(Int16 count)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT TOP " + count + " ");
            if (_SelectFields.Count > 0)
            {
                strSQL.Append(_SQLSelect);
            }
            else
            {
                strSQL.Append(_tableAliasName + ".* ");
            }
            strSQL.Append(" FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" ");
            strSQL.Append(_tableAliasName);

            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" ");

            return strSQL.ToString();
        }



        /// <summary>
        /// 生成参数化的Insert语句
        /// </summary>
        private void InitInsertCommand()
        {
            StringBuilder sbInsertField = new StringBuilder();
            StringBuilder sbInsertValue = new StringBuilder();

            _InsertFields.Sort(BaseFieldAttribute.SortBySelectSequence);

            sbInsertField.Append("INSERT INTO " + _tableName + "(");
            sbInsertValue.Append(" VALUES(");

            foreach (BaseFieldAttribute baseField in _InsertFields)
            {
                sbInsertField.Append(baseField.ColumnName + ",");
                sbInsertValue.Append("@" + baseField.ColumnName + ",");
            }

            sbInsertField.Remove(sbInsertField.Length - 1, 1);
            sbInsertField.Append(")");

            sbInsertValue.Remove(sbInsertValue.Length - 1, 1);
            sbInsertValue.Append(")");

            sbInsertField.Append(sbInsertValue.ToString());

            sbInsertField.Append("; Select @@IDENTITY;");

            _InsertCMD = sbInsertField.ToString();
        }


        /// <summary>
        /// 生成带参数的更新语句
        /// </summary>
        private void InitUpdateCommand()
        {
            StringBuilder sbUpdateSQL = new StringBuilder();
            _UpdateFields.Sort(BaseFieldAttribute.SortBySelectSequence);
            sbUpdateSQL.Append("UPDATE " + _tableName + " SET ");
            foreach (BaseFieldAttribute baseField in _UpdateFields)
            {
                sbUpdateSQL.Append(baseField.ColumnName + " = @" + baseField.ColumnName + ",");
            }
            sbUpdateSQL.Remove(sbUpdateSQL.Length - 1, 1);
            sbUpdateSQL.Append(" WHERE ");
            sbUpdateSQL.Append(_RecordIDFieldName);
            sbUpdateSQL.Append(" = @" + _RecordIDFieldName);
            _UpdateCMD = sbUpdateSQL.ToString();
        }

        /// <summary>
        /// 生成带参数的删除语句
        /// </summary>
        private void InitDeleteCommand()
        {
            StringBuilder sbDeleteSQL = new StringBuilder();
            if (KeyFields.Count > 0)
            {
                sbDeleteSQL.Append("DELETE FROM " + _tableName + " WHERE " + _RecordIDFieldName + "=@" + _RecordIDFieldName);
            }
            _DeleteCMD = sbDeleteSQL.ToString();
        }

        #endregion

        #region 获取字段及属性列表

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get { return _tableName; }
        }

        /// <summary>
        /// 表别名
        /// </summary>
        public string TableAliasName
        {
            get { return _tableAliasName; }
        }

        /// <summary>
        /// 获取表自动增长字段名称
        /// </summary>
        public string RecordIDFieldName
        {
            get { return _RecordIDFieldName; }
        }

        /// <summary>
        /// 获取Auto ID字段
        /// </summary>
        public ArrayList RecordIDFields
        {
            get { return _RecordIDFields; }
        }

        /// <summary>
        /// 获取Key Code字段列表
        /// </summary>
        public ArrayList KeyFields
        {
            get { return _KeyFields; }
        }

        /// <summary>
        /// 获取外键字段列表
        /// </summary>
        public ArrayList ForeignKeyFields
        {
            get { return _ForeignKeyFields; }
        }

        /// <summary>
        /// 获取关联表中的字段列表
        /// </summary>
        public ArrayList ForeignFields
        {
            get { return _ForeignFields; }
        }

        /// <summary>
        /// 获取普通字段列表
        /// </summary>
        public ArrayList DataFields
        {
            get { return _DataFields; }
        }

        /// <summary>
        /// 获取Select语句中的字段列表
        /// </summary>
        public ArrayList SelectFields
        {
            get { return _SelectFields; }
        }

        /// <summary>
        /// 返回选择窗口查询列表
        /// </summary>
        public ArrayList DialogFields
        {
            get { return _DialogFields; }
        }

        #endregion 获取字段及属性列表

        #region Find\GetID\GetKeyCode\GetKeyCodes
        /// <summary>
        /// 查询指定ID值的记录是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public virtual bool Find(decimal recordID)
        {
            CheckDataType();
            CheckRecordIDField();

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT COUNT(1) FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(_RecordIDFieldName);
            strSQL.Append(" = " + recordID);

            return DbHelperSQL.Exists(strSQL.ToString());
        }

        /// <summary>
        /// 根据第一个Key Code值查询记录是否存在
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual bool Find(object keyCode)
        {
            CheckDataType();
            CheckKeyFields();

            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT COUNT(1) FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(keyField.ColumnName);
            strSQL.Append(" = @" + keyField.ColumnName);

            SqlParameter[] parameters ={ DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCode, keyField.IsNullable) };

            return DbHelperSQL.Exists(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// 根据所有KeyCode查询记录是否存在
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <returns></returns>
        public virtual bool Find(Object[] keyCodes)
        {
            CheckDataType();
            CheckKeyFields();

            ///值数量与参数数量不合
            if (keyCodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("SELECT COUNT(1) FROM " + _tableName);

            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];
            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                if (i == 0)
                {
                    strSQL.Append(" WHERE ");
                }
                else
                {
                    strSQL.Append(" AND ");
                }
                strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);

                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCodes[i], keyField.IsNullable);

            }

            return DbHelperSQL.Exists(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// 检查除指定ID外的KeyCode是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual bool Find(decimal recordID, object keyCode)
        {
            CheckDataType();
            CheckKeyFields();
            CheckRecordIDField();

            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT COUNT(1) FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(_RecordIDFieldName);
            strSQL.Append(" !=" + recordID);
            strSQL.Append(" AND ");
            strSQL.Append(keyField.ColumnName);
            strSQL.Append(" = @" + keyField.ColumnName);

            SqlParameter[] parameters ={ DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCode, keyField.IsNullable) };

            return DbHelperSQL.Exists(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// 检查除指定ID外的非KeyCode是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual bool Find(decimal recordID, string Field, object Value)
        {
            CheckDataType();
            CheckRecordIDField();

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT COUNT(1) FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(_RecordIDFieldName);
            strSQL.Append(" !=" + recordID);
            strSQL.Append(" AND ");
            strSQL.Append(Field);
            strSQL.Append(" = @" + Field);

            DbType DataType = DbType.Object;
            if (Value is String)
                DataType = DbType.String;
            else if (Value is DateTime)
                DataType = DbType.DateTime;
            else if (Value is decimal)
                DataType = DbType.Decimal;

            SqlParameter[] parameters ={ DbHelperSQL.CreateDataParameter("@" + Field, DataType, Value) };

            return DbHelperSQL.Exists(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// 检查除指定ID外的KeyCodes是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="keyCodes"></param>
        /// <returns></returns>
        public virtual bool Find(decimal recordID, Object[] keyCodes)
        {
            CheckDataType();
            CheckKeyFields();

            ///值数量与参数数量不合
            if (keyCodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("SELECT COUNT(1) FROM " + _tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(_RecordIDFieldName);
            strSQL.Append(" !=" + recordID);

            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];
            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                strSQL.Append(" AND ");
                strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);

                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCodes[i], keyField.IsNullable);

            }

            return DbHelperSQL.Exists(strSQL.ToString(), parameters);
        }


        /// <summary>
        /// 根据KeyCode查询对应的ID
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual decimal GetID(Object keyCode)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckKeyFields();

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            strSQL.Append("SELECT " + _RecordIDFieldName + " FROM " + _tableName + " WHERE ");
            strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);

            SqlParameter[] parameters ={ DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCode, keyField.IsNullable) };

            return DbHelperSQL.GetID(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// 根据KeyCodes取得ID
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <returns></returns>
        public virtual decimal GetID(Object[] keyCodes)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckKeyFields();

            if (keyCodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("SELECT " + _RecordIDFieldName + " FROM " + _tableName);
            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];

            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                if (i == 0)
                {
                    strSQL.Append(" WHERE ");
                }
                else
                {
                    strSQL.Append(" AND ");
                }
                strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);
                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCodes[i], keyField.IsNullable);

            }

            return DbHelperSQL.GetID(strSQL.ToString(), parameters);
        }


        /// <summary>
        /// 根据KeyCode查询指定栏位的值
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual object GetFieldValue(Object keyCode, string fieldName)
        {
            CheckDataType();
            CheckKeyFields();

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            strSQL.Append("SELECT " + fieldName + " FROM " + _tableName + " WHERE ");
            strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);

            SqlParameter[] parameters ={ DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCode, keyField.IsNullable) };

            return DbHelperSQL.GetSingle(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// 根据所有KeyCodes查询返回指定栏位的值
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public virtual object GetFieldValue(Object[] keyCodes, string fieldName)
        {
            CheckDataType();
            CheckKeyFields();

            if (keyCodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("SELECT " + fieldName + " FROM " + _tableName);
            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];

            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                if (i == 0)
                {
                    strSQL.Append(" WHERE ");
                }
                else
                {
                    strSQL.Append(" AND ");
                }
                strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);
                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCodes[i], keyField.IsNullable);

            }

            return DbHelperSQL.GetSingle(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// 根据查询条件返回指定栏位的值
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public virtual object GetFieldValue(ParamCollection _paramCollection, string fieldName)
        {
            CheckDataType();
            CheckRecordIDField();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT " + fieldName + " FROM " + _tableName);
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            strSQL.Append(getSortClause(""));

            return DbHelperSQL.GetSingle(strSQL.ToString(), GetParams(_paramCollection));
        }

        /// <summary>
        /// 根据查询条件返回指定栏位的值
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="fieldName"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual object GetFieldValue(ParamCollection _paramCollection, string fieldName, string sort)
        {
            CheckDataType();
            CheckRecordIDField();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT " + fieldName + " FROM " + _tableName);
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            strSQL.Append(getSortClause(sort));

            return DbHelperSQL.GetSingle(strSQL.ToString(), GetParams(_paramCollection));
        }

        /// <summary>
        /// 根据ID返回KeyCode值
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public virtual Object GetCode(decimal recordID)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckKeyFields();

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            strSQL.Append("SELECT " + keyField.ColumnName + " FROM " + _tableName + " WHERE " + _RecordIDFieldName + "=" + recordID.ToString());

            return DbHelperSQL.GetSingle(strSQL.ToString());
        }

        /// <summary>
        /// 根据ID返回KeyCodes
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public virtual Object[] GetCodes(decimal recordID)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckKeyFields();

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("SELECT ");
            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                strSQL.Append(keyField.ColumnName);
                strSQL.Append(",");
            }
            strSQL.Remove(strSQL.Length - 1, 1);
            strSQL.Append(" FROM " + _tableName + " WHERE " + _RecordIDFieldName + "=" + recordID.ToString());

            Object[] codes = new object[_KeyFields.Count];
            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(strSQL.ToString()))
            {

                if (reader.Read())
                {
                    for (int i = 0; i < _KeyFields.Count; i++)
                    {
                        keyField = (KeyFieldAttribute)_KeyFields[i];
                        codes[i] = reader[keyField.ColumnName];
                    }
                }
                reader.Close();
            }

            return codes;

        }

        #endregion Find

        #region 新增\修改\删除

        /// <summary>
        /// 生成不带参数Insert语句
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private string GetInsertSQL(BaseObject data)
        {
            StringBuilder sbInsertField = new StringBuilder();
            StringBuilder sbInsertValue = new StringBuilder();

            _InsertFields.Sort(BaseFieldAttribute.SortBySelectSequence);

            sbInsertField.Append("INSERT INTO " + _tableName + "(");
            sbInsertValue.Append(" VALUES(");

            foreach (BaseFieldAttribute baseField in _InsertFields)
            {
                sbInsertField.Append(baseField.ColumnName);
                sbInsertField.Append(",");
                //PropertyInfo propertyInfo = data.GetType().GetProperty(baseField.ColumnName);
                PropertyInfo propertyInfo = _dataType.GetProperty(baseField.ColumnName);
                object value = propertyInfo.GetValue(data, null);

                if (baseField.DefaultValue.ToUpper() == "USERID")
                {
                    sbInsertValue.Append(CacheHelper.getCurrentUser().USER_ID.ToString());
                    sbInsertValue.Append(",");
                    continue;
                }
                if (baseField.DefaultValue.ToUpper() == "SYSDATE")
                {
                    sbInsertValue.Append(getFieldDateFormat(DbHelperSQL.GetDBSystemDatetime(), true));
                    sbInsertValue.Append(",");
                    continue;
                }
                //if (dataRow[baseField.AliasName].ToString() == "")
                if (value == null)
                {
                    if (baseField.DefaultValue != "")
                    {
                        sbInsertValue.Append(baseField.DefaultValue);
                    }
                    else
                    {
                        sbInsertValue.Append("null");
                    }
                }
                else
                {
                    if (baseField.DataType == DbType.String)
                    {
                        sbInsertValue.Append("'");
                        string strField = value.ToString();
                        strField = strField.Replace("'", "''");
                        sbInsertValue.Append(strField);
                        sbInsertValue.Append("'");
                    }
                    else if (baseField.DataType == DbType.Date)
                    {
                        //if (value ==DateTime.)
                        //{
                        //    sbInsertValue.Append("null");
                        //}
                        //else
                        //{
                        sbInsertValue.Append(getFieldDateFormat((DateTime)value, false));
                        //}

                    }
                    else if (baseField.DataType == DbType.DateTime)
                    {
                        //if (value is DateTime.MinValue)
                        //{
                        //    sbInsertValue.Append("null");
                        //}
                        //else
                        //{
                        sbInsertValue.Append(getFieldDateFormat((DateTime)value, true));
                        //}
                    }
                    else
                    {
                        sbInsertValue.Append(value.ToString());
                    }
                }
                sbInsertValue.Append(",");
            }
            //Field
            sbInsertField.Remove(sbInsertField.Length - 1, 1);
            sbInsertField.Append(")");
            //Value
            sbInsertValue.Remove(sbInsertValue.Length - 1, 1);
            sbInsertValue.Append(");");

            //Insert SQL Statement
            sbInsertField.Append(sbInsertValue.ToString());

            sbInsertField.Append("Select @@IDENTITY;");//执行后返回ID值
            return sbInsertField.ToString();
        }

        /// <summary>
        /// 生成Insert语句的参数
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private SqlParameter[] GetInsertParams(BaseObject data)
        {
            SqlParameter[] parameters = new SqlParameter[_InsertFields.Count];
            for (int i = 0; i < _InsertFields.Count; i++)
            {

                BaseFieldAttribute baseField = (BaseFieldAttribute)_InsertFields[i];
                //LogHelper.Log(baseField.ColumnName + "  OK");
                PropertyInfo propertyInfo = _dataType.GetProperty(baseField.ColumnName);
                object value = propertyInfo.GetValue(data, null);

                SqlParameter parameter = DbHelperSQL.CreateDataParameter("@" + baseField.ColumnName, baseField.DataType);
                if (baseField.DefaultValue.ToUpper() == "USERID")
                {
                    parameter.Value = CacheHelper.getCurrentUser().USER_ID;
                    parameters[i] = parameter;
                    continue;
                }
                if (baseField.DefaultValue.ToUpper() == "SYSDATE")
                {
                    parameter.Value = DbHelperSQL.GetDBSystemDatetime();
                    parameters[i] = parameter;
                    continue;
                }
                if (value == null)
                {
                    if (baseField.DefaultValue != "")
                    {
                        parameter.Value = baseField.DefaultValue;
                    }
                    else
                    {
                        parameter.Value = System.DBNull.Value;
                    }
                }
                else
                {
                    parameter.Value = value;
                    if (baseField.DataType == DbType.Date || baseField.DataType == DbType.DateTime)
                    {
                        try
                        {
                            if ((DateTime)value == DateTime.MinValue)
                            {
                                parameter.Value = System.DBNull.Value;
                            }
                        }
                        catch { parameter.Value = System.DBNull.Value; }
                    }
                }

                parameters[i] = parameter;
            }
            return parameters;
        }

        /// <summary>
        /// 生成不带参数的Update语句
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        protected virtual string GetUpdateSQL(BaseObject data)
        {
            StringBuilder sbUpdateSQL = new StringBuilder();

            _UpdateFields.Sort(BaseFieldAttribute.SortBySelectSequence);

            sbUpdateSQL.Append("UPDATE " + _tableName + " SET ");

            foreach (BaseFieldAttribute baseField in _UpdateFields)
            {
                PropertyInfo propertyInfo = _dataType.GetProperty(baseField.ColumnName);
                object value = propertyInfo.GetValue(data, null);


                sbUpdateSQL.Append(baseField.ColumnName);
                sbUpdateSQL.Append(" = ");

                if (baseField.DefaultValue.ToUpper() == "USERID")
                {
                    sbUpdateSQL.Append(CacheHelper.getCurrentUser().USER_ID.ToString());
                    sbUpdateSQL.Append(",");
                    continue;
                }
                if (baseField.DefaultValue.ToUpper() == "SYSDATE")
                {
                    sbUpdateSQL.Append(getFieldDateFormat(DbHelperSQL.GetDBSystemDatetime(), true));
                    sbUpdateSQL.Append(",");
                    continue;
                }
                if (value == null)
                {
                    if (baseField.DefaultValue != "")
                    {
                        sbUpdateSQL.Append(baseField.DefaultValue);
                    }
                    else
                    {
                        sbUpdateSQL.Append("null");
                    }
                }
                else
                {
                    if (baseField.DataType == DbType.String)
                    {
                        sbUpdateSQL.Append("'");
                        string strField = value.ToString();
                        strField = strField.Replace("'", "''");
                        sbUpdateSQL.Append(strField);
                        sbUpdateSQL.Append("'");
                    }
                    else if (baseField.DataType == DbType.Date)
                    {
                        //if (value == DateTime.MinValue)
                        //{
                        //    sbUpdateSQL.Append("null");
                        //}
                        //else
                        //{
                        sbUpdateSQL.Append(getFieldDateFormat((DateTime)value, false));
                        //}

                    }
                    else if (baseField.DataType == DbType.DateTime)
                    {
                        //if (value == DateTime.MinValue)
                        //{
                        //    sbUpdateSQL.Append("null");
                        //}
                        //else
                        //{
                        sbUpdateSQL.Append(getFieldDateFormat((DateTime)value, true));
                        //}
                    }
                    else
                    {
                        sbUpdateSQL.Append(value.ToString());
                    }
                }
                sbUpdateSQL.Append(",");
            }
            sbUpdateSQL.Remove(sbUpdateSQL.Length - 1, 1);
            sbUpdateSQL.Append(" WHERE ");
            sbUpdateSQL.Append(_RecordIDFieldName);
            sbUpdateSQL.Append(" = ");
            PropertyInfo idpropertyInfo = _dataType.GetProperty(_RecordIDFieldName);
            object idvalue = idpropertyInfo.GetValue(data, null);
            sbUpdateSQL.Append(idvalue.ToString());

            return sbUpdateSQL.ToString();
        }


        /// <summary>
        /// 生成Update语句的参数
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private SqlParameter[] GetUpdateParams(BaseObject data)
        {
            SqlParameter[] parameters = new SqlParameter[_UpdateFields.Count + 1];
            for (int i = 0; i < _UpdateFields.Count; i++)
            {
                BaseFieldAttribute baseField = (BaseFieldAttribute)_UpdateFields[i];

                PropertyInfo propertyInfo = _dataType.GetProperty(baseField.ColumnName);
                object value = propertyInfo.GetValue(data, null);

                SqlParameter parameter = DbHelperSQL.CreateDataParameter("@" + baseField.ColumnName, baseField.DataType);
                if (baseField.DefaultValue.ToUpper() == "USERID")
                {
                    parameter.Value = CacheHelper.getCurrentUser().USER_ID;
                    parameters[i] = parameter;
                    continue;
                }
                if (baseField.DefaultValue.ToUpper() == "SYSDATE")
                {
                    parameter.Value = DbHelperSQL.GetDBSystemDatetime();
                    parameters[i] = parameter;
                    continue;
                }
                if (value == null)
                {
                    if (baseField.DefaultValue != "")
                    {
                        parameter.Value = baseField.DefaultValue;
                    }
                    else
                    {
                        parameter.Value = System.DBNull.Value;
                    }
                }
                else
                {
                    if (baseField.DataType == DbType.Date)
                    {
                        try
                        {
                            if ((DateTime)value == DateTime.MinValue)
                            {
                                parameter.Value = DBNull.Value;
                            }
                            else
                            {
                                parameter.Value = value;
                            }

                        }
                        catch { parameter.Value = DBNull.Value; }
                    }
                    else if (baseField.DataType == DbType.DateTime)
                    {
                        try
                        {
                            if ((DateTime)value == DateTime.MinValue)
                            {
                                parameter.Value = DBNull.Value;
                            }
                            else
                            {
                                parameter.Value = value;
                            }
                        }
                        catch { parameter.Value = DBNull.Value; }
                    }
                    else
                    {
                        parameter.Value = value;
                    }
                   
                }
                parameters[i] = parameter;
            }
            ///指定ID的Param
            PropertyInfo idpropertyInfo = _dataType.GetProperty(_RecordIDFieldName);
            object idvalue = idpropertyInfo.GetValue(data, null);

            SqlParameter paramId = DbHelperSQL.CreateDataParameter("@" + _RecordIDFieldName, DbType.Decimal);
            paramId.Value = idvalue;
            parameters[_UpdateFields.Count] = paramId;

            return parameters;
        }

        /// <summary>
        /// 生成Delete语句
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        protected virtual string GetDeleteSQL(BaseObject data)
        {
            StringBuilder sbDeleteSQL = new StringBuilder();
            sbDeleteSQL.Append("DELETE FROM ");
            sbDeleteSQL.Append(_tableName);
            sbDeleteSQL.Append(" WHERE ");
            sbDeleteSQL.Append(_RecordIDFieldName);
            sbDeleteSQL.Append(" = ");

            PropertyInfo idpropertyInfo = _dataType.GetProperty(_RecordIDFieldName);
            object idvalue = idpropertyInfo.GetValue(data, null);
            sbDeleteSQL.Append(idvalue.ToString());

            //sbDeleteSQL.Append(dataRow[_RecordIDFieldName, DataRowVersion.Original].ToString());
            return sbDeleteSQL.ToString();
        }


        /// <summary>
        /// 使用参数的方式更新数据集
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual BaseList UpdateAllByParams(BaseList masterData)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
                foreach (BaseObject instance in masterData)
                {
                    if (instance.CurModel == DealModel.Delete)
                    {
                        DeleteInstance(instance);
                    }
                    else if (instance.CurModel == DealModel.Modify)
                    {
                        UpdateInstanceByParam(instance);
                    }
                    else if (instance.CurModel == DealModel.New)
                    {
                        AddInstanceByParam(instance);
                    }
                }
                //BaseList deleteData = masterData.GetDeleteData();
                //if (deleteData != null)
                //{
                //    Delete(deleteData);
                //}

                /////更新修改之数据
                //BaseList modifyData = masterData.GetUpdateData();
                //if (modifyData != null)
                //{
                //    UpdateByParams(modifyData);
                //}

                /////更新新增之数据
                //BaseList addedData = masterData.GetNewData();
                //if (addedData != null)
                //{
                //    InsertByParams(addedData);
                //}

            //    ts.Complete();
            //}
            return masterData;
        }

        /// <summary>
        /// 使用SQL语句的方式更新数据集
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual BaseList UpdateAllBySQL(BaseList masterData)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                foreach (BaseObject instance in masterData)
                {
                    if (instance.CurModel == DealModel.New)
                    {
                        DeleteInstance(instance);
                    }
                    else if (instance.CurModel == DealModel.Modify)
                    {
                        UpdateInstanceBySQL(instance);
                    }
                    else if (instance.CurModel == DealModel.New)
                    {
                        AddInstanceBySQL(instance);
                    }
                }
                //BaseList deleteData = masterData.GetDeleteData();
                //if (deleteData != null)
                //{
                //    Delete(deleteData);
                //}

                /////更新修改之数据
                //BaseList modifyData = masterData.GetUpdateData();
                //if (modifyData != null)
                //{
                //    UpdateBySQL(modifyData);
                //}

                /////更新新增之数据
                //BaseList addedData = masterData.GetNewData();
                //if (addedData != null)
                //{
                //    InsertBySQL(addedData);
                //}

                ts.Complete();
            }
            return masterData;
        }

        /// <summary>
        /// 用参数方式插入数据
        /// </summary>
        /// <param name="masterData">数据集合</param>
        /// <returns></returns>
        public virtual BaseList InsertByParams(BaseList masterData)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckInsertFields();

            using (TransactionScope ts = new TransactionScope())
            {
                BaseObject instance;

                PropertyInfo idpropertyInfo = _dataType.GetProperty(_RecordIDFieldName);

                for (int i = 0; i < masterData.Count; i++)
                {
                    instance = masterData[i];
                    //SqlParameter[] parms = GetInsertParams(instance);
                    decimal id = AddInstanceByParam(instance); //DbHelperSQL.ExecuteInsert(_InsertCMD, parms);
                    idpropertyInfo.SetValue(instance, id, null);
                }
                ts.Complete();
            }

            return masterData;
        }

        /// <summary>
        /// 插入一个实体数据，返回其AUTO_ID
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        public virtual decimal AddInstanceByParam(BaseObject _data)
        {
            try
            {
                SqlParameter[] parms = GetInsertParams(_data);
                _data.ID = DbHelperSQL.ExecuteInsert(_InsertCMD, parms);


                return _data.ID;
            }
            catch (Exception e) { LogHelper.Log("ERROR  MODIFY(DALObject) : " + e.Message); return -1; }
        }

        /// <summary>
        /// 用SQL语句方式插入数据
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual BaseList InsertBySQL(BaseList masterData)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckInsertFields();

            using (TransactionScope ts = new TransactionScope())
            {
                BaseObject instance;

                PropertyInfo idpropertyInfo = _dataType.GetProperty(_RecordIDFieldName);

                for (int i = 0; i < masterData.Count; i++)
                {

                    instance = masterData[i];
                    decimal id = AddInstanceBySQL(instance);
                    //string sqlStr = GetInsertSQL(instance);
                    //decimal id = DbHelperSQL.ExecuteInsert(sqlStr);
                    idpropertyInfo.SetValue(instance, id, null);
                }
                ts.Complete();
            }
            return masterData;
        }

        /// <summary>
        /// 按SQL语句方式插入数据，返回AUTO_ID
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        public virtual decimal AddInstanceBySQL(BaseObject _data)
        {
            string sqlStr = GetInsertSQL(_data);

            //return DbHelperSQL.ExecuteInsert(sqlStr);
            _data.ID = DbHelperSQL.ExecuteInsert(sqlStr);
            return _data.ID;
        }

        /// <summary>
        /// 使用参数方式更新数据
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual BaseList UpdateByParams(BaseList masterData)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckUpdateFields();

            using (TransactionScope ts = new TransactionScope())
            {
                for (int i = 0; i < masterData.Count; i++)
                {
                    UpdateInstanceByParam(masterData[i]);
                    //SqlParameter[] parms = GetUpdateParams(masterData[i]);
                    //DbHelperSQL.ExecuteSql(_UpdateCMD, parms);
                }
                ts.Complete();
            }

            return masterData;
        }

        /// <summary>
        /// 按参数方式修改实体数据
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        public virtual int UpdateInstanceByParam(BaseObject _data)
        {
            try
            {
                SqlParameter[] parms = GetUpdateParams(_data);

                return DbHelperSQL.ExecuteSql(_UpdateCMD, parms);
            }
            catch (Exception e) { LogHelper.Log("ERROR  ADD(DALObject) : " + e.Message); return -1; }
        }

        /// <summary>
        /// 使用SQL语句方式更新数据
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual BaseList UpdateBySQL(BaseList masterData)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckUpdateFields();
            using (TransactionScope ts = new TransactionScope())
            {
                for (int i = 0; i < masterData.Count; i++)
                {
                    UpdateInstanceBySQL(masterData[i]);
                    //string sqlStr = GetUpdateSQL(masterData[i]);
                    //DbHelperSQL.ExecuteSql(sqlStr);
                }
                ts.Complete();
            }
            return masterData;
        }

        /// <summary>
        /// 按SQL语句的方式修改实体数据
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        public virtual int UpdateInstanceBySQL(BaseObject _data)
        {
            string sqlStr = GetUpdateSQL(_data);

            return DbHelperSQL.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 删除指定数据
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual BaseList Delete(BaseList masterData)
        {
            CheckDataType();
            CheckRecordIDField();

            using (TransactionScope ts = new TransactionScope())
            {

                for (int i = 0; i < masterData.Count; i++)
                {
                    DeleteInstance(masterData[i]);
                }
                ts.Complete();
            }

            return masterData;
        }
        /// <summary>
        /// 删除实体数据
        /// </summary>
        /// <param name="_data"></param>
        public virtual int DeleteInstance(BaseObject _data)
        {
            string sqlStr = GetDeleteSQL(_data);
            return DbHelperSQL.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 通过ID删除记录
        /// </summary>
        /// <param name="recordID"></param>
        public virtual int Delete(decimal recordID)
        {
            CheckDataType();
            CheckRecordIDField();

            StringBuilder strSQL = new StringBuilder();

            strSQL.Append("DELETE FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(_RecordIDFieldName);
            strSQL.Append(" = ");
            strSQL.Append(recordID.ToString());
            return DbHelperSQL.ExecuteSql(strSQL.ToString());
        }

        /// <summary>
        /// 根据第一个Key Code值删除记录
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual int Delete(object keyCode)
        {
            CheckDataType();
            CheckKeyFields();

            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("DELETE FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(keyField.ColumnName);
            strSQL.Append(" = @" + keyField.ColumnName);

            SqlParameter[] parameters ={ DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCode, keyField.IsNullable) };
            return DbHelperSQL.ExecuteSql(strSQL.ToString(), parameters);
        }



        /// <summary>
        /// 根据所有KeyCode值删除记录
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <returns></returns>
        public virtual int Delete(Object[] keyCodes)
        {
            CheckDataType();
            CheckKeyFields();

            ///值数量与参数数量不合
            if (keyCodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("DELETE FROM ");
            strSQL.Append(_tableName);

            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];
            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                if (i == 0)
                {
                    strSQL.Append(" WHERE ");
                }
                else
                {
                    strSQL.Append(" AND ");
                }
                strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);

                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCodes[i], keyField.IsNullable);

            }
            return DbHelperSQL.ExecuteSql(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// 按条件删除资料
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <returns></returns>
        public virtual int Delete(ParamCollection _paramCollection)
        {
            CheckDataType();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("DELETE FROM ");
            strSQL.Append(_tableName);
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);


            return DbHelperSQL.ExecuteSql(strSQL.ToString(), GetParams(_paramCollection)); ;
        }




        #endregion 新增\修改\删除

        #region 查询并返回强类型数据集

        /// <summary>
        /// 返回所有数据
        /// </summary>
        /// <returns></returns>
        public virtual BaseList Select()
        {
            ParamCollection criteria = new ParamCollection();
            return this.Select(criteria, "");
        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public virtual BaseList Select(ParamCollection criteria)
        {
            return this.Select(criteria, "");
        }

        /// <summary>
        /// 根据ID查询记录集
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public virtual BaseList Select(decimal recordID)
        {
            return this.Select(recordID, _tableAliasName + "." + _RecordIDFieldName);
        }

        /// <summary>
        /// 根据ID查询记录集
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList Select(decimal recordID, string sort)
        {
            ParamCollection criteria = new ParamCollection();
            criteria.Clause = _tableAliasName + "." + _RecordIDFieldName + "=" + recordID.ToString();
            return this.Select(criteria, sort);
        }


        /// <summary>
        /// 返回查询结果数
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual Int32 GetCount(ParamCollection _paramCollection)
        {
            CheckDataType();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(GetCountCommand());
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            string sqlstr = strSQL.ToString();
            if (_paramCollection.ParaData == null)
            {
                _paramCollection.ParaData = selectPara;
            }
            else if (_paramCollection.ParaData.Length != selectPara.Length)
            {
                _paramCollection.ParaData = selectPara;
            }

            if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
            {
                sqlstr = String.Format(sqlstr, _paramCollection.ParaData);
            }


            return DbHelperSQL.GetCount(sqlstr, GetParams(_paramCollection));
        }


        /// <summary>
        /// 获取满足查询条件的记录并放到记录集
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList Select(ParamCollection _paramCollection, string sort)
        {
            try
            {

                CheckDataType();
                CheckRecordIDField();
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append(_SelectCMD);
                string whereClause = _paramCollection.Clause;
                if (whereClause != "")
                {
                    whereClause = " WHERE " + whereClause;
                }
                strSQL.Append(whereClause);

                strSQL.Append(getSortClause(sort));

                string sqlstr = strSQL.ToString();

                if (_paramCollection.ParaData == null)
                {
                    _paramCollection.ParaData = selectPara;
                }
                else if (_paramCollection.ParaData.Length != selectPara.Length)
                {
                    _paramCollection.ParaData = selectPara;
                }

                if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
                {
                    sqlstr = String.Format(sqlstr, _paramCollection.ParaData);
                }

                return getDataList(sqlstr, GetParams(_paramCollection));
            }
            catch (Exception e) { LogHelper.Log("ERROR   SELECT(DAL) : " + e.TargetSite.ToString() + " " + e.Message); return new BaseList(); }
        }

        /// <summary>
        /// 获取满足查询条件的记录并放到记录集
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList Select(ParamCollection _paramCollection, string sort, int indexStart, int indexEnd)
        {
            try
            {

                CheckDataType();
                CheckRecordIDField();
                StringBuilder strSQL = new StringBuilder();
                string sqlstr = "";
                string whereClause = _paramCollection.Clause;
                if (whereClause != "")
                {
                    whereClause = " WHERE " + whereClause;
                }
                strSQL.Append(_SelectPageCountCMD);
            
                if (_paramCollection.ParaData == null)
                {
                    _paramCollection.ParaData = selectPara;
                }
                else if (_paramCollection.ParaData.Length != selectPara.Length)
                {
                    _paramCollection.ParaData = selectPara;
                }
                if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
                {
                    sqlstr = String.Format(strSQL.ToString(), _paramCollection.ParaData[0].ToString(), getSortClause(sort), whereClause, indexStart, indexEnd);
                }
                else
                {
                    sqlstr = String.Format(strSQL.ToString(), 0, getSortClause(sort), whereClause, indexStart, indexEnd);
                }


                return getDataList(sqlstr, GetParams(_paramCollection));
            }
            catch (Exception e) { LogHelper.Log("ERROR   SELECT(DAL) : " + e.TargetSite.ToString() + " " + e.Message); return new BaseList(); }
        }


        /// <summary>
        /// 返回GROUP BY语句的查询结果
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="grouby"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList SelectGroup(ParamCollection _paramCollection, string grouby, string sort)
        {
            CheckDataType();
            CheckRecordIDField();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(GetGroupCommand());
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            strSQL.Append(" GROUP BY " + grouby);
            strSQL.Append(getSortClause(sort));

            string sqlstr = strSQL.ToString();
            if (_paramCollection.ParaData == null)
            {
                _paramCollection.ParaData = selectPara;
            }
            else if (_paramCollection.ParaData.Length != selectPara.Length)
            {
                _paramCollection.ParaData = selectPara;
            }

            if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
            {
                sqlstr = String.Format(sqlstr, _paramCollection.ParaData);
            }

            return getDataList(sqlstr, GetParams(_paramCollection));
        }

        /// <summary>
        /// 返回根据Dialog字段填充的数据
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList SelectDialog(ParamCollection _paramCollection, string sort)
        {
            CheckDataType();
            CheckRecordIDField();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(_SelectDialogCMD);
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            strSQL.Append(getSortClause(sort));
            string sqlstr = strSQL.ToString();
            if (_paramCollection.ParaData == null)
            {
                _paramCollection.ParaData = dialogPara;
            }
            else if (_paramCollection.ParaData.Length != dialogPara.Length)
            {
                _paramCollection.ParaData = dialogPara;
            }

            if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
            {
                sqlstr = String.Format(sqlstr, _paramCollection.ParaData);
            }
            return getDataListforDialog(sqlstr, GetParams(_paramCollection));
        }



        /// <summary>
        /// 返回前N条记录
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public virtual BaseList Select(ParamCollection _paramCollection, string sort, Int16 topCount)
        {
            CheckDataType();
            CheckRecordIDField();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(InitTopSelectCommand(topCount));
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            strSQL.Append(getSortClause(sort));
            string sqlstr = strSQL.ToString();
            if (_paramCollection.ParaData == null)
            {
                _paramCollection.ParaData = selectPara;
            }
            else if (_paramCollection.ParaData.Length != selectPara.Length)
            {
                _paramCollection.ParaData = selectPara;
            }

            if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
            {
                sqlstr = String.Format(sqlstr, _paramCollection.ParaData);
            }
            return getDataList(sqlstr, GetParams(_paramCollection));
        }

        /// <summary>
        /// 返回泛型的集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public BaseList getDataList(string sql, params SqlParameter[] cmdParms)
        {

            BaseList dataList = new BaseList();

            using (IDataReader dataReader = DbHelperSQL.getReader(sql, cmdParms))
            {
                while (dataReader.Read())
                {
                    BaseObject data = Activator.CreateInstance(_dataType) as BaseObject;
                    int M = data.CHECK_CODE;
                    data.CurModel = DealModel.None;
                    for (int i = 0; i < _SelectFields.Count; i++)
                    {
                        BaseFieldAttribute baseField = (BaseFieldAttribute)_SelectFields[i];
                        PropertyInfo propertyInfo = _dataType.GetProperty(baseField.AliasName);
                        if (dataReader[baseField.AliasName] != System.DBNull.Value)
                        {
                            try
                            {
                                propertyInfo.SetValue(data, dataReader[baseField.AliasName], null);
                            }
                            catch (Exception e) { LogHelper.Log("ERROR  getDataList(DAL) : " + baseField.AliasName + "  " + e.Message); }
                        }
                    }
                    //for (int i = 0; i < selectPropertyInfo.Count; i++)
                    //{

                    //    PropertyInfo propertyInfo = selectPropertyInfo[i];

                    //    if (dataReader[propertyInfo.Name] != System.DBNull.Value)
                    //    {
                    //        propertyInfo.SetValue(data, dataReader[propertyInfo.Name], null);
                    //    }

                    //}
                    dataList.Add(data);
                }
            }

            return dataList;
        }

        /// <summary>
        /// 返回根据Dialog字段设置的Datalist
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public BaseList getDataListforDialog(string sql, params SqlParameter[] cmdParms)
        {
            BaseList dataList = new BaseList();

            using (IDataReader dataReader = DbHelperSQL.getReader(sql, cmdParms))
            {
                while (dataReader.Read())
                {
                    BaseObject data = Activator.CreateInstance(_dataType) as BaseObject;
                    data.CurModel = DealModel.None;
                    for (int i = 0; i < _DialogFields.Count; i++)
                    {
                        BaseFieldAttribute baseField = (BaseFieldAttribute)_DialogFields[i];

                        PropertyInfo propertyInfo = _dataType.GetProperty(baseField.AliasName);
                        if (dataReader[baseField.AliasName] != System.DBNull.Value)
                        {

                            propertyInfo.SetValue(data, dataReader[baseField.AliasName], null);
                        }

                    }
                    dataList.Add(data);
                }
            }
            return dataList;
        }

        /// <summary>
        /// 根据KeyCode值查询结果集
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        public virtual BaseList Select(object keycode)
        {
            return this.Select(keycode, "");
        }

        /// <summary>
        /// 根据KeyCode值查询结果集
        /// </summary>
        /// <param name="keycode"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList Select(object keycode, string sort)
        {
            CheckDataType();
            CheckKeyFields();
            StringBuilder strSQL = new StringBuilder();

            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            strSQL.Append(_SelectCMD);
            strSQL.Append(" WHERE ");
            strSQL.Append(_tableAliasName + "." + keyField.ColumnName);
            strSQL.Append(" = @" + keyField.ColumnName);

            SqlParameter[] parameters ={ DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keycode, keyField.IsNullable) };

            string sqlstr = strSQL.ToString();
            if (selectPara != null && selectPara.Length > 0)
            {
                sqlstr = String.Format(sqlstr, selectPara);
            }

            return getDataList(sqlstr, parameters);

        }

        /// <summary>
        /// 根据KeyCode值查询结果集
        /// </summary>
        /// <param name="keycodes"></param>
        /// <returns></returns>
        public virtual BaseList Select(object[] keycodes)
        {
            return this.Select(keycodes, "");
        }

        /// <summary>
        /// 根据KeyCode值查询结果集
        /// </summary>
        /// <param name="keycodes"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList Select(object[] keycodes, string sort)
        {
            CheckDataType();
            CheckKeyFields();

            ///值数量与参数数量不合
            if (keycodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();

            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            strSQL.Append(_SelectCMD);

            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];
            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                if (i == 0)
                {
                    strSQL.Append(" WHERE ");
                }
                else
                {
                    strSQL.Append(" AND ");
                }
                strSQL.Append(_tableAliasName + "." + keyField.ColumnName + "=@" + keyField.ColumnName);

                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keycodes[i], keyField.IsNullable);

            }

            //BaseData dsData = Activator.CreateInstance(_dataType) as BaseData;
            //DbHelperSQL.Fill(strSQL.ToString(), dsData, _tableAliasName, parameters);
            string sqlstr = strSQL.ToString();
            if (selectPara != null && selectPara.Length > 0)
            {
                sqlstr = String.Format(sqlstr, selectPara);
            }
            return getDataList(sqlstr, parameters);

        }

        #endregion 查询并返回强类型数据集

        #region Utility

        /// <summary>
        /// 检查数据类型是否为NULL
        /// </summary>
        protected void CheckDataType()
        {
            if (_dataType == null)
                throw new Exception(_errMsg);
        }

        /// <summary>
        /// 检查Record ID字段是否存在
        /// </summary>
        protected void CheckRecordIDField()
        {
            if (_RecordIDFieldName == "")
                throw new Exception(_errMsg);
        }

        /// <summary>
        /// 检查Key Fields字段是否存在
        /// </summary>
        protected void CheckKeyFields()
        {
            if (_KeyFields.Count <= 0)
                throw new Exception(_errMsg);
        }

        /// <summary>
        /// 检查是否存在新增字段
        /// </summary>
        protected void CheckInsertFields()
        {
            if (_InsertFields.Count <= 0)
                throw new Exception(_errMsg);
        }

        /// <summary>
        /// 检查是否存在更新字段
        /// </summary>
        protected void CheckUpdateFields()
        {
            if (_UpdateFields.Count <= 0)
                throw new Exception(_errMsg);
        }

        /// <summary>
        /// 获取排序子句
        /// </summary>
        /// <param name="sord"></param>
        /// <returns></returns>
        private string getSortClause(string sort)
        {
            StringBuilder sortSQL = new StringBuilder();
            sortSQL.Append(" ORDER BY ");
            if (sort == "" || sort == null)
            {
                if (_KeyFields.Count > 0)//如果存在KeyCode，则按KeyCode排序
                {
                    _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
                    KeyFieldAttribute keyField;
                    for (int i = 0; i < _KeyFields.Count; i++)
                    {
                        keyField = (KeyFieldAttribute)_KeyFields[i];
                        sortSQL.Append(_tableAliasName + "." + keyField.ColumnName);
                        sortSQL.Append(",");
                    }
                    sortSQL.Remove(sortSQL.Length - 1, 1);
                }
                else
                {
                    sortSQL.Append(_tableAliasName + "." + _RecordIDFieldName);
                }
            }
            else
            {
                sortSQL.Append(sort);
            }
            sortSQL.Append("    ");
            return sortSQL.ToString();
        }

        private string getRowNumClause(int indexStart, int indexEnd)
        {
            StringBuilder ClauesSQL = new StringBuilder();
            ClauesSQL.Append("AND ");
            ClauesSQL.Append(_tableName);
            ClauesSQL.Append(".ROW_NUM ");
            ClauesSQL.Append(" BETWEEN ");
            ClauesSQL.Append(" {0} ");
            ClauesSQL.Append(" AND ");
            ClauesSQL.Append(" {1} ");
            return String.Format(ClauesSQL.ToString(), indexStart, indexEnd);
        }

        /// <summary>
        /// 参数列表
        /// </summary>
        /// <param name="_ParamCollection"></param>
        /// <returns></returns>
        public SqlParameter[] GetParams(ParamCollection _ParamCollection)
        {
            SqlParameter[] parameters = new SqlParameter[_ParamCollection.Count];
            for (int i = 0; i < _ParamCollection.Count; i++)
            {
                SqlParameter parameter = DbHelperSQL.CreateDataParameter("@" + _ParamCollection[i].ParamName, _ParamCollection[i].DataType, _ParamCollection[i].Value);
                parameters[i] = parameter;
            }
            return parameters;
        }

        /// <summary>
        /// 返回格式化之后用于插入数据库的日期时间字符串
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="isTime"></param>
        /// <returns></returns>
        public static string getFieldDateFormat(DateTime datetime, bool isTime)
        {
            string dateFormate = "";
            if (isTime)
            {
                dateFormate = datetime.ToString("'" + Const.datetimeFormat + "'");
            }
            else
            {
                dateFormate = datetime.ToString("'" + Const.dateFormat + "'");
            }
            return dateFormate;
        }

        #endregion

    }
}
