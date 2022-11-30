
namespace scooters.Services.Models;
public class CreateScooterModel
{
   
    public string? Address { get; set; }
    public bool IsBooking { get; set; }
    public Guid CityId { get; set; }
    public int Price { get; set; }
}