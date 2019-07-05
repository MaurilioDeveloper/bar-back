using PortalDeParceiros.Infrastructure.IRepository;
using AutoMapper;
using PortalDeParceiros.Dto.Model;
using PortalDeParceiros.Infrastructure.Configuration.Context;
using PortalDeParceiros.Domain.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PortalDeParceiros.Infrastructure.Repository
{
    public class UserRepository : Repository<User, long>, IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly PortalParceiroDbContext _context;

        public UserRepository(IMapper mapper, PortalParceiroDbContext context) : base(context)
        {
            _mapper = mapper;
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<UserDto> GetUser(int id)
        {
            var user = await _context.User
                .Include(u => u.Company)
                .Include(u => u.UserLeader)
                .Where(u => u.Id == id)
                .Select(u => _mapper.Map<UserDto>(u))
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<UserDto> GetuserByEmail(UserDto user)
        {
            return await _context.User
                .Where(u => u.Email == user.Email)
                .Select(u => _mapper.Map<UserDto>(u))
                .FirstOrDefaultAsync();
        }

        public async Task<bool> HasUsersByEmail(UserDto user, int id = 0)
        {
            return await _context.User
                .Where(u => u.Email == user.Email)
                .Where(u => u.Id != id)
                .Select(u => _mapper.Map<UserDto>(u))
                .AnyAsync();
        }

        public async Task<bool> HasUserByIdCompany(int idCompany)
        {
            return await _context.Company
                .Where(c => c.Id == idCompany)
                .Where(c => c.Users.Any())
                .AnyAsync();
        }
        public async Task<UserDto> GetUserByEmailCpf(UserDto user)
        {
            return await _context.User
                .Where(u => u.Email == user.Email)
                .Where(u => u.Cpf == user.Cpf)
                .Where(u => u.Status)
                .Select(u => _mapper.Map<UserDto>(u))
                .FirstOrDefaultAsync();
        }
        public void UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            _context.Entry(user).State = EntityState.Modified;
            _context.Entry(user).Property("Password").IsModified = false; 
            _context.Entry(user).Property("CreatedAt").IsModified = false; 
            _context.SaveChanges();
        }

        public void UpdateUserAndPassword(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            _context.Entry(user).State = EntityState.Modified;
            _context.Entry(user).Property("CreatedAt").IsModified = false; 
            _context.SaveChanges();
        }

        public int InsertUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            _context.User.Add(user);
            _context.SaveChanges();

            return user.Id;
        }
    }
}