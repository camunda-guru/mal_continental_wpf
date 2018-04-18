using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreDllDemo
{
    public class OracleHelper
    {
        public static OracleConnection getConnection()
        {
            string ConString = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SID = XE))); User Id = System; Password=vignesh";
            return new OracleConnection(ConString);
        }
    }
}
