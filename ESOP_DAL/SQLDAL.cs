using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ESOP_DAL
{
    public class SQLDAL
    {
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;

        /// <constructor>
        /// Constructor CommonDAL
        /// </constructor>
        public SQLDAL()
        {
            myAdapter = new SqlDataAdapter();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        }


        private SqlConnection openConnection()
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
        public DataSet exe_SelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
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
            catch (SqlException e)
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
        public int exe_ExecuteNonQuery(String _query, SqlParameter[] sqlParameter)
        {
            int result = 0;
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                result = myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
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
        public int exe_ExecuteNonQuery_DT(String _dtName, DataTable dt, String _query, SqlParameter[] sqlParameter)
        {
            int result = 0;
            SqlCommand myCommand = new SqlCommand();
            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = _dtName;
                param.SqlDbType = SqlDbType.Structured;
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
            catch (SqlException e)
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
