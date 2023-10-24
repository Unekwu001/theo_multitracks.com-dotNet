using System.Data;

namespace API.Repositories.Artist.SearchArtist
{
    public interface ISearchArtistRepository
    {
        string SearchArtistsFromDatabase(string name);

    }
}
