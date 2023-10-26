using System.ComponentModel.DataAnnotations;

namespace API_with_EntityFramework.Data.DTOs
{
    public class AddArtistDto
    {


        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Biography { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ImageUrl { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string HeroUrl { get; set; } 
    }
}
