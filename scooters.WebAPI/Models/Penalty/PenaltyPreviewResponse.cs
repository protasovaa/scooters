namespace scooters.WebAPI.Models;
public class PenaltyPreviewResponse
{
    public Guid Id{get;set;}
    public string? TypePenalty { get; set; }
    public int AmountPenalty { get; set; }
}