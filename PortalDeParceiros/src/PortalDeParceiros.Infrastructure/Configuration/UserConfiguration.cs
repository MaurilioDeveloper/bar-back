using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseNpgsqlIdentityColumn<int>()
                .ValueGeneratedOnAdd();
            builder
                .HasOne(x => x.Company)
                .WithMany(x => x.Users);
            builder
                .HasMany(x => x.Proposals);
            builder
                .HasMany(x => x.UserPermissions);    
            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
            builder.Property(x => x.Cpf)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11);
            builder.Property(x => x.Password)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
        }
    }
}