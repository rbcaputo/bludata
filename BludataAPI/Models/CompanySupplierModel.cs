namespace BludataAPI.Models
{
	public class CompanySupplierModel
	{
		public int? CompanyID { get; set; }
		public CompanyModel? Company { get; set; }
		public int? SupplierID { get; set; }
		public SupplierModel? Supplier { get; set; }
	}
}
