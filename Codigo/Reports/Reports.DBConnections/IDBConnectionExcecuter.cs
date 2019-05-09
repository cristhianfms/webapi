using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Reports.DBConnections
{

    public interface IDBConnectionExcecuter
    {
        void SetConnectionString(string connStr);
        void SetQuerySQL(string query);
        DataSet GetResult();
    }
}
