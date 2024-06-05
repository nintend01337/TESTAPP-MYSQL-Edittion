using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MySQL_Prototype.DB
{
    public class MysqlWriter : IDatabaseWriter, IDisposable
    {
        private MysqlConnector _connector = new MysqlConnector();
        public MysqlWriter()
        {
            //_connector.OpenConnection(); 
        }

        public void Dispose()
        {
            //_connector.CloseConnection();
        }

        public void WriteData(string query, Dictionary<string, object> parameters)
        {
            using (var connection = _connector.GetConnection())
            {
                connection.Open();

                using (var cmd = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param.Key, (MySqlDbType)param.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

