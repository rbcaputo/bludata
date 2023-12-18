using BludataAPI.Models;

namespace BludataAPI.DTOs.Company
{
	public class CompanyDTO
	{
		public string Name { get; set; } = string.Empty;
		public string UF { get; set; } = string.Empty;
		public string CNPJ { get; set; } = string.Empty;

		public virtual List<CompanySupplierModel> CompanySuppliers { get; set; } = [];
	}
}
