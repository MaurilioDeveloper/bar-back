using AutoMapper;
using FluentAssertions;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Application.Service;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;
using PortalDeParceiros.Infrastructure.Configuration.Context;
using PortalDeParceiros.Infrastructure.IRepository;
using PortalDeParceiros.Infrastructure.Mapper;
using PortalDeParceiros.Infrastructure.Repository;
using Xunit;

namespace PortalDeParceiros.Application.Test
{
    public class UserServiceTest
    {
        private readonly IMapper _mapper;
        private PortalParceiroDbContext _context;
        private ILoginService _serviceLogin;
        private IEmailService _serviceEmail;
        private UserService _service;
        private IUserRepository _repository;
        private IPermissionRepository _permissionRepository;
        private IUserPermissionRepository _repositoryPermission;

        public UserServiceTest()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<MapperRepository>();
            });
            _mapper = mapperConfig.CreateMapper();
            _context = InMemoryContextFactory.Create();
            this._repository = new UserRepository(_mapper, _context);

            this._service = new UserService(_repository, _permissionRepository, _repositoryPermission, _serviceLogin, _serviceEmail, _mapper);
        }
        [Fact]
        public void ShouldInsert()
        {
            var user = new User() { Id = 300 };

            _context.Add(user);
            _context.SaveChanges();

            //Fact
            var result = _repository.GetUser(300);
            //Assert
            result.Should().NotBeNull();
        }

        public async void ShoulUpdate()
        {
            var user1 = new User() { Id = 300, Email = "old@mail.com" };

             _context.User.Add(user1);
             _context.SaveChanges();

            //Act
            var User = await _service.GetUser(300);
            var entity = _mapper.Map<User>(User);
            entity.Email = "new@mail.com";
            _context.SaveChanges();
            var result = _mapper.Map<UserDto>(entity);
            //Assert
            result.Email.Should().NotContain(user1.Email);  
        }
    }
}