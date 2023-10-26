using API_with_EntityFramework.Data.DTOs;
using API_with_EntityFramework.Data.Entities;

namespace API_with_EntityFramework.Core.Service
{
    public interface SongServices
    {
        Task<List<object>> GetAllSongsAsync(GetAllSongsDto getAllSongsDto);
    }
}
