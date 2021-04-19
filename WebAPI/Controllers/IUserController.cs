using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace WebAPI.Controllers
{
    public interface IUserController
    {
        Task<ActionResult<User>> ValidateUserAsync([FromQuery] string username, [FromQuery] string password);

        Task<ActionResult<User>> RegisterUser([FromBody] User user);
        
        Task<ActionResult<User>> EditUser([FromBody] User user);
        Task<ActionResult<User>> DeleteUser([FromBody] int userId);
    }
}