using Microsoft.EntityFrameworkCore;
using scooters.Entities.Models;

namespace scooters.Entities;
public class Context : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<City>? Cities { get; set; }
    public DbSet<Scooter>? Scooters { get; set; }
    public DbSet<Booking>? Bookings { get; set; }
    public DbSet<Penalty>? Penalties { get; set; }
    public DbSet<UserPenalty>? UserPenalties { get; set; }
    public DbSet<Admin>? Admins { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
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