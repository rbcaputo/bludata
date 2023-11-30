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
			List<SupplierModel>? suppliers = await context.Suppliers.ToListAsync();

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
			List<SupplierDTO>? suppliers = await context.Suppliers.Where(sup => sup.Companies.Any(com => com.Name.Equals(companyName, StringComparison.CurrentCultureIgnoreCase)))
				.Select(sup => SupplierMapper.ModelToDTO(sup)).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}
		public async Task<List<SupplierDTO>?> GetByCompanyUFAsync(string companyUF)
		{
			List<SupplierDTO>? suppliers = await context.Suppliers.Where(sup => sup.Companies.Any(com => com.UF.Equals(companyUF, StringComparison.CurrentCultureIgnoreCase)))
				.Select(sup => SupplierMapper.ModelToDTO(sup)).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}

		public async Task<SupplierDTO> AddAsync(SupplierDTO supplierDTO)
		{
			SupplierModel supplier = SupplierMapper.DTOToModel(supplierDTO);

			
		}
		public async Task<SupplierDTO?> EditByIDAsync(int supplierID, SupplierDTO supplierDTO)
		{
			SupplierModel? supplier = await context.Suppliers.FindAsync(supplierID);
			int supplierAge = 0;

			if (supplier == null) return null;
			else
			{
				if (supplier.BirthDate != null)
				{
					supplierAge = DateTime.Now.Year - supplier.BirthDate.Value.Year;

					if (DateTime.Now < supplier.BirthDate.Value.AddYears(supplierAge)) supplierAge--;
				}

				if (supplier.Companies.Any(com => com.UF.Equals("PR", StringComparison.CurrentCultureIgnoreCase)) && supplierAge < 18) throw new InvalidOperationException("An under legal age supplier can't be assigned to a company registered in PR.");
				else
				{
					supplier = SupplierMapper.DTOToModel(supplierDTO);

					await context.SaveChangesAsync();

					return SupplierMapper.ModelToDTO(supplier);
				}
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
