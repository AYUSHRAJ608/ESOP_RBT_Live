using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Configuration;
using Entity_REPORT;
using System.Web;

namespace DAL_REPORT
{
    public class LoginDAL
    {
        OracleConnection Con = new OracleConnection(ConnectionStringDAL.Getconnectionstring(Convert.ToString(HttpContext.Current.Session["AppConnectionstring"]))); 
     
        public DataSet Validuser(LoginBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = "SP_ESOP_PMS_LoginValidate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = objBO.EMP_ID;
                cmd.Parameters.Add("P_Password", OracleType.VarChar).Value = objBO.EMP_Password;
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
                Con.Close();
            }
        }
    }
}
