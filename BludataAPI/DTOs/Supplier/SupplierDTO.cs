using BludataAPI.DTOs.Company;

namespace BludataAPI.DTOs.Supplier
{
	public class SupplierDTO
	{
		public int ID { get; set; }
		public string Name { get; set; } = string.Empty;
		public string DocType { get; set; } = string.Empty;
		public DateTime SubDate { get; set; }
		public List<string> Phones { get; set; } = [];
		public List<CompanyDTOGet> Companies { get; set; } = [];

		public string? CNPJ { get; set; }
		public string? CPF { get; set; }
		public string? RG { get; set; }
		public DateTime? BirthDate { get; set; }
	}
}
