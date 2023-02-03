using IMDB.Models.Base;
using IMDB.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IMDB.Models
{
    public class User: BaseEntity
    {
        [Required, JsonIgnore]
        public Guid UserId { get; set; }
        public Guid DirectorId { get; set; }
        public UserPreferences? UserPreferences { get; set; }
        public Director? FavouriteDirector { get; set; }

        [Required, MinLength(6), MaxLength(128)]
        public string Username { get; set; }

        [Required, RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Ati introdus un email gresit!")]
        public string Email { get; set; }

        [Required, RegularExpression(@"^(?=.{1,50}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$")]
        public string? FirstName { get; set; }

        [Required, RegularExpression(@"^(?=.{1,50}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$")]
        public string? LastName { get; set; }

        [Required, RegularExpression(@"^((19[2-9][0-9])|(200[0-9]))$",ErrorMessage = "Nu indepliniti varsta necesara pentru a intra pe acest site!")]
        public int? Age { get; set; }

        [Required, JsonIgnore]
        public string PasswordHash { get; set; }
        public Role RoleName { get; set; }

    }
}
