using System;
using Microsoft.EntityFrameworkCore;
using TheProjectToSend.DTOs;
using TheProjectToSend.Models;
using TheProjectToSend.Repositories;

namespace TheProjectToSend.Service
{
	public class PersonService:IPersonService
	{
		private readonly IPersonRepository<Person> _repository;
        private readonly IGenderRepository<Gender> _genderrepository;
		public PersonService(IPersonRepository<Person> repository, IGenderRepository<Gender> genderrepository)
		{
			_repository = repository;
            _genderrepository = genderrepository;
		}

        public async Task<Person> AddPerson(PersonCreateDTO person)
        {
            var gender = await _genderrepository.GetGenderById(person.GenderId);
            if (gender == null)
                return null;

            var mappedPerson = new Person
            {
                CreateDate = DateTime.UtcNow,
                DateofBirth = person.DateofBirth,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                GenderId = person.GenderId,
                PersonalNumber = person.PersonalNumber,
                Password = PasswordHasher.hashPass(person.Password),
                Status = person.Status,
                Usermail = person.UserEmail
            };

            var user = await _repository.AddUser(mappedPerson);
            if (user == null)
                return null;

            await _repository.SaveChangesAsync();

            return user;
        }


        public async Task<Person> FindPerson(string text)
        {
            return await _repository.FindPerson(text);
        }


        public async Task Update(PersonUpdateDTO person, int id)
        {
            var existingPerson = await _repository.GetPersonById(id);
            if (existingPerson == null)
                return;
            existingPerson.Firstname = person.Firstname;
            existingPerson.Lastname = person.Lastname;
            existingPerson.DateofBirth = person.DateofBirth;
            existingPerson.GenderId = person.GenderId;
            existingPerson.Password = person.Password;
            existingPerson.Usermail = person.UserEmail;
            existingPerson.Status = person.Status;
            existingPerson.PersonalNumber = person.PersonalNumber;
           
           _repository.Update(existingPerson);
           await _repository.SaveChangesAsync();
        }
    }
}

