using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL_REPORT;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Drawing;
using Entity_REPORT;
using System.Security.Cryptography;
using System.Text;

namespace Report_Builder
{
    public partial class ShowReport : System.Web.UI.Page
    {
        ReportBAL objRpt_BAL = new ReportBAL();
        EReport objReport = new EReport();
        protected void Page_Load(object sender, EventArgs e)
        {
            FunGetReportsData();
        }

        #region Export to Excel, CSV and PDF
        protected void lnkExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";

            string FileName = "Report" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);

            var gv = new GridView();
            gv.AllowSorting = false;

            gv.DataSource = grdReports.DataSource;
            gv.DataBind();

            gv.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
        protected void lnkCSV_Click(object sender, EventArgs e)
        {
            ToCSV((DataTable)Session["grdReports"]);
        }
        protected void lnkPDF_Click(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    iTextSharp.text.Font fontHeader = FontFactory.GetFont("Zurich BT", 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    iTextSharp.text.Font fontTiny = FontFactory.GetFont("Zurich BT", 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    iTextSharp.text.Font fontHeaderMain = FontFactory.GetFont("Zurich BT", 11, iTextSharp.text.Font.BOLD, BaseColor.RED);

                    PdfPTable HeaderTable = new PdfPTable(2);
                    HeaderTable.SpacingBefore = 40f;

                    HeaderTable.WidthPercentage = 100f;
                    float[] width = new float[] { 550f, 250f };
                    HeaderTable.SetWidths(width);
                    PdfPCell HeaderCell1 = new PdfPCell();
                    PdfPCell HeaderCell2 = new PdfPCell();

                    HeaderCell1.Border = 0;
                    HeaderCell2.Border = 0;

                    string path = "img";
                    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(Server.MapPath(path + "/logo.png"));
                    gif.Alignment = Element.ALIGN_RIGHT;
                    gif.ScaleToFit(50, 60);
                    gif.Border = 0;

                    HeaderCell2.AddElement(gif);

                    Phrase p = new Phrase(Session["ReportName"].ToString(), fontHeaderMain);
                    HeaderCell1.AddElement(p);
                    HeaderTable.AddCell(HeaderCell1);
                    HeaderTable.AddCell(HeaderCell2);
                    HeaderTable.SpacingAfter = 40;

                    var gv = new GridView();
                    gv.AllowSorting = false;
                    gv.Width = Unit.Percentage(100);

                    gv.DataSource = grdReports.DataSource;
                    gv.DataBind();
                    gv.HeaderRow.BackColor = Color.Navy;
                    gv.HeaderRow.ForeColor = Color.White;
                    gv.RenderControl(hw);

                    StringReader sr = new StringReader(sw.ToString().Trim().Replace("img/", Server.MapPath("img/")));
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    pdfDoc.SetPageSize(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    pdfDoc.Add(HeaderTable);
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Report_" + DateTime.Now + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
        #endregion Export

        #region Events Declarations
        protected void grdReports_PreRender(object sender, EventArgs e)
        {
            DataTable ds = (DataTable)Session["grdReports"];
            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {
                    grdReports.UseAccessibleHeader = true;
                    grdReports.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            if (Session["grdReports"] != null)
            {
                objReport.ReportID = Convert.ToInt32(Session["ReportId"]);
                objReport.Query = Session["InLineQueryWithFilter"].ToString();
                objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                objRpt_BAL.UpdateReportsData(objReport);
                Response.Write("<script language='javascript'>window.alert('Report Saved Successfully');window.location='Dashboard.aspx';</script>");
            }
        }
        #endregion Events Declarations

        #region Method Declarations
        public void FunGetReportsData()
        {
            objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
            DataSet ds = objRpt_BAL.GetReportData(Session["InLineQueryWithFilter"].ToString());
            var key = "b14ca5898a4e4133bbce2ea2315a1916";

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    ds.Tables[0].Rows[i]["RATING1415"] = DecryptString(key, ds.Tables[0].Rows[i]["RATING1415"].ToString());
            //    ds.Tables[0].Rows[i]["PROMOTION1415"] = DecryptString(key, ds.Tables[0].Rows[i]["PROMOTION1415"].ToString());
            //    ds.Tables[0].Rows[i]["RATING1516"] = DecryptString(key, ds.Tables[0].Rows[i]["RATING1516"].ToString());
            //    ds.Tables[0].Rows[i]["PROMOTION1516"] = DecryptString(key, ds.Tables[0].Rows[i]["PROMOTION1516"].ToString());
            //    ds.Tables[0].Rows[i]["RATING1617"] = DecryptString(key, ds.Tables[0].Rows[i]["RATING1617"].ToString());
            //    ds.Tables[0].Rows[i]["PROMOTION1617"] = DecryptString(key, ds.Tables[0].Rows[i]["PROMOTION1617"].ToString());
            //}

            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                Session["grdReports"] = dt;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    BoundField bfield = new BoundField();
                    bfield.HeaderText = dt.Columns[i].ToString();
                    bfield.DataField = dt.Columns[i].ToString();
                    grdReports.Columns.Add(bfield);
                }
                grdReports.DataSource = dt;
                grdReports.DataBind();
            }
        }
        public string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);

                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public void ToCSV(DataTable dtDataTable)
        {
            using (StringWriter sw = new StringWriter())
            {
                //headers    
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    sw.Write(dtDataTable.Columns[i]);
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                foreach (DataRow dr in dtDataTable.Rows)
                {
                    for (int i = 0; i < dtDataTable.Columns.Count; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            string value = dr[i].ToString();
                            if (value.Contains(','))
                            {
                                value = String.Format("\"{0}\"", value);
                                sw.Write(value);
                            }
                            else
                            {
                                sw.Write(dr[i].ToString());
                            }
                        }
                        if (i < dtDataTable.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
                Response.ContentType = "application/csv";
                Response.AddHeader("content-disposition", "attachment;filename=Report" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(sw);
                Response.End();
            }
        }
        #endregion Method Declarations
    }
}