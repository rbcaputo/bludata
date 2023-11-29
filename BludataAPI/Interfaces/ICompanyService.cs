using BludataAPI.DTOs;

namespace BludataAPI.Interfaces
{
	public interface ICompanyService
	{
		public Task<CompanyDTO> AddAsync(CompanyDTO companyDTO);
		public Task<CompanyDTO?> EditByIDAsync(int companyID, CompanyDTO companyDTO);
		public Task<bool?> RemoveByIDAsync(int companyID);
	}
}
