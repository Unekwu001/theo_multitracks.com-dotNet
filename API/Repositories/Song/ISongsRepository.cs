using System.Data;

namespace API.Repositories.Song
{
	public interface ISongsRepository
	{
		int GetTotalSongCount();
		string GetSongs(int pageNumber, int pageSize);
		
	}
}
