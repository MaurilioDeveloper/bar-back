using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("company");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseNpgsqlIdentityColumn<int>()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Description)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
            builder.Property(x => x.City)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
            builder.Property(x => x.State)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
            builder.Property(x => x.Cep)
                .HasColumnType("varchar(8)")
                .HasMaxLength(8);
            builder.Property(x => x.Observation)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
        }
    }
}