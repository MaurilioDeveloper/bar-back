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
    public class LoginRepository : Repository<User, long>, ILoginRepository
    {
        private readonly IMapper _mapper;
        private readonly PortalParceiroDbContext _context;

        public LoginRepository(IMapper mapper, PortalParceiroDbContext context) : base(context)
        {
            _mapper = mapper;
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<UserDto> GetLogin(UserDto user)
        {
            return await _context.User
                .Include(u => u.Company)
                .Include(u => u.UserPermissions)
                .Where(u => u.Email == user.Email)
                .Where(u => u.Password == user.Password)
                .Where(u => u.Status)
                .Select(u => _mapper.Map<UserDto>(u))
                .FirstOrDefaultAsync();
        }
    }
}