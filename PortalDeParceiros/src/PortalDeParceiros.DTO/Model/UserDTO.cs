using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalDeParceiros.Dto.Model
{
    public class UserDto
    {
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        [MaxLength(150, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string Email { get; set; }
        [MaxLength(255, ErrorMessage="Limite máximo de {1} caracteres excedido para o nome do usuário.")]
        public string Name { get; set; }
        [MaxLength(11, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string Cpf { get; set; }
        [MaxLength(255, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string Password { get; set; }
        [MaxLength(255, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string ConfirmPassword { get; set; }
        [MaxLength(30, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string Phone { get; set; }
        [MaxLength(255, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string City { get; set; }
        [MaxLength(255, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string State { get; set; }
        [MaxLength(8, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string Cep { get; set; }
        [MaxLength(255, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string Observation { get; set; }
        public bool Status { get; set; }
        public bool FirstAccessCompany { get; set; }
        public bool ChangedPassword { get; set; }
        public bool Novi { get; set; }
        public int? CompanyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public int? UserLeaderIdDto { get; set; }
        public string Token { get; set; }
        public virtual UserDto UserLeaderDto { get; set; }
        public ICollection<UserPermissionDto> UserPermissionsDto { get; set; }
        public EmailDto EmailDto { get; set; } 
    }
}