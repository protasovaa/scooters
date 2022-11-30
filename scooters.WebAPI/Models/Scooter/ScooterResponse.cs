namespace scooters.WebAPI.Models;
public class ScooterResponse
{
    public Guid Id{get;set;}
    public string? Address { get; set; }
    public bool IsBooking { get; set; }
    public Guid CityId { get; set; }
    public int Price { get; set; }
}