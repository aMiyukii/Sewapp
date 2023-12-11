using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sewapp.Data
{
    public class CategoryRepository
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public CategoryRepository(string name)
        {
            Name = name;
        }

        public CategoryRepository(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public void SendCategoryToDatabase()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.OpenConnection();

            try
            {
                using (SqlConnection connection = dbConnection.GetSqlConnection())
                {
                    string insertQuery = "INSERT INTO dbo.category (CategoryId, Name) VALUES (@CategoryId, @Name);";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        if (CategoryId == 0)
                        {
                            string getIdQuery = "SELECT ISNULL(MAX(CategoryId), 0) + 1 FROM dbo.category;";
                            using (SqlCommand getIdCmd = new SqlCommand(getIdQuery, connection))
                            {
                                CategoryId = Convert.ToInt32(getIdCmd.ExecuteScalar());
                            }
                        }

                        cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
                        cmd.Parameters.AddWithValue("@Name", Name);

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Category added successfully with CategoryId: " + CategoryId);
                        Console.WriteLine("Category added successfully with Name: " + Name);
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

        public static List<CategoryRepository> GetAllCategoriesFromDatabase()
        {
            List<CategoryRepository> categories = new List<CategoryRepository>();

            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.OpenConnection();

            try
            {
                using (SqlConnection connection = dbConnection.GetSqlConnection())
                {
                    string selectQuery = "SELECT CategoryId, Name FROM dbo.category";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int categoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));

                                CategoryRepository category = new CategoryRepository(categoryId, name);
                                categories.Add(category);
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

            return categories;
        }

        public static CategoryRepository GetCategoryByIdFromDatabase(int categoryId)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.OpenConnection();

            try
            {
                using (SqlConnection connection = dbConnection.GetSqlConnection())
                {
                    string selectQuery = "SELECT CategoryId, Name FROM dbo.category WHERE CategoryId = @CategoryId";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));

                                return new CategoryRepository(id, name);
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

            return null;
        }
    }
}
