using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Transactions;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Crownbio.Common;
using Crownbio.Utility;


namespace Crownbio.DAL
{
    /// <summary>
    /// 数据访问抽象基础类
    /// Copyright (C) 2004-2008 Crownbio
    /// All rights reserved
    /// </summary>
    public abstract class DbHelperSQL
    {
        #region Member
        public static string connectionString = "YLYConnectionstring";

        public DbHelperSQL()
        {
        }

        #endregion

        #region 公用方法


        /// <summary>
        /// 获取表某个字段的最大值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strSql = "select max(" + FieldName + ")+1 from " + TableName;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                object obj = db.ExecuteScalar(dbCommand);

                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return 1;
                }
                else
                {
                    return int.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// 返回数据库服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDBSystemDatetime()
        {
            string strSql = "select getdate() ";
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                object obj = db.ExecuteScalar(dbCommand);

                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return DateTime.Now;
                }
                else
                {
                    return (DateTime)obj;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }


        /// <summary>
        /// 检测一个记录是否存在(SQL语句方式)
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static bool Exists(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                object obj = db.ExecuteScalar(dbCommand);
                int cmdresult;
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    cmdresult = 0;
                }
                else
                {
                    cmdresult = int.Parse(obj.ToString());
                }
                if (cmdresult == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// 检测一个记录是否存在(SqlParameter语句方式)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                object obj = db.ExecuteScalar(dbCommand);
                int cmdresult;
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    cmdresult = 0;
                }
                else
                {
                    cmdresult = int.Parse(obj.ToString());
                }
                if (cmdresult == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }


        #endregion

        #region Create SqlParameter

        /// <summary>
        /// 创建一个SqlParameter
        /// </summary>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter()
        {
            return new SqlParameter();
        }

        /// <summary>
        /// 创建一个SqlParameter
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="dataType">参数类型</param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, DbType dataType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.DbType = dataType;
            return parameter;
        }

        /// <summary>
        /// 创建一个SqlParameter
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        /// <summary>
        /// 创建一个SqlParameter
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="dataType">参数类型</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, DbType dataType, object value)
        {
            SqlParameter parameter = new SqlParameter();

            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.Value = value;
            return parameter;
        }

        public static SqlParameter CreateDataParameter(string name, DbType dataType, object value, bool isNullable)
        {
            SqlParameter parameter = new SqlParameter();

            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.IsNullable = isNullable;
            parameter.Value = value;
            return parameter;
        }

        /// <summary>
        /// 创建一个SqlParameter
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="dataType">参数类型</param>
        /// <param name="size">参数允许的长度</param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, DbType dataType, int size)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.Size = size;
            return parameter;
        }

        public static SqlParameter CreateDataParameter(string name, DbType dataType, bool isNullable)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.IsNullable = isNullable;
            return parameter;
        }

        /// <summary>
        /// 创建一个SqlParameter
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="dataType">参数类型</param>
        /// <param name="size">参数长度</param>
        /// <param name="srcColumn">参数对应的DataSet列名</param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, DbType dataType, int size, string srcColumn)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.Size = size;
            parameter.SourceColumn = srcColumn;
            return parameter;
        }

        /// <summary>
        /// 创建一个SqlParameter
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="dataType">参数类型</param>
        /// <param name="size">参数长度</param>
        /// <param name="direction"></param>
        /// <param name="isNullable"></param>
        /// <param name="precision"></param>
        /// <param name="scale"></param>
        /// <param name="srcColumn"></param>
        /// <param name="srcVersion"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(string name, DbType dataType, int size, ParameterDirection direction, bool isNullable, Byte precision, Byte scale, string srcColumn, DataRowVersion srcVersion, object value)
        {
            SqlParameter parameter = new SqlParameter();

            parameter.ParameterName = name;
            parameter.DbType = dataType;
            parameter.Size = size;
            parameter.Direction = direction;
            parameter.IsNullable = isNullable;
            parameter.Precision = precision;
            parameter.Scale = scale;
            parameter.SourceColumn = srcColumn;
            parameter.SourceVersion = srcVersion;
            parameter.Value = value;
            return parameter;
        }

        /// <summary>
        /// 创建一个SqlParameter
        /// </summary>
        /// <param name="fieldAttribute"></param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(BaseFieldAttribute fieldAttribute)
        {
            return CreateDataParameter(fieldAttribute, DataRowVersion.Current);
        }

        /// <summary>
        /// 创建一个SqlParameter
        /// </summary>
        /// <param name="fieldAttribute">列属性</param>
        /// <param name="srcVersion">版本</param>
        /// <returns></returns>
        public static SqlParameter CreateDataParameter(BaseFieldAttribute fieldAttribute, DataRowVersion srcVersion)
        {
            SqlParameter parameter = new SqlParameter();
            string name = "";

            if (srcVersion == DataRowVersion.Original)
            {
                name = "@ORIGINAL_" + fieldAttribute.AliasName;
            }
            else
            {
                name = "@" + fieldAttribute.AliasName;
            }

            parameter.ParameterName = name;
            parameter.DbType = fieldAttribute.DataType;
            parameter.Size = fieldAttribute.Size;
            parameter.Direction = ParameterDirection.Input;
            //parameter.IsNullable = isNullable;
            parameter.Precision = fieldAttribute.Precision;
            parameter.Scale = fieldAttribute.Scale;
            parameter.SourceColumn = fieldAttribute.AliasName;
            parameter.SourceVersion = srcVersion;
            //parameter.Value = value;
            return parameter;
        }



        /// <summary>
        /// 加载参数
        /// </summary>
        /// <param name="db"></param>
        /// <param name="dbCommand"></param>
        /// <param name="cmdParms"></param>
        public static void BuildDBParameter(Database db, DbCommand dbCommand, params SqlParameter[] cmdParms)
        {
            foreach (SqlParameter sp in cmdParms)
            {
                db.AddInParameter(dbCommand, sp.ParameterName, sp.DbType, sp.Value);
            }
        }

        #endregion

        #region  执行简单SQL语句

        public static int GetCount(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                object obj = db.ExecuteScalar(dbCommand);
                int cmdresult;
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    cmdresult = 0;
                }
                else
                {
                    cmdresult = int.Parse(obj.ToString());
                }
                return cmdresult;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数(对于长时间查询的语句，设置等待时间避免查询超时)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="Times"></param>
        /// <returns></returns>
        public static int ExecuteSqlByTime(string strSql, int Times)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                dbCommand.CommandTimeout = Times;
                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }

        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList"></param>
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            Database db = DatabaseFactory.CreateDatabase(connectionString);
            string strsql = "";
            try
            {
                for (int n = 0; n < SQLStringList.Count; n++)
                {
                    strsql = SQLStringList[n].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        DbCommand dbCommand = db.GetSqlStringCommand(strsql);
                        db.ExecuteNonQuery(dbCommand);
                        LogHelper.LogDB("Normal", strsql);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strsql);
                throw new Exception(ex.Message + ",SQL=" + strsql, ex);
            }
            //    ts.Complete();
            //}
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：使用后一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                SqlDataReader dr = (SqlDataReader)db.ExecuteReader(dbCommand);
                return dr;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        public static IDataReader getReader(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                IDataReader dr = db.ExecuteReader(dbCommand);
                return dr;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// (对于长时间查询的语句，设置等待时间避免查询超时)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="Times"></param>
        /// <returns></returns>
        public static DataSet Query(string strSql, int Times)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                dbCommand.CommandTimeout = Times;
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        #endregion

        #region Fill Data
        /// <summary>
        /// 根据SQL语句填充数据到指定的DataSet中
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        public static void Fill(string strSql, DataSet dataSet, string tableName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                if (dataSet.Tables.Contains(tableName))
                    dataSet.Tables[tableName].Clear();
                db.LoadDataSet(dbCommand, dataSet, tableName);
                LogHelper.LogDB("Select", strSql);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// 使用指定SQL语句、指定参数填充数据到指定DataSet中
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        /// <param name="cmdParms"></param>
        public static void Fill(string strSql, DataSet dataSet, string tableName, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                if (dataSet.Tables.Contains(tableName))
                    dataSet.Tables[tableName].Clear();
                db.LoadDataSet(dbCommand, dataSet, tableName);
                LogHelper.LogDB("Select", strSql, cmdParms);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }

        }

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                LogHelper.LogDB("Normal", strSql);
                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }


        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static int ExecuteSql(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                LogHelper.LogDB("Execute", strSql, cmdParms);
                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            Database db = DatabaseFactory.CreateDatabase(connectionString);
            string strsql = "";
            try
            {
                foreach (DictionaryEntry myDE in SQLStringList)
                {
                    strsql = myDE.Key.ToString();
                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                    if (strsql.Trim().Length > 1)
                    {
                        DbCommand dbCommand = db.GetSqlStringCommand(strsql);
                        BuildDBParameter(db, dbCommand, cmdParms);
                        db.ExecuteNonQuery(dbCommand);
                        LogHelper.LogDB("Normal", strsql, cmdParms);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strsql);
                throw new Exception(ex.Message + ",SQL=" + strsql, ex);
            }
            //    ts.Complete();
            //}

        }


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="strSql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                object obj = db.ExecuteScalar(dbCommand);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }
        public static object GetSingle(string strSql, ref string strError)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                object obj = db.ExecuteScalar(dbCommand);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                strError = ex.Message;
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="strSql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                object obj = db.ExecuteScalar(dbCommand);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }

        }

        /// <summary>
        /// 返回记录ID
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static decimal GetID(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                object obj = db.ExecuteScalar(dbCommand);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return -1;
                }
                else
                {
                    return (decimal)obj;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// 执行一条插入语句，语法如下，返回主键ID
        /// Insert Into Customers (Name, Address, City, Country, PostalCode) values ([Name], [Address],[City],[Country],[PostalCode]); Select @@IDENTITY;";
        /// </summary>
        /// <param name="strSql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static decimal ExecuteInsert(string strSql)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                object obj = db.ExecuteScalar(dbCommand);
                LogHelper.LogDB("Insert", strSql);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return -1;
                }
                else
                {
                    return Convert.ToDecimal(obj);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// 执行一条插入语句，语法如下，返回主键ID
        /// Insert Into Customers (Name, Address, City, Country, PostalCode) values (@Name, @Address, @City, @Country, @PostalCode); Select @@IDENTITY;";
        /// </summary>
        /// <param name="strSql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static decimal ExecuteInsert(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                object obj = db.ExecuteScalar(dbCommand);
                LogHelper.LogDB("Insert", strSql, cmdParms);
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return -1;
                }
                else
                {
                    return Convert.ToDecimal(obj);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：使用后一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                SqlDataReader dr = (SqlDataReader)db.ExecuteReader(dbCommand);
                return dr;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string strSql, params SqlParameter[] cmdParms)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(strSql);
                BuildDBParameter(db, dbCommand, cmdParms);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, strSql, cmdParms);
                throw new Exception(ex.Message + ",SQL=" + strSql, ex);
            }
        }



        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程，返回影响的行数       
        /// </summary>       
        public static int RunProcedure(string storedProcName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcName);
                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }

        /// <summary>
        /// 执行存储过程，返回输出参数的值和影响的行数       
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="OutParameter">输出参数名称</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static object RunProcedure(string storedProcName, IDataParameter[] InParameters, SqlParameter OutParameter, int rowsAffected)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcName);
                BuildDBParameter(db, dbCommand, (SqlParameter[])InParameters);
                db.AddOutParameter(dbCommand, OutParameter.ParameterName, OutParameter.DbType, OutParameter.Size);
                rowsAffected = db.ExecuteNonQuery(dbCommand);
                return db.GetParameterValue(dbCommand, "@" + OutParameter.ParameterName);  //得到输出参数的值
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }

        /// <summary>
        /// 执行存储过程，返回SqlDataReader ( 注意：使用后一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string storedProcName, SqlParameter[] parameters)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcName);
                BuildDBParameter(db, dbCommand, parameters);
                return (SqlDataReader)db.ExecuteReader(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }

        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, SqlParameter[] parameters, string tableName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcName);
                BuildDBParameter(db, dbCommand, parameters);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }
        /// <summary>
        /// 执行存储过程，返回总行数
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static IDataReader RunProcedureTotle(string storedProcName, SqlParameter[] parameters, string tableName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcName);
                BuildDBParameter(db, dbCommand, parameters);
                return db.ExecuteReader(dbCommand);

            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }
        /// <summary>
        /// 执行存储过程，返回DataSet(设定等待时间)
        /// </summary>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcName, parameters);
                dbCommand.CommandTimeout = Times;
                //BuildDBParameter(db, dbCommand, parameters);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }

        /// <summary>
        /// 构建SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(storedProcName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.
                        if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        command.Parameters.Add(parameter);
                    }
                }
                return command;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex, storedProcName);
                throw new Exception(ex.Message + ",SQL=" + storedProcName, ex);
            }
        }

        #endregion


        #region 大数据导入sql
        public static void SqlBulkCopyData(DataTable dt, ArrayList columns, string tablename)
        {
            try
            {
                string connection = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
                using (SqlBulkCopy bulkCopy = new
                SqlBulkCopy(connection))
                {

                    foreach (string column in columns)
                    {
                        bulkCopy.ColumnMappings.Add(column, column);
                    }
                    bulkCopy.DestinationTableName = tablename;
                    bulkCopy.WriteToServer(dt);
                    bulkCopy.Close();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                throw new Exception(ex.Message);
            }

        }
        #endregion
    }

}
