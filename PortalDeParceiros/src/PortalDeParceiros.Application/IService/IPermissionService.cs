using System.Collections.Generic;
using System.Threading.Tasks;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Application.IService
{
    public interface IPermissionService
    {
        Task<List<PermissionDto>> GetPermissions(bool novi);
        Task<PermissionDto> GetPermission(int id);
    }
}