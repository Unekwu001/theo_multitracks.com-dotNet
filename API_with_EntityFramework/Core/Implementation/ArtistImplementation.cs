using API_with_EntityFramework.Core.Service;
using API_with_EntityFramework.Data.DTOs;
using API_with_EntityFramework.Data.Entities;
using API_with_EntityFramework.Data.MyMultitrackDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API_with_EntityFramework.Core.Implementation
{
    public class ArtistImplementation : ArtistServices
    {
        private readonly MultitrackDbContext _multitrackDbContext;

        public ArtistImplementation(MultitrackDbContext multitrackDbContext)
        {
            _multitrackDbContext = multitrackDbContext;
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
            _multitrackDbContext.Artists.Add(artist);
            await _multitrackDbContext.SaveChangesAsync();
            return artist;
        }



        public async Task<IEnumerable<object>> SearchArtistByNameAsync(SearchArtistDto searchArtistDto)
        {
            var artists = await _multitrackDbContext.Artists
                .Where(artist => artist.Title.ToLower().Contains(searchArtistDto.ArtistName.ToLower()))
                .Select(artist => new
                {
                    artist.Title,
                    artist.Biography,
                    artist.HeroUrl,
                    artist.ImageUrl
                })
                .ToListAsync();

            return artists;
        }




    }
}
