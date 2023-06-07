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
    public class Employee_profileDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();
        public DataSet get_empbank_detail(Employee_profileBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Get_EmpBank_Details";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.VarChar).Value = objbo.ECODE;
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
            }
        }

        public bool Insert_Emp_bankDetail(Employee_profileBO ValBo)
        {
            bool statu1 = false;
            try
            {

                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Save_EmpBnkDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.VarChar).Value = ValBo.ECODE;
                cmd.Parameters.Add("P_BANK_NAME", OracleType.VarChar).Value = ValBo.BANK_NAME;
                cmd.Parameters.Add("P_BRANCH_NAME", OracleType.VarChar).Value = ValBo.BRANCH_NAME;
                cmd.Parameters.Add("P_ACC_NO", OracleType.VarChar).Value = ValBo.ACC_NO;
                cmd.Parameters.Add("P_IFSC", OracleType.VarChar).Value = ValBo.IFSC;
                cmd.Parameters.Add("P_FILE_PATH", OracleType.VarChar).Value = ValBo.FILE_PATH;


                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    statu1 = true;
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
            return statu1;
        }

        public void Update_Emp_Active_Status(Employee_profileBO ValBo)
        {
            try
            {
                //DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_EMP_BANK_ACTIVE_STATUS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ID", OracleType.Number).Value = ValBo.ID;
                cmd.Parameters.Add("p_ISACTIVE", OracleType.NVarChar).Value = ValBo.ISACTIVE;
                cmd.Parameters.Add("p_MODIFIEDBY", OracleType.NVarChar).Value = ValBo.MODIFIEDBY;

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


        public void Update_Emp_Dmat_Active_Status(Employee_profileBO ValBo)
        {
            try
            {
                //DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_EMP_DMAT_ACTIVE_STATUS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ID", OracleType.Number).Value = ValBo.ID;
                cmd.Parameters.Add("p_ISACTIVE", OracleType.NVarChar).Value = ValBo.ISACTIVE;
                cmd.Parameters.Add("p_MODIFIEDBY", OracleType.NVarChar).Value = ValBo.MODIFIEDBY;

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


        public bool Insert_Emp_DmatDetail(Employee_profileBO ValBo)
        {
            bool statu1 = false;
            try
            {

                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Save_EmpDmatDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.VarChar).Value = ValBo.ECODE;
                cmd.Parameters.Add("P_SECURITY_NAME", OracleType.VarChar).Value = ValBo.SECURITY_NAME;
                cmd.Parameters.Add("P_DPID", OracleType.VarChar).Value = ValBo.DPID;
                cmd.Parameters.Add("P_CLIENT_ID", OracleType.VarChar).Value = ValBo.CLIENT_ID;
                cmd.Parameters.Add("P_MEMBER_TYPE", OracleType.VarChar).Value = ValBo.MEMBER_TYPE;

                cmd.Parameters.Add("P_FILE_PATH", OracleType.VarChar).Value = ValBo.FILE_PATH;


                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    statu1 = true;
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
            return statu1;
        }


        public DataSet CHECK_activeinactive_status(Employee_profileBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_CHK_EMPDMAT_ACTIVESTATUS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.VarChar).Value = objbo.ECODE;

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
            }
        }

        public void Update_Emp_Profile_Status(Employee_profileBO ValBo)
        {
            try
            {
                //DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_EMP_Profile_STATUS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ECODE", OracleType.VarChar).Value = ValBo.ECODE;
                cmd.Parameters.Add("p_email_id", OracleType.VarChar).Value = ValBo.email_id;
                cmd.Parameters.Add("p_empstatus", OracleType.VarChar).Value = ValBo.empstatus;

                cmd.Parameters.Add("p_FILE_PATH", OracleType.VarChar).Value = ValBo.FILE_PATH;
                cmd.Parameters.Add("p_profile_img", OracleType.VarChar).Value = ValBo.profile_img;
                cmd.Parameters.Add("p_MODIFIEDBY", OracleType.VarChar).Value = ValBo.MODIFIEDBY;
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
        public DataSet GET_LAPS_EMP_STOCK(Employee_profileBO ValBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_LBV_LAV1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                //cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("P_EMPID", OracleType.NVarChar).Value = ValBo.ECODE;
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
