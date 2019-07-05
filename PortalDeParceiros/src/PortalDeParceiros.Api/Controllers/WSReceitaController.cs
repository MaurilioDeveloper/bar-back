using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize()]
    public class WSReceitaController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IUserPermissionService _serviceUserPermission;
        private readonly AuthenticatedUserDto _authenticatedUser;

        public WSReceitaController(IConfiguration configuration,
            IUserPermissionService serviceUserPermission,
            AuthenticatedUserDto authenticatedUser
            )
        {
            _configuration = configuration;
            _serviceUserPermission = serviceUserPermission;
            _authenticatedUser = authenticatedUser;
        }


        [HttpGet("{cnpj}")]
        public async Task<ActionResult<object>> Get(string cnpj)
        {
            if(!(await _serviceUserPermission.ValidationPermission(PermissionDto.CodeTypes.AdmCreatCompany, 
                        _authenticatedUser.Id)))
                    return this.StatusCode(StatusCodes.Status403Forbidden);
            try
            {

                string token = _configuration.GetValue<string>("TokenReceita");
                var address = new Uri(_configuration.GetValue<string>("UrlReceita"));
                string responseData;

                using (var httpClient = new HttpClient { BaseAddress = address })
                {
                    using (var response = await httpClient.GetAsync(cnpj))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        responseData = await response.Content.ReadAsStringAsync();
                        if(responseData == null)
                        {
                            return ("Nenhum conteúdo encontrado");
                        }

                        return JsonConvert.DeserializeObject<object>(responseData);
                    }
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Limite de requisição excedido (Max: 3 consulta/minuto).");
            }
        }
    }
}