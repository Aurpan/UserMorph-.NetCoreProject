using UserMorph.Core.DTOs.PersistenceModels;

namespace UserMorph.Core.Interfaces.Persistence
{
    public interface IRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserDetailsByID(int id);
    }
}
