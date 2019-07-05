using System.Threading.Tasks;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Infrastructure.IRepository
{
    public interface ILoginRepository : IRepository<User, long>
    {
        Task<UserDto> GetLogin(UserDto user);
    }
}