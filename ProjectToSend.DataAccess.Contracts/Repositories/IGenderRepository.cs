using ProjectToSend.DataAccess.Contracts.Repositories;
using TheProjectToSend.Models;

namespace TheProjectToSend.Repositories
{
    public interface IGenderRepository:IGenericRepository<Gender>
	{
		public Task<Gender> GetGenderById(int id);	
	}
}

