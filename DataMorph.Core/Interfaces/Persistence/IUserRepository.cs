using UserMorph.Core.DTOs.PersistenceModels;
using UserMorph.Core.Interfaces.Persistence;

namespace UserMorph.Core.Interfaces.Persistence
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(); 
        User GetUserDetailsByID(int id);
    }
}
