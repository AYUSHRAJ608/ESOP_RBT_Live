using BAL_REPORT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report_Builder
{
    public partial class SelectCriteria : System.Web.UI.Page
    {
        ReportBAL objRpt_BAL = new ReportBAL();
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetInitialRow();
                FillSortByDdl();
            }
        }

        #region Events Declarations
        protected void ddlAO_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCondition = (DropDownList)sender;

            //Added by Bhushan on 14-07-2021 to add new row
            int rowIndex = 0;
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DropDownList box0 = new DropDownList();
            DropDownList box1 = new DropDownList();
            DropDownList box2 = new DropDownList();
            TextBox box3 = new TextBox();
            DropDownList box4 = new DropDownList();
            for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
            {
                box0 = (DropDownList)grdFilters.Rows[rowIndex].Cells[0].FindControl("ddlTables");
                box1 = (DropDownList)grdFilters.Rows[rowIndex].Cells[1].FindControl("ddlFields");
                box2 = (DropDownList)grdFilters.Rows[rowIndex].Cells[2].FindControl("ddlCondition");
                box3 = (TextBox)grdFilters.Rows[rowIndex].Cells[3].FindControl("txtCriteria");
                box4 = (DropDownList)grdFilters.Rows[rowIndex].Cells[4].FindControl("ddlAO");
                rowIndex++;
            }
            if (ddlCondition != null && Convert.ToInt32(ddlCondition.SelectedValue) > 0)
            {
                if (box0.SelectedIndex > 0 && box1.SelectedIndex > 0 && box2.SelectedIndex > 0 && !string.IsNullOrEmpty(box3.Text.Trim()) && box4.SelectedIndex > 0)
                {
                    AddNewRowToGrid();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Please Fill the Details');", true);
                    box4.SelectedIndex = 0;
                }
            }
            //End

            //if (ddlCondition != null && Convert.ToInt32(ddlCondition.SelectedValue) > 0)
            //{
            //    AddNewRowToGrid();
            //}
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string query = Convert.ToString(Session["InLineQuery"]);
            string ruleQuery = " Where ";
            string sortQuery = " Order by ";
            string finalQuery = "";
            int i = 0;
            try
            {
                objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                foreach (GridViewRow row in grdFilters.Rows)
                {
                    DropDownList data_ddlTables = (DropDownList)row.FindControl("ddlTables");
                    DropDownList data_ddlFields = (DropDownList)row.FindControl("ddlFields");
                    DropDownList data_ddlCondition = (DropDownList)row.FindControl("ddlCondition");
                    TextBox data_txtCriteria = (TextBox)row.FindControl("txtCriteria");
                    DropDownList data_ddlAO = (DropDownList)row.FindControl("ddlAO");

                    if (data_ddlTables.SelectedIndex > 0)
                    {
                        DataSet dsType = objRpt_BAL.GetDataTypeForColumns(data_ddlTables.SelectedItem.Text, data_ddlFields.SelectedItem.Text);
                        DataTable dtType = dsType.Tables[0];

                        switch (dtType.Rows[0]["DATA_TYPE"].ToString())
                        {
                            case "CHAR":
                            case "VARCHAR2":
                            case "NVARCHAR2":
                            case "TIMESTAMP(6)":
                                data_txtCriteria.Text = string.Concat("'", data_txtCriteria.Text, "'");
                                break;
                            case "NUMBER":
                                data_txtCriteria.Text = data_txtCriteria.Text;
                                break;
                        }

                        if (data_ddlAO.Text != "0")
                        {
                            ruleQuery = ruleQuery + data_ddlTables.Text + "." + data_ddlFields.Text + " " + data_ddlCondition.Text + " " + data_txtCriteria.Text + " " + data_ddlAO.SelectedItem.Text + " ";
                        }
                        else
                        {
                            ruleQuery = ruleQuery + data_ddlTables.Text + "." + data_ddlFields.Text + " " + data_ddlCondition.Text + " " + data_txtCriteria.Text;
                        }
                        i++;
                    }
                }
                if (ddlTabs.SelectedIndex != 0 && ddlCols.SelectedIndex != 0)
                {
                    sortQuery = sortQuery + ddlTabs.Text + "." + ddlCols.Text + " " + ddlSort.SelectedValue;
                }
                else
                {
                    sortQuery = " ";
                }
                if (i > 0)
                {
                    finalQuery = query + ruleQuery + sortQuery;
                }
                else
                {
                    finalQuery = query;
                }
                Session["InLineQueryWithFilter"] = finalQuery.ToString().Trim();
                Response.Redirect("ShowReport.aspx");
            }
            catch (Exception ex)
            {
            }
        }
        protected void grdFilters_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)Session["Selection"];

                DropDownList ddlTable = (DropDownList)e.Row.FindControl("ddlTables");
                DropDownList ddlFields = (DropDownList)e.Row.FindControl("ddlFields");
                DropDownList ddlCondition = (DropDownList)e.Row.FindControl("ddlCondition");
                ddlTable.DataSource = dt;
                ddlTable.DataTextField = dt.Columns["TABLE_ALIAS"].ToString();
                ddlTable.DataValueField = dt.Columns["TABLE_NAME"].ToString();
                ddlTable.DataBind();
                ddlTable.Items.Insert(0, new ListItem("--Select--", "0"));

                if (Session["ddlFieldsValue"] != null)
                {
                    DataTable dt2 = (DataTable)Session["ddlFieldsValue"];
                    ddlFields.DataSource = dt2;

                    ddlFields.DataTextField = dt2.Columns["COLUMN_NAME"].ToString();
                    ddlFields.DataValueField = dt2.Columns["COLUMN_NAME"].ToString();
                    ddlFields.DataBind();
                    ddlFields.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
        }
        protected void ddlTable_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                DropDownList ddlFields1 = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddlFields1.NamingContainer;
                DropDownList ddlFields = (DropDownList)row.FindControl("ddlFields");

                DropDownList ddlTable1 = (DropDownList)sender;
                GridViewRow row1 = (GridViewRow)ddlTable1.NamingContainer;
                DropDownList ddlTable = (DropDownList)row1.FindControl("ddlTables");
                DropDownList ddlCondition = (DropDownList)row1.FindControl("ddlCondition");

                string ddlTableValue = Convert.ToString(Session["ddlTableValue"]);

                DataSet ds = objRpt_BAL.GetColumnsForDatasets(ddlTable.SelectedItem.Text);
                DataTable dt2 = ds.Tables[0];

                ddlFields.DataSource = dt2;
                Session["ddlFieldsValue"] = dt2;
                ddlFields.DataTextField = dt2.Columns["COLUMN_NAME"].ToString();
                ddlFields.DataValueField = dt2.Columns["COLUMN_NAME"].ToString();
                ddlFields.DataBind();
                ddlFields.Items.Insert(0, new ListItem("--Select--", "0"));

                DataTable dtCnd = new DataTable();
                dtCnd.Columns.Add("Text");
                dtCnd.Columns.Add("Value");

                dtCnd.Rows.Add("=", "=");
                dtCnd.Rows.Add("<>", "<>");
                dtCnd.Rows.Add(">", ">");
                dtCnd.Rows.Add("<", "<");
                dtCnd.Rows.Add(">=", ">=");
                dtCnd.Rows.Add("<=", "<=");
                dtCnd.Rows.Add("Like", "Like");
                dtCnd.Rows.Add("Not Like", "Not Like");

                ddlCondition.DataSource = dtCnd;
                ddlCondition.DataTextField = "Text";
                ddlCondition.DataValueField = "Value";
                ddlCondition.DataBind();
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/errorpage.aspx", true);
            }
        }
        protected void ddlTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
            DataSet ds = objRpt_BAL.GetColumnsForDatasets(ddlTabs.SelectedItem.Text);
            DataTable dt2 = ds.Tables[0];

            ddlCols.DataSource = dt2;
            ddlCols.DataTextField = dt2.Columns["COLUMN_NAME"].ToString();
            ddlCols.DataValueField = dt2.Columns["COLUMN_NAME"].ToString();
            ddlCols.DataBind();
            ddlCols.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        protected void ddlFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlFields1 = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlFields1.NamingContainer;
            DropDownList ddlTable = (DropDownList)row.FindControl("ddlTables");
            DropDownList ddlFields = (DropDownList)row.FindControl("ddlFields");
            TextBox txtCriteria = (TextBox)row.FindControl("txtCriteria");

            if (ddlFields.SelectedIndex != 0)
            {
                objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                DataSet dsType = objRpt_BAL.GetDataTypeForColumns(ddlTable.SelectedItem.Text, ddlFields.SelectedItem.Text);
                DataTable dtType = dsType.Tables[0];

                switch (dtType.Rows[0]["DATA_TYPE"].ToString())
                {
                    case "CHAR":
                    case "VARCHAR2":
                    case "NVARCHAR2":
                    case "NUMBER":
                        txtCriteria.TextMode = TextBoxMode.SingleLine;
                        break;

                    case "TIMESTAMP(6)":
                        txtCriteria.TextMode = TextBoxMode.Date;
                        break;
                }
            }
        }
        protected void grdFilters_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            dt.Rows[index].Delete();
            ViewState["CurrentTable"] = dt;
            grdFilters.DataSource = (DataTable)ViewState["CurrentTable"];
            grdFilters.DataBind();
            SetPreviousData();
        }
        #endregion Events Declarations

        #region Method Declarations
        public void SetInitialRow()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Tables", typeof(string)));
            dt.Columns.Add(new DataColumn("Fields", typeof(string)));
            dt.Columns.Add(new DataColumn("Condition", typeof(string)));
            dt.Columns.Add(new DataColumn("Criteria", typeof(string)));
            dt.Columns.Add(new DataColumn("And/Or", typeof(string)));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            grdFilters.DataSource = dt;
            grdFilters.DataBind();
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        DropDownList box0 = (DropDownList)grdFilters.Rows[rowIndex].Cells[0].FindControl("ddlTables");
                        DropDownList box1 = (DropDownList)grdFilters.Rows[rowIndex].Cells[1].FindControl("ddlFields");
                        DropDownList box2 = (DropDownList)grdFilters.Rows[rowIndex].Cells[2].FindControl("ddlCondition");
                        TextBox box3 = (TextBox)grdFilters.Rows[rowIndex].Cells[3].FindControl("txtCriteria");
                        DropDownList box4 = (DropDownList)grdFilters.Rows[rowIndex].Cells[4].FindControl("ddlAO");

                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[i - 1]["Tables"] = box0.Text;
                        dtCurrentTable.Rows[i - 1]["Fields"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Condition"] = box2.SelectedItem.Text;
                        dtCurrentTable.Rows[i - 1]["Criteria"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["And/Or"] = box4.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable"] = dtCurrentTable;
                    grdFilters.DataSource = dtCurrentTable;
                    grdFilters.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            try
            {
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DropDownList box0 = (DropDownList)grdFilters.Rows[rowIndex].Cells[0].FindControl("ddlTables");
                            DropDownList box1 = (DropDownList)grdFilters.Rows[rowIndex].Cells[1].FindControl("ddlFields");
                            DropDownList box2 = (DropDownList)grdFilters.Rows[rowIndex].Cells[2].FindControl("ddlCondition");
                            TextBox box3 = (TextBox)grdFilters.Rows[rowIndex].Cells[3].FindControl("txtCriteria");
                            DropDownList box4 = (DropDownList)grdFilters.Rows[rowIndex].Cells[4].FindControl("ddlAO");

                            box0.Text = dt.Rows[i]["Tables"].ToString();
                            box1.Text = dt.Rows[i]["Fields"].ToString();
                            box2.Text = dt.Rows[i]["Condition"].ToString();
                            box4.Text = dt.Rows[i]["And/Or"].ToString();

                            objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                            DataSet dsType = objRpt_BAL.GetDataTypeForColumns(box0.SelectedItem.Text, box1.SelectedItem.Text);
                            DataTable dtType = dsType.Tables[0];

                            if (dtType.Rows.Count > 0)
                            {
                                switch (dtType.Rows[0]["DATA_TYPE"].ToString())
                                {
                                    case "CHAR":
                                    case "VARCHAR2":
                                    case "NVARCHAR2":
                                    case "NUMBER":
                                        box3.Text = dt.Rows[i]["Criteria"].ToString();
                                        break;

                                    case "TIMESTAMP(6)":
                                        box3.Text = Convert.ToDateTime(dt.Rows[i]["Criteria"]).ToString("dd-MM-yyyy");
                                        break;
                                }
                            }
                            rowIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void FillSortByDdl()
        {
            DataTable dt = (DataTable)Session["Selection"];

            ddlTabs.DataSource = dt;
            ddlTabs.DataTextField = dt.Columns["TABLE_ALIAS"].ToString();
            ddlTabs.DataValueField = dt.Columns["TABLE_NAME"].ToString();
            ddlTabs.DataBind();
            ddlTabs.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        #endregion Method Declarations
    }
}