using API_with_EntityFramework.Core.Service;
using API_with_EntityFramework.Data.DTOs;
using API_with_EntityFramework.Data.Entities;
using API_with_EntityFramework.Data.MyMultitrackDbContext;
using Microsoft.EntityFrameworkCore;

namespace API_with_EntityFramework.Core.Implementation
{
    public class SongImplementation : SongServices
    {
        private readonly MultitrackDbContext _multitrackDbContext;

        public SongImplementation(MultitrackDbContext multitrackDbContext)
        {
            _multitrackDbContext = multitrackDbContext;
        }



        public async Task<List<object>> GetAllSongsAsync(GetAllSongsDto getAllSongsDto)
        {
            return await _multitrackDbContext.Songs
                .Skip((getAllSongsDto.PageNumber - 1) * getAllSongsDto.PageSize)
                .Take(getAllSongsDto.PageSize)
                .Select(song => new
                {
                    Title = song.Title
                    
                })
                .Cast<object>()
                .ToListAsync();
        }





    }
}
