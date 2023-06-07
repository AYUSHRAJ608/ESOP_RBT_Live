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
    public class vesting_creation_DAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        vesting_creation_BO VestingBO;
        public DataSet GetVestingDuration(vesting_creation_BO VestingBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetVestingDuration";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_YEAR", OracleType.Number).Value = VestingBO.YEAR;
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

        public DataSet GET_VESTING_MASTER_ID()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "GET_VESTING_MASTER_ID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("p_VID", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public void VESTING_MASTER_INSERT(vesting_creation_BO VestingBO)
        {
            try
            {
                //DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_VESTING_MASTER_INSERT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_VID", OracleType.Number).Value = VestingBO.VID;
                cmd.Parameters.Add("p_VNAME", OracleType.NVarChar).Value = VestingBO.VNAME;
                cmd.Parameters.Add("p_VCYCLE", OracleType.Number).Value = VestingBO.VCYCLE;
                cmd.Parameters.Add("p_VCYCLENAME", OracleType.NVarChar).Value = VestingBO.VCYCLENAME;
                cmd.Parameters.Add("p_PERCENTAGE", OracleType.Number).Value = VestingBO.PERCENTAGE;
                cmd.Parameters.Add("p_DURATION", OracleType.Number).Value = VestingBO.DURATION;
                cmd.Parameters.Add("p_CREATEDBY", OracleType.NVarChar).Value = VestingBO.CREATEDBY;

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

        public DataSet GETVESTINGDETAILS()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GETVESTINGDETAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
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
        public DataSet GETVESTINGDETAILSBYID(vesting_creation_BO VestingBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GETVESTINGDETAILSBYID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_VID", OracleType.Number).Value = VestingBO.VID;
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
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_ADMIN_EMP_STOCK_MAPPING4";//3 //2
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

        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_DETAILS()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_ADMIN_EMP_STOCK_MAPPING_DETAILS";
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

        public DataSet USP_GET_ADMIN_STOCK_MAPPING_TRANCHWISE()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_ADMIN_STOCK_MAPPING_TRANCHWISE_NEW";
                    //"ESOP_USP_GET_ADMIN_STOCK_MAPPING_TRANCHWISE1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
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
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_TRANCHWISE_DETAILS(vesting_creation_BO VestingBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                //cmd.CommandText = "ESOP_USP_GET_ADMIN_EMP_STOCK_MAPPING_TRANCHWISE_DETAILS4";  //3 //2
                cmd.CommandText = "ESOP_USP_GET_ADMIN_EMP_STOCK_MAPPING_TRANCHWISE_DETAILS_5";   //Created by Krutika on 19-05-22 and added lapse_date)
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_GRANT_NAME", OracleType.NVarChar).Value = VestingBO.GRANT_NAME;
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
        public DataSet CHECK_VESTING_NAME(vesting_creation_BO VestingBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_CHECK_VESTING_NAME";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_VNAME", OracleType.NVarChar).Value = VestingBO.VNAME;
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
        public void VESTING_MASTER_UPDATE_ACTIVE_STATUS(vesting_creation_BO VestingBO)
        {
            try
            {
                //DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_VESTING_MASTER_UPDATE_ACTIVE_STATUS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_VID", OracleType.Number).Value = VestingBO.VID;               
                cmd.Parameters.Add("p_ISACTIVE", OracleType.NVarChar).Value = VestingBO.ISACTIVE;
                cmd.Parameters.Add("p_MODIFIEDBY", OracleType.NVarChar).Value = VestingBO.MODIFIEDBY;

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
        public void VESTING_MASTER_DELETE(vesting_creation_BO VestingBO)
        {
            try
            {
                //DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_VESTING_MASTER_DELETE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_VID", OracleType.Number).Value = VestingBO.VID;
                cmd.Parameters.Add("p_MODIFIEDBY", OracleType.NVarChar).Value = VestingBO.MODIFIEDBY;

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
        public DataSet CHECK_GRANT_VID(vesting_creation_BO VestingBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_CHECK_GRANT_VID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_VID", OracleType.NVarChar).Value = VestingBO.VID;
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
        //public DataSet GET_LAPS_EMP_STOCK()
        //{
        //    try
        //    {
        //        DataSet dsresult = new DataSet();
        //        OracleCommand cmd = new OracleCommand();
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "ESOP_GET_LBV_LAV";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("P_EMPID", OracleType.NVarChar).Value = VestingBO.VID;
        //        OracleDataAdapter objAdap = new OracleDataAdapter(cmd);

        //        objAdap.Fill(dsresult);

        //        return dsresult;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        //con.Dispose();
        //    }
        //}
        public DataSet ESOP_VESTING_ALL_COUNT()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_VESTING_ALL_COUNT";
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
        public DataSet FIVE_YEAR_Laps()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_LBV_LAV_5Years";
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
