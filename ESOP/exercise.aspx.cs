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
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESOP
{
    public partial class exercise : System.Web.UI.Page
    {
        GrandCreationBO objbo = new GrandCreationBO();
        GrandCreationBAL objbal = new GrandCreationBAL();
        FMVCreationBO objfmvbo = new FMVCreationBO();
        FMVCreationBAL objfmvbal = new FMVCreationBAL();
        public int SuccRecords = 0;
        public int FailRecords = 0;
        public int TotalRecords = 0;
        //string strCSV = System.Configuration.ConfigurationManager.AppSettings["CSV_1"];
        string ctlCOnn = System.Configuration.ConfigurationManager.AppSettings["ctl"];
        EMailBO eMailBO = new EMailBO();
        EMailBAL eMailBAL = new EMailBAL();
        bool IsPageRefresh = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            showmsg.InnerText = "";
            txtstartdate.Attributes.Add("readonly", "readonly");
            txtenddate.Attributes.Add("readonly", "readonly");
            tablediv.Visible = false;
            if (!IsPostBack)
            {

                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();

                GetFMV();
                GetValuedBy();
                GetExerciseDates();
                bindexcisegrid();
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

        private void bindexcisegrid()
        {
            try
            {
                DataSet ds = objbal.ESOP_GET_EXCISE_sell_GRIDDATA();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdexcise.DataSource = ds.Tables[0];
                    grdexcise.DataBind();
                    // ViewState["Getvaluation"] = ds.Tables[0];

                    grdexcise.UseAccessibleHeader = true;
                    grdexcise.HeaderRow.TableSection = TableRowSection.TableHeader;


                }
                else
                {
                    grdexcise.DataSource = ds.Tables[0];
                    grdexcise.DataBind();
                    //  ViewState["Getvaluation"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void GetExerciseDates()
        {

            DataSet ds = objbal.GetExerciseDates();
            ddlDates.DataSource = ds.Tables[0];
            ddlExistingDate.DataSource = ds.Tables[0];
            if (ds.Tables.Count > 0)
            {
                ddlDates.DataTextField = "Ex_Date";
                ddlDates.DataValueField = "Exercise_ID";
                ddlDates.DataBind();
                ddlDates.Items.Insert(0, new ListItem("Select Exercise Dates", "0"));


                ddlExistingDate.DataTextField = "Ex_Date";
                ddlExistingDate.DataValueField = "Exercise_ID";
                ddlExistingDate.DataBind();
                ddlExistingDate.Items.Insert(0, new ListItem("Select Exercise Dates", "0"));

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
                if (FileUpload1.FileName != "")
                {
                    FileUpload1.SaveAs(System.IO.Path.Combine(Server.MapPath("Fmv_excel"), FileUpload1.FileName));
                }
                else
                {
                }

                if (txtvaldate.Text == "")
                {
                }
                else
                {
                    objfmvbo.VALUATION_DATE = Convert.ToDateTime(txtvaldate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);//(txtvaldate.Text);
                }
                if (txtvalidupto.Text == "")
                {
                }
                else
                {
                    objfmvbo.VALID_UPTO_DATE = Convert.ToDateTime(txtvalidupto.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);//(txtvalidupto.Text);
                }
                objfmvbo.FMV_PRICE = (txtfmvprice.Text);
                objfmvbo.VALUED_BY = ddlvaluedby.SelectedValue.ToString();
                if (FileUpload1.FileName != "")
                {
                    objfmvbo.UPLOAD_FILE = "Fmv_excel/" + FileUpload1.FileName.ToString();
                }
                else
                {
                }
                objfmvbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                objfmvbo.UPDATED_BY = "";

                objfmvbo.btntext = "CREATE";
                string strmsg = objfmvbal.Insert_Fmv(objfmvbo);

                GetFMV();
                txtfmvprice.Text = "";
                ddlvaluedby.SelectedIndex = -1;
                if (strmsg == "exi")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV already exist'); ", true);
                }
                else
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV added successfully'); ", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "FMV added successfully.";
                }
                ClearFMVControl();
                bindfmvondate();


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



                Session["FMV_ID"] = ddlFMV.SelectedValue;
                if (ddlExistingDate.SelectedValue != "0")
                {
                    //if (RadioAppend.Checked == false && RadioOverwrite.Checked == false)
                    //{
                    //    Common.ShowJavascriptAlert("Please select atleast one option from Append/Overwrite");
                    //    return;
                    //}
                    string[] commandArgs = ddlExistingDate.SelectedItem.Text.ToString().Split(new string[] { " to " }, StringSplitOptions.None);
                    // Session["S_Date"] = commandArgs[0].ToString().Trim();
                    //Session["E_Date"] = commandArgs[1].ToString().Trim();
                    Session["S_Date"] = txtstartdate.Text;
                    Session["E_Date"] = txtenddate.Text;

                }
                else
                {

                    if (txtstartdate.Text != "" || txtenddate.Text != "")
                    {
                        DataSet DS_VALIDATION = new DataSet();
                        objbo.Start_Date = Convert.ToDateTime(txtstartdate.Text, System.Globalization.CultureInfo.GetCultureInfo("HI-IN").DateTimeFormat);
                        objbo.End_Date = Convert.ToDateTime(txtenddate.Text, System.Globalization.CultureInfo.GetCultureInfo("HI-IN").DateTimeFormat);
                        objbo.Key = "EXERCISE";
                        DS_VALIDATION = objbal.ESOP_GET_EXERCISE_SALE_VALIDATION(objbo);

                        if (Convert.ToInt32(DS_VALIDATION.Tables[0].Rows[0][0]) > 0)
                        {
                            Common.ShowJavascriptAlert("EXCERCISE ALREADY EXIST FOR SELECTED DATE");
                            txtstartdate.Text = "";
                            txtenddate.Text = "";
                            return;
                        }
                    }
                    Session["S_Date"] = txtstartdate.Text;
                    Session["E_Date"] = txtenddate.Text;
                }



                string fileName = Path.GetFileName(uploadfile.FileName).ToLower();
                string extension = Path.GetExtension(uploadfile.FileName).ToLower();
                string fileNamebk = Path.GetFileName(FileUpload2.FileName).ToLower();
                string extensionbk = Path.GetExtension(FileUpload2.FileName).ToLower();

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

                if (FileUpload2.HasFile)
                {
                    //string filepath = Path.GetFullPath(FileUpload2.PostedFile.FileName);
                    //string folderPath = Server.MapPath("~/Uploaded_Files");
                    //FileUpload2.SaveAs(folderPath + Path.GetFileName(FileUpload2.FileName));
                    if (Path.GetExtension(fileNamebk).Contains(".xls") || Path.GetExtension(fileNamebk).Contains(".xslx") || Path.GetExtension(fileNamebk).Contains(".txt") || Path.GetExtension(fileNamebk).Contains(".pdf"))
                    {
                        //string filenam = FileUpload2.FileName.ToString();
                        string filename = "BankStatment_" + ddlDates.SelectedItem.Text.ToString().Replace(" ", "_") + "" + extensionbk;
                        string path = Server.MapPath("~/Uploaded_Files/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        path = path + filename;
                        FileUpload2.PostedFile.SaveAs(path);
                        ////////////////////////////////////////Bankstatment update in ExcercisevTable//////

                        string[] commandArgs = ddlDates.SelectedItem.Text.ToString().Split(new string[] { " to " }, StringSplitOptions.None);
                        objbo.Start_Date = Convert.ToDateTime(commandArgs[0].ToString().Trim(), System.Globalization.CultureInfo.GetCultureInfo("HI-IN").DateTimeFormat);
                        objbo.End_Date = Convert.ToDateTime(commandArgs[1].ToString().Trim(), System.Globalization.CultureInfo.GetCultureInfo("HI-IN").DateTimeFormat);
                        objbo.excelDoucmentName = "~/Uploaded_Files/" + filename.ToString();
                        bool Val = objbal.Update_Excercise_BnkStatmnt(objbo);
                        if (Val == true)
                        {

                        }
                        ////////////////////////////////////////////////////////////////////////////////////////

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('File uploaded successfully');", true);
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "File uploaded successfully";
                        Session["UploadDoc"] = "IN";
                    }
                    else
                    {
                        Common.ShowJavascriptAlert("File type should be in .xls,.xslx format");
                    }
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "D1();", true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "D2();", true);
                }
                ddlDates.SelectedIndex = 0;
                bindexcisegrid();
            }
            catch (Exception ex)

            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
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

            DataTable exceldata = GetData(path); // get data from the excel - redirected to the getData function
                                                 //exceldata.Columns.Add("CREATED_BY", typeof(string));
            DataTable dtCloned = exceldata.Clone();

            bool a = InsertEmpMastRec(exceldata);

        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public DataTable GetData(string path)
        {
            DataSet result;
            DataTable dtData = new DataTable();
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

        public bool InsertEmpMastRec(DataTable dt)
        {
            DataTable dt_bulkTemp = new DataTable();
            //dt_bulkTemp.Columns.Add("DEM_EU_ID");
            dt_bulkTemp.Columns.Add("DEM_EMP_ID");
            dt_bulkTemp.Columns.Add("DEM_START_DATE");
            dt_bulkTemp.Columns.Add("DEM_END_DATE");
            dt_bulkTemp.Columns.Add("DEM_FMV_ID");
            dt_bulkTemp.Columns.Add("DEM_FMV_PRICE");
            dt_bulkTemp.Columns.Add("DEM_TAXABLE_INCOME");
            dt_bulkTemp.Columns.Add("DEM_ErrorString");
            dt_bulkTemp.Columns.Add("DEM_RecStatus");

            //-----------------------------------------------------------------------------------

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

                                ///
                                //// CHECKING VALIDATION FOR EXCEL DATA    --->    START
                                ///
                                #region validation start

                                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                                var regexItem_varchar = new Regex("^[a-zA-Z]*$");
                                var regexItem_onlyNumeric = new Regex("^[0-9 ]*$");
                                var regexItem_decimal = new Regex("^[1-9]\\d*(\\.\\d{1,2})?$"); //("^[0-9 ]*$");
                                var regexDateDDMMYYYY = new Regex("^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[13-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$");

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
                                if (dt.Rows[i]["Taxable Income"].ToString().Trim() == "")
                                {
                                    message = " Please enter Taxable Income.";
                                    ValError = false;
                                    objbo.Taxable_Income = 0;
                                    //objbo.Taxable_Income = Convert.ToInt32(dt.Rows[i]["Taxable Income"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["Taxable Income"].ToString().Trim()))
                                    {
                                        objbo.Taxable_Income = Convert.ToInt32(dt.Rows[i]["Taxable Income"].ToString().Trim());
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Taxable Income"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["Taxable Income"].ToString().Trim(), @"[a-zA-Z]").Count == 0)   //&& Regex.Matches(dt.Rows[i]["Taxable Income"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0
                                        {
                                            //objbo.Taxable_Income = Convert.ToInt32(dt.Rows[i]["Taxable Income"].ToString().Trim());
                                            objbo.Taxable_Income = 0;
                                        }
                                        else
                                        {
                                            message = message + " Only Numbers allowed for Taxable Income.";
                                            ValError = false;
                                            //objbo.Taxable_Income = Convert.ToInt32(dt.Rows[i]["Taxable Income"].ToString().Trim());

                                        }
                                    }
                                }

                                //-----------------------------------------------------------------------

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








                                dr["DEM_EMP_ID"] = objbo.EMP_ID;
                                dr["DEM_TAXABLE_INCOME"] = objbo.Taxable_Income;
                                dr["DEM_FMV_ID"] = ddlFMV.SelectedValue;
                                dr["DEM_FMV_PRICE"] = ddlFMV.SelectedItem.Text;
                                //dr["DEM_START_DATE"] = txtstartdate.Text; //Convert.ToDateTime(txtstartdate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat); 
                                //dr["DEM_END_DATE"] = txtenddate.Text; //Convert.ToDateTime(txtenddate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat); //Convert.ToDateTime(txtDateOfGrant.Text);
                                dr["DEM_START_DATE"] = Session["S_Date"];
                                dr["DEM_END_DATE"] = Session["E_Date"];
                                dr["DEM_RecStatus"] = objbo.RecStatus;
                                dr["DEM_ErrorString"] = objbo.ErrorString;



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

                string strCSV = Server.MapPath("~/MyFolder/abc2.csv");
                dt_bulkTemp.ToCSV(strCSV);

                ctlupload("abc2", "MyFolder/");
            }

            catch (Exception ex)
            {
                string exmsg = ex.Message.ToString();
                if (exmsg.Contains(" does not belong to table"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myalert", "alert('Please check the columns name in Excel');", true);
                }
                else
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                }
                // throw ex;

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

                string templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE esop_tbl_exercise_dump_table fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(DEM_EMP_ID \"trim(:DEM_EMP_ID)\",DEM_START_DATE \"trim(:DEM_START_DATE)\",DEM_END_DATE \"trim(:DEM_END_DATE)\",DEM_FMV_ID \"trim(:DEM_FMV_ID)\",DEM_FMV_PRICE \"trim(:DEM_FMV_PRICE)\",DEM_Taxable_Income \"trim(:DEM_Taxable_Income)\",DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_RecStatus \"trim(:DEM_RecStatus)\")";
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
                    objbo.EMP_ID = Session["ECode"].ToString();
                    objbo.FMV_ID = Convert.ToInt32(ddlFMV.SelectedValue.ToString());
                    //objbo.Start_Date = Convert.ToDateTime(txtstartdate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    //objbo.End_Date = Convert.ToDateTime(txtenddate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objbo.Start_Date = Convert.ToDateTime(Session["S_Date"].ToString(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objbo.End_Date = Convert.ToDateTime(Session["E_Date"].ToString(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                    DataSet ds;
                    //if (RadioAppend.Checked == true)
                    //{
                    //    objbo.Key = "Append";
                    //    objbo.ExercisedID = Convert.ToInt32(Session["ExerciseID"]);
                    //    ds = objbal.Vesting_Taxable_Income_Append_Overwrite(objbo);
                    //    ViewState["DataHistory"] = ds.Tables[0];
                    //}
                    //else
                    //{
                    //    if (RadioOverwrite.Checked == true)
                    //    {
                    //        objbo.Key = "Overwrite";
                    //        objbo.ExercisedID = Convert.ToInt32(Session["ExerciseID"]);
                    //        ds = objbal.Vesting_Taxable_Income_Append_Overwrite(objbo);
                    //        ViewState["DataHistory"] = ds.Tables[0];
                    //    }
                    //    else
                    //    {
                    //        ds = objbal.Vesting_Taxable_Income(objbo);
                    //        ViewState["DataHistory"] = ds.Tables[0];
                    //    }
                    //}
                    if (ddlExistingDate.SelectedIndex == 0)
                    {
                        ds = objbal.Vesting_Taxable_Income(objbo);
                        ViewState["DataHistory"] = ds.Tables[0];
                    }
                    else
                    {
                        objbo.Key = "Append";
                        objbo.ExercisedID = Convert.ToInt32(Session["ExerciseID"]);
                        ds = objbal.Vesting_Taxable_Income_Append_Overwrite(objbo);
                        ViewState["DataHistory"] = ds.Tables[0];
                    }

                    DataTable dt = ds.Tables[0];
                    SuccRecords = dt.Select("status = 'Success' and start_date='" + txtstartdate.Text + "' and end_date='" + txtenddate.Text + "' and FMV='" + ddlFMV.SelectedItem + "'").Length;
                    FailRecords = dt.Select("status = 'Failed' and start_date='" + txtstartdate.Text + "' and end_date='" + txtenddate.Text + "' and FMV='" + ddlFMV.SelectedItem + "'").Length;
                    string status1 = "Approved";
                    string Attachment = ""; // Server.MapPath(@"/Fmv_excel/Employee.xlsx");

                    DateTime firstDate = Convert.ToDateTime(txtstartdate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    DateTime secondDate = Convert.ToDateTime(txtenddate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                    System.TimeSpan diff = secondDate.Subtract(firstDate);
                    System.TimeSpan diff1 = secondDate - firstDate;

                    String diff2 = (secondDate - firstDate).TotalDays.ToString();

                    if (SuccRecords > 0)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                {
                                    if (ddlExistingDate.SelectedIndex != 0)
                                    {
                                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[1].Rows[i]["DEM_USER_NAME"].ToString(), "Exercise", "Append Exercise by Admin", "", ds.Tables[1].Rows[i]["DEM_EMAIL_ID"].ToString(), "", ddlFMV.SelectedItem.Text, txtstartdate.Text, txtenddate.Text, "");

                                    }
                                    //else if (RadioOverwrite.Checked == true)
                                    //{
                                    //    SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[1].Rows[i]["DEM_USER_NAME"].ToString(), "Exercise", "Override Exercise by Admin", "", ds.Tables[1].Rows[i]["DEM_EMAIL_ID"].ToString(), "", ddlFMV.SelectedItem.Text, txtstartdate.Text, txtenddate.Text, "");

                                    //}
                                    else
                                    {
                                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[1].Rows[i]["DEM_USER_NAME"].ToString(), "Exercise", "Approved Exercise by Admin", "", ds.Tables[1].Rows[i]["DEM_EMAIL_ID"].ToString(), "", ddlFMV.SelectedItem.Text, txtstartdate.Text, txtenddate.Text, "");
                                    }
                                }
                            }
                        }
                        //   ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Exercise window created successfully');", true);     
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Exercise window created successfully";
                    }
                    else
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Please upload excel file with valid records";
                    }
                    ClearInputs(Page.Controls);
                    GetExerciseDates();
                    uploadfile.Dispose();
                    tablediv.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
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
            RadioAppend.Checked = false;
            RadioOverwrite.Checked = false;
        }
        protected void downloadFailedRec(object sender, EventArgs e)
        {
            //////show msg for fetching Failed Records of Excel name : tempdata and uploaded on : dateAndtime
            ////try
            ////{
            ////    objbo.Start_Date = Convert.ToDateTime(Session["S_Date"].ToString(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            ////    objbo.End_Date = Convert.ToDateTime(Session["E_Date"].ToString(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            ////    objbo.FMV_ID = Convert.ToInt32(Session["FMV_ID"].ToString());
            ////    DataTable dt = new DataTable();
            ////    //objEntity.EmpUpload_ID = Session["EMU_ID"].ToString();
            ////    dt = objbal.getFailedData_Exercise(objbo);

            ////    //if (dt.Rows.Count==0)
            ////    if (dt == null)
            ////    {
            ////        Response.Write("<script language='javascript'>window.alert('No Failed records found.');</script>");
            ////    }
            ////    else
            ////    {
            ////        ViewState["DataHistory"] = dt;
            ////        ExportToExcel(dt);
            ////    }
            ////    //tablediv.Visible = true;
            ////}
            ////catch (Exception ex)
            ////{
            ////    Response.Write("<script language='javascript'>window.alert('No records found.');</script>");
            ////}
            DataTable dt = (DataTable)ViewState["DataHistory"];
            ExportToExcel(dt);
        }

        public void ExportToExcel(DataTable dtHistory)
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

        public void SendMail_2(string status, string Empname, string ToEmailID, string Attachment, string FMV_Price)
        {
            try
            {


                eMailBO.userName = Empname;
                eMailBO.FMV_Price = FMV_Price;
                eMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/EmployeeExercise.html");
                eMailBO.EmailID = ToEmailID;//multple mail id
                eMailBO.subject = "Exercise Approved";
                eMailBO.Status1 = status;


                eMailBO.Attachment = ""; //Attachment;
                if (ConfigurationManager.AppSettings["SendMail"].ToUpper() == "YES")
                {
                    string Data = eMailBAL.SendHtmlFormattedEmail(eMailBO);//SUB                               
                    if (!string.IsNullOrEmpty(Data))
                    {
                        eMailBO.body = Data;
                        eMailBO.Status = "Sucess";
                        eMailBO.CreatedBy = Convert.ToString(Session["LoginID"]);
                        bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
                    }
                    else
                    {
                        eMailBO.body = Data;
                        eMailBO.Status = "Failed";
                        eMailBO.CreatedBy = Convert.ToString(Session["LoginID"]);
                        bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        public void SendMail_1(string username, string MailID, string type)
        {
            string UserMailID = System.Configuration.ConfigurationManager.AppSettings["UserName"];
            string Password = System.Configuration.ConfigurationManager.AppSettings["Password"];

            cEmailEntityRequest emailreq = new cEmailEntityRequest();

            eMailBO.Em_Action = "SendEmail";
            eMailBO.Em_Type = "Exercise";
            eMailBO.Em_Sub_Type = type;
            emailreq.EmailEntity = eMailBO;
            DataSet ds = eMailBAL.insertEmail(emailreq);
            if (ds.Tables[0].Rows.Count > 0)
            {
                String mailSubject = ds.Tables[0].Rows[0]["Em_Sub"].ToString();
                String SessionCheck = Convert.ToString(Session["UserName"]);
                String body = ds.Tables[0].Rows[0]["Em_body"].ToString();
                //body = body.Replace("{{User}}", SessionCheck);
                body = body.Replace("{{To}}", username);
                body = body.Replace("{{UserName}}", Convert.ToString(Session["UserName"]));

                string ccMailID = ds.Tables[0].Rows[0]["EM_CC_ID"].ToString();
                ccMailID = MailID;  // ccMailID.Replace(";", ",");
                string frommailId = ds.Tables[0].Rows[0]["EM_From_ID"].ToString();
                string ToMailId = "pallavi.chaware@cloverinfotech.com";
                    //"Prashant.shinde@cloverinfotech.com";

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(frommailId);
                message.To.Add(new MailAddress(ToMailId));
                //message.CC.Add(ccMailID);
                message.Subject = mailSubject;
                message.IsBodyHtml = true;
                message.Body = body;
                //added by Pallavi on 07/03/2022
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("~/Grant_Files/Grant_Issued.xls");
                message.Attachments.Add(attachment);

                smtp.Port = 25;
                smtp.Host = "email.cloverinfotech.com";
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(UserMailID, Password);

                //Comeented Temporary
                smtp.Send(message);
            }

        }



        protected void myLink_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/ExcelFormat/Employee_Taxable_Income.xlsx");
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
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

            if (txtstartdate.Text != "" && txtenddate.Text != "")
            {
                objbo.Start_Date = Convert.ToDateTime(txtstartdate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                objbo.End_Date = Convert.ToDateTime(txtenddate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                objbo.FMV_PRICE = Convert.ToDecimal(0);
                DataSet ds = objbal.get_exercise_datewise_fmv(objbo);
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
                    Common.ShowJavascriptAlert("FMV price isn't available for selected excise date");
                }
            }
        }

        protected void grdexcise_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objbal.ESOP_GET_EXCISE_sell_GRIDDATA();
            if (ds.Tables[0].Rows.Count > 0)
            {


                grdexcise.UseAccessibleHeader = true;
                grdexcise.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdexcise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdexcise, "Select$" + e.Row.RowIndex);

                e.Row.Attributes["style"] = "cursor:pointer";


            }
        }

        protected void grdexcise_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int index = grdexcise.SelectedRow.RowIndex;
            //Label lblStart = (Label)grdexcise.Rows[index].FindControl("lblstrtdate");
            //Label lblEnd = (Label)grdexcise.Rows[index].FindControl("lbltodate");
            //string date1 = lblStart.Text;
            //string date2 = lblEnd.Text;

            //-- objbo.Start_Date = Convert.ToDateTime(date1, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            //-- objbo.End_Date = Convert.ToDateTime(date2, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

            // GridViewRow id = ((GridView)sender).NamingContainer as GridViewRow;
            // objbo.ExercisedID = Convert.ToInt32(grdexcise.DataKeys[id.RowIndex].Value.ToString());

            if (IsPageRefresh)
            {
                return;
            }

            int index = grdexcise.SelectedIndex;
            objbo.ExercisedID = Convert.ToInt32(grdexcise.SelectedValue.ToString());
            objbo.ExercisedID = Convert.ToInt32(grdexcise.DataKeys[index].Value.ToString());

            objbo.Start_Date = Convert.ToDateTime(DateTime.Now);

            objbo.End_Date = Convert.ToDateTime(DateTime.Now);



            DataSet ds = objbal.get_exercise_datewise_fmv(objbo);
            ViewState["Emp_filterRec"] = null;
            ViewState["Emp_filterRec"] = ds.Tables[1];
            if (ds.Tables[1].Rows.Count > 0)

            {
                grdempexercise.DataSource = ds.Tables[1];
                grdempexercise.DataBind();
                // grdempexercise.UseAccessibleHeader = true;
                // grdempexercise.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdempexercise.DataSource = ds.Tables[1];
                grdempexercise.DataBind();
            }



            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }

        protected void ddlExistingDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlExistingDate.SelectedValue != "0")
            {
                string[] commandArgs = ddlExistingDate.SelectedItem.Text.ToString().Split(new string[] { " to " }, StringSplitOptions.None);
                txtstartdate.Text = Convert.ToDateTime(commandArgs[0].ToString().Trim()).ToString("dd-MM-yyyy");
                txtenddate.Text = Convert.ToDateTime(commandArgs[1].ToString().Trim()).ToString("dd-MM-yyyy");
                objbo.Start_Date = Convert.ToDateTime(commandArgs[0].ToString().Trim(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                objbo.End_Date = Convert.ToDateTime(commandArgs[1].ToString().Trim(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                Session["ExerciseID"] = ddlExistingDate.SelectedValue.ToString();
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

        protected void grdempexercise_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdempexercise.PageIndex = e.NewPageIndex;
            DataTable ds = (DataTable)ViewState["Emp_filterRec"];
            if (ds.Rows.Count > 0)
            {
                grdempexercise.DataSource = ds;
                grdempexercise.DataBind();
            }
        }

        protected void grdempexercise_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)
            {
                ViewState["SortDirection"] = "ASC";
                grdempexercise.PageIndex = 0;
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
                grdempexercise.DataSource = dt;
                grdempexercise.DataBind();
            }
        }

        protected void grdempexercise_PreRender(object sender, EventArgs e)
        {


            DataTable ds = (DataTable)ViewState["Emp_filterRec"];

            if (ds == null) { }
            else
            {

                if (ds.Rows.Count > 0)
                {

                    grdempexercise.UseAccessibleHeader = true;
                    grdempexercise.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            if (Convert.ToString(Session["UploadDoc"]) == "IN")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "FixTabs(2);", true);
                Session["UploadDoc"] = "";
            }
        }

    }

}
