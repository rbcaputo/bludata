using BludataAPI.Data;
using BludataAPI.DTOs;
using BludataAPI.Interfaces;
using BludataAPI.Mappers;
using BludataAPI.Models;
using BludataAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace BludataAPI.Services
{
	public class SupplierService(DataContext context) : ISupplierService
	{
		public async Task<List<SupplierModel>?> GetAllAsync()
		{
			List<SupplierModel>? suppliers = await context.Suppliers.Include(sup => sup.Companies).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}
		public async Task<SupplierModel?> GetByIDAsync(int supplierID)
		{
			SupplierModel? supplier = await context.Suppliers.FindAsync(supplierID);

			if (supplier == null) return null;
			else return supplier;
		}
		public async Task<List<SupplierDTO>?> GetByNameAsync(string supplierName)
		{
			List<SupplierDTO>? suppliers = await context.Suppliers.Select(sup => SupplierMapper.ModelToDTO(sup)).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}
		public async Task<List<SupplierDTO>?> GetByCompanyNameAsync(string companyName)
		{
			List<SupplierDTO>? suppliers = await context.Suppliers.Where(sup => sup.Companies.Any(com => com.Name.ToLower() == companyName.ToLower()))
				.Select(sup => SupplierMapper.ModelToDTO(sup)).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}
		public async Task<List<SupplierDTO>?> GetByCompanyUFAsync(string companyUF)
		{
			List<SupplierDTO>? suppliers = await context.Suppliers.Where(sup => sup.Companies.Any(com => com.UF.ToLower() == companyUF.ToLower()))
				.Select(sup => SupplierMapper.ModelToDTO(sup)).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}

		public async Task<bool> AddAsync(SupplierDTO supplierDTO)
		{
			SupplierModel supplier = SupplierMapper.DTOToModel(supplierDTO);
			supplier = SupplierUtils.HandleForm(supplier, supplierDTO);

			await context.Suppliers.AddAsync(supplier);
			await context.SaveChangesAsync();

			return true;
		}
		public async Task<bool?> EditByIDAsync(int supplierID, SupplierDTO supplierDTO)
		{
			SupplierModel? supplier = await context.Suppliers.FindAsync(supplierID);
			
			if(supplier == null) return null;
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
