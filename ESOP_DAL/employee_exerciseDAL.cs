
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
    public class employee_exerciseDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        public DataSet GET_EMP_EXERCISE_DATA(employee_exerciseBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                //cmd.CommandText = "ESOP_USP_GET_EMP_EXERCISE_DATA1";
                cmd.CommandText = "ESOP_USP_GET_EMP_EXERCISE_DATA3";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPID", OracleType.NVarChar).Value = objBO.ECODE;
                cmd.Parameters.Add("P_START_DATE", OracleType.DateTime).Value = objBO.EXERCISE_WINDOW_START_DATE;
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

        public DataSet GET_EMP_BANK_DETAILS(employee_exerciseBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_EMP_BANK_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPID", OracleType.NVarChar).Value = objBO.ECODE;
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

        public DataSet GET_EMP_DEMAT_DETAILS(employee_exerciseBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_EMP_DEMAT_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPID", OracleType.NVarChar).Value = objBO.ECODE;
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

        public DataSet GetDematDetails(employee_exerciseBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_EMP_DEMAT_DETAILS_ForReport";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPID", OracleType.NVarChar).Value = objBO.ECODE;
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
        public int INSERT_EMPLOYEE_EXERCISE_TRANSACTION(employee_exerciseBO objBO)
        {
            bool status = false;
            int id;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_INSERT_EMPLOYEE_EXERCISE_TRANSACTION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE;
                cmd.Parameters.Add("P_OPTION_EXERCISE", OracleType.Number).Value = objBO.OPTION_EXERCISE;
                cmd.Parameters.Add("P_TRANCH_VESTING", OracleType.NVarChar).Value = objBO.TRANCH_VESTING;
                cmd.Parameters.Add("P_TOTAL_AMOUNT", OracleType.Number).Value = objBO.TOTAL_AMOUNT;
                cmd.Parameters.Add("P_PAYMENT_MODE", OracleType.NVarChar).Value = objBO.PAYMENT_MODE;

                cmd.Parameters.Add("P_CHEQUE_BANK_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_BANK_NAME;               
                cmd.Parameters.Add("P_CHEQUE_BRANCH_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_BRANCH_NAME;
                cmd.Parameters.Add("P_CHEQUE_ACC_NO", OracleType.NVarChar).Value = objBO.CHEQUE_ACC_NO;
                cmd.Parameters.Add("P_CHEQUE_IFSC", OracleType.NVarChar).Value = objBO.CHEQUE_IFSC;
                cmd.Parameters.Add("P_CHEQUE_FILE_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_NAME;
                cmd.Parameters.Add("P_CHEQUE_FILE_PATH", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_PATH;
                cmd.Parameters.Add("P_CHEQUE_NUMBER", OracleType.NVarChar).Value = objBO.CHEQUE_NUMBER;
                cmd.Parameters.Add("P_CHEQUE_DATE", OracleType.DateTime).Value = objBO.CHEQUE_DATE;
                cmd.Parameters.Add("P_CHEQUE_AMOUNT", OracleType.Number).Value = objBO.CHEQUE_AMOUNT;
                cmd.Parameters.Add("P_CHEQUE_FILE_PATH_FRESH", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_PATH_FRESH;

                cmd.Parameters.Add("P_NEFT_BANK_NAME", OracleType.NVarChar).Value = objBO.NEFT_BANK_NAME;
                cmd.Parameters.Add("P_NEFT_BRANCH_NAME", OracleType.NVarChar).Value = objBO.NEFT_BRANCH_NAME;
                cmd.Parameters.Add("P_NEFT_ACC_NO", OracleType.NVarChar).Value = objBO.NEFT_ACC_NO;
                cmd.Parameters.Add("P_NEFT_IFSC", OracleType.NVarChar).Value = objBO.NEFT_IFSC;
                cmd.Parameters.Add("P_NEFT_FILE_NAME", OracleType.NVarChar).Value = objBO.NEFT_FILE_NAME;
                cmd.Parameters.Add("P_NEFT_FILE_PATH", OracleType.NVarChar).Value = objBO.NEFT_FILE_PATH;
                cmd.Parameters.Add("P_NEFT_UTR_NO", OracleType.NVarChar).Value = objBO.NEFT_UTR_NO;

                cmd.Parameters.Add("P_LOAN_LENDER_BANK_NAME", OracleType.NVarChar).Value = objBO.LOAN_LENDER_BANK_NAME;
                cmd.Parameters.Add("P_LOAN_AMOUNT", OracleType.Number).Value = objBO.LOAN_AMOUNT;
                cmd.Parameters.Add("P_LOAN_MARGIN_AMOUNT", OracleType.Number).Value = objBO.LOAN_MARGIN_AMOUNT;
                cmd.Parameters.Add("P_LOAN_MARGIN_PAYMENT_MODE", OracleType.NVarChar).Value = objBO.LOAN_MARGIN_PAYMENT_MODE;

                cmd.Parameters.Add("P_SECURITY_NAME", OracleType.NVarChar).Value = objBO.SECURITY_NAME;
                cmd.Parameters.Add("P_DPID", OracleType.NVarChar).Value = objBO.DPID;
                cmd.Parameters.Add("P_CLIENT_ID", OracleType.NVarChar).Value = objBO.CLIENT_ID;
                cmd.Parameters.Add("P_MEMBER_TYPE", OracleType.NVarChar).Value = objBO.MEMBER_TYPE;
                cmd.Parameters.Add("P_DEMAT_FILE_PATH", OracleType.NVarChar).Value = objBO.DEMAT_FILE_PATH;

                cmd.Parameters.Add("P_CREATEDBY", OracleType.NVarChar).Value = objBO.CREATEDBY;

                cmd.Parameters.Add("P_ID", OracleType.Number);
                cmd.Parameters["P_ID"].Direction = ParameterDirection.Output;
                int result = cmd.ExecuteNonQuery();
                id =Convert.ToInt32( cmd.Parameters["P_ID"].Value);
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

        public void UPDATE_EMPLOYEE_EXERCISE(employee_exerciseBO objBO)
        {
           
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_UPDATE_EMPLOYEE_EXERCISE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE; 
                cmd.Parameters.Add("P_VESTING_DETAIL_ID", OracleType.Number).Value = objBO.VESTING_DETAIL_ID;
                cmd.Parameters.Add("P_OPTION_EXERCISE", OracleType.Number).Value = objBO.OPTION_EXERCISE;

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

        public void INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS(employee_exerciseBO objBO)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EXERCISE_TRAN_ID", OracleType.Number).Value = objBO._EXERCISE_TRAN_ID;
                cmd.Parameters.Add("P_GRANT_ID", OracleType.Number).Value = objBO._GRANT_ID;
                cmd.Parameters.Add("P_VESTING_DETAIL_ID", OracleType.Number).Value = objBO._VESTING_DETAIL_ID;
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO._ECODE;
                cmd.Parameters.Add("P_ENAME", OracleType.NVarChar).Value = objBO._ENAME;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.NVarChar).Value = objBO._GRANT_NAME;
                cmd.Parameters.Add("P_VESTING_DETAIL_CODE", OracleType.NVarChar).Value = objBO._VESTING_DETAIL_CODE;
                cmd.Parameters.Add("P_VESTING_DATE", OracleType.DateTime).Value = objBO._VESTING_DATE;
                cmd.Parameters.Add("P_NO_OF_VESTING", OracleType.Number).Value = objBO._NO_OF_VESTING;
                cmd.Parameters.Add("P_GRANT_PRICE", OracleType.Number).Value = objBO._GRANT_PRICE;
                cmd.Parameters.Add("P_GRANT_FMV_PRICE", OracleType.Number).Value = objBO._GRANT_FMV_PRICE;
                cmd.Parameters.Add("P_NO_OF_EXERCISE", OracleType.Number).Value = objBO._NO_OF_EXERCISE;
                cmd.Parameters.Add("P_TAXABLE_INCOME", OracleType.Number).Value = objBO._TAXABLE_INCOME;
                cmd.Parameters.Add("P_EXERCISE_CONSIDERATION", OracleType.Number).Value = objBO._EXERCISE_CONSIDERATION;
                cmd.Parameters.Add("P_FMV_GRANT_OPTION_EXERCISE", OracleType.Number).Value = objBO._FMV_GRANT_OPTION_EXERCISE;
                cmd.Parameters.Add("P_REVISED_TAXABLE_INCOME", OracleType.Number).Value = objBO._REVISED_TAXABLE_INCOME;
                cmd.Parameters.Add("P_TAX_PER_OPTION", OracleType.Number).Value = objBO._TAX_PER_OPTION;
                cmd.Parameters.Add("P_PERQ_TAX_AMOUNT", OracleType.Number).Value = objBO._PERQ_TAX_AMOUNT;
                cmd.Parameters.Add("P_TOTAL_AMOUNT", OracleType.Number).Value = objBO._TOTAL_AMOUNT;
                cmd.Parameters.Add("P_AMOUNT_DEPOSITED", OracleType.Number).Value = objBO._AMOUNT_DEPOSITED;
                cmd.Parameters.Add("P_FUNDING_AMOUNT", OracleType.Number).Value = objBO._FUNDING_AMOUNT;                
                cmd.Parameters.Add("P_SECURITY_NAME", OracleType.NVarChar).Value = objBO._SECURITY_NAME;
                cmd.Parameters.Add("P_DPID", OracleType.NVarChar).Value = objBO._DPID;
                cmd.Parameters.Add("P_CLIENT_ID", OracleType.NVarChar).Value = objBO._CLIENT_ID;
                cmd.Parameters.Add("P_MEMBER_TYPE", OracleType.NVarChar).Value = objBO._MEMBER_TYPE;
                cmd.Parameters.Add("P_PAYMENT_MODE", OracleType.NVarChar).Value = objBO._PAYMENT_MODE;
                cmd.Parameters.Add("P_BANK_NAME", OracleType.NVarChar).Value = objBO._BANK_NAME;
                cmd.Parameters.Add("P_BANK_BRANCH", OracleType.NVarChar).Value = objBO._BANK_BRANCH;
                cmd.Parameters.Add("P_ACC_NO", OracleType.NVarChar).Value = objBO._ACC_NO;
                cmd.Parameters.Add("P_IFSC", OracleType.NVarChar).Value = objBO._IFSC;
                cmd.Parameters.Add("P_CHEQUE_NUMBER", OracleType.NVarChar).Value = objBO._CHEQUE_NUMBER;
                cmd.Parameters.Add("P_CHEQUE_DATE", OracleType.DateTime).Value = objBO._CHEQUE_DATE;
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

        //Added by Rahul_Natu on 26-05-2022

        public int UPDATE_EMPLOYEE_EXERCISE_TRANSACTION(employee_exerciseBO objBO)
        {
            bool status = false;
            int id;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_UPDATE_EMPLOYEE_EXERCISE_TRANSACTION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE;
                cmd.Parameters.Add("P_PAYMENT_MODE", OracleType.NVarChar).Value = objBO.PAYMENT_MODE;
                cmd.Parameters.Add("P_MODIFIEDBY", OracleType.NVarChar).Value = objBO.CREATEDBY; 

                cmd.Parameters.Add("P_CHEQUE_BANK_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_BANK_NAME;
                cmd.Parameters.Add("P_CHEQUE_BRANCH_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_BRANCH_NAME;
                cmd.Parameters.Add("P_CHEQUE_ACC_NO", OracleType.NVarChar).Value = objBO.CHEQUE_ACC_NO;
                cmd.Parameters.Add("P_CHEQUE_IFSC", OracleType.NVarChar).Value = objBO.CHEQUE_IFSC;
                cmd.Parameters.Add("P_CHEQUE_FILE_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_NAME;
                cmd.Parameters.Add("P_CHEQUE_FILE_PATH", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_PATH;
                cmd.Parameters.Add("P_CHEQUE_NUMBER", OracleType.NVarChar).Value = objBO.CHEQUE_NUMBER;
                cmd.Parameters.Add("P_CHEQUE_DATE", OracleType.DateTime).Value = objBO.CHEQUE_DATE;
                cmd.Parameters.Add("P_CHEQUE_AMOUNT", OracleType.Number).Value = objBO.CHEQUE_AMOUNT;
                cmd.Parameters.Add("P_CHEQUE_FILE_PATH_FRESH", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_PATH_FRESH;

                cmd.Parameters.Add("P_NEFT_BANK_NAME", OracleType.NVarChar).Value = objBO.NEFT_BANK_NAME;
                cmd.Parameters.Add("P_NEFT_BRANCH_NAME", OracleType.NVarChar).Value = objBO.NEFT_BRANCH_NAME;
                cmd.Parameters.Add("P_NEFT_ACC_NO", OracleType.NVarChar).Value = objBO.NEFT_ACC_NO;
                cmd.Parameters.Add("P_NEFT_IFSC", OracleType.NVarChar).Value = objBO.NEFT_IFSC;
                cmd.Parameters.Add("P_NEFT_FILE_NAME", OracleType.NVarChar).Value = objBO.NEFT_FILE_NAME;
                cmd.Parameters.Add("P_NEFT_FILE_PATH", OracleType.NVarChar).Value = objBO.NEFT_FILE_PATH;
                cmd.Parameters.Add("P_NEFT_UTR_NO", OracleType.NVarChar).Value = objBO.NEFT_UTR_NO;

                cmd.Parameters.Add("P_LOAN_LENDER_BANK_NAME", OracleType.NVarChar).Value = objBO.LOAN_LENDER_BANK_NAME;
                cmd.Parameters.Add("P_LOAN_AMOUNT", OracleType.Number).Value = objBO.LOAN_AMOUNT;
                cmd.Parameters.Add("P_LOAN_MARGIN_AMOUNT", OracleType.Number).Value = objBO.LOAN_MARGIN_AMOUNT;
                cmd.Parameters.Add("P_LOAN_MARGIN_PAYMENT_MODE", OracleType.NVarChar).Value = objBO.LOAN_MARGIN_PAYMENT_MODE;

                cmd.Parameters.Add("P_SECURITY_NAME", OracleType.NVarChar).Value = objBO.SECURITY_NAME;
                cmd.Parameters.Add("P_DPID", OracleType.NVarChar).Value = objBO.DPID;
                cmd.Parameters.Add("P_CLIENT_ID", OracleType.NVarChar).Value = objBO.CLIENT_ID;
                cmd.Parameters.Add("P_MEMBER_TYPE", OracleType.NVarChar).Value = objBO.MEMBER_TYPE;
                cmd.Parameters.Add("P_DEMAT_FILE_PATH", OracleType.NVarChar).Value = objBO.DEMAT_FILE_PATH;


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
        public void INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_NEW(employee_exerciseBO objBO)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_NEW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EXERCISE_TRAN_ID", OracleType.Number).Value = objBO._EXERCISE_TRAN_ID;
                cmd.Parameters.Add("P_GRANT_ID", OracleType.Number).Value = objBO._GRANT_ID;
                cmd.Parameters.Add("P_VESTING_DETAIL_ID", OracleType.Number).Value = objBO._VESTING_DETAIL_ID;
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO._ECODE;
                cmd.Parameters.Add("P_ENAME", OracleType.NVarChar).Value = objBO._ENAME;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.NVarChar).Value = objBO._GRANT_NAME;
                cmd.Parameters.Add("P_VESTING_DETAIL_CODE", OracleType.NVarChar).Value = objBO._VESTING_DETAIL_CODE;
                cmd.Parameters.Add("P_VESTING_DATE", OracleType.DateTime).Value = objBO._VESTING_DATE;
                cmd.Parameters.Add("P_NO_OF_VESTING", OracleType.Number).Value = objBO._NO_OF_VESTING;
                cmd.Parameters.Add("P_GRANT_PRICE", OracleType.Number).Value = objBO._GRANT_PRICE;
                cmd.Parameters.Add("P_GRANT_FMV_PRICE", OracleType.Number).Value = objBO._GRANT_FMV_PRICE;
                cmd.Parameters.Add("P_NO_OF_EXERCISE", OracleType.Number).Value = objBO._NO_OF_EXERCISE;
                cmd.Parameters.Add("P_TAXABLE_INCOME", OracleType.Number).Value = objBO._TAXABLE_INCOME;
                cmd.Parameters.Add("P_EXERCISE_CONSIDERATION", OracleType.Number).Value = objBO._EXERCISE_CONSIDERATION;
                cmd.Parameters.Add("P_FMV_GRANT_OPTION_EXERCISE", OracleType.Number).Value = objBO._FMV_GRANT_OPTION_EXERCISE;
                cmd.Parameters.Add("P_REVISED_TAXABLE_INCOME", OracleType.Number).Value = objBO._REVISED_TAXABLE_INCOME;
                cmd.Parameters.Add("P_TAX_PER_OPTION", OracleType.Number).Value = objBO._TAX_PER_OPTION;
                cmd.Parameters.Add("P_PERQ_TAX_AMOUNT", OracleType.Number).Value = objBO._PERQ_TAX_AMOUNT;
                cmd.Parameters.Add("P_TOTAL_AMOUNT", OracleType.Number).Value = objBO._TOTAL_AMOUNT;
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
        public void UPDATE_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS(employee_exerciseBO objBO)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_UPDATE_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EXERCISE_TRAN_ID", OracleType.Number).Value = objBO._EXERCISE_TRAN_ID;
                cmd.Parameters.Add("P_GRANT_ID", OracleType.Number).Value = objBO._GRANT_ID;
                cmd.Parameters.Add("P_VESTING_DETAIL_ID", OracleType.Number).Value = objBO._VESTING_DETAIL_ID;
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO._ECODE;
                cmd.Parameters.Add("P_ENAME", OracleType.NVarChar).Value = objBO._ENAME;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.NVarChar).Value = objBO._GRANT_NAME;
                cmd.Parameters.Add("P_VESTING_DETAIL_CODE", OracleType.NVarChar).Value = objBO._VESTING_DETAIL_CODE;
                cmd.Parameters.Add("P_VESTING_DATE", OracleType.DateTime).Value = objBO._VESTING_DATE;
                cmd.Parameters.Add("P_NO_OF_VESTING", OracleType.Number).Value = objBO._NO_OF_VESTING;
                cmd.Parameters.Add("P_GRANT_PRICE", OracleType.Number).Value = objBO._GRANT_PRICE;
                cmd.Parameters.Add("P_GRANT_FMV_PRICE", OracleType.Number).Value = objBO._GRANT_FMV_PRICE;
                cmd.Parameters.Add("P_NO_OF_EXERCISE", OracleType.Number).Value = objBO._NO_OF_EXERCISE;
                cmd.Parameters.Add("P_TAXABLE_INCOME", OracleType.Number).Value = objBO._TAXABLE_INCOME;
                cmd.Parameters.Add("P_EXERCISE_CONSIDERATION", OracleType.Number).Value = objBO._EXERCISE_CONSIDERATION;
                cmd.Parameters.Add("P_FMV_GRANT_OPTION_EXERCISE", OracleType.Number).Value = objBO._FMV_GRANT_OPTION_EXERCISE;
                cmd.Parameters.Add("P_REVISED_TAXABLE_INCOME", OracleType.Number).Value = objBO._REVISED_TAXABLE_INCOME;
                cmd.Parameters.Add("P_TAX_PER_OPTION", OracleType.Number).Value = objBO._TAX_PER_OPTION;
                cmd.Parameters.Add("P_PERQ_TAX_AMOUNT", OracleType.Number).Value = objBO._PERQ_TAX_AMOUNT;
                cmd.Parameters.Add("P_TOTAL_AMOUNT", OracleType.Number).Value = objBO._TOTAL_AMOUNT;
                cmd.Parameters.Add("P_AMOUNT_DEPOSITED", OracleType.Number).Value = objBO._AMOUNT_DEPOSITED;
                cmd.Parameters.Add("P_FUNDING_AMOUNT", OracleType.Number).Value = objBO._FUNDING_AMOUNT;
                cmd.Parameters.Add("P_SECURITY_NAME", OracleType.NVarChar).Value = objBO._SECURITY_NAME;
                cmd.Parameters.Add("P_DPID", OracleType.NVarChar).Value = objBO._DPID;
                cmd.Parameters.Add("P_CLIENT_ID", OracleType.NVarChar).Value = objBO._CLIENT_ID;
                cmd.Parameters.Add("P_MEMBER_TYPE", OracleType.NVarChar).Value = objBO._MEMBER_TYPE;
                cmd.Parameters.Add("P_PAYMENT_MODE", OracleType.NVarChar).Value = objBO._PAYMENT_MODE;
                cmd.Parameters.Add("P_BANK_NAME", OracleType.NVarChar).Value = objBO._BANK_NAME;
                cmd.Parameters.Add("P_BANK_BRANCH", OracleType.NVarChar).Value = objBO._BANK_BRANCH;
                cmd.Parameters.Add("P_ACC_NO", OracleType.NVarChar).Value = objBO._ACC_NO;
                cmd.Parameters.Add("P_IFSC", OracleType.NVarChar).Value = objBO._IFSC;
                cmd.Parameters.Add("P_CHEQUE_NUMBER", OracleType.NVarChar).Value = objBO._CHEQUE_NUMBER;
                cmd.Parameters.Add("P_CHEQUE_DATE", OracleType.DateTime).Value = objBO._CHEQUE_DATE;
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
        public void INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_SESSION_NEW(employee_exerciseBO objBO)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_SESSION_NEW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EXERCISE_TRAN_ID", OracleType.Number).Value = objBO._EXERCISE_TRAN_ID;
                cmd.Parameters.Add("P_GRANT_ID", OracleType.Number).Value = objBO._GRANT_ID;
                cmd.Parameters.Add("P_VESTING_DETAIL_ID", OracleType.Number).Value = objBO._VESTING_DETAIL_ID;
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO._ECODE;
                cmd.Parameters.Add("P_ENAME", OracleType.NVarChar).Value = objBO._ENAME;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.NVarChar).Value = objBO._GRANT_NAME;
                cmd.Parameters.Add("P_VESTING_DETAIL_CODE", OracleType.NVarChar).Value = objBO._VESTING_DETAIL_CODE;
                cmd.Parameters.Add("P_VESTING_DATE", OracleType.DateTime).Value = objBO._VESTING_DATE;
                cmd.Parameters.Add("P_NO_OF_VESTING", OracleType.Number).Value = objBO._NO_OF_VESTING;
                cmd.Parameters.Add("P_GRANT_PRICE", OracleType.Number).Value = objBO._GRANT_PRICE;
                cmd.Parameters.Add("P_GRANT_FMV_PRICE", OracleType.Number).Value = objBO._GRANT_FMV_PRICE;
                cmd.Parameters.Add("P_NO_OF_EXERCISE", OracleType.Number).Value = objBO._NO_OF_EXERCISE;
                cmd.Parameters.Add("P_TAXABLE_INCOME", OracleType.Number).Value = objBO._TAXABLE_INCOME;
                cmd.Parameters.Add("P_EXERCISE_CONSIDERATION", OracleType.Number).Value = objBO._EXERCISE_CONSIDERATION;
                cmd.Parameters.Add("P_FMV_GRANT_OPTION_EXERCISE", OracleType.Number).Value = objBO._FMV_GRANT_OPTION_EXERCISE;
                cmd.Parameters.Add("P_REVISED_TAXABLE_INCOME", OracleType.Number).Value = objBO._REVISED_TAXABLE_INCOME;
                cmd.Parameters.Add("P_TAX_PER_OPTION", OracleType.Number).Value = objBO._TAX_PER_OPTION;
                cmd.Parameters.Add("P_PERQ_TAX_AMOUNT", OracleType.Number).Value = objBO._PERQ_TAX_AMOUNT;
                cmd.Parameters.Add("P_TOTAL_AMOUNT", OracleType.Number).Value = objBO._TOTAL_AMOUNT;
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
        //END
        public DataSet GET_ECERCISE_WINDOW()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EXERCISE_WINDOW";
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
                //con.Dispose();
            }
        }

        public int INSERT_EMPLOYEE_EXERCISE_TRANSACTION_SESSION(employee_exerciseBO objBO)
        {
            bool status = false;
            int id;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_INSERT_EMPLOYEE_EXERCISE_TRANSACTION_SESSION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE;
                cmd.Parameters.Add("P_OPTION_EXERCISE", OracleType.Number).Value = objBO.OPTION_EXERCISE;
                cmd.Parameters.Add("P_TRANCH_VESTING", OracleType.NVarChar).Value = objBO.TRANCH_VESTING;
                cmd.Parameters.Add("P_TOTAL_AMOUNT", OracleType.Number).Value = objBO.TOTAL_AMOUNT;
                cmd.Parameters.Add("P_PAYMENT_MODE", OracleType.NVarChar).Value = objBO.PAYMENT_MODE;

                cmd.Parameters.Add("P_CHEQUE_BANK_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_BANK_NAME;
                cmd.Parameters.Add("P_CHEQUE_BRANCH_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_BRANCH_NAME;
                cmd.Parameters.Add("P_CHEQUE_ACC_NO", OracleType.NVarChar).Value = objBO.CHEQUE_ACC_NO;
                cmd.Parameters.Add("P_CHEQUE_IFSC", OracleType.NVarChar).Value = objBO.CHEQUE_IFSC;
                cmd.Parameters.Add("P_CHEQUE_FILE_NAME", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_NAME;
                cmd.Parameters.Add("P_CHEQUE_FILE_PATH", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_PATH;
                cmd.Parameters.Add("P_CHEQUE_NUMBER", OracleType.NVarChar).Value = objBO.CHEQUE_NUMBER;
                cmd.Parameters.Add("P_CHEQUE_DATE", OracleType.DateTime).Value = objBO.CHEQUE_DATE;
                cmd.Parameters.Add("P_CHEQUE_AMOUNT", OracleType.Number).Value = objBO.CHEQUE_AMOUNT;
                cmd.Parameters.Add("P_CHEQUE_FILE_PATH_FRESH", OracleType.NVarChar).Value = objBO.CHEQUE_FILE_PATH_FRESH;

                cmd.Parameters.Add("P_NEFT_BANK_NAME", OracleType.NVarChar).Value = objBO.NEFT_BANK_NAME;
                cmd.Parameters.Add("P_NEFT_BRANCH_NAME", OracleType.NVarChar).Value = objBO.NEFT_BRANCH_NAME;
                cmd.Parameters.Add("P_NEFT_ACC_NO", OracleType.NVarChar).Value = objBO.NEFT_ACC_NO;
                cmd.Parameters.Add("P_NEFT_IFSC", OracleType.NVarChar).Value = objBO.NEFT_IFSC;
                cmd.Parameters.Add("P_NEFT_FILE_NAME", OracleType.NVarChar).Value = objBO.NEFT_FILE_NAME;
                cmd.Parameters.Add("P_NEFT_FILE_PATH", OracleType.NVarChar).Value = objBO.NEFT_FILE_PATH;
                cmd.Parameters.Add("P_NEFT_UTR_NO", OracleType.NVarChar).Value = objBO.NEFT_UTR_NO;

                cmd.Parameters.Add("P_LOAN_LENDER_BANK_NAME", OracleType.NVarChar).Value = objBO.LOAN_LENDER_BANK_NAME;
                cmd.Parameters.Add("P_LOAN_AMOUNT", OracleType.Number).Value = objBO.LOAN_AMOUNT;
                cmd.Parameters.Add("P_LOAN_MARGIN_AMOUNT", OracleType.Number).Value = objBO.LOAN_MARGIN_AMOUNT;
                cmd.Parameters.Add("P_LOAN_MARGIN_PAYMENT_MODE", OracleType.NVarChar).Value = objBO.LOAN_MARGIN_PAYMENT_MODE;

                cmd.Parameters.Add("P_SECURITY_NAME", OracleType.NVarChar).Value = objBO.SECURITY_NAME;
                cmd.Parameters.Add("P_DPID", OracleType.NVarChar).Value = objBO.DPID;
                cmd.Parameters.Add("P_CLIENT_ID", OracleType.NVarChar).Value = objBO.CLIENT_ID;
                cmd.Parameters.Add("P_MEMBER_TYPE", OracleType.NVarChar).Value = objBO.MEMBER_TYPE;
                cmd.Parameters.Add("P_DEMAT_FILE_PATH", OracleType.NVarChar).Value = objBO.DEMAT_FILE_PATH;

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
        public void INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_SESSION(employee_exerciseBO objBO)
        {
            bool status = false;
            try
            {
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_SESSION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EXERCISE_TRAN_ID", OracleType.Number).Value = objBO._EXERCISE_TRAN_ID;
                cmd.Parameters.Add("P_GRANT_ID", OracleType.Number).Value = objBO._GRANT_ID;
                cmd.Parameters.Add("P_VESTING_DETAIL_ID", OracleType.Number).Value = objBO._VESTING_DETAIL_ID;
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO._ECODE;
                cmd.Parameters.Add("P_ENAME", OracleType.NVarChar).Value = objBO._ENAME;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.NVarChar).Value = objBO._GRANT_NAME;
                cmd.Parameters.Add("P_VESTING_DETAIL_CODE", OracleType.NVarChar).Value = objBO._VESTING_DETAIL_CODE;
                cmd.Parameters.Add("P_VESTING_DATE", OracleType.DateTime).Value = objBO._VESTING_DATE;
                cmd.Parameters.Add("P_NO_OF_VESTING", OracleType.Number).Value = objBO._NO_OF_VESTING;
                cmd.Parameters.Add("P_GRANT_PRICE", OracleType.Number).Value = objBO._GRANT_PRICE;
                cmd.Parameters.Add("P_GRANT_FMV_PRICE", OracleType.Number).Value = objBO._GRANT_FMV_PRICE;
                cmd.Parameters.Add("P_NO_OF_EXERCISE", OracleType.Number).Value = objBO._NO_OF_EXERCISE;
                cmd.Parameters.Add("P_TAXABLE_INCOME", OracleType.Number).Value = objBO._TAXABLE_INCOME;
                cmd.Parameters.Add("P_EXERCISE_CONSIDERATION", OracleType.Number).Value = objBO._EXERCISE_CONSIDERATION;
                cmd.Parameters.Add("P_FMV_GRANT_OPTION_EXERCISE", OracleType.Number).Value = objBO._FMV_GRANT_OPTION_EXERCISE;
                cmd.Parameters.Add("P_REVISED_TAXABLE_INCOME", OracleType.Number).Value = objBO._REVISED_TAXABLE_INCOME;
                cmd.Parameters.Add("P_TAX_PER_OPTION", OracleType.Number).Value = objBO._TAX_PER_OPTION;
                cmd.Parameters.Add("P_PERQ_TAX_AMOUNT", OracleType.Number).Value = objBO._PERQ_TAX_AMOUNT;
                cmd.Parameters.Add("P_TOTAL_AMOUNT", OracleType.Number).Value = objBO._TOTAL_AMOUNT;
                cmd.Parameters.Add("P_AMOUNT_DEPOSITED", OracleType.Number).Value = objBO._AMOUNT_DEPOSITED;
                cmd.Parameters.Add("P_FUNDING_AMOUNT", OracleType.Number).Value = objBO._FUNDING_AMOUNT;
                cmd.Parameters.Add("P_SECURITY_NAME", OracleType.NVarChar).Value = objBO._SECURITY_NAME;
                cmd.Parameters.Add("P_DPID", OracleType.NVarChar).Value = objBO._DPID;
                cmd.Parameters.Add("P_CLIENT_ID", OracleType.NVarChar).Value = objBO._CLIENT_ID;
                cmd.Parameters.Add("P_MEMBER_TYPE", OracleType.NVarChar).Value = objBO._MEMBER_TYPE;
                cmd.Parameters.Add("P_PAYMENT_MODE", OracleType.NVarChar).Value = objBO._PAYMENT_MODE;
                cmd.Parameters.Add("P_BANK_NAME", OracleType.NVarChar).Value = objBO._BANK_NAME;
                cmd.Parameters.Add("P_BANK_BRANCH", OracleType.NVarChar).Value = objBO._BANK_BRANCH;
                cmd.Parameters.Add("P_ACC_NO", OracleType.NVarChar).Value = objBO._ACC_NO;
                cmd.Parameters.Add("P_IFSC", OracleType.NVarChar).Value = objBO._IFSC;
                cmd.Parameters.Add("P_CHEQUE_NUMBER", OracleType.NVarChar).Value = objBO._CHEQUE_NUMBER;
                cmd.Parameters.Add("P_CHEQUE_DATE", OracleType.DateTime).Value = objBO._CHEQUE_DATE;
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
        public DataSet GET_SESSION(employee_exerciseBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_SESSION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECODE", OracleType.NVarChar).Value = objBO.ECODE;
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

        public DataSet InsertEmployeeExerRec(employee_exerciseBO objbo)
        {
            DataSet dsresult = new DataSet();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_EMP_Exercise_DATA";
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
        //public DataSet GET_EMPLOYEE_EXERCISE_DATA(employee_exerciseBO objBO)
        //{
        //    try
        //    {
        //        DataSet dsresult = new DataSet();
        //        OracleCommand cmd = new OracleCommand();
        //        con.Open();
        //        cmd.Connection = con;
        //        //cmd.CommandText = "ESOP_GET_EMPLOYEE_EXERCISE_DATA";
        //        cmd.CommandText = "ESOP_GET_EMPLOYEE_ADMIN_DATA_5";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.Add("p_ID", OracleType.VarChar).Value = objBO.id;
        //        cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
        //        //cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
        //        //cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public DataSet GET_EMPLOYEE_EXERCISE_DATA(employee_exerciseBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                //cmd.CommandText = "ESOP_GET_EMPLOYEE_EXERCISE_DATA";
                cmd.CommandText = "ESOP_GET_EMPLOYEE_ADMIN_DATA_5";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                //cmd.Parameters.Add("p_ID", OracleType.VarChar).Value = objBO.id;
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
        public bool update_status(employee_exerciseBO objBO)
        {
            bool status = false;
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_STATUS_BY_EMPLOYEE_ADMIN";
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

        public bool update_status_1(employee_exerciseBO objBO)
        {
            bool status = false;
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_EXERCISE_STATUS_BY_ADMIN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id", OracleType.Int32).Value = objBO.id;
                cmd.Parameters.Add("p_etid", OracleType.Number).Value = objBO.etid;
                cmd.Parameters.Add("P_remark", OracleType.VarChar).Value = objBO.remark;
                cmd.Parameters.Add("P_dstatus", OracleType.VarChar).Value = objBO.detail_status;
                //Added by Bhushan on 02-02-2023 for Tax Master CR
                cmd.Parameters.Add("p_perqTax", OracleType.Number).Value = objBO._PERQ_TAX_AMOUNT;
                cmd.Parameters.Add("p_totalAmt", OracleType.Number).Value = objBO.TOTAL_AMOUNT;
                //End
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
        public DataSet GET_Employee_Admin_Main_Grid()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_ADMIN_MAIN_GRID";
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
        public DataSet ESOP_GET_EMPLOYEE_ADMIN_DATA(string id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_DATA";
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
        public DataSet GET_Employee_Admin_Main_Grid_1()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_ADMIN_MAIN_GRID_1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
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
            }

        }
        public DataSet GET_Employee_Admin_Main_Grid_NEW()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_ADMIN_MAIN_GRID_NEW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
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
            }

        }
        public DataSet EMPLOYEE_DETAIL_APPROVAL_DATA()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_DETAIL_APPROVAL_DATA";
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
        public DataSet ESOP_GET_EMPLOYEE_ADMIN_DATA_1(string id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_DATA_1";
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

        public DataSet ESOP_GET_EMPLOYEE_ADMIN_DATA_2(string id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_DATA_3";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ID", OracleType.VarChar).Value = id;
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
        public DataSet ESOP_GET_EMPLOYEE_ADMIN_DATA_4(employee_exerciseBO objBO)
        {
            try
            {
                //OracleCommand cmd = new OracleCommand();

                //DataSet dsresult = new DataSet();
                //con.Open();
                //cmd.Connection = con;
                //cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_DATA_4";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Clear();
                //cmd.Parameters.Add("p_ID", OracleType.VarChar).Value = id;
                //cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;              
                //OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                //objAdap.Fill(dsresult);
                //return dsresult;

                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SECRETARIAL_DATA_4";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_Action", OracleType.VarChar).Value = objBO.remark;
                cmd.Parameters.Add("p_ID", OracleType.VarChar).Value = objBO.ECODE;
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
        public DataSet GET_Employee_Admin_Main_Grid_2()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_SALE_DATA_MAIN_GRID";
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

        public DataSet GET_EMPLOYEE_SECRETARIAL_DownloadLink(double id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
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
        public DataSet GET_EMPLOYEE_EXERCISE_DATA_NEW(employee_exerciseBO objBO)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                //cmd.CommandText = "ESOP_GET_EMPLOYEE_EXERCISE_DATA";
                cmd.CommandText = "ESOP_GET_EMPLOYEE_ADMIN_DATA_6";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                //cmd.Parameters.Add("p_ID", OracleType.VarChar).Value = objBO.id;
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

        public DataSet ESOP_GET_EMPLOYEE_ADMIN_DATA_NEW(string id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMPLOYEE_ADMIN_DATA_NEW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ID", OracleType.VarChar).Value = id;
                //cmd.Parameters.Add("p_Grant", OracleType.VarChar).Value = grant;
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
        public DataSet ESOP_GET_Employee_Exercise_Data_NEW(string id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_Employee_Exercise_Data_NEW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ID", OracleType.VarChar).Value = id;
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

        public DataSet GET_CHECKER_COUNT()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_CHECKER_GRANT_LAPSE_COUNT";
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
            }

        }
    }
}
