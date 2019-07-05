using System.Collections.Generic;
using System.Threading.Tasks;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Dto.Model;
using PortalDeParceiros.Infrastructure.IRepository;

namespace PortalDeParceiros.Application.Service
{
    public class PermissionService : IPermissionService
    {
        public readonly IPermissionRepository _repository;

        public PermissionService(IPermissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PermissionDto>> GetPermissions(bool novi)
        {
            return await _repository.GetPermissions(!novi);
        }

        public Task<PermissionDto> GetPermission(int id)
        {
            return _repository.GetPermission(id);
        }
    }
}