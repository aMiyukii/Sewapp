using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Sewapp.Data
{
    public class DatabaseConnection
    {
        private SqlConnection connection;

        public void OpenConnection()
        {
            try
            {
                // Initialize the SqlConnection
                connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Database=master;");

                // Open the connection
                connection.Open();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Connection not working");
            }
        }


        public SqlConnection GetSqlConnection()
        {
            return connection;
        }


        public void CloseConnection()
        {
            // Close the connection if it's open
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }   
        }
    }
}
