using UserMorph.Core.DTOs.PersistenceModels;
namespace UserMorph.Core.Interfaces.Persistence
{
    public interface IUserJsonRepository
    {
        void UpdateJsonDb(List<User> users);
    }
}
