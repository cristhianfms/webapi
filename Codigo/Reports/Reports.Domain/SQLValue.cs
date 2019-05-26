using System;
using System.Collections.Generic;
using System.Text;
using Reports.DBConnections;
using System.Data;

namespace Reports.Domain
{
    public class SQLValue : Value
    {

        public string Data { get; set; }
        public Guid? AreaId { get; set; }
        public virtual Area Area { get; set; }

        public override string Display()
        {
            return Data;
        }

        public override string Eval()
        {
            try
            {
                IDBConnectionExcecuter DBConn = new DBConnectionExcecuter();
                DBConn.SetConnectionString(Area.ConnectionString);
                DBConn.SetQuerySQL(Data);
                DataSet dset = DBConn.GetResult();

                return dset.Tables[0].Rows[0][0].ToString();
            }
            catch (DBConnectionException e)
            {
                throw new DomainException("Error in sql excecution", e);
            }

        }
    }
}
