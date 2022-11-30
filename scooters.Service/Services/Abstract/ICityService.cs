using scooters.Services.Models;
namespace scooters.Services.Abstract;

public interface ICityService
{
CityModel GetCity(Guid id);

CityModel UpdateCity(Guid id, UpdateCityModel CityModel);

void DeleteCity(Guid id);

PageModel<CityPreviewModel> GetCitys(int limit = 20, int offset = 0);
CityModel CreateCity(CityModel CityModel);
}
