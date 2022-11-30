using AutoMapper;
using scooters.Entities.Models;
using scooters.Repository;
using scooters.Services.Abstract;
using scooters.Services.Models;

namespace scooters.Services.Implementation;

public class PenaltyService :IPenaltyService
{
private readonly IRepository<Penalty> PenaltyRepository;
private readonly IMapper mapper;
public PenaltyService(IRepository<Penalty> PenaltyRepository, IMapper mapper)
{
this.PenaltyRepository=PenaltyRepository;
this.mapper = mapper;
}

public void DeletePenalty(Guid id)
{
var PenaltyToDelete =PenaltyRepository.GetById(id);
if (PenaltyToDelete == null)
{
throw new Exception("Penalty not found");
}
PenaltyRepository.Delete(PenaltyToDelete);
}

public PenaltyModel GetPenalty(Guid id)
{
var Penalty =PenaltyRepository.GetById(id);
return mapper.Map<PenaltyModel>(Penalty);
}

public PageModel<PenaltyPreviewModel> GetPenaltys(int limit = 20, int offset = 0)
{
var Penalty =PenaltyRepository.GetAll();
int totalCount =Penalty.Count();
var chunk=Penalty.OrderBy(x=>x.TypePenalty).Skip(offset).Take(limit);

return new PageModel<PenaltyPreviewModel>()
{
Items = mapper.Map<IEnumerable<PenaltyPreviewModel>>(Penalty),
TotalCount = totalCount
};
}

public PenaltyModel UpdatePenalty(Guid id, UpdatePenaltyModel Penalty)
{
var existingPenalty = PenaltyRepository.GetById(id);
if (existingPenalty == null)
{
throw new Exception("Penalty not found");
}
existingPenalty.TypePenalty=Penalty.TypePenalty;
existingPenalty.AmountPenalty=Penalty.AmountPenalty;
existingPenalty = PenaltyRepository.Save(existingPenalty);
return mapper.Map<PenaltyModel>(existingPenalty);
}
PenaltyModel IPenaltyService.CreatePenalty(PenaltyModel PenaltyModel)
{
PenaltyRepository.Save(mapper.Map<Entities.Models.Penalty>(PenaltyModel));
return PenaltyModel;
}
}