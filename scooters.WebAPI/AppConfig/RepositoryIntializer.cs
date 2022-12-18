using System;
using scooters.Entities;
using scooters.Entities.Models;
using scooters.Services.Abstract;
using scooters.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace scooters.WebAPI.AppConfig;

public static class RepositoryInitializer
{
    public const string MASTER_ADMIN_EMAIL = "master@mail.ru";
    public const string MASTER_ADMIN_PASSWORD = "12345678";

    private static async Task CreateGlobalAdmin(IAuthService authService)
    {
        await authService.RegisterUser(new Services.Models.RegisterUserModel()
        {
            Email = MASTER_ADMIN_EMAIL,
            PasswordHash = MASTER_ADMIN_PASSWORD,
           // Role = Entity.Models.Role.Admin
        });
    }

    public static async Task InitializeRepository(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
           
            
            var userRepository = (IRepository<User>)scope.ServiceProvider.GetRequiredService(typeof(IRepository<User>));
            var user =  userRepository.GetAll().Where(x => x.Email == MASTER_ADMIN_EMAIL).FirstOrDefault();
            if (user == null)
            {
                var authService = (IAuthService)scope.ServiceProvider.GetRequiredService(typeof(IAuthService));
                await CreateGlobalAdmin(authService);
            }
        }
    }
}