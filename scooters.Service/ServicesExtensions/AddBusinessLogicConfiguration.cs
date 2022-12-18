using scooters.Services.Abstract;
using scooters.Services.Implementation;
using scooters.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;
namespace scooters.Services;

public static partial class ServicesExtensions
{
public static void AddBusinessLogicConfiguration(this IServiceCollection services)
{
services.AddAutoMapper(typeof(ServicesProfile));
//services
services.AddScoped<IAdminService, AdminService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IBookingService, BookingService>();
services.AddScoped<ICityService, CityService>();
services.AddScoped<IPenaltyService, PenaltyService>();
services.AddScoped<IScooterService, ScooterService>();
services.AddScoped<IUserPenaltyService, UserPenaltyService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IAuthService, AuthService>();
}
}