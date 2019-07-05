using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Dto.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PortalDeParceiros.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize()]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        private readonly IUserService _serviceUser;
        private readonly IUserPermissionService _serviceUserPermission;
        private readonly AuthenticatedUserDto _authenticatedUser;

        public CompanyController(ICompanyService service, 
            IUserService serviceUser,
            IUserPermissionService serviceUserPermission,
            AuthenticatedUserDto authenticatedUser
            )
        {
            _service = service;
            _serviceUser = serviceUser;
            _serviceUserPermission = serviceUserPermission;
            _authenticatedUser = authenticatedUser;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CompanyDto>> GetCompanie(int id)
        {
            try
            {
                var company = await _service.GetCompany(id);

                if (company != null)
                    return Ok(company);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }

            return BadRequest("Parceiro não localizado.");
        }

        [HttpGet]
        public async Task<ActionResult<CompanyListDto>> GetCompanies()
        {
            try
            {
                var user = await _serviceUser.GetUser(int.Parse(_authenticatedUser.Id));
                var companys = new List<CompanyDto>();
                
                if(user.Novi)
                    return Ok(await _service.GetCompaniesAsync());
                else
                    companys.Add(await _service.GetCompany(user.CompanyId ?? 0));
                
                return Ok(companys);
            }
            catch (NullReferenceException)
            {
                return BadRequest("Não foi possível carregar a listagem de parceiros.");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }
        }

        [HttpGet("GetCompanieByCnpj/{cnpj}")]
        public async Task<ActionResult<CompanyDto>> GetCompanieByCnpj(string cnpj)
        {
            try
            {
                var companie = await _service.GetCompanyByCnpj(cnpj);
                if(companie == null)
                     return this.StatusCode(StatusCodes.Status204NoContent);

                return Ok(companie);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }
        }

        [HttpGet("GetCompanieByMaster/{cnpj}")]
        public async Task<ActionResult<CompanyDto>> GetCompanieByMaster(string cnpj)
        {
            try
            {
                var companie = await _service.GetCompanyByCnpj(cnpj);
                if(companie == null)
                     return this.StatusCode(StatusCodes.Status204NoContent);

                var master = companie.UsersDto.Select(u => u)
                .OrderBy(u => u.CreatedAt)
                .FirstOrDefault();

                companie.UsersDto = new List<UserDto>();
                companie.UsersDto.Add(master);

                return Ok(companie);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }
        }

        [HttpGet("GetCompaniesbyuserId/{userId}")]
        public async Task<ActionResult<CompanyDto>> GetCompaniesbyuserId(int userId)
        {
            try
            {
                return Ok(await _service.GetCompaniesbyuserId(userId));
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> InsertCompany([FromBody] CompanyDto company)
        {
            try
            {
                if(!(await _serviceUserPermission.ValidationPermission(PermissionDto.CodeTypes.AdmCreatCompany, 
                        _authenticatedUser.Id)))
                    return this.StatusCode(StatusCodes.Status403Forbidden);

                int userId = int.Parse(_authenticatedUser.Id);

                _service.InserCompany(company, userId);
                return this.StatusCode(StatusCodes.Status201Created, "Parceiro criado com sucesso.");
            }
            catch (ArgumentException e)
            {
                return BadRequest($"{e.Message}");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição");
            }
        }

        [HttpPut("UpdateCompanyBasic")]
        public async Task<ActionResult> UpdateCompanyBasic([FromBody] CompanyDto company)
        {
            try
            {
                if(!(await _serviceUserPermission.ValidationPermission(PermissionDto.CodeTypes.AdmCreatCompany, 
                        _authenticatedUser.Id)))
                    return this.StatusCode(StatusCodes.Status403Forbidden);

                int userId = int.Parse(_authenticatedUser.Id);

                _service.UpdateCompanyBasic(company, userId);
                return Ok("Parceiro atualizado com sucesso.");
            }
            catch (ArgumentException e)
            {
                return BadRequest($"{e.Message}");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCompany([FromBody] CompanyDto company)
        {
            try
            {
                if(!(await _serviceUserPermission.ValidationPermission(PermissionDto.CodeTypes.AdmCreatCompany, 
                        _authenticatedUser.Id)))
                    return this.StatusCode(StatusCodes.Status403Forbidden);
                    
                await _service.UpdateCompanyAsync(company);
                return Ok("Parceiro atualizado com sucesso.");
            }
            catch (ArgumentException e)
            {
                return BadRequest($"{e.Message}");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao processar requisição");
            }
        }
    }
}