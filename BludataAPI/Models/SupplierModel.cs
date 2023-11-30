namespace BludataAPI.Models
{
	public class SupplierModel
	{
		public int ID { get; set; }
		public string Name { get; set; } = string.Empty;
		public string DocType { get; set; } = string.Empty;
		public DateTime SubDate { get; set; } = DateTime.Now;
		public List<CompanyModel> Companies { get; set; } = [];

		public string? CPF { get; set; }
		public string? CNPJ { get; set; }
		public string? RG { get; set; }
		public DateTime? BirthDate { get; set; }
	}
}
