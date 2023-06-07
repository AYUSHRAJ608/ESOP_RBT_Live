using System;
using System.Web.UI.WebControls;
using ESOP_BAL;
using ESOP_BO;
using System.Data;
using System.Web.UI;
using System.IO;
using System.Web;

namespace ESOP
{
    public partial class Employee_Transaction_History : System.Web.UI.Page
    {
        GrandCreationBO objbo = new GrandCreationBO();
        GrandCreationBAL objbal = new GrandCreationBAL();
        employee_exerciseBO objBO = new employee_exerciseBO();
        employee_exerciseBAL objBAL = new employee_exerciseBAL();
        employee_saleBO objSBO = new employee_saleBO();
        employee_saleBAL objSBAL = new employee_saleBAL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {

            if (ddlWorkflow.SelectedIndex == 1)
            {
                grdmain_1.Attributes.Add("style", "display: block");
                grdMain2.Attributes.Add("style", "display: none");

                BindMainGrid_1();
            }

            if (ddlWorkflow.SelectedIndex == 2)
            {
                grdmain_1.Attributes.Add("style", "display: none");
                grdMain2.Attributes.Add("style", "display: block");

                BindMainGrid_2();
            }
        }
        private void BindMainGrid_1()
        {
            try
            {
                objbo.Key = "5";
                objbo.Ecode = Convert.ToString(Session["ECode"]);
                DataSet ds = objbal.Admin_Trans_History(objbo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdmain_1.DataSource = ds.Tables[0];
                    grdmain_1.DataBind();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }


        private void BindMainGrid_2()
        {
            try
            {
                objbo.Key ="6";
                objbo.Ecode = Convert.ToString(Session["ECode"]);
                DataSet ds = objbal.Admin_Trans_History(objbo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdMain2.DataSource = ds.Tables[0];
                    grdMain2.DataBind();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        protected void grdmain_1_Child_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                string commandArg = e.CommandArgument.ToString();
                GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                GridView gv1 = (GridView)sender;
                objbo.Ecode = Convert.ToString(gv1.DataKeys[rowIndex].Values[0]);

                objbo.Key = "3.2";
                DataSet ds = objbal.Admin_Trans_History(objbo);


                ViewState["GrvPendingforApproval_app_rej"] = null;

                ViewState["GrvPendingforApproval_app_rej"] = ds.Tables[0];


                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData_2.DataSource = ds.Tables[0];
                    grdData_2.DataBind();
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowExerciseAudit();", true);

            }
        }
        protected void grdmain_1_PreRender(object sender, EventArgs e)
        {
            if (ddlWorkflow.SelectedIndex == 1)
            {
                try
                {

                    DataSet de = new DataSet();
                    DataSet ds = objBAL.GET_Employee_Admin_Main_Grid_1();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        grdmain_1.DataSource = ds.Tables[1];
                        grdmain_1.DataBind();
                        grdmain_1.UseAccessibleHeader = true;
                        grdmain_1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                }
            }
        }

        protected void GrvPFADB(object sender, GridViewRowEventArgs e)
        {
            GridView grdmain_1_Child = e.Row.FindControl("grdmain_1_Child") as GridView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdmain_1.Rows.Count; i++)
                {
                    //string id = (grdmain_1.DataKeys[i].Values[0].ToString());
                    //ds = objBAL.GET_Employee_Admin_Main_Data_2(id);
                    objbo.Ecode = grdmain_1.DataKeys[i].Values[0].ToString();
                    objbo.Key = "3.1";

                    DataSet ds = objbal.Admin_Trans_History(objbo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdmain_1_Child.DataSource = ds.Tables[0];
                        grdmain_1_Child.DataBind();
                    }
                }
            }
        }
        protected void grdMain2_PreRender(object sender, EventArgs e)
        {
            if (ddlWorkflow.SelectedIndex == 2)
            {
                try
                {
                    DataSet de = new DataSet();
                    DataSet ds = objBAL.GET_Employee_Admin_Main_Grid_2();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdMain2.DataSource = ds.Tables[0];
                        grdMain2.DataBind();
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                    //throw ex;
                }
            }
        }
        protected void GrvPFADB_2(object sender, GridViewRowEventArgs e)
        {
            Session["GrvPendingforApproval_data"] = "";
            GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval_2") as GridView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdMain2.Rows.Count; i++)
                {
                    objbo.Key = "4.1";
                    objbo.Ecode = grdMain2.DataKeys[i].Values[0].ToString();
                    DataSet ds = objbal.Admin_Trans_History(objbo);

                    GrvPendingforApproval.DataSource = ds.Tables[0];
                    GrvPendingforApproval.DataBind();
                    Session["GrvPendingforApproval_data"] = ds.Tables[0];
                }
            }
        }

        protected void GrvPendingforApproval_2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                string commandArg = e.CommandArgument.ToString();
                GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                GridView gv1 = (GridView)sender;
                objbo.Ecode = Convert.ToString(gv1.DataKeys[rowIndex].Values[0]);

                objbo.Key = "4.2";
                DataSet ds = objbal.Admin_Trans_History(objbo);


                ViewState["GrvPendingforApproval_app_rej"] = null;

                ViewState["GrvPendingforApproval_app_rej"] = ds.Tables[0];


                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData_3.DataSource = ds.Tables[0];
                    grdData_3.DataBind();
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowSaleAudit();", true);

            }
        }
        protected void grdData_2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        //protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdData.PageIndex = e.NewPageIndex;
        //    DataSet ds = (DataSet)ViewState["Emp_filterRec"];
        //    if (ds.Tables.Count > 0)
        //    {
        //        grdData.DataSource = ds.Tables[0];
        //        grdData.DataBind();
        //    }
        //}
        //protected void grdData_1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdData.PageIndex = e.NewPageIndex;
        //    DataSet ds = (DataSet)ViewState["Emp_filterRec"];
        //    if (ds.Tables.Count > 0)
        //    {
        //        grdData.DataSource = ds.Tables[0];
        //        grdData.DataBind();
        //    }
        //}

    }
}