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
    public partial class PresidentsGrantApproval_Report : System.Web.UI.Page
    {
        PresidentBO PresidentBO;
        PresidentBAL PresidentBAL = new PresidentBAL();
        PresedentApprovalBO objbo = new PresedentApprovalBO();
        PresedentApprovalBAL objbal = new PresedentApprovalBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        exercise_reportBAL objBAL = new exercise_reportBAL();
        exercise_reportBO objBO = new exercise_reportBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Role"]) == "Admin")
            {
                dasboard.HRef = "admin-dashboard.aspx";
                report.HRef = "reports.aspx";
                li.InnerText = "Employee wise Grant Report";
                div.InnerText = "Employee wise Grant Report";
            }

           // FunGetApprovalRecords_Filter();
        }
        //protected void GrvApproved_PreRender(object sender, EventArgs e)
        //{
        //    if (txtStartDate.Text != "" && txtEndDate.Text != "")
        //    {
        //        objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
        //        objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
        //    }
        //    DataSet ds = objbal.FunGetApprovalRecords_Filter(objBO);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {

        //        gvParent.UseAccessibleHeader = true;
        //        GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //    else
        //    {
        //        GrvApproved.DataSource = ds.Tables[0];
        //        GrvApproved.DataBind();


        //        // GrvApproved.UseAccessibleHeader = true;
        //        // GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //}
        //public void FunGetApprovalRecords_Filter()
        //{
        //    try
        //    {
        //        if (txtStartDate.Text != "" && txtEndDate.Text != "")
        //        {
        //            objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
        //            objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
        //        }
        //        DataSet ds = new DataSet();
        //        ds = objbal.FunGetApprovalRecords_Filter(objBO);
        //        if (ds.Tables[0].Rows.Count > 0)

        //        {


        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                GrvApproved.DataSource = ds.Tables[0];
        //                GrvApproved.DataBind();
        //                //ViewState["ApprovedRecords"] = ds.Tables[0];
        //                //GrvApproved.UseAccessibleHeader = true;
        //                //GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
        //            }
        //            else
        //            {
        //                GrvApproved.DataSource = ds.Tables[0];
        //                GrvApproved.DataBind();
        //                //ViewState["ApprovedRecords"] = null;
        //            }


        //        }
        //        else
        //        {


        //            GrvApproved.DataSource = null;
        //            GrvApproved.DataBind();
        //            ViewState["ApprovedRecords"] = null;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

        //        //throw ex;
        //    }
        //}
        //protected void GrvApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GrvApproved.PageIndex = e.NewPageIndex;
        //    if (ViewState["ApprovedRecords"] != null)
        //    {
        //        DataTable Dt = (DataTable)ViewState["ApprovedRecords"];
        //        if (Dt.Rows.Count > 0)
        //        {
        //            GrvApproved.DataSource = ViewState["ApprovedRecords"];
        //            GrvApproved.DataBind();
        //        }
        //    }
        //    else
        //        FunGetApprovalRecords_Filter();
        //}

        public void GET_PRESIDENT_VESTING_FOR_APPROVAL()
        {
            try
            {
                if (txtStartDate.Text != "" && txtEndDate.Text != "")
                {
                    objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }
                else if (txtEndDate.Text != "")
                {
                    objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }
                DataSet ds = new DataSet();
                ds = objbal.GET_EMPLOYEE_GRANT_REPORT(objbo);
                if (ds.Tables[0].Rows.Count > 0)
                {


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvParent.DataSource = ds.Tables[0];
                        gvParent.DataBind();
                    }
                    else
                    {
                        gvParent.DataSource = ds.Tables[0];
                        gvParent.DataBind();

                    }


                }
                else
                {

                    //ViewState["PendingforApprovalRecords"] = null;


                    gvParent.DataSource = ds.Tables[0];
                    gvParent.DataBind();
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
                objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            }
            DataSet ds = objbal.GET_EMPLOYEE_GRANT_REPORT(objbo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvParent.UseAccessibleHeader = true;
                gvParent.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtStartDate.Text != "" && txtEndDate.Text != "")
                {
                    GET_EMPLOYEE_GRANT_REPORT();
                }
                else if (txtStartDate.Text == "" && txtEndDate.Text != "")
                {
                    GET_EMPLOYEE_GRANT_REPORT();
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
            //try
            //{
            //    DataSet ds = PresidentBAL.GET_ExportToExcel_Data(PresidentBO);
            //    if (ds.Tables.Count > 0 && ds != null)
            //    {
            //        gvExcelToExport.DataSource = ds.Tables[0];
            //        gvExcelToExport.DataBind();
            //    }
            //    else
            //    {
            //        gvExcelToExport.DataSource = null;
            //        gvExcelToExport.DataBind();
            //    }
            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.ClearContent();
            //    Response.ClearHeaders();
            //    Response.Charset = "";
               
            //    StringWriter strwritter = new StringWriter();
            //    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //    Response.ContentType = "application/vnd.ms-excel";
            //    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                

            //    gvExcelToExport.GridLines = GridLines.Both;
            //    gvExcelToExport.RenderControl(htmltextwrtter);
            //    Response.Write(strwritter.ToString());
            //    Response.End();
            //}
            //catch(Exception ex)
            //{

            //}

            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";

                string FileName = "Employee_Grant_Report" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);

                var gv = new GridView();
                gv.AllowSorting = false;

                DataSet ds = PresidentBAL.GET_ExportToExcel_Data(PresidentBO);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gv.DataSource = ds.Tables[0];
                    gv.DataBind();

                    gv.HeaderStyle.Font.Bold = true;
                    gv.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
                    gv.HeaderRow.VerticalAlign = VerticalAlign.Middle;

                    gv.RenderControl(htmltextwrtter);
                    Response.Write(strwritter.ToString());
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }


        protected void btnpdfexport_Click(object sender, ImageClickEventArgs e)
        {
            string filename;
            Response.ContentType = "application/pdf";
            if (Convert.ToString(Session["Role"]) == "Admin")
            {
                filename = "EMPLOYEE_GRANT_APPROVAL_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            }
            else
            {
                filename = "PRESIDENT_GRANT_APPROVAL_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            }
            // Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");


            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvParent.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            gvParent.AllowPaging = true;
            gvParent.DataBind();
        }
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtStartDate.Text = txtEndDate.Text = string.Empty;
            objBO.START_DATE = "";
            objBO.END_DATE = "";
           // FunGetApprovalRecords_Filter();
        }

        public void GET_EMPLOYEE_GRANT_REPORT()
        {
            try
            {
                DataSet ds = new DataSet();
                if (txtStartDate.Text != "" && txtEndDate.Text != "")
                {
                    objbo.START_DATE = txtStartDate.Text;
                    objbo.END_DATE = txtEndDate.Text;
                }  
                else if (txtStartDate.Text == "" && txtEndDate.Text != "")
                {
                    objbo.START_DATE = txtStartDate.Text;
                    objbo.END_DATE = txtEndDate.Text;
                }
                ds = objbal.GET_EMPLOYEE_GRANT_REPORT(objbo);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvParent.DataSource = ds.Tables[0];
                    gvParent.DataBind();
                    gvParent.UseAccessibleHeader = true;
                    gvParent.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    gvParent.DataSource = ds.Tables[0];
                    gvParent.DataBind();

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void gvParent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvChild = e.Row.FindControl("gvChild") as GridView;
                PresidentBO = new PresidentBO();

                GridView gv1 = (GridView)sender;
                HiddenField HdEmpCode = (HiddenField)e.Row.FindControl("HdEmpCode");
                PresidentBO.ECode = HdEmpCode.Value.ToString().Trim();
                DataSet ds = PresidentBAL.GET_Distinct_VestID(PresidentBO);

                if (ds.Tables.Count > 0 && ds != null)
                {
                    gvChild.DataSource = ds.Tables[0];
                    gvChild.DataBind();

                }
                else
                {
                    gvChild.DataSource = null;
                    gvChild.DataBind();
                }

            }

        }
        protected void gvChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                GridView gvSubChild = e.Row.FindControl("gvSubChild") as GridView;
                PresidentBO = new PresidentBO();

                GridView gv1 = (GridView)sender;
                Label lblobjective = (Label)e.Row.FindControl("lblTranchName");
                PresidentBO.GRANT_NAME = lblobjective.Text.Trim();

                HiddenField HdEmpCode = (HiddenField)e.Row.FindControl("HdEmpCodeTranchwise");
                PresidentBO.ECode = HdEmpCode.Value.ToString().Trim();

                DataSet ds = PresidentBAL.GET_ADMIN_EMP_STOCK_MAPPING_DETAILS(PresidentBO);
                if (ds.Tables.Count > 0 && ds != null)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        ds.Tables[0].Rows[j]["STOCK_IN_HAND"] = Convert.ToDecimal(ds.Tables[0].Rows[j]["EXERCISED"]) - Convert.ToDecimal(ds.Tables[0].Rows[j]["SALE"]);// - Convert.ToDecimal(ds.Tables[0].Rows[j]["TOTAL_LAPSE"]); //- Convert.ToDecimal(ds.Tables[0].Rows[i]["EXERCISED"])
                        ds.Tables[0].Rows[j]["STOCK_IN_HAND"] = Math.Abs(Convert.ToDecimal(ds.Tables[0].Rows[j]["STOCK_IN_HAND"]));
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataTable dt = (ds.Tables[1]);
                            string VP = ds.Tables[0].Rows[i]["VPERCENTAGE"].ToString();

                            decimal tot = dt.AsEnumerable()
                                        .Where(y => y.Field<string>("VESTINGNAME") == VP)
                                        .Sum(x => x.Field<decimal?>("LBV") ?? 0);

                            ds.Tables[0].Rows[i]["LBV"] = tot;
                            ds.Tables[0].AcceptChanges();

                            DataTable dt1 = (ds.Tables[1]);
                            string VP1 = ds.Tables[0].Rows[i]["VPERCENTAGE"].ToString();


                            decimal tot1 = dt.AsEnumerable()
                                        .Where(y => y.Field<string>("VESTINGNAME") == VP)
                                        .Sum(x => x.Field<decimal?>("LAV") ?? 0);

                            ds.Tables[0].Rows[i]["LAV"] = tot1;
                            ds.Tables[0].AcceptChanges();

                            string VP2 = ds.Tables[0].Rows[i]["TOTAL_LAPSE"].ToString();

                            decimal tot2 = dt.AsEnumerable()
                                        .Where(y => y.Field<string>("VESTINGNAME") == VP)
                                        .Sum(x => x.Field<decimal?>("TOTAL_LAPSED") ?? 0);

                            ds.Tables[0].Rows[i]["TOTAL_LAPSE"] = tot2;
                            ds.Tables[0].AcceptChanges();

                            ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = Convert.ToDecimal(ds.Tables[0].Rows[i]["EXERCISED"]) - Convert.ToDecimal(ds.Tables[0].Rows[i]["SALE"]);// - Convert.ToDecimal(ds.Tables[0].Rows[i]["TOTAL_LAPSE"]); //- Convert.ToDecimal(ds.Tables[0].Rows[i]["EXERCISED"])
                            ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = Math.Abs(Convert.ToDecimal(ds.Tables[0].Rows[i]["STOCK_IN_HAND"]));
                        }
                    }
                    DataTable dtcal =ds.Tables[0];
                    gvSubChild.DataSource = dtcal;
                    gvSubChild.DataBind();
                }
                else
                {
                    gvSubChild.DataSource = null;
                    gvSubChild.DataBind();
                }
            }
        }


        protected void gvExcelToExport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvExcelToExport = e.Row.FindControl("gvExcelToExport") as GridView;
                PresidentBO = new PresidentBO();

                GridView gv1 = (GridView)sender;
                HiddenField HdEmpCode = (HiddenField)e.Row.FindControl("HdEmpCode");
                PresidentBO.ECode = HdEmpCode.Value.ToString().Trim();
                DataSet ds = PresidentBAL.GET_ExportToExcel_Data(PresidentBO);

                if (ds.Tables.Count > 0 && ds != null)
                {
                    gvExcelToExport.DataSource = ds.Tables[0];
                    gvExcelToExport.DataBind();

                }
                else
                {
                    gvExcelToExport.DataSource = null;
                    gvExcelToExport.DataBind();
                }

            }
        }
    }
}