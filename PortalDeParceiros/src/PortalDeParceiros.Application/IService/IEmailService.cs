using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Application.IService
{
    public interface IEmailService
    {
        void SendEmailNewUser(EmailDto email);
        void SendEmailResetUser(EmailDto email);
    }
}