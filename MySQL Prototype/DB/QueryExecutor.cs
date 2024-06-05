using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace MySQL_Prototype.DB
{
    public  class QueryExecutor
    {
        DataBaseConnector connector = new DataBaseConnector();
        public QueryExecutor()
        {
            connector.OpenConnection();
        }

        public int ExecuteNonQuery(string querry) 
        {
            int rowsAffected = 0;
            MySqlCommand cmd = new MySqlCommand(querry,connector.GetConnection());
            rowsAffected = cmd.ExecuteNonQuery();
            connector.CloseConnection();
            return rowsAffected; 
        
        }

        public string ExecuteQuery(string query)
        {
            StringBuilder sb = new StringBuilder();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connector.GetConnection());
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            //Перебираем таблицы
            foreach (DataTable dt in ds.Tables)
            {
                //Получаем названия столбцов
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append($"{column.ColumnName}\t");
                }
                sb.AppendLine();
                //Получаем значения ячеек
                foreach (DataRow row in dt.Rows)
                {
                    // получаем все ячейки строки
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                    {
                        sb.Append($"{cell}\t");
                    }
                    sb.AppendLine();
                }
                sb.AppendLine();
            }

            connector.CloseConnection();
            return sb.ToString();
        }

    }
}
