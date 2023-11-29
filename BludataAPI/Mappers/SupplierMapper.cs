using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Mappers
{
	public class SupplierMapper
	{
		public SupplierDTO ModelToDTO(SupplierModel supplierModel)
		{
			return new()
			{
				Name = supplierModel.Name,
				DocType = supplierModel.DocType,
				SubDate = supplierModel.SubDate,
				Companies = supplierModel.Companies,

				CPF = supplierModel.CPF,
				CNPJ = supplierModel.CNPJ,
				RG = supplierModel.RG,
				BirthDate = supplierModel.BirthDate
			};
		}

		public SupplierModel DTOToModel(SupplierDTO supplierDTO) { return new(supplierDTO.Name, supplierDTO.DocType, supplierDTO.Companies, supplierDTO.SubDate, supplierDTO.CPF, supplierDTO.CNPJ, supplierDTO.RG, supplierDTO.BirthDate); }
	}
}
