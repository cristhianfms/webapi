using System;
using System.Collections.Generic;
using System.Text;
using Reports.DataAccess.Interface;
using System.Data;

namespace Reports.Domain
{
    public class SQLValue : ValueExpression
    {
        public Area Area { get; set; }
        public IDBConnection DBConn { get; set; }

        public override string Evaluate()
        {
            DBConn.ConnectionString = Area.ConnectionString;
            DBConn.QuerySQL = this.Value;
            DataSet dset = DBConn.GetResult();

            return dset.Tables[0].Rows[0][0].ToString();
        }
    }
}
