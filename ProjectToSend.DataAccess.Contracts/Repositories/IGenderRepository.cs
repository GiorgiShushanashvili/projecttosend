using ProjectToSend.DataAccess.Contracts.Repositories;
using System;
using TheProjectToSend.DTOs;
using TheProjectToSend.Models;

namespace TheProjectToSend.Repositories
{
	public interface IGenderRepository:IGenericRepository<Gender>
	{
		public Task<Gender> GetGenderById(int id);	
	}
}

