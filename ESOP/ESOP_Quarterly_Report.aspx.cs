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
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Net.Mail;
using System.Net;
using System.Drawing;
using System.Globalization;

namespace ESOP
{
    public partial class ESOP_Quarterly_Report : System.Web.UI.Page
    {
        PresedentApprovalBO objbo = new PresedentApprovalBO();
        PresedentApprovalBAL objbal = new PresedentApprovalBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        exercise_reportBAL objBAL = new exercise_reportBAL();
        exercise_reportBO objBO = new exercise_reportBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            FunGetApprovalRecords_Filter();
        }
        protected void GrvApproved_PreRender(object sender, EventArgs e)
        {
            if (txtStartDate.Text != "" && txtEndDate.Text != "")
            {
                objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            }
            DataSet ds = objbal.ESOP_QUARTERLY_REPORT(objBO);
            if (ds.Tables[0].Rows.Count > 0)
            {

                GrvApproved.UseAccessibleHeader = true;
                GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                GrvApproved.DataSource = ds.Tables[0];
                GrvApproved.DataBind();
            }
        }
        public void FunGetApprovalRecords_Filter()
        {
            try
            {
                var year = DateTime.Now.Year;
                DateTime date = DateTime.Now;
                if (date.Month >= 4 && date.Month <= 6 && date.Year == year)
                { }
                else if (date.Month >= 7 && date.Month <= 9 && date.Year == year)
                { }
                else if (date.Month >= 10 && date.Month <= 12 && date.Year == year)
                { }

                else if (date.Month >= 1 && date.Month <= 3 && date.Year == year)
                {
                    if (ddlDuratin.SelectedValue == "1" || ddlDuratin.SelectedValue == "2" || ddlDuratin.SelectedValue == "3" || ddlDuratin.SelectedValue == "5")
                    {
                        year = year - 1;
                    }
                };


                if (ddlDuratin.SelectedValue == "1")
                {
                    txtStartDate.Text = "01-4-" + year;
                    txtEndDate.Text = "30-6-" + year;
                }
                if (ddlDuratin.SelectedValue == "2")
                {
                    txtStartDate.Text = "01-7-" + year;
                    txtEndDate.Text = "30-9-" + year;
                }
                if (ddlDuratin.SelectedValue == "3")
                {
                    txtStartDate.Text = "01-10-" + year;
                    txtEndDate.Text = "31-12-" + year;
                }
                if (ddlDuratin.SelectedValue == "4")
                {
                    txtStartDate.Text = "01-1-" + year;
                    txtEndDate.Text = "31-3-" + year;
                }
                if (ddlDuratin.SelectedValue == "5")
                {
                    txtStartDate.Text = "01-4-" + year;
                    txtEndDate.Text = "30-9-" + year;
                }
                if (ddlDuratin.SelectedValue == "6")
                {
                    if (date.Month >= 1 && date.Month <= 3 && date.Year == year)
                    {
                        txtStartDate.Text = "01-10-" + (year - 1);
                    }
                    else
                    {
                        txtStartDate.Text = "01-10-" + year;
                    }
                    txtEndDate.Text = "31-3-" + year;
                }
                if (ddlDuratin.SelectedValue == "7")
                {
                    if (date.Month >= 1 && date.Month <= 3 && date.Year == year)
                    {
                        txtStartDate.Text = "01-4-" + (year - 1);
                    }
                    else
                    {
                        txtStartDate.Text = "01-4-" + year;
                    }
                    txtEndDate.Text = "31-3-" + (year + 1);
                }

                objBO.START_DATE = txtStartDate.Text;
                objBO.END_DATE = txtEndDate.Text;

                DataSet ds = new DataSet();
                ds = objbal.ESOP_QUARTERLY_REPORT(objBO);
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


                    GrvApproved.DataSource = null;
                    GrvApproved.DataBind();
                    ViewState["ApprovedRecords"] = null;

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }
        protected void GrvApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvApproved.PageIndex = e.NewPageIndex;
            if (ViewState["ApprovedRecords"] != null)
            {
                DataTable Dt = (DataTable)ViewState["ApprovedRecords"];
                if (Dt.Rows.Count > 0)
                {
                    GrvApproved.DataSource = ViewState["ApprovedRecords"];
                    GrvApproved.DataBind();
                }
            }
            else
                FunGetApprovalRecords_Filter();
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {

            try
            {
                if (ddlDuratin.SelectedValue != "0")
                {
                    FunGetApprovalRecords_Filter();
                }
                else
                {
                    Common.ShowJavascriptAlert("Please select duration");
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
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName;
            var year = DateTime.Now.Year;
            DateTime date = DateTime.Now;
            if (date.Month >= 1 && date.Month <= 3 && date.Year == year)
            {
                year = year - 1;
            }
            FileName = "ESOP_"+ year + "_" + ddlDuratin.SelectedItem + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
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
            filename = "PRESIDENT_GRANT_APPROVAL_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
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
            objBO.START_DATE = "";
            objBO.END_DATE = "";
            FunGetApprovalRecords_Filter();
        }
    }
}