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
    public class Exercise_CancelDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        public DataSet GET_Employee_Exercise_Cancel()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_CANCELLATION_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
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
            }

        }

        public DataSet GET_Employee_Exercise_Reverted()
        {
            try
            {

                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_REVERTED_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
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
            }
        }


        public bool Update_Revert(Exercise_BtnRevertBO objBO)
        {
            bool status = false;
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand();
            try
            {
                cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_UPDATE_CANCELLATION_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ECODE", OracleType.Int32).Value = objBO.ECODE;
                cmd.Parameters.Add("P_ENAME", OracleType.VarChar).Value = objBO.ENAME;
                cmd.Parameters.Add("P_grant_name", OracleType.VarChar).Value = objBO.Grant_Name;
                cmd.Parameters.Add("P_VESTING_DETAIL_CODE", OracleType.VarChar).Value = objBO.Vesting_Detail_Code;
                cmd.Parameters.Add("P_Exercise_Tran_Id", OracleType.Int32).Value = objBO.Exercise_Tran_Id;
                cmd.Parameters.Add("P_Total_Vesting", OracleType.Int32).Value = objBO.Total_Vesting;
                cmd.Parameters.Add("P_EXERCISE_PENDING", OracleType.Int32).Value = objBO.EXERCISE_PENDING;
                cmd.Parameters.Add("P_Total_Exercise_Approved", OracleType.Int32).Value = objBO.Total_Exercise_Approved;
                
                cmd.Parameters.Add("P_Remark", OracleType.VarChar).Value = objBO.Remark;
                cmd.Parameters.Add("P_Status", OracleType.VarChar).Value = objBO.Status;
                cmd.Parameters.Add("P_Reverted_Date", OracleType.DateTime).Value = objBO.Reverted_Date;

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
