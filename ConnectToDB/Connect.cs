using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectToDB
{
    public class Connect
    {
        protected static string _connStr;


        public Connect(string connectStr)
        {
            _connStr = connectStr;
        }

        public static string GetStr()
        {
            return _connStr;
        }
        
        
    }
}
