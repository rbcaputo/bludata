using BludataAPI.Data;
using BludataAPI.DTOs.Supplier;
using BludataAPI.Interfaces;
using BludataAPI.Interfaces.Supplier;
using BludataAPI.Models;
using BludataAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace BludataAPI.Services
{
	public class SupplierService(DataContext context, IMapperFactory factory) : ISupplierService
	{
		private readonly Lazy<ISupplierMapper> _mapper = factory.CreateSupplierMapper(context);

		public async Task<List<SupplierDTO>?> GetAllAsync()
		{
			List<SupplierModel>? suppliers = await context.Suppliers.Include(sup => sup.Companies).ToListAsync();

			if (suppliers.Count == 0) return null;
			else
			{
				List<SupplierDTO>? results = [];

				foreach (SupplierModel supplier in suppliers) results.Add(_mapper.Value.ModelToDTO(supplier));

				return results;
			}
		}
		public async Task<SupplierDTO?> GetByIDAsync(int supplierID)
		{
			SupplierModel? supplier = await context.Suppliers.FindAsync(supplierID);

			if (supplier == null) return null;
			else
			{
				SupplierDTO result = _mapper.Value.ModelToDTO(supplier);

				return result;
			}
		}
		public async Task<List<SupplierDTO>?> GetByNameAsync(string supplierName)
		{
			List<SupplierDTO>? suppliers = await context.Suppliers.Include(sup => sup.Companies).Select(sup => _mapper.Value.ModelToDTO(sup)).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}
		public async Task<List<SupplierDTO>?> GetByCompanyNameAsync(string companyName)
		{
			List<SupplierDTO>? suppliers = await context.Suppliers.Where(sup => sup.Companies.Any(com => com.Name.ToLower() == companyName.ToLower()))
				.Select(sup => _mapper.Value.ModelToDTO(sup)).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}
		public async Task<List<SupplierDTO>?> GetByCompanyUFAsync(string companyUF)
		{
			List<SupplierDTO>? suppliers = await context.Suppliers.Where(sup => sup.Companies.Any(com => com.UF.ToLower() == companyUF.ToLower()))
				.Select(sup => _mapper.Value.ModelToDTO(sup)).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}

		public async Task<bool> AddAsync(SupplierDTO supplierDTO)
		{
			SupplierModel supplier = await _mapper.Value.DTOToModelAsync(supplierDTO);
			supplier = SupplierUtils.HandleForm(supplier, supplierDTO);

			await context.Suppliers.AddAsync(supplier);
			await context.SaveChangesAsync();

			return true;
		}
		public async Task<bool?> EditByIDAsync(int supplierID, SupplierDTO supplierDTO)
		{
			SupplierModel? supplier = await context.Suppliers.FindAsync(supplierID);

			if (supplier == null) return null;
			else
			{
				SupplierUtils.HandleForm(supplier, supplierDTO);
				await context.SaveChangesAsync();

				return true;
			}
		}
		public async Task<bool?> RemoveByIDAsync(int supplierID)
		{
			SupplierModel? supplier = await context.Suppliers.FindAsync(supplierID);

			if (supplier == null) return null;
			else
			{
				context.Suppliers.Remove(supplier);
				await context.SaveChangesAsync();

				return true;
			}
		}
	}
}
