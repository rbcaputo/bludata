using BludataAPI.DTOs.Company;
using BludataAPI.Models;

namespace BludataAPI.Interfaces.Company
{
	public interface ICompanyMapper
	{
		public CompanyDTOGet ModelToDTOGet(CompanyModel companyModel);
		public CompanyDTO ModelToDTO(CompanyModel companyModel);
		
		public Task<CompanyModel> DTOToModelAsync(CompanyDTO companyDTO);
		public Task<CompanyModel> DTOToModelPutAsync(CompanyModel companyModel, CompanyDTO companyDTO);
	}
}
