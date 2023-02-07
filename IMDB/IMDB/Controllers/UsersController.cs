using IMDB.Models.DTOs.Users;
using IMDB.Models;
using IMDB.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using BCryptNet = BCrypt.Net.BCrypt;
using IMDB.Helpers.Attributes;
using IMDB.Models.Enums;

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
        public async Task<IActionResult> Authenticate(UserRequestDTO user)
        {
            var response = _userService.Authenticate(user);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok();
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

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO newUser)
        {
            var userToCreate = new User
            {
                Id = Guid.NewGuid(),
                Username = newUser.Username,
                Email = newUser.Email,
                PasswordHash = BCryptNet.HashPassword(newUser.Password),
                RoleName = Role.Admin
            };

            await _userService.Create(userToCreate);
            return Ok();
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
                    PasswordHash = BCryptNet.HashPassword(newUser.Password),
                    RoleName = Role.User
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

        [Authorization(Role.User)]
        [HttpGet("user")]
        public IActionResult GetAllUser()
        {
            return Ok("User");
        }

        [Authorization(Role.Admin)]
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllAdmin()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPut]
        public IActionResult Update(User updatedUser)
        {
            _userService.Update(updatedUser);
            return Ok();
        }
        [Authorization(Role.Admin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            var userFound = _userService.GetById(Id);
            if (userFound == null)
            {
                return BadRequest("The ID does not exist.");
            }
            _userService.Delete(userFound);
            if (_userService.Save() == false)
            {
                return BadRequest("Database error.");
            }
            return Ok();
        }
    }
}
