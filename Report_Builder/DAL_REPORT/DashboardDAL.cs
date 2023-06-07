using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Entity_REPORT;

namespace DAL_REPORT
{
    public class DashboardDAL
    {
        OracleConnection con;
        OracleCommand cmd;
        public void GetConnString(string key)
        {
            if (key == "ESOP")
            {
                con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLConStringESOP"].ConnectionString);
            }
            else
            {
                con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLConStringPMS"].ConnectionString);
            }
        }
        public DataSet GetDashGrid_DAL(EDashboard objEnt)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                if (objEnt.key == "ESOP")
                {
                    con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLConStringESOP"].ConnectionString);
                }
                else
                {
                    con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLConStringPMS"].ConnectionString);
                }
                cmd.Connection = con;
                cmd.CommandText = "SP_RB_Dashboard_data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                ////cmd.Parameters.Add("p_rolename", OracleType.VarChar).Value = objEnt.rolename;
                ////cmd.Parameters.Add("p_ecode", OracleType.Number).Value = objEnt.emp_code;

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
        public DataSet GetReportData_DAL(EDashboard objEnt)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                if (objEnt.key == "ESOP")
                {
                    con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLConStringESOP"].ConnectionString);
                }
                else
                {
                    con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLConStringPMS"].ConnectionString);
                }
                cmd.Connection = con;
                cmd.CommandText = "sp_GetReportData";
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
    }
}
