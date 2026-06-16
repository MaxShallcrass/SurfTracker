using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurfTrackerBackend.Models.Domain;

namespace SurfTrackerBackend.Data.Configurations;

public class SurfboardConfiguration : IEntityTypeConfiguration<Surfboard>
{
    public void Configure(EntityTypeBuilder<Surfboard> entity)
    {
        entity.HasKey(s => s.SurfboardId);

        entity.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .IsRequired();
    }
}
