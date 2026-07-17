using System;
using System.Transactions;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Crownbio.Model;
using Crownbio.DAL;
using Crownbio.Utility;
using Crownbio.Language;
using Crownbio.Common;
using System.Data.SqlClient;
using System.Web;
using Crownbio.BLL.Rule;

namespace Crownbio.BLL
{
    /// <summary>
    /// 提供基于DataSet的操作方法
    /// </summary>
    public class ObjectBLL : MarshalByRefObject
    {
        #region member,constructor

        public ObjectBLL()
        {
        }


        #endregion

        #region property
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName(Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).TableName;
        }

        /// <summary>
        /// 表别名
        /// </summary>
        public string TableAliasName(Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).TableAliasName;
        }

        /// <summary>
        /// 获取表自动增长字段名称
        /// </summary>
        public string RecordIDFieldName(Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).RecordIDFieldName;
        }

        /// <summary>
        /// 获取Auto ID字段
        /// </summary>
        public ArrayList RecordIDFields(Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).RecordIDFields;
        }

        /// <summary>
        /// 获取Key Code字段列表
        /// </summary>
        public ArrayList KeyFields(Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).KeyFields;
        }

        /// <summary>
        /// 获取外键字段列表
        /// </summary>
        public ArrayList ForeignKeyFields(Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).ForeignKeyFields;
        }

        /// <summary>
        /// 获取关联表中的字段列表
        /// </summary>
        public ArrayList ForeignFields(Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).ForeignFields;
        }

        /// <summary>
        /// 获取普通字段列表
        /// </summary>
        public ArrayList DataFields(Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).DataFields;
        }

        /// <summary>
        /// 获取Select语句中的字段列表
        /// </summary>
        public ArrayList SelectFields(Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).SelectFields;
        }

        /// <summary>
        /// 获取Dialog中显示的字段
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public ArrayList DialogFields(Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).DialogFields;
        }
        #endregion

        #region Find\GetID\GetKeyCode\GetKeyCodes

        /// <summary>
        /// 查询指定ID的记录是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public bool Find(decimal recordID, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Find(recordID);
        }

        /// <summary>
        /// 查询指定Key值的记录是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Find(object code, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Find(code);
        }

        /// <summary>
        /// 查询指定Key值的记录是否存在
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool Find(object[] codes, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Find(codes);
        }

        /// <summary>
        /// 检查除指定ID外的KeyCode是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Find(decimal recordID, object code, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Find(recordID, code);
        }

        /// <summary>
        /// 检查除指定ID外的KeyCode是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool Find(decimal recordID, object[] codes, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Find(recordID, codes);
        }

        /// <summary>
        /// 检查除指定ID外的非KeyCode是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool Find(decimal recordID, string field, object codes, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Find(recordID, field, codes);
        }

        /// <summary>
        /// 根据KeyCode返回ID
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public decimal GetID(object code, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).GetID(code);
        }

        /// <summary>
        /// 根据第一个Key值返回指定的栏位值
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="fieldName"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public object GetFieldValue(Object keyCode, string fieldName, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).GetFieldValue(keyCode, fieldName);
        }

        /// <summary>
        /// 根据所有Key值返回指定栏位值
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <param name="fieldName"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public object GetFieldValue(Object[] keyCodes, string fieldName, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).GetFieldValue(keyCodes, fieldName);
        }

        /// <summary>
        /// 根据查询条件返回指定栏位值
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="fieldName"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public object GetFieldValue(ParamCollection _paramCollection, string fieldName, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).GetFieldValue(_paramCollection, fieldName);
        }

        /// <summary>
        /// 根据查询条件返回栏位值
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="fieldName"></param>
        /// <param name="sort"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public object GetFieldValue(ParamCollection _paramCollection, string fieldName, string sort, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).GetFieldValue(_paramCollection, fieldName, sort);
        }

        /// <summary>
        /// 根据KeyCodes返回ID
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <returns></returns>
        public decimal GetID(object[] keyCodes, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).GetID(keyCodes);
        }

        /// <summary>
        /// 根据ID返回KeyCode
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public object GetCode(decimal recordID, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).GetCode(recordID);
        }

        /// <summary>
        /// 根据ID返回所有KeyCodes
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public object[] GetCodes(decimal recordID, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).GetCodes(recordID);
        }

        #endregion

        #region Insert,Update,Delete
        /// <summary>
        /// 插入一个实体数据
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public decimal Add(BaseObject instanceData)
        {
            if (instanceData == null)
                return -1;
            return ObjectBLLHelper.getTypeDAL(instanceData.GetType()).AddInstanceByParam(instanceData);
        }

        /// <summary>
        /// 修改一个实体数据，返回影响的行数，是新增时返回ID
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public decimal Modify(BaseObject instanceData)
        {
            if (instanceData == null)
                return -1;
            return ObjectBLLHelper.getTypeDAL(instanceData.GetType()).UpdateInstanceByParam(instanceData);
        }
        /// <summary>
        /// 修改一个实体数据，返回影响的行数，是新增时返回ID
        /// </summary>
        /// <param name="instanceData"></param>
        /// <returns></returns>
        public decimal Update(BaseObject instanceData)
        {
            if (instanceData == null)
                return -1;
            if (instanceData.CurModel == DealModel.New)
            {
                return ObjectBLLHelper.getTypeDAL(instanceData.GetType()).AddInstanceByParam(instanceData);
            }
            else
            {
                return (decimal)ObjectBLLHelper.getTypeDAL(instanceData.GetType()).UpdateInstanceByParam(instanceData);
            }
        }


        /// <summary>
        /// 删除一条实体数据，返回影响的行数
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public decimal Delete(BaseObject instanceData)
        {
            if (instanceData == null)
                return -1;
            return ObjectBLLHelper.getTypeDAL(instanceData.GetType()).DeleteInstance(instanceData);
        }

        /// <summary>
        /// 更新主从表
        /// </summary>
        /// <param name="masterData">主表</param>
        /// <param name="datas">从表的数组</param>
        public decimal UpdateMasterDetail(BaseObject masterData, BaseList[] datas)
        {
            if (datas == null)
                return -1;
            if (datas.Length <= 0)
                return -1;
            //using (TransactionScope ts = new TransactionScope())
            //{
            Update(masterData);
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i] == null)
                    continue;
                for (int j = 0; j < datas[i].Count; j++)
                {
                    datas[i][j].PID = masterData.ID;
                }
                UpdateAllByParams(datas[i]);
            }
            //    ts.Complete();
            //}
            return masterData.ID;
        }
        /// <summary>
        /// 更新流程主从表
        /// </summary>
        /// <param name="masterData">主表</param>
        /// <param name="datas">从表的数组</param>
        public void UpdateMasterDetail(BaseObject[] masterData, BaseList[] datas)
        {
            if (datas == null)
                return;
            if (datas.Length <= 0)
                return;
            //using (TransactionScope ts = new TransactionScope())
            //{
            for (int i = 0; i < masterData.Length; i++)
            {
                Update(masterData[i]);
            }
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i] == null)
                    continue;
                //for (int j = 0; j < datas[i].Count; j++)
                //{
                //    datas[i][j].PID = masterData.ID;
                //}
                UpdateAllByParams(datas[i]);
            }
            //    ts.Complete();
            //}
            //return masterData.ID;
        }

        public void UpdateMasterDetail(BaseObject[] masterData)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            for (int i = 0; i < masterData.Length; i++)
            {
                Update(masterData[i]);
            }
            //    ts.Complete();
            //}
        }

        //以上为新增方法

        /// <summary>
        /// 更新多表
        /// </summary>
        /// <param name="datas"></param>
        public void UpdateMultiData(BaseList[] datas)
        {
            if (datas == null)
                return;
            if (datas.Length <= 0)
                return;
            //using (TransactionScope ts = new TransactionScope())
            //{
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i] == null)
                    continue;
                UpdateAllByParams(datas[i]);
            }
            //    ts.Complete();
            //}
        }




        /// <summary>
        /// 使用参数的方式更新数据集
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public void UpdateAllByParams(BaseList masterData)
        {
            if (masterData.Count > 0)
            {
                try
                {
                    Type _dataType = masterData[0].GetType();
                    if (_dataType == typeof(APP_FILE))
                    {
                        List<BaseObject> del = masterData.FindAll(BaseObject.IsDelete);
                        FileRule.DelFile(BaseList.convertToBaseList(del));
                        List<BaseObject> delNot = masterData.FindAll(BaseObject.IsNotDelete);
                        ObjectBLLHelper.getTypeDAL(_dataType).UpdateAllByParams(BaseList.convertToBaseList(delNot));
                    }
                    else
                    {
                        ObjectBLLHelper.getTypeDAL(_dataType).UpdateAllByParams(masterData);
                    }

                }
                catch (Exception ec)
                {
                    LogHelper.Log(ec.Message);
                }
            }
        }

        /// <summary>
        /// 使用SQL语句的方式更新数据集
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public void UpdateAllBySQL(BaseList masterData)
        {
            if (masterData.Count > 0)
            {
                Type _dataType = masterData[0].GetType();
                ObjectBLLHelper.getTypeDAL(_dataType).UpdateAllBySQL(masterData);
            }
        }

        /// <summary>
        /// 用参数方式插入数据
        /// </summary>
        /// <param name="masterData">数据集合</param>
        /// <returns></returns>
        public void InsertByParams(BaseList masterData)
        {
            if (masterData.Count > 0)
            {
                Type _dataType = masterData[0].GetType();
                ObjectBLLHelper.getTypeDAL(_dataType).InsertByParams(masterData);
            }
        }

        /// <summary>
        /// 用SQL语句方式插入数据
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public void InsertBySQL(BaseList masterData)
        {
            if (masterData.Count > 0)
            {
                Type _dataType = masterData[0].GetType();
                ObjectBLLHelper.getTypeDAL(_dataType).InsertBySQL(masterData);
            }
        }

        /// <summary>
        /// 使用参数方式更新数据
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public void UpdateByParams(BaseList masterData)
        {
            if (masterData.Count > 0)
            {
                Type _dataType = masterData[0].GetType();
                ObjectBLLHelper.getTypeDAL(_dataType).UpdateByParams(masterData);
            }
        }

        /// <summary>
        /// 使用SQL语句方式更新数据
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public void UpdateBySQL(BaseList masterData)
        {
            if (masterData.Count > 0)
            {
                Type _dataType = masterData[0].GetType();
                ObjectBLLHelper.getTypeDAL(_dataType).UpdateAllBySQL(masterData);
            }
        }

        /// <summary>
        /// 删除指定数据
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public void Delete(BaseList masterData)
        {
            if (masterData.Count > 0)
            {
                Type _dataType = masterData[0].GetType();
                if (_dataType == typeof(APP_FILE))
                {
                    FileRule.DelFile(masterData);
                }
                else
                {
                    ObjectBLLHelper.getTypeDAL(_dataType).Delete(masterData);
                }
            }
        }

        /// <summary>
        /// 通过ID删除记录
        /// </summary>
        /// <param name="recordID"></param>
        public int Delete(decimal recordID, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Delete(recordID);
        }

        /// <summary>
        /// 根据第一个Key Code值删除记录
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual int Delete(object keyCode, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Delete(keyCode);
        }



        /// <summary>
        /// 根据所有KeyCode值删除记录
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <returns></returns>
        public virtual int Delete(Object[] keyCodes, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Delete(keyCodes);
        }

        /// <summary>
        /// 按条件删除资料
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public virtual int Delete(ParamCollection _paramCollection, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Delete(_paramCollection);
        }

        /// <summary>
        /// 删除Master-Detail数据
        /// </summary>
        /// <param name="masterdata"></param>
        /// <param name="detailType"></param>
        /// <param name="keyField"></param>
        public void DeleteMasterDetail(BaseList masterdata, Type detailType, string keyField)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            if (masterdata.Count > 0)
            {
                Type _dataType = masterdata[0].GetType();
                UpdateAllByParams(masterdata);

                string clause = "";
                PropertyInfo idpropertyInfo = _dataType.GetProperty(keyField);


                for (int i = 0; i < masterdata.Count; i++)
                {
                    BaseObject _data = masterdata[i];
                    if (_data.CurModel == DealModel.Delete)
                    {
                        object keyvalue = idpropertyInfo.GetValue(_data, null);
                        clause += "'" + keyvalue.ToString() + "',";
                    }
                }
                if (clause != "")
                {
                    ParamCollection _paramCollection = new ParamCollection();
                    _paramCollection.Clause = String.Format("({0}.{1} IN ({2}))", ObjectBLLHelper.getTypeDAL(detailType).TableAliasName, keyField, clause.Substring(0, clause.Length - 1));
                    Delete(_paramCollection, detailType);
                }

            }
            //    ts.Complete();

            //}
        }
        public void DeleteMasterDetail(BaseList masterdata, Type[] detailType, string keyField)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            Type _dataType = masterdata[0].GetType();
            UpdateAllByParams(masterdata);

            string clause = "";
            PropertyInfo idpropertyInfo = _dataType.GetProperty(keyField);
            for (int i = 0; i < masterdata.Count; i++)
            {
                BaseObject dr = masterdata[i];
                if (dr.CurModel == DealModel.Delete)
                {
                    object keyvalue = idpropertyInfo.GetValue(dr, null);
                    clause += "'" + keyvalue.ToString() + "',";
                }
            }
            if (clause != "")
            {
                for (int i = 0; i < detailType.Length; i++)
                {
                    ParamCollection _paramCollection = new ParamCollection();
                    _paramCollection.Clause = String.Format("({0}.{1} IN ({2}))", ObjectBLLHelper.getTypeDAL((Type)detailType[i]).TableAliasName, keyField, clause.Substring(0, clause.Length - 1));
                    Delete(_paramCollection, (Type)detailType[i]);
                }
            }
            // ts.Complete();
            //}
        }

        public void DeleteMasterDetail(BaseList masterdata, Type[] detailType, string keyField, BaseList[] data)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            Type _dataType = masterdata[0].GetType();
            UpdateAllByParams(masterdata);

            string clause = "";
            PropertyInfo idpropertyInfo = _dataType.GetProperty(keyField);
            for (int i = 0; i < masterdata.Count; i++)
            {
                BaseObject dr = masterdata[i];
                if (dr.CurModel == DealModel.Delete)
                {
                    object keyvalue = idpropertyInfo.GetValue(dr, null);
                    clause += "'" + keyvalue.ToString() + "',";
                }
            }
            if (clause != "")
            {
                for (int i = 0; i < detailType.Length; i++)
                {
                    ParamCollection _paramCollection = new ParamCollection();
                    _paramCollection.Clause = String.Format("({0}.{1} IN ({2}))", ObjectBLLHelper.getTypeDAL((Type)detailType[i]).TableAliasName, keyField, clause.Substring(0, clause.Length - 1));
                    Delete(_paramCollection, (Type)detailType[i]);
                }
            }
            UpdateMultiData(data);
            //    ts.Complete();
            //}
        }


        /// <summary>
        /// 删除带文件的Master-detail
        /// </summary>
        /// <param name="masterdata"></param>
        /// <param name="keyField"></param>
        /// <param name="fileType"></param>
        public void DeleteFile(BaseList masterdata, string keyField, string fileType)
        {
            if (masterdata.Count > 0)
            {
                Type _dataType = masterdata[0].GetType();
                ParamCollection _paramCollection = new ParamCollection();
                string clause = "";

                PropertyInfo idpropertyInfo = _dataType.GetProperty(keyField);

                for (int i = 0; i < masterdata.Count; i++)
                {
                    BaseObject _data = masterdata[i];
                    if (_data.CurModel == DealModel.Delete)
                    {
                        object keyvalue = idpropertyInfo.GetValue(_data, null);
                        clause += "'" + keyvalue.ToString() + "',";
                    }
                }
                //BaseList detaildata = new AppFileData();
                //if (clause != "")
                //{
                //    _paramCollection.Clause = String.Format("({0}.{1} IN ({2}) )", AppFileData.APP_FILE_TABLE, AppFileData.REF_NO_FIELD, clause.Substring(0, clause.Length - 1));
                //    _paramCollection.Clause += String.Format("AND ({0}.{1} ='{2}' )", AppFileData.APP_FILE_TABLE, AppFileData.FILE_TYPE_FIELD, fileType);
                //    detaildata = Select(_paramCollection, typeof(AppFileData));
                //    if (detaildata.Tables[0].Rows.Count > 0)
                //    {
                //        for (int i = 0; i < detaildata.Tables[0].Rows.Count; i++)
                //        {
                //            detaildata.Tables[0].Rows[i].Delete();
                //        }
                //        UpdateFile(detaildata);
                //    }
                //}
                //UpdateMultiData(new BaseList[] { masterdata, detaildata });
            }
        }

        #endregion

        #region 查询并返回强类型数据集

        public int GetCount(ParamCollection _paramCollection, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).GetCount(_paramCollection);
        }

        /// <summary>
        /// 查询满足条件的前N条记录
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <param name="topcount"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public BaseList Select(ParamCollection _paramCollection, string sort, Int16 topcount, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Select(_paramCollection, sort, topcount);
        }


        /// <summary>
        /// 查询满足条件的对话框记录
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <param name="topcount"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public BaseList SelectDialog(ParamCollection _paramCollection, string sort, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).SelectDialog(_paramCollection, sort);
        }

        /// <summary>
        /// 返回Group by语句的查询结果
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="groupby"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public BaseList SelectGroup(ParamCollection _paramCollection, string groupby, string sort, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).SelectGroup(_paramCollection, groupby, sort);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public BaseList SelectByPageIndex(ParamCollection _paramCollection, string sort, int pageIndex, int pageSize, Type dataType)
        {
            BaseList list = ObjectBLLHelper.getTypeDAL(dataType).Select(_paramCollection, sort, (pageIndex - 1) * pageSize + 1, pageIndex * pageSize);
            list.ListCount = ObjectBLLHelper.getTypeDAL(dataType).GetCount(_paramCollection);
            return list;
        }

        /// <summary>
        /// 返回所有数据
        /// </summary>
        /// <returns></returns>
        public BaseList Select(Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Select();
        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public BaseList Select(ParamCollection criteria, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Select(criteria);
        }

        /// <summary>
        /// 根据ID查询记录集
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public BaseList Select(decimal recordID, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Select(recordID);
        }

        /// <summary>
        /// 根据ID查询记录集
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public BaseList Select(decimal recordID, string sort, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Select(recordID, sort);
        }


        /// <summary>
        /// 获取满足查询条件的记录并放到记录集
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public BaseList Select(ParamCollection _paramCollection, string sort, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Select(_paramCollection, sort);
        }


        /// <summary>
        /// 根据KeyCode值查询结果集
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        public BaseList Select(object keycode, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Select(keycode);
        }

        /// <summary>
        /// 根据KeyCode值查询结果集
        /// </summary>
        /// <param name="keycode"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public BaseList Select(object keycode, string sort, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Select(keycode, sort);

        }

        /// <summary>
        /// 根据KeyCode值查询结果集
        /// </summary>
        /// <param name="keycodes"></param>
        /// <returns></returns>
        public BaseList Select(object[] keycodes, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Select(keycodes);
        }

        /// <summary>
        /// 根据KeyCode值查询结果集
        /// </summary>
        /// <param name="keycodes"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public BaseList Select(object[] keycodes, string sort, Type dataType)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Select(keycodes, sort);

        }

        #endregion 查询并返回强类型数据集

        #region CheckData

        /// <summary>
        /// 检查指定类型的Code是否存在
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CheckCode(Type dataType, object code)
        {
            return ObjectBLLHelper.getTypeDAL(dataType).Find(code);
        }



        #endregion

        #region 系统管理

        /// <summary>
        /// 返回系统编号
        /// </summary>
        /// <param name="noType"></param>
        /// <returns></returns>
        public string GetSysNo(string noType)
        {
            return SeqNoRule.getSeqNo(noType);
        }

        public string GetSysNo(string noType, int CodeLen)
        {
            return SeqNoRule.getSeqNo(noType, CodeLen);
        }



        ///// <summary>
        ///// 返回公司基本资料
        ///// </summary>
        ///// <returns></returns>
        //public BASE_COMPANY getCompany()
        //{
        //    BASE_COMPANY company = new BASE_COMPANY();

        //    //BaseList _data=ObjectBLLHelper.getTypeDAL(typeof(BaseCompanyData)).Select();
        //    //if (_data.Count > 0)
        //    //{
        //    //    DataRow currentRow = _data.Tables[0].Rows[0];
        //    //    company.COMPANY_ID = (decimal)currentRow[BaseCompanyData.COMPANY_ID_FIELD];
        //    //    company.COMPANY_CODE = currentRow[BaseCompanyData.COMPANY_CODE_FIELD].ToString();
        //    //    company.CORP_NO = currentRow[BaseCompanyData.CORP_NO_FIELD].ToString();
        //    //    company.CN_NAME = currentRow[BaseCompanyData.CN_NAME_FIELD].ToString();
        //    //    company.EN_NAME = currentRow[BaseCompanyData.EN_NAME_FIELD].ToString();
        //    //    company.CN_ADDRESS = currentRow[BaseCompanyData.CN_ADDRESS_FIELD].ToString();
        //    //    company.EN_ADDRESS = currentRow[BaseCompanyData.EN_ADDRESS_FIELD].ToString();
        //    //    company.ZIP = currentRow[BaseCompanyData.ZIP_FIELD].ToString();
        //    //    company.TEL = currentRow[BaseCompanyData.TEL_FIELD].ToString();
        //    //    company.FAX = currentRow[BaseCompanyData.FAX_FIELD].ToString();
        //    //    company.BANK = currentRow[BaseCompanyData.BANK_FIELD].ToString();
        //    //    company.ACCOUNT = currentRow[BaseCompanyData.ACCOUNT_FIELD].ToString();
        //    //    company.TAX_NO = currentRow[BaseCompanyData.TAX_NO_FIELD].ToString();
        //    //    company.REMARK = currentRow[BaseCompanyData.REMARK_FIELD].ToString();
        //    //}
        //    return company;
        //}




        /// <summary>
        /// 文件、图片的新增、修改、删除
        /// </summary>
        /// <param name="filedata"></param>
        /// <returns></returns>
        //public string UpdateFile(BaseList filedata)
        //{
        //    return FileRule.UpdateFileData(filedata);
        //}

        /// <summary>
        /// 获取文件资料
        /// </summary>
        /// <param name="refNo"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public BaseList GetFileData(string refNo, string fileType, string str)
        {
            return FileRule.GetFileData(refNo, fileType, str);
        }

        #endregion

        # region 用户权限模块

        /// <summary>
        /// 返回所有权限列表
        /// </summary>
        /// <returns></returns>
        public FunctionCollection getFunctionList(string module_type)
        {
            return SysFunctionDAL.GetFunctionList(module_type);
        }

        /// <summary>
        /// 权限导入
        /// </summary>
        /// <param name="roleData">要导入的权限列表必须指定ImportCode</param>
        /// <returns></returns>
        public bool ImportRole(BaseList roleData)
        {
            bool IsComplete = false;
            if (roleData != null)
            {

                //using (TransactionScope ts = new TransactionScope())
                //{
                for (int i = 0; i < roleData.Count; i++)
                {
                    SYS_ROLE role = (SYS_ROLE)roleData[i];
                    if (role.CurModel == DealModel.New)
                    {
                        ojbReportRule.ImportRole(role.IMPORT_CODE, role.ROLE_NO);
                        role.ID = Update(role);
                    }
                }

                //  ts.Complete();
                IsComplete = true;
                //}
            }
            return IsComplete;
        }

        /// <summary>
        /// 更新用户权限
        /// </summary>
        /// <param name="_userRow">用户行</param>
        /// <param name="_userRole">角色权限表</param>
        /// <returns></returns>
        public decimal updateUserRole(BaseObject _userRow, BaseList _userRole)
        {
            decimal _id = 0;
            //using (TransactionScope ts = new TransactionScope())
            //{

            if (_userRow != null)
            {
                _id = Update(_userRow);
            }
            if (_userRow.CurModel == DealModel.New)
            {
                foreach (SYS_USER_ROLE r in _userRole)
                {
                    r.USER_ID = _id;
                }
            }
            UpdateAllByParams(_userRole);
            //    ts.Complete();
            //}
            return _id;
        }

        /// <summary>
        /// 处理用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SYS_USER Login(HttpContext context, string userName, string password)
        {
            BaseList userList = new BaseList();
            bool isInAD = false;
            #region not in AD
            ParamCollection paraList = new ParamCollection();
            paraList.Clause = "email = @loginEmail and (email not like '%@crownbio.com%' or email is null)";
            paraList.Add(new ParamData("loginEmail", DbType.String, userName));
            userList = Select(paraList, typeof(SYS_USER));
            if (userList.Count == 0)
            {
                ParamCollection paraListCode = new ParamCollection();
                paraListCode.Clause = "USER_CODE = @loginCode and (email not like '%crownbio%' or email is null)";
                paraListCode.Add(new ParamData("loginCode", DbType.String, userName.Trim()));
                userList = Select(paraListCode, typeof(SYS_USER));
            }
            #endregion

            if (userList.Count == 0)
            {
                bool isAdAuthenticated = false;
                try
                {
                    isAdAuthenticated = ActiveDirectoryConnector.IsUserLoggedIn(userName, DEncryptHelper.Decrypt(password));
                }
                catch (ActiveDirectoryUserNotFoundException)
                {
                    // 新旧两个域都确实没有这个账号，维持原有行为：走到下面统一提示"用户不存在"。
                    isAdAuthenticated = false;
                }
                catch (Exception)
                {
                    // 密码错误、账号锁定/过期等域里能确认账号存在的具体原因，
                    // 直接提示密码不正确，不要被误判成"用户不存在"。
                    SYS_USER adPasswordErrorResult = new SYS_USER();
                    adPasswordErrorResult.ErrMsg = LanguageHelper.GetResourceText("USER_PWD") + LanguageHelper.GetResourceText("Incorrect");
                    adPasswordErrorResult.IS_Login = false;
                    return adPasswordErrorResult;
                }

                if (isAdAuthenticated)
                {
                    #region in AD
                    if (userName.IndexOf("crownbio", StringComparison.CurrentCultureIgnoreCase) < 0)
                    {
                        userName = userName + "@crownbio.com";
                    }
                    ParamCollection paraList2 = new ParamCollection();
                    paraList2.Clause = SYS_USER.EMAIL_FIELD + " = @adEmail";
                    paraList2.Add(new ParamData("adEmail", DbType.String, userName));
                    userList = Select(paraList2, typeof(SYS_USER));
                    isInAD = true;
                    #endregion
                }
            }

            SYS_USER userLogin = null;
            if (userList.Count > 0)
            {
                userLogin = (SYS_USER)userList[0];
                if (userLogin.IS_AVAILABLE == "N")
                {
                    userLogin = new SYS_USER();
                    userLogin.ErrMsg = LanguageHelper.GetResourceText("USER_NOT_AVAILABLE");
                    userLogin.IS_Login = false;
                }
                else if (!isInAD && DEncryptHelper.Decrypt(userLogin.USER_PWD) != DEncryptHelper.Decrypt(password))
                {
                    userLogin = new SYS_USER();
                    userLogin.ErrMsg = LanguageHelper.GetResourceText("USER_PWD") + LanguageHelper.GetResourceText("Incorrect");
                    userLogin.IS_Login = false;
                }
                else if ((userLogin.REMARK != null && userLogin.REMARK != "") && DateTime.Parse(userLogin.REMARK).AddDays(1) < System.DateTime.Now)
                {
                    userLogin = new SYS_USER();
                    userLogin.ErrMsg = LanguageHelper.GetResourceText("USER_trial_expired");
                    userLogin.IS_Login = false;
                }
                else
                {
                    bool sameIP = false;
                    //if (userLogin.IS_ADMIN == "N" && userLogin.ROLE_TYPE =="03")
                    //{
                    //    BaseList bl = ObjectBLLHelper.getTypeDAL(typeof(SYS_USER_LOG)).Select(userName.Trim());
                    //    if (bl.Count > 0)
                    //    {
                    //        SYS_USER_LOG ip = (SYS_USER_LOG)bl[0];
                    //        if (context.Request.UserHostAddress != ip.IP)
                    //        {
                    //            userLogin = new SYS_USER();
                    //            userLogin.ErrMsg = "You can only in the same IP next login";
                    //            userLogin.IS_Login = false;
                    //            sameIP = true;
                    //        }
                    //    }
                    //}
                    if (sameIP != true)
                    {
                        userLogin.IS_Login = true;
                        userLogin.Token = Guid.NewGuid().ToString();
                        userLogin.LoginTime = System.DateTime.Now;
                        userLogin.ErrMsg = LanguageHelper.GetResourceText("Successful login");
                        //ParamCollection _paramCollection = new ParamCollection();
                        //_paramCollection.Clause = String.Format("{0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.USER_ID = {3} ) AND SYS_WEB_MODULE.IS_AVAILABLE = 'Y' "
                        ////_paramCollection.Clause = String.Format("{0}.{1} IN ('R00001')"
                        //    , new object[] { SYS_PERM.TABLE_NAME, SYS_PERM.ROLE_NO_FIELD, SYS_USER_ROLE.TABLE_NAME, userLogin.USER_ID });
                        //userLogin.Permission = PermCollection.converToPermList(ObjectBLLHelper.getTypeDAL(typeof(SYS_PERM)).SelectGroup(_paramCollection, "  SYS_PERM.FUNCTION_ID ", "    MAX(SYS_WEB_MODULE.MODULE_CODE),MAX(SYS_FUNCTION.FUNCTION_CODE) "));
                        ParamCollection _paramCollection = new ParamCollection();
                        _paramCollection.Clause = String.Format("{0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.USER_ID = {3} ) "
                            , new object[] { SYS_PERM.TABLE_NAME, SYS_PERM.ROLE_NO_FIELD, SYS_USER_ROLE.TABLE_NAME, userLogin.USER_ID });
                        userLogin.Permission = PermCollection.converToPermList(ObjectBLLHelper.getTypeDAL(typeof(SYS_PERM)).SelectGroup(_paramCollection, "  SYS_PERM.FUNCTION_ID ", "    MAX(SYS_PERM.FUNCTION_ID) "));
                    }

                }
            }
            else
            {
                userLogin = new SYS_USER();
                userLogin.ErrMsg = LanguageHelper.GetResourceText("USER_NOT_EXIST");
                userLogin.IS_Login = false;
            }

            return userLogin;
        }


        /// <summary>
        /// 处理用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SYS_USER LoginSSO(HttpContext context, string userName, string password)
        {
            BaseList userList = new BaseList();
            bool isInAD = false;
            #region not in AD
            ParamCollection paraList = new ParamCollection();
            paraList.Clause = "email = @loginEmail and (email not like '%@crownbio.com%' or email is null)";
            paraList.Add(new ParamData("loginEmail", DbType.String, userName));
            userList = Select(paraList, typeof(SYS_USER));
            if (userList.Count == 0)
            {
                ParamCollection paraListCode = new ParamCollection();
                paraListCode.Clause = "USER_CODE = @loginCode and (email not like '%crownbio%' or email is null)";
                paraListCode.Add(new ParamData("loginCode", DbType.String, userName.Trim()));
                userList = Select(paraListCode, typeof(SYS_USER));
            }
            #endregion

            if (userList.Count == 0)
            {
                //if (ActiveDirectoryConnector.IsUserLoggedIn(userName, DEncryptHelper.Decrypt(password)))
                //{
                    #region in AD
                    if (userName.IndexOf("crownbio", StringComparison.CurrentCultureIgnoreCase) < 0)
                    {
                        userName = userName + "@crownbio.com";
                    }
                    ParamCollection paraList2 = new ParamCollection();
                    paraList2.Clause = SYS_USER.EMAIL_FIELD + " = @adEmail";
                    paraList2.Add(new ParamData("adEmail", DbType.String, userName));
                    userList = Select(paraList2, typeof(SYS_USER));
                    isInAD = true;
                    #endregion
                //}
            }

            SYS_USER userLogin = null;
            if (userList.Count > 0)
            {
                userLogin = (SYS_USER)userList[0];
                if (userLogin.IS_AVAILABLE == "N")
                {
                    userLogin = new SYS_USER();
                    userLogin.ErrMsg = LanguageHelper.GetResourceText("USER_NOT_AVAILABLE");
                    userLogin.IS_Login = false;
                }
                else if (!isInAD && DEncryptHelper.Decrypt(userLogin.USER_PWD) != DEncryptHelper.Decrypt(password))
                {
                    userLogin = new SYS_USER();
                    userLogin.ErrMsg = LanguageHelper.GetResourceText("USER_PWD") + LanguageHelper.GetResourceText("Incorrect");
                    userLogin.IS_Login = false;
                }
                else if ((userLogin.REMARK != null && userLogin.REMARK != "") && DateTime.Parse(userLogin.REMARK).AddDays(1) < System.DateTime.Now)
                {
                    userLogin = new SYS_USER();
                    userLogin.ErrMsg = LanguageHelper.GetResourceText("USER_trial_expired");
                    userLogin.IS_Login = false;
                }
                else
                {
                    bool sameIP = false;
                    //if (userLogin.IS_ADMIN == "N" && userLogin.ROLE_TYPE =="03")
                    //{
                    //    BaseList bl = ObjectBLLHelper.getTypeDAL(typeof(SYS_USER_LOG)).Select(userName.Trim());
                    //    if (bl.Count > 0)
                    //    {
                    //        SYS_USER_LOG ip = (SYS_USER_LOG)bl[0];
                    //        if (context.Request.UserHostAddress != ip.IP)
                    //        {
                    //            userLogin = new SYS_USER();
                    //            userLogin.ErrMsg = "You can only in the same IP next login";
                    //            userLogin.IS_Login = false;
                    //            sameIP = true;
                    //        }
                    //    }
                    //}
                    if (sameIP != true)
                    {
                        userLogin.IS_Login = true;
                        userLogin.Token = Guid.NewGuid().ToString();
                        userLogin.LoginTime = System.DateTime.Now;
                        userLogin.ErrMsg = LanguageHelper.GetResourceText("Successful login");
                        //ParamCollection _paramCollection = new ParamCollection();
                        //_paramCollection.Clause = String.Format("{0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.USER_ID = {3} ) AND SYS_WEB_MODULE.IS_AVAILABLE = 'Y' "
                        ////_paramCollection.Clause = String.Format("{0}.{1} IN ('R00001')"
                        //    , new object[] { SYS_PERM.TABLE_NAME, SYS_PERM.ROLE_NO_FIELD, SYS_USER_ROLE.TABLE_NAME, userLogin.USER_ID });
                        //userLogin.Permission = PermCollection.converToPermList(ObjectBLLHelper.getTypeDAL(typeof(SYS_PERM)).SelectGroup(_paramCollection, "  SYS_PERM.FUNCTION_ID ", "    MAX(SYS_WEB_MODULE.MODULE_CODE),MAX(SYS_FUNCTION.FUNCTION_CODE) "));
                        ParamCollection _paramCollection = new ParamCollection();
                        _paramCollection.Clause = String.Format("{0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.USER_ID = {3} ) "
                            , new object[] { SYS_PERM.TABLE_NAME, SYS_PERM.ROLE_NO_FIELD, SYS_USER_ROLE.TABLE_NAME, userLogin.USER_ID });
                        userLogin.Permission = PermCollection.converToPermList(ObjectBLLHelper.getTypeDAL(typeof(SYS_PERM)).SelectGroup(_paramCollection, "  SYS_PERM.FUNCTION_ID ", "    MAX(SYS_PERM.FUNCTION_ID) "));
                    }

                }
            }
            else
            {
                userLogin = new SYS_USER();
                userLogin.ErrMsg = LanguageHelper.GetResourceText("USER_NOT_EXIST");
                userLogin.IS_Login = false;
            }

            return userLogin;
        }


        /// <summary>
        /// 处理前台用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public APP_USR LoginA(string userName, string password)
        {
            BaseList userList = ObjectBLLHelper.getTypeDAL(typeof(APP_USR)).Select(userName.Trim());
            APP_USR userLogin = null;
            if (userList.Count > 0)
            {
                userLogin = (APP_USR)userList[0];
                if (userLogin.USR_STATUS == 1)
                {
                    userLogin = new APP_USR();
                    userLogin.ErrMsg = LanguageHelper.GetResourceText("USER_NOT_AVAILABLE");
                    userLogin.IS_Login = false;
                }
                else if (DEncryptHelper.Decrypt(userLogin.USR_PASSWORD) != DEncryptHelper.Decrypt(password))
                {
                    userLogin = new APP_USR();
                    userLogin.ErrMsg = LanguageHelper.GetResourceText("USR_PASSWORD") + LanguageHelper.GetResourceText("Incorrect");
                    userLogin.IS_Login = false;
                }
                else
                {
                    userLogin.IS_Login = true;
                    userLogin.Token = Guid.NewGuid().ToString();
                }
            }
            else
            {
                userLogin = new APP_USR();
                userLogin.ErrMsg = LanguageHelper.GetResourceText("USER_NOT_EXIST");
                userLogin.IS_Login = false;
            }
            return userLogin;
        }

        //public SYS_USER fillUserPerm(SYS_USER userLogin)
        //{
        //    BaseList u = SysOrgan.GetUserListbyUserId(userLogin.USER_ID);
        //    if (u.Count > 0)
        //    {
        //        USR Act = u[0] as USR;
        //        userLogin.USER_ID = Act.USER_ID;
        //        userLogin.USER_NAME = Act.USR_NAME;
        //        userLogin.PID = Act.USR_DEP_ID;
        //    }

        //    ParamCollection _paramCollection = new ParamCollection();
        //    _paramCollection.Clause = String.Format("{0}.{1} IN (SELECT {2}.ROLE_NO FROM {2} WHERE {2}.USER_ID = {3} ) AND SYS_WEB_MODULE.IS_AVAILABLE = 'Y' "
        //        // _paramCollection.Clause = String.Format("{0}.{1} IN ('R00001')"
        //        , new object[] { SYS_PERM.TABLE_NAME, SYS_PERM.ROLE_NO_FIELD, SYS_USER_ROLE.TABLE_NAME, userLogin.USER_ID });
        //    userLogin.Permission = PermCollection.converToPermList(ObjectBLLHelper.getTypeDAL(typeof(SYS_PERM)).SelectGroup(_paramCollection, "  SYS_PERM.FUNCTION_ID ", "   MAX(SYS_WEB_MODULE.MODULE_CODE),MAX(SYS_FUNCTION.FUNCTION_CODE) "));
        //    return userLogin;
        //}


        /// <summary>
        /// 修改当前登录用户的帐户密码
        /// </summary>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public string ChangePassword(string newPassword)
        {
            decimal USER_ID = CacheHelper.getCurrentUser().USER_ID;
            string errMsg = "";
            if (USER_ID == -1)
            {
                errMsg = LanguageHelper.GetResourceText("NotLogin");
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update SYS_USER set ");
                strSql.Append("USER_PWD=@USER_PWD");
                strSql.Append(" where USER_ID=@USER_ID");
                SqlParameter[] parameters = {
                    new SqlParameter("@USER_PWD", SqlDbType.NVarChar),
                    new SqlParameter("@USER_ID", SqlDbType.Decimal)};
                parameters[0].Value = newPassword;
                parameters[1].Value = USER_ID;
                if (DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0)
                {
                    errMsg = LanguageHelper.GetResourceText("PasswordChange") + LanguageHelper.GetResourceText("Success") + "\r\n" + LanguageHelper.GetResourceText("RestartValid");
                }
                else
                {
                    errMsg = LanguageHelper.GetResourceText("PasswordChange") + LanguageHelper.GetResourceText("Failed");
                }
            }
            return errMsg;
        }

        public decimal getSeqByProType(string proCode, string fileType)
        {
            return SeqNoRule.getFileSeq(proCode, fileType);
        }

        ///// <summary>
        ///// 获取组织机构列表
        ///// </summary>
        ///// <returns></returns>z
        //public List<DEP> getOrganlist()
        //{
        //    return SysOrgan.GetOrganList();
        //}
        //public BaseList getUserList()
        //{
        //    return SysOrgan.GetUserList();
        //}

        //public BaseList getUserListByUids(string str)
        //{
        //    if (str.Trim() != string.Empty)
        //    {
        //        str = str.Substring(1, str.Length - 2);
        //        str = str.Replace(';', ',');
        //        return SysOrgan.GetUserList(str);
        //    }
        //    else
        //    {
        //        return new BaseList();
        //    }
        //}

        //public BaseList getUserList1()
        //{
        //    return SysOrgan.GetUserList1();
        //}

        //public List<USER_DEP> getDepUser(string[] ids)
        //{
        //    List<USER_DEP> _depUserList = new List<USER_DEP>();
        //    List<DEP> _DepList = SysOrgan.GetOrganList();
        //    List<USR> _UserList = null;
        //    if (ids.Length > 0)
        //    {

        //    }
        //    else
        //    {
        //        _UserList = SysOrgan.GetUserList().ConvertAll<USR>(USR.Convert);
        //    }
        //    if (_DepList.Count > 0)
        //    {
        //        USER_DEP depRow = null;
        //        for (int i = 0; i < _DepList.Count; i++)
        //        {
        //            depRow = new USER_DEP();
        //            depRow.DEP_ID = _DepList[i].DEP_ID;
        //            depRow.DEP_NAME = _DepList[i].DEP_NAME;
        //            depRow.DEP_PARENT_ID = _DepList[i].DEP_PARENT_ID;
        //            depRow.DEP_ORDER = _DepList[i].DEP_ORDER;
        //            _depUserList.Add(depRow);
        //            List<USR> userList = _UserList.FindAll(delegate(USR _u) { return _u.USR_DEP_ID == _DepList[i].DEP_ID; });
        //            if (userList.Count > 0)
        //            {
        //                foreach (USR _user in userList)
        //                {
        //                    depRow = new USER_DEP();
        //                    depRow.DEP_ID = _user.USER_ID + 10000;
        //                    depRow.DEP_NAME = _user.USR_NAME;
        //                    depRow.DEP_PARENT_ID = _DepList[i].DEP_ID;
        //                    depRow.DEP_ORDER = _user.USR_ORDER;
        //                    depRow.USER_ROLE = _user.USR_DESCRIPTION;
        //                    depRow.PID = _user.USER_ID;
        //                    _depUserList.Add(depRow);
        //                }
        //            }
        //        }
        //    }
        //    return _depUserList;
        //}


        #endregion

        #region 文档编制及打印
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="strSql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string strSql, ref string strError)
        {
            object value = null;
            try
            {
                value = DbHelperSQL.GetSingle(strSql, ref strError);
            }
            catch (Exception ex)
            {
            }
            return value;
        }



        //public DataTable getExelist(string proCode)
        //{
        //    return ojbReportRule.getExeList(proCode);
        //}
        //public DataTable getExeplist(string proCode)
        //{
        //    return ojbReportRule.getExepList(proCode);
        //}
        //public DataTable getStepList(string proCode)
        //{
        //    return ojbReportRule.getStepList(proCode);
        //}
        //public DataTable getRevList(string exe_no)
        //{
        //    return ojbReportRule.getRevList(exe_no);
        //}

        #endregion

        #region 项目变更

        /// <summary>
        /// 项目变更
        /// </summary>
        /// <param name="_row">变更信息</param>
        /// <param name="list">要保留或者带到新项目的数据</param>
        /// <returns></returns>
        //public decimal UpDataProChange(BaseObject _row,BaseList list,BaseList appFile)
        //{
        //    decimal id = -1;
        //    if (_row != null)
        //    {

        //        id = Update(_row);
        //        PRO_CHANGE change = _row as PRO_CHANGE;
        //        BaseList changeList = new BaseList();
        //        List<PRO_CHANGE_LIST>  changeL = list.ConvertAll<PRO_CHANGE_LIST>(PRO_CHANGE_LIST.Convert);
        //        if (change.CHANGE_TYPE == "原项目更改")
        //        {
        //            if (changeL.Count > 0)
        //            {
        //                _changType = ChangeType.项目信息; //变更类型
        //                PRO_CHANGE_LIST pro = changeL.Find(findChange);//项目信息
        //                if (pro != null)
        //                {
        //                    if (pro.IS_SELECTED) //如果用户选择保留
        //                    {
        //                        BASE_PROJECT proRow = pro.LIST_ROW as BASE_PROJECT;
        //                        if (proRow != null)
        //                        {
        //                            proRow.CurModel = DealModel.Modify;
        //                            proRow.PROJECT_STATUS = "变更";
        //                            proRow.PROJECT_NAME += change.CHANGE_TYPE + "_";
        //                            proRow.CHANGE_VERSION = change.CHANGE_VERSION;
        //                            Update(proRow);
        //                        }
        //                    }
        //                }
        //                _changType = ChangeType.质量计划书; 
        //                PRO_CHANGE_LIST proQp = changeL.Find(findChange);//质量计划书(带审批)
        //                if (proQp != null)
        //                { 
        //                    PRO_QUALITY_PLAN qpRow = pro.LIST_ROW as PRO_QUALITY_PLAN;
        //                    if (proQp.IS_SELECTED)//如果用户选择保留
        //                    {

        //                    }
        //                    else //如果不保留
        //                    {
        //                        if (qpRow != null)
        //                        {
        //                            //删除审批相关
        //                            DelApproval(qpRow.PLAN_NO, qpRow);
        //                        }
        //                    }
        //                }
        //                _changType = ChangeType.工作计划书;
        //                PRO_CHANGE_LIST proQp0 = changeL.Find(findChange);//工作计划书(带审批)
        //                if (proQp0 != null)
        //                {
        //                    PRO_WORK_PLAN qpRow0 = pro.LIST_ROW as PRO_WORK_PLAN;
        //                    if (proQp0.IS_SELECTED)//如果用户选择保留
        //                    {

        //                    }
        //                    else //如果不保留
        //                    {
        //                        if (qpRow0 != null)
        //                        {
        //                            //删除审批相关
        //                            DelApproval(qpRow0.PLAN_NO, qpRow0);
        //                        }
        //                    }
        //                }
        //                _changType = ChangeType.评估会;
        //                PRO_CHANGE_LIST proPm = changeL.Find(findChange);//评估会(带审批)
        //                if (proPm != null)
        //                {
        //                    PRO_MEETING qpmRow = pro.LIST_ROW as PRO_MEETING;
        //                    if (proPm.IS_SELECTED)//如果用户选择保留
        //                    {

        //                    }
        //                    else //如果不保留
        //                    {
        //                        if (qpmRow != null)
        //                        {
        //                            //删除审批相关
        //                            DelApproval(qpmRow.MEETING_CODE, qpmRow);
        //                        }
        //                    }
        //                }
        //                _changType = ChangeType.项目文档明细; 
        //                List<PRO_CHANGE_LIST> proDoc = changeL.FindAll(findChange);//项目文档(带审批)
        //                if (proDoc.Count > 0)
        //                {
        //                    foreach (PRO_CHANGE_LIST doc in proDoc)
        //                    {
        //                        DCM_DOCUMENT docRow = doc.LIST_ROW as DCM_DOCUMENT;
        //                        if (doc.IS_SELECTED)//如果用户选择保留
        //                        {

        //                        }
        //                        else //如果不保留
        //                        {
        //                            if (docRow != null)
        //                            {
        //                                //删除审批相关
        //                                DelApproval(docRow.DOCUMENT_CODE_R, docRow);
        //                            }
        //                        }
        //                    }
        //                }
        //                _changType = ChangeType.踏勘记录;
        //                List<PRO_CHANGE_LIST> proRecon = changeL.FindAll(findChange);//踏勘记录
        //                if (proRecon.Count > 0)
        //                {
        //                    proRecon.ForEach(UpdataChangeDetail);//更新或删除选择保留数据
        //                }

        //                _changType = ChangeType.评估会议程;
        //                List<PRO_CHANGE_LIST> proPmd = changeL.FindAll(findChange);//评估会议程
        //                if (proPmd.Count > 0)
        //                {
        //                    proPmd.ForEach(UpdataChangeDetail);//更新或删除选择保留数据
        //                }

        //                _changType = ChangeType.顾客提供产品清单明细;
        //                List<PRO_CHANGE_LIST> proVide = changeL.FindAll(findChange);//顾客提供产品清单明细
        //                if (proVide.Count > 0)
        //                {
        //                    proVide.ForEach(UpdataChangeDetail);//更新或删除选择保留数据
        //                }
        //                _changType = ChangeType.内部外部接口记录表明细;
        //                List<PRO_CHANGE_LIST> proInt = changeL.FindAll(findChange);//内部外部接口记录表明细
        //                if (proInt.Count > 0)
        //                {
        //                    proInt.ForEach(UpdataChangeDetail);//更新或删除选择保留数据
        //                }
        //                _changType = ChangeType.附件列表;
        //                List<PRO_CHANGE_LIST> proFile = changeL.FindAll(findChange);//附件
        //                if (proFile.Count > 0)
        //                {
        //                    proFile.ForEach(UpdataChangeDetail);//更新或删除选择保留数据
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (changeL.Count > 0)
        //            {
        //                string _procode = GetSysNo("PRO");
        //                _changType = ChangeType.项目信息; //变更类型
        //                PRO_CHANGE_LIST pro = changeL.Find(findChange);//项目信息
        //                if (pro != null)
        //                {
        //                    if (pro.IS_SELECTED) //如果用户选择保留
        //                    {
        //                        BASE_PROJECT proRow = pro.LIST_ROW as BASE_PROJECT;
        //                        if (proRow != null)
        //                        {
        //                            proRow.CurModel = DealModel.Modify;
        //                            proRow.PROJECT_STATUS = "变更";
        //                            proRow.CHANGE_VERSION = change.CHANGE_VERSION;
        //                            Update(proRow);

        //                            proRow.CurModel = DealModel.New;
        //                            proRow.PROJECT_CODE = _procode;
        //                            proRow.PROJECT_NAME += change.CHANGE_TYPE + "_";
        //                            proRow.PROJECT_STATUS = "已下达";
        //                            proRow.CHANGE_VERSION = 0;
        //                            Update(proRow);
        //                        }
        //                    }
        //                }
        //                _changType = ChangeType.质量计划书;
        //                PRO_CHANGE_LIST proQp = changeL.Find(findChange);//质量计划书(带审批)
        //                if (proQp != null)
        //                {
        //                    PRO_QUALITY_PLAN qpRow = proQp.LIST_ROW as PRO_QUALITY_PLAN;
        //                    if (proQp.IS_SELECTED)//如果用户选择保留
        //                    {
        //                        qpRow.CurModel = DealModel.New;
        //                        qpRow.PROJECT_CODE = _procode;
        //                        qpRow.PLAN_NO = GetSysNo("QP");
        //                        Update(qpRow);
        //                    }
        //                }
        //                _changType = ChangeType.工作计划书;
        //                PRO_CHANGE_LIST proQp0 = changeL.Find(findChange);//工作计划书(带审批)
        //                if (proQp0 != null)
        //                {
        //                    PRO_WORK_PLAN qpRow0 = proQp0.LIST_ROW as PRO_WORK_PLAN;
        //                    if (proQp0.IS_SELECTED)//如果用户选择保留
        //                    {
        //                        qpRow0.CurModel = DealModel.New;
        //                        qpRow0.PROJECT_CODE = _procode;
        //                        qpRow0.PLAN_NO = GetSysNo("QP");
        //                        Update(qpRow0);
        //                    }
        //                }
        //                _changType = ChangeType.评估会;
        //                PRO_CHANGE_LIST proPm = changeL.Find(findChange);//评估会(带审批)
        //                if (proQp != null)
        //                {
        //                    PRO_MEETING pmRow = proPm.LIST_ROW as PRO_MEETING;
        //                    if (proPm.IS_SELECTED)//如果用户选择保留
        //                    {
        //                        pmRow.CurModel = DealModel.New;
        //                        pmRow.PROJECT_CODE = _procode;
        //                        pmRow.MEETING_CODE = GetSysNo("MC");
        //                        Update(pmRow);
        //                    }
        //                }
        //                _changType = ChangeType.项目文档明细;
        //                List<PRO_CHANGE_LIST> proDoc = changeL.FindAll(findChange);//项目文档(带审批)
        //                if (proDoc.Count > 0)
        //                {
        //                    foreach (PRO_CHANGE_LIST doc in proDoc)
        //                    {
        //                        DCM_DOCUMENT docRow = doc.LIST_ROW as DCM_DOCUMENT;
        //                        if (doc.IS_SELECTED)//如果用户选择保留
        //                        {
        //                            docRow.CurModel = DealModel.New;
        //                            docRow.PROJECT_CODE = _procode;
        //                            docRow.DOCUMENT_CODE_R = GetSysNo("DCR");
        //                            Update(docRow);
        //                        }
        //                    }
        //                }
        //                _changType = ChangeType.踏勘记录;
        //                List<PRO_CHANGE_LIST> proRecon = changeL.FindAll(findChange);//踏勘记录
        //                if (proRecon.Count > 0)
        //                {
        //                    foreach (PRO_CHANGE_LIST doc in proRecon)
        //                    {
        //                        PRO_PLAN_RECON docRow = doc.LIST_ROW as PRO_PLAN_RECON;
        //                        if (doc.IS_SELECTED)//如果用户选择保留
        //                        {
        //                            docRow.CurModel = DealModel.New;
        //                            docRow.PROJECT_CODE = _procode;
        //                            docRow.RECON_NO = GetSysNo("RN");
        //                            Update(docRow);
        //                        }
        //                    }

        //                    //proRecon.ForEach(UpdataChangeDetail);//更新或删除选择保留数据
        //                }

        //                _changType = ChangeType.评估会议程;
        //                List<PRO_CHANGE_LIST> proPmd = changeL.FindAll(findChange);//评估会议程
        //                if (proPmd.Count > 0)
        //                {
        //                    foreach (PRO_CHANGE_LIST doc in proPmd)
        //                    {
        //                        PRO_MEETING_D docRow = doc.LIST_ROW as PRO_MEETING_D;
        //                        if (doc.IS_SELECTED)//如果用户选择保留
        //                        {
        //                            docRow.CurModel = DealModel.New;
        //                            docRow.PROJECT_CODE = _procode;
        //                            Update(docRow);
        //                        }
        //                    }

        //                    //proRecon.ForEach(UpdataChangeDetail);//更新或删除选择保留数据
        //                }

        //                _changType = ChangeType.顾客提供产品清单明细;
        //                List<PRO_CHANGE_LIST> proVide = changeL.FindAll(findChange);//顾客提供产品清单明细
        //                if (proVide.Count > 0)
        //                {
        //                    foreach (PRO_CHANGE_LIST doc in proVide)
        //                    {
        //                        PRO_CUSTOMER_PROVIDE docRow = doc.LIST_ROW as PRO_CUSTOMER_PROVIDE;
        //                        if (doc.IS_SELECTED)//如果用户选择保留
        //                        {
        //                            docRow.CurModel = DealModel.New;
        //                            docRow.PROJECT_CODE = _procode;
        //                            Update(docRow);
        //                        }
        //                    }
        //                    //proVide.ForEach(UpdataChangeDetail);//更新或删除选择保留数据
        //                }
        //                _changType = ChangeType.内部外部接口记录表明细;
        //                List<PRO_CHANGE_LIST> proInt = changeL.FindAll(findChange);//内部外部接口记录表明细
        //                if (proInt.Count > 0)
        //                {
        //                    foreach (PRO_CHANGE_LIST doc in proInt)
        //                    {
        //                        PRO_INTERFACE docRow = doc.LIST_ROW as PRO_INTERFACE;
        //                        if (doc.IS_SELECTED)//如果用户选择保留
        //                        {
        //                            docRow.CurModel = DealModel.New;
        //                            docRow.PROJECT_CODE = _procode;
        //                            Update(docRow);
        //                        }
        //                    }
        //                    //proInt.ForEach(UpdataChangeDetail);//更新或删除选择保留数据
        //                }
        //                _changType = ChangeType.附件列表;
        //                List<PRO_CHANGE_LIST> proFile = changeL.FindAll(findChange);//附件
        //                if (proFile.Count > 0)
        //                {
        //                    foreach (PRO_CHANGE_LIST doc in proFile)
        //                    {
        //                        APP_FILE docRow = doc.LIST_ROW as APP_FILE;
        //                        if (doc.IS_SELECTED)//如果用户选择保留
        //                        {
        //                            docRow.CurModel = DealModel.New;
        //                            docRow.PROJECT_CODE = _procode;
        //                            docRow.DOC_NO = _procode;
        //                            Update(docRow);
        //                        }
        //                    }
        //                    //proFile.ForEach(UpdataChangeDetail);//更新或删除选择保留数据
        //                }
        //            }
        //        }
        //    }
        //    return id;
        //}
        //private ChangeType _changType = ChangeType.空; //查找用类型变量

        /// <summary>
        /// 查找方法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        //private bool findChange(PRO_CHANGE_LIST s)
        //{
        //    return s.LIST_TYPE == _changType;
        //}
        /// <summary>
        /// 更新变更明细(非审批,在现有基础变更)
        /// </summary>
        /// <param name="s"></param>
        //private void UpdataChangeDetail(PRO_CHANGE_LIST s)
        //{
        //    if (!s.IS_SELECTED) //如果没有选择保留
        //    {
        //        Delete(s.LIST_ROW);
        //    }
        //}

        /// <summary>
        /// 删除审批记录
        /// </summary>
        /// <param name="_WorkNo">工作编号</param>
        /// <param name="_MainRow">相关记录行</param>
        //public void DelApproval(string _WorkNo,BaseObject _MainRow)
        //{
        //    if (_MainRow != null)
        //    {
        //        Delete(_MainRow);
        //        ojbReportRule.DelApproVal(_WorkNo);
        //    }
        //}

        //public void CopyFile(BaseObject row, BaseList list, BaseList ArcData, string procode)
        //{
        //    Update(row);
        //    UpdateByParams(list);
        //    FileRule.CopyFile(ArcData,procode);
        //}
        #endregion

        #region 自动短信\EAMIL

        /// <summary>
        /// 查找并且验证待发消息以及消息相关可发手机号、Email
        /// </summary>
        /// <param name="_pc"></param>
        /// <returns></returns>
        //public List<MSG_LIST> searchMsgInfo(ParamCollection _pc)
        //{
        //    List<MSG_LIST> msgList = ojbReportRule.getMsg().ConvertAll<MSG_LIST>(MSG_LIST.Convert);

        //    List<SYS_USER> user = SysOrgan.GetUserList1().ConvertAll<SYS_USER>(SYS_USER.Convert);
        //    if (msgList.Count > 0)
        //    {
        //        foreach (MSG_LIST msg in msgList)
        //        {
        //            if (msg.USER_LIST != string.Empty)
        //            {
        //                string[] _User = msg.USER_LIST.Split(new char[] { ';' });
        //                foreach (string uid in _User)
        //                {
        //                    if (RegHelper.IsDecimal(uid))
        //                    {
        //                        _uid = decimal.Parse( uid);
        //                        SYS_USER _user = user.Find(findUser);
        //                        if (_user != null)
        //                        {
        //                            if (_user.USR_MOBILE != string.Empty && msg.IS_MSG == "Y")
        //                            {
        //                                msg.SEND_NO.Add(_user.USR_MOBILE);
        //                            }
        //                            if (_user.USR_HOME_EMAIL != string.Empty && msg.IS_MAIL == "Y")
        //                            {
        //                                msg.SEND_EMAIL.Add(_user.USR_HOME_EMAIL);
        //                            }

        //                        }
        //                    }
        //                }
        //                if (msg.IS_GSM == "Y")
        //                {
        //                    string[] strU = msg.USER_LIST.Split(new char[] { ';' });
        //                    int length = strU.Length;
        //                    if (strU.Length > 2)
        //                    {
        //                        length = strU.Length - 2;
        //                    }
        //                    int[] obj = new int[length];
        //                    int index = 0;
        //                    for (int i = 0; i < strU.Length; i++)
        //                    {
        //                        if (RegHelper.IsDecimal(strU[i]))
        //                        {
        //                            index++;
        //                            obj.SetValue(int.Parse(strU[i]), index - 1);
        //                        }
        //                    }
        //                    msg.SEND_USER = obj;
        //                }

        //            }
        //        }
        //    }
        //    return msgList;
        //}
        private decimal _uid = -1;
        /// <summary>
        /// 查找用户信息
        /// </summary>
        /// <param name="_u"></param>
        /// <returns></returns>
        private bool findUser(SYS_USER _u)
        {
            return _u.USER_ID == _uid;
        }

        /// <summary>
        /// 发送消息后更新标记
        /// </summary>
        /// <param name="list"></param>
        //public void updateSendFlag(List<MSG_LIST> list)
        //{
        //    if (list.Count > 0)
        //    {
        //        foreach (MSG_LIST msg in list)
        //        {
        //            ojbReportRule.UpdateMsgList(msg);
        //        }
        //    }
        //}
        #endregion
    }
}
