using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}