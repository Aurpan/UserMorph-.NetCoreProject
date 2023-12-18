using UserMorph.Core.DTOs.DomainModels;
using UserMorph.Core.Enums;

namespace UserMorph.Core.Interfaces.Domain
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(DataSourceType sourceType, string searchText);
        User GetUserDetailsById(int id, DataSourceType sourceType);
        void UpdateUser(User user);
        void CreateUser(User user);
        void DeleteUser(int userId);


    }
}