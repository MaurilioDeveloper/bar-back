using System;
using Microsoft.EntityFrameworkCore;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Seed
{
    public class CompanySeed
    {
        public CompanySeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1, 
                    Cnpj = "32683621000103",
                    Description = "BARIGUI SERVICOS DE APOIO A ESCRITORIOS LTDA",
                    City = "Curitiba",
                    State = "PR",
                    Cep = "80250205",
                    Status = true,
                    CreatedAt = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    FirstAcess = true,
                    UserCommercial = null
                }
            );
        }
    }
}