using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Build_Final.Services
{
    public class DAL : IDAL
    {
        private string connString;
        private SqlConnection conn;

        public DAL(IConfiguration config)
        {
            connString = config.GetConnectionString("default");
            conn = new SqlConnection(connString);
        }
    }
}
