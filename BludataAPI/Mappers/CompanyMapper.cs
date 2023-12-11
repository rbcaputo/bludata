using BludataAPI.Data;
using BludataAPI.DTOs.Company;
using BludataAPI.DTOs.Supplier;
using BludataAPI.Interfaces.Company;
using BludataAPI.Interfaces.Supplier;
using BludataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BludataAPI.Mappers
{
	public class CompanyMapper(DataContext context, Lazy<ISupplierMapper> mapper) : ICompanyMapper
	{
		public CompanyDTOGet ModelToDTOGet(CompanyModel companymodel)
		{
			return new()
			{
				Name = companymodel.Name,
				UF = companymodel.UF,
				CNPJ = companymodel.CNPJ
			};
		}

		public CompanyDTO ModelToDTO(CompanyModel companyModel)
		{
			List<SupplierDTOGet> suppliers = [];

			foreach (SupplierModel supplier in companyModel.Suppliers) suppliers.Add(mapper.Value.ModelToDTOGet(supplier));

			return new()
			{
				ID = companyModel.ID,
				Name = companyModel.Name,
				UF = companyModel.UF.ToUpper(),
				CNPJ = companyModel.CNPJ,
				Suppliers = suppliers
			};
		}

		private async Task<List<SupplierModel>> CheckSuppliersAsync(CompanyDTO companyDTO)
		{
			List<SupplierModel> suppliers = [];

			if (companyDTO.Suppliers.Count != 0)
			{
				foreach (SupplierDTOGet supplier in companyDTO.Suppliers)
				{
					if (supplier.DocType.ToLower() == "cnpj")
					{
						SupplierModel? result = await context.Suppliers.FirstOrDefaultAsync(sup => sup.CNPJ == supplier.CNPJ);

						if (result == null) throw new Exception("One or more supplier entries nonexistent or not found.");
						else suppliers.Add(result);
					}
					else
					{
						SupplierModel? result = await context.Suppliers.FirstOrDefaultAsync(sup => sup.CPF == supplier.CPF);

						if (result == null) throw new Exception("One or more supplier entries nonexistent or not found.");
						else suppliers.Add(result);
					}
				}
			}

			return suppliers;
		}

		public async Task<CompanyModel> DTOToModelAsync(CompanyDTO companyDTO)
		{
			try
			{
				return new()
				{
					ID = companyDTO.ID,
					Name = companyDTO.Name,
					UF = companyDTO.UF.ToUpper(),
					CNPJ = companyDTO.CNPJ,
					Suppliers = await CheckSuppliersAsync(companyDTO)
				};
			}
			catch (Exception exc) { throw new Exception(exc.ToString()); }
		}

		public async Task<CompanyModel> DTOToModelPutAsync(CompanyModel companyModel, CompanyDTO companyDTO)
		{
			try
			{
				companyModel.Name = companyDTO.Name;
				companyModel.UF = companyDTO.UF.ToUpper();
				companyModel.CNPJ = companyDTO.CNPJ;
				companyModel.Suppliers = await CheckSuppliersAsync(companyDTO);
			
				return companyModel;
			}
			catch (Exception exc) { throw new Exception(exc.ToString()); }
		}
	}
}