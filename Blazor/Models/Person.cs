using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Blazor.Models {
public class Person {
    
    public int Id { get; set; }
    
    [Required, MaxLength(32)]
    public string FirstName { get; set; }
    
    [Required, MaxLength(32)]
    public string LastName { get; set; }
    
    public string HairColor { get; set; }
    
    public string EyeColor { get; set; }
   
    [Range(0, Int32.MaxValue, ErrorMessage = "Please enter a valid age.")]
    public int Age { get; set; }
    
    [Range(0, Int32.MaxValue, ErrorMessage = "Please enter a valid Weight.")]
    public float Weight { get; set; }
   
    [Range(0, Int32.MaxValue, ErrorMessage = "Please enter a valid Height.")]
    public int Height { get; set; }
    
    [Required]
    public string Sex { get; set; }
    
}
}