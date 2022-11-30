namespace scooters.WebAPI.Models;
public class UserPenaltyPreviewResponse
{
      public Guid PenaltyId{get;set;}
     public Guid UserId{get;set;}
    public bool IsPaidFor { get; set; }
}