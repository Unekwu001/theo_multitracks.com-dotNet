using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AddArtistModel
    {
        [Required]
        public string Title { get; set; }
       
        public string Biography { get; set; }

        public string ImageURL { get; set; }

        public string HeroURL { get; set; }
    }
}

