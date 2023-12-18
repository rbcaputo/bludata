using BludataAPI.Data;
using BludataAPI.DTOs.Supplier;
using BludataAPI.Interfaces;
using BludataAPI.Mappers;
using BludataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BludataAPI.Services
{
	public class SupplierService(DataContext context) : ISupplierService
	{
		public async Task<List<SupplierModel>?> GetAllAsync()
		{
			List<SupplierModel>? suppliers = await context.Suppliers
				.Include(sup => sup.SupplierCompanies)
				.ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}

		public async Task<List<SupplierDTO?>?> GetAllByNameAsync(string supplierName)
		{
			List<SupplierDTO?> suppliers = await context.Suppliers
				.Where(sup => sup.Name.ToLower() == supplierName.ToLower())
				.Include(sup => sup.SupplierCompanies)
				.Select(sup => SupplierMapper.ModelToDTO(sup))
				.ToListAsync();

			if (suppliers == null) return null;
			else return suppliers;
		}

		public async Task<SupplierDTO?> GetByIDAsync(int supplierID)
		{
			SupplierModel? supplier = await context.Suppliers
				.Include(sup => sup.SupplierCompanies)
				.FirstOrDefaultAsync(sup => sup.ID == supplierID);

			if (supplier == null) return null;
			else return SupplierMapper.ModelToDTO(supplier);
		}

		public async Task<SupplierDTO?> GetByDocNumberAsync(string docType, string docNumber)
		{
			if (docType.ToLower() == "cnpj")
			{
				SupplierModel? supplier = await context.Suppliers
					.Include(sup => sup.SupplierCompanies)
					.FirstOrDefaultAsync(sup => sup.CNPJ == docNumber);

				if (supplier == null) return null;
				else return SupplierMapper.ModelToDTO(supplier);
			}
			else
			{
				SupplierModel? supplier = await context.Suppliers
					.Include(sup => sup.SupplierCompanies)
					.FirstOrDefaultAsync(sup => sup.CPF == docNumber);

				if (supplier == null) return null;
				else return SupplierMapper.ModelToDTO(supplier);
			}
		}

		public async Task<bool?> AddAsync(SupplierPostDTO? supplierPostDTO)
		{
			if (supplierPostDTO == null) return null;
			else
			{
				SupplierModel? supplier = SupplierMapper.DTOToModel(null, supplierPostDTO);

				if (supplier == null) return null;
				else
				{
					await context.Suppliers.AddAsync(supplier);
					await context.SaveChangesAsync();

					return true;
				}
			}
		}

		public async Task<SupplierModel?> UpdateByIDAsync(int supplierID, SupplierDTO? supplierDTO)
		{
			if (supplierDTO == null) return null;
			else
			{
				SupplierModel? supplier = await context.Suppliers
					.FindAsync(supplierID);

				if (supplier == null) return null;
				else
				{
					SupplierMapper.DTOToModelPut(supplierDTO, supplier);
					await context.SaveChangesAsync();

					return supplier;
				}
			}
		}

		public async Task<bool?> RemoveByIDAsync(int supplierID)
		{
			SupplierModel? supplier = await context.Suppliers
				.FindAsync(supplierID);

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
