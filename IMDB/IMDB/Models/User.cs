using IMDB.Models.Base;
using IMDB.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IMDB.Models
{
    public class User: BaseEntity
    {
        [Required, MinLength(6), MaxLength(128)]
        public string Username { get; set; } = null!;

        [Required, RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Ati introdus un email gresit!")]
        public string Email { get; set; } = null!;

        [Required, RegularExpression(@"^(?=.{1,50}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$")]
        public string FirstName { get; set; } = null!;

        [Required, RegularExpression(@"^(?=.{1,50}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$")]
        public string LastName { get; set; } = null!;

        [Required, RegularExpression(@"^((19[2-9][0-9])|(200[0-9]))$",ErrorMessage = "Nu indepliniti varsta necesara pentru a intra pe acest site!")]
        public int Year { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; } = null!;

        public string? FavouriteActor { get; set; }

        public Role RoleName { get; set; }
    }
}
