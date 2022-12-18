using scooters.Entities.Models;
namespace scooters.Services.Models;
public class UserPenaltyModel:BaseModel
{
    public Guid UserId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPaidFor { get; set; }
}