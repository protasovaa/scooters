namespace scooters.Entities.Models;
public class UserPenalty : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
    public Guid PenaltyId { get; set; }
    public virtual Penalty? Penalty { get; set; }
    public bool IsPaidFor { get; set; }
}