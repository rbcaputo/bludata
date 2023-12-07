using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Mappers
{
	public class SupplierMapper
	{
		public static SupplierDTOGet ModelToDTOGet(SupplierModel supplierModel)
		{
			return new()
			{
				Name = supplierModel.Name,
				DocType = supplierModel.DocType,

				CNPJ = supplierModel.CNPJ,
				CPF = supplierModel.CPF,
				RG = supplierModel.RG,
				BirthDate = supplierModel.BirthDate
			};
		}

		public static SupplierDTO ModelToDTO(SupplierModel supplierModel)
		{
			List<CompanyDTOGet> companies = [];

			foreach (CompanyModel company in supplierModel.Companies) companies.Add(CompanyMapper.ModelToDTOGet(company));

			return new()
			{
				ID = supplierModel.ID,
				Name = supplierModel.Name,
				DocType = supplierModel.DocType.ToUpper(),
				SubDate = supplierModel.SubDate,
				Companies = companies,

				CNPJ = supplierModel.CNPJ,
				CPF = supplierModel.CPF,
				RG = supplierModel.RG,
				BirthDate = supplierModel.BirthDate
			};
		}

		//public static SupplierModel DTOGetToModel(SupplierDTOGet supplierDTOGet)
		//{
		//	return new()
		//	{
		//		Name = supplierDTOGet.Name,
		//		DocType = supplierDTOGet.DocType.ToUpper(),
		//		SubDate = supplierDTOGet.SubDate,

		//		CNPJ = supplierDTOGet.CNPJ,
		//		CPF = supplierDTOGet.CPF,
		//		RG = supplierDTOGet.RG,
		//		BirthDate = supplierDTOGet.BirthDate
		//	};
		//}

		public static SupplierModel DTOToModel(SupplierDTO supplierDTO, List<CompanyModel>? companyModelList = null)
		{
			return new()
			{
				Name = supplierDTO.Name,
				DocType = supplierDTO.DocType.ToUpper(),
				SubDate = supplierDTO.SubDate,
				Companies = companyModelList ??= [],

				CNPJ = supplierDTO.CNPJ,
				CPF = supplierDTO.CPF,
				RG = supplierDTO.RG,
				BirthDate = supplierDTO.BirthDate
			};
		}

		public static SupplierModel DTOToModelPut(SupplierModel supplierModel, SupplierDTO supplierDTO, List<CompanyModel>? companyModelList = null)
		{
			supplierModel.Name = supplierDTO.Name;
			supplierModel.DocType = supplierDTO.DocType.ToUpper();
			supplierModel.Companies = companyModelList ??= [];

			supplierModel.CNPJ = supplierDTO.CNPJ;
			supplierModel.CPF = supplierDTO.CPF;
			supplierModel.RG = supplierDTO.RG;
			supplierModel.BirthDate = supplierDTO.BirthDate;

			return supplierModel;
		}
	}
}
