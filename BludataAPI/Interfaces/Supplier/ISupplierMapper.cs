using BludataAPI.DTOs.Supplier;
using BludataAPI.Models;

namespace BludataAPI.Interfaces.Supplier
{
	public interface ISupplierMapper
	{
		public SupplierDTO ModelToDTO(SupplierModel supplierModel);

		public Task<SupplierModel> DTOToModelAsync(SupplierDTO supplierDTO);
		public Task<SupplierModel> DTOToModelPutAsync(SupplierModel supplierModel, SupplierDTO supplierDTO);
	}
}
