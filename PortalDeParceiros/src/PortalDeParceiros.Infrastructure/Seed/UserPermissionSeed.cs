using System;
using Microsoft.EntityFrameworkCore;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Seed
{
    public class UserPermissionSeed
    {
        public UserPermissionSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermission>().HasData(
                new UserPermission{ UserId = 1, PermissionId = 1 , LastUpdate = DateTime.Now, CreatedAt = DateTime.Now },
                new UserPermission{ UserId = 1, PermissionId = 2 , LastUpdate = DateTime.Now, CreatedAt = DateTime.Now },
                new UserPermission{ UserId = 1, PermissionId = 3 , LastUpdate = DateTime.Now, CreatedAt = DateTime.Now },
                new UserPermission{ UserId = 1, PermissionId = 4 , LastUpdate = DateTime.Now, CreatedAt = DateTime.Now },
                new UserPermission{ UserId = 1, PermissionId = 5 , LastUpdate = DateTime.Now, CreatedAt = DateTime.Now }
            );
        }
    }
}