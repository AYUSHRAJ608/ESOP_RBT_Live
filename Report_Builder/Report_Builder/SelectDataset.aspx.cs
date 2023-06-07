using BAL_REPORT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report_Builder
{
    public partial class SelectDataset : System.Web.UI.Page
    {
        ReportBAL objRpt_BAL = new ReportBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {                 
                GetDatasets();
            }
        }

        #region Events Declarations
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chckheader = (CheckBox)grdAll.HeaderRow.FindControl("chkAll");

                foreach (GridViewRow row in grdAll.Rows)
                {
                    CheckBox chckrw = (CheckBox)row.FindControl("chk");

                    if (chckheader.Checked == true)
                    {
                        chckrw.Checked = true;
                    }
                    else
                    {
                        chckrw.Checked = false;
                    }
                }

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[1] { new DataColumn("TABLE_ALIAS") });
                foreach (GridViewRow row in grdAll.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string Datasetname = row.Cells[1].Text;
                            dt.Rows.Add(Datasetname);
                        }
                    }
                }
                grdSelected.DataSource = dt;
                grdSelected.DataBind();
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/errorpage.aspx", true);
            }
        }
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetCheckedRecord();
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/errorpage.aspx", true);
            }
        }
        protected void btnSelCol_Click(object sender, EventArgs e)
        {
            GetCheckedRecord();        
            Response.Redirect("~/SelectColumns.aspx");
        }
        #endregion Events Declarations

        #region Method Declarations
        public void GetDatasets()
        {
            objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
            DataSet ds = objRpt_BAL.GetDataSet();
            DataTable dt = ds.Tables[0];
            Session["Tables"] = grdAll.DataSource = dt;
            grdAll.DataBind();
        }
        public void GetCheckedRecord()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("TABLE_ALIAS") });
            foreach (GridViewRow row in grdAll.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string Datasetname = row.Cells[1].Text;
                        dt.Rows.Add(Datasetname);
                    }
                }
            }
            Session["Selection"] = grdSelected.DataSource = dt;
            Session["tblcnt"] = dt.Rows.Count;
            grdSelected.DataBind();
        }
        #endregion Method Declarations
    }
}