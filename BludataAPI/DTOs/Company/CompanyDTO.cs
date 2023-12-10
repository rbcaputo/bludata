using BludataAPI.DTOs.Supplier;

namespace BludataAPI.DTOs.Company
{
	public class CompanyDTO
	{
		public int ID { get; set; }
		public string Name { get; set; } = string.Empty;
		public string UF { get; set; } = string.Empty;
		public string CNPJ { get; set; } = string.Empty;
		public List<SupplierDTOGet> Suppliers { get; set; } = [];
	}
}
