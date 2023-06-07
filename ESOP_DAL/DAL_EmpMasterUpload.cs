using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESOP_DAL;
using ESOP_BAL;
using System.Data.OracleClient;

/// <summary>
/// ADITYA PC CODE
/// </summary>
namespace ESOP_DAL
{
    public class DAL_EmpMasterUpload
    {
        ////SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        ////SqlCommand cmd, cmdDoc, cmdDoc1;
        ////SqlTransaction transactionReq, transactionDoc, transactionDoc1 = null;

        /// <summary>
        /// BULK UPLOAD CODE STARTS BELOW -  aditya
        /// </summary>
        /// 

        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        OracleCommand cmd;

        public DataTable getEMuId_Dal(E_EmployeMasterUpload objEntity)
        {
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_getEMU_IDUpload";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                if (objEntity.firstEntry == true)
                {
                    con.Open();
                    cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                    OracleDataAdapter adp = new OracleDataAdapter(cmd);
                    adp.Fill(ds);
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataTable InsertEmpMastRecToDump_BulkUpload(E_EmployeMasterUpload ObjEntity)
        {
            //bool status = false;
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_EmployeeMaster_Upload";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
               // cmd.Parameters.Add("p_flag", OracleType.VarChar).Value = "SubmitRequest";

                cmd.Parameters.Add("p_DEM_EU_ID", OracleType.VarChar).Value = ObjEntity.EmpUpload_ID;
                cmd.Parameters.Add("p_DEM_ECODE", OracleType.VarChar).Value = ObjEntity.Ecode;
                cmd.Parameters.Add("p_DEM_COMPANY_NAME", OracleType.VarChar).Value = ObjEntity.Company_name;
                cmd.Parameters.Add("p_DEM_GENDER", OracleType.VarChar).Value = ObjEntity.Gender;
                cmd.Parameters.Add("p_DEM_EMP_STATUS", OracleType.VarChar).Value = ObjEntity.Emp_status;
                cmd.Parameters.Add("p_DEM_LWD", OracleType.VarChar).Value = ObjEntity.Lwd;
                cmd.Parameters.Add("p_DEM_TNTR", OracleType.VarChar).Value = ObjEntity.Tntr;
                cmd.Parameters.Add("p_DEM_EMP_NAME", OracleType.VarChar).Value = ObjEntity.Emp_name;
                cmd.Parameters.Add("p_DEM_DESIGNATION", OracleType.VarChar).Value = ObjEntity.Designation;
                cmd.Parameters.Add("p_DEM_BANDS", OracleType.VarChar).Value = ObjEntity.Bands;
                cmd.Parameters.Add("p_DEM_DOJ", OracleType.VarChar).Value = ObjEntity.Doj;
                cmd.Parameters.Add("p_DEM_LOCATION", OracleType.VarChar).Value = ObjEntity.Location;
                cmd.Parameters.Add("p_DEM_DEPARTMENT", OracleType.VarChar).Value = ObjEntity.Department;
                cmd.Parameters.Add("p_DEM_FUNCTION", OracleType.VarChar).Value = ObjEntity.Function;
                cmd.Parameters.Add("p_DEM_COST_CENTRE", OracleType.VarChar).Value = ObjEntity.Cost_centre;
                cmd.Parameters.Add("p_DEM_APP_CODE", OracleType.VarChar).Value = ObjEntity.App_code;
                cmd.Parameters.Add("p_DEM_APPRAISER_NAME", OracleType.VarChar).Value = ObjEntity.Appraiser_name;
                cmd.Parameters.Add("p_DEM_APP_BAND", OracleType.VarChar).Value = ObjEntity.App_band;
                cmd.Parameters.Add("p_DEM_REV_CODE", OracleType.VarChar).Value = ObjEntity.Rev_code;
                cmd.Parameters.Add("p_DEM_REVIEWER_NAME", OracleType.VarChar).Value = ObjEntity.Reviewer_name;
                cmd.Parameters.Add("p_DEM_REV_BAND", OracleType.VarChar).Value = ObjEntity.Rev_band;
                cmd.Parameters.Add("p_DEM_HOD_CODE", OracleType.VarChar).Value = ObjEntity.Hod_code;
                cmd.Parameters.Add("p_DEM_HOD_NAME", OracleType.VarChar).Value = ObjEntity.Hod_name;
                cmd.Parameters.Add("p_DEM_HOD_BAND", OracleType.VarChar).Value = ObjEntity.Hod_band;
                cmd.Parameters.Add("p_DEM_BH_CODE", OracleType.VarChar).Value = ObjEntity.Bh_code;
                cmd.Parameters.Add("p_DEM_BH_NAME", OracleType.VarChar).Value = ObjEntity.Bh_name;

                cmd.Parameters.Add("p_DEM_INTERNAL", OracleType.VarChar).Value = ObjEntity.Internal;
                cmd.Parameters.Add("p_DEM_EXTERNAL", OracleType.VarChar).Value = ObjEntity.External;
                cmd.Parameters.Add("p_DEM_TOTAL", OracleType.VarChar).Value = ObjEntity.Total;

                cmd.Parameters.Add("p_DEM_RecStatus", OracleType.VarChar).Value = ObjEntity.RecStatus;

                cmd.Parameters.Add("p_DEM_UploadBy", OracleType.VarChar).Value = ObjEntity.CreatedBy;
                cmd.Parameters.Add("p_DEM_ErrorString", OracleType.VarChar).Value = ObjEntity.ErrorString;
                cmd.Parameters.Add("p_DEM_NT_ID", OracleType.VarChar).Value = ObjEntity.Nt_ID;
                con.Open();

                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                //cmd.ExecuteNonQuery();
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                     con.Close();                    
                }
            }
            //return status;
            return ds;
        }
        public DataTable getFailedData_Dal(E_EmployeMasterUpload ObjEntity)
        {
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetFailedRec_ByUGID_EmpMast";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("p_DEM_EU_ID", OracleType.VarChar).Value = ObjEntity.EmpUpload_ID;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;

                con.Open();

                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataTable getRecCount_DAL(E_EmployeMasterUpload ObjEntity)
        {
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetRecCount_EmpMast";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                if (ObjEntity.firstEntry == false)
                {
                    cmd.Parameters.Add("p_DEM_EU_ID", OracleType.VarChar).Value = ObjEntity.EmpUpload_ID;
                    cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;

                    con.Open();
                    OracleDataAdapter adp = new OracleDataAdapter(cmd);
                    adp.Fill(ds);
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataTable getRecCountFailed_DAL(E_EmployeMasterUpload ObjEntity)
        {
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetRecCount_failed_EmpMast";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                if (ObjEntity.firstEntry == false)
                {
                    cmd.Parameters.Add("p_DEM_EU_ID", OracleType.VarChar).Value = ObjEntity.EmpUpload_ID;
                    cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;

                    con.Open();
                    OracleDataAdapter adp = new OracleDataAdapter(cmd);
                    adp.Fill(ds);
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataTable addSuccessData_DAL(E_EmployeMasterUpload ObjEntity)
        {
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_AddSuccessData_HRMS";//sp_AddSuccessData_fromUpload_EmpMast  //IMP UserMaster 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                if (ObjEntity.firstEntry == false)
                {
                    cmd.Parameters.Add("p_DEM_EU_ID", OracleType.VarChar).Value = ObjEntity.EmpUpload_ID;
                    cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;

                    con.Open();
                    OracleDataAdapter adp = new OracleDataAdapter(cmd);
                    adp.Fill(ds);
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataTable UpdateOverwriteRec_BulkUpload(E_EmployeMasterUpload ObjEntity)
        {
            //bool status = false;
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_EmpMastlUpload_Overwrite";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("p_EM_DEM_UGID", OracleType.VarChar).Value = ObjEntity.EmpUpload_ID;
                cmd.Parameters.Add("p_DEM_UploadBy", OracleType.VarChar).Value = ObjEntity.CreatedBy;

                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;

                con.Open();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                //cmd.ExecuteNonQuery();
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            //return status;
            return ds;
        }
        //Added by Bhushan on 16-12-2021 for PAN Card upload
        public DataSet getRecordCount(E_EmployeMasterUpload ObjEntity)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SP_GETSUCCESSFAILEDCOUNT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                if (ObjEntity.firstEntry == false)
                {
                    cmd.Parameters.Add("p_DEM_EU_ID", OracleType.VarChar).Value = ObjEntity.EmpUpload_ID;
                    cmd.Parameters.Add("curSuccess", OracleType.Cursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("curFailed", OracleType.Cursor).Direction = ParameterDirection.Output;

                    con.Open();
                    OracleDataAdapter adp = new OracleDataAdapter(cmd);
                    adp.Fill(ds);
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataTable getLastGuid(E_EmployeMasterUpload objEntity)
        {
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_getLastGuid";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                if (objEntity.firstEntry == true)
                {
                    con.Open();
                    cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                    OracleDataAdapter adp = new OracleDataAdapter(cmd);
                    adp.Fill(ds);
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataTable UpdateEmpPANDetails(E_EmployeMasterUpload ObjEntity)
        {
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SP_UPDATEPANDETAILSBYEMPID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                if (ObjEntity.firstEntry == false)
                {
                    cmd.Parameters.Add("p_DEM_ECODE", OracleType.VarChar).Value = ObjEntity.Ecode;
                    cmd.Parameters.Add("p_DEM_PAN", OracleType.VarChar).Value = ObjEntity.PanNumber;

                    con.Open();
                    OracleDataAdapter adp = new OracleDataAdapter(cmd);
                    adp.Fill(ds);
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataTable getFailedRecordsData(E_EmployeMasterUpload objEntity)
        {
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SP_GETFAILEDPANRECORDS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("p_DEM_EU_ID", OracleType.VarChar).Value = objEntity.EmpUpload_ID;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;

                con.Open();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        //End
    }
}
