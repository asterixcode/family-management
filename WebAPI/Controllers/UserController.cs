using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repo;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserRepo _userRepository;

        public UserController(IUserRepo userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUserAsync([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                User validUser = await _userRepository.ValidateUserAsync(username, password);
                return Ok(validUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> RegisterUserAsync([FromBody] User user)
        {
            try
            {
                await _userRepository.RegisterUserAsync(user);
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