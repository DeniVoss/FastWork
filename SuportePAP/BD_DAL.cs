using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace SuportePAP
{
    public class BD_DAL
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;user=root;password=;database=pap;";

        public BD_DAL()
        {
            connection = new MySqlConnection(connectionString);
        }

        private void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        private void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                OpenConnection();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return dataTable;
        }

        public void ExecuteNonQuery(string query)
        {
            try
            {
                OpenConnection();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar a consulta não-query: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
