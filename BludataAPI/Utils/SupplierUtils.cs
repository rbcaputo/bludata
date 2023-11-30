using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Utils
{
	public class SupplierUtils
	{
		public static int CheckDocType(SupplierModel supplierModel)
		{
			if (supplierModel.DocType.Equals("CNPJ", StringComparison.CurrentCultureIgnoreCase)) return 1;
			else return 2;
		}

		private static bool CheckLegalAge(SupplierModel supplierModel)
		{
			if (CheckDocType(supplierModel) == 2)
			{
				if (supplierModel.Companies.Any(com => com.UF.Equals("PR", StringComparison.CurrentCultureIgnoreCase)))
				{
					if (supplierModel.BirthDate!.Value.Year - DateTime.Now.Year < 18) return false;
					else return true;
				}
				else return true;
			}

			return true;
		}

		public static SupplierDTO FillForm(SupplierModel supplierModel, SupplierDTO supplierDTO)
		{
			if (CheckDocType(supplierModel) == 1) supplierModel.CNPJ = supplierDTO.CNPJ;
			else
			{
				if (CheckLegalAge(supplierModel))
				{
					supplierModel.CPF = supplierDTO.CPF;
					supplierModel.RG = supplierDTO.RG;
					supplierModel.BirthDate = supplierDTO.BirthDate;
				}
				else throw new InvalidOperationException(/* TODO: exception message */);
			}

			return supplierDTO;
		}
	}
}

