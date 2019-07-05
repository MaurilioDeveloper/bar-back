using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;
using PortalDeParceiros.Infrastructure.IRepository;

namespace PortalDeParceiros.Application.Service
{
    public class UserPermissionService : IUserPermissionService
    {
        public readonly IUserPermissionRepository _repository;
        private readonly IMapper _mapper;
        public UserPermissionService(IUserPermissionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public Task<List<PermissionDto>> GetPermissionByUser(int userId)
        {
            return _repository.GetPermissionByUser(userId);
        }
        public Task<PermissionDto> GetPermissionByIdIdUser(int id, int userId)
        {
            return _repository.GetPermissionByIdIdUser(id, userId);
        }
        public Task<bool> HasPermissionByIdIdUser(int id, int userId)
        {
            return _repository.HasPermissionByIdIdUser(id, userId);
        }

        public Task<bool> ValidationPermission(PermissionDto.CodeTypes id, string userIdStr)
        {
            int userId = 0;

            int.TryParse(userIdStr, out userId);

            return _repository.HasPermissionByIdIdUser((int)id, userId);
        }
        public void UpSertUserPermission(UserDto user)
        {
            var userPermissions = _repository.getUserPermissionByUser(user.Id).Result;
            var permissions = user.UserPermissionsDto.Select(p => p.PermissionId).ToArray();

            userPermissions
                .ForEach(u =>
                {
                    if(!permissions.Contains(u.PermissionId))
                    {
                        u.Status = false;
                        u.LastUpdate = DateTime.Now;
                        _repository.UpdateAsync(_mapper.Map<UserPermission>(u));
                    }
                    else if(permissions.Contains(u.PermissionId) && !u.Status)
                    {
                        u.Status = true;
                        u.LastUpdate = DateTime.Now;
                        _repository.UpdateAsync(_mapper.Map<UserPermission>(u));
                    }
                }
            );

            permissions
                .Where(p => !userPermissions
                        .Select(up => up.PermissionId)
                        .Contains(p))
                .Select(p => p)
                .ToList()
                .ForEach(p =>
                {
                    _repository.Insert(
                        _mapper.Map<UserPermission>(new UserPermissionDto
                        {
                            UserId = user.Id,
                            PermissionId = p,
                            LastUpdate = DateTime.Now,
                            CreatedAt = DateTime.Now,
                            Status = true                        
                        })
                    );
                });
        }
    }
}