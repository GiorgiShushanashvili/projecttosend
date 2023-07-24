using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheProjectToSend.DTOs;
using TheProjectToSend.Models;

namespace ProjectToSend.Contracts.Services
{
    public interface IPersonService
    {
        //Task<Person> LoginUser(string email, string password);
        Task<Person> AddPerson(PersonCreateDTO person);
        Task<Person> FindPerson(string text);
        Task Update(PersonUpdateDTO person, int id);
    }
}
