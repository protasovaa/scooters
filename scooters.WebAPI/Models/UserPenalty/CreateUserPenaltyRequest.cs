namespace scooters.WebAPI.Models;
public class CreateUserPenaltyRequest:UpdateUserPenaltyRequest
{
    public Guid PenaltyId{get;set;}
    public Guid UserId{get;set;}
}