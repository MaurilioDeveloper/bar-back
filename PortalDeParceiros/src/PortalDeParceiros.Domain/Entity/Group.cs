using System.Collections.Generic;

namespace PortalDeParceiros.Domain.Entity
{
    public class Group
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}