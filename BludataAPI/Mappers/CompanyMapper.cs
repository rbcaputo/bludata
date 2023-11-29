using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Mappers
{
	public class CompanyMapper
	{
		public CompanyDTO ModelToDTO(CompanyModel companyModel)
		{
			return new()
			{
				Name = companyModel.Name,
				UF = companyModel.UF,
				CNPJ = companyModel.CNPJ
			};
		}

		public CompanyModel DTOToModel(CompanyDTO companyDTO) { return new(companyDTO.Name, companyDTO.UF, companyDTO.CNPJ); }
	}
}
