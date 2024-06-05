using MySql.Data.MySqlClient;
using System;
using System.Data;

/// <summary>
/// Класс управляющий подключениями к Базе Данных 
/// </summary>
public class DataBaseConnector
{
    MySqlConnection connection = new MySqlConnection($"Server=localhost;Port=3306;Database=shoping;Uid=root;pwd={string.Empty}");
    
    /// <summary>
    /// Открывает подключение к БД
    /// </summary>
    public void OpenConnection()
    {
        if (connection.State == ConnectionState.Closed)
        {
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось подключиться к базе данных" +
                                    $" проверьте подключение а также убедитесь что БД существует.\n{e.Message}");
            }
        }
    }

    /// <summary>
    /// Закрывает подключение к БД
    /// </summary>
    public void CloseConnection()
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }

    /// <summary>
    /// Возвращает текущее подключения.
    /// </summary>
    /// <returns>SqlConnetion instance</returns>
    public MySqlConnection GetConnection()
    {
        return connection;
    }
}
