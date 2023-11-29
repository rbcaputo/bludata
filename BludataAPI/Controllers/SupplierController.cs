using BludataAPI.DTOs;
using BludataAPI.Models;
using BludataAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BludataAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class SupplierController(SupplierService service) : ControllerBase
	{
		private readonly SupplierService _service = service;

		[HttpGet]
		public async Task<ActionResult<List<SupplierModel>?>> GetAllAsync()
		{
			List<SupplierModel>? suppliers = await _service.GetAllAsync();

			if (suppliers == null) return BadRequest("This database doesn't have any entries registered.");
			else return Ok(suppliers);
		}
		[HttpGet("{supplierID}")]
		public async Task<ActionResult<SupplierModel?>> GetByIDAsync(int supplierID)
		{
			SupplierModel? supplier = await _service.GetByIDAsync(supplierID);

			if (supplier == null) return NotFound($"Entry with ID {supplierID} inexistent or not found.");
			else return supplier;
		}
		[HttpGet("/name/{supplierName}")]
		public async Task<ActionResult<List<SupplierDTO>?>> GetByNameAsync(string supplierName)
		{
			List<SupplierDTO>? suppliers = await _service.GetByNameAsync(supplierName);

			if (suppliers == null) return NotFound($"Entry with name {supplierName} inexistent or not found.");
			else return Ok(suppliers);
		}
		[HttpGet("/company/name/{companyName}")]
		public async Task<ActionResult<List<SupplierDTO>?>> GetByCompanyNameAsync(string companyName)
		{
			List<SupplierDTO>? suppliers = await _service.GetByCompanyNameAsync(companyName);

			if (suppliers == null) return NotFound($"Entry with name {companyName} inexistent or not found.");
			else return Ok(suppliers);
		}
		[HttpGet("/company/uf/{companyUF}")]
		public async Task<ActionResult<List<SupplierDTO>?>> GetByCompanyUFAsync(string companyUF)
		{
			List<SupplierDTO>? suppliers = await _service.GetByCompanyUFAsync(companyUF);

			if (suppliers == null) return NotFound($"Entry with UF {companyUF} inexistent or not found.");
			else return suppliers;
		}

		
	}
}
