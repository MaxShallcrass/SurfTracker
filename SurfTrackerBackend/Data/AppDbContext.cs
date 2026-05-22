using Microsoft.EntityFrameworkCore;

namespace SurfTrackerBackend.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // DbSets will be added here as domain models are created.
    // Example: public DbSet<SurfSession> SurfSessions => Set<SurfSession>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
