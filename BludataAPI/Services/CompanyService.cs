using BludataAPI.Data;
using BludataAPI.DTOs;
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
			List<CompanyModel>? companies = await context.Companies.ToListAsync();

			if (companies.Count == 0) return null;
			else return companies;
		}
		public async Task<CompanyModel?> GetByIDAsync(int companyID)
		{
			CompanyModel? company = await context.Companies.FindAsync(companyID);

			if (company == null) return null;
			else return company;
		}
		public async Task<List<CompanyDTO>?> GetByNameAsync(string companyName)
		{
			List<CompanyDTO>? companies = await context.Companies.Where(com => com.Name.ToLower() == companyName.ToLower())
				.Select(com => CompanyMapper.ModelToDTO(com)).ToListAsync();

			if (companies.Count == 0) return null;
			else return companies;
		}

		public async Task<bool> AddAsync(CompanyDTO companyDTO)
		{
			CompanyModel company = CompanyMapper.DTOToModel(companyDTO);

			await context.AddAsync(company);
			await context.SaveChangesAsync();

			return true;
		}
		public async Task<bool?> EditByIDAsync(int companyID, CompanyDTO companyDTO)
		{
			CompanyModel? company = await context.Companies.FindAsync(companyID);

			if (company == null) return null;
			else
			{
				CompanyMapper.DTOToModelPut(company, companyDTO);

				await context.SaveChangesAsync();

				return true;
			}
		}
		public async Task<bool?> RemoveByIDAsync(int companyID)
		{
			CompanyModel? company = await context.Companies.FindAsync(companyID);

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
