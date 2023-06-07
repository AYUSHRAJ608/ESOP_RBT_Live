using ESOP_BAL;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESOP
{
    public partial class PANCardUpload : System.Web.UI.Page
    {
        public int SuccessRecords = 0;
        public int FailRecords = 0;
        public int TotalRecords = 0;
        string strCSV = System.Configuration.ConfigurationManager.AppSettings["CSV"];
        string ctlCOnn = System.Configuration.ConfigurationManager.AppSettings["ctl"];

        E_EmployeMasterUpload objPanUpload = new E_EmployeMasterUpload();
        BEmployeeMasterUpload objEmpBAL = new BEmployeeMasterUpload();
        protected void Page_Load(object sender, EventArgs e)
        {
            showmsg.InnerHtml = "";
            //btnUpload.Attributes.Add("onclick", "return validate()");

            //if (!string.IsNullOrEmpty(Session["TotalRecords"] as string))
            //{
            //    TotalRecords = Convert.ToInt32(Session["TotalRecords"].ToString());
            //    SuccessRecords = Convert.ToInt32(Session["SuccessRecords"].ToString());
            //    FailRecords = Convert.ToInt32(Session["FailRecords"].ToString());
            //}

            if(!IsPostBack)
            {
                Session["SessionId"] = Guid.NewGuid().ToString();
            }
            tablediv.Visible = false;
        }
        protected void lnkDownloadFormat_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/ExcelFormat/PAN_ExcelFormat.xlsx");
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (uploadfile.HasFile)
            {
                string fileuploadpath = Path.GetFullPath(uploadfile.PostedFile.FileName);
                if (!string.IsNullOrEmpty(fileuploadpath))
                {
                    ReadExcel();
                }
            }
        }
        protected void downloadFailedRec(object sender, EventArgs e)
        {
            //show msg for fetching Failed Records of Excel name : tempdata and uploaded on : dateAndtime
            try
            {
                DataTable dt = new DataTable();

                objPanUpload.EmpUpload_ID = Session["GUID"].ToString();
                dt = objEmpBAL.getFailedRecordsData(objPanUpload);
                
                if (dt == null)
                {
                    Response.Write("<script language='javascript'>window.alert('No Failed records found.');</script>");
                }
                else
                {
                    ViewState["DataHistory"] = dt;
                    ExportToExcel(dt);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>window.alert('No records found.');</script>");
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

            string timeStamp = GetTimestamp(DateTime.Now);  // current date time added for the file name
            string path = FilePath + "/" + Path.GetFileNameWithoutExtension(uploadfile.FileName) + timeStamp + ext; // given file name as required
            uploadfile.SaveAs(path);

            DataTable exceldata = GetData(path); // get data from the excel - redirected to the getData function
                                                 
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
        public bool InsertEmpMastRec(DataTable dt)
        {
            DataTable dt_bulkTemp = new DataTable();

            dt_bulkTemp.Columns.Add("DEM_EMP_ID");
            dt_bulkTemp.Columns.Add("DEM_GRANT_NAME");
            dt_bulkTemp.Columns.Add("DEM_ErrorString");
            dt_bulkTemp.Columns.Add("DEM_RecStatus");
            dt_bulkTemp.Columns.Add("DEM_EU_ID");

            string ErrorValidationMsg = "";
            bool status = false;
            string msg = "";
            bool ValError = true;
            string message = "";
            string errorMsg = "";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            DataTable dsGuid = new DataTable();

            try
            {
                TotalRecords = dt.Rows.Count;

                DataRow[] EmpID;

                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataColumn col in dt.Columns)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if (dt.Rows.Count - 1 >= i)
                            {
                                if (i == 0)
                                {
                                    objPanUpload.firstEntry = true;
                                }

                                if (objPanUpload.firstEntry == true)
                                {
                                    dsGuid = objEmpBAL.getLastGuid(objPanUpload);
                                    objPanUpload.EmpUpload_ID = dsGuid.Rows[0]["DEM_EU_ID"].ToString().Trim();
                                    objPanUpload.firstEntry = false;
                                    Session["GUID"] = objPanUpload.EmpUpload_ID;
                                }

                                #region Validation Start
                                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                                var regexItem_PAN = new Regex("[A-Z]{5}[0-9]{4}[A-Z]{1}");
                                var regexItem_varchar = new Regex("^[a-zA-Z]*$");
                                var regexItem_onlyNumeric = new Regex("^[0-9 ]*$");
                                var regexItem_decimal = new Regex("^[1-9]\\d*(\\.\\d{1,2})?$");
                                var regexDateDDMMYYYY = new Regex("^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[13-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$");

                                if (dt.Rows[i]["Employee Code"].ToString().Trim() == "")
                                {
                                    message = " Please enter Employee Code.";
                                    ValError = false;
                                    objPanUpload.Ecode = dt.Rows[i]["Employee Code"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Employee Code"].ToString().Trim()))
                                    {
                                        objPanUpload.Ecode = dt.Rows[i]["Employee Code"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Employee Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Employee Code"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objPanUpload.Ecode = dt.Rows[i]["Employee Code"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Employee Code.";
                                            ValError = false;
                                            objPanUpload.Ecode = dt.Rows[i]["Employee Code"].ToString().Trim();
                                        }
                                    }
                                }

                                if (dt.Rows[i]["Pan Number"].ToString().Trim() == "")
                                {
                                    message = " Please enter Pan Number.";
                                    ValError = false;
                                    objPanUpload.PanNumber = (dt.Rows[i]["Pan Number"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_PAN.IsMatch(dt.Rows[i]["Pan Number"].ToString().Trim()))
                                    {
                                        if (dt.Rows[i]["Pan Number"].ToString().Trim() == "0")
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            objPanUpload.PanNumber = dt.Rows[i]["Pan Number"].ToString().Trim();
                                        }
                                        else
                                        {
                                            objPanUpload.PanNumber = dt.Rows[i]["Pan Number"].ToString().Trim();
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
                                                objPanUpload.PanNumber = dt.Rows[i]["Pan Number"].ToString().Trim();
                                            }
                                            else
                                            {
                                                objPanUpload.PanNumber = (dt.Rows[i]["Pan Number"].ToString().Trim());
                                            }
                                        }
                                        else
                                        {
                                            message = message + " Invalid Pan Number.";
                                            ValError = false;
                                            objPanUpload.PanNumber = (dt.Rows[i]["Pan Number"].ToString().Trim());
                                        }
                                    }
                                }

                                if (ValError == false)
                                {
                                    objPanUpload.ErrorString = sb.Append(message).ToString().Trim();
                                    objPanUpload.RecStatus = "Failed";
                                    FailRecords = FailRecords + 1;
                                }
                                else
                                {
                                    objPanUpload.ErrorString = "N.A.";
                                    objPanUpload.RecStatus = "Success";
                                    SuccessRecords = SuccessRecords + 1;
                                }
                                #endregion Validation End

                                DataRow dr = dt_bulkTemp.NewRow();

                                string EU_ID = objPanUpload.EmpUpload_ID;

                                dr["DEM_EMP_ID"] = objPanUpload.Ecode;
                                dr["DEM_GRANT_NAME"] = objPanUpload.PanNumber;
                                dr["DEM_RecStatus"] = objPanUpload.RecStatus;
                                dr["DEM_ErrorString"] = objPanUpload.ErrorString;
                                dr["DEM_EU_ID"] = objPanUpload.EmpUpload_ID;

                                dt_bulkTemp.Rows.Add(dr);

                                ValError = true;
                                message = "";
                                sb.Clear();
                                i = i + 1;
                            }
                        }
                    }
                }
                dt_bulkTemp.ToCSV(strCSV);
                ctlupload("abc1", "MyFolder/");

                DataSet dt_getCount = new DataSet();
                objPanUpload.EmpUpload_ID = Session["GUID"].ToString();
                dt_getCount = objEmpBAL.getRecordCount(objPanUpload);

                SuccessRecords = Convert.ToInt32(dt_getCount.Tables[0].Rows[0]["SuccessCount"].ToString());
                FailRecords = Convert.ToInt32(dt_getCount.Tables[1].Rows[0]["FailedCount"].ToString());

                Session["TotalRecords"] = TotalRecords;
                Session["SuccessRecords"] = SuccessRecords;
                Session["FailRecords"] = FailRecords;

                if(SuccessRecords.ToString() != "0")
                {
                    DataTable dt_addSuccessRec = new DataTable();
                    EmpID = dt_bulkTemp.Select("DEM_RecStatus='Success'");

                    string attachEmp = string.Empty;

                    for (int j = 0; j < EmpID.Count(); j++)
                    {
                        objPanUpload.Ecode = EmpID[j]["DEM_EMP_ID"].ToString();
                        objPanUpload.PanNumber = EmpID[j]["DEM_GRANT_NAME"].ToString();
                        dt_addSuccessRec = objEmpBAL.UpdateEmpPANDetails(objPanUpload);

                        //attachEmp += Convert.ToString(EmpID[j]["DEM_EMP_ID"]) + ",";
                    }
                    //attachEmp = attachEmp.Remove(attachEmp.Length - 1, 1);
                    //objPanUpload.Ecode = attachEmp;
                    //dt_addSuccessRec = objEmpBAL.UpdateEmpPANDetails(objPanUpload);
                }
                tablediv.Visible = true;
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
            }
            finally
            {
                objPanUpload = null;
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

                StreamWriter writer = File.CreateText(CtlFileName);

                string templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_tbl_dump_table fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(DEM_EMP_ID \"trim(:DEM_EMP_ID)\",DEM_GRANT_NAME \"trim(:DEM_GRANT_NAME)\",DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_RecStatus \"trim(:DEM_RecStatus)\",DEM_EU_ID \"trim(:DEM_EU_ID)\")";
                writer.WriteLine(templine);
                writer.Close();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

            try
            {
                string output, Error;

                ProcessStartInfo p1 = new ProcessStartInfo("Cmd.exe", "/c sqlldr \'" + ctlCOnn + "\' Control=" + CtlFileName + "");

                Process p2;
                p1.UseShellExecute = false;
                p1.RedirectStandardError = true; 
                string al = Server.MapPath("cmd.exe");
                p1.FileName = Path.GetFileName("cmd.exe");
                p1.WorkingDirectory = Path.GetDirectoryName(Server.MapPath("cmd.exe"));

                p1.CreateNoWindow = true;
                p1.WindowStyle = ProcessWindowStyle.Hidden;
                p1.RedirectStandardOutput = true;

                p2 = Process.Start(p1);

                output = p2.StandardOutput.ReadToEnd();
                Error = p2.StandardError.ReadToEnd();
                p2.WaitForExit();

                int exitcode = p2.ExitCode;
                if (exitcode == 0)
                {
                    
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

        }
        public void ExportToExcel(DataTable dtHistory)
        {
            string filename = "FailedData_" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            DataGrid dgGrid = new DataGrid();

            dgGrid.DataSource = dtHistory;
            dgGrid.DataBind();

            dgGrid.RenderControl(hw);

            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}