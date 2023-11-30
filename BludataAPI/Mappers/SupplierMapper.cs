using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Mappers
{
	public class SupplierMapper(CompanyMapper mapper)
	{
		private readonly CompanyMapper _mapper = mapper;

		public SupplierDTO ModelToDTO(SupplierModel supplierModel)
		{
			List<CompanyDTO> companies = [];

			foreach (CompanyModel company in supplierModel.Companies)
			{
				CompanyDTO companyDTO = _mapper.ModelToDTO(company);

				companies.Add(companyDTO);
			}

			return new()
			{
				Name = supplierModel.Name,
				DocType = supplierModel.DocType,
				SubDate = supplierModel.SubDate,
				Companies = companies,

				CPF = supplierModel.CPF,
				CNPJ = supplierModel.CNPJ,
				RG = supplierModel.RG,
				BirthDate = supplierModel.BirthDate
			};
		}

		public SupplierModel DTOToModel(SupplierDTO supplierDTO)
		{
			List<CompanyModel> companies = [];

			foreach (CompanyDTO company in supplierDTO.Companies)
			{
				CompanyModel companyModel = _mapper.DTOToModel(company);

				companies.Add(companyModel);
			}

			return new(supplierDTO.Name, supplierDTO.DocType, companies, supplierDTO.SubDate, supplierDTO.CPF, supplierDTO.CNPJ, supplierDTO.RG, supplierDTO.BirthDate);
		}
	}
}
