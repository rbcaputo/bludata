using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Interfaces
{
	public interface ISupplierService
	{
		public Task<List<SupplierDTO>> GetAllAsync();
		public Task<SupplierDTO> GetByIDAsync(int supplierID);
		public Task<List<SupplierDTO>> GetByNameAsync(string supplierName);
		public Task<List<SupplierDTO>> GetByCompanyNameAsync(string companyName);
		public Task<List<SupplierDTO>> GetByCompanyUFAsync(string companyUF);

		public Task<SupplierDTO> AddAsync(string name, string docType, List<CompanyModel> companies, DateTime subDate, string? cpf = null, string? cnpj = null, string? rg = null, DateTime? birthDate = null);
		public Task<SupplierDTO?> EditByIDAsync(int supplierID);
		public Task<bool?> RemoveByIDAsync(int supplierID);

	}
}
