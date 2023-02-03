using IMDB.Models.DTOs.Users;
using IMDB.Models;
using IMDB.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using BCryptNet = BCrypt.Net.BCrypt;

namespace IMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public UserResponseDTO Authenticate(UserRequestDTO user)
        {
            return _userService.Authenticate(user);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public User GetById(int id)
        {
            return _userService.GetById(id);
        }

        [HttpPost("user-create")]
        public async Task<IActionResult> CreateUser( UserRequestDTO newUser)
        {
            try
            {
                await _userService.Create(new User
                {
                    Id = Guid.NewGuid(),
                    Username = newUser.Username,
                    Email = newUser.Email,
                    PasswordHash = BCryptNet.HashPassword(newUser.Password)
                });
                if (_userService.Save())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(User updatedUser)
        {
            _userService.Update(updatedUser);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            _userService.Delete(Id);
            return Ok();
        }
    }
}
