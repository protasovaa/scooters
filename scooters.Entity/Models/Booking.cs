namespace scooters.Entities.Models;
public class Booking : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
    public Guid ScooterId { get; set; }
    public virtual Scooter? Scooter { get; set; }
    public DateTime TimeOfBooking { get; set; }
    public DateTime TimeOfStart { get; set; }
    public DateTime TimeOfFinish { get; set; }
}