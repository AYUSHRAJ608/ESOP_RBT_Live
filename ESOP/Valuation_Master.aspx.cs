using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ESOP
{
    public partial class Valuation_Master : System.Web.UI.Page
    {


        ValuationBO objbo = new ValuationBO();
        ValuationBAL objbal = new ValuationBAL();
           bool IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)

        {

            showmsg.InnerText = "";
            // btn.Attributes.Add("onClick", "return false;");
            if (!IsPostBack)

            {

                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();

                bindvaluationGrid();
                clearcontrol();
            }
            else
            {

                if (Convert.ToString(ViewState["ViewStateId"]) != Convert.ToString(Session["SessionId"]))
                {
                    IsPageRefresh = true;
                }
                Session["SessionId"] = System.Guid.NewGuid().ToString();
                ViewState["ViewStateId"] = Session["SessionId"].ToString();
            }
        }

        private void clearcontrol()
        {
            txtagencyname.Text = "";
            txtagencyaddress.Text = "";
            // lbl1.InnerText = string.Empty;
            // lbl2.InnerText = string.Empty;
        }
        #region

        #endregion
        // 

        private void bindvaluationGrid()
        {


            try
            {
                DataSet ds = objbal.getAgency(objbo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdvaluation.DataSource = ds.Tables[0];
                    grdvaluation.DataBind();
                    // ViewState["Getvaluation"] = ds.Tables[0];

                    grdvaluation.UseAccessibleHeader = true;
                    grdvaluation.HeaderRow.TableSection = TableRowSection.TableHeader;


                }
                else
                {
                    grdvaluation.DataSource = ds.Tables[0];
                    grdvaluation.DataBind();
                    //  ViewState["Getvaluation"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }




        protected void btnSaveValuation_click(object sender, EventArgs e)
        {
            try
            {

                if (IsPageRefresh)
                {
                    return;
                }


                string message = "";
                DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                objbo.AGENCY_NAME = txtagencyname.Text;

                objbo.AGENCY_ADDRESS = txtagencyaddress.Text;
                //  objbo.CREATION_DATE = date;
                //  objbo.UPDATION_DATE = date;
                objbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                // objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                objbo.search = btnSave.Text;
                // objbo.ISVISIBLE = "false";
                //objbo.Task = "Insert";

                //  objbo.REMARK1 = "";
                // objbo.REMARK1 = "";

                //bool i = objbal.Insert_Valuation(objbo);
                string strmsg = objbal.Insert_Valuation(objbo);
                if (strmsg == "exi")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Agency name already exist.');", true);
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record added successfully.');", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record added successfully";

                }
                bindvaluationGrid();
                clearcontrol();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }

            //Response.Redirect("Valuation_Master.aspx");
        }


        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    RegisterAsyncPostBackControls();
        //}
        //protected void RegisterAsyncPostBackControls()
        //{

        //    foreach (LinkButton l in ContentPlaceHolder1.Controls.OfType<LinkButton>())
        //        ScriptManager.GetCurrent(Page).RegisterAsyncPostBackControl(l);

        //    foreach (UpdatePanel upd in ContentPlaceHolder1.Controls.OfType<UpdatePanel>())
        //    {
        //        foreach (Control ctl in upd.Controls.OfType<Control>())
        //        {
        //            foreach (GridView grd in ctl.Controls.OfType<GridView>())
        //            {
        //                foreach (GridViewRow gvr in grd.Rows)
        //                    foreach (Control c in gvr.Controls)
        //                        foreach (LinkButton l in c.Controls.OfType<LinkButton>())
        //                            ScriptManager.GetCurrent(Page).RegisterAsyncPostBackControl(l);
        //            }
        //        }
        //    }
        //}

        protected void grdvaluation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {


                grdvaluation.EditIndex = e.NewEditIndex;
                this.bindvaluationGrid();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdvaluation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {


                bool val = true;
                DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                GridViewRow row = grdvaluation.Rows[e.RowIndex];
                objbo.AGENCY_ID = Convert.ToInt32(grdvaluation.DataKeys[e.RowIndex].Values[0]);
                objbo.AGENCY_NAME = (row.FindControl("txt_agency_name") as TextBox).Text;


                objbo.AGENCY_ADDRESS = (row.FindControl("txt_agency_address") as TextBox).Text;

                objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                objbo.search = (grdvaluation.Rows[e.RowIndex].FindControl("btn_Update") as LinkButton).Text;
                string strmsg = objbal.Insert_Valuation(objbo);
                if (strmsg == "exi")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Agency name is existed');", true);

                }
                else
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record updated successfully'); ", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record updated successfully";
                }
                grdvaluation.EditIndex = -1;
                this.bindvaluationGrid();



            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdvaluation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            try
            {
                grdvaluation.EditIndex = -1;
                bindvaluationGrid();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdvaluation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                objbo.AGENCY_ID = Convert.ToInt32(grdvaluation.DataKeys[e.RowIndex].Values[0]);
                // objbo.ISVISIBLE = "true";
                string result = objbal.valuationDelete(objbo);

                if (result == "Cannot")
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Valuation cannot be deleted, FMV price is already assigned to selected valuation.');", true);
                }
                else
                {

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Valuation deleted successfully.');", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Valuation deleted successfully";


                }

                bindvaluationGrid();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdvaluation_PreRender(object sender, EventArgs e)
        {

            DataSet ds = objbal.getAgency(objbo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdvaluation.DataSource = ds.Tables[0];
                grdvaluation.DataBind();

                grdvaluation.UseAccessibleHeader = true;
                grdvaluation.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}