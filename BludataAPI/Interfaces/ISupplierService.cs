using BludataAPI.DTOs;
using BludataAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BludataAPI.Interfaces
{
	public interface ISupplierService
	{
		public Task<List<SupplierModel>?> GetAllAsync();
		public Task<SupplierModel?> GetByIDAsync(int supplierID);
		public Task<List<SupplierDTO>?> GetByNameAsync(string supplierName);
		public Task<List<SupplierDTO>?> GetByCompanyNameAsync(string companyName);
		public Task<List<SupplierDTO>?> GetByCompanyUFAsync(string companyUF);

		public Task<bool> AddAsync(SupplierDTO supplierDTO);
		public Task<SupplierModel?> EditByIDAsync(int supplierID, SupplierDTO supplierDTO);
		public Task<bool?> RemoveByIDAsync(int supplierID);
	}
}
