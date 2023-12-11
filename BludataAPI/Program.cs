using BludataAPI.Data;
using BludataAPI.Factories;
using BludataAPI.Interfaces;
using BludataAPI.Interfaces.Company;
using BludataAPI.Interfaces.Supplier;
using BludataAPI.Mappers;
using BludataAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection"));
});
builder.Services.AddScoped<IMapperFactory, MapperFactory>();
builder.Services.AddScoped(provider =>
{
	CompanyMapper mapper = provider.GetRequiredService<CompanyMapper>();

	return (ICompanyMapper) new Lazy<ICompanyMapper>(() =>  mapper);
});
builder.Services.AddScoped(provider =>
{
	SupplierMapper mapper = provider.GetRequiredService<SupplierMapper>();

	return (ISupplierMapper) new Lazy<ISupplierMapper>(() => mapper);
});
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
