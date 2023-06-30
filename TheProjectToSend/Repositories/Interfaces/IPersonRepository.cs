using System;
using TheProjectToSend.Models;

namespace TheProjectToSend.Repositories
{
	public interface IPersonRepository<T1>where T1:class
	{
		Task<T1> GetPersonToLogin(string email, string password);
		Task<T1> GetPersonById(int id);
		Task<T1> AddUser(T1 person);
		void Update(T1 person);
		Task<T1> FindPerson(string text);
		Task SaveChangesAsync();
	}
}

