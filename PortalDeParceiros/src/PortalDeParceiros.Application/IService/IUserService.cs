using System.Threading.Tasks;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Application.IService
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int Id);
        Task<bool> UpdateUser(UserDto user);
        void UpdateUserAndPassword(UserDto user);
        void InsertUser(UserDto user);
        Task<UserDto> GetUserByEmailCpf(UserDto user);
        Task<UserDto> GetuserByEmail(UserDto user);
        UserDto UserValidateInsert(UserDto user, bool master = false);
        UserDto UserValidateUpdate(UserDto user);
        bool UserValidateUpdateBasic(UserDto user);
    }
}