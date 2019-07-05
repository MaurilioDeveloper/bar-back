using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Configuration
{
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.HasKey(x => new {x.UserId, x.PermissionId});
            builder.ToTable("userpermission");
            builder
                .HasOne(x => x.Permission)
                .WithMany(x => x.UserPermissions);
        }
    }
}