using IMDB.Models.AssociativeModels;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Genre
    {
        [Required, Key]
        public Guid GenreId { get; set; }
        public ICollection<MovieGenre> MovieGenre { get; set; }
    }
}
