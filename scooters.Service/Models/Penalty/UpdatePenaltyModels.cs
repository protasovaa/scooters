using scooters.Entities.Models;
namespace scooters.Services.Models;
public class UpdatePenaltyModel
{
    public string? TypePenalty { get; set; }
    public int AmountPenalty { get; set; }
}