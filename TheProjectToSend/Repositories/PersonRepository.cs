using System;
using Microsoft.EntityFrameworkCore;
using TheProjectToSend.Context;
using TheProjectToSend.Models;

namespace TheProjectToSend.Repositories
{
    public class PersonRepository : IPersonRepository<Person>
    {
        private readonly PersonContext _context;
        public PersonRepository(PersonContext context)
        {
            _context = context;
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _context.Person.FirstOrDefaultAsync(x => x.PersonId == id);
        }



        public async Task<Person> AddUser(Person person)
        {
           await _context.Person.AddAsync(person);

            return person;
        }



        public async Task<Person> FindPerson(string input)
        {
            var person = await _context.Person.FirstOrDefaultAsync(x => x.Firstname.Contains(input) ||
            x.Lastname.Contains(input) || x.PersonalNumber.Contains(input));
            return person;
        }

        public void Update(Person person)
        {
          _context.Person.Update(person); 
        }

        public async Task<Person> GetPersonToLogin(string email, string password)
        {
            return await _context.Person.FirstOrDefaultAsync(x => x.Usermail == email && x.Password == password);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

