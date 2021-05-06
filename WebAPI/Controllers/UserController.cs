using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserContextAdapter _userContextAdapter;

        public UserController(IUserContextAdapter userContextAdapter)
        {
            this._userContextAdapter = userContextAdapter;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUserAsync([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                User validUser = await _userContextAdapter.ValidateUserAsync(username, password);
                return Ok(validUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {
            try
            {
                await _userContextAdapter.RegisterUser(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}