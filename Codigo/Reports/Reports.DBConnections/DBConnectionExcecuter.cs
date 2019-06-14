using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Reports.DBConnections
{
    public class DBConnectionExcecuter : IDBConnectionExcecuter
    {
        public string QuerySQL { get; set; }
        public string ConnectionString { get; set; }

        public DBConnectionExcecuter() { }

        public DBConnectionExcecuter(string connectionString, string querySQL)
        {
            this.QuerySQL = querySQL;
            this.ConnectionString = connectionString;
        }

        public DataSet GetResult()
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(QuerySQL, connection);
                DataSet dSet = new DataSet();
                dataAdapter.Fill(dSet);
                connection.Close();
                return dSet;
            }
            catch (Exception e)
            {
                throw new DBConnectionException("Connection database error",e);
            }

        }

        public void SetConnectionString(string connStr)
        {
            this.ConnectionString = connStr;
        }

        public void SetQuerySQL(string query)
        {
            this.QuerySQL = query;
        }
    }
}
