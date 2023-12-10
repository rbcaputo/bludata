using BludataAPI.DTOs.Supplier;
using BludataAPI.Interfaces;
using BludataAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BludataAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class SupplierController(ISupplierService service) : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<List<SupplierModel>?>> GetAllAsync()
		{
			List<SupplierModel>? suppliers = await service.GetAllAsync();

			if (suppliers == null) return BadRequest("Suppliers database doesn't have any entries registered.");
			else return Ok(suppliers);
		}
		[HttpGet("{supplierID}")]
		public async Task<ActionResult<SupplierModel?>> GetByIDAsync(int supplierID)
		{
			SupplierModel? supplier = await service.GetByIDAsync(supplierID);

			if (supplier == null) return NotFound($"Supplier entry with ID {supplierID} inexistent or not found.");
			else return supplier;
		}
		[HttpGet("name/{supplierName}")]
		public async Task<ActionResult<List<SupplierDTO>?>> GetByNameAsync(string supplierName)
		{
			List<SupplierDTO>? suppliers = await service.GetByNameAsync(supplierName);

			if (suppliers == null) return NotFound($"Supplier entry with name {supplierName} inexistent or not found.");
			else return Ok(suppliers);
		}
		[HttpGet("company/name/{companyName}")]
		public async Task<ActionResult<List<SupplierDTO>?>> GetByCompanyNameAsync(string companyName)
		{
			List<SupplierDTO>? suppliers = await service.GetByCompanyNameAsync(companyName);

			if (suppliers == null) return NotFound($"No suppliers entries linked to company entry with name {companyName} were found.");
			else return Ok(suppliers);
		}
		[HttpGet("company/uf/{companyUF}")]
		public async Task<ActionResult<List<SupplierDTO>?>> GetByCompanyUFAsync(string companyUF)
		{
			List<SupplierDTO>? suppliers = await service.GetByCompanyUFAsync(companyUF);

			if (suppliers == null) return NotFound($"No suppliers entries linked to company entry with UF {companyUF} were found.");
			else return Ok(suppliers);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(SupplierDTO supplierDTO)
		{
			try
			{
				await service.AddAsync(supplierDTO);

				return Ok($"Supplier entry with name {supplierDTO.Name} registered successfully.");
			}
			catch (Exception exc)
			{
				return BadRequest(exc);
			}
		}
		[HttpPut("{supplierID}")]
		public async Task<IActionResult> EditByIDAsync(int supplierID, SupplierDTO supplierDTO)
		{
			try
			{
				bool? supplier = await service.EditByIDAsync(supplierID, supplierDTO);

				if (supplier == null) return NotFound($"Supplier entry with ID {supplierID} inexistent or not found.");
				else return Ok($"Supplier entry with ID {supplierID} updated successfully.");
			}
			catch (Exception exc)
			{
				return BadRequest(exc);
			}
		}
		[HttpDelete("{supplierID}")]
		public async Task<IActionResult> RemoveByIDAsync(int supplierID)
		{
			bool? supplier = await service.RemoveByIDAsync(supplierID);

			if (supplier == null) return NotFound($"Supplier entry with ID {supplierID} inexistent or not found.");
			else return Ok($"Supplier entry with ID {supplierID} removed successfully.");
		}
	}
}
