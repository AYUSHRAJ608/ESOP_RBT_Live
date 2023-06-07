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
    public class employee_saleDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        public DataSet GET_EMP_SALE_DATA(employee_saleBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_EMP_SALE_DATA3";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPID", OracleType.NVarChar).Value = objBO.ECODE;
                cmd.Parameters.Add("P_START_DATE", OracleType.DateTime).Value = objBO.SALE_WINDOW_START_DATE;
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
        public DataSet GET_EMPLOYEE_SELL_DATA1(employee_saleBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SELL_DATA1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
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
                //con.Dispose();
            }
        }
        public DataSet GET_EMP_data(employee_saleBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Get_EMP_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPCODE", OracleType.NVarChar).Value = objBO.ECODE;
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
        public int INSERT_EMPLOYEE_SALE_TRANSACTION(employee_saleBO objBO)
        {
            bool status = false;
            int id;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_INSERT_EMPLOYEE_SALE_TRANSACTION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE;
                cmd.Parameters.Add("P_OPTION_SALE", OracleType.Number).Value = objBO.OPTION_SALE;
                cmd.Parameters.Add("P_TRANCH_VESTING", OracleType.NVarChar).Value = objBO.TRANCH_VESTING;
                cmd.Parameters.Add("P_TOTAL_AMOUNT", OracleType.Number).Value = objBO.TOTAL_AMOUNT;
                //cmd.Parameters.Add("P_PAYMENT_MODE", OracleType.NVarChar).Value = objBO.PAYMENT_MODE;

                cmd.Parameters.Add("P_CHEQUE_BANK_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_BANK_NAME;
                cmd.Parameters.Add("P_CHEQUE_BRANCH_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_BRANCH_NAME;
                cmd.Parameters.Add("P_CHEQUE_ACC_NO", OracleType.NVarChar).Value = objBO.CHEQUE_ACC_NO;
                cmd.Parameters.Add("P_CHEQUE_IFSC", OracleType.NVarChar).Value = objBO.CHEQUE_IFSC;
                //cmd.Parameters.Add("P_CHEQUE_MICR", OracleType.NVarChar).Value = objBO.CHEQUE_MICR;
                //cmd.Parameters.Add("P_CHEQUE_FILE_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_NAME;
                //cmd.Parameters.Add("P_CHEQUE_FILE_PATH", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_PATH;

                //cmd.Parameters.Add("P_CHEQUE_NUMBER", OracleType.NVarChar).Value = objBO.CHEQUE_NUMBER;
                //cmd.Parameters.Add("P_CHEQUE_DATE", OracleType.DateTime).Value = objBO.CHEQUE_DATE;
                //cmd.Parameters.Add("P_CHEQUE_AMOUNT", OracleType.Number).Value = objBO.CHEQUE_AMOUNT;
                //cmd.Parameters.Add("P_CHEQUE_FILE_PATH_FRESH", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_PATH_FRESH;

                //cmd.Parameters.Add("P_NEFT_BANK_NAME", OracleType.NVarChar).Value = objBO.NEFT_BANK_NAME;
                //cmd.Parameters.Add("P_NEFT_BRANCH_NAME", OracleType.NVarChar).Value = objBO.NEFT_BRANCH_NAME;
                //cmd.Parameters.Add("P_NEFT_ACC_NO", OracleType.NVarChar).Value = objBO.NEFT_ACC_NO;
                //cmd.Parameters.Add("P_NEFT_IFSC", OracleType.NVarChar).Value = objBO.NEFT_IFSC;
                //cmd.Parameters.Add("P_NEFT_FILE_NAME", OracleType.NVarChar).Value = objBO.NEFT_FILE_NAME;
                //cmd.Parameters.Add("P_NEFT_FILE_PATH", OracleType.NVarChar).Value = objBO.NEFT_FILE_PATH;
                //cmd.Parameters.Add("P_NEFT_UTR_NO", OracleType.NVarChar).Value = objBO.NEFT_UTR_NO;

                //cmd.Parameters.Add("P_LOAN_LENDER_BANK_NAME", OracleType.NVarChar).Value = objBO.LOAN_LENDER_BANK_NAME;
                //cmd.Parameters.Add("P_LOAN_AMOUNT", OracleType.Number).Value = objBO.LOAN_AMOUNT;
                //cmd.Parameters.Add("P_LOAN_MARGIN_AMOUNT", OracleType.Number).Value = objBO.LOAN_MARGIN_AMOUNT;
                //cmd.Parameters.Add("P_LOAN_MARGIN_PAYMENT_MODE", OracleType.NVarChar).Value = objBO.LOAN_MARGIN_PAYMENT_MODE;

                cmd.Parameters.Add("P_SECURITY_NAME", OracleType.NVarChar).Value = objBO.SECURITY_NAME;
                cmd.Parameters.Add("P_DPID", OracleType.NVarChar).Value = objBO.DPID;
                cmd.Parameters.Add("P_CLIENT_ID", OracleType.NVarChar).Value = objBO.CLIENT_ID;
                cmd.Parameters.Add("P_MEMBER_TYPE", OracleType.NVarChar).Value = objBO.MEMBER_TYPE;
                cmd.Parameters.Add("P_DEMAT_FILE_PATH", OracleType.NVarChar).Value = objBO.DEMAT_FILE_PATH;
                cmd.Parameters.Add("P_PAN_FILE_PATH", OracleType.NVarChar).Value = objBO.PAN_FILE_PATH;

                cmd.Parameters.Add("P_SALE_OFFER_FILE_PATH", OracleType.NVarChar).Value = objBO.SALE_OFFER_FILE_PATH;
                cmd.Parameters.Add("P_SALE_DECLARATION_FILE_PATH", OracleType.NVarChar).Value = objBO.SALE_DECLARATION_FILE_PATH;
                cmd.Parameters.Add("P_SALE_TRANSACTION_RECEIPT_FILE_PATH", OracleType.NVarChar).Value = objBO.SALE_TRANSACTION_RECEIPT_FILE_PATH;
                cmd.Parameters.Add("P_DIS_STATUS", OracleType.NVarChar).Value = objBO.DIS_STATUS;
                cmd.Parameters.Add("P_APPROVE_STATUS", OracleType.NVarChar).Value = objBO.APPROVE_STATUS;
                cmd.Parameters.Add("P_CREATEDBY", OracleType.NVarChar).Value = objBO.CREATEDBY;

                cmd.Parameters.Add("P_ID", OracleType.Number);
                cmd.Parameters["P_ID"].Direction = ParameterDirection.Output;

                int result = cmd.ExecuteNonQuery();
                id = Convert.ToInt32(cmd.Parameters["P_ID"].Value);
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
            return id;
        }
        public int INSERT_SALE_TRANSACTION_RECEIPT_FILE_PATH(employee_saleBO objBO)
        {
            bool status = false;
            int id;
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand();
            try
            {
                cmd = new OracleCommand();
                // con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_SALE_TRANSACTION_RECEIPT_FILE_PATH";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_id", OracleType.VarChar).Value = objBO.ID;
                cmd.Parameters.Add("P_ECODE", OracleType.VarChar).Value = objBO.ECODE;
                cmd.Parameters.Add("P_SALE_TRANSACTION_RECEIPT_FILE_PATH", OracleType.VarChar).Value = objBO.SALE_TRANSACTION_RECEIPT_FILE_PATH;
                con.Open();
                int result = cmd.ExecuteNonQuery();
                id = Convert.ToInt32(cmd.Parameters["P_id"].Value);
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
            return id;
        }
        public int INSERT_EMPLOYEE_SALE_TRANSACTION_SESSION(employee_saleBO objBO)
        {
            bool status = false;
            int id;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_INSERT_EMPLOYEE_SALE_TRANSACTION_SESSION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE;
                cmd.Parameters.Add("P_OPTION_SALE", OracleType.Number).Value = objBO.OPTION_SALE;
                cmd.Parameters.Add("P_TRANCH_VESTING", OracleType.NVarChar).Value = objBO.TRANCH_VESTING;
                cmd.Parameters.Add("P_TOTAL_AMOUNT", OracleType.Number).Value = objBO.TOTAL_AMOUNT;
                //cmd.Parameters.Add("P_PAYMENT_MODE", OracleType.NVarChar).Value = objBO.PAYMENT_MODE;

                cmd.Parameters.Add("P_CHEQUE_BANK_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_BANK_NAME;
                cmd.Parameters.Add("P_CHEQUE_BRANCH_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_BRANCH_NAME;
                cmd.Parameters.Add("P_CHEQUE_ACC_NO", OracleType.NVarChar).Value = objBO.CHEQUE_ACC_NO;
                cmd.Parameters.Add("P_CHEQUE_IFSC", OracleType.NVarChar).Value = objBO.CHEQUE_IFSC;
                //cmd.Parameters.Add("P_CHEQUE_MICR", OracleType.NVarChar).Value = objBO.CHEQUE_MICR;
                //cmd.Parameters.Add("P_CHEQUE_FILE_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_NAME;
                //cmd.Parameters.Add("P_CHEQUE_FILE_PATH", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_PATH;

                //cmd.Parameters.Add("P_CHEQUE_NUMBER", OracleType.NVarChar).Value = objBO.CHEQUE_NUMBER;
                //cmd.Parameters.Add("P_CHEQUE_DATE", OracleType.DateTime).Value = objBO.CHEQUE_DATE;
                //cmd.Parameters.Add("P_CHEQUE_AMOUNT", OracleType.Number).Value = objBO.CHEQUE_AMOUNT;
                //cmd.Parameters.Add("P_CHEQUE_FILE_PATH_FRESH", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_PATH_FRESH;

                //cmd.Parameters.Add("P_NEFT_BANK_NAME", OracleType.NVarChar).Value = objBO.NEFT_BANK_NAME;
                //cmd.Parameters.Add("P_NEFT_BRANCH_NAME", OracleType.NVarChar).Value = objBO.NEFT_BRANCH_NAME;
                //cmd.Parameters.Add("P_NEFT_ACC_NO", OracleType.NVarChar).Value = objBO.NEFT_ACC_NO;
                //cmd.Parameters.Add("P_NEFT_IFSC", OracleType.NVarChar).Value = objBO.NEFT_IFSC;
                //cmd.Parameters.Add("P_NEFT_FILE_NAME", OracleType.NVarChar).Value = objBO.NEFT_FILE_NAME;
                //cmd.Parameters.Add("P_NEFT_FILE_PATH", OracleType.NVarChar).Value = objBO.NEFT_FILE_PATH;
                //cmd.Parameters.Add("P_NEFT_UTR_NO", OracleType.NVarChar).Value = objBO.NEFT_UTR_NO;

                //cmd.Parameters.Add("P_LOAN_LENDER_BANK_NAME", OracleType.NVarChar).Value = objBO.LOAN_LENDER_BANK_NAME;
                //cmd.Parameters.Add("P_LOAN_AMOUNT", OracleType.Number).Value = objBO.LOAN_AMOUNT;
                //cmd.Parameters.Add("P_LOAN_MARGIN_AMOUNT", OracleType.Number).Value = objBO.LOAN_MARGIN_AMOUNT;
                //cmd.Parameters.Add("P_LOAN_MARGIN_PAYMENT_MODE", OracleType.NVarChar).Value = objBO.LOAN_MARGIN_PAYMENT_MODE;

                cmd.Parameters.Add("P_SECURITY_NAME", OracleType.NVarChar).Value = objBO.SECURITY_NAME;
                cmd.Parameters.Add("P_DPID", OracleType.NVarChar).Value = objBO.DPID;
                cmd.Parameters.Add("P_CLIENT_ID", OracleType.NVarChar).Value = objBO.CLIENT_ID;
                cmd.Parameters.Add("P_MEMBER_TYPE", OracleType.NVarChar).Value = objBO.MEMBER_TYPE;
                cmd.Parameters.Add("P_DEMAT_FILE_PATH", OracleType.NVarChar).Value = objBO.DEMAT_FILE_PATH;
                cmd.Parameters.Add("P_PAN_FILE_PATH", OracleType.NVarChar).Value = objBO.PAN_FILE_PATH;

                cmd.Parameters.Add("P_SALE_OFFER_FILE_PATH", OracleType.NVarChar).Value = objBO.SALE_OFFER_FILE_PATH;
                cmd.Parameters.Add("P_SALE_DECLARATION_FILE_PATH", OracleType.NVarChar).Value = objBO.SALE_DECLARATION_FILE_PATH;
                cmd.Parameters.Add("P_SALE_TRANSACTION_RECEIPT_FILE_PATH", OracleType.NVarChar).Value = objBO.SALE_TRANSACTION_RECEIPT_FILE_PATH;

                cmd.Parameters.Add("P_CREATEDBY", OracleType.NVarChar).Value = objBO.CREATEDBY;

                cmd.Parameters.Add("P_ID", OracleType.Number);
                cmd.Parameters["P_ID"].Direction = ParameterDirection.Output;

                int result = cmd.ExecuteNonQuery();
                id = Convert.ToInt32(cmd.Parameters["P_ID"].Value);
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
            return id;
        }
        public void UPDATE_EMPLOYEE_SALE(employee_saleBO objBO)
        {

            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_UPDATE_EMPLOYEE_SALE"; //00
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE;
                cmd.Parameters.Add("P_VESTING_DETAIL_ID", OracleType.Number).Value = objBO.VESTING_DETAIL_ID;
                cmd.Parameters.Add("P_OPTION_SALE", OracleType.Number).Value = objBO.OPTION_SALE;

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

        public void INSERT_EMPLOYEE_SALE_TRANSACTION_DETAILS(employee_saleBO objBO)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_INSERT_EMPLOYEE_SALE_TRANSACTION_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_SALE_TRAN_ID", OracleType.Number).Value = objBO._SALE_TRAN_ID;
                cmd.Parameters.Add("P_GRANT_ID", OracleType.Number).Value = objBO._GRANT_ID;
                cmd.Parameters.Add("P_VESTING_DETAIL_ID", OracleType.Number).Value = objBO._VESTING_DETAIL_ID;
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO._ECODE;
                cmd.Parameters.Add("P_ENAME", OracleType.NVarChar).Value = objBO._ENAME;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.NVarChar).Value = objBO._GRANT_NAME;
                cmd.Parameters.Add("P_VESTING_DETAIL_CODE", OracleType.NVarChar).Value = objBO._VESTING_DETAIL_CODE;
                cmd.Parameters.Add("P_VESTING_DATE", OracleType.DateTime).Value = objBO._VESTING_DATE;
                cmd.Parameters.Add("P_NO_OF_VESTING", OracleType.Number).Value = objBO._NO_OF_VESTING;
                cmd.Parameters.Add("P_GRANT_PRICE", OracleType.Number).Value = objBO._GRANT_PRICE;
                cmd.Parameters.Add("P_EXERCISE_FMV_PRICE", OracleType.Number).Value = objBO._EXERCISE_FMV_PRICE;
                cmd.Parameters.Add("P_SALE_FMV_PRICE", OracleType.Number).Value = objBO._SALE_FMV_PRICE;
                cmd.Parameters.Add("P_NO_OF_SALE", OracleType.Number).Value = objBO._NO_OF_SALE;
                //////////cmd.Parameters.Add("P_TAXABLE_INCOME", OracleType.Number).Value = objBO._TAXABLE_INCOME;
                //////////cmd.Parameters.Add("P_EXERCISE_CONSIDERATION", OracleType.Number).Value = objBO._EXERCISE_CONSIDERATION;
                //////////cmd.Parameters.Add("P_FMV_GRANT_OPTION_EXERCISE", OracleType.Number).Value = objBO._FMV_GRANT_OPTION_EXERCISE;
                //////////cmd.Parameters.Add("P_REVISED_TAXABLE_INCOME", OracleType.Number).Value = objBO._REVISED_TAXABLE_INCOME;
                //////////cmd.Parameters.Add("P_TAX_PER_OPTION", OracleType.Number).Value = objBO._TAX_PER_OPTION;
                //////////cmd.Parameters.Add("P_PERQ_TAX_AMOUNT", OracleType.Number).Value = objBO._PERQ_TAX_AMOUNT;
                //////////cmd.Parameters.Add("P_TOTAL_AMOUNT", OracleType.Number).Value = objBO._TOTAL_AMOUNT;
                //////////cmd.Parameters.Add("P_AMOUNT_DEPOSITED", OracleType.Number).Value = objBO._AMOUNT_DEPOSITED;
                //////////cmd.Parameters.Add("P_FUNDING_AMOUNT", OracleType.Number).Value = objBO._FUNDING_AMOUNT;
                cmd.Parameters.Add("P_SECURITY_NAME", OracleType.NVarChar).Value = objBO._SECURITY_NAME;
                cmd.Parameters.Add("P_DPID", OracleType.NVarChar).Value = objBO._DPID;
                cmd.Parameters.Add("P_CLIENT_ID", OracleType.NVarChar).Value = objBO._CLIENT_ID;
                cmd.Parameters.Add("P_MEMBER_TYPE", OracleType.NVarChar).Value = objBO._MEMBER_TYPE;
                //cmd.Parameters.Add("P_PAYMENT_MODE", OracleType.NVarChar).Value = objBO._PAYMENT_MODE;
                cmd.Parameters.Add("P_BANK_NAME", OracleType.NVarChar).Value = objBO._BANK_NAME;
                cmd.Parameters.Add("P_BANK_BRANCH", OracleType.NVarChar).Value = objBO._BANK_BRANCH;
                cmd.Parameters.Add("P_ACC_NO", OracleType.NVarChar).Value = objBO._ACC_NO;
                cmd.Parameters.Add("P_IFSC", OracleType.NVarChar).Value = objBO._IFSC;
                //cmd.Parameters.Add("P_MICR", OracleType.NVarChar).Value = objBO._MICR;
                //cmd.Parameters.Add("P_CHEQUE_NUMBER", OracleType.NVarChar).Value = objBO._CHEQUE_NUMBER;
                //cmd.Parameters.Add("P_CHEQUE_DATE", OracleType.DateTime).Value = objBO._CHEQUE_DATE;
                cmd.Parameters.Add("P_CREATEDBY", OracleType.NVarChar).Value = objBO._CREATEDBY;
                cmd.Parameters.Add("P_DIS_STATUS", OracleType.NVarChar).Value = objBO.DIS_STATUS;
                cmd.Parameters.Add("P_APPROVE_STATUS", OracleType.NVarChar).Value = objBO.APPROVE_STATUS;
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
            //return status;
        }

        public void INSERT_EMPLOYEE_SALE_TRANSACTION_DETAILS_SESSION(employee_saleBO objBO)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_INSERT_EMPLOYEE_SALE_TRANSACTION_DETAILS_SESSION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_SALE_TRAN_ID", OracleType.Number).Value = objBO._SALE_TRAN_ID;
                cmd.Parameters.Add("P_GRANT_ID", OracleType.Number).Value = objBO._GRANT_ID;
                cmd.Parameters.Add("P_VESTING_DETAIL_ID", OracleType.Number).Value = objBO._VESTING_DETAIL_ID;
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO._ECODE;
                cmd.Parameters.Add("P_ENAME", OracleType.NVarChar).Value = objBO._ENAME;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.NVarChar).Value = objBO._GRANT_NAME;
                cmd.Parameters.Add("P_VESTING_DETAIL_CODE", OracleType.NVarChar).Value = objBO._VESTING_DETAIL_CODE;
                cmd.Parameters.Add("P_VESTING_DATE", OracleType.DateTime).Value = objBO._VESTING_DATE;
                cmd.Parameters.Add("P_NO_OF_VESTING", OracleType.Number).Value = objBO._NO_OF_VESTING;
                cmd.Parameters.Add("P_GRANT_PRICE", OracleType.Number).Value = objBO._GRANT_PRICE;
                cmd.Parameters.Add("P_EXERCISE_FMV_PRICE", OracleType.Number).Value = objBO._EXERCISE_FMV_PRICE;
                cmd.Parameters.Add("P_SALE_FMV_PRICE", OracleType.Number).Value = objBO._SALE_FMV_PRICE;
                cmd.Parameters.Add("P_NO_OF_SALE", OracleType.Number).Value = objBO._NO_OF_SALE;
                //////////cmd.Parameters.Add("P_TAXABLE_INCOME", OracleType.Number).Value = objBO._TAXABLE_INCOME;
                //////////cmd.Parameters.Add("P_EXERCISE_CONSIDERATION", OracleType.Number).Value = objBO._EXERCISE_CONSIDERATION;
                //////////cmd.Parameters.Add("P_FMV_GRANT_OPTION_EXERCISE", OracleType.Number).Value = objBO._FMV_GRANT_OPTION_EXERCISE;
                //////////cmd.Parameters.Add("P_REVISED_TAXABLE_INCOME", OracleType.Number).Value = objBO._REVISED_TAXABLE_INCOME;
                //////////cmd.Parameters.Add("P_TAX_PER_OPTION", OracleType.Number).Value = objBO._TAX_PER_OPTION;
                //////////cmd.Parameters.Add("P_PERQ_TAX_AMOUNT", OracleType.Number).Value = objBO._PERQ_TAX_AMOUNT;
                //////////cmd.Parameters.Add("P_TOTAL_AMOUNT", OracleType.Number).Value = objBO._TOTAL_AMOUNT;
                //////////cmd.Parameters.Add("P_AMOUNT_DEPOSITED", OracleType.Number).Value = objBO._AMOUNT_DEPOSITED;
                //////////cmd.Parameters.Add("P_FUNDING_AMOUNT", OracleType.Number).Value = objBO._FUNDING_AMOUNT;
                cmd.Parameters.Add("P_SECURITY_NAME", OracleType.NVarChar).Value = objBO._SECURITY_NAME;
                cmd.Parameters.Add("P_DPID", OracleType.NVarChar).Value = objBO._DPID;
                cmd.Parameters.Add("P_CLIENT_ID", OracleType.NVarChar).Value = objBO._CLIENT_ID;
                cmd.Parameters.Add("P_MEMBER_TYPE", OracleType.NVarChar).Value = objBO._MEMBER_TYPE;
                //cmd.Parameters.Add("P_PAYMENT_MODE", OracleType.NVarChar).Value = objBO._PAYMENT_MODE;
                cmd.Parameters.Add("P_BANK_NAME", OracleType.NVarChar).Value = objBO._BANK_NAME;
                cmd.Parameters.Add("P_BANK_BRANCH", OracleType.NVarChar).Value = objBO._BANK_BRANCH;
                cmd.Parameters.Add("P_ACC_NO", OracleType.NVarChar).Value = objBO._ACC_NO;
                cmd.Parameters.Add("P_IFSC", OracleType.NVarChar).Value = objBO._IFSC;
                //cmd.Parameters.Add("P_MICR", OracleType.NVarChar).Value = objBO._MICR;
                //cmd.Parameters.Add("P_CHEQUE_NUMBER", OracleType.NVarChar).Value = objBO._CHEQUE_NUMBER;
                //cmd.Parameters.Add("P_CHEQUE_DATE", OracleType.DateTime).Value = objBO._CHEQUE_DATE;
                cmd.Parameters.Add("P_CREATEDBY", OracleType.NVarChar).Value = objBO._CREATEDBY;
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
            //return status;
        }

        public DataSet GET_EMPLOYEE_SELL_DATA(employee_saleBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SELL_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
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

        public DataSet GET_EMPLOYEE_SELL_DETAILS_DATA(string ID)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SELL_DETAILS_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPCODE", OracleType.NVarChar).Value = ID;
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

        public DataSet GET_EMPLOYEE_SELL_DETAILS_DATA1(string ID)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SELL_DETAILS_DATA1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPCODE", OracleType.NVarChar).Value = ID;
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

        public bool update_status(employee_saleBO objBO)
        {
            bool status = false;
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_STATUS_OF_SELL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id", OracleType.VarChar).Value = objBO.DPID;
                cmd.Parameters.Add("P_remark", OracleType.VarChar).Value = objBO.Remark;
                cmd.Parameters.Add("P_status", OracleType.VarChar).Value = objBO.Status;
                cmd.Parameters.Add("P_modified_by", OracleType.VarChar).Value = objBO.MODIFIEDBY;
                cmd.Parameters.Add("P_sid", OracleType.VarChar).Value = objBO.CLIENT_ID;
                cmd.Parameters.Add("P_APPROVE_STATUS", OracleType.VarChar).Value = objBO.APPROVE_STATUS;
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

        public bool update_status1(employee_saleBO objBO)
        {
            bool status = false;
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_STATUS_OF_SELL1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id", OracleType.VarChar).Value = objBO.DPID;
                cmd.Parameters.Add("P_remark", OracleType.VarChar).Value = objBO.Remark;
                cmd.Parameters.Add("P_status", OracleType.VarChar).Value = objBO.Status;
                cmd.Parameters.Add("P_modified_by", OracleType.VarChar).Value = objBO.MODIFIEDBY;
                cmd.Parameters.Add("P_sid", OracleType.VarChar).Value = objBO.CLIENT_ID;
                cmd.Parameters.Add("P_APPROVE_STATUS", OracleType.NVarChar).Value = objBO.APPROVE_STATUS;
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

        public bool update_status2(employee_saleBO objBO)
        {
            bool status = false;
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_STATUS_OF_SELL2";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id", OracleType.VarChar).Value = objBO.DPID;
                cmd.Parameters.Add("P_remark", OracleType.VarChar).Value = objBO.Remark;
                cmd.Parameters.Add("P_status", OracleType.VarChar).Value = objBO.Status;
                cmd.Parameters.Add("P_modified_by", OracleType.VarChar).Value = objBO.MODIFIEDBY;
                cmd.Parameters.Add("P_sid", OracleType.VarChar).Value = objBO.CLIENT_ID;
                cmd.Parameters.Add("P_DIS_STATUS", OracleType.NVarChar).Value = objBO.DIS_STATUS;
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
        public DataSet GET_SALE_WINDOW()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_SALE_WINDOW";
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

        public DataSet GET_EMPLOYEE_SELL_DATA_Count(employee_saleBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SELL_DATA_Count";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
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

        public DataSet GetSalesActiveLetter()
        {
            DataSet dsresult = new DataSet();
            OracleCommand cmd = new OracleCommand();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_SalesActiveLetter";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public DataSet GET_SESSION(employee_saleBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_SALE_SESSION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE;
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
                //con.Dispose();
            }
        }

        public DataSet InsertEmployeeSaleRec(employee_saleBO objbo)
        {
            DataSet dsresult = new DataSet();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_EMP_SALE_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                con.Open();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(dsresult);
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
        public DataSet GET_EMP_SALE_DOC(employee_saleBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_SALE_DOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE;
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

        public DataSet GET_EMPLOYEE_SELL_DETAILS_DATA_2(string ID)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SALE_DATA_DETAIL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPCODE", OracleType.NVarChar).Value = ID;
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
        public DataSet GET_EMPLOYEE_SELL_DATA_1(employee_saleBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SELL_DATA_1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
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
        public DataSet GET_EMPLOYEE_SELL_DETAILS_DATA_1(string ID)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SELL_DETAILS_DATA_1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPCODE", OracleType.NVarChar).Value = ID;
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
        public DataSet GET_EMP_SALE_DOC_1(employee_saleBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_SALE_DOC_1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE;
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
