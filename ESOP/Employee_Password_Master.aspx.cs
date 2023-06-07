using ESOP_BAL;
using ESOP_BO;
using it = iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace ESOP
{
    public partial class Employee_Password_Master : System.Web.UI.Page
    {
        FMVCreationBO objbo = new FMVCreationBO();
        FMVCreationBAL objbal = new FMVCreationBAL();
        bool IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            showmsg.InnerText = "";
            if (!IsPostBack)
            {
                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();
                bindfmvGrid();
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


        private void bindfmvGrid()
        {
            try
            {
                objbo.btntext = "";//btncreatefmv.Text;
                DataSet ds = objbal.Insert_Emp_Password(objbo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdfmv.DataSource = ds.Tables[0];
                    grdfmv.DataBind();

                    grdfmv.UseAccessibleHeader = true;
                    grdfmv.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                else
                {
                    grdfmv.DataSource = ds.Tables[0];
                    grdfmv.DataBind();
                }
                ViewState["Emp_filterRec"] = null;
                ViewState["Data"] = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }
        protected void grdfmv_PreRender(object sender, EventArgs e)
        {
            DataTable ds = (DataTable)ViewState["Data"];
            if (ds.Rows.Count > 0)
            {
                grdfmv.UseAccessibleHeader = true;
                grdfmv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        private void clearcontrol()
        {
            txtfmvprice.Text = string.Empty;

        }

        protected void btncreatefmv_Click(object sender, EventArgs e)
        {
            try
            {

                if (IsPageRefresh)
                {
                    return;
                }
                objbo.msg = txtfmvprice.Text;
                objbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                objbo.UPDATED_BY = "";
                objbo.btntext = "CREATE";//btncreatefmv.Text;
                DataSet ds = objbal.Insert_Emp_Password(objbo);

                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Employee Password created successfully";

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "displayimg('" + showmsg.InnerText + "');", true);
                bindfmvGrid();
                clearcontrol();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;

            }

        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {


            string filename = (sender as LinkButton).CommandArgument;
            string filePath = Server.MapPath(filename);
            if (System.IO.File.Exists(filePath) && Path.HasExtension(filePath))
            {
                ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
                ViewState["filepath"] = filename.Replace("~/", "");
            }
            else
            {

                Common.ShowJavascriptAlert("File is not uploded for selected FMV.");
            }

        }

        protected void grdfmv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdfmv.PageIndex = e.NewPageIndex;
            this.bindfmvGrid();
        }

        protected void grdfmv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grdfmv.EditIndex = e.NewEditIndex;
                this.bindfmvGrid();


            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdfmv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                GridViewRow row = grdfmv.Rows[e.RowIndex];
                objbo.FMV_CREATION_ID = Convert.ToInt32(grdfmv.DataKeys[e.RowIndex].Values[0]);
                objbo.VALUATION_DATE = Convert.ToDateTime((row.FindControl("txtvaldate_Grid") as TextBox).Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);//Convert.ToDateTime(row.FindControl("txtvaldate_Grid") as TextBox); 
                objbo.VALID_UPTO_DATE = Convert.ToDateTime((row.FindControl("txtvaliduptodate") as TextBox).Text,
System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat); //(row.FindControl("txtvaliduptodate") as TextBox).Text;

                objbo.FMV_PRICE = (row.FindControl("txtfmvprice") as TextBox).Text;
                objbo.VALUED_BY = (row.FindControl("DropDownList1") as DropDownList).SelectedValue;

                objbo.CREATED_BY = "";
                objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                objbo.btntext = "UPDATE";
                //objbal.Insert_Fmv(objbo);
                string strmsg = objbal.Insert_Fmv(objbo);
                if (strmsg == "exi")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV date already exist'); ", true);
                }
                //else if (strmsg == "cannot")
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV price cannot be updated, FMV price is already assigned to grant.'); ", true);



                //}


                else
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV updated successfully'); ", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "FMV updated successfully";
                }
                grdfmv.EditIndex = -1;
                this.bindfmvGrid();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdfmv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdfmv.EditIndex = -1;
                bindfmvGrid();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdfmv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                objbo.FMV_CREATION_ID = Convert.ToInt32(grdfmv.DataKeys[e.RowIndex].Values[0]);
                string result = objbal.FmvDelete(objbo);
                if (result == "Cannot")
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV cannot be deleted, FMV price is already assigned to grant.');", true);
                }
                else
                {

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV deleted successfully.');", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "FMV deleted successfully";

                }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "displayimg('" + showmsg.InnerText + "');", true);


                bindfmvGrid();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        //protected void txtvaluedby_TextChanged(object sender, EventArgs e)
        //{
        //    DataSet ds = objbal.getvaluedbyddl(objbo);
        //    if (ds.Tables.Count > 0)
        //    {
        //        grdfmv.DataSource = ds;
        //        grdfmv.DataBind();
        //         txtvaldate. = "AGENCY_NAME";
        //        ddltxtvaluedby.DataValueField = "AGENCY_ID";
        //    }}



        protected void grdfmv_RowDataBound(object sender, GridViewRowEventArgs e)

        {

            //    if (e.Row.RowType == DataControlRowType.DataRow && grdfmv.EditIndex == e.Row.RowIndex)
            //    {

            //        TextBox txtvaldate_Grid = e.Row.FindControl("txtvaldate_Grid") as TextBox;
            //        txtvaldate_Grid.Attributes.Add("readonly", "readonly");

            //        TextBox txtvaliduptodate = e.Row.FindControl("txtvaliduptodate") as TextBox;
            //        txtvaliduptodate.Attributes.Add("readonly", "readonly");

            //    }
        }

        protected void grdfmv_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                grdfmv.DataSource = dtrslt;
                grdfmv.DataBind();
            }
        }



        protected void grdfmv_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}