using scooters.Services.Models;
namespace scooters.Services.Abstract;

public interface IUserService
{
UserModel GetUser(Guid id);

UserModel UpdateUser(Guid id, UpdateUserModel UserModel);

void DeleteUser(Guid id);

PageModel<UserPreviewModel> GetUsers(int limit = 20, int offset = 0);

}
