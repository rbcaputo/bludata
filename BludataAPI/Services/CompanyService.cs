using BludataAPI.Data;
using BludataAPI.DTOs.Company;
using BludataAPI.Interfaces;
using BludataAPI.Interfaces.Company;
using BludataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BludataAPI.Services
{
	public class CompanyService(DataContext context, IMapperFactory factory) : ICompanyService
	{
		private readonly Lazy<ICompanyMapper> _mapper = factory.CreateCompanyMapper(context);

		public async Task<List<CompanyDTO>?> GetAllAsync()
		{
			List<CompanyModel>? companies = await context.Companies.Include(com => com.Suppliers).ToListAsync();

			if (companies.Count == 0) return null;
			else
			{
				List<CompanyDTO> results = [];

				foreach (CompanyModel company in companies) results.Add(_mapper.Value.ModelToDTO(company));

				return results;
			}
		}
		public async Task<CompanyDTO?> GetByIDAsync(int companyID)
		{
			CompanyModel? company = await context.Companies.FindAsync(companyID);

			if (company == null) return null;
			else
			{
				CompanyDTO result = _mapper.Value.ModelToDTO(company);

				return result;
			}
		}
		public async Task<List<CompanyDTO>?> GetByNameAsync(string companyName)
		{
			List<CompanyDTO>? companies = await context.Companies
				.Where(com => com.Name.ToLower() == companyName.ToLower())
				.Include(com => com.Suppliers)
				.Select(com => _mapper.Value.ModelToDTO(com))
				.ToListAsync();

			if (companies.Count == 0) return null;
			else return companies;
		}

		public async Task<bool> AddAsync(CompanyDTO companyDTO)
		{
			CompanyModel company = await _mapper.Value.DTOToModelAsync(companyDTO);

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
				await _mapper.Value.DTOToModelPutAsync(company, companyDTO);
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
