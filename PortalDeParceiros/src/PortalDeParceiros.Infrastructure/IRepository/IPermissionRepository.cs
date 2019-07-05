using System.Collections.Generic;
using System.Threading.Tasks;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Infrastructure.IRepository
{
    public interface IPermissionRepository: IRepository<Permission, long>
    {
        Task<List<PermissionDto>> GetPermissions();
        Task<List<PermissionDto>> GetPermissions(bool parthner);
        Task<PermissionDto> GetPermission(int id);
    }
}