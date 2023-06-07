using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BO;
using ESOP_BAL;
using System.Data;

namespace ESOP
{
    public partial class ESOP_Status_Report : System.Web.UI.Page
    {
        PresidentBO PresidentBO;
        PresidentBAL PresidentBAL = new PresidentBAL();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            PresidentBO = new PresidentBO();
            DataSet ds = PresidentBAL.GET_ESOP_STATUS(PresidentBO);

            DataTable dtcal_1_1 = CalculateTotal_1_1(ds.Tables[0]);
            GrdExcelData.DataSource = dtcal_1_1;
            GrdExcelData.DataBind();

            DataSet ds1 = PresidentBAL.GET_ESOP_STATUS_BANDWISE(PresidentBO);
            GrdExcelData_1.DataSource = ds1.Tables[0];
            GrdExcelData_1.DataBind();

        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            PresidentBO = new PresidentBO();
            DataSet ds = PresidentBAL.GET_ESOP_STATUS(PresidentBO);

            DataTable dtcal_1 = CalculateTotal_1_1(ds.Tables[0]);

            string filename = "ESOP_Status_Report" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dtcal_1;
            dgGrid.DataBind();

            dgGrid.RenderControl(hw);

            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }

        private DataTable CalculateTotal_1_1(DataTable dt)
        {
            DataTable newdt = new DataTable();
            try
            {

                DataRow dr1 = newdt.NewRow();

                newdt.Columns.Add("Sr No");
                newdt.Columns.Add("ESOP Status as on Date");
                newdt.Columns.Add("Number of Options");
                newdt.AcceptChanges();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

            DataRow dr = newdt.NewRow();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    DataRow dr1 = newdt.NewRow();
                    dr1["Sr No"] = "A";
                    dr1["ESOP Status as on Date"] = dt.Columns[i].ColumnName.ToString();
                    dr1["Number of Options"] = dt.Rows[j][i];
                    newdt.Rows.Add(dr1);
                }
            }

            int r = 0;
            for (char c = 'A'; c < 'G'; c++)
            {
                newdt.Rows[r][0] = c;
                r++;
            }
                return newdt;
        }

        protected void btnBandWise_Click(object sender, EventArgs e)
        {
            PresidentBO = new PresidentBO();
            DataSet ds = PresidentBAL.GET_ESOP_STATUS_BANDWISE(PresidentBO);

            string filename = "Excel_Bands_Wise_Data" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = ds.Tables[0];
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