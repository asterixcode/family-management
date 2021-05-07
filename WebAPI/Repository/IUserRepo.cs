using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface IUserRepo
    {
        Task<User> ValidateUserAsync(string username, string password);
        Task RegisterUserAsync(User user);
    }
}