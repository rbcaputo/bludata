using BludataAPI.DTOs.Company;
using BludataAPI.DTOs.Supplier;
using BludataAPI.Models;

namespace BludataAPI.Utils
{
	public static class Validator
	{
		public static List<CompanySupplierModel> ValidateCompanySuppliersAge(CompanyDTO? companyDTO = null, string companyUF = "pr", int legalAge = 18)
		{
			if (companyDTO == null) return [];
			else
			{
				List<CompanySupplierModel> companySuppliers = [];

				if (companyDTO.CompanySuppliers.Count != 0)
				{
					foreach (CompanySupplierModel companySupplier in companyDTO.CompanySuppliers)
					{
						if (companyDTO.UF.ToLower() == companyUF
								&& DateTime.Now.Year - companySupplier.Supplier!.BirthDate!.Value.Year > legalAge) companySuppliers.Add(companySupplier);
						else throw new Exception($"A supplier entry under the age of {legalAge} cannot be registered in a company entry from {companyUF}");
					}
				}

				return companySuppliers;
			}
		}

		public static List<CompanySupplierModel> ValidateSuppliersCompanyUF(SupplierDTO? supplierDTO, string companyUF = "pr", int legalAge = 18)
		{
			if (supplierDTO == null) return [];
			else
			{
				List<CompanySupplierModel> supplierCompanies = [];

				if (supplierDTO.SupplierCompanies.Count != 0)
				{
					foreach (CompanySupplierModel companySupplier in supplierDTO.SupplierCompanies)
					{
						if (DateTime.Now.Year - supplierDTO.BirthDate!.Value.Year > legalAge
								&& companySupplier.Company!.UF.ToLower() == companyUF) supplierCompanies.Add(companySupplier);
						else throw new Exception($"A supplier entry under the age of {legalAge} cannot be registered in a company entry from {companyUF}");
					}
				}

				return supplierCompanies;
			}
		}
	}
}
