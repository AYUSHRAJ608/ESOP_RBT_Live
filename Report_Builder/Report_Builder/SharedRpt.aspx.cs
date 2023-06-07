using BAL_REPORT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity_REPORT;

namespace Report_Builder
{
    public partial class SharedRpt : System.Web.UI.Page
    {
        EReport objRS_E = new EReport();
        ReportBAL objRpt_BAL = new ReportBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUsers();
                BindRpts();
                lstBoxFilter.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "callJS", "callJsForSumoSel()", true);
            }
        }

        #region Method Declarations
        public void BindUsers()
        {
            objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
            DataSet ds = objRpt_BAL.FillUsers();
            lstBoxFilter.SelectionMode = ListSelectionMode.Multiple;
            lstBoxFilter.DataSource = ds.Tables[0];
            lstBoxFilter.DataTextField = "EMP_NAME";
            lstBoxFilter.DataValueField = "ECODE";
            lstBoxFilter.DataBind();

            ListBx_emp.DataSource = ds.Tables[0];
            ListBx_emp.DataTextField = "EMP_NAME";
            ListBx_emp.DataValueField = "ECODE";
            ListBx_emp.DataBind();
            ScriptManager.RegisterStartupScript(this, GetType(), "callJS", "callJsForSumoSel()", true);

        }
        public void BindRpts()
        {
            objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
            DataSet ds = objRpt_BAL.FillRpts();

            lstBoxFilter.SelectionMode = ListSelectionMode.Single;

            lstBoxFilter.DataSource = ds.Tables[0];
            lstBoxFilter.DataTextField = "report_name";
            lstBoxFilter.DataValueField = "id";
            lstBoxFilter.DataBind();

            ListBx_Rpt.DataSource = ds.Tables[0];
            ListBx_Rpt.DataTextField = "report_name";
            ListBx_Rpt.DataValueField = "id";
            ListBx_Rpt.DataBind();
            ScriptManager.RegisterStartupScript(this, GetType(), "callJS", "callJsForSumoSel()", true);
        }
        protected string btnGetSelectedValues(ListBox listBxName)
        {
            string listValues;
            string selectedValues = string.Empty;
            foreach (ListItem li in listBxName.Items)
            {
                if (li.Selected == true)
                {
                    selectedValues += li.Value + ",";
                }
            }

            if (selectedValues != "")
            {
                listValues = selectedValues.ToString().Remove(selectedValues.LastIndexOf(","), 1);
            }
            else
            {
                listValues = "";
            }
            return listValues;
        }

        //public void BindDepartments()
        //{
        //    objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
        //    DataSet ds = objRpt_BAL.FillDepartments();

        //    ddlDepartment.DataSource = ds.Tables[0];
        //    ddlDepartment.DataTextField = "DEPARTMENT";
        //    ddlDepartment.DataValueField = "ID";
        //    ddlDepartment.DataBind();
        //    ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
        //}
        //public void BindRoles()
        //{
        //    objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
        //    DataSet ds = objRpt_BAL.FillRoles();

        //    ddlRoles.DataSource = ds.Tables[0];
        //    ddlRoles.DataTextField = "ROLENAME";
        //    ddlRoles.DataValueField = "ROLEID";
        //    ddlRoles.DataBind();
        //    ddlRoles.Items.Insert(0, new ListItem("--Select--", "0"));
        //}

        #endregion Method Declarations

        #region Events Declarations
        protected void btnAddShareRecord_Click(object sender, EventArgs e)
        {
            ListBx_emp.ClearSelection();
            ListBx_Rpt.ClearSelection();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal(); callJsForSumoSel();", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                String Str = "Please select at least one Report to share and try again.";
                String StrErrEmpName = "Please Select at least one Employee Name.";
                String rec = null;

                if (rec != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "callJS", "callJsForSumoSel()", true);
                }
                else
                {
                    for (int i = 0; i < ListBx_Rpt.Items.Count; i++)
                    {
                        if (ListBx_Rpt.Items[i].Selected == true)
                        {
                            Str = null;
                            break;
                        }
                    }

                    for (int i = 0; i < ListBx_emp.Items.Count; i++)
                    {
                        if (ListBx_emp.Items[i].Selected == true)
                        {
                            StrErrEmpName = null;
                            break;
                        }
                    }

                    ////    RS = Report Share   ////

                    if (Str == null && StrErrEmpName == null)
                    {
                        objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                        DataSet ds = objRpt_BAL.getMaxRSID();
                        int Shareid = Convert.ToInt32(ds.Tables[0].Rows[0]["RS_SHARE_ID"].ToString());
                        string strId = "";
                        for (int i = 0; i < ListBx_Rpt.Items.Count; i++)
                        {
                            if (ListBx_Rpt.Items[i].Selected == true)
                            {
                                Str = "";
                                strId = ListBx_Rpt.Items[i].Value;
                                objRS_E.ReportID = Convert.ToInt32(strId);
                                objRS_E.shareID = Shareid;
                                ////// ADDING USER
                                string Ecodestr = "";
                                for (int k = 0; k < ListBx_emp.Items.Count; k++)
                                {
                                    if (ListBx_emp.Items[k].Selected == true)
                                    {
                                        Ecodestr = ListBx_emp.Items[k].Value;
                                        objRS_E.empCode = Convert.ToInt32(Ecodestr);
                                        objRpt_BAL.addShareRpt(objRS_E);
                                        StrErrEmpName = null;
                                    }
                                }
                            }
                        }
                        Response.Write("<script language='javascript'>window.alert('Report Shared Successfully');window.location='SharedRpt.aspx';</script>");
                        //Response.Redirect("SharedRpt.aspx");
                    }
                    else
                    {
                        string errorString = Str + StrErrEmpName;
                        ClientScript.RegisterStartupScript(this.GetType(), "myalertVal", "alert('" + errorString + "');", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "callJS", "callJsForSumoSel()", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "callJS", "callJsForSumoSel()", true);
            }
        }
        protected void lstFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBoxFilter.Visible = true;
            if (lstFilterBy1.SelectedItem.Text.ToString() == "Users")
            {
                BindUsers();
            }
            else
            {
                BindRpts();
            }
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Grid_ShowReport.DataSource = null;
            Grid_ShowReport.DataBind();
            if (lstFilterBy1.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalertVal", "alert('Please select one option to Filter Records.');", true);
                Grid_ShowReport.DataSource = null;
                Grid_ShowReport.DataBind();
            }
            else
            {
                string filterbyValues = btnGetSelectedValues(lstBoxFilter);
                objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                DataTable dt = new DataTable();
                if (lstFilterBy1.SelectedItem.Text.ToString() == "Users")
                {
                    DataSet ds = objRpt_BAL.GetFilterData_ByUsers(filterbyValues);
                    dt = ds.Tables[0];
                }
                else
                {
                    DataSet ds = objRpt_BAL.GetFilterData_ByReport(filterbyValues);
                    dt = ds.Tables[0];
                }
                if (dt.Rows.Count > 0)
                {
                    ViewState["Share"] = Grid_ShowReport.DataSource = dt;
                    Grid_ShowReport.DataBind();
                    Grid_ShowReport.UseAccessibleHeader = true;
                    Grid_ShowReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    Grid_ShowReport.DataSource = null;
                    Grid_ShowReport.DataBind();
                }
            }
        }
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            Grid_ShowReport.DataSource = null;
            Grid_ShowReport.DataBind();

            lstFilterBy1.ClearSelection();
            lstBoxFilter.Visible = false;

            string filterbyValues = btnGetSelectedValues(lstBoxFilter);
            objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
            DataTable dt = new DataTable();
            DataSet ds = objRpt_BAL.GetFilterData_All();
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                Grid_ShowReport.DataSource = dt;
                Grid_ShowReport.DataBind();
                Grid_ShowReport.UseAccessibleHeader = true;
                Grid_ShowReport.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void Grid_ShowReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkbAction = (CheckBox)e.Row.FindControl("chkbAction");
                    string value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RS_IFSHARED"));

                    if (value == "Y")
                    {
                        chkbAction.Checked = true;
                    }
                    else
                    {
                        chkbAction.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void chkbAction_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkbAction = (CheckBox)sender;
            if (chkbAction.Checked == true)
            {
                //GridViewRow parentRow = chkbAction.NamingContainer as GridViewRow;
                //Label lblrsid = parentRow.FindControl("lblrsid") as Label;
                //Label lblRS_SHARE_ID = parentRow.FindControl("lblRS_SHARE_ID") as Label;

                //int rsId = Convert.ToInt32(lblrsid.Text);
                //int shareid = Convert.ToInt32(lblRS_SHARE_ID.Text);
                //string Action = "Y";
                //DataSet ds = objRM_BAL.setRoleStatus(rsId, shareid, Action);
                //bindRM_Grid();
            }
            else
            {
                GridViewRow parentRow = chkbAction.NamingContainer as GridViewRow;
                Label lblrsid = parentRow.FindControl("lblrsid") as Label;
                Label lblRS_SHARE_ID = parentRow.FindControl("lblRS_SHARE_ID") as Label;

                int rsId = Convert.ToInt32(lblrsid.Text);
                int shareid = Convert.ToInt32(lblRS_SHARE_ID.Text);
                string Action = "N";
                objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());
                DataSet ds = objRpt_BAL.setRptStatus(rsId, shareid, Action);
                if (lstFilterBy1.SelectedValue == "2")
                {
                    btnFilter_Click(sender, e);
                }
                else
                {
                    btnShowAll_Click(sender, e);
                }
            }
        }
        protected void Grid_ShowReport_PreRender(object sender, EventArgs e)
        {
            DataTable ds = (DataTable)ViewState["Share"];
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

        #endregion Events Declarations
    }
}