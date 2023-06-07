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
using System.Collections.Generic;

namespace ESOP
{
    public partial class exercise_report : System.Web.UI.Page
    {
        exercise_reportBAL objBAL = new exercise_reportBAL();
        exercise_reportBO objBO = new exercise_reportBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtStartDate.Attributes.Add("readonly", "readonly");
            txtEndDate.Attributes.Add("readonly", "readonly");
            if (!IsPostBack)
            {
                GET_ADMIN_EXERCISE_REPORT();
            }

            if (Convert.ToString(Session["Role"]) == "Secretarial")
            {
                shownav1.Visible = false;
                shownav.Visible = true;
            }
            else
            {
                shownav1.Visible = true;
                shownav.Visible = false;

            }
        }
        public void GET_ADMIN_EXERCISE_REPORT()
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
                    objBO.START_DATE = txtStartDate.Text;
                    objBO.END_DATE = txtEndDate.Text;
                }
                //else
                //{
                //    objBO.START_DATE = "";// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                //    objBO.END_DATE = "";// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                //}
                ds = objBAL.GET_ADMIN_EXERCISE_REPORT(objBO);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Rows[0]["STOCK_IN_HAND"] = ((Convert.ToString(ds.Tables[0].Rows[0]["NO_OF_EXERCISE"]) == "") ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[0]["NO_OF_EXERCISE"])) - ((Convert.ToString(ds.Tables[0].Rows[0]["NO_OF_SALE"]) == "") ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[0]["NO_OF_SALE"]));// - Convert.ToDecimal(ds.Tables[0].Rows[0]["TOTAL_LAPSE"]);  //- Convert.ToDecimal(ds.Tables[0].Rows[0]["EXERCISED"])  Convert.ToDecimal(ds.Tables[0].Rows[0]["GRANTED"])-
                    ds.Tables[0].Rows[0]["STOCK_IN_HAND"] = Math.Abs(Convert.ToDecimal(ds.Tables[0].Rows[0]["STOCK_IN_HAND"]));

                    gvExercise.DataSource = ds.Tables[0];
                    gvExercise.DataBind();

                    gvExercise_dummy.DataSource = ds.Tables[0];
                    gvExercise_dummy.DataBind();

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
                    GET_ADMIN_EXERCISE_REPORT();
                }
                else if (txtStartDate.Text == "" && txtEndDate.Text != "")
                {
                    GET_ADMIN_EXERCISE_REPORT();
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
            //string filename = "EXERCISE_REPORT_" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    //To Export all pages
            //    gvExercise.AllowPaging = false;
            //    this.GET_ADMIN_EXERCISE_REPORT();

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
            string FileName = "EXERCISE_REPORT_" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            gvExercise_dummy.GridLines = GridLines.Both;
            gvExercise_dummy.HeaderStyle.Font.Bold = true;
            gvExercise_dummy.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void btnpdfexport_Click(object sender, ImageClickEventArgs e)
        {
            if (gvExercise_dummy.Rows.Count > 0)
            {

                Response.ContentType = "application/pdf";
                string filename = "EXERCISE_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                // Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");           
                Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvExercise_dummy.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
                gvExercise_dummy.AllowPaging = true;
                gvExercise_dummy.DataBind();
            }

        }

        protected void gvExercise_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
                GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                GridView gv1 = (GridView)sender;
                double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                string Emp_Name = gv1.Rows[rowIndex].Cells[2].Text;
                Download(ID, Emp_Name);
            }

            if (e.CommandName == "Preview")
            {
                GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                GridView gv1 = (GridView)sender;
                double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                DataSet ds = new DataSet();
                ds = objBAL.GET_EMPLOYEE_SECRETARIAL_DownloadLink(ID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string Freshchequefile = ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
                    FreshChequeImage1.Src = Freshchequefile;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No file for preview!!');", true);
                }
            }
        }

        protected void Download(double id, string Name)
        {
            DataSet ds = new DataSet();
            ds = objBAL.GET_EMPLOYEE_SECRETARIAL_DownloadLink(id);
            List<string> list = new List<string>();
            string Freshchequefile = ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
            if (Freshchequefile != "")
            {
                list.Add(Freshchequefile);
            }

            string[] str = list.ToArray();
            string EMPNAME = Name;
            DownloadFiles(str, EMPNAME);
        }

        protected void DownloadFiles(string[] link, string ENAME)
        {
            string In = "";
            string filePath = "";
            foreach (string R in link)
            {
                filePath = Server.MapPath(R);
                In = "IN";
            }
            if (In == "IN")
            {
                if (File.Exists(filePath))
                {
                    Response.Clear();
                    Response.ContentType = ContentType;
                    Response.AddHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Documents are there to download!!');", true);
            }
        }

        protected void BtnClose_Click(object sender, EventArgs e)
        {

        }

        protected void gvExercise_PreRender(object sender, EventArgs e)
        {
            GET_ADMIN_EXERCISE_REPORT();
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtStartDate.Text = txtEndDate.Text = string.Empty;
            objBO.START_DATE = "";
            objBO.END_DATE = "";
            GET_ADMIN_EXERCISE_REPORT();
        }

        protected void gvExercise_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToString(e.Row.Cells[15].Text) == "01-JAN-2001")
                {
                    e.Row.Cells[15].Text = "";
                }
            }
        }
    }
}
