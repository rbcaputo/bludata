using BludataAPI.DTOs;

namespace BludataAPI.Models
{
	public class CompanyModel(string name, string uf, string cnpj, List<SupplierModel> suppliers)
	{
		public int ID { get; set; }
		public string Name { get; set; } = name;
		public string UF { get; set; } = uf;
		public string CNPJ { get; set; } = cnpj;
		public List<SupplierModel> Suppliers { get; set; } = suppliers;
	}
}
