using Microsoft.AspNetCore.Mvc;
using VirtPlatform.Application.DTOs;
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

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser(UserDto userDto)
        {
            var user = await _userService.Add(userDto);

            return Ok(user);
        }
    }
}
