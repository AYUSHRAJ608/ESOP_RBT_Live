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
    public class Secretarial_grant_approvalDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();
        public DataSet get_secretarial_appraval_data(Secretarial_grant_approvalBO SecBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_SECRETARIAL_APPROVAL_RECORDS";
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
            }
        }
        public DataSet get_secretarial_all_count(Secretarial_grant_approvalBO SecBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_SECRETARIAL_ALL_COUNT";
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
            }
        }
        public bool update_status(Secretarial_grant_approvalBO SecBo)
        {
            bool status = false;
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_STATUS_BY_SECRETARIAL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_GrantID", OracleType.VarChar).Value = SecBo.grantid;
                
                cmd.Parameters.Add("P_UPDATED_BY", OracleType.VarChar).Value = SecBo.UPDATED_BY;

                cmd.Parameters.Add("P_remark2", OracleType.VarChar).Value = SecBo.remark;
                cmd.Parameters.Add("P_Status", OracleType.VarChar).Value = SecBo.status;

                cmd.Parameters.Add("P_Proxy", OracleType.VarChar).Value = SecBo.proxy;

                cmd.Parameters.Add("P_FMVId", OracleType.VarChar).Value = SecBo.FMVId;
                cmd.Parameters.Add("P_Valued_by", OracleType.VarChar).Value = SecBo.Valued_by;
                cmd.Parameters.Add("P_Upload_File", OracleType.VarChar).Value = SecBo.Upload_File;

                con.Open();

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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return status;
        }
        public bool update_status1(Secretarial_grant_approvalBO SecBo)
        {
            bool status = false;
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_STATUS_BY_HR1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_grant_id", OracleType.VarChar).Value = SecBo.grantid;

                cmd.Parameters.Add("P_UPDETED_BY", OracleType.VarChar).Value = SecBo.UPDATED_BY;

                cmd.Parameters.Add("P_remark2", OracleType.VarChar).Value = SecBo.remark;
                cmd.Parameters.Add("P_status", OracleType.VarChar).Value = SecBo.status;

                cmd.Parameters.Add("P_Proxy", OracleType.VarChar).Value = SecBo.proxy;

                con.Open();

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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return status;
        }
        public bool update_status2(Secretarial_grant_approvalBO SecBo)
        {
            bool status = false;
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_STATUS_BY_HR_2";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_GrantID", OracleType.VarChar).Value = SecBo.grantid;

                cmd.Parameters.Add("P_UPDATED_BY", OracleType.VarChar).Value = SecBo.UPDATED_BY;

                cmd.Parameters.Add("P_remark2", OracleType.VarChar).Value = SecBo.remark;
                cmd.Parameters.Add("P_Status", OracleType.VarChar).Value = SecBo.status;

                cmd.Parameters.Add("P_Proxy", OracleType.VarChar).Value = SecBo.proxy;

                con.Open();

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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return status;
        }
        public bool update_rejected_status(Secretarial_grant_approvalBO SecBo)
        {
            bool status = false;
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_REJECTED_STATUS_BY_HR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_grant_id", OracleType.VarChar).Value = SecBo.grantid;

                cmd.Parameters.Add("P_ecode", OracleType.VarChar).Value = SecBo.ecode;
                cmd.Parameters.Add("P_emp_name", OracleType.VarChar).Value = SecBo.emp_name;
                cmd.Parameters.Add("P_date_of_grant", OracleType.VarChar).Value = SecBo.date_of_grant;

                cmd.Parameters.Add("P_no_of_options", OracleType.VarChar).Value = SecBo.no_of_options;

                cmd.Parameters.Add("P_fmv_price", OracleType.VarChar).Value = SecBo.fmv_price;
                cmd.Parameters.Add("P_appraiser_name", OracleType.VarChar).Value = SecBo.appraiser_name;
                cmd.Parameters.Add("P_remark2", OracleType.VarChar).Value = SecBo.remark;
                cmd.Parameters.Add("P_UPDETED_BY", OracleType.VarChar).Value = SecBo.UPDATED_BY;
                cmd.Parameters.Add("P_status", OracleType.VarChar).Value = SecBo.status;
                cmd.Parameters.Add("P_Proxy", OracleType.VarChar).Value = SecBo.proxy;
                con.Open();

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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return status;

        }
        public DataSet get_hr_appraval_date_wise(exercise_reportBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_HR_APPROVAL_RECORDS_FILTER";//GET_ADMIN_EXERCISE_REPORT
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
        public bool update_status_Checker(Secretarial_grant_approvalBO SecBo)
        {
            bool status = false;
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_STATUS_BY_CHECKER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_grant_id", OracleType.VarChar).Value = SecBo.grantid;

                cmd.Parameters.Add("P_ecode", OracleType.VarChar).Value = SecBo.ecode;
                cmd.Parameters.Add("P_emp_name", OracleType.VarChar).Value = SecBo.emp_name;
                cmd.Parameters.Add("P_appraiser_name", OracleType.VarChar).Value = SecBo.appraiser_name;

                cmd.Parameters.Add("P_date_of_grant", OracleType.VarChar).Value = SecBo.date_of_grant;

                cmd.Parameters.Add("P_no_of_options", OracleType.VarChar).Value = SecBo.no_of_options;

                cmd.Parameters.Add("P_fmv_price", OracleType.VarChar).Value = SecBo.fmv_price;
                cmd.Parameters.Add("P_UPDETED_BY", OracleType.VarChar).Value = SecBo.UPDATED_BY;

                cmd.Parameters.Add("P_remark2", OracleType.VarChar).Value = SecBo.remark;
                cmd.Parameters.Add("P_status", OracleType.VarChar).Value = SecBo.status;

                cmd.Parameters.Add("P_Proxy", OracleType.VarChar).Value = SecBo.proxy;

                con.Open();

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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return status;
        }
        public DataSet get_checker_appraval_date(Secretarial_grant_approvalBO SecBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_CHECKER_APPROVAL_RECORDS";
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
            }
        }
        public DataSet get_checker_all_count(Secretarial_grant_approvalBO SecBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_CHECKER_ALL_COUNT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;
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
            }
        }
        public bool update_rejected_status_Checker(Secretarial_grant_approvalBO SecBo)
        {
            bool status = false;
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_REJECTED_STATUS_BY_CHECKER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_grant_id", OracleType.VarChar).Value = SecBo.grantid;

                cmd.Parameters.Add("P_ecode", OracleType.VarChar).Value = SecBo.ecode;
                cmd.Parameters.Add("P_emp_name", OracleType.VarChar).Value = SecBo.emp_name;
                cmd.Parameters.Add("P_date_of_grant", OracleType.VarChar).Value = SecBo.date_of_grant;

                cmd.Parameters.Add("P_no_of_options", OracleType.VarChar).Value = SecBo.no_of_options;

                cmd.Parameters.Add("P_fmv_price", OracleType.VarChar).Value = SecBo.fmv_price;
                cmd.Parameters.Add("P_appraiser_name", OracleType.VarChar).Value = SecBo.appraiser_name;
                cmd.Parameters.Add("P_remark2", OracleType.VarChar).Value = SecBo.remark;
                cmd.Parameters.Add("P_UPDETED_BY", OracleType.VarChar).Value = SecBo.UPDATED_BY;
                cmd.Parameters.Add("P_status", OracleType.VarChar).Value = SecBo.status;
                cmd.Parameters.Add("P_Proxy", OracleType.VarChar).Value = SecBo.proxy;
                con.Open();

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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return status;

        }

    }
}
