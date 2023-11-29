﻿using BludataAPI.DTOs;
using BludataAPI.Models;

namespace BludataAPI.Interfaces
{
	public interface ICompanyService
	{
		public Task<List<CompanyModel>?> GetAllAsync();
		public Task<CompanyModel?> GetByIDAsync(int companyID);

		public Task<CompanyDTO> AddAsync(CompanyDTO companyDTO);
		public Task<CompanyDTO?> EditByIDAsync(int companyID, CompanyDTO companyDTO);
		public Task<bool?> RemoveByIDAsync(int companyID);
	}
}
