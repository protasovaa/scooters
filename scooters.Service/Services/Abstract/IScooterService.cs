using scooters.Services.Models;
namespace scooters.Services.Abstract;

public interface IScooterService
{
ScooterModel GetScooter(Guid id);

ScooterModel UpdateScooter(Guid id, UpdateScooterModel ScooterModel);

void DeleteScooter(Guid id);

PageModel<ScooterPreviewModel> GetScooters(int limit = 20, int offset = 0);
ScooterModel CreateScooter(CreateScooterModel scooterModel);
}
