using System.ComponentModel.DataAnnotations;

namespace IMDB.Models.DTOs.Users
{
    public class UserRequestDTO
    {
        [Required, MaxLength(100)]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        [Required, MaxLength(64)]
        public string Password { get; set; }
    }
}
