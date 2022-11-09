namespace scooters.Entities.Models;
public class City : BaseEntity
{
    public string? Name { get; set; }
    public virtual ICollection<User>? Users { get; set; }
    public virtual ICollection<Scooter>? Scooters { get; set; }
}