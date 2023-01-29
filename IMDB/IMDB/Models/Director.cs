using IMDB.Models.AssociativeModels;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Director
    {
        [Required]
        public Guid DirectorId { get; set; }
        public string? DirectorFirstName { get; set; }
        public string? DirectorLastName { get; set; }

        //users who have this director as their favourite
        public ICollection<User>? Users { get; set; }

        //movies this director directed
        public ICollection<Movie>? Movies { get; set; }
    }
}
