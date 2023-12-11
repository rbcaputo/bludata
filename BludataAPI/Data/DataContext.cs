using BludataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BludataAPI.Data
{
	public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
	{
		public DbSet<CompanyModel> Companies { get; set; }
		public DbSet<SupplierModel> Suppliers { get; set; }
		public DbSet<CompanySupplierModel> CompaniesSuppliers { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<CompanyModel>(com => com.HasIndex(doc => doc.CNPJ).IsUnique(true));
			builder.Entity<SupplierModel>(sup => sup.HasIndex(doc => doc.CNPJ).IsUnique(true));
			builder.Entity<SupplierModel>(sup => sup.HasIndex(doc => doc.CPF).IsUnique(true));

			builder.Entity<CompanyModel>(com => com.HasMany(com => com.Suppliers)
				.WithMany(sup => sup.Companies)
				.UsingEntity<CompanySupplierModel>());
		}
	}
}
