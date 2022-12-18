using AutoMapper;
using scooters.Entities.Models;
using scooters.Repository;
using scooters.Services.Abstract;
using scooters.Services.Models;

namespace scooters.Services.Implementation;

public class ScooterService :IScooterService
{
private readonly IRepository<Scooter> ScooterRepository;
private readonly IMapper mapper;
public ScooterService(IRepository<Scooter> ScooterRepository, IMapper mapper)
{
this.ScooterRepository=ScooterRepository;
this.mapper = mapper;
}

public void DeleteScooter(Guid id)
{
var ScooterToDelete =ScooterRepository.GetById(id);
if (ScooterToDelete == null)
{
throw new Exception("Scooter not found");
}
ScooterRepository.Delete(ScooterToDelete);
}

public ScooterModel GetScooter(Guid id)
{
var Scooter =ScooterRepository.GetById(id);
return mapper.Map<ScooterModel>(Scooter);
}

public PageModel<ScooterPreviewModel> GetScooters(int limit = 20, int offset = 0)
{
var Scooter =ScooterRepository.GetAll();
int totalCount =Scooter.Count();
var chunk=Scooter.OrderBy(x=>x.Address).Skip(offset).Take(limit);

return new PageModel<ScooterPreviewModel>()
{
Items = mapper.Map<IEnumerable<ScooterPreviewModel>>(Scooter),
TotalCount = totalCount
};
}

public ScooterModel UpdateScooter(Guid id, UpdateScooterModel Scooter)
{
var existingScooter = ScooterRepository.GetById(id);
if (existingScooter == null)
{
throw new Exception("Scooter not found");
}
existingScooter.Address=Scooter.Address;
existingScooter.Price=Scooter.Price;
existingScooter = ScooterRepository.Save(existingScooter);
return mapper.Map<ScooterModel>(existingScooter);
}
public ScooterModel CreateScooter(Guid CityId,ScooterModel ScooterModel)
    {
      if(ScooterRepository.GetAll(x=>x.Id==ScooterModel.Id).FirstOrDefault()!=null)
      {
        throw new Exception ("Attempt to create a non-unique object!");
      }
      
        ScooterModel createScooter = new ScooterModel();
        createScooter.CityId=ScooterModel.CityId;
        createScooter.Address=ScooterModel.Address;
        createScooter.IsBooking=ScooterModel.IsBooking;
        createScooter.Price=ScooterModel.Price;
        ScooterRepository.Save(mapper.Map<Scooter>(createScooter));
        return createScooter;

    }
}