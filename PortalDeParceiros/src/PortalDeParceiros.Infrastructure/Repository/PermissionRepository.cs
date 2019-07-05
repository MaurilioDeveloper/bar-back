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
    public class PermissionRepository : Repository<Permission, long>, IPermissionRepository
    {
        private readonly IMapper _mapper;
        private readonly PortalParceiroDbContext _context;
        public PermissionRepository(IMapper mapper, PortalParceiroDbContext context): base(context)
        {
            _mapper = mapper;
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<PermissionDto>> GetPermissions()
        {
            return await _context.Permission
                .Include(p => p.Group)
                .Select(p => _mapper.Map<PermissionDto>(p))
                .OrderBy(p => p.Description)
                .ToListAsync();
        }

        public async Task<List<PermissionDto>> GetPermissions(bool parthner)
        {
            return await _context.Permission
                .Include(p => p.Group)
                .Where(p => p.Partner == parthner || p.Partner)
                .Select(p => _mapper.Map<PermissionDto>(p))
                .OrderBy(p => p.Description)
                .ToListAsync();
        }

        public async Task<PermissionDto> GetPermission(int id)
        {
            return await _context.Permission
                .Where(p => p.Id == id)
                .Include(p => p.Group)
                .Select(p => _mapper.Map<PermissionDto>(p))
                .FirstOrDefaultAsync();
        }
    }
}