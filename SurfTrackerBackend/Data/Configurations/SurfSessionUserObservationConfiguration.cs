using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurfTrackerBackend.Models.Domain;

namespace SurfTrackerBackend.Data.Configurations;

public class SurfSessionUserObservationConfiguration : IEntityTypeConfiguration<SurfSessionUserObservation>
{
    public void Configure(EntityTypeBuilder<SurfSessionUserObservation> entity)
    {
        entity.HasKey(o => o.SurfSessionUserObservationId);

        entity.Property(o => o.Notes)
            .HasMaxLength(2000);

        entity.HasOne(o => o.SurfSession)
            .WithMany(s => s.UserObservations)
            .HasForeignKey(o => o.SurfSessionId)
            .IsRequired();
    }
}
