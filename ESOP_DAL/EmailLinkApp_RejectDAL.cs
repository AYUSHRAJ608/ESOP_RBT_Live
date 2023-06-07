using System;
using System.Configuration;
using System.Data;
using ESOP_BO;
//using Oracle.ManagedDataAccess.Client;
using System.Data.OracleClient;

namespace ESOP_DAL
{
    public class EmailLinkApp_RejectDAL
    {

        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        OracleCommand cmd = new OracleCommand();  

        public bool UpdateStatus(int GrantID, string Status, string GrantName)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_STATUS_Through_Email";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GrantID", OracleType.Number).Value=GrantID;
                cmd.Parameters.Add("P_UPDATED_BY", OracleType.VarChar).Value ="";             
                cmd.Parameters.Add("P_Status", OracleType.VarChar).Value = Status.ToString();
                cmd.Parameters.Add("P_GrantName", OracleType.VarChar).Value = GrantName.ToString();
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
            }
            return status;
        }
        

    }

}
