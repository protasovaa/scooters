namespace scooters.Entities.Models;

public class User : BaseEntity
{
    public string? Number { get; set; }
    public string? FirstName { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid CityId { get; set; }
    public virtual City? City { get; set; }
    public string? Login { get; set; }
    public string? PasswordHash { get; set; }
    public bool Is_bloked { get; set; } 
    public virtual ICollection<Booking>? Bookings { get; set; } 
    public virtual ICollection<UserPenalty>? UserPenalties { get; set; } 
}


