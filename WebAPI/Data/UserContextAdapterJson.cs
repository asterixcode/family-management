using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Data
{
    public class UserContextAdapterJson : IUserContextAdapter
    {
        private FileContext FileContext = new FileContext();

        
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            return FileContext.ValidateUser(username, password);
        }

        public async Task RegisterUser(User user)
        {
            FileContext.RegisterUser(user);
        }

        public async Task EditUser(User user)
        {
            FileContext.EditUser(user);
        }

        public async Task DeleteUser(int id)
        {
            FileContext.DeleteUser(id);
        }
        
    }
}