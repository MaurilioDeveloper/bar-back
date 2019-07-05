using Microsoft.EntityFrameworkCore;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Seed
{
    public class GroupSeed
    {
        public GroupSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(
                new Group{Id = 1, Description = "Administrativo"},
                new Group{Id = 2, Description = "Comunicação"},
                new Group{Id = 3, Description = "Marketing"},
                new Group{Id = 4, Description = "Treinamento"},
                new Group{Id = 5, Description = "Financeiro"},
                new Group{Id = 6, Description = "Propostas"},
                new Group{Id = 7, Description = "Master"}
            );
        }
    }
}