using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectToDB
{
    public class Class1
    {
        protected string _connStr;


        public Class1(string connectStr)
        {
            _connStr = connectStr;
        }

        public string GetStr()
        {
            return this._connStr;
        }
        
        
    }
}
