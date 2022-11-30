using AutoMapper;
using scooters.Entities.Models;
using scooters.Repository;
using scooters.Services.Abstract;
using scooters.Services.Models;

namespace scooters.Services.Implementation;

public class UserService :IUserService
{
private readonly IRepository<User> UserRepository;
private readonly IMapper mapper;
public UserService(IRepository<User> UserRepository, IMapper mapper)
{
this.UserRepository=UserRepository;
this.mapper = mapper;
}

public void DeleteUser(Guid id)
{
var UserToDelete =UserRepository.GetById(id);
if (UserToDelete == null)
{
throw new Exception("User not found");
}
UserRepository.Delete(UserToDelete);
}

public UserModel GetUser(Guid id)
{
var User =UserRepository.GetById(id);
return mapper.Map<UserModel>(User);
}

public PageModel<UserPreviewModel> GetUsers(int limit = 20, int offset = 0)
{
var User =UserRepository.GetAll();
int totalCount =User.Count();
var chunk=User.OrderBy(x=>x.Login).Skip(offset).Take(limit);

return new PageModel<UserPreviewModel>()
{
Items = mapper.Map<IEnumerable<UserPreviewModel>>(User),
TotalCount = totalCount
};
}

public UserModel UpdateUser(Guid id, UpdateUserModel User)
{
var existingUser = UserRepository.GetById(id);
if (existingUser == null)
{
throw new Exception("User not found");
}
existingUser.Login=User.Login;
existingUser.Number=User.Number;
existingUser.FirstName=User.FirstName;
existingUser.Email=User.Email;
existingUser.DateOfBirth=User.DateOfBirth;
existingUser.Is_bloked=User.Is_bloked;
existingUser = UserRepository.Save(existingUser);
return mapper.Map<UserModel>(existingUser);
}

}