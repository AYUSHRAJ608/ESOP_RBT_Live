using System;
using System.Configuration;
using System.Data;
using ESOP_BO;
//using Oracle.ManagedDataAccess.Client;
using System.Data.OracleClient;

namespace ESOP_DAL
{
    public class PresedentApprovalDAL
    {

        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();
        public DataSet FunGetApprovalRecords(PresedentApprovalBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_PRESIDENT_APPRVL_RECORDS_1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Emp_ID", OracleType.VarChar).Value = objbo.EMPCODE;
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

        public DataSet FunGetApprovalRecords_Filter(PresedentApprovalBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_PRESIDENT_APPRVL_RECORDS_FILTER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("P_START_DATE", OracleType.VarChar).Value = objbo.START_DATE;
                cmd.Parameters.Add("P_END_DATE", OracleType.VarChar).Value = objbo.END_DATE;
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

        public DataSet GET_EMPLOYEE_GRANT_REPORT(PresedentApprovalBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_EMPLOYEE_GRANT_REPORT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();                
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("P_START_DATE", OracleType.VarChar).Value = objbo.START_DATE;
                cmd.Parameters.Add("P_END_DATE", OracleType.VarChar).Value = objbo.END_DATE;

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

        public DataSet Get_President_all_count(PresidentBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_PRESIDENT_ALL_COUNT1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Emp_ID", OracleType.VarChar).Value = objbo.ECode;
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

        public void valuationDelete(ValuationBO ValBo)
        {
            try
            {

                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESPO_Delete_valuation";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_AGENCY_ID", OracleType.Number).Value = ValBo.AGENCY_ID;

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


        public bool UpdateStatus(PresedentApprovalBO ValBo)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_STATUS_BY_President";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GrantID", OracleType.Number).Value = ValBo.GrantID;
                cmd.Parameters.Add("P_UPDATED_BY", OracleType.VarChar).Value = ValBo.UPDATED_BY;
                cmd.Parameters.Add("P_REMARK2", OracleType.VarChar).Value = ValBo.REMARK2;
                cmd.Parameters.Add("P_Status", OracleType.VarChar).Value = ValBo.Status;
                cmd.Parameters.Add("P_Proxy", OracleType.VarChar).Value = ValBo.proxy;
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

        public DataSet GetEmpDetails_AdminPswd(PresedentApprovalBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_EMPLOYEE_GRANT_DETAILS_CANCEL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = objbo.EMPCODE;//"CI_10245";
                cmd.Parameters.Add("p_GRANT_ID", OracleType.Number).Value = objbo.GrantID;  //"TRANCH1";
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


        public DataSet GetLetterPath(PresedentApprovalBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_UPDATE_FILEPATH2";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_LETTERID", OracleType.Number).Value = objbo.LETTERID;
                cmd.Parameters.Add("p_GrantID", OracleType.Number).Value = objbo.GrantID;
                cmd.Parameters.Add("p_FILEPATH", OracleType.VarChar).Value = objbo.FILEPATH;
                cmd.Parameters.Add("p_Type", OracleType.VarChar).Value = objbo.Update_Type;
                cmd.Parameters.Add("p_EMPID", OracleType.VarChar).Value = objbo.EMPCODE;
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

        public DataSet GetReportDesign(PresedentApprovalBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GetLetterDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_LETTER_Type", OracleType.VarChar).Value = objbo.LETTERNAME;
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

        public DataSet GetLetterPathCancel(PresedentApprovalBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_UPDATE_FILEPATH2_CANCEL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_LETTERID", OracleType.Number).Value = objbo.LETTERID;
                cmd.Parameters.Add("p_GrantID", OracleType.Number).Value = objbo.GrantID;
                cmd.Parameters.Add("p_FILEPATH", OracleType.VarChar).Value = objbo.FILEPATH;
                cmd.Parameters.Add("p_Type", OracleType.VarChar).Value = objbo.Update_Type;
                cmd.Parameters.Add("p_EMPID", OracleType.VarChar).Value = objbo.EMPCODE;
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
        public DataSet ESOP_QUARTERLY_REPORT(exercise_reportBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_QUARTERLY_REPORT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("P_START_DATE", OracleType.VarChar).Value = objBO.START_DATE;
                cmd.Parameters.Add("P_END_DATE", OracleType.VarChar).Value = objBO.END_DATE;
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

        public DataSet GET_ALL_EMPLOYEE_DETAIL_REPORT(PresedentApprovalBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_ALL_EMPLOYEE_DETAIL_REPORT";
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
