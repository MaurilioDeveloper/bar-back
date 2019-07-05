using System.Collections.Generic;
using System.Threading.Tasks;
using PortalDeParceiros.Dto.Model;

namespace PortalDeParceiros.Application.IService
{
    public interface ICompanyService
    {
        Task<CompanyDto> GetCompany(int Id);
        Task<List<CompanyListDto>> GetCompaniesAsync();
        Task<CompanyDto> GetCompanyByCnpj(string cnpj);
        Task<CompanyDto> GetCompaniesbyuserId(int userId);
        Task<bool> UpdateCompanyAsync(CompanyDto company);
        void InserCompany(CompanyDto companyDto, int userId);
        void UpdateCompanyBasic(CompanyDto companyDto, int userId);

    }
}