using TheProjectToSend.Models;
using ProjectToSend.DataAccess.Contracts.Repositories;
using TheProjectToSend.Repositories;
using ProjectToSend.Contracts.Services;

namespace TheProjectToSend.Service
{

    public class AuthService : IAuthService
    {
        private readonly IPersonRepository _repository;
        public AuthService(IPersonRepository repository)
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

