using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Crownbio.Model;

namespace Crownbio.DAL
{
	/// <summary>
    /// 数据访问类SysFunctionDAL。
	/// </summary>
	public class SysFunctionDAL
	{
        public SysFunctionDAL()
		{}
		#region  成员方法

		
		/// <summary>
		/// 目录、模块、功能列表
		/// </summary>
        public static FunctionCollection GetFunctionList()
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select FUNCTION_ID,FUNCTION_CODE,FUNCTION_NAME,SYS_MODULE.MODULE_CODE AS MODULE_CODE, ");
            strSql.Append("MODULE_NAME,PARENT_CODE from SYS_FUNCTION ");
            strSql.Append(" INNER JOIN SYS_MODULE ON SYS_MODULE.MODULE_CODE=SYS_FUNCTION.MODULE_CODE ");
            //strSql.Append(" WHERE SYS_MODULE.IS_AVAILABLE='N' ");
            strSql.Append(" ORDER BY SYS_MODULE.MODULE_CODE,FUNCTION_CODE ");
			
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            FunctionCollection funcList = new FunctionCollection();
			if(ds.Tables[0].Rows.Count>0)
			{
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SYS_FUNCTION model = new SYS_FUNCTION();
                    model.FUNCTION_ID = ds.Tables[0].Rows[i]["FUNCTION_ID"].ToString();
                    model.FUNCTION_CODE = decimal.Parse(ds.Tables[0].Rows[i]["FUNCTION_CODE"].ToString());
                    model.FUNCTION_NAME = ds.Tables[0].Rows[i]["FUNCTION_NAME"].ToString();
                    model.MODULE_CODE = ds.Tables[0].Rows[i]["MODULE_CODE"].ToString();
                    model.MODULE_NAME = ds.Tables[0].Rows[i]["MODULE_NAME"].ToString();
                    model.PARENT_CODE = ds.Tables[0].Rows[i]["PARENT_CODE"].ToString();

                    funcList.Add(model);
                }
			}

            return funcList;
			
		}

        /// <summary>
        /// 目录、模块、功能列表
        /// </summary>
        public static FunctionCollection GetFunctionList(string module_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FUNCTION_ID,FUNCTION_CODE,FUNCTION_NAME,SYS_MODULE.MODULE_CODE AS MODULE_CODE, ");
            strSql.Append("MODULE_NAME,PARENT_CODE from SYS_FUNCTION ");
            strSql.Append(" INNER JOIN SYS_MODULE ON SYS_MODULE.MODULE_CODE=SYS_FUNCTION.MODULE_CODE ");
            strSql.Append(" WHERE SYS_MODULE.IS_AVAILABLE='Y' ");
            strSql.Append(" AND SYS_MODULE.MODULE_TYPE='" + module_type + "' ");
            strSql.Append(" ORDER BY SYS_MODULE.MODULE_CODE,FUNCTION_CODE ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            FunctionCollection funcList = new FunctionCollection();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SYS_FUNCTION model = new SYS_FUNCTION();
                    model.FUNCTION_ID = ds.Tables[0].Rows[i]["FUNCTION_ID"].ToString();
                    model.FUNCTION_CODE = decimal.Parse(ds.Tables[0].Rows[i]["FUNCTION_CODE"].ToString());
                    model.FUNCTION_NAME = ds.Tables[0].Rows[i]["FUNCTION_NAME"].ToString();
                    model.MODULE_CODE = ds.Tables[0].Rows[i]["MODULE_CODE"].ToString();
                    model.MODULE_NAME = ds.Tables[0].Rows[i]["MODULE_NAME"].ToString();
                    model.PARENT_CODE = ds.Tables[0].Rows[i]["PARENT_CODE"].ToString();

                    funcList.Add(model);
                }
            }

            return funcList;

        }

		#endregion  成员方法
	}
}

