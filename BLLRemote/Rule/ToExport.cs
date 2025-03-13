using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI.WebControls;
using Aspose.Cells;
using Crownbio.BLL.Rule;
using static System.Net.Mime.MediaTypeNames;

namespace Crownbio.BLL
{
    public class ToExport
    {
        //public static void TableToExcel(System.Data.DataTable tb, string title)
        //{
        //    string Filename = title;
        //    System.Web.HttpContext context = System.Web.HttpContext.Current;
        //    if ((tb != null))
        //    {
        //        context.Response.Clear();
        //        context.Response.Charset = "GB2312";
        //        context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //        context.Response.ContentType = "application/ms-excel";
        //        context.Response.AppendHeader("content-disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(Filename, System.Text.Encoding.GetEncoding("utf-8")) + ".xls\"");

        //        CultureInfo cult = new CultureInfo("zh-CN", true);
        //        StringWriter sw = new StringWriter(cult);
        //        HtmlTextWriter htw = new HtmlTextWriter(sw);

        //        GridView gv = new GridView();
        //        gv.DataSource = tb.DefaultView;
        //        gv.AllowPaging = false;
        //        gv.Caption = "<b><font color=black size=5>" + title + "</font></b>";
        //        gv.DataBind();

        //        //GridViewRow rowHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        //        //string HeaderBackColor = "seashell";
        //        //rowHeader.BackColor = System.Drawing.ColorTranslator.FromHtml(HeaderBackColor);
        //        ////rowHeader.BackColor = System.Drawing.Color.AliceBlue;  
        //        //rowHeader.Font.Bold = true;


        //        //TableCell headerCell0 = new TableCell();
        //        //headerCell0 = new TableCell();
        //        //headerCell0.Text = "基本资料";
        //        //headerCell0.ColumnSpan = 9;
        //        ////headerCell1.BorderWidth = Unit.Pixel(0);  
        //        ////headerCell1.BorderStyle = BorderStyle.None;  
        //        ////headerCell0.BorderColor = System.Drawing.Color.Red;  
        //        //headerCell0.HorizontalAlign = HorizontalAlign.Center;
        //        //headerCell0.VerticalAlign = VerticalAlign.Bottom;
        //        //rowHeader.Cells.Add(headerCell0);

        //        //gv.Controls[0].Controls.AddAt(0, rowHeader);


        //        htw.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html;charset=GB2312\">");
        //        gv.RenderControl(htw);
        //        context.Response.Write(sw.ToString());
        //        context.Response.End();
        //    }
        //}

        public static void TableToExcel2(System.Data.DataTable dt, string title)
        {
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];
            Cells cells = worksheet.Cells;
            cells.ImportDataTable(dt, true, "a1");
            //workbook.Save(HttpContext.Current.Response, title + ".xlsx", ContentDisposition.Attachment, new OoxmlSaveOptions(SaveFormat.Xlsx));
            
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.Charset = "utf-8";
            context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + title + ".xls");
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.ContentType = "application/ms-excel";
            context.Response.BinaryWrite(workbook.SaveToStream().ToArray());
            context.Response.End();
        }

        public static void TableToExcel(System.Data.DataTable dt, string title)
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            Workbook workbook = new Workbook();
            Worksheet sheet = (Worksheet)workbook.Worksheets[0];

            Cell cell = null;
            for (int col = 0; col < dt.Columns.Count; col++)
            {
                cell = sheet.Cells[0, col];
                cell.PutValue(dt.Columns[col].ColumnName);

            }

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    sheet.Cells[r + 1, c].PutValue(dt.Rows[r][c].ToString());
                }
            }

            context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.Charset = "utf-8";
            context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + title + ".xls");
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.ContentType = "application/ms-excel";
            context.Response.BinaryWrite(workbook.SaveToStream().ToArray());
            context.Response.End();
        }


        public static string ExcelToEmail(System.Data.DataTable dt, string title)
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            Workbook workbook = new Workbook();
            Worksheet sheet = (Worksheet)workbook.Worksheets[0];

            Cell cell = null;
            for (int col = 0; col < dt.Columns.Count; col++)
            {
                cell = sheet.Cells[0, col];
                cell.PutValue(dt.Columns[col].ColumnName);

            }

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    sheet.Cells[r + 1, c].PutValue(dt.Rows[r][c].ToString());
                }
            }

            byte[] attachments = workbook.SaveToStream().ToArray();
            string msg = SendEmail.SendMail_SMTP("html", "Subject", "body", new []{ "lijun@crownbio.com"}, "Sendmail successfully.");
            return msg;

        }



     
    }
}
