using System;
using System.Configuration;
using System.Data;
using ESOP_BO;
using System.Data.OracleClient;

namespace ESOP_DAL
{
    public class vesting_approvalDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();
        public DataSet GET_ADMIN_VESTING_FOR_APPROVAL()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_ADMIN_VESTING_FOR_APPROVAL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public DataSet GET_ADMIN_VESTING_FOR_APPROVAL_COUNT()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_ADMIN_VESTING_FOR_APPROVAL_COUNT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public bool UPDATE_ADMIN_VESTING_APPROVAL(vesting_approvalBO ValBo)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "USP_ESOP_UPDATE_ADMIN_VESTING_APPROVAL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GRANT_ID", OracleType.Number).Value = ValBo.GRANT_ID;
                cmd.Parameters.Add("P_V_DETAIL_ID", OracleType.Number).Value = ValBo.V_DETAIL_ID;
                cmd.Parameters.Add("P_ADMIN_VESTING_REMARK", OracleType.VarChar).Value = ValBo.ADMIN_VESTING_REMARK;
                cmd.Parameters.Add("P_STATUS", OracleType.VarChar).Value = ValBo.STATUS;
                cmd.Parameters.Add("P_MODIFIEDBY", OracleType.VarChar).Value = ValBo.MODIFIEDBY;
                cmd.Parameters.Add("P_PROXY", OracleType.VarChar).Value = ValBo.PROXY;
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

        public DataSet GET_PRESIDENT_VESTING_FOR_APPROVAL(vesting_approvalBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_PRESIDENT_VESTING_FOR_APPROVAL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Emp_ID", OracleType.VarChar).Value = objBO.EMPCODE;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public DataSet GET_PRESIDENT_VESTING_FOR_APPROVAL_COUNT(PresedentApprovalBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_PRESIDENT_VESTING_FOR_APPROVAL_COUNT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Emp_ID", OracleType.VarChar).Value = objBO.EMPCODE;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public bool UPDATE_PRESIDENT_VESTING_APPROVAL(vesting_approvalBO ValBo)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "USP_ESOP_UPDATE_PRESIDENT_VESTING_APPROVAL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GRANT_ID", OracleType.Number).Value = ValBo.GRANT_ID;
                cmd.Parameters.Add("P_V_DETAIL_ID", OracleType.Number).Value = ValBo.V_DETAIL_ID;
                cmd.Parameters.Add("P_ADMIN_VESTING_REMARK", OracleType.VarChar).Value = ValBo.pr_vesting_remark;
                cmd.Parameters.Add("P_STATUS", OracleType.VarChar).Value = ValBo.STATUS;
                cmd.Parameters.Add("P_MODIFIEDBY", OracleType.VarChar).Value = ValBo.MODIFIEDBY;
                cmd.Parameters.Add("P_PROXY", OracleType.VarChar).Value = ValBo.PROXY;
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
        public DataSet GET_PRESIDENT_VESTING_FOR_APPROVAL_FILTER(exercise_reportBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                //"ESOP_GET_PRESIDENT_VESTING_FOR_APPROVAL_FILTER"; replaced by Pallavi
                cmd.CommandText = "ESOP_GET_PRESIDENT_VESTING_FOR_APPROVAL_FILTER1"; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_START_DATE", OracleType.VarChar).Value = objBO.START_DATE;
                cmd.Parameters.Add("P_END_DATE", OracleType.VarChar).Value = objBO.END_DATE;
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
        public DataSet GET_VESTING_AUDIT(vesting_approvalBO ValBo, string Vest_Cycle_Name)
        {
            DataSet dsresult = new DataSet();
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_VESTING_AUDIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GRANT_ID", OracleType.Number).Value = ValBo.GRANT_ID;
                cmd.Parameters.Add("P_Vest_Cycle_Name", OracleType.VarChar).Value = Vest_Cycle_Name;
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
