using BludataAPI.Data;
using BludataAPI.DTOs.Company;
using BludataAPI.DTOs.Supplier;
using BludataAPI.Interfaces.Supplier;
using BludataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BludataAPI.Mappers
{
	public class SupplierMapper(DataContext context) : ISupplierMapper
	{
		//public SupplierDTOGet ModelToDTOGet(SupplierModel supplierModel)
		//{
		//	return new()
		//	{
		//		Name = supplierModel.Name,
		//		DocType = supplierModel.DocType,
		//		SubDate = supplierModel.SubDate,
		//		Phones = supplierModel.Phones,

		//		CNPJ = supplierModel.CNPJ,
		//		CPF = supplierModel.CPF,
		//		RG = supplierModel.RG,
		//		BirthDate = supplierModel.BirthDate
		//	};
		//}

		public SupplierDTO ModelToDTO(SupplierModel supplierModel)
		{
			List<CompanyDTOGet> companies = [];

			foreach (CompanyModel company in supplierModel.Companies) companies.Add(new()
			{
				Name = company.Name,
				UF = company.UF,
				CNPJ = company.CNPJ
			});

			return new()
			{
				ID = supplierModel.ID,
				Name = supplierModel.Name,
				DocType = supplierModel.DocType.ToUpper(),
				SubDate = supplierModel.SubDate,
				Phones = supplierModel.Phones,
				Companies = companies,

				CNPJ = supplierModel.CNPJ,
				CPF = supplierModel.CPF,
				RG = supplierModel.RG,
				BirthDate = supplierModel.BirthDate
			};
		}

		private async Task<List<CompanyModel>> CheckCompaniesAsync(SupplierDTO supplierDTO)
		{
			List<CompanyModel> companies = [];

			if (supplierDTO.Companies.Count != 0)
			{
				foreach (CompanyDTOGet company in supplierDTO.Companies)
				{
					CompanyModel? result = await context.Companies.FirstOrDefaultAsync(com => com.CNPJ == company.CNPJ);

					if (result == null) throw new Exception("One or more company entries nonexistent or not found.");
					else companies.Add(result);
				}
			}

			return companies;
		}

		public async Task<SupplierModel> DTOToModelAsync(SupplierDTO supplierDTO)
		{
			return new()
			{
				Name = supplierDTO.Name,
				DocType = supplierDTO.DocType.ToUpper(),
				SubDate = supplierDTO.SubDate,
				Phones = supplierDTO.Phones,
				Companies = await CheckCompaniesAsync(supplierDTO),

				CNPJ = supplierDTO.CNPJ,
				CPF = supplierDTO.CPF,
				RG = supplierDTO.RG,
				BirthDate = supplierDTO.BirthDate
			};
		}

		public async Task<SupplierModel> DTOToModelPutAsync(SupplierModel supplierModel, SupplierDTO supplierDTO)
		{
			supplierModel.Name = supplierDTO.Name;
			supplierModel.DocType = supplierDTO.DocType.ToUpper();
			supplierModel.Phones = supplierDTO.Phones;
			supplierModel.Companies = await CheckCompaniesAsync(supplierDTO);

			supplierModel.CNPJ = supplierDTO.CNPJ;
			supplierModel.CPF = supplierDTO.CPF;
			supplierModel.RG = supplierDTO.RG;
			supplierModel.BirthDate = supplierDTO.BirthDate;

			return supplierModel;
		}
	}
}
