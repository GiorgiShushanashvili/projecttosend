using ProjectToSend.Contracts.Services;
using ProjectToSend.DataAccess.Contracts.Repositories;
using TheProjectToSend.DTOs;
using TheProjectToSend.Models;
using TheProjectToSend.Repositories;

namespace TheProjectToSend.Service
{
    public class PersonService:IPersonService
	{
        private readonly IUnitOfWorkRepository _unitofworkrepository;
		private readonly IPersonRepository _personRepository;
		public PersonService(IPersonRepository personRepository,IUnitOfWorkRepository unitOfWorkRepository)
		{
			_personRepository = personRepository;
            _unitofworkrepository = unitOfWorkRepository;
		}

        public async Task<Person> AddPerson(PersonCreateDTO person)
        {
            var gender = await _unitofworkrepository.PersonRepository.GetByIdAsync(person.GenderId);
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

            var user = await _personRepository.AddUser(mappedPerson);
            if (user == null)
                return null;

            await _personRepository.SaveChangesAsync();

            return user;
        }


        public async Task<Person> FindPerson(string text)
        {
            return await _personRepository.FindPerson(text);
        }


        public async Task Update(PersonUpdateDTO person, int id)
        {
            var existingPerson = await _personRepository.GetPersonById(id);
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
           
           _personRepository.Update(existingPerson);
           await _personRepository.SaveChangesAsync();
        }
    }
}

