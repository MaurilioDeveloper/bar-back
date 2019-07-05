using AutoMapper;
using Moq;
using Xunit;
using FluentAssertions;
using PortalDeParceiros.Infrastructure.Repository;
using PortalDeParceiros.Infrastructure.Configuration.Context;
using PortalDeParceiros.Infrastructure.IRepository;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Application.Service;
using PortalDeParceiros.Infrastructure.Mapper;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Application.Test
{
    public class CompanyServiceTest
    {
        private ICompanyRepository _repository;
        private readonly IMapper _mapper;
        private PortalParceiroDbContext _context;
        private IUserService _serviceUser;
        private IPermissionRepository _permissionRepositoy;
        private IUserPermissionRepository _repositoryPermission;
        private ILoginService _serviceLogin;
        private IEmailService _serviceEmail;
        private CompanyService _service;
        private IPermissionRepository _permissionRepository;

        public CompanyServiceTest()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<MapperRepository>();
            });
            _mapper = mapperConfig.CreateMapper();
            _context = InMemoryContextFactory.Create();
            this._repository = new CompanyRepository(_mapper, _context);

            this._service = new CompanyService(_repository, _serviceUser,_permissionRepositoy, _repositoryPermission, _serviceLogin, _serviceEmail, _mapper );
        }

        [Fact]
        public async void ShouldInsertCompany()
        {
            var company = new Company() { Id = 100 };

            _context.Company.Add(company);
            await _context.SaveChangesAsync();

            //Act
            var result = await _service.GetCompany(100);

            //Assert          
            result.Should().NotBeNull();
        }
        [Fact]
        public async void ShouldGetCompanies()
        {
            var company = new CompanyListDto() { Id = 100,Description = "Test List" };
            var otherCompany = new CompanyListDto() { Id = 200, Description = "Test list 2" };


            _context.Company.Add( _mapper.Map<Company>(company));
            _context.Company.Add(_mapper.Map<Company>(otherCompany));
            await _context.SaveChangesAsync();
            var result = "";
            //Act
            //result = _service.GetCompaniesAsync();
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public async void ShouldUpdateCompany()
        {
             var company1 = new Company() { Id = 300, Description = "Test Update" };

             _context.Company.Add(company1);
             _context.SaveChanges();

            //Act
            var company = await _service.GetCompany(300);
            var entity = _mapper.Map<Company>(company);
            entity.Description = "New Description";
            _context.SaveChanges();
            var result = _mapper.Map<CompanyDto>(entity);
            //Assert
            result.Description.Should().NotContain(company1.Description);
        }
    }
}