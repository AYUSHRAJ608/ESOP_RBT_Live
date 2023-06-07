using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BAL;
using ESOP_BO;
using System.IO;
using System.Drawing;
using System.Text;

namespace ESOP
{
    public partial class ErrorPage : Page
    {
        exercise_reportBAL objDash_BAL = new exercise_reportBAL();
        exercise_reportBO objDash_ent = new exercise_reportBO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                bindRM_Grid();
            }
        }

        #region Export To Excel

        protected void lnkExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "Report_" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataTable DtReport = new DataTable();
                DtReport = (DataTable)ViewState["Report"];
                if (DtReport.Rows.Count > 0)
                {
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = DtReport;
                    dgGrid.DataBind();
                    dgGrid.RenderControl(hw);

                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
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
        #endregion Events Declarations

        #region Method Declarations
        public void bindRM_Grid()
        {
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = objDash_BAL.GetError();
                dt = ds.Tables[0];
                grdReports.DataSource = dt;
                grdReports.DataBind();

                grdReports.UseAccessibleHeader = true;
                grdReports.HeaderRow.TableSection = TableRowSection.TableHeader;
                ViewState["Report"] = dt;
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        #endregion Method Declarations
    }
}