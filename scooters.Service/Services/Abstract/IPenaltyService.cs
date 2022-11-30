using scooters.Services.Models;
namespace scooters.Services.Abstract;

public interface IPenaltyService
{
PenaltyModel GetPenalty(Guid id);

PenaltyModel UpdatePenalty(Guid id, UpdatePenaltyModel PenaltyModel);

void DeletePenalty(Guid id);

PageModel<PenaltyPreviewModel> GetPenaltys(int limit = 20, int offset = 0);
PenaltyModel CreatePenalty(PenaltyModel PenaltyModel);
}
