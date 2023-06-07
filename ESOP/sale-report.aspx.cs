using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BAL;
using ESOP_BO;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System;
using System.IO;
using System.Drawing;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace ESOP
{
    public partial class sale_report : System.Web.UI.Page
    {
        sale_reportBAL objBAL = new sale_reportBAL();
        sale_reportBO objBO = new sale_reportBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtStartDate.Attributes.Add("readonly", "readonly");
            txtEndDate.Attributes.Add("readonly", "readonly");
            GET_ADMIN_SALE_REPORT();
        }
        public void GET_ADMIN_SALE_REPORT()
        {
            try
            {
                DataSet ds = new DataSet();
                if (txtStartDate.Text != "" && txtEndDate.Text != "")
                {
                    objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }
                else if (txtStartDate.Text == "" && txtEndDate.Text != "")
                {
                    objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }
                ds = objBAL.GET_ADMIN_SALE_REPORT(objBO);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Rows[0]["STOCK_IN_HAND"] = ((Convert.ToString(ds.Tables[0].Rows[0]["NO_OF_EXERCISE"]) == "") ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[0]["NO_OF_EXERCISE"])) - ((Convert.ToString(ds.Tables[0].Rows[0]["NO_OF_SALE"]) == "") ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[0]["NO_OF_SALE"]));// - Convert.ToDecimal(ds.Tables[0].Rows[0]["TOTAL_LAPSE"]);  //- Convert.ToDecimal(ds.Tables[0].Rows[0]["EXERCISED"])  Convert.ToDecimal(ds.Tables[0].Rows[0]["GRANTED"])-
                    ds.Tables[0].Rows[0]["STOCK_IN_HAND"] = Math.Abs(Convert.ToDecimal(ds.Tables[0].Rows[0]["STOCK_IN_HAND"]));

                    gvSale.DataSource = ds.Tables[0];
                    gvSale.DataBind();

                    gvSale.UseAccessibleHeader = true;
                    gvSale.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    gvSale.DataSource = ds.Tables[0];
                    gvSale.DataBind();

                }
                //clearcontrol();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        private void clearcontrol()
        {
            txtStartDate.Text = txtEndDate.Text = string.Empty;
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {

                GET_ADMIN_SALE_REPORT();



            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }


        protected void btnexcelExport_Click(object sender, ImageClickEventArgs e)
        {
            #region Commented Data
            //Response.Clear();
            //Response.Buffer = true;
            //string filename = "SELL_REPORT_" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    //To Export all pages
            //    gvSale.AllowPaging = false;
            //    this.GET_ADMIN_SALE_REPORT();

            //    gvSale.HeaderRow.BackColor = Color.White;
            //    foreach (TableCell cell in gvSale.HeaderRow.Cells)
            //    {
            //        cell.BackColor = gvSale.HeaderStyle.BackColor;
            //    }
            //    foreach (GridViewRow row in gvSale.Rows)
            //    {
            //        row.BackColor = Color.White;
            //        foreach (TableCell cell in row.Cells)
            //        {
            //            if (row.RowIndex % 2 == 0)
            //            {
            //                cell.BackColor = gvSale.AlternatingRowStyle.BackColor;
            //            }
            //            else
            //            {
            //                cell.BackColor = gvSale.RowStyle.BackColor;
            //            }
            //            cell.CssClass = "textmode";
            //        }
            //    }

            //    gvSale.RenderControl(hw);

            //    //style to format numbers to string
            //    string style = @"<style> .textmode { } </style>";
            //    Response.Write(style);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}
            #endregion
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "SELL_REPORT_" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            gvSale.GridLines = GridLines.Both;
            gvSale.HeaderStyle.Font.Bold = true;
            gvSale.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }



        protected void btnpdfexport_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";

            string filename = "SELL_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            // Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");


            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvSale.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            gvSale.AllowPaging = true;
            gvSale.DataBind();
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            clearcontrol();
            objBO.START_DATE = "";
            objBO.END_DATE = "";
            GET_ADMIN_SALE_REPORT();
        }
    }
}