using static API.Repositories.Artist.AddArtist.AddArtistRepository;
using System.Data.SqlClient;

namespace API.Repositories.Artist.AddArtist
{
	public class AddArtistRepository : IAddArtistRepository
	{

		private readonly string connectionString;

		public AddArtistRepository(string connectionString) 
		{
			this.connectionString = connectionString;
		}	




		public void AddArtist(string title, string biography, string imageURL, string heroURL)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				string query = @"INSERT INTO Artist (dateCreation, title, biography, imageURL, heroURL) 
                             VALUES (@DateCreated, @Title, @Biography, @ImageURL, @HeroURL)";

				using (var command = new SqlCommand(query, connection))
				{
					 
					command.Parameters.AddWithValue("@DateCreated", DateTime.Now);
					command.Parameters.AddWithValue("@Title", title);
					command.Parameters.AddWithValue("@Biography", biography);
					command.Parameters.AddWithValue("@ImageURL", imageURL);
					command.Parameters.AddWithValue("@HeroURL", heroURL);

					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}







	}

}

