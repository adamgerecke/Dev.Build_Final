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
            connString = config.GetConnectionString("Brendan");
            conn = new SqlConnection(connString);
        }

        public IEnumerable<planner> GetList()
        {
            return conn.GetAll<planner>().ToList();
        }

        public void RemoveTask(planner myTask)
        {
            string query = $"DELETE FROM party WHERE description='{myTask.description}'";
            conn.Query<planner>(query);
        }

        public void AddTask(planner myTask)
        {
            conn.Insert<planner>(myTask);
        }

        public void CompleteTask(planner myTask)
        {
            var procedure = "[toggle]";
            var values = new { description = myTask.description };
            conn.Query(procedure, values, commandType: CommandType.StoredProcedure);
        }

    }
}
