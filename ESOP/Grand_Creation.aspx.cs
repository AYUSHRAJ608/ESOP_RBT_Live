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
using System.Data.SqlClient;
using System.IO;
using ExcelDataReader;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using iTextSharp.text.pdf;
using DocumentFormat.OpenXml.Packaging;
//using Microsoft.Office.Interop.Word;

namespace ESOP
{
    public partial class Grand_Creation : System.Web.UI.Page
    {
        public int SuccRecords = 0;
        public int FailRecords = 0;
        public int TotalRecords = 0;
        string strCSV = System.Configuration.ConfigurationManager.AppSettings["CSV"];
        string ctlCOnn = System.Configuration.ConfigurationManager.AppSettings["ctl"];
        GrandCreationBO objbo = new GrandCreationBO();
        GrandCreationBAL objbal = new GrandCreationBAL();
        FMVCreationBO objfmvbo = new FMVCreationBO();
        FMVCreationBAL objfmvbal = new FMVCreationBAL();
        vesting_creation_BO VestingBO;
        vesting_creation_BAL VestingBAL = new vesting_creation_BAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        cEmailEntityRequest emailreq = new cEmailEntityRequest();
        string rdb = "";
        protected string inputtypeBulk;
        protected string inputtypeSingle;
        bool IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            buttonChk();
            showmsg.InnerHtml = "";
            txtvaldate.Attributes.Add("readonly", "readonly");
            txtvalidupto.Attributes.Add("readonly", "readonly");
            txtDateOfGrant.Attributes.Add("readonly", "readonly");
            btnSaveGrant.Attributes.Add("onclick", "return validate()");


            if (!string.IsNullOrEmpty(Session["TotalRecords"] as string))
            {
                TotalRecords = Convert.ToInt32(Session["TotalRecords"].ToString());
                SuccRecords = Convert.ToInt32(Session["SuccRecords"].ToString());
                FailRecords = Convert.ToInt32(Session["FailRecords"].ToString());
            }
            if (rdb == "single")
            {

            }

            if (!IsPostBack)
            {
                BtnRetunt.Visible = false;
                tablediv.Visible = false;
                tablediv_1.Visible = false;
                btnPendingGrant.Visible = false;

                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();

                this.inputtypeBulk = "checked";

                //txtDateOfGrant.Text = DateTime.Now.ToString("dd-MM-yyyy");

                ////txtDateOfGrant.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
                MaxValue();
                GetDropDown();
                bindvaluationddl();
                GetVestingDuration1();
                GET_VESTING_MASTER_ID();
                //DataSet ds = objbal.Emptydumptable();


                objbo.RecStatus = "BULK";
                DataSet dss = objbal.GET_FILEPATH(objbo);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    btnPendingGrant.Visible = true;
                    grdData.DataSource = dss.Tables[0];
                    grdData.DataBind();
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
        }
        private void bindvaluationddl()
        {
            try
            {
                System.Data.DataTable ds = objfmvbal.getvaluedbyddl(objfmvbo);
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
                    ddlvaluedby.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }
        protected void MaxValue()
        {
            DataSet ds = objbal.GetMaxValue();
            System.Data.DataTable dt = ds.Tables[0];
            txtGrantName.Text = "TRANCH" + dt.Rows[0][0].ToString();
            ViewState["TranchName"] = txtGrantName.Text;
        }
        protected void GetDropDown()
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

                    //ddlVesting.DataSource = ds.Tables[0];

                    //if (ds.Tables.Count > 0)
                    //{
                    //    ddlVesting.DataTextField = "VNAME";
                    //    ddlVesting.DataValueField = "VID";
                    //    ddlVesting.DataBind();
                    //    ddlVesting.Items.Insert(0, new ListItem("Select Vesting Cycle", "0"));
                    //}
                    ddlVesting.Items.Clear();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ListItem item = new ListItem();
                        item.Text = row["VNAME"].ToString();
                        item.Value = row["VID"].ToString();
                        if (row["ACTION"].ToString() == "BASE")
                        {
                            item.Attributes.Add("class", "optiongroup1");
                        }
                        else
                        {
                            item.Attributes.Add("class", "optionchild1");
                            item.Attributes.Add("disabled", "disabled");
                        }
                        ddlVesting.Items.Add(item);
                    }
                    ddlVesting.Items.Insert(0, new ListItem("Select Vesting", "0"));
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "padLeft()", true);
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
            // GetDropDown_FMV();
        }
        protected void btnSaveGrant_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPageRefresh)
                {
                    return;
                }

                if ((txtGrantName.Text).Substring(0, 6) == "TRANCH")
                {
                    if (ViewState["TranchName"].ToString() != txtGrantName.Text)
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = txtGrantName.Text + " is invalid Grant Name. Please create " + ViewState["TranchName"].ToString() + " Grant Name";
                        return;
                    }
                }
                else
                {
                    //to check the previous Grant Name
                    objbo.GRANT_NAME = txtGrantName.Text;
                    DataSet dss = objbal.Emptydumptable(objbo);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "This Grant Name is already exists";
                        return;
                    }
                }
                rdb = "";
                if (Request.Form["customRadioInline3"] != null)
                {
                    rdb = Request.Form["customRadioInline3"].ToString();
                }

                bool result = true;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                DataSet DsLetter = new DataSet();
                DsLetter = objbal.GetActiveLetter();
                if (DsLetter != null && DsLetter.Tables[0].Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Atleast one Grant letter should be active!!');", true);
                    return;
                }

                if (rdb == "bulk")
                {
                    showmsg.InnerText = "";
                    string fileName = Path.GetFileName(uploadfile.FileName).ToLower();
                    string extension = Path.GetExtension(uploadfile.FileName).ToLower();
                    if (uploadfile.HasFile)
                    {
                        if (Path.GetExtension(fileName).Contains(".xls") || Path.GetExtension(fileName).Contains(".xslx"))
                        {
                            string fileuploadpath = Path.GetFullPath(uploadfile.PostedFile.FileName);
                            if (!string.IsNullOrEmpty(fileuploadpath))
                            {
                                ReadExcel();
                            }
                        }
                        else
                        {
                            Common.ShowJavascriptAlert("File type should be in .xls,.xslx format");
                        }
                    }
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Please select file');", true);

                    //}
                }
                else if (rdb == "single")
                {
                    showmsg.InnerText = "";
                    {
                        try
                        {
                            objbo.GRANT_NAME = txtGrantName.Text;// txtGrantName.Text;
                                                                 //objbo.DATE_OF_GRANT =Convert.ToDateTime(txtDateOfGrant.Text);

                            objbo.DATE_OF_GRANT = Convert.ToDateTime(txtDateOfGrant.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat); //Convert.ToDateTime(txtDateOfGrant.Text);
                            objbo.EMP_ID = txtEmpID.Text;
                            objbo.FMV_ID = Convert.ToInt32(ddlFMV.SelectedValue);
                            objbo.VESTING_ID = Convert.ToInt32(ddlVesting.SelectedValue);
                            objbo.NO_OF_OPTION = Convert.ToInt32(txtNoOfOption.Text);
                            objbo.CREATED_DATE = DateTime.Now.ToShortDateString();
                            objbo.UPDATED_DATE = DateTime.Now.ToShortDateString();
                            objbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                            objbo.LAPSE_MONTH = Convert.ToString(txtLapsMonth.Text);
                            objbo.TAX_REGIME = Convert.ToString(ddlTaxRegime.SelectedValue);                            //Added by Krutika on 09-01-23
                            objbo.UPDATED_BY = "";
                            objbo.IS_VISIBLE = "true";

                            objbo.REMARK1 = "";
                            objbo.REMARK2 = "";

                            DataSet ds = new DataSet();
                            ds = objbal.Insert_GrandCreation(objbo);
                            System.Data.DataTable dt = ds.Tables[0];
                            if (ds.Tables[0].Rows.Count == 0)
                            {
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('This Employee does not exist');", true);
                                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                                showmsg.InnerText = "This Employee is not active or does not exist";
                            }
                            else
                            {
                                string status1 = "Approved";
                                string Attachment = Server.MapPath(@"/Fmv_excel/Employee.xlsx");
                                DataSet ds1 = OEMailBAL.GetEMPDetails(OEMailBO);
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    FuncReplaceWord(txtEmpID.Text, Convert.ToInt32(ds.Tables[1].Rows[0][1].ToString()), Convert.ToInt32(ds.Tables[1].Rows[0][2].ToString()));
                                    //objbo.RecStatus = "BULK";
                                    objbo.EMP_ID = txtEmpID.Text;
                                    objbo.GRANT_NAME = txtGrantName.Text;
                                    DataSet dss = objbal.GET_FILEPATH(objbo);
                                    grdData.DataSource = dss.Tables[0];
                                    grdData.DataBind();
                                    ViewState["Grddata"] = dss.Tables[0];
                                    tablediv_1.Visible = true;
                                    GrantCreation.Visible = false;

                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGrandModal();", true);
                                    SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds1.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant_Created", txtGrantName.Text, "", "", ddlFMV.SelectedItem.ToString(), "", "", "");
                                }

                                //showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                                //showmsg.InnerText = "Grant has been created & sent for HR Head approval.";
                                ////ClearInputs(Page.Controls);
                                ////MaxValue();
                                ////GetDropDown();
                                //Response.Redirect("grand_creation.aspx");
                            }

                            ////(Request.Form["customRadioInline3"]) = "single";
                            ////Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "single()", true);
                            ////ScriptManager.RegisterStartupScript(this,this.GetType(), "CallMyFunction", "single()", true);


                            //clearcontrol();
                        }
                        catch (Exception ex)
                        {
                            Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                            // throw ex;
                        }

                        //string status1 = "Approved";
                        //string Attachment = Server.MapPath(@"/Fmv_excel/Employee.xlsx");
                        //DataSet ds = OEMailBAL.GetEMPDetails(OEMailBO);
                        //if (ds.Tables[0].Rows.Count > 0)
                        //{
                        //    //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);

                        //    //commented for UAT
                        //    SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString());
                        //}

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Grant created successfully');", true);

                        //ClearInputs(Page.Controls);
                        //MaxValue();
                        //GetDropDown();
                        ////Response.Redirect("grand_creation.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        //protected void grdData_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //        {

        //            DataSet ds = VestingBAL.GET_ADMIN_EMP_STOCK_MAPPING_TRANCHWISE_DETAILS(VestingBO);
        //            ds.Tables[0].Columns.Add("LAPSE DATE");
        //            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        //            {
        //                TextBox LapseDate = (TextBox)e.Row.FindControl("TxtLaps");
        //                if (LapseDate.Text != "")
        //                {
        //                    DateTime myDate = Convert.ToDateTime(ds.Tables[0].Rows[j]["VESTING_DATE"]);
        //                    DateTime newDate = myDate.AddYears(Convert.ToInt32(LapseDate.Text)).Date;
        //                    newDate = newDate.Date;
        //                    ds.Tables[0].Rows[j]["LAPSE DATE"] = newDate.ToString("dd/MMM/yyyy");
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //        }
        //}
        public void ReadExcel()
        {
            string ext = Path.GetExtension(uploadfile.FileName).ToLower(); //  extension checked
            string FilePath = Server.MapPath("MyFolder");   // checked the file path 

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            String timeStamp = GetTimestamp(DateTime.Now);  // current date time added for the file name
            string path = FilePath + "/" + Path.GetFileNameWithoutExtension(uploadfile.FileName) + timeStamp + ext; // given file name as required
            uploadfile.SaveAs(path);

            System.Data.DataTable exceldata = GetData(path); // get data from the excel - redirected to the getData function
                                                             //exceldata.Columns.Add("CREATED_BY", typeof(string));
            System.Data.DataTable dtCloned = exceldata.Clone();

            bool a = InsertEmpMastRec(exceldata);

        }

        //public static String GetTimestamp(DateTime value)
        //{
        //    return value.ToString("yyyyMMddHHmmssffff");
        //}
        //public DataTable GetData(string path)
        //{
        //    DataSet result;
        //    DataTable dtData = new DataTable();
        //    using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read)) //checking the file validations if open & etc
        //    {
        //        using (var excelReader = ExcelReaderFactory.CreateReader(fileStream)) // read the file for the 1st style sheet
        //        {
        //            var dataSet = excelReader.AsDataSet(new ExcelDataSetConfiguration // data is fetch in DS
        //            {
        //                ConfigureDataTable = _ => new ExcelDataTableConfiguration
        //                {
        //                    UseHeaderRow = true // Use first row is ColumnName here :D
        //                }
        //            });
        //            if (dataSet.Tables.Count > 0)
        //            {
        //                dtData = dataSet.Tables[0];
        //            }
        //        }
        //    }
        //    return dtData;

        //}
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
        public System.Data.DataTable GetData(string path)
        {
            DataSet result;
            System.Data.DataTable dtData = new System.Data.DataTable();
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read)) //checking the file validations if open & etc
            {
                using (var excelReader = ExcelReaderFactory.CreateReader(fileStream)) // read the file for the 1st style sheet
                {
                    var dataSet = excelReader.AsDataSet(new ExcelDataSetConfiguration // data is fetch in DS
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // Use first row is ColumnName here :D
                        }
                    });
                    if (dataSet.Tables.Count > 0)
                    {
                        dtData = dataSet.Tables[0];
                    }
                }
            }
            return dtData;

        }
        public bool InsertEmpMastRec(System.Data.DataTable dt)
        {
            System.Data.DataTable dt_bulkTemp = new System.Data.DataTable();
            //dt_bulkTemp.Columns.Add("DEM_EU_ID");
            dt_bulkTemp.Columns.Add("DEM_EMP_ID");
            dt_bulkTemp.Columns.Add("DEM_GRANT_DATE");
            dt_bulkTemp.Columns.Add("DEM_VESTING_ID");
            dt_bulkTemp.Columns.Add("DEM_FMV_ID");
            dt_bulkTemp.Columns.Add("DEM_GRANT_NAME");
            dt_bulkTemp.Columns.Add("DEM_NO_OF_OPTION");
            dt_bulkTemp.Columns.Add("DEM_ErrorString");
            dt_bulkTemp.Columns.Add("DEM_RecStatus");
            dt_bulkTemp.Columns.Add("DEM_LAPSE_MONTH");                                                 //added field DEM_LAPSE_MONTH by Nagesh on 03/03/2022
            dt_bulkTemp.Columns.Add("DEM_APP_CODE");
            dt_bulkTemp.Columns.Add("DEM_TAX_REGIME");                                                  //Added by Krutika on 04-01-23

            #region comments
            ////////dt_bulkTemp.Columns.Add("DEM_EU_ID");
            ////////dt_bulkTemp.Columns.Add("DEM_ECODE");
            ////////dt_bulkTemp.Columns.Add("DEM_COMPANY_NAME");
            ////////dt_bulkTemp.Columns.Add("DEM_GENDER");
            ////////dt_bulkTemp.Columns.Add("DEM_EMP_STATUS");
            ////////dt_bulkTemp.Columns.Add("DEM_EMP_NAME");
            ////////dt_bulkTemp.Columns.Add("DEM_DESIGNATION");
            ////////dt_bulkTemp.Columns.Add("DEM_LOCATION");
            ////////dt_bulkTemp.Columns.Add("DEM_DEPARTMENT");
            ////////dt_bulkTemp.Columns.Add("DEM_APP_CODE");
            ////////dt_bulkTemp.Columns.Add("DEM_APPRAISER_NAME");
            ////////dt_bulkTemp.Columns.Add("DEM_DOJ");

            ////dt_bulkTemp.Columns.Add("DEM_GENDER");
            ////------------------------------------------------------------------------
            ////dt_bulkTemp.Columns.Add("DEM_EU_ID");
            ////dt_bulkTemp.Columns.Add("DEM_ECODE");
            ////dt_bulkTemp.Columns.Add("DEM_COMPANY_NAME");
            ////dt_bulkTemp.Columns.Add("DEM_GENDER");
            ////dt_bulkTemp.Columns.Add("DEM_EMP_STATUS");
            //dt_bulkTemp.Columns.Add("DEM_LWD");
            //dt_bulkTemp.Columns.Add("DEM_TNTR");
            ////dt_bulkTemp.Columns.Add("DEM_EMP_NAME");
            ////dt_bulkTemp.Columns.Add("DEM_DESIGNATION");
            //dt_bulkTemp.Columns.Add("DEM_BANDS");
            //dt_bulkTemp.Columns.Add("DEM_DOJ");
            //dt_bulkTemp.Columns.Add("DEM_LOCATION");
            //dt_bulkTemp.Columns.Add("DEM_DEPARTMENT");
            //dt_bulkTemp.Columns.Add("DEM_FUNCTION");
            //dt_bulkTemp.Columns.Add("DEM_COST_CENTRE");
            ////dt_bulkTemp.Columns.Add("DEM_APP_CODE");
            ////dt_bulkTemp.Columns.Add("DEM_APPRAISER_NAME");
            //dt_bulkTemp.Columns.Add("DEM_APP_BAND");
            //dt_bulkTemp.Columns.Add("DEM_REV_CODE");
            //dt_bulkTemp.Columns.Add("DEM_REVIEWER_NAME");
            //dt_bulkTemp.Columns.Add("DEM_REV_BAND");
            //dt_bulkTemp.Columns.Add("DEM_HOD_CODE");
            //dt_bulkTemp.Columns.Add("DEM_HOD_NAME");
            //dt_bulkTemp.Columns.Add("DEM_HOD_BAND");
            //dt_bulkTemp.Columns.Add("DEM_BH_CODE");
            //dt_bulkTemp.Columns.Add("DEM_BH_NAME");
            //dt_bulkTemp.Columns.Add("DEM_INTERNAL");
            //dt_bulkTemp.Columns.Add("DEM_EXTERNAL");
            //dt_bulkTemp.Columns.Add("DEM_TOTAL");
            ////dt_bulkTemp.Columns.Add("DEM_RecStatus");
            //dt_bulkTemp.Columns.Add("DEM_UploadBy");
            ////dt_bulkTemp.Columns.Add("DEM_ErrorString");
            //dt_bulkTemp.Columns.Add("DEM_NT_ID");
            //-----------------------------------------------------------------------------------
            #endregion

            SqlConnection con;
            //Boolean validate = true;
            string ErrorValidationMsg = "";
            bool status = false;
            string msg = "";
            bool ValError = true;
            string message = "";
            string errorMsg = "";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                TotalRecords = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataColumn col in dt.Columns)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if (dt.Rows.Count - 1 >= i)
                            {
                                //if (i == 0)
                                //{
                                //    objbo.CREATED_BY = Session["EmpId"].ToString(); // Convert.ToInt32(dt.Rows[i]["CREATED_BY"].ToString());
                                //}

                                //if (objbo.firstEntry == true)
                                //{
                                //    DataTable dt_getUGID = new DataTable();
                                //    dt_getUGID = objBal.fetchLastemuId(objbo);
                                //    objbo.EmpUpload_ID = dt_getUGID.Rows[0]["DEM_EU_ID"].ToString().Trim();
                                //    //objbo.EmpUpload_ID = 1;
                                //    Session["EMU_ID"] = objbo.EmpUpload_ID;
                                //    objbo.firstEntry = false;
                                //}

                                ///
                                //// CHECKING VALIDATION FOR EXCEL DATA    --->    START
                                ///

                                #region validation start

                                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                                var regexItem_varchar = new Regex("^[a-zA-Z]*$");
                                var regexItem_onlyNumeric = new Regex("^[0-9 ]*$");
                                var regexItem_decimal = new Regex("^[1-9]\\d*(\\.\\d{1,2})?$"); //("^[0-9 ]*$");
                                var regexDateDDMMYYYY = new Regex("^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[13-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$");
                                var regexItem_PAN = new Regex("[A-Z]{5}[0-9]{4}[A-Z]{1}");

                                if (dt.Rows[i]["Employee Code"].ToString().Trim() == "")
                                {
                                    message = " Please enter Employee Code.";
                                    ValError = false;
                                    objbo.EMP_ID = dt.Rows[i]["Employee Code"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Employee Code"].ToString().Trim()))
                                    {
                                        objbo.EMP_ID = dt.Rows[i]["Employee Code"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Employee Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Employee Code"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objbo.EMP_ID = dt.Rows[i]["Employee Code"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Employee Code.";
                                            ValError = false;
                                            objbo.EMP_ID = dt.Rows[i]["Employee Code"].ToString().Trim();
                                        }
                                    }
                                }

                                //------
                                if (dt.Rows[i]["No of Option"].ToString().Trim() == "")
                                {
                                    message = " Please enter No of Option.";
                                    ValError = false;
                                    objbo.No_Of_Option_Excel = (dt.Rows[i]["No of Option"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["No of Option"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["No of Option"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            objbo.No_Of_Option_Excel = dt.Rows[i]["No of Option"].ToString().Trim();
                                        }
                                        else
                                        {
                                            objbo.No_Of_Option_Excel = dt.Rows[i]["No of Option"].ToString().Trim();
                                        }
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["No of Option"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["No of Option"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["No of Option"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
                                        {
                                            if (dt.Rows[i]["No of Option"].ToString().Trim() == "0")
                                            {
                                                message = message + "Zero cant be added";
                                                ValError = false;
                                                objbo.No_Of_Option_Excel = dt.Rows[i]["No of Option"].ToString().Trim();
                                            }
                                            else
                                            {
                                                objbo.No_Of_Option_Excel = (dt.Rows[i]["No of Option"].ToString().Trim());
                                            }
                                        }
                                        else
                                        {
                                            message = message + " Only Numbers allowed for No of Option.";
                                            ValError = false;
                                            // objbo.NO_OF_OPTION = 0;
                                            objbo.No_Of_Option_Excel = dt.Rows[i]["No of Option"].ToString().Trim();

                                        }
                                    }
                                }

                                if (dt.Rows[i]["Pan Number"].ToString().Trim() == "")
                                {
                                    //message = " Please enter Pan Number.";
                                    //ValError = false;
                                    objbo.App_code = (dt.Rows[i]["Pan Number"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_PAN.IsMatch(dt.Rows[i]["Pan Number"].ToString().Trim()))
                                    {
                                        if (dt.Rows[i]["Pan Number"].ToString().Trim() == "0")
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            objbo.App_code = dt.Rows[i]["Pan Number"].ToString().Trim();
                                        }
                                        else
                                        {
                                            objbo.App_code = dt.Rows[i]["Pan Number"].ToString().Trim();
                                        }
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Pan Number"].ToString().Trim(), @"[A-Z]{5}[0-9]{4}[A-Z]{1}").Count > 0)
                                        {
                                            if (dt.Rows[i]["Pan Number"].ToString().Trim() == "0")
                                            {
                                                message = message + "Zero cant be added";
                                                ValError = false;
                                                objbo.App_code = dt.Rows[i]["Pan Number"].ToString().Trim();
                                            }
                                            else
                                            {
                                                objbo.App_code = (dt.Rows[i]["Pan Number"].ToString().Trim());
                                            }
                                        }
                                        else
                                        {
                                            message = message + " Invalid Pan Number.";
                                            ValError = false;
                                            objbo.App_code = (dt.Rows[i]["Pan Number"].ToString().Trim());
                                        }
                                    }
                                }

                                if (Regex.Matches(Convert.ToString(txtLapsMonth.Text).Trim(), @"^[0-9 ]*$").Count > 0)
                                {
                                    if (Convert.ToString(txtLapsMonth.Text).Trim() == "")
                                    {
                                        message = message + "Please enter Lapse Month.";
                                        ValError = false;
                                        objbo.LAPSE_MONTH = Convert.ToString(txtLapsMonth.Text).Trim();
                                    }
                                    else
                                    {
                                        objbo.LAPSE_MONTH = Convert.ToString(txtLapsMonth.Text).Trim();
                                    }
                                }
                                else
                                {
                                    message = message + " Invalid Lapse Month.";
                                    ValError = false;
                                    objbo.LAPSE_MONTH = Convert.ToString(txtLapsMonth.Text).Trim();
                                }

                                //Added by Krutika on 04-01-23
                                if (dt.Rows[i]["Tax Regime"].ToString().Trim() == "")
                                {
                                    message = " Please enter Tax Regime.";
                                    ValError = false;
                                    objbo.TAX_REGIME = (dt.Rows[i]["Tax Regime"].ToString().Trim());
                                }
                                else
                                {
                                    objbo.TAX_REGIME = (dt.Rows[i]["Tax Regime"].ToString().Trim());
                                }
                                //End

                                #region Comments
                                //------------------------------------------------------------------------------------

                                ////if (dt.Rows[i]["Company Name"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Company Name.";
                                ////    //ValError = false;
                                ////    objbo.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Company Name"].ToString().Trim()))
                                ////    {
                                ////        objbo.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Company Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Company Name"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Company Name.";
                                ////            ValError = false;
                                ////            objbo.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                //////if (dt.Rows[i]["Gender"].ToString().Trim() == "")
                                //////{
                                //////    //if (message != "")
                                //////    //{
                                //////    //    message = message + " ";
                                //////    //}
                                //////    //message = message + " Please Enter Gender.";
                                //////    //ValError = false;
                                //////    objbo.Gender = dt.Rows[i]["Gender"].ToString().Trim();
                                //////}
                                //////else
                                //////{
                                //////    if (regexItem.IsMatch(dt.Rows[i]["Gender"].ToString().Trim()))
                                //////    {
                                //////        objbo.Gender = dt.Rows[i]["Gender"].ToString().Trim();
                                //////    }
                                //////    else
                                //////    {
                                //////        if (Regex.Matches(dt.Rows[i]["Gender"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Gender"].ToString().Trim(), @"[0-9]").Count > 0)
                                //////        {
                                //////            objbo.Gender = dt.Rows[i]["Gender"].ToString().Trim();
                                //////        }
                                //////        else
                                //////        {
                                //////            message = message + " Only Special Characters are not allowed for Gender.";
                                //////            ValError = false;
                                //////            objbo.Gender = dt.Rows[i]["Gender"].ToString().Trim();
                                //////        }
                                //////    }
                                //////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Employee Status"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Employee Status.";
                                ////    //ValError = false;
                                ////    objbo.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Employee Status"].ToString().Trim()))
                                ////    {
                                ////        objbo.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Employee Status"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Employee Status"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Employee Status.";
                                ////            ValError = false;
                                ////            objbo.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //

                                ////if (dt.Rows[i]["LWD"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter LWD.";
                                ////    //ValError = false;
                                ////    objbo.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (Regex.Matches(dt.Rows[i]["LWD"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                ////    {
                                ////        message = message + " Invalid Date format for LWD.";
                                ////        ValError = false;
                                ////        objbo.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
                                ////    }
                                ////    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["LWD"].ToString().Trim()))
                                ////    {
                                ////        objbo.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        message = message + " Invalid Date format for Date of LWD.";
                                ////        ValError = false;
                                ////        objbo.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["TNTR"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter TNTR.";
                                ////    //ValError = false;
                                ////    objbo.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["TNTR"].ToString().Trim()))
                                ////    {
                                ////        objbo.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["TNTR"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["TNTR"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for TNTR.";
                                ////            ValError = false;
                                ////            objbo.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Employee Name"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Employee Name.";
                                ////    //ValError = false;
                                ////    objbo.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Employee Name"].ToString().Trim()))
                                ////    {
                                ////        objbo.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Employee Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Employee Name"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Employee Name.";
                                ////            ValError = false;
                                ////            objbo.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Designation"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Designation.";
                                ////    //ValError = false;
                                ////    objbo.Designation = dt.Rows[i]["Designation"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Designation"].ToString().Trim()))
                                ////    {
                                ////        objbo.Designation = dt.Rows[i]["Designation"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Designation"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Designation"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Designation = dt.Rows[i]["Designation"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Designation.";
                                ////            ValError = false;
                                ////            objbo.Designation = dt.Rows[i]["Designation"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Bands"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Bands.";
                                ////    //ValError = false;
                                ////    objbo.Bands = dt.Rows[i]["Bands"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Bands"].ToString().Trim()))
                                ////    {
                                ////        objbo.Bands = dt.Rows[i]["Bands"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Bands"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Bands"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Bands = dt.Rows[i]["Bands"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Bands.";
                                ////            ValError = false;
                                ////            objbo.Bands = dt.Rows[i]["Bands"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Date of Joining"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter a Date of Joining.";
                                ////    //ValError = false;
                                ////    objbo.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (Regex.Matches(dt.Rows[i]["Date of Joining"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                ////    {
                                ////        message = message + " Invalid Date format for Date of Joining.";
                                ////        ValError = false;
                                ////        objbo.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
                                ////    }
                                ////    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["Date of Joining"].ToString().Trim()))
                                ////    {
                                ////        objbo.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        message = message + " Invalid Date format for Date of Joining.";
                                ////        ValError = false;
                                ////        objbo.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Location"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Location.";
                                ////    //ValError = false;
                                ////    objbo.Location = dt.Rows[i]["Location"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Location"].ToString().Trim()))
                                ////    {
                                ////        objbo.Location = dt.Rows[i]["Location"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Location"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Location"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Location = dt.Rows[i]["Location"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Location.";
                                ////            ValError = false;
                                ////            objbo.Location = dt.Rows[i]["Location"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Department"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Department.";
                                ////    //ValError = false;
                                ////    objbo.Department = dt.Rows[i]["Department"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Department"].ToString().Trim()))
                                ////    {
                                ////        objbo.Department = dt.Rows[i]["Department"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Department"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Department"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Department = dt.Rows[i]["Department"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Department.";
                                ////            ValError = false;
                                ////            objbo.Department = dt.Rows[i]["Department"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Function"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Function.";
                                ////    //ValError = false;
                                ////    objbo.Function = dt.Rows[i]["Function"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Function"].ToString().Trim()))
                                ////    {
                                ////        objbo.Function = dt.Rows[i]["Function"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Function"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Function"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Function = dt.Rows[i]["Function"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Function.";
                                ////            ValError = false;
                                ////            objbo.Function = dt.Rows[i]["Function"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Cost Center"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Cost Center.";
                                ////    //ValError = false;
                                ////    objbo.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Cost Center"].ToString().Trim()))
                                ////    {
                                ////        objbo.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Cost Center"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Cost Center"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Cost Center.";
                                ////            ValError = false;
                                ////            objbo.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Appraiser Code"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Appraiser Code.";
                                ////    //ValError = false;
                                ////    objbo.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Appraiser Code"].ToString().Trim()))
                                ////    {
                                ////        objbo.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Appraiser Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Appraiser Code"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Appraiser Code.";
                                ////            ValError = false;
                                ////            objbo.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Appraiser Band"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Appraiser Band.";
                                ////    //ValError = false;
                                ////    objbo.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Appraiser Band"].ToString().Trim()))
                                ////    {
                                ////        objbo.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Appraiser Band"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Appraiser Band"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Appraiser Band.";
                                ////            ValError = false;
                                ////            objbo.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                ////if (dt.Rows[i]["Appraiser Name"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Appraiser Name.";
                                ////    //ValError = false;
                                ////    objbo.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Appraiser Name"].ToString().Trim()))
                                ////    {
                                ////        objbo.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Appraiser Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Appraiser Name"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Appraiser Name.";
                                ////            ValError = false;
                                ////            objbo.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//
                                //
                                ////if (dt.Rows[i]["Reviewer Code"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Reviewer Code.";
                                ////    //ValError = false;
                                ////    objbo.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Reviewer Code"].ToString().Trim()))
                                ////    {
                                ////        objbo.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Reviewer Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Reviewer Code"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Reviewer Code.";
                                ////            ValError = false;
                                ////            objbo.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Reviewer Name"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Reviewer Name.";
                                ////    //ValError = false;
                                ////    objbo.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Reviewer Name"].ToString().Trim()))
                                ////    {
                                ////        objbo.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Reviewer Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Reviewer Name"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Reviewer Name.";
                                ////            ValError = false;
                                ////            objbo.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["Reviewer Band"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Reviewer Band.";
                                ////    //ValError = false;
                                ////    objbo.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["Reviewer Band"].ToString().Trim()))
                                ////    {
                                ////        objbo.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["Reviewer Band"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Reviewer Band"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for Reviewer Band.";
                                ////            ValError = false;
                                ////            objbo.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["HOD Code"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter HOD Code.";
                                ////    //ValError = false;
                                ////    objbo.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["HOD Code"].ToString().Trim()))
                                ////    {
                                ////        objbo.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["HOD Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["HOD Code"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for HOD Code.";
                                ////            ValError = false;
                                ////            objbo.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["HOD Name"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter HOD Name.";
                                ////    //ValError = false;
                                ////    objbo.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["HOD Name"].ToString().Trim()))
                                ////    {
                                ////        objbo.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["HOD Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["HOD Name"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for HOD Name.";
                                ////            ValError = false;
                                ////            objbo.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["HOD Band"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter HOD Band.";
                                ////    //ValError = false;
                                ////    objbo.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["HOD Band"].ToString().Trim()))
                                ////    {
                                ////        objbo.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["HOD Band"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["HOD Band"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for HOD Band.";
                                ////            ValError = false;
                                ////            objbo.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["BHCode"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter BHCode.";
                                ////    //ValError = false;
                                ////    objbo.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["BHCode"].ToString().Trim()))
                                ////    {
                                ////        objbo.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["BHCode"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["BHCode"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for BHCode.";
                                ////            ValError = false;
                                ////            objbo.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //
                                ////if (dt.Rows[i]["BHName"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter BHName.";
                                ////    //ValError = false;
                                ////    objbo.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["BHName"].ToString().Trim()))
                                ////    {
                                ////        objbo.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["BHName"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["BHName"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for BHName.";
                                ////            ValError = false;
                                ////            objbo.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //=====//

                                //

                                ////if (dt.Rows[i]["Internal"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Internal value.";
                                ////    //ValError = false;
                                ////    objbo.Internal = dt.Rows[i]["Internal"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem_decimal.IsMatch(dt.Rows[i]["Internal"].ToString().Trim()))
                                ////    {
                                ////        objbo.Internal = dt.Rows[i]["Internal"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        message = message + " Only Numeric value allowed for Internal.";
                                ////        ValError = false;
                                ////        objbo.Internal = dt.Rows[i]["Internal"].ToString().Trim(); ;
                                ////    }
                                ////}

                                ////if (dt.Rows[i]["External"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter External value.";
                                ////    //ValError = false;
                                ////    objbo.External = dt.Rows[i]["External"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem_decimal.IsMatch(dt.Rows[i]["External"].ToString().Trim()))
                                ////    {
                                ////        objbo.External = dt.Rows[i]["External"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        message = message + " Only Numeric value allowed for External.";
                                ////        ValError = false;
                                ////        objbo.External = dt.Rows[i]["External"].ToString().Trim();
                                ////    }
                                ////}

                                ////if (dt.Rows[i]["Total"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter Total value.";
                                ////    //ValError = false;
                                ////    objbo.Total = dt.Rows[i]["Total"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem_decimal.IsMatch(dt.Rows[i]["Total"].ToString().Trim()))
                                ////    {
                                ////        objbo.Total = dt.Rows[i]["Total"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        message = message + " Only Numeric value allowed for Total.";
                                ////        ValError = false;
                                ////        objbo.Total = dt.Rows[i]["Total"].ToString().Trim();
                                ////    }
                                ////}


                                ////if (dt.Rows[i]["NT ID"].ToString().Trim() == "")
                                ////{
                                ////    //if (message != "")
                                ////    //{
                                ////    //    message = message + " ";
                                ////    //}
                                ////    //message = message + " Please Enter NT ID.";
                                ////    //ValError = false;
                                ////    objbo.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
                                ////}
                                ////else
                                ////{
                                ////    if (regexItem.IsMatch(dt.Rows[i]["NT ID"].ToString().Trim()))
                                ////    {
                                ////        objbo.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
                                ////    }
                                ////    else
                                ////    {
                                ////        if (Regex.Matches(dt.Rows[i]["NT ID"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["NT ID"].ToString().Trim(), @"[0-9]").Count > 0)
                                ////        {
                                ////            objbo.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
                                ////        }
                                ////        else
                                ////        {
                                ////            message = message + " Only Special Characters are not allowed for NT ID.";
                                ////            ValError = false;
                                ////            objbo.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
                                ////        }
                                ////    }
                                ////}
                                //-----------------------------------------------------------------------

                                #endregion

                                if (ValError == false)
                                {
                                    objbo.ErrorString = sb.Append(message).ToString().Trim();
                                    objbo.RecStatus = "Failed";
                                    FailRecords = FailRecords + 1;
                                    //throw new Exception();
                                }
                                else
                                {
                                    objbo.ErrorString = "N.A.";
                                    objbo.RecStatus = "Success";
                                    SuccRecords = SuccRecords + 1;
                                }
                                //
                                ///
                                //// CHECKING VALIDATION FOR EXCEL DATA    --->    END
                                ///
                                #endregion validation end

                                DataRow dr = dt_bulkTemp.NewRow();

                                #region Comments
                                //--------------------------------------------------------------------//-------------------------------------------------------------------------
                                ////dr["DEM_EU_ID"] = objbo.EmpUpload_ID;
                                ////dr["DEM_ECODE"] = objbo.Ecode;
                                ////dr["DEM_COMPANY_NAME"] = objbo.Company_name;
                                ////dr["DEM_GENDER"] = objbo.Gender;
                                ////dr["DEM_EMP_STATUS"] = objbo.Emp_status;
                                ////dr["DEM_LWD"] = objbo.Lwd;
                                ////dr["DEM_TNTR"] = objbo.Tntr;
                                ////dr["DEM_EMP_NAME"] = objbo.Emp_name;
                                ////dr["DEM_DESIGNATION"] = objbo.Designation;
                                ////dr["DEM_BANDS"] = objbo.Bands;
                                ////dr["DEM_DOJ"] = objbo.Doj;
                                ////dr["DEM_LOCATION"] = objbo.Location;
                                ////dr["DEM_DEPARTMENT"] = objbo.Department;
                                ////dr["DEM_FUNCTION"] = objbo.Function;
                                ////dr["DEM_COST_CENTRE"] = objbo.Cost_centre;
                                ////dr["DEM_APP_CODE"] = objbo.App_code;
                                ////dr["DEM_APPRAISER_NAME"] = objbo.Appraiser_name;
                                ////dr["DEM_APP_BAND"] = objbo.App_band;
                                ////dr["DEM_REV_CODE"] = objbo.Rev_code;
                                ////dr["DEM_REVIEWER_NAME"] = objbo.Reviewer_name;
                                ////dr["DEM_REV_BAND"] = objbo.Rev_band;
                                ////dr["DEM_HOD_CODE"] = objbo.Hod_code;
                                ////dr["DEM_HOD_NAME"] = objbo.Hod_name;
                                ////dr["DEM_HOD_BAND"] = objbo.Hod_band;
                                ////dr["DEM_BH_CODE"] = objbo.Bh_code;
                                ////dr["DEM_BH_NAME"] = objbo.Bh_name;
                                ////dr["DEM_INTERNAL"] = objbo.Internal;
                                ////dr["DEM_EXTERNAL"] = objbo.External;
                                ////dr["DEM_TOTAL"] = objbo.Total;
                                //////dr["DEM_RecStatus"] = objbo.RecStatus;
                                ////dr["DEM_UploadBy"] = objbo.CreatedBy;
                                //////dr["DEM_ErrorString"] = objbo.ErrorString;
                                ////dr["DEM_NT_ID"] = objbo.Nt_ID;

                                //////--------------------------------------------------------------------------
                                ////dr["DEM_EMP_ID"] = objbo.EMP_ID;
                                ////dr["DEM_GRANT_NAME"] = txtGrantName.Text;
                                ////dr["DEM_GRANT_DATE"] = txtDateOfGrant.Text;
                                ////dr["DEM_VESTING_ID"] = ddlVesting.SelectedIndex;
                                ////dr["DEM_FMV_ID"] = ddlFMV.SelectedIndex;
                                ////dr["DEM_NO_OF_OPTION"] = objbo.NO_OF_OPTION;
                                ////dr["DEM_RecStatus"] = objbo.RecStatus;
                                ////dr["DEM_ErrorString"] = objbo.ErrorString;
                                //-------------------------------------------------------------------------//-------------------------------------------------------------------------



                                ////////dr["DEM_EMP_ID"] = objbo.EMP_ID;
                                ////////dr["DEM_GRANT_DATE"] = txtDateOfGrant.Text;
                                ////////dr["DEM_VESTING_ID"] = ddlVesting.SelectedValue;
                                ////////dr["DEM_FMV_ID"] = ddlFMV.SelectedValue;
                                ////////dr["DEM_GRANT_NAME"] = txtGrantName.Text;
                                ////////dr["DEM_NO_OF_OPTION"] = objbo.NO_OF_OPTION;
                                ////////dr["DEM_ErrorString"] = objbo.ErrorString;
                                ////////dr["DEM_RecStatus"] = objbo.RecStatus;
                                ////////dr["DEM_EU_ID"] = objbo.EmpUpload_ID;
                                ////////dr["DEM_ECODE"] = objbo.Ecode;
                                ////////dr["DEM_COMPANY_NAME"] = objbo.Company_name;

                                ////////dr["DEM_GENDER"] = objbo.Gender;
                                ////////dr["DEM_EMP_STATUS"] = objbo.Emp_status;
                                ////////dr["DEM_EMP_NAME"] = objbo.Emp_name;
                                ////////dr["DEM_DESIGNATION"] = objbo.Designation;
                                ////////dr["DEM_LOCATION"] = objbo.Location;
                                ////////dr["DEM_DEPARTMENT"] = objbo.Department;
                                ////////dr["DEM_APP_CODE"] = objbo.App_code;
                                ////////dr["DEM_APPRAISER_NAME"] = objbo.Appraiser_name;
                                ////////dr["DEM_DOJ"] = objbo.Doj;
                                #endregion

                                dr["DEM_EMP_ID"] = objbo.EMP_ID;
                                //dr["DEM_NO_OF_OPTION"] = objbo.NO_OF_OPTION;

                                dr["DEM_GRANT_NAME"] = txtGrantName.Text;
                                dr["DEM_GRANT_DATE"] = txtDateOfGrant.Text; //Convert.ToDateTime(txtDateOfGrant.Text);
                                dr["DEM_VESTING_ID"] = ddlVesting.SelectedValue;
                                dr["DEM_FMV_ID"] = ddlFMV.SelectedValue;
                                dr["DEM_NO_OF_OPTION"] = objbo.No_Of_Option_Excel;
                                dr["DEM_RecStatus"] = objbo.RecStatus;
                                dr["DEM_ErrorString"] = objbo.ErrorString;

                                dr["DEM_LAPSE_MONTH"] = objbo.LAPSE_MONTH;                          //added field DEM_LAPSE_MONTH by Nagesh on 03/03/2022
                                dr["DEM_APP_CODE"] = objbo.App_code;
                                dr["DEM_TAX_REGIME"] = objbo.TAX_REGIME == "New" ? "N" : "O";                            //Added by Krutika on 04-01-23

                                //--------------------------------------------------------------

                                dt_bulkTemp.Rows.Add(dr);

                                ValError = true;
                                message = "";
                                sb.Clear();
                                i = i + 1;
                            }
                        }
                    }
                }

                //SuccRecords = TotalRecords - FailRecords;


                dt_bulkTemp.ToCSV(strCSV);

                ctlupload("abc1", "MyFolder/");

                #region Comments
                ////try
                ////{
                ////    DataTable dt_getCount = new DataTable();
                ////    objbo.EMP_ID = Session["EMU_ID"].ToString();
                ////    dt_getCount = objBal.getRecCount(objbo);
                ////    SuccessCountEx = Convert.ToInt32(dt_getCount.Rows[0]["SuccessCount"].ToString());

                ////    DataTable dt_getCountFail = new DataTable();
                ////    objbo.EMP_ID = Session["EMU_ID"].ToString();
                ////    dt_getCountFail = objBal.getRecCount_Fail(objbo);
                ////    if (dt_getCountFail.Rows[0]["FailedCount"] == null || dt_getCountFail.Rows[0]["FailedCount"].ToString() == "0")
                ////    {
                ////        //lblFailedTitle.Text = "";
                ////        //lblFailedCount.Text = "";
                ////        ////Div_FailRec.Visible = false;
                ////        //btnExDown.Visible = false;
                ////        /// btnCSVDown.Visible = false;
                ////    }
                ////    else
                ////    {
                ////        lblFailedTitle.Text = "Failed:- ";
                ////        lblFailedCount.Text = dt_getCountFail.Rows[0]["FailedCount"].ToString().Trim() + " record(s) have been entered in wrong format, kindly check!";
                ////        btnExDown.Visible = true;
                ////        Div_FailRec.Visible = true;
                ////        // btnCSVDown.Visible = true;
                ////    }

                ////    if (SuccessCountEx > 0)
                ////    {
                ////        DataTable dt_addSuccessRec = new DataTable();
                ////        objbo.EMP_ID = Session["EMU_ID"].ToString();
                ////        dt_addSuccessRec = objBal.addSuccessData(objbo);
                ////        SuccessCountMain = Convert.ToInt32(dt_addSuccessRec.Rows[0]["SuccessCountMain"].ToString());
                ////        if (SuccessCountMain == 0)
                ////        {
                ////            lblSuccessTitle.Text = "Success:-";
                ////            lblSuccessCount.Text = "No Record(s) found in correct format.";
                ////        }
                ////        else
                ////        {
                ////            lblSuccessTitle.Text = "Success:-";
                ////            lblSuccessCount.Text = SuccessCountMain.ToString() + " record(s) have been entered successfully.";
                ////        }
                ////        if (overwriteFlag == true)
                ////        {
                ////            lblSuccessTitle.Text = "Success:-";
                ////            lblSuccessCount.Text = SuccessCountMain.ToString() + " record(s) have been updated successfully.";
                ////            DataTable dt_OverwriteGURec = new DataTable();
                ////            objbo.EmpUpload_ID = Session["EMU_ID"].ToString();
                ////            objbo.CREATED_BY = Convert.ToInt32(Session["EmpId"].ToString());
                ////            dt_OverwriteGURec = objBal.updateOverwriteRec(objbo);
                ////            objbo.EmpUpload_ID = dt_OverwriteGURec.Rows[0]["updatedCount"].ToString().Trim();
                ////        }
                ////    }
                ////    else
                ////    {
                ////        lblSuccessTitle.Text = "Success:-";
                ////        lblSuccessCount.Text = "No Record found in correct format.";
                ////    }


                ////}
                ////catch (Exception ex)
                ////{
                ////    throw ex;
                ////}
                //  tablediv.Visible = true;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Excel Uploaded Successfully.');", true);
                //Response.Write("<script language='javascript'>window.alert('" + SuccessCountMain + " Record Uploaded Successfully. Failed to Upload " + lblFailedCount.Text + " Record.');window.location='HRMSUpload.aspx';</script>");
                #endregion
            }
            catch (Exception ex)
            {
                string exmsg = ex.Message.ToString();
                if (exmsg.Contains(" does not belong to table"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myalert", "alert('Please check the columns name in Excel');", true);
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalertVal", "alert('Record cannot be Approved." + exmsg.ToString() + "');", true);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", exmsg, true);
                }
                else
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                }
                //throw ex;

            }
            finally
            {
                objbo = null;
            }
            return status;
        }
        public void ctlupload(string fileNameWithoutExt, string FolderPath)
        {
            string CtlFileName = null;
            try
            {
                string FlnameWithoutExtension;
                FlnameWithoutExtension = fileNameWithoutExt.Replace(" ", "_");
                string tempname = FlnameWithoutExtension.Replace(" ", "_");

                string filelocation = Server.MapPath(FolderPath);
                CtlFileName = filelocation + FlnameWithoutExtension.Trim().ToString() + ".ctl";
                string FileWithExtension = filelocation + FlnameWithoutExtension.Trim().ToString() + ".csv";
                System.IO.StreamWriter writer = File.CreateText(CtlFileName);

                #region Comments
                //  string templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE DEMO fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(EMPLOYEECODE \"trim(:EMPLOYEECODE)\",OBJECTIVE \"trim(:OBJECTIVE)\",MEASURE \"trim(:MEASURE)\",TARGETTYPE \"trim(:TARGETTYPE)\",TARGET \"trim(:TARGET)\",TARGETWEIGHT \"trim(:TARGETWEIGHT)\")";

                //-----------------------------------------------------------
                //Working one         //string templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_tbl_dump_table fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(DEM_EMP_ID \"trim(:DEM_EMP_ID)\",DEM_GRANT_DATE \"trim(:DEM_GRANT_DATE)\",DEM_VESTING_ID \"trim(:DEM_VESTING_ID)\",DEM_FMV_ID \"trim(:DEM_FMV_ID)\", DEM_GRANT_NAME \"trim(:DEM_GRANT_NAME)\",DEM_NO_OF_OPTION \"trim(:DEM_NO_OF_OPTION)\",DEM_EU_ID \"trim(:DEM_EU_ID)\",DEM_ECODE \"trim(:DEM_ECODE)\",DEM_COMPANY_NAME \"trim(:DEM_COMPANY_NAME)\", DEM_GENDER \"trim(:DEM_GENDER)\",DEM_EMP_STATUS \"trim(:DEM_EMP_STATUS)\",DEM_LWD \"trim(:DEM_LWD)\",DEM_TNTR \"trim(:DEM_TNTR)\",DEM_EMP_NAME \"trim(:DEM_EMP_NAME)\",DEM_DESIGNATION \"trim(:DEM_DESIGNATION)\",DEM_BANDS \"trim(:DEM_BANDS)\",DEM_DOJ \"trim(:DEM_DOJ)\",DEM_LOCATION \"trim(:DEM_LOCATION)\",DEM_DEPARTMENT \"trim(:DEM_DEPARTMENT)\",DEM_FUNCTION \"trim(:DEM_FUNCTION)\",DEM_COST_CENTRE \"trim(:DEM_COST_CENTRE)\",DEM_APP_CODE \"trim(:DEM_APP_CODE)\",DEM_APPRAISER_NAME \"trim(:DEM_APPRAISER_NAME)\",DEM_APP_BAND \"trim(:DEM_APP_BAND)\",DEM_REV_CODE \"trim(:DEM_REV_CODE)\",DEM_REVIEWER_NAME \"trim(:DEM_REVIEWER_NAME)\",DEM_REV_BAND \"trim(:DEM_REV_BAND)\",DEM_HOD_CODE \"trim(:DEM_HOD_CODE)\",DEM_HOD_NAME \"trim(:DEM_HOD_NAME)\",DEM_HOD_BAND \"trim(:DEM_HOD_BAND)\",DEM_BH_CODE \"trim(:DEM_BH_CODE)\",DEM_BH_NAME \"trim(:DEM_BH_NAME)\",DEM_INTERNAL \"trim(:DEM_INTERNAL)\",DEM_EXTERNAL \"trim(:DEM_EXTERNAL)\",DEM_TOTAL \"trim(:DEM_TOTAL)\",DEM_RecStatus \"trim(:DEM_RecStatus)\",DEM_UploadBy \"trim(:DEM_UploadBy)\",DEM_NT_ID \"trim(:DEM_NT_ID)\")";

                //-------------------------------------------------------------------

                //string templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_tbl_dump_table fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(DEM_EMP_ID \"trim(:DEM_EMP_ID)\",DEM_GRANT_DATE \"trim(:DEM_GRANT_DATE)\",DEM_VESTING_ID \"trim(:DEM_VESTING_ID)\",DEM_FMV_ID \"trim(:DEM_FMV_ID)\", DEM_GRANT_NAME \"trim(:DEM_GRANT_NAME)\",DEM_NO_OF_OPTION \"trim(:DEM_NO_OF_OPTION)\",DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_RecStatus \"trim(:DEM_RecStatus)\")";
                //string templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_tbl_dump_table fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(DEM_EMP_ID \"trim(:DEM_EMP_ID)\",DEM_GRANT_DATE \"trim(:DEM_GRANT_DATE)\",DEM_VESTING_ID \"trim(:DEM_VESTING_ID)\",DEM_FMV_ID \"trim(:DEM_FMV_ID)\", DEM_GRANT_NAME \"trim(:DEM_GRANT_NAME)\",DEM_NO_OF_OPTION \"trim(:DEM_NO_OF_OPTION)\",DEM_EU_ID \"trim(:DEM_EU_ID)\",DEM_ECODE \"trim(:DEM_ECODE)\",DEM_COMPANY_NAME \"trim(:DEM_COMPANY_NAME)\", DEM_GENDER \"trim(:DEM_GENDER)\",DEM_EMP_STATUS \"trim(:DEM_EMP_STATUS)\",DEM_LWD \"trim(:DEM_LWD)\",DEM_TNTR \"trim(:DEM_TNTR)\",DEM_EMP_NAME \"trim(:DEM_EMP_NAME)\",DEM_DESIGNATION \"trim(:DEM_DESIGNATION)\",DEM_BANDS \"trim(:DEM_BANDS)\",DEM_DOJ \"trim(:DEM_DOJ)\",DEM_LOCATION \"trim(:DEM_LOCATION)\",DEM_DEPARTMENT \"trim(:DEM_DEPARTMENT)\",DEM_FUNCTION \"trim(:DEM_FUNCTION)\",DEM_COST_CENTRE \"trim(:DEM_COST_CENTRE)\",DEM_APP_CODE \"trim(:DEM_APP_CODE)\",DEM_APPRAISER_NAME \"trim(:DEM_APPRAISER_NAME)\",DEM_APP_BAND \"trim(:DEM_APP_BAND)\",DEM_REV_CODE \"trim(:DEM_REV_CODE)\",DEM_REVIEWER_NAME \"trim(:DEM_REVIEWER_NAME)\",DEM_REV_BAND \"trim(:DEM_REV_BAND)\",DEM_HOD_CODE \"trim(:DEM_HOD_CODE)\",DEM_HOD_NAME \"trim(:DEM_HOD_NAME)\",DEM_HOD_BAND \"trim(:DEM_HOD_BAND)\",DEM_BH_CODE \"trim(:DEM_BH_CODE)\",DEM_BH_NAME \"trim(:DEM_BH_NAME)\",DEM_INTERNAL \"trim(:DEM_INTERNAL)\",DEM_EXTERNAL \"trim(:DEM_EXTERNAL)\",DEM_TOTAL \"trim(:DEM_TOTAL)\",DEM_RecStatus \"trim(:DEM_RecStatus)\",DEM_UploadBy \"trim(:DEM_UploadBy)\",DEM_NT_ID \"trim(:DEM_NT_ID)\")";


                ////string templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_tbl_dump_table fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(DEM_EMP_ID \"trim(:DEM_EMP_ID)\",DEM_GRANT_DATE \"trim(:DEM_GRANT_DATE)\",DEM_VESTING_ID \"trim(:DEM_VESTING_ID)\",DEM_FMV_ID \"trim(:DEM_FMV_ID)\",DEM_GRANT_NAME \"trim(:DEM_GRANT_NAME)\",DEM_NO_OF_OPTION \"trim(:DEM_NO_OF_OPTION)\",DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_RecStatus \"trim(:DEM_RecStatus)\",DEM_EU_ID \"trim(:DEM_EU_ID)\",DEM_ECODE \"trim(:DEM_ECODE)\",DEM_COMPANY_NAME \"trim(:DEM_COMPANY_NAME)\",DEM_GENDER \"trim(:DEM_GENDER)\",DEM_EMP_STATUS\"trim(:DEM_EMP_STATUS)\",DEM_EMP_NAME \"trim(:DEM_EMP_NAME)\",DEM_DESIGNATION \"trim(:DEM_DESIGNATION)\",DEM_LOCATION \"trim(:DEM_LOCATION)\",DEM_DEPARTMENT \"trim(:DEM_DEPARTMENT)\",DEM_APP_CODE \"trim(:DEM_APP_CODE)\",DEM_APPRAISER_NAME \"trim(:DEM_APPRAISER_NAME)\",DEM_DOJ \"trim(:DEM_DOJ)\")";
                #endregion

                string templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_tbl_dump_table fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(DEM_EMP_ID \"trim(:DEM_EMP_ID)\",DEM_GRANT_DATE \"" +
                                  "trim(:DEM_GRANT_DATE)\",DEM_VESTING_ID \"trim(:DEM_VESTING_ID)\",DEM_FMV_ID \"trim(:DEM_FMV_ID)\",DEM_GRANT_NAME \"trim(:DEM_GRANT_NAME)\",DEM_NO_OF_OPTION \"trim(:DEM_NO_OF_OPTION)\",DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_RecStatus \"" +
                                  "trim(:DEM_RecStatus)\",DEM_LAPSE_MONTH \"trim(:DEM_LAPSE_MONTH)\",DEM_APP_CODE \"trim(:DEM_APP_CODE)\",DEM_TAX_REGIME \"trim(:DEM_TAX_REGIME)\")"; //,DEM_EU_ID \"trim(:DEM_EU_ID)\"
                                                                                                                                                                                      //added field DEM_LAPSE_MONTH by Nagesh on 03/03/2022
                                                                                                                                                                                      //DEM_TAX_REGIME added by Krutika on 04-01-23

                writer.WriteLine(templine);
                writer.Close();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw;
            }

            try
            {
                string output, Error;
                //System.Diagnostics.ProcessStartInfo p1 = new System.Diagnostics.ProcessStartInfo("Cmd.exe", "/c sqlldr \'pms/pms@(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST =192.168.7.199)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = HERGO_PMS)))\' Control=" + CtlFileName + "");
                System.Diagnostics.ProcessStartInfo p1 = new System.Diagnostics.ProcessStartInfo("Cmd.exe", "/c sqlldr \'" + ctlCOnn + "\' Control=" + CtlFileName + "");

                Process p2;
                p1.UseShellExecute = false;
                p1.RedirectStandardError = true; //string fullPath rc:\FoLDER,folder with spies,THER_FoLDER\tbie.e, 
                string al = Server.MapPath("cmd.exe");
                p1.FileName = System.IO.Path.GetFileName("cmd.exe");
                p1.WorkingDirectory = System.IO.Path.GetDirectoryName(Server.MapPath("cmd.exe"));

                p1.CreateNoWindow = true;
                p1.WindowStyle = ProcessWindowStyle.Hidden;
                p1.RedirectStandardOutput = true;

                p2 = System.Diagnostics.Process.Start(p1);

                output = p2.StandardOutput.ReadToEnd();
                Error = p2.StandardError.ReadToEnd();
                p2.WaitForExit();

                int exitcode = p2.ExitCode;
                if (exitcode == 0)
                {
                    objbo.GRANT_NAME = txtGrantName.Text;
                    objbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                    DataSet ds = objbal.Insert_Copy_EMP(objbo);
                    System.Data.DataTable dt = ds.Tables[0];
                    SuccRecords = dt.Select("dem_recstatus = 'Success'").Length;
                    FailRecords = TotalRecords - SuccRecords;// dt.Select("dem_recstatus = 'Failed'").Length;
                    Session["TotalRecords"] = Convert.ToString(TotalRecords);
                    Session["SuccRecords"] = SuccRecords;
                    Session["FailRecords"] = FailRecords;
                    string status1 = "Approved";
                    string Attachment = Server.MapPath(@"/Fmv_excel/Employee.xlsx");
                    DataSet ds1 = OEMailBAL.GetEMPDetails(OEMailBO);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            FuncReplaceWord(dt.Rows[i][0].ToString(), Convert.ToInt32(dt.Rows[i][1].ToString()), Convert.ToInt32(dt.Rows[i][2].ToString()));
                        }
                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds1.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant_Created", txtGrantName.Text, "", "", ddlFMV.SelectedItem.ToString(), "", "", "");
                        objbo.RecStatus = "BULK";
                        DataSet dss = objbal.GET_FILEPATH(objbo);
                        grdData.DataSource = dss.Tables[0];
                        grdData.DataBind();
                        ViewState["Grddata"] = dss.Tables[0];

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGrandModal();", true);
                    }
                    if (SuccRecords > 0)
                    {
                        //showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        //showmsg.InnerText = "Grant has been created & sent for HR head approval.";
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Grant has not been created, please check excel file');", true);
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Grant has not been created, please check excel file";
                    }

                    //ClearInputs(Page.Controls);
                    //MaxValue();

                    //GetDropDown();

                    tablediv.Visible = true;
                    tablediv_1.Visible = true;
                    GrantCreation.Visible = false;
                    // Common.ShowJavascriptAlert("File Successfully Upload..!");
                    //Code start and  added by Nagesh
                    ValuationBO objvbo = new ValuationBO();
                    ValuationBAL objvbal = new ValuationBAL();
                    if (Convert.ToString(txtLapsMonth.Text) != "")
                    {
                        objvbo.Month_of_Lapse = Convert.ToString(txtLapsMonth.Text).Trim();
                        objvbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                        objvbo.AGENCY_NAME = Convert.ToString(txtGrantName.Text).Trim();//ID;
                        //DataSet strmsg = objvbal.Insert_Yrs_Lapse(objvbo);
                    }
                    //Code end and added by Nagesh
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }

        }
        protected void LinkButton_Click(object sender, EventArgs e)
        {

            string filePath = Server.MapPath("~/ExcelFormat/Grant_ExcelFormat.xlsx");
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();

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
            txtv1.Text = "v1";
            txtv2.Text = "v2";
            txtv3.Text = "v3";
            txtv4.Text = "v4";
            txtv5.Text = "v5";
        }
        protected void ClearInputs1(ControlCollection ctrls)
        {
            ////////foreach (Control ctrl in ctrls)
            ////////{
            ////////    if (ctrl is TextBox)
            ////////        ((TextBox)ctrl).Text = string.Empty;
            ////////    else if (ctrl is DropDownList)
            ////////        ((DropDownList)ctrl).ClearSelection();

            ////////    ClearInputs(ctrl.Controls);
            ////////}
            foreach (Control ctrl in ctrls)
            {
                //if (ctrl is TextBox)
                //    ((TextBox)ctrl).Text = string.Empty;
                //else 
                if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();

                ClearInputs1(ctrl.Controls);
            }
            txtperc1.Text = string.Empty;
            txtperc2.Text = string.Empty;
            txtperc3.Text = string.Empty;
            txtperc4.Text = string.Empty;
            txtperc5.Text = string.Empty;
            txtVestingName.Text = string.Empty;
        }
        protected void downloadFailedRec(object sender, EventArgs e)
        {
            //show msg for fetching Failed Records of Excel name : tempdata and uploaded on : dateAndtime
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                //objEntity.EmpUpload_ID = Session["EMU_ID"].ToString();
                dt = objbal.getFailedData();
                //if (dt.Rows.Count==0)
                if (dt == null)
                {
                    Response.Write("<script language='javascript'>window.alert('No Failed records found.');</script>");
                }
                else
                {
                    ViewState["DataHistory"] = dt;
                    ExportToExcel(dt);
                }
                //tablediv.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>window.alert('No records found.');</script>");
            }
        }
        public void ExportToExcel(System.Data.DataTable dtHistory)
        {
            string filename = "Upload_FailedData_" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            DataGrid dgGrid = new DataGrid();
            //dt = (DataTable)ViewState["DataHistory"];
            dgGrid.DataSource = dtHistory;
            dgGrid.DataBind();

            dgGrid.RenderControl(hw);

            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();

            //Workbook workbook = new Workbook();
            //workbook.LoadFromFile(@"Test.xls");

            //Worksheet sheet = workbook.Worksheets[0];

            //sheet.SetRowHeight(1, 20);
            //sheet.SetColumnWidth(1, 23);

            //workbook.SaveToFile("Result.xls", ExcelVersion.Version97to2003);
        }
        protected void btncreatefmv_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.FileName != "")
                {
                    FileUpload1.SaveAs(System.IO.Path.Combine(Server.MapPath("Fmv_excel"), FileUpload1.FileName));
                }
                else { }
                objfmvbo.VALUATION_DATE = Convert.ToDateTime(txtvaldate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);//(txtvaldate.Text);

                objfmvbo.VALID_UPTO_DATE = Convert.ToDateTime(txtvalidupto.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);//(txtvalidupto.Text);
                objfmvbo.FMV_PRICE = (txtfmvprice.Text);
                objfmvbo.VALUED_BY = ddlvaluedby.SelectedValue.ToString();
                if (FileUpload1.FileName != "")
                {
                    objfmvbo.UPLOAD_FILE = "Fmv_excel/" + FileUpload1.FileName.ToString();
                }
                else { }
                objfmvbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                objfmvbo.UPDATED_BY = "";

                objfmvbo.btntext = "CREATE";
                string strmsg = objfmvbal.Insert_Fmv(objfmvbo);

                GetDropDown();
                txtfmvprice.Text = "";
                ddlvaluedby.SelectedIndex = -1;
                if (strmsg == "exi")
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV already exist'); ", true);

                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "FMV already exist";
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV added successfully'); ", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "FMV created successfully";
                }
                clearcontrol();
                GetDropDown_FMV();
                buttonChk();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;

            }
        }
        private void clearcontrol()
        {
            txtvaldate.Text = "";
            txtvalidupto.Text = "";
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
        }
        private void GetVestingDuration1()
        {
            VestingBO = new vesting_creation_BO();
            VestingBO.YEAR = Convert.ToInt32("0");
            ddlduration1.DataSource = GetVestingDuration(VestingBO);
            ddlduration1.DataTextField = "YEAR_DESC";
            ddlduration1.DataValueField = "YEAR";

            ddlduration1.DataBind();
            ddlduration1.Items.Insert(0, new ListItem("Select", "0"));
            ddlduration2.Items.Insert(0, new ListItem("Select", "0"));
            ddlduration3.Items.Insert(0, new ListItem("Select", "0"));
            ddlduration4.Items.Insert(0, new ListItem("Select", "0"));
            ddlduration5.Items.Insert(0, new ListItem("Select", "0"));
        }
        private int GET_VESTING_MASTER_ID()
        {
            DataSet ds;
            int vID = 0;
            try
            {
                VestingBO = new vesting_creation_BO();

                ds = VestingBAL.GET_VESTING_MASTER_ID();

                vID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
            return vID;
        }
        private DataSet GetVestingDuration(vesting_creation_BO VestingBO)
        {
            DataSet ds = null;
            try
            {
                //VestingBO = new vesting_creation_BO();
                ds = VestingBAL.GetVestingDuration(VestingBO);

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
            }
            return ds;
        }
        protected void ddlduration1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VestingBO = new vesting_creation_BO();
            VestingBO.YEAR = Convert.ToInt32(ddlduration1.SelectedValue);
            ddlduration2.DataSource = GetVestingDuration(VestingBO);
            ddlduration2.DataTextField = "YEAR_DESC";
            ddlduration2.DataValueField = "YEAR";

            ddlduration2.DataBind();
            ddlduration2.Items.Insert(0, new ListItem("Select", "0"));
        }
        protected void ddlduration2_SelectedIndexChanged(object sender, EventArgs e)
        {
            VestingBO = new vesting_creation_BO();
            VestingBO.YEAR = Convert.ToInt32(ddlduration2.SelectedValue);
            ddlduration3.DataSource = GetVestingDuration(VestingBO);
            ddlduration3.DataTextField = "YEAR_DESC";
            ddlduration3.DataValueField = "YEAR";

            ddlduration3.DataBind();
            ddlduration3.Items.Insert(0, new ListItem("Select", "0"));
        }
        protected void ddlduration3_SelectedIndexChanged(object sender, EventArgs e)
        {
            VestingBO = new vesting_creation_BO();
            VestingBO.YEAR = Convert.ToInt32(ddlduration3.SelectedValue);
            ddlduration4.DataSource = GetVestingDuration(VestingBO);
            ddlduration4.DataTextField = "YEAR_DESC";
            ddlduration4.DataValueField = "YEAR";

            ddlduration4.DataBind();
            ddlduration4.Items.Insert(0, new ListItem("Select", "0"));
        }
        protected void ddlduration4_SelectedIndexChanged(object sender, EventArgs e)
        {
            VestingBO = new vesting_creation_BO();
            VestingBO.YEAR = Convert.ToInt32(ddlduration4.SelectedValue);
            ddlduration5.DataSource = GetVestingDuration(VestingBO);
            ddlduration5.DataTextField = "YEAR_DESC";
            ddlduration5.DataValueField = "YEAR";

            ddlduration5.DataBind();
            ddlduration5.Items.Insert(0, new ListItem("Select", "0"));

        }
        protected void btnimport_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("VID");
            dt.Columns.Add("Vesting_Name");
            dt.Columns.Add("No_Of_Cycle");
            dt.Columns.Add("Vesting_Cycle_Name");
            dt.Columns.Add("Percentage");
            dt.Columns.Add("Duration");

            int VID = GET_VESTING_MASTER_ID();
            DataRow dr = dt.NewRow();
            DataRow dr1 = dt.NewRow();
            DataRow dr2 = dt.NewRow();
            DataRow dr3 = dt.NewRow();
            DataRow dr4 = dt.NewRow();
            if (ddlnoOfCycle1.SelectedValue == "1")
            {
                dr[0] = VID;
                dr[1] = txtVestingName.Text;
                dr[2] = ddlnoOfCycle1.SelectedValue;
                dr[3] = txtv1.Text;
                dr[4] = txtperc1.Text;
                dr[5] = ddlduration1.SelectedValue;
                dt.Rows.Add(dr);
            }
            else if (ddlnoOfCycle1.SelectedValue == "2")
            {
                dr[0] = VID;
                dr[1] = txtVestingName.Text;
                dr[2] = ddlnoOfCycle1.SelectedValue;
                dr[3] = txtv1.Text;
                dr[4] = txtperc1.Text;
                dr[5] = ddlduration1.SelectedValue;
                dt.Rows.Add(dr);

                dr1[0] = VID;
                dr1[1] = txtVestingName.Text;
                dr1[2] = ddlnoOfCycle1.SelectedValue;
                dr1[3] = txtv2.Text;
                dr1[4] = txtperc2.Text;
                dr1[5] = ddlduration2.SelectedValue;
                dt.Rows.Add(dr1);
            }
            else if (ddlnoOfCycle1.SelectedValue == "3")
            {
                dr[0] = VID;
                dr[1] = txtVestingName.Text;
                dr[2] = ddlnoOfCycle1.SelectedValue;
                dr[3] = txtv1.Text;
                dr[4] = txtperc1.Text;
                dr[5] = ddlduration1.SelectedValue;
                dt.Rows.Add(dr);

                dr1[0] = VID;
                dr1[1] = txtVestingName.Text;
                dr1[2] = ddlnoOfCycle1.SelectedValue;
                dr1[3] = txtv2.Text;
                dr1[4] = txtperc2.Text;
                dr1[5] = ddlduration2.SelectedValue;
                dt.Rows.Add(dr1);

                dr2[0] = VID;
                dr2[1] = txtVestingName.Text;
                dr2[2] = ddlnoOfCycle1.SelectedValue;
                dr2[3] = txtv3.Text;
                dr2[4] = txtperc3.Text;
                dr2[5] = ddlduration3.SelectedValue;
                dt.Rows.Add(dr2);
            }
            else if (ddlnoOfCycle1.SelectedValue == "4")
            {
                dr[0] = VID;
                dr[1] = txtVestingName.Text;
                dr[2] = ddlnoOfCycle1.SelectedValue;
                dr[3] = txtv1.Text;
                dr[4] = txtperc1.Text;
                dr[5] = ddlduration1.SelectedValue;
                dt.Rows.Add(dr);

                dr1[0] = VID;
                dr1[1] = txtVestingName.Text;
                dr1[2] = ddlnoOfCycle1.SelectedValue;
                dr1[3] = txtv2.Text;
                dr1[4] = txtperc2.Text;
                dr1[5] = ddlduration2.SelectedValue;
                dt.Rows.Add(dr1);

                dr2[0] = VID;
                dr2[1] = txtVestingName.Text;
                dr2[2] = ddlnoOfCycle1.SelectedValue;
                dr2[3] = txtv3.Text;
                dr2[4] = txtperc3.Text;
                dr2[5] = ddlduration3.SelectedValue;
                dt.Rows.Add(dr2);

                dr3[0] = VID;
                dr3[1] = txtVestingName.Text;
                dr3[2] = ddlnoOfCycle1.SelectedValue;
                dr3[3] = txtv4.Text;
                dr3[4] = txtperc4.Text;
                dr3[5] = ddlduration4.SelectedValue;
                dt.Rows.Add(dr3);
            }
            else
            {
                dr[0] = VID;
                dr[1] = txtVestingName.Text;
                dr[2] = ddlnoOfCycle1.SelectedValue;
                dr[3] = txtv1.Text;
                dr[4] = txtperc1.Text;
                dr[5] = ddlduration1.SelectedValue;
                dt.Rows.Add(dr);

                dr1[0] = VID;
                dr1[1] = txtVestingName.Text;
                dr1[2] = ddlnoOfCycle1.SelectedValue;
                dr1[3] = txtv2.Text;
                dr1[4] = txtperc2.Text;
                dr1[5] = ddlduration2.SelectedValue;
                dt.Rows.Add(dr1);

                dr2[0] = VID;
                dr2[1] = txtVestingName.Text;
                dr2[2] = ddlnoOfCycle1.SelectedValue;
                dr2[3] = txtv3.Text;
                dr2[4] = txtperc3.Text;
                dr2[5] = ddlduration3.SelectedValue;
                dt.Rows.Add(dr2);

                dr3[0] = VID;
                dr3[1] = txtVestingName.Text;
                dr3[2] = ddlnoOfCycle1.SelectedValue;
                dr3[3] = txtv4.Text;
                dr3[4] = txtperc4.Text;
                dr3[5] = ddlduration4.SelectedValue;
                dt.Rows.Add(dr3);

                dr4[0] = VID;
                dr4[1] = txtVestingName.Text;
                dr4[2] = ddlnoOfCycle1.SelectedValue;
                dr4[3] = txtv5.Text;
                dr4[4] = txtperc5.Text;
                dr4[5] = ddlduration5.SelectedValue;
                dt.Rows.Add(dr4);

            }
            VestingBO = new vesting_creation_BO();
            DataSet dsVestingName = new DataSet();
            VestingBO.VNAME = txtVestingName.Text;
            dsVestingName = VestingBAL.CHECK_VESTING_NAME(VestingBO);
            if (dsVestingName.Tables[0].Rows.Count > 0)
            {
                txtVestingName.Focus();
                Common.ShowJavascriptAlert("Vesting Name alredy exist.");
                GetDropDown();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

                return;
            }
            //VestingBO = new vesting_creation_BO();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                VestingBO.VID = Convert.ToInt32(dt.Rows[i][0].ToString());
                VestingBO.VNAME = dt.Rows[i][1].ToString();
                VestingBO.VCYCLE = Convert.ToInt32(dt.Rows[i][2].ToString());
                VestingBO.VCYCLENAME = dt.Rows[i][3].ToString();
                VestingBO.PERCENTAGE = Convert.ToInt32(dt.Rows[i][4].ToString());
                VestingBO.DURATION = Convert.ToInt32(dt.Rows[i][5].ToString());

                VestingBAL.VESTING_MASTER_INSERT(VestingBO);

            }
            GetDropDown();
            buttonChk();
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Vesting created successfully');", true);
            showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
            showmsg.InnerText = "Vesting created successfully";
            ClearInputs1(Page.Controls);
            GetDropDown_FMV();
            //Common.ShowJavascriptAlert("Vesting created successfully");
            //Page.Response.Redirect("~/vesting-creation.aspx", false);
        }
        protected void GetDropDown_FMV()

        {
            DataSet dss = objbal.Emptydumptable(objbo);
            try
            {

                if (txtDateOfGrant.Text == "")
                {

                }
                else
                {
                    objbo.DATE_OF_GRANT = Convert.ToDateTime(txtDateOfGrant.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);


                    DataSet ds = objbal.get_fmv_ondate_ofgrant(objbo);

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ddlFMV.DataTextField = "FMV_PRICE";
                        ddlFMV.DataValueField = "FMV_CREATION_ID";
                        ddlFMV.DataSource = ds.Tables[0];
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
                        Common.ShowJavascriptAlert("FMV price isn't available for selected date");
                    }


                    //DataSet ds = objbal.GetDropDown();
                    //DataTable dt = ds.Tables[1];
                    //DataView dataView = dt.DefaultView;


                    //string iDate = Convert.ToDateTime(txtDateOfGrant.Text).ToString("dd-MM-yyyy");
                    //DateTime oDate = Convert.ToDateTime(iDate);
                    ////DateTime dt_2 = DateTime.ParseExact(iDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                    //DateTime Dt_1 = DateTime.Now;
                    //IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-US");
                    //Dt_1 = DateTime.Parse(iDate, mFomatter);

                    //string DateFormat = Dt_1.ToString("dd-MM-yyyy");
                    //DateFormat = DateFormat.Replace("/", "-");

                    //dt.Columns.Add("Date_VALUATION_Str");
                    //dt.Columns.Add("Date_VALID_Str");

                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    dr["Date_VALUATION_Str"] = string.Format("{0:dd-MM-yyyy}", dr["VALUATION_DATE"]);
                    //    dr["Date_VALID_Str"] = string.Format("{0:dd-MM-yyyy}", dr["VALID_UPTO_DATE"]);
                    //}

                    //dataView.RowFilter = "Date_VALUATION_Str <= '" + DateFormat + "' and Date_VALID_Str  >= '" + DateFormat + "'";
                    ////dataView.RowFilter = "Date_VALUATION_Str <= '2020/10/08'";

                    //ddlFMV.DataSource = dataView;
                    //if (dataView.Count > 0)
                    //{
                    //    ddlFMV.DataTextField = "FMV_PRICE";
                    //    ddlFMV.DataValueField = "FMV_CREATION_ID";
                    //    ddlFMV.DataBind();
                    //    ddlFMV.Items.Insert(0, new ListItem("Select FMV", "0"));
                    //}

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        //public void SendMail(string status, string Empname, string ToEmailID, string Attachment)
        //{
        //    try
        //    {

        //        EMailBO eMailBO = new EMailBO();
        //        EMailBAL eMailBAL = new EMailBAL();
        //        eMailBO.userName = Empname;
        //        eMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/GrantCreated.html");
        //        eMailBO.EmailID = ToEmailID;//multple mail id
        //        eMailBO.subject = "Grant Created";
        //        eMailBO.Status1 = status;

        //        eMailBO.Attachment = ""; //Attachment;
        //        if (ConfigurationManager.AppSettings["SendMail"].ToUpper() == "YES")
        //        {
        //            string Data = eMailBAL.SendHtmlFormattedEmail(eMailBO);//SUB                               
        //            if (!string.IsNullOrEmpty(Data))
        //            {
        //                eMailBO.body = Data;
        //                eMailBO.Status = "Sucess";
        //                eMailBO.CreatedBy = Convert.ToString(Session["LoginID"]);
        //                bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
        //            }
        //            else
        //            {
        //                eMailBO.body = Data;
        //                eMailBO.Status = "Failed";
        //                eMailBO.CreatedBy = Convert.ToString(Session["LoginID"]);
        //                bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

        //        throw ex;
        //    }
        //}
        public void SendMail_1(string username)
        {
            string UserMailID = System.Configuration.ConfigurationManager.AppSettings["UserName"];
            string UserPassword = System.Configuration.ConfigurationManager.AppSettings["Password"];

            OEMailBO.Em_Action = "SendEmail";
            OEMailBO.Em_Type = "Grant";
            OEMailBO.Em_Sub_Type = "Grant_Created";
            emailreq.EmailEntity = OEMailBO;
            DataSet ds = OEMailBAL.insertEmail(emailreq);
            if (ds.Tables[0].Rows.Count > 0)
            {
                String mailSubject = ds.Tables[0].Rows[0]["Em_Sub"].ToString();
                String SessionCheck = Convert.ToString(Session["UserName"]);
                String body = ds.Tables[0].Rows[0]["Em_body"].ToString();
                //body = body.Replace("{{User}}", SessionCheck);
                body = body.Replace("@To", username);
                body = body.Replace("{{GrantName}}", txtGrantName.Text);
                body = body.Replace("@From", Convert.ToString(Session["UserName"]));

                string ccMailID = ds.Tables[0].Rows[0]["EM_CC_ID"].ToString();
                ccMailID = ccMailID.Replace(";", ",");
                string frommailId = ds.Tables[0].Rows[0]["EM_From_ID"].ToString();
                string ToMailId = "Prashant.shinde@cloverinfotech.com";

                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(frommailId);
                message.To.Add(new MailAddress(ToMailId));
                message.CC.Add(ccMailID);
                message.Subject = mailSubject;
                message.IsBodyHtml = true;
                message.Body = body;

                smtp.Port = 25;
                smtp.Host = "email.cloverinfotech.com";
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(UserMailID, UserPassword);

                //Comeented Temporary
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                    //throw ex;
                }
            }

        }
        protected void txtDateOfGrant_TextChanged1(object sender, EventArgs e)
        {
            GetDropDown_FMV();
            buttonChk();

        }
        protected void buttonChk()
        {
            rdb = "";
            if (Request.Form["customRadioInline3"] != null)
            {
                rdb = Request.Form["customRadioInline3"].ToString();
            }
            if (rdb == "single")
            {
                this.inputtypeSingle = "checked";
            }
            else
            {
                this.inputtypeBulk = "checked";
            }
        }

        //protected void ddlFMV_TextChanged(object sender, EventArgs e)
        //{
        //    //showmsg.InnerHtml = "";
        //}

        //protected void ddlVesting_TextChanged(object sender, EventArgs e)
        //{
        //    showmsg.InnerHtml = "";
        //}
        public string FuncReplaceWord(string EMPcode, int GrantID, int LetterID)
        {
            PresedentApprovalBO objbo_P = new PresedentApprovalBO();
            PresedentApprovalBAL objbal_P = new PresedentApprovalBAL();

            string sourceFile = "";
            string destinationFile = System.IO.Path.Combine(Server.MapPath("OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_GrantID_" + GrantID.ToString() + ".docx"));
            string PdfPathOutput = Server.MapPath("OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_" + DateTime.Now.ToString("ddMMyyyyHHmm") + ".pdf");
            string AdminPwd = "";
            try
            {
                DataSet Ds1 = new DataSet();
                objbo_P.FILEPATH = "OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_" + DateTime.Now.ToString("ddMMyyyyHHmm") + ".pdf";
                objbo_P.GrantID = GrantID;
                objbo_P.LETTERID = LetterID;
                objbo_P.Update_Type = "INSERT";
                //Ds1 = objbal_P.GetLetterPath(objbo_P);

                Ds1 = objbal_P.GetLetterPathCancel(objbo_P);

                if (Ds1.Tables[0].Rows.Count > 0 && Ds1 != null)
                {
                    sourceFile = System.IO.Path.Combine(Server.MapPath(Ds1.Tables[0].Rows[0][0].ToString()));
                    File.Copy(sourceFile, destinationFile, true);

                    //string F_Path = destinationFile;
                    //Common.UploadFtpFile("OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_GrantID_" + GrantID.ToString() + ".docx", F_Path);

                    DataSet ds = new DataSet();
                    objbo_P.EMPCODE = EMPcode.ToString();
                    objbo_P.GrantID = GrantID;
                    ds = objbal_P.GetEmpDetails_AdminPswd(objbo_P);
                    string pan_passward = ds.Tables[0].Rows[0]["PAN_CARD_NUMBER"].ToString();
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            AdminPwd = ds.Tables[2].Rows[0]["PDF_PASSWORD"].ToString();
                        }
                        if (chk.Checked == false)
                        {
                            pan_passward = "";
                            AdminPwd = "";
                        }
                        //Editing Docx file with Dynamic data from database.
                        using (WordprocessingDocument doc =
                            WordprocessingDocument.Open(destinationFile, true))
                        {
                            ///////////////////////////////Edit/////////////////////////////
                            string docText = null;
                            string docP = null;
                            using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                            {
                                docText = sr.ReadToEnd();
                            }

                            //////////////////////////////-Letter Edit Keywords///////////////////////////////
                            if (docText.Contains("@Emp_Code"))
                            {
                                Regex regexText = new Regex("@Emp_Code");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@TodayDate"))
                            {
                                Regex regexText = new Regex("@TodayDate");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Emp_Name"))
                            {
                                Regex regexText = new Regex("@Emp_Name");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["EMP_NAME"].ToString());
                            }

                            if (docText.Contains("@Grant_Date"))
                            {
                                Regex regexText = new Regex("@Grant_Date");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["Grant_Date"].ToString().Trim());
                            }
                            if (docText.Contains("@Tranch_Name"))
                            {
                                Regex regexText = new Regex("@Tranch_Name");
                                //docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["grant_name"].ToString());
                                string Grant_Name = Convert.ToString((txtGrantName.Text).Substring(0, 6));
                                Int32 number = Convert.ToInt32((txtGrantName.Text).Substring(6));
                                string x = ToRoman(number);
                                docText = regexText.Replace(docText, Grant_Name + "-" + x);

                                Regex regexText_1 = new Regex("@Tranch_Number");
                                docText = regexText_1.Replace(docText, "T" + number);
                            }
                            if (docText.Contains("@No_Of_Options"))
                            {
                                Regex regexText = new Regex("@No_Of_Options");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["no_of_options"].ToString());
                            }
                            if (docText.Contains("@Share_Price"))
                            {
                                Regex regexText = new Regex("@Share_Price");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["Grant_Price"].ToString());
                            }

                            if (docText.Contains("@FMV_Price"))
                            {
                                Regex regexText = new Regex("@FMV_Price");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["Grant_Price"].ToString());
                            }

                            if (docText.Contains("@Reference_No"))
                            {
                                Regex regexText = new Regex("@Reference_No");
                                docText = regexText.Replace(docText, "ESOP-09-G-" + ds.Tables[0].Rows[0]["grant_name"].ToString().Replace("RANCH", "") + "" + ds.Tables[0].Rows[0]["VNAME"].ToString() + "/" + Ds1.Tables[1].Rows[0][0].ToString());
                            }

                            if (docText.Contains("@SrNo"))
                            {
                                Regex regexText = new Regex("@SrNo");
                                docText = regexText.Replace(docText, Ds1.Tables[1].Rows[0][0].ToString());
                            }

                            if (docText.Contains("@Title"))
                            {
                                Regex regexText = new Regex("@Title");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Band"))
                            {
                                Regex regexText = new Regex("@Band");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Designation"))
                            {
                                Regex regexText = new Regex("@Designation");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Location"))
                            {
                                Regex regexText = new Regex("@Location");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Department"))
                            {
                                Regex regexText = new Regex("@Department");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Function"))
                            {
                                Regex regexText = new Regex("@Function");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@CostCenter"))
                            {
                                Regex regexText = new Regex("@CostCenter");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            string Vestdate1 = "";
                            string Vestdate2 = "";
                            string Vestdate3 = "";
                            string Vestdate4 = "";
                            string Vestdate5 = "";
                            string Vestdate6 = "";

                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                string Type = (i + 1).ToString();
                                switch (Type)
                                {
                                    case "1":
                                        {
                                            if (docText.Contains("@Vest_Date1"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date1");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                                Vestdate1 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); //+ " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }
                                        }
                                        break;
                                    case "2":
                                        {
                                            if (docText.Contains("@Vest_Date2"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date2");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years and the balance");
                                                Vestdate2 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); // + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }

                                        }
                                        break;
                                    case "3":
                                        {
                                            if (docText.Contains("@Vest_Date3"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date3");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                                Vestdate3 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); // + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }
                                        }
                                        break;
                                    case "4":
                                        {
                                            if (docText.Contains("@Vest_Date4"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date4");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                                Vestdate4 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); // + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }
                                        }
                                        break;
                                    case "5":
                                        {
                                            if (docText.Contains("@Vest_Date5"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date5");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                                Vestdate5 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); // + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }

                                        }
                                        break;
                                    case "6":
                                        {
                                            if (docText.Contains("@Vest_Date6"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date6");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                                Vestdate6 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); // + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }


                            if (Vestdate1 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date1");
                                docText = regexText.Replace(docText, Vestdate1);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date1");
                                docText = regexText.Replace(docText, "");
                            }

                            if (Vestdate2 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date2");
                                docText = regexText.Replace(docText, Vestdate2);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date2");
                                docText = regexText.Replace(docText, "");
                            }

                            if (Vestdate3 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date3");
                                docText = regexText.Replace(docText, Vestdate3);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date3");
                                docText = regexText.Replace(docText, "");
                            }

                            if (Vestdate4 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date4");
                                docText = regexText.Replace(docText, Vestdate4);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date4");
                                docText = regexText.Replace(docText, "");
                            }

                            if (Vestdate5 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date5");
                                docText = regexText.Replace(docText, Vestdate5);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date5");
                                docText = regexText.Replace(docText, "");
                            }

                            if (Vestdate6 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date6");
                                docText = regexText.Replace(docText, Vestdate6);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date6");
                                docText = regexText.Replace(docText, "");
                            }
                            //////////////////////////////////////////////////////////////////////////s


                            if (docText.Contains("No. of Options"))
                            {
                                Regex regexText = new Regex("No. of Options");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["no_of_options"].ToString());
                            }

                            if (docText.Contains("In Words"))
                            {
                                Regex regexText = new Regex("In Words");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["grant_name"].ToString());
                            }

                            if (docText.Contains("No of Shares"))
                            {
                                Regex regexText = new Regex("No of Shares");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["no_of_options"].ToString());
                            }

                            if (docText.Contains("&lt;"))
                            {
                                Regex regexText = new Regex("&lt;");
                                docText = regexText.Replace(docText, "");
                            }

                            if (docText.Contains("&gt;"))
                            {
                                Regex regexText = new Regex("&gt;");
                                docText = regexText.Replace(docText, "");
                            }

                            if (docText.Contains("Emp Name"))
                            {
                                Regex regexText = new Regex("Emp Name");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["EMP_NAME"].ToString());
                            }

                            if (docText.Contains("Emp Code"))
                            {
                                Regex regexText = new Regex("Emp Code");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                            {
                                sw.Write(docText);
                                sw.Close();
                            }
                        }

                        #region pdf generate using docx file. comment on hdfc argo server"

                        using (Process pdfprocess = new Process())
                        {
                            pdfprocess.StartInfo.UseShellExecute = true;
                            pdfprocess.StartInfo.LoadUserProfile = true;
                            pdfprocess.StartInfo.FileName = "soffice.exe";
                            pdfprocess.StartInfo.Arguments = "soffice  --headless --convert-to pdf " + destinationFile;
                            pdfprocess.StartInfo.WorkingDirectory = Server.MapPath("outputreport/");
                            pdfprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            pdfprocess.Start();
                            if (!pdfprocess.WaitForExit(1000 * 60 * 1))
                            {
                                pdfprocess.Kill();
                            }
                            pdfprocess.Close();
                        }
                        #endregion

                        string PdfPathInput = destinationFile.Replace(".docx", ".pdf");

                        #region "Generate PDF using Interop.Word--comment on clover server"
                        //var appWord = new Application();
                        //if (appWord.Documents != null)
                        //{
                        //    var wordDocument = appWord.Documents.Open(destinationFile);
                        //    string pdfDocName = PdfPathInput;
                        //    if (wordDocument != null)
                        //    {
                        //        wordDocument.ExportAsFixedFormat(pdfDocName, WdExportFormat.wdExportFormatPDF);
                        //        wordDocument.Close();
                        //    }
                        //    appWord.Quit();
                        //}
                        #endregion

                        //string F_Path1 = destinationFile.Replace(".docx", ".pdf");
                        //Common.UploadFtpFile("OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_GrantID_" + GrantID.ToString() + ".pdf", F_Path1);


                        //Password Encrypt//////////////////

                        //string alert = "";
                        //alert = "1";
                        if (!File.Exists(PdfPathInput))
                        {
                            return "";
                        }
                        //alert = alert + "2";

                        using (Stream input = new FileStream(PdfPathInput, FileMode.Open, FileAccess.Read, FileShare.Read))
                        using (Stream output = new FileStream(PdfPathOutput, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            //alert = alert + "3";

                            if (!File.Exists(PdfPathOutput))
                            {
                                //alert = alert + "4";
                                return "";
                            }
                            //alert = alert + "5";

                            try
                            {
                                PdfReader reader = new PdfReader(input);
                                //PdfEncryptor.Encrypt(reader, output, true, EMPcode, EMPcode, PdfWriter.ALLOW_PRINTING);
                                PdfEncryptor.Encrypt(reader, output, true, pan_passward, AdminPwd, PdfWriter.ALLOW_PRINTING);
                                output.Close();
                                input.Close();
                            }
                            catch (Exception ex)
                            {
                                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                            }
                            //alert = alert + "6";
                            //string F_Path2 = PdfPathOutput;
                            //Common.UploadFtpFile("OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_" + DateTime.Now.ToString("ddMMyyyyHHmm") + ".pdf", F_Path2);
                        }
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alert('" + alert + "');", true);

                    }
                }
                else
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), "Letter not found for Grant Id-" + GrantID.ToString(), "Letter not found for Grant Id-" + GrantID.ToString());
                    PdfPathOutput = "";
                }

            }
            catch (Exception ex)
            {
                // throw;
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                PdfPathOutput = "";
            }
            return PdfPathOutput;
        }
        protected void grdData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "download")
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    string hd = (gvr.FindControl("HiddenField1") as HiddenField).Value;
                    string LtrFile = hd.ToString();

                    string filePath = Server.MapPath(LtrFile);
                    if (File.Exists(filePath))
                    {
                        Response.ContentType = ContentType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                        Response.WriteFile(filePath);
                        Response.End();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        protected void btn_Preview_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                if (row != null)
                {
                    int rowindex = row.RowIndex;
                    HiddenField Hdf = grdData.Rows[rowindex].FindControl("HiddenField1") as HiddenField;
                    //string Path1 = Hdf.Value.ToString().Replace(".docx", ".pdf");               


                    if (Path.GetExtension(Hdf.Value.ToString()).ToString() == ".docx" || Path.GetExtension(Hdf.Value.ToString()).ToString() == ".pdf")
                    {
                        string Path = Hdf.Value.ToString().Replace(".docx", ".pdf");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal2('" + Path + "');", true);
                    }
                    else
                    {
                        string Freshchequefile = Hdf.Value.ToString();
                        FreshChequeImage1.Src = Freshchequefile;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal1();", true);
                    }

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        protected void lb_download_Click(object sender, EventArgs e)
        {
            //string filename = (sender as LinkButton).CommandArgument;
            //string filePath = Server.MapPath(filename);
            //if (System.IO.File.Exists(filePath) && System.IO.Path.HasExtension(filePath))
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
            //    ViewState["filepath"] = filename.Replace("~/", "");
            //}
            //else
            //{

            //    Common.ShowJavascriptAlert("File is not uploded");
            //}
            try
            {
                //var  filePath = Request.Form["__EVENTARGUMENT"];
                string filename = (sender as LinkButton).CommandArgument;
                string filePath = Server.MapPath(filename);
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        protected void DownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                //var  filePath = Request.Form["__EVENTARGUMENT"];
                string filePath = ViewState["filepath"].ToString();
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        protected void Cancle_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                //int Num = Convert.ToInt32(txtGrantName.Text.Substring(6)) - 1;
                //objbo.GRANT_NAME = "TRANCH" + Num;
                objbo.GRANT_NAME = txtGrantName.Text;
                ds = objbal.Delete_GrandCreation(objbo);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant has been cancelled";
                GrantCreation.Visible = true;
                tablediv_1.Visible = false;
                tablediv.Visible = false;
                btnPendingGrant.Visible = false;
                clearcontrol_GC();

                MaxValue();
                GetDropDown();
                //tablediv_1.Visible = false;
                //MaxValue();
                //BtnCancle.Visible = false;
                //BtnSubmitGrant.Visible = false;
                //BtnRetunt.Visible = true;
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

        }
        protected void BtnSubmitGrant_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            objbo.GRANT_NAME = txtGrantName.Text;
            ds = objbal.Save_GrandCreation(objbo);
            
            showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
            showmsg.InnerText = "Grant has been created & sent to Checker " + (ds.Tables[1].Rows[0][0].ToString()) + " for approval.";
            GrantCreation.Visible = true;
            tablediv_1.Visible = false;
            tablediv.Visible = false;
            btnPendingGrant.Visible = false;
            clearcontrol_GC();


            DataSet ds1 = OEMailBAL.GetEMPDetails(OEMailBO);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds1.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant_Created", txtGrantName.Text, "", "", ddlFMV.SelectedItem.ToString(), "", "", "");
            }
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "javascript:window.close();", true);
            //BtnCancle.Visible = false;
            //BtnSubmitGrant.Visible = false;
            //BtnRetunt.Visible = true;

            MaxValue();
            GetDropDown();
        }
        private void clearcontrol_GC()
        {
            txtEmpID.Text = "";
            txtDateOfGrant.Text = "";
            ddlFMV.SelectedIndex = 0;
            ddlVesting.SelectedIndex = 0;
            txtNoOfOption.Text = "";
        }
        protected void BtnRetunt_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
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
        protected void grdData_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void grdData_PreRender(object sender, EventArgs e)
        {
            System.Data.DataTable ds = (System.Data.DataTable)ViewState["Grddata"];
            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {
                    grdData.UseAccessibleHeader = true;
                    grdData.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }
        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }
        protected void btnPendingGrant_Click(object sender, EventArgs e)
        {
            tablediv.Visible = true;
            tablediv_1.Visible = true;
            GrantCreation.Visible = false;
        }
    }
}