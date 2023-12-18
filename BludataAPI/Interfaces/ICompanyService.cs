using BludataAPI.DTOs.Company;
using BludataAPI.Models;

namespace BludataAPI.Interfaces
{
    public interface ICompanyService
	{
		public Task<List<CompanyModel>?> GetAllAsync();
		public Task<List<CompanyDTO?>?> GetAllByUFAsync(string companiesUF);
		public Task<CompanyDTO?> GetByIDAsync(int companyID);
		public Task<CompanyDTO?> GetByCNPJAsync(string companyCNPJ);
		public Task<CompanyDTO?> GetByNameAsync(string companyName);

		public Task<bool?> AddAsync(CompanyPostDTO? companyPostDTO);

		public Task<CompanyModel?> UpdateByIDAsync(int companyID, CompanyDTO? companyDTO);

		public Task<bool?> RemoveByIDAsync(int companyID);
	}
}
