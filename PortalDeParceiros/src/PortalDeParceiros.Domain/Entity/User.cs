using System;
using System.Collections.Generic;

namespace PortalDeParceiros.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public string Observation { get; set; }
        public bool Status { get; set; }
        public bool Novi { get; set; }
        public int? CompanyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public Company Company { get; set; } 
        public virtual int? UserLeaderId { get; set; }
        public virtual User UserLeader { get; set; }
        public bool ChangedPassword { get; set; }
        public ICollection<Proposal> Proposals { get; set; } 
        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}