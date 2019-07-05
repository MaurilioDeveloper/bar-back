using System;
using System.Threading.Tasks;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Dto.Model;
using PortalDeParceiros.Infrastructure.IRepository;
using AutoMapper;
using PortalDeParceiros.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PortalDeParceiros.Application.Service
{
    public class CompanyService : ICompanyService
    {
        public readonly ICompanyRepository _repository;
        public readonly IUserRepository _repositoryUser;
        public readonly IUserService _serviceUser;
        private readonly IPermissionRepository _repositoryPermission;
        private readonly IUserPermissionRepository _repositoryUserPermission;
        public readonly ILoginService _serviceLogin;
        public readonly IEmailService _serviceEmail;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository repository, 
            IUserRepository repositoryUser,
            IUserService serviceUser,
            IPermissionRepository repositoryPermission,
            IUserPermissionRepository repositoryUserPermission,
            ILoginService serviceLogin,
            IEmailService serviceEmail,
            IMapper mapper)
        {
            _serviceUser =  serviceUser;
            _repositoryUser = repositoryUser;
            _repository = repository;
            _repositoryPermission = repositoryPermission;
            _repositoryUserPermission = repositoryUserPermission;
            _serviceLogin = serviceLogin;
            _serviceEmail = serviceEmail;
            _mapper = mapper;
        }

        public async Task<List<CompanyListDto>> GetCompaniesAsync()
        {
            return await _repository.GetCompaniesAsync();
        }

        public async Task<CompanyDto> GetCompany(int Id)
        {
            return await _repository.GetCompany(Id);
        }

        public async Task<CompanyDto> GetCompanyByCnpj(string cnpj)
        {
            return await _repository.GetCompanyByCnpj(cnpj);
        }

        public async Task<CompanyDto> GetCompaniesbyuserId(int userId)
        {
            return await _repository.GetCompaniesbyuserId(userId);
        }

        public void InserCompany(CompanyDto companyDto, int userId)
        {
            if(_repository.GetCompanyByCnpj(companyDto.Cnpj).Result != null) 
                throw new ArgumentException("Parceiro já cadastrado");

            if(validateInsertCompany(userId).Result > 2)
                throw new ArgumentException("Não é permitido inserir novo parceiro. Limite de subparceiro atingido");

            companyDto.CreatedAt = DateTime.Now;
            companyDto.LastUpdate = DateTime.Now;
            companyDto.Status = true;
            companyDto.FirstAcess = false;
            companyDto.UserCommercialId = userId;
            
            var user = _serviceUser.UserValidateInsert(companyDto.UsersDto.FirstOrDefault(u => u.Id == 0), true);
            var email = user.EmailDto;              

            companyDto.UsersDto = new List<UserDto>();
            companyDto.UsersDto.Add(user);

            _repository.InsertCompany(companyDto);
            _serviceEmail.SendEmailNewUser(email);
        }

        private async Task<int> validateInsertCompany(int userId)
        {
            var user = await _repositoryUser.GetUser(userId);

            if(user.Novi)
                return 1;

            var company = await _repository.GetCompany(user.CompanyId ?? 0);

            return (await validateInsertCompany(company.UserCommercialId ?? 0)) + 1;
        }

        public void UpdateCompanyBasic(CompanyDto companyDto, int userId)
        {
            var company = _repository.GetCompanyByCnpj(companyDto.Cnpj).Result;

            if(company == null)
                throw new ArgumentException("Parceiro não cadastrado");

            var userMasterDto = companyDto.UsersDto.Select(u => u).FirstOrDefault();
            var userMaster = company.UsersDto.FirstOrDefault(u => u.Id == userMasterDto.Id);

            if(userMaster == null)
                throw new ArgumentException("Usuário não localizado");

            if(company.FirstAcess)
                throw new ArgumentException("Este usuário já realizou o acesso");

            _serviceUser.UserValidateUpdateBasic(userMasterDto);

            userMaster.Cpf = userMasterDto.Cpf;
            userMaster.Email = userMasterDto.Email;
            userMaster.Name = userMasterDto.Name;
            userMaster.Phone = userMasterDto.Phone;
            userMaster.Cep = userMasterDto.Cep;
            userMaster.State = userMasterDto.State;
            userMaster.City = userMasterDto.City;
            userMaster.LastUpdate = DateTime.Now;
            userMaster.Observation = userMasterDto.Observation;

            company.LastUpdate = DateTime.Now;
            company.Description = companyDto.Description;
            company.City = companyDto.City;
            company.State = companyDto.State;
            company.Cep = companyDto.Cep;
            company.Observation = companyDto.Observation;
            company.UserCommercialId = userId;
            company.FirstAcess = true;
            company.UsersDto = new List<UserDto>();
            company.UsersDto.Add(userMaster);

            _repository.UpdateCompanyAsync(company);
            _repositoryUser.UpdateUser(userMaster);
        }

        public async Task<bool> UpdateCompanyAsync(CompanyDto company)
        {
            var companyDto = await _repository.GetCompany(company.Id);

            if (companyDto == null)
                throw new ArgumentException("Parceiro não localizado");

            if(companyDto.FirstAcess)
                throw new ArgumentException("Parceiro já cadastrado");

            var userMaster = company.UsersDto.FirstOrDefault();
            var user = _repositoryUser.GetUser(userMaster.Id).Result;

            if(companyDto.UsersDto.Count == 1 && user.Email != userMaster.Email)
            {
                user.Email = userMaster.Email;
                user.Name = userMaster.Name;
                
                user = _serviceUser.UserValidateUpdate(user);
                
                _repositoryUser.UpdateUserAndPassword(user);
                _serviceEmail.SendEmailNewUser(user.EmailDto);
            }                

            companyDto.Cnpj = company.Cnpj;
            companyDto.Description = company.Description;
            companyDto.Cep = company.Cep;
            companyDto.State = company.State;
            companyDto.City = company.City;
            companyDto.Observation = company.Observation;
            companyDto.LastUpdate = DateTime.Now;

            _repository.UpdateAsync(_mapper.Map<Company>(companyDto));

            return true;
        }
    }
}