using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurfTrackerBackend.Models.Domain;

namespace SurfTrackerBackend.Data.Configurations;

public class SurfSpotConfiguration : IEntityTypeConfiguration<SurfSpot>
{
    public void Configure(EntityTypeBuilder<SurfSpot> entity)
    {
        entity.HasKey(s => s.SurfSpotId);

        entity.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(s => s.Latitude)
            .HasColumnType("decimal(9,6)")
            .IsRequired();

        entity.Property(s => s.Longitude)
            .HasColumnType("decimal(9,6)")
            .IsRequired();

        entity.HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .IsRequired();
    }
}
