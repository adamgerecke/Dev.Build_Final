using Dapper;
using Dapper.Contrib.Extensions;
using Dev.Build_Final.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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

        public IEnumerable<party> GetList()
        {
            return conn.GetAll<party>().ToList();
        }

        public void RemoveTask(party myTask)
        {
            string query = $"DELETE FROM party WHERE description='{myTask.description}'";
            conn.Query<party>(query);
        }

        public void AddTask(party myTask)
        {

            conn.Insert<party>(myTask);
        }

        public void CompleteTask(party myTask)
        {
            var procedure = "[toggle]";
            var values = new { description = myTask.description };
            conn.Query(procedure, values, commandType: CommandType.StoredProcedure);
        }

    }
}
