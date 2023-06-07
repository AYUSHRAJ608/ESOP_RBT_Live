using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;

namespace ESOP_DAL
{
    public class OracleDAL
    {
        private OracleDataAdapter myAdapter;
        private OracleConnection conn;

        /// <constructor>
        /// Constructor CommonDAL
        /// </constructor>
        public OracleDAL()
        {
            myAdapter = new OracleDataAdapter();
            conn = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        }


        private OracleConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State ==
                        ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        /// <method>
        /// Select Query
        /// </method>
        public DataSet exe_SelectQuery(String _query, OracleParameter[] sqlParameter)
        {
            OracleCommand myCommand = new OracleCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                //myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                //dataTable = ds.Tables[0];
            }
            catch (OracleException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                //return null;
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return ds;
        }
        /// <method>
        /// Insert Query
        /// </method>
        public int exe_ExecuteNonQuery(String _query, OracleParameter[] sqlParameter)
        {
            int result = 0;
            OracleCommand myCommand = new OracleCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                result = myCommand.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " + _query + " \nException: \n" + e.StackTrace.ToString());
                return result;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }
        public int exe_ExecuteNonQuery_DT(String _dtName, DataTable dt, String _query, OracleParameter[] sqlParameter)
        {
            int result = 0;
            OracleCommand myCommand = new OracleCommand();
            try
            {
                OracleParameter param = new OracleParameter();
                param.ParameterName = _dtName;
                //   param.OracleDbType  = OracleType.S.Structured;
                param.Value = dt;
                param.Direction = ParameterDirection.Input;

                myCommand.Connection = openConnection();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = _query;
                myCommand.Parameters.Add(param);
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                result = myCommand.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " + _query + " \nException: \n" + e.StackTrace.ToString());
                return result;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }

    }
}
