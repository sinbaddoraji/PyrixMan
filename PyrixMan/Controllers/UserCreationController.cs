using Microsoft.AspNetCore.Mvc;
using PyrixMan.Helpers.Implementation;
using PyrixMan.Helpers.Interface;
using PyrixMan.Model;

namespace PyrixMan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserCreationController (IUserCreator userCreator) : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateUser([FromBody] User user)
        {
            // TODO: Hash password with AES256....
            // TODO: Create User creation DTO


            bool userExists = userCreator.UserExists(user.Email);
            if (!userExists)
            {
                //user.Id = Guid.NewGuid().ToString();
                bool created = userCreator.CreateUser(user);
                if (created)
                {
                    return Ok("User created successfully");
                }
                else
                {
                    return BadRequest("Failed to create user");
                }
            }
            else
            {
                return BadRequest("User already exists");
            }
        }
        
    }
}
