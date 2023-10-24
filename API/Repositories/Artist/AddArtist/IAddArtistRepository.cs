namespace API.Repositories.Artist.AddArtist
{
	public interface IAddArtistRepository
	{
		void AddArtist(string title, string biography, string imageURL, string heroURL);
	}
}
