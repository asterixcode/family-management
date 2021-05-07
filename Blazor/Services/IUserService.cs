using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Services
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);

        Task RegisterUser(User user);
        //void EditUser(User user);
        //void DeleteUser(int userId);
        int GetUserId(string username);
    }
}