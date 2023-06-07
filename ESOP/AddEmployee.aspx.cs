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
using System.Data.SqlClient;
using System.IO;
using ExcelDataReader;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace ESOP
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        string role;
        string gender;
        GrandCreationBO objbo = new GrandCreationBO();
        GrandCreationBAL objbal = new GrandCreationBAL();
        EmployeeBO objEmpBo = new EmployeeBO();
        EmployeeBAL objEmpBal = new EmployeeBAL();
        string PreviousPage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.ServerVariables["HTTP_REFERER"] != null && Request.ServerVariables["HTTP_REFERER"] != "http://localhost:20546/proxy")
            //{
            //    PreviousPage = Request.ServerVariables["HTTP_REFERER"];
            //}
            if (!IsPostBack)
            {
                //DivFilter.Style["display"] = "none";
                FillUserName();
            }
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
                ddlUserName.DataSource = ds.Tables[0];
                if (ds.Tables.Count > 0)
                {
                    ddlUserName.DataTextField = "USERNAME";
                    ddlUserName.DataValueField = "USERID";
                    ddlUserName.DataBind();
                    ddlUserName.Items.Insert(0, new ListItem("", "0"));
                }

                if (ds.Tables.Count > 1)
                {
                    ddlDept.DataSource = ds.Tables[1];
                    ddlDept.DataTextField = "department";
                    ddlDept.DataValueField = "ID";
                    ddlDept.DataBind();
                    ddlDept.Items.Insert(0, new ListItem("", "0"));
                }

                if (ds.Tables.Count > 1)
                {
                    ddlBand.DataSource = ds.Tables[2];
                    ddlBand.DataTextField = "bands";
                    ddlBand.DataValueField = "ID";
                    ddlBand.DataBind();
                    ddlBand.Items.Insert(0, new ListItem("", "0"));
                }
                //if (ds.Tables.Count > 1)
                //{
                //    ddlDesignation.DataSource = ds.Tables[4];
                //    ddlDesignation.DataTextField = "designation";
                //    ddlDesignation.DataValueField = "ID";
                //    ddlDesignation.DataBind();
                //    ddlDesignation.Items.Insert(0, new ListItem("", "0"));
                //}
                if (ds.Tables.Count > 1)
                {
                    ddlLocation.DataSource = ds.Tables[3];
                    ddlLocation.DataTextField = "location";
                    ddlLocation.DataValueField = "ID";
                    ddlLocation.DataBind();
                    ddlLocation.Items.Insert(0, new ListItem("", "0"));
                }

                if (ds.Tables[5].Rows.Count > 1)
                {
                    ddlRole.DataSource = ds.Tables[5];
                    ddlRole.DataTextField = "ROLENAME";
                    ddlRole.DataValueField = "ROLEID";
                    ddlRole.DataBind();
                    ddlRole.Items.Insert(0, new ListItem("", "0"));
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void btnProxyLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUserName.SelectedValue != "0")
                {
                    string NameRole = ddlUserName.SelectedItem.Text;
                    if (Session["Proxy"] is string)
                    {

                    }
                    else
                    {
                        Session["Proxy"] = Session["ECode"].ToString();
                        Session["ProxyName"] = Session["UserName"].ToString();
                    }
                    Session["UserName"] = ddlUserName.SelectedItem.Text;

                    int i = 0;
                    string[] Role_Name = NameRole.Split('-');
                    foreach (var word in Role_Name)
                    {
                        if (i == 2)
                        {
                            Session["Role"] = word;
                        }
                        i++;
                    }
                    //Session["Role"] = ddlUser.SelectedItem.Text;

                    Session["ECode"] = ddlUserName.SelectedValue.ToString();

                    if (Convert.ToString(Session["Role"]) == "Admin")
                    {
                        Response.Redirect("~/admin-dashboard.aspx", false);
                    }
                    if (Convert.ToString(Session["Role"]) == "HR Head")
                    {
                        Response.Redirect("~/hr-dashboard.aspx", false);
                    }
                    if (Convert.ToString(Session["Role"]) == "President")
                    {
                        Response.Redirect("~/president-dashboard.aspx", false);
                    }
                    if (Convert.ToString(Session["Role"]) == "Employee")
                    {
                        Response.Redirect("~/employee-dashboard.aspx", false);
                    }

                    //Label lblUserVal = (Label)Page.Master.FindControl("lblProxy");
                    //lblUserVal.Text = Session["Proxy"].ToString();
                    //    ((Label)Master.FindControl("lblProxy")).Text = "Proxy";
                }
                else
                {
                    lbl_text.Text = "Please select User Name";
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FillUserName();
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //DivFilter.Style["display"] = "block";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            showmsg.InnerText = "";
            //DivFilter.Style["display"] = "none";
            btnClear_Click(new object(), new EventArgs());
            lbl_text.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            showmsg.InnerText = "";
            txtEmpCode.Text = "";
            txtEmpName.Text = "";
            ddlBand.SelectedIndex = 0;
            ddlDept.SelectedIndex = 0;
            //ddlDesignation.SelectedIndex = 0;
            ddlLocation.SelectedIndex = 0;
            //btnFilter_Click_1(new object(), new EventArgs());
            lbl_text.Text = "";
            ddlRole.SelectedIndex = 0;
        }

        protected DataSet GetApprovalDS()
        {
            DataSet ds = new DataSet();
            try
            {
                objEmpBo.ECode = txtEmpCode.Text;
                objEmpBo.Emp_Name = txtEmpName.Text;
                objEmpBo.Dept = ddlDept.SelectedItem.Text;
                objEmpBo.Band = ddlBand.SelectedItem.Text;
                //objEmpBo.Designation = ddlDesignation.SelectedItem.Text;
                objEmpBo.Location = ddlLocation.SelectedItem.Text;
                objEmpBo.RoleID =Convert.ToInt32(ddlRole.SelectedValue.ToString());
                ds = objbal.UserFilter_1(objEmpBo);
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
            return ds;
        }
        protected void btnFilter_Click_1(object sender, EventArgs e)
        {
            showmsg.InnerText = "";
            if (txtEmpCode.Text == "" && txtEmpName.Text =="" &&  ddlDept.SelectedValue == "0" && ddlBand.SelectedValue =="0" && ddlLocation.SelectedValue=="0" && ddlRole.SelectedValue =="0" )
            {
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Please fill at least one option";
            }
            else
            {
                try
                {
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
                        grdapproval.DataSource = ds.Tables[0];
                        grdapproval.DataBind();
                        grdapproval.UseAccessibleHeader = true;
                        grdapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
                        //ViewState["grdapproval"] = ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                }
            }
        }

        protected void btnPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect(PreviousPage);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            showmsg.InnerText = "";
        }
        //protected void grdapproval_PreRender(object sender, EventArgs e)
        //{
        //objEmpBo.ECode = txtEmpCode.Text;
        //objEmpBo.Emp_Name = txtEmpName.Text;
        //objEmpBo.Dept = ddlDept.SelectedItem.Text;
        //objEmpBo.Band = ddlBand.SelectedItem.Text;
        //objEmpBo.Designation = ddlDesignation.SelectedItem.Text;
        //DataSet ds = objbal.UserFilter(objEmpBo);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    grdapproval.UseAccessibleHeader = true;
        //    grdapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
        //}
        //}
        protected void grdapproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            showmsg.InnerText = "";
            string Role_Sel = "";
            try
            {
                if (e.CommandName == "Add")
                {

                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdapproval.Rows[index];


                    objEmpBo.LoginID = "0000";
                    objEmpBo.RoleID = 0;
                    objEmpBo.EmpID = Convert.ToInt32(grdapproval.DataKeys[index].Values[0]);
                    //int ds = objEmpBal.InsertEmp(objEmpBo);
                    DataSet ds = objEmpBal.InsertEmp(objEmpBo);

                    int ds1 = 0;
                    DataSet dase = new DataSet();
                    CheckBoxList checkboxlist1 = (CheckBoxList)grdapproval.Rows[Convert.ToInt32(index)].FindControl("checkboxlist1");

                    for (int i = 0; i < checkboxlist1.Items.Count; i++)
                    {

                        if (checkboxlist1.Items[i].Selected)
                        {
                            Role_Sel = checkboxlist1.Items[i].Value;
                            objEmpBo.LoginID = Convert.ToString(Session["ECode"]);
                            objEmpBo.RoleID = Convert.ToInt32(Role_Sel);
                            objEmpBo.EmpID = Convert.ToInt32(grdapproval.DataKeys[index].Values[0]);
                            dase = objEmpBal.InsertEmp(objEmpBo);
                            if (Role_Sel == "6" && dase.Tables[0].Rows[0][0].ToString() != "1" && dase.Tables[0].Rows[0][0].ToString() != Convert.ToString(grdapproval.DataKeys[index].Values[0]))
                            {
                                Common.ShowJavascriptAlert("Checker : "+ dase.Tables[0].Rows[0][0].ToString() + " already exist in ESOP system");
                            }
                            if (Role_Sel == "6" && dase.Tables[0].Rows[0][0].ToString() == "1")
                            {
                                SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), dase.Tables[0].Rows[0][1].ToString(), "Checker", "Checker_Created", "", "", "", "", "", "", "");
                            }
                            if (Role_Sel == "2" && dase.Tables[0].Rows[0][2].ToString() != "1")
                            {
                                Common.ShowJavascriptAlert("HR : " + dase.Tables[0].Rows[0][2].ToString() + " already exist in ESOP system");
                            }
                        }

                    }

                    ////DropDownList ddlroleGrid = (DropDownList)row.FindControl("ddlRole");
                    ////if (ddlroleGrid.SelectedValue.ToString() == "0")
                    ////{
                    ////    showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                    ////    showmsg.InnerText = "Please Select Role!";
                    ////    return;
                    ////}

                    ////objEmpBo.LoginID = Convert.ToString(Session["ECode"]);
                    ////objEmpBo.RoleID = Convert.ToInt32(ddlroleGrid.SelectedValue);
                    ////objEmpBo.EmpID = Convert.ToInt32(grdapproval.DataKeys[index].Values[0]);

                    ////objEmpBo.LoginID = Convert.ToString(Session["ECode"]);
                    ////objEmpBo.RoleID = Convert.ToInt32(Role_Sel);
                    ////objEmpBo.EmpID = Convert.ToInt32(grdapproval.DataKeys[index].Values[0]);
                    ////int ds1 = objEmpBal.InsertEmp(objEmpBo);

                    //if (ds1 > 0)
                    if (dase.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Employee Added successfully";
                        ////ddlroleGrid.SelectedValue = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void grdapproval_PreRender(object sender, EventArgs e)
        {
            // DataTable ds = (DataTable)ViewState["grdapproval"];
            DataSet dsAll = new DataSet();
            DataTable ds = new DataTable();
            dsAll = GetApprovalDS();
            ds = dsAll.Tables[0];

            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {
                    if (grdapproval.Rows.Count > 0)
                    {
                        grdapproval.UseAccessibleHeader = true;
                        grdapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
        }

        protected void grdapproval_DataBound(object sender, EventArgs e)
        {

        }

        protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBoxList CheckBoxList1 = (CheckBoxList)e.Row.FindControl("CheckBoxList1");

                    DataSet ds = new DataSet();

                    objEmpBo.ECode = e.Row.Cells[0].Text;
                    ds = objbal.GET_EMP_ROLL(objEmpBo);

                    if (ds.Tables[0].Rows.Count == 0)
                    { }
                    else
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            int no1 = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString()) - 1;
                            CheckBoxList1.Items[no1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
    }
}