using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Configuration
{
    public class StageConfiguration : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder.ToTable("stage");
            builder.HasKey("Id");
            builder.HasMany(x => x.Proposal);
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