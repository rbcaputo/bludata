using BludataAPI.DTOs.Supplier;
using BludataAPI.Models;
using BludataAPI.Utils;

namespace BludataAPI.Mappers
{
	public static class SupplierMapper
	{
		public static SupplierDTO? ModelToDTO(SupplierModel? supplierModel)
		{
			if (supplierModel == null) return null;
			else
			{
				return new()
				{
					Name = supplierModel.Name,
					DocType = supplierModel.DocType.ToUpper(),
					SubDate = supplierModel.SubDate,
					Phones = supplierModel.Phones,

					CNPJ = supplierModel.CNPJ,
					CPF = supplierModel.CPF,
					RG = supplierModel.RG,
					BirthDate = supplierModel.BirthDate,

					SupplierCompanies = supplierModel.SupplierCompanies
				};
			}
		}

		public static SupplierModel? DTOToModel(SupplierDTO? supplierDTO = null, SupplierPostDTO? supplierPostDTO = null)
		{
			if (supplierDTO != null)
			{
				return new()
				{
					Name = supplierDTO.Name,
					DocType = supplierDTO.DocType.ToUpper(),
					SubDate = supplierDTO.SubDate,
					Phones = supplierDTO.Phones,

					CNPJ = supplierDTO.CNPJ,
					CPF = supplierDTO.CPF,
					RG = supplierDTO.RG,
					BirthDate = supplierDTO.BirthDate,

					SupplierCompanies = supplierDTO.SupplierCompanies
				};
			}
			else if (supplierPostDTO != null)
			{
				return new()
				{
					Name = supplierPostDTO.Name,
					DocType = supplierPostDTO.DocType.ToUpper(),
					SubDate = supplierPostDTO.SubDate,
					Phones = supplierPostDTO.Phones,

					CNPJ = supplierPostDTO.CNPJ,
					CPF = supplierPostDTO.CPF,
					RG = supplierPostDTO.RG,
					BirthDate = supplierPostDTO.BirthDate
				};
			}
			else return null;
		}

		public static bool? DTOToModelPut(SupplierDTO supplierDTO, SupplierModel supplierModel)
		{
			if (supplierDTO == null || supplierModel == null) return null;
			else
			{
				try
				{
					supplierModel.Name = supplierDTO.Name;
					supplierModel.DocType = supplierDTO.DocType;
					supplierModel.SubDate = supplierDTO.SubDate;
					supplierModel.Phones = supplierDTO.Phones;

					supplierModel.CNPJ = supplierDTO.CNPJ;
					supplierModel.CPF = supplierDTO.CPF;
					supplierModel.RG = supplierDTO.RG;
					supplierModel.BirthDate = supplierDTO.BirthDate;

					supplierModel.SupplierCompanies = Validator.ValidateSuppliersCompanyUF(supplierDTO);

					return true;
				}
				catch (Exception exc) { throw new Exception(exc.Message); }
			}
		}

		public static SupplierModel? SupplierModelPostDTOToModel(SupplierDTO? supplierDTO)
		{
			if (supplierDTO == null) return null;
			else
			{
				return new()
				{
					Name = supplierDTO.Name,
					DocType = supplierDTO.DocType.ToUpper(),
					SubDate = supplierDTO.SubDate,
					Phones = supplierDTO.Phones,

					CNPJ = supplierDTO.CNPJ,
					CPF = supplierDTO.CPF,
					RG = supplierDTO.RG,
					BirthDate = supplierDTO.BirthDate,
				};
			}
		}
	}
}
