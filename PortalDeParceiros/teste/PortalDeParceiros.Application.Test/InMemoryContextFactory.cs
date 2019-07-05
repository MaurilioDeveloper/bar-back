using Microsoft.EntityFrameworkCore;
using PortalDeParceiros.Infrastructure.Configuration.Context;
using System;

namespace PortalDeParceiros.Application.Test
{
    public static class InMemoryContextFactory
    {
        public static PortalParceiroDbContext Create()
        {
            var options = new DbContextOptionsBuilder<PortalParceiroDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;

            return new PortalParceiroDbContext(options);
        }
    }
}