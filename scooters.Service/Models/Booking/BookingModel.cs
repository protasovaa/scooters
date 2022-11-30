using scooters.Entities.Models;
namespace scooters.Services.Models;
public class BookingModel:BaseModel
{
    public Guid Id{get;set;}
    public Guid UserId { get; set; }
    public Guid ScooterId { get; set; }
    public DateTime TimeOfBooking { get; set; }
    public DateTime TimeOfStart { get; set; }
    public DateTime TimeOfFinish { get; set; }
}