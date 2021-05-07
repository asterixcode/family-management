using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required, MaxLength(32)]
        public string Username { get; set; }
        
        [Required, MaxLength(32)]
        public string Password { get; set; }


        public string Role { get; set; } = "user";
    }
}