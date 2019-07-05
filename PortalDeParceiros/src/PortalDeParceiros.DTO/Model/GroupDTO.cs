using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalDeParceiros.Dto.Model
{
    public class GroupDto
    {
        public int Id { get; set; }
        [MaxLength(255, ErrorMessage="Limite máximo de {1} caracteres excedido.")]
        public string Description { get; set; }
        public ICollection<PermissionDto> PermissionsDto { get; set; }
    }
}