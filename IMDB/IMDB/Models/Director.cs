using IMDB.Models.AssociativeModels;
using IMDB.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Director : BaseEntity
    {
        [Required]
        public Guid DirectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Nationality { get; set; }

        //users who have this director as their favourite
        public ICollection<User>? Users { get; set; }

        //movies this director directed
        public ICollection<Movie> Movies { get; set; }
    }
}
