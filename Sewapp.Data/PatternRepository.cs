using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sewapp.Data
{
    public class PatternRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        private static int lastAssignedId = 0;


        public PatternRepository(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }

        public PatternRepository(int id, string name, int categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
        }

        public void SendPatternToDatabase()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.OpenConnection();

            try
            {
                using (SqlConnection connection = dbConnection.GetSqlConnection())
                {
                    if (Id == 0)
                    {
                        string getMaxIdQuery = "SELECT ISNULL(MAX(Id), 0) FROM dbo.pattern;";
                        using (SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, connection))
                        {
                            lastAssignedId = Convert.ToInt32(getMaxIdCmd.ExecuteScalar());
                        }

                        Id = ++lastAssignedId;
                    }

                    if (Name != null && CategoryId > 0)
                    {
                        string insertQuery = "INSERT INTO dbo.pattern (Id, Name, CategoryId) VALUES (@Id, @Name, @CategoryId);";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", Id);
                            cmd.Parameters.AddWithValue("@Name", Name);
                            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);

                            cmd.ExecuteNonQuery();
                            Console.WriteLine($"Pattern added with Id: {Id}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Name or CategoryId is null.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public static List<PatternRepository> GetPatternsFromDatabase()
        {
            List<PatternRepository> patterns = new List<PatternRepository>();
            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.OpenConnection();

            try
            {
                using (SqlConnection connection = dbConnection.GetSqlConnection())
                {
                    string selectQuery = "SELECT Id, Name, CategoryId FROM dbo.pattern";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id"));
                                string name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name"));
                                int categoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId")) ? 0 : reader.GetInt32(reader.GetOrdinal("CategoryId"));

                                PatternRepository pattern = new PatternRepository(id, name, categoryId);
                                patterns.Add(pattern);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching patterns from the database: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return patterns;
        }

    }
}
