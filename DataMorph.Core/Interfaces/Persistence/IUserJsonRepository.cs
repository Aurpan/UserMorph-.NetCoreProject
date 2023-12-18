using UserMorph.Core.DTOs.PersistenceModels;
namespace UserMorph.Core.Interfaces.Persistence
{
    public interface IUserJsonRepository
    {
        void UpdateUser(List<User> users);
        void DeleteUser(List<User> users);
        void CreateUser(List<User> users);
    }
}
