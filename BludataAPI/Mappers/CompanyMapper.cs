using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Mappers
{
	public class CompanyMapper
	{
		public static CompanyDTOGet ModelToDTOGet(CompanyModel companymodel)
		{
			return new()
			{
				Name = companymodel.Name,
				UF = companymodel.UF,
				CNPJ = companymodel.CNPJ
			};
		}

		public static CompanyDTO ModelToDTO(CompanyModel companyModel)
		{
			List<SupplierDTOGet> suppliers = [];

			foreach (SupplierModel supplier in companyModel.Suppliers) suppliers.Add(SupplierMapper.ModelToDTOGet(supplier));

			return new()
			{
				ID = companyModel.ID,
				Name = companyModel.Name,
				UF = companyModel.UF.ToUpper(),
				CNPJ = companyModel.CNPJ,
				Suppliers = suppliers,
			};
		}

		//public static CompanyModel DTOToModel(CompanyDTOGet companyDTOGet)
		//{
		//	return new()
		//	{
		//		Name= companyDTOGet.Name,
		//		UF = companyDTOGet.UF,
		//		CNPJ = companyDTOGet.CNPJ
		//	};
		//}

		public static CompanyModel DTOToModel(CompanyDTO companyDTO, List<SupplierModel>? supplierModelList = null)
		{
			return new()
			{
				ID = companyDTO.ID,
				Name = companyDTO.Name,
				UF = companyDTO.UF.ToUpper(),
				CNPJ = companyDTO.CNPJ,
				Suppliers = supplierModelList ??= []
			};
		}

		public static CompanyModel DTOToModelPut(CompanyModel companyModel, CompanyDTO companyDTO, List<SupplierModel>? supplierModelList = null)
		{
			companyModel.Name = companyDTO.Name;
			companyModel.UF = companyDTO.UF.ToUpper();
			companyModel.CNPJ = companyDTO.CNPJ;
			companyModel.Suppliers = supplierModelList ??= [];

			return companyModel;
		}
	}
}
