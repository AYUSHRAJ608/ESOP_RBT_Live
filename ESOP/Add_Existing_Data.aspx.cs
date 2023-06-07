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
using System.Globalization;

namespace ESOP
{
    public partial class Add_Existing_Data : System.Web.UI.Page
    {
        public int SuccRecords = 0;
        public int FailRecords = 0;
        public int TotalRecords = 0;
        GrandCreationBO objbo = new GrandCreationBO();
        GrandCreationBAL objbal = new GrandCreationBAL();
        FMVCreationBO objfmvbo = new FMVCreationBO();
        FMVCreationBAL objfmvbal = new FMVCreationBAL();
        vesting_creation_BO VestingBO;
        vesting_creation_BAL VestingBAL = new vesting_creation_BAL();
        string strCSV = System.Configuration.ConfigurationManager.AppSettings["CSV"];
        string ctlCOnn = System.Configuration.ConfigurationManager.AppSettings["ctl"];
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(Session["TotalRecords"] as string))
            //{
            //    TotalRecords = Convert.ToInt32(Session["TotalRecords"].ToString());
            //    SuccRecords = Convert.ToInt32(Session["SuccRecords"].ToString());
            //    FailRecords = Convert.ToInt32(Session["FailRecords"].ToString());
            //}
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            // if (ddlData.SelectedValue == "1")
            {
                ReadExcel();
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

            if (ddlData.SelectedValue == "1")
            {
                bool a = InsertFMVMastRec(exceldata);
            }
            if (ddlData.SelectedValue == "2")
            {
                bool a = InsertGrantMastRec(exceldata);
            }
            if (ddlData.SelectedValue == "3")
            {
                bool a = InsertValMasterRec(exceldata);
            }
            if (ddlData.SelectedValue == "4")
            {
                bool a = InsertVestingMasterRec(exceldata);
            }
            if (ddlData.SelectedValue == "5")
            {
                bool a = InsertEmployeeSaleRec(exceldata);
            }
            if (ddlData.SelectedValue == "6")
            {
                bool a = InsertEmployeeExcerciseRec(exceldata);
            }
            if (ddlData.SelectedValue == "7")
            {
                bool a = InsertGrantVestingRec(exceldata);
            }

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
        public bool InsertFMVMastRec(DataTable dt)
        {
            DataTable dt_bulkTemp = new DataTable();
            //dt_bulkTemp.Columns.Add("DEM_EU_ID");
            dt_bulkTemp.Columns.Add("DEM_EMP_ID");
            dt_bulkTemp.Columns.Add("DEM_GRANT_DATE");
            dt_bulkTemp.Columns.Add("DEM_VESTING_ID");
            dt_bulkTemp.Columns.Add("DEM_FMV_ID");
            dt_bulkTemp.Columns.Add("DEM_GRANT_NAME");
            dt_bulkTemp.Columns.Add("DEM_NO_OF_OPTION");
            dt_bulkTemp.Columns.Add("DEM_ErrorString");
            dt_bulkTemp.Columns.Add("DEM_RecStatus");

            dt_bulkTemp.Columns.Add("DEM_COMPANY_NAME");

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

                                if (dt.Rows[i]["Start Date"].ToString().Trim() == "")
                                {
                                    message = " Please enter Start Date";
                                    ValError = false;
                                    objbo.Doj = dt.Rows[i]["Start Date"].ToString().Trim();
                                }
                                else
                                {
                                    //if (regexItem.IsMatch(dt.Rows[i]["Start Date"].ToString().Trim()))
                                    //{
                                    //    objbo.EMP_ID = dt.Rows[i]["Start Date"].ToString().Trim();
                                    //}
                                    //else
                                    {

                                        if (Regex.Matches(dt.Rows[i]["Start Date"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                        {
                                            message = message + " Invalid Date format for Start Date";
                                            ValError = false;
                                            objbo.Doj = dt.Rows[i]["Start Date"].ToString().Trim();
                                        }
                                        else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["Start Date"].ToString().Trim()))
                                        {
                                            objbo.Doj = dt.Rows[i]["Start Date"].ToString().Trim();
                                            ValError = true;
                                        }
                                        else
                                        {
                                            message = message + " Invalid Date format for Start Date";
                                            ValError = false;
                                            objbo.Doj = dt.Rows[i]["Start Date"].ToString().Trim();
                                        }
                                    }
                                }

                                //------


                                if (dt.Rows[i]["End Date"].ToString().Trim() == "")
                                {
                                    message = " Please enter End Date";
                                    ValError = false;
                                    objbo.EMP_ID = dt.Rows[i]["End Date"].ToString().Trim();
                                }
                                else
                                {
                                    //if (regexItem.IsMatch(dt.Rows[i]["End Date"].ToString().Trim()))
                                    //{
                                    //    objbo.EMP_ID = dt.Rows[i]["End Date"].ToString().Trim();
                                    //}
                                    //else
                                    {

                                        if (Regex.Matches(dt.Rows[i]["End Date"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                        {
                                            message = message + " Invalid Date format for End Date";
                                            ValError = false;
                                            objbo.EMP_ID = dt.Rows[i]["End Date"].ToString().Trim();
                                        }
                                        else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["End Date"].ToString().Trim()))
                                        {
                                            objbo.EMP_ID = dt.Rows[i]["End Date"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + " Invalid Date format for End Date";
                                            ValError = false;
                                            objbo.EMP_ID = dt.Rows[i]["End Date"].ToString().Trim();
                                        }
                                    }
                                }

                                //------
                                if (dt.Rows[i]["FMV Price"].ToString().Trim() == "")
                                {

                                    message = "Please enter FMV Price";
                                    ValError = false;
                                    objbo.No_Of_Option_Excel = (dt.Rows[i]["FMV Price"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["FMV Price"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["FMV Price"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            objbo.No_Of_Option_Excel = dt.Rows[i]["FMV Price"].ToString().Trim();
                                        }
                                        else
                                        {

                                            objbo.No_Of_Option_Excel = dt.Rows[i]["FMV Price"].ToString().Trim();
                                        }
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["FMV Price"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["FMV Price"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["FMV Price"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
                                        {
                                            if (dt.Rows[i]["FMV Price"].ToString().Trim() == "0")
                                            {
                                                message = message + "Zero cant be added";
                                                ValError = false;
                                                objbo.No_Of_Option_Excel = dt.Rows[i]["FMV Price"].ToString().Trim();
                                            }
                                            else
                                            {
                                                objbo.No_Of_Option_Excel = (dt.Rows[i]["FMV Price"].ToString().Trim());
                                            }
                                        }
                                        else
                                        {
                                            message = message + " Only Numbers allowed for FMV Price";
                                            ValError = false;
                                            // objbo.NO_OF_OPTION = 0;
                                            objbo.No_Of_Option_Excel = dt.Rows[i]["FMV Price"].ToString().Trim();

                                        }
                                    }
                                }



                                //------------------------------------------------------------------------------------

                                if (dt.Rows[i]["Valued By Name"].ToString().Trim() == "")
                                {
                                    //if (message != "")
                                    //{
                                    //    message = message + " ";
                                    //}
                                    //message = message + " Please Enter Company Name.";
                                    //ValError = false;
                                    objbo.Company_name = dt.Rows[i]["Valued By Name"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["Valued By Name"].ToString().Trim()))
                                    {
                                        objbo.Company_name = dt.Rows[i]["Valued By Name"].ToString().Trim();
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Valued By Name"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["Valued By Name"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["Valued By Name"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
                                        {
                                            objbo.Company_name = dt.Rows[i]["Valued By Name"].ToString().Trim();
                                        }
                                        else
                                        {
                                            message = message + "  Only Numbers allowed for Valued By Name";
                                            ValError = false;
                                            objbo.Company_name = dt.Rows[i]["Valued By Name"].ToString().Trim();
                                        }
                                    }
                                }

                                //if (dt.Rows[i]["Value Name"].ToString().Trim() == "")
                                //{
                                //    //if (message != "")
                                //    //{
                                //    //    message = message + " ";
                                //    //}
                                //    //message = message + " Please Enter Company Name.";
                                //    //ValError = false;
                                //    objbo.Company_name = dt.Rows[i]["Value Name"].ToString().Trim();
                                //}
                                //else
                                //{
                                //    if (regexItem.IsMatch(dt.Rows[i]["Value Name"].ToString().Trim()))
                                //    {
                                //        objbo.Company_name = dt.Rows[i]["Value Name"].ToString().Trim();
                                //    }
                                //    else
                                //    {
                                //        if (Regex.Matches(dt.Rows[i]["Value Name"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["Value Name"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["Value Name"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
                                //        {
                                //            objbo.Company_name = dt.Rows[i]["Value Name"].ToString().Trim();
                                //        }
                                //        else
                                //        {
                                //            message = message + "  Only Numbers allowed for Valued By";
                                //            ValError = false;
                                //            objbo.Company_name = dt.Rows[i]["Value Name"].ToString().Trim();
                                //        }
                                //    }
                                //}
                                #region Commented Code
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

                                #endregion




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




                                dr["DEM_EMP_ID"] = objbo.Doj;
                                dr["DEM_GRANT_DATE"] = objbo.EMP_ID;

                                dr["DEM_GRANT_NAME"] = "1";
                                //////dr["DEM_GRANT_DATE"] = txtDateOfGrant.Text; //Convert.ToDateTime(txtDateOfGrant.Text);
                                //////dr["DEM_VESTING_ID"] = ddlVesting.SelectedValue;
                                //////dr["DEM_FMV_ID"] = ddlFMV.SelectedValue;
                                dr["DEM_NO_OF_OPTION"] = objbo.No_Of_Option_Excel;
                                dr["DEM_RecStatus"] = objbo.RecStatus;
                                dr["DEM_ErrorString"] = objbo.ErrorString;
                                dr["DEM_COMPANY_NAME"] = objbo.Company_name;


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

                ctlupload("abc1", "MyFolder/", "FMV");





                //Region Commented Code
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
                //EndRegion Commented Code

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
        //Region Commented method
        //public bool InsertGrantMastRec(DataTable dt)
        //{
        //    DataTable dt_bulkTemp = new DataTable();
        //    //dt_bulkTemp.Columns.Add("DEM_EU_ID");
        //    dt_bulkTemp.Columns.Add("DEM_EMP_ID");
        //    dt_bulkTemp.Columns.Add("DEM_GRANT_DATE");
        //    dt_bulkTemp.Columns.Add("DEM_VESTING_ID");
        //    dt_bulkTemp.Columns.Add("DEM_FMV_ID");
        //    dt_bulkTemp.Columns.Add("DEM_GRANT_NAME");
        //    dt_bulkTemp.Columns.Add("DEM_NO_OF_OPTION");
        //    dt_bulkTemp.Columns.Add("DEM_ErrorString");
        //    dt_bulkTemp.Columns.Add("DEM_RecStatus");

        //    ////////dt_bulkTemp.Columns.Add("DEM_EU_ID");
        //    ////////dt_bulkTemp.Columns.Add("DEM_ECODE");
        //    ////////dt_bulkTemp.Columns.Add("DEM_COMPANY_NAME");
        //    ////////dt_bulkTemp.Columns.Add("DEM_GENDER");
        //    ////////dt_bulkTemp.Columns.Add("DEM_EMP_STATUS");
        //    ////////dt_bulkTemp.Columns.Add("DEM_EMP_NAME");
        //    ////////dt_bulkTemp.Columns.Add("DEM_DESIGNATION");
        //    ////////dt_bulkTemp.Columns.Add("DEM_LOCATION");
        //    ////////dt_bulkTemp.Columns.Add("DEM_DEPARTMENT");
        //    ////////dt_bulkTemp.Columns.Add("DEM_APP_CODE");
        //    ////////dt_bulkTemp.Columns.Add("DEM_APPRAISER_NAME");
        //    ////////dt_bulkTemp.Columns.Add("DEM_DOJ");

        //    ////dt_bulkTemp.Columns.Add("DEM_GENDER");
        //    ////------------------------------------------------------------------------
        //    ////dt_bulkTemp.Columns.Add("DEM_EU_ID");
        //    ////dt_bulkTemp.Columns.Add("DEM_ECODE");
        //    ////dt_bulkTemp.Columns.Add("DEM_COMPANY_NAME");
        //    ////dt_bulkTemp.Columns.Add("DEM_GENDER");
        //    ////dt_bulkTemp.Columns.Add("DEM_EMP_STATUS");
        //    //dt_bulkTemp.Columns.Add("DEM_LWD");
        //    //dt_bulkTemp.Columns.Add("DEM_TNTR");
        //    ////dt_bulkTemp.Columns.Add("DEM_EMP_NAME");
        //    ////dt_bulkTemp.Columns.Add("DEM_DESIGNATION");
        //    //dt_bulkTemp.Columns.Add("DEM_BANDS");
        //    //dt_bulkTemp.Columns.Add("DEM_DOJ");
        //    //dt_bulkTemp.Columns.Add("DEM_LOCATION");
        //    //dt_bulkTemp.Columns.Add("DEM_DEPARTMENT");
        //    //dt_bulkTemp.Columns.Add("DEM_FUNCTION");
        //    //dt_bulkTemp.Columns.Add("DEM_COST_CENTRE");
        //    ////dt_bulkTemp.Columns.Add("DEM_APP_CODE");
        //    ////dt_bulkTemp.Columns.Add("DEM_APPRAISER_NAME");
        //    //dt_bulkTemp.Columns.Add("DEM_APP_BAND");
        //    //dt_bulkTemp.Columns.Add("DEM_REV_CODE");
        //    //dt_bulkTemp.Columns.Add("DEM_REVIEWER_NAME");
        //    //dt_bulkTemp.Columns.Add("DEM_REV_BAND");
        //    //dt_bulkTemp.Columns.Add("DEM_HOD_CODE");
        //    //dt_bulkTemp.Columns.Add("DEM_HOD_NAME");
        //    //dt_bulkTemp.Columns.Add("DEM_HOD_BAND");
        //    //dt_bulkTemp.Columns.Add("DEM_BH_CODE");
        //    //dt_bulkTemp.Columns.Add("DEM_BH_NAME");
        //    //dt_bulkTemp.Columns.Add("DEM_INTERNAL");
        //    //dt_bulkTemp.Columns.Add("DEM_EXTERNAL");
        //    //dt_bulkTemp.Columns.Add("DEM_TOTAL");
        //    ////dt_bulkTemp.Columns.Add("DEM_RecStatus");
        //    //dt_bulkTemp.Columns.Add("DEM_UploadBy");
        //    ////dt_bulkTemp.Columns.Add("DEM_ErrorString");
        //    //dt_bulkTemp.Columns.Add("DEM_NT_ID");



        //    //-----------------------------------------------------------------------------------

        //    SqlConnection con;
        //    //Boolean validate = true;
        //    string ErrorValidationMsg = "";
        //    bool status = false;
        //    string msg = "";
        //    bool ValError = true;
        //    string message = "";
        //    string errorMsg = "";
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    try
        //    {
        //        TotalRecords = dt.Rows.Count;
        //        if (dt.Rows.Count > 0)
        //        {
        //            int i = 0;
        //            foreach (DataColumn col in dt.Columns)
        //            {
        //                foreach (DataRow row in dt.Rows)
        //                {
        //                    if (dt.Rows.Count - 1 >= i)
        //                    {
        //                        //if (i == 0)
        //                        //{
        //                        //    objbo.CREATED_BY = Session["EmpId"].ToString(); // Convert.ToInt32(dt.Rows[i]["CREATED_BY"].ToString());
        //                        //}

        //                        //if (objbo.firstEntry == true)
        //                        //{
        //                        //    DataTable dt_getUGID = new DataTable();
        //                        //    dt_getUGID = objBal.fetchLastemuId(objbo);
        //                        //    objbo.EmpUpload_ID = dt_getUGID.Rows[0]["DEM_EU_ID"].ToString().Trim();
        //                        //    //objbo.EmpUpload_ID = 1;
        //                        //    Session["EMU_ID"] = objbo.EmpUpload_ID;
        //                        //    objbo.firstEntry = false;
        //                        //}

        //                        ///
        //                        //// CHECKING VALIDATION FOR EXCEL DATA    --->    START
        //                        ///
        //                        #region validation start

        //                        var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
        //                        var regexItem_varchar = new Regex("^[a-zA-Z]*$");
        //                        var regexItem_onlyNumeric = new Regex("^[0-9 ]*$");
        //                        var regexItem_decimal = new Regex("^[1-9]\\d*(\\.\\d{1,2})?$"); //("^[0-9 ]*$");
        //                        var regexDateDDMMYYYY = new Regex("^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[13-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$");

        //                        if (dt.Rows[i]["Date of Grant"].ToString().Trim() == "")
        //                        {
        //                            message = " Please enter Date of Grant";
        //                            ValError = false;
        //                            objbo.Doj = dt.Rows[i]["Date of Grant"].ToString().Trim();
        //                        }
        //                        else
        //                        {
        //                            if (Regex.Matches(dt.Rows[i]["Date of Grant"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
        //                            {
        //                                message = message + " Invalid Date format for Date of Grant";
        //                                ValError = false;
        //                                objbo.Doj = dt.Rows[i]["Date of Grant"].ToString().Trim();
        //                            }
        //                            else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["Date of Grant"].ToString().Trim()))
        //                            {
        //                                objbo.Doj = dt.Rows[i]["Date of Grant"].ToString().Trim();
        //                                ValError = true;
        //                            }
        //                            else
        //                            {
        //                                message = message + " Invalid Date format for Date of Grant";
        //                                ValError = false;
        //                                objbo.Doj = dt.Rows[i]["Date of Grant"].ToString().Trim();
        //                            }
        //                        }

        //                        //------


        //                        if (dt.Rows[i]["Grant Name"].ToString().Trim() == "")
        //                        {
        //                            message = " Please enter End Date";
        //                            ValError = false;
        //                            objbo.GRANT_NAME = dt.Rows[i]["Grant Name"].ToString().Trim();
        //                        }
        //                        else
        //                        {
        //                            if (Regex.Matches(dt.Rows[i]["Grant Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Grant Name"].ToString().Trim(), @"[0-9]").Count > 0)
        //                            {
        //                                objbo.GRANT_NAME = dt.Rows[i]["Grant Name"].ToString().Trim();
        //                            }
        //                            else
        //                            {
        //                                message = message + " Only Special Characters are not allowed for TNTR.";
        //                                ValError = false;
        //                                objbo.GRANT_NAME = dt.Rows[i]["Grant Name"].ToString().Trim();
        //                            }
        //                        }

        //                        //------
        //                        if (dt.Rows[i]["No Of Options"].ToString().Trim() == "")
        //                        {

        //                            message = "Please enter No Of Options";
        //                            ValError = false;
        //                            objbo.No_Of_Option_Excel = (dt.Rows[i]["No Of Options"].ToString().Trim());
        //                        }
        //                        else
        //                        {
        //                            if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["No Of Options"].ToString().Trim()))
        //                            {
        //                                if (Convert.ToInt32(dt.Rows[i]["No Of Options"].ToString().Trim()) == 0)
        //                                {
        //                                    message = message + "Zero cant be added";
        //                                    ValError = false;
        //                                    objbo.No_Of_Option_Excel = dt.Rows[i]["No Of Options"].ToString().Trim();
        //                                }
        //                                else
        //                                {

        //                                    objbo.No_Of_Option_Excel = dt.Rows[i]["No Of Options"].ToString().Trim();
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (Regex.Matches(dt.Rows[i]["No Of Option"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["No of Option"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["No of Option"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
        //                                {
        //                                    if (dt.Rows[i]["No Of Option"].ToString().Trim() == "0")
        //                                    {
        //                                        message = message + "Zero cant be added";
        //                                        ValError = false;
        //                                        objbo.No_Of_Option_Excel = dt.Rows[i]["No Of Option"].ToString().Trim();
        //                                    }
        //                                    else
        //                                    {
        //                                        objbo.No_Of_Option_Excel = (dt.Rows[i]["No Of Option"].ToString().Trim());
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    message = message + " Only Numbers allowed for No of Option";
        //                                    ValError = false;
        //                                    // objbo.NO_OF_OPTION = 0;
        //                                    objbo.No_Of_Option_Excel = dt.Rows[i]["No Of Option"].ToString().Trim();

        //                                }
        //                            }
        //                        }

        //                        //------
        //                        if (dt.Rows[i]["Employee ID"].ToString().Trim() == "")
        //                        {

        //                            message = "Please enter Employee ID";
        //                            ValError = false;
        //                            objbo.EMP_ID = (dt.Rows[i]["Employee ID"].ToString().Trim());
        //                        }
        //                        else
        //                        {
        //                            if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["Employee ID"].ToString().Trim()))
        //                            {
        //                                if (Convert.ToInt32(dt.Rows[i]["Employee ID"].ToString().Trim()) == 0)
        //                                {
        //                                    message = message + "Zero cant be added";
        //                                    ValError = false;
        //                                    objbo.EMP_ID = dt.Rows[i]["No Of Option"].ToString().Trim();
        //                                }
        //                                else
        //                                {

        //                                    objbo.EMP_ID = dt.Rows[i]["Employee ID"].ToString().Trim();
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (Regex.Matches(dt.Rows[i]["Employee ID"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["Employee ID"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["Employee ID"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
        //                                {
        //                                    if (dt.Rows[i]["Employee ID"].ToString().Trim() == "0")
        //                                    {
        //                                        message = message + "Zero cant be added";
        //                                        ValError = false;
        //                                        objbo.EMP_ID = dt.Rows[i]["Employee ID"].ToString().Trim();
        //                                    }
        //                                    else
        //                                    {
        //                                        objbo.EMP_ID = (dt.Rows[i]["Employee ID"].ToString().Trim());
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    message = message + " Only Numbers allowed for Employee ID";
        //                                    ValError = false;
        //                                    // objbo.NO_OF_OPTION = 0;
        //                                    objbo.EMP_ID = dt.Rows[i]["Employee ID"].ToString().Trim();

        //                                }
        //                            }
        //                        }


        //                        //------
        //                        if (dt.Rows[i]["FMV ID"].ToString().Trim() == "")
        //                        {

        //                            message = "Please enter FMV ID";
        //                            ValError = false;
        //                            objbo.Lwd = (dt.Rows[i]["FMV ID"].ToString().Trim());
        //                        }
        //                        else
        //                        {
        //                            if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["FMV ID"].ToString().Trim()))
        //                            {
        //                                if (Convert.ToInt32(dt.Rows[i]["FMV ID"].ToString().Trim()) == 0)
        //                                {
        //                                    message = message + "Zero cant be added";
        //                                    ValError = false;
        //                                    objbo.Lwd = dt.Rows[i]["No Of Option"].ToString().Trim();
        //                                }
        //                                else
        //                                {

        //                                    objbo.Lwd = dt.Rows[i]["FMV ID"].ToString().Trim();
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (Regex.Matches(dt.Rows[i]["FMV ID"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["FMV ID"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["FMV ID"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
        //                                {
        //                                    if (dt.Rows[i]["FMV ID"].ToString().Trim() == "0")
        //                                    {
        //                                        message = message + "Zero cant be added";
        //                                        ValError = false;
        //                                        objbo.Lwd = dt.Rows[i]["FMV ID"].ToString().Trim();
        //                                    }
        //                                    else
        //                                    {
        //                                        objbo.Lwd = (dt.Rows[i]["FMV ID"].ToString().Trim());
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    message = message + " Only Numbers allowed for FMV ID";
        //                                    ValError = false;
        //                                    // objbo.NO_OF_OPTION = 0;
        //                                    objbo.Lwd = dt.Rows[i]["FMV ID"].ToString().Trim();

        //                                }
        //                            }
        //                        }


        //                        //------
        //                        if (dt.Rows[i]["Vesting ID"].ToString().Trim() == "")
        //                        {

        //                            message = "Please enter Vesting ID";
        //                            ValError = false;
        //                            objbo.Tntr = (dt.Rows[i]["Vesting ID"].ToString().Trim());
        //                        }
        //                        else
        //                        {
        //                            if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["Vesting ID"].ToString().Trim()))
        //                            {
        //                                if (Convert.ToInt32(dt.Rows[i]["Vesting ID"].ToString().Trim()) == 0)
        //                                {
        //                                    message = message + "Zero cant be added";
        //                                    ValError = false;
        //                                    objbo.Tntr = dt.Rows[i]["No Of Option"].ToString().Trim();
        //                                }
        //                                else
        //                                {

        //                                    objbo.Tntr = dt.Rows[i]["Vesting ID"].ToString().Trim();
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (Regex.Matches(dt.Rows[i]["Vesting ID"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["Vesting ID"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["Vesting ID"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
        //                                {
        //                                    if (dt.Rows[i]["Vesting ID"].ToString().Trim() == "0")
        //                                    {
        //                                        message = message + "Zero cant be added";
        //                                        ValError = false;
        //                                        objbo.Tntr = dt.Rows[i]["Vesting ID"].ToString().Trim();
        //                                    }
        //                                    else
        //                                    {
        //                                        objbo.Tntr = (dt.Rows[i]["Vesting ID"].ToString().Trim());
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    message = message + " Only Numbers allowed for Vesting ID";
        //                                    ValError = false;
        //                                    // objbo.NO_OF_OPTION = 0;
        //                                    objbo.Tntr = dt.Rows[i]["Vesting ID"].ToString().Trim();

        //                                }
        //                            }
        //                        }
        //                        //------------------------------------------------------------------------------------

        //                        ////if (dt.Rows[i]["Company Name"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Company Name.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Company Name"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Company Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Company Name"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Company Name.";
        //                        ////            ValError = false;
        //                        ////            objbo.Company_name = dt.Rows[i]["Company Name"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        //////if (dt.Rows[i]["Gender"].ToString().Trim() == "")
        //                        //////{
        //                        //////    //if (message != "")
        //                        //////    //{
        //                        //////    //    message = message + " ";
        //                        //////    //}
        //                        //////    //message = message + " Please Enter Gender.";
        //                        //////    //ValError = false;
        //                        //////    objbo.Gender = dt.Rows[i]["Gender"].ToString().Trim();
        //                        //////}
        //                        //////else
        //                        //////{
        //                        //////    if (regexItem.IsMatch(dt.Rows[i]["Gender"].ToString().Trim()))
        //                        //////    {
        //                        //////        objbo.Gender = dt.Rows[i]["Gender"].ToString().Trim();
        //                        //////    }
        //                        //////    else
        //                        //////    {
        //                        //////        if (Regex.Matches(dt.Rows[i]["Gender"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Gender"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        //////        {
        //                        //////            objbo.Gender = dt.Rows[i]["Gender"].ToString().Trim();
        //                        //////        }
        //                        //////        else
        //                        //////        {
        //                        //////            message = message + " Only Special Characters are not allowed for Gender.";
        //                        //////            ValError = false;
        //                        //////            objbo.Gender = dt.Rows[i]["Gender"].ToString().Trim();
        //                        //////        }
        //                        //////    }
        //                        //////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Employee Status"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Employee Status.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Employee Status"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Employee Status"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Employee Status"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Employee Status.";
        //                        ////            ValError = false;
        //                        ////            objbo.Emp_status = dt.Rows[i]["Employee Status"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //

        //                        ////if (dt.Rows[i]["LWD"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter LWD.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (Regex.Matches(dt.Rows[i]["LWD"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
        //                        ////    {
        //                        ////        message = message + " Invalid Date format for LWD.";
        //                        ////        ValError = false;
        //                        ////        objbo.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
        //                        ////    }
        //                        ////    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["LWD"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        message = message + " Invalid Date format for Date of LWD.";
        //                        ////        ValError = false;
        //                        ////        objbo.Lwd = dt.Rows[i]["LWD"].ToString().Trim();
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["TNTR"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter TNTR.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["TNTR"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["TNTR"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["TNTR"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for TNTR.";
        //                        ////            ValError = false;
        //                        ////            objbo.Tntr = dt.Rows[i]["TNTR"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Employee Name"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Employee Name.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Employee Name"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Employee Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Employee Name"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Employee Name.";
        //                        ////            ValError = false;
        //                        ////            objbo.Emp_name = dt.Rows[i]["Employee Name"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Designation"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Designation.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Designation = dt.Rows[i]["Designation"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Designation"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Designation = dt.Rows[i]["Designation"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Designation"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Designation"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Designation = dt.Rows[i]["Designation"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Designation.";
        //                        ////            ValError = false;
        //                        ////            objbo.Designation = dt.Rows[i]["Designation"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Bands"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Bands.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Bands = dt.Rows[i]["Bands"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Bands"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Bands = dt.Rows[i]["Bands"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Bands"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Bands"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Bands = dt.Rows[i]["Bands"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Bands.";
        //                        ////            ValError = false;
        //                        ////            objbo.Bands = dt.Rows[i]["Bands"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Date of Joining"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter a Date of Joining.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (Regex.Matches(dt.Rows[i]["Date of Joining"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
        //                        ////    {
        //                        ////        message = message + " Invalid Date format for Date of Joining.";
        //                        ////        ValError = false;
        //                        ////        objbo.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
        //                        ////    }
        //                        ////    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["Date of Joining"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        message = message + " Invalid Date format for Date of Joining.";
        //                        ////        ValError = false;
        //                        ////        objbo.Doj = dt.Rows[i]["Date of Joining"].ToString().Trim();
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Location"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Location.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Location = dt.Rows[i]["Location"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Location"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Location = dt.Rows[i]["Location"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Location"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Location"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Location = dt.Rows[i]["Location"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Location.";
        //                        ////            ValError = false;
        //                        ////            objbo.Location = dt.Rows[i]["Location"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Department"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Department.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Department = dt.Rows[i]["Department"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Department"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Department = dt.Rows[i]["Department"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Department"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Department"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Department = dt.Rows[i]["Department"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Department.";
        //                        ////            ValError = false;
        //                        ////            objbo.Department = dt.Rows[i]["Department"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Function"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Function.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Function = dt.Rows[i]["Function"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Function"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Function = dt.Rows[i]["Function"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Function"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Function"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Function = dt.Rows[i]["Function"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Function.";
        //                        ////            ValError = false;
        //                        ////            objbo.Function = dt.Rows[i]["Function"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Cost Center"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Cost Center.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Cost Center"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Cost Center"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Cost Center"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Cost Center.";
        //                        ////            ValError = false;
        //                        ////            objbo.Cost_centre = dt.Rows[i]["Cost Center"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Appraiser Code"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Appraiser Code.";
        //                        ////    //ValError = false;
        //                        ////    objbo.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Appraiser Code"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Appraiser Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Appraiser Code"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Appraiser Code.";
        //                        ////            ValError = false;
        //                        ////            objbo.App_code = dt.Rows[i]["Appraiser Code"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Appraiser Band"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Appraiser Band.";
        //                        ////    //ValError = false;
        //                        ////    objbo.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Appraiser Band"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Appraiser Band"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Appraiser Band"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Appraiser Band.";
        //                        ////            ValError = false;
        //                        ////            objbo.App_band = dt.Rows[i]["Appraiser Band"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        ////if (dt.Rows[i]["Appraiser Name"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Appraiser Name.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Appraiser Name"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Appraiser Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Appraiser Name"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Appraiser Name.";
        //                        ////            ValError = false;
        //                        ////            objbo.Appraiser_name = dt.Rows[i]["Appraiser Name"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//
        //                        //
        //                        ////if (dt.Rows[i]["Reviewer Code"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Reviewer Code.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Reviewer Code"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Reviewer Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Reviewer Code"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Reviewer Code.";
        //                        ////            ValError = false;
        //                        ////            objbo.Rev_code = dt.Rows[i]["Reviewer Code"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Reviewer Name"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Reviewer Name.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Reviewer Name"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Reviewer Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Reviewer Name"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Reviewer Name.";
        //                        ////            ValError = false;
        //                        ////            objbo.Reviewer_name = dt.Rows[i]["Reviewer Name"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["Reviewer Band"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Reviewer Band.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["Reviewer Band"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["Reviewer Band"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Reviewer Band"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for Reviewer Band.";
        //                        ////            ValError = false;
        //                        ////            objbo.Rev_band = dt.Rows[i]["Reviewer Band"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["HOD Code"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter HOD Code.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["HOD Code"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["HOD Code"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["HOD Code"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for HOD Code.";
        //                        ////            ValError = false;
        //                        ////            objbo.Hod_code = dt.Rows[i]["HOD Code"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["HOD Name"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter HOD Name.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["HOD Name"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["HOD Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["HOD Name"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for HOD Name.";
        //                        ////            ValError = false;
        //                        ////            objbo.Hod_name = dt.Rows[i]["HOD Name"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["HOD Band"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter HOD Band.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["HOD Band"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["HOD Band"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["HOD Band"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for HOD Band.";
        //                        ////            ValError = false;
        //                        ////            objbo.Hod_band = dt.Rows[i]["HOD Band"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["BHCode"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter BHCode.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["BHCode"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["BHCode"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["BHCode"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for BHCode.";
        //                        ////            ValError = false;
        //                        ////            objbo.Bh_code = dt.Rows[i]["BHCode"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //
        //                        ////if (dt.Rows[i]["BHName"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter BHName.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["BHName"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["BHName"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["BHName"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for BHName.";
        //                        ////            ValError = false;
        //                        ////            objbo.Bh_name = dt.Rows[i]["BHName"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}
        //                        //=====//

        //                        //

        //                        ////if (dt.Rows[i]["Internal"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Internal value.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Internal = dt.Rows[i]["Internal"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem_decimal.IsMatch(dt.Rows[i]["Internal"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Internal = dt.Rows[i]["Internal"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        message = message + " Only Numeric value allowed for Internal.";
        //                        ////        ValError = false;
        //                        ////        objbo.Internal = dt.Rows[i]["Internal"].ToString().Trim(); ;
        //                        ////    }
        //                        ////}

        //                        ////if (dt.Rows[i]["External"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter External value.";
        //                        ////    //ValError = false;
        //                        ////    objbo.External = dt.Rows[i]["External"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem_decimal.IsMatch(dt.Rows[i]["External"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.External = dt.Rows[i]["External"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        message = message + " Only Numeric value allowed for External.";
        //                        ////        ValError = false;
        //                        ////        objbo.External = dt.Rows[i]["External"].ToString().Trim();
        //                        ////    }
        //                        ////}

        //                        ////if (dt.Rows[i]["Total"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter Total value.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Total = dt.Rows[i]["Total"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem_decimal.IsMatch(dt.Rows[i]["Total"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Total = dt.Rows[i]["Total"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        message = message + " Only Numeric value allowed for Total.";
        //                        ////        ValError = false;
        //                        ////        objbo.Total = dt.Rows[i]["Total"].ToString().Trim();
        //                        ////    }
        //                        ////}


        //                        ////if (dt.Rows[i]["NT ID"].ToString().Trim() == "")
        //                        ////{
        //                        ////    //if (message != "")
        //                        ////    //{
        //                        ////    //    message = message + " ";
        //                        ////    //}
        //                        ////    //message = message + " Please Enter NT ID.";
        //                        ////    //ValError = false;
        //                        ////    objbo.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (regexItem.IsMatch(dt.Rows[i]["NT ID"].ToString().Trim()))
        //                        ////    {
        //                        ////        objbo.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
        //                        ////    }
        //                        ////    else
        //                        ////    {
        //                        ////        if (Regex.Matches(dt.Rows[i]["NT ID"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["NT ID"].ToString().Trim(), @"[0-9]").Count > 0)
        //                        ////        {
        //                        ////            objbo.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
        //                        ////        }
        //                        ////        else
        //                        ////        {
        //                        ////            message = message + " Only Special Characters are not allowed for NT ID.";
        //                        ////            ValError = false;
        //                        ////            objbo.Nt_ID = dt.Rows[i]["NT ID"].ToString().Trim();
        //                        ////        }
        //                        ////    }
        //                        ////}






        //                        //-----------------------------------------------------------------------

        //                        if (ValError == false)
        //                        {
        //                            objbo.ErrorString = sb.Append(message).ToString().Trim();
        //                            objbo.RecStatus = "Failed";
        //                            FailRecords = FailRecords + 1;
        //                            //throw new Exception();
        //                        }
        //                        else
        //                        {
        //                            objbo.ErrorString = "N.A.";
        //                            objbo.RecStatus = "Success";
        //                            SuccRecords = SuccRecords + 1;
        //                        }
        //                        //
        //                        ///
        //                        //// CHECKING VALIDATION FOR EXCEL DATA    --->    END
        //                        ///
        //                        #endregion validation end

        //                        DataRow dr = dt_bulkTemp.NewRow();
        //                        //--------------------------------------------------------------------//-------------------------------------------------------------------------
        //                        ////dr["DEM_EU_ID"] = objbo.EmpUpload_ID;
        //                        ////dr["DEM_ECODE"] = objbo.Ecode;
        //                        ////dr["DEM_COMPANY_NAME"] = objbo.Company_name;
        //                        ////dr["DEM_GENDER"] = objbo.Gender;
        //                        ////dr["DEM_EMP_STATUS"] = objbo.Emp_status;
        //                        ////dr["DEM_LWD"] = objbo.Lwd;
        //                        ////dr["DEM_TNTR"] = objbo.Tntr;
        //                        ////dr["DEM_EMP_NAME"] = objbo.Emp_name;
        //                        ////dr["DEM_DESIGNATION"] = objbo.Designation;
        //                        ////dr["DEM_BANDS"] = objbo.Bands;
        //                        ////dr["DEM_DOJ"] = objbo.Doj;
        //                        ////dr["DEM_LOCATION"] = objbo.Location;
        //                        ////dr["DEM_DEPARTMENT"] = objbo.Department;
        //                        ////dr["DEM_FUNCTION"] = objbo.Function;
        //                        ////dr["DEM_COST_CENTRE"] = objbo.Cost_centre;
        //                        ////dr["DEM_APP_CODE"] = objbo.App_code;
        //                        ////dr["DEM_APPRAISER_NAME"] = objbo.Appraiser_name;
        //                        ////dr["DEM_APP_BAND"] = objbo.App_band;
        //                        ////dr["DEM_REV_CODE"] = objbo.Rev_code;
        //                        ////dr["DEM_REVIEWER_NAME"] = objbo.Reviewer_name;
        //                        ////dr["DEM_REV_BAND"] = objbo.Rev_band;
        //                        ////dr["DEM_HOD_CODE"] = objbo.Hod_code;
        //                        ////dr["DEM_HOD_NAME"] = objbo.Hod_name;
        //                        ////dr["DEM_HOD_BAND"] = objbo.Hod_band;
        //                        ////dr["DEM_BH_CODE"] = objbo.Bh_code;
        //                        ////dr["DEM_BH_NAME"] = objbo.Bh_name;
        //                        ////dr["DEM_INTERNAL"] = objbo.Internal;
        //                        ////dr["DEM_EXTERNAL"] = objbo.External;
        //                        ////dr["DEM_TOTAL"] = objbo.Total;
        //                        //////dr["DEM_RecStatus"] = objbo.RecStatus;
        //                        ////dr["DEM_UploadBy"] = objbo.CreatedBy;
        //                        //////dr["DEM_ErrorString"] = objbo.ErrorString;
        //                        ////dr["DEM_NT_ID"] = objbo.Nt_ID;

        //                        //////--------------------------------------------------------------------------
        //                        ////dr["DEM_EMP_ID"] = objbo.EMP_ID;
        //                        ////dr["DEM_GRANT_NAME"] = txtGrantName.Text;
        //                        ////dr["DEM_GRANT_DATE"] = txtDateOfGrant.Text;
        //                        ////dr["DEM_VESTING_ID"] = ddlVesting.SelectedIndex;
        //                        ////dr["DEM_FMV_ID"] = ddlFMV.SelectedIndex;
        //                        ////dr["DEM_NO_OF_OPTION"] = objbo.NO_OF_OPTION;
        //                        ////dr["DEM_RecStatus"] = objbo.RecStatus;
        //                        ////dr["DEM_ErrorString"] = objbo.ErrorString;
        //                        //-------------------------------------------------------------------------//-------------------------------------------------------------------------



        //                        ////////dr["DEM_EMP_ID"] = objbo.EMP_ID;
        //                        ////////dr["DEM_GRANT_DATE"] = txtDateOfGrant.Text;
        //                        ////////dr["DEM_VESTING_ID"] = ddlVesting.SelectedValue;
        //                        ////////dr["DEM_FMV_ID"] = ddlFMV.SelectedValue;
        //                        ////////dr["DEM_GRANT_NAME"] = txtGrantName.Text;
        //                        ////////dr["DEM_NO_OF_OPTION"] = objbo.NO_OF_OPTION;
        //                        ////////dr["DEM_ErrorString"] = objbo.ErrorString;
        //                        ////////dr["DEM_RecStatus"] = objbo.RecStatus;
        //                        ////////dr["DEM_EU_ID"] = objbo.EmpUpload_ID;
        //                        ////////dr["DEM_ECODE"] = objbo.Ecode;
        //                        ////////dr["DEM_COMPANY_NAME"] = objbo.Company_name;

        //                        ////////dr["DEM_GENDER"] = objbo.Gender;
        //                        ////////dr["DEM_EMP_STATUS"] = objbo.Emp_status;
        //                        ////////dr["DEM_EMP_NAME"] = objbo.Emp_name;
        //                        ////////dr["DEM_DESIGNATION"] = objbo.Designation;
        //                        ////////dr["DEM_LOCATION"] = objbo.Location;
        //                        ////////dr["DEM_DEPARTMENT"] = objbo.Department;
        //                        ////////dr["DEM_APP_CODE"] = objbo.App_code;
        //                        ////////dr["DEM_APPRAISER_NAME"] = objbo.Appraiser_name;
        //                        ////////dr["DEM_DOJ"] = objbo.Doj;




        //                        dr["DEM_EMP_ID"] = objbo.EMP_ID;
        //                        dr["DEM_GRANT_DATE"] = objbo.Doj;
        //                        dr["DEM_GRANT_NAME"] = objbo.GRANT_NAME;
        //                        dr["DEM_VESTING_ID"] = objbo.Lwd;
        //                        dr["DEM_FMV_ID"] = objbo.Tntr;
        //                        dr["DEM_NO_OF_OPTION"] = objbo.No_Of_Option_Excel;
        //                        dr["DEM_RecStatus"] = objbo.RecStatus;
        //                        dr["DEM_ErrorString"] = objbo.ErrorString;



        //                        //--------------------------------------------------------------

        //                        dt_bulkTemp.Rows.Add(dr);

        //                        ValError = true;
        //                        message = "";
        //                        sb.Clear();
        //                        i = i + 1;
        //                    }
        //                }
        //            }
        //        }

        //        //SuccRecords = TotalRecords - FailRecords;



        //        dt_bulkTemp.ToCSV(strCSV);

        //        ctlupload("abc1", "MyFolder/", "Grant");






        //        ////try
        //        ////{
        //        ////    DataTable dt_getCount = new DataTable();
        //        ////    objbo.EMP_ID = Session["EMU_ID"].ToString();
        //        ////    dt_getCount = objBal.getRecCount(objbo);
        //        ////    SuccessCountEx = Convert.ToInt32(dt_getCount.Rows[0]["SuccessCount"].ToString());

        //        ////    DataTable dt_getCountFail = new DataTable();
        //        ////    objbo.EMP_ID = Session["EMU_ID"].ToString();
        //        ////    dt_getCountFail = objBal.getRecCount_Fail(objbo);
        //        ////    if (dt_getCountFail.Rows[0]["FailedCount"] == null || dt_getCountFail.Rows[0]["FailedCount"].ToString() == "0")
        //        ////    {
        //        ////        //lblFailedTitle.Text = "";
        //        ////        //lblFailedCount.Text = "";
        //        ////        ////Div_FailRec.Visible = false;
        //        ////        //btnExDown.Visible = false;
        //        ////        /// btnCSVDown.Visible = false;
        //        ////    }
        //        ////    else
        //        ////    {
        //        ////        lblFailedTitle.Text = "Failed:- ";
        //        ////        lblFailedCount.Text = dt_getCountFail.Rows[0]["FailedCount"].ToString().Trim() + " record(s) have been entered in wrong format, kindly check!";
        //        ////        btnExDown.Visible = true;
        //        ////        Div_FailRec.Visible = true;
        //        ////        // btnCSVDown.Visible = true;
        //        ////    }

        //        ////    if (SuccessCountEx > 0)
        //        ////    {
        //        ////        DataTable dt_addSuccessRec = new DataTable();
        //        ////        objbo.EMP_ID = Session["EMU_ID"].ToString();
        //        ////        dt_addSuccessRec = objBal.addSuccessData(objbo);
        //        ////        SuccessCountMain = Convert.ToInt32(dt_addSuccessRec.Rows[0]["SuccessCountMain"].ToString());
        //        ////        if (SuccessCountMain == 0)
        //        ////        {
        //        ////            lblSuccessTitle.Text = "Success:-";
        //        ////            lblSuccessCount.Text = "No Record(s) found in correct format.";
        //        ////        }
        //        ////        else
        //        ////        {
        //        ////            lblSuccessTitle.Text = "Success:-";
        //        ////            lblSuccessCount.Text = SuccessCountMain.ToString() + " record(s) have been entered successfully.";
        //        ////        }
        //        ////        if (overwriteFlag == true)
        //        ////        {
        //        ////            lblSuccessTitle.Text = "Success:-";
        //        ////            lblSuccessCount.Text = SuccessCountMain.ToString() + " record(s) have been updated successfully.";
        //        ////            DataTable dt_OverwriteGURec = new DataTable();
        //        ////            objbo.EmpUpload_ID = Session["EMU_ID"].ToString();
        //        ////            objbo.CREATED_BY = Convert.ToInt32(Session["EmpId"].ToString());
        //        ////            dt_OverwriteGURec = objBal.updateOverwriteRec(objbo);
        //        ////            objbo.EmpUpload_ID = dt_OverwriteGURec.Rows[0]["updatedCount"].ToString().Trim();
        //        ////        }
        //        ////    }
        //        ////    else
        //        ////    {
        //        ////        lblSuccessTitle.Text = "Success:-";
        //        ////        lblSuccessCount.Text = "No Record found in correct format.";
        //        ////    }


        //        ////}
        //        ////catch (Exception ex)
        //        ////{
        //        ////    throw ex;
        //        ////}
        //        //  tablediv.Visible = true;
        //        //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Excel Uploaded Successfully.');", true);
        //        //Response.Write("<script language='javascript'>window.alert('" + SuccessCountMain + " Record Uploaded Successfully. Failed to Upload " + lblFailedCount.Text + " Record.');window.location='HRMSUpload.aspx';</script>");

        //    }

        //    catch (Exception ex)
        //    {
        //        string exmsg = ex.Message.ToString();
        //        if (exmsg.Contains(" does not belong to table"))
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myalert", "alert('Please check the columns name in Excel');", true);
        //            //ClientScript.RegisterStartupScript(this.GetType(), "myalertVal", "alert('Record cannot be Approved." + exmsg.ToString() + "');", true);
        //            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", exmsg, true);
        //        }
        //        else
        //        {
        //            Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //        }
        //        //throw ex;

        //    }
        //    finally
        //    {
        //        objbo = null;
        //    }
        //    return status;
        //}
        //EndRegion Commented method

        public bool InsertValMasterRec(DataTable dt)
        {
            DataTable dt_bulkTemp = new DataTable();
            dt_bulkTemp.Columns.Add("DEM_EMP_ID");
            dt_bulkTemp.Columns.Add("DEM_GRANT_DATE");
            dt_bulkTemp.Columns.Add("DEM_VESTING_ID");
            dt_bulkTemp.Columns.Add("DEM_FMV_ID");
            dt_bulkTemp.Columns.Add("DEM_GRANT_NAME");
            dt_bulkTemp.Columns.Add("DEM_NO_OF_OPTION");
            dt_bulkTemp.Columns.Add("DEM_ErrorString");
            dt_bulkTemp.Columns.Add("DEM_RecStatus");

            SqlConnection con;
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
                                #region validation start
                                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                                var regexItem_varchar = new Regex("^[a-zA-Z]*$");
                                var regexItem_onlyNumeric = new Regex("^[0-9 ]*$");
                                var regexItem_decimal = new Regex("^[1-9]\\d*(\\.\\d{1,2})?$"); //("^[0-9 ]*$");
                                var regexDateDDMMYYYY = new Regex("^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[13-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$");

                                if (dt.Rows[i]["AGENCY_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter AGENCY NAME";
                                    ValError = false;
                                    objbo.GRANT_NAME = "NA";
                                }
                                else
                                {
                                    if (!regexItem.IsMatch(dt.Rows[i]["AGENCY_NAME"].ToString().Trim()))
                                    {
                                        message = "Special characters not allowed in AGENCY NAME";
                                        objbo.GRANT_NAME = dt.Rows[i]["AGENCY_NAME"].ToString().Trim();
                                        ValError = false;
                                    }
                                    else
                                    {
                                        if (regexItem.IsMatch(dt.Rows[i]["AGENCY_NAME"].ToString().Trim()))
                                        {
                                            objbo.GRANT_NAME = dt.Rows[i]["AGENCY_NAME"].ToString().Trim();
                                            //  ValError = true;
                                        }
                                    }
                                }

                                if (dt.Rows[i]["AGENCY_ADDRESS"].ToString().Trim() == "")
                                {
                                    message = " Please enter AGENCY ADDRESS";
                                    ValError = false;
                                    objbo.Location = "NA";
                                }
                                else
                                {
                                    if (!regexItem.IsMatch(dt.Rows[i]["AGENCY_ADDRESS"].ToString().Trim()))
                                    {
                                        message = "Special characters not allowed in AGENCY ADDRESS";
                                        objbo.Location = dt.Rows[i]["AGENCY_ADDRESS"].ToString().Trim();
                                        ValError = false;
                                    }
                                    else
                                    {
                                        if (regexItem.IsMatch(dt.Rows[i]["AGENCY_ADDRESS"].ToString().Trim()))
                                        {
                                            objbo.Location = dt.Rows[i]["AGENCY_ADDRESS"].ToString().Trim();
                                        }
                                    }
                                }

                                if (ValError == false)
                                {
                                    objbo.ErrorString = sb.Append(message).ToString().Trim();
                                    objbo.RecStatus = "Failed";
                                    FailRecords = FailRecords + 1;
                                }
                                else
                                {
                                    objbo.ErrorString = "N.A.";
                                    objbo.RecStatus = "Success";
                                    SuccRecords = SuccRecords + 1;
                                }
                                #endregion validation end

                                DataRow dr = dt_bulkTemp.NewRow();
                                dr["DEM_EMP_ID"] = Convert.ToString(Session["ECode"]);
                                dr["DEM_GRANT_DATE"] = "1";
                                dr["DEM_GRANT_NAME"] = objbo.GRANT_NAME;
                                dr["DEM_VESTING_ID"] = objbo.Location;
                                dr["DEM_RecStatus"] = objbo.RecStatus;
                                dr["DEM_ErrorString"] = objbo.ErrorString;
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
                ctlupload("abc1", "MyFolder/", "VALUATION");
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
                objbo = null;
            }
            return status;
        }

        public bool InsertVestingMasterRec(DataTable dt)
        {
            DataTable dt_bulkTemp = new DataTable();
            dt_bulkTemp.Columns.Add("DEM_EMP_ID");
            dt_bulkTemp.Columns.Add("DEM_GRANT_DATE");
            dt_bulkTemp.Columns.Add("DEM_VESTING_ID");
            dt_bulkTemp.Columns.Add("DEM_FMV_ID");
            dt_bulkTemp.Columns.Add("DEM_GRANT_NAME");
            dt_bulkTemp.Columns.Add("DEM_NO_OF_OPTION");
            dt_bulkTemp.Columns.Add("DEM_ErrorString");
            dt_bulkTemp.Columns.Add("DEM_RecStatus");
            dt_bulkTemp.Columns.Add("DEM_EU_ID");

            SqlConnection con;
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
                                #region validation start
                                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                                var regexItem_varchar = new Regex("^[a-zA-Z]*$");
                                var regexItem_onlyNumeric = new Regex("^[0-9 ]*$");
                                var regexItem_decimal = new Regex("^[1-9]\\d*(\\.\\d{1,2})?$"); //("^[0-9 ]*$");
                                var regexDateDDMMYYYY = new Regex("^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[13-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$");

                                if (dt.Rows[i]["Vesting_Name"].ToString().Trim() == "")
                                {
                                    message = message + " Please enter VESTING NAME";
                                    ValError = false;
                                    objbo.GRANT_NAME = dt.Rows[i]["Vesting_Name"].ToString().Trim();
                                }
                                else
                                {
                                    if (!regexItem.IsMatch(dt.Rows[i]["Vesting_Name"].ToString().Trim()))
                                    {
                                        message = " Special character not allowed in VESTING NAME.";
                                        objbo.GRANT_NAME = dt.Rows[i]["Vesting_Name"].ToString().Trim();
                                        ValError = false;
                                    }
                                    else
                                    {

                                        if (regexItem.IsMatch(dt.Rows[i]["Vesting_Name"].ToString().Trim()))
                                        {
                                            objbo.GRANT_NAME = dt.Rows[i]["Vesting_Name"].ToString().Trim();
                                            //   ValError = true;
                                        }
                                    }
                                }

                                if (dt.Rows[i]["No_Of_Cycle"].ToString().Trim() == "")
                                {
                                    message = message + " Please enter No of Cycle";
                                    ValError = false;
                                    objbo.No_Of_Option_Excel = dt.Rows[i]["No_Of_Cycle"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["No_Of_Cycle"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["No_Of_Cycle"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            objbo.No_Of_Option_Excel = dt.Rows[i]["No_Of_Cycle"].ToString().Trim();
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["No_Of_Cycle"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero";
                                            ValError = false;
                                            objbo.No_Of_Option_Excel = dt.Rows[i]["No_Of_Cycle"].ToString().Trim();
                                        }
                                        else
                                        {
                                            objbo.No_Of_Option_Excel = dt.Rows[i]["No_Of_Cycle"].ToString().Trim();
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed";
                                        ValError = false;
                                        objbo.No_Of_Option_Excel = dt.Rows[i]["No_Of_Cycle"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["Vesting_Cycle_Name"].ToString().Trim() == "")
                                {
                                    message = message + " Please enter Vesting Cycle Name";
                                    ValError = false;
                                    objbo.Location = dt.Rows[i]["Vesting_Cycle_Name"].ToString().Trim();
                                }
                                else
                                {
                                    if (!regexItem.IsMatch(dt.Rows[i]["Vesting_Cycle_Name"].ToString().Trim()))
                                    {
                                        message = " Special character not allowed in Vesting Cycle Name";
                                        objbo.Location = dt.Rows[i]["Vesting_Cycle_Name"].ToString().Trim();
                                        ValError = false;
                                    }
                                    else
                                    {
                                        if (regexItem.IsMatch(dt.Rows[i]["Vesting_Cycle_Name"].ToString().Trim()))
                                        {
                                            objbo.Location = dt.Rows[i]["Vesting_Cycle_Name"].ToString().Trim();
                                            //   ValError = true;
                                        }
                                    }
                                }

                                if (dt.Rows[i]["Percentage"].ToString().Trim() == "")
                                {
                                    message = message + " Please enter Percentage";
                                    ValError = false;
                                    objbo.Gender = dt.Rows[i]["Percentage"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["Percentage"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["Percentage"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            objbo.Gender = dt.Rows[i]["Percentage"].ToString().Trim();
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["Percentage"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero";
                                            ValError = false;
                                            objbo.Gender = dt.Rows[i]["Percentage"].ToString().Trim();
                                        }
                                        else
                                        {

                                            objbo.Gender = dt.Rows[i]["Percentage"].ToString().Trim();
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed";
                                        ValError = false;
                                        objbo.Gender = dt.Rows[i]["Percentage"].ToString().Trim();
                                    }
                                }


                                if (dt.Rows[i]["Duration"].ToString().Trim() == "")
                                {
                                    message = message + " Please enter Duration";
                                    ValError = false;
                                    objbo.Doj = dt.Rows[i]["Duration"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["Duration"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["Duration"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            objbo.Doj = dt.Rows[i]["Duration"].ToString().Trim();
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["Duration"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero";
                                            ValError = false;
                                            objbo.Doj = dt.Rows[i]["Duration"].ToString().Trim();
                                        }
                                        else
                                        {
                                            objbo.Doj = dt.Rows[i]["Duration"].ToString().Trim();
                                            //  ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed";
                                        ValError = false;
                                        objbo.Doj = dt.Rows[i]["Duration"].ToString().Trim();
                                    }
                                }

                                if (ValError == false)
                                {
                                    objbo.ErrorString = sb.Append(message).ToString().Trim();
                                    objbo.RecStatus = "Failed";
                                    FailRecords = FailRecords + 1;
                                }
                                else
                                {
                                    objbo.ErrorString = "N.A.";
                                    objbo.RecStatus = "Success";
                                    SuccRecords = SuccRecords + 1;
                                }
                                #endregion validation end

                                DataRow dr = dt_bulkTemp.NewRow();
                                dr["DEM_EMP_ID"] = Convert.ToString(Session["ECode"]);
                                dr["DEM_GRANT_DATE"] = objbo.Location;//Vesting cycle name
                                dr["DEM_GRANT_NAME"] = objbo.GRANT_NAME;//Vesting Name
                                dr["DEM_VESTING_ID"] = objbo.No_Of_Option_Excel;//No of cycle
                                dr["DEM_FMV_ID"] = objbo.Doj;//Duration
                                dr["DEM_NO_OF_OPTION"] = objbo.Gender;//Percentage                                                                 
                                dr["DEM_RecStatus"] = objbo.RecStatus;
                                dr["DEM_ErrorString"] = objbo.ErrorString;
                                dr["DEM_EU_ID"] = "";
                                dt_bulkTemp.Rows.Add(dr);

                                ValError = true;
                                message = "";
                                sb.Clear();
                                i = i + 1;
                            }
                        }
                    }
                }
                vesting_creation_BAL VestingBAL = new vesting_creation_BAL();
                DataSet DS = VestingBAL.GET_VESTING_MASTER_ID();
                int VID = 0;
                if (DS.Tables[0].Rows.Count > 0)
                {
                    VID = Convert.ToInt32(DS.Tables[0].Rows[0][0]);
                }

                DataView view = new DataView(dt_bulkTemp);
                view.RowFilter = "DEM_RecStatus = 'Success'";
                DataTable Dt1 = new DataTable();
                Dt1 = view.ToTable(true, "DEM_GRANT_NAME");


                if (Dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt1.Rows.Count; i++)
                    {
                        dt_bulkTemp.Select(string.Format("[DEM_GRANT_NAME] = '{0}' and [DEM_RecStatus]>='{1}' ", Dt1.Rows[i][0].ToString(), "Success")).ToList<DataRow>().ForEach(r => r["DEM_EU_ID"] = VID);
                        VID++;
                    }
                }
                dt_bulkTemp.AcceptChanges();
                dt_bulkTemp.ToCSV(strCSV);
                ctlupload("abc1", "MyFolder/", "VESTING");
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
                objbo = null;
            }
            return status;
        }

        public bool InsertEmployeeSaleRec(DataTable dt)
        {
            DataTable dt_bulkTemp = new DataTable();

            dt_bulkTemp.Columns.Add("ECODE");
            dt_bulkTemp.Columns.Add("ENAME");

            dt_bulkTemp.Columns.Add("GRANT_NAME");
            dt_bulkTemp.Columns.Add("VESTING_DETAIL_CODE");
            dt_bulkTemp.Columns.Add("VESTING_DATE");

            dt_bulkTemp.Columns.Add("NO_OF_VESTING");
            dt_bulkTemp.Columns.Add("GRANT_PRICE");
            dt_bulkTemp.Columns.Add("EXERCISE_FMV_PRICE");
            dt_bulkTemp.Columns.Add("SALE_FMV_PRICE");
            dt_bulkTemp.Columns.Add("NO_OF_SALE");
            dt_bulkTemp.Columns.Add("SALE_DATE");

            dt_bulkTemp.Columns.Add("SECURITY_NAME");
            dt_bulkTemp.Columns.Add("DPID");
            dt_bulkTemp.Columns.Add("CLIENT_ID");
            dt_bulkTemp.Columns.Add("MEMBER_TYPE");

            dt_bulkTemp.Columns.Add("BANK_NAME");
            dt_bulkTemp.Columns.Add("BANK_BRANCH");
            dt_bulkTemp.Columns.Add("ACC_NO");
            dt_bulkTemp.Columns.Add("IFSC");

            dt_bulkTemp.Columns.Add("SALE_OFFER_FILE_PATH");
            dt_bulkTemp.Columns.Add("SALE_DECLARATION_FILE_PATH");
            dt_bulkTemp.Columns.Add("SALE_TRAN_ID");


            dt_bulkTemp.Columns.Add("CREATEDBY");
            dt_bulkTemp.Columns.Add("DEM_ErrorString");
            dt_bulkTemp.Columns.Add("DEM_RecStatus");


            SqlConnection con;
            string ErrorValidationMsg = "";
            bool status = false;
            string msg = "";
            bool ValError = true;
            string message = "";
            employee_saleBO Emp_sale_BO = new employee_saleBO();
            employee_saleBAL Emp_sale_BAL = new employee_saleBAL();
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
                                #region validation start
                                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                                var regexItem_varchar = new Regex("^[a-zA-Z]*$");
                                var regexItem_onlyNumeric = new Regex("^[0-9 ]*$");
                                var regexItem_decimal = new Regex("^[1-9]\\d*(\\.\\d{1,2})?$"); //("^[0-9 ]*$");
                                var regexDateDDMMYYYY = new Regex("^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[13-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$");

                                if (dt.Rows[i]["EMP_CODE"].ToString().Trim() == "")
                                {
                                    message = " Please enter Employee Code";
                                    ValError = false;
                                    // Emp_sale_BO.ECODE = dt.Rows[i]["EMP_CODE"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["EMP_CODE"].ToString().Trim()))
                                    {
                                        Emp_sale_BO.ECODE = dt.Rows[i]["EMP_CODE"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["EMP_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter Employee Name";
                                    ValError = false;
                                    // Emp_sale_BO._ENAME = dt.Rows[i]["EMP_NAME"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["EMP_NAME"].ToString().Trim()))
                                    {
                                        Emp_sale_BO._ENAME = dt.Rows[i]["EMP_NAME"].ToString().Trim();
                                        //  ValError = true;
                                    }
                                    else
                                    {
                                        Emp_sale_BO._ENAME = dt.Rows[i]["EMP_NAME"].ToString().Trim();
                                        //  ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["GRANT_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter GRANT NAME";
                                    ValError = false;
                                    //  Emp_sale_BO._GRANT_NAME = dt.Rows[i]["GRANT_NAME"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["GRANT_NAME"].ToString().Trim()))
                                    {
                                        Emp_sale_BO._GRANT_NAME = dt.Rows[i]["GRANT_NAME"].ToString().Trim();
                                        //  ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["VESTING_DETAIL_CODE"].ToString().Trim() == "")
                                {
                                    message = " Please enter VESTING DETAIL CODE";
                                    ValError = false;
                                    // Emp_sale_BO._VESTING_DETAIL_CODE = dt.Rows[i]["VESTING_DETAIL_CODE"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["VESTING_DETAIL_CODE"].ToString().Trim()))
                                    {
                                        Emp_sale_BO._VESTING_DETAIL_CODE = dt.Rows[i]["VESTING_DETAIL_CODE"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }


                                if (dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim() == "")
                                {
                                    message = " Please enter VESTING Date";
                                    ValError = false;
                                    // Emp_sale_BO._Str_VESTING_DATE = dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim();
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                    {
                                        message = message + " Invalid Date format for VESTING Date";
                                        ValError = false;
                                        //  Emp_sale_BO._Str_VESTING_DATE = dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim()))
                                    {
                                        Emp_sale_BO._Str_VESTING_DATE = dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim();
                                        ///   ValError = true;
                                    }
                                    else
                                    {
                                        message = message + " Invalid Date format for VESTING Date";
                                        ValError = false;
                                        //   Emp_sale_BO._Str_VESTING_DATE = dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["NO_OF_VESTING"].ToString().Trim() == "")
                                {
                                    message = " Please enter No of Vesting";
                                    ValError = false;
                                    // Emp_sale_BO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim());
                                }
                                else
                                {

                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in NO OF VESTING";
                                            ValError = false;
                                            //   Emp_sale_BO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["NO_OF_VESTING"]);
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in NO OF VESTING";
                                            ValError = false;
                                            //    Emp_sale_BO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim());
                                        }
                                        else
                                        {
                                            Emp_sale_BO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim());
                                            //    ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in NO OF VESTING";
                                        ValError = false;
                                        //  Emp_sale_BO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim());
                                    }
                                }

                                if (dt.Rows[i]["EXERCISE_FMV_PRICE"].ToString().Trim() == "")
                                {
                                    message = " Please enter EXERCISE FMV PRICE";
                                    ValError = false;
                                    // Emp_sale_BO._EXERCISE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["EXERCISE_FMV_PRICE"].ToString().Trim());
                                }
                                else
                                {

                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["EXERCISE_FMV_PRICE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["EXERCISE_FMV_PRICE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in EXERCISE FMV PRICE";
                                            ValError = false;
                                            // Emp_sale_BO._EXERCISE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["EXERCISE_FMV_PRICE"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["EXERCISE_FMV_PRICE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in EXERCISE FMV PRICE";
                                            ValError = false;
                                            //  Emp_sale_BO._EXERCISE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["EXERCISE_FMV_PRICE"].ToString().Trim());
                                        }
                                        else
                                        {
                                            Emp_sale_BO._EXERCISE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["EXERCISE_FMV_PRICE"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in EXERCISE FMV PRICE";
                                        ValError = false;
                                        // Emp_sale_BO._EXERCISE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["EXERCISE_FMV_PRICE"].ToString().Trim());
                                    }
                                }



                                if (dt.Rows[i]["GRANT_PRICE"].ToString().Trim() == "")
                                {
                                    message = " Please enter GRANT PRICE";
                                    ValError = false;
                                    // Emp_sale_BO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_PRICE"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["GRANT_PRICE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["GRANT_PRICE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in Grant PRICE";
                                            ValError = false;
                                            //Emp_sale_BO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_PRICE"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["GRANT_PRICE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in Grant PRICE";
                                            ValError = false;
                                            //Emp_sale_BO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_PRICE"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_sale_BO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_PRICE"].ToString().Trim());
                                            //ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in Grant PRICE";
                                        ValError = false;
                                        //Emp_sale_BO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_PRICE"].ToString().Trim());
                                    }
                                }


                                if (dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim() == "")
                                {
                                    message = " Please enter SALE FMV PRICE";
                                    ValError = false;
                                    //Emp_sale_BO._SALE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in SALE FMV PRICE";
                                            ValError = false;
                                            //Emp_sale_BO._SALE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in SALE FMV PRICE";
                                            ValError = false;
                                            //Emp_sale_BO._SALE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim());
                                        }
                                        else
                                        {
                                            Emp_sale_BO._SALE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim());
                                            //ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in SALE FMV PRICE";
                                        ValError = false;
                                        //Emp_sale_BO._SALE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim());
                                    }
                                }


                                if (dt.Rows[i]["NO_OF_SALE"].ToString().Trim() == "")
                                {
                                    message = " Please enter No Of Sale";
                                    ValError = false;
                                    //Emp_sale_BO._NO_OF_SALE = Convert.ToDouble(dt.Rows[i]["NO_OF_SALE"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["NO_OF_SALE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["NO_OF_SALE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in No Of Sale";
                                            ValError = false;
                                            //Emp_sale_BO._NO_OF_SALE = Convert.ToDouble(dt.Rows[i]["NO_OF_SALE"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["NO_OF_SALE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in No Of Sale";
                                            ValError = false;
                                            //Emp_sale_BO._NO_OF_SALE = Convert.ToDouble(dt.Rows[i]["NO_OF_SALE"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_sale_BO._NO_OF_SALE = Convert.ToDouble(dt.Rows[i]["NO_OF_SALE"].ToString().Trim());
                                            //ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in No Of Sale";
                                        ValError = false;
                                        //Emp_sale_BO._NO_OF_SALE = Convert.ToDouble(dt.Rows[i]["NO_OF_SALE"].ToString().Trim());
                                    }
                                }

                                if (dt.Rows[i]["SALE_DATE(DD-MM-YYYY)"].ToString().Trim() == "")
                                {
                                    message = " Please enter SALE Date";
                                    ValError = false;
                                    //Emp_sale_BO._STR_SALE_DATE = dt.Rows[i]["SALE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["SALE_DATE(DD-MM-YYYY)"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                    {
                                        message = message + " Invalid Date format for SALE Date";
                                        ValError = false;
                                        //Emp_sale_BO._STR_SALE_DATE = dt.Rows[i]["SALE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["SALE_DATE(DD-MM-YYYY)"].ToString().Trim()))
                                    {
                                        Emp_sale_BO._STR_SALE_DATE = dt.Rows[i]["SALE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                        //ValError = true;
                                    }
                                    else
                                    {
                                        message = message + " Invalid Date format for SALE Date";
                                        ValError = false;
                                        //Emp_sale_BO._STR_SALE_DATE = dt.Rows[i]["SALE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                }



                                if (dt.Rows[i]["SECURITY_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter SECURITY NAME";
                                    ValError = false;
                                    // Emp_sale_BO._SECURITY_NAME = dt.Rows[i]["SECURITY_NAME"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["SECURITY_NAME"].ToString().Trim()))
                                    {
                                        Emp_sale_BO._SECURITY_NAME = dt.Rows[i]["SECURITY_NAME"].ToString().Trim();
                                        //ValError = true;
                                    }
                                }


                                if (dt.Rows[i]["DPID"].ToString().Trim() == "")
                                {
                                    message = " Please enter DPID";
                                    ValError = false;
                                    // Emp_sale_BO.DPID = dt.Rows[i]["DPID"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["DPID"].ToString().Trim()))
                                    {
                                        Emp_sale_BO.DPID = dt.Rows[i]["DPID"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["CLIENT_ID"].ToString().Trim() == "")
                                {
                                    message = " Please enter CLIENT ID";
                                    ValError = false;
                                    //Emp_sale_BO.CLIENT_ID = dt.Rows[i]["CLIENT_ID"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["CLIENT_ID"].ToString().Trim()))
                                    {
                                        Emp_sale_BO.CLIENT_ID = dt.Rows[i]["CLIENT_ID"].ToString().Trim();
                                        //ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["MEMBER_TYPE"].ToString().Trim() == "")
                                {
                                    message = " Please enter MEMBER TYPE";
                                    ValError = false;
                                    //Emp_sale_BO.MEMBER_TYPE = dt.Rows[i]["MEMBER_TYPE"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["MEMBER_TYPE"].ToString().Trim()))
                                    {
                                        Emp_sale_BO.MEMBER_TYPE = dt.Rows[i]["MEMBER_TYPE"].ToString().Trim();
                                        //ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["BANK_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter BANK NAME";
                                    ValError = false;
                                    //Emp_sale_BO._BANK_NAME = dt.Rows[i]["BANK_NAME"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["BANK_NAME"].ToString().Trim()))
                                    {
                                        Emp_sale_BO._BANK_NAME = dt.Rows[i]["BANK_NAME"].ToString().Trim();
                                        //ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["BANK_BRANCH"].ToString().Trim() == "")
                                {
                                    message = " Please enter BANK BRANCH";
                                    ValError = false;
                                    // Emp_sale_BO._BANK_BRANCH = dt.Rows[i]["BANK_BRANCH"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["BANK_BRANCH"].ToString().Trim()))
                                    {
                                        Emp_sale_BO._BANK_BRANCH = dt.Rows[i]["BANK_BRANCH"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["ACC_NO"].ToString().Trim() == "")
                                {
                                    message = " Please enter Account NO";
                                    ValError = false;
                                    //Emp_sale_BO._ACC_NO = dt.Rows[i]["ACC_NO"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["ACC_NO"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt64(dt.Rows[i]["ACC_NO"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in Account NO";
                                            ValError = false;
                                            //Emp_sale_BO._ACC_NO = dt.Rows[i]["ACC_NO"].ToString().Trim();
                                        }
                                        else if (Convert.ToInt64(dt.Rows[i]["ACC_NO"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in Account NO";
                                            ValError = false;
                                            // Emp_sale_BO._ACC_NO = dt.Rows[i]["ACC_NO"].ToString().Trim();
                                        }
                                        else
                                        {
                                            Emp_sale_BO._ACC_NO = dt.Rows[i]["ACC_NO"].ToString().Trim();
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in Account NO";
                                        ValError = false;
                                        //Emp_sale_BO._ACC_NO = dt.Rows[i]["ACC_NO"].ToString().Trim();
                                    }
                                }




                                if (dt.Rows[i]["IFSC"].ToString().Trim() == "")
                                {
                                    message = " Please enter IFSC";
                                    ValError = false;
                                    //  Emp_sale_BO._IFSC = dt.Rows[i]["IFSC"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["IFSC"].ToString().Trim()))
                                    {
                                        Emp_sale_BO._IFSC = dt.Rows[i]["IFSC"].ToString().Trim();
                                        //  ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["SALE_OFFER_FILE_PATH"].ToString().Trim() == "")
                                {
                                    message = " Please enter SALE OFFER FILE PATH";
                                    ValError = false;
                                    //  Emp_sale_BO.SALE_OFFER_FILE_PATH = dt.Rows[i]["SALE_OFFER_FILE_PATH"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["SALE_OFFER_FILE_PATH"].ToString().Trim()))
                                    {
                                        Emp_sale_BO.SALE_OFFER_FILE_PATH = dt.Rows[i]["SALE_OFFER_FILE_PATH"].ToString().Trim();
                                        //ValError = true;
                                    }
                                    else
                                    {
                                        Emp_sale_BO.SALE_OFFER_FILE_PATH = dt.Rows[i]["SALE_OFFER_FILE_PATH"].ToString().Trim();
                                        //ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["SALE_DECLARATION_FILE_PATH"].ToString().Trim() == "")
                                {
                                    message = " Please enter SALE DECLARATION FILE PATH";
                                    ValError = false;
                                    // Emp_sale_BO.SALE_DECLARATION_FILE_PATH = dt.Rows[i]["SALE_DECLARATION_FILE_PATH"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["SALE_DECLARATION_FILE_PATH"].ToString().Trim()))
                                    {
                                        Emp_sale_BO.SALE_DECLARATION_FILE_PATH = dt.Rows[i]["SALE_DECLARATION_FILE_PATH"].ToString().Trim();
                                        //ValError = true;
                                    }
                                    else
                                    {
                                        Emp_sale_BO.SALE_DECLARATION_FILE_PATH = dt.Rows[i]["SALE_DECLARATION_FILE_PATH"].ToString().Trim();
                                        //ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["SALE_TRAN_ID"].ToString().Trim() == "")
                                {
                                    message = " Please enter SALE TRANSACTION ID";
                                    ValError = false;
                                    //Emp_sale_BO._SALE_TRAN_ID = Convert.ToInt32(dt.Rows[i]["SALE_TRAN_ID"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["SALE_TRAN_ID"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["SALE_TRAN_ID"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in SALE TRANSACTION ID";
                                            ValError = false;
                                            //Emp_sale_BO._SALE_TRAN_ID = Convert.ToInt32(dt.Rows[i]["SALE_TRAN_ID"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["SALE_TRAN_ID"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in SALE TRANSACTION ID";
                                            ValError = false;
                                            //Emp_sale_BO._SALE_TRAN_ID = Convert.ToInt32(dt.Rows[i]["SALE_TRAN_ID"].ToString().Trim());
                                        }
                                        else
                                        {
                                            Emp_sale_BO._SALE_TRAN_ID = Convert.ToInt32(dt.Rows[i]["SALE_TRAN_ID"].ToString().Trim());
                                            //ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in SALE TRANSACTION ID";
                                        ValError = false;
                                        //Emp_sale_BO._SALE_TRAN_ID = Convert.ToInt32(dt.Rows[i]["SALE_TRAN_ID"].ToString().Trim());
                                    }
                                }


                                if (ValError == false)
                                {
                                    Emp_sale_BO.ErrorString = sb.Append(message).ToString().Trim();
                                    Emp_sale_BO.RecStatus = "Failed";
                                    FailRecords = FailRecords + 1;
                                }
                                else
                                {
                                    Emp_sale_BO.ErrorString = "N.A.";
                                    Emp_sale_BO.RecStatus = "Success";
                                    SuccRecords = SuccRecords + 1;
                                }
                                #endregion validation end

                                DataRow dr = dt_bulkTemp.NewRow();
                                //dr["ECODE"] = Convert.ToString(Session["ECode"]);
                                dr["ECODE"] = Emp_sale_BO.ECODE;
                                dr["ENAME"] = Emp_sale_BO._ENAME;//Vesting cycle name

                                dr["GRANT_NAME"] = Emp_sale_BO._GRANT_NAME;//Vesting Name
                                dr["VESTING_DETAIL_CODE"] = Emp_sale_BO._VESTING_DETAIL_CODE;//No of cycle
                                dr["VESTING_DATE"] = Emp_sale_BO._Str_VESTING_DATE;//Duration

                                dr["NO_OF_VESTING"] = Emp_sale_BO._NO_OF_VESTING;//Percentage                                                                 
                                dr["GRANT_PRICE"] = Emp_sale_BO._GRANT_PRICE;
                                dr["EXERCISE_FMV_PRICE"] = Emp_sale_BO._EXERCISE_FMV_PRICE;
                                dr["SALE_FMV_PRICE"] = Emp_sale_BO._SALE_FMV_PRICE;
                                dr["NO_OF_SALE"] = Emp_sale_BO._NO_OF_SALE;
                                dr["SALE_DATE"] = Emp_sale_BO._STR_SALE_DATE;//Vesting cycle name

                                dr["SECURITY_NAME"] = Emp_sale_BO._SECURITY_NAME;//Vesting Name
                                dr["DPID"] = Emp_sale_BO.DPID;//No of cycle
                                dr["CLIENT_ID"] = Emp_sale_BO.CLIENT_ID;//Duration
                                dr["MEMBER_TYPE"] = Emp_sale_BO.MEMBER_TYPE;//Percentage  

                                dr["BANK_NAME"] = Emp_sale_BO._BANK_NAME;
                                dr["BANK_BRANCH"] = Emp_sale_BO._BANK_BRANCH;
                                dr["ACC_NO"] = Emp_sale_BO._ACC_NO;
                                dr["IFSC"] = Emp_sale_BO._IFSC;//Percentage

                                dr["SALE_OFFER_FILE_PATH"] = Emp_sale_BO.SALE_OFFER_FILE_PATH;
                                dr["SALE_DECLARATION_FILE_PATH"] = Emp_sale_BO.SALE_DECLARATION_FILE_PATH;
                                dr["SALE_TRAN_ID"] = Emp_sale_BO._SALE_TRAN_ID;

                                dr["CREATEDBY"] = Convert.ToString(Session["ECode"]);
                                dr["DEM_ErrorString"] = Emp_sale_BO.ErrorString;
                                dr["DEM_RecStatus"] = Emp_sale_BO.RecStatus;

                                dt_bulkTemp.Rows.Add(dr);

                                ValError = true;
                                message = "";
                                sb.Clear();
                                i = i + 1;
                            }
                        }
                    }
                }
                DataView view = new DataView(dt_bulkTemp);
                view.RowFilter = "DEM_RecStatus = 'Failed'";
                DataTable Dt1 = new DataTable();
                Dt1 = view.ToTable(true);


                if (Dt1.Rows.Count > 0)
                {
                    FailRecords = Dt1.Rows.Count;
                    SuccRecords = TotalRecords - FailRecords;// dt.Select("dem_recstatus = 'Failed'").Length;
                    Session["TotalRecords"] = Convert.ToString(TotalRecords);
                    Session["SuccRecords"] = SuccRecords;
                    Session["FailRecords"] = FailRecords;
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Error while uploading file,Please check and upload again.";
                    ViewState["ExcelFailRecord"] = Dt1;
                    return false;
                }
                else
                {
                    dt_bulkTemp.ToCSV(strCSV);
                    ctlupload("abc1", "MyFolder/", "Emp_Sale");
                }
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
                objbo = null;
            }
            return status;
        }

        public bool InsertEmployeeExcerciseRec(DataTable dt)
        {
            DataTable dt_bulkTemp = new DataTable();
            dt_bulkTemp.Columns.Add("ECODE");
            dt_bulkTemp.Columns.Add("ENAME");

            dt_bulkTemp.Columns.Add("GRANT_NAME");
            dt_bulkTemp.Columns.Add("VESTING_DETAIL_CODE");
            dt_bulkTemp.Columns.Add("VESTING_DATE");

            dt_bulkTemp.Columns.Add("NO_OF_VESTING");
            dt_bulkTemp.Columns.Add("GRANT_PRICE");
            dt_bulkTemp.Columns.Add("GRANT_FMV_PRICE");
            dt_bulkTemp.Columns.Add("NO_OF_EXERCISE");
            dt_bulkTemp.Columns.Add("EXERCISE_DATE");

            dt_bulkTemp.Columns.Add("TAXABLE_INCOME");
            dt_bulkTemp.Columns.Add("EXERCISE_CONSIDERATION");
            dt_bulkTemp.Columns.Add("FMV_GRANT_OPTION_EXERCISE");
            dt_bulkTemp.Columns.Add("REVISED_TAXABLE_INCOME");
            dt_bulkTemp.Columns.Add("TAX_PER_OPTION");
            dt_bulkTemp.Columns.Add("PERQ_TAX_AMOUNT");
            dt_bulkTemp.Columns.Add("TOTAL_AMOUNT");

            dt_bulkTemp.Columns.Add("SECURITY_NAME");
            dt_bulkTemp.Columns.Add("DPID");
            dt_bulkTemp.Columns.Add("CLIENT_ID");
            dt_bulkTemp.Columns.Add("MEMBER_TYPE");

            dt_bulkTemp.Columns.Add("PAYMENT_MODE");
            dt_bulkTemp.Columns.Add("BANK_NAME");
            dt_bulkTemp.Columns.Add("BANK_BRANCH");
            dt_bulkTemp.Columns.Add("ACC_NO");
            dt_bulkTemp.Columns.Add("IFSC");

            dt_bulkTemp.Columns.Add("CHEQUE_NUMBER");
            dt_bulkTemp.Columns.Add("CHEQUE_DATE");
            dt_bulkTemp.Columns.Add("CREATEDBY");
           // dt_bulkTemp.Columns.Add("EXERCISE_TRAN_ID");
            dt_bulkTemp.Columns.Add("CHEQUE_AMOUNT");
            dt_bulkTemp.Columns.Add("NEFT_FILE_PATH");
            dt_bulkTemp.Columns.Add("CHEQUE_FILE_PATH");

            dt_bulkTemp.Columns.Add("DEMAT_FILE_PATH");
            dt_bulkTemp.Columns.Add("CHEQUE_FILE_PATH_FRESH");

            dt_bulkTemp.Columns.Add("LOAN_LENDER_BANK_NAME");
            dt_bulkTemp.Columns.Add("LOAN_AMOUNT");
            dt_bulkTemp.Columns.Add("LOAN_MARGIN_AMOUNT");
            dt_bulkTemp.Columns.Add("LOAN_MARGIN_PAYMENT_MODE");

            dt_bulkTemp.Columns.Add("NEFT_UTR_NO");
            dt_bulkTemp.Columns.Add("DEM_ErrorString");
            dt_bulkTemp.Columns.Add("DEM_RecStatus");

            SqlConnection con;
            string ErrorValidationMsg = "";
            bool status = false;
            string msg = "";
            bool ValError = true;
            string message = "";
            employee_exerciseBO Emp_exercise_BO = new employee_exerciseBO();
            employee_exerciseBAL Emp_exercise_BAL = new employee_exerciseBAL();
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
                                #region validation start
                                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                                var regexItem_varchar = new Regex("^[a-zA-Z]*$");
                                var regexItem_onlyNumeric = new Regex("^[0-9 ]*$");
                                var regexItem_decimal = new Regex("^[1-9]\\d*(\\.\\d{1,2})?$"); //("^[0-9 ]*$");
                                var regexDateDDMMYYYY = new Regex("^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[13-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$");


                                if (dt.Rows[i]["EMP_CODE"].ToString().Trim() == "")
                                {
                                    message = " Please enter Employee Code";
                                    ValError = false;
                                    Emp_exercise_BO.ECODE = dt.Rows[i]["EMP_CODE"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["EMP_CODE"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO.ECODE = dt.Rows[i]["EMP_CODE"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["EMP_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter Employee Name";
                                    ValError = false;
                                    Emp_exercise_BO._ENAME = dt.Rows[i]["EMP_NAME"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["EMP_NAME"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO._ENAME = dt.Rows[i]["EMP_NAME"].ToString().Trim();
                                        // ValError = true;
                                    }
                                    else
                                    {
                                        Emp_exercise_BO._ENAME = dt.Rows[i]["EMP_NAME"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["GRANT_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter GRANT NAME";
                                    ValError = false;
                                    Emp_exercise_BO._GRANT_NAME = dt.Rows[i]["GRANT_NAME"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["GRANT_NAME"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO._GRANT_NAME = dt.Rows[i]["GRANT_NAME"].ToString().Trim();
                                        //  ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["VESTING_DETAIL_CODE"].ToString().Trim() == "")
                                {
                                    message = " Please enter VESTING DETAIL CODE";
                                    ValError = false;
                                    Emp_exercise_BO._VESTING_DETAIL_CODE = dt.Rows[i]["VESTING_DETAIL_CODE"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["VESTING_DETAIL_CODE"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO._VESTING_DETAIL_CODE = dt.Rows[i]["VESTING_DETAIL_CODE"].ToString().Trim();
                                        //  ValError = true;
                                    }
                                }


                                if (dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim() == "")
                                {
                                    message = " Please enter VESTING Date";
                                    ValError = false;
                                    Emp_exercise_BO._Str_VESTING_DATE = dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim();
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                    {
                                        message = message + " Invalid Date format for VESTING Date";
                                        ValError = false;
                                        Emp_exercise_BO._Str_VESTING_DATE = dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                    else
                                    if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO._Str_VESTING_DATE = dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim();
                                        // ValError = true;
                                    }
                                    else
                                    {
                                        message = message + " Invalid Date format for VESTING Date";
                                        ValError = false;
                                        Emp_exercise_BO._Str_VESTING_DATE = dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["NO_OF_VESTING"].ToString().Trim() == "")
                                {
                                    message = " Please enter No of Vesting";
                                    ValError = false;
                                    // Emp_exercise_BO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim());
                                }
                                else
                                {

                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            // Emp_exercise_BO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["NO_OF_VESTING"]);
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero";
                                            ValError = false;
                                            // Emp_exercise_BO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim());
                                        }
                                        else
                                        {
                                            Emp_exercise_BO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed";
                                        ValError = false;
                                        // Emp_exercise_BO._NO_OF_VESTING = dt.Rows[i]["NO_OF_VESTING"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["GRANT_FMV_PRICE"].ToString().Trim() == "")
                                {
                                    message = " Please enter GRANT FMV PRICE";
                                    ValError = false;
                                    //Emp_exercise_BO._GRANT_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_FMV_PRICE"].ToString().Trim());
                                }
                                else
                                {

                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["GRANT_FMV_PRICE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["GRANT_FMV_PRICE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in GRANT FMV PRICE";
                                            ValError = false;
                                            //  Emp_exercise_BO._GRANT_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_FMV_PRICE"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["GRANT_FMV_PRICE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in GRANT FMV PRICE";
                                            ValError = false;
                                            // Emp_exercise_BO._GRANT_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_FMV_PRICE"].ToString().Trim());
                                        }
                                        else
                                        {
                                            Emp_exercise_BO._GRANT_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_FMV_PRICE"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in GRANT FMV PRICE";
                                        ValError = false;
                                        // Emp_exercise_BO._GRANT_FMV_PRICE = dt.Rows[i]["GRANT_FMV_PRICE"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["GRANT_PRICE"].ToString().Trim() == "")
                                {
                                    message = " Please enter GRANT PRICE";
                                    ValError = false;
                                    // Emp_exercise_BO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_PRICE"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["GRANT_PRICE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["GRANT_PRICE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in GRANT PRICE";
                                            ValError = false;
                                            //Emp_exercise_BO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_PRICE"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["GRANT_PRICE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in GRANT PRICE";
                                            ValError = false;
                                            // Emp_exercise_BO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_PRICE"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_exercise_BO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_PRICE"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in GRANT PRICE";
                                        ValError = false;
                                        // Emp_exercise_BO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i]["GRANT_PRICE"].ToString().Trim());
                                    }
                                }


                                if (dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim() == "")
                                {
                                    message = " Please enter NO OF EXERCISE";
                                    ValError = false;
                                    Emp_exercise_BO._NO_OF_EXERCISE = Convert.ToDouble(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in NO OF EXERCISE";
                                            ValError = false;
                                            Emp_exercise_BO._NO_OF_EXERCISE = Convert.ToDouble(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in NO OF EXERCISE";
                                            ValError = false;
                                            Emp_exercise_BO._NO_OF_EXERCISE = Convert.ToDouble(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_exercise_BO._NO_OF_EXERCISE = Convert.ToDouble(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in NO OF EXERCISE";
                                        ValError = false;
                                        Emp_exercise_BO._NO_OF_EXERCISE = Convert.ToDouble(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim());
                                    }
                                }

                                if (dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim() == "")
                                {
                                    message = " Please enter EXERCISE Date";
                                    ValError = false;
                                    Emp_exercise_BO._STR_Excer_DATE = dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                    {
                                        message = message + " Invalid Date format for EXERCISE Date";
                                        ValError = false;
                                        Emp_exercise_BO._STR_Excer_DATE = dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO._STR_Excer_DATE = dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                        // ValError = true;
                                    }
                                    else
                                    {
                                        message = message + " Invalid Date format for EXERCISE Date";
                                        ValError = false;
                                        Emp_exercise_BO._STR_Excer_DATE = dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                }


                                if (Convert.ToString(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim()) != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in TAXABLE INCOME";
                                            ValError = false;
                                            Emp_exercise_BO._TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in TAXABLE INCOME";
                                            ValError = false;
                                            Emp_exercise_BO._TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_exercise_BO._TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in TAXABLE INCOME";
                                        ValError = false;
                                        Emp_exercise_BO._TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim());
                                    }
                                }

                                if (Convert.ToString(dt.Rows[i]["EXERCISE_CONSIDERATION"].ToString().Trim()) != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["EXERCISE_CONSIDERATION"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["EXERCISE_CONSIDERATION"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in EXERCISE CONSIDERATION";
                                            ValError = false;
                                            Emp_exercise_BO._EXERCISE_CONSIDERATION = Convert.ToDouble(dt.Rows[i]["EXERCISE_CONSIDERATION"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["EXERCISE_CONSIDERATION"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in EXERCISE CONSIDERATION";
                                            ValError = false;
                                            Emp_exercise_BO._EXERCISE_CONSIDERATION = Convert.ToDouble(dt.Rows[i]["EXERCISE_CONSIDERATION"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_exercise_BO._EXERCISE_CONSIDERATION = Convert.ToDouble(dt.Rows[i]["EXERCISE_CONSIDERATION"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in EXERCISE CONSIDERATION";
                                        ValError = false;
                                        Emp_exercise_BO._EXERCISE_CONSIDERATION = Convert.ToDouble(dt.Rows[i]["EXERCISE_CONSIDERATION"].ToString().Trim());
                                    }
                                }

                                if (Convert.ToString(dt.Rows[i]["FMV_GRANT_OPTION_EXERCISE"].ToString().Trim()) != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["FMV_GRANT_OPTION_EXERCISE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["FMV_GRANT_OPTION_EXERCISE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in FMV GRANT OPTION EXERCISE";
                                            ValError = false;
                                            Emp_exercise_BO._FMV_GRANT_OPTION_EXERCISE = Convert.ToDouble(dt.Rows[i]["FMV_GRANT_OPTION_EXERCISE"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["FMV_GRANT_OPTION_EXERCISE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in FMV GRANT OPTION EXERCISE";
                                            ValError = false;
                                            Emp_exercise_BO._FMV_GRANT_OPTION_EXERCISE = Convert.ToDouble(dt.Rows[i]["FMV_GRANT_OPTION_EXERCISE"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_exercise_BO._FMV_GRANT_OPTION_EXERCISE = Convert.ToDouble(dt.Rows[i]["FMV_GRANT_OPTION_EXERCISE"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in FMV GRANT OPTION EXERCISE";
                                        ValError = false;
                                        Emp_exercise_BO._FMV_GRANT_OPTION_EXERCISE = Convert.ToDouble(dt.Rows[i]["FMV_GRANT_OPTION_EXERCISE"].ToString().Trim());
                                    }
                                }

                                if (Convert.ToString(dt.Rows[i]["REVISED_TAXABLE_INCOME"].ToString().Trim()) != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["REVISED_TAXABLE_INCOME"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["REVISED_TAXABLE_INCOME"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in REVISED TAXABLE INCOME";
                                            ValError = false;
                                            Emp_exercise_BO._REVISED_TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["REVISED_TAXABLE_INCOME"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["REVISED_TAXABLE_INCOME"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in REVISED TAXABLE INCOME";
                                            ValError = false;
                                            Emp_exercise_BO._REVISED_TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["REVISED_TAXABLE_INCOME"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_exercise_BO._REVISED_TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["REVISED_TAXABLE_INCOME"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in REVISED TAXABLE INCOME";
                                        ValError = false;
                                        Emp_exercise_BO._REVISED_TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["REVISED_TAXABLE_INCOME"].ToString().Trim());
                                    }
                                }

                                if (Convert.ToString(dt.Rows[i]["TAX_PER_OPTION"].ToString().Trim()) != "")
                                {
                                    if ((regexItem_onlyNumeric.IsMatch(dt.Rows[i]["TAX_PER_OPTION"].ToString().Trim()) == true) || (regexItem_decimal.IsMatch(dt.Rows[i]["TAX_PER_OPTION"].ToString().Trim()) == true))
                                    {
                                        if (Convert.ToDouble(dt.Rows[i]["TAX_PER_OPTION"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in TAX PER OPTION";
                                            ValError = false;
                                            Emp_exercise_BO._TAX_PER_OPTION = Convert.ToDouble(dt.Rows[i]["TAX_PER_OPTION"].ToString().Trim());
                                        }
                                        else if (Convert.ToDouble(dt.Rows[i]["TAX_PER_OPTION"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in TAX PER OPTION";
                                            ValError = false;
                                            Emp_exercise_BO._TAX_PER_OPTION = Convert.ToDouble(dt.Rows[i]["TAX_PER_OPTION"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_exercise_BO._TAX_PER_OPTION = Convert.ToDouble(dt.Rows[i]["TAX_PER_OPTION"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in TAX PER OPTION";
                                        ValError = false;
                                        Emp_exercise_BO._TAX_PER_OPTION = Convert.ToDouble(dt.Rows[i]["TAX_PER_OPTION"].ToString().Trim());
                                    }
                                }

                                if (Convert.ToString(dt.Rows[i]["PERQ_TAX_AMOUNT"].ToString().Trim()) != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["PERQ_TAX_AMOUNT"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["PERQ_TAX_AMOUNT"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in PERQ TAX AMOUNT";
                                            ValError = false;
                                            Emp_exercise_BO._PERQ_TAX_AMOUNT = Convert.ToDouble(dt.Rows[i]["PERQ_TAX_AMOUNT"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["PERQ_TAX_AMOUNT"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in PERQ TAX AMOUNT";
                                            ValError = false;
                                            Emp_exercise_BO._PERQ_TAX_AMOUNT = Convert.ToDouble(dt.Rows[i]["PERQ_TAX_AMOUNT"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_exercise_BO._PERQ_TAX_AMOUNT = Convert.ToDouble(dt.Rows[i]["PERQ_TAX_AMOUNT"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in PERQ TAX AMOUNT";
                                        ValError = false;
                                        Emp_exercise_BO._PERQ_TAX_AMOUNT = Convert.ToDouble(dt.Rows[i]["PERQ_TAX_AMOUNT"].ToString().Trim());
                                    }
                                }

                                if (Convert.ToString(dt.Rows[i]["TOTAL_AMOUNT"].ToString().Trim()) != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["TOTAL_AMOUNT"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["TOTAL_AMOUNT"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in TOTAL AMOUNT";
                                            ValError = false;
                                            Emp_exercise_BO._TOTAL_AMOUNT = Convert.ToDouble(dt.Rows[i]["TOTAL_AMOUNT"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["TOTAL_AMOUNT"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in TOTAL AMOUNT";
                                            ValError = false;
                                            Emp_exercise_BO._TOTAL_AMOUNT = Convert.ToDouble(dt.Rows[i]["TOTAL_AMOUNT"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_exercise_BO._TOTAL_AMOUNT = Convert.ToDouble(dt.Rows[i]["TOTAL_AMOUNT"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in TOTAL AMOUNT";
                                        ValError = false;
                                        Emp_exercise_BO._TOTAL_AMOUNT = Convert.ToDouble(dt.Rows[i]["TOTAL_AMOUNT"].ToString().Trim());
                                    }
                                }


                                if (dt.Rows[i]["SECURITY_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter SECURITY NAME";
                                    ValError = false;
                                    Emp_exercise_BO._SECURITY_NAME = dt.Rows[i]["SECURITY_NAME"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["SECURITY_NAME"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO._SECURITY_NAME = dt.Rows[i]["SECURITY_NAME"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }


                                if (dt.Rows[i]["DPID"].ToString().Trim() == "")
                                {
                                    message = " Please enter DPID";
                                    ValError = false;
                                    Emp_exercise_BO.DPID = dt.Rows[i]["DPID"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["DPID"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO.DPID = dt.Rows[i]["DPID"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["CLIENT_ID"].ToString().Trim() == "")
                                {
                                    message = " Please enter CLIENT ID";
                                    ValError = false;
                                    Emp_exercise_BO.CLIENT_ID = dt.Rows[i]["CLIENT_ID"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["CLIENT_ID"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO.CLIENT_ID = dt.Rows[i]["CLIENT_ID"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["MEMBER_TYPE"].ToString().Trim() == "")
                                {
                                    message = " Please enter MEMBER TYPE";
                                    ValError = false;
                                    Emp_exercise_BO.MEMBER_TYPE = dt.Rows[i]["MEMBER_TYPE"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["MEMBER_TYPE"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO.MEMBER_TYPE = dt.Rows[i]["MEMBER_TYPE"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["PAYMENT_MODE"].ToString().Trim() == "")
                                {
                                    message = " Please enter PAYMENT MODE";
                                    ValError = false;
                                    Emp_exercise_BO._PAYMENT_MODE = dt.Rows[i]["PAYMENT_MODE"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["PAYMENT_MODE"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO._PAYMENT_MODE = dt.Rows[i]["PAYMENT_MODE"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }


                                if (dt.Rows[i]["BANK_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter BANK NAME";
                                    ValError = false;
                                    Emp_exercise_BO._BANK_NAME = dt.Rows[i]["BANK_NAME"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["BANK_NAME"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO._BANK_NAME = dt.Rows[i]["BANK_NAME"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["BANK_BRANCH"].ToString().Trim() == "")
                                {
                                    message = " Please enter BANK BRANCH";
                                    ValError = false;
                                    Emp_exercise_BO._BANK_BRANCH = dt.Rows[i]["BANK_BRANCH"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["BANK_BRANCH"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO._BANK_BRANCH = dt.Rows[i]["BANK_BRANCH"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["ACC_NO"].ToString().Trim() == "")
                                {
                                    message = " Please enter Account NO";
                                    ValError = false;
                                    Emp_exercise_BO._ACC_NO = dt.Rows[i]["ACC_NO"].ToString().Trim();
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["ACC_NO"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt64(dt.Rows[i]["ACC_NO"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in Account No.";
                                            ValError = false;
                                            Emp_exercise_BO._ACC_NO = dt.Rows[i]["ACC_NO"].ToString().Trim();
                                        }
                                        else if (Convert.ToInt64(dt.Rows[i]["ACC_NO"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in Account No.";
                                            ValError = false;
                                            Emp_exercise_BO._ACC_NO = dt.Rows[i]["ACC_NO"].ToString().Trim();
                                        }
                                        else
                                        {
                                            Emp_exercise_BO._ACC_NO = dt.Rows[i]["ACC_NO"].ToString().Trim();
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in Account No.";
                                        ValError = false;
                                        Emp_exercise_BO._ACC_NO = dt.Rows[i]["ACC_NO"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["IFSC"].ToString().Trim() == "")
                                {
                                    message = " Please enter IFSC";
                                    ValError = false;
                                    Emp_exercise_BO._IFSC = dt.Rows[i]["IFSC"].ToString().Trim();
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["IFSC"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO._IFSC = dt.Rows[i]["IFSC"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (Convert.ToString(dt.Rows[i]["CHEQUE_NUMBER"].ToString().Trim()) != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["CHEQUE_NUMBER"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["CHEQUE_NUMBER"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in CHEQUE NUMBER";
                                            ValError = false;
                                            Emp_exercise_BO._CHEQUE_NUMBER = dt.Rows[i]["CHEQUE_NUMBER"].ToString().Trim();
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["CHEQUE_NUMBER"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in CHEQUE NUMBER";
                                            ValError = false;
                                            Emp_exercise_BO._CHEQUE_NUMBER = dt.Rows[i]["CHEQUE_NUMBER"].ToString().Trim();
                                        }
                                        else
                                        {

                                            Emp_exercise_BO._CHEQUE_NUMBER = dt.Rows[i]["CHEQUE_NUMBER"].ToString().Trim();
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in CHEQUE NUMBER";
                                        ValError = false;
                                        Emp_exercise_BO._CHEQUE_NUMBER = dt.Rows[i]["CHEQUE_NUMBER"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["CHEQUE_DATE(DD-MM-YYYY)"].ToString().Trim() != "")
                                {
                                    if (Regex.Matches(dt.Rows[i]["CHEQUE_DATE(DD-MM-YYYY)"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                    {
                                        message = message + " Invalid Date format for CHEQUE Date";
                                        ValError = false;
                                        Emp_exercise_BO._Str_Cheque_DATE = dt.Rows[i]["CHEQUE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["CHEQUE_DATE(DD-MM-YYYY)"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO._Str_Cheque_DATE = dt.Rows[i]["CHEQUE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                        // ValError = true;
                                    }
                                    else
                                    {
                                        message = message + " Invalid Date format for CHEQUE Date";
                                        ValError = false;
                                        Emp_exercise_BO._Str_Cheque_DATE = dt.Rows[i]["CHEQUE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                }

                                if (Convert.ToString(dt.Rows[i]["CHEQUE_AMOUNT"].ToString().Trim()) != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["CHEQUE_AMOUNT"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["CHEQUE_AMOUNT"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in CHEQUE Amount";
                                            ValError = false;
                                            Emp_exercise_BO.CHEQUE_AMOUNT = Convert.ToDouble(dt.Rows[i]["CHEQUE_AMOUNT"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["CHEQUE_AMOUNT"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in CHEQUE Amount";
                                            ValError = false;
                                            Emp_exercise_BO.CHEQUE_AMOUNT = Convert.ToDouble(dt.Rows[i]["CHEQUE_AMOUNT"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_exercise_BO.CHEQUE_AMOUNT = Convert.ToDouble(dt.Rows[i]["CHEQUE_AMOUNT"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in CHEQUE Amount";
                                        ValError = false;
                                        Emp_exercise_BO.CHEQUE_AMOUNT = Convert.ToDouble(dt.Rows[i]["CHEQUE_AMOUNT"].ToString().Trim());
                                    }
                                }

                                if (dt.Rows[i]["NEFT_UTR_NO"].ToString().Trim() != "")
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["NEFT_UTR_NO"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO.NEFT_UTR_NO = dt.Rows[i]["NEFT_UTR_NO"].ToString().Trim();
                                        // ValError = true;
                                    }
                                    else
                                    {
                                        Emp_exercise_BO.NEFT_UTR_NO = dt.Rows[i]["NEFT_UTR_NO"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["LOAN_LENDER_BANK_NAME"].ToString().Trim() != "")
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["LOAN_LENDER_BANK_NAME"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO.LOAN_LENDER_BANK_NAME = dt.Rows[i]["LOAN_LENDER_BANK_NAME"].ToString().Trim();
                                        // ValError = true;
                                    }
                                    else
                                    {
                                        Emp_exercise_BO.LOAN_LENDER_BANK_NAME = dt.Rows[i]["LOAN_LENDER_BANK_NAME"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (Convert.ToString(dt.Rows[i]["LOAN_AMOUNT"].ToString().Trim()) != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["LOAN_AMOUNT"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["LOAN_AMOUNT"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in LOAN Amount";
                                            ValError = false;
                                            Emp_exercise_BO.LOAN_AMOUNT = Convert.ToDouble(dt.Rows[i]["LOAN_AMOUNT"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["LOAN_AMOUNT"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in LOAN Amount";
                                            ValError = false;
                                            Emp_exercise_BO.LOAN_AMOUNT = Convert.ToDouble(dt.Rows[i]["LOAN_AMOUNT"].ToString().Trim());
                                        }
                                        else
                                        {

                                            Emp_exercise_BO.LOAN_AMOUNT = Convert.ToDouble(dt.Rows[i]["LOAN_AMOUNT"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in LOAN Amount";
                                        ValError = false;
                                        Emp_exercise_BO.LOAN_AMOUNT = Convert.ToDouble(dt.Rows[i]["LOAN_AMOUNT"].ToString().Trim());
                                    }
                                }

                                if (Convert.ToString(dt.Rows[i]["LOAN_MARGIN_AMOUNT"].ToString().Trim()) != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["LOAN_MARGIN_AMOUNT"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["LOAN_MARGIN_AMOUNT"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in LOAN MARGIN Amount";
                                            ValError = false;
                                            Emp_exercise_BO.LOAN_MARGIN_AMOUNT = Convert.ToDouble(dt.Rows[i]["LOAN_MARGIN_AMOUNT"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["LOAN_MARGIN_AMOUNT"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in LOAN MARGIN Amount";
                                            ValError = false;
                                            Emp_exercise_BO.LOAN_MARGIN_AMOUNT = Convert.ToDouble(dt.Rows[i]["LOAN_MARGIN_AMOUNT"].ToString().Trim());
                                        }
                                        else
                                        {
                                            Emp_exercise_BO.LOAN_MARGIN_AMOUNT = Convert.ToDouble(dt.Rows[i]["LOAN_MARGIN_AMOUNT"].ToString().Trim());
                                            // ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in LOAN MARGIN Amount";
                                        ValError = false;
                                        Emp_exercise_BO.LOAN_MARGIN_AMOUNT = Convert.ToDouble(dt.Rows[i]["LOAN_MARGIN_AMOUNT"].ToString().Trim());
                                    }
                                }

                                if (dt.Rows[i]["LOAN_MARGIN_PAYMENT_MODE"].ToString().Trim() != "")
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["LOAN_MARGIN_PAYMENT_MODE"].ToString().Trim()))
                                    {
                                        Emp_exercise_BO.LOAN_MARGIN_PAYMENT_MODE = dt.Rows[i]["LOAN_MARGIN_PAYMENT_MODE"].ToString().Trim();
                                        // ValError = true;
                                    }
                                }

                                if (dt.Rows[i]["CHEQUE_FILE_PATH"].ToString().Trim() != "")
                                {
                                    Emp_exercise_BO.CHEQUE_FILE_PATH = dt.Rows[i]["CHEQUE_FILE_PATH"].ToString().Trim();
                                    // ValError = true;

                                }

                                if (dt.Rows[i]["NEFT_FILE_PATH"].ToString().Trim() != "")
                                {
                                    Emp_exercise_BO.NEFT_FILE_PATH = dt.Rows[i]["NEFT_FILE_PATH"].ToString().Trim();
                                    // ValError = true;
                                }


                                if (dt.Rows[i]["DEMAT_FILE_PATH"].ToString().Trim() != "")
                                {
                                    Emp_exercise_BO.DEMAT_FILE_PATH = dt.Rows[i]["DEMAT_FILE_PATH"].ToString().Trim();
                                    // ValError = true;
                                }

                                if (dt.Rows[i]["CHEQUE_FILE_PATH_FRESH"].ToString().Trim() != "")
                                {
                                    Emp_exercise_BO.CHEQUE_FILE_PATH_FRESH = dt.Rows[i]["CHEQUE_FILE_PATH_FRESH"].ToString().Trim();
                                    // ValError = true;
                                }

                                //if (dt.Rows[i]["Excercise_TRAN_ID"].ToString().Trim() == "")
                                //{
                                //    message = " Please enter Excercise TRANSACTION ID";
                                //    ValError = false;
                                //    Emp_exercise_BO._EXERCISE_TRAN_ID = Convert.ToInt32(dt.Rows[i]["Excercise_TRAN_ID"].ToString().Trim());
                                //}
                                //else
                                //{
                                //    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["Excercise_TRAN_ID"].ToString().Trim()))
                                //    {
                                //        if (Convert.ToInt32(dt.Rows[i]["Excercise_TRAN_ID"].ToString().Trim()) == 0)
                                //        {
                                //            message = message + "Zero cant be added in Excercise TRAN ID";
                                //            ValError = false;
                                //            Emp_exercise_BO._EXERCISE_TRAN_ID = Convert.ToInt32(dt.Rows[i]["Excercise_TRAN_ID"].ToString().Trim());
                                //        }
                                //        else if (Convert.ToInt32(dt.Rows[i]["Excercise_TRAN_ID"].ToString().Trim()) < 0)
                                //        {
                                //            message = message + "Cannot be less then zero in Excercise TRAN ID";
                                //            ValError = false;
                                //            Emp_exercise_BO._EXERCISE_TRAN_ID = Convert.ToInt32(dt.Rows[i]["Excercise_TRAN_ID"].ToString().Trim());
                                //        }
                                //        else
                                //        {
                                //            Emp_exercise_BO._EXERCISE_TRAN_ID = Convert.ToInt32(dt.Rows[i]["Excercise_TRAN_ID"].ToString().Trim());
                                //            // ValError = true;
                                //        }
                                //    }
                                //    else
                                //    {
                                //        message = message + "Only numbers are allowed in Excercise TRAN ID";
                                //        ValError = false;
                                //        Emp_exercise_BO._EXERCISE_TRAN_ID = Convert.ToInt32(dt.Rows[i]["Excercise_TRAN_ID"].ToString().Trim());
                                //    }
                                //}

                                if (ValError == false)
                                {
                                    Emp_exercise_BO.ErrorString = sb.Append(message).ToString().Trim();
                                    Emp_exercise_BO.RecStatus = "Failed";
                                    FailRecords = FailRecords + 1;
                                }
                                else
                                {
                                    Emp_exercise_BO.ErrorString = "N.A.";
                                    Emp_exercise_BO.RecStatus = "Success";
                                    SuccRecords = SuccRecords + 1;
                                }

                                #endregion validation end

                                DataRow dr = dt_bulkTemp.NewRow();

                                dr["ECODE"] = Emp_exercise_BO.ECODE;
                                dr["ENAME"] = Emp_exercise_BO._ENAME;//Vesting cycle name

                                dr["GRANT_NAME"] = Emp_exercise_BO._GRANT_NAME;//Vesting Name
                                dr["VESTING_DETAIL_CODE"] = Emp_exercise_BO._VESTING_DETAIL_CODE;//No of cycle
                                dr["VESTING_DATE"] = Emp_exercise_BO._Str_VESTING_DATE;//Duration

                                dr["NO_OF_VESTING"] = Emp_exercise_BO._NO_OF_VESTING;//Percentage                                                                 
                                dr["GRANT_PRICE"] = Emp_exercise_BO._GRANT_PRICE;
                                dr["GRANT_FMV_PRICE"] = Emp_exercise_BO._GRANT_FMV_PRICE;
                                dr["NO_OF_EXERCISE"] = Emp_exercise_BO._NO_OF_EXERCISE;
                                dr["EXERCISE_DATE"] = Emp_exercise_BO._STR_Excer_DATE;//Vesting cycle name

                                dr["TAXABLE_INCOME"] = Emp_exercise_BO._TAXABLE_INCOME;//Percentage                                                                 
                                dr["EXERCISE_CONSIDERATION"] = Emp_exercise_BO._EXERCISE_CONSIDERATION;
                                dr["FMV_GRANT_OPTION_EXERCISE"] = Emp_exercise_BO._FMV_GRANT_OPTION_EXERCISE;
                                dr["REVISED_TAXABLE_INCOME"] = Emp_exercise_BO._REVISED_TAXABLE_INCOME;
                                dr["TAX_PER_OPTION"] = Emp_exercise_BO._TAX_PER_OPTION;
                                dr["PERQ_TAX_AMOUNT"] = Emp_exercise_BO._PERQ_TAX_AMOUNT;//Vesting cycle name
                                dr["TOTAL_AMOUNT"] = Emp_exercise_BO._TOTAL_AMOUNT;//Vesting cycle name

                                dr["SECURITY_NAME"] = Emp_exercise_BO._SECURITY_NAME;//Vesting Name
                                dr["DPID"] = Emp_exercise_BO.DPID;//No of cycle
                                dr["CLIENT_ID"] = Emp_exercise_BO.CLIENT_ID;//Duration
                                dr["MEMBER_TYPE"] = Emp_exercise_BO.MEMBER_TYPE;//Percentage  

                                dr["PAYMENT_MODE"] = Emp_exercise_BO._PAYMENT_MODE;
                                dr["BANK_NAME"] = Emp_exercise_BO._BANK_NAME;
                                dr["BANK_BRANCH"] = Emp_exercise_BO._BANK_BRANCH;
                                dr["ACC_NO"] = Emp_exercise_BO._ACC_NO;
                                dr["IFSC"] = Emp_exercise_BO._IFSC;//Percentage


                                dr["CHEQUE_NUMBER"] = Emp_exercise_BO._CHEQUE_NUMBER;
                                dr["CHEQUE_DATE"] = Emp_exercise_BO._Str_Cheque_DATE;
                                dr["CREATEDBY"] = Convert.ToString(Session["ECode"]);
                              //  dr["EXERCISE_TRAN_ID"] = Emp_exercise_BO._EXERCISE_TRAN_ID;
                                dr["CHEQUE_AMOUNT"] = Emp_exercise_BO.CHEQUE_AMOUNT;
                                dr["NEFT_FILE_PATH"] = Emp_exercise_BO.NEFT_FILE_PATH;//Percentage
                                dr["CHEQUE_FILE_PATH"] = Emp_exercise_BO.CHEQUE_FILE_PATH;//Percentage

                                dr["DEMAT_FILE_PATH"] = Emp_exercise_BO.DEMAT_FILE_PATH;
                                dr["CHEQUE_FILE_PATH_FRESH"] = Emp_exercise_BO.CHEQUE_FILE_PATH_FRESH;

                                dr["LOAN_LENDER_BANK_NAME"] = Emp_exercise_BO.LOAN_LENDER_BANK_NAME;//Percentage
                                dr["LOAN_AMOUNT"] = Emp_exercise_BO.LOAN_AMOUNT;//Percentage
                                dr["LOAN_MARGIN_AMOUNT"] = Emp_exercise_BO.LOAN_MARGIN_AMOUNT;//Percentage
                                dr["LOAN_MARGIN_PAYMENT_MODE"] = Emp_exercise_BO.LOAN_MARGIN_PAYMENT_MODE;//Percentage

                                dr["NEFT_UTR_NO"] = Emp_exercise_BO.NEFT_UTR_NO;
                                dr["DEM_ErrorString"] = Emp_exercise_BO.ErrorString;
                                dr["DEM_RecStatus"] = Emp_exercise_BO.RecStatus;

                                dt_bulkTemp.Rows.Add(dr);
                                ValError = true;
                                message = "";
                                sb.Clear();
                                i = i + 1;
                            }
                        }
                    }
                }

                DataView view = new DataView(dt_bulkTemp);
                view.RowFilter = "DEM_RecStatus = 'Failed'";
                DataTable Dt1 = new DataTable();
                Dt1 = view.ToTable(true);


                if (Dt1.Rows.Count > 0)
                {
                    FailRecords = Dt1.Rows.Count;
                    SuccRecords = TotalRecords - FailRecords;// dt.Select("dem_recstatus = 'Failed'").Length;
                    Session["TotalRecords"] = Convert.ToString(TotalRecords);
                    Session["SuccRecords"] = SuccRecords;
                    Session["FailRecords"] = FailRecords;
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Error while uploading file,Please check and upload again.";
                    ViewState["ExcelFailRecord"] = Dt1;
                    return false;
                }
                else
                {
                    dt_bulkTemp.ToCSV(strCSV);
                    ctlupload("abc1", "MyFolder/", "Emp_Excerice");
                }
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
                objbo = null;
            }
            return status;
        }

        public bool InsertGrantMastRec(DataTable dt)
        {
            DataTable dt_bulkTemp = new DataTable();
            //dt_bulkTemp.Columns.Add("DEM_EU_ID");
            dt_bulkTemp.Columns.Add("DEM_EMP_ID");
            dt_bulkTemp.Columns.Add("DEM_GRANT_DATE");
            dt_bulkTemp.Columns.Add("DEM_VESTING_ID");
            dt_bulkTemp.Columns.Add("DEM_FMV_ID");
            dt_bulkTemp.Columns.Add("DEM_GRANT_NAME");
            dt_bulkTemp.Columns.Add("DEM_NO_OF_OPTION");
            dt_bulkTemp.Columns.Add("DEM_ErrorString");
            dt_bulkTemp.Columns.Add("DEM_RecStatus");

            //dt_bulkTemp.Columns.Add("DEM_EU_ID");
            //dt_bulkTemp.Columns.Add("DEM_ECODE");
            //dt_bulkTemp.Columns.Add("DEM_COMPANY_NAME");

            //dt_bulkTemp.Columns.Add("DEM_LOCATION");
            //dt_bulkTemp.Columns.Add("DEM_DEPARTMENT");
            //dt_bulkTemp.Columns.Add("DEM_APPRAISER_NAME");

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

                                if (dt.Rows[i]["Date of Grant"].ToString().Trim() == "")
                                {
                                    message = " Please enter Date of Grant";
                                    ValError = false;
                                    objbo.Doj = dt.Rows[i]["Date of Grant"].ToString().Trim();
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["Date of Grant"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                    {
                                        message = message + " Invalid Date format for Date of Grant";
                                        ValError = false;
                                        objbo.Doj = dt.Rows[i]["Date of Grant"].ToString().Trim();
                                    }
                                    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["Date of Grant"].ToString().Trim()))
                                    {
                                        objbo.Doj = dt.Rows[i]["Date of Grant"].ToString().Trim();
                                        ValError = true;
                                    }
                                    else
                                    {
                                        message = message + " Invalid Date format for Date of Grant";
                                        ValError = false;
                                        objbo.Doj = dt.Rows[i]["Date of Grant"].ToString().Trim();
                                    }
                                }

                                //------


                                if (dt.Rows[i]["Grant Name"].ToString().Trim() == "")
                                {
                                    message = " Please enter Grant Name";
                                    ValError = false;
                                    objbo.GRANT_NAME = dt.Rows[i]["Grant Name"].ToString().Trim();
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["Grant Name"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Grant Name"].ToString().Trim(), @"[0-9]").Count > 0)
                                    {
                                        objbo.GRANT_NAME = dt.Rows[i]["Grant Name"].ToString().Trim();
                                    }
                                    else
                                    {
                                        message = message + " Only Special Characters are not allowed for Grant Name";
                                        ValError = false;
                                        objbo.GRANT_NAME = dt.Rows[i]["Grant Name"].ToString().Trim();
                                    }
                                }

                                //------
                                if (dt.Rows[i]["No Of Options"].ToString().Trim() == "")
                                {

                                    message = "Please enter No Of Options";
                                    ValError = false;
                                    objbo.No_Of_Option_Excel = (dt.Rows[i]["No Of Options"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["No Of Options"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["No Of Options"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            objbo.No_Of_Option_Excel = dt.Rows[i]["No Of Options"].ToString().Trim();
                                        }
                                        else
                                        {

                                            objbo.No_Of_Option_Excel = dt.Rows[i]["No Of Options"].ToString().Trim();
                                        }
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["No Of Option"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["No of Option"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["No of Option"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
                                        {
                                            if (dt.Rows[i]["No Of Option"].ToString().Trim() == "0")
                                            {
                                                message = message + "Zero cant be added";
                                                ValError = false;
                                                objbo.No_Of_Option_Excel = dt.Rows[i]["No Of Option"].ToString().Trim();
                                            }
                                            else
                                            {
                                                objbo.No_Of_Option_Excel = (dt.Rows[i]["No Of Option"].ToString().Trim());
                                            }
                                        }
                                        else
                                        {
                                            message = message + " Only Numbers allowed for No of Option";
                                            ValError = false;
                                            // objbo.NO_OF_OPTION = 0;
                                            objbo.No_Of_Option_Excel = dt.Rows[i]["No Of Option"].ToString().Trim();

                                        }
                                    }
                                }

                                //------
                                if (dt.Rows[i]["Employee ID"].ToString().Trim() == "")
                                {

                                    message = "Please enter Employee ID";
                                    ValError = false;
                                    objbo.EMP_ID = (dt.Rows[i]["Employee ID"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["Employee ID"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["Employee ID"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            objbo.EMP_ID = dt.Rows[i]["No Of Option"].ToString().Trim();
                                        }
                                        else
                                        {

                                            objbo.EMP_ID = dt.Rows[i]["Employee ID"].ToString().Trim();
                                        }
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["Employee ID"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["Employee ID"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["Employee ID"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
                                        {
                                            if (dt.Rows[i]["Employee ID"].ToString().Trim() == "0")
                                            {
                                                message = message + "Zero cant be added";
                                                ValError = false;
                                                objbo.EMP_ID = dt.Rows[i]["Employee ID"].ToString().Trim();
                                            }
                                            else
                                            {
                                                objbo.EMP_ID = (dt.Rows[i]["Employee ID"].ToString().Trim());
                                            }
                                        }
                                        else
                                        {
                                            message = message + " Only Numbers allowed for Employee ID";
                                            ValError = false;
                                            // objbo.NO_OF_OPTION = 0;
                                            objbo.EMP_ID = dt.Rows[i]["Employee ID"].ToString().Trim();

                                        }
                                    }
                                }


                                //------
                                if (dt.Rows[i]["FMV PRICE"].ToString().Trim() == "")
                                {

                                    message = "Please enter FMV PRICE";
                                    ValError = false;
                                    objbo.Lwd = (dt.Rows[i]["FMV PRICE"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["FMV PRICE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["FMV PRICE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            objbo.Lwd = dt.Rows[i]["FMV PRICE"].ToString().Trim();
                                        }
                                        else
                                        {

                                            objbo.Lwd = dt.Rows[i]["FMV PRICE"].ToString().Trim();
                                        }
                                    }
                                    else
                                    {
                                        if (Regex.Matches(dt.Rows[i]["FMV PRICE"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["FMV PRICE"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["FMV PRICE"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
                                        {
                                            if (dt.Rows[i]["FMV PRICE"].ToString().Trim() == "0")
                                            {
                                                message = message + "Zero cant be added";
                                                ValError = false;
                                                objbo.Lwd = dt.Rows[i]["FMV PRICE"].ToString().Trim();
                                            }
                                            else
                                            {
                                                objbo.Lwd = (dt.Rows[i]["FMV PRICE"].ToString().Trim());
                                            }
                                        }
                                        else
                                        {
                                            message = message + " Only Numbers allowed for FMV PRICE";
                                            ValError = false;
                                            // objbo.NO_OF_OPTION = 0;
                                            objbo.Lwd = dt.Rows[i]["FMV PRICE"].ToString().Trim();

                                        }
                                    }
                                }


                                //------
                                if (dt.Rows[i]["Vesting Cycle Name"].ToString().Trim() == "")
                                {

                                    message = "Please enter Vesting Cycle Name";
                                    ValError = false;
                                    objbo.Tntr = (dt.Rows[i]["Vesting Cycle Name"].ToString().Trim());
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["Vesting Cycle Name"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["Vesting Cycle Name"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added";
                                            ValError = false;
                                            objbo.Tntr = dt.Rows[i]["No Of Option"].ToString().Trim();
                                        }
                                        else
                                        {

                                            objbo.Tntr = dt.Rows[i]["Vesting Cycle Name"].ToString().Trim();
                                        }
                                    }
                                    else
                                    {
                                        //if (Regex.Matches(dt.Rows[i]["Vesting Cycle Name"].ToString().Trim(), @"[0-9 ]").Count > 0 && Regex.Matches(dt.Rows[i]["Vesting Cycle Name"].ToString().Trim(), @"[a-zA-Z]").Count == 0 && Regex.Matches(dt.Rows[i]["Vesting Cycle Name"].ToString().Trim(), @"[1-9]\\d*(\\.\\d{1,2})").Count != 0)
                                        if (Regex.Matches(dt.Rows[i]["Vesting Cycle Name"].ToString().Trim(), @"[a-zA-Z]").Count != 0)
                                        {
                                            if (dt.Rows[i]["Vesting Cycle Name"].ToString().Trim() == "0")
                                            {
                                                message = message + "Zero cant be added";
                                                ValError = false;
                                                objbo.Tntr = dt.Rows[i]["Vesting Cycle Name"].ToString().Trim();
                                            }
                                            else
                                            {
                                                objbo.Tntr = (dt.Rows[i]["Vesting Cycle Name"].ToString().Trim());
                                            }
                                        }
                                        else
                                        {
                                            message = message + " Only Name are allowed in Vesting Cycle Name";
                                            ValError = false;
                                            // objbo.NO_OF_OPTION = 0;
                                            objbo.Tntr = dt.Rows[i]["Vesting Cycle Name"].ToString().Trim();

                                        }
                                    }
                                }

                                //------

                                //if (dt.Rows[i]["HR Remark"].ToString().Trim() == "")
                                //{
                                //    message = " Please enter HR Remark";
                                //    ValError = false;
                                //    objbo.GRANT_NAME = dt.Rows[i]["HR Remark"].ToString().Trim();
                                //}
                                //else
                                //{
                                //    if (Regex.Matches(dt.Rows[i]["HR Remark"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["HR Remark"].ToString().Trim(), @"[0-9]").Count > 0)
                                //    {
                                //        objbo.Location = dt.Rows[i]["HR Remark"].ToString().Trim();
                                //    }
                                //    else
                                //    {
                                //        message = message + " Only Special Characters are not allowed for HR Remark";
                                //        ValError = false;
                                //        objbo.Location = dt.Rows[i]["HR Remark"].ToString().Trim();
                                //    }
                                //}

                                ////------

                                //if (Regex.Matches(dt.Rows[i]["President Remark"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["President Remark"].ToString().Trim(), @"[0-9]").Count > 0)
                                //{
                                //    objbo.Department = dt.Rows[i]["President Remark"].ToString().Trim();
                                //}
                                //else
                                //{
                                //    message = message + " Only Special Characters are not allowed for President Remark";
                                //    ValError = false;
                                //    objbo.Department = dt.Rows[i]["President Remark"].ToString().Trim();
                                //}

                                ////------
                                //if (dt.Rows[i]["Status"].ToString().Trim() == "")
                                //{
                                //    ////message = " Please enter Status";
                                //    ////ValError = false;
                                //    objbo.Function = dt.Rows[i]["Status"].ToString().Trim();
                                //}
                                //else
                                //{
                                //    if (Regex.Matches(dt.Rows[i]["Status"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Status"].ToString().Trim(), @"[0-9]").Count > 0)
                                //    {
                                //        objbo.Function = dt.Rows[i]["Status"].ToString().Trim();
                                //    }
                                //    else
                                //    {
                                //        message = message + " Only Special Characters are not allowed for Status";
                                //        ValError = false;
                                //        objbo.Function = dt.Rows[i]["Status"].ToString().Trim();
                                //    }
                                //}
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




                                dr["DEM_EMP_ID"] = objbo.EMP_ID;
                                dr["DEM_GRANT_DATE"] = objbo.Doj;
                                dr["DEM_GRANT_NAME"] = objbo.GRANT_NAME;
                                dr["DEM_VESTING_ID"] = objbo.Tntr;
                                dr["DEM_FMV_ID"] = objbo.Lwd;
                                dr["DEM_NO_OF_OPTION"] = objbo.No_Of_Option_Excel;
                                dr["DEM_RecStatus"] = objbo.RecStatus;
                                dr["DEM_ErrorString"] = objbo.ErrorString;
                                //dr["DEM_LOCATION"] = objbo.Location;
                                //dr["DEM_DEPARTMENT"] = objbo.Department;
                                //dr["DEM_APPRAISER_NAME"] = objbo.Function;

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

                ctlupload("abc1", "MyFolder/", "Create_Grant");






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

        public bool InsertGrantVestingRec(DataTable dt)
        {
            DataTable dt_bulkTemp = new DataTable();

            dt_bulkTemp.Columns.Add("ECODE");
            dt_bulkTemp.Columns.Add("ENAME");

            dt_bulkTemp.Columns.Add("GRANT_NAME");

            dt_bulkTemp.Columns.Add("VESTING_DETAIL_CODE");
            dt_bulkTemp.Columns.Add("VESTING_DATE");
            dt_bulkTemp.Columns.Add("NO_OF_VESTING");

            dt_bulkTemp.Columns.Add("ADMIN_VESTING_REMARK");
            dt_bulkTemp.Columns.Add("PR_VESTING_REMARK");
            dt_bulkTemp.Columns.Add("STATUS");

            dt_bulkTemp.Columns.Add("FMV_PRICE");
            dt_bulkTemp.Columns.Add("TAXABLE_INCOME");
            dt_bulkTemp.Columns.Add("EXERCISE_STATUS");
            dt_bulkTemp.Columns.Add("EXERCISE_BY");
            dt_bulkTemp.Columns.Add("EXERCISE_DATE");
            dt_bulkTemp.Columns.Add("NO_OF_EXERCISE");

            dt_bulkTemp.Columns.Add("SALE_FMV_PRICE");
            dt_bulkTemp.Columns.Add("SALE_STATUS");
            dt_bulkTemp.Columns.Add("SALE_BY");
            dt_bulkTemp.Columns.Add("SALE_DATE");
            dt_bulkTemp.Columns.Add("NO_OF_SALE");

            dt_bulkTemp.Columns.Add("LBV");
            dt_bulkTemp.Columns.Add("LAV");
            dt_bulkTemp.Columns.Add("TOTAL_LAPSED");

            dt_bulkTemp.Columns.Add("EXERCISE_APPROVED_DATE");
            dt_bulkTemp.Columns.Add("SALE_APPROVED_DATE");

            dt_bulkTemp.Columns.Add("CREATEDBY");
            dt_bulkTemp.Columns.Add("DEM_ErrorString");
            dt_bulkTemp.Columns.Add("DEM_RecStatus");
            dt_bulkTemp.Columns.Add("VESTING_NAME");


            SqlConnection con;
            bool status = false;
            string msg = "";
            bool ValError = true;
            string message = "";
            vesting_creation_BO vesting_BO = new vesting_creation_BO();
            employee_saleBAL Emp_sale_BAL = new employee_saleBAL();
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
                                #region validation start
                                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                                var regexItem_varchar = new Regex("^[a-zA-Z]*$");
                                var regexItem_onlyNumeric = new Regex("^[0-9 ]*$");
                                var regexItem_decimal = new Regex("^[1-9]\\d*(\\.\\d{1,2})?$"); //("^[0-9 ]*$");
                                var regexDateDDMMYYYY = new Regex("^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[13-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$");

                                if (dt.Rows[i]["EMP_CODE"].ToString().Trim() == "")
                                {
                                    message = " Please enter Employee Code";
                                    ValError = false;
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["EMP_CODE"].ToString().Trim()))
                                    {
                                        vesting_BO.ECODE = dt.Rows[i]["EMP_CODE"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["EMP_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter Employee Name";
                                    ValError = false;
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["EMP_NAME"].ToString().Trim()))
                                    {
                                        vesting_BO.ENAME = dt.Rows[i]["EMP_NAME"].ToString().Trim();
                                    }
                                    else
                                    {
                                        vesting_BO.ENAME = dt.Rows[i]["EMP_NAME"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["GRANT_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter GRANT NAME";
                                    ValError = false;

                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["GRANT_NAME"].ToString().Trim()))
                                    {
                                        vesting_BO._GRANT_NAME = dt.Rows[i]["GRANT_NAME"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["VESTING_NAME"].ToString().Trim() == "")
                                {
                                    message = " Please enter VESTING NAME";
                                    ValError = false;
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["VESTING_NAME"].ToString().Trim()))
                                    {
                                        vesting_BO.VESTING_NAME = dt.Rows[i]["VESTING_NAME"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["VESTING_DETAIL_CODE"].ToString().Trim() == "")
                                {
                                    message = " Please enter VESTING DETAIL CODE";
                                    ValError = false;
                                }
                                else
                                {

                                    if (regexItem.IsMatch(dt.Rows[i]["VESTING_DETAIL_CODE"].ToString().Trim()))
                                    {
                                        vesting_BO.VESTING_DETAIL_CODE = dt.Rows[i]["VESTING_DETAIL_CODE"].ToString().Trim();
                                    }
                                }


                                if (dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim() == "")
                                {
                                    message = " Please enter VESTING Date";
                                    ValError = false;
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                    {
                                        message = message + " Invalid Date format for VESTING Date";
                                        ValError = false;
                                    }
                                    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim()))
                                    {
                                        vesting_BO.VESTING_DATE = dt.Rows[i]["VESTING_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                    else
                                    {
                                        message = message + " Invalid Date format for VESTING Date";
                                        ValError = false;
                                    }
                                }

                                if (dt.Rows[i]["NO_OF_VESTING"].ToString().Trim() == "")
                                {
                                    message = " Please enter No of Vesting";
                                    ValError = false;
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in NO OF VESTING";
                                            ValError = false;

                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in NO OF VESTING";
                                            ValError = false;
                                        }
                                        else
                                        {
                                            vesting_BO.NO_OF_VESTING = Convert.ToDouble(dt.Rows[i]["NO_OF_VESTING"].ToString().Trim());
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in NO OF VESTING";
                                        ValError = false;
                                    }
                                }

                                if (dt.Rows[i]["ADMIN_VESTING_REMARK"].ToString().Trim() == "")
                                {
                                    //message = " Please enter GRANT NAME";
                                    //ValError = false;                                  
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["ADMIN_VESTING_REMARK"].ToString().Trim()))
                                    {
                                        vesting_BO.ADMIN_VESTING_REMARK = dt.Rows[i]["ADMIN_VESTING_REMARK"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["PR_VESTING_REMARK"].ToString().Trim() == "")
                                {
                                    //message = " Please enter PR VESTING REMARK";
                                    //ValError = false;                                   
                                }
                                else
                                {
                                    if (regexItem.IsMatch(dt.Rows[i]["PR_VESTING_REMARK"].ToString().Trim()))
                                    {
                                        vesting_BO.PR_VESTING_REMARK = dt.Rows[i]["PR_VESTING_REMARK"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["STATUS"].ToString().Trim() == "")
                                {
                                    //message = " Please enter GRANT NAME";
                                    //ValError = false;                                    
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["Status"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["Status"].ToString().Trim(), @"[0-9]").Count > 0)
                                    {
                                        vesting_BO.Status = dt.Rows[i]["Status"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["EXEC_FMV_PRICE"].ToString().Trim() != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["EXEC_FMV_PRICE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["EXEC_FMV_PRICE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in EXERCISE FMV PRICE";
                                            ValError = false;
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["EXEC_FMV_PRICE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in EXERCISE FMV PRICE";
                                            ValError = false;
                                        }
                                        else
                                        {
                                            vesting_BO.EXERCISE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["EXEC_FMV_PRICE"].ToString().Trim());
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in EXERCISE FMV PRICE";
                                        ValError = false;
                                    }
                                }

                                if (Convert.ToString(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim()) != "")
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in TAXABLE INCOME";
                                            ValError = false;
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in TAXABLE INCOME";
                                            ValError = false;
                                        }
                                        else
                                        {
                                            vesting_BO.TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i]["TAXABLE_INCOME"].ToString().Trim());
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in TAXABLE INCOME";
                                        ValError = false;
                                    }
                                }

                                if (dt.Rows[i]["EXERCISE_BY_CODE"].ToString().Trim() == "")
                                {
                                    //message = " Please enter PR VESTING REMARK";
                                    //ValError = false;                                   
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["EXERCISE_BY_CODE"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["EXERCISE_BY_CODE"].ToString().Trim(), @"[0-9]").Count > 0)
                                    {
                                        vesting_BO.EXERCISE_BY = dt.Rows[i]["EXERCISE_BY_CODE"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["EXERCISE_STATUS"].ToString().Trim() == "")
                                {
                                    //message = " Please enter PR VESTING REMARK";
                                    //ValError = false;                                   
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["EXERCISE_STATUS"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["EXERCISE_STATUS"].ToString().Trim(), @"[0-9]").Count > 0)
                                    {
                                        vesting_BO.EXERCISE_STATUS = dt.Rows[i]["EXERCISE_STATUS"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim() == "")
                                {
                                    message = " Please enter EXERCISE Date";
                                    ValError = false;
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                    {
                                        message = message + " Invalid Date format for EXERCISE Date";
                                        ValError = false;

                                    }
                                    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim()))
                                    {
                                        vesting_BO.EXERCISE_DATE = dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                    else
                                    {
                                        message = message + " Invalid Date format for EXERCISE Date";
                                        ValError = false;
                                    }
                                }

                                if (dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim() == "")
                                {
                                    message = " Please enter NO OF EXERCISE";
                                    ValError = false;
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in NO OF EXERCISE";
                                            ValError = false;
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in NO OF EXERCISE";
                                            ValError = false;
                                        }
                                        else
                                        {
                                            vesting_BO.NO_OF_EXERCISE = Convert.ToDouble(dt.Rows[i]["NO_OF_EXERCISE"].ToString().Trim());
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in NO OF EXERCISE";
                                        ValError = false;
                                    }
                                }


                                if (dt.Rows[i]["EXERCISE_APPROVED_DATE(DD-MM-YYYY)"].ToString().Trim() == "")
                                {
                                    message = " Please enter EXERCISE Date";
                                    ValError = false;
                                }
                                else
                                {
                                    if (Regex.Matches(dt.Rows[i]["EXERCISE_APPROVED_DATE(DD-MM-YYYY)"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                    {
                                        message = message + " Invalid Date format for EXERCISE Date";
                                        ValError = false;
                                    }
                                    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["EXERCISE_APPROVED_DATE(DD-MM-YYYY)"].ToString().Trim()))
                                    {
                                        vesting_BO.EXERCISE_APPRV_DATE = dt.Rows[i]["EXERCISE_DATE(DD-MM-YYYY)"].ToString().Trim();

                                    }
                                    else
                                    {
                                        message = message + " Invalid Date format for EXERCISE Date";
                                        ValError = false;
                                    }
                                }

                                if (dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim() == "")
                                {
                                    message = " Please enter SALE FMV PRICE";
                                    ValError = false;
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in SALE FMV PRICE";
                                            ValError = false;

                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in SALE FMV PRICE";
                                            ValError = false;
                                        }
                                        else
                                        {
                                            vesting_BO._SALE_FMV_PRICE = Convert.ToDouble(dt.Rows[i]["SALE_FMV_PRICE"].ToString().Trim());
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in SALE FMV PRICE";
                                        ValError = false;
                                    }
                                }


                                if (dt.Rows[i]["SALE_STATUS"].ToString().Trim() == "")
                                {
                                    //message = " Please enter PR VESTING REMARK";
                                    //ValError = false;                                   
                                }
                                else
                                {

                                    if (Regex.Matches(dt.Rows[i]["SALE_STATUS"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["SALE_STATUS"].ToString().Trim(), @"[0-9]").Count > 0)
                                    {
                                        vesting_BO.SALE_STATUS = dt.Rows[i]["SALE_STATUS"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["SALE_BY_CODE"].ToString().Trim() == "")
                                {
                                    //message = " Please enter PR VESTING REMARK";
                                    //ValError = false;                                   
                                }
                                else
                                {

                                    if (Regex.Matches(dt.Rows[i]["SALE_BY_CODE"].ToString().Trim(), @"[a-zA-Z]").Count > 0 || Regex.Matches(dt.Rows[i]["SALE_BY_CODE"].ToString().Trim(), @"[0-9]").Count > 0)
                                    {
                                        vesting_BO.SALE_BY = dt.Rows[i]["SALE_BY_CODE"].ToString().Trim();
                                    }
                                }

                                if (dt.Rows[i]["SALE_DATE(DD-MM-YYYY)"].ToString().Trim() != "")
                                {
                                    if (Regex.Matches(dt.Rows[i]["SALE_DATE(DD-MM-YYYY)"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                    {
                                        message = message + " Invalid Date format for SALE Date";
                                        ValError = false;
                                    }
                                    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["SALE_DATE(DD-MM-YYYY)"].ToString().Trim()))
                                    {
                                        vesting_BO._SALE_DATE = dt.Rows[i]["SALE_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                    else
                                    {
                                        message = message + " Invalid Date format for SALE Date";
                                        ValError = false;
                                    }
                                }



                                if (dt.Rows[i]["NO_OF_SALE"].ToString().Trim() != "")
                                {

                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["NO_OF_SALE"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["NO_OF_SALE"].ToString().Trim()) == 0)
                                        {
                                            message = message + "Zero cant be added in No Of Sale";
                                            ValError = false;
                                            //Emp_sale_BO._NO_OF_SALE = Convert.ToDouble(dt.Rows[i]["NO_OF_SALE"].ToString().Trim());
                                        }
                                        else if (Convert.ToInt32(dt.Rows[i]["NO_OF_SALE"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in No Of Sale";
                                            ValError = false;
                                            //Emp_sale_BO._NO_OF_SALE = Convert.ToDouble(dt.Rows[i]["NO_OF_SALE"].ToString().Trim());
                                        }
                                        else
                                        {

                                            vesting_BO._NO_OF_SALE = Convert.ToDouble(dt.Rows[i]["NO_OF_SALE"].ToString().Trim());
                                            //ValError = true;
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in No Of Sale";
                                        ValError = false;
                                        //Emp_sale_BO._NO_OF_SALE = Convert.ToDouble(dt.Rows[i]["NO_OF_SALE"].ToString().Trim());
                                    }
                                }

                                if (dt.Rows[i]["SALE_APPROVED_DATE(DD-MM-YYYY)"].ToString().Trim() != "")
                                {
                                    if (Regex.Matches(dt.Rows[i]["SALE_APPROVED_DATE(DD-MM-YYYY)"].ToString().Trim(), @"[a-zA-Z]").Count > 0)
                                    {
                                        message = message + " Invalid Date format for SALE Date";
                                        ValError = false;
                                    }
                                    else if (regexDateDDMMYYYY.IsMatch(dt.Rows[i]["SALE_APPROVED_DATE(DD-MM-YYYY)"].ToString().Trim()))
                                    {
                                        vesting_BO.SALE_APPRV_DATE = dt.Rows[i]["SALE_APPROVED_DATE(DD-MM-YYYY)"].ToString().Trim();
                                    }
                                    else
                                    {
                                        message = message + " Invalid Date format for SALE Date";
                                        ValError = false;
                                    }
                                }


                                if (dt.Rows[i]["LBV"].ToString().Trim() == "")
                                {
                                    //message = " Please enter No Of Sale";
                                    //ValError = false;                                  
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["LBV"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["LBV"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in LBV";
                                            ValError = false;
                                        }
                                        else
                                        {
                                            vesting_BO.LBV = Convert.ToDouble(dt.Rows[i]["LBV"].ToString().Trim());
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in LBV";
                                        ValError = false;
                                    }
                                }

                                if (dt.Rows[i]["LAV"].ToString().Trim() == "")
                                {
                                    //message = " Please enter LAV";
                                    //ValError = false;

                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["LAV"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["LAV"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero inLAV";
                                            ValError = false;
                                        }
                                        else
                                        {

                                            vesting_BO.LAV = Convert.ToDouble(dt.Rows[i]["LAV"].ToString().Trim());
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in LAV";
                                        ValError = false;
                                    }
                                }


                                if (dt.Rows[i]["TOTAL_LAPSED"].ToString().Trim() == "")
                                {
                                    //message = " Please enter TOTAL LAPSED";
                                    //ValError = false;                                    
                                }
                                else
                                {
                                    if (regexItem_onlyNumeric.IsMatch(dt.Rows[i]["TOTAL_LAPSED"].ToString().Trim()))
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["TOTAL_LAPSED"].ToString().Trim()) < 0)
                                        {
                                            message = message + "Cannot be less then zero in TOTAL LAPSED";
                                            ValError = false;
                                        }
                                        else
                                        {
                                            vesting_BO.TOTAL_LAPSED = Convert.ToDouble(dt.Rows[i]["TOTAL_LAPSED"].ToString().Trim());
                                        }
                                    }
                                    else
                                    {
                                        message = message + "Only numbers are allowed in TOTAL LAPSED";
                                        ValError = false;
                                    }
                                }

                                if (ValError == false)
                                {
                                    vesting_BO.ErrorString = sb.Append(message).ToString().Trim();
                                    vesting_BO.RecStatus = "Failed";
                                    FailRecords = FailRecords + 1;
                                }
                                else
                                {
                                    vesting_BO.ErrorString = "N.A.";
                                    vesting_BO.RecStatus = "Success";
                                    SuccRecords = SuccRecords + 1;
                                }
                                #endregion validation end

                                DataRow dr = dt_bulkTemp.NewRow();
                                dr["ECODE"] = vesting_BO.ECODE;//Emp Code
                                dr["ENAME"] = vesting_BO.ENAME;//Emp name

                                dr["GRANT_NAME"] = vesting_BO._GRANT_NAME;//Grant Name                                

                                dr["VESTING_DETAIL_CODE"] = vesting_BO.VESTING_DETAIL_CODE;//VESTING DETAIL CODE
                                dr["VESTING_DATE"] = vesting_BO.VESTING_DATE;//Vesting Date
                                dr["NO_OF_VESTING"] = vesting_BO.NO_OF_VESTING;//NO OF VESTING

                                dr["ADMIN_VESTING_REMARK"] = vesting_BO.ADMIN_VESTING_REMARK;//ADMIN VESTING REMARK
                                dr["PR_VESTING_REMARK"] = vesting_BO.PR_VESTING_REMARK;//President_VESTING_REMARK
                                dr["STATUS"] = vesting_BO.Status;//Percentage

                                dr["FMV_PRICE"] = vesting_BO.EXERCISE_FMV_PRICE;//EXEC FMV PRICE
                                dr["TAXABLE_INCOME"] = vesting_BO.TAXABLE_INCOME;//TAXABLE INCOME
                                dr["EXERCISE_STATUS"] = vesting_BO.EXERCISE_STATUS;//EXERCISE STATUS
                                dr["EXERCISE_BY"] = vesting_BO.EXERCISE_BY;//EXERCISE BY
                                dr["EXERCISE_DATE"] = vesting_BO.EXERCISE_DATE;//EXERCISE DATE
                                dr["NO_OF_EXERCISE"] = vesting_BO.NO_OF_EXERCISE;//NO OF EXERCISE                               

                                dr["SALE_FMV_PRICE"] = vesting_BO._SALE_FMV_PRICE;//SALE FMV PRICE
                                dr["SALE_STATUS"] = vesting_BO.SALE_STATUS;//SALE STATUS
                                dr["SALE_BY"] = vesting_BO.SALE_BY;//SALE BY
                                dr["SALE_DATE"] = vesting_BO._SALE_DATE;//SALE DATE
                                dr["NO_OF_SALE"] = vesting_BO._NO_OF_SALE;//NO OF SALE

                                dr["LBV"] = vesting_BO.LBV;//LBV
                                dr["LAV"] = vesting_BO.LAV;//LAV
                                dr["TOTAL_LAPSED"] = vesting_BO.TOTAL_LAPSED;//TOTAL LAPSED

                                dr["EXERCISE_APPROVED_DATE"] = vesting_BO.EXERCISE_APPRV_DATE;//EXERCISE APPROVED DATE
                                dr["SALE_APPROVED_DATE"] = vesting_BO.SALE_APPRV_DATE;//SALE APPROVED DATE                               

                                dr["CREATEDBY"] = Convert.ToString(Session["ECode"]);
                                dr["DEM_ErrorString"] = vesting_BO.ErrorString;//Error String
                                dr["DEM_RecStatus"] = vesting_BO.RecStatus;//RecStatus
                                dr["VESTING_NAME"] = vesting_BO.VESTING_NAME;//VESTING DETAIL CODE
                                dt_bulkTemp.Rows.Add(dr);

                                ValError = true;
                                message = "";
                                sb.Clear();
                                i = i + 1;
                            }
                        }
                    }
                }

                DataView view = new DataView(dt_bulkTemp);
                view.RowFilter = "DEM_RecStatus = 'Failed'";
                DataTable Dt1 = new DataTable();
                Dt1 = view.ToTable(true);


                if (Dt1.Rows.Count > 0)
                {
                    FailRecords = Dt1.Rows.Count;
                    SuccRecords = TotalRecords - FailRecords;// dt.Select("dem_recstatus = 'Failed'").Length;
                    Session["TotalRecords"] = Convert.ToString(TotalRecords);
                    Session["SuccRecords"] = SuccRecords;
                    Session["FailRecords"] = FailRecords;
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Error while uploading file,Please check and upload again.";
                    ViewState["ExcelFailRecord"] = Dt1;
                    return false;
                }
                else
                {
                    dt_bulkTemp.ToCSV(strCSV);
                    ctlupload("abc1", "MyFolder/", "Create_Grant_Vesting");
                }
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
                objbo = null;
            }
            return status;
        }

        public void ctlupload(string fileNameWithoutExt, string FolderPath, string MasterType)
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
                string templine = "";
                if (MasterType == "Emp_Sale")
                {
                    templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_TBL_EMPLOYEE_EXCER_SALE_TRANSACTION_DETAILS_DUMP fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(ECODE \"trim(:ECODE)\",ENAME \"trim(:ENAME)\",GRANT_NAME \"trim(:GRANT_NAME)\",VESTING_DETAIL_CODE \"trim(:VESTING_DETAIL_CODE)\",VESTING_DATE \"trim(:VESTING_DATE)\",NO_OF_VESTING \"trim(:NO_OF_VESTING)\",GRANT_PRICE \"trim(:GRANT_PRICE)\",EXERCISE_FMV_PRICE \"trim(:EXERCISE_FMV_PRICE)\",SALE_FMV_PRICE \"trim(:SALE_FMV_PRICE)\",NO_OF_SALE \"trim(:NO_OF_SALE)\",SALE_DATE \"trim(:SALE_DATE)\",SECURITY_NAME \"trim(:SECURITY_NAME)\",DPID \"trim(:DPID)\",CLIENT_ID \"trim(:CLIENT_ID)\",MEMBER_TYPE \"trim(:MEMBER_TYPE)\"," +
                   "BANK_NAME \"trim(:BANK_NAME)\",BANK_BRANCH \"trim(:BANK_BRANCH)\",ACC_NO \"trim(:ACC_NO)\",IFSC \"trim(:IFSC)\"," +
                   "SALE_OFFER_FILE_PATH \"trim(:SALE_OFFER_FILE_PATH)\",SALE_DECLARATION_FILE_PATH \"trim(:SALE_DECLARATION_FILE_PATH)\",SALE_TRAN_ID \"trim(:SALE_TRAN_ID)\"," +
                    "CREATEDBY \"trim(:CREATEDBY)\",DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_RecStatus \"trim(:DEM_RecStatus)\")";
                }
                else if (MasterType == "Emp_Excerice")
                {
                    templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_TBL_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_DUMP fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(ECODE \"trim(:ECODE)\"," +
                         "ENAME \"trim(:ENAME)\",GRANT_NAME \"trim(:GRANT_NAME)\",VESTING_DETAIL_CODE \"trim(:VESTING_DETAIL_CODE)\",VESTING_DATE \"trim(:VESTING_DATE)\",NO_OF_VESTING \"trim(:NO_OF_VESTING)\"," +
                         "GRANT_PRICE \"trim(:GRANT_PRICE)\",GRANT_FMV_PRICE \"trim(:GRANT_FMV_PRICE)\",NO_OF_EXERCISE \"trim(:NO_OF_EXERCISE)\",EXERCISE_DATE \"trim(:EXERCISE_DATE)\"," +
                         "TAXABLE_INCOME \"trim(:TAXABLE_INCOME)\",EXERCISE_CONSIDERATION \"trim(:EXERCISE_CONSIDERATION)\",FMV_GRANT_OPTION_EXERCISE \"trim(:FMV_GRANT_OPTION_EXERCISE)\",REVISED_TAXABLE_INCOME \"trim(:REVISED_TAXABLE_INCOME)\",TAX_PER_OPTION \"trim(:TAX_PER_OPTION)\",PERQ_TAX_AMOUNT \"trim(:PERQ_TAX_AMOUNT)\",TOTAL_AMOUNT \"trim(:TOTAL_AMOUNT)\"," +
                         "SECURITY_NAME \"trim(:SECURITY_NAME)\",DPID \"trim(:DPID)\",CLIENT_ID \"trim(:CLIENT_ID)\",MEMBER_TYPE \"trim(:MEMBER_TYPE)\"," +
                         "PAYMENT_MODE \"trim(:PAYMENT_MODE)\",BANK_NAME \"trim(:BANK_NAME)\",BANK_BRANCH \"trim(:BANK_BRANCH)\",ACC_NO \"trim(:ACC_NO)\",IFSC \"trim(:IFSC)\"," +
                         "CHEQUE_NUMBER \"trim(:CHEQUE_NUMBER)\",CHEQUE_DATE \"trim(:CHEQUE_DATE)\",CREATEDBY \"trim(:CREATEDBY)\"," +
                         /*EXERCISE_TRAN_ID \"trim(:EXERCISE_TRAN_ID)\",*/
                         "CHEQUE_AMOUNT \"trim(:CHEQUE_AMOUNT)\",NEFT_FILE_PATH \"trim(:NEFT_FILE_PATH)\",CHEQUE_FILE_PATH \"trim(:CHEQUE_FILE_PATH)\"," +
                         "DEMAT_FILE_PATH \"trim(:DEMAT_FILE_PATH)\",CHEQUE_FILE_PATH_FRESH \"trim(:CHEQUE_FILE_PATH_FRESH)\"," +
                         "LOAN_LENDER_BANK_NAME \"trim(:LOAN_LENDER_BANK_NAME)\",LOAN_AMOUNT \"trim(:LOAN_AMOUNT)\",LOAN_MARGIN_AMOUNT \"trim(:LOAN_MARGIN_AMOUNT)\",LOAN_MARGIN_PAYMENT_MODE \"trim(:LOAN_MARGIN_PAYMENT_MODE)\",NEFT_UTR_NO \"trim(:NEFT_UTR_NO)\"," +
                         "DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_RecStatus \"trim(:DEM_RecStatus)\")";
                }
                else if (MasterType == "FMV")
                {
                    templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_tbl_dump_table fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(DEM_EMP_ID \"trim(:DEM_EMP_ID)\",DEM_GRANT_DATE \"trim(:DEM_GRANT_DATE)\",DEM_VESTING_ID \"trim(:DEM_VESTING_ID)\",DEM_FMV_ID \"trim(:DEM_FMV_ID)\",DEM_GRANT_NAME \"trim(:DEM_GRANT_NAME)\",DEM_NO_OF_OPTION \"trim(:DEM_NO_OF_OPTION)\",DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_RecStatus \"trim(:DEM_RecStatus)\",DEM_EU_ID \"trim(:DEM_EU_ID)\",DEM_COMPANY_NAME \"trim(:DEM_COMPANY_NAME)\")";
                }
                else if (MasterType == "Create_Grant")
                {
                    templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_tbl_dump_table fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(DEM_EMP_ID \"trim(:DEM_EMP_ID)\",DEM_GRANT_DATE \"trim(:DEM_GRANT_DATE)\",DEM_VESTING_ID \"trim(:DEM_VESTING_ID)\",DEM_FMV_ID \"trim(:DEM_FMV_ID)\",DEM_GRANT_NAME \"trim(:DEM_GRANT_NAME)\",DEM_NO_OF_OPTION \"trim(:DEM_NO_OF_OPTION)\",DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_RecStatus \"trim(:DEM_RecStatus)\")";
                    /*,DEM_LOCATION \"trim(:DEM_LOCATION)\",DEM_DEPARTMENT \"trim(:DEM_DEPARTMENT)\",DEM_APPRAISER_NAME \"trim(:DEM_APPRAISER_NAME)\"*/
                }
                else if (MasterType == "Create_Grant_Vesting")
                {
                    templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_TBL_GRANT_VESTING_DETAILS_DUMP fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(ECODE \"trim(:ECODE)\",ENAME \"trim(:ENAME)\",GRANT_NAME \"trim(:GRANT_NAME)\",VESTING_DETAIL_CODE \"trim(:VESTING_DETAIL_CODE)\",VESTING_DATE \"trim(:VESTING_DATE)\",NO_OF_VESTING \"trim(:NO_OF_VESTING)\"," +
                     "ADMIN_VESTING_REMARK \"trim(:ADMIN_VESTING_REMARK)\",PR_VESTING_REMARK \"trim(:PR_VESTING_REMARK)\",STATUS \"trim(:STATUS)\"," +
                     "FMV_PRICE \"trim(:FMV_PRICE)\",TAXABLE_INCOME \"trim(:TAXABLE_INCOME)\",EXERCISE_STATUS \"trim(:EXERCISE_STATUS)\",EXERCISE_BY \"trim(:EXERCISE_BY)\",EXERCISE_DATE \"trim(:EXERCISE_DATE)\",NO_OF_EXERCISE \"trim(:NO_OF_EXERCISE)\"," +
                     "SALE_FMV_PRICE \"trim(:SALE_FMV_PRICE)\",SALE_STATUS \"trim(:SALE_STATUS)\",SALE_BY \"trim(:SALE_BY)\",SALE_DATE \"trim(:SALE_DATE)\",NO_OF_SALE \"trim(:NO_OF_SALE)\"," +
                     "LBV \"trim(:LBV)\",LAV \"trim(:LAV)\",TOTAL_LAPSED \"trim(:TOTAL_LAPSED)\",EXERCISE_APPROVED_DATE \"trim(:EXERCISE_APPROVED_DATE)\",SALE_APPROVED_DATE \"trim(:SALE_APPROVED_DATE)\"," +
                     "CREATEDBY \"trim(:CREATEDBY)\",DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_RecStatus \"trim(:DEM_RecStatus)\",VESTING_NAME \"trim(:VESTING_NAME)\")";
                }
                else
                {
                    templine = "OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE \"" + FileWithExtension + "\" APPEND INTO TABLE ESOP_tbl_dump_table fields terminated by \",\" optionally enclosed by '\"' TRAILING NULLCOLS(DEM_EMP_ID \"trim(:DEM_EMP_ID)\",DEM_GRANT_DATE \"trim(:DEM_GRANT_DATE)\",DEM_VESTING_ID \"trim(:DEM_VESTING_ID)\",DEM_FMV_ID \"trim(:DEM_FMV_ID)\",DEM_GRANT_NAME \"trim(:DEM_GRANT_NAME)\",DEM_NO_OF_OPTION \"trim(:DEM_NO_OF_OPTION)\",DEM_ErrorString \"trim(:DEM_ErrorString)\",DEM_RecStatus \"trim(:DEM_RecStatus)\",DEM_EU_ID \"trim(:DEM_EU_ID)\")";
                }
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
                    objbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                    //DataSet ds = objbal.Insert_Copy_EMP(objbo);

                    DataSet ds = new DataSet();
                    if (MasterType == "FMV")
                    {
                        ds = objbal.Insert_FMV(objbo);
                    }
                    else if (MasterType == "VALUATION")
                    {
                        ds = objbal.Insert_VALUATION(objbo);
                    }
                    else if (MasterType == "VESTING")
                    {
                        ds = objbal.Insert_VESTING(objbo);
                    }
                    else if (MasterType == "Emp_Sale")
                    {
                        employee_saleBO Emp_sale_BO = new employee_saleBO();
                        employee_saleBAL Emp_sale_BAL = new employee_saleBAL();
                        ds = Emp_sale_BAL.InsertEmployeeSaleRec(Emp_sale_BO);
                    }
                    else if (MasterType == "Emp_Excerice")
                    {
                        employee_exerciseBO Emp_exercise_BO = new employee_exerciseBO();
                        employee_exerciseBAL Emp_exercise_BAL = new employee_exerciseBAL();
                        ds = Emp_exercise_BAL.InsertEmployeeExerRec(Emp_exercise_BO);
                    }
                    else if (MasterType == "Create_Grant")
                    {
                        objbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                        ds = objbal.Insert_Copy_EMP_Ex_Data(objbo);
                        DataTable dt1 = ds.Tables[0];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            if (dt1.Rows[i]["dem_recstatus"].ToString() == "Success")
                            {
                                objbo.GRANT_ID = dt1.Rows[i]["dem_doj"].ToString();
                                DataSet ds1 = objbal.INSERT_GVD(objbo);
                                DataTable dt2 = ds1.Tables[1];
                                gvdttoexcel.DataSource = dt2;
                                gvdttoexcel.DataBind();
                            }
                        }
                        //NewExportToExcel();
                        //ExportToExcel1();
                    }
                    //else if (MasterType == "Create_Grant_Vesting")
                    //{
                    //    objbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                    //    ds = objbal.Insert_Grant_Vesting(objbo);
                    //    DataTable dt1 = ds.Tables[0];
                    //    for (int i = 0; i <= dt1.Rows.Count; i++)
                    //    {
                    //        if (dt1.Rows[i]["dem_recstatus"].ToString() == "Success")
                    //        {
                    //            objbo.GRANT_ID = dt1.Rows[i]["ECODE"].ToString();
                    //            ds = objbal.INSERT_GVD(objbo);

                    //            //gvdttoexcel.DataBind();
                    //            //gvdttoexcel.DataSource = dt1;
                    //            //ExportToExcel1(dt1);

                    //        }
                    //    }
                    //}
                    DataTable dt = ds.Tables[0];

                    SuccRecords = dt.Select("dem_recstatus = 'Success'").Length;
                    FailRecords = TotalRecords - SuccRecords;// dt.Select("dem_recstatus = 'Failed'").Length;
                    Session["TotalRecords"] = Convert.ToString(TotalRecords);
                    Session["SuccRecords"] = SuccRecords;
                    Session["FailRecords"] = FailRecords;
                    TotalRecords = Convert.ToInt32(Session["TotalRecords"].ToString());
                    SuccRecords = Convert.ToInt32(Session["SuccRecords"].ToString());
                    FailRecords = Convert.ToInt32(Session["FailRecords"].ToString());
                    DataView view = new DataView(dt);
                    view.RowFilter = "DEM_RecStatus = 'Failed'";
                    //DataTable Dt1 = new DataTable();
                    //Dt1 = view.ToTable(true);
                    Session["DumpTableHistory"] = view.ToTable(true);
                    string status1 = "Approved";
                    string Attachment = Server.MapPath(@"/Fmv_excel/Employee.xlsx");
                    ViewState["ExcelFailRecord"] = null;

                    if (SuccRecords > 0)
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "File uploaded successfully.";
                    }
                    else
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Error while uploading file, please check excel file";
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Error while uploading file, please check excel file";
            }

        }

        private void ExportToExcel1()
        {
            try
            {
                Response.Clear();
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";

                string FilePath = Server.MapPath("Grant_Creation");
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                string FileName = "Grant_Creation.xls"; //+DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")+ 

                string serverfile = FilePath + "/" + FileName;

                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);

                var gvdttoexcel = new GridView();
                gvdttoexcel.AllowSorting = false;

                DataSet ds = objbal.INSERT_GVD(objbo);

                DataTable dt = new DataTable();
                dt = ds.Tables[1];

                gvdttoexcel.DataSource = dt;
                gvdttoexcel.DataBind();

                gvdttoexcel.HeaderStyle.Font.Bold = true;
                gvdttoexcel.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
                gvdttoexcel.HeaderRow.VerticalAlign = VerticalAlign.Middle;

                gvdttoexcel.RenderControl(htmltextwrtter);

                if (System.IO.File.Exists(serverfile))
                {
                    System.IO.File.Delete(serverfile);
                }
                //Writetherenderedcontenttoafile.
                string renderedGridView = strwritter.ToString();
                System.IO.File.WriteAllText(serverfile, renderedGridView);

                //Response.Write(strwritter.ToString());
                //HttpContext.Current.ApplicationInstance.CompleteRequest(); 
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
            finally
            {
                //Response.End();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        protected void downloadFailedRec(object sender, EventArgs e)
        {

            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                System.Data.DataTable dtcheck = new System.Data.DataTable();
                string Table = "";
                dtcheck = (DataTable)ViewState["ExcelFailRecord"];
                if (dtcheck == null)
                {
                    //if (ddlData.SelectedItem.Text == "Employee Sale")
                    //{
                    //    Table = "Sale";
                    //}
                    //if (ddlData.SelectedItem.Text == "Employee Excercise")
                    //{
                    //    Table = "Excerice";
                    //}
                    //if (ddlData.SelectedItem.Text == "FMV Master")
                    //{
                    //    Table = "FMV";
                    //}
                    //if (ddlData.SelectedItem.Text == "Grant Creation Master")
                    //{
                    //    Table = "Grant";
                    //}
                    //if (ddlData.SelectedItem.Text == "Valuation Master")
                    //{
                    //    Table = "Valuation";
                    //}
                    //if (ddlData.SelectedItem.Text == "Vesting Master")
                    //{
                    //    Table = "Vesting";
                    //}
                    dt = (DataTable)Session["DumpTableHistory"];
                    //dt = objbal.getFailedDataTableWise(Table);
                }
                else
                {
                    dt = dtcheck.Copy();
                }


                if (dt.Rows.Count == 0)
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

        //protected void LinkButton_Click(object sender, EventArgs e)
        //{

        //    string filePath = Server.MapPath("~/ExcelFormat/ESOP Excel Files.zip");
        //    Response.ContentType = ContentType;
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        //    Response.WriteFile(filePath);
        //    Response.End();

        //}

        protected void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "";
                if (ddlData.SelectedValue == "1")
                {
                    filePath = Server.MapPath("~/ExcelFormat/FMV.xlsx");
                }
                else if (ddlData.SelectedValue == "2")
                {
                    filePath = Server.MapPath("~/ExcelFormat/Grant.xlsx");
                }
                else if (ddlData.SelectedValue == "3")
                {
                    filePath = Server.MapPath("~/ExcelFormat/Valuationmaster.xlsx");
                }
                else if (ddlData.SelectedValue == "4")
                {
                    filePath = Server.MapPath("~/ExcelFormat/VestingMaster.xlsx");
                }
                else if (ddlData.SelectedValue == "5")
                {
                    filePath = Server.MapPath("~/ExcelFormat/Emp_sale.xlsx");
                }
                else if (ddlData.SelectedValue == "6")
                {
                    filePath = Server.MapPath("~/ExcelFormat/Emp_Exercise.xlsx");
                }
                else if (ddlData.SelectedValue == "7")
                {
                    filePath = Server.MapPath("~/ExcelFormat/Grant_Vesting.xlsx");
                }
                else if (ddlData.SelectedValue == "0")
                {
                }
                if (ddlData.SelectedValue != "0")
                {
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        //public void NewExportToExcel()
        //{
        //    try
        //    {
        //        DataSet ds = objbal.INSERT_GVD(objbo);
        //        DataTable dt = new DataTable();
        //        dt = ds.Tables[1];

        //        string FilePath = Server.MapPath("~/Grant_Creation");

        //        if (!Directory.Exists(FilePath))
        //        {
        //            Directory.CreateDirectory(FilePath);
        //        }

        //        string FileName = "Grant_Creation" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".xls";

        //        string serverfile = FilePath + "/" + FileName;

        //        StreamWriter wr = new StreamWriter(serverfile, true);

        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
        //        }

        //        wr.WriteLine();

        //        //write rows to excel file
        //        for (int i = 0; i < (dt.Rows.Count); i++)
        //        {
        //            for (int j = 0; j < dt.Columns.Count; j++)
        //            {
        //                if (dt.Rows[i][j] != null)
        //                {
        //                    wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
        //                }
        //                else
        //                {
        //                    wr.Write("\t");
        //                }
        //            }
        //            //go to next line
        //            wr.WriteLine();
        //        }
        //        //close file
        //        wr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //    }
        //}

        //public void NewExportToExcel()
        //{
        //    try
        //    {
        //        DataSet ds = objbal.INSERT_GVD(objbo);
        //        DataTable dt = new DataTable();
        //        dt = ds.Tables[1];

        //        string FilePath = Server.MapPath("~/Grant_Creation");

        //        if (!Directory.Exists(FilePath))
        //        {
        //            Directory.CreateDirectory(FilePath);
        //        }

        //        string FileName = "Grant_Creation" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xlsx";

        //        string serverfile = FilePath + "/" + FileName;

        //        StreamWriter wr = new StreamWriter(serverfile, true);

        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
        //        }

        //        wr.WriteLine();

        //        //write rows to excel file
        //        for (int i = 0; i < (dt.Rows.Count); i++)
        //        {
        //            for (int j = 0; j < dt.Columns.Count; j++)
        //            {
        //                if (dt.Rows[i][j] != null)
        //                {
        //                    wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
        //                }
        //                else
        //                {
        //                    wr.Write("\t");
        //                }
        //            }
        //            //go to next line
        //            wr.WriteLine();
        //        }
        //        //close file
        //        wr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //    }
        //}
        public void NewExportToExcel()
        {
            try
            {
                DataSet ds = objbal.INSERT_GVD(objbo);
                DataTable dt = new DataTable();
                dt = ds.Tables[1];

                string FilePath = Server.MapPath("~/Grant_Creation");

                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }

                string FileName = "Grant_Creation_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";

                string serverfile = FilePath + "/" + FileName;

                StreamWriter wr = new StreamWriter(serverfile, true);

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                }

                wr.WriteLine();

                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    //go to next line
                    wr.WriteLine();
                }
                //close file
                wr.Close();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
    }
}