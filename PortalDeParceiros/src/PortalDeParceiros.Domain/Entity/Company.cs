using System;
using System.Collections.Generic;

namespace PortalDeParceiros.Domain.Entity
{
    public class Company
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public string Observation { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt{ get; set; }
        public DateTime LastUpdate { get; set; }
        public bool FirstAcess { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public int? UserCommercialId { get; set; }
        public virtual User UserCommercial { get; set; }
    }
}