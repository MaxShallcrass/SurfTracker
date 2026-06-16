using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurfTrackerBackend.Models.Domain;

namespace SurfTrackerBackend.Data.Configurations;

public class SurfSessionWeatherConfiguration : IEntityTypeConfiguration<SurfSessionWeather>
{
    public void Configure(EntityTypeBuilder<SurfSessionWeather> entity)
    {
        entity.HasKey(w => w.SurfSessionWeatherId);

        entity.Property(w => w.Time)
            .HasColumnType("datetime2")
            .IsRequired();

        entity.Property(w => w.Temperature2m).HasColumnType("decimal(5,2)");
        entity.Property(w => w.WindSpeed10m).HasColumnType("decimal(5,2)");
        entity.Property(w => w.UvIndex).HasColumnType("decimal(5,2)");
        entity.Property(w => w.Precipitation).HasColumnType("decimal(5,2)");

        entity.HasIndex(w => new { w.SurfSessionId, w.Time }).IsUnique();

        entity.HasOne(w => w.SurfSession)
            .WithMany(ss => ss.WeatherRecords)
            .HasForeignKey(w => w.SurfSessionId)
            .IsRequired();
    }
}
