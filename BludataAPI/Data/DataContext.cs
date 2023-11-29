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
			// Demais configurações das relações necessárias entre as entidades
		}
	}
}
