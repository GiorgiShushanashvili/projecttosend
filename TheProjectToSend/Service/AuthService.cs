using System;
using Microsoft.EntityFrameworkCore;
using TheProjectToSend.Models;
using TheProjectToSend.Repositories;

namespace TheProjectToSend.Service
{
    
    public class AuthService : IAuthService
    {
        private readonly IPersonRepository<Person> _repository;
        public AuthService(IPersonRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<Person> LoginUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            password = PasswordHasher.hashPass(password);
            var activeuser = await _repository.GetPersonToLogin(email,password);
            return activeuser;
        }
    }
}

