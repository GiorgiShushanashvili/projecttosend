using System;
using TheProjectToSend.Models;

namespace TheProjectToSend.Service
{
	public interface IAuthService
	{
        Task<Person> LoginUser(string email, string password);
    }
}

