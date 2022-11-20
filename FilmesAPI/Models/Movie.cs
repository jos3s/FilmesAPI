using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Range(1,600)]
        public long Duration { get; set; }
    }
}
