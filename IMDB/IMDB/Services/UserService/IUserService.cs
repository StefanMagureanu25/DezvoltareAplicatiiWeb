using IMDB.Models;
using IMDB.Models.DTOs.Users;

namespace IMDB.Services.UserService
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserRequestDTO model);
        User GetById(Object id);
        Task Create(User newUser);
        Task<IEnumerable<User>> GetAllUsers();
        void Update(User updatedUser);
        void Delete(Object id);
        bool Save();
    }
}
