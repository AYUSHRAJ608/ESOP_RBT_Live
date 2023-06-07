using System;
using System.Configuration;
using System.Data;
using ESOP_BO;
//using Oracle.ManagedDataAccess.Client;
using System.Data.OracleClient;

namespace ESOP_DAL
{
    public class ValuationDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        OracleCommand cmd = new OracleCommand();
        public DataSet getAgency(ValuationBO ValBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Get_Valuation_Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                // cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("P_search", OracleType.VarChar).Value = ValBo.search;
                // cmd.Parameters.Add("P_AGENCY_NAME", OracleType.VarChar).Value = ValBo.search;
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


        public DataSet ESOP_GET_SRCH_FILTER(ValuationBO ValBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_SRCH_FILTER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                // cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("P_search", OracleType.VarChar).Value = ValBo.search;
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

        public string Insert_Valuation(ValuationBO ValBo)
        {
            string strmsg = "";
            //  DataTable ds = new DataTable();
            try
            {
                //string agencyid;
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_insert_valuation";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_AGENCY_ID", OracleType.VarChar).Value = ValBo.AGENCY_ID;
                cmd.Parameters.Add("P_AGENCY_NAME", OracleType.VarChar).Value = ValBo.AGENCY_NAME;
                cmd.Parameters.Add("P_AGENCY_ADDRESS", OracleType.VarChar).Value = ValBo.AGENCY_ADDRESS;
                //  cmd.Parameters.Add("P_CREATION_DATE", OracleType.DateTime).Value = ValBo.CREATION_DATE;
                //  cmd.Parameters.Add("P_UPDATION_DATE", OracleType.DateTime).Value = ValBo.UPDATION_DATE;
                cmd.Parameters.Add("P_CREATED_BY", OracleType.VarChar).Value = ValBo.CREATED_BY;
                cmd.Parameters.Add("P_UPDATED_BY", OracleType.VarChar).Value = ValBo.UPDATED_BY;
                // cmd.Parameters.Add("P_ISVISIBLE", OracleType.VarChar).Value = ValBo.ISVISIBLE;
                // cmd.Parameters.Add("P_REMARK1", OracleType.VarChar).Value = ValBo.REMARK1;
                // cmd.Parameters.Add("P_REMARK2", OracleType.VarChar).Value = ValBo.REMARK2;
                cmd.Parameters.Add("P_key", OracleType.VarChar).Value = ValBo.search;
                cmd.Parameters.Add("p_message", OracleType.VarChar, 10).Direction = ParameterDirection.Output;
                con.Open();
                int i = cmd.ExecuteNonQuery();


                strmsg = cmd.Parameters["p_message"].Value.ToString();
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
        public string valuationDelete(ValuationBO ValBo)
        {
            //bool status1 = false;
            DataSet ds = new DataSet();
            string strmsg = "";
            try
            {

                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESPO_Delete_valuation";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_AGENCY_ID", OracleType.Number).Value = ValBo.AGENCY_ID;
                cmd.Parameters.Add("p_message", OracleType.VarChar, 50).Direction = ParameterDirection.Output;

                //cmd.Parameters.Add("P_ISVISIBLE", OracleType.VarChar).Value = ValBo.ISVISIBLE;

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

            }
            return strmsg;
        }

        public DataSet ESOP_GET_VALUATION_ALL_COUNT()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_VALUATION_ALL_COUNT";
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
        public DataSet Insert_PDF_Password(ValuationBO ValBo)
        {
            string strmsg = "";
            //  DataTable ds = new DataTable();
            try
            {
                //string agencyid;
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_PDF_PASSWORD";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_PASSWORD", OracleType.VarChar).Value = ValBo.AGENCY_NAME;
                cmd.Parameters.Add("E_PASSWORD", OracleType.VarChar).Value = ValBo.AGENCY_ADDRESS;
                cmd.Parameters.Add("P_CREATED_BY", OracleType.VarChar).Value = ValBo.CREATED_BY;
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

        public DataSet Insert_Yrs_Lapse(ValuationBO ValBo)
        {
            string strmsg = "";
            //  DataTable ds = new DataTable();
            try
            {
                //string agencyid;
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "Sp_Esop_LapseMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Grant_Name", OracleType.VarChar).Value = ValBo.AGENCY_NAME;
                cmd.Parameters.Add("P_Month_of_Lapse", OracleType.Number).Value = ValBo.Month_of_Lapse;
                cmd.Parameters.Add("P_Created_By", OracleType.VarChar).Value = ValBo.CREATED_BY;
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
        public DataSet ESOP_AUDIT()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_PDF_PASSWORD_AUDIT";
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
        public DataSet GET_Yrs_lapsedata()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Sp_Get_Lapse_Years";
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

        public DataSet GET_DROPDOWN()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_ID_PROOF";
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
    }
}
