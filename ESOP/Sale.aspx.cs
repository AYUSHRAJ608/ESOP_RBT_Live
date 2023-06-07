
using ESOP_BAL;
using ESOP_BO;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESOP
{
    public partial class Sale : System.Web.UI.Page
    {
        GrandCreationBO objbo = new GrandCreationBO();
        GrandCreationBAL objbal = new GrandCreationBAL();
        FMVCreationBO objfmvbo = new FMVCreationBO();
        FMVCreationBAL objfmvbal = new FMVCreationBAL();
        bool IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            showmsg.InnerHtml = "";
            if (!IsPostBack)
            {

                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();

                GetFMV();
                GetSalesDates();
                GetValuedBy();
                bindsellgrid();
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

        private void bindsellgrid()
        {
            try
            {
                DataSet ds = objbal.ESOP_GET_EXCISE_sell_GRIDDATA();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    grdsell.DataSource = ds.Tables[1];
                    grdsell.DataBind();
                    // ViewState["Getvaluation"] = ds.Tables[0];

                    //grdsell.UseAccessibleHeader = true;
                    //grdsell.HeaderRow.TableSection = TableRowSection.TableHeader;


                }
                else
                {
                    grdsell.DataSource = ds.Tables[1];
                    grdsell.DataBind();
                    //  ViewState["Getvaluation"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }
        protected void GetFMV()
        {
            try
            {

                DataSet ds = objbal.GetDropDown();
                ddlFMV.DataSource = ds.Tables[1];
                if (ds.Tables.Count > 0)
                {
                    ddlFMV.DataTextField = "FMV_PRICE";
                    ddlFMV.DataValueField = "FMV_CREATION_ID";
                    ddlFMV.DataBind();
                    ddlFMV.Items.Insert(0, new ListItem("Select FMV", "0"));

                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }

        }
        protected void btncreatefmv_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                string fileName = FileUpload1.FileName;

                if (fileName == "")
                {
                }
                else
                {
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Fmv_excel/" + fileName));
                }


                // string fileName = Path.GetFileName(FullFilename);

                //   HttpContext.Current.Server.MapPath("/Fmv_excel" + fileName);




                //string fileName = "";
                objfmvbo.VALUATION_DATE = Convert.ToDateTime(txtvaldate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);//(txtvaldate.Text);

                objfmvbo.VALID_UPTO_DATE = Convert.ToDateTime(txtvalidupto.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);//(txtvalidupto.Text);

                objfmvbo.FMV_PRICE = (txtfmvprice.Text);
                objfmvbo.VALUED_BY = ddlvaluedby.SelectedValue.ToString();
                objfmvbo.UPLOAD_FILE = fileName;
                // objfmvbo.CREATION_DATE = date;
                //  objfmvbo.UPDATATION_DATE = date;
                //  objfmvbo.ISVISIBLE = "";
                objfmvbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                objfmvbo.UPDATED_BY = "";
                //  objfmvbo.REMARK1 = "";
                //  objfmvbo.REMARK1 = "";
                objfmvbo.btntext = "CREATE";
                string strmsg = objfmvbal.Insert_Fmv(objfmvbo);

                GetFMV();
                txtfmvprice.Text = "";
                ddlvaluedby.SelectedIndex = -1;
                if (strmsg == "exi")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV price already exist'); ", true);
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV added successfully'); ", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "FMV created successfully";
                }
                ClearFMVControl();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        private void ClearFMVControl()
        {
            txtvaldate.Text = "";
            txtvalidupto.Text = "";
        }
        private void GetValuedBy()
        {
            try
            {
                DataTable ds = objfmvbal.getvaluedbyddl(objfmvbo);
                if (ds.Rows.Count > 0)
                {
                    ddlvaluedby.DataSource = ds;
                    ddlvaluedby.DataBind();
                    ddlvaluedby.DataTextField = "Valued_By";
                    ddlvaluedby.DataValueField = "AGENCY_ID";
                    ddlvaluedby.DataBind();
                    ddlvaluedby.Items.Insert(0, new ListItem("Select", "0"));


                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPageRefresh)
                {
                    return;
                }




                objbo.EMP_ID = Session["ECode"].ToString();
                objbo.FMV_ID = Convert.ToInt32(ddlFMV.SelectedValue.ToString());
                if (ddlSaleDate.SelectedValue != "0")
                {
                    string[] commandArgs = ddlSaleDate.SelectedItem.Text.ToString().Split(new string[] { " to " }, StringSplitOptions.None);
                    objbo.Start_Date = Convert.ToDateTime(txtstartdate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objbo.End_Date = Convert.ToDateTime(txtenddate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objbo.SaleID = Convert.ToInt32(Session["SaleID"]);
                    objbo.Key = "UPDATE";
                }
                else
                {
                    if (txtstartdate.Text != "" || txtenddate.Text != "")
                    {
                        DataSet Ds_Validation = new DataSet();
                        objbo.Start_Date = Convert.ToDateTime(txtstartdate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                        objbo.End_Date = Convert.ToDateTime(txtenddate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                        objbo.Key = "SALE";
                        Ds_Validation = objbal.ESOP_GET_EXERCISE_SALE_VALIDATION(objbo);
                        if (Convert.ToInt32(Ds_Validation.Tables[0].Rows[0][0]) > 0)
                        {
                            Common.ShowJavascriptAlert("Sale window already exist for selected date");
                            txtstartdate.Text = "";
                            txtenddate.Text = "";
                            return;
                        }
                    }
                    objbo.Start_Date = Convert.ToDateTime(txtstartdate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objbo.End_Date = Convert.ToDateTime(txtenddate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objbo.Key = "INSERT";
                }

                DataSet ds = objbal.Insert_sale(objbo);
                //   string emailid = ds.Tables[0].Rows[0]["emailid"].ToString();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Sell window created successfully');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";

                showmsg.InnerText = "Sale window created successfully";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), "", "Sell", "Sell Completed", "", "", "", "", "", "", "");
                    }

                }
                bindsellgrid();
                GetSalesDates();
                ClearInputs(Page.Controls);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "D1();", true);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "D2();", true);
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
               
            }

        }

        protected void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();

                ClearInputs(ctrl.Controls);

            }
        }


        protected void txtenddate_TextChanged1(object sender, EventArgs e)
        {
            if (txtstartdate.Text == "")
            {
            }

            else if (txtenddate.Text == "")
            {
            }
            else
            {
                bindfmvondate();
            }
        }

        protected void txtstartdate_TextChanged(object sender, EventArgs e)
        {
            if (txtstartdate.Text == "")
            {
            }


            else if (txtenddate.Text == "")
            {
            }
            else
            {
                bindfmvondate();
            }
        }

        private void bindfmvondate()
        {
            objbo.Start_Date = Convert.ToDateTime(txtstartdate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

            objbo.End_Date = Convert.ToDateTime(txtenddate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            objbo.FMV_PRICE = Convert.ToDecimal(0);
            DataSet ds = objbal.get_sell_datewise_fmv(objbo);
            ddlFMV.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlFMV.DataTextField = "FMV_PRICE";
                ddlFMV.DataValueField = "FMV_CREATION_ID";
                ddlFMV.DataBind();
                ddlFMV.Items.Insert(0, new ListItem("Select FMV", "0"));


            }
            else
            {
                //
                //  string display2 = "";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "displayimg();", true);


                ddlFMV.DataSource = ds.Tables[0];
                ddlFMV.DataBind();
                ddlFMV.Items.Insert(0, new ListItem("Select FMV", "0"));
                Common.ShowJavascriptAlert("FMV price isn't available for selected sale date");
            }
        }

        protected void grdsell_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objbal.ESOP_GET_EXCISE_sell_GRIDDATA();
            if (ds.Tables[1].Rows.Count > 0)
            {


                grdsell.UseAccessibleHeader = true;
                grdsell.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdsell_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdsell, "Select$" + e.Row.RowIndex);

                e.Row.Attributes["style"] = "cursor:pointer";


            }
        }

        protected void grdsell_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int index = grdsell.SelectedRow.RowIndex;
            //Label lblStart = (Label)grdsell.Rows[index].FindControl("lblstrtdate");
            //Label lblEnd = (Label)grdsell.Rows[index].FindControl("lbltodate");
            //string date1 = lblStart.Text;
            //string date2 = lblEnd.Text;

            //objbo.Start_Date = Convert.ToDateTime(date1, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            //objbo.End_Date = Convert.ToDateTime(date2, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

            int index = grdsell.SelectedIndex;
            // objbo.ExercisedID = Convert.ToInt32(grdsell.SelectedValue.ToString());
            objbo.SaleID = Convert.ToInt32(grdsell.DataKeys[index].Value.ToString());

            objbo.Start_Date = Convert.ToDateTime(DateTime.Now);

            objbo.End_Date = Convert.ToDateTime(DateTime.Now);

            DataSet ds = objbal.get_sell_datewise_fmv(objbo);

            ViewState["Emp_filterRec"] = null;
            ViewState["Emp_filterRec"] = ds.Tables[1];
            if (ds.Tables[1].Rows.Count > 0)

            {
                grdempsell.DataSource = ds.Tables[1];
                grdempsell.DataBind();
                // grdempexercise.UseAccessibleHeader = true;
                // grdempexercise.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdempsell.DataSource = ds.Tables[1];
                grdempsell.DataBind();
            }



            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }

        protected void GetSalesDates()
        {
            DataSet ds = objbal.GetSaleDates();
            ddlSaleDate.DataSource = ds.Tables[0];
            if (ds.Tables.Count > 0)
            {
                ddlSaleDate.DataTextField = "Sale_Date";
                ddlSaleDate.DataValueField = "SALE_ID";
                ddlSaleDate.DataBind();
                ddlSaleDate.Items.Insert(0, new ListItem("Select Sale Dates", "0"));
            }
        }

        protected void ddlSaleDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSaleDate.SelectedValue != "0")
            {
                string[] commandArgs = ddlSaleDate.SelectedItem.Text.ToString().Split(new string[] { " to " }, StringSplitOptions.None);
                txtstartdate.Text = Convert.ToDateTime(commandArgs[0].ToString().Trim()).ToString("dd-MM-yyyy");
                txtenddate.Text = Convert.ToDateTime(commandArgs[1].ToString().Trim()).ToString("dd-MM-yyyy");
                objbo.Start_Date = Convert.ToDateTime(commandArgs[0].ToString().Trim(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                objbo.End_Date = Convert.ToDateTime(commandArgs[1].ToString().Trim(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                Session["SaleID"] = ddlSaleDate.SelectedValue.ToString();
                DataSet ds = objbal.get_sell_datewise_fmv(objbo);
                ddlFMV.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlFMV.DataTextField = "FMV_PRICE";
                    ddlFMV.DataValueField = "FMV_CREATION_ID";
                    ddlFMV.DataBind();
                    ddlFMV.Items.Insert(0, new ListItem("Select FMV", "0"));
                }
                else
                {
                    ddlFMV.DataSource = ds.Tables[0];
                    ddlFMV.DataBind();
                    ddlFMV.Items.Insert(0, new ListItem("Select FMV", "0"));
                }
            }
        }

        protected void grdempsell_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdempsell.PageIndex = e.NewPageIndex;
            DataTable ds = (DataTable)ViewState["Emp_filterRec"];
            if (ds.Rows.Count > 0)
            {
                grdempsell.DataSource = ds;
                grdempsell.DataBind();
            }
        }

        protected void grdempsell_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)
            {
                ViewState["SortDirection"] = "ASC";
                grdempsell.PageIndex = 0;
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

            DataTable dt = (DataTable)ViewState["Emp_filterRec"];
            if (dt != null)
            {
                dt.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + ViewState["SortDirection"].ToString();
                grdempsell.DataSource = dt;
                grdempsell.DataBind();
            }
        }

        protected void grdempsell_PreRender(object sender, EventArgs e)
        {
            DataTable ds = (DataTable)ViewState["Emp_filterRec"];

            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {
                    grdempsell.UseAccessibleHeader = true;
                    grdempsell.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }
    }
}
