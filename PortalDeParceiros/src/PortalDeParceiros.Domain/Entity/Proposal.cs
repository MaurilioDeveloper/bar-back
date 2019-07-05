using System;
using System.Collections.Generic;

namespace PortalDeParceiros.Domain.Entity
{
    public class Proposal
    {
        public int Id { get; set; } 
        public string Cpf { get; set; }
        public string ClientName { get; set; }
        public decimal PropertyPrice { get; set; }
        public decimal CreditValue { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public virtual User User { get; set; }
        public virtual Stage Stage { get; set; } 
        public virtual ICollection<ProposalDocument> ProposalDocuments { get; set; } 

    }
}