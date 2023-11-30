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
		private readonly CompanyService _service = service;

		[HttpGet]
		public async Task<ActionResult<List<CompanyModel>?>> GetAllAsync()
		{
			List<CompanyModel>? companies = await _service.GetAllAsync();

			if (companies == null) return BadRequest("This database doesn't have any entries registered.");
			else return Ok(companies);
		}
		[HttpGet("{companyID}")]
		public async Task<ActionResult<CompanyModel?>> GetByIDAsync(int companyID)
		{
			CompanyModel? company = await _service.GetByIDAsync(companyID);

			if (company == null) return NotFound($"Entry with ID {companyID} inexistent or not found.");
			else return Ok(company);
		}
		[HttpGet("name/{companyName}")]
		public async Task<ActionResult<List<CompanyDTO>?>> GetByNameAsync(string companyName)
		{
			List<CompanyDTO>? companies = await _service.GetByNameAsync(companyName);

			if (companies == null) return NotFound($"Entry with name {companyName} inexistent or not found.");
			else return Ok(companies);
		}

		[HttpPost]
		public async Task<ActionResult<CompanyDTO>> AddAsync(CompanyDTO companyDTO)
		{
			CompanyDTO company = await _service.AddAsync(companyDTO);
			
			return Ok(company);
		}
		[HttpPut("{companyID}")]
		public async Task<ActionResult<CompanyDTO>> EditByIDAsync(int companyID, CompanyDTO companyDTO)
		{
			CompanyDTO? company = await _service.EditByIDAsync(companyID, companyDTO);

			if (company == null) return NotFound($"Entry with ID {companyID} inexistent or not found.");
			else return Ok(company);
		}
		[HttpDelete("{companyID}")]
		public async Task<IActionResult> RemoveByIDAsync(int companyID)
		{
			bool? company = await _service.RemoveByIDAsync(companyID);

			if (company == null) return NotFound($"Entry with ID {companyID} inexistent or not found.");
			else return Ok($"Company with ID {companyID} successfuly removed.");
		}
	}
}
