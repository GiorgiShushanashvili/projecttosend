using ProjectToSend.DataAccess.Contracts.Repositories;
using TheProjectToSend.Context;
using TheProjectToSend.Models;
using TheProjectToSend.Repositories;

namespace ProjectToSend.DataAccess.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly PersonContext _personContext;
        private IGenericRepository<Person> _personRespoitory;
        private IGenericRepository<Gender> _genderRespoitory;
        public UnitOfWorkRepository(PersonContext personcontext)
        {
            _personContext = personcontext;
        }
        public IGenericRepository<Gender> GenderRepository => _genderRespoitory ??= new GenderRepository(_personContext);
        public IGenericRepository<Person> PersonRepository => _personRespoitory ??= new PersonRepository(_personContext);

        public async Task<int> SaveAsync()
        {
            return await _personContext.SaveChangesAsync();
        }
        public void DisposeAsync()
        {
            _personContext.DisposeAsync();
        }
    }
}
