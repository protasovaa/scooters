using AutoMapper;
using scooters.Entities.Models;
using scooters.Repository;
using scooters.Services.Abstract;
using scooters.Services.Models;

namespace scooters.Services.Implementation;

public class UserPenaltyService :IUserPenaltyService
{
private readonly IRepository<UserPenalty> UserPenaltyRepository;
private readonly IMapper mapper;
public UserPenaltyService(IRepository<UserPenalty> UserPenaltyRepository, IMapper mapper)
{
this.UserPenaltyRepository=UserPenaltyRepository;
this.mapper = mapper;
}

public void DeleteUserPenalty(Guid id)
{
var UserPenaltyToDelete =UserPenaltyRepository.GetById(id);
if (UserPenaltyToDelete == null)
{
throw new Exception("UserPenalty not found");
}
UserPenaltyRepository.Delete(UserPenaltyToDelete);
}

public UserPenaltyModel GetUserPenalty(Guid id)
{
var UserPenalty =UserPenaltyRepository.GetById(id);
return mapper.Map<UserPenaltyModel>(UserPenalty);
}

public PageModel<UserPenaltyPreviewModel> GetUserPenaltys(int limit = 20, int offset = 0)
{
var UserPenalty =UserPenaltyRepository.GetAll();
int totalCount =UserPenalty.Count();
var chunk=UserPenalty.OrderBy(x=>x.IsPaidFor).Skip(offset).Take(limit);

return new PageModel<UserPenaltyPreviewModel>()
{
Items = mapper.Map<IEnumerable<UserPenaltyPreviewModel>>(UserPenalty),
TotalCount = totalCount
};
}

public UserPenaltyModel UpdateUserPenalty(Guid id, UpdateUserPenaltyModel UserPenalty)
{
var existingUserPenalty = UserPenaltyRepository.GetById(id);
if (existingUserPenalty == null)
{
throw new Exception("UserPenalty not found");
}
existingUserPenalty.IsPaidFor=UserPenalty.IsPaidFor;
existingUserPenalty = UserPenaltyRepository.Save(existingUserPenalty);
return mapper.Map<UserPenaltyModel>(existingUserPenalty);
}
UserPenaltyModel IUserPenaltyService.CreateUserPenalty(CreateUserPenaltyModel userPenaltyModel)
{
var userPenalty= mapper.Map<Entities.Models.UserPenalty>(userPenaltyModel);
return mapper.Map<UserPenaltyModel>(UserPenaltyRepository.Save(userPenalty));
}
}