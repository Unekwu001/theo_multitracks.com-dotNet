using API_with_EntityFramework.Data.DTOs;
using API_with_EntityFramework.Data.Entities;

namespace API_with_EntityFramework.Core.Service
{
    public interface ArtistServices
    {
        Task<Artist> AddArtistAsync(AddArtistDto addArtistDto);
        Task<IEnumerable<object>> SearchArtistByNameAsync(SearchArtistDto searchArtistDto);
    }
}
