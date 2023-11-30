using BludataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BludataAPI.Data
{
	public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
	{
		public DbSet<CompanyModel> Companies { get; set; }
		public DbSet<SupplierModel> Suppliers { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<CompanyModel>()
				.HasMany(com => com.Suppliers)
				.WithMany(sup => sup.Companies)
				.UsingEntity(jnt => jnt.ToTable("CompanySupplier"));
		}
	}
}
