using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurfTrackerBackend.Models.Domain;

namespace SurfTrackerBackend.Data.Configurations;

public class SurfSessionConfiguration : IEntityTypeConfiguration<SurfSession>
{
    public void Configure(EntityTypeBuilder<SurfSession> entity)
    {
        entity.HasKey(s => s.SurfSessionId);

        entity.Property(s => s.StartTime)
            .HasColumnType("datetime2")
            .IsRequired();

        entity.Property(s => s.EndTime)
            .HasColumnType("datetime2")
            .IsRequired();

        entity.Property(s => s.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        entity.HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .IsRequired();

        entity.HasOne(s => s.Surfboard)
            .WithMany(b => b.SurfSessions)
            .HasForeignKey(s => s.SurfboardId)
            .IsRequired();

        entity.HasOne(s => s.SurfSpot)
            .WithMany(sp => sp.SurfSessions)
            .HasForeignKey(s => s.SurfSpotId)
            .IsRequired();
    }
}
