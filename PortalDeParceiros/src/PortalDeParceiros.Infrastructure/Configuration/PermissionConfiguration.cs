using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("permission");
            builder.HasKey("Id");
            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("Varchar(255)")
                .HasMaxLength(255);
        }
    }
}