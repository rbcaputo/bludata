using BludataAPI.Data;
using BludataAPI.DTOs;
using BludataAPI.Interfaces;
using BludataAPI.Mappers;
using BludataAPI.Models;

namespace BludataAPI.Services
{
	public class CompanyService(DataContext context, CompanyMapper mapper) : ICompanyService
	{
		private readonly DataContext _context = context;
		private readonly CompanyMapper _mapper = mapper;

		public async Task<CompanyDTO> AddAsync(CompanyDTO companyDTO)
		{
			CompanyModel company = _mapper.CompanyDTOToModel(companyDTO);

			await _context.AddAsync(company);
			await _context.SaveChangesAsync();

			return _mapper.CompanyModelToDTO(company);
		}

		public async Task<CompanyDTO?> EditByIDAsync(int companyID, CompanyDTO companyDTO)
		{
			CompanyModel? company = await _context.Companies.FindAsync(companyID);

			if (company == null) return null;
			else
			{
				company = _mapper.CompanyDTOToModel(companyDTO);

				await _context.SaveChangesAsync();

				return _mapper.CompanyModelToDTO(company);
			}
		}

		public async Task<bool?> RemoveByIDAsync(int companyID)
		{
			CompanyModel? company = await _context.Companies.FindAsync(companyID);

			if (company == null) return null;
			else
			{
				_context.Remove(company);

				await _context.SaveChangesAsync();

				return true;
			}
		}
	}
}
