using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sewapp.Data
{
    public class PatternRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public PatternRepository(string name)
        {
            Name = name;
        }

        public PatternRepository(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void SendPatternToDatabase()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.OpenConnection();

            try
            {
                using (SqlConnection connection = dbConnection.GetSqlConnection())
                {
                    string insertQuery = "INSERT INTO dbo.Pattern (Name) VALUES (@Name); SELECT SCOPE_IDENTITY() AS NewId;";


                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", Name);

                        // ExecuteScalar is used to retrieve the newly generated Id
                        Id = Convert.ToInt32(cmd.ExecuteScalar());
                        Console.WriteLine($"Pattern added with Id: {Id}");
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


        public static List<PatternRepository> GetAllPatternsFromDatabase()
        {
            List<PatternRepository> patterns = new List<PatternRepository>();

            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.OpenConnection();

            try
            {
                using (SqlConnection connection = dbConnection.GetSqlConnection())
                {
                    string selectQuery = "SELECT Id, Name FROM dbo.Pattern";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));

                                PatternRepository pattern = new PatternRepository(id, name);
                                patterns.Add(pattern);
                            }
                        }
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

            return patterns;
        }

    }
}
