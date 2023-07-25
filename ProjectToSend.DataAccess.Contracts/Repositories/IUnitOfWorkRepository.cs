using TheProjectToSend.Models;

namespace ProjectToSend.DataAccess.Contracts.Repositories
{
    public interface IUnitOfWorkRepository
    {
        IGenericRepository<Gender> GenderRepository { get; }
        IGenericRepository<Person> PersonRepository { get; }
        Task<int> SaveAsync();
    }
}
