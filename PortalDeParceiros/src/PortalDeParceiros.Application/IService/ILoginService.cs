using System.Threading.Tasks;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Application.IService
{
    public interface ILoginService
    {
        Task<UserDto> GetLogin(UserDto userValidation);
        void UpdatePassword(UserDto user, bool ConfirmPassword = false);
        string GeneratePassward();
        string EncryptPassword(string password);
         
    }
}