using System;
using System.Configuration;
using System.Data;
using ESOP_BO;
//using Oracle.ManagedDataAccess.Client;
using System.Data.OracleClient;

namespace ESOP_DAL
{
    public class LetterConfigDAL    {

        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();
        public DataSet FunGetLetterConfig()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Get_LetterCofig";
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

        public void valuationDelete(LetterConfigBO objbo)
        {
            try
            {

                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESPO_Delete_valuation";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                //cmd.Parameters.Add("P_AGENCY_ID", OracleType.Number).Value = objbo.AGENCY_ID;

                cmd.ExecuteNonQuery();
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


        public bool UpdateStatus(LetterConfigBO objbo)
        {
            bool status = false;
            try
            {               
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_Letterconfig";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_LetterID", OracleType.Number).Value = objbo.LetterConfig_ID;
                cmd.Parameters.Add("P_LETTERNAME", OracleType.VarChar).Value = objbo.Letter_NAME;
                cmd.Parameters.Add("P_UPDATED_BY", OracleType.VarChar).Value = objbo.Modified_BY;               
                cmd.Parameters.Add("P_Status", OracleType.VarChar).Value = objbo.ISACTIVE;
                cmd.Parameters.Add("P_Filepath", OracleType.VarChar).Value = objbo.FilePath;
                cmd.Parameters.Add("P_Delete", OracleType.VarChar).Value = objbo.IsDelete;
                cmd.Parameters.Add("P_Mode", OracleType.VarChar).Value = objbo.Mode;
                cmd.Parameters.Add("P_UploadType", OracleType.VarChar).Value = objbo.UPLOADType;
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

        public DataSet report(LetterConfigBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_Employee_Grant_Details";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = objbo.EMPCODE;//"CI_10245";
                //cmd.Parameters.Add("p_GRANT_ID", OracleType.Number).Value = objbo.GrantID;  //"TRANCH1";
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

        public DataSet GetReportDesign(LetterConfigBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GetLetterEditDetails";
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


        public DataSet ESOP_GET_LETTER_CONFIGURATION_COUNT()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_LETTER_CONFIGURATION_COUNT";
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
