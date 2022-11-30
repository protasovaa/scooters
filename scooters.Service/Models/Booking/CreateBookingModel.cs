
namespace scooters.Services.Models;
public class CreateBookingModel
{
    public Guid UserId { get; set; }
    public Guid ScooterId { get; set; }
    public DateTime TimeOfBooking { get; set; }
    public DateTime TimeOfStart { get; set; }
    public DateTime TimeOfFinish { get; set; }
}