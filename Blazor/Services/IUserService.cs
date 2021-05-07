using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Services
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
        Task RegisterUser(User user);
        int GetUserId(string username);
    }
}