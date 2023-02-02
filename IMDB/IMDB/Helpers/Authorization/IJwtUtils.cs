using IMDB.Models;

namespace IMDB.Helpers.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
    }
}
