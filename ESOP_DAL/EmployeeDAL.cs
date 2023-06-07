//using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ESOP_BO;

namespace ESOP_DAL
{
    public class EmployeeDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        OracleCommand cmd = new OracleCommand();
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING(EmployeeBO EmpBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                //cmd.CommandText = "ESOP_USP_GET_EMP_HR1"; //ESOP_USP_GET_EMP_DASHBOARD3 //2
                cmd.CommandText = "ESOP_USP_GET_EMP_HR2"; //ESOP_USP_GET_EMP_HR1 to HR2 by Pallavi
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();     
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = EmpBo.ECode;
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
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_DETAILS(EmployeeBO EmpBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                //cmd.CommandText = "ESOP_USP_GET_EMP_DASHBOARD_DETAILS_HR1";  //ESOP_USP_GET_EMP_DASHBOARD_DETAILS3 //2
                cmd.CommandText = "ESOP_USP_GET_EMP_DASHBOARD_DETAILS_HR2";  //Created by Krutika on 19-05-22, Lapse date addede
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();               
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = EmpBo.ECode;
                cmd.Parameters.Add("p_GRANT_NAME", OracleType.VarChar).Value = EmpBo.GRANT_NAME;
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


        public DataSet GET_Distinct_VestID(EmployeeBO EmpBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_EMP_TRANCHWISE1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = EmpBo.ECode;
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
            }
        }
        //--------------------------------------------------------
        public DataSet getEmp(string ecode, String Action)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_GetEmployeeName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_Action", OracleType.VarChar).Value = Action;
                cmd.Parameters.Add("p_EmpName", OracleType.VarChar).Value = ecode;
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
        public DataSet InserEmp(EmployeeBO EmpBo)
        {
            int i = 0;
            string strmsg = "";
            DataSet dsresult = new DataSet();

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_EMP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_EmpID", OracleType.VarChar).Value = EmpBo.EmpID;
                cmd.Parameters.Add("p_Role", OracleType.Int32).Value = EmpBo.RoleID;
                cmd.Parameters.Add("p_CreatedBy", OracleType.VarChar).Value = EmpBo.LoginID;
                cmd.Parameters.Add("p_message", OracleType.VarChar, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_message_hr", OracleType.VarChar, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;

                i = cmd.ExecuteNonQuery();
                strmsg = cmd.Parameters["p_message"].Value.ToString().Trim();

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
            //return i;
            return dsresult;
        }


    }
}
