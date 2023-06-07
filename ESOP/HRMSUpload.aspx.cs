using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Text;
using System.Net;
using ExcelDataReader;
using System.Web.Script.Serialization;
using ESOP_BO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Diagnostics;
using ESOP_BAL;
using ESOP_BO;
namespace ESOP
{
    public partial class HRMSUpload : System.Web.UI.Page
    {
        int RowCnt = 0;
        E_EmployeMasterUpload objEntity = new E_EmployeMasterUpload();
        BEmployeeMasterUpload objBal = new BEmployeeMasterUpload();
        Boolean appendFlag, overwriteFlag;
        String templateDownloadFlag, uploadDataFlag, uploadDataFormatFlag;
        int SuccessCountEx, SuccessCountMain;

        string strCSV = System.Configuration.ConfigurationManager.AppSettings["CSV"];
        string ctlCOnn = System.Configuration.ConfigurationManager.AppSettings["ctl"];
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Left"] = "Upload";
            Session["Header"] = "Admin";
            //lblUploadValidation.Visible = false;
            String myGuid = Guid.NewGuid().ToString();
            tablediv.Visible = false;
            //lblUploadValidation.Visible = false;
            //btnimport.Visible = true;
            btnimport1.Visible = true;
            Div1.Visible = false;
            //lblSuccessCount.Text = " 155 record(s) have been entered in wrong format ";
            //lblFailedCount.Text = " 55 record(s) have been entered in wrong format, kindly check!";

        }

        protected void btn_downloadFormat_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["EmpId"]) == 0)
            {
                Response.Redirect("~/HRMSUpload.aspx");
            }
            else
            {
                templateDownloadFlag = "ExcelDownload";// Request.Form["rdobtnExcel"].ToString();
                if (templateDownloadFlag == "ExcelDownload")
                {
                    string filePath = Server.MapPath("~/ExcelFormat/EmployeeMaster_ExcelFormat.xls");
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
            }
        }

        protected void uploadData(object sender, EventArgs e) // button upload data NOT IN USE
        {
            try
            {
                if (Convert.ToInt32(Session["EmpId"]) == 0)
                {
                    Response.Redirect("~/HRMSUpload.aspx");
                }
                else
                {
                    uploadDataFormatFlag = "ExcelDownload";
                    if (uploadDataFormatFlag == "ExcelDownload")
                    {
                        //btnimport.Visible = false;
                        //btnimport1.Visible = false;
                        uploadExcelData();
                    }

                }
            }
            catch (Exception ex)
            {

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
            //exceldata.Columns.Add("CreatedBy", typeof(string));
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
            dt_bulkTemp.Columns.Add("DEM_EU_ID");
            dt_bulkTemp.Columns.Add("DEM_ECODE");
            dt_bulkTemp.Columns.Add("DEM_COMPANY_NAME");
            dt_bulkTemp.Columns.Add("DEM_GENDER");
            dt_bulkTemp.Columns.Add("DEM_EMP_STATUS");
            dt_bulkTemp.Columns.Add("DEM_LWD");
            dt_bulkTemp.Columns.Add("DEM_TNTR");
            dt_bulkTemp.Columns.Add("DEM_EMP_NAME");
            dt_bulkTemp.Columns.Add("DEM_DESIGNATION");
            dt_bulkTemp.Columns.Add("DEM_BANDS");
            dt_bulkTemp.Columns.Add("DEM_DOJ");
            dt_bulkTemp.Columns.Add("DEM_LOCATION");
            dt_bulkTemp.Columns.Add("DEM_DEPARTMENT");
            dt_bulkTemp.Columns.Add("DEM_FUNCTION");
            dt_bulkTemp.Columns.Add("DEM_COST_CENTRE");
            dt_bulkTemp.Columns.Add("DEM_APP_CODE");
            dt_bulkTemp.Columns.Add("DEM_APPRAISER_NAME");
            dt_bulkTemp.Columns.Add("DEM_APP_BAND");
            dt_bulkTemp.Columns.Add("DEM_REV_CODE");
            dt_bulkTemp.Columns.Add("DEM_REVIEWER_NAME");
            dt_bulkTemp.Columns.Add("DEM_REV_BAND");
            dt_bulkTemp.Columns.Add("DEM_HOD_CODE");
            dt_bulkTemp.Columns.Add("DEM_HOD_NAME");
            dt_bulkTemp.Columns.Add("DEM_HOD_BAND");
            dt_bulkTemp.Columns.Add("DEM_BH_CODE");
            dt_bulkTemp.Columns.Add("DEM_BH_NAME");
            dt_bulkTemp.Columns.Add("DEM_INTERNAL");
            dt_bulkTemp.Columns.Add("DEM_EXTERNAL");
            dt_bulkTemp.Columns.Add("DEM_TOTAL");
            dt_bulkTemp.Columns.Add("DEM_RecStatus");
            dt_bulkTemp.Columns.Add("DEM_UploadBy");
            dt_bulkTemp.Columns.Add("DEM_ErrorString");
            dt_bulkTemp.Columns.Add("DEM_NT_ID");

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
                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (dt.Rows.Count - 1 >= i)
                            {
                                if (i == 0)
                                {
                                    objEntity.firstEntry = true;
                                    objEntity.CreatedBy = Convert.ToInt32(Session["EmpId"].ToString()); // Convert.ToInt32(dt.Rows[i]["CreatedBy"].ToString());
                                }

                                if (objEntity.firstEntry == true)
                                {
                                    DataTable dt_getUGID = new DataTable();
                                    dt_getUGID = objBal.fetchLastemuId(objEntity);
                                    objEntity.EmpUpload_ID = dt_getUGID.Rows[0]["DEM_EU_ID"].ToString().Trim();
                                    //objEntity.EmpUpload_ID = 1;
                                    Session["EMU_ID"] = objEntity.EmpUpload_ID;
                                    objEntity.firstEntry = false;
                                }

                                ///
                                //// CHECKING VALIDATION FOR EXCEL DATA    --->    START
                                ///
                                #region validation start

                                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                                var regexItem_varchar = new Regex("^[a-zA-Z]*$");
                                var regexItem_onlyNumeric = new Regex("^[0-9 ]*$");

                                var regexItem_decimal = new Regex("^[0-9]\\d*(\\.\\d{1,2})?$"); //("^[0-9 ]*$");
                                var regexDateDDMMYYYY = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
                                var regexDateDDMMYYYY_HHMMSS = new Regex(@"^(?:(?:(?:(0[1-9]|1[0-9]|2[0-8])[\/\-\.](0[1-9]|1[0-2])|(29|30)[\/\-\.](0[13-9]|1[0-2])|(31)[\/\-\.](0[13578]|1[02]))[\/\-\.]([1-2][0-9]{3}))|(?:(29)[\/\-\.](02)[\/\-\.]([1-2][0-9](?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)))(?: ((?:[0-1][0-9])|(?:2[0-3])):([0-5][0-9]):([0-5][0-9]))?$");
                                // var regexDateDDMMYYYY_HHMMSS_AmPm = new Regex("^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[13-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2}) (AM|am|pm|PM)$");
                                var regexDateDDMMYYYY_HHMMSS_AmPm = new Regex(@"^(((0[1 - 9] |[12]\d | 3[01])[\/\.-](0[13578]|1[02])[\/\.-]((19|[2-9]\d)\d{2})\s(0[0-9]|1[0-2]):(0[0-9]|[1-59]\d):(0[0-9]|[1-59]\d)\s(AM|am|PM|pm))|((0[1-9]|[12]\d|30)[\/\.-](0[13456789]|1[012])[\/\.-]((19|[2-9]\d)\d{2})\s(0[0-9]|1[0-2]):(0[0-9]|[1-59]\d):(0[0-9]|[1-59]\d)\s(AM|am|PM|pm))|((0[1-9]|1\d|2[0-8])[\/\.-](02)[\/\.-]((19|[2-9]\d)\d{2})\s(0[0-9]|1[0-2]):(0[0-9]|[1-59]\d):(0[0-9]|[1-59]\d)\s(AM|am|PM|pm))|((29)[\/\.-](02)[\/\.-]((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))\s(0[0-9]|1[0-2]):(0[0-9]|[1-59]\d):(0[0-9]|[1-59]\d)\s(AM|am|PM|pm)))$");

                                if (dt.Rows[i]["Employee Code"].ToString().Trim() == "")
                                {
                                    message = " Please enter Employee Code.";
                                    ValError = false;
                                    objEntity.Ecode = dt.Rows[i]["Employee Code"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Employee Code"].ToString().Trim()))
                                    {
                                        objEntity.Ecode = dt.Rows[i]["Employee Code"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Employee Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Employee Code"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Ecode = dt.Rows[i]["Employee Code"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Employee Code.";
                                            ValError = false;
                                            objEntity.Ecode = dt.Rows[i]["Employee Code"].ToString().Trim();
                                        }
                                    }
                                }

                                //
                                if (dt.Rows[i]["Company Name"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Company Name.";
                                    //ValError = false;
                                    objEntity.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Company Name"].ToString().Trim()))
                                    {
                                        objEntity.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Company Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Company Name"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Company Name.";
                                            ValError = false;
                                            objEntity.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Gender"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Gender.";
                                    //ValError = false;
                                    objEntity.Gender = dt.Rows[i]["Gender"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Gender"].ToString().Trim()))
                                    {
                                        objEntity.Gender = dt.Rows[i]["Gender"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Gender"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Gender"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Gender = dt.Rows[i]["Gender"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Gender.";
                                            ValError = false;
                                            objEntity.Gender = dt.Rows[i]["Gender"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Employee Status"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Employee Status.";
                                    //ValError = false;
                                    objEntity.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Employee Status"].ToString().Trim()))
                                    {
                                        objEntity.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Employee Status"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Employee Status"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Employee Status.";
                                            ValError = false;
                                            objEntity.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //=====//
                                try
                                {
                                    if (dt.Rows[i]["LWD"].ToString().Trim() == "")
                                    {
                                        //if (message != "")
                                        //{
                                        //    message = message + " ";
                                        //}
                                        //message = message + " Please Enter a LWD.";
                                        //ValError = false;
                                        objEntity.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["LWD"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                        {
                                            if (regexDateDDMMYYYY_HHMMSS_AmPm.IsMatch(dt.Rows[i]["LWD"].ToString().Trim()))
                                            {
                                                objEntity.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
                                                string convDateTm = Convert.ToDateTime(objEntity.Lwd).ToString("dd/MM/yyyy");
                                                objEntity.Lwd = convDateTm;
                                            }
                                            else
                                            {
                                                message = message + " Invalid Date format for LWD.";
                                                ValError = false;
                                                objEntity.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
                                            }
                                        }
                                        else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["LWD"].ToString().Trim()) || regexDateDDMMYYYY_HHMMSS.IsMatch(dt.Rows[i]["LWD"].ToString().Trim()))
                                        {
                                            objEntity.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
                                            string convDateTm = Convert.ToDateTime(objEntity.Lwd).ToString("dd/MM/yyyy");
                                            objEntity.Lwd = convDateTm;
                                        }
                                        else
                                        {
                                            message = message + " Invalid Date format for LWD.";
                                            ValError = false;
                                            objEntity.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw;
                                }
                                //
                                if (dt.Rows[i]["TNTR"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter TNTR.";
                                    //ValError = false;
                                    objEntity.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["TNTR"].ToString().Trim()))
                                    {
                                        objEntity.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["TNTR"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["TNTR"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for TNTR.";
                                            ValError = false;
                                            objEntity.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Employee Name"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Employee Name.";
                                    //ValError = false;
                                    objEntity.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Employee Name"].ToString().Trim()))
                                    {
                                        objEntity.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Employee Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Employee Name"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Employee Name.";
                                            ValError = false;
                                            objEntity.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Designation"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Designation.";
                                    //ValError = false;
                                    objEntity.Designation = dt.Rows[i]["Designation"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Designation"].ToString().Trim()))
                                    {
                                        objEntity.Designation = dt.Rows[i]["Designation"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Designation"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Designation"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Designation = dt.Rows[i]["Designation"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Designation.";
                                            ValError = false;
                                            objEntity.Designation = dt.Rows[i]["Designation"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Band"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Band.";
                                    //ValError = false;
                                    objEntity.Bands = dt.Rows[i]["Band"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Band"].ToString().Trim()))
                                    {
                                        objEntity.Bands = dt.Rows[i]["Band"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Band"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Band"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Bands = dt.Rows[i]["Band"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Band.";
                                            ValError = false;
                                            objEntity.Bands = dt.Rows[i]["Band"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                try
                                {
                                    if (dt.Rows[i]["Date of Joining"].ToString().Trim() == "")
                                    {
                                        //if (message != "")
                                        //{
                                        //    message = message + " ";
                                        //}
                                        //message = message + " Please Enter a Date of Joining.";
                                        //ValError = false;
                                        objEntity.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Date of Joining"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                        {
                                            if (regexDateDDMMYYYY_HHMMSS_AmPm.IsMatch(dt.Rows[i]["Date of Joining"].ToString().Trim()))
                                            {
                                                objEntity.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
                                                string convDateTm = Convert.ToDateTime(objEntity.Doj).ToString("dd/MM/yyyy");
                                                objEntity.Doj = convDateTm;
                                            }
                                            else
                                            {
                                                message = message + " Invalid Date format for Date of Joining.";
                                                ValError = false;
                                                objEntity.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
                                            }
                                        }
                                        else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["Date of Joining"].ToString().Trim()) || regexDateDDMMYYYY_HHMMSS.IsMatch(dt.Rows[i]["Date of Joining"].ToString().Trim()))
                                        {
                                            objEntity.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
                                            string convDateTm = Convert.ToDateTime(objEntity.Doj).ToString("dd/MM/yyyy");
                                            objEntity.Doj = convDateTm;
                                        }
                                        else
                                        {
                                            message = message + " Invalid Date format for Date of Joining.";
                                            ValError = false;
                                            objEntity.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw;
                                }
                                
                                //=====//

                                //
                                if (dt.Rows[i]["Location"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Location.";
                                    //ValError = false;
                                    objEntity.Location = dt.Rows[i]["Location"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Location"].ToString().Trim()))
                                    {
                                        objEntity.Location = dt.Rows[i]["Location"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Location"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Location"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Location = dt.Rows[i]["Location"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Location.";
                                            ValError = false;
                                            objEntity.Location = dt.Rows[i]["Location"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Department"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Department.";
                                    //ValError = false;
                                    objEntity.Department = dt.Rows[i]["Department"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Department"].ToString().Trim()))
                                    {
                                        objEntity.Department = dt.Rows[i]["Department"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Department"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Department"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Department = dt.Rows[i]["Department"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Department.";
                                            ValError = false;
                                            objEntity.Department = dt.Rows[i]["Department"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Function"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Function.";
                                    //ValError = false;
                                    objEntity.Function = dt.Rows[i]["Function"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Function"].ToString().Trim()))
                                    {
                                        objEntity.Function = dt.Rows[i]["Function"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Function"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Function"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Function = dt.Rows[i]["Function"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Function.";
                                            ValError = false;
                                            objEntity.Function = dt.Rows[i]["Function"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Cost Center"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Cost Center.";
                                    //ValError = false;
                                    objEntity.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Cost Center"].ToString().Trim()))
                                    {
                                        objEntity.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Cost Center"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Cost Center"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Cost Center.";
                                            ValError = false;
                                            objEntity.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Appraiser Code"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Appraiser Code.";
                                    //ValError = false;
                                    objEntity.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Appraiser Code"].ToString().Trim()))
                                    {
                                        objEntity.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Appraiser Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Appraiser Code"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Appraiser Code.";
                                            ValError = false;
                                            objEntity.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Appraiser Band"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Appraiser Band.";
                                    //ValError = false;
                                    objEntity.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Appraiser Band"].ToString().Trim()))
                                    {
                                        objEntity.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Appraiser Band"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Appraiser Band"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Appraiser Band.";
                                            ValError = false;
                                            objEntity.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                if (dt.Rows[i]["Appraiser Name"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Appraiser Name.";
                                    //ValError = false;
                                    objEntity.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Appraiser Name"].ToString().Trim()))
                                    {
                                        objEntity.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Appraiser Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Appraiser Name"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Appraiser Name.";
                                            ValError = false;
                                            objEntity.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//
                                //
                                if (dt.Rows[i]["Reviewer Code"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Reviewer Code.";
                                    //ValError = false;
                                    objEntity.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Reviewer Code"].ToString().Trim()))
                                    {
                                        objEntity.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Reviewer Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Reviewer Code"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Reviewer Code.";
                                            ValError = false;
                                            objEntity.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Reviewer Name"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Reviewer Name.";
                                    //ValError = false;
                                    objEntity.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Reviewer Name"].ToString().Trim()))
                                    {
                                        objEntity.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Reviewer Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Reviewer Name"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Reviewer Name.";
                                            ValError = false;
                                            objEntity.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["Reviewer Band"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Reviewer Band.";
                                    //ValError = false;
                                    objEntity.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Reviewer Band"].ToString().Trim()))
                                    {
                                        objEntity.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Reviewer Band"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Reviewer Band"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for Reviewer Band.";
                                            ValError = false;
                                            objEntity.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["HOD Code"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter HOD Code.";
                                    //ValError = false;
                                    objEntity.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["HOD Code"].ToString().Trim()))
                                    {
                                        objEntity.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["HOD Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["HOD Code"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for HOD Code.";
                                            ValError = false;
                                            objEntity.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["HOD Name"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter HOD Name.";
                                    //ValError = false;
                                    objEntity.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["HOD Name"].ToString().Trim()))
                                    {
                                        objEntity.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["HOD Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["HOD Name"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for HOD Name.";
                                            ValError = false;
                                            objEntity.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["HOD Band"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter HOD Band.";
                                    //ValError = false;
                                    objEntity.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["HOD Band"].ToString().Trim()))
                                    {
                                        objEntity.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["HOD Band"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["HOD Band"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for HOD Band.";
                                            ValError = false;
                                            objEntity.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["BHCode"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter BHCode.";
                                    //ValError = false;
                                    objEntity.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["BHCode"].ToString().Trim()))
                                    {
                                        objEntity.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["BHCode"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["BHCode"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for BHCode.";
                                            ValError = false;
                                            objEntity.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //
                                if (dt.Rows[i]["BHName"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter BHName.";
                                    //ValError = false;
                                    objEntity.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["BHName"].ToString().Trim()))
                                    {
                                        objEntity.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["BHName"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["BHName"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for BHName.";
                                            ValError = false;
                                            objEntity.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
                                        }
                                    }
                                }
                                //=====//

                                //

                                if (dt.Rows[i]["Internal"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Internal value.";
                                    //ValError = false;
                                    objEntity.Internal = dt.Rows[i]["Internal"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem_decimal.IsMatch(dt.Rows[i]["Internal"].ToString().Trim()))
                                    {
                                        objEntity.Internal = dt.Rows[i]["Internal"].ToString().Trim();
                                    }
                                    else
                                    {
                                        message = message + " Only Numeric value allowed for Internal.";
                                        ValError = false;
                                        objEntity.Internal = dt.Rows[i]["Internal"].ToString().Trim(); ;
                                    }
                                }

                                if (dt.Rows[i]["External"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter External value.";
                                    //ValError = false;
                                    objEntity.External = dt.Rows[i]["External"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem_decimal.IsMatch(dt.Rows[i]["External"].ToString().Trim()))
                                    {
                                        objEntity.External = dt.Rows[i]["External"].ToString().Trim();
                                    }
                                    else
                                    {
                                        message = message + " Only Numeric value allowed for External.";
                                        ValError = false;
                                        objEntity.External = dt.Rows[i]["External"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["Total"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Total value.";
                                    //ValError = false;
                                    objEntity.Total = dt.Rows[i]["Total"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem_decimal.IsMatch(dt.Rows[i]["Total"].ToString().Trim()))
                                    {
                                        objEntity.Total = dt.Rows[i]["Total"].ToString().Trim();
                                    }
                                    else
                                    {
                                        message = message + " Only Numeric value allowed for Total.";
                                        ValError = false;
                                        objEntity.Total = dt.Rows[i]["Total"].ToString().Trim();
                                    }
                                }


                                if (dt.Rows[i]["NT ID"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter NT ID.";
                                    //ValError = false;
                                    objEntity.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["NT ID"].ToString().Trim()))
                                    {
                                        objEntity.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["NT ID"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["NT ID"].ToString().Trim(), @"[0-9]").Count > 0)
                                        {
                                            objEntity.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Only Special Characters are not allowed for NT ID.";
                                            ValError = false;
                                            objEntity.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
                                        }
                                    }
                                }
                                if (ValError == false)
                                {
                                    objEntity.ErrorString = sb.Append(message).ToString().Trim();
                                    objEntity.RecStatus = "Failed";
                                    //throw new Exception();
                                }
                                else
                                {
                                    objEntity.ErrorString = "N.A.";
                                    objEntity.RecStatus = "Success";
                                }
                                ///
                                //// CHECKING VALIDATION FOR EXCEL DATA    --->    END
                                ///
                                #endregion validation end

                                //String GolID = objEntity.GoalUpload_ID;
                                //string EmpCode = objEntity.EmployeeCode;
                                DataRow dr = dt_bulkTemp.NewRow();
                                dr["DEM_EU_ID"] = objEntity.EmpUpload_ID;
                                dr["DEM_ECODE"] = objEntity.Ecode;
                                dr["DEM_COMPANY_NAME"] = objEntity.Company_name.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_GENDER"] = objEntity.Gender.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_EMP_STATUS"] = objEntity.Emp_status.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_LWD"] = objEntity.Lwd.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_TNTR"] = objEntity.Tntr.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_EMP_NAME"] = objEntity.Emp_name.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_DESIGNATION"] = objEntity.Designation.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_BANDS"] = objEntity.Bands.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_DOJ"] = objEntity.Doj.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_LOCATION"] = objEntity.Location.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_DEPARTMENT"] = objEntity.Department.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_FUNCTION"] = objEntity.Function.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_COST_CENTRE"] = objEntity.Cost_centre.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_APP_CODE"] = objEntity.App_code.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_APPRAISER_NAME"] = objEntity.Appraiser_name.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_APP_BAND"] = objEntity.App_band.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_REV_CODE"] = objEntity.Rev_code.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_REVIEWER_NAME"] = objEntity.Reviewer_name.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_REV_BAND"] = objEntity.Rev_band.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_HOD_CODE"] = objEntity.Hod_code.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_HOD_NAME"] = objEntity.Hod_name.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_HOD_BAND"] = objEntity.Hod_band.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_BH_CODE"] = objEntity.Bh_code.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_BH_NAME"] = objEntity.Bh_name.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_INTERNAL"] = objEntity.Internal.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_EXTERNAL"] = objEntity.External.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_TOTAL"] = objEntity.Total.Replace("’", "'").Replace("'", "'").Replace("‘", "'").Replace("“", "&quot").Replace("”", "&quot").Replace("<", "&lsaquo;").Replace(">", "&rsaquo;");
                                dr["DEM_RecStatus"] = objEntity.RecStatus;
                                dr["DEM_UploadBy"] = objEntity.CreatedBy;
                                dr["DEM_ErrorString"] = objEntity.ErrorString;
                                dr["DEM_NT_ID"] = objEntity.Nt_ID;


                                dt_bulkTemp.Rows.Add(dr);

                                //DataTable dt_GURec = new DataTable();
                                //dt_GURec = objBal.addExcelDump(objEntity);
                                //objEntity.EmpUpload_ID = dt_GURec.Rows[0]["DEM_EU_ID"].ToString().Trim();

                                ValError = true;
                                message = "";
                                sb.Clear();
                                i = i + 1;
                            }
                        }
                    }

                string pathnew = Convert.ToString(ViewState["Path"]);
                string fname = Convert.ToString(ViewState["fileName"]);

                try
                {
                    dt_bulkTemp.ToCSV(strCSV);
                    ctlupload("abc1", "MyFolder/");

                    DataTable dt_getCount = new DataTable();
                    objEntity.EmpUpload_ID = Session["EMU_ID"].ToString();
                    dt_getCount = objBal.getRecCount(objEntity);
                    SuccessCountEx = Convert.ToInt32(dt_getCount.Rows[0]["SuccessCount"].ToString());

                    //DataTable dt_getCountFail = new DataTable();
                    //objEntity.EmpUpload_ID = Session["EMU_ID"].ToString();
                    //dt_getCountFail = objBal.getRecCount_Fail(objEntity);
                    if (dt_getCount.Rows[0]["FailedCount"] == null || dt_getCount.Rows[0]["FailedCount"].ToString() == "0")
                    {
                        //lblFailedTitle.Text = "";
                        //lblFailedCount.Text = "";
                        Div_FailRec.Visible = false;
                        btnExDown.Visible = false;
                        /// btnCSVDown.Visible = false;
                    }
                    else
                    {
                        lblFailedTitle.Text = "Failed:- ";
                        lblFailedCount.Text = dt_getCount.Rows[0]["FailedCount"].ToString().Trim() + " record(s) have been entered in wrong format, kindly check!";
                        btnExDown.Visible = true;
                        Div_FailRec.Visible = true;
                        // btnCSVDown.Visible = true;
                    }

                    if (SuccessCountEx > 0)
                    {
                        DataTable dt_addSuccessRec = new DataTable();
                        objEntity.EmpUpload_ID = Session["EMU_ID"].ToString();
                        dt_addSuccessRec = objBal.addSuccessData(objEntity);
                        SuccessCountMain = Convert.ToInt32(dt_addSuccessRec.Rows[0]["SuccessCountMain"].ToString());
                        if (SuccessCountMain == 0)
                        {
                           // lblSuccessTitle.Text = "Failed:-";
                            lblSuccessCount.Text = "No Record(s) found in correct format.";
                        }
                        else
                        {
                            SuccessDiv.Visible = true;
                            lblSuccessTitle.Text = "Success:-";
                            lblSuccessCount.Text = SuccessCountMain.ToString() + " record(s) have been entered successfully.";
                        }

                        overwriteFlag = false; //flag set false as code as been set as PK so there will be no multiple rec of emp in main table. so overwrite wont take place.
                        if (overwriteFlag == true)
                        {
                            SuccessDiv.Visible = true;
                            lblSuccessTitle.Text = "Success:-";
                            lblSuccessCount.Text = SuccessCountMain.ToString() + " record(s) have been updated successfully.";
                            DataTable dt_OverwriteGURec = new DataTable();
                            objEntity.EmpUpload_ID = Session["EMU_ID"].ToString();
                            objEntity.CreatedBy = Convert.ToInt32(Session["EmpId"].ToString());
                            dt_OverwriteGURec = objBal.updateOverwriteRec(objEntity);
                            objEntity.EmpUpload_ID = dt_OverwriteGURec.Rows[0]["updatedCount"].ToString().Trim();
                        }
                    }
                    else
                    {
                        //lblSuccessTitle.Text = "";
                        //lblSuccessCount.Text = "No Record found in correct format.";
                        SuccessDiv.Visible = false;
                    }
                    tablediv.Visible = true;
                    //btnimport.Visible = true;
                    btnimport1.Visible = true;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //  tablediv.Visible = true;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Excel Uploaded Successfully.');", true);
                //Response.Write("<script language='javascript'>window.alert('" + SuccessCountMain + " Record Uploaded Successfully. Failed to Upload " + lblFailedCount.Text + " Record.');window.location='HRMSUpload.aspx';</script>");

            }

            catch (Exception ex)
            {
                throw ex;
                tablediv.Visible = false;
            }
            finally
            {
                objEntity = null;
            }
            return status;
        }

        public void ExportToExcel(DataTable dtHistory)
        {
            string filename = "HRMSlUpload_FailedData_" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
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

        protected void downloadFailedRec(object sender, EventArgs e)
        {
            //show msg for fetching Failed Records of Excel name : tempdata and uploaded on : dateAndtime
            try
            {
                DataTable dt = new DataTable();
                objEntity.EmpUpload_ID = Session["EMU_ID"].ToString();
                dt = objBal.getFailedData(objEntity);
                if (dt == null)
                {
                    Response.Write("<script language='javascript'>window.alert('No Failed records found.');window.location='HRMSUpload.aspx';</script>");
                }
                else
                {
                    ViewState["DataHistory"] = dt;
                    ExportToExcel(dt);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>window.alert('No records found.');window.location='HRMSUpload.aspx';</script>");
            }
        }

        protected void uploadExcelData()
        {
            try
            {
                if (Convert.ToInt32(Session["EmpId"]) == 0)
                {
                    Response.Redirect("~/HRMSUpload.aspx");
                }
                else
                {
                    if (Request.Form["rdobtnAppendOverWrite"] != null)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Please select the option if you want to Append or Overwrite the data.');", true);
                        // lblUploadValidation.Visible = true;
                        //btnimport.Visible = true;
                        btnimport1.Visible = true;
                    }
                    else
                    {
                        // lblUploadValidation.Visible = false;
                        uploadDataFlag = "OverwriteData";// Request.Form["rdobtnAppendOverWrite"].ToString();
                        if (uploadDataFlag == "OverwriteData")
                        {
                            appendFlag = false;
                            overwriteFlag = true;
                        }
                        else                                                //(uploadDataFlag == "AppendData")
                        {
                            appendFlag = true;
                            overwriteFlag = false;
                        }

                        if (uploadfile.HasFile)
                        {
                            string fileuploadpath = Path.GetFullPath(uploadfile.PostedFile.FileName);
                            if (!string.IsNullOrEmpty(fileuploadpath))
                            {
                                ReadExcel();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Please select file to Upload.');", true);
                            tablediv.Visible = false;
                            //btnimport.Visible = true;
                            btnimport1.Visible = true;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Failed to Upload Record(s). Please Select the correct Excel File');", true);
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                tablediv.Visible = false;
                //btnimport.Visible = true;
                btnimport1.Visible = true;
            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Session["EmpId"]) == 0)
                {
                    Response.Redirect("~/HRMSUpload.aspx");
                }
                else
                {
                    uploadDataFormatFlag = "ExcelDownload";
                    if (uploadDataFormatFlag == "ExcelDownload")
                    {
                        //btnimport.Visible = false;
                        //btnimport1.Visible = false;
                        uploadExcelData();
                    }

                }
            }
            catch (Exception ex)
            {

            }

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
                //  string templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE DEMO fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(EMPLOYEECODE \"trim(:EMPLOYEECODE)\",OBJECTIVE \"trim(:OBJECTIVE)\",MEASURE \"trim(:MEASURE)\",TARGETTYPE \"trim(:TARGETTYPE)\",TARGET \"trim(:TARGET)\",TARGETWEIGHT \"trim(:TARGETWEIGHT)\")";
                string templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE tbl_dump_employeemaster fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(DEM_EU_ID \"trim(:DEM_EU_ID)\",DEM_ECODE \"trim(:DEM_ECODE)\",DEM_COMPANY_NAME \"trim(:DEM_COMPANY_NAME)\", DEM_GENDER \"trim(:DEM_GENDER)\",DEM_EMP_STATUS \"trim(:DEM_EMP_STATUS)\",DEM_LWD \"trim(:DEM_LWD)\",DEM_TNTR \"trim(:DEM_TNTR)\",DEM_EMP_NAME \"trim(:DEM_EMP_NAME)\",DEM_DESIGNATION \"trim(:DEM_DESIGNATION)\",DEM_BANDS \"trim(:DEM_BANDS)\"    ,DEM_DOJ \"trim(:DEM_DOJ)\",DEM_LOCATION \"trim(:DEM_LOCATION)\",DEM_DEPARTMENT \"trim(:DEM_DEPARTMENT)\",DEM_FUNCTION \"trim(:DEM_FUNCTION)\",DEM_COST_CENTRE \"trim(:DEM_COST_CENTRE)\",DEM_APP_CODE \"trim(:DEM_APP_CODE)\",DEM_APPRAISER_NAME \"trim(:DEM_APPRAISER_NAME)\",DEM_APP_BAND \"trim(:DEM_APP_BAND)\",DEM_REV_CODE \"trim(:DEM_REV_CODE)\",DEM_REVIEWER_NAME \"trim(:DEM_REVIEWER_NAME)\",DEM_REV_BAND \"trim(:DEM_REV_BAND)\",DEM_HOD_CODE \"trim(:DEM_HOD_CODE)\",DEM_HOD_NAME \"trim(:DEM_HOD_NAME)\",DEM_HOD_BAND \"trim(:DEM_HOD_BAND)\",DEM_BH_CODE \"trim(:DEM_BH_CODE)\",DEM_BH_NAME \"trim(:DEM_BH_NAME)\",DEM_INTERNAL \"trim(:DEM_INTERNAL)\",DEM_EXTERNAL \"trim(:DEM_EXTERNAL)\",DEM_TOTAL \"trim(:DEM_TOTAL)\",DEM_RecStatus \"trim(:DEM_RecStatus)\"    ,DEM_UploadBy \"trim(:DEM_UploadBy)\",DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_NT_ID \"trim(:DEM_NT_ID)\")";
                writer.WriteLine(templine);
                writer.Close();
            }
            catch (Exception ex)
            {

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
                    // Common.ShowJavascriptAlert("File Successfully Upload..!");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}