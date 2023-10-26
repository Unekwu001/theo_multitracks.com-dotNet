using API_with_EntityFramework.Core.Service;
using API_with_EntityFramework.Data.DTOs;
using API_with_EntityFramework.Data.Entities;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace API_with_EntityFramework.Core.Implementation
{
    public class ArtistImplementation : ArtistServices
    {
        private readonly IDbConnection _connection;

        public ArtistImplementation(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }


        public async Task<Artist> AddArtistAsync(AddArtistDto addArtistDto)
        {
            var artist = new Artist()
            {
                Title = addArtistDto.Title,
                Biography = addArtistDto.Biography,
                HeroUrl = addArtistDto.HeroUrl,
                ImageUrl = addArtistDto.ImageUrl,
                DateCreation = DateTime.Now,
            };
            var sql = "INSERT INTO Artist (Title, Biography, HeroUrl, ImageUrl, DateCreation) " +
             "VALUES (@Title, @Biography, @HeroUrl, @ImageUrl, @DateCreation); " +
             "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var artistId = await _connection.QuerySingleAsync<int>(sql, artist);

            artist.ArtistId = artistId;
            return artist;

        }



        public async Task<IEnumerable<object>> SearchArtistByNameAsync(SearchArtistDto searchArtistDto)
        {
            var sql = "SELECT Title, Biography, HeroUrl, ImageUrl " +
              "FROM Artist " +
              "WHERE LOWER(Title) LIKE @ArtistName";

            var artists = await _connection.QueryAsync(sql, new { ArtistName = "%" + searchArtistDto.ArtistName.ToLower() + "%" });
            return artists;
        }




    }
}
