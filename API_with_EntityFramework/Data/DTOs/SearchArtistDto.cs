using System.ComponentModel.DataAnnotations;

namespace API_with_EntityFramework.Data.DTOs
{
    public class SearchArtistDto
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Prompt = "Enter artist name here")]
        public string ArtistName { get; set; }
    }
}
