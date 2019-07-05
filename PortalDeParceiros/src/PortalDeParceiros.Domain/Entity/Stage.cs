using System.Collections.Generic;

namespace PortalDeParceiros.Domain.Entity
{
    public class Stage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Proposal> Proposal { get; set; }
    }
}