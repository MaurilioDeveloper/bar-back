using System.Collections.Generic;
using System.Threading.Tasks;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Infrastructure.IRepository
{
    public interface IUserPermissionRepository : IRepository<UserPermission, long>
    {
        Task<List<UserPermissionDto>> getUserPermissionByUser(int userId);
        Task<List<PermissionDto>> GetPermissionByUser(int userId);
        Task<PermissionDto> GetPermissionByIdIdUser(int id, int userId);
        Task<bool> HasPermissionByIdIdUser(int id, int userId);
    }
}