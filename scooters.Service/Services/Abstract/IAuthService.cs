using scooters.Services.Models;
using IdentityModel.Client;
namespace scooters.Services.Abstract;
public interface IAuthService
{
    Task<UserModel> RegisterUser(RegisterUserModel model);
    Task<TokenResponse> LoginUser(LoginUserModel model);
}