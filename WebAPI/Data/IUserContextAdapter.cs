using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IUserContextAdapter
    {
        
        Task<User> ValidateUserAsync(string username, string password);
        Task RegisterUser(User user);
        Task EditUser(User user);
        Task DeleteUser(int id);
        
        //User ValidateUser(string username, string password);
        //void EditUser(User user);
        //void DeleteUser(int userId);
        //int GetUserId(string username);
    }
}