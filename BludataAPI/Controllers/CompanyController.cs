using BludataAPI.DTOs.Company;
using BludataAPI.Interfaces;
using BludataAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BludataAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CompanyController(ICompanyService service) : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<List<CompanyModel>?>> GetAllAsync()
		{
			List<CompanyModel>? companies = await service.GetAllAsync();

			if (companies == null) return BadRequest("Companies database doesn't have any entries registered.");
			else return Ok(companies);
		}

		[HttpGet("uf/{companiesUF}")]
		public async Task<ActionResult<List<CompanyDTO?>?>> GetAllByUFAsync(string companiesUF)
		{
			List<CompanyDTO?>? companies = await service.GetAllByUFAsync(companiesUF);

			if (companies == null) return NotFound($"Company entries with UF {companiesUF.ToUpper()} nonexistent or not found.");
			else return Ok(companies);
		}

		[HttpGet("{companyID}")]
		public async Task<ActionResult<CompanyDTO?>> GetByIDAsync(int companyID)
		{
			CompanyDTO? company = await service.GetByIDAsync(companyID);

			if (company == null) return NotFound($"Company entry with ID {companyID} nonexistent or not found.");
			else return Ok(company);
		}

		[HttpGet("cnpj/{companyCNPJ}")]
		public async Task<ActionResult<CompanyDTO?>> GetByCNPJAsync(string companyCNPJ)
		{
			CompanyDTO? company = await service.GetByCNPJAsync(companyCNPJ);

			if (company == null) return NotFound($"Company entry with CNPJ {companyCNPJ} nonexistent or not found.");
			else return Ok(company);
		}

		[HttpGet("name/{companyName}")]
		public async Task<ActionResult<List<CompanyDTO>?>> GetByNameAsync(string companyName)
		{
			CompanyDTO? company = await service.GetByNameAsync(companyName);

			if (company == null) return NotFound($"Company entry with name {companyName} nonexistent or not found.");
			else return Ok(company);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CompanyPostDTO companyPostDTO)
		{
			await service.AddAsync(companyPostDTO);

			return Ok($"Company entry with CNPJ {companyPostDTO.CNPJ} registered successfully.");
		}

		[HttpPut("{companyID}")]
		public async Task<IActionResult> EditByIDAsync(int companyID, CompanyDTO companyDTO)
		{
			try
			{
				CompanyModel? company = await service.UpdateByIDAsync(companyID, companyDTO);

				if (company == null) return NotFound($"Company entry with ID {companyID} nonexistent or not found.");
				else return Ok($"Company entry with ID {companyID} updated successfully.");
			}
			catch (Exception exc) { return BadRequest(exc.Message); }
		}

		[HttpDelete("{companyID}")]
		public async Task<IActionResult> RemoveByIDAsync(int companyID)
		{
			bool? company = await service.RemoveByIDAsync(companyID);

			if (company == null) return NotFound($"Company entry with ID {companyID} nonexistent or not found.");
			else return Ok($"Company entry with ID {companyID} removed successfully.");
		}
	}
}
