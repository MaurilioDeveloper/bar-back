using System.Collections.Generic;
using System.Threading.Tasks;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Infrastructure.IRepository
{
    public interface ICompanyRepository : IRepository<Company, long>
    {
        void UpdateCompanyAsync(CompanyDto company);
        Task<CompanyDto> GetCompany(int id);
        Task<List<CompanyListDto>> GetCompaniesAsync();
        Task<CompanyDto> GetCompaniesbyuserId(int userId);
        Task<CompanyDto> GetCompanyByCnpj(string cnpj);
        CompanyDto InsertCompany(CompanyDto companyDto);
    }
}