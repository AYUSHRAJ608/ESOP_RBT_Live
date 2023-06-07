
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
using System.Drawing;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ESOP
{
    public partial class employee_exercise_report : System.Web.UI.Page
    {
        exercise_reportBAL objBAL = new exercise_reportBAL();
        exercise_reportBO objBO = new exercise_reportBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtStartDate.Attributes.Add("readonly", "readonly");
            txtEndDate.Attributes.Add("readonly", "readonly");
            if (!IsPostBack)
            {
                GET_EMPLOYEE_EXERCISE_REPORT();
            }

        }
        public void GET_EMPLOYEE_EXERCISE_REPORT()
        {
            try
            {
                objBO.ECODE = Convert.ToString(Session["ECODE"]);
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
                //else
                //{
                //    objBO.START_DATE = "";// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                //    objBO.END_DATE = "";// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                //}
                ds = objBAL.GET_EMPLOYEE_EXERCISE_REPORT(objBO);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvExercise.DataSource = ds.Tables[0];
                    gvExercise.DataBind();

                    gvExercise.UseAccessibleHeader = true;
                    gvExercise.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    gvExercise.DataSource = ds.Tables[0];
                    gvExercise.DataBind();

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStartDate.Text != "" && txtEndDate.Text != "")
                {
                    GET_EMPLOYEE_EXERCISE_REPORT();
                }
                else if (txtStartDate.Text == "" && txtEndDate.Text != "")
                {
                    GET_EMPLOYEE_EXERCISE_REPORT();
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


        protected void btnexcelExport_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Clear();
            //Response.Buffer = true;
            //string filename = "EMPLOYEE_EXERCISE_REPORT_" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    //To Export all pages
            //    gvExercise.AllowPaging = false;
            //    this.GET_EMPLOYEE_EXERCISE_REPORT();

            //    gvExercise.HeaderRow.BackColor = Color.White;
            //    foreach (TableCell cell in gvExercise.HeaderRow.Cells)
            //    {
            //        cell.BackColor = gvExercise.HeaderStyle.BackColor;
            //    }
            //    foreach (GridViewRow row in gvExercise.Rows)
            //    {
            //        row.BackColor = Color.White;
            //        foreach (TableCell cell in row.Cells)
            //        {
            //            if (row.RowIndex % 2 == 0)
            //            {
            //                cell.BackColor = gvExercise.AlternatingRowStyle.BackColor;
            //            }
            //            else
            //            {
            //                cell.BackColor = gvExercise.RowStyle.BackColor;
            //            }
            //            cell.CssClass = "textmode";
            //        }
            //    }

            //    gvExercise.RenderControl(hw);

            //    //style to format numbers to string
            //    string style = @"<style> .textmode { } </style>";
            //    Response.Write(style);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "EMPLOYEE_EXERCISE_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            gvExercise.GridLines = GridLines.Both;
            gvExercise.HeaderStyle.Font.Bold = true;
            gvExercise.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void btnpdfexport_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";
            string filename = "EMPLOYEE_EXERCISE_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            // Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");


            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvExercise.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            gvExercise.AllowPaging = true;
            gvExercise.DataBind();
        }
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtStartDate.Text = txtEndDate.Text = string.Empty;
            objBO.START_DATE = "";
            objBO.END_DATE = "";
            GET_EMPLOYEE_EXERCISE_REPORT();
        }

        protected void gvExercise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {               
                if (Convert.ToString(e.Row.Cells[15].Text) == "01-JAN-0001")
                {
                    e.Row.Cells[15].Text = "";
                }
            }
        }
    }
}