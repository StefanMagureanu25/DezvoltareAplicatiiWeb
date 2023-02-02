namespace IMDB.Models.DTOs.Users
{
    public class UserResponseDTO
    {
        public Guid UserId { get; set; }
        public Guid DirectorId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DirectorName { get; set; }
        public UserPreferences? UserPreferences { get; set; }
    }
}
