using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Entity_REPORT;

namespace DAL_REPORT
{
    public class ReportDAL
    {
        OracleConnection con;
        OracleCommand cmd;
        public void GetConnString(string key)
        {
            if (key == "ESOP")
            {
                con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLConStringESOP"].ConnectionString);                
            }
            else
            {
                con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLConStringPMS"].ConnectionString);
            }
        }
        public DataSet GetDataSet()
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetDatasetsFor_PMS_ESOP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
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
        public DataSet GetColumnsForDatasets(string tableName)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetColumnsForDatasets";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_Table", OracleType.VarChar).Value = tableName;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
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
        public DataSet ShowReport(string columns, string[] tableName, int count)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetJoinConditions";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_Column", OracleType.VarChar).Value = columns;
                cmd.Parameters.Add("p_Table1", OracleType.VarChar).Value = tableName[0];
                cmd.Parameters.Add("p_Table2", OracleType.VarChar).Value = tableName[1];
                cmd.Parameters.Add("p_Table3", OracleType.VarChar).Value = tableName[2];
                cmd.Parameters.Add("p_Table4", OracleType.VarChar).Value = tableName[3];
                cmd.Parameters.Add("p_Count", OracleType.Number).Value = count;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
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
        public DataSet AddCreateReport(EReport ObjEntity)
        {
            DataSet dsNew = new DataSet();
            try
            {
                cmd = new OracleCommand();
                if (ObjEntity.key == "ESOP")
                {
                    con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLConStringESOP"].ConnectionString);
                }
                else
                {
                    con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLConStringPMS"].ConnectionString);
                }
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "sp_RB_CreateReport";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_CR_DomainName", OracleType.NVarChar).Value = ObjEntity.DomainName;
                cmd.Parameters.Add("p_CR_ReportName", OracleType.NVarChar).Value = ObjEntity.ReportName;
                cmd.Parameters.Add("p_CR_ReportDesc", OracleType.NVarChar).Value = ObjEntity.ReportDesc;
                cmd.Parameters.Add("p_create_by", OracleType.Number).Value = ObjEntity.CreatedBy;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;

                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(dsNew);
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
            return dsNew;
        }
        public DataSet GetReportData(string Squery)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetReportData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_Query", OracleType.VarChar).Value = Squery;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
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
        public void UpdateReportsData(EReport objReport)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_UpdateReportsData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_ReportID", OracleType.Number).Value = objReport.ReportID;
                cmd.Parameters.Add("p_Query", OracleType.VarChar).Value = objReport.Query;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
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
        public DataSet FillUsers()
        {
            try
            {               
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "sp_FillUsers";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("curRptNames", OracleType.Cursor).Direction = ParameterDirection.Output;

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
        public DataSet FillRptNames()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "sp_FillRptNames";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("curRptNames", OracleType.Cursor).Direction = ParameterDirection.Output;

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
        public DataSet FillDepartments()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "sp_FillDepartments";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
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
        public DataSet FillRoles()
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "sp_FillRoles";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
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
            }
        }
        public DataSet getMaxRSID_DAL()
        {
            DataSet ds = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "sp_getMaxShareReportId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
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
        public void addShareRpt_dal(EReport objReport)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_AddShareReportsData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_shareID", OracleType.Number).Value = objReport.shareID;
                cmd.Parameters.Add("p_ReportID", OracleType.Number).Value = objReport.ReportID;
                cmd.Parameters.Add("p_Empcode", OracleType.Number).Value = objReport.empCode;
                cmd.Parameters.Add("p_RS_Flag", OracleType.VarChar).Value = "Insert";

                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
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
        public DataSet GetFilterData_ByReport(string val)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_getFilterDataBy_Report";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_val", OracleType.VarChar).Value = val;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
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
        public DataSet GetFilterData_ByUsers(string val)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_getFilterDataBy_Users";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_val", OracleType.VarChar).Value = val;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
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
        public DataSet GetFilterData_All()
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_getFilterDataBy_All";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
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
        public DataSet setRptStatus_DAL(Int32 rsId, Int32 shareid, String Action)
        {
            DataSet dsresult = new DataSet();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "sp_AddShareReportsData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_shareID", OracleType.Number).Value = shareid;
                cmd.Parameters.Add("p_rs_id", OracleType.Number).Value = rsId;
                cmd.Parameters.Add("p_action", OracleType.VarChar).Value = Action;
                cmd.Parameters.Add("p_RS_Flag", OracleType.VarChar).Value = "Update_action";
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
        public DataSet GetDataTypeForColumns(string tableName, string columnName)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "sp_GetDataTypeForColumns";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_Table", OracleType.VarChar).Value = tableName;
                cmd.Parameters.Add("p_Column", OracleType.VarChar).Value = columnName;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
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
