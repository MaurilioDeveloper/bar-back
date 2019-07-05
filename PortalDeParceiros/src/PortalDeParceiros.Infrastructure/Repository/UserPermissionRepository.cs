using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;
using PortalDeParceiros.Infrastructure.Configuration.Context;
using PortalDeParceiros.Infrastructure.IRepository;

namespace PortalDeParceiros.Infrastructure.Repository
{
    public class UserPermissionRepository : Repository<UserPermission, long>, IUserPermissionRepository
    {
        private readonly IMapper _mapper;
        private readonly PortalParceiroDbContext _context;

        public UserPermissionRepository(IMapper mapper, PortalParceiroDbContext context) : base(context)
        {
            _mapper = mapper;
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<UserPermissionDto>> getUserPermissionByUser(int userId)
        {
            return await _context.UserPermission
            .Where(u => u.UserId == userId)
            .Select(u => _mapper.Map<UserPermissionDto>(u))
            .ToListAsync();            
        }

        public async Task<List<PermissionDto>> GetPermissionByUser(int userId)
        {
            return await _context.UserPermission
            .Where(u => u.UserId == userId)
            .Include(u => u.Permission)
            .Select(u => _mapper.Map<PermissionDto>(u.Permission))
            .ToListAsync();
        }

        public async Task<PermissionDto> GetPermissionByIdIdUser(int id, int userId)
        {
            return await _context.UserPermission
            .Where(u => u.UserId == userId)
            .Where(u => u.Permission.Id == id)
            .Include(u => u.Permission)
            .Select(u => _mapper.Map<PermissionDto>(u.Permission))
            .FirstOrDefaultAsync();
        }

        public async Task<bool> HasPermissionByIdIdUser(int id, int userId)
        {
            return await _context.UserPermission
            .Where(u => u.UserId == userId)
            .Where(u => u.Permission.Id == id)
            .AnyAsync();
        }
    }
}