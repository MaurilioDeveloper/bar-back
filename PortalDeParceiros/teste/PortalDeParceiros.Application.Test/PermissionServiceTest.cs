using AutoMapper;
using FluentAssertions;
using PortalDeParceiros.Application.Service;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Infrastructure.Configuration.Context;
using PortalDeParceiros.Infrastructure.IRepository;
using PortalDeParceiros.Infrastructure.Mapper;
using PortalDeParceiros.Infrastructure.Repository;
using Xunit;

namespace PortalDeParceiros.Application.Test
{
    public class PermissionServiceTest
    {
        private readonly IMapper _mapper;
        private PortalParceiroDbContext _context;
        private PermissionService _service;
        private IPermissionRepository _repository;

        public PermissionServiceTest()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<MapperRepository>();
            });
            _mapper = mapperConfig.CreateMapper();
            _context = InMemoryContextFactory.Create();
            this._repository = new PermissionRepository(_mapper, _context);

            this._service = new PermissionService(_repository);
        }
        [Fact]
        public void ShouldInsert()
        {
            var permission = new Permission() { Id = 1 };

            _context.Add(permission);
            _context.SaveChanges();

            //Fact
            var result = _repository.GetPermission(1);
            //Assert
            result.Should().NotBeNull();
        }
    }
}