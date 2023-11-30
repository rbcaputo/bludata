using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Mappers
{
	public class CompanyMapper
	{
		public static CompanyDTO ModelToDTO(CompanyModel companyModel)
		{
			List<SupplierDTO> suppliers = [];

			foreach (SupplierModel supplier in companyModel.Suppliers)
			{
				SupplierDTO supplierDTO = SupplierMapper.ModelToDTO(supplier);

				suppliers.Add(supplierDTO);
			}

			return new()
			{
				Name = companyModel.Name,
				UF = companyModel.UF.ToUpper(),
				CNPJ = companyModel.CNPJ,
				Suppliers = suppliers
			};
		}

		public static CompanyModel DTOToModel(CompanyDTO companyDTO)
		{
			List<SupplierModel> suppliers = [];

			foreach (SupplierDTO supplier in companyDTO.Suppliers)
			{
				SupplierModel supplierModel = SupplierMapper.DTOToModel(supplier);

				suppliers.Add(supplierModel);
			}

			return new()
			{
				Name = companyDTO.Name,
				UF = companyDTO.UF.ToUpper(),
				CNPJ = companyDTO.CNPJ,
				Suppliers = suppliers
			};
		}
	}
}
