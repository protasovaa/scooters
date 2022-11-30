using scooters.Entities.Models;
namespace scooters.Services.Models;
public class ScooterPreviewModel
{
    public Guid Id{get;set;}
    public string? Address { get; set; }
    public bool IsBooking { get; set; }
    public int Price { get; set; }
}