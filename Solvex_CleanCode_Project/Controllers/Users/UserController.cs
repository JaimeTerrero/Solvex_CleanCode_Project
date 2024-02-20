using Microsoft.AspNetCore.Mvc;
using VirtPlatform.Application.Users.DTOs;
using VirtPlatform.Application.Users.Interfaces;
using VirtPlatform.Application.Users.Services;
using VirtPlatform.Infrastructure.Repositories.Users;

namespace Solvex_CleanCode_Project.Controllers.Users
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var user = await _userService.GetAll();

            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(SignUp signUp)
        {
            var user = await _userService.Register(signUp);

            return Ok(user);
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult> AuthenticateUser(LogIn logIn)
        {
            var user = await _userService.Authenticate(logIn);

            return Ok(user);
        }

        [HttpGet("GetUserById/{id:int}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _userService.GetById(id);

            return Ok(user);
        }

        [HttpPut("UpdateUser/{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, UserDto userDto)
        {
            await _userService.Update(id, userDto);

            return NoContent();
        }

        [HttpDelete("DeleteUser/{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.Delete(id);

            return NoContent();
        }
    }
}
