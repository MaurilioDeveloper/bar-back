using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Configuration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("group");
            builder.HasKey("Id");
            builder.HasMany(x => x.Permissions);
            builder.Property(x => x.Id)
                .UseNpgsqlIdentityColumn<int>()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
        }
    }
}