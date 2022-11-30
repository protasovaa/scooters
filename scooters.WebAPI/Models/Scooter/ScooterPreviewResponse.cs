namespace scooters.WebAPI.Models;
public class ScooterPreviewResponse
{
    public Guid Id{get;set;}
    public string? Address { get; set; }
    public bool IsBooking { get; set; }
    public int Price { get; set; }
}