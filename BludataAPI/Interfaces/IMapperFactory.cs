using BludataAPI.Data;
using BludataAPI.Interfaces.Company;
using BludataAPI.Interfaces.Supplier;

namespace BludataAPI.Interfaces
{
	public interface IMapperFactory
	{
		Lazy<ICompanyMapper> CreateCompanyMapper(DataContext context);
		Lazy<ISupplierMapper> CreateSupplierMapper(DataContext context);
	}
}
