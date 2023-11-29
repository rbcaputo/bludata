namespace BludataAPI.Models
{
	public class CompanySupplierModel
	{
		public int ID { get; set; }
		public int SupplierID { get; set; }
		public int CompanyID { get; set; }

		public CompanyModel? Company { get; set; }
		public SupplierModel? Supplier { get; set; }
	}
}
