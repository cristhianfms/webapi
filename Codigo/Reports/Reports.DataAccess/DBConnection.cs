using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Reports.DataAccess.Interface;
using System.Data.SqlClient;

namespace Reports.DataAccess
{
    public class DBConnection : IDBConnection
    {
        public string QuerySQL { get; set; }
        public string ConnectionString { get; set; }

        public DBConnection(string connectionString, string querySQL)
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
                return dSet;
            }
            catch (Exception e)
            {
                throw new RepositoryException("Error de conexión a la base",e);
            }

        }
    }
}
