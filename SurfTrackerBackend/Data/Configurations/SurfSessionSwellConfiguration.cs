using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurfTrackerBackend.Models.Domain;

namespace SurfTrackerBackend.Data.Configurations;

public class SurfSessionSwellConfiguration : IEntityTypeConfiguration<SurfSessionSwell>
{
    public void Configure(EntityTypeBuilder<SurfSessionSwell> entity)
    {
        entity.HasKey(s => s.SurfSessionSwellId);

        entity.ToTable("SurfSessionSwell");

        entity.Property(s => s.Time)
            .HasColumnType("datetime2")
            .IsRequired();

        entity.Property(s => s.WaveHeight).HasColumnType("decimal(5,2)");
        entity.Property(s => s.WavePeriod).HasColumnType("decimal(5,2)");
        entity.Property(s => s.SwellWaveHeight).HasColumnType("decimal(5,2)");
        entity.Property(s => s.SwellWavePeriod).HasColumnType("decimal(5,2)");
        entity.Property(s => s.WindWaveHeight).HasColumnType("decimal(5,2)");
        entity.Property(s => s.WindWavePeriod).HasColumnType("decimal(5,2)");
        entity.Property(s => s.SecondarySwellWaveHeight).HasColumnType("decimal(5,2)");
        entity.Property(s => s.SecondarySwellWavePeriod).HasColumnType("decimal(5,2)");
        entity.Property(s => s.SeaLevelHeightMsl).HasColumnType("decimal(5,2)");
        entity.Property(s => s.SeaSurfaceTemperature).HasColumnType("decimal(5,2)");
        entity.Property(s => s.OceanCurrentVelocity).HasColumnType("decimal(5,2)");

        entity.HasIndex(s => new { s.SurfSessionId, s.Time }).IsUnique();

        entity.HasOne(s => s.SurfSession)
            .WithMany(ss => ss.Swells)
            .HasForeignKey(s => s.SurfSessionId)
            .IsRequired();
    }
}
