namespace scooters.WebAPI.Models;
public class CreateBookingRequest: UpdateBookingRequest
{
    public Guid UserId { get; set; }
    public Guid ScooterId { get; set; }
    
}