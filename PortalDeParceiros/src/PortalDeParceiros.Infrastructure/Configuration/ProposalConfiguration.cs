using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Configuration
{
    public class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            builder.ToTable("proposal");
            builder.HasKey("Id");
            builder.Property(x => x.Id)
                .UseNpgsqlIdentityColumn<int>()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)")
                .HasMaxLength(11);
            builder.Property(x => x.ClientName)
                .IsRequired()
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
        }
    }
}