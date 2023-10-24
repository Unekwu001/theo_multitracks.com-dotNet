using System;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace API.Repositories.Artist.SearchArtist
{
    public class SearchArtistRepository : ISearchArtistRepository
    {

        private readonly string connectionString;



        public SearchArtistRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }




        //Method that searches for Artist 
        public string SearchArtistsFromDatabase(string name)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    string query = $"SELECT * FROM Artist WHERE title LIKE @Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    // You may want to throw or handle the exception in a different way
                }

                // Now you need to decide what you want to return.
                // For example, you can return a serialized JSON string of the DataTable:
                return ConvertDataTableToJson(dataTable);

                // Or if you want to return the DataTable directly, change the return type to DataTable:
                // return dataTable;
            }
        }




        // Helper method to convert DataTable to JSON string
        private string ConvertDataTableToJson(DataTable dataTable)
        {
            string jsonString = string.Empty;
            if (dataTable.Rows.Count > 0)
            {
                jsonString = JsonConvert.SerializeObject(dataTable);
            }
            return jsonString;
        }
    }
}





