using IMDB.Models.AssociativeModels;
using IMDB.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IMDB.Models
{
    public class Movie: BaseEntity
    {
        public Guid MovieId { get; set; }
        public Guid DirectorId { get; set; }
        public Director? Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<MovieGenre>? MovieGenre { get; set; }
        public string? MovieTitle { get; set; }
        public string? MovieDescription { get; set; }

    }
}
