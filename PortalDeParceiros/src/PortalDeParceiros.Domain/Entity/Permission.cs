using System;
using System.Collections.Generic;

namespace PortalDeParceiros.Domain.Entity
{
    public class Permission
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Partner { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }
        public int? GroupId { get; set; } 
        public Group Group { get; set; } 
    }
}