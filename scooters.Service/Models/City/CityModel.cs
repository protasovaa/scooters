using scooters.Entities.Models;
namespace scooters.Services.Models;
public class CityModel:BaseModel
{
    public Guid Id{get;set;}
    public string? Name { get; set; }
}