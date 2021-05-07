using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class User
    {
        public int UserId { get; set; }
        
        [Required, MaxLength(32)]
        public string Username { get; set; }
        
        [Required, MaxLength(32)]
        public string Password { get; set; }


        public string Role { get; set; } = "user";
    }
}