using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESOP
{
    public partial class Tax_Master_New : System.Web.UI.Page
    {
        TaxBO taxbo = new TaxBO();
        TaxBAL taxbal = new TaxBAL();
        bool IsPageRefresh = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            showmsg.InnerText = "";
            if (!IsPostBack)
            {
                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();

                clearcontrol();
                bind_dataddl();
                bind_dataddl_GRD();
                DateTime myDateTime = DateTime.Now;
                int year = myDateTime.Year;
                int nextyear = year + 1;
                string combyear = Convert.ToString(year) + "-" + Convert.ToString(nextyear);
                //combyear = "1990-1991"; //to be commented in future
                taxbo.FINANCIAL_YEAR = combyear;

                //Commented by Krutika on 03-01-23
                //DataSet ds = taxbal.gettaxdata(taxbo);
                //ViewState["check"] = ds.Tables[1].Rows[0][0].ToString();
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    grdtax.DataSource = ds.Tables[0];
                //    grdtax.DataBind();
                //    // ViewState["Getvaluation"] = ds.Tables[0];

                //    grdtax.UseAccessibleHeader = true;
                //    grdtax.HeaderRow.TableSection = TableRowSection.TableHeader;
                //}
                //End

                //Added by Krutika on 03-01-23
                bindtaxGrid(combyear);
                bindTaxRegimeGrid(combyear);
                //End


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
            txtfrom.Text = txtto.Text = txtrate.Text = string.Empty;
            ddl_FaYrs.SelectedIndex = -1;
            ddlTaxRegime.SelectedIndex = -1;
        }

        private void bindtaxGrid(string Year)
        {
            taxbo.FINANCIAL_YEAR = Year;
            DataSet ds = taxbal.gettaxdata(taxbo);
            ViewState["check"] = ds.Tables[1].Rows[0][0].ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdtax.DataSource = ds.Tables[0];
                grdtax.DataBind();
                // ViewState["Getvaluation"] = ds.Tables[0];

                grdtax.UseAccessibleHeader = true;
                grdtax.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdtax.DataSource = ds.Tables[0];
                grdtax.DataBind();
                //  ViewState["Getvaluation"] = null;

                //grdtax.UseAccessibleHeader = true;
                //grdtax.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        //Added by Krutika on 02-01-23
        private void bindTaxRegimeGrid(string Year)
        {
            taxbo.FINANCIAL_YEAR = Year;
            DataSet ds = taxbal.getTaxRegimedata(taxbo);
            ViewState["check"] = ds.Tables[1].Rows[0][0].ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdTaxRegime.DataSource = ds.Tables[0];
                grdTaxRegime.DataBind();
                // ViewState["Getvaluation"] = ds.Tables[0];

                grdTaxRegime.UseAccessibleHeader = true;
                grdTaxRegime.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdTaxRegime.DataSource = ds.Tables[0];
                grdTaxRegime.DataBind();
            }
        }
        //End

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPageRefresh)
                {
                    return;
                }
                taxbo.INCOME_RANGE_FROM = (txtfrom.Text);
                taxbo.INCOME_RANGE_TO = (txtto.Text);
                taxbo.YEAR = ddl_FaYrs.SelectedItem.Text.ToString();
                taxbo.TAX_REGIME = ddlTaxRegime.SelectedValue.ToString();                          //Added by Krutika on 02-01-23
                //string count = taxbal.GET_F_YEAR_TAX_DATA(taxbo);

                DataSet ds = taxbal.GET_F_YEAR_TAX_DATA(taxbo);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                int lastrow_IncomeRangeToValues = -1;
                if (dt1.Rows.Count != 0)
                {
                    int lastrow = dt1.Rows.Count - 1;
                    lastrow_IncomeRangeToValues = Convert.ToInt32(dt1.Rows[lastrow]["INCOME_RANGE_TO"]);
                }
                if (dt2.Rows[0][0].ToString() != "0") // (count == "exi")
                {
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record already exists";
                }
                else if (dt.Rows[0][0].ToString() != "0" && dt1.Rows.Count != 0
                    && lastrow_IncomeRangeToValues + 1 != Convert.ToInt32(txtfrom.Text))
                {

                    Common.ShowJavascriptAlert("Income Range from should be" + lastrow_IncomeRangeToValues + 1);
                }
                else //if(dt.Rows[0][0].ToString() == "0") //if (Convert.ToString(ViewState["check"]) == txtfrom.Text)
                {
                    string message = "";
                    DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    // taxbo.FINANCIAL_YEAR = ddl_FaYrs.SelectedItem.Value.ToString();
                    taxbo.INCOME_RANGE_FROM = (txtfrom.Text);
                    taxbo.INCOME_RANGE_TO = (txtto.Text);
                    taxbo.TAX_RATE = (txtrate.Text);
                    taxbo.TAX_REGIME = ddlTaxRegime.SelectedValue.ToString();                                     //Added by Krutika on 02-01-23
                    taxbo.FINANCIAL_YEAR = ddl_FaYrs.SelectedItem.Text.ToString();
                    taxbo.CREATEDBY = Convert.ToString(Session["ECode"]);
                    bool strmsg = taxbal.Insert_tax(taxbo);

                    if (strmsg == true)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record added successfully');", true);
                        //showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        //showmsg.InnerText = "Record already exists";
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Record added successfully";
                    }
                    //else
                    //{
                    //    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    //    showmsg.InnerText = "Record added successfully";
                    //}

                    if (ddlTaxRegime.SelectedValue == "O")
                    {
                        bindtaxGrid(ddl_FaYrs.SelectedItem.Text);
                    }
                    else
                    {
                        bindTaxRegimeGrid(ddl_FaYrs.SelectedItem.Text);
                    }
                    clearcontrol();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void bind_dataddl()
        {
            try
            {
                DataSet ds = taxbal.Fill_Financial_Year();
                ddl_FaYrs.DataSource = ds.Tables[0];
                if (ds.Tables.Count > 0)
                {
                    ddl_FaYrs.DataTextField = "FINANCIAL_YEAR";
                    ddl_FaYrs.DataValueField = "ID";
                    ddl_FaYrs.DataBind();
                    ddl_FaYrs.Items.Insert(0, new ListItem("Select Financial Year", "0"));
                }


            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void bind_dataddl_GRD()
        {
            try
            {
                //taxbo.YEAR = ddl_Fa_Yrs.SelectedItem.Text.ToString();
                DataSet ds = taxbal.Fill_Financial_Year_DDL();
                ddl_Fa_Yrs.DataSource = ds.Tables[0];
                if (ds.Tables.Count > 0)
                {
                    ddl_Fa_Yrs.DataTextField = "FINANCIAL_YEAR";
                    ddl_Fa_Yrs.DataValueField = "ID";
                    ddl_Fa_Yrs.DataBind();
                    ddl_Fa_Yrs.Items.Insert(0, new ListItem("Select Financial Year", "0"));
                }

                ddlYear.DataSource = ds.Tables[0];
                if (ds.Tables.Count > 0)
                {
                    ddlYear.DataTextField = "FINANCIAL_YEAR";
                    ddlYear.DataValueField = "ID";
                    ddlYear.DataBind();
                    ddlYear.Items.Insert(0, new ListItem("Select Financial Year", "0"));
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void grdtax_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grdtax.EditIndex = e.NewEditIndex;

                //Added by Krutika on 03-01-23
                if (ddl_Fa_Yrs.SelectedValue == "0")
                {
                    DateTime myDateTime = DateTime.Now;
                    int year = myDateTime.Year;
                    int nextyear = year + 1;
                    string combyear = Convert.ToString(year) + "-" + Convert.ToString(nextyear);
                    this.bindtaxGrid(combyear);
                }
                else
                {
                    this.bindtaxGrid(ddl_Fa_Yrs.SelectedItem.Text);
                }
                //End
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }

        protected void grdtax_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = grdtax.Rows[e.RowIndex];
                int row_from = Convert.ToInt32((row.FindControl("txt_Income_Range_From") as TextBox).Text);
                int row_to = Convert.ToInt32((row.FindControl("txt_Income_Range_To") as TextBox).Text);

                bool strmsg = false;
                bool a_strmsg = false;
                bool b_strmsg = false;

                if (Convert.ToInt32(e.RowIndex - 1) >= 0)
                {
                    GridViewRow Brow = grdtax.Rows[Convert.ToInt32(e.RowIndex - 1)];
                    int brow_from = Convert.ToInt32((Brow.FindControl("lbl_Income_Range_From") as Label).Text);

                    if (brow_from < row_from && row_from < row_to)
                    {
                        taxbo.ID = Convert.ToInt32(grdtax.DataKeys[e.RowIndex].Values[0]);
                        taxbo.INCOME_RANGE_FROM = (row.FindControl("txt_Income_Range_From") as TextBox).Text;
                        taxbo.INCOME_RANGE_TO = (row.FindControl("txt_Income_Range_To") as TextBox).Text;
                        taxbo.TAX_RATE = (row.FindControl("txt_TAX_RATE") as TextBox).Text;
                        taxbo.TAX_REGIME = "O";                                                      //Added by Krutika on 02-01-23
                        taxbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                        taxbo.FINANCIAL_YEAR = (row.FindControl("txt_FINANCIAL_YEAR") as TextBox).Text;
                        strmsg = taxbal.Insert_tax(taxbo);

                        taxbo.ID = Convert.ToInt32(grdtax.DataKeys[e.RowIndex - 1].Values[0]);
                        taxbo.INCOME_RANGE_FROM = (Brow.FindControl("lbl_Income_Range_From") as Label).Text;
                        taxbo.INCOME_RANGE_TO = (Convert.ToInt32((row.FindControl("txt_Income_Range_From") as TextBox).Text) - 1).ToString();
                        taxbo.TAX_RATE = (Brow.FindControl("lbl_TAX_RATE") as Label).Text;
                        taxbo.TAX_REGIME = "O";                                                      //Added by Krutika on 02-01-23
                        taxbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                        taxbo.FINANCIAL_YEAR = (row.FindControl("txt_FINANCIAL_YEAR") as TextBox).Text;
                        b_strmsg = taxbal.Insert_tax(taxbo);
                    }
                    else
                    {
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Income Range overlaping with another Income Range.";
                    }
                }
                if (Convert.ToInt32(e.RowIndex + 1) <= Convert.ToInt32(grdtax.Rows.Count) - 1)
                {
                    GridViewRow arow = grdtax.Rows[Convert.ToInt32(e.RowIndex + 1)];
                    int arow_to = Convert.ToInt32((arow.FindControl("lbl_Income_Range_To") as Label).Text);

                    if (arow_to > row_to && row_from < row_to)
                    {
                        taxbo.ID = Convert.ToInt32(grdtax.DataKeys[e.RowIndex].Values[0]);
                        taxbo.INCOME_RANGE_FROM = (row.FindControl("txt_Income_Range_From") as TextBox).Text;
                        taxbo.INCOME_RANGE_TO = (row.FindControl("txt_Income_Range_To") as TextBox).Text;
                        taxbo.TAX_RATE = (row.FindControl("txt_TAX_RATE") as TextBox).Text;
                        taxbo.TAX_REGIME = "O";                                                      //Added by Krutika on 02-01-23
                        taxbo.FINANCIAL_YEAR = (row.FindControl("txt_FINANCIAL_YEAR") as TextBox).Text;
                        taxbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                        strmsg = taxbal.Insert_tax(taxbo);

                        taxbo.ID = Convert.ToInt32(grdtax.DataKeys[e.RowIndex + 1].Values[0]);
                        taxbo.INCOME_RANGE_FROM = (Convert.ToInt32((row.FindControl("txt_Income_Range_To") as TextBox).Text) + 1).ToString();
                        taxbo.INCOME_RANGE_TO = (arow.FindControl("lbl_Income_Range_To") as Label).Text;
                        taxbo.TAX_RATE = (arow.FindControl("lbl_TAX_RATE") as Label).Text;
                        taxbo.TAX_REGIME = "O";                                                      //Added by Krutika on 02-01-23
                        taxbo.FINANCIAL_YEAR = (row.FindControl("txt_FINANCIAL_YEAR") as TextBox).Text;
                        taxbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                        a_strmsg = taxbal.Insert_tax(taxbo);
                    }
                    else
                    {
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Income Range overlaping with another Income Range.";
                    }
                }
                if (Convert.ToInt32(e.RowIndex - 1) < 0 && Convert.ToInt32(e.RowIndex + 1) > Convert.ToInt32(grdtax.Rows.Count) && Convert.ToInt32(e.RowIndex) == 1)
                {
                    taxbo.ID = Convert.ToInt32(grdtax.DataKeys[e.RowIndex].Values[0]);
                    taxbo.INCOME_RANGE_FROM = (row.FindControl("txt_Income_Range_From") as TextBox).Text;
                    taxbo.INCOME_RANGE_TO = (row.FindControl("txt_Income_Range_To") as TextBox).Text;
                    taxbo.TAX_RATE = (row.FindControl("txt_TAX_RATE") as TextBox).Text;
                    taxbo.TAX_REGIME = "O";                                                      //Added by Krutika on 02-01-23
                    taxbo.FINANCIAL_YEAR = (row.FindControl("txt_FINANCIAL_YEAR") as TextBox).Text;

                    taxbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                    strmsg = taxbal.Insert_tax(taxbo);
                    if (strmsg == true)
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Record updated successfully";
                    }
                }
                if ((strmsg == true && b_strmsg == true) || (strmsg == true && a_strmsg == true))
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record updated successfully.');", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record updated successfully";
                }

                grdtax.EditIndex = -1;
                this.bindtaxGrid(taxbo.FINANCIAL_YEAR);
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        //Commented by Krutika on 03-01-23
        //protected void grdtax_PreRender(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //DataSet ds = taxbal.gettaxdata(taxbo);
        //        //if (ds.Tables[0].Rows.Count > 0)
        //        //{
        //        //    grdtax.DataSource = ds.Tables[0];
        //        //    grdtax.DataBind();

        //        //    grdtax.UseAccessibleHeader = true;
        //        //    grdtax.HeaderRow.TableSection = TableRowSection.TableHeader;
        //        //}

        //        //Added by Krutika on 03-01-23
        //        bindtaxGrid(ddl_FaYrs.SelectedItem.Text);
        //        //End
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

        //        throw ex;
        //    }
        //}
        //End

        protected void grdtax_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdtax.EditIndex = -1;

                //Added by Krutika on 03-01-23
                if (ddl_Fa_Yrs.SelectedValue == "0")
                {
                    DateTime myDateTime = DateTime.Now;
                    int year = myDateTime.Year;
                    int nextyear = year + 1;
                    string combyear = Convert.ToString(year) + "-" + Convert.ToString(nextyear);
                    this.bindtaxGrid(combyear);
                }
                else
                {
                    this.bindtaxGrid(ddl_Fa_Yrs.SelectedItem.Text);
                }
                //End
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdtax_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                taxbo.ID = Convert.ToInt32(grdtax.DataKeys[e.RowIndex].Values[0]);
                // objbo.ISVISIBLE = "true";
                bool result = taxbal.taxDelete(taxbo);

                if (result == true)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('.Record deleted successfully');", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record deleted successfully";
                }

                //Added by Krutika on 03-01-23
                if (ddl_Fa_Yrs.SelectedValue == "0")
                {
                    DateTime myDateTime = DateTime.Now;
                    int year = myDateTime.Year;
                    int nextyear = year + 1;
                    string combyear = Convert.ToString(year) + "-" + Convert.ToString(nextyear);
                    this.bindtaxGrid(combyear);
                }
                else
                {
                    this.bindtaxGrid(ddl_Fa_Yrs.SelectedItem.Text);
                }
                //End
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdtax_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //CultureInfo CInfo = new CultureInfo("hi-IN");

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label txtCol2 = (e.Row.FindControl("lbl_Income_Range_From") as Label);
            //    if (txtCol2 != null && txtCol2.Text != "")
            //    {
            //        txtCol2.Text = Convert.ToInt64(txtCol2.Text).ToString("N", CInfo);
            //    }

            //    Label txtCol1 = (e.Row.FindControl("lbl_Income_Range_To") as Label);
            //    if (txtCol1 != null && txtCol1.Text != "")
            //    {
            //        txtCol1.Text = Convert.ToInt64(txtCol1.Text).ToString("N", CInfo);
            //    }

            //}
        }

        protected void grdtax_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            CultureInfo CInfo = new CultureInfo("hi-IN");
            //Reference the GridView Row.
            GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;

            if (row.RowType == DataControlRowType.DataRow)
            {
                Label txtCol2 = (row.Cells[0].FindControl("lbl_Income_Range_From") as Label);
                if (txtCol2 != null && txtCol2.Text != "")
                {
                    txtCol2.Text = Convert.ToInt64(txtCol2.Text).ToString("N", CInfo);
                }

                Label txtCol1 = (row.Cells[1].FindControl("lbl_Income_Range_To") as Label);
                if (txtCol1 != null && txtCol1.Text != "")
                {
                    txtCol1.Text = Convert.ToInt64(txtCol1.Text).ToString("N", CInfo);
                }
            }
        }

        protected void txtto_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt64(txtfrom.Text) < Convert.ToInt64(txtto.Text))
            {
                return;
            }
            else
            {
                Common.ShowJavascriptAlert("Income Range To should be greater than Income Range From.");
            }
            clearcontrol();
        }

        protected void ddl_Fa_Yrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindtaxGrid(ddl_Fa_Yrs.SelectedItem.Text);
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindTaxRegimeGrid(ddlYear.SelectedItem.Text);
        }

        protected void grdTaxRegime_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grdTaxRegime.EditIndex = e.NewEditIndex;

                //Added by Krutika on 03-01-23
                if (ddlYear.SelectedValue == "0")
                {
                    DateTime myDateTime = DateTime.Now;
                    int year = myDateTime.Year;
                    int nextyear = year + 1;
                    string combyear = Convert.ToString(year) + "-" + Convert.ToString(nextyear);
                    this.bindTaxRegimeGrid(combyear);
                }
                else
                {
                    this.bindTaxRegimeGrid(ddlYear.SelectedItem.Text);
                }
                //End
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }

        protected void grdTaxRegime_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdTaxRegime_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = grdTaxRegime.Rows[e.RowIndex];
                int row_from = Convert.ToInt32((row.FindControl("txt_Income_Range_From") as TextBox).Text);
                int row_to = Convert.ToInt32((row.FindControl("txt_Income_Range_To") as TextBox).Text);

                bool strmsg = false;
                bool a_strmsg = false;
                bool b_strmsg = false;

                if (Convert.ToInt32(e.RowIndex - 1) >= 0)
                {
                    GridViewRow Brow = grdTaxRegime.Rows[Convert.ToInt32(e.RowIndex - 1)];
                    int brow_from = Convert.ToInt32((Brow.FindControl("lbl_Income_Range_From") as Label).Text);

                    if (brow_from < row_from && row_from < row_to)
                    {
                        taxbo.ID = Convert.ToInt32(grdTaxRegime.DataKeys[e.RowIndex].Values[0]);
                        taxbo.INCOME_RANGE_FROM = (row.FindControl("txt_Income_Range_From") as TextBox).Text;
                        taxbo.INCOME_RANGE_TO = (row.FindControl("txt_Income_Range_To") as TextBox).Text;
                        taxbo.TAX_RATE = (row.FindControl("txt_TAX_RATE") as TextBox).Text;
                        taxbo.TAX_REGIME = "N";                                                     //Added by Krutika on 02-01-23
                        taxbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                        taxbo.FINANCIAL_YEAR = (row.FindControl("txt_FINANCIAL_YEAR") as TextBox).Text;
                        strmsg = taxbal.Insert_tax(taxbo);

                        taxbo.ID = Convert.ToInt32(grdTaxRegime.DataKeys[e.RowIndex - 1].Values[0]);
                        taxbo.INCOME_RANGE_FROM = (Brow.FindControl("lbl_Income_Range_From") as Label).Text;
                        taxbo.INCOME_RANGE_TO = (Convert.ToInt32((row.FindControl("txt_Income_Range_From") as TextBox).Text) - 1).ToString();
                        taxbo.TAX_RATE = (Brow.FindControl("lbl_TAX_RATE") as Label).Text;
                        taxbo.TAX_REGIME = "N";                                                     //Added by Krutika on 02-01-23
                        taxbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                        taxbo.FINANCIAL_YEAR = (row.FindControl("txt_FINANCIAL_YEAR") as TextBox).Text;
                        b_strmsg = taxbal.Insert_tax(taxbo);
                    }
                    else
                    {
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Income Range overlaping with another Income Range.";
                    }
                }
                if (Convert.ToInt32(e.RowIndex + 1) <= Convert.ToInt32(grdTaxRegime.Rows.Count) - 1)
                {
                    GridViewRow arow = grdTaxRegime.Rows[Convert.ToInt32(e.RowIndex + 1)];
                    int arow_to = Convert.ToInt32((arow.FindControl("lbl_Income_Range_To") as Label).Text);

                    if (arow_to > row_to && row_from < row_to)
                    {
                        taxbo.ID = Convert.ToInt32(grdTaxRegime.DataKeys[e.RowIndex].Values[0]);
                        taxbo.INCOME_RANGE_FROM = (row.FindControl("txt_Income_Range_From") as TextBox).Text;
                        taxbo.INCOME_RANGE_TO = (row.FindControl("txt_Income_Range_To") as TextBox).Text;
                        taxbo.TAX_RATE = (row.FindControl("txt_TAX_RATE") as TextBox).Text;
                        taxbo.TAX_REGIME = "N";                                                     //Added by Krutika on 02-01-23
                        taxbo.FINANCIAL_YEAR = (row.FindControl("txt_FINANCIAL_YEAR") as TextBox).Text;
                        taxbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                        strmsg = taxbal.Insert_tax(taxbo);

                        taxbo.ID = Convert.ToInt32(grdTaxRegime.DataKeys[e.RowIndex + 1].Values[0]);
                        taxbo.INCOME_RANGE_FROM = (Convert.ToInt32((row.FindControl("txt_Income_Range_To") as TextBox).Text) + 1).ToString();
                        taxbo.INCOME_RANGE_TO = (arow.FindControl("lbl_Income_Range_To") as Label).Text;
                        taxbo.TAX_RATE = (arow.FindControl("lbl_TAX_RATE") as Label).Text;
                        taxbo.TAX_REGIME = "N";                                                     //Added by Krutika on 02-01-23
                        taxbo.FINANCIAL_YEAR = (row.FindControl("txt_FINANCIAL_YEAR") as TextBox).Text;
                        taxbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                        a_strmsg = taxbal.Insert_tax(taxbo);
                    }
                    else
                    {
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Income Range overlaping with another Income Range.";
                    }
                }
                if (Convert.ToInt32(e.RowIndex - 1) < 0 && Convert.ToInt32(e.RowIndex + 1) > Convert.ToInt32(grdTaxRegime.Rows.Count) && Convert.ToInt32(e.RowIndex) == 1)
                {
                    taxbo.ID = Convert.ToInt32(grdTaxRegime.DataKeys[e.RowIndex].Values[0]);
                    taxbo.INCOME_RANGE_FROM = (row.FindControl("txt_Income_Range_From") as TextBox).Text;
                    taxbo.INCOME_RANGE_TO = (row.FindControl("txt_Income_Range_To") as TextBox).Text;
                    taxbo.TAX_RATE = (row.FindControl("txt_TAX_RATE") as TextBox).Text;
                    taxbo.FINANCIAL_YEAR = (row.FindControl("txt_FINANCIAL_YEAR") as TextBox).Text;
                    taxbo.TAX_REGIME = "N";                                                     //Added by Krutika on 02-01-23
                    taxbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                    strmsg = taxbal.Insert_tax(taxbo);
                    if (strmsg == true)
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Record updated successfully";
                    }
                }
                if ((strmsg == true && b_strmsg == true) || (strmsg == true && a_strmsg == true))
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record updated successfully.');", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record updated successfully";
                }

                grdTaxRegime.EditIndex = -1;
                this.bindTaxRegimeGrid(taxbo.FINANCIAL_YEAR);
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }

        //Commented by Krutika on 03-01-23
        //protected void grdTaxRegime_PreRender(object sender, EventArgs e)
        //{
        //try
        //{
        //    DataSet ds = taxbal.getTaxRegimedata(taxbo);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        grdTaxRegime.DataSource = ds.Tables[0];
        //        grdTaxRegime.DataBind();

        //        grdTaxRegime.UseAccessibleHeader = true;
        //        grdTaxRegime.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //    throw ex;
        //}
        //}
        //End

        protected void grdTaxRegime_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            CultureInfo CInfo = new CultureInfo("hi-IN");
            //Reference the GridView Row.
            GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;

            if (row.RowType == DataControlRowType.DataRow)
            {
                Label txtCol2 = (row.Cells[0].FindControl("lbl_Income_Range_From") as Label);
                if (txtCol2 != null && txtCol2.Text != "")
                {
                    txtCol2.Text = Convert.ToInt64(txtCol2.Text).ToString("N", CInfo);
                }

                Label txtCol1 = (row.Cells[1].FindControl("lbl_Income_Range_To") as Label);
                if (txtCol1 != null && txtCol1.Text != "")
                {
                    txtCol1.Text = Convert.ToInt64(txtCol1.Text).ToString("N", CInfo);
                }
            }
        }

        protected void grdTaxRegime_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdTaxRegime.EditIndex = -1;

                //Added by Krutika on 03-01-23
                if (ddlYear.SelectedValue == "0")
                {
                    DateTime myDateTime = DateTime.Now;
                    int year = myDateTime.Year;
                    int nextyear = year + 1;
                    string combyear = Convert.ToString(year) + "-" + Convert.ToString(nextyear);
                    this.bindTaxRegimeGrid(combyear);
                }
                else
                {
                    this.bindTaxRegimeGrid(ddlYear.SelectedItem.Text);
                }
                //End
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }

        protected void grdTaxRegime_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                taxbo.ID = Convert.ToInt32(grdTaxRegime.DataKeys[e.RowIndex].Values[0]);
                // objbo.ISVISIBLE = "true";
                bool result = taxbal.taxDelete(taxbo);

                if (result == true)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('.Record deleted successfully');", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record deleted successfully";
                }

                //Added by Krutika on 03-01-23
                if (ddlYear.SelectedValue == "0")
                {
                    DateTime myDateTime = DateTime.Now;
                    int year = myDateTime.Year;
                    int nextyear = year + 1;
                    string combyear = Convert.ToString(year) + "-" + Convert.ToString(nextyear);
                    this.bindTaxRegimeGrid(combyear);
                }
                else
                {
                    this.bindTaxRegimeGrid(ddlYear.SelectedItem.Text);
                }
                //End
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }
    }
}