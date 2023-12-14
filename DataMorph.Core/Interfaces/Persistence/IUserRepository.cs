using UserMorph.Core.DTOs.PersistenceModels;
using UserMorph.Core.Interfaces.Persistence;

namespace UserMorph.DataManagement.Repositories
{
    public interface IUserRepository : IRepository<User, int>
    {
        IEnumerable<User> GetUsers();
    }
}
