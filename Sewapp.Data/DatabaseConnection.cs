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
                connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Database=SewApp;");

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
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }   
        }
    }
}
