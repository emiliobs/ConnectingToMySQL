
using Dapper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class DataAccess : IDataAccess
    {
        public async  Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public Task SaveData<T, U>(string sql, U parameter, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                return  connection.ExecuteAsync(sql, parameter);
            }
        }


    }
}
