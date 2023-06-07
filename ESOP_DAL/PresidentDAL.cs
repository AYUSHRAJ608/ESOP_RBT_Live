//using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ESOP_BO;

namespace ESOP_DAL
{
    public class PresidentDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING(PresidentBO PresidentBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_PR_DASHBOARD5"; //4 //3
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();            
                cmd.Parameters.Add("P_Emp_ID", OracleType.VarChar).Value = PresidentBO.ECode;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();                
            }
        }
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_DETAILS(PresidentBO PresidentBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_PR_DASHBOARD_DETAILS_5";  //"ESOP_USP_GET_PR_DASHBOARD_DETAILS_4"; // "ESOP_USP_GET_PR_DASHBOARD_DETAILS3";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();               
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = PresidentBO.ECode;
                cmd.Parameters.Add("p_GRANT_NAME", OracleType.VarChar).Value = PresidentBO.GRANT_NAME;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();               
            }
        }


        public DataSet GET_Distinct_VestID(PresidentBO PresidentBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_PR_TRANCHWISE_NAME_2"; // "ESOP_USP_GET_PR_TRANCHWISE_NAME1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = PresidentBO.ECode;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet GET_ExportToExcel_Data(PresidentBO PresidentBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_GET_EXPORT_TO_EXCEL_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public DataSet GET_All_Data(PresidentBO PresidentBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_EXCEL_REPORT_1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_1(PresidentBO PresidentBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_EMP_DATA"; //3
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Emp_ID", OracleType.VarChar).Value = PresidentBO.ECode;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UPDATE_LAPS(PresidentBO PresidentBO)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_LAPS_NEW";// "ESOP_UPDATE_LAPS_1"; // "ESOP_UPDATE_LAPS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Action", OracleType.VarChar).Value = PresidentBO.Action;
                cmd.Parameters.Add("P_Grant_ID", OracleType.VarChar).Value = PresidentBO.GRANT_ID;
                cmd.Parameters.Add("P_V_ID", OracleType.VarChar).Value = PresidentBO.V_ID;
                cmd.Parameters.Add("P_VestingD_ID", OracleType.VarChar).Value = PresidentBO.VestingD_ID;
                cmd.Parameters.Add("P_LBV", OracleType.Number).Value = PresidentBO.LBV;
                cmd.Parameters.Add("P_LAV", OracleType.Number).Value = PresidentBO.LAV;
                cmd.Parameters.Add("P_Remark", OracleType.VarChar).Value = PresidentBO.Remark;
                cmd.Parameters.Add("P_LapseDate", OracleType.DateTime).Value = PresidentBO.LapseDate;
                cmd.Parameters.Add("P_ECODE", OracleType.VarChar).Value = PresidentBO.ECode;

                con.Open();
                //OracleDataAdapter objAdap = new OracleDataAdapter(cmd);

                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
            return status;
        }
        public bool UPDATE_LAPS_CHECKER(PresidentBO PresidentBO)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "esop_update_lapse_Checker_new";// "ESOP_UPDATE_LAPS_1"; // "ESOP_UPDATE_LAPS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_action", OracleType.VarChar).Value = PresidentBO.Action;
                cmd.Parameters.Add("p_grant_id", OracleType.VarChar).Value = PresidentBO.GRANT_ID;
                cmd.Parameters.Add("p_v_id", OracleType.VarChar).Value = PresidentBO.V_ID;
                cmd.Parameters.Add("p_vestingd_id", OracleType.VarChar).Value = PresidentBO.VestingD_ID;
                cmd.Parameters.Add("p_lbv", OracleType.Number).Value = PresidentBO.LBV;
                cmd.Parameters.Add("p_lav", OracleType.Number).Value = PresidentBO.LAV;
                cmd.Parameters.Add("p_remark", OracleType.VarChar).Value = PresidentBO.Remark;
                cmd.Parameters.Add("p_lapsedate", OracleType.DateTime).Value = PresidentBO.LapseDate;
                cmd.Parameters.Add("p_ecode", OracleType.VarChar).Value = PresidentBO.ECode;

                con.Open();
                //OracleDataAdapter objAdap = new OracleDataAdapter(cmd);

                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
            return status;
        }
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_2(PresidentBO PresidentBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_LBV_LAV_LAPSE"; // "ESOP_USP_GET_EMP_DATA_1"; //3
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Emp_ID", OracleType.VarChar).Value = PresidentBO.ECode;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public DataSet GET_ESOP_STATUS(PresidentBO PresidentBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_FINAL_TOTAL_REPORT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public DataSet GET_ESOP_STATUS_BANDWISE(PresidentBO PresidentBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_BAND_EMP_WISE_REPORT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public DataSet GET_LAPSE_LIST(PresidentBO PresidentBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_LBV_LAV_LAPSE_NEW"; // "ESOP_USP_GET_EMP_DATA_1"; //3
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }    
}
