using System;
using System.Data.SqlClient;

namespace Sewapp.Data
{
    public class AddToDatabase
    {
        private readonly string _connectionString;

        public AddToDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SavePatternToDatabase(PatternDTO patternDto)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Patterns (Name) VALUES (@Name);";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", patternDto.Name);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Error saving pattern to the database: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
