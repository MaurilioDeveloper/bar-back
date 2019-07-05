using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize()]
    public class UserPasswordController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILoginService _serviceLogin;

        public UserPasswordController(IUserService service, 
            ILoginService serviceLogin)
        {
            _service = service;
            _serviceLogin = serviceLogin;
        }

        [HttpPut]
        public ActionResult UpdatePassword([FromBody] UserDto user)
        {
            try
            {
                user.ChangedPassword = true;

                _serviceLogin.UpdatePassword(user, true);
                
                return Ok("Usuário atualizado com sucesso.");
            }
            catch(ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("ResetPassword")]
        public async Task<ActionResult> ResetPassword([FromBody] UserDto user)
        {
            try
            {
                var userDto = await _service.GetUserByEmailCpf(user);

                if(userDto == null)
                    return BadRequest("Dados não conferem");

                userDto.Password = _serviceLogin.GeneratePassward();
                userDto.ChangedPassword = false;

                userDto.EmailDto = new EmailDto
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password
                };
                
                _serviceLogin.UpdatePassword(userDto);

                return Ok("Nova senha enviada por email");
            }
            catch(ArgumentNullException)
            {
                return BadRequest("Nenhum usuário localizado.");
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição");
            }
        }
    }
}