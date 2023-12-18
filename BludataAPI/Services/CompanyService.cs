using BludataAPI.Data;
using BludataAPI.DTOs.Company;
using BludataAPI.Interfaces;
using BludataAPI.Mappers;
using BludataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BludataAPI.Services
{
	public class CompanyService(DataContext context) : ICompanyService
	{
		public async Task<List<CompanyModel>?> GetAllAsync()
		{
			List<CompanyModel>? companies = await context.Companies
				.Include(com => com.CompanySuppliers)
				.ThenInclude(sup => sup.Supplier)
				.ToListAsync();

			if (companies.Count == 0) return null;
			else return companies;
		}

		public async Task<List<CompanyDTO?>?> GetAllByUFAsync(string companiesUF)
		{
			List<CompanyDTO?> companies = await context.Companies
				.Where(com => com.UF == companiesUF)
				.Include(com => com.CompanySuppliers)
				.ThenInclude(sup => sup.Supplier)
				.Select(com => CompanyMapper.ModelToDTO(com))
				.ToListAsync();

			if (companies.Count == 0) return null;
			else return companies;
		}

		public async Task<CompanyDTO?> GetByIDAsync(int companyID)
		{
			CompanyModel? company = await context.Companies
				.Include(com => com.CompanySuppliers)
				.ThenInclude(sup => sup.Supplier)
				.FirstOrDefaultAsync(com => com.ID == companyID);

			if (company == null) return null;
			else return CompanyMapper.ModelToDTO(company);
		}

		public async Task<CompanyDTO?> GetByCNPJAsync(string companyCNPJ)
		{
			CompanyModel? company = await context.Companies
				.Where(com => com.CNPJ == companyCNPJ)
				.Include(com => com.CompanySuppliers)
				.ThenInclude(sup => sup.Supplier)
				.FirstOrDefaultAsync();

			if (company == null) return null;
			else return CompanyMapper.ModelToDTO(company);
		}

		public async Task<CompanyDTO?> GetByNameAsync(string companyName)
		{
			CompanyModel? company = await context.Companies
				.Where(com => com.Name == companyName)
				.Include(com => com.CompanySuppliers)
				.ThenInclude(sup => sup.Supplier)
				.FirstOrDefaultAsync();

			if (company == null) return null;
			else return CompanyMapper.ModelToDTO(company);
		}

		public async Task<bool?> AddAsync(CompanyPostDTO? companyPostDTO)
		{
			if (companyPostDTO == null) return null;
			else
			{
				CompanyModel? company = CompanyMapper.DTOToModel(null, companyPostDTO);

				if (company == null) return null;
				else
				{
					await context.Companies.AddAsync(company);
					await context.SaveChangesAsync();

					return true;
				}
			}
		}

		public async Task<CompanyModel?> UpdateByIDAsync(int companyID, CompanyDTO? companyDTO)
		{
			if (companyDTO == null) return null;
			else
			{
				try
				{
					CompanyModel? company = await context.Companies
					.FindAsync(companyID);

					if (company == null) return null;
					else
					{
						CompanyMapper.DTOToModelPut(companyDTO, company);
						await context.SaveChangesAsync();

						return company;
					}
				}
				catch (Exception exc) { throw new Exception(exc.Message); }
			}
		}

		public async Task<bool?> RemoveByIDAsync(int companyID)
		{
			CompanyModel? company = await context.Companies
				.FindAsync(companyID);

			if (company == null) return null;
			else
			{
				context.Companies.Remove(company);
				await context.SaveChangesAsync();

				return true;
			}
		}
	}
}
