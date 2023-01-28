using IMDB.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IMDB.Models
{
    public class Movies: BaseEntity
    {
        [Required]
        public string MovieName { get; set; }
    }
}
