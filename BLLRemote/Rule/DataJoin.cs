using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Crownbio.BLL
{
    public class DataJoin
    {
        public static DataTable Join(DataTable First, DataTable Second, DataColumn[] FJC, DataColumn[] SJC, int m, bool includeLeftJoin, bool includeRightJoin)
        {
            //创建一个新的DataTable
            DataTable table = new DataTable("Join");
            try
            {
                // Use a DataSet to leverage DataRelation
                using (DataSet ds = new DataSet())
                {
                    //把DataTable Copy到DataSet中
                    ds.Tables.AddRange(new DataTable[] { First.Copy(), Second.Copy() });
                    DataColumn[] parentcolumns = new DataColumn[FJC.Length];
                    for (int i = 0; i < parentcolumns.Length; i++)
                    {
                        parentcolumns[i] = ds.Tables[0].Columns[FJC[i].ColumnName];
                    }
                    DataColumn[] childcolumns = new DataColumn[SJC.Length];
                    for (int i = 0; i < childcolumns.Length; i++)
                    {
                        childcolumns[i] = ds.Tables[1].Columns[SJC[i].ColumnName];
                    }
                    //创建关联
                    DataRelation r = new DataRelation(string.Empty, parentcolumns, childcolumns, false);
                    ds.Relations.Add(r);
                    //为关联表创建列
                    for (int i = 0; i < First.Columns.Count; i++)
                    {
                        table.Columns.Add(First.Columns[i].ColumnName, First.Columns[i].DataType);
                    }
                    for (int i = 0; i < Second.Columns.Count; i++)
                    {
                        //看看有没有重复的列，如果有在第二个DataTable的Column的列明后加_Second
                        if (!table.Columns.Contains(Second.Columns[i].ColumnName))
                            table.Columns.Add(Second.Columns[i].ColumnName, Second.Columns[i].DataType);
                        else
                            table.Columns.Add(Second.Columns[i].ColumnName + m.ToString(), Second.Columns[i].DataType);
                    }
                    table.BeginLoadData();



                    foreach (DataRow firstrow in ds.Tables[0].Rows)
                    {
                        //内连接
                        DataRow[] childrows = firstrow.GetChildRows(r);
                        if (childrows != null && childrows.Length > 0)
                        {
                            object[] parentarray = firstrow.ItemArray;
                            foreach (DataRow secondrow in childrows)
                            {
                                object[] secondarray = secondrow.ItemArray;
                                object[] joinarray = new object[parentarray.Length + secondarray.Length];
                                Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length);
                                Array.Copy(secondarray, 0, joinarray, parentarray.Length, secondarray.Length);
                                table.LoadDataRow(joinarray, true);
                            }
                        }
                        else//去掉就是内连接，加上是左链接
                        {
                            if (includeLeftJoin)
                            {
                                object[] parentarray = firstrow.ItemArray;
                                object[] joinarray = new object[parentarray.Length];
                                Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length);
                                table.LoadDataRow(joinarray, true);
                            }
                        }
                    }
                    if (includeRightJoin)
                    {
                        //add right join relations
                        DataRelation drRightJoin = new DataRelation("rRight", childcolumns, parentcolumns, false);
                        ds.Relations.Add(drRightJoin);

                        foreach (DataRow parentRow in ds.Tables[1].Rows)
                        {
                            DataRow[] childrenRowList = parentRow.GetChildRows(drRightJoin);
                            if (childrenRowList == null || childrenRowList.Length == 0)
                            {
                                object[] parentArray = parentRow.ItemArray;
                                object[] joinArray = new object[table.Columns.Count];
                                Array.Copy(parentArray, 0, joinArray,
                                    joinArray.Length - parentArray.Length, parentArray.Length);
                                table.LoadDataRow(joinArray, true);
                            }
                        }
                    }
                    table.EndLoadData();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }


        public static DataTable Join(DataTable First, DataTable Second, DataColumn FJC, DataColumn SJC, int m, bool includeLeftJoin, bool includeRightJoin)
        {
            return Join(First, Second, new DataColumn[] { FJC }, new DataColumn[] { SJC }, m, includeLeftJoin, includeRightJoin);
        }

        public static DataTable Join(DataTable First, DataTable Second, string FJC, string SJC, int m, bool includeLeftJoin, bool includeRightJoin)
        {
            return Join(First, Second, new DataColumn[] { First.Columns[FJC] }, new DataColumn[] { Second.Columns[SJC] }, m, includeLeftJoin, includeRightJoin);
        }
    }
}
