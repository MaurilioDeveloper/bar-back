using System.Collections.Generic;
using System.Threading.Tasks;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Infrastructure.IRepository
{
    public interface IUserRepository : IRepository<User, long>
    {
        Task<UserDto> GetUser(int id);
        Task<UserDto> GetuserByEmail(UserDto user);
        Task<bool> HasUserByIdCompany(int idCompany);
        Task<UserDto> GetUserByEmailCpf(UserDto user);
        void UpdateUser(UserDto userDto);
        void UpdateUserAndPassword(UserDto userDto);
        int InsertUser(UserDto userDto);
        Task<bool> HasUsersByEmail(UserDto user, int id = 0);
    }
}