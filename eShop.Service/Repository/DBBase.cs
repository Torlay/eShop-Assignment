using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace eShop.Service.Repository
{
    public abstract class DBBase<T>
    {
        private readonly string _connectionString = @"Server=localhost\SQLExpress;Database=eShopAssignment;User Id=sa;Password=Sovos2020@;";
        private SqlConnection _connection;

        ~DBBase()
        {
            _connection = null;
        }

        internal List<T> Select(string query) 
        {
            List<T> result = new List<T>();

            using (_connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, _connection);
                _connection.Open();
                var sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    result.Add(GetInstance(sqlDataReader));
                }
                _connection.Close();
            }

            return result;
        }

        internal int ExecuteCommand(string commandText)
        {
            int result;

            using (_connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(commandText, _connection);
                _connection.Open();
                result = command.ExecuteNonQuery();

                _connection.Close();
            }

            return result;
        }

        internal abstract T GetInstance(SqlDataReader reader);
    }
}
