using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Configuration
{
    public class ProposalDocumentConfigurations : IEntityTypeConfiguration<ProposalDocument>
    {
        public void Configure(EntityTypeBuilder<ProposalDocument> builder)
        {
            builder.ToTable("proposalDocument");
            builder.HasKey("Id");
            builder.Property(x => x.Id)
                .UseNpgsqlIdentityColumn<int>()
                .ValueGeneratedOnAdd();
            builder
           .HasOne(x => x.Proposals)
           .WithMany(x => x.ProposalDocuments);
            builder.Property(x => x.DocumentPath)
                .IsRequired()
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
        }
    }
}