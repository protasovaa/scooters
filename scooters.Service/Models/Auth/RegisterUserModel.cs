using scooters.Entities.Models;
namespace scooters.Services.Models;
public class RegisterUserModel
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    // public Role Role { get; set; }
    public string? Number { get; set; }
    public string? FirstName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Login { get; set; }
    public bool Is_bloked { get; set; } 
   
}