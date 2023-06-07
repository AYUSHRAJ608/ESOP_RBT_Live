using System;
using System.Collections.Generic;
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
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Drawing;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace ESOP
{
    public partial class vesting_approval_president_Report : System.Web.UI.Page
    {
        vesting_approvalBAL objBAL = new vesting_approvalBAL();
        vesting_approvalBO objBO = new vesting_approvalBO();
        exercise_reportBAL objBAL_Ex = new exercise_reportBAL();
        exercise_reportBO objBO_Ex = new exercise_reportBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Session["Role"]) == "Admin")
                {
                    dasboard.HRef = "admin-dashboard.aspx";
                    report.HRef = "reports.aspx";
                    li.InnerText = "Employee wise Vesting Report";
                    div.InnerText = "Employee wise Vesting Report";
                }
                GET_PRESIDENT_VESTING_FOR_APPROVAL();
                //GET_PRESIDENT_VESTING_FOR_APPROVAL_COUNT();
            }

        }

        public void GET_PRESIDENT_VESTING_FOR_APPROVAL()
        {
            try
            {
                if (txtStartDate.Text != "" && txtEndDate.Text != "")
                {
                    objBO_Ex.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objBO_Ex.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }
                else if (txtStartDate.Text == "" && txtEndDate.Text != "")
                {
                    objBO_Ex.START_DATE = txtStartDate.Text;
                    objBO_Ex.END_DATE = txtEndDate.Text;
                }
                DataSet ds = new DataSet();
                ds = objBAL.GET_PRESIDENT_VESTING_FOR_APPROVAL_FILTER(objBO_Ex);
                if (ds.Tables[0].Rows.Count > 0)
                {


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GrvApproved.DataSource = ds.Tables[0];
                        GrvApproved.DataBind();
                    }
                    else
                    {
                        GrvApproved.DataSource = ds.Tables[0];
                        GrvApproved.DataBind();

                    }


                }
                else
                {

                    //ViewState["PendingforApprovalRecords"] = null;


                    GrvApproved.DataSource = ds.Tables[0];
                    GrvApproved.DataBind();
                    //ViewState["ApprovedRecords"] = null;


                    //ViewState["RejectRecords"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }











        protected void GrvApproved_PreRender(object sender, EventArgs e)
        {
            if (txtStartDate.Text != "" && txtEndDate.Text != "")
            {
                objBO_Ex.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                objBO_Ex.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            }
            DataSet ds = objBAL.GET_PRESIDENT_VESTING_FOR_APPROVAL_FILTER(objBO_Ex);
            if (ds.Tables[0].Rows.Count > 0)
            {

                GrvApproved.UseAccessibleHeader = true;
                GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtStartDate.Text != "" && txtEndDate.Text != "")
                {
                    GET_PRESIDENT_VESTING_FOR_APPROVAL();
                }
                else if (txtStartDate.Text == "" && txtEndDate.Text != "")
                {
                    GET_PRESIDENT_VESTING_FOR_APPROVAL();
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
            //string filename = "PRESIDENT_VESTING_APPROVAL_REPORT_" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    //To Export all pages
            //    GrvApproved.AllowPaging = false;
            //    //this.GET_ADMIN_EXERCISE_REPORT();

            //    GrvApproved.HeaderRow.BackColor = Color.White;
            //    foreach (TableCell cell in GrvApproved.HeaderRow.Cells)
            //    {
            //        cell.BackColor = GrvApproved.HeaderStyle.BackColor;
            //    }
            //    foreach (GridViewRow row in GrvApproved.Rows)
            //    {
            //        row.BackColor = Color.White;
            //        foreach (TableCell cell in row.Cells)
            //        {
            //            if (row.RowIndex % 2 == 0)
            //            {
            //                cell.BackColor = GrvApproved.AlternatingRowStyle.BackColor;
            //            }
            //            else
            //            {
            //                cell.BackColor = GrvApproved.RowStyle.BackColor;
            //            }
            //            cell.CssClass = "textmode";
            //        }
            //    }

            //    GrvApproved.RenderControl(hw);

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
            string FileName;
            if (Convert.ToString(Session["Role"]) == "Admin")
            {
                FileName = "EMPLOYEE_VESTING_APPROVAL_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            }
            else
            {
                FileName = "PRESIDENT_VESTING_APPROVAL_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            }
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            GrvApproved.GridLines = GridLines.Both;
            GrvApproved.HeaderStyle.Font.Bold = true;
            GrvApproved.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void btnpdfexport_Click(object sender, ImageClickEventArgs e)
        {
            string filename;
            Response.ContentType = "application/pdf";
            if (Convert.ToString(Session["Role"]) == "Admin")
            {
                filename = "EMPLOYEE_VESTING_APPROVAL_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            }
            else
            {
                filename = "PRESIDENT_VESTING_APPROVAL_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            }
            // Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");


            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GrvApproved.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            GrvApproved.AllowPaging = true;
            GrvApproved.DataBind();
        }
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtStartDate.Text = txtEndDate.Text = string.Empty;
            objBO_Ex.START_DATE = "";
            objBO_Ex.END_DATE = "";
            GET_PRESIDENT_VESTING_FOR_APPROVAL();
        }
    }
}