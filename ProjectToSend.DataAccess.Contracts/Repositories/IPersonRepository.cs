using ProjectToSend.DataAccess.Contracts.Repositories;
using System;
using TheProjectToSend.Models;

namespace TheProjectToSend.Repositories
{
	public interface IPersonRepository:IGenericRepository<Person>
	{
		Task<Person> GetPersonToLogin(string email, string password);
		Task<Person> GetPersonById(int id);
		Task<Person> AddUser(Person person);
		void Update (Person person);
		Task<Person> FindPerson(string text);
		Task SaveChangesAsync();
	}
}

