using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Crownbio.Model;
using Crownbio.DAL;
using Crownbio.Language;
using Crownbio.Common;
using Crownbio.Utility;
using System.Web.UI.WebControls;
using System.Transactions;

namespace Crownbio.BLL
{
    public class FileRule
    {
        public static string PATH = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];


        public static BaseList GetFileData(string refNo, string fileType, string str)
        {
            ParamCollection paraList = new ParamCollection();
            paraList.Clause = String.Format(" ({0}.{1} = @{1}) AND ({0}.{2}=@{2}) ", APP_FILE.TABLE_NAME, APP_FILE.DOC_NO_FIELD, APP_FILE.FILE_TYPE_FIELD);
            paraList.Add(new ParamData(APP_FILE.DOC_NO_FIELD, DbType.String, refNo));
            paraList.Add(new ParamData(APP_FILE.FILE_TYPE_FIELD, DbType.String, fileType));
            BaseList dataFile = ObjectBLLHelper.getTypeDAL(typeof(APP_FILE)).Select(paraList);

            return dataFile;

        }

        public static void DelFile(BaseList _delData)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                foreach (APP_FILE dr in _delData)
                {
                    File.Delete(PATH + dr.FILE_PATH);
                }
                ObjectBLLHelper.getTypeDAL(typeof(APP_FILE)).Delete(_delData);
                ts.Complete();
            }
        }

        private static string getFileName(string oldName)
        {
            FileInfo newFile = new FileInfo(oldName);
            string c1 = Path.GetExtension(oldName);
            if (newFile.Exists)
            {
                string newName = PATH + new ObjectBLL().GetSysNo("file") + c1;
                return getFileName(newName);
            }
            else
            {
                return oldName;
            }
        }

        //public static void CopyFile(BaseList ArcData, string code)
        //{
        //    int a = 0;

        //    BaseList filedata = new ObjectBLL().Select(typeof(APP_FILE));
        //    foreach (PRO_ARC_D dr in ArcData)
        //    {

        //        if (dr.URL != "")
        //        {
        //            string c1 = Path.GetExtension(dr.URL);
        //            string url = dr.URL;
        //            if (c1 != ".PDF")
        //            {
        //                url = dr.URL;
        //            }

        //            string name = new ObjectBLL().GetSysNo("file") + c1;
        //            FileInfo d1 = new FileInfo(url);
        //            if (d1.Exists)
        //            {

        //                d1.CopyTo(getFileName(PATH + name));

        //                a++;
        //                APP_FILE currentRow = new APP_FILE(DealModel.New);
        //                currentRow.DOC_NO = new ObjectBLL().GetSysNo("COPY");
        //                currentRow.PROJECT_CODE = code;
        //                currentRow.SEQ_NO = a;
        //                currentRow.FILE_TYPE = "X701";
        //                currentRow.FILE_NAME = "¹éµµÎÄ¼þ" + currentRow.SEQ_NO;
        //                currentRow.FILE_PATH = name;
        //                currentRow.REMARK = a.ToString();
        //                if (currentRow.CurModel == DealModel.New)
        //                {
        //                    filedata.Add(currentRow);
        //                }

        //                dr.CurModel = DealModel.Modify;
        //                dr.DOC_NO = currentRow.DOC_NO;

        //            }
        //        }
        //    }
        //    new ObjectBLL().UpdateMultiData(new BaseList[] { filedata, ArcData });
        //}

    }
}
