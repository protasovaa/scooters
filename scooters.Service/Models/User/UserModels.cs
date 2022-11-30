using scooters.Entities.Models;
namespace scooters.Services.Models;
public class UserModel:BaseModel
{
    public Guid Id{get;set;}
    public string? Number { get; set; }
    public string? FirstName { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid CityId { get; set; }
    public string? Login { get; set; }
    public bool Is_bloked { get; set; } 
}