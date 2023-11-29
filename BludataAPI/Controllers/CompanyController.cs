using BludataAPI.DTOs;
using BludataAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BludataAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CompanyController(CompanyService service) : ControllerBase
	{
		private readonly CompanyService _service = service;

		public async Task<ActionResult<CompanyDTO>> AddAsync(CompanyDTO companyDTO)
		{
			CompanyDTO company = await _service.AddAsync(companyDTO);
			
			return Ok(company);
		}

		public async Task<ActionResult<CompanyDTO>> EditByIDAsync(int companyID, CompanyDTO companyDTO)
		{
			CompanyDTO? company = await _service.EditByIDAsync(companyID, companyDTO);

			if (company == null) return NotFound($"Entry with ID {companyID} inexistent or not found.");
			else return Ok(company);
		}

		public async Task<IActionResult> RemoveByIDAsync(int companyID)
		{
			bool? company = await _service.RemoveByIDAsync(companyID);

			if (company == null) return NotFound($"Entry with ID {companyID} inexistent or not found.");
			else return Ok($"Company with ID {companyID} successfuly removed.");
		}
	}
}
