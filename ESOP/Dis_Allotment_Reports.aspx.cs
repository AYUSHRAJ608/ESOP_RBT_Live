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
    public partial class Dis_Allotment_Approve : System.Web.UI.Page
    {
        Dis_Allotment_ReportsBAL objDisBAL = new Dis_Allotment_ReportsBAL();
        Dis_Allotment_ReportsBO objDisBO = new Dis_Allotment_ReportsBO();
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
                    objDisBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objDisBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }
                else if (txtStartDate.Text == "" && txtEndDate.Text != "")
                {
                    objDisBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objDisBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }
                ds = objDisBAL.GET_ADMIN_SALE_REPORT(objDisBO);

                if (ds.Tables[0].Rows.Count > 0)
                {
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

                throw ex;
            }
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
        private void clearcontrol()
        {
            txtStartDate.Text = txtEndDate.Text = string.Empty;
        }
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            clearcontrol();
            objDisBO.START_DATE = "";
            objDisBO.END_DATE = "";
            GET_ADMIN_SALE_REPORT();
        }

        protected void btnexcelExport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "DIS_Allotment_REPORT_" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
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

            string filename = "DIS_Allotment_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
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
    }
}