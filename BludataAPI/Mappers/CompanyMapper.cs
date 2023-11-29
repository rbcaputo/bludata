using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Mappers
{
	public class CompanyMapper
	{
		public CompanyDTO CompanyModelToDTO(CompanyModel companyModel)
		{
			return new()
			{
				Name = companyModel.Name,
				UF = companyModel.UF,
				CNPJ = companyModel.CNPJ
			};
		}

		public CompanyModel CompanyDTOToModel(CompanyDTO companyDTO) { return new(companyDTO.Name, companyDTO.UF, companyDTO.CNPJ); }
	}
}
