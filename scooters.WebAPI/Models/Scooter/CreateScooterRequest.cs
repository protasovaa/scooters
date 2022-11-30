namespace scooters.WebAPI.Models;
public class CreateScooterRequest: UpdateScooterRequest
{
    
    public Guid CityId { get; set; }
   
}