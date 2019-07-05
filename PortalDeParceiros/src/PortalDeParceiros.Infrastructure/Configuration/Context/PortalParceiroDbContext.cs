using Microsoft.EntityFrameworkCore;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Infrastructure.Seed;

namespace PortalDeParceiros.Infrastructure.Configuration.Context
{
    public partial class PortalParceiroDbContext : DbContext
    {
        public PortalParceiroDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new ProposalConfiguration());
            modelBuilder.ApplyConfiguration(new ProposalDocumentConfigurations());
            modelBuilder.ApplyConfiguration(new StageConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserPermissionConfiguration());

            new GroupSeed(modelBuilder);
            new PermissionSeed(modelBuilder);
            new CompanySeed(modelBuilder);
            new UserSeed(modelBuilder);
            new UserPermissionSeed(modelBuilder);
        }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //override this method
        }
        
         public PortalParceiroDbContext(DbContextOptions<PortalParceiroDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Proposal> Proposal { get; set; }
        public virtual DbSet<ProposalDocument> ProposalDocument { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }
    }
}



