using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Models;
using UsersAPI.Services.Services.Interface;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("all")]
        public async Task<IActionResult> GetAllUsers([FromBody] FilterVM filterRequest)
        {
            var data = await _userService.GetAllUsers(filterRequest);
            return Ok(data);
        }

    }
}
