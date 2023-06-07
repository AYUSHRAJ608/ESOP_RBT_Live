using System;
using System.Configuration;
using System.Data;
using ESOP_BO;
using System.Data.OracleClient;

namespace ESOP_DAL
{
    public class exercise_reportDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();
        public DataSet GET_ADMIN_EXERCISE_REPORT(exercise_reportBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                //ESOP_USP_GET_ADMIN_EXERCISE_REPORT replaced by Pallavi
                cmd.CommandText = "ESOP_USP_GET_ADMIN_EXERCISE_REPORT1";//GET_ADMIN_EXERCISE_REPORT
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_START_DATE", OracleType.VarChar).Value = objBO.START_DATE;
                cmd.Parameters.Add("P_END_DATE", OracleType.VarChar).Value = objBO.END_DATE;
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
                //con.Dispose();
            }

        }
        public DataSet GET_EMPLOYEE_EXERCISE_REPORT(exercise_reportBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_EMPLOYEE_EXERCISE_REPORT";//GET_ADMIN_EXERCISE_REPORT
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE;
                cmd.Parameters.Add("P_START_DATE", OracleType.VarChar).Value = objBO.START_DATE;
                cmd.Parameters.Add("P_END_DATE", OracleType.VarChar).Value = objBO.END_DATE;
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
                //con.Dispose();
            }



        }

        public DataSet ESOP_admin_EXERCISE_REPORT_ALL_COUNT()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_admin_EXERCISE_REPORT_ALL_COUNT";//GET_ADMIN_EXERCISE_REPORT
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
                //con.Dispose();
            }

        }

        public DataSet GET_EMPLOYEE_SECRETARIAL_DownloadLink(double id)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_DownloadLink";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ID", OracleType.Double).Value = id;
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
                //con.Dispose();
            }

        }

        public DataSet GetError()
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetErrorList";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
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
        public DataSet GetDashGrid_DAL(exercise_reportBO objEnt)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SP_RB_Dashboard_data_EMP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ecode", OracleType.Number).Value = objEnt.ECODE;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
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

        public DataSet GetReportData(string Squery)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetReportData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_Query", OracleType.VarChar).Value = Squery;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
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
