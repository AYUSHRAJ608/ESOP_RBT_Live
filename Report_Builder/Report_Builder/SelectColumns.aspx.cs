using BAL_REPORT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report_Builder
{
    public partial class SelectColumns : System.Web.UI.Page
    {
        ReportBAL objRpt_BAL = new ReportBAL();
        DataTable dt_tabName;
        DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                GetColumnsForDatasets();
            }
        }

        #region Events Declarations
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = GetCheckedRecord();
                if (ViewState["SelColumnFinal"] != null)
                {
                    dt.Merge((DataTable)ViewState["SelColumnFinal"]);
                }
                grdSelColumns.DataSource = dt;
                grdSelColumns.DataBind();
                ViewState["SelColumn"] = dt;
                grdSelColumns.Columns[2].Visible = false;
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/errorpage.aspx", true);
            }
        }
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chckheader = (CheckBox)grdColumns.HeaderRow.FindControl("chkAll");

                foreach (GridViewRow row in grdColumns.Rows)
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
                dt.Columns.AddRange(new DataColumn[1] { new DataColumn("COLUMN_NAME") });
                foreach (GridViewRow row in grdColumns.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string Datasetname = ddlTables.SelectedItem.Value + "." + row.Cells[1].Text; //row.Cells[1].Text;
                            dt.Rows.Add(Datasetname);
                        }
                    }
                }
                if (ViewState["SelColumnFinal"] != null)
                {
                    dt.Merge((DataTable)ViewState["SelColumnFinal"]);
                }
                grdSelColumns.DataSource = dt;
                grdSelColumns.DataBind();
                ViewState["SelColumn"] = dt;
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/errorpage.aspx", true);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["Selection"] != null)
            {
                //objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                //DataTable dt = (DataTable)Session["Selection"];
                //StringBuilder sb = new StringBuilder();
                //int n = grdSelColumns.Rows.Count;
                //ArrayList arlist = new ArrayList();
                //int i;

                //for (i = 0; i <= n - 1; i++)
                //{                   
                //    string a = grdSelColumns.Rows[i].Cells[1].Text;
                //    TextBox TextBox1 = (grdSelColumns.Rows[i].FindControl("txtAlias") as TextBox);

                //    if (TextBox1.Text != "" || TextBox1.Text != string.Empty)
                //    {
                //        string b = a + " as " + '"' + TextBox1.Text + '"';
                //        sb.Append(b + ",");
                //    }
                //    else
                //    {
                //        string b = a;
                //        sb.Append(b + ",");
                //    }

                //}
                //Session["SB"] = sb.ToString().TrimEnd(',');

                //DataTable[] dtTempCol = new DataTable[4];
                //DataTable dtFinalCol = new DataTable();

                //DataSet ds;
                //string squery = string.Empty;
                //string col1,col2,col3,col4 = string.Empty;

                //string[] jc = new string[4];
                //int tblcnt = (int)Session["tblcnt"];
                //if (tblcnt == 1)
                //{
                //    jc[0] = dt.Rows[0]["TABLE_NAME"].ToString();
                //    squery = "Select " + Session["SB"].ToString() + " from " + jc[0];
                //    Session["InLineQuery"] = squery;
                //    //ds = objRpt_BAL.ShowReport(Session["SB"].ToString(), jc, tblcnt);
                //}
                //else if (tblcnt == 2)
                //{
                //    jc[0] = dt.Rows[0]["TABLE_NAME"].ToString();
                //    jc[1] = dt.Rows[1]["TABLE_NAME"].ToString();
                //    dtTempCol[0] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[0]["TABLE_ALIAS"].ToString()).Tables[0];
                //    dtTempCol[1] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[1]["TABLE_ALIAS"].ToString()).Tables[0];
                //    dtFinalCol = MergeTable(dtTempCol, tblcnt);
                //    col1 = GetPrimaryKey(dtFinalCol);
                //    col2 = GetForeignKey(dtTempCol[1]);
                //    squery = "Select " + Session["SB"].ToString() + " from " + jc[0] + " left join " + jc[1] + " on " + jc[0] + "." + col1 + " = " + jc[1] + "." + col2;
                //    Session["InLineQuery"] = squery;
                //    //ds = objRpt_BAL.ShowReport(Session["SB"].ToString(), jc, tblcnt);
                //}
                //else if (tblcnt == 3)
                //{
                //    jc[0] = dt.Rows[0]["TABLE_NAME"].ToString();
                //    jc[1] = dt.Rows[1]["TABLE_NAME"].ToString();
                //    jc[2] = dt.Rows[2]["TABLE_NAME"].ToString();
                //    dtTempCol[0] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[0]["TABLE_ALIAS"].ToString()).Tables[0];
                //    dtTempCol[1] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[1]["TABLE_ALIAS"].ToString()).Tables[0];
                //    dtTempCol[2] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[2]["TABLE_ALIAS"].ToString()).Tables[0];
                //    dtFinalCol = MergeTable(dtTempCol, tblcnt);
                //    col1 = GetPrimaryKey(dtFinalCol);
                //    col2 = GetForeignKey(dtTempCol[1]);
                //    col3 = GetForeignKey(dtTempCol[2]);
                //    squery = "Select " + Session["SB"].ToString() + " from " + jc[0] + " left join " + jc[1] + " on " + jc[0] + "." + col1 + " = " + jc[1] + "." + col2 + " left join " + jc[2] + " on " + jc[0] + "." + col1 + " = " + jc[2] + "." + col3;
                //    Session["InLineQuery"] = squery;
                //    //ds = objRpt_BAL.ShowReport(Session["SB"].ToString(), jc, tblcnt);
                //}
                //else if (tblcnt == 4)
                //{
                //    jc[0] = dt.Rows[0]["TABLE_NAME"].ToString();
                //    jc[1] = dt.Rows[1]["TABLE_NAME"].ToString();
                //    jc[2] = dt.Rows[2]["TABLE_NAME"].ToString();
                //    jc[3] = dt.Rows[3]["TABLE_NAME"].ToString();
                //    dtTempCol[0] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[0]["TABLE_ALIAS"].ToString()).Tables[0];
                //    dtTempCol[1] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[1]["TABLE_ALIAS"].ToString()).Tables[0];
                //    dtTempCol[2] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[2]["TABLE_ALIAS"].ToString()).Tables[0];
                //    dtTempCol[3] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[3]["TABLE_ALIAS"].ToString()).Tables[0];
                //    dtFinalCol = MergeTable(dtTempCol, tblcnt);
                //    col1 = GetPrimaryKey(dtFinalCol);
                //    col2 = GetForeignKey(dtTempCol[1]);
                //    col3 = GetForeignKey(dtTempCol[2]);
                //    col4 = GetForeignKey(dtTempCol[3]);
                //    squery = "Select " + Session["SB"].ToString() + " from " + jc[0] + " left join " + jc[1] + " on " + jc[0] + "." + col1 + " = " + jc[1] + "." + col2 + " left join " + jc[2] + " on " + jc[0] + "." + col1 + " = " + jc[2] + "." + col3 + " left join " + jc[3] + " on " + jc[0] + "." + col1 + " = " + jc[3] + "." + col4;
                //    Session["InLineQuery"] = squery;
                //    //ds = objRpt_BAL.ShowReport(Session["SB"].ToString(), jc, tblcnt);
                //}
                FunCreateColumn();
                Response.Redirect("~/SelectCriteria.aspx", false);
            }
        }
        protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetColumnsForDatasets();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            DataTable dtCheck = GetCheckedRecord();
            if (dtCheck.Rows.Count > 0)
            {
                int[] locationIds = (from p in Request.Form["LocationId"].Split(',')
                                     select int.Parse(p)).ToArray();

                string[] mytitles = new string[grdSelColumns.Rows.Count];
                for (int c = 0; c < grdSelColumns.Rows.Count; c++)
                {
                    int val = locationIds[c] - 1;
                    mytitles[c] = Convert.ToString(grdSelColumns.Rows[val].Cells[1].Text);
                }

                string[] pref = new string[grdSelColumns.Rows.Count];
                for (int c1 = 0; c1 < grdSelColumns.Rows.Count; c1++)
                {
                    int val = locationIds[c1] - 1;
                    pref[c1] = Convert.ToString(grdSelColumns.Rows[val].Cells[2].Text);
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("COLUMN_NAME");
                dt.Columns.Add("ALIAS");

                for (int j = 0; j < grdSelColumns.Rows.Count; j++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = locationIds[j];
                    dr[1] = mytitles[j];
                    dr[2] = pref[j];
                    dt.Rows.Add(dr);
                }
                grdSelColumns.DataSource = dt;
                grdSelColumns.DataBind();
                grdSelColumns.Columns[2].Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Columns Updated Successfully!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('CPlease select atleast one column');", true);
            }
        }

        protected void BtnShow_Click(object sender, EventArgs e)
        {
            if (Session["Selection"] != null)
            {
                FunCreateColumn();
                Session["InLineQueryWithFilter"] = Session["InLineQuery"].ToString();
                Response.Redirect("~/ShowReport.aspx", false);
            }
        }
        #endregion Events Declarations

        #region Method Declarations
        public void BindDropDown()
        {
            DataTable dt = (DataTable)Session["Selection"];
            DataTable dtTab = (DataTable)Session["Tables"];

            if (!(dt.Columns.Contains("TABLE_NAME")))
            {
                dt_tabName = new DataTable();
                DataColumn newCo1l = new DataColumn("TABLE_NAME", typeof(string));
                newCo1l.AllowDBNull = true;
                dt_tabName.Columns.Add(newCo1l);

                DataTable newDt = new DataTable();
                DataColumn newCol123 = new DataColumn("TABLE_ALIAS", typeof(string));
                DataColumn newCol1234 = new DataColumn("TABLE_NAME", typeof(string));

                newCol123.AllowDBNull = true;
                newCol1234.AllowDBNull = true;

                newDt.Columns.Add(newCol123);
                newDt.Columns.Add(newCol1234);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var res = from f in dtTab.AsEnumerable()
                              where f.Field<string>("TABLE_ALIAS") == dt.Rows[i]["TABLE_ALIAS"].ToString()
                              select f.Field<string>("TABLE_NAME");

                    dt_tabName.Rows.Add(res.FirstOrDefault()?.ToString());

                    DataRow dr = newDt.NewRow();
                    dr["TABLE_ALIAS"] = dt.Rows[i]["TABLE_ALIAS"].ToString();
                    dr["TABLE_NAME"] = dt_tabName.Rows[i]["TABLE_NAME"].ToString();
                    newDt.Rows.Add(dr);
                }
                dt = newDt;
                Session["Selection"] = dt;
            }

            ddlTables.DataSource = dt;
            ddlTables.DataTextField = dt.Columns["TABLE_ALIAS"].ToString();
            ddlTables.DataValueField = dt.Columns["TABLE_NAME"].ToString();
            ddlTables.DataBind();
            ddlTables.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void GetColumnsForDatasets()
        {
            objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
            DataSet ds = objRpt_BAL.GetColumnsForDatasets(ddlTables.SelectedItem.Text);
            DataTable dt2 = ds.Tables[0];
            grdColumns.UseAccessibleHeader = true;
            grdColumns.DataSource = dt2;
            grdColumns.DataBind();

            dt2.Rows.Clear();
            if (ViewState["SelColumn"] != null)
            {
                grdSelColumns.DataSource = (DataTable)ViewState["SelColumn"];
                grdSelColumns.DataBind();
                ViewState["SelColumnFinal"] = (DataTable)ViewState["SelColumn"];
            }
            else
            {
                grdSelColumns.DataSource = dt2;
                grdSelColumns.DataBind();
            }
            grdSelColumns.Columns[2].Visible = false;
        }
        public DataTable GetCheckedRecord()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("COLUMN_NAME") });

            foreach (GridViewRow row in grdColumns.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string Datasetname = ddlTables.SelectedItem.Value + "." + row.Cells[1].Text;
                        dt.Rows.Add(Datasetname);
                    }
                }
            }
            return dt;
        }
        public string GetPrimaryKey(DataTable dt)
        {
            string col1;
            var value = from f in dt.AsEnumerable()
                        where f.Field<string>("Column_TYPE") == "PK"
                        select f.Field<string>("column_name");
            return col1 = value.FirstOrDefault()?.ToString();
        }
        public string GetForeignKey(DataTable dt)
        {
            string col2;
            var value = from f in dt.AsEnumerable()
                       where f.Field<string>("Column_TYPE2") == "FK"
                       select f.Field<string>("column_name");
            return col2 = value.FirstOrDefault()?.ToString();
        }
        public DataTable MergeTable(DataTable[] dt,int count)
        {
            DataTable dtFinal = new DataTable();
            if (dt != null)
            {
                switch(count)
                {
                    case 2:
                        dt[0].Merge(dt[1]);
                        dt[0].AcceptChanges();
                        dtFinal = dt[0];
                        break;
                    case 3:
                        dt[0].Merge(dt[1]);
                        dt[0].Merge(dt[2]);
                        dt[0].AcceptChanges();
                        dtFinal = dt[0];
                        break;
                    case 4:
                        dt[0].Merge(dt[1]);
                        dt[0].Merge(dt[2]);
                        dt[0].Merge(dt[3]);
                        dt[0].AcceptChanges();
                        dtFinal = dt[0];
                        break;
                }
            }
            return dtFinal;
        }
        public void FunCreateColumn()
        {
            objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
            DataTable dt = (DataTable)Session["Selection"];
            StringBuilder sb = new StringBuilder();
            int n = grdSelColumns.Rows.Count;
            ArrayList arlist = new ArrayList();
            int i;

            for (i = 0; i <= n - 1; i++)
            {
                string a = grdSelColumns.Rows[i].Cells[1].Text;
                TextBox TextBox1 = (grdSelColumns.Rows[i].FindControl("txtAlias") as TextBox);

                if (TextBox1.Text != "" || TextBox1.Text != string.Empty)
                {
                    string b = a + " as " + '"' + TextBox1.Text + '"';
                    sb.Append(b + ",");
                }
                else
                {
                    string b = a;
                    sb.Append(b + ",");
                }

            }
            Session["SB"] = sb.ToString().TrimEnd(',');

            DataTable[] dtTempCol = new DataTable[4];
            DataTable dtFinalCol = new DataTable();

            DataSet ds;
            string squery = string.Empty;
            string col1, col2, col3, col4 = string.Empty;

            string[] jc = new string[4];
            int tblcnt = (int)Session["tblcnt"];
            if (tblcnt == 1)
            {
                jc[0] = dt.Rows[0]["TABLE_NAME"].ToString();
                squery = "Select " + Session["SB"].ToString() + " from " + jc[0];
                Session["InLineQuery"] = squery;
                //ds = objRpt_BAL.ShowReport(Session["SB"].ToString(), jc, tblcnt);
            }
            else if (tblcnt == 2)
            {
                jc[0] = dt.Rows[0]["TABLE_NAME"].ToString();
                jc[1] = dt.Rows[1]["TABLE_NAME"].ToString();
                dtTempCol[0] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[0]["TABLE_ALIAS"].ToString()).Tables[0];
                dtTempCol[1] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[1]["TABLE_ALIAS"].ToString()).Tables[0];
                dtFinalCol = MergeTable(dtTempCol, tblcnt);
                col1 = GetPrimaryKey(dtFinalCol);
                col2 = GetForeignKey(dtTempCol[1]);
                squery = "Select " + Session["SB"].ToString() + " from " + jc[0] + " left join " + jc[1] + " on " + jc[0] + "." + col1 + " = " + jc[1] + "." + col2;
                Session["InLineQuery"] = squery;
                //ds = objRpt_BAL.ShowReport(Session["SB"].ToString(), jc, tblcnt);
            }
            else if (tblcnt == 3)
            {
                jc[0] = dt.Rows[0]["TABLE_NAME"].ToString();
                jc[1] = dt.Rows[1]["TABLE_NAME"].ToString();
                jc[2] = dt.Rows[2]["TABLE_NAME"].ToString();
                dtTempCol[0] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[0]["TABLE_ALIAS"].ToString()).Tables[0];
                dtTempCol[1] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[1]["TABLE_ALIAS"].ToString()).Tables[0];
                dtTempCol[2] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[2]["TABLE_ALIAS"].ToString()).Tables[0];
                dtFinalCol = MergeTable(dtTempCol, tblcnt);
                col1 = GetPrimaryKey(dtFinalCol);
                col2 = GetForeignKey(dtTempCol[1]);
                col3 = GetForeignKey(dtTempCol[2]);
                squery = "Select " + Session["SB"].ToString() + " from " + jc[0] + " left join " + jc[1] + " on " + jc[0] + "." + col1 + " = " + jc[1] + "." + col2 + " left join " + jc[2] + " on " + jc[0] + "." + col1 + " = " + jc[2] + "." + col3;
                Session["InLineQuery"] = squery;
                //ds = objRpt_BAL.ShowReport(Session["SB"].ToString(), jc, tblcnt);
            }
            else if (tblcnt == 4)
            {
                jc[0] = dt.Rows[0]["TABLE_NAME"].ToString();
                jc[1] = dt.Rows[1]["TABLE_NAME"].ToString();
                jc[2] = dt.Rows[2]["TABLE_NAME"].ToString();
                jc[3] = dt.Rows[3]["TABLE_NAME"].ToString();
                dtTempCol[0] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[0]["TABLE_ALIAS"].ToString()).Tables[0];
                dtTempCol[1] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[1]["TABLE_ALIAS"].ToString()).Tables[0];
                dtTempCol[2] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[2]["TABLE_ALIAS"].ToString()).Tables[0];
                dtTempCol[3] = objRpt_BAL.GetColumnsForDatasets(dt.Rows[3]["TABLE_ALIAS"].ToString()).Tables[0];
                dtFinalCol = MergeTable(dtTempCol, tblcnt);
                col1 = GetPrimaryKey(dtFinalCol);
                col2 = GetForeignKey(dtTempCol[1]);
                col3 = GetForeignKey(dtTempCol[2]);
                col4 = GetForeignKey(dtTempCol[3]);
                squery = "Select " + Session["SB"].ToString() + " from " + jc[0] + " left join " + jc[1] + " on " + jc[0] + "." + col1 + " = " + jc[1] + "." + col2 + " left join " + jc[2] + " on " + jc[0] + "." + col1 + " = " + jc[2] + "." + col3 + " left join " + jc[3] + " on " + jc[0] + "." + col1 + " = " + jc[3] + "." + col4;
                Session["InLineQuery"] = squery;
                //ds = objRpt_BAL.ShowReport(Session["SB"].ToString(), jc, tblcnt);
            }
        }
        #endregion Method Declaration
    }
}