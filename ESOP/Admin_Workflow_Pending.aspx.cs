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
    public partial class Admin_Workflow_Pending : System.Web.UI.Page
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
                DataSet ds = objbal.Workflow(objbo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GrvGrant.Attributes.Add("style", "display: block");
                    grdMain.Attributes.Add("style", "display: none");
                    grdmain_1.Attributes.Add("style", "display: none");
                    grdMain2.Attributes.Add("style", "display: none");

                    GrvGrant.DataSource = ds.Tables[0];
                    GrvGrant.DataBind();
                }
            }
            if (ddlWorkflow.SelectedIndex == 2)
            {
                GrvGrant.Attributes.Add("style", "display: none");
                grdMain.Attributes.Add("style", "display: block");
                grdmain_1.Attributes.Add("style", "display: none");
                grdMain2.Attributes.Add("style", "display: none");

                BindMainGrid();
            }
            if (ddlWorkflow.SelectedIndex == 3)
            {
                GrvGrant.Attributes.Add("style", "display: none");
                grdMain.Attributes.Add("style", "display: none");
                grdmain_1.Attributes.Add("style", "display: block");
                grdMain2.Attributes.Add("style", "display: none");

                BindMainGrid_1();
            }

            if (ddlWorkflow.SelectedIndex == 4)
            {
                GrvGrant.Attributes.Add("style", "display: none");
                grdMain.Attributes.Add("style", "display: none");
                grdmain_1.Attributes.Add("style", "display: none");
                grdMain2.Attributes.Add("style", "display: block");

                BindMainGrid_2();
            }
        }
        protected void GrvGrant_PreRender(object sender, EventArgs e)
        {
            if (ddlWorkflow.SelectedIndex == 1)
            {
                objbo.Key = Convert.ToString(ddlWorkflow.SelectedIndex);
                DataSet ds = objbal.Workflow(objbo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GrvGrant.DataSource = ds.Tables[0];
                    GrvGrant.DataBind();

                    GrvGrant.UseAccessibleHeader = true;
                    GrvGrant.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {

                }
            }
        }
        private void BindMainGrid()
        {
            try
            {
                objbo.Key = Convert.ToString(ddlWorkflow.SelectedIndex);
                DataSet de = new DataSet();
                DataSet ds = objbal.Workflow(objbo);

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

            //GridView GrvPendingforApproval = e.Row.FindControl("gvChild") as GridView;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    for (int i = 0; i <= grdMain.Rows.Count; i++)
            //    {
            //        objbo.Key = "2.1";
            //        DataSet ds = objbal.Workflow(objbo);

            //        gvSubChild.DataSource = ds.Tables[0];
            //        grdChild.DataBind();
            //    }
            //}
            GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdMain.Rows.Count; i++)
                {
                    objbo.Key = "2.2";
                    DataSet ds = objbal.Workflow(objbo);
                    GrvPendingforApproval.DataSource = ds.Tables[0];
                    GrvPendingforApproval.DataBind();
                }
            }

        }

        protected void gvChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdMain.Rows.Count; i++)
                {
                    objbo.Key = "2.2";
                    DataSet ds = objbal.Workflow(objbo);
                    GrvPendingforApproval.DataSource = ds.Tables[0];
                    GrvPendingforApproval.DataBind();
                }
            }
        }


        protected void grdMain_PreRender(object sender, EventArgs e)
        {
            if (ddlWorkflow.SelectedIndex == 2)
            {
                try
                {

                    objbo.Key = Convert.ToString(ddlWorkflow.SelectedIndex);
                    DataSet de = new DataSet();
                    DataSet ds = objbal.Workflow(objbo);

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
                DataSet de = new DataSet();
                //DataSet ds = objBAL.GET_Employee_Admin_Main_Grid();
                DataSet ds = objBAL.GET_Employee_Admin_Main_Grid_1();

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
            GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;
            DataSet ds = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdmain_1.Rows.Count; i++)
                {
                    string id = (grdmain_1.DataKeys[i].Values[0].ToString());
                    ds = objBAL.GET_Employee_Admin_Main_Data_2(id);


                    GrvPendingforApproval.DataSource = ds.Tables[0];
                    GrvPendingforApproval.DataBind();
                }
            }
        }

        private void BindMainGrid_2()
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

        protected void GrvPFADB_2(object sender, GridViewRowEventArgs e)
        {
            Session["GrvPendingforApproval_data"] = "";
            GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval_2") as GridView;
            DataSet ds = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdMain2.Rows.Count; i++)
                {
                    string id = (grdMain2.DataKeys[i].Values[0].ToString());
                    ds = objSBAL.GET_EMPLOYEE_SELL_DETAILS_DATA_2(id);

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
                GrvGrant.GridLines = GridLines.Both;
                GrvGrant.HeaderStyle.Font.Bold = true;
                GrvGrant.RenderControl(htmltextwrtter);
            }
            else if (ddlWorkflow.SelectedIndex == 2)
            {

            }
            Response.Write(strwritter.ToString());
            Response.End();

        }

    }
}