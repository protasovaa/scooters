using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using scooters.Entities.Models;

namespace scooters.Entities;
public class Context : IdentityDbContext<User, UserRole, Guid>
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Penalties

        builder.Entity<Penalty>().ToTable("penalties");
        builder.Entity<Penalty>().HasKey(x => x.Id);

        #endregion

        #region Cities

        builder.Entity<City>().ToTable("cities");
        builder.Entity<City>().HasKey(x => x.Id);

        #endregion

        #region Admins

        builder.Entity<Admin>().ToTable("admins");
        builder.Entity<Admin>().HasKey(x => x.Id);

        #endregion

        #region Users
        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);
        builder.Entity<User>().HasOne(x => x.City)
                                    .WithMany(x => x.Users)
                                    .HasForeignKey(x => x.CityId)
                                    .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        builder.Entity<UserRole>().ToTable("user_roles");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");

        #endregion

        #region UserPenalties

        builder.Entity<UserPenalty>().ToTable("userPenalties");
        builder.Entity<UserPenalty>().HasKey(x => x.Id);
        builder.Entity<UserPenalty>().HasOne(x => x.User)
                                    .WithMany(x => x.UserPenalties)
                                    .HasForeignKey(x => x.UserId)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<UserPenalty>().HasOne(x => x.Penalty)
                                    .WithMany(x => x.UserPenalties)
                                    .HasForeignKey(x => x.PenaltyId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Scooters

        builder.Entity<Scooter>().ToTable("scooters");
        builder.Entity<Scooter>().HasKey(x => x.Id);
        builder.Entity<Scooter>().HasOne(x => x.City)
                                    .WithMany(x => x.Scooters)
                                    .HasForeignKey(x => x.CityId)
                                    .OnDelete(DeleteBehavior.Cascade);
    
        #endregion

        #region Bookings

        builder.Entity<Booking>().ToTable("bookings");
        builder.Entity<Booking>().HasKey(x => x.Id);
        builder.Entity<Booking>().HasOne(x => x.User)
                                    .WithMany(x => x.Bookings)
                                    .HasForeignKey(x => x.UserId)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Booking>().HasOne(x => x.Scooter)
                                    .WithMany(x => x.Bookings)
                                    .HasForeignKey(x => x.ScooterId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}