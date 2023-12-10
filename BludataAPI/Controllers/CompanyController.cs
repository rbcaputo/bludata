﻿using BludataAPI.DTOs.Company;
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
			List<CompanyDTO>? companies = await service.GetAllAsync();

			if (companies == null) return BadRequest("Companies database doesn't have any entries registered.");
			else return Ok(companies);
		}
		[HttpGet("{companyID}")]
		public async Task<ActionResult<CompanyModel?>> GetByIDAsync(int companyID)
		{
			CompanyDTO? company = await service.GetByIDAsync(companyID);

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
			bool? company = await service.EditByIDAsync(companyID, companyDTO);

			if (company == null) return NotFound($"Company entry with ID {companyID} inexistent or not found.");
			else return Ok($"Company entry with ID {companyID} updated successfully.");
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
