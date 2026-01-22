using System;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Crownbio.Model;
using Crownbio.DAL;
using Crownbio.Utility;
using Crownbio.Language;
using Crownbio.Common;

namespace Crownbio.BLL
{
    /// <summary>
    /// 提供基于DataSet的操作方法
    /// </summary>
    public class ojbReportRule
    {
        #region member,constructor

        public ojbReportRule()
        {
        }

        public static void InsertBigSql(DataTable table, ArrayList columns, string tablename)
        {
            try
            {
                DbHelperSQL.SqlBulkCopyData(table, columns, tablename);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);

            }
        }
      

        #region

      
        //总grid
        public static DataTable GetGrid(string proc_name, SqlParameter[] parameters)
        {
            DataSet ds = DbHelperSQL.RunProcedure(proc_name, parameters, "table");
            return ds.Tables[0];
        }

        public static int GetTotle(string proc_name, SqlParameter[] parameters)
        {
            IDataReader dataReader = DbHelperSQL.RunProcedureTotle(proc_name, parameters, "table");
            int count = 0;
            while (dataReader.Read())
            {
                count = (int)dataReader[0];
            }
            return count;

        }
        //  //分页grid
        //public static DataTable GetgridCircuit(string proc_name, int pageSize, int CurrentPageIndex, string pid)
        //{
        //    SqlParameter[] parameters = { DbHelperSQL.CreateDataParameter("@pageSize", DbType.Int16, pageSize, false), DbHelperSQL.CreateDataParameter("@CurrentPageIndex", DbType.Int16, CurrentPageIndex, false)
        //                                , DbHelperSQL.CreateDataParameter("@F_circuitid", DbType.String, pid, false)};
        //    DataSet ds = DbHelperSQL.RunProcedure(proc_name, parameters, "table");
        //    return ds.Tables[0];
        //}
        #endregion
   


        //datagrid
        #region
        //不带参数，不分页
        public static DataTable Getdatagrid(string proc_name)
        {
            DataSet ds = DbHelperSQL.RunProcedure(proc_name, new SqlParameter[] { }, "table");
            return ds.Tables[0];
        }
        //带分页
        public static DataTable Getdatagrid(string proc_name, int pageSize, int CurrentPageIndex)
        {
            SqlParameter[] parameters = { DbHelperSQL.CreateDataParameter("@pageSize", DbType.Int16, pageSize, false), DbHelperSQL.CreateDataParameter("@CurrentPageIndex", DbType.Int16, CurrentPageIndex, false) };
            DataSet ds = DbHelperSQL.RunProcedure(proc_name, parameters, "table");
            return ds.Tables[0];
        }
        //带日期参数，不分页
        public static DataTable Getdatagrid(string proc_name, DateTime timestamp)
        {
            SqlParameter[] parameters = { DbHelperSQL.CreateDataParameter("@timestamp", DbType.DateTime, timestamp, false) };
            DataSet ds = DbHelperSQL.RunProcedure(proc_name, parameters, "table");
            return ds.Tables[0];
        }
        //带日期参数，分页
        public static DataTable Getdatagrid(string proc_name, int pageSize, int CurrentPageIndex, DateTime begintime, DateTime endtime)
        {
            SqlParameter[] parameters = { 
            DbHelperSQL.CreateDataParameter("@pageSize", DbType.Int16, pageSize, false), 
            DbHelperSQL.CreateDataParameter("@CurrentPageIndex", DbType.Int16, CurrentPageIndex, false),
            DbHelperSQL.CreateDataParameter("@begintime", DbType.DateTime, begintime, false),  
            DbHelperSQL.CreateDataParameter("@endtime", DbType.DateTime, endtime, false)
                                        };
            DataSet ds = DbHelperSQL.RunProcedure(proc_name, parameters, "table");
            return ds.Tables[0];
        }
        #endregion

        #endregion

        public static void ImportRole(string _roleCode, string _NewRole)
        {
            try
            {
                StringBuilder buider = new StringBuilder();
                buider.Append(" INSERT INTO SYS_PERM  ");
                buider.Append(" (ROLE_NO,FUNCTION_ID,CREATE_BY,CREATE_TIME,UPDATE_BY,UPDATE_TIME) ");
                buider.Append(" SELECT  '{0}' ,FUNCTION_ID ,'{1}' ,'{2}','{1}' ,'{2}' FROM SYS_PERM  WHERE SYS_PERM.ROLE_NO = '{3}'");
                string sql = String.Format(buider.ToString(), _NewRole, CacheHelper.getCurrentUser().USER_ID, DateTime.Now.ToString("yyyy-MM-dd HH:mm"), _roleCode);
                DbHelperSQL.ExecuteSql(sql);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);

            }
        }

        /// <summary>
        /// crownbio-ccle
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        #region
        //CCLE_Tree
        public static DataTable GetSitePrimary()
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT ");
            strSql.Append("max(Cancer_type) Cancer_type ");
            strSql.Append(" FROM [HUBASE].[dbo].[CancerModel] where Isdelete = 'N'");
            strSql.Append(" group by Cancer_type");
            DataSet ds1 = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds1, "table");
            return ds1.Tables[0];
        }
        public static DataTable GetSitePrimary_1(string param)
        {


            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT ");
            strSql.Append("max(Cancer_type) Cancer_type ");
            strSql.Append(" FROM [HUBASE].[dbo].[CancerModel] where Isdelete = 'N' and sample_name in (" + param + ")");
            strSql.Append(" group by Cancer_type");
            DataSet ds1 = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds1, "table");
            return ds1.Tables[0];
        }
        //copbynumber_cellline_tree in All
        public static DataTable GetTreeCellline(string pid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CancerModel_Id,sample_name,Cancer_type ");
            strSql.Append("where Cancer_type = '{0}' and Isdelete = 'N' ");
            DataSet ds1 = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString(), pid), ds1, "table");
            return ds1.Tables[0];
        }

        /// <summary>
        /// CopyNumber_GetCellline_tree in All
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static DataTable GetCopyNumber_GetCellline_tree(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("CopyNumber_GetCellline_tree", para1);
            return dt;
        }
        /// <summary>
        /// CopyNumber_GetCellline_tree in CBIS
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCopyNumber_GetCellline_treetype_cbis()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("CopyNumber_GetCellline_treetype_cbis", para1);
            return dt;
        }
        public static DataTable GetCopyNumber_GetCellline_tree_cbis(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("CopyNumber_GetCellline_tree_cbis", para1);
            return dt;
        }
        /// <summary>
        /// CopyNumber_GetCellline_tree in XenoSelect
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCopyNumber_GetCellline_treetype_xeno()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("CopyNumber_GetCellline_treetype_xeno", para1);
            return dt;
        }
        public static DataTable GetCopyNumber_GetCellline_tree_Xeno(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("CopyNumber_GetCellline_tree_Xeno", para1);
            return dt;
        }

        //Search 页面 左边树
        public static DataTable HuBase_AllCellline_treetype()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("HuBase_AllCellline_treetype", para1);
            return dt;
        }
        public static DataTable HuBase_AllCellline_tree(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("HuBase_AllCellline_tree", para1);
            return dt;
        }
        /// <summary>
        /// GetXenoBase_GetCellline_tree in All
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static DataTable XenoBase_AllCellline_treetype()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("XenoBase_AllCellline_treetype", para1);
            return dt;
        }
        public static DataTable XenoBase_AllCellline_tree(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("XenoBase_AllCellline_tree", para1);
            return dt;
        }
        /// <summary>
        /// GetXenoBase_GetCellline_tree in CBIS
        /// </summary>
        /// <returns></returns>
        public static DataTable XenoBase_AllCellline_treetype_cbis()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("XenoBase_AllCellline_treetype_cbis", para1);
            return dt;
        }
        public static DataTable XenoBase_AllCellline_tree_cbis(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("XenoBase_AllCellline_tree_cbis", para1);
            return dt;
        }
        /// <summary>
        /// XenoBase_AllCellline_treetype_xeno
        /// </summary>
        /// <returns></returns>
        public static DataTable XenoBase_AllCellline_treetype_xeno()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("XenoBase_AllCellline_treetype_xeno", para1);
            return dt;
        }
        public static DataTable XenoBase_AllCellline_tree_xeno(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("XenoBase_AllCellline_tree_xeno", para1);
            return dt;
        }



        /// <summary>
        /// CCLE和CGP的cellline in all
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static DataTable GetMutation_AllCellline_treetype()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("GetMutation_AllCellline_treetype", para1);
            return dt;
        }
        public static DataTable GetMutation_AllCellline_tree(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("GetMutation_AllCellline_tree", para1);
            return dt;
        }
        /// <summary>
        /// CCLE和CGP的cellline in cbis
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMutation_AllCellline_treetype_cbis()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("GetMutation_AllCellline_treetype_cbis", para1);
            return dt;
        }
        public static DataTable GetMutation_AllCellline_tree_cbis(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("GetMutation_AllCellline_tree_cbis", para1);
            return dt;
        }
        /// <summary>
        /// CCLE和CGP的cellline in xeno
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMutation_AllCellline_treetype_xeno()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("GetMutation_AllCellline_treetype_xeno", para1);
            return dt;
        }
        public static DataTable GetMutation_AllCellline_tree_xeno(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("GetMutation_AllCellline_tree_xeno", para1);
            return dt;
        }

        /// <summary>
        /// xenoModel的cellline in xeno
        /// </summary>
        /// <returns></returns>
        public static DataTable GetXenoModel_treetype_xeno(string model, string drug)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@Model", model), new SqlParameter("@Drug", drug) };
            DataTable dt = ojbReportRule.GetGrid("GetXenoModel_treetype_xeno", para1);
            return dt;
        }
        public static DataTable GetXenoModel_tree_xeno(string pid, string model, string drug)
        {
            SqlParameter[] para1 = new SqlParameter[] { 
                new SqlParameter("@pid", pid), new SqlParameter("@Model", model),new SqlParameter("@Drug", drug)
            };
            DataTable dt = ojbReportRule.GetGrid("GetXenoModel_tree_xeno", para1);
            return dt;
        }






        /// <summary>
        /// GeneExpress_GetCellline_tree in All
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static DataTable GetGeneExpress_GetCellline_tree(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("GeneExpress_GetCellline_tree", para1);
            return dt;
        }
        public static DataTable getTumorModel(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("GetTumorModel", para1);
            return dt;
        }
        public static DataTable getTumorModel_CN(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("GetTumorModel_CN", para1);
            return dt;
        }
        public static DataTable getTumorModel_MU(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("GetTumorModel_MU", para1);
            return dt;
        }
        public static DataTable getModelCancerType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ModelID,Cancer_type FROM TumorModel inner join CancerModel on CancerModel.sample_name = substring (ModelID,0,7)  where Isdelete = 'N'");
            DataSet ds1 = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds1, "table");
            return ds1.Tables[0];
        }
        public static DataTable getModelCancerTypeCN()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CN_ModelID,Cancer_type FROM TumorModel_CN inner join CancerModel on CancerModel.sample_name = substring (CN_ModelID,0,7)  where Isdelete = 'N'");
            DataSet ds1 = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds1, "table");
            return ds1.Tables[0];
        }
        public static DataTable getCopyNumber_ALL_View_models()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TumorModel_CN.CN_ModelID as All_models,t.CN_ModelID as View_models from");
            strSql.Append(" TumorModel_CN left join");
            strSql.Append(" (SELECT CN_ModelID,Cancer_type FROM TumorModel_CN inner join CancerModel on CancerModel.sample_name = substring (CN_ModelID,0,7)  where Isdelete = 'N') as t");
            strSql.Append(" on TumorModel_CN.CN_ModelID = t.CN_ModelID");
            strSql.Append(" order by TumorModel_CN.CN_ModelID");
            DataSet ds1 = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds1, "table");
            return ds1.Tables[0];
        }
        public static DataTable GetGeneExpress_GetCellline_tree2(string SOCname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CancerModel_Id,sample_name,Cancer_type from CancerModel ");
            strSql.Append(" where Isdelete = 'N' and sample_name in (" + SOCname + ")");
            DataSet ds1 = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds1, "table");
            return ds1.Tables[0];
        }
        public static DataTable GetGeneExpress_GetCellline_tree_1(string pid, string SOCname)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select CancerModel_Id,sample_name,Cancer_type from CancerModel ");
            strSql.Append("where Isdelete = 'N' and  Cancer_type = '" + pid + "' ");
            strSql.Append(" and sample_name in (" + SOCname + ")");
            DataSet ds1 = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds1, "table");
            return ds1.Tables[0];
        }
        /// <summary>
        /// GeneExpress_GetCellline_tree in CBIS
        /// </summary>
        /// <returns></returns>
        public static DataTable GetGeneExpress_GetCellline_treetype_cbis()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("GeneExpress_GetCellline_treetype_cbis", para1);
            return dt;
        }
        public static DataTable GetGeneExpress_GetCellline_tree_cbis(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("GeneExpress_GetCellline_tree_cbis", para1);
            return dt;
        }
        /// <summary>
        /// GeneExpress_GetCellline_tree in XenoSelect
        /// </summary>
        /// <returns></returns>
        public static DataTable GetGeneExpress_GetCellline_treetype_xeno()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("GeneExpress_GetCellline_treetype_xeno", para1);
            return dt;
        }
        public static DataTable GetGeneExpress_GetCellline_tree_Xeno(string pid)
        {
            SqlParameter[] para1 = new SqlParameter[] { new SqlParameter("@pid", pid) };
            DataTable dt = ojbReportRule.GetGrid("GeneExpress_GetCellline_tree_Xeno", para1);
            return dt;
        }


        //CGP in All
        public static DataTable GetMutation_CGPCellline()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("GetMutation_CGPCellline", para1);
            return dt;
        }
        //CGP in CBIS
        public static DataTable GetMutation_CGPCellline_InCBIS()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("GetMutation_CGPCellline_InCBIS", para1);
            return dt;
        }
        //CGP in XenoSelect
        public static DataTable GetMutation_CGPCellline_Xeno()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("GetMutation_CGPCellline_Xeno", para1);
            return dt;
        }
        //combobox
        public static DataTable GetSitePrimaryAll()
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT 'All Type'  SitePrimary FROM CCLE_CellLineAnnotations  union SELECT ");
            strSql.Append("max(SitePrimary) SitePrimary ");
            strSql.Append(" FROM [CCLE].[dbo].[CCLE_CellLineAnnotations] ");
            strSql.Append(" group by SitePrimary ");
            DataSet ds1 = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds1, "table");
            return ds1.Tables[0];
        }
        #endregion


        public static DataTable getXenoDrugs()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Max(Drug) as id,Max(Drug) as value FROM [CCLE].[dbo].[Xeno_Data] where Drug <> '' and Drug not like '%&%' group by Drug order by Drug ");
            DataSet ds1 = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds1, "table");
            return ds1.Tables[0];

        }


        //check-Cellline in mouse model
        public static bool IsNotInMouseModel(string cellline)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CCLE_name from XenoSelect where cell_line = '{0}'");
            DataSet ds1 = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString(), cellline), ds1, "table");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0][0].ToString() != "mouse_cell")
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return true;
            }
        }
        public static DataTable GetGeneNameRNA_Custom()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT max(feature_name) + '(' + MAX(feature_id) + ')' as GeneName  ");
            strSql.Append("  FROM [HUBASE].[dbo].[GeneExpressionRNA_Custom]");
            strSql.Append("  group by feature_name");
            strSql.Append("  order by feature_name");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
            return ds.Tables[0];
        }
        public static DataTable GetGeneNameRNA_Affymetrix()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GeneName from (");
            strSql.Append("  SELECT max(gene_name) + '(' +  max(transcript_id) + ')' as GeneName ,MAX(gene_name)  as gene_name");
            strSql.Append("  FROM GeneExpressionRNA_Affymetrix ");
            strSql.Append("  group by transcript_id ) t order by gene_name");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
            return ds.Tables[0];
        }


        #region 获取用户模块权限
        /// <summary>
        /// 获取用户模块权限
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="fname"></param>
        /// <param name="Operate"></param>
        /// <returns></returns>
        public static bool GetUserFunctions(PermCollection perm, string fname, string Operate)
        {
            ObjectBLL bll = new ObjectBLL();
            bool _dealPerm = false;
            BaseList dataf = bll.Select(queryF(fname, Operate), typeof(HUBASE_FUNCTION));
            if (dataf.Count > 0)
            {
                if (perm.Find(dataf[0].ID.ToString()) != null)
                {
                    _dealPerm = true;
                }
            }
            return _dealPerm;
        }

        public static bool GetUserFunctions2(PermCollection perm, string fname, List<string> Operates)
        {
            ObjectBLL bll = new ObjectBLL();
            bool _dealPerm = false;
            foreach (string op in Operates)
            {
                BaseList dataf = bll.Select(queryF(fname, op), typeof(HUBASE_FUNCTION));
                if (dataf.Count > 0)
                {
                    if (perm.Find(dataf[0].ID.ToString()) != null)
                    {
                        _dealPerm = true;
                        break;
                    }
                }
            }
            return _dealPerm;
        }

        private static ParamCollection queryF(string fname, string Operat)
        {
            ParamCollection paraList = new ParamCollection();
            string Clause = "";
            string column = "";

            column = HUBASE_FUNCTION.FUNCTION_NAME_FIELD;
            Clause += string.Format("({0}.{1} =@{1})", HUBASE_FUNCTION.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, fname));

            column = HUBASE_FUNCTION.OPERATE_FIELD;
            Clause += string.Format(" AND ({0}.{1} =@{1})", HUBASE_FUNCTION.TABLE_NAME, column);
            paraList.Add(new ParamData(column, DbType.String, Operat));

            paraList.Clause = Clause;
            return paraList;
        }

        #endregion


        #region GetGeneName_MutationValidated
        public static DataTable GetGeneName_MutationValidated()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from GeneName_MutationValidated");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
            return ds.Tables[0];
        }
        #endregion

        #region GetgridAnimalInfo
        public static DataTable GetgridAnimalInfo()
        {
            SqlParameter[] para1 = new SqlParameter[] { };
            DataTable dt = ojbReportRule.GetGrid("GetdgAnimalInfo", para1);
            return dt;
        }
        #endregion

        //getAllUsers
        public static DataTable getAllUsers()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT USER_ID, [First_name] as [First Name],[Last_name] as  [Last Name] ,[EMAIL] as Email ,[IS_AVAILABLE] as Available");
            strSql.Append(" ,[Position] ,[Department] ,[Institution]");
            strSql.Append(" ,[Street_Address] as [Street Address] ,[City] ,[Country]  ,[Phone]   ,[Fax]");
            strSql.Append(" FROM [HuData].[dbo].[SYS_USER] order by USER_ID DESC");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
            return ds.Tables[0];
        }

       
    }
}
