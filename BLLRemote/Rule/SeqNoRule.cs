using System;
using System.Transactions;
using System.Data;
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
    public class SeqNoRule
    {
        /// <summary>
        /// 返回指定类型的序列号
        /// </summary>
        /// <param name="noType"></param>
        /// <returns></returns>
        public static string getSeqNo(string noType)
        {
            string yymm = DbHelperSQL.GetDBSystemDatetime().ToString("yyMM");
            string sql = "select SERIALS from SYS_NO where YYMM='" + yymm + "' AND NO_TYPE='" + noType + "'";
            object seq_no = DbHelperSQL.GetSingle(sql); 
            decimal seq = 0;
            if (seq_no == null)
            {
                sql = "Insert into SYS_NO(NO_TYPE,YYMM,SERIALS) values('" + noType + "','" + yymm + "',1)";
                seq = 1;
            }
            else
            {
                seq = (decimal)seq_no + 1;
                sql = "Update SYS_NO set SERIALS=" + seq + " WHERE NO_TYPE='" + noType + "' AND YYMM='" + yymm + "'";
            }
            DbHelperSQL.ExecuteSql(sql);
            string seqNo = "" + seq;
            while (seqNo.Length < 5)
            {
                seqNo = "0" + seqNo;
            }
            return noType + yymm + seqNo;
        }


        /// <summary>
        /// 返回某一类的代码编码
        /// </summary>
        /// <param name="noType"></param>
        /// <param name="yymm"></param>
        /// <param name="CodeLen"></param>
        /// <returns></returns>
        public static string getSeqNo(string noType, int CodeLen)
        {
            string sql = "select SERIALS from SYS_NO where YYMM='" + noType + "' AND NO_TYPE='" + noType + "'";
            object seq_no = DbHelperSQL.GetSingle(sql);
            decimal seq = 0;
            if (seq_no == null)
            {
                sql = "Insert into SYS_NO(NO_TYPE,YYMM,SERIALS) values('" + noType + "','" + noType + "',1)";
                seq = 1;
            }
            else
            {
                seq = (decimal)seq_no + 1;
                sql = "Update SYS_NO set SERIALS=" + seq + " WHERE NO_TYPE='" + noType + "' AND YYMM='" + noType + "'";
            }
            DbHelperSQL.ExecuteSql(sql);
            string seqNo = "" + seq;
            while (seqNo.Length < CodeLen)
            {
                seqNo = "0" + seqNo;
            }
            return noType + seqNo;
        }


        public static int MaxSeqNo(string tableName, string keyField, string keyValue, string seqField)
        {
            StringBuilder SqlBuider = new StringBuilder();

            SqlBuider.Append("SELECT ");
            SqlBuider.Append(" MAX(convert(int,");
            SqlBuider.Append(seqField);
            SqlBuider.Append(")) ");
            SqlBuider.Append(" FROM ");
            SqlBuider.Append(tableName);
            SqlBuider.Append(" WHERE ");
            SqlBuider.Append(keyField);
            SqlBuider.Append(" ='");
            SqlBuider.Append(keyValue);
            SqlBuider.Append("' ");

            object Seq = DbHelperSQL.GetSingle(SqlBuider.ToString());
            if (Seq != null)
                return int.Parse(Seq.ToString());
            else
                return 0;
        }

        public static decimal getFileSeq(string ProjectCode, string fileType)
        {
            StringBuilder SqlBuider = new StringBuilder();

            SqlBuider.Append("SELECT ");
            SqlBuider.Append(" MAX(");
            SqlBuider.Append(" REMARK ");
            SqlBuider.Append(") ");
            SqlBuider.Append(" FROM ");
            SqlBuider.Append(" APP_FILE ");
            SqlBuider.Append(" WHERE ");
            SqlBuider.Append(" PROJECT_CODE ");
            SqlBuider.Append(" ='");
            SqlBuider.Append(ProjectCode);
            SqlBuider.Append("' ");
            SqlBuider.Append(" AND FILE_TYPE ");
            SqlBuider.Append(" ='");
            SqlBuider.Append(fileType);
            SqlBuider.Append("' ");

            object Seq = DbHelperSQL.GetSingle(SqlBuider.ToString());
            if (Seq != null)
                return decimal.Parse(Seq.ToString()) + 1;
            else
                return 1;
        }

    }
}
