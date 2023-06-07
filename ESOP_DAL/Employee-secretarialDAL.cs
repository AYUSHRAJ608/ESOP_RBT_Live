using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESOP_BO;

namespace ESOP_DAL
{
    public class Employee_secretarialDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();

        public DataSet ESOP_GET_EMPLOYEE_SECRETARIAL_DATA(string id)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_DATA";
                //cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_DATA_1";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ID", OracleType.VarChar).Value = id;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
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
        public DataSet ESOP_GET_EMPLOYEE_SECRETARIAL_Approvr_Reject()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_Approve_Reject_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                //cmd.Parameters.Add("p_Ecode", OracleType.VarChar).Value = EMPCode;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public DataSet GET_Employee_Secretarial_Main_Grid()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                //cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_MAIN_GRID";
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_MAIN_GRID_1";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public bool update_status(Employee_SecretarialBO objBO)
        {
            bool status = false;
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_STATUS_BY_EMPLOYEE_SECRETARIAL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id", OracleType.VarChar).Value = objBO.id;
                cmd.Parameters.Add("p_etid", OracleType.VarChar).Value = objBO.etid;
                cmd.Parameters.Add("P_remark", OracleType.VarChar).Value = objBO.remark;
                cmd.Parameters.Add("P_status", OracleType.VarChar).Value = objBO.status;
                cmd.Parameters.Add("P_modified_by", OracleType.VarChar).Value = objBO.modifiedBy;
                
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
        public DataSet GET_EMPLOYEE_SECRETARIAL_DownloadLink(double id)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_DownloadLink";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ID", OracleType.Double).Value = id;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public DataSet USP_GET_EMP_DETAILS_for_sell(EMailBO EmpBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "USP_GET_EMP_DETAILS_for_sell";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_role", OracleType.VarChar).Value = EmpBo.RoleName;
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = EmpBo.userName;

                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
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
