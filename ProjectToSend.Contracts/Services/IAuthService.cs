using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheProjectToSend.Models;

namespace ProjectToSend.Contracts.Services
{
    public interface IAuthService
    {
        Task<Person> LoginUser(string email, string password);
    }
}
