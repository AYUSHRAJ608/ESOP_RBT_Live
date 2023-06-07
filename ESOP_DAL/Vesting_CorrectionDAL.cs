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
    public class Vesting_CorrectionDAL
    {

        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();
        public DataSet Get_vesting_correction_records()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_VESTING_CORRECTION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
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
                //con.Dispose();
            }

        }



        public void DeleteVestingcorrection(Vesting_CorrectionBO objBO)
        {
            try
            {

                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Delete_VESTING";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("ID", OracleType.Number).Value = objBO.GRANT_ID;

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


        public bool UpdateVestingcorrection(Vesting_CorrectionBO objBO)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_UPDATE_VESTING_CORRECTION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GrantID", OracleType.Number).Value = objBO.GRANT_ID;
                cmd.Parameters.Add("P_UPDATED_BY", OracleType.VarChar).Value = objBO.UPDATED_BY;
                //cmd.Parameters.Add("P_Emp_name", OracleType.VarChar).Value = objBO.Emp_name;
                //cmd.Parameters.Add("P_Emp_code", OracleType.VarChar).Value = objBO.Emp_code;


                cmd.Parameters.Add("P_No_of_options", OracleType.Number).Value = objBO.NO_OF_OPTION;
              //  cmd.Parameters.Add("P_VID", OracleType.Number).Value = objBO.VID;
                // cmd.Parameters.Add("P_FMV_PRICE", OracleType.VarChar).Value = objBO.FMV_PRICE;
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
    }
}
