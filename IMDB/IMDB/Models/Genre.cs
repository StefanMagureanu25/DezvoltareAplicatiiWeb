using IMDB.Models.AssociativeModels;
using IMDB.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Genre : BaseEntity
    {
        [Required]
        public Guid GenreId { get; set; }
        public ICollection<MovieGenre>? MovieGenre { get; set; }
    }
}
