using System;
using TheProjectToSend.DTOs;
using TheProjectToSend.Models;

namespace TheProjectToSend.Service
{
	public interface IPersonService
	{
		//Task<Person> LoginUser(string email, string password);
		Task<Person> AddPerson(PersonCreateDTO person);
		Task<Person> FindPerson(string text);
		Task Update(PersonUpdateDTO person,int id);
	}
}

