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
using System.Text;

namespace Report_Builder
{
    public partial class Dashboard : Page
    {
        DashboardBAL objDash_BAL = new DashboardBAL();
        EDashboard objDash_ent = new EDashboard();
        ReportBAL objRpt_BAL = new ReportBAL();
        //string rolename;
        protected void Page_Load(object sender, EventArgs e)
        {
            ////rolename = Session["LoginRole"].ToString().ToUpper();
            ////if(rolename == null)
            ////{
            ////    rolename = "USER";
            ////}
            if (Page.IsPostBack == false)
            {
                bindRM_Grid();
            }
        }

        #region Method Declarations
        public void bindRM_Grid()
        {
            try
            {
                DataTable dt = new DataTable();
                objDash_ent.key = Session["AppConnectionstring"].ToString();
                //objDash_ent.rolename = rolename;
                //objDash_ent.emp_code = Convert.ToInt32(Session["EMPID"]);
                DataSet ds = objDash_BAL.GetDashGrid(objDash_ent);
                dt = ds.Tables[0];
                Session["Grid"] = grdReports.DataSource = dt;
                grdReports.DataBind();
                ViewState["Report"] = dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion Method Declarations

        #region View, Export To Excel, CSV and PDF
        protected void lnkView_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            Grid_ShowReport.DataSource = null;
            Grid_ShowReport.Columns.Clear();
            Grid_ShowReport.DataBind();
            if (row != null)
            {
                var lblQuery = row.FindControl("lblquery") as Label;
                if (lblQuery != null && lblQuery.Text != "")
                {
                    string Query = lblQuery.Text;
                    objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                    DataSet ds = objRpt_BAL.GetReportData(Query.ToString());
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Session["grdReportsDash"] = dt;

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            BoundField bfield = new BoundField();
                            bfield.HeaderText = dt.Columns[i].ToString();
                            bfield.DataField = dt.Columns[i].ToString();
                            Grid_ShowReport.Columns.Add(bfield);
                        }
                        ViewState["View"] = Grid_ShowReport.DataSource = dt;
                        Grid_ShowReport.DataBind();
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalertVal", "alert('Query String not found.');", true);
                }
            }
        }
        protected void lnkExcel_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblQuery = row.FindControl("lblquery") as Label;
                if (lblQuery != null)
                {
                    string Query = lblQuery.Text;
                    objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                    DataSet ds = objRpt_BAL.GetReportData(Query.ToString());
                    DataTable dtRpt = ds.Tables[0];

                    string filename = "Report_" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dtRpt;
                    dgGrid.DataBind();
                    dgGrid.RenderControl(hw);

                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();
                }
            }
        }
        protected void lnkCSV_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblQuery = row.FindControl("lblquery") as Label;
                if (lblQuery != null)
                {
                    string Query = lblQuery.Text;
                    objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                    DataSet ds = objRpt_BAL.GetReportData(Query.ToString());
                    DataTable dtRpt = ds.Tables[0];

                    string filename = "Report_" + DateTime.Now.ToString("ddMMyyyy") + ".csv";

                    if (dtRpt.Rows.Count > 0)
                    {
                        Session["grdReportsDash"] = dtRpt;
                        for (int i = 0; i < dtRpt.Columns.Count; i++)
                        {
                            BoundField bfield = new BoundField();
                            bfield.HeaderText = dtRpt.Columns[i].ToString();
                            bfield.DataField = dtRpt.Columns[i].ToString();
                            Grid_ShowReport.Columns.Add(bfield);
                        }
                        Grid_ShowReport.DataSource = dtRpt;
                        Grid_ShowReport.AllowPaging = false;
                        Grid_ShowReport.DataBind();
                        Grid_ShowReport.Visible = false;
                    }

                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=" + filename +"");
                    Response.Charset = "";
                    Response.ContentType = "application/text";

                    StringBuilder columnbind = new StringBuilder();
                    for (int k = 0; k < Grid_ShowReport.Columns.Count; k++)
                    {
                        columnbind.Append(Grid_ShowReport.Columns[k].HeaderText + ',');
                    }
                    columnbind.Append("\r\n");
                    for (int i = 0; i < Grid_ShowReport.Rows.Count; i++)
                    {
                        for (int k = 0; k < Grid_ShowReport.Columns.Count; k++)
                        {
                            columnbind.Append(Grid_ShowReport.Rows[i].Cells[k].Text + ',');
                        }
                        columnbind.Append("\r\n");
                    }
                    Response.Output.Write(columnbind.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            
            
        }
        protected void lnkPDF_Click(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    LinkButton lb = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)lb.NamingContainer;
                    if (row != null)
                    {
                        var lblQuery = row.FindControl("lblquery") as Label;
                        if (lblQuery != null)
                        {
                            string Query = lblQuery.Text;
                            objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                            DataSet ds = objRpt_BAL.GetReportData(Query.ToString());
                            DataTable dt = ds.Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                Session["grdReportsDash"] = dt;

                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    BoundField bfield = new BoundField();
                                    bfield.HeaderText = dt.Columns[i].ToString();
                                    bfield.DataField = dt.Columns[i].ToString();
                                    Grid_ShowReport.Columns.Add(bfield);
                                }
                                Grid_ShowReport.DataSource = dt;
                                Grid_ShowReport.AllowPaging = false;
                                Grid_ShowReport.DataBind();
                                Grid_ShowReport.Visible = false;
                            }
                        }
                    }

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

                    Phrase p = new Phrase(row.Cells[1].Text, fontHeaderMain);
                    HeaderCell1.AddElement(p);
                    HeaderTable.AddCell(HeaderCell1);
                    HeaderTable.AddCell(HeaderCell2);
                    HeaderTable.SpacingAfter = 40;

                    var gv = new GridView();
                    gv.AllowSorting = false;
                    gv.Width = Unit.Percentage(100);

                    gv.DataSource = Grid_ShowReport.DataSource;
                    gv.DataBind();
                    //gv.HeaderRow.BackColor = Color.Navy;
                    //gv.HeaderRow.ForeColor = Color.White;
                    gv.RenderControl(hw);

                    StringReader sr = new StringReader(sw.ToString().Trim().Replace("img/", Server.MapPath("img/")));
                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                    pdfDoc.SetPageSize(PageSize.A4.Rotate());
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

        #endregion View, Export To Excel, CSV and PDF

        #region Events Declarations
        protected void grdReports_PreRender(object sender, EventArgs e)
        {
            DataTable ds = (DataTable)ViewState["Report"];
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
        protected void Grid_ShowReport_PreRender(object sender, EventArgs e)
        {
            DataTable ds = (DataTable)ViewState["View"];
            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {
                    Grid_ShowReport.UseAccessibleHeader = true;
                    Grid_ShowReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }
		protected void grdReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "query"));
                    LinkButton lnkExcel = (LinkButton)e.Row.FindControl("lnkExcel");
                    LinkButton lnkCSV = (LinkButton)e.Row.FindControl("lnkCSV");
                    LinkButton lnkPDF = (LinkButton)e.Row.FindControl("lnkPDF");

                    if (value == "")
                    {
                        lnkExcel.Visible = false;
                        lnkCSV.Visible = false;
                        lnkPDF.Visible = false;
                    }
                    else
                    {
                        lnkExcel.Visible = true;
                        lnkCSV.Visible = true;
                        lnkPDF.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion Events Declarations       
    }
}