using scooters.Entities.Models;
namespace scooters.Services.Models;
public class AdminModel:BaseModel
{
    public Guid Id{get;set;}
    public string Login{get;set;}
}