using BludataAPI.DTOs.Supplier;
using BludataAPI.Models;

namespace BludataAPI.Interfaces
{
    public interface ISupplierService
	{
		public Task<List<SupplierModel>?> GetAllAsync();
		public Task<List<SupplierDTO?>?> GetAllByNameAsync(string supplierName);
		public Task<SupplierDTO?> GetByIDAsync(int supplierID);
		public Task<SupplierDTO?> GetByDocNumberAsync(string docType, string docNumber);

		public Task<bool?> AddAsync(SupplierPostDTO? supplierPostDTO);

		public Task<SupplierModel?> UpdateByIDAsync(int supplierID, SupplierDTO? supplierDTO);

		public Task<bool?> RemoveByIDAsync(int supplierID);
	}
}
