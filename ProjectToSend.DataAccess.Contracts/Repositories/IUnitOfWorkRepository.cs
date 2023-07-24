using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
