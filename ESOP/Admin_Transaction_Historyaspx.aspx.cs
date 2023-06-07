﻿using System;
using System.Web.UI.WebControls;
using ESOP_BAL;
using ESOP_BO;
using System.Data;
using System.Web.UI;
using System.IO;
using System.Web;


namespace ESOP
{
    public partial class Admin_Transaction_Historyaspx : System.Web.UI.Page
    {
        GrandCreationBO objbo = new GrandCreationBO();
        GrandCreationBAL objbal = new GrandCreationBAL();
        employee_exerciseBO objBO = new employee_exerciseBO();
        employee_exerciseBAL objBAL = new employee_exerciseBAL();
        employee_saleBO objSBO = new employee_saleBO();
        employee_saleBAL objSBAL = new employee_saleBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //GrvGrant.Attributes.Add("style", "display: none");
            //grdMain.Attributes.Add("style", "display: none");
            //grdmain_1.Attributes.Add("style", "display: none");
            //grdMain2.Attributes.Add("style", "display: none");
        }



        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (ddlWorkflow.SelectedIndex == 1)
            {
                objbo.Key = Convert.ToString(ddlWorkflow.SelectedIndex);
                DataSet ds = objbal.Admin_Trans_History(objbo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GrvGrantMain.Attributes.Add("style", "display: block");
                    grdMain.Attributes.Add("style", "display: none");
                    grdmain_1.Attributes.Add("style", "display: none");
                    grdMain2.Attributes.Add("style", "display: none");

                    GrvGrantMain.DataSource = ds.Tables[0];
                    GrvGrantMain.DataBind();
                }
            }
            if (ddlWorkflow.SelectedIndex == 2)
            {
                GrvGrantMain.Attributes.Add("style", "display: none");
                grdMain.Attributes.Add("style", "display: block");
                grdmain_1.Attributes.Add("style", "display: none");
                grdMain2.Attributes.Add("style", "display: none");

                BindMainGrid();
            }
            if (ddlWorkflow.SelectedIndex == 3)
            {
                GrvGrantMain.Attributes.Add("style", "display: none");
                grdMain.Attributes.Add("style", "display: none");
                grdmain_1.Attributes.Add("style", "display: block");
                grdMain2.Attributes.Add("style", "display: none");

                BindMainGrid_1();
            }

            if (ddlWorkflow.SelectedIndex == 4)
            {
                GrvGrantMain.Attributes.Add("style", "display: none");
                grdMain.Attributes.Add("style", "display: none");
                grdmain_1.Attributes.Add("style", "display: none");
                grdMain2.Attributes.Add("style", "display: block");

                BindMainGrid_2();
            }
        }
        protected void GrvGrant_PreRender(object sender, EventArgs e)
        {
            //if (ddlWorkflow.SelectedIndex == 1)
            //{
            //    objbo.Key = Convert.ToString(ddlWorkflow.SelectedIndex);
            //    DataSet ds = objbal.Admin_Trans_History(objbo);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        GrvGrant.DataSource = ds.Tables[0];
            //        GrvGrant.DataBind();

            //        GrvGrant.UseAccessibleHeader = true;
            //        GrvGrant.HeaderRow.TableSection = TableRowSection.TableHeader;
            //    }
            //    else
            //    {

            //    }
            //}
        }
        private void BindMainGrid()
        {
            try
            {
                objbo.Key = Convert.ToString(ddlWorkflow.SelectedIndex);
                DataSet de = new DataSet();
                DataSet ds = objbal.Admin_Trans_History(objbo);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdMain.DataSource = ds.Tables[0];
                    grdMain.DataBind();
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

        protected void grdMain_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                objbo.Ecode = grdMain.DataKeys[e.Row.RowIndex].Values[0].ToString();
            }
            GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdMain.Rows.Count; i++)
                {
                    objbo.Key = "2.2";
                    DataSet ds = objbal.Admin_Trans_History(objbo);
                    GrvPendingforApproval.DataSource = ds.Tables[0];
                    GrvPendingforApproval.DataBind();
                }
            }

        }

        protected void gvChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    for (int i = 0; i <= grdMain.Rows.Count; i++)
            //    {
            //        objbo.Key = "2.2";
            //        DataSet ds = objbal.Admin_Trans_History(objbo);
            //        GrvPendingforApproval.DataSource = ds.Tables[0];
            //        GrvPendingforApproval.DataBind();
            //    }
            //}
        }


        protected void grdMain_PreRender(object sender, EventArgs e)
        {
            if (ddlWorkflow.SelectedIndex == 2)
            {
                try
                {

                    objbo.Key = Convert.ToString(ddlWorkflow.SelectedIndex);
                    DataSet ds = objbal.Admin_Trans_History(objbo);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdMain.DataSource = ds.Tables[0];
                        grdMain.DataBind();
                        grdMain.UseAccessibleHeader = true;
                        grdMain.HeaderRow.TableSection = TableRowSection.TableHeader;
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


        private void BindMainGrid_1()
        {
            try
            {
                objbo.Key = Convert.ToString(ddlWorkflow.SelectedIndex);
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

                //throw ex;
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

        private void BindMainGrid_2()
        {
            try
            {
                objbo.Key = Convert.ToString(ddlWorkflow.SelectedIndex);
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

                //throw ex;
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
        protected void grdMain2_PreRender(object sender, EventArgs e)
        {
            if (ddlWorkflow.SelectedIndex == 4)
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

        protected void GrvPendingforApproval_PreRender(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable dt = Session["GrvPendingforApproval_data"] as DataTable;
            //    if (dt.Rows.Count > 0)
            //    {
            //        GrvPendingforApproval.DataSource = dt;
            //        GrvPendingforApproval.DataBind();
            //    }
            //}
            //catch (Exception ex)
            //{

            //}

        }

        protected void grdmain_1_PreRender(object sender, EventArgs e)
        {
            if (ddlWorkflow.SelectedIndex == 3)
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
        protected void btnexcelExport_Click(object sender, ImageClickEventArgs e)
        {




            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "";
            if (ddlWorkflow.SelectedIndex == 1)
            {
                FileName = "PENDING_GRANT_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            }
            else if (ddlWorkflow.SelectedIndex == 2)
            {
                FileName = "PENDING_VESTING_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            }
            else if (ddlWorkflow.SelectedIndex == 3)
            {
                FileName = "PENDING_EXERCISE_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            }
            else if (ddlWorkflow.SelectedIndex == 4)
            {
                FileName = "PENDING_SALE_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            }

            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            if (ddlWorkflow.SelectedIndex == 1)
            {
                //GrvGrant.GridLines = GridLines.Both;
                //GrvGrant.HeaderStyle.Font.Bold = true;
                //GrvGrant.RenderControl(htmltextwrtter);
            }
            else if (ddlWorkflow.SelectedIndex == 2)
            {

            }
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void GrvGrant_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Grant_CorrectionBO objBo = new Grant_CorrectionBO();
            Grant_CorrectionBAL objBal = new Grant_CorrectionBAL();
            if (e.CommandName == "Audit")
            {
                //int index = Convert.ToInt32(e.CommandArgument);
                //GridViewRow row = GrvGrant.Rows[index];
                //objBo.GRANT_ID = Convert.ToInt32(GrvGrant.DataKeys[index].Values[0]);

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvGrantMain.Rows[index];
                objBo.GRANT_ID = Convert.ToInt32(GrvGrantMain.DataKeys[index].Values[1]);
                ViewState["grant_id"] = objBo.GRANT_ID;
                DataSet ds = objBal.GET_GRANT_CORRECTION_AUDIT(objBo);

                ViewState["Emp_filterRec"] = null;
                ViewState["Emp_filterRec"] = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData.DataSource = ds.Tables[0];
                    grdData.DataBind();
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
            }
        }
        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdData.PageIndex = e.NewPageIndex;
            DataSet ds = (DataSet)ViewState["Emp_filterRec"];
            if (ds.Tables.Count > 0)
            {
                grdData.DataSource = ds.Tables[0];
                grdData.DataBind();
            }
        }
        protected void GrvApproved_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            vesting_approvalBAL objBAL = new vesting_approvalBAL();
            vesting_approvalBO objBO = new vesting_approvalBO();
            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdMain.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(grdMain.DataKeys[index].Values[0]);
                string Vest_Cycle_Name = Convert.ToString(grdMain.DataKeys[index].Values[3]);
                DataSet ds = objBAL.GET_VESTING_AUDIT(objBO, Vest_Cycle_Name);


                ViewState["GrvPendingforApproval_app_rej"] = null;

                ViewState["GrvPendingforApproval_app_rej"] = ds.Tables[0];


                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData_1.DataSource = ds.Tables[0];
                    grdData_1.DataBind();
                    //ViewState["dtAuditExport"] = ds.Tables[0];
                }
                //ViewState["Emp_filterRec"] = ds;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowVestAudit();", true);
            }
        }

        protected void grdData_1_PreRender(object sender, EventArgs e)
        {
            if (ddlWorkflow.SelectedIndex == 2)
            {
                DataTable ds = (DataTable)ViewState["GrvPendingforApproval_app_rej"];
                if (ds == null) { }
                else
                {
                    if (ds.Rows.Count > 0)
                    {
                        grdData_1.UseAccessibleHeader = true;
                        grdData_1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
        }

        protected void grdData_1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdData.PageIndex = e.NewPageIndex;
            DataSet ds = (DataSet)ViewState["Emp_filterRec"];
            if (ds.Tables.Count > 0)
            {
                grdData.DataSource = ds.Tables[0];
                grdData.DataBind();
            }
        }

        protected void grdData_1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label lbl_Code = (Label)e.Row.FindControl("lbl_Status");
            //    if (lbl_Code.Text.Contains("APP"))
            //    {
            //        e.Row.BackColor = System.Drawing.Color.LightPink;
            //    }
            //    else if (lbl_Code.Text.Contains("REJ"))
            //    {
            //        e.Row.BackColor = System.Drawing.Color.BurlyWood;
            //    }
            //}
        }
        protected void GrvApproved_PreRender(object sender, EventArgs e)
        {
            if (ddlWorkflow.SelectedIndex == 2)
            {
                objbo.Key = Convert.ToString(ddlWorkflow.SelectedIndex);
                DataSet ds = objbal.Admin_Trans_History(objbo);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    grdMain.UseAccessibleHeader = true;
                    grdMain.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }

        protected void GrvPendingforApproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            vesting_approvalBAL objBAL = new vesting_approvalBAL();
            vesting_approvalBO objBO = new vesting_approvalBO();
            if (e.CommandName == "Audit")
            {
                //int index = Convert.ToInt32(e.CommandArgument);
                //GridViewRow row = grdMain.Rows[index];
                //objBO.GRANT_ID = Convert.ToInt32(grdmain_1.DataKeys[index].Values[0]);
                //string Vest_Cycle_Name = Convert.ToString(grdmain_1.DataKeys[index].Values[3]);

                string commandArg = e.CommandArgument.ToString();
                GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                GridView gv1 = (GridView)sender;
                string Vest_Cycle_Name = Convert.ToString(gv1.DataKeys[rowIndex].Values[1]);
                objBO.GRANT_ID = Convert.ToInt32(gv1.DataKeys[rowIndex].Values[0]);


                DataSet ds = objBAL.GET_VESTING_AUDIT(objBO, Vest_Cycle_Name);


                ViewState["GrvPendingforApproval_app_rej"] = null;

                ViewState["GrvPendingforApproval_app_rej"] = ds.Tables[0];


                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData_1.DataSource = ds.Tables[0];
                    grdData_1.DataBind();
                    //ViewState["dtAuditExport"] = ds.Tables[0];
                }
                //ViewState["Emp_filterRec"] = ds;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowVestAudit();", true);
            }

        }

        protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GrvGrantMain_PreRender(object sender, EventArgs e)
        {

        }

        protected void GrvGrantMain_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                objbo.GRANT_NAME = GrvGrantMain.DataKeys[e.Row.RowIndex].Values[0].ToString();
            }
            GridView GrvGrant = e.Row.FindControl("GrvGrant") as GridView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= GrvGrantMain.Rows.Count; i++)
                {
                    objbo.Key = "1.1";
                    DataSet ds = objbal.Admin_Trans_History(objbo);
                    GrvGrant.DataSource = ds.Tables[0];
                    GrvGrant.DataBind();
                }
            }

        }

        protected void GrvGrantMain_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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

        protected void grdData_2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

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
    }
}