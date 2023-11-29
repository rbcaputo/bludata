using BludataAPI.Data;
using BludataAPI.DTOs;
using BludataAPI.Interfaces;
using BludataAPI.Mappers;
using BludataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BludataAPI.Services
{
	public class SupplierService(DataContext context, SupplierMapper mapper) : ISupplierService
	{
		private readonly DataContext _context = context;
		private readonly SupplierMapper _mapper = mapper;

		public async Task<List<SupplierModel>?> GetAllAsync()
		{
			List<SupplierModel>? suppliers = await _context.Suppliers.ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}
		public async Task<SupplierModel?> GetByIDAsync(int supplierID)
		{
			SupplierModel? supplier = await _context.Suppliers.FindAsync(supplierID);

			if (supplier == null) return null;
			else return supplier;
		}
		public async Task<List<SupplierDTO>?> GetByNameAsync(string supplierName)
		{
			List<SupplierDTO>? suppliers = await _context.Suppliers.Select(sup => _mapper.ModelToDTO(sup)).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}
		public async Task<List<SupplierDTO>?> GetByCompanyNameAsync(string companyName)
		{
			List<SupplierDTO>? suppliers = await _context.Suppliers.Where(sup => sup.Companies.Any(com => com.Name == companyName))
				.Select(sup => _mapper.ModelToDTO(sup)).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}
		public async Task<List<SupplierDTO>?> GetByCompanyUFAsync(string companyUF)
		{
			List<SupplierDTO>? suppliers = await _context.Suppliers.Where(sup => sup.Companies.Any(com => com.UF == companyUF))
				.Select(sup => _mapper.ModelToDTO(sup)).ToListAsync();

			if (suppliers.Count == 0) return null;
			else return suppliers;
		}

		public async Task<SupplierDTO> AddAsync(SupplierDTO supplierDTO)
		{
			SupplierModel supplier = _mapper.DTOToModel(supplierDTO);

			await _context.Suppliers.AddAsync(supplier);
			await _context.SaveChangesAsync();

			return _mapper.ModelToDTO(supplier);
		}
		public async Task<SupplierDTO?> EditByIDAsync(int supplierID, SupplierDTO supplierDTO)
		{
			SupplierModel? supplier = await _context.Suppliers.FindAsync(supplierID);

			if (supplier == null) return null;
			else
			{
				supplier = _mapper.DTOToModel(supplierDTO);

				await _context.SaveChangesAsync();

				return _mapper.ModelToDTO(supplier);
			}
		}
		public async Task<bool?> RemoveByIDAsync(int supplierID)
		{
			SupplierModel? supplier = await _context.Suppliers.FindAsync(supplierID);

			if (supplier == null) return null;
			else
			{
				_context.Suppliers.Remove(supplier);

				await _context.SaveChangesAsync();

				return true;
			}
		}
	}
}
