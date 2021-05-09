using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Persistence
{
    public interface IUserRepo
    {
        Task<User> ValidateUserAsync(string username, string password);
        Task RegisterUserAsync(User user);
    }
}