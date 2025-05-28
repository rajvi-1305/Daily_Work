using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Users.Models;
using Users.Services;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            List<User> users = _userService.GetUsers();
            if(users == null || users.Count == 0)
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
            else {
                return Ok(user);
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
