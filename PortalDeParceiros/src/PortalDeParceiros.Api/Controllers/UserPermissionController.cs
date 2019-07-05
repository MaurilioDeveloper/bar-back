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
    public class UserPermissionController : ControllerBase
    {
        private readonly IUserPermissionService _service;
        private readonly AuthenticatedUserDto _authenticatedUser;

        public UserPermissionController(IUserPermissionService service, 
            AuthenticatedUserDto authenticatedUser)
        {
            _service = service;
            _authenticatedUser = authenticatedUser;
        } 

        [HttpPost]
        public async Task<ActionResult> UpSertUserPermission([FromBody] UserDto user)
        {
            try
            {   
                if(!(await _service.ValidationPermission(PermissionDto.CodeTypes.AdmEdtPermission, 
                        _authenticatedUser.Id)))
                    return this.StatusCode(StatusCodes.Status403Forbidden);

                _service.UpSertUserPermission(user);

                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }
        }
        
        [HttpGet("GetPermissionByUserId/{userId}")]
        public async Task<ActionResult<List<PermissionDto>>> GetPermissionByUserId(int userId)
        {
            try
            {
                if(!(await _service.ValidationPermission(PermissionDto.CodeTypes.AdmEdtPermission, 
                        _authenticatedUser.Id)))
                    return this.StatusCode(StatusCodes.Status403Forbidden);

                return Ok(await _service.GetPermissionByUser(userId));
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }
        }

        [HttpGet("HasPermission/{id}/{userId}")]
        public async Task<ActionResult<bool>> HasPermission(int id, int userId)
        {
            try
            {
                if(!(await _service.ValidationPermission(PermissionDto.CodeTypes.AdmEdtPermission, 
                        _authenticatedUser.Id)))
                    return this.StatusCode(StatusCodes.Status403Forbidden);
                    
                return Ok(await _service.HasPermissionByIdIdUser(id, userId));
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }
        }
    }
}