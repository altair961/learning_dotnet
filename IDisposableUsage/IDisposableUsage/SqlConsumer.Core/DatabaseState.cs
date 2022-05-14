﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace SqlConsumer.Core
{
    public class DatabaseState : IDisposable
    {
        private readonly string _connectionString;
        protected SqlConnection _connection;

        public DatabaseState(IConfiguration config) : this(config.GetConnectionString("db")) { }

        public DatabaseState(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetDate()
        {
            if (_connection == null) 
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open(); // we do not remove connection after usage that will exaust connections of sqlserver connections pool if we create multiple instances of DatabasState class. If we create just one instance and create it with "using" then all is good.
            }
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT getdate()";
                return command.ExecuteScalar().ToString();
            }
        }

        public void Dispose()
        {
            Debug.WriteLine($"[{DateTime.Now.ToLongTimeString()}] Disposing; SqlConnection: {_connectionString}");
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }
}