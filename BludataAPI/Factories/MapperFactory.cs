using BludataAPI.Data;
using BludataAPI.Interfaces;
using BludataAPI.Interfaces.Company;
using BludataAPI.Interfaces.Supplier;
using BludataAPI.Mappers;

namespace BludataAPI.Factories
{
	public class MapperFactory(IServiceProvider provider) : IMapperFactory
	{
		public Lazy<ICompanyMapper> CreateCompanyMapper(DataContext context)
		{
			ISupplierMapper mapper = provider.GetRequiredService<ISupplierMapper>();
			Lazy<ISupplierMapper> lazyMapper = new(() => mapper);

			return new Lazy<ICompanyMapper>(() => new CompanyMapper(context, lazyMapper));
		}
		public Lazy<ISupplierMapper> CreateSupplierMapper(DataContext context)
		{
			ICompanyMapper mapper = provider.GetRequiredService<ICompanyMapper>();
			Lazy<ICompanyMapper> lazyMapper = new(() => mapper);

			return new Lazy<ISupplierMapper>(() => new SupplierMapper(context, lazyMapper));
		}
	}
}
