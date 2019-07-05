using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalDeParceiros.Dto.Model
{
    public class CompanyDto
    {
        public int Id { get; set; }
        [MaxLength(14, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string Cnpj { get; set; }
        [MaxLength(255, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string Description { get; set; }
        [MaxLength(255, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string City { get; set; }
        [MaxLength(255, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string State { get; set; }
        [MaxLength(8, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string Cep { get; set; }
        [MaxLength(255, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string Observation { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt{ get; set; }
        public DateTime LastUpdate { get; set; }
        public bool FirstAcess { get; set; }
        public virtual ICollection<UserDto> UsersDto { get; set; }
        public int? UserCommercialId { get; set; }
    }
}