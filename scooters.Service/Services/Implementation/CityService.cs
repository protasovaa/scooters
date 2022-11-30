using AutoMapper;
using scooters.Entities.Models;
using scooters.Repository;
using scooters.Services.Abstract;
using scooters.Services.Models;

namespace scooters.Services.Implementation;

public class CityService :ICityService
{
private readonly IRepository<City> CityRepository;
private readonly IMapper mapper;
public CityService(IRepository<City> CityRepository, IMapper mapper)
{
this.CityRepository=CityRepository;
this.mapper = mapper;
}

public void DeleteCity(Guid id)
{
var CityToDelete =CityRepository.GetById(id);
if (CityToDelete == null)
{
throw new Exception("City not found");
}
CityRepository.Delete(CityToDelete);
}

public CityModel GetCity(Guid id)
{
var City =CityRepository.GetById(id);
return mapper.Map<CityModel>(City);
}

public PageModel<CityPreviewModel> GetCitys(int limit = 20, int offset = 0)
{
var City =CityRepository.GetAll();
int totalCount =City.Count();
var chunk=City.OrderBy(x=>x.Name).Skip(offset).Take(limit);

return new PageModel<CityPreviewModel>()
{
Items = mapper.Map<IEnumerable<CityPreviewModel>>(City),
TotalCount = totalCount
};
}

public CityModel UpdateCity(Guid id, UpdateCityModel City)
{
var existingCity = CityRepository.GetById(id);
if (existingCity == null)
{
throw new Exception("City not found");
}
existingCity.Name=City.Name;
existingCity = CityRepository.Save(existingCity);
return mapper.Map<CityModel>(existingCity);
}
CityModel ICityService.CreateCity(CityModel CityModel)
{
CityRepository.Save(mapper.Map<Entities.Models.City>(CityModel));
return CityModel;
}
}