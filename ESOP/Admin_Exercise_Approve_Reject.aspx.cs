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
using System.IO;
using System.Drawing;
using System.Net;
using Ionic.Zip;

namespace ESOP
{
    public partial class Admin_Exercise_Approve_Reject : System.Web.UI.Page
    {
        employee_exerciseBO objBO = new employee_exerciseBO();
        employee_exerciseBAL objBAL = new employee_exerciseBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                GET_Employee_Admin_Approve_Reject_Data();
                BindMainGrid();
            }
        }

        private void BindMainGrid()
        {
            try
            {
                DataSet de = new DataSet();
                DataSet ds = objBAL.GET_Employee_Admin_Main_Grid();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdMain.DataSource = ds.Tables[0];
                    grdMain.DataBind();
                    btn_BulkApprove.Visible = true;
                    // btn_BulkReject.Visible = true;
                }
                else
                {
                    grdMain.DataSource = ds.Tables[0];
                    grdMain.DataBind();
                    btn_BulkApprove.Visible = false;
                    //  btn_BulkReject.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }
        protected void GET_Employee_Admin_Approve_Reject_Data()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objBAL.GET_EMPLOYEE_EXERCISE_DATA(objBO);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GrvApproved.DataSource = ds.Tables[0];
                        GrvApproved.DataBind();
                        btn_BulkApprove.Visible = false;
                        ViewState["Approved"] = ds.Tables[0];
                        // btn_BulkReject.Visible = false;
                    }
                    else
                    {
                        GrvApproved.DataSource = ds.Tables[0];
                        GrvApproved.DataBind();
                        ViewState["Approved"] = null;
                        btn_BulkApprove.Visible = false;
                        //  btn_BulkReject.Visible = false;

                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GrvReject.DataSource = ds.Tables[1];
                        GrvReject.DataBind();
                        btn_BulkApprove.Visible = false;
                        // btn_BulkReject.Visible = false;
                    }
                    else
                    {
                        GrvReject.DataSource = ds.Tables[1];
                        GrvReject.DataBind();
                        btn_BulkApprove.Visible = false;
                        // btn_BulkReject.Visible = false;
                    }
                }
                else
                {


                    GrvApproved.DataSource = ds.Tables[0];
                    GrvApproved.DataBind();


                    GrvReject.DataSource = ds.Tables[1];
                    GrvReject.DataBind();
                    btn_BulkApprove.Visible = false;
                    // btn_BulkReject.Visible = false;
                }
                ViewState["Emp_filterRec"] = ds;
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        protected void GrvPendingforApproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //try
            {

                if (e.CommandName == "Approve")
                {

                    GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                    int rowIndex = gvr.RowIndex;

                    GridView gv1 = (GridView)sender;
                    double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                    string Grant_ID = Convert.ToString(gv1.DataKeys[rowIndex].Values[1]);
                    double etID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);

                    // GridView GrvPendingforApproval = (GridView)grdMain.Rows[rowIndex].FindControl("GrvPendingforApproval");

                    objBO.id = ID;
                    objBO.etid = etID;
                    objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                    TextBox txt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("txt_remark");
                    objBO.remark = txt.Text.Replace(",", "");
                    objBO.status = "APPROVED_BY_ADMIN";

                    bool val = objBAL.update_status(objBO);
                }
                if (e.CommandName == "Reject")
                {
                    GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                    int rowIndex = gvr.RowIndex;
                    GridView gv1 = (GridView)sender;
                    double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                    string Grant_ID = Convert.ToString(gv1.DataKeys[rowIndex].Values[1]);
                    double etID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);

                    // GridView GrvPendingforApproval = (GridView)grdMain.Rows[rowIndex].FindControl("GrvPendingforApproval");

                    objBO.id = ID;
                    objBO.etid = etID;
                    objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                    TextBox txt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("txt_remark");
                    objBO.remark = txt.Text.Replace(",", "");
                    objBO.status = "REJECTED_BY_ADMIN";

                    bool val = objBAL.update_status(objBO);
                    if (val == true)
                    {
                        GridViewRow gvr1 = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                        int rowIndex1 = gvr.RowIndex;

                        GridView gv11 = (GridView)sender;
                        OEMailBO.userName = (gv11.DataKeys[rowIndex1].Values[4].ToString());

                        OEMailBO.RoleName = "EMP";
                        // OEMailBO.userName = ecode;

                        Employee_secretarialBAL objBAL_BAL = new Employee_secretarialBAL();
                        DataSet ds = objBAL_BAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);
                        string email2 = "";
                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            email2 = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                        }
                        else
                        {
                            email2 = (ds.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds.Tables[0].Rows[1]["EMAILID"].ToString());
                        }

                        string Attachment = "";
                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Secretarial Reject", "Exercise Rejected By Secretarial", "", email2, "", "", "", "", "");
                    }

                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record Reject successfully!.";
                    GET_Employee_Admin_Approve_Reject_Data();
                    BindMainGrid();
                }

                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            TextBox txt = (TextBox)gvrow.FindControl("txt_remark");
                            string disply = txt.Text;
                            txt.Text = string.Empty;
                        }
                    }
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void grdMain_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.GET_Employee_Admin_Main_Grid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdMain.UseAccessibleHeader = true;
                grdMain.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrvApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvApproved.PageIndex = e.NewPageIndex;
            GET_Employee_Admin_Approve_Reject_Data();

        }

        protected void GrvApproved_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)
            {
                ViewState["SortDirection"] = "ASC";
                GrvApproved.PageIndex = 0;
            }
            else if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else if (ViewState["SortDirection"].ToString() == "DESC")
            {
                ViewState["SortDirection"] = "ASC";
            }
            ViewState["SortExpression"] = e.SortExpression;

            DataTable dt = (DataTable)ViewState["Approved"];
            if (dt != null)
            {
                dt.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + ViewState["SortDirection"].ToString();
                GrvApproved.DataSource = dt;
                GrvApproved.DataBind();
            }
        }

        protected void GrvApproved_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.GET_EMPLOYEE_EXERCISE_DATA(objBO);
            if (ds.Tables[0].Rows.Count > 0)
            {

                GrvApproved.UseAccessibleHeader = true;
                GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void btn_bulkApprove_Click(object sender, EventArgs e)
        {
            
        }

        protected void btn_bulkReject_Click(object sender, EventArgs e)
        {
            
        }

        protected void GrvPFADB(object sender, GridViewRowEventArgs e)
        {
            GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;
            DataSet ds = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdMain.Rows.Count; i++)
                {
                    //double id = grdMain.DataKeys[i].Values[0].ToString();
                    string id = (grdMain.DataKeys[i].Values[0].ToString());
                    ds = objBAL.GET_Employee_Admin_Main_Data(id);
                    GrvPendingforApproval.DataSource = ds.Tables[0];
                    GrvPendingforApproval.DataBind();
                }
            }
        }
    }
}