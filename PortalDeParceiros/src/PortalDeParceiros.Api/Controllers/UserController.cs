using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Dto.Model;
using Microsoft.AspNetCore.Authorization;

namespace PortalDeParceiros.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize()]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly ICompanyService _serviceCompany;
        private readonly IUserPermissionService _serviceUserPermission;
        private readonly AuthenticatedUserDto _authenticatedUser;

        public UserController(IUserService service, 
            ICompanyService serviceCompany,
            IUserPermissionService serviceUserPermission,
            AuthenticatedUserDto authenticatedUser
            )
        {
            _service = service;
            _serviceCompany = serviceCompany;
            _serviceUserPermission = serviceUserPermission;
            _authenticatedUser = authenticatedUser;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            try
            {
                var user = await _service.GetUser(id);

                if (user != null)
                    return Ok(user);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }

            return BadRequest("Parceiro não localizado.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] UserDto user)
        {
            try
            {
                await _service.UpdateUser(user);

                return Ok("Usuário atualizado com sucesso.");
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Usuário não localizado.");
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }
        }

        [HttpPost]
        public ActionResult InsertUser([FromBody] UserDto user)
        {
            try
            {   
                if(!_serviceUserPermission.ValidationPermission(PermissionDto.CodeTypes.AdmCreatUser, 
                        _authenticatedUser.Id)
                        .Result)
                    return this.StatusCode(StatusCodes.Status403Forbidden);

                var company = _serviceCompany.GetCompany(user.CompanyId.Value).Result;

                if(company == null)
                    return BadRequest("Parceiro não localizado");

                _service.InsertUser(user);

                return this.StatusCode(StatusCodes.Status201Created, "Usuário inserido com sucesso");
            }
            catch (ArgumentException e)
            {
                return BadRequest($"{e.Message}");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }
        }
    }
}