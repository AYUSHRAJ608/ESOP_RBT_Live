using ESOP_BO;
using System;
using System.Data;
//using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data.OracleClient;

namespace ESOP_DAL
{
    public class GrandCreationDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);

        OracleCommand cmd = new OracleCommand();

        public DataSet Insert_GrandCreation(GrandCreationBO FMVBo)
        {
            //bool status = false;
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_GRANDCREATION_CANCEL";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Clear();
                // cmd.Parameters.Add("p_flag", OracleType.VarChar).Value = "SubmitRequest";

                cmd.Parameters.Add("P_GRANT_NAME", OracleType.VarChar).Value = FMVBo.GRANT_NAME;
                cmd.Parameters.Add("P_DATE_OF_GRANT", OracleType.DateTime).Value = FMVBo.DATE_OF_GRANT;
                cmd.Parameters.Add("P_EMP_ID", OracleType.VarChar).Value = FMVBo.EMP_ID;
                cmd.Parameters.Add("P_FMV_ID", OracleType.Int32).Value = FMVBo.FMV_ID;
                cmd.Parameters.Add("P_VESTING_ID", OracleType.Int32).Value = FMVBo.VESTING_ID;
                cmd.Parameters.Add("P_NO_OF_OPTION", OracleType.Int32).Value = FMVBo.NO_OF_OPTION;
                cmd.Parameters.Add("P_LAPSE_MONTH", OracleType.VarChar).Value = FMVBo.LAPSE_MONTH;
                cmd.Parameters.Add("P_CREATED_BY", OracleType.VarChar).Value = FMVBo.CREATED_BY;
                cmd.Parameters.Add("P_UPDATED_BY", OracleType.VarChar).Value = FMVBo.UPDATED_BY;
                cmd.Parameters.Add("P_CREATION_DATE", OracleType.VarChar).Value = FMVBo.CREATED_DATE;
                cmd.Parameters.Add("P_UPDATION_DATE", OracleType.VarChar).Value = FMVBo.UPDATED_DATE;
                cmd.Parameters.Add("P_ISVISIBLE", OracleType.VarChar).Value = FMVBo.IS_VISIBLE;
                cmd.Parameters.Add("P_REMARK1", OracleType.VarChar).Value = FMVBo.REMARK1;
                cmd.Parameters.Add("P_REMARK2", OracleType.VarChar).Value = FMVBo.REMARK2;
                cmd.Parameters.Add("P_TAX_REGIME", OracleType.VarChar).Value = FMVBo.TAX_REGIME;                        //Added by Krutika on 09-01-23
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;

                con.Open();
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
            //return status;
            //return ds;
        }
        public DataSet GetMaxValue()
        {
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GENRATE_GRANTNAME";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
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
        public DataSet GetDropDown()
        {
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_VESTING_FMV";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
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
        public DataSet GetUserDropDown(GrandCreationBO USerBo)
        {
            {
                try
                {
                    DataSet dsresult = new DataSet();
                    cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "ESOP_GET_USERS";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("P_EMP_ID", OracleType.VarChar).Value = USerBo.EMP_ID;
                    cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("cur4", OracleType.Cursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("cur5", OracleType.Cursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("cur6", OracleType.Cursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("cur7", OracleType.Cursor).Direction = ParameterDirection.Output;
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
        public DataSet Insert_Copy_EMP(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            //bool status = false;
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SP_COPY_EMP_CANCEL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_CREATED_BY", OracleType.VarChar).Value = objbo.CREATED_BY;
                cmd.Parameters.Add("P_Grand_Name", OracleType.VarChar).Value = objbo.GRANT_NAME;
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
            //return status;
            //return ds;

        }
        public DataTable getFailedData_Dal()
        {
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GETFAILRECORDS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();


                //cmd.Parameters.Add("p_DEM_EU_ID", OracleType.VarChar).Value = ObjEntity.EmpUpload_ID;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;

                con.Open();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataSet UserFilter(EmployeeBO ObjBo)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_USER_FILTER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECode", OracleType.VarChar).Value = ObjBo.ECode.ToLower();
                cmd.Parameters.Add("P_Emp_Name", OracleType.VarChar).Value = ObjBo.Emp_Name.ToLower();
                cmd.Parameters.Add("P_Dept", OracleType.VarChar).Value = ObjBo.Dept;
                cmd.Parameters.Add("P_Band", OracleType.VarChar).Value = ObjBo.Band;
                cmd.Parameters.Add("P_Location", OracleType.VarChar).Value = ObjBo.Location;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;

                con.Open();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataSet GetExerciseDates()
        {
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EXERCISE_RECORDS";
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public DataSet Vesting_Taxable_Income(GrandCreationBO objbo)
        {

            DataSet dsresult = new DataSet();
            //bool status = false;
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_VESTING_TAX_INCOME";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Start_Date", OracleType.DateTime).Value = objbo.Start_Date;
                cmd.Parameters.Add("P_End_Date", OracleType.DateTime).Value = objbo.End_Date;
                cmd.Parameters.Add("P_FMV_ID", OracleType.Int32).Value = objbo.FMV_ID;
                cmd.Parameters.Add("P_CreatedBy", OracleType.VarChar).Value = objbo.EMP_ID;
                //cmd.Parameters.Add("P_FMV_Price", OracleType.Int32).Value = objbo.FMV_Price;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
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
            //return status;
            //return ds;

        }
        public DataSet Vesting_Taxable_Income_Append_Overwrite(GrandCreationBO objbo)
        {

            DataSet dsresult = new DataSet();
            //bool status = false;
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_VESTING_TAX_INCOME_Append_Overwrite";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Start_Date", OracleType.DateTime).Value = objbo.Start_Date;
                cmd.Parameters.Add("P_End_Date", OracleType.DateTime).Value = objbo.End_Date;
                cmd.Parameters.Add("P_FMV_ID", OracleType.Int32).Value = objbo.FMV_ID;
                cmd.Parameters.Add("P_CreatedBy", OracleType.VarChar).Value = objbo.EMP_ID;
                cmd.Parameters.Add("P_Status", OracleType.VarChar).Value = objbo.Key;
                cmd.Parameters.Add("P_ExercisedID", OracleType.Int32).Value = objbo.ExercisedID;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
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
            //return status;
            //return ds;

        }
        public DataSet Insert_sale(GrandCreationBO objbo)
        {

            DataSet dsresult = new DataSet();
            //bool status = false;
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_UPDATE_SALE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Start_Date", OracleType.DateTime).Value = objbo.Start_Date;
                cmd.Parameters.Add("P_End_Date", OracleType.DateTime).Value = objbo.End_Date;
                cmd.Parameters.Add("P_FMV_ID", OracleType.Int32).Value = objbo.FMV_ID;
                cmd.Parameters.Add("P_CreatedBy", OracleType.VarChar).Value = objbo.EMP_ID;
                cmd.Parameters.Add("P_key", OracleType.VarChar).Value = objbo.Key;
                cmd.Parameters.Add("P_SaleID", OracleType.Int32).Value = objbo.SaleID;
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
            //return status;
            //return ds;

        }
        public DataTable getFailedData_Dal_Exercise(GrandCreationBO objbo)
        {
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GETFAILRECORDS_EXERCISE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("P_Start_Date", OracleType.DateTime).Value = objbo.Start_Date;
                cmd.Parameters.Add("P_End_Date", OracleType.DateTime).Value = objbo.End_Date;
                cmd.Parameters.Add("P_FMV_ID", OracleType.Int32).Value = objbo.FMV_ID;
                //cmd.Parameters.Add("p_DEM_EU_ID", OracleType.VarChar).Value = ObjEntity.EmpUpload_ID;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;

                con.Open();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataSet GetActiveLetter()
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_ActiveLetter";
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public DataSet get_exercise_datewise_fmv(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_exciseDATEWISE_FMV";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Start_Date", OracleType.DateTime).Value = objbo.Start_Date.ToShortDateString();
                cmd.Parameters.Add("P_End_Date", OracleType.DateTime).Value = objbo.End_Date.ToShortDateString();
                cmd.Parameters.Add("P_exercise_id", OracleType.Number).Value = objbo.ExercisedID;
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public DataSet get_fmv_ondate_ofgrant(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_get_fmv_ondate_ofgrant";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_grant_date", OracleType.DateTime).Value = objbo.DATE_OF_GRANT.ToShortDateString();

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
        public DataSet get_sell_datewise_fmv(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_sellDATEWISE_FMV";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Start_Date", OracleType.DateTime).Value = objbo.Start_Date.ToShortDateString();
                cmd.Parameters.Add("P_End_Date", OracleType.DateTime).Value = objbo.End_Date.ToShortDateString();
                cmd.Parameters.Add("P_Sell_id", OracleType.Number).Value = objbo.SaleID;
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public DataSet GetSaleDates()
        {
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_SALE_RECORDS";
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public DataSet ESOP_GET_EXERCISE_SALE_VALIDATION(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EXERCISE_SALE_VALIDATION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Start_Date", OracleType.DateTime).Value = objbo.Start_Date.ToShortDateString();
                cmd.Parameters.Add("P_End_Date", OracleType.DateTime).Value = objbo.End_Date.ToShortDateString();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("P_key", OracleType.VarChar).Value = objbo.Key;
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
        public DataSet ESOP_GET_EXCISE_sell_GRIDDATA()
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EXCISE_sell_GRIDDATA";
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public DataSet GetGrantName(GrandCreationBO objbo)
        {
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_TRANCHNAME_NEW"; //ESOP_GET_TRANCHNAME
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public DataSet GetGrantWiseData(GrandCreationBO objbo)
        {
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_TRANCHWISE_DATA_NEW"; //ESOP_GET_TRANCHWISE_DATA
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("P_Grant_Name", OracleType.VarChar).Value = objbo.GRANT_NAME;
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
        public DataSet Insert_Copy_EMP_Override(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            //bool status = false;
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SP_COPY_EMP_Override_CANCEL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_CREATED_BY", OracleType.VarChar).Value = objbo.CREATED_BY;
                cmd.Parameters.Add("P_Grand_Name", OracleType.VarChar).Value = objbo.GRANT_NAME;
                cmd.Parameters.Add("P_Key", OracleType.VarChar).Value = objbo.Key;
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
            //return status;
            //return ds;
        }
        public DataSet Insert_GrandCreation_Append_overeide(GrandCreationBO FMVBo)
        {
            //bool status = false;
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_GRANDCREATION_APPEND_OVERRIDE_CANCEL";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Clear();
                // cmd.Parameters.Add("p_flag", OracleType.VarChar).Value = "SubmitRequest";

                cmd.Parameters.Add("P_GRANT_NAME", OracleType.VarChar).Value = FMVBo.GRANT_NAME;
                cmd.Parameters.Add("P_DATE_OF_GRANT", OracleType.DateTime).Value = FMVBo.DATE_OF_GRANT;
                cmd.Parameters.Add("P_EMP_ID", OracleType.VarChar).Value = FMVBo.EMP_ID;
                cmd.Parameters.Add("P_FMV_ID", OracleType.Int32).Value = FMVBo.FMV_ID;
                cmd.Parameters.Add("P_VESTING_ID", OracleType.Int32).Value = FMVBo.VESTING_ID;
                cmd.Parameters.Add("P_NO_OF_OPTION", OracleType.Int32).Value = FMVBo.NO_OF_OPTION;
                cmd.Parameters.Add("P_CREATED_BY", OracleType.VarChar).Value = FMVBo.CREATED_BY;
                cmd.Parameters.Add("P_UPDATED_BY", OracleType.VarChar).Value = FMVBo.UPDATED_BY;
                cmd.Parameters.Add("P_CREATION_DATE", OracleType.VarChar).Value = FMVBo.CREATED_DATE;
                cmd.Parameters.Add("P_UPDATION_DATE", OracleType.VarChar).Value = FMVBo.UPDATED_DATE;
                cmd.Parameters.Add("P_ISVISIBLE", OracleType.VarChar).Value = FMVBo.IS_VISIBLE;
                cmd.Parameters.Add("P_REMARK1", OracleType.VarChar).Value = FMVBo.REMARK1;
                cmd.Parameters.Add("P_REMARK2", OracleType.VarChar).Value = FMVBo.REMARK2;
                cmd.Parameters.Add("P_Key", OracleType.VarChar).Value = FMVBo.Key;
                cmd.Parameters.Add("P_TAX_REGIME", OracleType.VarChar).Value = FMVBo.TAX_REGIME;                //Added by Krutika on 09-01-23
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                con.Open();
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
            //return status;
            //return ds;
        }
        public DataSet ESOP_EMPTY_DUMP_TABLE(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_EMPTY_DUMP_TABLE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.VarChar).Value = objbo.GRANT_NAME;
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

        //Added by Krutika on 05-01-23
        public DataSet ESOP_TRUNCATE_DUMP_TABLE(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_TRUNCATE_DUMP_TABLE";
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        //End
        public DataSet ESOP_ISSUED_GRANT(GrandCreationBO objBO)
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_ISSUED_GRANT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.VarChar).Value = objBO.GRANT_NAME;
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
        public bool Update_Excercise_BnkStatmnt(GrandCreationBO objBO)
        {
            bool status = false;
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_UPDATE_Excercise_BankStatement";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_Start_Date", OracleType.DateTime).Value = objBO.Start_Date.ToShortDateString();
                cmd.Parameters.Add("P_End_Date", OracleType.DateTime).Value = objBO.End_Date.ToShortDateString();
                cmd.Parameters.Add("P_FilePath", OracleType.VarChar).Value = objBO.excelDoucmentName;
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
        public DataSet GET_FILEPATH(GrandCreationBO objbo)
        {
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_FILEPATH_CANCEL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_STATUS", OracleType.VarChar).Value = objbo.RecStatus;
                cmd.Parameters.Add("P_EMP_ID", OracleType.VarChar).Value = objbo.EMP_ID;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.VarChar).Value = objbo.GRANT_NAME;
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
        public DataSet Delete_GrandCreation(GrandCreationBO FMVBo)
        {
            //bool status = false;
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_DELETE_GRANDCREATION_CANCEL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.VarChar).Value = FMVBo.GRANT_NAME;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                con.Open();
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
        public DataSet SaveGranttoCancelTbl(GrandCreationBO FMVBo)
        {
            //bool status = false;
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_SaveGranttoCancelTbl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.VarChar).Value = FMVBo.GRANT_NAME;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                con.Open();
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
            //return status;
            //return ds;
        }
        public DataSet Cancel_GrandCreation(GrandCreationBO FMVBo)
        {
            //bool status = false;
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                //cmd.CommandText = "ESOP_CANCEL_GRANT_GRAND_CREATION_APPEND_OVERRIDE";
                cmd.CommandText = "ESOP_SAVE_GRAND_CREATION_APPEND_OVERRIDE_CANCEL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.VarChar).Value = FMVBo.GRANT_NAME;
                cmd.Parameters.Add("P_KEY", OracleType.VarChar).Value = FMVBo.Key;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                con.Open();
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
        public DataSet Save_GrandCreation(GrandCreationBO FMVBo)
        {
            //bool status = false;
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_SAVE_GRANDCREATION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_GRANT_NAME", OracleType.VarChar).Value = FMVBo.GRANT_NAME;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                con.Open();
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
        public DataSet Insert_FMV(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            //bool status = false;
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                //cmd.CommandText = "ESOP_INSERT_FMV_DATA"; 
                cmd.CommandText = "ESOP_INSERT_FMV_DATA_test";   //Added by Krutika on 05-09-22 for duplicate entries
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_CreatedBy", OracleType.VarChar).Value = objbo.CREATED_BY;
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
            //return status;
            //return ds;

        }
        public DataSet Insert_VESTING(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_VESTING_DATA";
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
        public DataSet Insert_VALUATION(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_VALUATION_DATA";
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
        public DataTable getFailedDataTableWise(string table)
        {
            DataTable ds = new DataTable();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GETFAILRECORDS_TableWise";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_TableWise", OracleType.VarChar).Value = table;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                con.Open();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataSet Insert_Copy_EMP_Ex_Data(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            //bool status = false;
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SP_COPY_EMP_1_new"; //"SP_COPY_EMP_1" Replaced by Krutika on 06-09-22 ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_CREATED_BY", OracleType.VarChar).Value = objbo.CREATED_BY;
                cmd.Parameters.Add("P_Grand_Name", OracleType.VarChar).Value = objbo.GRANT_NAME;
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
        public DataSet Insert_Grant_Vesting(GrandCreationBO objbo)
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_GRANT_VESTING_BULK_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                // cmd.Parameters.Add("P_CREATED_BY", OracleType.VarChar).Value = objbo.CreatedBy;
                // cmd.Parameters.Add("P_Grand_Name", OracleType.VarChar).Value = objbo.GRANT_NAME;
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
        public DataSet GET_EMP_ROLL(EmployeeBO ObjBo)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMP_ROLL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECode", OracleType.VarChar).Value = ObjBo.ECode.ToLower();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;

                con.Open();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataSet Workflow(GrandCreationBO objbo)
        {
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ADMIN_PENDING_WORKFLOW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Key", OracleType.VarChar).Value = objbo.Key;
                cmd.Parameters.Add("P_ECode", OracleType.VarChar).Value = objbo.Ecode;
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
        public DataSet UserFilter_1(EmployeeBO ObjBo)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_USER_FILTER_1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_ECode", OracleType.VarChar).Value = ObjBo.ECode.ToLower();
                cmd.Parameters.Add("P_Emp_Name", OracleType.VarChar).Value = ObjBo.Emp_Name.ToLower();
                cmd.Parameters.Add("P_Dept", OracleType.VarChar).Value = ObjBo.Dept;
                cmd.Parameters.Add("P_Band", OracleType.VarChar).Value = ObjBo.Band;
                cmd.Parameters.Add("P_Location", OracleType.VarChar).Value = ObjBo.Location;
                cmd.Parameters.Add("P_Role", OracleType.VarChar).Value = ObjBo.RoleID;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;

                con.Open();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataSet Admin_Trans_History(GrandCreationBO objbo)
        {
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ADMIN_TRANS_HISTORY_1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Key", OracleType.VarChar).Value = objbo.Key;
                cmd.Parameters.Add("P_ECode", OracleType.VarChar).Value = objbo.Ecode;
                cmd.Parameters.Add("P_Grant_Name", OracleType.VarChar).Value = objbo.GRANT_NAME;
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
        public DataSet INSERT_GVD(GrandCreationBO objbo)
        {
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_INSERT_GVD";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GrantID", OracleType.VarChar).Value = objbo.GRANT_ID;
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
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public bool Insert_Lapse_Historic(GrandCreationBO objbo)
        {
            bool status = false;
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Insert_Lapse_Historic";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_CREATED_BY", OracleType.VarChar).Value = objbo.CREATED_BY;
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
        public bool Update_GVD_Lapse_Historic(GrandCreationBO objbo)
        {
            bool status = false;
            DataTable ds = new DataTable();
            try
            {
                DataSet dsresult = new DataSet();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_Update_gvd_lapse_historic";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_GrantID", OracleType.VarChar).Value = objbo.GRANT_ID;
                cmd.Parameters.Add("P_V_ID", OracleType.VarChar).Value = objbo.VESTING_ID;
                cmd.Parameters.Add("P_ECODE", OracleType.VarChar).Value = objbo.Ecode;
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
    }
}
