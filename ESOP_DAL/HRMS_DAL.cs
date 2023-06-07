using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_DAL
{
    public class HRMS_DAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();
        public DataSet GETMERGEEMPCHECK()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_GETMERGEEMPCHECK";
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
                // con.Dispose();
            }
        }
        public int UPDATEMERGEEMPCHECK(string flag,string modifiedby)
        {
            int result = 0;
            try
            {
                //DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_MERGEEMPCHECK";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_flag", OracleType.VarChar).Value = flag;
                cmd.Parameters.Add("p_modifiedby", OracleType.VarChar).Value = modifiedby;
                
                cmd.ExecuteNonQuery();
                result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public DataSet GETMERGEEMPDATA()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_GETMERGEEMPDATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
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
                // con.Dispose();
            }
        }


        public int UPDATEMERGEEMPDATA(string emplist, string empDeletelist, string modifiedby)
        {
            int result = 0;
            try
            {
                //DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_UPDATEMERGEEMPDATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_emplist", OracleType.VarChar).Value = emplist;
                cmd.Parameters.Add("p_empDeletelist", OracleType.VarChar).Value = empDeletelist;
                cmd.Parameters.Add("p_modifiedby", OracleType.VarChar).Value = modifiedby;

                cmd.ExecuteNonQuery();
                result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public int INSERTMERGEEMPDATA(string emplist, string modifiedby)
        {
            int result = 0;
            try
            {
                //DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_INSERTMERGEEMPDATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_emplist", OracleType.VarChar).Value = emplist;
                cmd.Parameters.Add("p_modifiedby", OracleType.VarChar).Value = modifiedby;

                cmd.ExecuteNonQuery();
                result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        
        //Added by Rahul_Natu on 14-10-2021
        public DataSet FetchEmployeeData()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_FetchEmployeeData";
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

        public DataSet getEmpIDName(string search)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_GetEmpIDName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_search", OracleType.VarChar).Value = search;
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

        public DataSet GetAdminGoalsFilter()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetAdminGoalsFilter";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("cur4", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur5", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur6", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur7", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur8", OracleType.Cursor).Direction = ParameterDirection.Output;

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
                // con.Dispose();
            }
        }

        public DataSet GetEmpNames()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "sp_SearchEmpNames";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                //cmd.Parameters.Add("p_Search", OracleType.VarChar).Value = search;
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

        public DataSet UserFilter(HRMSIntegrationBO emp)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_USER_FILTER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECode", OracleType.VarChar).Value = emp.ECODE.ToLower();
                cmd.Parameters.Add("P_Emp_Name", OracleType.VarChar).Value = emp.EMP_NAME.ToLower();
                cmd.Parameters.Add("P_Dept", OracleType.VarChar).Value = emp.DEPARTMENT;
                cmd.Parameters.Add("P_Band", OracleType.VarChar).Value = emp.BANDS;
                cmd.Parameters.Add("P_Location", OracleType.VarChar).Value = emp.LOCATION;
                cmd.Parameters.Add("P_FUNCTION", OracleType.VarChar).Value = emp.FUNCTION;
                cmd.Parameters.Add("P_COST_CENTRE", OracleType.VarChar).Value = emp.COST_CENTRE;
                cmd.Parameters.Add("P_HOD_CODE", OracleType.VarChar).Value = emp.HOD_CODE;
                cmd.Parameters.Add("P_EMP_STATUS", OracleType.VarChar).Value = emp.EMP_STATUS;
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

        public int updateEmpDetails(HRMSIntegrationBO objEmployee)
        {
            int result = 0;
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_UpdateEmployeeDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ECODE", OracleType.VarChar).Value = objEmployee.ECODE;
                cmd.Parameters.Add("p_EMP_STATUS", OracleType.VarChar).Value = objEmployee.EMP_STATUS;
                cmd.Parameters.Add("p_BH_CODE", OracleType.VarChar).Value = objEmployee.BH_CODE;
                cmd.Parameters.Add("p_BH_NAME", OracleType.VarChar).Value = objEmployee.BH_NAME;
                cmd.Parameters.Add("p_HOD_CODE", OracleType.VarChar).Value = objEmployee.HOD_CODE;
                cmd.Parameters.Add("p_HOD_NAME", OracleType.VarChar).Value = objEmployee.HOD_NAME;

                //Added by Ushir on 12-11-2020 for HRMS - end

                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                result = 1;
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
            return result;
        }
    }
}
