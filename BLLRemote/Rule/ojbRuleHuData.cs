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
    public class ojbRuleHuData
    {
        public static DataTable getCountBankBox(string Location_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(Specimen_Stock_ID) as number FROM [Specimen_Stock]");
            strSql.Append(" where [Location_ID] = '{0}'");
       
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString(), Location_ID), ds, "table");
            return ds.Tables[0];
        }
        public static DataTable getDTgroup_workload(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * , case when convert(varchar(12) , Randomization, 23 ) = '0001-01-01' then '' else convert(varchar(12) , Randomization, 23 ) end as Randomization ");
            strSql.Append("FROM [HuData].[dbo].[PROJECT_MONITOR] ");
            strSql.Append("left join PROJECT_MONITOR_STUDY_DESIGN on PROJECT_MONITOR_STUDY_DESIGN.PROJECT_MONITOR_ID = [PROJECT_MONITOR].PROJECT_MONITOR_ID ");
            strSql.Append("where Randomization <> '' ");
            strSql.Append("and DT_Group = 'DT group1' ");
            
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
            return ds.Tables[0];
        }

        public static DataTable GetCancerTypeTree()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ( ");
            strSql.Append(" SELECT (case when (SUBSTRING([Model_ID],1,1) collate Chinese_PRC_CS_AI) ='m' then SUBSTRING([Model_ID],2,2) ");
            strSql.Append(" else SUBSTRING([Model_ID],1,2) end ) as abbr ");
            strSql.Append(" FROM [ANIMAL_TREE]  ");
            strSql.Append(" where P_ID='0' group by case when (SUBSTRING([Model_ID],1,1) collate Chinese_PRC_CS_AI) ='m' then SUBSTRING([Model_ID],2,2)");
            strSql.Append(" else SUBSTRING([Model_ID],1,2) end ");
            strSql.Append(" )t left join CancerType_Abbr on CancerType_Abbr.Abbreviation  = t.abbr order by abbr");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
            return ds.Tables[0];
        }

        public static DataTable GetCancerTypeTree_ModelID(string pcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM [HuData].[dbo].[ANIMAL_TREE] ");
            strSql.Append("where P_ID='0' and (case when (SUBSTRING([Model_ID],1,1) collate Chinese_PRC_CS_AI) ='m' then SUBSTRING([Model_ID],2,2) else SUBSTRING([Model_ID],1,2) end ) = '{0}' order by Model_ID");            
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString(),pcode), ds, "table");
            return ds.Tables[0];
        }


        #region GetCancerType
        public static DataTable GetCancerType_Abbr()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT max(Cancer_Type) as CancerType, max(Abbreviation) as Abbreviation ");
            strSql.Append("FROM CancerType_Abbr ");
            strSql.Append("group by Cancer_Type ");
            strSql.Append("order by CancerType ");

            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
            return ds.Tables[0];
        }

        public static DataTable GetCancerType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ' ' CancerType union all SELECT max(Cancer_Type) as CancerType ");
            strSql.Append("FROM CancerType_Abbr ");
            strSql.Append("group by Cancer_Type ");
            strSql.Append("order by CancerType ");

            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
            return ds.Tables[0];
        }

        public static void deleteCancerType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CancerType_Abbr ");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
        }
        public static void deleteAnimalInfo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete ANIMAL_INFO ");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
        }
        public static void deleteSponsor()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SPONSOR_AX_CODE ");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
        }
        public static void deleteSubtype1()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Cancer_Subtype1 ");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
        }
        public static void deleteSubtype2()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Cancer_Subtype2 ");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
        }
        #endregion


        #region getSearchAlive
        public static DataTable getSearchAlive()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT max([Mortality_Observation]) as Mortality_Observation ");
            strSql.Append(" FROM [HuData].[dbo].[ANIMAL_INFO] ");
            strSql.Append("group by [Mortality_Observation] ");
            strSql.Append("order by [Mortality_Observation] ");

            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "table");
            return ds.Tables[0];
        }
        #endregion
        


        #region GetSubtype
        public static DataTable GetSubtype(string cancer_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ' ' Subtype1 union all ");
            strSql.Append("SELECT Subtype1 ");
            strSql.Append("FROM [HuData].[dbo].[Cancer_Subtype1] ");
            //strSql.Append("where Subtype1 <> '' ");
            //if (cancer_type != "" && cancer_type != " ")
            //{
            //    strSql.Append("and [CANCER_TYPE] = '{0}' ");
            //}
            strSql.Append("order by Subtype1 ");

            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString(), cancer_type), ds, "table");
            return ds.Tables[0];
        }
        public static DataTable GetSubtype2(string cancer_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ' ' Subtype2 union all ");
            strSql.Append("SELECT Subtype2 ");
            strSql.Append("FROM [HuData].[dbo].[Cancer_Subtype2] ");
            //strSql.Append("where Subtype2 <> '' ");
            //if (cancer_type != "" && cancer_type != " ")
            //{
            //    strSql.Append("and [CANCER_TYPE] = '{0}' ");
            //}
            //strSql.Append("group by SUBTYPE2 ");
            strSql.Append("order by Subtype2 ");

            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString(), cancer_type), ds, "table");
            return ds.Tables[0];
        }
        #endregion

        #region getProjectbooking
        public static DataTable getProjectbooking()
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT * FROM [HuData].[dbo].[PROJECT_BOOKING] ");

            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "booking");
            return ds.Tables[0];
        }
        #endregion

        #region getModifyLogCount
        public static DataTable getModifyLogCount()
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT MAX([REQUEST_ID]) as [REQUEST_ID] ,COUNT([REQUEST_ID]) as log_count ");
            strSql.Append("FROM [HuData].[dbo].[REQUEST_LOG] ");
            strSql.Append("group by [REQUEST_ID] ");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "logs");
            return ds.Tables[0];
        }
        #endregion


        #region getProjectBooking
        public static DataTable getProjectBooking(string txtAnimalBooking, string txtFurtherExpanding, string txtRevive, string searchModelID, string searchBD, string searchSD, string txtPN, string txtAnimal_Number)
        {
            SqlParameter[] para1 = new SqlParameter[] { 
                new SqlParameter("@txtAnimalBooking",txtAnimalBooking),
                  new SqlParameter("@txtFurtherExpanding",txtFurtherExpanding),
                   new SqlParameter("@txtRevive",txtRevive),
                    new SqlParameter("@searchModelID",searchModelID),
                      new SqlParameter("@searchBD",searchBD),
                        new SqlParameter("@searchSD",searchSD),
                          new SqlParameter("@txtPN",txtPN),
                             new SqlParameter("@txtAnimal_Number",txtAnimal_Number)
            };
            DataTable dt = ojbReportRule.GetGrid("getProjectBooking", para1);
            return dt;
        }
        #endregion

        #region Husbandry
        public static DataTable Husbandry()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT   [Model_ID] , Rn,  Pn,  ");
            strSql.Append(" case when convert(varchar(12) , DOI, 23 ) = '0001-01-01' then '' else convert(varchar(12) ,DOI, 23 ) end as [DOI], ");
            strSql.Append(" [Cage], [Number_in_Cage], ");
            strSql.Append(" case when convert(varchar(12) , Date_of_Update, 23 ) = '0001-01-01' then '' else convert(varchar(12) ,Date_of_Update, 23 ) end as [Date_of_Update], ");
            strSql.Append(" [Hunbandry_Days] ,[Cost_accumulation] ");
            strSql.Append(" FROM [HuData].[dbo].[Husbandry_Analysis]  ");


            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "Husbandry_Analysis");
            return ds.Tables[0];
        }
        public static DataTable Husbandry2()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  max([Cancer_Type])as [Cancer_Type],max([Model_ID])as [Model_ID] , max([Rn]) as Rn, max([Pn]) as Pn,  ");
            strSql.Append(" max([DOI]) as [DOI],  max([Cage]) as [Cage], ");
            strSql.Append(" case when max([Number_in_Cage]) <> '0' then MAX([Number_in_Cage]) else count([Cage]) end as [Number_in_Cage], ");
            strSql.Append(" max([Date_of_Update]) as [Date_of_Update], ");
            strSql.Append(" max([Hunbandry_Days])  as [Hunbandry_Days] , max([Cost_accumulation])as [Cost_accumulation] ,max([Project])as [Project]");
            strSql.Append(" ,max([Ongoing_Project]) as [Ongoing_Project], max([Source_Project]) as [Source_Project] ");
            strSql.Append(" FROM [HuData].[dbo].[Husbandry_Temp]  ");
            strSql.Append(" group by [MODEL_ID],[Rn],[Pn],[Cage] order by MODEL_ID,Rn,Pn  ");

            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "Husbandry_Temp");
            return ds.Tables[0];
        }
        public static Int32 delHusbandry()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [HuData].[dbo].[Husbandry_Analysis]");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "Husbandry");
            return ds.Tables.Count;
        }
        public static Int32 delHusbandry_Temp()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [HuData].[dbo].[Husbandry_Temp]");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "Husbandry_Temp");
            return ds.Tables.Count;
        }
        public static Int32 delHusbandry_Days()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [HuData].[dbo].[Husbandry_Days]");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString()), ds, "Husbandry");
            return ds.Tables.Count;
        }


        public static string getCancerType_Abbr(string cancertype)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Abbreviation from CancerType_Abbr where Cancer_Type = '{0}'");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString(), cancertype), ds, "CancerType_Abbr");
            return ds.Tables[0].Rows[0][0].ToString();
        }
        #endregion

        public static int DelCheck_SpecimenStocks(string str)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from [HuData].[dbo].[Specimen_Stock] where CAST(Specimen_Stock_ID as varchar) in (");
            strSql.Append(str + ")");
            return DbHelperSQL.ExecuteSql(String.Format(strSql.ToString()));
        }

        public static bool CheckIsAdmin(decimal uid,string role_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from sys_user_role");
            strSql.Append(" where USER_ID = '{0}' and ROLE_NO in (select ROLE_NO from SYS_ROLE where ROLE_NAME = '"+ role_name + "') ");
            DataSet ds = new DataSet();
            DbHelperSQL.Fill(String.Format(strSql.ToString(), uid.ToString()), ds, "table");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
    }
}
