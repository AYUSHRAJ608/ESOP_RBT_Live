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
    public class UserDAL
    {

        private OracleDAL conn;
        public UserDAL()
        {
            conn = new OracleDAL();
        }

        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        //public DataSet GetUser(cUserEntityRequest request)
        //{
        //    DataSet dsresult = new DataSet();
        //    try
        //    {
        //        OracleParameter[] sqlParameters = new OracleParameter[2];

        //        sqlParameters[0] = new OracleParameter("@Action", OracleType.VarChar);
        //        sqlParameters[0].Value = request.UserEntity.Action;

        //        sqlParameters[1] = new OracleParameter("@UserName", OracleType.VarChar);
        //        sqlParameters[1].Value = request.UserEntity.UserName;

        //        dsresult = conn.exe_SelectQuery("sp_UserMaster", sqlParameters);
        //        return dsresult;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //public DataSet chkLoginCredential(cUserEntityRequest request)
        //{
        //    DataSet dsresult = new DataSet();
        //    try
        //    {
        //        OracleCommand objCmd = new OracleCommand(" select e.Emp_NAME,R.RoleName into from UserMAster U Inner Join EmployeeMaster E on U.EmpID = E.ECode Inner Join RoleMaster R on U.Roleid = R.Roleid where LoginID = "+ request.UserEntity.LoginID, conn);
        //        objCmd.Connection = conn;
        //        objCmd.CommandType = CommandType.StoredProcedure;
        //        //objCmd.Parameters.Add("p_Name", OracleType.VarChar).Value = request.UserEntity.LoginID;
        //        //objCmd.Parameters.Add("p_Password", OracleType.VarChar).Value =request.UserEntity.Password;
        //        OracleDataAdapter da = new OracleDataAdapter(objCmd);
        //        da.Fill(dsresult);

        //        return dsresult;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public DataSet chkLoginCredential(cUserEntityRequest request)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                //  con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_CHECK_LOGIN_USER_1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("ploginID", OracleType.VarChar).Value = request.UserEntity.LoginID;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;

                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;

                //OracleCommand cmd = new OracleCommand();
                //con.Open();
                //cmd.Connection = con;
                //cmd.CommandText = "Select * from demo";
                //OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                //DataSet objDs = new DataSet();
                //objAdap.Fill(objDs);
                //return objDs;


            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public int InsertIPAddressDetails(cUserEntityRequest request)
        {
            int result = 0;
            try
            {
                //DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_IPADDRESS_DTL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_LOGINID", OracleType.VarChar).Value = request.UserEntity.LoginID;
                cmd.Parameters.Add("P_IPADDRESS", OracleType.VarChar).Value = request.UserEntity.IPAddress;

                result=cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public DataSet GetAllUsers()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                //  con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_ALL_USERS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataSet GetUser(UserBO Bo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                //  con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_USER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("Emp_ID", OracleType.VarChar).Value = Bo.EmpID;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
