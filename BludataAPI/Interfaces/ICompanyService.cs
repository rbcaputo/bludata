using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Interfaces
{
	public interface ICompanyService
	{
		public Task<List<CompanyModel>?> GetAllAsync();
		public Task<CompanyModel?> GetByIDAsync(int companyID);
		public Task<List<CompanyDTO>?> GetByNameAsync(string companyName);

		public Task<bool> AddAsync(CompanyDTO companyDTO);
		public Task<bool?> EditByIDAsync(int companyID, CompanyDTO companyDTO);
		public Task<bool?> RemoveByIDAsync(int companyID);
	}
}
