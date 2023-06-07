using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_DAL
{
    public class CommonDAL
    {
        private SQLDAL conn;
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        public CommonDAL()
        {
            conn = new SQLDAL();
        }
        ////////public bool LogExceptionDB(string PageName, string MethodName, string exMsg, string exstack)
        ////////{
        ////////    int result = 0;
        ////////    try
        ////////    {
        ////////        SqlParameter[] sqlParameters = new SqlParameter[4];
        ////////        sqlParameters[0] = new SqlParameter("@Err_PageName", SqlDbType.VarChar);
        ////////        sqlParameters[0].Value = PageName;

        ////////        sqlParameters[1] = new SqlParameter("@Err_MethodName", SqlDbType.VarChar);
        ////////        sqlParameters[1].Value = MethodName;

        ////////        sqlParameters[2] = new SqlParameter("@Err_exMsg", SqlDbType.VarChar);
        ////////        sqlParameters[2].Value = exMsg;

        ////////        sqlParameters[3] = new SqlParameter("@Err_exstack", SqlDbType.VarChar);
        ////////        sqlParameters[3].Value = exstack;

        ////////        ///               result = conn.exe_ExecuteNonQuery("sp_ErrLogException", sqlParameters);
        ////////        if (result > 0)
        ////////        {
        ////////            return true;
        ////////        }
        ////////        else
        ////////        {
        ////////            return false;
        ////////        }
        ////////    }
        ////////    catch (SqlException sqlEx)
        ////////    {
        ////////        return false;
        ////////    }
        ////////    catch (Exception ex)
        ////////    {
        ////////        throw ex;
        ////////    }



        ////////}

        public bool LogExceptionDB(string PageName, string MethodName, string exMsg, string exstack)
        {            
            int result = 0;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "sp_ErrLogException";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
               
                cmd.Parameters.Add("p_Err_PageName", OracleType.NVarChar).Value = PageName;               
                cmd.Parameters.Add("p_Err_MethodName", OracleType.NVarChar).Value = MethodName;              
                cmd.Parameters.Add("p_Err_exMsg", OracleType.NVarChar).Value = exMsg;
                cmd.Parameters.Add("p_Err_exstack", OracleType.NVarChar).Value = exstack;

                result = cmd.ExecuteNonQuery();
               
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (OracleException sqlEx)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Execute_Query(string Query)
        {
            DataSet dsresult = new DataSet();
            try
            {
                OracleCommand cmd = new OracleCommand(Query, con);
                con.Open();
                cmd.Connection = con;
                cmd.Parameters.Clear();
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
