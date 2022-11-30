
namespace scooters.Services.Models;
public class CreateUserPenaltyModel
{
    public Guid UserId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPaidFor { get; set; }
}