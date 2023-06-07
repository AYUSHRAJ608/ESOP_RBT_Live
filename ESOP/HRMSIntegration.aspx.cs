using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESOP
{
    public partial class HRMSIntegration : System.Web.UI.Page
    {
        HRMSIntegrationBO emp = new HRMSIntegrationBO();
        HRMS_BAL objHRMS_BAL = new HRMS_BAL();
        cEmployeeEntityRequest objEmprequest = new cEmployeeEntityRequest();
        HRMS_BAL objGoalsAdminBAL = new HRMS_BAL();
        String basic = "show";
        GrandCreationBAL objbal = new GrandCreationBAL();
        GrandCreationBO objbo = new GrandCreationBO();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                btnexcelExport.Attributes.Add("style", "display:none");

                FetchEmployeeData();
                FillUserName();
                GETMERGEEMPCHECK();
            }
        }
        protected void GETMERGEEMPCHECK()
        {
            DataSet ds = new DataSet();
            ds = objHRMS_BAL.GETMERGEEMPCHECK();
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        myonoffswitch1.Checked = true;
                    }
                    else
                    {
                        myonoffswitch1.Checked = false;
                    }
                }
                else
                {
                    myonoffswitch1.Checked = false;
                }
            }
            else
            {
                myonoffswitch1.Checked = false;
            }

            //if(myonoffswitch1.Checked)
            //{
            //    btnImport.Visible = false;
            //    tablediv.Visible = false;
            //}
            //else
            //{
            //    btnImport.Visible = true;
            //    tablediv.Visible = true;
            //    GETMERGEEMPDATA();
            //}

            //if (!myonoffswitch1.Checked)
            //{
            //    btnImport.Visible = true;
            //}
            //else
            //{
            //    btnImport.Visible = false;
            //}
        }
        protected void FillUserName()
        {
            try
            {
                //objbo.Role_ID = Convert.ToInt32(ddlUser.SelectedItem.Value);
                //DataSet ds = objbal.GetUserDropDown(objbo);
                //ddlUserName.DataSource = ds.Tables[0];
                //if (ds.Tables.Count > 0)
                //{
                //    ddlUserName.DataTextField = "USERNAME";
                //    ddlUserName.DataValueField = "USERID";
                //    ddlUserName.DataBind();
                //    //ddlUserName.Items.Insert(0, new ListItem("Select ROLE", "0"));
                //}

                //objbo.Role_ID = Convert.ToInt32(ddlUser.SelectedItem.Value);
                DataSet ds = objbal.GetUserDropDown(objbo);

                if (ds.Tables.Count > 1)
                {
                    ddlDept.DataSource = ds.Tables[1];
                    ddlDept.DataTextField = "department";
                    ddlDept.DataValueField = "ID";
                    ddlDept.DataBind();
                    ddlDept.Items.Insert(0, new ListItem("Select", "0"));
                
                    ddlBand.DataSource = ds.Tables[2];
                    ddlBand.DataTextField = "bands";
                    ddlBand.DataValueField = "ID";
                    ddlBand.DataBind();
                    ddlBand.Items.Insert(0, new ListItem("Select", "0"));
                
                //if (ds.Tables.Count > 1)
                //{
                //    ddlDesignation.DataSource = ds.Tables[4];
                //    ddlDesignation.DataTextField = "designation";
                //    ddlDesignation.DataValueField = "ID";
                //    ddlDesignation.DataBind();
                //    ddlDesignation.Items.Insert(0, new ListItem("", "0"));
                //}

                    ddlLocation.DataSource = ds.Tables[3];
                    ddlLocation.DataTextField = "location";
                    ddlLocation.DataValueField = "ID";
                    ddlLocation.DataBind();
                    ddlLocation.Items.Insert(0, new ListItem("Select", "0"));

                    ddlFunction.DataSource = ds.Tables[6];
                    ddlFunction.DataTextField = "FUNCTION";
                    ddlFunction.DataValueField = "ID";
                    ddlFunction.DataBind();
                    ddlFunction.Items.Insert(0, new ListItem("Select", "0"));

                    ddlCC.DataSource = ds.Tables[7];
                    ddlCC.DataTextField = "COST_CENTRE";
                    ddlCC.DataValueField = "ID";
                    ddlCC.DataBind();
                    ddlCC.Items.Insert(0, new ListItem("Select", "0"));
                }

                //if (ds.Tables[5].Rows.Count > 1)
                //{
                //    ddlRole.DataSource = ds.Tables[5];
                //    ddlRole.DataTextField = "ROLENAME";
                //    ddlRole.DataValueField = "ROLEID";
                //    ddlRole.DataBind();
                //    ddlRole.Items.Insert(0, new ListItem("", "0"));
                //}
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void myonoffswitch1_CheckedChanged(object sender, EventArgs e)
        {
            string flag = "0";
            if (myonoffswitch1.Checked)
            {
                flag = "1";
            }
            int result = objHRMS_BAL.UPDATEMERGEEMPCHECK(flag, Convert.ToString(Session["EmpId"]));
            if (result == 1)
            {
                //lblmsg.Text = "Flag changed successfully";
                //lblerror.Text = "Flag changed successfully";
                //lblerror.ForeColor = System.Drawing.Color.Green;
                if (myonoffswitch1.Checked)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alert('HRMS Data Integration Enabled successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alert('HRMS Data Integration Disabled successfully');", true);
                }
            }
            else
            {
                //lblmsg.Text = "Error occured";
                //lblerror.Text = "Error occured";

                //lblerror.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alert('Error occured');", true);
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        #region Employee Master Details Gridview
        public void FetchEmployeeData()
        {
            DataSet ds2 = objHRMS_BAL.GetEmpNameList();

            ddlHOD.DataSource = ds2.Tables[0];
            ddlHOD.DataTextField = "EMP_NAME";
            ddlHOD.DataValueField = "ID";
            ddlHOD.DataBind();
            ddlHOD.Items.Insert(0, new ListItem("Select", "0"));

            //DataSet dsEmpDetails = objHRMS_BAL.FetchEmployeeData(objEmprequest);
            //DataTable dtEmpDetails = dsEmpDetails.Tables[0];

            //grdEmployee.DataSource = dtEmpDetails;
            //grdEmployee.DataBind();
            //Session["dirState"] = dtEmpDetails;
        }

        //protected void grdEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdEmployee.PageIndex = e.NewPageIndex;
        //    grdEmployee.EditIndex = -1;
        //    DataTable dtrslt = (DataTable)Session["dirState"];
        //    if (dtrslt.Rows.Count > 0)
        //    {
        //        string ss = Convert.ToString(ViewState["SortNew"]);
        //        if (!String.IsNullOrEmpty(ss))
        //        {
        //            dtrslt.DefaultView.Sort = ss;

        //        }
        //        grdEmployee.DataSource = dtrslt;
        //        grdEmployee.DataBind();
        //    }

        //}

        //protected void grdEmployee_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    String s = null;
        //    DataTable dtrslt = (DataTable)Session["dirState"];
        //    DataTable dt;
        //    DataTable dt3 = new DataTable();
        //    // dtrst.
        //    if (dtrslt.Rows.Count > 0)
        //    {
        //        if (Convert.ToString(Session["sortdr"]) == "Asc")
        //        {
        //            s = e.SortExpression + " Desc";
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
        //            Session["sortdr"] = "Desc";
        //            if (e.SortExpression == "ECode" || e.SortExpression == "APP_CODE" || e.SortExpression == "HOD_CODE")
        //            {
        //                DataTable dt2 = dtrslt.Clone();
        //                dt2.Columns["ECode"].DataType = Type.GetType("System.Int32");
        //                dt2.Columns["APP_CODE"].DataType = Type.GetType("System.Int32");
        //                dt2.Columns["HOD_CODE"].DataType = Type.GetType("System.Int32");

        //                foreach (DataRow dr in dtrslt.Rows)
        //                {
        //                    dt2.ImportRow(dr);
        //                }
        //                dt2.AcceptChanges();
        //                DataView dv = dt2.DefaultView;
        //                dv.Sort = s;//"ECode Desc";
        //                dt3 = dv.ToTable();
        //            }

        //            else
        //            {
        //                dt3 = dtrslt;
        //            }
        //        }
        //        else
        //        {
        //            s = e.SortExpression + " Asc";
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Asc";

        //            Session["sortdr"] = "Asc";
        //            if (e.SortExpression == "ECode" || e.SortExpression == "APP_CODE" || e.SortExpression == "HOD_CODE")
        //            {
        //                DataTable dt2 = dtrslt.Clone();
        //                dt2.Columns["ECode"].DataType = Type.GetType("System.Int32");
        //                dt2.Columns["APP_CODE"].DataType = Type.GetType("System.Int32");
        //                dt2.Columns["HOD_CODE"].DataType = Type.GetType("System.Int32");

        //                foreach (DataRow dr in dtrslt.Rows)
        //                {
        //                    dt2.ImportRow(dr);
        //                }
        //                dt2.AcceptChanges();
        //                DataView dv = dt2.DefaultView;
        //                dv.Sort = s;//"ECode Desc";
        //                dt3 = dv.ToTable();
        //            }
        //            else
        //            {
        //                dt3 = dtrslt;
        //            }
        //        }
        //        Session["dirState"] = dt3;
        //        //  ViewState["SortNew"] =s;
        //        grdEmployee.DataSource = dt3;
        //        grdEmployee.DataBind();

        //    }
        //}

        protected void grdEmployee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                int basicCount = 16;
                //setVisibilityNew();
                //GridView HeaderGrid = (GridView)sender;
                //GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //TableCell cell = new TableCell();
                ////   cell.Text = " ";
                ////cell.ColumnSpan = 2;
                ////cell.Style.Add("text-align", "center");
                ////cell.Style.Add("color", "White");
                ////cell.Style.Add("background-color", "#E41F25");
                ////cell.Style.Add("font-weight", "Bold");
                //HeaderGridRow.Cells.Add(cell);
                //if (basicCount > 0)
                //{
                //    // cell = new TableCell();
                //    cell.Text = "Basic Employee Information";
                //    cell.ColumnSpan = basicCount;
                //    cell.Style.Add("text-align", "center");
                //    cell.Style.Add("color", "White");
                //    cell.Style.Add("background-color", "#2600ff");
                //    cell.Style.Add("font-weight", "Bold");
                //    HeaderGridRow.Cells.Add(cell);
                //}

                //HeaderGridRow.BackColor = ColorTranslator.FromHtml("#e41f25");
                //HeaderGridRow.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                //// grdMgr1.HeaderRow.Parent.Controls.AddAt(0, row);
                //grdEmployee.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }

        }
        protected void grdEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEmp")
            {
                //DataSet ds = objHRMS_BAL.GetAdminGoalsFilter();

                DataSet ds2 = objHRMS_BAL.GetEmpNameList();

                txtHODName.DataSource = ds2.Tables[0];
                txtHODName.DataTextField = "EMP_NAME";
                txtHODName.DataValueField = "ID";
                txtHODName.DataBind();

                txtBHName.DataSource = ds2.Tables[0];
                txtBHName.DataTextField = "EMP_NAME";
                txtBHName.DataValueField = "ID";
                txtBHName.DataBind();

                DataSet ds1 = objHRMS_BAL.getEmpIDName(e.CommandArgument.ToString());
                if (ds1 != null && ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        lblEmpcode.Text = ds1.Tables[0].Rows[0]["ECODE"].ToString();
                        lblEmpname.Text = ds1.Tables[0].Rows[0]["EMP_NAME"].ToString();
                        txtempstatus.ClearSelection();
                        string Value = ds1.Tables[0].Rows[0]["EMP_Status"].ToString();
                        txtempstatus.Items.FindByText(Value).Selected = true;
                        txtHODID.Text = ds1.Tables[0].Rows[0]["HOD_CODE"].ToString();
                        txtHODName.SelectedItem.Text = ds1.Tables[0].Rows[0]["HOD_NAME"].ToString();
                        txtBHID.Text = ds1.Tables[0].Rows[0]["BH_CODE"].ToString();
                        txtBHName.SelectedItem.Text = ds1.Tables[0].Rows[0]["BH_NAME"].ToString();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openUpdateModal();", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "callJS", "callJsForSumoSel()", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alert('Unable to fetch employee details');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alert('Unable to fetch employee details');", true);
                }
            }
        }

        protected void grdEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdEmployee.EditIndex = e.NewEditIndex;
            bindEmployeeGrid();
        }

        protected void grdEmployee_PreRender(object sender, EventArgs e)
        {
            //DataSet ds = objHRMS_BAL.FetchEmployeeData(objEmprequest);
            DataSet newds = new DataSet();
            newds = objHRMS_BAL.FetchEmployeeData(objEmprequest);
            if (newds.Tables[0].Rows.Count > 0)
            {
                grdEmployee.UseAccessibleHeader = true;
                //grdEmployee.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlStatus = e.Row.FindControl("ddlStatus") as DropDownList;
                    ddlStatus.Items.Add(new ListItem("Select Employee Status", "0"));
                    ddlStatus.Items.Add(new ListItem("Active", "Y"));
                    ddlStatus.Items.Add(new ListItem("InActive", "N"));
                    ddlStatus.AppendDataBoundItems = true;
                    ddlStatus.DataBind();
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EMP_Status")).Trim() == "Active")
                    {
                        ddlStatus.SelectedValue = "Y";
                    }
                    else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EMP_Status")).Trim() == "Inactive")
                    {
                        ddlStatus.SelectedValue = "N";
                    }

                }
                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{

                //    System.Web.UI.WebControls.Image img = (System.Web.UI.WebControls.Image)e.Row.FindControl("logo1");
                //    //                    ImageButton img = (ImageButton)e.Row.FindControl("logo1");
                //    //                    Image img1 = (Image)e.Row.FindControl("logo1");
                //    HiddenField hdn = (HiddenField)e.Row.FindControl("gdnGender1");
                //    String s = hdn.Value;

                //    //string gender = e.Row.Cells[5].Text;
                //    //
                //    switch (s)
                //    {
                //        case "Female":
                //            img.ImageUrl = "images/girl.svg";
                //            break;
                //        case "Male":
                //            img.ImageUrl = "images/user.svg";
                //            break;
                //        default:
                //            img.ImageUrl = "images/user.svg";
                //            break;
                //    }

                //}
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        public void bindEmployeeGrid()
        {
            try
            {
                //DisplayDecryptedDate();
                DataSet ds = objHRMS_BAL.FetchEmployeeData(objEmprequest);
                Session["dirState"] = ds.Tables[0];

                //grdEmployee.DataSource = ds.Tables[0];
                //grdEmployee.DataBind();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void grdEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ECode = grdEmployee.Rows[e.RowIndex].FindControl("lblEmployeeCode") as Label;
                TextBox Reportingmgr = grdEmployee.Rows[e.RowIndex].FindControl("txtrptMgr") as TextBox;
                TextBox ReportingmgrName = grdEmployee.Rows[e.RowIndex].FindControl("txtrptMgrCode") as TextBox;
                TextBox rev = grdEmployee.Rows[e.RowIndex].FindControl("txtrevMgr") as TextBox;
                TextBox RevierName = grdEmployee.Rows[e.RowIndex].FindControl("txtrevMgrName") as TextBox;
                TextBox HOD = grdEmployee.Rows[e.RowIndex].FindControl("txthodMgr") as TextBox;
                TextBox HODNAME = grdEmployee.Rows[e.RowIndex].FindControl("txthodName") as TextBox;

                DropDownList ddlStatus = grdEmployee.Rows[e.RowIndex].FindControl("ddlStatus") as DropDownList;


                emp.ECODE = ECode.Text;

                emp.APP_CODE = Reportingmgr.Text;
                emp.APPRAISER_NAME = ReportingmgrName.Text;
                emp.EMP_STATUS = ddlStatus.SelectedValue;
                emp.REV_CODE = rev.Text;
                emp.REVIEWER_NAME = RevierName.Text;
                emp.HOD_CODE = HOD.Text;
                emp.HOD_NAME = HODNAME.Text;
                //objEmprequest.EmpEntity = emp;
                //DataSet ds = objHRMS_BAL.updateEmployee(objEmprequest);
                grdEmployee.EditIndex = -1;
                bindEmployeeGrid();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

        }
        protected void grdEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdEmployee.EditIndex = -1;
            bindEmployeeGrid();
        }
        protected void setVisibilityNew()
        {
            int basicCount = 16;
            #region basic

            //if (basic == "show")
            //{
            //    //grdEmployee.Columns[0].Visible = true;
            //    //grdEmployee.Columns[1].Visible = true;
            //    grdEmployee.Columns[2].Visible = true;
            //    grdEmployee.Columns[3].Visible = true;
            //    grdEmployee.Columns[4].Visible = true;
            //    grdEmployee.Columns[5].Visible = true;
            //    grdEmployee.Columns[6].Visible = true;
            //    grdEmployee.Columns[7].Visible = true;
            //    grdEmployee.Columns[8].Visible = true;
            //    grdEmployee.Columns[9].Visible = true;
            //    grdEmployee.Columns[10].Visible = true;
            //    grdEmployee.Columns[11].Visible = true;
            //    grdEmployee.Columns[12].Visible = true;
            //}
            //else
            //{
            //    //grdEmployee.Columns[0].Visible = false;
            //    //grdEmployee.Columns[1].Visible = false;
            //    // grdEmployee.Columns[2].Visible = false;
            //    grdEmployee.Columns[3].Visible = false;
            //    grdEmployee.Columns[4].Visible = false;
            //    grdEmployee.Columns[5].Visible = false;
            //    grdEmployee.Columns[6].Visible = false;
            //    grdEmployee.Columns[7].Visible = false;
            //    //  grdEmployee.Columns[8].Visible = false;
            //    grdEmployee.Columns[9].Visible = false;
            //    //grdEmployee.Columns[10].Visible = false;
            //    grdEmployee.Columns[11].Visible = false;
            //    grdEmployee.Columns[12].Visible = false;
            //    basicCount = 5;
            //}
            #endregion
        }

        protected void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            try
            {
                emp.ECODE = lblEmpcode.Text;
                emp.EMP_NAME = lblEmpname.Text;
                //emp.EMP_STATUS = txtempstatus.SelectedItem.Text.Trim();
                emp.EMP_STATUS = txtempstatus.SelectedValue;
                emp.HOD_CODE = txtHODID.Text.Trim();
                emp.HOD_NAME = txtHODName.SelectedItem.Text.Trim();
                emp.BH_CODE = txtBHID.Text.Trim();
                emp.BH_NAME = txtBHName.SelectedItem.Text.Trim();

                int result = objHRMS_BAL.updateEmpDetails(emp);

                if (result == 1)
                {
                    emp.ECODE = lblEmpcode.Text;

                    //if (Session["filtercheck"] == "1")
                    //{
                    //    FetchSearch();
                    //}
                    //else
                    //{
                    //    FetchEmployeeData();
                    //}
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alert('Employee details updated successfully');", true);

                    DataSet ds = new DataSet();
                    emp.ECODE = lblEmpcode.Text;
                    emp.EMP_NAME = lblEmpname.Text;
                    emp.DEPARTMENT = "";
                    emp.BANDS = "";
                    //objEmpBo.Designation = ddlDesignation.SelectedItem.Text;
                    emp.LOCATION = "";
                    ds = objHRMS_BAL.UserFilter(emp);
                    grdEmployee.DataSource = ds.Tables[0];
                    grdEmployee.DataBind();
                    grdEmployee.UseAccessibleHeader = true;
                    grdEmployee.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alert('Error occured');", true);
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void FetchSearch()
        {
            HRMSIntegrationBO emp1 = (HRMSIntegrationBO)Session["EmpObj"];

            //emp1.ECODE = txtEmpCode.Text;
            //emp1.EMP_NAME = txtEmpName.Text;
            //emp1.DEPARTMENT = Convert.ToString(ddlDept.SelectedItem.Value);
            //emp1.FUNCTION = Convert.ToString(ddlFunction.SelectedItem.Value);
            //emp1.COST_CENTRE = Convert.ToString(ddlCostCenter.SelectedItem.Value);
            //emp1.LOCATION = Convert.ToString(ddlLocation.SelectedItem.Value);
            //emp1.BANDS = Convert.ToString(ddlBand.SelectedItem.Value);
            //emp1.HOD_NAME = Convert.ToString(ddlHOD.SelectedItem.Text);

            //emp1.EmpStatus = Convert.ToString(ddlEmpStatus.SelectedItem.Value); //// UPDATE ADITYA
            DataTable dtEmpDetails = new DataTable();
            if (emp1.EmpStatus == "A")
            {
                //objEmprequest.EmpEntity = emp1;
                //DataSet ds1 = objHRMS_BAL.FetchEmpFilterNew(objEmprequest);
                //dtEmpDetails = ds1.Tables[1];
                //Session["dirState"] = ds1.Tables[1];

                //grdEmployee.DataSource = ds1.Tables[1];
                //grdEmployee.DataBind();
            }
            else if (emp1.EmpStatus == "")
            {
                emp1.EmpStatus = "Y";
                //objEmprequest.EmpEntity = emp1;
                //DataSet ds1 = objHRMS_BAL.FetchEmpFilterNew(objEmprequest);
                //dtEmpDetails = ds1.Tables[2];
                //Session["dirState"] = ds1.Tables[2];

                //grdEmployee.DataSource = ds1.Tables[2];
                //grdEmployee.DataBind();
            }
            else
            {
                //objEmprequest.EmpEntity = emp1;
                //DataSet ds = objHRMS_BAL.FetchEmpFilterNew(objEmprequest);
                //dtEmpDetails = ds.Tables[0];
                //Session["dirState"] = ds.Tables[0];

                //grdEmployee.DataSource = ds.Tables[0];
                //grdEmployee.DataBind();
            }

            //grdEmployee.DataSource = dtEmpDetails;
            //grdEmployee.DataBind();
            //Session["dirState"] = dtEmpDetails;

            if (grdEmployee.Rows.Count > 0)
            {
                //ImageButton2.Visible = true;
            }
            else
            {
                //ImageButton2.Visible = false;
            }
            ViewState["EmpName"] = emp1.EMP_NAME;
        }
        protected void txtempstatus_TextChanged(object sender, EventArgs e)
        {
            DataSet ds1 = objHRMS_BAL.getEmpIDName(txtHODName.Text);
            if (ds1 != null && ds1.Tables.Count > 0)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    txtHODID.Text = ds1.Tables[0].Rows[0]["ECODE"].ToString();
                }
                else
                {
                    txtHODID.Text = "";
                }
            }
            else
            {
                txtHODID.Text = "";
            }
        }
        protected void txtHODID_TextChanged(object sender, EventArgs e)
        {
            DataSet ds1 = objHRMS_BAL.getEmpIDName(txtHODID.Text);
            if (ds1 != null && ds1.Tables.Count > 0)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    txtHODName.SelectedItem.Text = ds1.Tables[0].Rows[0]["EMP_NAME"].ToString();
                }
                else
                {
                    txtHODName.SelectedItem.Text = "";
                }
            }
            else
            {
                txtHODName.SelectedItem.Text = "";
            }
        }
        protected void txtHODName_TextChanged(object sender, EventArgs e)
        {
            DataSet ds1 = objHRMS_BAL.getEmpIDName(txtHODName.SelectedItem.Text.Trim());
            if (ds1 != null && ds1.Tables.Count > 0)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    txtHODID.Text = ds1.Tables[0].Rows[0]["ECODE"].ToString();
                }
                else
                {
                    txtHODID.Text = "";
                }
            }
            else
            {
                txtHODID.Text = "";
            }
        }
        protected void txtBHID_TextChanged(object sender, EventArgs e)
        {
            DataSet ds1 = objHRMS_BAL.getEmpIDName(txtBHID.Text);
            if (ds1 != null && ds1.Tables.Count > 0)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    txtBHName.SelectedItem.Text = ds1.Tables[0].Rows[0]["EMP_NAME"].ToString();
                }
                else
                {
                    txtBHName.SelectedItem.Text = "";
                }
            }
            else
            {
                txtBHName.SelectedItem.Text = "";
            }
        }
        protected void txtBHName_TextChanged(object sender, EventArgs e)
        {
            DataSet ds1 = objHRMS_BAL.getEmpIDName(txtBHName.SelectedItem.Text.Trim());
            if (ds1 != null && ds1.Tables.Count > 0)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    txtBHID.Text = ds1.Tables[0].Rows[0]["ECODE"].ToString();
                }
                else
                {
                    txtBHID.Text = "";
                }
            }
            else
            {
                txtBHID.Text = "";
            }
        }


        #endregion
        protected void btnFilter_Click_1(object sender, EventArgs e)
        {
            if (txtEmpCode.Text == "" && txtEmpName.Text == "" && ddlDept.SelectedValue == "0" && ddlBand.SelectedValue == "0" 
                && ddlLocation.SelectedValue == "0" && ddlFunction.SelectedValue == "0" && ddlCC.SelectedValue == "0" 
                && ddlHOD.SelectedValue == "0" && ddlempstatus.SelectedValue == "0")
            {
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Please fill at least one option";
            }
            else
            {
                try
                {
                    showmsg.InnerText = "";
                    DataSet ds = new DataSet();
                    ds = GetApprovalDS();
                    if (ds.Tables.Count > 0)
                    {
                        //int count = ds.Tables[0].Rows.Count;
                        //lbl_text.Text = "Filtered " + count + " Names";
                        //ddlUserName.DataSource = ds.Tables[0];
                        //ddlUserName.DataTextField = "EMP_NAME";
                        //ddlUserName.DataValueField = "USERID";
                        //ddlUserName.DataBind();
                        //ddlUserName.Items.Insert(0, new ListItem("Select an Option", "0"));
                        grdEmployee.DataSource = ds.Tables[0];
                        grdEmployee.DataBind();
                        grdEmployee.UseAccessibleHeader = true;
                        grdEmployee.HeaderRow.TableSection = TableRowSection.TableHeader;
                        //ViewState["grdapproval"] = ds.Tables[0];
                        grdEmployee_Export.DataSource = ds.Tables[0];
                        grdEmployee_Export.DataBind();
                        grdEmployee_Export.UseAccessibleHeader = true;
                        grdEmployee_Export.HeaderRow.TableSection = TableRowSection.TableHeader;

                        btnexcelExport.Attributes.Add("style", "display:inline-block");

                    }
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                }
            }
        }

        protected DataSet GetApprovalDS()
        {
            DataSet ds = new DataSet();
            try
            {
                emp.ECODE = txtEmpCode.Text;
                emp.EMP_NAME = txtEmpName.Text;
                emp.DEPARTMENT = (ddlDept.SelectedItem.Value == "0") ? null : ddlDept.SelectedItem.Value;
                emp.BANDS = (ddlBand.SelectedItem.Value == "0") ? null : ddlBand.SelectedItem.Value;
                //objEmpBo.Designation = ddlDesignation.SelectedItem.Text;
                emp.LOCATION = (ddlLocation.SelectedItem.Value == "0") ? null : ddlLocation.SelectedItem.Value;
                emp.FUNCTION= (ddlFunction.SelectedItem.Value == "0") ? null : ddlFunction.SelectedItem.Value; 
                emp.COST_CENTRE = (ddlCC.SelectedItem.Value == "0") ? null : ddlCC.SelectedItem.Value; 
                emp.HOD_CODE = (ddlHOD.SelectedItem.Value == "0") ? null : ddlHOD.SelectedItem.Value; 
                emp.EMP_STATUS = (ddlempstatus.SelectedItem.Value == "0") ? null : ddlempstatus.SelectedItem.Value;  
                ds = objHRMS_BAL.UserFilter(emp);

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
            return ds;
        }

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    btnClear_Click(new object(), new EventArgs());
        //}

        protected void btnClear_Click(object sender, EventArgs e)
        {
            showmsg.InnerText = "";
            grdEmployee.DataSource = null;
            grdEmployee.DataBind();
            txtEmpCode.Text = "";
            txtEmpName.Text = "";
            ddlBand.SelectedIndex = 0;
            ddlDept.SelectedIndex = 0;
            //ddlDesignation.SelectedIndex = 0;
            ddlLocation.SelectedIndex = 0;
            //btnFilter_Click_1(new object(), new EventArgs());
            ddlFunction.SelectedIndex = 0;
            ddlCC.SelectedIndex = 0;
            ddlHOD.SelectedIndex = 0;
            ddlempstatus.SelectedIndex = 0;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void btnexcelExport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Employee_Details" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            grdEmployee_Export.GridLines = GridLines.Both;
            grdEmployee_Export.HeaderStyle.Font.Bold = true;
            grdEmployee_Export.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
}
