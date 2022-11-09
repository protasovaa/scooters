namespace scooters.Entities.Models;
public class Admin : BaseEntity
{
    public string? Login { get; set; }
    public string? PasswordHash { get; set; }   
}