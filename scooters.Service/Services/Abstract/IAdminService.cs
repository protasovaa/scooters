using scooters.Services.Models;
namespace scooters.Services.Abstract;

public interface IAdminService
{
AdminModel GetAdmin(Guid id);

AdminModel UpdateAdmin(Guid id, UpdateAdminModel adminModel);

void DeleteAdmin(Guid id);

PageModel<AdminPreviewModel> GetAdmins(int limit = 20, int offset = 0);
AdminModel CreateAdmin(AdminModel adminModel);
}
