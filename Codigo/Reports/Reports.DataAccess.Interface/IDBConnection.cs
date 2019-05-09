using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Reports.DataAccess.Interface
{

    public interface IDBConnection
    {
        string QuerySQL { get; set; }
        string ConnectionString { get; set; }
        
        DataSet GetResult();
    }
}
