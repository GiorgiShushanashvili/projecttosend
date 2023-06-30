using System;
using TheProjectToSend.DTOs;
using TheProjectToSend.Models;

namespace TheProjectToSend.Repositories
{
	public interface IGenderRepository<T1> where T1:class
	{
		Task<T1> GetGenderById(int id);	
	}
}

