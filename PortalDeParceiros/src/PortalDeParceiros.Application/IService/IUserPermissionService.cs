using System.Collections.Generic;
using System.Threading.Tasks;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Application.IService
{
    public interface IUserPermissionService
    {
        void UpSertUserPermission(UserDto user);
        Task<List<PermissionDto>> GetPermissionByUser(int userId);
        Task<PermissionDto> GetPermissionByIdIdUser(int id, int userId);
        Task<bool> HasPermissionByIdIdUser(int id, int userId);
        Task<bool>  ValidationPermission(PermissionDto.CodeTypes id, string userIdStr);
    }
}