using ESOP_BO;
using System;
using System.Data;
//using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data.OracleClient;

namespace ESOP_DAL
{
    public class FMVCreationDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();
        public DataSet getFmv(FMVCreationBO FMVBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Get_Fmv_Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                // cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("P_VALUATION_DATE", OracleType.VarChar).Value = FMVBo.VALUATION_DATE;
                //cmd.Parameters.Add("P_VALID_UPTO_DATE", OracleType.VarChar).Value = FMVBo.VALID_UPTO_DATE;
                //cmd.Parameters.Add("P_FMV_PRICE", OracleType.VarChar).Value = FMVBo.FMV_PRICE;
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

        public DataTable getvaluedbyddl(FMVCreationBO FMVBo)
        {
            try
            {
                DataTable dsresult = new DataTable();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Get_Valuation_Data_Gridview";
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
            }
        }

        //public DataTable getvaluedbyddl2()
        //{
        //    try
        //    {
        //        DataTable dsresult = new DataTable();
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "ESOP_Get_Valuation_Data_Gridview";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
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
        //    }
        //}
        public string Insert_Fmv(FMVCreationBO FMVBo)
        {
            DataTable ds = new DataTable();
            string strmsg = "";
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "ESOP_insert_fmv";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_FMV_CREATION_ID", OracleType.Number).Value = FMVBo.FMV_CREATION_ID;
                cmd.Parameters.Add("P_VALUATION_DATE", OracleType.DateTime).Value = FMVBo.VALUATION_DATE;
                cmd.Parameters.Add("P_VALID_UPTO_DATE", OracleType.DateTime).Value = FMVBo.VALID_UPTO_DATE;
                cmd.Parameters.Add("P_FMV_PRICE", OracleType.VarChar).Value = FMVBo.FMV_PRICE;
                cmd.Parameters.Add("P_VALUED_BY", OracleType.VarChar).Value = FMVBo.VALUED_BY;
                cmd.Parameters.Add("P_UPLOAD_FILE", OracleType.VarChar).Value = FMVBo.UPLOAD_FILE;
                //  cmd.Parameters.Add("P_CREATION_DATE", OracleType.DateTime).Value = FMVBo.CREATION_DATE;
                //  cmd.Parameters.Add("P_UPDATATION_DATE", OracleType.DateTime).Value = FMVBo.UPDATATION_DATE;
                cmd.Parameters.Add("P_CREATED_BY", OracleType.VarChar).Value = FMVBo.CREATED_BY;
                cmd.Parameters.Add("P_UPDATED_BY", OracleType.VarChar).Value = FMVBo.UPDATED_BY;
                //  cmd.Parameters.Add("P_ISVISIBLE", OracleType.VarChar).Value = FMVBo.ISVISIBLE;
                // cmd.Parameters.Add("P_REMARK1", OracleType.VarChar).Value = FMVBo.REMARK1;
                // cmd.Parameters.Add("P_REMARK2", OracleType.VarChar).Value = FMVBo.REMARK2;
                cmd.Parameters.Add("P_key", OracleType.VarChar).Value = FMVBo.btntext;
                cmd.Parameters.Add("p_message", OracleType.VarChar, 150).Direction = ParameterDirection.Output;
                int i = cmd.ExecuteNonQuery();


                strmsg = cmd.Parameters["p_message"].Value.ToString().Trim();


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
            return strmsg;
        }


        public string FmvDelete(FMVCreationBO FMVBo)
        {
            // bool status1 = false;
            DataSet ds = new DataSet();
            string strmsg = "";
            try
            {
                //DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESPO_Delete_fmv";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_key", OracleType.VarChar).Value = FMVBo.btntext;
                cmd.Parameters.Add("P_FMV_CREATION_ID", OracleType.Number).Value = FMVBo.FMV_CREATION_ID;
                cmd.Parameters.Add("p_message", OracleType.VarChar, 150).Direction = ParameterDirection.Output;

                int i = cmd.ExecuteNonQuery();
                strmsg = cmd.Parameters["p_message"].Value.ToString().Trim();
                //cmd.Dispose();
                //if (result > 0)
                //{
                //    status1 = true;
                //}
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
            return strmsg;
        }

        public DataSet ESOP_FMV_CREATION_ALL_COUNT()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_FMV_CREATION_ALL_COUNT";
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
            }
        }

        public DataSet GET_FMV_AUDIT(FMVCreationBO FMVBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "GET_FMV_AUDIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_FMV_CREATION_ID", OracleType.Number).Value = FMVBo.FMV_CREATION_ID;
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
        public DataSet Insert_Emp_Password(FMVCreationBO FMVBo)
        {
            DataSet dsresult = new DataSet();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "ESOP_INSERT_EMP_PASSWORD";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_EMP_PASSWORD", OracleType.VarChar).Value = FMVBo.msg;
                cmd.Parameters.Add("P_CREATED_BY", OracleType.VarChar).Value = FMVBo.CREATED_BY;
                cmd.Parameters.Add("P_key", OracleType.VarChar).Value = FMVBo.btntext;
                //cmd.Parameters.Add("P_message", OracleType.VarChar, 150).Direction = ParameterDirection.Output;
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
    }
}
