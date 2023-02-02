using IMDB.Helpers.Authorization;
using IMDB.Models;
using IMDB.Models.DTOs.Users;
using IMDB.Repositories.UserRepository;
using Microsoft.IdentityModel.Abstractions;

namespace IMDB.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IJwtUtils _jwtUtils;
        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }
        public User GetById(Object id)
        {
            return _userRepository.FindById(id);
        }

        public async Task Create(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }
        public void Update(User updatedUser)
        {
            _userRepository.Update(updatedUser);
        }
        public void Delete(object Id)
        {
            _userRepository.Delete(GetById(Id));
        }
        public bool Save()
        {
            return _userRepository.Save();
        }
        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = _userRepository.FindByUsername(model.Username) ;

            if (user == null)
            {
                return null;
            }

            var token = _jwtUtils.GenerateJwtToken(user);

            return new UserResponseDTO
            {
                UserId = user.Id,
                DirectorId = user.DirectorId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DirectorName = user.FavouriteDirector,
                UserPreferences = user.UserPreferences,
                Token = token
            };
        }
    }
}
