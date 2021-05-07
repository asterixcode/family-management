using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models {
public class Person {
    
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string HairColor { get; set; }
    [Required]
    public string EyeColor { get; set; }
   
    public int Age { get; set; }
    
    public float Weight { get; set; }
   
    public int Height { get; set; }
    [Required]
    public string Sex { get; set; }
    
    
}


}