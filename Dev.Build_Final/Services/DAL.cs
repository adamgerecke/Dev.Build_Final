﻿using Dapper;
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
    public class DAL :IDAL
    {
        private string connString;
        private SqlConnection conn;

        public DAL(IConfiguration config)
        {
            connString = config.GetConnectionString("default");
            conn = new SqlConnection(connString);
        }
        #region PartyCode
        public IEnumerable<party> GetPartyList()
        {
            string query = "SELECT * FROM party";
            return conn.Query<party>(query);
        }

        public void RemoveTask(party myTask)
        {
            var procedure = "[deleteFromParty]";
            var values = new { description = myTask.description };
            conn.Query(procedure, values, commandType: CommandType.StoredProcedure);

            //string query = $"DELETE FROM party WHERE description='{myTask.description}'";
            //conn.Query<party>(query);
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
        #endregion


    }
}
