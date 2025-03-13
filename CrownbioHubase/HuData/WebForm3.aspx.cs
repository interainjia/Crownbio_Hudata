using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Cells;
using Crownbio.BLL;
using Crownbio.Common;
using Crownbio.Model;
namespace PDXmodelBase.HuData
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //FileUpload1.PostedFile
            Workbook book = new Workbook("C:\\LiJun\\项目文件\\冠科新项目\\Crownbio_HuData\\CrownbioHubase\\File\\RNAseq.xlsx");
            Worksheet sheet = book.Worksheets[0];

            Cells cells = sheet.Cells;

            ObjectBLL bll = new ObjectBLL();
            BaseList data = bll.Select(typeof(PDXMODEL_INFO));
            List<PDXMODEL_INFO> all = data.ConvertAll<PDXMODEL_INFO>(PDXMODEL_INFO.Convert);

            for (int i = 0; i < cells.MaxDataRow + 1; i++)
            {
              
                PDXMODEL_INFO row = all.Find(delegate (PDXMODEL_INFO perm) { return perm.SQ_NUMBER == cells[i,0].Value.ToString().TrimStart('0'); });
                if (row != null)
                {
                    row.CurModel = DealModel.Modify;
                    row.IN_HUBA = cells[i,1].Value.ToString();
                    bll.Update(row);
                    
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //FileUpload1.PostedFile
            Workbook book = new Workbook("C:\\LiJun\\项目文件\\冠科新项目\\Crownbio_HuData\\CrownbioHubase\\File\\Exome.xlsx");
            Worksheet sheet = book.Worksheets[0];

            Cells cells = sheet.Cells;

            ObjectBLL bll = new ObjectBLL();
            BaseList data = bll.Select(typeof(PDXMODEL_INFO));
            List<PDXMODEL_INFO> all = data.ConvertAll<PDXMODEL_INFO>(PDXMODEL_INFO.Convert);

            for (int i = 0; i < cells.MaxDataRow + 1; i++)
            {

                PDXMODEL_INFO row = all.Find(delegate (PDXMODEL_INFO perm) { return perm.SQ_NUMBER == cells[i, 0].Value.ToString().TrimStart('0'); });
                if (row != null)
                {
                    row.CurModel = DealModel.Modify;
                    row.EXOMESEQ = cells[i, 1].Value.ToString();
                    bll.Update(row);

                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //FileUpload1.PostedFile
            Workbook book = new Workbook("C:\\LiJun\\项目文件\\冠科新项目\\Crownbio_HuData\\CrownbioHubase\\File\\上传Hudata.xlsx");
            Worksheet sheet = book.Worksheets[0];

            Cells cells = sheet.Cells;

            ObjectBLL bll = new ObjectBLL();
            BaseList data = bll.Select(typeof(PDXMODEL_INFO));
            List<PDXMODEL_INFO> all = data.ConvertAll<PDXMODEL_INFO>(PDXMODEL_INFO.Convert);
            int count = 0;
            for (int i = 1; i < cells.MaxDataRow + 1; i++)
            {
                PDXMODEL_INFO row = all.Find(delegate (PDXMODEL_INFO perm) { return perm.SQ_NUMBER.TrimStart('0') == cells[i, 0].Value.ToString().TrimStart('0'); });
                if (row != null)
                {
                    count++;
                    row.CurModel = DealModel.Modify;
                    //第一批修改
                    //row.SOURCE_ID = cells[i, 5].Value is null ? "" : cells[i, 5].Value.ToString().Trim();
                    //row.SOURCE_NOTE = cells[i, 6].Value is null ? "" : cells[i, 6].Value.ToString().Trim();
                    //row.PDX_QC = cells[i, 7].Value is null ? "" : cells[i, 7].Value.ToString().Trim();
                    //第二批修改
                    row.ORIGIN = cells[i, 4].Value is null ? "" : cells[i, 4].Value.ToString().Trim();
                    row.SUBTYPE1 = cells[i, 8].Value is null ? "" : cells[i, 8].Value.ToString().Trim();
                    row.SUBTYPE2 = cells[i, 9].Value is null ? "" : cells[i, 9].Value.ToString().Trim();
                    row.TREATMENT_HISTORY_1 = cells[i, 6].Value is null ? "" : cells[i, 6].Value.ToString().Trim();
                    row.TREATMENT_HISTORY_2 = cells[i, 7].Value is null ? "" : cells[i, 7].Value.ToString().Trim();
                }
                else {
                    count++;
                    row = new PDXMODEL_INFO();
                    row.CurModel = DealModel.New;
                    row.ORIGIN = cells[i, 4].Value is null ? "" : cells[i, 4].Value.ToString().Trim();
                    row.SUBTYPE1 = cells[i, 8].Value is null ? "" : cells[i, 8].Value.ToString().Trim();
                    row.SUBTYPE2 = cells[i, 9].Value is null ? "" : cells[i, 9].Value.ToString().Trim();
                    row.TREATMENT_HISTORY_1 = cells[i, 6].Value is null ? "" : cells[i, 6].Value.ToString().Trim();
                    row.TREATMENT_HISTORY_2 = cells[i, 7].Value is null ? "" : cells[i, 7].Value.ToString().Trim();

                    row.SQ_NUMBER = cells[i, 0].Value is null ? "" : cells[i, 0].Value.ToString().Trim().TrimStart('0');
                    row.CANCER_TYPE_ABBR = cells[i, 1].Value is null ? "" : cells[i, 1].Value.ToString().Trim();
                    row.MODEL_ID = cells[i, 2].Value is null ? "" : cells[i, 2].Value.ToString().Trim();
                    row.SOURCE = cells[i, 3].Value is null ? "" : cells[i, 3].Value.ToString().Trim();
                    row.CANCER_TYPE = cells[i, 5].Value is null ? "" : cells[i, 5].Value.ToString().Trim();
                    row.MODEL_CATEGORY = cells[i, 10].Value is null ? "" : cells[i, 10].Value.ToString().Trim();
                    row.MODEL_STATUS = cells[i, 11].Value is null ? "" : cells[i, 11].Value.ToString().Trim();
                    row.SOURCE_ID = cells[i, 12].Value is null ? "" : cells[i, 12].Value.ToString().Trim();
                    row.SOURCE_NOTE = cells[i, 13].Value is null ? "" : cells[i, 13].Value.ToString().Trim();
                }
                bll.Update(row);
                row.CurModel = DealModel.None;
            }
            Console.WriteLine(count);
        }
    }
}