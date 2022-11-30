using scooters.Entities.Models;
namespace scooters.Services.Models;
public class BookingPreviewModel
{
    public Guid Id{get;set;}
    public DateTime TimeOfBooking { get; set; }
    public DateTime TimeOfStart { get; set; }
    public DateTime TimeOfFinish { get; set; }
}