using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Reports.DataAccess.Interface
{

    public interface IDBConnection
    {
        void SetConnectionString(string connStr);
        void SetQuerySQL(string query);
        DataSet GetResult();
    }
}
