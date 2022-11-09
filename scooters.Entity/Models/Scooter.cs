namespace scooters.Entities.Models;

public class Scooter : BaseEntity
{
    public string? Address { get; set; }
    public bool IsBooking { get; set; }
    public Guid CityId { get; set; }
    public virtual City? City { get; set; }
    public int Price { get; set; }
    public virtual ICollection<Booking>? Bookings { get; set; }
}