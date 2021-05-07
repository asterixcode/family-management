using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Models {
public class Person {
    
    public int Id { get; set; }
    
    [Required, MaxLength(32)]
    public string FirstName { get; set; }
    
    [Required, MaxLength(32)]
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