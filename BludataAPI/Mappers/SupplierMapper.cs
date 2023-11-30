using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Mappers
{
	public class SupplierMapper
	{
		public static SupplierDTO ModelToDTO(SupplierModel supplierModel)
		{
			List<CompanyDTO> companies = [];

			foreach (CompanyModel company in supplierModel.Companies)
			{
				CompanyDTO companyDTO = CompanyMapper.ModelToDTO(company);

				companies.Add(companyDTO);
			}

			return new()
			{
				Name = supplierModel.Name,
				DocType = supplierModel.DocType.ToUpper(),
				SubDate = supplierModel.SubDate,
				Companies = companies,

				CPF = supplierModel.CPF,
				CNPJ = supplierModel.CNPJ,
				RG = supplierModel.RG,
				BirthDate = supplierModel.BirthDate
			};
		}

		public static SupplierModel DTOToModel(SupplierDTO supplierDTO)
		{
			List<CompanyModel> companies = [];

			foreach (CompanyDTO company in supplierDTO.Companies)
			{
				CompanyModel companyModel = CompanyMapper.DTOToModel(company);

				companies.Add(companyModel);
			}

			return new()
			{
				Name= supplierDTO.Name,
				DocType = supplierDTO.DocType.ToUpper(),
				SubDate = supplierDTO.SubDate,
				Companies = companies,

				CPF = supplierDTO.CPF,
				CNPJ= supplierDTO.CNPJ,
				RG = supplierDTO.RG,
				BirthDate = supplierDTO.BirthDate
			};
		}
	}
}
