using BludataAPI.DTOs.Company;
using BludataAPI.Models;
using BludataAPI.Utils;

namespace BludataAPI.Mappers
{
	public static class CompanyMapper
	{
		public static CompanyDTO? ModelToDTO(CompanyModel? companyModel)
		{
			if (companyModel == null) return null;
			else
			{
				return new()
				{
					Name = companyModel.Name,
					UF = companyModel.UF.ToUpper(),
					CNPJ = companyModel.CNPJ,

					CompanySuppliers = companyModel.CompanySuppliers
				};
			}
		}

		public static CompanyModel? DTOToModel(CompanyDTO? companyDTO = null, CompanyPostDTO? companyPostDTO = null)
		{
			if (companyDTO != null)
			{
				return new()
				{
					Name = companyDTO.Name,
					UF = companyDTO.UF.ToUpper(),
					CNPJ = companyDTO.CNPJ,

					CompanySuppliers = companyDTO.CompanySuppliers
				};
			}
			else if (companyPostDTO != null)
			{
				return new()
				{
					Name = companyPostDTO.Name,
					UF = companyPostDTO.UF.ToUpper(),
					CNPJ = companyPostDTO.CNPJ
				};
			}
			else return null;
		}

		public static bool? DTOToModelPut(CompanyDTO? companyDTO, CompanyModel? companyModel)
		{
			if (companyDTO == null || companyModel == null) return null;
			else
			{
				try
				{
					companyModel.Name = companyDTO.Name;
					companyModel.UF = companyDTO.UF.ToUpper();
					companyModel.CNPJ = companyDTO.CNPJ;

					companyModel.CompanySuppliers = Validator.ValidateCompanySuppliersAge(companyDTO);

					return true;
				}
				catch (Exception exc) { throw new Exception(exc.Message); }
			}
		}

		public static CompanyModel? CompanyPostDTOToModel(CompanyPostDTO companyPostDTO)
		{
			if (companyPostDTO == null) return null;
			else
			{
				return new()
				{
					Name = companyPostDTO.Name,
					UF = companyPostDTO.UF.ToUpper(),
					CNPJ = companyPostDTO.CNPJ,
				};
			}
		}
	}
}
