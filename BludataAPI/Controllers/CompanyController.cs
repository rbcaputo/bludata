using BludataAPI.DTOs;
using BludataAPI.Models;
using BludataAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BludataAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CompanyController(CompanyService service) : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<List<CompanyModel>?>> GetAllAsync()
		{
			List<CompanyModel>? companies = await service.GetAllAsync();

			if (companies == null) return BadRequest("Companies database doesn't have any entries registered.");
			else return Ok(companies);
		}
		[HttpGet("{companyID}")]
		public async Task<ActionResult<CompanyModel?>> GetByIDAsync(int companyID)
		{
			CompanyModel? company = await service.GetByIDAsync(companyID);

			if (company == null) return NotFound($"Company entry with ID {companyID} inexistent or not found.");
			else return Ok(company);
		}
		[HttpGet("name/{companyName}")]
		public async Task<ActionResult<List<CompanyDTO>?>> GetByNameAsync(string companyName)
		{
			List<CompanyDTO>? companies = await service.GetByNameAsync(companyName);

			if (companies == null) return NotFound($"Company entry with name {companyName} inexistent or not found.");
			else return Ok(companies);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CompanyDTO companyDTO)
		{
			await service.AddAsync(companyDTO);

			return Ok($"Company entry with name {companyDTO.Name} registered successfully.");
		}
		[HttpPut("{companyID}")]
		public async Task<ActionResult<CompanyDTO>> EditByIDAsync(int companyID, CompanyDTO companyDTO)
		{
			CompanyModel? company = await service.EditByIDAsync(companyID, companyDTO);

			if (company == null) return NotFound($"Company entry with ID {companyID} inexistent or not found.");
			else return Ok(company);
		}
		[HttpDelete("{companyID}")]
		public async Task<IActionResult> RemoveByIDAsync(int companyID)
		{
			bool? company = await service.RemoveByIDAsync(companyID);

			if (company == null) return NotFound($"Company entry with ID {companyID} inexistent or not found.");
			else return Ok($"Company entry with ID {companyID} removed successfully.");
		}
	}
}
