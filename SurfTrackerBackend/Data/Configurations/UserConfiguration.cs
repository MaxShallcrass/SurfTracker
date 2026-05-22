using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurfTrackerBackend.Models.Domain;

namespace SurfTrackerBackend.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(u => u.UserId);

        entity.Property(u => u.CognitoId)
            .IsRequired()
            .HasMaxLength(128);

        entity.HasIndex(u => u.CognitoId)
            .IsUnique();

        entity.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256);

        entity.Property(u => u.CreatedAt)
            .HasColumnType("datetime2");

        entity.Property(u => u.UpdatedAt)
            .HasColumnType("datetime2");
    }
}
