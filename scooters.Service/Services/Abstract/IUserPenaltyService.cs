using scooters.Services.Models;
namespace scooters.Services.Abstract;

public interface IUserPenaltyService
{
UserPenaltyModel GetUserPenalty(Guid id);

UserPenaltyModel UpdateUserPenalty(Guid id, UpdateUserPenaltyModel UserPenaltyModel);

void DeleteUserPenalty(Guid id);

PageModel<UserPenaltyPreviewModel> GetUserPenaltys(int limit = 20, int offset = 0);
UserPenaltyModel CreateUserPenalty(CreateUserPenaltyModel UserPenaltyModel);
}
