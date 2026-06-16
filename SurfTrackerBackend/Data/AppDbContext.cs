using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SurfTrackerBackend.Models.Domain;

namespace SurfTrackerBackend.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<SurfSpot> SurfSpots => Set<SurfSpot>();
    public DbSet<Surfboard> Surfboards => Set<Surfboard>();
    public DbSet<SurfSession> SurfSessions => Set<SurfSession>();
    public DbSet<SurfSessionUserObservation> SurfSessionUserObservations => Set<SurfSessionUserObservation>();
    public DbSet<SurfSessionSwell> SurfSessionSwells => Set<SurfSessionSwell>();
    public DbSet<SurfSessionWeather> SurfSessionWeather => Set<SurfSessionWeather>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
