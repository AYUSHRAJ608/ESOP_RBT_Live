using AjaxControlToolkit;
using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESOP
{
    public partial class employee_exercise_new : System.Web.UI.Page
    {
        public int Show = 0;
        employee_exerciseBO objBO;
        employee_exerciseBAL objBAL = new employee_exerciseBAL();
        protected string UploadFolderPath = "~/Exercise_Doc/";
        bool IsPageRefresh = false;
        CultureInfo CInfo = new CultureInfo("hi-IN");
        protected string inputtypeCheque;
        protected string inputtypeNEFT;
        protected string inputtypeLoan;
        public string RadiobvuttonValue;
        string msg = "";
        string Tranch_Vesting = "";
        //Added on 16-12-2021
        Employee_profileBO objbo = new Employee_profileBO();
        Employee_profileBAL objbal = new Employee_profileBAL();

        employee_exerciseBO obj_Emp_BO = new employee_exerciseBO();
        employee_exerciseBAL obj_Emp_BAL = new employee_exerciseBAL();

        TaxBO taxbo = new TaxBO();
        TaxBAL taxbal = new TaxBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DataSet ds = new DataSet();
                    string id = Convert.ToString(Session["ECODE"]);
                    ds = objBAL.GET_Employee_Exercise_Data_NEW(id); // changed from GET_Employee_Admin_Main_Data_2 on 27-05-2022 by Rahul_Natu

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["PENDING_WITH"].ToString() == "Pending with Secreterial")
                        {
                            showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                            msg = "Exercise is pending for approval by Secreterial";
                            lblmsg4.Text = msg;
                            lblmsg4.Visible = true;
                            DisablePageControls(false);
                        }
                        if (ds.Tables[0].Rows[0]["PENDING_WITH"].ToString() == "Pending with Admin")
                        {
                            showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                            msg = "Exercise is pending for approval by Admin";
                            lblmsg4.Text = msg;
                            lblmsg4.Visible = true;
                            DisablePageControls(false);
                        }
                        if (ds.Tables[0].Rows[0]["PENDING_WITH"].ToString() == "Doc Upload Pending")
                        {
                            showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                            msg = "Document is pending for upload by Admin";
                            lblmsg4.Text = msg;
                            lblmsg4.Visible = true;
                            DisablePageControls(false);
                        }
                        if (ds.Tables[0].Rows[0]["PENDING_WITH"].ToString() == "Pending with Employee")
                        {
                            showmsg.Attributes["style"] = "color:Green; font-weight:bold;text-align: center;";
                            msg = "Exercise detail is approved by Admin. Please Complete the form";
                            lblmsg4.Text = msg;
                            lblmsg4.Visible = true;
                            DisablePageControls(true);
                        }
                    }
                    else
                    {
                        gvExerciseCal.Columns[6].Visible = false;
                        gvExerciseCal.Columns[7].Visible = false;
                    }

                    DateTime myDateTime = DateTime.Now;
                    int year = myDateTime.Year;
                    int nextyear = year + 1;
                    string combyear = Convert.ToString(year) + "-" + Convert.ToString(nextyear);
                    //combyear = "1990-1991"; //to be commented in future
                    taxbo.FINANCIAL_YEAR = combyear;
                    DataSet dstax = taxbal.gettaxdata(taxbo);

                    if (dstax.Tables[0].Rows.Count < 0)
                    {
                        showmsg.Visible = true;
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        msg = "Tax Slab for Current Year is not submitted";
                        lblmsg5.Text = msg;
                        lblmsg5.Visible = true;
                        DisablePageControls(false);
                    }

                    if (Convert.ToString(Session["Done"]) == "Done")
                    {
                        Session["Done"] = "";
                    }
                    else
                    {
                        showmsg.Visible = true;
                    }

                    if (Convert.ToBoolean(Session["Checkerlblmsg1"]) == true)
                    {
                        showmsg.Visible = true;
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        msg = "Please submit Bank details for login Employee";
                        lblmsg1.Text = msg;
                        lblmsg1.Visible = true;
                        //btnmsg1.Visible = true;
                        Session["Checkerlblmsg1"] = false;
                    }

                    if (Convert.ToBoolean(Session["Checkerlblmsg2"]) == true)
                    {
                        showmsg.Visible = true;
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        msg = "Please submit Demat details for login Employee";
                        lblmsg2.Text = msg;
                        lblmsg2.Visible = true;
                        //btnmsg2.Visible = true;
                        Session["Checkerlblmsg2"] = false;
                    }
                    if (lblmsg3.Text == "Exercise window is closed or not been created by admin")
                    {
                        btnPreview.Visible = false;
                    }
                    //txtChequeDate.Attributes.Add("readonly", "readonly");
                    //if (lblmsg1.Text == "Please submit Bank details for login Employee"
                    //    || lblmsg2.Text == "Please submit Demat details for login Employee"
                    //    || lblmsg3.Text == "Exercise window is closed or not been created by admin")
                    //{
                    //    //DisablePageControls(false);
                    //}
                    //else
                    //{
                    //    //DisablePageControls(true);
                    //}
                    //if (!IsPostBack)
                    //{
                    Session.Remove("Emp_Exercise_Session");
                    Session.Remove("NEFT_FilePath");
                    Session.Remove("Cheque_FilePathFresh");
                    Session.Remove("NEFT_FilePathLoan");
                    Session.Remove("Cheque_FilePathLoanFresh");
                    Session.Remove("Cheque_FilePathLoanFresh");
                    Session.Remove("NEFT_FilePathLoan");

                    bool xBank = GET_EMP_BANK_DETAILS();
                    if (xBank == false)
                    {
                        showmsg.Visible = true;
                        lblmsg1.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        msg = "Please submit Bank details for login Employee";
                        lblmsg1.Text = msg;
                        lblmsg1.Visible = true;
                        //btnmsg1.Visible = true;
                        //Session["msg"] = msg;
                        //showmsg.InnerText = "Please submit Bank details for login Employee";
                        //return;
                    }

                    bool yDemat = GET_EMP_DEMAT_DETAILS();
                    if (yDemat == false)
                    {
                        showmsg.Visible = true;
                        lblmsg2.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        msg = "Please submit Demat details for login Employee";
                        lblmsg2.Text = msg;
                        lblmsg2.Visible = true;
                        //btnmsg2.Visible = true;
                        //Session["msg"] = msg;
                        //showmsg.InnerText = "Please submit Demat details for login Employee";
                        //return;
                    }

                    objBO = new employee_exerciseBO();
                    Session["Emp_Exercise_Session"] = "";
                    ViewState["Grd_Session"] = "";

                    objBO.ECODE = Convert.ToString(Session["ECODE"]);
                    DataSet ds1 = objBAL.GET_SESSION(objBO);
                    if (ds1.Tables[0].Rows.Count > 0 && ds1.Tables[1].Rows.Count > 0)
                    {
                        //if (Session["msg"].ToString() != "")
                        //{
                        Feeldata(ds1);
                        //}

                    }

                    DataSet ds2 = objBAL.GET_ECERCISE_WINDOW();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        lblmsg3.Visible = false;
                        objBO = new employee_exerciseBO();
                        Session["EXERCISE_ID"] = Convert.ToInt32(ds2.Tables[0].Rows[0]["EXERCISE_id"]);
                        Session["START_DATE"] = Convert.ToString(ds2.Tables[0].Rows[0]["START_DATE"]);
                        Session["exercise_ID"] = Convert.ToString(ds2.Tables[0].Rows[0]["exercise_ID"]);
                        Session["FMV_PRICE"] = Convert.ToString(ds2.Tables[0].Rows[0]["FMV_PRICE"]);
                        BIND_EXERCISE_GRID();
                    }
                    else
                    {
                        showmsg.Visible = true;
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        msg = "Exercise window is closed or not been created by admin";
                        lblmsg3.Text = msg;
                        lblmsg3.Visible = true;
                        btnPreview.Visible = false;
                        DisablePageControls(true);
                    }

                    //if (lblmsg1.Text == "Please submit Bank details for login Employee"
                    //|| lblmsg2.Text == "Please submit Demat details for login Employee"
                    //|| lblmsg3.Text == "Exercise window is closed or not been created by admin")
                    //{
                    //    //DisablePageControls(false);
                    //}
                    //else
                    //{
                    //    //DisablePageControls(true);
                    //}
                    if (Convert.ToString(ViewState["Grd_Session"]) == "True")
                    {

                        txtLoanAmount.Text = Convert.ToString(ViewState["LoanAmount"]);
                        txtLoanMarginAmount.Text = Convert.ToString(ViewState["LoanMarginAmount"]);
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        if ((Convert.ToString(ds.Tables[1].Rows[0]["DETAIL_STATUS"]).Trim() == "" && Convert.ToString(ds.Tables[1].Rows[0]["STATUS"]).Trim() == "") ||
                           (Convert.ToString(ds.Tables[1].Rows[0]["DETAIL_STATUS"]).Trim() == "APPROVED_BY_ADMIN" && Convert.ToString(ds.Tables[1].Rows[0]["STATUS"]).Trim() == "Approved") ||
                           (Convert.ToString(ds.Tables[1].Rows[0]["DETAIL_STATUS"]).Trim() == "REJECTED_BY_ADMIN" && Convert.ToString(ds.Tables[1].Rows[0]["STATUS"]).Trim() == "") ||
                           (Convert.ToString(ds.Tables[1].Rows[0]["DETAIL_STATUS"]).Trim() == "APPROVED_BY_ADMIN" && Convert.ToString(ds.Tables[1].Rows[0]["STATUS"]).Trim() == "REJECTED_BY_ADMIN") ||
                           (Convert.ToString(ds.Tables[1].Rows[0]["DETAIL_STATUS"]).Trim() == "APPROVED_BY_ADMIN" && Convert.ToString(ds.Tables[1].Rows[0]["STATUS"]).Trim() == "Reject"))
                        {
                            DisablePageControls(false);
                            btnSubmit.Visible = true;
                            btnSubmit.Enabled = true;

                            //    btnFinalSubmit.Enabled = false;
                            btnFinalSubmit.Visible = false;

                            //    btnPreview.Visible = false;
                            btnPreview.Enabled = false;

                            //    btnmsg1.Enabled = false;
                            btnmsg1.Visible = false;
                            lblmsg1.Visible = false;

                            //    btnmsg2.Enabled = false;
                            btnmsg2.Visible = false;
                            lblmsg2.Visible = false;

                            ddlChequeBankName.Enabled = false;
                            ddlOtherSecurity.Enabled = false;
                            ddlLoanMarginMode.Enabled = false;
                            ddlNEFTBankName.Enabled = false;

                            fuCheque.Enabled = false;
                            fuNEFT1.Enabled = false;
                            fuChequeLoan.Enabled = false;
                            fuNEFTLoan.Enabled = false;
                            calcel_cheque_file.Enabled = false;
                            fileuploadproof.Enabled = false;

                            foreach (GridViewRow gr in gvExercise.Rows)
                            {
                                TextBox txtOptionsExercised = new TextBox();
                                txtOptionsExercised = (TextBox)gr.FindControl("txtOptionsExercised");

                                if (gr.RowIndex < (Convert.ToInt32(gvExercise.Rows.Count) - 1))
                                {
                                    txtOptionsExercised.Enabled = true;
                                }
                            }
                        }
                        else if ((Convert.ToString(ds.Tables[1].Rows[0]["DETAIL_STATUS"]).Trim() == "Pending" && Convert.ToString(ds.Tables[1].Rows[0]["STATUS"]).Trim() == "") ||
                            (Convert.ToString(ds.Tables[1].Rows[0]["DETAIL_STATUS"]).Trim() == "APPROVED_BY_ADMIN" && Convert.ToString(ds.Tables[1].Rows[0]["STATUS"]).Trim() == "Pending") ||
                            (Convert.ToString(ds.Tables[1].Rows[0]["DETAIL_STATUS"]).Trim() == "APPROVED_BY_ADMIN" && Convert.ToString(ds.Tables[1].Rows[0]["STATUS"]).Trim() == "APPROVED_BY_ADMIN"))
                        {
                            DisablePageControls(false);
                            //    btnSubmit.Enabled = false;
                            btnSubmit.Visible = false;

                            //    btnFinalSubmit.Enabled = false;
                            btnFinalSubmit.Visible = false;

                            //    btnPreview.Enabled = false;
                            btnPreview.Visible = false;

                            //    btnmsg1.Enabled = false;
                            btnmsg1.Visible = false;
                            lblmsg1.Visible = false;

                            //    btnmsg2.Enabled = false;
                            btnmsg2.Visible = false;
                            lblmsg2.Visible = false;

                            ddlChequeBankName.Enabled = false;
                            ddlOtherSecurity.Enabled = false;
                            ddlLoanMarginMode.Enabled = false;
                            ddlNEFTBankName.Enabled = false;

                            fuCheque.Enabled = false;
                            fuNEFT1.Enabled = false;
                            fuChequeLoan.Enabled = false;
                            fuNEFTLoan.Enabled = false;
                            calcel_cheque_file.Enabled = false;
                            fileuploadproof.Enabled = false;

                            foreach (GridViewRow gr in gvExercise.Rows)
                            {
                                TextBox txtOptionsExercised = new TextBox();
                                txtOptionsExercised = (TextBox)gr.FindControl("txtOptionsExercised");
                                txtOptionsExercised.Enabled = false;

                                TextBox TxtPendingAPP = new TextBox();
                                TxtPendingAPP = (TextBox)gr.FindControl("TxtPendingAPP");
                                txtOptionsExercised.Text = TxtPendingAPP.Text;

                                if (gr.RowIndex < (Convert.ToInt32(gvExercise.Rows.Count) - 1))
                                {
                                    txtOptionsExercised_TextChanged(txtOptionsExercised, e);
                                }
                            }

                            foreach (GridViewRow gr in gvExercise.Rows)
                            {
                                if (gr.RowIndex < (Convert.ToInt32(gvExercise.Rows.Count) - 1))
                                {
                                    TextBox txtOptionsExercised = new TextBox();
                                    txtOptionsExercised = (TextBox)gr.FindControl("txtOptionsExercised");
                                    txtOptionsExercised.Enabled = false;

                                    TextBox TxtPendingAPP = new TextBox();
                                    TxtPendingAPP = (TextBox)gr.FindControl("TxtPendingAPP");
                                    txtOptionsExercised.Text = TxtPendingAPP.Text;
                                }
                            }
                        }
                        else if (Convert.ToString(ds.Tables[1].Rows[0]["DETAIL_STATUS"]).Trim() == "APPROVED_BY_ADMIN" && Convert.ToString(ds.Tables[1].Rows[0]["STATUS"]).Trim() == "")
                        {
                            DisablePageControls(true);
                            btnSubmit.Visible = false;
                            btnSubmit.Enabled = false;

                            //    btnPreview.Enabled = true;
                            btnPreview.Visible = true;

                            //    btnmsg1.Enabled = true;
                            btnmsg1.Visible = true;
                            lblmsg1.Visible = true;

                            //    btnmsg2.Enabled = true;
                            btnmsg2.Visible = true;
                            lblmsg2.Visible = true;

                            //    btnFinalSubmit.Enabled = true;
                            btnFinalSubmit.Visible = true;

                            ddlChequeBankName.Enabled = true;
                            ddlOtherSecurity.Enabled = true;
                            ddlLoanMarginMode.Enabled = true;
                            ddlNEFTBankName.Enabled = true;

                            fuCheque.Enabled = true;
                            fuNEFT1.Enabled = true;
                            fuChequeLoan.Enabled = true;
                            fuNEFTLoan.Enabled = true;
                            calcel_cheque_file.Enabled = true;
                            fileuploadproof.Enabled = true;

                            foreach (GridViewRow gr in gvExercise.Rows)
                            {
                                if (gr.RowIndex < (Convert.ToInt32(gvExercise.Rows.Count) - 1))
                                {
                                    TextBox txtOptionsExercised = new TextBox();
                                    txtOptionsExercised = (TextBox)gr.FindControl("txtOptionsExercised");
                                    txtOptionsExercised.Enabled = false;

                                    TextBox TxtPendingAPP = new TextBox();
                                    TxtPendingAPP = (TextBox)gr.FindControl("TxtPendingAPP");
                                    txtOptionsExercised.Text = TxtPendingAPP.Text;

                                    txtOptionsExercised_TextChanged(txtOptionsExercised, e);
                                }
                            }

                            foreach (GridViewRow gr in gvExercise.Rows)
                            {
                                if (gr.RowIndex < (Convert.ToInt32(gvExercise.Rows.Count) - 1))
                                {
                                    TextBox txtOptionsExercised = new TextBox();
                                    txtOptionsExercised = (TextBox)gr.FindControl("txtOptionsExercised");
                                    txtOptionsExercised.Enabled = false;

                                    TextBox TxtPendingAPP = new TextBox();
                                    TxtPendingAPP = (TextBox)gr.FindControl("TxtPendingAPP");
                                    txtOptionsExercised.Text = TxtPendingAPP.Text;
                                }
                            }
                        }
                    }
                    else
                    {
                        DisablePageControls(false);

                        btnSubmit.Visible = true;
                        btnSubmit.Enabled = true;

                        btnFinalSubmit.Visible = false;

                        btnPreview.Visible = false;

                        btnmsg1.Visible = false;
                        lblmsg1.Visible = false;

                        btnmsg2.Visible = false;
                        lblmsg2.Visible = false;

                        ddlChequeBankName.Enabled = false;
                        ddlOtherSecurity.Enabled = false;
                        ddlLoanMarginMode.Enabled = false;
                        ddlNEFTBankName.Enabled = false;

                        fuCheque.Enabled = false;
                        fuNEFT1.Enabled = false;
                        fuChequeLoan.Enabled = false;
                        fuNEFTLoan.Enabled = false;
                        calcel_cheque_file.Enabled = false;
                        fileuploadproof.Enabled = false;

                        foreach (GridViewRow gr in gvExercise.Rows)
                        {
                            TextBox txtOptionsExercised = new TextBox();
                            txtOptionsExercised = (TextBox)gr.FindControl("txtOptionsExercised");

                            if (gr.RowIndex < (Convert.ToInt32(gvExercise.Rows.Count) - 1))
                            {
                                txtOptionsExercised.Enabled = true;
                            }
                        }
                    }

                    if(gvExercise.Rows.Count > 0)//if (ds.Tables[2].Rows.Count > 0)
                    {
                        foreach (GridViewRow gr in gvExercise.Rows)
                        {
                            TextBox txtOptionsExercised = new TextBox();
                            txtOptionsExercised = (TextBox)gr.FindControl("txtOptionsExercised");
                            
                            HiddenField hdnlapsedate = new HiddenField();
                            hdnlapsedate = (HiddenField)gr.FindControl("hdnlapsedate");

                            if (gr.RowIndex < (Convert.ToInt32(gvExercise.Rows.Count) - 1))
                            {
                                if (Convert.ToDateTime(hdnlapsedate.Value) < DateTime.Now)
                                {
                                    txtOptionsExercised.Enabled = false;
                                }
                            }
                        }
                    }
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

                //ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();0

                //Session["SessionId"] = ViewState["ViewStateId"].ToString();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop99", "radioValue_1();", true);

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        public void DisablePageControls(bool status)
        {
            foreach (Control c in Page.Controls)
            {
                foreach (Control ctrl in c.FindControl("ContentPlaceHolder1").Controls)
                {
                    if (ctrl is TextBox)
                        ((TextBox)ctrl).Enabled = status;
                    else if (ctrl is Button)
                        ((Button)ctrl).Enabled = status;
                    else if (ctrl is RadioButton)
                        ((RadioButton)ctrl).Enabled = status;
                    else if (ctrl is RadioButtonList)
                        ((RadioButtonList)ctrl).Enabled = status;
                    else if (ctrl is ImageButton)
                        ((ImageButton)ctrl).Enabled = status;
                    else if (ctrl is CheckBox)
                        ((CheckBox)ctrl).Enabled = status;
                    else if (ctrl is CheckBoxList)
                        ((CheckBoxList)ctrl).Enabled = status;
                    else if (ctrl is DropDownList)
                        ((DropDownList)ctrl).Enabled = status;
                    else if (ctrl is HyperLink)
                        ((HyperLink)ctrl).Enabled = status;
                    else if (ctrl is AsyncFileUpload)
                        ((AsyncFileUpload)ctrl).Enabled = status;
                    else if (ctrl is FileUpload)
                        ((FileUpload)ctrl).Enabled = status;
                }
            }
            foreach (GridViewRow row in gvExercise.Rows)
            {
                TextBox name = row.FindControl("txtOptionsExercised") as TextBox;
                name.Enabled = status;
            }
            //ddlChequeBankName.Enabled = status;
            btnPreview.Enabled = status;
            //Common.ShowJavascriptAlert("sale transaction is pending with the Admin");
        }

        #region Gridview Event
        protected void gvExercise_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[7].Visible = false;
        }

        protected void gvExercise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView gv1 = (GridView)sender;
                    TextBox txtTranchVesting = (TextBox)e.Row.FindControl("txtTranchVesting");
                    Label lblTranchVesting = (Label)e.Row.FindControl("lblTranchVesting");

                    TextBox txtGrantPrice = (TextBox)e.Row.FindControl("txtGrantPrice");
                    Label lblGrantPrice = (Label)e.Row.FindControl("lblGrantPrice");

                    TextBox txtFMV = (TextBox)e.Row.FindControl("txtFMV");
                    Label lblFMV = (Label)e.Row.FindControl("lblFMV");

                    TextBox txtOptionsPending = (TextBox)e.Row.FindControl("txtOptionsPending");
                    Label lblOptionsPending = (Label)e.Row.FindControl("lblOptionsPending");

                    TextBox txtOptions = (TextBox)e.Row.FindControl("txtOptions");
                    Label lblOptions = (Label)e.Row.FindControl("lblOptions");

                    TextBox txtOptionsExercised = (TextBox)e.Row.FindControl("txtOptionsExercised");
                    Label lblOptionsExercised = (Label)e.Row.FindControl("lblOptionsExercised");

                    TextBox txtNoofExcercise = (TextBox)e.Row.FindControl("txtNoofExcercise");
                    Label lblNoofExercise = (Label)e.Row.FindControl("lblNoofExercise");

                    TextBox TxtPendingAPP = (TextBox)e.Row.FindControl("TxtPendingAPP");
                    Label lblPendingAPP = (Label)e.Row.FindControl("lblPendingAPP");

                    TextBox txtTotOptions = (TextBox)e.Row.FindControl("txtTotOptions");
                    Label lblTotOptions = (Label)e.Row.FindControl("lblTotOptions");

                    if (txtOptions.Text.Contains("Total"))
                    {
                        txtTranchVesting.Visible = false;
                        txtGrantPrice.Visible = false;
                        txtFMV.Visible = false;
                        txtOptionsPending.Visible = false;
                        txtOptions.Visible = false;

                        txtOptionsExercised.Visible = true;
                        lblOptionsExercised.Visible = false;
                        txtOptionsExercised.Enabled = false;

                        lblOptions.Font.Bold = true;
                        lblOptionsExercised.Font.Bold = true;

                        txtNoofExcercise.Visible = false;
                        TxtPendingAPP.Visible = false;

                        txtTotOptions.Visible = false;
                        lblTotOptions.Font.Bold = true;
                    }
                    else
                    {
                        lblTranchVesting.Visible = false;
                        lblGrantPrice.Visible = false;
                        lblFMV.Visible = false;
                        lblOptionsPending.Visible = false;
                        lblOptions.Visible = false;

                        txtOptionsExercised.Visible = true;
                        lblOptionsExercised.Visible = false;

                        lblNoofExercise.Visible = false;
                        lblPendingAPP.Visible = false;

                        lblTotOptions.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void gvExerciseCal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView gv1 = (GridView)sender;

                    Label lblPerq_Tax_Amount = (Label)e.Row.FindControl("lblPerq_Tax_Amount");
                    Label lblTotal_Amount = (Label)e.Row.FindControl("lblTotal_Amount");
                    Label lblVesting_Cycle = (Label)e.Row.FindControl("lblVesting_Cycle");
                    Label lblExercise_Consideration = (Label)e.Row.FindControl("lblExercise_Consideration");

                    if (lblVesting_Cycle.Text.Contains("Total(₹)"))
                    {
                        lblPerq_Tax_Amount.Font.Bold = true;
                        lblTotal_Amount.Font.Bold = true;
                        lblVesting_Cycle.Font.Bold = true;
                        lblExercise_Consideration.Font.Bold = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        #endregion
        protected void Feeldata(DataSet ds1)
        {
            DataTable dtBankDetails = (DataTable)ViewState["Bank_Details"];

            ViewState["Grd_Session"] = "True";
            ViewState["Grd_Table"] = ds1.Tables[1];
            if (ds1.Tables[0].Rows[0]["PAYMENT_MODE"].ToString() == "Cheque")
            {
                this.RadiobvuttonValue = "Checked";
                this.inputtypeCheque = "Checked";
                if (ds1.Tables[0].Rows[0]["CHEQUE_BANK_NAME"].ToString() != "")
                {
                    for (int i = 0; i < dtBankDetails.Rows.Count; i++)
                    {
                        if (Convert.ToString(dtBankDetails.Rows[i][2]).Contains(ds1.Tables[0].Rows[0]["CHEQUE_BANK_NAME"].ToString()))
                        {
                            ddlChequeBankName.SelectedValue = Convert.ToString(dtBankDetails.Rows[i][0]);
                            ddlChequeBankName_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                    }
                }
                txtChequeNo.Text = ds1.Tables[0].Rows[0]["CHEQUE_NUMBER"].ToString();
                if (ds1.Tables[0].Rows[0]["CHQ_DATE"].ToString() != "")
                {
                    txtChequeDate.Text = ds1.Tables[0].Rows[0]["CHQ_DATE"].ToString();
                }
                txtChequeAmount.Text = ds1.Tables[0].Rows[0]["CHEQUE_AMOUNT"].ToString();

                Session["Cheque_FilePathFresh"] = ds1.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
                if (ds1.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString() != "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop1", "uploadComplete1();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop2", "FreshChequeSS();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop3", "Fresh_Cheque_SS_Hide();", true);
                }
            }
            else if (ds1.Tables[0].Rows[0]["PAYMENT_MODE"].ToString() == "NEFT")
            {
                this.RadiobvuttonValue = "NEFT";
                this.inputtypeNEFT = "Checked";
                if (ds1.Tables[0].Rows[0]["NEFT_BANK_NAME"].ToString() != "")
                {
                    for (int i = 0; i < dtBankDetails.Rows.Count; i++)
                    {
                        if (Convert.ToString(dtBankDetails.Rows[i][2]).Contains(ds1.Tables[0].Rows[0]["NEFT_BANK_NAME"].ToString()))
                        {
                            ddlNEFTBankName.SelectedValue = Convert.ToString(dtBankDetails.Rows[i][0]);
                            ddlNEFTBankName_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                    }
                }
                txtNEFTUTR.Text = ds1.Tables[0].Rows[0]["NEFT_UTR_NO"].ToString();
                Session["NEFT_FilePath"] = ds1.Tables[0].Rows[0]["NEFT_FILE_PATH"].ToString();
                if (ds1.Tables[0].Rows[0]["NEFT_FILE_PATH"].ToString() != "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop4", "NEFT_Trans_SS();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop5", "uploadComplete();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop6", "NEFT_Trans_SS_Hide();", true);
                }

            }
            else if (ds1.Tables[0].Rows[0]["PAYMENT_MODE"].ToString() == "Loan")
            {
                this.RadiobvuttonValue = "Loan";
                this.inputtypeLoan = "Checked";

                txtLoanBankName.Text = ds1.Tables[0].Rows[0]["LOAN_LENDER_BANK_NAME"].ToString();
                txtLoanAmount.Text = ds1.Tables[0].Rows[0]["LOAN_AMOUNT"].ToString();
                txtLoanMarginAmount.Text = ds1.Tables[0].Rows[0]["LOAN_MARGIN_AMOUNT"].ToString();
                ViewState["LoanAmount"] = ds1.Tables[0].Rows[0]["LOAN_AMOUNT"].ToString();
                ViewState["LoanMarginAmount"] = ds1.Tables[0].Rows[0]["LOAN_MARGIN_AMOUNT"].ToString();

                ddlLoanMarginMode.SelectedValue = ds1.Tables[0].Rows[0]["LOAN_MARGIN_PAYMENT_MODE"].ToString();

                if (ds1.Tables[0].Rows[0]["LOAN_MARGIN_PAYMENT_MODE"].ToString() == "Cheque")
                {
                    if (ds1.Tables[0].Rows[0]["CHEQUE_BANK_NAME"].ToString() != "")
                    {
                        for (int i = 0; i < dtBankDetails.Rows.Count; i++)
                        {
                            if (Convert.ToString(dtBankDetails.Rows[i][2]).Contains(ds1.Tables[0].Rows[0]["CHEQUE_BANK_NAME"].ToString()))
                            {
                                ddlChequeBankNameLoan.SelectedValue = Convert.ToString(dtBankDetails.Rows[i][0]);
                                ddlChequeBankNameLoan_SelectedIndexChanged(this, EventArgs.Empty);
                            }
                        }
                    }

                    txtChequeNoLoan.Text = ds1.Tables[0].Rows[0]["CHEQUE_NUMBER"].ToString();
                    txtChequeDateLoan.Text = ds1.Tables[0].Rows[0]["CHQ_DATE"].ToString();
                    txtChequeAmountLoan.Text = ds1.Tables[0].Rows[0]["CHEQUE_AMOUNT"].ToString();

                    Session["Cheque_FilePathLoanFresh"] = ds1.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
                    if (ds1.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString() != "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop7", "Loan_Cheque_SS();", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop8", "uploadComplete1Loan();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop9", "Loan_Cheque_SS_Hide();", true);
                    }
                }
                else
                {
                    for (int i = 0; i < dtBankDetails.Rows.Count; i++)
                    {
                        if (Convert.ToString(dtBankDetails.Rows[i][2]).Contains(ds1.Tables[0].Rows[0]["NEFT_BANK_NAME"].ToString()))
                        {
                            ddlNEFTBankNameLoan.SelectedValue = Convert.ToString(dtBankDetails.Rows[i][0]);
                            ddlNEFTBankNameLoan_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                    }
                    Session["NEFT_FilePathLoan"] = ds1.Tables[0].Rows[0]["NEFT_FILE_PATH"].ToString();
                    if (ds1.Tables[0].Rows[0]["NEFT_FILE_PATH"].ToString() != "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop10", "NEFTLoan_SS();", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop11", "uploadCompleteLoan();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop12", "NEFTLoan_SS_Hide();", true);
                    }
                    txtNEFTUTRLoan.Text = ds1.Tables[0].Rows[0]["NEFT_UTR_NO"].ToString();
                }
            }

            if (ds1.Tables[0].Rows[0]["SECURITY_NAME"].ToString() != "")
            {
                DataTable DEMAT_Details = (DataTable)ViewState["DEMAT_Details"];
                for (int i = 0; i < DEMAT_Details.Rows.Count; i++)
                {
                    if (Convert.ToString(DEMAT_Details.Rows[i][2]).Contains(ds1.Tables[0].Rows[0]["SECURITY_NAME"].ToString()))
                    {
                        ddlOtherSecurity.SelectedValue = Convert.ToString(DEMAT_Details.Rows[i][0]);
                        ddlOtherSecurity_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                }
            }
            ////ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop99", "radiobtn();", true);

            //btnSession_Click(this, new EventArgs());
        }
        protected void txtOptionsExercised_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
                int rowindex = row.RowIndex;
                string Vesting_Detail_ID = gvExercise.DataKeys[rowindex].Values[0].ToString();
                TextBox txtOptionsPending = (TextBox)row.FindControl("txtOptionsPending");
                TextBox txtOptions = (TextBox)row.FindControl("txtOptions");
                TextBox txtOptionsExercised = (TextBox)row.FindControl("txtOptionsExercised");
                TextBox TxtPendingAPP = (TextBox)row.FindControl("TxtPendingAPP");
                Label LblAlert = (Label)row.FindControl("LblAlert");
                if (txtOptionsExercised.Text == "")
                {
                    txtOptionsExercised.Text = "0";
                }

                if ((Convert.ToDouble(txtOptionsPending.Text) < Convert.ToDouble(txtOptionsExercised.Text)) && Convert.ToDouble(TxtPendingAPP.Text) == 0)
                {
                    Common.ShowJavascriptAlert("No.of options to be Exercised is not greater than No.of pending Exercise");
                    txtOptionsExercised.Text = "0";
                }

                txtOptionsPending.Text = Convert.ToString(Convert.ToDouble(txtOptions.Text) - Convert.ToDouble(txtOptionsExercised.Text));

                DataTable dtcal = CalculateTotal(Convert.ToInt32(Vesting_Detail_ID), Convert.ToInt32(txtOptionsExercised.Text));
                gvExerciseCal.DataSource = dtcal;
                gvExerciseCal.DataBind();

                DataTable dtcalexCount = CalculateTotal_No_Of_Options(Convert.ToInt32(Vesting_Detail_ID), Convert.ToDouble(txtOptionsExercised.Text));
                gvExercise.DataSource = null;
                gvExercise.DataSource = dtcalexCount;
                gvExercise.DataBind();

                Label lblTotal_Amount = (Label)gvExerciseCal.Rows[gvExerciseCal.Rows.Count - 1].FindControl("lblTotal_Amount");
                if (lblTotal_Amount.Text != "0.00")
                {
                    txtChequeAmount.Text = Convert.ToDecimal(Convert.ToString(lblTotal_Amount.Text)).ToString("N", CInfo); //Total_Amount.ToString();
                }

                if (gvExercise.Rows.Count > 0)//if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (GridViewRow gr in gvExercise.Rows)
                    {
                        TextBox txtOptionsExercised1 = new TextBox();
                        txtOptionsExercised1 = (TextBox)gr.FindControl("txtOptionsExercised");

                        HiddenField hdnlapsedate = new HiddenField();
                        hdnlapsedate = (HiddenField)gr.FindControl("hdnlapsedate");

                        if (gr.RowIndex < (Convert.ToInt32(gvExercise.Rows.Count) - 1))
                        {
                            if (Convert.ToDateTime(hdnlapsedate.Value) < DateTime.Now)
                            {
                                txtOptionsExercised1.Enabled = false;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objBO = new employee_exerciseBO();
                DataSet ds_1 = new DataSet();
                objBO.ECODE = Convert.ToString(Session["ECODE"]);
                objBO.remark = "ExerciseDetailApproval";
                ds_1 = objBAL.GET_Employee_Admin_Main_Data_4(objBO);
                if (ds_1.Tables[0].Rows.Count > 0)
                {
                    showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                    msg = "Exercise is pending for approval by Admin";
                    lblmsg4.Text = msg;
                    lblmsg4.Visible = true;
                    //DisablePageControls(false);
                }
                else
                {
                    objBO.ECODE = Convert.ToString(Session["ECODE"]);
                    objBO.OPTION_EXERCISE = Convert.ToInt32(ViewState["Exercise_Count"]);
                    objBO.TOTAL_AMOUNT = Convert.ToDouble(ViewState["Total_Amount"]);

                    objBO.CREATEDBY = Convert.ToString(Session["ECODE"]);
                    objBO.EXERCISE_WINDOW_ID = Convert.ToInt32(Session["EXERCISE_ID"].ToString());
                    int EXERCISE_TRAN_ID = 0;
                    if (Convert.ToString(Session["Emp_Exercise_Session"]) == "True")
                    {
                        EXERCISE_TRAN_ID = objBAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_SESSION(objBO);
                    }
                    else
                    {
                        EXERCISE_TRAN_ID = objBAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION(objBO);
                    }

                    if (EXERCISE_TRAN_ID > 0)
                    {
                        DataTable dt = (DataTable)ViewState["Exercise"];
                        for (int i = 0; i < dt.Rows.Count - 1; i++)
                        {
                            if (Convert.ToDouble(dt.Rows[i]["no_of_option_exercise"]) != 0)
                            {
                                //----------------------insert into transaction details table for each option exercised tranch vesting wise-------------
                                objBO._EXERCISE_TRAN_ID = EXERCISE_TRAN_ID;
                                objBO._VESTING_DETAIL_ID = Convert.ToInt32(dt.Rows[i]["vesting_detail_id"]);
                                objBO._ECODE = Convert.ToString(dt.Rows[i]["ecode"]);
                                objBO._ENAME = Convert.ToString(dt.Rows[i]["emp_name"]);
                                objBO._GRANT_ID = Convert.ToInt32(dt.Rows[i]["grant_id"]);
                                objBO._GRANT_NAME = Convert.ToString(dt.Rows[i]["grant_name"]);
                                objBO._VESTING_DETAIL_CODE = Convert.ToString(dt.Rows[i]["vesting_id"]);
                                objBO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["no_of_vesting"]);
                                objBO._VESTING_DATE = Convert.ToDateTime(dt.Rows[i]["vesting_date"]);
                                objBO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["grant_price"]);
                                objBO._GRANT_FMV_PRICE = Convert.ToDouble(Session["FMV_PRICE"].ToString()); // Convert.ToDouble(dt.Rows[i][12]);
                                objBO._NO_OF_EXERCISE = Convert.ToDouble(dt.Rows[i]["no_of_option_exercise"]);
                                //objBO._EXERCISE_DATE = Convert.ToInt32();
                                objBO._TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["taxable_income"]);
                                objBO._EXERCISE_CONSIDERATION = Convert.ToDouble(dt.Rows[i]["exercise_consideration"]);
                                objBO._FMV_GRANT_OPTION_EXERCISE = Convert.ToDouble(dt.Rows[i]["fmv_grant_option__exercise"]);
                                objBO._REVISED_TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["revised_taxable_income"]);
                                objBO._TAX_PER_OPTION = Convert.ToDouble(dt.Rows[i]["tax_per_option"]);
                                objBO._PERQ_TAX_AMOUNT = Convert.ToDouble(dt.Rows[i]["perq_tax_amount"]);
                                objBO._TOTAL_AMOUNT = Convert.ToDouble(dt.Rows[i]["total_amount"]);

                                objBO._CREATEDBY = Convert.ToString(Session["ECODE"]);
                                if (Convert.ToString(Session["Emp_Exercise_Session"]) == "True")
                                {
                                    objBAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_SESSION_NEW(objBO);
                                }
                                else
                                {
                                    objBAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_NEW(objBO);
                                }
                            }
                        }
                    }
                    //Added by Bhushan on 02-02-2023 for Tax Master CR
                    if (ds_1.Tables[0].Rows.Count > 0)
                    {
                        if(Convert.ToString(ds_1.Tables[0].Rows[0]["DETAIL_STATUS"]) == "Pending")
                        {
                            gvExerciseCal.Columns[4].Visible = false;
                            gvExerciseCal.Columns[5].Visible = false;
                            gvExerciseCal.Columns[6].Visible = false;
                            gvExerciseCal.Columns[7].Visible = false;
                        }
                        else
                        {
                            gvExerciseCal.Columns[6].Visible = true;
                            gvExerciseCal.Columns[7].Visible = true;
                        }
                    }
                    //End
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {

                if (Convert.ToString(Session["Emp_Exercise_Session"]) == "True")
                {

                }
                else
                {
                    ClearInputs(Page.Controls);

                    Session.Remove("Emp_Exercise_Session");
                    Session.Remove("NEFT_FilePath");
                    Session.Remove("Cheque_FilePathFresh");
                    Session.Remove("NEFT_FilePathLoan");
                    Session.Remove("Cheque_FilePathLoanFresh");
                    Session.Remove("Cheque_FilePathLoanFresh");
                    Session.Remove("NEFT_FilePathLoan");

                    BIND_EXERCISE_GRID();
                    Session["Done"] = "Done";
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Exercise Details Submitted Successfully and send to Admin for Approval";
                    btnSubmit.Enabled = false;
                    btnSubmit.Visible = false;
                }
            }
        }

        private DataTable CalculateTotal(int Vesting_Detail_ID, int OptionsExercised)
        {
            DataTable newdt = new DataTable();
            double Total_Amount = 0;
            double Exercise_Consideration = 0;
            double Perq_Tax_Amount = 0;
            double Exercise_Count = 0;
            try
            {

                DataTable dt = (DataTable)ViewState["Exercise_Cal"];

                newdt.Columns.Add("Vesting_DETAIL_ID");
                newdt.Columns.Add("ECODE");
                newdt.Columns.Add("EMP_NAME");
                newdt.Columns.Add("GRANT_ID");
                newdt.Columns.Add("GRANT_NAME");
                newdt.Columns.Add("VESTING_ID");
                newdt.Columns.Add("V_DETAIL_ID");
                newdt.Columns.Add("no_of_vesting");
                newdt.Columns.Add("Vesting_Date");
                newdt.Columns.Add("Tranch_Vesting");
                newdt.Columns.Add("status");
                newdt.Columns.Add("GRANT_PRICE");
                newdt.Columns.Add("fmv_price");
                newdt.Columns.Add("no_of_exercise");
                newdt.Columns.Add("pending_exercise");
                newdt.Columns.Add("taxable_income");
                newdt.Columns.Add("Exercise_Consideration");
                newdt.Columns.Add("FMV_Grant_Option__Exercise");
                newdt.Columns.Add("Revised_Taxable_Income");
                newdt.Columns.Add("Tax_Per_Option");
                newdt.Columns.Add("Perq_Tax_Amount");
                newdt.Columns.Add("Total_Amount");
                newdt.Columns.Add("no_of_option_exercise");


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToString(dt.Rows[i]["vesting_detail_id"]) == Convert.ToString(Vesting_Detail_ID))
                    {
                        DataRow dr1 = newdt.NewRow();
                        dr1["Vesting_DETAIL_ID"] = Convert.ToString(dt.Rows[i]["vesting_detail_id"]);
                        dr1["ECODE"] = Convert.ToString(dt.Rows[i]["ecode"]);
                        dr1["EMP_NAME"] = Convert.ToString(dt.Rows[i]["emp_name"]);
                        dr1["GRANT_ID"] = Convert.ToString(dt.Rows[i]["grant_id"]);
                        dr1["GRANT_NAME"] = (dt.Rows[i]["grant_name"]);
                        dr1["VESTING_ID"] = (dt.Rows[i]["vesting_id"]);
                        dr1["V_DETAIL_ID"] = (dt.Rows[i]["v_detail_id"]);
                        dr1["no_of_vesting"] = (dt.Rows[i]["no_of_vesting"]);
                        dr1["Vesting_Date"] = (dt.Rows[i]["vesting_date"]);
                        dr1["Tranch_Vesting"] = (dt.Rows[i]["tranch_vesting"]);
                        dr1["status"] = (dt.Rows[i]["status"]);
                        dr1["GRANT_PRICE"] = (dt.Rows[i]["grant_price"]);
                        dr1["fmv_price"] = Convert.ToString(Session["FMV_PRICE"]);
                        dr1["no_of_exercise"] = (dt.Rows[i]["no_of_exercise"]);
                        dr1["pending_exercise"] = dt.Rows[i]["pending_exercise"].ToString();//Convert.ToDateTime(dt.Rows[i][14]).ToString("MM/dd/yyyy");
                        dr1["taxable_income"] = dt.Rows[i]["taxable_income"].ToString();
                        dr1["Exercise_Consideration"] = Convert.ToDouble(dt.Rows[i]["grant_price"]) * OptionsExercised;//dt.Rows[i][16].ToString();
                        dr1["FMV_Grant_Option__Exercise"] = Convert.ToDouble((Convert.ToDouble(dt.Rows[i]["fmv_price"]) - Convert.ToDouble(dt.Rows[i]["grant_price"])) * OptionsExercised);//dt.Rows[i][17].ToString();
                        if (OptionsExercised == 0)
                        {
                            dr1["Revised_Taxable_Income"] = 0;
                        }
                        else
                        {
                            dr1["Revised_Taxable_Income"] = (Convert.ToDouble(dt.Rows[i]["taxable_income"]) + ((Convert.ToDouble(dt.Rows[i]["fmv_price"]) - Convert.ToDouble(dt.Rows[i]["grant_price"])) * OptionsExercised));//dt.Rows[i][18].ToString();
                        }
                        dr1["Tax_Per_Option"] = Convert.ToString(dt.Rows[i]["tax_per_option"]);
                        //Commented by Bhushan on 02-02-2023 
                        //dr1["Perq_Tax_Amount"] = ((((Convert.ToDouble(dt.Rows[i]["fmv_price"]) - Convert.ToDouble(dt.Rows[i]["grant_price"])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i]["tax_per_option"])) / 100).ToString("0.00"); //dt.Rows[i][20].ToString();
                        //dr1["Total_Amount"] = (((((Convert.ToDouble(dt.Rows[i]["fmv_price"]) - Convert.ToDouble(dt.Rows[i]["grant_price"])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i]["tax_per_option"])) / 100) + (Convert.ToDouble(dt.Rows[i]["grant_price"]) * OptionsExercised)).ToString("0.00");//dt.Rows[i][21].ToString();
                        //End

                        //Added by Bhushan on 02-02-2023 for Tax Master CR
                        dr1["Perq_Tax_Amount"] = Convert.ToDouble(dt.Rows[i]["Perq_Tax_Amount"]);
                        dr1["Total_Amount"] = Convert.ToDouble(dt.Rows[i]["Total_Amount"]);
                        //End

                        if (Convert.ToDouble(dr1["Perq_Tax_Amount"]) < 0)
                        {
                            dr1["Perq_Tax_Amount"] = 0;
                        }
                        dr1["no_of_option_exercise"] = OptionsExercised;// dt.Rows[i][22].ToString();
                                                                        //newdt.Rows.Add(dr1);
                        if (Convert.ToString(dr1["Perq_Tax_Amount"]).Contains("Total(₹)"))
                        {

                        }
                        else
                        {
                            string Prc1 = Convert.ToDecimal(dr1["Revised_Taxable_Income"].ToString()).ToString("N", CInfo);
                            dr1["Revised_Taxable_Income"] = Prc1;

                            string Prc2 = Convert.ToDecimal(dr1["Perq_Tax_Amount"].ToString()).ToString("N", CInfo);
                            dr1["Perq_Tax_Amount"] = Prc2;

                            string Prc3 = Convert.ToDecimal(dr1["Total_Amount"].ToString()).ToString("N", CInfo);
                            dr1["Total_Amount"] = Prc3;

                            string Prc4 = Convert.ToDecimal(dr1["FMV_Grant_Option__Exercise"].ToString()).ToString("N", CInfo);
                            dr1["FMV_Grant_Option__Exercise"] = Prc4;

                            dr1["Exercise_Consideration"] = Convert.ToDecimal(dr1["Exercise_Consideration"].ToString()).ToString("N", CInfo);

                            newdt.Rows.Add(dr1);
                            //Commented by Bhushan on 02-02-2023
                            //Total_Amount += ((((Convert.ToDouble(dt.Rows[i]["fmv_price"]) - Convert.ToDouble(dt.Rows[i]["grant_price"])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i]["tax_per_option"])) / 100) + (Convert.ToDouble(dt.Rows[i]["grant_price"]) * OptionsExercised);
                            //End

                            //Added by Bhushan on 02-02-2023 for Tax Master CR
                            Total_Amount += Convert.ToDouble(dr1["Total_Amount"]);
                            //End

                            Exercise_Consideration += Convert.ToDouble(dr1["Exercise_Consideration"]);
                            Perq_Tax_Amount += Convert.ToDouble(dr1["Perq_Tax_Amount"]);
                            Exercise_Count += OptionsExercised;
                            if (Convert.ToString(ViewState["Tranch_Vesting"]) == "")
                            {
                                if (OptionsExercised == 0)
                                {
                                    Tranch_Vesting = Tranch_Vesting.Replace((dt.Rows[i]["tranch_vesting"].ToString()), "");
                                }
                                else
                                {
                                    Tranch_Vesting = (dt.Rows[i]["tranch_vesting"].ToString());
                                }
                            }
                            else
                            {
                                if (OptionsExercised == 0)
                                {
                                    Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]).Replace((dt.Rows[i]["tranch_vesting"].ToString()), "");
                                }
                                else
                                {
                                    Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]) + "," + (dt.Rows[i]["tranch_vesting"].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        DataRow dr1 = newdt.NewRow();
                        dr1["Vesting_DETAIL_ID"] = Convert.ToString(dt.Rows[i]["vesting_detail_id"]);
                        dr1["ECODE"] = Convert.ToString(dt.Rows[i]["ecode"]);
                        dr1["EMP_NAME"] = Convert.ToString(dt.Rows[i]["emp_name"]);
                        dr1["GRANT_ID"] = Convert.ToString(dt.Rows[i]["grant_id"]);
                        dr1["GRANT_NAME"] = (dt.Rows[i]["grant_name"]);
                        dr1["VESTING_ID"] = (dt.Rows[i]["vesting_id"]);
                        dr1["V_DETAIL_ID"] = (dt.Rows[i]["v_detail_id"]);
                        dr1["no_of_vesting"] = (dt.Rows[i]["no_of_vesting"]);
                        dr1["Vesting_Date"] = (dt.Rows[i]["vesting_date"]);
                        dr1["Tranch_Vesting"] = (dt.Rows[i]["tranch_vesting"]);
                        dr1["status"] = (dt.Rows[i]["status"]);
                        dr1["GRANT_PRICE"] = (dt.Rows[i]["grant_price"]);
                        dr1["fmv_price"] = Convert.ToString(Session["FMV_PRICE"]);
                        dr1["no_of_exercise"] = (dt.Rows[i]["no_of_exercise"]);
                        dr1["pending_exercise"] = dt.Rows[i]["pending_exercise"].ToString();//Convert.ToDateTime(dt.Rows[i][14]).ToString("MM/dd/yyyy");
                        dr1["taxable_income"] = dt.Rows[i]["taxable_income"].ToString();
                        dr1["Exercise_Consideration"] = dt.Rows[i]["exercise_consideration"].ToString();
                        dr1["FMV_Grant_Option__Exercise"] = dt.Rows[i]["fmv_grant_option__exercise"].ToString();
                        dr1["Revised_Taxable_Income"] = dt.Rows[i]["revised_taxable_income"].ToString();
                        dr1["Tax_Per_Option"] = dt.Rows[i]["tax_per_option"].ToString();
                        dr1["Perq_Tax_Amount"] = dt.Rows[i]["perq_tax_amount"].ToString();
                        dr1["Total_Amount"] = dt.Rows[i]["total_amount"].ToString();
                        dr1["no_of_option_exercise"] = dt.Rows[i]["no_of_option_exercise"].ToString();
                        if (dr1["Tranch_Vesting"].ToString().Contains("Total"))
                        {

                        }
                        else
                        {
                            string Prc = string.IsNullOrEmpty(dr1["taxable_income"].ToString()) ? "" : Convert.ToDecimal(dr1["taxable_income"].ToString()).ToString("N", CInfo);
                            dr1["taxable_income"] = Prc;

                            string Prc1 = Convert.ToDecimal(dr1["Revised_Taxable_Income"].ToString()).ToString("N", CInfo);
                            dr1["Revised_Taxable_Income"] = Prc1;

                            string Prc2 = Convert.ToDecimal(dr1["Perq_Tax_Amount"].ToString()).ToString("N", CInfo);
                            dr1["Perq_Tax_Amount"] = Prc2;

                            string Prc3 = Convert.ToDecimal(dr1["Total_Amount"].ToString()).ToString("N", CInfo);
                            dr1["Total_Amount"] = Prc3;

                            string Prc4 = Convert.ToDecimal(dr1["FMV_Grant_Option__Exercise"].ToString()).ToString("N", CInfo);
                            dr1["FMV_Grant_Option__Exercise"] = Prc4;

                            dr1["Exercise_Consideration"] = Convert.ToDecimal(dr1["Exercise_Consideration"].ToString()).ToString("N", CInfo);

                            newdt.Rows.Add(dr1);
                            Total_Amount += Convert.ToDouble(dt.Rows[i]["total_amount"].ToString());
                            Exercise_Consideration += Convert.ToDouble(dt.Rows[i]["exercise_consideration"].ToString());
                            Perq_Tax_Amount += Convert.ToDouble(dt.Rows[i]["perq_tax_amount"].ToString());
                            Exercise_Count += Convert.ToDouble(dt.Rows[i]["no_of_option_exercise"].ToString());
                        }
                    }
                    DataRow dr11 = newdt.NewRow();
                    if ((dt.Rows.Count - 1) == i)
                    {
                        dr11["Tranch_Vesting"] = "Total(₹)";
                        dr11["Total_Amount"] = Convert.ToDecimal(Total_Amount.ToString()).ToString("N", CInfo); // (Total_Amount).ToString("0.00");
                        dr11["Exercise_Consideration"] = Convert.ToDecimal(Exercise_Consideration.ToString()).ToString("N", CInfo);//Exercise_Consideration;
                        dr11["Perq_Tax_Amount"] = Convert.ToDecimal(Perq_Tax_Amount.ToString()).ToString("N", CInfo);// (Perq_Tax_Amount).ToString("0.00");
                        txtChequeAmount.Text = Convert.ToDecimal(Total_Amount.ToString()).ToString("N", CInfo); //Total_Amount.ToString();
                        if (txtLoanMarginAmount.Text != "")
                        {
                            if (Convert.ToDouble(txtLoanMarginAmount.Text) < Total_Amount)
                            {
                                txtLoanAmount.Text = Convert.ToDecimal((Total_Amount - Convert.ToDouble(txtLoanMarginAmount.Text)).ToString()).ToString("N", CInfo);// (Total_Amount - Convert.ToDouble(txtLoanMarginAmount.Text)).ToString();
                            }
                            else
                            {
                                txtLoanMarginAmount.Text = "0";
                                txtLoanAmount.Text = "0";
                            }

                        }
                        dr11["Exercise_Consideration"] = Convert.ToDecimal(dr11["Exercise_Consideration"].ToString()).ToString("N", CInfo);
                        newdt.Rows.Add(dr11);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
            ViewState["Exercise_Cal"] = newdt;
            ViewState["Total_Amount"] = Total_Amount;
            ViewState["Exercise_Count"] = Exercise_Count;
            ViewState["Tranch_Vesting"] = Tranch_Vesting;
            return newdt;
        }

        private DataTable CalculateTotal_No_Of_Options(int Vesting_Detail_ID, double OptionsExercised)
        {
            DataTable newdt = new DataTable();
            double Exercise_Count = 0;
            try
            {
                DataTable dt = (DataTable)ViewState["Exercise"];
                newdt.Columns.Add("Vesting_DETAIL_ID");
                newdt.Columns.Add("ECODE");
                newdt.Columns.Add("EMP_NAME");
                newdt.Columns.Add("GRANT_ID");
                newdt.Columns.Add("GRANT_NAME");
                newdt.Columns.Add("VESTING_ID");
                newdt.Columns.Add("V_DETAIL_ID");
                newdt.Columns.Add("no_of_vesting");
                newdt.Columns.Add("Vesting_Date");
                newdt.Columns.Add("Tranch_Vesting");
                newdt.Columns.Add("status");
                newdt.Columns.Add("GRANT_PRICE");
                newdt.Columns.Add("fmv_price");
                newdt.Columns.Add("no_of_exercise");
                newdt.Columns.Add("pending_exercise");
                newdt.Columns.Add("taxable_income");
                newdt.Columns.Add("Exercise_Consideration");
                newdt.Columns.Add("FMV_Grant_Option__Exercise");
                newdt.Columns.Add("Revised_Taxable_Income");
                newdt.Columns.Add("Tax_Per_Option");
                newdt.Columns.Add("Perq_Tax_Amount");
                newdt.Columns.Add("Total_Amount");
                newdt.Columns.Add("no_of_option_exercise");
                newdt.Columns.Add("Pending_for_Approval");
                newdt.Columns.Add("Total_no_of_Options");
                newdt.Columns.Add("Lapse_Date_new");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToString(dt.Rows[i]["vesting_detail_id"]) == Convert.ToString(Vesting_Detail_ID))
                    {
                        DataRow dr1 = newdt.NewRow();
                        dr1["Vesting_DETAIL_ID"] = Convert.ToString(dt.Rows[i]["vesting_detail_id"]);
                        dr1["ECODE"] = Convert.ToString(dt.Rows[i]["ecode"]);
                        dr1["EMP_NAME"] = Convert.ToString(dt.Rows[i]["emp_name"]);
                        dr1["GRANT_ID"] = Convert.ToString(dt.Rows[i]["grant_id"]);
                        dr1["GRANT_NAME"] = (dt.Rows[i]["grant_name"]);
                        dr1["VESTING_ID"] = (dt.Rows[i]["vesting_id"]);
                        dr1["V_DETAIL_ID"] = (dt.Rows[i]["v_detail_id"]);
                        dr1["no_of_vesting"] = (dt.Rows[i]["no_of_vesting"]);
                        dr1["Vesting_Date"] = (dt.Rows[i]["vesting_date"]);
                        dr1["Tranch_Vesting"] = (dt.Rows[i]["tranch_vesting"]);
                        dr1["status"] = (dt.Rows[i]["status"]);
                        dr1["GRANT_PRICE"] = (dt.Rows[i]["grant_price"]);
                        dr1["fmv_price"] = Convert.ToString(Session["FMV_PRICE"]);
                        dr1["no_of_exercise"] = (dt.Rows[i]["no_of_exercise"]);
                        dr1["Pending_for_Approval"] = (dt.Rows[i]["Pending_for_Approval"]);
                        dr1["Total_no_of_Options"] = (dt.Rows[i]["Total_no_of_Options"]);
                        dr1["Lapse_Date_new"] = (dt.Rows[i]["Lapse_Date_new"]);

                        dr1["pending_exercise"] = Convert.ToDouble(dt.Rows[i]["no_of_vesting"].ToString()) - Convert.ToDouble(dt.Rows[i]["no_of_exercise"].ToString()) - Convert.ToDouble(dt.Rows[i]["Pending_for_Approval"].ToString());

                        dr1["taxable_income"] = string.IsNullOrEmpty(dt.Rows[i]["taxable_income"].ToString()) ? "" : Convert.ToDecimal(dt.Rows[i]["taxable_income"].ToString()).ToString("N", CInfo);

                        dr1["Exercise_Consideration"] = Convert.ToDouble(dt.Rows[i]["grant_price"]) * OptionsExercised;

                        dr1["FMV_Grant_Option__Exercise"] = ((Convert.ToDouble(dt.Rows[i]["fmv_price"]) - Convert.ToDouble(dt.Rows[i]["grant_price"])) * OptionsExercised).ToString("0.00");//dt.Rows[i][17].ToString();

                        dr1["Revised_Taxable_Income"] = (Convert.ToDouble(dt.Rows[i]["taxable_income"]) + ((Convert.ToDouble(dt.Rows[i]["fmv_price"]) - Convert.ToDouble(dt.Rows[i]["grant_price"])) * OptionsExercised)).ToString("0.00"); ;//dt.Rows[i][18].ToString();
                        dr1["Tax_Per_Option"] = Convert.ToString(dt.Rows[i]["tax_per_option"]);

                        if ((Convert.ToDecimal(dt.Rows[i]["fmv_price"]) - Convert.ToDecimal(dt.Rows[i]["grant_price"])) != 0)
                        {
                            dr1["Perq_Tax_Amount"] = ((((Convert.ToDecimal(dt.Rows[i]["fmv_price"]) - Convert.ToDecimal(dt.Rows[i]["grant_price"])) * Convert.ToDecimal(OptionsExercised)) * Convert.ToDecimal(dt.Rows[i]["tax_per_option"])) / 100).ToString("0.00"); ; //dt.Rows[i][20].ToString();
                        }
                        else
                        {
                            dr1["Perq_Tax_Amount"] = "0";
                        }

                        Decimal Dum_Tot;
                        if ((Convert.ToDecimal(dt.Rows[i]["fmv_price"]) - Convert.ToDecimal(dt.Rows[i]["grant_price"])) == 0)
                        {
                            Dum_Tot = 0;
                        }
                        else
                        {
                            Dum_Tot = ((((Convert.ToDecimal(dt.Rows[i]["fmv_price"]) - Convert.ToDecimal(dt.Rows[i]["grant_price"])) * Convert.ToDecimal(OptionsExercised)) * Convert.ToDecimal(dt.Rows[i]["tax_per_option"])) / 100);
                        }

                        dr1["Total_Amount"] = (Dum_Tot + (Convert.ToDecimal(dt.Rows[i]["grant_price"]) * Convert.ToDecimal(OptionsExercised))).ToString("0.00");

                        dr1["no_of_option_exercise"] = OptionsExercised;

                        if (dr1["no_of_vesting"].ToString().Contains("Total"))
                        {

                        }
                        else
                        {
                            newdt.Rows.Add(dr1);

                            Exercise_Count += OptionsExercised;
                        }
                    }
                    else
                    {
                        DataRow dr1 = newdt.NewRow();
                        dr1["Vesting_DETAIL_ID"] = Convert.ToString(dt.Rows[i]["vesting_detail_id"]);
                        dr1["ECODE"] = Convert.ToString(dt.Rows[i]["ecode"]);
                        dr1["EMP_NAME"] = Convert.ToString(dt.Rows[i]["emp_name"]);
                        dr1["GRANT_ID"] = Convert.ToString(dt.Rows[i]["grant_id"]);
                        dr1["GRANT_NAME"] = (dt.Rows[i]["grant_name"]);
                        dr1["VESTING_ID"] = (dt.Rows[i]["vesting_id"]);
                        dr1["V_DETAIL_ID"] = (dt.Rows[i]["v_detail_id"]);
                        dr1["no_of_vesting"] = (dt.Rows[i]["no_of_vesting"]);
                        dr1["Vesting_Date"] = (dt.Rows[i]["vesting_date"]);
                        dr1["Tranch_Vesting"] = (dt.Rows[i]["tranch_vesting"]);
                        dr1["status"] = (dt.Rows[i]["status"]);
                        dr1["GRANT_PRICE"] = (dt.Rows[i]["grant_price"]);
                        dr1["fmv_price"] = Convert.ToString(Session["FMV_PRICE"]);
                        dr1["no_of_exercise"] = (dt.Rows[i]["no_of_exercise"]);
                        dr1["pending_exercise"] = dt.Rows[i]["pending_exercise"].ToString();//Convert.ToDateTime(dt.Rows[i][14]).ToString("MM/dd/yyyy");
                        dr1["taxable_income"] = dt.Rows[i]["taxable_income"].ToString();
                        dr1["Exercise_Consideration"] = dt.Rows[i]["exercise_consideration"].ToString();
                        dr1["FMV_Grant_Option__Exercise"] = dt.Rows[i]["fmv_grant_option__exercise"].ToString();
                        dr1["Revised_Taxable_Income"] = dt.Rows[i]["revised_taxable_income"].ToString();
                        dr1["Tax_Per_Option"] = dt.Rows[i]["tax_per_option"].ToString();
                        dr1["Perq_Tax_Amount"] = dt.Rows[i]["perq_tax_amount"].ToString();
                        dr1["Total_Amount"] = dt.Rows[i]["total_amount"].ToString();
                        dr1["no_of_option_exercise"] = dt.Rows[i]["no_of_option_exercise"].ToString();
                        dr1["Pending_for_Approval"] = (dt.Rows[i]["Pending_for_Approval"]);
                        dr1["Total_no_of_Options"] = (dt.Rows[i]["Total_no_of_Options"]);
                        dr1["Lapse_Date_new"] = (dt.Rows[i]["Lapse_Date_new"]); 

                        if (dr1["no_of_vesting"].ToString().Contains("Total"))
                        {

                        }
                        else
                        {
                            newdt.Rows.Add(dr1);
                            Exercise_Count += Convert.ToDouble(dt.Rows[i]["no_of_option_exercise"].ToString());
                        }

                    }
                    DataRow dr11 = newdt.NewRow();
                    if ((dt.Rows.Count - 1) == i)
                    {
                        dr11["total_no_of_options"] = "Total";
                        dr11["no_of_vesting"] = "Total";
                        dr11["no_of_option_exercise"] = Exercise_Count;
                        newdt.Rows.Add(dr11);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
            ViewState["Exercise"] = newdt;
            return newdt;

        }

        private void BIND_EXERCISE_GRID()
        {
            DataTable dtExCount = new DataTable();
            objBO = new employee_exerciseBO();
            try
            {
                objBO.ECODE = Convert.ToString(Session["ECODE"]);

                objBO.EXERCISE_WINDOW_ID = Convert.ToInt32(Session["EXERCISE_ID"].ToString());
                objBO.EXERCISE_WINDOW_START_DATE = Convert.ToDateTime(Session["START_DATE"].ToString(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat).ToString();//(txtvaldate.Text);

                DataSet ds = new DataSet();

                ds = objBAL.GET_EMP_EXERCISE_DATA(objBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["TAXABLE_INCOME"].ToString() == "")
                    {
                        //showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        //showmsg.InnerText = "Taxable Income not uploaded";
                    }
                    if (ds.Tables[0].Rows[0]["exercise_id"].ToString() == "")
                    {
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        msg = msg + "Exercise not uploaded by Admin ";
                        showmsg.InnerText = msg;
                    }

                    ViewState["Exercise"] = ds.Tables[0];

                    if (Convert.ToString(ViewState["Grd_Session"]) == "True")
                    {
                        DataTable GrdTable = (DataTable)ViewState["Grd_Table"];

                        if (GrdTable.Rows.Count > 0)
                        {
                            for (int i = 0; i < GrdTable.Rows.Count; i++)
                            {
                                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                {
                                    if (ds.Tables[0].Rows[j]["TRANCH_VESTING"].ToString() == GrdTable.Rows[i]["GRANT_NAME"].ToString() + GrdTable.Rows[i]["VESTING_DETAIL_CODE"].ToString())
                                    {
                                        ds.Tables[0].Rows[j]["NO_OF_OPTION_EXERCISE"] = GrdTable.Rows[i]["NO_OF_EXERCISE"].ToString();
                                    }
                                    ds.Tables[0].AcceptChanges();

                                    if (ds.Tables[0].Rows[j]["NO_OF_OPTION_EXERCISE"].ToString() != "")
                                    {
                                        dtExCount = CalculateTotal_No_Of_Options(Convert.ToInt32(ds.Tables[0].Rows[j]["VESTING_DETAIL_ID"]), Convert.ToInt32(ds.Tables[0].Rows[j]["NO_OF_OPTION_EXERCISE"]));
                                    }
                                }

                            }
                        }
                    }

                    if (Convert.ToString(ViewState["Grd_Session"]) != "True")
                    {
                        dtExCount = CalculateTotal_No_Of_Options(0, 0);
                    }

                    if (dtExCount.Rows.Count > 0)
                    {
                        gvExercise.DataSource = dtExCount;
                        gvExercise.DataBind();
                    }

                    ViewState["Exercise_Cal"] = ds.Tables[0];
                    DataTable dtcal = new DataTable();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            if (Convert.ToInt32(ds.Tables[0].Rows[j]["NO_OF_OPTION_EXERCISE"]) == 0)
                            {
                                dtcal = CalculateTotal(0, 0);
                            }
                            else
                            {
                                dtcal = CalculateTotal(Convert.ToInt32(ds.Tables[0].Rows[j]["Vesting_Detail_ID"]), Convert.ToInt32(ds.Tables[0].Rows[j]["NO_OF_OPTION_EXERCISE"]));
                            }
                        }
                    }
                    else
                    {
                        dtcal = CalculateTotal(0, 0);
                    }
                    if (dtcal.Rows.Count > 0)
                    {
                        gvExerciseCal.DataSource = dtcal;
                        gvExerciseCal.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void btnFinalSubmit_Click(object sender, EventArgs e)
        {
            objBO = new employee_exerciseBO();
            try
            {
                if (IsPageRefresh)
                {
                    return;
                }

                objBO.ECODE = Convert.ToString(Session["ECODE"]);
                objBO.OPTION_EXERCISE = Convert.ToInt32(ViewState["Exercise_Count"]);
                objBO.TOTAL_AMOUNT = Convert.ToDouble(ViewState["Total_Amount"]);
                objBO.PAYMENT_MODE = Convert.ToString(Request.Form[hfPaymantMode.UniqueID]);
                if (objBO.PAYMENT_MODE == "Cheque")
                {
                    objBO.CHEQUE_BANK_NAME = Convert.ToString(lblChequeBankName.InnerText);
                    objBO.CHEQUE_BRANCH_NAME = Convert.ToString(lblChequeBranchName.InnerText);
                    objBO.CHEQUE_ACC_NO = Convert.ToString(lblChequeAccNo.InnerText);
                    objBO.CHEQUE_IFSC = Convert.ToString(lblChequeIFSC.InnerText);
                    objBO.CHEQUE_FILE_NAME = "";
                    objBO.CHEQUE_FILE_PATH = Convert.ToString(ViewState["Cheque_FilePath"]);
                    objBO.CHEQUE_NUMBER = Convert.ToString(lblChequeNo.InnerText);
                    if (lblChequeDate.InnerText != "")
                    {
                        objBO.CHEQUE_DATE = Convert.ToDateTime(lblChequeDate.InnerText, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    }
                    objBO.CHEQUE_AMOUNT = Convert.ToDouble(lblChequeAmount.InnerText);
                    objBO.CHEQUE_FILE_PATH_FRESH = Convert.ToString(Session["Cheque_FilePathFresh"]);
                }
                else if (objBO.PAYMENT_MODE == "NEFT")
                {
                    objBO.NEFT_BANK_NAME = Convert.ToString(lblNEFTBankName.InnerText);
                    objBO.NEFT_BRANCH_NAME = Convert.ToString(lblNEFTBranchName.InnerText);
                    objBO.NEFT_ACC_NO = Convert.ToString(lblNEFTAccNo.InnerText);
                    objBO.NEFT_IFSC = Convert.ToString(lblNEFTIFSC.InnerText);
                    objBO.NEFT_FILE_NAME = "";
                    objBO.NEFT_FILE_PATH = Convert.ToString(Session["NEFT_FilePath"]);
                    objBO.NEFT_UTR_NO = Convert.ToString(lblNEFTUTR.InnerText);
                }
                else if (objBO.PAYMENT_MODE == "Loan")
                {

                    objBO.LOAN_LENDER_BANK_NAME = Convert.ToString(lblLoanBankName.InnerText);
                    objBO.LOAN_AMOUNT = Convert.ToDouble(lblLoanAmount.InnerText);
                    objBO.LOAN_MARGIN_AMOUNT = Convert.ToDouble(lblLoanMarginAmount.InnerText);
                    objBO.LOAN_MARGIN_PAYMENT_MODE = Convert.ToString(lblLoanPaymentMode.InnerText);

                    if (ddlLoanMarginMode.SelectedValue == "Cheque")
                    {
                        objBO.CHEQUE_BANK_NAME = Convert.ToString(lblChequeBankNameLoan.InnerText);
                        objBO.CHEQUE_BRANCH_NAME = Convert.ToString(lblChequeBranchNameLoan.InnerText);
                        objBO.CHEQUE_ACC_NO = Convert.ToString(lblChequeAccNoLoan.InnerText);
                        objBO.CHEQUE_IFSC = Convert.ToString(lblChequeIFSCLoan.InnerText);
                        objBO.CHEQUE_FILE_NAME = "";
                        objBO.CHEQUE_FILE_PATH = Convert.ToString(ViewState["Cheque_FilePathLoan"]);
                        objBO.CHEQUE_NUMBER = Convert.ToString(lblChequeNoLoan.InnerText);
                        if (lblChequeDateLoan.InnerText != "")
                        {
                            objBO.CHEQUE_DATE = Convert.ToDateTime(lblChequeDateLoan.InnerText, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                        }
                        else
                        {
                            objBO.CHEQUE_DATE = null;
                        }
                        objBO.CHEQUE_AMOUNT = Convert.ToDouble(lblChequeAmountLoan.InnerText);
                        objBO.CHEQUE_FILE_PATH_FRESH = Convert.ToString(Session["Cheque_FilePathLoanFresh"]);
                    }
                    else
                    {
                        if (ddlLoanMarginMode.SelectedValue == "NEFT")
                        {
                            objBO.NEFT_BANK_NAME = Convert.ToString(lblNEFTBankNameLoan.InnerText);
                            objBO.NEFT_BRANCH_NAME = Convert.ToString(lblNEFTBranchNameLoan.InnerText);
                            objBO.NEFT_ACC_NO = Convert.ToString(lblNEFTAccNoLoan.InnerText);
                            objBO.NEFT_IFSC = Convert.ToString(lblNEFTIFSCLoan.InnerText);
                            objBO.NEFT_FILE_NAME = "";
                            objBO.NEFT_FILE_PATH = Convert.ToString(Session["NEFT_FilePathLoan"]);
                            objBO.NEFT_UTR_NO = Convert.ToString(lblNEFTUTRLoan.InnerText);
                        }
                    }
                }
                objBO.SECURITY_NAME = Convert.ToString(lblSecurityName.InnerText);
                objBO.DPID = Convert.ToString(lblDPID.InnerText);
                objBO.CLIENT_ID = Convert.ToString(lblClientID.InnerText);
                objBO.MEMBER_TYPE = Convert.ToString(lblMemberType.InnerText);
                objBO.DEMAT_FILE_PATH = Convert.ToString(ViewState["OtherSecurity_FilePath"]);

                objBO.CREATEDBY = Convert.ToString(Session["ECODE"]);
                objBO.EXERCISE_WINDOW_ID = Convert.ToInt32(Session["EXERCISE_ID"].ToString());
                int EXERCISE_TRAN_ID = 0;
                if (Convert.ToString(Session["Emp_Exercise_Session"]) == "True")
                {
                    EXERCISE_TRAN_ID = objBAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_SESSION(objBO);
                }
                else
                {
                    EXERCISE_TRAN_ID = objBAL.UPDATE_EMPLOYEE_EXERCISE_TRANSACTION(objBO);
                }

                if (EXERCISE_TRAN_ID > 0)
                {
                    DataTable dt = (DataTable)ViewState["Exercise"];
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        if (Convert.ToDouble(dt.Rows[i]["no_of_option_exercise"]) != 0)
                        {
                            //----------------------insert into transaction details table for each option exercised tranch vesting wise-------------
                            objBO._EXERCISE_TRAN_ID = EXERCISE_TRAN_ID;
                            objBO._VESTING_DETAIL_ID = Convert.ToInt32(dt.Rows[i]["vesting_detail_id"]);
                            objBO._ECODE = Convert.ToString(dt.Rows[i]["ecode"]);
                            objBO._ENAME = Convert.ToString(dt.Rows[i]["emp_name"]);
                            objBO._GRANT_ID = Convert.ToInt32(dt.Rows[i]["grant_id"]);
                            objBO._GRANT_NAME = Convert.ToString(dt.Rows[i]["grant_name"]);
                            objBO._VESTING_DETAIL_CODE = Convert.ToString(dt.Rows[i]["vesting_id"]);
                            objBO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["no_of_vesting"]);
                            objBO._VESTING_DATE = Convert.ToDateTime(dt.Rows[i]["vesting_date"]);
                            objBO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["grant_price"]);
                            objBO._GRANT_FMV_PRICE = Convert.ToDouble(Session["FMV_PRICE"].ToString()); // Convert.ToDouble(dt.Rows[i][12]);
                            objBO._NO_OF_EXERCISE = Convert.ToDouble(dt.Rows[i]["no_of_option_exercise"]);
                            //objBO._EXERCISE_DATE = Convert.ToInt32();
                            objBO._TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["taxable_income"]);
                            objBO._EXERCISE_CONSIDERATION = Convert.ToDouble(dt.Rows[i]["exercise_consideration"]);
                            objBO._FMV_GRANT_OPTION_EXERCISE = Convert.ToDouble(dt.Rows[i]["fmv_grant_option__exercise"]);
                            objBO._REVISED_TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["revised_taxable_income"]);
                            objBO._TAX_PER_OPTION = Convert.ToDouble(dt.Rows[i]["tax_per_option"]);
                            objBO._PERQ_TAX_AMOUNT = Convert.ToDouble(dt.Rows[i]["perq_tax_amount"]);
                            objBO._TOTAL_AMOUNT = Convert.ToDouble(dt.Rows[i]["total_amount"]);
                            objBO._AMOUNT_DEPOSITED = Convert.ToDouble(0);
                            objBO._FUNDING_AMOUNT = Convert.ToDouble(0);
                            objBO._SECURITY_NAME = Convert.ToString(lblSecurityName.InnerText);
                            objBO._DPID = Convert.ToString(lblDPID.InnerText);
                            objBO._CLIENT_ID = Convert.ToString(lblClientID.InnerText);
                            objBO._MEMBER_TYPE = Convert.ToString(lblMemberType.InnerText);
                            objBO._PAYMENT_MODE = Convert.ToString(Request.Form[hfPaymantMode.UniqueID]);
                            if (objBO._PAYMENT_MODE == "Cheque")
                            {
                                objBO._BANK_NAME = Convert.ToString(lblChequeBankName.InnerText);
                                objBO._BANK_BRANCH = Convert.ToString(lblChequeBranchName.InnerText);
                                objBO._ACC_NO = Convert.ToString(lblChequeAccNo.InnerText);
                                objBO._IFSC = Convert.ToString(lblChequeIFSC.InnerText);
                                objBO._CHEQUE_NUMBER = Convert.ToString(lblChequeNo.InnerText);
                                if (lblChequeDate.InnerText != "")
                                {
                                    objBO._CHEQUE_DATE = Convert.ToDateTime(lblChequeDate.InnerText, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                                }
                            }
                            else if (objBO._PAYMENT_MODE == "NEFT")
                            {
                                objBO._BANK_NAME = Convert.ToString(lblNEFTBankName.InnerText);
                                objBO._BANK_BRANCH = Convert.ToString(lblNEFTBranchName.InnerText);
                                objBO._ACC_NO = Convert.ToString(lblNEFTAccNo.InnerText);
                                objBO._IFSC = Convert.ToString(lblNEFTIFSC.InnerText);
                            }
                            else if (objBO.PAYMENT_MODE == "Loan")
                            {

                                objBO._BANK_NAME = Convert.ToString(lblLoanBankName.InnerText);
                                if (ddlLoanMarginMode.SelectedValue == "Cheque")
                                {
                                    objBO._BANK_NAME = Convert.ToString(lblChequeBankNameLoan.InnerText);
                                    objBO._BANK_BRANCH = Convert.ToString(lblChequeBranchNameLoan.InnerText);
                                    objBO._ACC_NO = Convert.ToString(lblChequeAccNoLoan.InnerText);
                                    objBO._IFSC = Convert.ToString(lblChequeIFSCLoan.InnerText);
                                    objBO._CHEQUE_NUMBER = Convert.ToString(lblChequeNoLoan.InnerText);
                                    if (lblChequeDateLoan.InnerText != "")
                                    {
                                        objBO._CHEQUE_DATE = Convert.ToDateTime(lblChequeDateLoan.InnerText, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                                    }
                                }
                                else
                                {
                                    if (ddlLoanMarginMode.SelectedValue == "NEFT")
                                    {
                                        objBO._BANK_NAME = Convert.ToString(lblNEFTBankNameLoan.InnerText);
                                        objBO._BANK_BRANCH = Convert.ToString(lblNEFTBranchNameLoan.InnerText);
                                        objBO._ACC_NO = Convert.ToString(lblNEFTAccNoLoan.InnerText);
                                        objBO._IFSC = Convert.ToString(lblNEFTIFSCLoan.InnerText);
                                    }
                                }

                            }
                            objBO._CREATEDBY = Convert.ToString(Session["ECODE"]);
                            if (Convert.ToString(Session["Emp_Exercise_Session"]) == "True")
                            {
                                objBAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_SESSION(objBO);
                            }
                            else
                            {
                                objBAL.UPDATE_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS(objBO);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {

                if (Convert.ToString(Session["Emp_Exercise_Session"]) == "True")
                {

                }
                else
                {
                    ClearInputs(Page.Controls);

                    Session.Remove("Emp_Exercise_Session");
                    Session.Remove("NEFT_FilePath");
                    Session.Remove("Cheque_FilePathFresh");
                    Session.Remove("NEFT_FilePathLoan");
                    Session.Remove("Cheque_FilePathLoanFresh");
                    Session.Remove("Cheque_FilePathLoanFresh");
                    Session.Remove("NEFT_FilePathLoan");

                    BIND_EXERCISE_GRID();
                    Session["Done"] = "Done";
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Exercise Submitted Successfully and send to Admin for Approval";
                }
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
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string tranch_vesting;
                tranch_vesting = Convert.ToString(ViewState["Tranch_Vesting"]).Replace(",,", ",");
                string temp = "";
                tranch_vesting.Split(',').Distinct().ToList().ForEach(k => temp += k + ",");
                tranch_vesting = temp.Trim(',');
                tranch_vesting = tranch_vesting.Replace(",,", ",");
                tranch_vesting = tranch_vesting.Replace(",", ", ");
                //Label lblTranchVesting = gvExercise.FindControl("lblTranchVesting") as Label;
                lblTranchVesting.InnerText = tranch_vesting;

                lblTotalAmount.InnerText = Convert.ToDecimal(ViewState["Total_Amount"]).ToString("N", CInfo);
                lblExercise_Count.InnerText = Convert.ToString(ViewState["Exercise_Count"]);
                lblSecurityName.InnerText = txtOtherSECURITYNAME.Text;
                lblDPID.InnerText = txtOtherDPID.Text;
                lblClientID.InnerText = txtOtherClientID.Text;
                lblMemberType.InnerText = txtOtherMemberType.Text;

                if (lblExercise_Count.InnerText == "0" && Convert.ToString(Session["Emp_Exercise_Session"]) != "True")
                {
                    Common.ShowJavascriptAlert("Please Add Atleast One Option To Exercise.");
                    return;
                }

                lblChequeBankName.InnerText = txtChequeBankName.Text;
                lblChequeBranchName.InnerText = txtChequeBranchName.Text;
                lblChequeAccNo.InnerText = txtChequeAccNo.Text;
                lblChequeIFSC.InnerText = txtChequeIFSC.Text;
                lblChequeNo.InnerText = txtChequeNo.Text;
                lblChequeDate.InnerText = txtChequeDate.Text;
                lblChequeAmount.InnerText = txtChequeAmount.Text;

                lblNEFTBankName.InnerText = txtNEFTBankName.Text;
                lblNEFTBranchName.InnerText = txtNEFTBranchName.Text;
                lblNEFTIFSC.InnerText = txtNEFTIFSC.Text;
                lblNEFTAccNo.InnerText = txtNEFTAccNo.Text;
                lblNEFTUTR.InnerText = txtNEFTUTR.Text;

                // -----------Loan---------------------
                lblLoanBankName.InnerText = txtLoanBankName.Text;
                lblLoanAmount.InnerText = txtLoanAmount.Text;
                lblLoanMarginAmount.InnerText = txtLoanMarginAmount.Text;
                lblLoanPaymentMode.InnerText = ddlLoanMarginMode.SelectedValue;

                if (ddlLoanMarginMode.SelectedValue == "Cheque")
                {
                    lblChequeBankNameLoan.InnerText = txtChequeBankNameLoan.Text;
                    lblChequeBranchNameLoan.InnerText = txtChequeBranchNameLoan.Text;
                    lblChequeAccNoLoan.InnerText = txtChequeAccNoLoan.Text;
                    lblChequeIFSCLoan.InnerText = txtChequeIFSCLoan.Text;
                    lblChequeNoLoan.InnerText = txtChequeNoLoan.Text;
                    lblChequeDateLoan.InnerText = txtChequeDateLoan.Text;
                    lblChequeAmountLoan.InnerText = txtChequeAmountLoan.Text;
                }
                else
                {
                    if (ddlLoanMarginMode.SelectedValue == "NEFT")
                    {
                        lblNEFTBankNameLoan.InnerText = txtNEFTBankNameLoan.Text;
                        lblNEFTBranchNameLoan.InnerText = txtNEFTBranchNameLoan.Text;
                        lblNEFTIFSCLoan.InnerText = txtNEFTIFSCLoan.Text;
                        lblNEFTAccNoLoan.InnerText = txtNEFTAccNoLoan.Text;
                        lblNEFTUTRLoan.InnerText = txtNEFTUTRLoan.Text;
                    }

                }

                string rdb = "";
                if (Request.Form["customRadioInline3"] != null)
                {
                    rdb = Request.Form["customRadioInline3"].ToString();
                }

                if (rdb == "Cheque")
                {
                    if (Convert.ToString(Session["Cheque_FilePathFresh"]) != "")
                    {
                        Image3.ImageUrl = Session["Cheque_FilePathFresh"].ToString();
                        f2.Visible = true;
                    }
                    else
                    {
                        f2.Visible = false;
                    }
                    f4.Visible = false;
                    f5.Visible = false;
                    f6.Visible = false;
                }

                if (rdb == "neft")
                {
                    if (Convert.ToString(Session["NEFT_FilePath"]) != "")
                    {
                        Image4.ImageUrl = Session["NEFT_FilePath"].ToString();
                        f4.Visible = true;
                    }
                    else
                    {
                        f4.Visible = false;
                    }
                    //f1.Visible = false;
                    f2.Visible = false;
                    f5.Visible = false;
                    f6.Visible = false;
                }

                if (rdb == "loan")
                {

                    if (Convert.ToString(Session["Cheque_FilePathLoanFresh"]) != "")
                    {
                        Image5.ImageUrl = Session["Cheque_FilePathLoanFresh"].ToString();  //fre chq loan
                        f5.Visible = true;
                    }
                    else
                    {
                        f5.Visible = false;
                    }

                    if (Convert.ToString(Session["NEFT_FilePathLoan"]) != "")
                    {
                        Image6.ImageUrl = Session["NEFT_FilePathLoan"].ToString(); // neft loan
                        f6.Visible = true;
                    }
                    else
                    {
                        f6.Visible = false;
                    }
                    f2.Visible = false;
                    f4.Visible = false;
                }


                if (Convert.ToString(ViewState["OtherSecurity_FilePath"]) != "")
                {
                    Image2.ImageUrl = ViewState["OtherSecurity_FilePath"].ToString();
                    f3.Visible = true;
                }
                else
                {
                    f3.Visible = false;
                }

                if (Convert.ToString(Session["Emp_Exercise_Session"]) == "True")
                {
                    btnSubmit_Click(this, new EventArgs());
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop13", "openModal();", true);
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        #region Bank Details and DMAT Details Added on 16-12-2021 by Rahul_Natu

        protected void save_bankdetail_Click(object sender, EventArgs e)
        {
            try
            {
                string extension = Path.GetExtension(calcel_cheque_file.FileName);
                string filaname = Convert.ToString(Session["ECode"]) + "_" + "CHEQUE" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                string filepath = "~/EMP_BankDetail/" + filaname;
                string PhysicalPath = Server.MapPath(filepath);
                calcel_cheque_file.SaveAs(PhysicalPath);
                objbo.ECODE = Convert.ToString(Session["ECode"]);
                objbo.BANK_NAME = txtbankname.Text;
                objbo.BRANCH_NAME = txtbranchname.Text;
                objbo.ACC_NO = txtaccnumber.Text;
                objbo.IFSC = txtifsccode.Text;
                objbo.FILE_PATH = filepath;
                objbo.CREATEDBY = Convert.ToString(Session["ECode"]);

                bool result = objbal.Insert_Emp_bankDetail(objbo);
                if (result == true)
                {
                    lblmsg1.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    //showmsg.InnerText = "Bank details created successfully";
                    lblmsg1.Visible = true;
                    lblmsg1.Text = "Bank details created successfully";
                    //btnmsg1.Visible = false;
                    bool msgBank = GET_EMP_BANK_DETAILS();
                    if (lblmsg2.Text == "Please submit Demat details for login Employee")
                    {
                        Session["Checkerlblmsg1"] = false;
                        Session["Checkerlblmsg2"] = true;
                        lblmsg2.Visible = true;
                    }
                }
                //clearcontrol();
                //if (lblmsg1.Text == "Please submit Bank details for login Employee"
                //    || lblmsg2.Text == "Please submit Demat details for login Employee"
                //    || lblmsg3.Text == "Exercise window is closed or not been created by admin")
                //{
                //    //DisablePageControls(false);
                //}
                //else
                //{
                //    //DisablePageControls(true);
                //}
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;

            }
        }
        private void clearcontrol()
        {
            txtbankname.Text = txtbranchname.Text = txtaccnumber.Text = txtifsccode.Text = string.Empty;
        }
        protected void save_dmatdetail_Click(object sender, EventArgs e)
        {
            try
            {
                string extension = Path.GetExtension(fileuploadproof.PostedFile.FileName);
                string filaname = Convert.ToString(Session["ECode"]) + "_" + "DEMAT" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                string filepath = "~/EMP_BankDetail/" + filaname;
                string PhysicalPath = Server.MapPath(filepath);
                fileuploadproof.SaveAs(PhysicalPath);
                objbo.ECODE = Convert.ToString(Session["ECode"]);
                objbo.SECURITY_NAME = txtsecurityname.Text;
                objbo.DPID = txtdpid.Text;
                objbo.CLIENT_ID = txtclientid.Text;
                objbo.MEMBER_TYPE = ddlmembertype.SelectedItem.Text;
                objbo.FILE_PATH = filepath;
                objbo.CREATEDBY = Convert.ToString(Session["ECode"]);

                bool result = objbal.Insert_Emp_DmatDetail(objbo);
                if (result == true)
                {
                    lblmsg2.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    //showmsg.InnerText = "Dmat details created successfully";
                    lblmsg2.Visible = true;
                    lblmsg2.Text = "DMAT details created successfully";
                    //btnmsg2.Visible = false;
                    bool msgDemat = GET_EMP_DEMAT_DETAILS();
                    if (lblmsg1.Text == "Please submit Bank details for login Employee")
                    {
                        Session["Checkerlblmsg1"] = true;
                        Session["Checkerlblmsg2"] = false;
                        lblmsg1.Visible = true;
                        //btnmsg1.Visible = true;
                    }
                }
                clearcontrol1();
                //if (lblmsg1.Text == "Please submit Bank details for login Employee"
                //    || lblmsg2.Text == "Please submit Demat details for login Employee"
                //    || lblmsg3.Text == "Exercise window is closed or not been created by admin")
                //{
                //    //DisablePageControls(false);
                //}
                //else
                //{
                //    //DisablePageControls(true);
                //}
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }

        private void clearcontrol1()
        {
            txtsecurityname.Text = txtdpid.Text = txtclientid.Text = string.Empty;
            ddlmembertype.SelectedIndex = -1;
        }
        #endregion

        protected void ddlChequeBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBankDetails = (DataTable)ViewState["Bank_Details"];
                for (int i = 0; i < dtBankDetails.Rows.Count; i++)
                {
                    if (ddlChequeBankName.SelectedValue == Convert.ToString(dtBankDetails.Rows[i][0]))
                    {
                        txtChequeBankName.Text = Convert.ToString(dtBankDetails.Rows[i][3]);
                        txtChequeBranchName.Text = Convert.ToString(dtBankDetails.Rows[i][4]);
                        txtChequeAccNo.Text = Convert.ToString(dtBankDetails.Rows[i][5]);
                        txtChequeIFSC.Text = Convert.ToString(dtBankDetails.Rows[i][6]);
                        ViewState["Cheque_FilePath"] = Convert.ToString(dtBankDetails.Rows[i][8]);
                        //lnkChequeDownload.Visible = true;

                        string filePath = Server.MapPath(Convert.ToString(ViewState["Cheque_FilePath"]));
                        if (File.Exists(filePath) && Path.HasExtension(filePath))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop14", "Cancle_Cheque_SS();", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop15", "Cancle_Cheque_SS_Hide();", true);
                        }

                    }
                    if (ddlChequeBankName.SelectedValue == "0")
                    {
                        txtChequeBankName.Text = "";
                        txtChequeBranchName.Text = "";
                        txtChequeIFSC.Text = "";
                        txtChequeAccNo.Text = "";
                        ViewState["Cheque_FilePath"] = "";
                    }
                }
                ////txtChequeNo.Focus();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void fuCheque_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                string fileName = Path.GetFileName(fuCheque.FileName);
                string ext = Path.GetExtension(fuCheque.FileName).ToLower();

                if (Path.GetExtension(fileName).ToLower().Contains(".png") || Path.GetExtension(fileName).ToLower().Contains(".jpeg") || Path.GetExtension(fileName).ToLower().Contains(".jpg") || Path.GetExtension(fileName).ToLower().Contains(".pdf") || Path.GetExtension(fileName).ToLower().Contains(".doc") || Path.GetExtension(fileName).ToLower().Contains(".docx"))
                {
                    fileName = Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                    fuCheque.PostedFile.SaveAs(Server.MapPath(this.UploadFolderPath + fileName));
                    Session["Cheque_FilePathFresh"] = this.UploadFolderPath + fileName;
                    string F_Path = Server.MapPath(this.UploadFolderPath + fileName);
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void lnkChequeDownloadFresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuChequeLoan.IsUploading) return;
                if (Convert.ToString(Session["Cheque_FilePathFresh"]) == "")
                {
                    Common.ShowJavascriptAlert("Please Select screenshot to upload.");
                    return;
                }
                string filePath = Server.MapPath(Convert.ToString(Session["Cheque_FilePathFresh"]));
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void ddlNEFTBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBankDetails = (DataTable)ViewState["Bank_Details"];
                for (int i = 0; i < dtBankDetails.Rows.Count; i++)
                {
                    if (ddlNEFTBankName.SelectedValue == Convert.ToString(dtBankDetails.Rows[i][0]))
                    {
                        txtNEFTBankName.Text = Convert.ToString(dtBankDetails.Rows[i][3]);
                        txtNEFTBranchName.Text = Convert.ToString(dtBankDetails.Rows[i][4]);
                        txtNEFTAccNo.Text = Convert.ToString(dtBankDetails.Rows[i][5]);
                        txtNEFTIFSC.Text = Convert.ToString(dtBankDetails.Rows[i][6]);
                        ///ViewState["NEFT_FilePath"] = Convert.ToString(dtBankDetails.Rows[i][8]);
                    }
                    if (ddlNEFTBankName.SelectedValue == "0")
                    {
                        txtNEFTBankName.Text = "";
                        txtNEFTBranchName.Text = "";
                        txtNEFTAccNo.Text = "";
                        txtNEFTIFSC.Text = "";
                        //ViewState["NEFT_FilePath"] = "";
                    }
                }
                txtNEFTUTR.Focus();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void lnkNEFTDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuNEFT1.IsUploading) return;
                if (Convert.ToString(Session["NEFT_FilePath"]) == "")
                {
                    Common.ShowJavascriptAlert("Please Select screenshot to upload.");
                    return;
                }
                string filePath = Server.MapPath(Convert.ToString(Session["NEFT_FilePath"]));
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void fuNEFT1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                string fileName = Path.GetFileName(fuNEFT1.FileName);
                string ext = Path.GetExtension(fuNEFT1.FileName).ToLower();

                if (Path.GetExtension(fileName).ToLower().Contains(".png") || Path.GetExtension(fileName).ToLower().Contains(".jpeg") || Path.GetExtension(fileName).ToLower().Contains(".jpg") || Path.GetExtension(fileName).ToLower().Contains(".pdf") || Path.GetExtension(fileName).Contains(".doc") || Path.GetExtension(fileName).ToLower().Contains(".docx"))
                {
                    //fileName = Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                    ////string filename = System.IO.Path.GetFileName(fuNEFT1.FileName);
                    //fuNEFT1.SaveAs(Server.MapPath("Exercise_Doc/" + fileName));
                    //Session["NEFT_FilePath"] = "~/Exercise_Doc/" + fileName;

                    //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    fileName = Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                    fuNEFT1.PostedFile.SaveAs(Server.MapPath("~/Exercise_Doc/" + fileName));
                    Session["NEFT_FilePath"] = "~/Exercise_Doc/" + fileName;
                    //Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    //Common.ShowJavascriptAlert("Only .jpg, .gif, .png, .gif, .pdf, .doc, .docx files are allowed");//Common.ShowJavascriptAlert("File type not allowed");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void ddlLoanMarginMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLoanMarginMode.SelectedValue == "Cheque")
                {
                    txtChequeAmountLoan.Text = txtLoanMarginAmount.Text;
                    txtChequeAmountLoan.Text = string.IsNullOrEmpty(txtChequeAmountLoan.Text) ? "" : Convert.ToDecimal(txtChequeAmountLoan.Text.ToString()).ToString("N", CInfo);
                    Session["NEFT_FilePathLoan"] = "";
                }
                else
                {
                    txtChequeAmountLoan.Text = "";
                    Session["Cheque_FilePathLoanFresh"] = "";
                }
                txtChequeNoLoan.Focus();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void ddlChequeBankNameLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBankDetails = (DataTable)ViewState["Bank_Details"];
                for (int i = 0; i < dtBankDetails.Rows.Count; i++)
                {
                    if (ddlChequeBankNameLoan.SelectedValue == Convert.ToString(dtBankDetails.Rows[i][0]))
                    {
                        txtChequeBankNameLoan.Text = Convert.ToString(dtBankDetails.Rows[i][3]);
                        txtChequeBranchNameLoan.Text = Convert.ToString(dtBankDetails.Rows[i][4]);
                        txtChequeAccNoLoan.Text = Convert.ToString(dtBankDetails.Rows[i][5]);
                        txtChequeIFSCLoan.Text = Convert.ToString(dtBankDetails.Rows[i][6]);
                        ViewState["Cheque_FilePathLoan"] = Convert.ToString(dtBankDetails.Rows[i][8]);
                        //lnkChequeDownloadLoan.Visible = true;

                        // added by PS 09-02-2021
                        string filePath = Server.MapPath(Convert.ToString(ViewState["Cheque_FilePathLoan"]));
                        if (File.Exists(filePath) && Path.HasExtension(filePath))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop16", "Cancle_Cheque_Loan_SS();", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop17", "Cancle_Cheque_Loan_SS_Hide();", true);
                        }
                    }
                    if (ddlChequeBankNameLoan.SelectedValue == "0")
                    {
                        txtChequeBankNameLoan.Text = "";
                        txtChequeBranchNameLoan.Text = "";
                        txtChequeIFSCLoan.Text = "";
                        txtChequeAccNoLoan.Text = "";
                        ViewState["Cheque_FilePathLoan"] = "";
                    }
                }
                //txtChequeNoLoan.Focus();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void fuChequeLoan_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                string fileName = Path.GetFileName(fuChequeLoan.FileName);
                string ext = Path.GetExtension(fuChequeLoan.FileName).ToLower();

                if (Path.GetExtension(fileName).ToLower().Contains(".png") || Path.GetExtension(fileName).ToLower().Contains(".jpeg") || Path.GetExtension(fileName).ToLower().Contains(".jpg") || Path.GetExtension(fileName).ToLower().Contains(".pdf") || Path.GetExtension(fileName).ToLower().Contains(".doc") || Path.GetExtension(fileName).ToLower().Contains(".docx"))
                {
                    fileName = Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                    fuChequeLoan.SaveAs(Server.MapPath(this.UploadFolderPath + fileName));
                    Session["Cheque_FilePathLoanFresh"] = this.UploadFolderPath + fileName;
                }
                else
                {
                    //Common.ShowJavascriptAlert("Only .jpg, .gif, .png, .gif, .pdf, .doc, .docx files are allowed"); //Common.ShowJavascriptAlert("File type not allowed");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void lnkChequeDownloadFreshLoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuChequeLoan.IsUploading) return;
                if (Convert.ToString(Session["Cheque_FilePathLoanFresh"]) == "")
                {
                    Common.ShowJavascriptAlert("Please Select screenshot to upload.");
                    return;
                }
                string filePath = Server.MapPath(Convert.ToString(Session["Cheque_FilePathLoanFresh"]));
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void ddlNEFTBankNameLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBankDetails = (DataTable)ViewState["Bank_Details"];
                for (int i = 0; i < dtBankDetails.Rows.Count; i++)
                {
                    if (ddlNEFTBankNameLoan.SelectedValue == Convert.ToString(dtBankDetails.Rows[i][0]))
                    {
                        txtNEFTBankNameLoan.Text = Convert.ToString(dtBankDetails.Rows[i][3]);
                        txtNEFTBranchNameLoan.Text = Convert.ToString(dtBankDetails.Rows[i][4]);
                        txtNEFTAccNoLoan.Text = Convert.ToString(dtBankDetails.Rows[i][5]);
                        txtNEFTIFSCLoan.Text = Convert.ToString(dtBankDetails.Rows[i][6]);
                    }
                    if (ddlNEFTBankNameLoan.SelectedValue == "0")
                    {
                        txtNEFTBankNameLoan.Text = "";
                        txtNEFTBranchNameLoan.Text = "";
                        txtNEFTAccNoLoan.Text = "";
                        txtNEFTIFSCLoan.Text = "";
                    }
                }
                //txtNEFTUTRLoan.Focus();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void lnkNEFTDownloadLoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuNEFTLoan.IsUploading) return;
                if (Convert.ToString(Session["NEFT_FilePathLoan"]) == "")
                {
                    Common.ShowJavascriptAlert("Please Select screenshot to upload.");
                    return;
                }
                string filePath = Server.MapPath(Convert.ToString(Session["NEFT_FilePathLoan"]));
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void ddlOtherSecurity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtDEMATDetails = (DataTable)ViewState["DEMAT_Details"];
                for (int i = 0; i < dtDEMATDetails.Rows.Count; i++)
                {
                    if (ddlOtherSecurity.SelectedValue == Convert.ToString(dtDEMATDetails.Rows[i][0]))
                    {
                        txtOtherSECURITYNAME.Text = Convert.ToString(dtDEMATDetails.Rows[i][3]);
                        txtOtherDPID.Text = Convert.ToString(dtDEMATDetails.Rows[i][4]);
                        txtOtherClientID.Text = Convert.ToString(dtDEMATDetails.Rows[i][5]);
                        txtOtherMemberType.Text = Convert.ToString(dtDEMATDetails.Rows[i][6]);

                        ViewState["OtherSecurity_FilePath"] = Convert.ToString(dtDEMATDetails.Rows[i][8]);
                    }
                }
                if (ddlOtherSecurity.SelectedValue == "0")
                {
                    txtOtherSECURITYNAME.Text = "";
                    txtOtherDPID.Text = "";
                    txtOtherClientID.Text = "";
                    txtOtherMemberType.Text = "";
                    ViewState["OtherSecurity_FilePath"] = "";
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            try
            {
                var scriptManager = ScriptManager.GetCurrent(this.Page);
                if (scriptManager != null)
                {
                    scriptManager.RegisterPostBackControl(lnkDownload);
                }
                if (Convert.ToString(ViewState["OtherSecurity_FilePath"]) == "")
                {
                    Common.ShowJavascriptAlert("Please Select DP Name.");
                    return;
                }
                string filePath = Server.MapPath(Convert.ToString(ViewState["OtherSecurity_FilePath"]));
                if (File.Exists(filePath) && Path.HasExtension(filePath))
                {
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
                else
                {
                    Common.ShowJavascriptAlert("No file available to download.");

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        private bool GET_EMP_BANK_DETAILS()
        {
            objBO = new employee_exerciseBO();
            try
            {
                objBO.ECODE = Convert.ToString(Session["ECODE"]);
                DataSet ds = objBAL.GET_EMP_BANK_DETAILS(objBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["Bank_Details"] = ds.Tables[0];
                    ddlChequeBankName.DataSource = ds.Tables[0];
                    ddlChequeBankName.DataTextField = "BANK_ACC";
                    ddlChequeBankName.DataValueField = "ID";
                    ddlChequeBankName.DataBind();
                    ddlChequeBankName.Items.Insert(0, new ListItem("Select Bank", "0"));

                    ddlNEFTBankName.DataSource = ds.Tables[0];
                    ddlNEFTBankName.DataTextField = "BANK_ACC";
                    ddlNEFTBankName.DataValueField = "ID";
                    ddlNEFTBankName.DataBind();
                    ddlNEFTBankName.Items.Insert(0, new ListItem("Select Bank", "0"));


                    ddlChequeBankNameLoan.DataSource = ds.Tables[0];
                    ddlChequeBankNameLoan.DataTextField = "BANK_ACC";
                    ddlChequeBankNameLoan.DataValueField = "ID";
                    ddlChequeBankNameLoan.DataBind();
                    ddlChequeBankNameLoan.Items.Insert(0, new ListItem("Select Bank", "0"));

                    ddlNEFTBankNameLoan.DataSource = ds.Tables[0];
                    ddlNEFTBankNameLoan.DataTextField = "BANK_ACC";
                    ddlNEFTBankNameLoan.DataValueField = "ID";
                    ddlNEFTBankNameLoan.DataBind();
                    ddlNEFTBankNameLoan.Items.Insert(0, new ListItem("Select Bank", "0"));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
                return false;
            }
        }
        private bool GET_EMP_DEMAT_DETAILS()
        {
            objBO = new employee_exerciseBO();
            try
            {
                objBO.ECODE = Convert.ToString(Session["ECODE"]);
                DataSet ds = objBAL.GET_EMP_DEMAT_DETAILS(objBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DEMAT_Details"] = ds.Tables[0];
                    ddlOtherSecurity.DataSource = ds.Tables[0];
                    ddlOtherSecurity.DataTextField = "SECURITY_DPID";
                    ddlOtherSecurity.DataValueField = "ID";
                    ddlOtherSecurity.DataBind();
                    ddlOtherSecurity.Items.Insert(0, new ListItem("Select DP Name", "0"));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }

        protected void txtLoanAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLoanAmount.Text != "")
                {
                    if (Convert.ToDecimal(txtLoanAmount.Text) > 0)
                    {
                        decimal No_Of_options_Exec = 0;
                        for (int i = gvExerciseCal.Rows.Count - 1; i >= 0; i--)
                        {
                            if (No_Of_options_Exec == 0)
                            {
                                string Val = ((Label)gvExerciseCal.Rows[i].FindControl("lblTotal_Amount")).Text;
                                if (!string.IsNullOrEmpty(Val))
                                {
                                    No_Of_options_Exec = Convert.ToDecimal(Val);
                                }
                            }
                        }
                        if (No_Of_options_Exec > 0)
                        {
                            if ((No_Of_options_Exec - Convert.ToDecimal(txtLoanAmount.Text)) < 0)
                            {
                                txtLoanAmount.Text = "";
                                txtLoanMarginAmount.Text = "";
                                Common.ShowJavascriptAlert("Wrong value entered in Loan Amount..");
                                return;
                            }
                            txtLoanMarginAmount.Text = Convert.ToDecimal((No_Of_options_Exec - Convert.ToDecimal(txtLoanAmount.Text)).ToString()).ToString("N", CInfo);// (No_Of_options_Exec - Convert.ToDecimal(txtLoanAmount.Text)).ToString();
                        }
                        else
                        {
                            txtLoanMarginAmount.Text = "";
                        }
                        if (ddlLoanMarginMode.SelectedValue == "Cheque")
                        {
                            txtChequeAmountLoan.Text = Convert.ToDecimal(txtLoanMarginAmount.Text).ToString("N", CInfo); // txtLoanMarginAmount.Text;
                        }
                        else
                        {
                            txtChequeAmountLoan.Text = "";
                        }

                    }
                    txtLoanAmount.Text = Convert.ToDecimal(txtLoanAmount.Text).ToString("N", CInfo);
                }
                else
                {
                    txtLoanMarginAmount.Text = "";
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void txtLoanMarginAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLoanMarginAmount.Text != "")
                {
                    if (Convert.ToDecimal(txtLoanMarginAmount.Text) > 0)
                    {
                        decimal No_Of_options_Exec = 0;
                        for (int i = gvExerciseCal.Rows.Count - 1; i >= 0; i--)
                        {
                            if (No_Of_options_Exec == 0)
                            {
                                string Val = ((Label)gvExerciseCal.Rows[i].FindControl("lblTotal_Amount")).Text;
                                if (!string.IsNullOrEmpty(Val))
                                {
                                    No_Of_options_Exec = Convert.ToDecimal(Val);
                                }
                            }
                        }
                        if (No_Of_options_Exec > 0)
                        {
                            if ((No_Of_options_Exec - Convert.ToDecimal(txtLoanMarginAmount.Text)) < 0)
                            {
                                txtLoanAmount.Text = "";
                                txtLoanMarginAmount.Text = "";
                                Common.ShowJavascriptAlert("Wrong value entered in Margin Money Amount..");
                                return;
                            }
                            txtLoanAmount.Text = Convert.ToDecimal((No_Of_options_Exec - Convert.ToDecimal(txtLoanMarginAmount.Text)).ToString()).ToString("N", CInfo);// (No_Of_options_Exec - Convert.ToDecimal(txtLoanMarginAmount.Text)).ToString();
                        }
                        else
                        {
                            txtLoanAmount.Text = "";
                        }

                        if (ddlLoanMarginMode.SelectedValue == "Cheque")
                        {
                            txtChequeAmountLoan.Text = txtLoanMarginAmount.Text;
                        }
                        else
                        {
                            txtChequeAmountLoan.Text = "";
                        }
                        txtLoanMarginAmount.Text = Convert.ToDecimal(txtLoanMarginAmount.Text).ToString("N", CInfo);
                    }
                    else
                    {
                        txtLoanAmount.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void fuNEFTLoan_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                string fileName = Path.GetFileName(fuNEFTLoan.FileName);
                string ext = Path.GetExtension(fuNEFTLoan.FileName).ToLower();

                if (Path.GetExtension(fileName).ToLower().Contains(".png") || Path.GetExtension(fileName).ToLower().Contains(".jpeg") || Path.GetExtension(fileName).ToLower().Contains(".jpg") || Path.GetExtension(fileName).ToLower().Contains(".pdf") || Path.GetExtension(fileName).ToLower().Contains(".doc") || Path.GetExtension(fileName).ToLower().Contains(".docx"))
                {
                    fileName = Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                    fuNEFTLoan.SaveAs(Server.MapPath("Exercise_Doc/" + fileName));
                    Session["NEFT_FilePathLoan"] = "~/Exercise_Doc/" + fileName;
                }
                else
                {
                    //Common.ShowJavascriptAlert("Only .jpg, .gif, .png, .gif, .pdf, .doc, .docx files are allowed"); //Common.ShowJavascriptAlert("File type not allowed");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
    }
}