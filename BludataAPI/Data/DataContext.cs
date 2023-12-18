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

			builder.Entity<CompanyModel>(com => com
				.HasIndex(doc => doc.CNPJ)
				.IsUnique(true));
			builder.Entity<SupplierModel>(sup => sup
				.HasIndex(doc => doc.CNPJ)
				.IsUnique(true));
			builder.Entity<SupplierModel>(sup => sup
				.HasIndex(doc => doc.CPF)
				.IsUnique(true));

			builder.Entity<CompanySupplierModel>()
				.HasKey(csm => new { csm.CompanyID, csm.SupplierID });

			builder.Entity<CompanyModel>()
				.HasMany(com => com.CompanySuppliers)
				.WithOne(csm => csm.Company)
				.HasForeignKey(csm => csm.CompanyID);

			builder.Entity<SupplierModel>()
				.HasMany(sup => sup.SupplierCompanies)
				.WithOne(csm => csm.Supplier)
				.HasForeignKey(csm => csm.SupplierID);
		}
	}
}
