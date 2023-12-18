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

		[HttpGet("name/{supplierName}")]
		public async Task<ActionResult<List<SupplierDTO>?>?> GetAllByNameAsync(string supplierName)
		{
			List<SupplierDTO?>? suppliers = await service.GetAllByNameAsync(supplierName);

			if (suppliers == null) return NotFound($"Supplier entry with name {supplierName} nonexistent or not found.");
			else return Ok(suppliers);
		}

		[HttpGet("{supplierID}")]
		public async Task<ActionResult<SupplierDTO?>> GetByIDAsync(int supplierID)
		{
			SupplierDTO? supplier = await service.GetByIDAsync(supplierID);

			if (supplier == null) return NotFound($"Supplier entry with ID {supplierID} nonexistent or not found.");
			else return supplier;
		}

		[HttpGet("docnumber/{docNumber}")]
		public async Task<ActionResult<SupplierDTO?>> GetByDocNumberAsync(string docType, string docNumber)
		{
			SupplierDTO? supplier = await service.GetByDocNumberAsync(docType, docNumber);

			if (docType.ToLower() == "cnpj" && supplier == null) return NotFound($"Supplier entry with CNPJ {docNumber} nonexistent or not found.");
			else if (docType.ToLower() == "cpf" && supplier == null) return NotFound($"Supplier entry with CPF {docNumber} nonexistent or not found.");
			else return Ok(supplier);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(SupplierPostDTO supplierPostDTO)
		{
			await service.AddAsync(supplierPostDTO);

			if (supplierPostDTO.DocType.ToLower() == "cnpj") return Ok($"Supplier entry with CNPJ {supplierPostDTO.CNPJ} registered successfully.");
			else return Ok($"Supplier entry with CPF {supplierPostDTO.CPF} registered successfully.");
		}

		[HttpPut("{supplierID}")]
		public async Task<IActionResult> UpdateByIDAsync(int supplierID, SupplierDTO supplierDTO)
		{
			try
			{
				SupplierModel? supplier = await service.UpdateByIDAsync(supplierID, supplierDTO);

				if (supplier == null) return NotFound($"Supplier entry with ID {supplierID} nonexistent or not found.");
				else return Ok($"Supplier entry with ID {supplierID} updated successfully.");
			}
			catch (Exception exc) { return BadRequest(exc.Message); }
		}

		[HttpDelete("{supplierID}")]
		public async Task<IActionResult> RemoveByIDAsync(int supplierID)
		{
			bool? supplier = await service.RemoveByIDAsync(supplierID);

			if (supplier == null) return NotFound($"Supplier entry with ID {supplierID} nonexistent or not found.");
			else return Ok($"Supplier entry with ID {supplierID} removed successfully.");
		}
	}
}
