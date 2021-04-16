using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
        
    }
}