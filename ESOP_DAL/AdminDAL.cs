using System;
using System.Configuration;
using System.Data;
using ESOP_BO;
//using Oracle.ManagedDataAccess.Client;
using System.Data.OracleClient;

namespace ESOP_DAL
{
    public class AdminDAL
    {

        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();
        public DataSet FunGetApprovalRecords()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_GRANT_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur4", OracleType.Cursor).Direction = ParameterDirection.Output;
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



        public void GrantDelete(AdminBO ValBo)
        {
            try
            {

                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESPO_Delete_GRANT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GRANTID", OracleType.Number).Value = ValBo.GRANT_ID;

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


        public bool UpdateGrant(AdminBO ValBo)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Update_Grant";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GrantID", OracleType.Number).Value = ValBo.GRANT_ID;
                cmd.Parameters.Add("P_UPDATED_BY", OracleType.VarChar).Value = ValBo.UPDATED_BY;
                cmd.Parameters.Add("P_No_of_options", OracleType.Number).Value = ValBo.NO_OF_OPTION;
                cmd.Parameters.Add("P_VID", OracleType.Number).Value = ValBo.VID;
                cmd.Parameters.Add("P_admin_remark", OracleType.VarChar).Value = ValBo.admin_remark;
                //cmd.Parameters.Add("P_EmployeeID", OracleType.VarChar).Value = ValBo.EMP_ID;
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

        public DataSet ESOP_GET_ADMIN_GRANT_UPDATION_COUNT()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_ADMIN_GRANT_UPDATION_COUNT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
             
                //cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;
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
