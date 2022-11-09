namespace scooters.Entities.Models;
public class Penalty : BaseEntity
{
    public string? TypePenalty { get; set; }
    public int AmountPenalty { get; set; }
    public virtual ICollection<UserPenalty>? UserPenalties { get; set; } 
}