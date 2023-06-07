using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BO;
using ESOP_BAL;
using System.Data;
using System.IO;
using System.Globalization;
using System.Net;

namespace ESOP
{
    public partial class employee_exercise : System.Web.UI.Page
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
        //End
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    showmsg.Visible = false;
                    lblmsg1.Visible = false;
                    lblmsg2.Visible = false;
                    lblmsg3.Visible = false;
                    btnmsg1.Enabled = true;
                    btnmsg2.Enabled = true;
                    //EMPLOYEE_DETAIL_APPROVAL_DATA();
                    DataSet ds_1 = new DataSet();
                    string id = Convert.ToString(Session["ECODE"]);
                    ds_1 = objBAL.GET_Employee_Admin_Main_Data_2(id);
                    if (ds_1.Tables[0].Rows.Count > 0)
                    {

                        if (ds_1.Tables[0].Rows[0][20].ToString() == "Pending with Secreterial")
                        {
                            showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                            msg = "Exercise is pending for approval by Secreterial";
                            lblmsg4.Text = msg;
                            lblmsg4.Visible = true;
                            DisablePageControls(false);
                        }
                        if (ds_1.Tables[0].Rows[0][20].ToString() == "Pending with Admin")
                        {
                            showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                            msg = "Exercise is pending for approval by Admin";
                            lblmsg4.Text = msg;
                            lblmsg4.Visible = true;
                            DisablePageControls(false);
                        }
                        if (ds_1.Tables[0].Rows[0][20].ToString() == "Doc Upload Pending")
                        {
                            showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                            msg = "Document is pending for upload by Admin";
                            lblmsg4.Text = msg;
                            lblmsg4.Visible = true;
                            DisablePageControls(false);
                        }
                        //added by Pallavi on 26/04/2022
                        if (ds_1.Tables[1].Rows[0]["STATUS"].ToString() == "Approved")
                        {
                            //    btnmsg1.Enabled = true;
                            //    btnmsg2.Enabled = true;
                            DisablePageControls(false);
                        }

                        if (ds_1.Tables[1].Rows[0]["DETAIL_STATUS"].ToString() == "Pending")
                        {
                            btnSubmit1.Enabled = true;
                            btnSubmit1.Visible = true;
                        }
                        else
                        {
                            btnSubmit1.Visible = false;
                            btnSubmit1.Enabled = false;
                            btnmsg1.Enabled = true;
                            btnmsg2.Enabled = true;
                            btnimport.Enabled = true;
                            DisablePageControls(false);
                        }
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
                    //txtChequeDate.Attributes.Add("readonly", "readonly");
                    if (lblmsg1.Text == "Please submit Bank details for login Employee"
                        || lblmsg2.Text == "Please submit Demat details for login Employee"
                        || lblmsg3.Text == "Exercise window is closed or not been created by admin")
                    {
                        //DisablePageControls(false);
                    }
                    else
                    {
                        //DisablePageControls(true);
                    }
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

                    DataSet ds = objBAL.GET_ECERCISE_WINDOW();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblmsg3.Visible = false;
                        objBO = new employee_exerciseBO();
                        //objBO.EXERCISE_WINDOW_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["EXERCISE_id"].ToString());
                        //objBO.EXERCISE_WINDOW_END_DATE  = Convert.ToDateTime(ds.Tables[0].Rows[0]["END_DATE"].ToString());
                        Session["EXERCISE_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["EXERCISE_id"].ToString());
                        Session["START_DATE"] = ds.Tables[0].Rows[0]["START_DATE"].ToString();
                        Session["exercise_ID"] = ds.Tables[0].Rows[0]["exercise_ID"].ToString();
                        Session["FMV_PRICE"] = ds.Tables[0].Rows[0]["FMV_PRICE"].ToString();
                        BIND_EXERCISE_GRID();
                    }
                    else
                    {
                        showmsg.Visible = true;
                        lblmsg1.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        msg = "Exercise window is closed or not been created by admin";
                        lblmsg3.Text = msg;
                        lblmsg3.Visible = true;
                    }

                    if (lblmsg1.Text == "Please submit Bank details for login Employee"
                    || lblmsg2.Text == "Please submit Demat details for login Employee"
                    || lblmsg3.Text == "Exercise window is closed or not been created by admin")
                    {
                        //DisablePageControls(false);
                    }
                    else
                    {
                        //DisablePageControls(true);
                    }
                    if (Convert.ToString(ViewState["Grd_Session"]) == "True")
                    {

                        txtLoanAmount.Text = Convert.ToString(ViewState["LoanAmount"]);
                        txtLoanMarginAmount.Text = Convert.ToString(ViewState["LoanMarginAmount"]);
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
                //throw ex;
            }
        }

        private void EMPLOYEE_DETAIL_APPROVAL_DATA()
        {
            try
            {
                DataSet ds = objBAL.EMPLOYEE_DETAIL_APPROVAL_DATA();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["DETAIL_STATUS"].ToString() == "APPROVED_BY_ADMIN")
                    {
                        gvExercise.DataSource = ds.Tables[0];
                        gvExercise.DataBind();
                        CalculateTotal_No_Of_Options(0, 0);
                        // btn_BulkApprove.Visible = true;
                        //btn_BulkReject.Visible = true;
                    }
                    else
                    {
                        gvExercise.DataSource = null;
                        gvExercise.DataBind();
                        // btn_BulkApprove.Visible = false;
                        // btn_BulkReject.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }
        private void BIND_EXERCISE_GRID()
        {
            DataTable dtExCount = new DataTable();
            objBO = new employee_exerciseBO();
            try
            {
                objBO.ECODE = Convert.ToString(Session["ECODE"]);

                //-----
                objBO.EXERCISE_WINDOW_ID = Convert.ToInt32(Session["EXERCISE_ID"].ToString());
                objBO.EXERCISE_WINDOW_START_DATE = Convert.ToDateTime(Session["START_DATE"].ToString(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat).ToString();//(txtvaldate.Text);

                //objBO.EXERCISE_WINDOW_START_DATE ="12-09-2020";
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
                        //Session["msg"] = msg;  

                        //showmsg.InnerText = "Exercise not uploaded by Admin ";
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
                    //if (Session["msg"].ToString() != "")
                    //{
                    //    DisablePageControls(false);
                    //}
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
                //throw ex;
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

        protected void txtOptionsExercised_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
                int rowindex = row.RowIndex;
                string Vesting_Detail_ID = gvExercise.DataKeys[rowindex].Values[0].ToString();
                //NamingContainer return the container that the control sits in
                TextBox txtOptionsPending = (TextBox)row.FindControl("txtOptionsPending");
                TextBox txtOptions = (TextBox)row.FindControl("txtOptions");
                TextBox txtOptionsExercised = (TextBox)row.FindControl("txtOptionsExercised");
                Label LblAlert = (Label)row.FindControl("LblAlert");
                //txtOptionsPending.Text == "" ? "0" : txtOptionsPending.Text;
                if (txtOptionsExercised.Text == "")
                {
                    txtOptionsExercised.Text = "0";
                }
                if (Convert.ToDouble(txtOptionsPending.Text) < Convert.ToDouble(txtOptionsExercised.Text))
                {
                    Common.ShowJavascriptAlert("No.of options to be Exercised is not greater than No.of pending Exercise");
                    //LblAlert.Text = "*";
                    txtOptionsExercised.Text = "0";
                    //return;
                }
                else
                {
                    //LblAlert.Text = "";
                }
                txtOptionsPending.Text = Convert.ToString(Convert.ToDouble(txtOptions.Text) - Convert.ToDouble(txtOptionsExercised.Text));
                DataTable dtcal = CalculateTotal(Convert.ToInt32(Vesting_Detail_ID), Convert.ToInt32(txtOptionsExercised.Text));
                gvExerciseCal.DataSource = dtcal;
                gvExerciseCal.DataBind();

                DataTable dtcalexCount = CalculateTotal_No_Of_Options(Convert.ToInt32(Vesting_Detail_ID), Convert.ToDouble(txtOptionsExercised.Text));
                gvExercise.DataSource = null;
                gvExercise.DataSource = dtcalexCount;
                gvExercise.DataBind();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
            }

        }

        //private DataTable CalculateTotal(int Vesting_Detail_ID, double OptionsExercised)
        //{
        //    /* Code for Grouping and Total */
        //    DataTable newdt = new DataTable();
        //    //double Total_Amount = 0;
        //    decimal Total_Amount = 0;
        //    double Exercise_Count = 0;
        //    string Tranch_Vesting = "";
        //    try
        //    {

        //        DataTable dt = (DataTable)ViewState["Exercise_Cal"];

        //        newdt.Columns.Add("Vesting_DETAIL_ID");
        //        newdt.Columns.Add("ECODE");
        //        newdt.Columns.Add("EMP_NAME");
        //        newdt.Columns.Add("GRANT_ID");
        //        newdt.Columns.Add("GRANT_NAME");
        //        newdt.Columns.Add("VESTING_ID");
        //        newdt.Columns.Add("V_DETAIL_ID");
        //        newdt.Columns.Add("no_of_vesting");
        //        newdt.Columns.Add("Vesting_Date");
        //        newdt.Columns.Add("Tranch_Vesting");
        //        newdt.Columns.Add("status");
        //        newdt.Columns.Add("GRANT_PRICE");
        //        newdt.Columns.Add("fmv_price");
        //        newdt.Columns.Add("no_of_exercise");
        //        newdt.Columns.Add("pending_exercise");
        //        newdt.Columns.Add("taxable_income");
        //        newdt.Columns.Add("Exercise_Consideration");
        //        newdt.Columns.Add("FMV_Grant_Option__Exercise");
        //        newdt.Columns.Add("Revised_Taxable_Income");
        //        newdt.Columns.Add("Tax_Per_Option");
        //        newdt.Columns.Add("Perq_Tax_Amount");
        //        newdt.Columns.Add("Total_Amount");
        //        newdt.Columns.Add("no_of_option_exercise");


        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {

        //            if (Convert.ToString(dt.Rows[i][0].ToString()) == Convert.ToString(Vesting_Detail_ID))
        //            {
        //                DataRow dr1 = newdt.NewRow();
        //                dr1["Vesting_DETAIL_ID"] = dt.Rows[i][0].ToString();
        //                dr1["ECODE"] = dt.Rows[i][1].ToString();
        //                dr1["EMP_NAME"] = dt.Rows[i][2].ToString();
        //                dr1["GRANT_ID"] = dt.Rows[i][3].ToString();
        //                dr1["GRANT_NAME"] = (dt.Rows[i][4]);
        //                dr1["VESTING_ID"] = (dt.Rows[i][5]);
        //                dr1["V_DETAIL_ID"] = (dt.Rows[i][6]);
        //                dr1["no_of_vesting"] = (dt.Rows[i][7]);
        //                dr1["Vesting_Date"] = (dt.Rows[i][8]);
        //                dr1["Tranch_Vesting"] = (dt.Rows[i][9]);
        //                dr1["status"] = (dt.Rows[i][10]);
        //                dr1["GRANT_PRICE"] = (dt.Rows[i][11]);
        //                dr1["fmv_price"] = Session["FMV_PRICE"].ToString(); // (dt.Rows[i][12]);
        //                dr1["no_of_exercise"] = (dt.Rows[i][13]);
        //                dr1["pending_exercise"] = dt.Rows[i][14].ToString();//Convert.ToDateTime(dt.Rows[i][14]).ToString("MM/dd/yyyy");
        //                dr1["taxable_income"] = dt.Rows[i][15].ToString();

        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1", DateTime.Now));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1", dt.Rows[i][11]));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.1", Convert.ToDouble(dt.Rows[i][11])));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.2", Convert.ToDouble(OptionsExercised)));
        //                dr1["Exercise_Consideration"] = (Convert.ToDouble(dt.Rows[i][11]) * Convert.ToDouble(OptionsExercised));//dt.Rows[i][16].ToString();

        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 2", DateTime.Now));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 2", dt.Rows[i][12]));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 2.1", dt.Rows[i][11]));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 2.2", OptionsExercised));
        //                dr1["FMV_Grant_Option__Exercise"] = ((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised);//dt.Rows[i][17].ToString();

        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 3", DateTime.Now));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 3", Convert.ToDouble(dt.Rows[i][15])));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 3.1", (Convert.ToDouble(dt.Rows[i][12]))));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 3.2", Convert.ToDouble(dt.Rows[i][11])));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 3.3", OptionsExercised));

        //                ///////change-----6-12-2020
        //                if (OptionsExercised == 0)
        //                {
        //                    dr1["Revised_Taxable_Income"] = 0;
        //                }
        //                else
        //                {
        //                    ///////change-----6-12-2020
        //                    dr1["Revised_Taxable_Income"] = (Convert.ToDouble(dt.Rows[i][15]) + ((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised));//dt.Rows[i][18].ToString();
        //                }

        //                //dr1["Revised_Taxable_Income"] = (Convert.ToDouble(dt.Rows[i][15]) + ((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised));//dt.Rows[i][18].ToString();
        //                dr1["Tax_Per_Option"] = dt.Rows[i][19].ToString();

        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 4", DateTime.Now));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 4", dt.Rows[i][12]));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 4.1", Convert.ToDouble(dt.Rows[i][12])));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 4.2", Convert.ToDouble(dt.Rows[i][11])));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 4.3", OptionsExercised));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 4.4", Convert.ToDouble(dt.Rows[i][19])));
        //                if ((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) != 0)
        //                {
        //                    dr1["Perq_Tax_Amount"] = ((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100); //dt.Rows[i][20].ToString();
        //                }
        //                else
        //                {
        //                    dr1["Perq_Tax_Amount"] = "0";
        //                }
        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 5", DateTime.Now));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 4", Convert.ToDouble(dt.Rows[i][12])));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 4.1", Convert.ToDouble(dt.Rows[i][11])));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 4.3", OptionsExercised));
        //                //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Line 4.4", Convert.ToDouble(dt.Rows[i][19])));
        //                decimal Dum_Tot = 0;
        //                if ((Convert.ToDecimal(dt.Rows[i][12]) - Convert.ToDecimal(dt.Rows[i][11])) == 0)
        //                {
        //                    WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 5.1 inside if =0", DateTime.Now));
        //                    Dum_Tot = 0;
        //                }
        //                else
        //                {
        //                    WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 5.2 inside else", DateTime.Now));
        //                    Dum_Tot = ((((Convert.ToDecimal(dt.Rows[i][12]) - Convert.ToDecimal(dt.Rows[i][11])) * Convert.ToDecimal(OptionsExercised)) * Convert.ToDecimal(dt.Rows[i][19])) / 100);
        //                }
        //                // dr1["Total_Amount"] = ((Dum_Tot * Convert.ToDouble(dt.Rows[i][19])) / 100) + (Convert.ToDouble(dt.Rows[i][11]) * OptionsExercised);//dt.Rows[i][21].ToString();cimal(OptionsExercised)) * Convert.ToDecimal(dt.Rows[i][19])) / 100);
        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 5.3 outside if else", DateTime.Now));
        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Dum_to=" + Dum_Tot, DateTime.Now));
        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "11=" + dt.Rows[i][11], DateTime.Now));
        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "OptionsExercised=" + OptionsExercised, DateTime.Now));
        //                dr1["Total_Amount"] = (Dum_Tot + (Convert.ToDecimal(dt.Rows[i][11]) * Convert.ToDecimal(OptionsExercised)));//dt.Rows[i][21].ToString();

        //                dr1["no_of_option_exercise"] = OptionsExercised;// dt.Rows[i][22].ToString();
        //                //newdt.Rows.Add(dr1);
        //                if (dr1["Perq_Tax_Amount"].ToString().Contains("Total"))
        //                {

        //                }
        //                else
        //                {
        //                    WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line  inside NEW else", DateTime.Now));
        //                    newdt.Rows.Add(dr1);


        //                    Decimal New_Dum_Tot = 0;
        //                    if ((Convert.ToDecimal(dt.Rows[i][12]) - Convert.ToDecimal(dt.Rows[i][11])) == 0)
        //                    {
        //                        WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "inside New_Dum_Tot", DateTime.Now));
        //                        New_Dum_Tot = 0;
        //                    }
        //                    else
        //                    {
        //                        New_Dum_Tot = Convert.ToDecimal(dt.Rows[i][12]) - Convert.ToDecimal(dt.Rows[i][11]) * Convert.ToDecimal(OptionsExercised);
        //                    }
        //                    Decimal New_Dum_Tot_1 = 0;
        //                    if ((Convert.ToDecimal(dt.Rows[i][11]) * Convert.ToDecimal(OptionsExercised)) == 0)
        //                    {
        //                        WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "inside New_Dum_Tot1", DateTime.Now));

        //                        New_Dum_Tot_1 = 0;
        //                    }
        //                    else
        //                    {
        //                        WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "inside New_Dum_Tot11", DateTime.Now));

        //                        New_Dum_Tot_1 = Convert.ToDecimal(dt.Rows[i][11]) * Convert.ToDecimal(OptionsExercised);
        //                    }

        //                    Decimal New_Dum_Tot_2 = 0;

        //                    if ((New_Dum_Tot * Convert.ToDecimal(dt.Rows[i][19])) == 0)
        //                    {
        //                        WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "inside New_Dum_Tot21", DateTime.Now));

        //                        New_Dum_Tot_2 = 0;
        //                    }
        //                    else
        //                    {
        //                        WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "inside New_Dum_Tot22", DateTime.Now));

        //                        New_Dum_Tot_2 = (New_Dum_Tot * Convert.ToDecimal(dt.Rows[i][19])) / 100;
        //                    }
        //                    //Total_Amount += ((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100) + (Convert.ToDouble(dt.Rows[i][11]) * OptionsExercised);
        //                    Total_Amount += (New_Dum_Tot_2) + (New_Dum_Tot_1);

        //                    WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line Total_Amount", DateTime.Now));
        //                    Exercise_Count += OptionsExercised;
        //                    if (Convert.ToString(ViewState["Tranch_Vesting"]) == "")
        //                    {
        //                        if (OptionsExercised == 0)
        //                        {

        //                            Tranch_Vesting = Tranch_Vesting.Replace((dt.Rows[i][9].ToString()), "");
        //                        }
        //                        else
        //                        {
        //                            Tranch_Vesting = (dt.Rows[i][9].ToString());
        //                        }
        //                        WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line Tranch_Vesting", DateTime.Now));
        //                    }
        //                    else
        //                    {
        //                        if (OptionsExercised == 0)
        //                        {
        //                            Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]).Replace((dt.Rows[i][9].ToString()), "");
        //                        }
        //                        else
        //                        {
        //                            Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]) + "," + (dt.Rows[i][9].ToString());
        //                        }

        //                    }

        //                }
        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "FINAL LINE", DateTime.Now));

        //                //Total_Amount += ((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100) + (Convert.ToDouble(dt.Rows[i][12]) * OptionsExercised); 
        //            }
        //            else
        //            {
        //                DataRow dr1 = newdt.NewRow();
        //                dr1["Vesting_DETAIL_ID"] = dt.Rows[i][0].ToString();
        //                dr1["ECODE"] = dt.Rows[i][1].ToString();
        //                dr1["EMP_NAME"] = dt.Rows[i][2].ToString();
        //                dr1["GRANT_ID"] = dt.Rows[i][3].ToString();
        //                dr1["GRANT_NAME"] = (dt.Rows[i][4]);
        //                dr1["VESTING_ID"] = (dt.Rows[i][5]);
        //                dr1["V_DETAIL_ID"] = (dt.Rows[i][6]);
        //                dr1["no_of_vesting"] = (dt.Rows[i][7]);
        //                dr1["Vesting_Date"] = (dt.Rows[i][8]);
        //                dr1["Tranch_Vesting"] = (dt.Rows[i][9]);
        //                dr1["status"] = (dt.Rows[i][10]);
        //                dr1["GRANT_PRICE"] = (dt.Rows[i][11]);
        //                dr1["fmv_price"] = Session["FMV_PRICE"].ToString(); // (dt.Rows[i][12]);
        //                dr1["no_of_exercise"] = (dt.Rows[i][13]);
        //                dr1["pending_exercise"] = dt.Rows[i][14].ToString();//Convert.ToDateTime(dt.Rows[i][14]).ToString("MM/dd/yyyy");
        //                dr1["taxable_income"] = dt.Rows[i][15].ToString();
        //                dr1["Exercise_Consideration"] = dt.Rows[i][16].ToString();
        //                dr1["FMV_Grant_Option__Exercise"] = dt.Rows[i][17].ToString();
        //                dr1["Revised_Taxable_Income"] = dt.Rows[i][18].ToString();
        //                dr1["Tax_Per_Option"] = dt.Rows[i][19].ToString();
        //                dr1["Perq_Tax_Amount"] = dt.Rows[i][20].ToString();
        //                dr1["Total_Amount"] = dt.Rows[i][21].ToString();
        //                dr1["no_of_option_exercise"] = dt.Rows[i][22].ToString();
        //                //newdt.Rows.Add(dr1);
        //                if (dr1["Perq_Tax_Amount"].ToString().Contains("Total"))
        //                {

        //                }
        //                else
        //                {
        //                    newdt.Rows.Add(dr1);
        //                    //Total_Amount += Convert.ToDouble(dt.Rows[i][21].ToString());
        //                    Total_Amount += Convert.ToDecimal(dt.Rows[i][21].ToString());
        //                    Exercise_Count += Convert.ToDouble(dt.Rows[i][22].ToString());
        //                }

        //                //Total_Amount += Convert.ToDouble(dt.Rows[i][21].ToString());
        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "FINAL ELSE", DateTime.Now));
        //            }
        //            DataRow dr11 = newdt.NewRow();
        //            if ((dt.Rows.Count - 1) == i)
        //            {
        //                ////////if (dr11["Perq_Tax_Amount"].ToString().Contains("Total"))
        //                ////////{

        //                ////////}
        //                //dr11["Vesting_DETAIL_ID"] = "0";
        //                dr11["Perq_Tax_Amount"] = "Total";
        //                dr11["Total_Amount"] = Total_Amount;

        //                newdt.Rows.Add(dr11);

        //                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "FINAL_FINAL", DateTime.Now));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", ex.Message, DateTime.Now));
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //    }
        //    ViewState["Exercise_Cal"] = newdt;
        //    ViewState["Total_Amount"] = Total_Amount;
        //    ViewState["Exercise_Count"] = Exercise_Count;
        //    ViewState["Tranch_Vesting"] = Tranch_Vesting;
        //    return newdt;

        //}

        private DataTable CalculateTotal(int Vesting_Detail_ID, int OptionsExercised)
        {
            /* Code for Grouping and Total */
            DataTable newdt = new DataTable();
            double Total_Amount = 0;
            double Exercise_Consideration = 0;
            double Perq_Tax_Amount = 0;
            double Exercise_Count = 0;
            ////string Tranch_Vesting = "";
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
                    if (Convert.ToString(dt.Rows[i][0]) == Convert.ToString(Vesting_Detail_ID))
                    {
                        DataRow dr1 = newdt.NewRow();
                        dr1["Vesting_DETAIL_ID"] = dt.Rows[i][0].ToString();
                        dr1["ECODE"] = dt.Rows[i][1].ToString();
                        dr1["EMP_NAME"] = dt.Rows[i][2].ToString();
                        dr1["GRANT_ID"] = dt.Rows[i][3].ToString();
                        dr1["GRANT_NAME"] = (dt.Rows[i][4]);
                        dr1["VESTING_ID"] = (dt.Rows[i][5]);
                        dr1["V_DETAIL_ID"] = (dt.Rows[i][6]);
                        dr1["no_of_vesting"] = (dt.Rows[i][7]);
                        dr1["Vesting_Date"] = (dt.Rows[i][8]);
                        dr1["Tranch_Vesting"] = (dt.Rows[i][9]);
                        dr1["status"] = (dt.Rows[i][10]);
                        dr1["GRANT_PRICE"] = (dt.Rows[i][11]);
                        dr1["fmv_price"] = Session["FMV_PRICE"].ToString(); //(dt.Rows[i][12]);
                        dr1["no_of_exercise"] = (dt.Rows[i][13]);
                        dr1["pending_exercise"] = dt.Rows[i][14].ToString();//Convert.ToDateTime(dt.Rows[i][14]).ToString("MM/dd/yyyy");
                        dr1["taxable_income"] = dt.Rows[i][15].ToString();
                        dr1["Exercise_Consideration"] = Convert.ToDouble(dt.Rows[i][11]) * OptionsExercised;//dt.Rows[i][16].ToString();
                        dr1["FMV_Grant_Option__Exercise"] = Convert.ToDouble((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised);//dt.Rows[i][17].ToString();
                        if (OptionsExercised == 0)
                        {
                            dr1["Revised_Taxable_Income"] = 0;
                        }
                        else
                        {
                            ///////change-----6-12-2020
                            dr1["Revised_Taxable_Income"] = (Convert.ToDouble(dt.Rows[i][15]) + ((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised));//dt.Rows[i][18].ToString();
                        }
                        //dr1["Revised_Taxable_Income"] = Convert.ToInt32(dt.Rows[i][15]) + ((Convert.ToInt32(dt.Rows[i][12]) - Convert.ToInt32(dt.Rows[i][11])) * OptionsExercised);//dt.Rows[i][18].ToString();
                        dr1["Tax_Per_Option"] = Convert.ToString(dt.Rows[i][19]);
                        dr1["Perq_Tax_Amount"] = ((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100).ToString("0.00"); //dt.Rows[i][20].ToString();
                        dr1["Total_Amount"] = (((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100) + (Convert.ToDouble(dt.Rows[i][11]) * OptionsExercised)).ToString("0.00");//dt.Rows[i][21].ToString();
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
                            Total_Amount += ((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100) + (Convert.ToDouble(dt.Rows[i][11]) * OptionsExercised);
                            Exercise_Consideration += Convert.ToDouble(dr1["Exercise_Consideration"]);
                            Perq_Tax_Amount += Convert.ToDouble(dr1["Perq_Tax_Amount"]);
                            Exercise_Count += OptionsExercised;
                            if (Convert.ToString(ViewState["Tranch_Vesting"]) == "")
                            {
                                if (OptionsExercised == 0)
                                {
                                    Tranch_Vesting = Tranch_Vesting.Replace((dt.Rows[i][9].ToString()), "");
                                }
                                else
                                {
                                    Tranch_Vesting = (dt.Rows[i][9].ToString());
                                }

                            }
                            else
                            {
                                if (OptionsExercised == 0)
                                {
                                    Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]).Replace((dt.Rows[i][9].ToString()), "");
                                }
                                else
                                {
                                    Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]) + "," + (dt.Rows[i][9].ToString());
                                }

                            }

                        }

                        //Total_Amount += ((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100) + (Convert.ToDouble(dt.Rows[i][12]) * OptionsExercised); 
                    }
                    else
                    {
                        DataRow dr1 = newdt.NewRow();
                        dr1["Vesting_DETAIL_ID"] = dt.Rows[i][0].ToString();
                        dr1["ECODE"] = dt.Rows[i][1].ToString();
                        dr1["EMP_NAME"] = dt.Rows[i][2].ToString();
                        dr1["GRANT_ID"] = dt.Rows[i][3].ToString();
                        dr1["GRANT_NAME"] = (dt.Rows[i][4]);
                        dr1["VESTING_ID"] = (dt.Rows[i][5]);
                        dr1["V_DETAIL_ID"] = (dt.Rows[i][6]);
                        dr1["no_of_vesting"] = (dt.Rows[i][7]);
                        dr1["Vesting_Date"] = (dt.Rows[i][8]);
                        dr1["Tranch_Vesting"] = (dt.Rows[i][9]);
                        dr1["status"] = (dt.Rows[i][10]);
                        dr1["GRANT_PRICE"] = (dt.Rows[i][11]);
                        dr1["fmv_price"] = Session["FMV_PRICE"].ToString(); //(dt.Rows[i][12]);
                        dr1["no_of_exercise"] = (dt.Rows[i][13]);
                        dr1["pending_exercise"] = dt.Rows[i][14].ToString();//Convert.ToDateTime(dt.Rows[i][14]).ToString("MM/dd/yyyy");
                        dr1["taxable_income"] = dt.Rows[i][15].ToString();
                        dr1["Exercise_Consideration"] = dt.Rows[i][16].ToString();
                        dr1["FMV_Grant_Option__Exercise"] = dt.Rows[i][17].ToString();
                        dr1["Revised_Taxable_Income"] = dt.Rows[i][18].ToString();
                        dr1["Tax_Per_Option"] = dt.Rows[i][19].ToString();
                        dr1["Perq_Tax_Amount"] = dt.Rows[i][20].ToString();
                        dr1["Total_Amount"] = dt.Rows[i][21].ToString();
                        dr1["no_of_option_exercise"] = dt.Rows[i][22].ToString();
                        //newdt.Rows.Add(dr1);
                        //if (dr1["Perq_Tax_Amount"].ToString().Contains("Total"))
                        if (dr1["Tranch_Vesting"].ToString().Contains("Total"))
                        {

                        }
                        else
                        {
                            //string Prc = Convert.ToDecimal(dr1["taxable_income"].ToString()).ToString("N", CInfo);
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
                            Total_Amount += Convert.ToDouble(dt.Rows[i][21].ToString());
                            Exercise_Consideration += Convert.ToDouble(dt.Rows[i][16].ToString());
                            Perq_Tax_Amount += Convert.ToDouble(dt.Rows[i][20].ToString());
                            Exercise_Count += Convert.ToDouble(dt.Rows[i][22].ToString());
                        }

                        //Total_Amount += Convert.ToDouble(dt.Rows[i][21].ToString());
                    }
                    DataRow dr11 = newdt.NewRow();
                    if ((dt.Rows.Count - 1) == i)
                    {
                        ////////if (dr11["Perq_Tax_Amount"].ToString().Contains("Total"))
                        ////////{

                        ////////}
                        //dr11["Vesting_DETAIL_ID"] = "0";

                        //dr11["Perq_Tax_Amount"] = "Total(₹)";
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
                        //lblPerq_Tax_Amount.Font.Size = 13;
                        //lblTotal_Amount.Font.Size = 13;

                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

        }

        protected void btnimport_Click(object sender, EventArgs e)
        {

            //lblTranchVesting.InnerText = Convert.ToString(ViewState["Tranch_Vesting"]).Replace(", ,", ",");
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
                    //if (Convert.ToString(ViewState["Cheque_FilePath"]) != "")
                    //{
                    //    Image1.ImageUrl = ViewState["Cheque_FilePath"].ToString();
                    //    f1.Visible = true;
                    //}
                    //else
                    //{
                    //    f1.Visible = false;
                    //}

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
                    //if (Convert.ToString(ViewState["Cheque_FilePathLoan"]) != "")
                    //{
                    //    Image1.ImageUrl = ViewState["Cheque_FilePathLoan"].ToString();
                    //    f1.Visible = true;
                    //}
                    //else
                    //{
                    //    f1.Visible = false;
                    //}
                    //f1.Visible = false;
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

                //Common.ShowJavascriptAlert(Convert.ToString(ViewState["Total_Amount"]));
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

        }

        private DataTable CalculateTotal_No_Of_Options(int Vesting_Detail_ID, double OptionsExercised)
        {
            /* Code for Grouping and Total */
            DataTable newdt = new DataTable();
            /////double Total_Amount = 0;
            double Exercise_Count = 0;
            //////string Tranch_Vesting = "";
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

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToString(dt.Rows[i][0].ToString()) == Convert.ToString(Vesting_Detail_ID))
                    {
                        DataRow dr1 = newdt.NewRow();
                        dr1["Vesting_DETAIL_ID"] = dt.Rows[i][0].ToString();
                        dr1["ECODE"] = dt.Rows[i][1].ToString();
                        dr1["EMP_NAME"] = dt.Rows[i][2].ToString();
                        dr1["GRANT_ID"] = dt.Rows[i][3].ToString();
                        dr1["GRANT_NAME"] = (dt.Rows[i][4]);
                        dr1["VESTING_ID"] = (dt.Rows[i][5]);
                        dr1["V_DETAIL_ID"] = (dt.Rows[i][6]);
                        dr1["no_of_vesting"] = (dt.Rows[i][7]);
                        dr1["Vesting_Date"] = (dt.Rows[i][8]);
                        dr1["Tranch_Vesting"] = (dt.Rows[i][9]);
                        dr1["status"] = (dt.Rows[i][10]);
                        dr1["GRANT_PRICE"] = (dt.Rows[i][11]);
                        dr1["fmv_price"] = Session["FMV_PRICE"].ToString(); // (dt.Rows[i][12]);
                        dr1["no_of_exercise"] = (dt.Rows[i][13]);
                        dr1["Pending_for_Approval"] = (dt.Rows[i]["Pending_for_Approval"]);
                        dr1["Total_no_of_Options"] = (dt.Rows[i]["Total_no_of_Options"]);

                        //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.1", DateTime.Now));
                        //dr1["pending_exercise"] = Convert.ToDouble(dt.Rows[i][7].ToString()) - Convert.ToDouble(dt.Rows[i][13].ToString()) - OptionsExercised;//Convert.ToInt32(dt.Rows[i][7].ToString()) - OptionsExercised;
                        dr1["pending_exercise"] = Convert.ToDouble(dt.Rows[i][7].ToString()) - Convert.ToDouble(dt.Rows[i][13].ToString()) - Convert.ToDouble(dt.Rows[i]["Pending_for_Approval"].ToString());

                        //dr1["taxable_income"] = dt.Rows[i][15].ToString();
                        dr1["taxable_income"] = string.IsNullOrEmpty(dt.Rows[i][15].ToString()) ? "" : Convert.ToDecimal(dt.Rows[i][15].ToString()).ToString("N", CInfo);


                        //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.2", DateTime.Now));
                        dr1["Exercise_Consideration"] = Convert.ToDouble(dt.Rows[i][11]) * OptionsExercised;//dt.Rows[i][16].ToString();

                        //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.3", DateTime.Now));
                        dr1["FMV_Grant_Option__Exercise"] = ((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised).ToString("0.00");//dt.Rows[i][17].ToString();

                        //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.4", DateTime.Now));
                        dr1["Revised_Taxable_Income"] = (Convert.ToDouble(dt.Rows[i][15]) + ((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised)).ToString("0.00"); ;//dt.Rows[i][18].ToString();
                        dr1["Tax_Per_Option"] = dt.Rows[i][19].ToString();

                        //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.5", DateTime.Now));
                        if ((Convert.ToDecimal(dt.Rows[i][12]) - Convert.ToDecimal(dt.Rows[i][11])) != 0)
                        {
                            dr1["Perq_Tax_Amount"] = ((((Convert.ToDecimal(dt.Rows[i][12]) - Convert.ToDecimal(dt.Rows[i][11])) * Convert.ToDecimal(OptionsExercised)) * Convert.ToDecimal(dt.Rows[i][19])) / 100).ToString("0.00"); ; //dt.Rows[i][20].ToString();
                        }
                        else
                        {
                            dr1["Perq_Tax_Amount"] = "0";
                        }
                        //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.6", DateTime.Now));

                        Decimal Dum_Tot;
                        if ((Convert.ToDecimal(dt.Rows[i][12]) - Convert.ToDecimal(dt.Rows[i][11])) == 0)
                        {
                            //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.6.1 inside if ", DateTime.Now));
                            Dum_Tot = 0;
                        }
                        else
                        {
                            //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.6.2 inside  else", DateTime.Now));
                            Dum_Tot = ((((Convert.ToDecimal(dt.Rows[i][12]) - Convert.ToDecimal(dt.Rows[i][11])) * Convert.ToDecimal(OptionsExercised)) * Convert.ToDecimal(dt.Rows[i][19])) / 100);
                        }

                        //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.6.3 outside if else", DateTime.Now));

                        dr1["Total_Amount"] = (Dum_Tot + (Convert.ToDecimal(dt.Rows[i][11]) * Convert.ToDecimal(OptionsExercised))).ToString("0.00");
                        //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.6.4 outside if else", DateTime.Now));


                        //dr1["Total_Amount"] = (((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100) + (Convert.ToDouble(dt.Rows[i][11]) * OptionsExercised)).ToString("0.00");//dt.Rows[i][21].ToString();
                        //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 1.7", DateTime.Now));

                        dr1["no_of_option_exercise"] = OptionsExercised;// dt.Rows[i][22].ToString();
                        //newdt.Rows.Add(dr1);
                        if (dr1["no_of_vesting"].ToString().Contains("Total"))
                        {

                        }
                        else
                        {
                            newdt.Rows.Add(dr1);
                            //Total_Amount += ((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100) + (Convert.ToDouble(dt.Rows[i][11]) * OptionsExercised);
                            Exercise_Count += OptionsExercised;
                            ////////if (Convert.ToString(ViewState["Tranch_Vesting"]) == "")
                            ////////{
                            ////////    if (OptionsExercised == 0)
                            ////////    {
                            ////////        Tranch_Vesting = Tranch_Vesting.Replace((dt.Rows[i][9].ToString()), "");
                            ////////    }
                            ////////    else
                            ////////    {
                            ////////        Tranch_Vesting = (dt.Rows[i][9].ToString());
                            ////////    }

                            ////////}
                            ////////else
                            ////////{
                            ////////    if (OptionsExercised == 0)
                            ////////    {
                            ////////        Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]).Replace((dt.Rows[i][9].ToString()), "");
                            ////////    }
                            ////////    else
                            ////////    {
                            ////////        Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]) + "," + (dt.Rows[i][9].ToString());
                            ////////    }

                            ////////}

                        }

                        //Total_Amount += ((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100) + (Convert.ToDouble(dt.Rows[i][12]) * OptionsExercised); 
                    }
                    else
                    {
                        DataRow dr1 = newdt.NewRow();
                        dr1["Vesting_DETAIL_ID"] = dt.Rows[i][0].ToString();
                        dr1["ECODE"] = dt.Rows[i][1].ToString();
                        dr1["EMP_NAME"] = dt.Rows[i][2].ToString();
                        dr1["GRANT_ID"] = dt.Rows[i][3].ToString();
                        dr1["GRANT_NAME"] = (dt.Rows[i][4]);
                        dr1["VESTING_ID"] = (dt.Rows[i][5]);
                        dr1["V_DETAIL_ID"] = (dt.Rows[i][6]);
                        dr1["no_of_vesting"] = (dt.Rows[i][7]);
                        dr1["Vesting_Date"] = (dt.Rows[i][8]);
                        dr1["Tranch_Vesting"] = (dt.Rows[i][9]);
                        dr1["status"] = (dt.Rows[i][10]);
                        dr1["GRANT_PRICE"] = (dt.Rows[i][11]);
                        dr1["fmv_price"] = Session["FMV_PRICE"].ToString(); // (dt.Rows[i][12]);
                        dr1["no_of_exercise"] = (dt.Rows[i][13]);
                        dr1["pending_exercise"] = dt.Rows[i][14].ToString();//Convert.ToDateTime(dt.Rows[i][14]).ToString("MM/dd/yyyy");
                        dr1["taxable_income"] = dt.Rows[i][15].ToString();
                        dr1["Exercise_Consideration"] = dt.Rows[i][16].ToString();
                        dr1["FMV_Grant_Option__Exercise"] = dt.Rows[i][17].ToString();
                        dr1["Revised_Taxable_Income"] = dt.Rows[i][18].ToString();
                        dr1["Tax_Per_Option"] = dt.Rows[i][19].ToString();
                        dr1["Perq_Tax_Amount"] = dt.Rows[i][20].ToString();
                        dr1["Total_Amount"] = dt.Rows[i][21].ToString();
                        dr1["no_of_option_exercise"] = dt.Rows[i][22].ToString();
                        dr1["Pending_for_Approval"] = dt.Rows[i]["Pending_for_Approval"];
                        dr1["Total_no_of_Options"] = dt.Rows[i]["Total_no_of_Options"];

                        //newdt.Rows.Add(dr1);
                        if (dr1["no_of_vesting"].ToString().Contains("Total"))
                        {

                        }
                        else
                        {
                            newdt.Rows.Add(dr1);
                            //Total_Amount += Convert.ToDouble(dt.Rows[i][21].ToString());
                            Exercise_Count += Convert.ToDouble(dt.Rows[i][22].ToString());
                        }

                        //Total_Amount += Convert.ToDouble(dt.Rows[i][21].ToString());
                    }
                    DataRow dr11 = newdt.NewRow();
                    if ((dt.Rows.Count - 1) == i)
                    {
                        ////////if (dr11["Perq_Tax_Amount"].ToString().Contains("Total"))
                        ////////{

                        ////////}
                        //dr11["Vesting_DETAIL_ID"] = "0";

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
            //ViewState["Total_Amount"] = Total_Amount;
            //ViewState["Exercise_Count"] = Exercise_Count;
            //ViewState["Tranch_Vesting"] = Tranch_Vesting;
            return newdt;

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
                        ////////////////ViewState["OtherSecurity_FilePath"] = Server.MapPath("~/Exercise_Doc/EmployeeExcelFormatFile.xls");
                        //////////////////lnkDownload.Text = Path.GetFileName(Convert.ToString(ViewState["OtherSecurity_FilePath"]));
                        //////////////////lnkDownload.Visible = true;


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
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showhide()", true);

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

        protected void btnSubmit_Click(object sender, EventArgs e)
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
                ////Label lblTranchVesting = gvExercise.FindControl("lblTranchVesting") as Label;
                ////objBO.TRANCH_VESTING = Convert.ToString(lblTranchVesting.Text);
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
                    EXERCISE_TRAN_ID = objBAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION(objBO);
                }
                if (EXERCISE_TRAN_ID > 0)
                {
                    DataTable dt = (DataTable)ViewState["Exercise"];
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        if (Convert.ToDouble(dt.Rows[i][22]) != 0)
                        {
                            //objBO.ECODE = Convert.ToString(Session["ECODE"]);
                            //objBO.VESTING_DETAIL_ID = Convert.ToInt32(dt.Rows[i][0]);
                            //objBO.OPTION_EXERCISE = Convert.ToDouble(dt.Rows[i][22]);

                            //objBAL.UPDATE_EMPLOYEE_EXERCISE(objBO);

                            //----------------------insert into transaction details table for each option exercised tranch vesting wise-------------
                            objBO._EXERCISE_TRAN_ID = EXERCISE_TRAN_ID;
                            objBO._GRANT_ID = Convert.ToInt32(dt.Rows[i][3]);
                            objBO._VESTING_DETAIL_ID = Convert.ToInt32(dt.Rows[i][0]);
                            objBO._ECODE = Convert.ToString(dt.Rows[i][1]);
                            objBO._ENAME = Convert.ToString(dt.Rows[i][2]);
                            objBO._GRANT_NAME = Convert.ToString(dt.Rows[i][4]);
                            objBO._VESTING_DETAIL_CODE = Convert.ToString(dt.Rows[i][5]);
                            objBO._VESTING_DATE = Convert.ToDateTime(dt.Rows[i][8]);
                            objBO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i][7]);
                            objBO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i][11]);
                            objBO._GRANT_FMV_PRICE = Convert.ToDouble(Session["FMV_PRICE"].ToString()); // Convert.ToDouble(dt.Rows[i][12]);
                            objBO._NO_OF_EXERCISE = Convert.ToDouble(dt.Rows[i][22]);
                            //objBO._EXERCISE_DATE = Convert.ToInt32();
                            objBO._TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i][15]);
                            objBO._EXERCISE_CONSIDERATION = Convert.ToDouble(dt.Rows[i][16]);
                            objBO._FMV_GRANT_OPTION_EXERCISE = Convert.ToDouble(dt.Rows[i][17]);
                            objBO._REVISED_TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i][18]);
                            objBO._TAX_PER_OPTION = Convert.ToDouble(dt.Rows[i][19]);
                            objBO._PERQ_TAX_AMOUNT = Convert.ToDouble(dt.Rows[i][20]);
                            objBO._TOTAL_AMOUNT = Convert.ToDouble(dt.Rows[i][21]);
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
                                //////////objBO.LOAN_AMOUNT = Convert.ToDouble(lblLoanAmount.InnerText);
                                //////////objBO.LOAN_MARGIN_AMOUNT = Convert.ToDouble(lblLoanMarginAmount.InnerText);
                                //////////objBO.LOAN_MARGIN_PAYMENT_MODE = Convert.ToString(lblLoanPaymentMode.InnerText);
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

                                //DataSet ds1 = objBAL.GET_SESSION(objBO);
                                //if (ds1.Tables[0].Rows.Count > 0)
                                //{
                                //    Feeldata(ds1);
                                //}
                            }
                            else
                            {
                                objBAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS(objBO);
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
                    //showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    //showmsg.InnerText = "Exercise Data Saved";
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
                    // Common.ShowJavascriptAlert("Exercise Submitted Successfully.");
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Exercise Submitted Successfully and send to Admin for Approval";
                    //Response.Redirect(Request.Path, false);
                    ////Response.Redirect(Request.RawUrl);
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

        protected void lnkChequeDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuCheque.IsUploading) return;
                var scriptManager = ScriptManager.GetCurrent(this.Page);
                //if (scriptManager != null)
                //{
                //    scriptManager.RegisterPostBackControl(lnkChequeDownload);
                //}
                if (Convert.ToString(ViewState["Cheque_FilePath"]) == "")
                {
                    Common.ShowJavascriptAlert("Please Select Bank Name.");
                    return;
                }
                string filePath = Server.MapPath(Convert.ToString(ViewState["Cheque_FilePath"]));
                if (File.Exists(filePath) && Path.HasExtension(filePath))
                {
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No document available to download.');", true);
                }
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
                string ext = Path.GetExtension(fuNEFT1.FileName);

                if (Path.GetExtension(fileName).Contains(".png") || Path.GetExtension(fileName).Contains(".jpeg") || Path.GetExtension(fileName).Contains(".jpg") || Path.GetExtension(fileName).Contains(".pdf") || Path.GetExtension(fileName).Contains(".doc") || Path.GetExtension(fileName).Contains(".docx"))
                {
                    fileName = Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                    //string filename = System.IO.Path.GetFileName(fuNEFT1.FileName);
                    fuNEFT1.SaveAs(Server.MapPath("Exercise_Doc/" + fileName));
                    Session["NEFT_FilePath"] = "~/Exercise_Doc/" + fileName;
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

        protected void fuCheque_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                string fileName = Path.GetFileName(fuCheque.FileName);
                string ext = Path.GetExtension(fuCheque.FileName);

                if (Path.GetExtension(fileName).Contains(".png") || Path.GetExtension(fileName).Contains(".jpeg") || Path.GetExtension(fileName).Contains(".jpg") || Path.GetExtension(fileName).Contains(".pdf") || Path.GetExtension(fileName).Contains(".doc") || Path.GetExtension(fileName).Contains(".docx"))
                {

                    fileName = Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                    fuCheque.SaveAs(Server.MapPath(this.UploadFolderPath + fileName));
                    Session["Cheque_FilePathFresh"] = this.UploadFolderPath + fileName;
                    string F_Path = Server.MapPath(this.UploadFolderPath + fileName);
                    //UploadFtpFile(UploadFolderPath, fileName, F_Path);

                    //Common.UploadFtpFile("Exercise_Doc/" + fileName, F_Path);


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

        protected void txtLoanMarginAmount_TextChanged(object sender, EventArgs e)
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

        protected void txtLoanAmount_TextChanged(object sender, EventArgs e)
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

        #region "Loan Type"   
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

        protected void fuNEFTLoan_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                string fileName = Path.GetFileName(fuNEFTLoan.FileName);
                string ext = Path.GetExtension(fuNEFTLoan.FileName);

                if (Path.GetExtension(fileName).Contains(".png") || Path.GetExtension(fileName).Contains(".jpeg") || Path.GetExtension(fileName).Contains(".jpg") || Path.GetExtension(fileName).Contains(".pdf") || Path.GetExtension(fileName).Contains(".doc") || Path.GetExtension(fileName).Contains(".docx"))
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

        protected void fuChequeLoan_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                string fileName = Path.GetFileName(fuChequeLoan.FileName);
                string ext = Path.GetExtension(fuChequeLoan.FileName);

                if (Path.GetExtension(fileName).Contains(".png") || Path.GetExtension(fileName).Contains(".jpeg") || Path.GetExtension(fileName).Contains(".jpg") || Path.GetExtension(fileName).Contains(".pdf") || Path.GetExtension(fileName).Contains(".doc") || Path.GetExtension(fileName).Contains(".docx"))
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

        protected void lnkChequeDownloadLoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuChequeLoan.IsUploading) return;
                var scriptManager = ScriptManager.GetCurrent(this.Page);
                if (scriptManager != null)
                {
                    //scriptManager.RegisterPostBackControl(lnkChequeDownloadLoan);
                }
                if (Convert.ToString(ViewState["Cheque_FilePathLoan"]) == "")
                {
                    Common.ShowJavascriptAlert("Please Select Bank Name.");
                    return;
                }
                string filePath = Server.MapPath(Convert.ToString(ViewState["Cheque_FilePathLoan"]));
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
        #endregion
        protected void ddlLoanMarginMode_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void gvExercise_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[2].Visible = false;
            //e.Row.Cells[3].Visible = false;
            //e.Row.Cells[6].Visible = false;

            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[7].Visible = false;
        }

        protected void btnSession_Click(object sender, EventArgs e)
        {
            Session["Emp_Exercise_Session"] = "True";
            if (lblmsg1.Text == "Please submit Bank details for login Employee"
                    || lblmsg2.Text == "Please submit Demat details for login Employee"
                    || lblmsg3.Text == "Exercise window is closed or not been created by admin")
            {
                //nothing;
            }
            else
            {
                btnimport_Click(btnimport, new EventArgs());
            }
            //if (Session["msg"].ToString() != "")
            //{
            //    showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
            //    showmsg.InnerText = Session["msg"].ToString();
            //    Session["msg"] = msg;

            //}
        }

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

                //DataTable dtDEMATDetails = (DataTable)ViewState["DEMAT_Details"];
                //for (int i = 0; i < dtDEMATDetails.Rows.Count; i++)
                //{
                //    if (Convert.ToString(dtDEMATDetails.Rows[i][2]).Contains(ds1.Tables[0].Rows[0]["SECURITY_NAME"].ToString()))
                //    {
                //        ddlOtherSecurity.SelectedValue = Convert.ToString(dtDEMATDetails.Rows[i][0]);
                //        ddlOtherSecurity_SelectedIndexChanged(this, EventArgs.Empty);
                //    }
                //}

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

        //public void UploadFtpFile_0(string FolderPath, string fileName, string File_Path)
        //{
        //    string UserName = System.Configuration.ConfigurationManager.AppSettings["LinK_UserName"];
        //    string UserPassword = System.Configuration.ConfigurationManager.AppSettings["Link_UserPassword"];
        //    string Link = System.Configuration.ConfigurationManager.AppSettings["Link"];

        //    FtpWebRequest request;
        //    try
        //    {
        //        //string folderName;
        //        //string fileName;
        //        string absoluteFileName = Path.GetFileName(fileName);

        //        //request = WebRequest.Create(new Uri(string.Format(@"ftp://{0}/{1}", Link, absoluteFileName))) as FtpWebRequest;
        //        request = WebRequest.Create(new Uri(Link)) as FtpWebRequest;
        //        request.Method = WebRequestMethods.Ftp.UploadFile;
        //        request.UseBinary = true;
        //        request.UsePassive = true;
        //        request.KeepAlive = true;
        //        request.Credentials = new NetworkCredential(UserName, UserPassword);
        //        request.ConnectionGroupName = "group";

        //        // using (FileStream fs = System.IO.File.OpenRead(fileName))
        //        using (FileStream fs = File.OpenRead(File_Path))
        //        {
        //            byte[] buffer = new byte[fs.Length];
        //            fs.Read(buffer, 0, buffer.Length);
        //            fs.Close();
        //            Stream requestStream = request.GetRequestStream();
        //            requestStream.Write(buffer, 0, buffer.Length);
        //            requestStream.Flush();
        //            requestStream.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public void UploadFtpFile(string fileName, string F_Path)
        //{
        //    string UserName = System.Configuration.ConfigurationManager.AppSettings["LinK_UserName"];
        //    string UserPassword = System.Configuration.ConfigurationManager.AppSettings["Link_UserPassword"];
        //    string Link = System.Configuration.ConfigurationManager.AppSettings["Link"];

        //    WebClient client = new WebClient();
        //    //NetworkCredential nc = new NetworkCredential("adms.dotnet2", "Clover@1234");
        //    //Uri addy = new Uri(@"\\192.168.7.199\" + fileName);
        //    NetworkCredential nc = new NetworkCredential(UserName, UserPassword);
        //    Uri addy = new Uri(Link + fileName);
        //    client.Credentials = nc;
        //    byte[] arrReturn = client.UploadFile(addy, F_Path);
        //}


        public void DisablePageControls(bool status)
        {
            foreach (Control c in Page.Controls)
            {
                foreach (Control ctrl in c.Controls)
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


                }
            }
            foreach (GridViewRow row in gvExercise.Rows)
            {
                TextBox name = row.FindControl("txtOptionsExercised") as TextBox;
                name.Enabled = status;
            }
            //ddlChequeBankName.Enabled = status;
            btnimport.Enabled = status;
            //Common.ShowJavascriptAlert("sale transaction is pending with the Admin");
        }

        #region Bank Details and DMAT Details Added on 16-12-2021 by Rahul_Natu

        protected void save_bankdetail_Click(object sender, EventArgs e)
        {
            try
            {
                //if (IsPageRefresh)
                //{
                //    return;
                //}

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
                        //btnmsg2.Visible = true;
                    }
                }
                clearcontrol();
                if (lblmsg1.Text == "Please submit Bank details for login Employee"
                    || lblmsg2.Text == "Please submit Demat details for login Employee"
                    || lblmsg3.Text == "Exercise window is closed or not been created by admin")
                {
                    DisablePageControls(false);
                }
                else
                {
                    DisablePageControls(true);
                }
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

        //protected void grdbankdetail_PreRender(object sender, EventArgs e)
        //{
        //    // objbo.ECODE = Convert.ToString(Session["ECode"]);
        //    DataTable ds = (DataTable)ViewState["Emp_filterRec"];
        //    if (ds == null) { }
        //    else
        //    {
        //        if (ds.Rows.Count > 0)
        //        {

        //            grdbankdetail.UseAccessibleHeader = true;
        //            grdbankdetail.HeaderRow.TableSection = TableRowSection.TableHeader;
        //        }
        //    }
        //}

        protected void savedmatdetail_Click(object sender, EventArgs e)
        {
            try
            {
                //if (IsPageRefresh)
                //{
                //    return;
                //}

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
                if (lblmsg1.Text == "Please submit Bank details for login Employee"
                    || lblmsg2.Text == "Please submit Demat details for login Employee"
                    || lblmsg3.Text == "Exercise window is closed or not been created by admin")
                {
                    DisablePageControls(false);
                }
                else
                {
                    DisablePageControls(true);
                }
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

        //protected void grdempdmatdetail_PreRender(object sender, EventArgs e)
        //{
        //    DataTable ds = (DataTable)ViewState["Emp_filterRec1"];
        //    if (ds == null) { }
        //    else
        //    {
        //        if (ds.Rows.Count > 0)
        //        {
        //            grdempdmatdetail.UseAccessibleHeader = true;
        //            grdempdmatdetail.HeaderRow.TableSection = TableRowSection.TableHeader;
        //        }
        //    }
        //}

        protected void lnkDownload1_Click(object sender, EventArgs e)
        {
            string filename = (sender as LinkButton).CommandArgument;
            string filePath = Server.MapPath(filename);
            if (File.Exists(filePath) && Path.HasExtension(filePath))
            {
                ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
                ViewState["filepath"] = filename.Replace("~/", "");
            }
            else
            {
                Common.ShowJavascriptAlert("File is not exist.");
            }
        }

        protected void DownloadFile_Click(object sender, EventArgs e)
        {
            //var  filePath = Request.Form["__EVENTARGUMENT"];
            string filePath = ViewState["filepath"].ToString();
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        #endregion



        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DataSet ds_1 = new DataSet();
            //    string id = Convert.ToString(Session["ECODE"]);
            //    ds_1 = objBAL.GET_Employee_Admin_Main_Data_4(id);
            //    if (ds_1.Tables[0].Rows.Count > 0)
            //    { 

            //            showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
            //            msg = "Exercise is pending for approval by Admin";
            //            lblmsg4.Text = msg;
            //            lblmsg4.Visible = true;
            //            DisablePageControls(false);

            //    }
            //    else
            //    { 
            //        //objBAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_1(objBO);
            //        btnSubmit_Click(this, new EventArgs());
            //    }

            //}
            //catch (Exception ex)
            //{

            //}

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
                    DisablePageControls(false);

                }
                else
                {
                    //objBAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_1(objBO);
                    btnSubmit_Click(this, new EventArgs());
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }
    }
}