using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace ESOP
{
    public partial class Hr_Approval_Report : System.Web.UI.Page
    {
        HrapprovalBO objbo = new HrapprovalBO();
        HrapprovalBAL objbal = new HrapprovalBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        exercise_reportBAL objBAL = new exercise_reportBAL();
        exercise_reportBO objBO = new exercise_reportBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_approval_data_hr();
            }
        }
        protected void grdapproval_PreRender(object sender, EventArgs e)
        {
            if (txtStartDate.Text != "" && txtEndDate.Text != "")
            {
                objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            }
            DataSet ds = objbal.get_hr_appraval_date_wise(objBO);
            if (ds.Tables[0].Rows.Count > 0)
            {

                grdapproval.UseAccessibleHeader = true;
                grdapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        private void bind_approval_data_hr()
        {
            try
            {
                if (txtStartDate.Text != "" && txtEndDate.Text != "")
                {
                    objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }
                DataSet ds = objbal.get_hr_appraval_date_wise(objBO);
                if (ds.Tables[0].Rows.Count > 0 )
                {
                        Session["mydataset"] = ds;
                        grdapproval.DataSource = ds.Tables[0];
                        grdapproval.DataBind();

                }
                else
                {
                    grdapproval.DataSource = ds.Tables[0];
                    grdapproval.DataBind();
                   // ViewState["ApprovedRecords"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtStartDate.Text != "" && txtEndDate.Text != "")
                {
                    bind_approval_data_hr();
                }
                else
                {
                    Common.ShowJavascriptAlert("Please select date.");
                }
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
        //protected void btnExport_Click(object sender, EventArgs e)
        //{
        //    Response.Clear();
        //    Response.Buffer = true;
        //    string filename = "EXERCISE_REPORT_" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
        //    Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        HtmlTextWriter hw = new HtmlTextWriter(sw);

        //        //To Export all pages
        //        grdapproval.AllowPaging = false;
        //        //this.GET_ADMIN_EXERCISE_REPORT();

        //        grdapproval.HeaderRow.BackColor = Color.White;
        //        foreach (TableCell cell in grdapproval.HeaderRow.Cells)
        //        {
        //            cell.BackColor = grdapproval.HeaderStyle.BackColor;
        //        }
        //        foreach (GridViewRow row in grdapproval.Rows)
        //        {
        //            row.BackColor = Color.White;
        //            foreach (TableCell cell in row.Cells)
        //            {
        //                if (row.RowIndex % 2 == 0)
        //                {
        //                    cell.BackColor = grdapproval.AlternatingRowStyle.BackColor;
        //                }
        //                else
        //                {
        //                    cell.BackColor = grdapproval.RowStyle.BackColor;
        //                }
        //                cell.CssClass = "textmode";
        //            }
        //        }

        //        grdapproval.RenderControl(hw);

        //        //style to format numbers to string
        //        string style = @"<style> .textmode { } </style>";
        //        Response.Write(style);
        //        Response.Output.Write(sw.ToString());
        //        Response.Flush();
        //        Response.End();
        //    }
        //}
        private DataTable FilterTable()
        {
            DataSet ds = (DataSet)Session["mydataset"];
            DataTable table = ds.Tables[0];
            DateTime ST = DateTime.ParseExact(txtStartDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture); 

            var filteredRows =
                from row in table.Rows.OfType<DataRow>()
                where Convert.ToDateTime(row[2]) >= Convert.ToDateTime(txtStartDate.Text)
                where Convert.ToDateTime(row[2]) <= Convert.ToDateTime(txtEndDate.Text) 
                orderby (int)row[1] descending
                select row;

            var filteredTable = table.Clone();

            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));

            return filteredTable;
        }

        protected void btnexcelExport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "HR_APPROVAL_REPORT_" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            grdapproval.GridLines = GridLines.Both;
            grdapproval.HeaderStyle.Font.Bold = true;
            grdapproval.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void btnpdfexport_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";
            string filename = "HR_APPROVAL_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            // Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");


            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdapproval.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            grdapproval.AllowPaging = true;
            grdapproval.DataBind();
        }
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtStartDate.Text = txtEndDate.Text = string.Empty;
            objBO.START_DATE = "";
            objBO.END_DATE = "";
            bind_approval_data_hr();
        }
    }
}