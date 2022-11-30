namespace scooters.WebAPI.Models;
public class BookingResponse
{
    public Guid Id{get;set;}
    public Guid UserId { get; set; }
    public Guid ScooterId { get; set; }
    public DateTime TimeOfBooking { get; set; }
    public DateTime TimeOfStart { get; set; }
    public DateTime TimeOfFinish { get; set; }
}