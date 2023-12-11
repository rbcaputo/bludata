namespace BludataAPI.Models
{
	public class CompanyModel
	{
		public int ID { get; set; }
		public string Name { get; set; } = string.Empty;
		public string UF { get; set; } = string.Empty;
		public string CNPJ { get; set; } = string.Empty;
		public virtual List<SupplierModel> Suppliers { get; set; } = [];
	}
}
