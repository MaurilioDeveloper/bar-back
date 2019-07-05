using System;

namespace PortalDeParceiros.Dto.Model
{
    public class UserPermissionDto
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public PermissionDto PermissionDto { get; set; }
        public UserDto UserDto { get; set; }
        public bool Status { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}