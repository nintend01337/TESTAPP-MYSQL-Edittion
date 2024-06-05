using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MySQL_Prototype.DB
{
    public class MysqlConnector : IDbConnector
    {
        private string host { get; set; }
        private string username { get; set; }
        private string port { get; set; }
        private string password { get; set; }
        private string database { get; set; }
        MySqlConnection _connection;

        public MysqlConnector(string host = "localhost", string username = "root", string port = "3306", string database = "shoping", string password = "")
        {
            this.host = host;
            this.username = username;
            this.port = port;
            this.password = password;
            this.database = database;

            string connectionString = $"Server={host};Port={port};Database={database};Uid={username};pwd={password}";

            MySqlConnection _connection = new MySqlConnection(connectionString);
            OpenConnection();

        }
        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                try
                {
                    _connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot connect : \n" + ex.Message);
                }

            }
        }


        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();

            }
            else
            {
                Console.WriteLine("Already Closed");
            }
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
