using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace API.Repositories.Song
{

	public class SongsRepository : ISongsRepository
	{
		private readonly string connectionString;



		public SongsRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}





		public int GetTotalSongCount()
		{
			string query = "SELECT COUNT(*) FROM Song";

			using (var connection = new SqlConnection(connectionString))
			using (var command = new SqlCommand(query, connection))
				{
					connection.Open();
					return (int)command.ExecuteScalar();
				}
		}





		public string GetSongs(int pageNumber, int pageSize)
		{
			//Typically, We should not expose sensitive columns like the artistID  etc. 
			string query = "SELECT * FROM Song ORDER BY title OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

			int offset = (pageNumber - 1) * pageSize;

			using (var connection = new SqlConnection(connectionString))
			using (var command = new SqlCommand(query, connection))
			{
				command.Parameters.AddWithValue("@Offset", offset);
				command.Parameters.AddWithValue("@PageSize", pageSize);

				connection.Open();

				DataTable dataTable = new DataTable();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					dataTable.Load(reader);
				}

				string DatarTable = JsonConvert.SerializeObject(dataTable);
				return DatarTable;
			}
		}






	}

}

