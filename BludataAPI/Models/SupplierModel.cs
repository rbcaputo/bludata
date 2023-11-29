namespace BludataAPI.Models
{
	public class SupplierModel(string name, string docType, List<CompanyModel> companies, DateTime subDate, string? cpf = null, string? cnpj = null, string? rg = null, DateTime? birthDate = null)
	{
		public int ID { get; set; }
		public string Name { get; set; } = name;
		public string DocType { get; set; } = docType;
		public DateTime SubDate { get; set; } = subDate;
		public List<CompanyModel> Companies { get; set; } = companies;

		public string? CPF { get; set; }
		public string? CNPJ { get; set; }
		public string? RG { get; set; }
		public DateTime? BirthDate { get; set; }

		public void CheckDocType()
		{
			if (DocType == "cpf")
			{
				CPF = cpf;
				RG = rg;
				BirthDate = birthDate;
			}
			else CNPJ = cnpj;
		}
	}
}
