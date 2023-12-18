using BludataAPI.DTOs.Company;
using BludataAPI.DTOs.Supplier;
using BludataAPI.Models;

namespace BludataAPI.Utils
{
	public static class Validator
	{
		public static List<CompanySupplierModel> ValidateCompanySuppliersAge(CompanyDTO? companyDTO, string companyUF = "pr", int legalAge = 18)
		{
			if (companyDTO == null) return [];
			else
			{
				if (companyDTO.UF == companyUF)
				{
					List<CompanySupplierModel> companySuppliers = [];

					foreach (CompanySupplierModel companySupplier in companyDTO.CompanySuppliers)
					{
						if (DateTime.Now.Year - companySupplier.Supplier!.BirthDate!.Value.Year < legalAge)
							throw new Exception($"A supplier entry under the age of {legalAge} cannot be registered in a company entry with UF {companyUF.ToUpper()}");
						else companySuppliers.Add(companySupplier);
					}

					return companySuppliers;
				}
			}

			return [];
		}

		public static List<CompanySupplierModel> ValidateSuppliersCompanyUF(SupplierDTO? supplierDTO, string companyUF = "pr", int legalAge = 18)
		{
			if (supplierDTO == null) return [];
			else
			{
				if (DateTime.Now.Year - supplierDTO.BirthDate!.Value.Year < legalAge)
				{
					List<CompanySupplierModel> supplierCompanies = [];

					foreach (CompanySupplierModel companySupplier in supplierDTO.SupplierCompanies)
					{
						if (companySupplier.Company!.UF.ToLower() == companyUF)
							throw new Exception($"A supplier entry under the age of {legalAge} cannot be registered in a company entry with UF {companyUF.ToUpper()}");
						else supplierCompanies.Add(companySupplier);
					}

					return supplierCompanies;
				}
			}

			return [];
		}
	}
}
