using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace PortalDeParceiros.Dto.Model
{
    public class AuthenticatedUserDto
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthenticatedUserDto(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor
            .HttpContext.User.Claims
            .Select(e => e)
            .FirstOrDefault(e => e.Type == ClaimTypes.Name)
            ?.Value;
        public string Email => _accessor
            .HttpContext.User.Claims
            .Select(e => e)
            .FirstOrDefault(e => e.Type == ClaimTypes.Email)
            ?.Value;
        public string Id => _accessor
            .HttpContext.User.Claims
            .Select(e => e)
            .FirstOrDefault(e => e.Type == "UserId")
            ?.Value;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}