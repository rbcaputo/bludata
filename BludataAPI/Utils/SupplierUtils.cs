using BludataAPI.DTOs.Supplier;
using BludataAPI.Models;

namespace BludataAPI.Utils
{
	public class SupplierUtils
	{
		private static readonly int _legalAge = 18;

		public static int CheckDocType(SupplierModel supplierModel)
		{
			if (supplierModel.DocType.ToLower() == "cnpj") return 1;
			else return 2;
		}

		private static bool CheckLegalAge(SupplierModel supplierModel)
		{
			if (CheckDocType(supplierModel) == 2)
			{
				if (supplierModel.Companies.Any(com => com.UF.ToLower() == "pr"))
				{
					if (DateTime.Now.Year - supplierModel.BirthDate!.Value.Year < _legalAge) return false;
					else return true;
				}
				else return true;
			}
			else return true;
		}

		public static SupplierModel HandleForm(SupplierModel supplierModel, SupplierDTO supplierDTO)
		{
			if (CheckDocType(supplierModel) == 1)
			{
				supplierModel.CNPJ = supplierDTO.CNPJ;
				supplierModel.CPF = null;
				supplierModel.RG = null;
				supplierModel.BirthDate = null;
			}
			else
			{
				if (CheckLegalAge(supplierModel))
				{
					supplierModel.CNPJ = null;
					supplierModel.CPF = supplierDTO.CPF;
					supplierModel.RG = supplierDTO.RG;
					supplierModel.BirthDate = supplierDTO.BirthDate;
				}
				else throw new InvalidOperationException("An under legal age supplier can't be assigned to a company registered in PR.");
			}

			return supplierModel;
		}
	}
}
