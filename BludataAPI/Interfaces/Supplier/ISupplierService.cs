using BludataAPI.DTOs.Supplier;

namespace BludataAPI.Interfaces.Supplier
{
	public interface ISupplierService
	{
		public Task<List<SupplierDTO>?> GetAllAsync();
		public Task<SupplierDTO?> GetByIDAsync(int supplierID);
		public Task<List<SupplierDTO>?> GetByNameAsync(string supplierName);
		public Task<List<SupplierDTO>?> GetByCompanyNameAsync(string companyName);
		public Task<List<SupplierDTO>?> GetByCompanyUFAsync(string companyUF);

		public Task<bool> AddAsync(SupplierDTO supplierDTO);
		public Task<bool?> EditByIDAsync(int supplierID, SupplierDTO supplierDTO);
		public Task<bool?> RemoveByIDAsync(int supplierID);
	}
}
