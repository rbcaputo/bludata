using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Mappers
{
	public class CompanyMapper(SupplierMapper mapper)
	{
		private readonly SupplierMapper _mapper = mapper;

		public CompanyDTO ModelToDTO(CompanyModel companyModel)
		{
			List<SupplierDTO> suppliers = [];

			foreach (SupplierModel supplier in companyModel.Suppliers)
			{
				SupplierDTO supplierDTO = _mapper.ModelToDTO(supplier);

				suppliers.Add(supplierDTO);
			}

			return new()
			{
				Name = companyModel.Name,
				UF = companyModel.UF,
				CNPJ = companyModel.CNPJ,
				Suppliers = suppliers
			};
		}

		public CompanyModel DTOToModel(CompanyDTO companyDTO)
		{
			List<SupplierModel> suppliers = [];

			foreach (SupplierDTO supplier in companyDTO.Suppliers)
			{
				SupplierModel supplierModel = _mapper.DTOToModel(supplier);

				suppliers.Add(supplierModel);
			}

			return new(companyDTO.Name, companyDTO.UF, companyDTO.CNPJ, suppliers);
		}
	}
}
