using API_with_EntityFramework.Core.Service;
using API_with_EntityFramework.Data.DTOs;
using API_with_EntityFramework.Data.Entities;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace API_with_EntityFramework.Core.Implementation
{
    public class SongImplementation : SongServices
    {
        private readonly IDbConnection _connection;

        public SongImplementation(string connectionString) 
        {
            _connection = new SqlConnection(connectionString);
        }



        public async Task<List<object>> GetAllSongsAsync(GetAllSongsDto getAllSongsDto)
        {
            var sql = "SELECT Title FROM Song " +
                      "ORDER BY artistID " + // Assuming you have an Id or another field to order by
                      "OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                Offset = (getAllSongsDto.PageNumber - 1) * getAllSongsDto.PageSize,
                PageSize = getAllSongsDto.PageSize
            };

            var songs = await _connection.QueryAsync(sql, parameters);
            return songs.Cast<object>().ToList();
        }






    }
}
