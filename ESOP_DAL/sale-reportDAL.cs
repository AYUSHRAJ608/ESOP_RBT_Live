
using System;
using System.Configuration;
using System.Data;
using ESOP_BO;
using System.Data.OracleClient;

namespace ESOP_DAL
{
    public class sale_reportDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();
        public DataSet GET_ADMIN_SALE_REPORT(sale_reportBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                //ESOP_USP_GET_ADMIN_SALE_REPORT_1 replaced by Pallavi
                cmd.CommandText = "ESOP_USP_GET_ADMIN_SALE_REPORT_2";
                //ESOP_USP_GET_ADMIN_SALE_REPORT //GET_ADMIN_EXERCISE_REPORT
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
        public DataSet GET_EMPLOYEE_SALE_REPORT(sale_reportBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_EMPLOYEE_SALE_REPORT";//GET_ADMIN_EXERCISE_REPORT
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

        public DataSet ESOP_GET_ADMIN_SALE_report_COUNT()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_ADMIN_SALE_report_COUNT";//GET_ADMIN_EXERCISE_REPORT
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

    }
}
