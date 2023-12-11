using BludataAPI.DTOs.Company;

namespace BludataAPI.Interfaces.Company
{
    public interface ICompanyService
    {
        public Task<List<CompanyDTO>?> GetAllAsync();
        public Task<CompanyDTO?> GetByIDAsync(int companyID);
        public Task<List<CompanyDTO>?> GetByNameAsync(string companyName);

        public Task<bool> AddAsync(CompanyDTO companyDTO);
        public Task<bool?> EditByIDAsync(int companyID, CompanyDTO companyDTO);
        public Task<bool?> RemoveByIDAsync(int companyID);
    }
}
