using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Dto.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.AspNetCore.Http;

namespace PortalDeParceiros.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _serviceLogin;
        private readonly IConfiguration _configuration;

        public LoginController(ILoginService serviceLogin,
            IConfiguration configuration)
        {
            _serviceLogin = serviceLogin;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] UserDto user)
        {
            try
            {
                user = _serviceLogin.GetLogin(user).Result;

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserId", user.Id.ToString())
                };

                var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

               var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 

               var token = new JwtSecurityToken(
                    issuer: "Novi", 
                    audience: "Novi",
                    claims: claims,
                    expires: DateTime.Now.AddHours(12),
                    signingCredentials: creds);

                user.Token = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(user);
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Usuário ou senha invalido");
            }
        }
    }
}