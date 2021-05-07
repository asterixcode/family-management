using System.Collections.Generic;

namespace WebAPI.Models {
public class Family {
    
    public int Id { get; set; }
    public int UserId { get; set; }
    public string StreetName { get; set; }
    public int HouseNumber{ get; set; }
    public List<Adult> Adults { get; set; }
    public List<Child> Children{ get; set; }
    public List<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>();
        Children = new List<Child>();
        Pets = new List<Pet>();
    }
}


}