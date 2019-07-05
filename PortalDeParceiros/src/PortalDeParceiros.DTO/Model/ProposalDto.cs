using System;
using System.ComponentModel.DataAnnotations;

namespace PortalDeParceiros.Dto.Model
{
    public class ProposalDto
    {
        public int Id { get; set; }
        [MaxLength(11, ErrorMessage = "Limite máximo de {1} caracteres excedido.")]
        public string Cpf { get; set; }
        [MaxLength(255, ErrorMessage = "Limite máximo de {1} caracteres excedido.")]
        public string ClientName { get; set; }
        public decimal PropertyPrice { get; set; }
        public decimal CreditValue { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual StageDto StageId { get; set; }
        public virtual UserDto UsersDto { get; set; }
        
    }
}