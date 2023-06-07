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
    public class TaxDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        OracleCommand cmd = new OracleCommand();
        public DataSet gettaxdata(TaxBO objBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_TAX_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_YEAR", OracleType.VarChar).Value = string.IsNullOrEmpty(objBo.FINANCIAL_YEAR) ? (object)System.DBNull.Value : objBo.FINANCIAL_YEAR.ToString().Trim();
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
            }
        }

        //Added by Krutika on 02-01-23
        public DataSet getTaxRegimedata(TaxBO objBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_TAX_REGIME_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_YEAR", OracleType.VarChar).Value = string.IsNullOrEmpty(objBo.FINANCIAL_YEAR) ? (object)System.DBNull.Value : objBo.FINANCIAL_YEAR.ToString().Trim();
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
            }
        }
        //End

        public DataSet bind_Year_Grid(TaxBO objBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_FINANCIAL_YEAR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();                
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;

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


        public DataSet GET_F_YEAR_TAX_DATA(TaxBO objBo)
        {
            DataSet dsresult = new DataSet();
            bool status1 = false;
            string count = "";
            string[] values = new string[2];
            try
            {
                //string agencyid;
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = " ESOP_GET_F_YEAR_TAX_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_INCOME_RANGE_FROM", OracleType.VarChar).Value = objBo.INCOME_RANGE_FROM;
                cmd.Parameters.Add("P_INCOME_RANGE_TO", OracleType.VarChar).Value = objBo.INCOME_RANGE_TO;
                cmd.Parameters.Add("P_YEAR", OracleType.VarChar).Value = objBo.YEAR;
                cmd.Parameters.Add("P_TAX_REGIME", OracleType.VarChar).Value = objBo.TAX_REGIME;
                //cmd.Parameters.Add("p_message", OracleType.VarChar, 2000).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("p_message1", OracleType.VarChar, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                con.Open();
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
                //int i = cmd.ExecuteNonQuery();
                //count = cmd.Parameters["p_message"].Value.ToString().Trim();
                //values[0] = cmd.Parameters["p_message"].Value.ToString().Trim();
                //values[1] = cmd.Parameters["p_message1"].Value.ToString().Trim();
                //cmd.Dispose();
                //if (i > 0)
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            //return count;
            //return values;
        }
         
        public bool Insert_tax(TaxBO objBo)
        {
            bool status1 = false;
            try
            {
                //string agencyid;
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_UPDATE_TAX";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ID", OracleType.VarChar).Value = objBo.ID;
                cmd.Parameters.Add("P_INCOME_RANGE_FROM", OracleType.VarChar).Value = objBo.INCOME_RANGE_FROM;
                cmd.Parameters.Add("P_INCOME_RANGE_TO", OracleType.VarChar).Value = objBo.INCOME_RANGE_TO;
                cmd.Parameters.Add("P_TAX_RATE", OracleType.VarChar).Value = objBo.TAX_RATE;
                cmd.Parameters.Add("P_TAX_REGIME", OracleType.VarChar).Value = objBo.TAX_REGIME;               //Added by Krutika on 02-01-23
                cmd.Parameters.Add("P_YEAR", OracleType.VarChar).Value = string.IsNullOrEmpty(objBo.FINANCIAL_YEAR) ? (object)System.DBNull.Value : objBo.FINANCIAL_YEAR.ToString().Trim();
                cmd.Parameters.Add("P_CREATEDBY", OracleType.VarChar).Value = objBo.CREATEDBY;
                cmd.Parameters.Add("P_MODIFIEDBY", OracleType.VarChar).Value = objBo.MODIFIEDBY;
                cmd.Parameters.Add("p_message", OracleType.VarChar, 5000).Direction = ParameterDirection.Output;

                con.Open();
                int i = cmd.ExecuteNonQuery();


                cmd.Dispose();
                if (i > 0)
                {
                    status1 = true;
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
            return status1;
        }
        public String Insert_Financial_Year(TaxBO objBo)
        {
            bool status1 = false;
            string strmsg = "";
            try
            {
                //string agencyid;
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_FINANCIAL_YEAR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ACTION", OracleType.VarChar).Value = objBo.ACTION;
                cmd.Parameters.Add("P_FINANCIAL_YEAR", OracleType.VarChar).Value = objBo.FINANCIAL_YEAR;
                cmd.Parameters.Add("p_message", OracleType.VarChar, 2000).Direction = ParameterDirection.Output;
                con.Open();
                int i = cmd.ExecuteNonQuery();
                strmsg = cmd.Parameters["p_message"].Value.ToString().Trim();
                cmd.Dispose();
                if (i > 0)
                {
                    status1 = true;
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
            return strmsg;
        }
        public DataSet Fill_Financial_Year()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = " ESOP_FILL_FINANCIAL_YEAR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();               
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;

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

        public DataSet Fill_Financial_Year_DDL()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_FILL_FINANCIAL_YEAR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;

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
        public bool taxDelete(TaxBO objBo)
        {
            bool status1 = false;

            string strmsg = "";
            try
            {

                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_DELETE_TAX";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ID", OracleType.Number).Value = objBo.ID;


                int i = cmd.ExecuteNonQuery();


                cmd.Dispose();
                if (i > 0)
                {
                    status1 = true;
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
            return status1;
        }
        public DataSet taxcount()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_TAX_COUNT";
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
