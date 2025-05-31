using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Users.DataAccess.Models;
using Users.Dto;
using Users.Helper;
using Users.Services.Services;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtHelper _jwtHelper;

        public UserController(UserService userService, JwtHelper jwtHelper)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            List<User> users = _userService.GetUsers();
            if (users == null || users.Count == 0)
            {
                return NotFound("User Not Found");
            }
            else
            {
                return Ok(users);
            }
        }

        [HttpGet("id")]
        public ActionResult<List<User>> GetUser(int id)
        {
            User user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginReqDto dto)
        {
            var user = _userService.Login(dto.EmailAddress, dto.Password);

            if (user == null)
            {
                return NotFound("Please check your Email & Password");
            }

            var token = _jwtHelper.GetJwtToken(user);

            return Ok(new LoginResDto() { EmailAddress = user.EmailAddress, UserType = user.UserType, Token = token });
        }


        [HttpGet("usertype")]
        public ActionResult<List<User>> GetTypeUsers(string type)
        {
            List<User> users = _userService.GetType(type);
            if (users == null || users.Count == 0)
            {
                return NotFound("User Type Not Found");
            }
            else
            {
                return Ok(users);
            }
        }


        [HttpPost]
        public ActionResult AddUser(User book)
        {
            _userService.AddUser(book);
            return Ok("User Cretaed successfully");
        }

        [HttpPut]
        public ActionResult UpdateUserDetails(User userUpdate)
        {
            int userStatus = _userService.UpdateUser(userUpdate);
            if (userStatus == -1)
            {
                return NotFound("User Not Found");
            }
            else if (userStatus == 1)
            {
                return Ok("User Details updated successfully");
            }
            else
            {
                return BadRequest("Bad request");
            }
        }

        [HttpDelete]
        public ActionResult DeleteUserDetails(int id)
        {
            int deleteStatus = _userService.DeleteUser(id);
            if (deleteStatus == -1)
            {
                return NotFound("User Not found");
            }
            else if (deleteStatus == 1)
            {
                return Ok("User Details Deleted Successfully");
            }
            else
            {
                return BadRequest("Bad request");
            }
        }
    }
}
