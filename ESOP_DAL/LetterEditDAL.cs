using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ESOP_BO;
using System.Data.OracleClient;
namespace ESOP_DAL
{
    public class LetterEditDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        OracleCommand cmd = new OracleCommand();
        DataSet ds = new DataSet();
        CommonDAL comdal = new CommonDAL();

        //public bool InsertLetterDetails(LetterEditBO objEntity)
        //{
        //    bool status = false;
        //    try
        //    {
        //        cmd = new OracleCommand("ESOP_INSERT_REPORTIMG", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.Add("p_PATH", OracleType.VarChar).Value = objEntity.ImgPath.Trim();
        //        cmd.Parameters.Add("p_SECTION", OracleType.VarChar).Value = objEntity.ImageType.Trim();
        //        cmd.Parameters.Add("p_LETTERID", OracleType.Number).Value = objEntity.LetterID;
        //        cmd.Parameters.Add("p_CREATED_BY", OracleType.VarChar).Value = objEntity.CreatedBy.Trim();
        //        con.Open();
        //        int res = cmd.ExecuteNonQuery();
        //        con.Close();
        //        if (res > 0)
        //        {
        //            status = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (con.State != ConnectionState.Closed)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return status;
        //}

        public bool InsertLetterDetails(LetterEditBO objEntity)
        {
            bool status = false;
            try
            {
                cmd = new OracleCommand("ESOP_INSERT_Letter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_Header", OracleType.VarChar).Value = Convert.ToString(objEntity.Header);
                cmd.Parameters.Add("p_Footer", OracleType.VarChar).Value = Convert.ToString(objEntity.Footer);
                cmd.Parameters.Add("p_Signature", OracleType.VarChar).Value = Convert.ToString(objEntity.Signature);
                cmd.Parameters.Add("p_Designation", OracleType.VarChar).Value = Convert.ToString(objEntity.Designation);
                cmd.Parameters.Add("p_Content", OracleType.VarChar).Value = Convert.ToString(objEntity.Content);             
                cmd.Parameters.Add("p_LETTERID", OracleType.Number).Value = objEntity.LetterID;
                cmd.Parameters.Add("p_CREATED_BY", OracleType.VarChar).Value = objEntity.CreatedBy.Trim();
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                if (res > 0)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                comdal.LogExceptionDB(this.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
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

        public int InsertLetterConfig(LetterEditBO objEntity)
        {
            int ID = 0;
            try
            {
                cmd = new OracleCommand("ESOP_INSERT_LETTER_Config1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_Filepath", OracleType.VarChar).Value = objEntity.ImgPath;
                cmd.Parameters.Add("p_LETTERNAME", OracleType.VarChar).Value = objEntity.LetterName;
                cmd.Parameters.Add("p_CREATED_BY", OracleType.VarChar).Value = objEntity.CreatedBy.Trim();
                cmd.Parameters.Add("p_LETTERID", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_UPLOADTYPE", OracleType.VarChar).Value = objEntity.UPLOADType;
                con.Open();
                int i = cmd.ExecuteNonQuery();
                ID = Convert.ToInt32(cmd.Parameters["p_LETTERID"].Value);
            }
            catch (Exception ex)
            {
                 comdal.LogExceptionDB(this.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return ID;
        }
        public bool DeleteLetterDetails(LetterEditBO objEntity)
        {
            bool status = false;
            try
            {
                cmd = new OracleCommand("ESOP_DELETE_LETTERDETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_SECTION", OracleType.VarChar).Value = objEntity.ImageType.Trim();
                cmd.Parameters.Add("p_LETTERID", OracleType.Number).Value = objEntity.LetterID;
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                if (res > 0)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                comdal.LogExceptionDB(this.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
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
        public DataSet GetLetterEditDetails(LetterEditBO objEntity)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GetLetterEditDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_LETTERID", OracleType.Number).Value = objEntity.LetterID;
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
        public DataSet report(LetterEditBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_USP_GET_Employee_Grant_Details";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = objbo.EMPCODE;//"CI_10245";
                //cmd.Parameters.Add("p_GRANT_ID", OracleType.Number).Value = objbo.GrantID;  //"TRANCH1";
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

        public DataSet GetReportDesign(LetterEditBO objbo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GetLetterEditDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_LETTERID", OracleType.Number).Value = objbo.LetterID;
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
