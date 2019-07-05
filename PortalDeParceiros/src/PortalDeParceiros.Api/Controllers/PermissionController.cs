using System;
using System.Collections.Generic;
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
    public class PermissionController : ControllerBase
    {
        public readonly IPermissionService _service;
        private readonly IUserService _serviceUser;
        private readonly IUserPermissionService _serviceUserPermission;
        private readonly AuthenticatedUserDto _authenticatedUser;

        public PermissionController(IPermissionService service,
            IUserPermissionService serviceUserPermission,
            IUserService serviceUser,
            AuthenticatedUserDto authenticatedUser
            )
        {
            _service = service;
            _serviceUserPermission = serviceUserPermission;
            _serviceUser = serviceUser;
            _authenticatedUser = authenticatedUser;
        }

        [HttpGet]
        public async Task<ActionResult<List<PermissionDto>>> GetPermissions()
        {
            try
            {
                if(!(await _serviceUserPermission.ValidationPermission(PermissionDto.CodeTypes.AdmEdtPermission, 
                        _authenticatedUser.Id)))
                    return this.StatusCode(StatusCodes.Status403Forbidden);

                var novi = (await _serviceUser.GetUser(int.Parse(_authenticatedUser.Id))).Novi;

                return Ok(await _service.GetPermissions(novi));
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionDto>> GetPermission(int id)
        {
            try
            {
                if(!(await _serviceUserPermission.ValidationPermission(PermissionDto.CodeTypes.AdmEdtPermission, 
                        _authenticatedUser.Id)))
                    return this.StatusCode(StatusCodes.Status403Forbidden);

                return Ok(await _service.GetPermission(id));
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }
        }
    }
}