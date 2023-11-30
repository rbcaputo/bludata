using BludataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BludataAPI.Data
{
	public class DataContext(DbContextOptions<DbContext> options) : DbContext(options)
	{
		public DbSet<CompanyModel> Companies { get; set; }
		public DbSet<SupplierModel> Suppliers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CompanyModel>().HasMany(com => com.Suppliers)
				.WithMany(sup => sup.Companies)
				.UsingEntity<Dictionary<string, object>>("CompanySupplier",
					jnt => jnt.HasOne<SupplierModel>()
						.WithMany()
						.HasForeignKey("SupplierID")
						.OnDelete(DeleteBehavior.Restrict),
					jnt => jnt.HasOne<CompanyModel>()
						.WithMany()
						.HasForeignKey("CompanyID")
						.OnDelete(DeleteBehavior.Restrict)
				);
		}
	}
}
