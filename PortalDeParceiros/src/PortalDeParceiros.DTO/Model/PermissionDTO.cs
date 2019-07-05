using System;
using System.Collections.Generic;

namespace PortalDeParceiros.Dto.Model
{
    public class PermissionDto
    {
        public enum CodeTypes : int {
            AdmCreatUser = 1,
            AdmCreatCompany = 2,
            AdmEdtUser = 3,
            AdmEdtCompany = 4,
            AdmEdtPermission = 5
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool Partner { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<UserPermissionDto> UserPermissionsDto { get; set; }
        public GroupDto GroupDto { get; set; } 
        public int GroupIdDto { get; set; } 
    }
}