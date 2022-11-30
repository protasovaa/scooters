using scooters.Entities.Models;
namespace scooters.Services.Models;
public class PenaltyModel:BaseModel
{
    public Guid Id{get;set;}
    public string? TypePenalty { get; set; }
    public int AmountPenalty { get; set; }
}