using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;
using PortalDeParceiros.Infrastructure.Configuration.Context;
using PortalDeParceiros.Infrastructure.IRepository;

namespace PortalDeParceiros.Infrastructure.Repository
{
    public class CompanyRepository : Repository<Company, long>, ICompanyRepository
    {
        private readonly IMapper _mapper;
        private readonly PortalParceiroDbContext _context;

        public CompanyRepository(IMapper mapper, PortalParceiroDbContext context) : base(context)
        {
            _mapper = mapper;
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void UpdateCompanyAsync(CompanyDto company)
        {
            var entity = _mapper.Map<Company>(company);
            
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.CreatedAt).IsModified = false; 
            _context.Entry(entity).Property(x => x.UserCommercialId).IsModified = false; 

            _context.SaveChanges();
        }        
        public async Task<CompanyDto> GetCompany(int id)
        {
            var companyDto = await _context.Company
                .Include(c => c.Users)
                .Where(c => c.Id == id)
                .AsNoTracking()
                .Select(c => _mapper.Map<CompanyDto>(c))
                .FirstOrDefaultAsync();
            return companyDto;
        }
        public async Task<List<CompanyDto>> GetCompaniesByUser(int id)
        {
            var companiesDto =
               _context.Company
                .Where(c => _context.User.Where(x => x.Id == id)
                .AsNoTracking()
                .Select(x => x.Id).FirstOrDefault() == c.Id)
                .Select(c => _mapper.Map<CompanyDto>(c))
                .ToListAsync();

            return await companiesDto;
        }
        public async Task<CompanyDto> GetCompanyByCnpj(string cnpj)
        {
            return await _context.Company
                .Include(c => c.Users)
                .Where(c => c.Cnpj == cnpj)
                .Select(c => _mapper.Map<CompanyDto>(c))
                .FirstOrDefaultAsync();
        }
        public async Task<List<CompanyListDto>> GetCompaniesAsync()
        {
             var companies = await _context.Company
               .AsNoTracking()
               .Select(c => _mapper.Map<CompanyListDto>(c))
               .ToListAsync();
               return companies;
        }
        public async Task<CompanyDto> GetCompaniesbyuserId(int userId)
        {
            var company = await _context.Company
                .Where(c => c.Users.Any(u => u.Id == userId))
                .AsNoTracking()
                .Select(c => _mapper.Map<CompanyDto>(c))
                .FirstOrDefaultAsync();
            
            company.UsersDto.Add
            (
                await _context.User
                .Where(u => u.Id == userId)
                .Select(u => _mapper.Map<UserDto>(u))
                .FirstOrDefaultAsync()
            );

            return company;
        }
        public CompanyDto InsertCompany(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            company.Users = companyDto.UsersDto.Select(x => _mapper.Map<User>(x)).ToList();

            _context.Company.Add(company);
            _context.SaveChanges();

            return _mapper.Map<CompanyDto>(company);
        }
    }
}