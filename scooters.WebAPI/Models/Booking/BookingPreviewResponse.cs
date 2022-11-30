namespace scooters.WebAPI.Models;
public class BookingPreviewResponse
{
    public Guid Id{get;set;}
    public DateTime TimeOfBooking { get; set; }
    public DateTime TimeOfStart { get; set; }
    public DateTime TimeOfFinish { get; set; }
}