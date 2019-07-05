using System;

namespace PortalDeParceiros.Domain.Entity
{
    public class UserPermission
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        public User User { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}